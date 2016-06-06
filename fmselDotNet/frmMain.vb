Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text.Encoding
Imports System.Collections.Specialized
Imports System.Data.SQLite
Imports SevenZip

Public Class frmMain
    Inherits Form

    Dim ico As System.Drawing.Icon = Nothing
    Dim WithEvents cbMaxCash As CheckBox

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
#If DEBUG Then
        'CultureInfo.CurrentCulture = New CultureInfo("el-GR")
#End If
        Application.EnableVisualStyles()
        ico = System.Drawing.Icon.ExtractAssociatedIcon(Process.GetCurrentProcess.MainModule.FileName)
        Icon = ico
        btnPlay.Image = ico.ToBitmap
        Text = GameName & " Fan Mission Selector"
        LoadFMSelCfg()
        InitializeDb()

        gridFMs.Columns.RemoveAt(cols.Rating)
        gridFMs.Columns.Insert(cols.Rating, New RatingColumn With {.HeaderText = "Rating", .DataPropertyName = .HeaderText, .Name = "colRating", .SortMode = DataGridViewColumnSortMode.Automatic})
        gridFMs.DataSource = dvMissions
        UpdateCounts()

        mnuOnlyGameMissions.Text = String.Format(mnuOnlyGameMissions.Text, GameVersion)
        mnuAllMissions.Checked = ViewAllMissions
        mnuOnlyGameMissions.Checked = Not ViewAllMissions
        gridFMs.Columns.Item(cols.Ver).Visible = ViewAllMissions

        cboGamesys.Items.Clear()
        cboGamesys.Visible = False
        If Not (File.Exists(GamePath & "\TFix_readme.txt") Or Directory.Exists(GamePath & "\Tafferpatcher")) Then
            If GameVersion = "SS2" Or GameVersion = "T1" Or GameVersion = "T2" Then
                cboGamesys.Items.AddRange(GetGamesysFileList)
                cboGamesys.SelectedIndex = 0
                cboGamesys.Visible = True
            End If
        End If

        If GameVersion = "T1" Then
            For Each s As String In My.Settings.T1OrigMissions
                btnPlayOriginalMissions.DropDownItems.Add(s)
                mnuPlayOriginalMissions.DropDownItems.Add(s)
            Next
        ElseIf GameVersion = "T2" Then
            For Each s As String In My.Settings.T2OrigMissions
                btnPlayOriginalMissions.DropDownItems.Add(s)
                mnuPlayOriginalMissions.DropDownItems.Add(s)
            Next
        End If

        If GameVersion = "T1" Or GameVersion = "T2" Then
            'Add checkbox to status strip
            cbMaxCash = New CheckBox With {.Text = "Max Cash"}
            Dim tsItem As New ToolStripControlHost(cbMaxCash) With {.Alignment = ToolStripItemAlignment.Right}
            ToolStrip1.Items.Add(tsItem)
            mnuMaxCash.Visible = True
        End If

        AddHandler dtMissions.RowChanged, AddressOf dtMissions_RowChanged
        AddHandler dvMissions.ListChanged, Sub(sndr As Object, ee As ListChangedEventArgs) UpdateCounts()
        AddHandler fmselSync.SyncInfo, AddressOf SyncInfoEventHandler
    End Sub

    Private Sub txtFilter_Enter(sender As Object, e As EventArgs) Handles txtFilter.Enter
        txtFilter.BackColor = Drawing.Color.LightYellow
    End Sub

    Private Sub txtFilter_Leave(sender As Object, e As EventArgs) Handles txtFilter.Leave
        txtFilter.BackColor = Nothing
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        gridFMs.ClearSelection()
        Dim ss As String() = txtFilter.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim fltr As String = "("
        If Not ViewAllMissions Then fltr = "(Ver = '" & GameVersion & "') AND " & fltr
        If ss.Count > 0 Then
            For Each s As String In ss
                fltr &= "(Filename LIKE '%" & s.SQLify & "%' OR MissionName LIKE '%" & s.SQLify & "%' OR Author LIKE '%" & s.SQLify & "%' OR FileTypes LIKE '%" & s & "%') AND "
            Next
        Else
            fltr &= "1=1"
        End If
        fltr = fltr.TrimEnd({" "c, "D"c, "N"c, "A"c}) & ")"
        dvMissions.RowFilter = fltr
        txtFilter.Focus()
    End Sub

    Private Sub mnuExitGame_Click(sender As Object, e As EventArgs) Handles mnuExitGame.Click
        gridFMs.EndEdit()
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        With New AboutBox1
            .ShowDialog()
        End With
    End Sub

    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem1.Click
        With New dlgSettings
            If .ShowDialog(Me) = DialogResult.OK Then
                LoadFMSelCfg()
            End If
        End With
    End Sub

    Private Async Sub btnPlay_ButtonClick(sender As Object, e As EventArgs) Handles btnPlay.ButtonClick, mnuPlayFanMission.Click
        gridFMs.EndEdit()
        Await Task.Run(Sub()
                           If gridFMs.SelectedCells.Count > 0 Then
                               With CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)
                                   If .Cells(cols.Ver).Value = GameVersion Then
                                       Dim sourceZip As String = .Cells(cols.Directory).Value.ToString & "\" & .Cells(cols.FileName).Value.ToString
                                       Dim destFldr As String = ""
                                       If FMRootPath = "" Then
                                           destFldr = ".\FMs\" & .Cells(cols.InstallFolder).Value.ToString
                                       Else
                                           destFldr = FMRootPath & "\" & .Cells(cols.InstallFolder).Value.ToString
                                       End If
                                       If destFldr.StartsWith(".\") Then
                                           destFldr = GamePath & destFldr.Substring(1)
                                       End If
                                       If Not Directory.Exists(destFldr) Then
                                           If File.Exists(sourceZip) Then
                                               Try
                                                   Directory.CreateDirectory(destFldr)
                                                   UnzipMission(sourceZip, destFldr)
                                                   SelectedFM = .Cells(cols.InstallFolder).Value.ToString
                                                   FMSelReturnValue = eFMSelReturn.kSelFMRet_OK
                                                   Close()
                                               Catch ex As Exception
                                                   If Directory.Exists(destFldr) Then
                                                       Directory.Delete(destFldr, True)
                                                   End If
                                                   MsgBox("Error launching fan mission. Error was: " & ex.Message)
                                               End Try
                                           Else
                                               MsgBox("Source zip file not found. Can't launch fan mission.", MsgBoxStyle.Critical)
                                           End If
                                       Else
                                           SelectedFM = .Cells(cols.InstallFolder).Value.ToString
                                           ApplyMaxCash(.Cells(cols.InstallFolder).Value.ToString)
                                           ApplyCustomGameSys(.Cells(cols.InstallFolder).Value.ToString)
                                           FMSelReturnValue = eFMSelReturn.kSelFMRet_OK
                                           Close()
                                       End If
                                   Else
                                       MsgBox("The selected mission is a " & .Cells(cols.Ver).Value & " mission. It cannot run in " & GameName, MsgBoxStyle.Information)
                                   End If
                               End With
                           End If
                       End Sub)
    End Sub

    Private UnzipDestFolder As String = ""
    Private Sub UnzipMission(sourceZip As String, destFldr As String)
        UnzipDestFolder = destFldr

        ToolStrip1.BeginInvoke(Sub()
                                   lblSyncProg.Text = ""
                                   pbSyncProg.Value = 0
                                   pbSyncProg.Visible = True
                                   lblSyncProg.Visible = True
                                   btnSync.Visible = False
                               End Sub)

        Using sze As New SevenZipExtractor(sourceZip)
            AddHandler sze.FileExtractionStarted, AddressOf sze_FileExtractionStarted
            AddHandler sze.FileExtractionFinished, AddressOf sze_FileExtractionFinished
            sze.ExtractArchive(destFldr)
            RemoveHandler sze.FileExtractionStarted, AddressOf sze_FileExtractionStarted
            RemoveHandler sze.FileExtractionFinished, AddressOf sze_FileExtractionFinished
        End Using

        ToolStrip1.BeginInvoke(Sub()
                                   lblSyncProg.Visible = False
                                   pbSyncProg.Visible = False
                                   btnSync.Visible = True
                               End Sub)
    End Sub

    Private Sub ApplyMaxCash(Optional SelectedFM As String = "")
        If GameVersion = "T1" Or GameVersion = "T2" Then
            Dim UserCfgData As String = File.ReadAllText(GamePath & "\User.cfg")
            If SelectedFM = "" Then
                Dim TargetCfgData As String = GamePath & "\User.cfg"
                If cbMaxCash.Checked Then
                    If Not File.Exists(TargetCfgData & ".bak") Then File.WriteAllText(TargetCfgData & ".bak", UserCfgData)
                    UserCfgData = "cash_bonus " & If(GameVersion = "T1", "99999", "1500") & vbCrLf & UserCfgData
                    File.WriteAllText(TargetCfgData, UserCfgData)
                Else
                    If File.Exists(TargetCfgData & ".bak") Then
                        File.Copy(TargetCfgData & ".bak", TargetCfgData, True)
                    End If
                End If
            Else
                Dim TargetCfgData As String = FMRootPath & "\" & SelectedFM & "\User.cfg"
                If cbMaxCash.Checked Then
                    UserCfgData = "cash_bonus " & If(GameVersion = "T1", "99999", "1500") & vbCrLf & UserCfgData
                    File.WriteAllText(TargetCfgData, UserCfgData)
                Else
                    If File.Exists(TargetCfgData) Then File.Delete(TargetCfgData)
                End If
            End If
        End If
    End Sub

    Private Sub ApplyCustomGameSys(SelectedFM As String)
        If GameVersion <> "T3" AndAlso cboGamesys.SelectedIndex > -1 Then
            Dim CustomGamesys As String = AppPath & "\CustomGamesys\" & cboGamesys.SelectedItem.ToString
            Dim TargetGamesys As String = If(SelectedFM = "", GamePath, FMRootPath & "\" & SelectedFM) & "\dark.gam"
            If cboGamesys.SelectedItem.ToString = "None" Then
                If File.Exists(TargetGamesys) AndAlso File.Exists(TargetGamesys & ".bak") Then
                    File.Copy(TargetGamesys & ".bak", TargetGamesys, True)  'User chose None so restore original gamesys file.
                ElseIf Not TargetGamesys.Contains(GamePath) AndAlso File.Exists(TargetGamesys) Then
                    File.Delete(TargetGamesys)  'delete dark.gam from fan mission only.
                End If
            Else
                If File.Exists(TargetGamesys) AndAlso Not File.Exists(TargetGamesys & ".bak") Then File.Copy(TargetGamesys, TargetGamesys & ".bak")
                File.Copy(CustomGamesys, TargetGamesys, True)
            End If
        End If
    End Sub

    Private Sub btnPlayOriginalMissions_Click(sender As Object, e As EventArgs) Handles btnPlayOriginalMissions.Click, mnuPlayOriginalMissions.Click
        gridFMs.EndEdit()
        ApplyMaxCash()
        FMSelReturnValue = eFMSelReturn.kSelFMRet_Cancel
        Close()
    End Sub

    Private Sub btnPlayOriginalMissions_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles btnPlayOriginalMissions.DropDownItemClicked, mnuPlayOriginalMissions.DropDownItemClicked
        Dim MissionIndex As Integer = e.ClickedItem.Text.Substring(0, 2).Trim
        gridFMs.EndEdit()
        ApplyMaxCash()
        Dim UserCfgData As String = File.ReadAllText(GamePath & "\User.cfg")
        UserCfgData = "starting_mission " & MissionIndex & vbCrLf & UserCfgData
        File.WriteAllText(GamePath & "\User.cfg", UserCfgData)
        FMSelReturnValue = eFMSelReturn.kSelFMRet_Cancel
        Close()
    End Sub

    Private Sub grid_DragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub grid_DragDrop(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Display the file Name
            'TextBoxDrop.Text = MyFiles(0)
            ' Display the file contents
            MsgBox(MyFiles(0))
        End If
    End Sub

    Private Sub SyncInfoEventHandler(sender As Object, e As SyncInfoEventArgs)
        If e.Index < e.FileCount - 1 Then
            ToolStrip1.BeginInvoke(Sub()
                                       btnSync.Visible = False
                                       pbSyncProg.Visible = True
                                       pbSyncProg.Maximum = e.FileCount - 1
                                       pbSyncProg.Value = If(e.Index < 0, 0, e.Index)
                                       lblSyncProg.Visible = True
                                       lblSyncProg.Text = "(" & e.Index + 1 & " of " & e.FileCount & ") " & e.Filename
                                       AddDataRow(e.mi)
                                       UpdateCounts()
                                   End Sub)
        Else
            ToolStrip1.BeginInvoke(Sub()
                                       pbSyncProg.Visible = False
                                       lblSyncProg.Visible = False
                                       btnSync.Visible = True
                                       AddDataRow(e.mi)
                                       UpdateCounts()
                                       AddHandler dtMissions.RowChanged, AddressOf dtMissions_RowChanged
                                   End Sub)
        End If
    End Sub

    Private Sub AddDataRow(mi As BoycoT.TFMM.MissionInfo)
        If mi.ArchiveFile IsNot Nothing Then
            Dim dr As DataRow = dtMissions.NewRow
            dr("rowid") = mi.rowid
            dr("Ver") = mi.Game.ToString
            dr("Filename") = mi.ArchiveFile.Name
            dr("FileSize") = mi.ArchiveFile.Length
            dr("MissionName") = mi.Title
            dr("Author") = mi.Author
            dr("ReleaseDate") = mi.ReleaseDate
            dr("Rating") = 0
            dr("Completed") = "No"
            dr("FileTypes") = mi.FileTypes
            dr("Directory") = mi.ArchiveFile.DirectoryName
            dr("InstallFolder") = mi.InstallDirName
            dtMissions.Rows.Add(dr)
            dtMissions.AcceptChanges()
        End If
    End Sub

    Private Sub gridFMs_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridFMs.CellFormatting
        Select Case e.ColumnIndex
            Case cols.Ver
                e.Value = If(My.Resources.ResourceManager.GetObject(e.Value & vbNullString), My.Resources.err)
            Case cols.FileSize
                e.Value = FormatFileSize(e.Value)
            Case cols.Released
                If e.Value IsNot Nothing Then
                    If IsDate(e.Value.ToString) Then
                        e.Value = CDate(e.Value).ToString("d", CultureInfo.CurrentCulture)
                    End If
                End If
        End Select
    End Sub

    Private Sub UpdateCounts()
        lblTotalMissionFiles.Text = TotalRowCount.ToString("N0", CultureInfo.CurrentCulture)
        lblTotalDisplayed.Text = FilteredRowCount.ToString("N0", CultureInfo.CurrentCulture)
    End Sub

    Dim lastRowId As Integer = -1
    Dim lastRow As Integer = -1
    Private Sub gridFMs_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridFMs.CellClick
        If gridFMs.SelectedCells.Count > 0 AndAlso gridFMs.SelectedCells(0).RowIndex <> lastRow Then
            If UserNoteDirty Then
                Dim tp As TabPage = tabsDocs.TabPages.Item(tabsDocs.TabPages.Count - 1)
                Dim txt As TextBox = tp.Controls.Item(0)
                SaveUserNote(lastRowId, txt.Text)
                UserNoteDirty = False
            End If
            lastRow = gridFMs.SelectedCells(0).RowIndex
            lastRowId = If(IsDBNull(gridFMs.Rows(lastRow).Cells(0).Value), -1, (gridFMs.Rows(lastRow).Cells(0).Value))
            With CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)
                If Not IsDBNull(.Cells(0).Value) Then
                    Dim nv As NameValueCollection = SelectInfoFiles(CInt(.Cells(0).Value))
                    UpdateInfoTabs(lastRowId, nv)
                End If
            End With
        End If
    End Sub

    Dim UserNoteDirty As Boolean = False
    Private Sub UpdateInfoTabs(rowid As Integer, nv As NameValueCollection)
        tabsDocs.TabPages.Clear()
        For Each key As String In nv
            Dim tp As New TabPage(key)
            Select Case key.ToLower.Substring(key.LastIndexOf("."c))
                Case ".txt", ".glml"
                    Dim t As New TextBox With {.Multiline = True, .Dock = DockStyle.Fill, .ReadOnly = True, .Parent = tp, .ScrollBars = ScrollBars.Vertical, .WordWrap = True, .Text = nv(key)}
                Case ".rtf"
                    Dim r As New RichTextBox With {.Dock = DockStyle.Fill, .ReadOnly = True, .Parent = tp, .ScrollBars = RichTextBoxScrollBars.Vertical, .WordWrap = True, .Rtf = nv(key)}
                Case ".htm", ".html"
                    Dim b As New WebBrowser With {.Dock = DockStyle.Fill, .DocumentText = nv(key), .Parent = tp}
            End Select
            tabsDocs.TabPages.Add(tp)
        Next
        Dim tpUserNotes As New TabPage("UserNotes")
        Dim txtUserNotes As New TextBox With {.Multiline = True, .Dock = DockStyle.Fill, .Parent = tpUserNotes, .ScrollBars = ScrollBars.Vertical, .WordWrap = True}
        txtUserNotes.Text = GetUserNotesFromDb(rowid)
        AddHandler txtUserNotes.TextChanged, Sub() UserNoteDirty = True
        tabsDocs.TabPages.Add(tpUserNotes)
    End Sub

    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        RemoveHandler dtMissions.RowChanged, AddressOf dtMissions_RowChanged
        btnSync.Visible = False
        SyncMissionFolders()
    End Sub

    Private Function GetGamesysFileList() As String()
        Dim lst As New List(Of String)
        For Each fi As FileInfo In New DirectoryInfo(AppPath & "\CustomGamesys").GetFiles
            If fi.Name.ToUpper.StartsWith(GameVersion) Then
                lst.Add(fi.Name)
            End If
        Next
        lst.Sort()
        lst.Insert(0, "None")
        Return lst.ToArray
    End Function

    Private Sub mnuMissions_Click(sender As Object, e As EventArgs) Handles mnuAllMissions.Click, mnuOnlyGameMissions.Click
        Dim mi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If mi.Name = "mnuAllMissions" Then
            mnuAllMissions.Checked = True
            mnuOnlyGameMissions.Checked = False
            ViewAllMissions = True
        Else
            mnuAllMissions.Checked = False
            mnuOnlyGameMissions.Checked = True
            ViewAllMissions = False
        End If
        txtFilter_TextChanged(Nothing, Nothing)
        gridFMs.Columns.Item(cols.Ver).Visible = ViewAllMissions
        SaveFMSelCfg()
    End Sub

    Private Sub ShowGameInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowGameInfoToolStripMenuItem.Click
        Dim gInfo As String =
        "AppPath: " & AppPath & vbCrLf &
        "GamePath: " & GamePath & vbCrLf &
        "GameVerRaw: " & GameVersionRaw & vbCrLf &
        "GameVer: " & GameVersion & vbCrLf &
        "GameName: " & GameName & vbCrLf &
        "FMRootPath: " & FMRootPath & vbCrLf
        MsgBox(gInfo)
    End Sub

    Private Sub gridFMs_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridFMs.CellDoubleClick
        Select Case e.ColumnIndex
            Case cols.Directory
                Process.Start(gridFMs.Item(cols.Directory, e.RowIndex).Value.ToString)
            Case cols.FileName
                Process.Start(gridFMs.Item(cols.Directory, e.RowIndex).Value.ToString & "\" & gridFMs.Item(cols.FileName, e.RowIndex).Value.ToString)
            Case cols.InstallFolder
                Dim InstPath As String = CStr(FMRootPath & vbNullString).Trim
                If InstPath = "" Or InstPath.StartsWith(".\FMs") Then InstPath = GamePath & "\FMs"
                InstPath &= "\" & gridFMs.Item(cols.InstallFolder, e.RowIndex).Value.ToString
                If Directory.Exists(InstPath) Then
                    Process.Start(InstPath)
                Else
                    MsgBox("This mission is either not installed, or it is not a " & GameName & " mission.", vbInformation)
                End If
            Case cols.Ver
                With New dlgGameVer(gridFMs.CurrentCell.Value)
                    If .ShowDialog = DialogResult.OK Then
                        Dim dr As DataRow = dtMissions.Select("rowid=" & gridFMs.Rows(gridFMs.SelectedCells(0).RowIndex).Cells(0).Value)(0)
                        dr.Item("Ver") = .SelectedValue
                    End If
                End With
        End Select
    End Sub

    Private Sub mnuMaxCash_Click(sender As Object, e As EventArgs) Handles mnuMaxCash.Click
        cbMaxCash.Checked = mnuMaxCash.Checked
    End Sub
    Private Sub cbMaxCash_Click(sender As Object, e As EventArgs) Handles cbMaxCash.Click
        mnuMaxCash.Checked = cbMaxCash.Checked
    End Sub

#Region "SevenZip Event Handlers"

    'Private Sub sze_Extracting(sender As Object, e As SevenZip.ProgressEventArgs) 'Handles sze.Extracting
    '    'This returns percentages of large files extracted. Not needed here.
    'End Sub

    'Private Sub szs_ExtractionFinished(sender As Object, e As EventArgs) 'Handles sze.ExtractionFinished
    '    'This is called when all files have been extracted. Not needed here.
    'End Sub

    'Private Sub sze_FileExists(sender As Object, e As FileOverwriteEventArgs) 'Handles sze.FileExists
    'End Sub

    Private Sub sze_FileExtractionFinished(sender As Object, e As FileInfoEventArgs) 'Handles sze.FileExtractionFinished
        If GameVersion <> "T3" Then    'no decoding necessary for TDS
            Dim fi As New FileInfo(UnzipDestFolder & "\" & e.FileInfo.FileName)
            Select Case fi.Extension.ToLower
                Case ".mp3", ".ogg" : ConvertToWav(fi)
            End Select
        End If
        ToolStrip1.BeginInvoke(Sub()
                                   pbSyncProg.Value = CInt(e.PercentDone)
                               End Sub)
    End Sub

    Private Sub sze_FileExtractionStarted(sender As Object, e As FileInfoEventArgs) 'Handles sze.FileExtractionStarted
        ToolStrip1.BeginInvoke(Sub()
                                   pbSyncProg.Value = CInt(e.PercentDone)
                                   lblSyncProg.Text = e.FileInfo.FileName
                               End Sub)
    End Sub

#End Region

End Class