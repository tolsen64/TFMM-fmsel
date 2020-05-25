Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization
Imports System.ComponentModel
Imports System.Collections.Specialized
Imports SevenZip
Imports System.Drawing

Public Class frmMain
    Inherits Form

    Dim WithEvents cbMaxCash As CheckBox
    Dim WithEvents cbReturnToTFMM As CheckBox
    Dim WithEvents cbOpenMissionNotes As CheckBox
    Private Const UserCfg As String = "USER.CFG"

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
#If DEBUG Then
        'CultureInfo.CurrentCulture = New CultureInfo("el-GR")
#End If
        If Not Directory.Exists(logDir) Then Directory.CreateDirectory(logDir)
        log("frmMain_Load")
        Application.EnableVisualStyles()
        Icon = System.Drawing.Icon.ExtractAssociatedIcon(Process.GetCurrentProcess.MainModule.FileName)
        btnPlay.Image = GetIcon(GameVersion)
        mnuPlayFanMission.Image = GetIcon(GameVersion)
        cmnuPlayFanMission.Image = GetIcon(GameVersion)
        btnPlayOriginalMissions.Image = GetIcon(GameVersion)
        mnuPlayOriginalMissions.Image = GetIcon(GameVersion)
        cmnuPlayOriginalMissions.Image = GetIcon(GameVersion)
        Text = GameName & " Fan Mission Selector"

        If Not File.Exists(cfgFile) Then SettingsToolStripMenuItem1_Click(Nothing, Nothing)
        LoadFMSelCfg()
        InitializeDb()

        ImportMissionNotes()

        gridFMs.Columns.RemoveAt(cols.Rating)
        gridFMs.Columns.Insert(cols.Rating, New RatingColumn With {.HeaderText = "Rating", .DataPropertyName = .HeaderText, .Name = "colRating", .SortMode = DataGridViewColumnSortMode.Automatic})
        gridFMs.DataSource = dvMissions
        UpdateCounts()

        mnuOnlyGameMissions.Text = String.Format(mnuOnlyGameMissions.Text, GameVersion)
        mnuAllMissions.Checked = ViewAllMissions
        mnuOnlyGameMissions.Checked = Not ViewAllMissions
        gridFMs.Columns.Item(cols.Ver).Visible = ViewAllMissions

        log("GameVersion: " & GameVersion)
        If GameVersion = "T1" Then
            For Each s As String In My.Settings.T1OrigMissions
                btnPlayOriginalMissions.DropDownItems.Add(s)
                mnuPlayOriginalMissions.DropDownItems.Add(s)
                cmnuPlayOriginalMissions.DropDownItems.Add(s)
            Next
        ElseIf GameVersion = "T2" Then
            For Each s As String In My.Settings.T2OrigMissions
                btnPlayOriginalMissions.DropDownItems.Add(s)
                mnuPlayOriginalMissions.DropDownItems.Add(s)
                cmnuPlayOriginalMissions.DropDownItems.Add(s)
            Next
        End If

        If GameVersion = "T1" Or GameVersion = "T2" Then
            'Add checkbox to status strip
            cbMaxCash = New CheckBox With {.Text = "Max Cash"}
            ToolStrip1.Items.Add(New ToolStripControlHost(cbMaxCash) With {.Alignment = ToolStripItemAlignment.Right})
            mnuMaxCash.Visible = True
            MakeBakup(Path.Combine(GamePath, UserCfg))
        End If

        cbReturnToTFMM = New CheckBox With {.Text = "Return to TFMM"}
        ToolStrip1.Items.Add(New ToolStripControlHost(cbReturnToTFMM) With {.Alignment = ToolStripItemAlignment.Right})

        cbOpenMissionNotes = New CheckBox With {.Text = "Open Mission Notes"}
        ToolStrip1.Items.Add(New ToolStripControlHost(cbOpenMissionNotes) With {.Alignment = ToolStripItemAlignment.Right})

        SetMenuItemVisibility()

        If gridFMs.RowCount > 0 Then
            gridFMs.Item(cols.FileName, 0).Selected = True
            gridFMs_CellClick(Nothing, New DataGridViewCellEventArgs(cols.FileName, 0))
        End If

        AddHandler dtMissions.RowChanged, AddressOf dtMissions_RowChanged
        AddHandler dvMissions.ListChanged, Sub(sndr As Object, ee As ListChangedEventArgs) UpdateCounts()
        AddHandler fmselSync.SyncInfo, AddressOf SyncInfoEventHandler
    End Sub

    Private Sub SetMenuItemVisibility()
        For Each mi As ToolStripMenuItem In SwitchGameToolStripMenuItem.DropDownItems
            mi.Visible = Not mi.Name.StartsWith(GameVersion)
        Next
        cbReturnToTFMM.Checked = ReturnToTFMMDefault
        mnuReturnToTFMM.Checked = ReturnToTFMMDefault
        cbOpenMissionNotes.Checked = OpenMissionNotesDefault
        mnuOpenMissionNotes.Checked = OpenMissionNotesDefault
        If cbMaxCash IsNot Nothing Then
            cbMaxCash.Checked = MaxCashDefault
            mnuMaxCash.Checked = MaxCashDefault
        End If
    End Sub

    Private Sub SwitchGame(sender As Object, e As EventArgs) Handles SS2ToolStripMenuItem.Click, T1GoldToolStripMenuItem.Click, T2ToolStripMenuItem.Click, T3ToolStripMenuItem.Click
        Dim si As New ProcessStartInfo
        Dim fi As FileInfo = Nothing
        With CType(sender, ToolStripMenuItem)
            Select Case .Name.Substring(0, 2)
                Case "SS" : If SS2GameExe <> "" Then fi = New FileInfo(SS2GameExe)
                Case "T1" : If T1GameExe <> "" Then fi = New FileInfo(T1GameExe)
                Case "T2" : If T2GameExe <> "" Then fi = New FileInfo(T2GameExe)
                Case "T3" : If T3GameExe <> "" Then fi = New FileInfo(T3GameExe)
            End Select
        End With
        If fi IsNot Nothing Then
            si.FileName = fi.Name
            si.WorkingDirectory = fi.DirectoryName
            Process.Start(si)
            Close()
        Else
            MsgBox("Configure Game EXE's in settings.", vbExclamation)
        End If
    End Sub

    Private Sub MakeBakup(Filename As String)
        With New FileInfo(Filename)
            If File.Exists(.FullName.bak) Then
                File.Copy(.FullName.bak, .FullName, True)
            ElseIf File.Exists(.FullName) Then
                If File.Exists(.FullName.tfmm) Then
                    File.Delete(.FullName)
                Else
                    File.Copy(.FullName, .FullName.bak, True)
                End If
            Else
                File.WriteAllText(.FullName.tfmm, "This file was added by TFMM and is a flag indicating that " & .Name & " was added by TFMM and should be deleted. Make sense?")
            End If
        End With
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
        log("mnuExitGame_Click")
        gridFMs.EndEdit()
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        log("AboutToolStripMenuItem_Click")
        With New AboutBox1
            .ShowDialog()
        End With
    End Sub

    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem1.Click
        log("SettingsToolStripMenuItem1_Click")
        With New dlgSettings
            If .ShowDialog(Me) = DialogResult.OK Then
                LoadFMSelCfg()
                SetMenuItemVisibility()
            End If
        End With
    End Sub

    Private Async Sub btnPlay_ButtonClick(sender As Object, e As EventArgs) Handles btnPlay.ButtonClick, mnuPlayFanMission.Click, cmnuPlayFanMission.Click
        Dim name As String = If(TypeOf sender Is ToolStripSplitButton, CType(sender, ToolStripSplitButton).Name, CType(sender, ToolStripMenuItem).Name)
        log("btnPlay_ButtonClick (" & name & ")")
        gridFMs.EndEdit()
        Await Task.Run(Sub()
                           If gridFMs.SelectedCells.Count > 0 Then
                               With CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)
                                   If .Cells(cols.Ver).Value = GameVersion Then
                                       If cbOpenMissionNotes.Checked Then OpenMissionNotes(lastRowId)
                                       Dim sourceZip As String = Path.Combine(.Cells(cols.Directory).Value.ToString, .Cells(cols.FileName).Value.ToString)
                                       Dim destFldr As String = Path.Combine(FMRootPath, .Cells(cols.InstallFolder).Value.ToString)
                                       If Not Directory.Exists(destFldr) Then
                                           If File.Exists(sourceZip) Then
                                               Try
                                                   Directory.CreateDirectory(destFldr)
                                                   UnzipMission(sourceZip, destFldr)
                                               Catch ex As Exception
                                                   If Directory.Exists(destFldr) Then
                                                       Directory.Delete(destFldr, True)
                                                   End If
                                                   MsgBox("Error launching fan mission. Error was: " & ex.Message)
                                                   Exit Sub
                                               End Try
                                           Else
                                               MsgBox("Source zip file not found. Can't launch fan mission.", MsgBoxStyle.Critical)
                                               Exit Sub
                                           End If
                                       End If
                                       MakeBakup(Path.Combine(destFldr, UserCfg))
                                       ApplyMaxCash(Path.Combine(destFldr, UserCfg))
                                       SelectedFM = .Cells(cols.InstallFolder).Value.ToString
                                       RunAfterGameExit = cbReturnToTFMM.Checked
                                       FMSelReturnValue = eFMSelReturn.kSelFMRet_OK
                                       Close()
                                   Else
                                       MsgBox("The selected mission is a " & .Cells(cols.Ver).Value.ToString & " mission. It cannot run in " & GameName, MsgBoxStyle.Information)
                                   End If
                               End With
                           End If
                       End Sub)
    End Sub

    Private UnzipDestFolder As String = ""
    Private Sub UnzipMission(sourceZip As String, destFldr As String)
        log("UnzipMission(""" & sourceZip & ", """ & destFldr & """")
        UnzipDestFolder = destFldr

        ToolStrip1.BeginInvoke(Sub()
                                   lblSyncProg.Text = "Preparing to install fan mission."
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

        'If this is a "dromed only" mission (contains only .mis files), then we set it up to play normally in Thief.
        If GameVersion = "T1" Or GameVersion = "T2" Then
            If Not File.Exists(Path.Combine(destFldr, "strings", "missflag.str")) Then
                Dim newMisNum As Integer = 19
                Dim di As New DirectoryInfo(destFldr)
                For Each fi As FileInfo In di.GetFiles("*.mis")
                    newMisNum += 1
                    fi.MoveTo(Path.Combine(fi.DirectoryName, "miss" & newMisNum.ToString & ".mis"))
                Next
                If Not Directory.Exists(Path.Combine(destFldr, "strings")) Then Directory.CreateDirectory(Path.Combine(destFldr, "strings"))
                Using sw As New StreamWriter(Path.Combine(destFldr, "strings", "missflag.str"))
                    For i As Integer = 1 To 19
                        sw.WriteLine("miss_" & i.ToString & ": ""skip""")
                    Next
                    For i As Integer = 20 To newMisNum
                        sw.Write("miss_" & i.ToString & ": ""no_briefing, no_loadout")
                        sw.WriteLine(IIf(i = newMisNum, ", end""", """"))
                    Next
                    sw.Close()
                End Using
                For Each fi As FileInfo In di.GetFiles("*.str")
                    If Not Directory.Exists(Path.Combine(destFldr, "books")) Then Directory.CreateDirectory(Path.Combine(destFldr, "books"))
                    fi.MoveTo(Path.Combine(destFldr, "books", fi.Name))
                Next
            End If
        End If

        With New FileInfo(sourceZip)
            If File.Exists(.FullName.Replace(.Extension, ".saves")) Then
                Using sze As New SevenZipExtractor(.FullName.Replace(.Extension, ".saves"))
                    sze.ExtractArchive(Path.Combine(destFldr, If(GameVersion = "T3", "SaveGames", "")))
                End Using
            End If
        End With

        ToolStrip1.BeginInvoke(Sub()
                                   lblSyncProg.Visible = False
                                   pbSyncProg.Visible = False
                                   btnSync.Visible = True
                               End Sub)
    End Sub

    Private Sub ZipSaves()
        log("ZipSaves")
        Dim lst As New List(Of String)
        If GameVersion = "SS2" Then
            For Each di As DirectoryInfo In New DirectoryInfo(Path.Combine(FMRootPath, GetGridValue(cols.InstallFolder))).GetDirectories("save_*")
                For Each fi As FileInfo In di.GetFiles()
                    lst.Add(fi.FullName)
                Next
            Next
        ElseIf GameVersion = "T3" Then
            For Each fi As FileInfo In New DirectoryInfo(Path.Combine(FMRootPath, GetGridValue(cols.InstallFolder), "SaveGames")).GetFiles("*.*", SearchOption.AllDirectories)
                lst.Add(fi.FullName)
            Next
        Else
            For Each fi As FileInfo In New DirectoryInfo(Path.Combine(FMRootPath, GetGridValue(cols.InstallFolder))).GetFiles("*.sav", SearchOption.AllDirectories)
                lst.Add(fi.FullName)
            Next
        End If
        Dim savfi As New FileInfo(GetGridValue(cols.FileName))
        Dim tmp As String = ""
        For Each s As String In lst
            tmp &= s & vbCrLf
        Next
        If lst.Count > 0 Then
            With New SevenZipCompressor(Path.Combine(AppPath, "tmp.zip"))
                .ArchiveFormat = OutArchiveFormat.SevenZip
                .CompressFiles(Path.Combine(GetGridValue(cols.Directory), savfi.Name.Replace(savfi.Extension, ".saves")), lst.ToArray)
            End With
        End If
    End Sub

    Private Sub ApplyMaxCash(UserCfgFile As String)
        log("ApplyMaxCash(""" & UserCfgFile & """)")
        If (GameVersion = "T1" Or GameVersion = "T2") AndAlso cbMaxCash.Checked Then
            Dim UserCfgData As String = ""
            If File.Exists(UserCfgFile) Then UserCfgData = File.ReadAllText(UserCfgFile)
            UserCfgData = "cash_bonus " & If(GameVersion = "T1", "99999", "1500") & vbCrLf & UserCfgData
            File.WriteAllText(UserCfgFile, UserCfgData)
        End If
    End Sub

    Private Sub btnUninstallFanMission_Click(sender As Object, e As EventArgs) Handles btnUninstallFanMission.Click, mnuUninstallFanMission.Click, cmnuUninstallFanMission.Click
        Dim name As String = If(TypeOf sender Is ToolStripSplitButton, CType(sender, ToolStripSplitButton).Name, CType(sender, ToolStripMenuItem).Name)
        log("btnUninstallFanMission_Click (" & name & ")")
        Dim MissionName As String = GetGridValue(cols.MissionName)
        If MissionName = "" Then MissionName = GetGridValue(cols.FileName)
        If MsgBox("Uninstall " & MissionName & "?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ZipSaves()
        End If
        Directory.Delete(Path.Combine(FMRootPath, GetGridValue(cols.InstallFolder)), True)
        MsgBox(MissionName & " is uninstalled.", MsgBoxStyle.Information)
    End Sub

    Private Sub btnPlayOriginalMissions_Click(sender As Object, e As EventArgs) Handles btnPlayOriginalMissions.Click, mnuPlayOriginalMissions.Click, cmnuPlayOriginalMissions.Click
        Dim name As String = If(TypeOf sender Is ToolStripSplitButton, CType(sender, ToolStripSplitButton).Name, CType(sender, ToolStripMenuItem).Name)
        log("btnPlayOriginalMissions_Click (" & name & ")")
        gridFMs.EndEdit()
        ApplyMaxCash(Path.Combine(GamePath, UserCfg))
        FMSelReturnValue = eFMSelReturn.kSelFMRet_Cancel
        Close()
    End Sub

    Private Sub btnPlayOriginalMissions_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles btnPlayOriginalMissions.DropDownItemClicked, mnuPlayOriginalMissions.DropDownItemClicked, cmnuPlayOriginalMissions.DropDownItemClicked
        Dim name As String = If(TypeOf sender Is ToolStripSplitButton, CType(sender, ToolStripSplitButton).Name, CType(sender, ToolStripMenuItem).Name)
        log("btnPlayOriginalMissions_DropDownItemClick (" & name & ") : " & e.ClickedItem.Text)
        Dim MissionIndex As Integer = e.ClickedItem.Text.Substring(0, 2).Trim
        gridFMs.EndEdit()
        ApplyMaxCash(Path.Combine(GamePath, UserCfg))
        Dim UserCfgData As String = File.ReadAllText(Path.Combine(GamePath, UserCfg))
        UserCfgData = "starting_mission " & MissionIndex & vbCrLf & UserCfgData
        File.WriteAllText(Path.Combine(GamePath, UserCfg), UserCfgData)
        FMSelReturnValue = eFMSelReturn.kSelFMRet_Cancel
        Close()
    End Sub

    'Private Sub grid_DragEnter(sender As Object, e As DragEventArgs)
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        e.Effect = DragDropEffects.All
    '    End If
    'End Sub

    'Private Sub grid_DragDrop(sender As Object, e As DragEventArgs)
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        Dim MyFiles() As String
    '        ' Assign the files to an array.
    '        MyFiles = e.Data.GetData(DataFormats.FileDrop)
    '        ' Display the file Name
    '        'TextBoxDrop.Text = MyFiles(0)
    '        ' Display the file contents
    '        MsgBox(MyFiles(0))
    '    End If
    'End Sub

    Private Sub SyncInfoEventHandler(sender As Object, e As SyncInfoEventArgs)
        log("SyncInfoEventHandler")
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
        If mi.ArchiveFile Is Nothing Then
            'Debug.WriteLine("mi.ArchiveFile Is Nothing")
            Exit Sub
        End If
        Debug.WriteLine(mi.ArchiveFile.Name)
        log("AddRowData(""" & mi.ArchiveFile.Name)
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
        log("gridFMs_CellClick : col=" & e.ColumnIndex & ", row=" & e.RowIndex)
        If gridFMs.SelectedCells.Count > 0 AndAlso gridFMs.SelectedCells(0).RowIndex <> lastRow Then
            If UserNoteDirty Then
                Dim tp As TabPage = tabsDocs.TabPages.Item(tabsDocs.TabPages.Count - 1)
                Dim txt As TextBox = CType(tp.Controls.Item(0), TextBox)
                SaveUserNote(lastRowId, txt.Text)
                UserNoteDirty = False
            End If
            lastRow = gridFMs.SelectedCells(0).RowIndex
            lastRowId = gridFMs.Rows(lastRow).Cells(0).Value
            With CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)
                Dim nv As NameValueCollection = SelectInfoFiles(CInt(.Cells(0).Value))
                UpdateInfoTabs(lastRowId, nv)
                SetMenuChoices()
            End With
        End If
    End Sub

    Private Sub SetMenuChoices()
        log("SetMenuChoices")
        With CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)
            Dim GameVer As String = .Cells(cols.Ver).Value.ToString
            Dim GameIsMatch As Boolean = (GameVer = GameVersion)
            Dim GameIsInstalled As Boolean = Directory.Exists(Path.Combine(FMRootPath, .Cells(cols.InstallFolder).Value.ToString))
            mnuPlayFanMission.Visible = GameIsMatch
            cmnuPlayFanMission.Visible = GameIsMatch
            btnUninstallFanMission.Visible = GameIsInstalled
            mnuUninstallFanMission.Visible = GameIsInstalled
            cmnuUninstallFanMission.Visible = GameIsInstalled
            If GameIsInstalled Then
                Dim bmp As System.Drawing.Bitmap = GetIcon(GameVer)
                btnUninstallFanMission.Image = bmp
                mnuUninstallFanMission.Image = bmp
                cmnuUninstallFanMission.Image = bmp
            End If
        End With
    End Sub

    Private Function GetIcon(GameVer As String) As System.Drawing.Bitmap
        log("GetIcon(" & GameVer & ")")
        Select Case GameVer
            Case "SS2" : Return My.Resources.SS2
            Case "T1" : Return My.Resources.T1
            Case "T2" : Return My.Resources.T2
            Case "T3" : Return My.Resources.T3
            Case Else : Return My.Resources.err
        End Select
    End Function

    Private Sub gridFMs_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gridFMs.CellMouseDown
        log("gridFMs_CellMouseDown : col=" & e.ColumnIndex & ", row=" & e.RowIndex & ", button=" & e.Button.ToString)
        If e.Button = MouseButtons.Right Then
            gridFMs.Item(e.ColumnIndex, e.RowIndex).Selected = True
            gridFMs_CellClick(Nothing, New DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex))
        End If
    End Sub

    Dim UserNoteDirty As Boolean = False
    Private Sub UpdateInfoTabs(rowid As Integer, nv As NameValueCollection)
        log("UpdateInfoTabs")
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
        Dim tpUserNotes As New TabPage("User Notes")
        Dim txtUserNotes As New TextBox With {.Multiline = True, .Dock = DockStyle.Fill, .Parent = tpUserNotes, .ScrollBars = ScrollBars.Vertical, .WordWrap = True}
        txtUserNotes.Text = GetUserNotesFromDb(rowid)
        AddHandler txtUserNotes.TextChanged, Sub() UserNoteDirty = True
        tabsDocs.TabPages.Add(tpUserNotes)
    End Sub

    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        log("btnSync_Click")
        RemoveHandler dtMissions.RowChanged, AddressOf dtMissions_RowChanged
        btnSync.Visible = False
        SyncMissionFolders()
    End Sub

    Private Sub mnuMissions_Click(sender As Object, e As EventArgs) Handles mnuAllMissions.Click, mnuOnlyGameMissions.Click
        Dim mi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        log("mnuMissions_Click : " & mi.Name)
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
        log("ShowGameInfoToolStripMenuItem_Click")
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
        log("gridFMs_CellDoubleClick : col=" & e.ColumnIndex & ", row=" & e.RowIndex)
        If e.RowIndex = -1 Then Exit Sub
        Select Case e.ColumnIndex
            Case cols.Directory
                Process.Start(gridFMs.Item(cols.Directory, e.RowIndex).Value.ToString)
            Case cols.FileName
                Process.Start(Path.Combine(gridFMs.Item(cols.Directory, e.RowIndex).Value.ToString, gridFMs.Item(cols.FileName, e.RowIndex).Value.ToString))
            Case cols.InstallFolder
                Dim InstPath As String = Path.Combine(FMRootPath, GetGridValue(cols.InstallFolder))
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

    Private Function GetGridValue(col As cols) As String
        Return GetSelectedGridRow.Cells(col).Value.ToString
    End Function

    Private Function GetSelectedGridRow() As DataGridViewRow
        Return CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)
    End Function

    Private Sub mnuMaxCash_Click(sender As Object, e As EventArgs) Handles mnuMaxCash.Click
        log("mnuMaxCash_Click : checked=" & mnuMaxCash.Checked.ToString)
        cbMaxCash.Checked = mnuMaxCash.Checked
    End Sub
    Private Sub cbMaxCash_Click(sender As Object, e As EventArgs) Handles cbMaxCash.Click
        log("cbMaxCash_Click : checked=" & cbMaxCash.Checked.ToString)
        mnuMaxCash.Checked = cbMaxCash.Checked
    End Sub

    Private Sub mnuReturnToTFMM_Click(sender As Object, e As EventArgs) Handles mnuReturnToTFMM.Click
        log("mnuReturnToTFMM_Click : checked=" & mnuReturnToTFMM.Checked.ToString)
        cbReturnToTFMM.Checked = mnuReturnToTFMM.Checked
    End Sub

    Private Sub cbReturnToTFMM_Click(sender As Object, e As EventArgs) Handles cbReturnToTFMM.Click
        log("cbReturnToTFMM_Click : checked=" & cbReturnToTFMM.Checked.ToString)
        mnuReturnToTFMM.Checked = cbReturnToTFMM.Checked
    End Sub

    Private Sub cbOpenMissionNotes_Click(sender As Object, e As EventArgs) Handles cbOpenMissionNotes.Click
        log("cbOpenMissionNotes_Click : checked=" & cbOpenMissionNotes.Checked.ToString)
        mnuOpenMissionNotes.Checked = cbOpenMissionNotes.Checked
    End Sub

    Private Sub mnuOpenMissionNotes_Click(sender As Object, e As EventArgs) Handles mnuOpenMissionNotes.Click
        log("mnuOpenMissionNotes_Click : checked=" & mnuOpenMissionNotes.Checked.ToString)
        cbOpenMissionNotes.Checked = mnuOpenMissionNotes.Checked
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
            Dim fi As New FileInfo(Path.Combine(UnzipDestFolder, e.FileInfo.FileName))
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

    Private Sub gridFMs_Sorted(sender As Object, e As EventArgs) Handles gridFMs.Sorted
        SetMenuChoices()
    End Sub

#End Region

#Region "Drag & Drop"

    Private dragIndex As Integer
    Private dropIndex As Integer
    Private dragRect As Rectangle

    Private Sub gridFMs_DragOver(sender As Object, e As DragEventArgs) Handles gridFMs.DragOver
        If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub gridFMs_MouseDown(sender As Object, e As MouseEventArgs) Handles gridFMs.MouseDown
        dragIndex = gridFMs.HitTest(e.X, e.Y).RowIndex
        If dragIndex > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
        Else
            dragRect = Rectangle.Empty
        End If
    End Sub

    Private Sub gridFMs_MouseMove(sender As Object, e As MouseEventArgs) Handles gridFMs.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                gridFMs.DoDragDrop(gridFMs.Rows(dragIndex), DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub gridFMs_DragDrop(sender As Object, e As DragEventArgs) Handles gridFMs.DragDrop
        Dim p As Point = gridFMs.PointToClient(New Point(e.X, e.Y))
        dropIndex = gridFMs.HitTest(p.X, p.Y).RowIndex
        e.Effect = DragDropEffects.None
        If MsgBox("Copy meta data from " & gridFMs.Item(cols.FileName, dragIndex).Value.ToString & " to " & gridFMs.Item(cols.FileName, dropIndex).Value.ToString & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Dim dragRow As DataRow = dtMissions.Select("rowid=" & gridFMs.Item(cols.id, dragIndex).Value)(0)
            Dim dropRow As DataRow = dtMissions.Select("rowid=" & gridFMs.Item(cols.id, dropIndex).Value)(0)
            dropRow.Item(cols.Ver) = dragRow(cols.Ver)
            dropRow.Item(cols.MissionName) = dragRow(cols.MissionName)
            dropRow.Item(cols.Author) = dragRow(cols.Author)
            dropRow.Item(cols.Rating) = dragRow(cols.Rating)
            dropRow.Item(cols.Completed) = dragRow(cols.Completed)
            dropRow.AcceptChanges()
            SaveUserNote(dropRow.Item(cols.id), GetUserNotesFromDb(dragRow.Item(cols.id)))
        End If
    End Sub

    Private Shared ReadOnly _syncObject = New Object
    Private Shared ReadOnly logDir = Path.Combine(GetDLLPath, "Logs")

    ''' <summary>
    ''' Thread-Safe logging
    ''' </summary>
    ''' <param name="msg">The message to insert into the log file.</param>
    Private Sub log(msg As String)
        SyncLock _syncObject
            Dim logFileName As String = $"{Now:yyyy-MM-dd}.log"
            File.AppendAllText(Path.Combine(logDir, logFileName), $"{Now:hh:mm:ss tt} - {msg}{vbCrLf}")
        End SyncLock
    End Sub

#End Region

End Class