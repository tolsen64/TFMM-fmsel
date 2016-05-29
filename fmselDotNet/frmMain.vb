Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text.Encoding
Imports System.Collections.Specialized
Imports System.Data.SQLite

Public Class frmMain
    Inherits Form

    Dim ico As System.Drawing.Icon = Nothing
    Dim cbMaxCash As CheckBox

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
        gridFMs.DataSource = dvMissions
        UpdateCounts()

        mnuOnlyGameMissions.Text = String.Format(mnuOnlyGameMissions.Text, GameVersion)
        mnuAllMissions.Checked = ViewAllMissions
        mnuOnlyGameMissions.Checked = Not ViewAllMissions
        gridFMs.Columns.Item(4).Visible = ViewAllMissions

        If GameVersion = "SS2" Or GameVersion = "T1" Or GameVersion = "T2" Then
            cboGamesys.Items.AddRange(GetGamesysFileList)
            cboGamesys.SelectedIndex = 0
            cboGamesys.Visible = True
        Else
            cboGamesys.Items.Clear()
            cboGamesys.Visible = False
        End If

        If GameVersion = "T1" Or GameVersion = "T2" Then
            'Add checkbox to status strip
            cbMaxCash = New CheckBox With {.Text = "Max Cash"}
            Dim tsItem As New ToolStripControlHost(cbMaxCash) With {.Alignment = ToolStripItemAlignment.Right}
            ToolStrip1.Items.Add(tsItem)
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
        Dim ss As String() = txtFilter.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim fltr As String = "("
        If Not ViewAllMissions Then fltr = "(ThiefVersion = '" & GameVersion & "') AND " & fltr
        If ss.Count > 0 Then
            For Each s As String In ss
                fltr &= "Filename LIKE '%" & s.SQLify & "%' OR MissionName LIKE '%" & s.SQLify & "%' OR Author LIKE '%" & s.SQLify & "%' OR "
            Next
        Else
            fltr &= "1=1"
        End If
        fltr = fltr.TrimEnd({" "c, "R"c, "O"c}) & ")"
        dvMissions.RowFilter = fltr
    End Sub

    Private Sub mnuExitGame_Click(sender As Object, e As EventArgs) Handles mnuExitGame.Click
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub

    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem1.Click
        With New dlgSettings
            If .ShowDialog(Me) = DialogResult.OK Then
                LoadFMSelCfg()
            End If
        End With
    End Sub

    Private Async Sub btnPlay_ButtonClick(sender As Object, e As EventArgs) Handles btnPlay.ButtonClick, mnuPlayFanMission.Click
        Await Task.Run(Sub()
                           If gridFMs.SelectedCells.Count > 0 Then
                               With CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)

                                   Dim sourceZip As String = .Cells(7).Value.ToString & "\" & .Cells(1).Value.ToString
                                   Dim destFldr As String = ""
                                   If FMRootPath = "" Then
                                       destFldr = ".\FMs\" & .Cells(8).Value.ToString
                                   Else
                                       destFldr = FMRootPath & "\" & .Cells(8).Value.ToString
                                   End If
                                   If destFldr.StartsWith(".\") Then
                                       destFldr = GamePath & destFldr.Substring(1)
                                   End If
                                   If Not Directory.Exists(destFldr) Then
                                       If File.Exists(sourceZip) Then
                                           Directory.CreateDirectory(destFldr)
                                           UnzipMission(sourceZip, destFldr)
                                           SelectedFM = .Cells(8).Value.ToString
                                           FMSelReturnValue = eFMSelReturn.kSelFMRet_OK
                                           Close()
                                       Else
                                           MsgBox("Source zip file not found. Can't launch game.", MsgBoxStyle.Critical)
                                       End If
                                   Else
                                       SelectedFM = .Cells(8).Value.ToString
                                       ApplyMaxCash(.Cells(8).Value.ToString)
                                       ApplyCustomGameSys(.Cells(8).Value.ToString)
                                       FMSelReturnValue = eFMSelReturn.kSelFMRet_OK
                                       Close()
                                   End If
                               End With
                           End If
                       End Sub)
    End Sub

    Private Sub UnzipMission(sourceZip As String, destFldr As String)
        ToolStrip1.Invoke(Sub()
                              lblSyncProg.Text = ""
                              pbSyncProg.Value = 0
                              pbSyncProg.Visible = True
                              lblSyncProg.Visible = True
                              btnSync.Visible = False
                          End Sub)

        Using z As ZipArchive = ZipFile.OpenRead(sourceZip)
            pbSyncProg.Maximum = z.Entries.Count
            'For Each ze As ZipArchiveEntry In z.Entries
            '    If String.IsNullOrEmpty(ze.Name) Then
            '        Directory.CreateDirectory(destFldr & "\" & ze.FullName)
            '    End If
            'Next
            For Each ze As ZipArchiveEntry In z.Entries
                lblSyncProg.Text = ze.FullName
                Dim fi As New FileInfo(destFldr & "\" & ze.FullName)
                If Not fi.Directory.Exists Then fi.Directory.Create()
                If Not String.IsNullOrEmpty(ze.Name) Then
                    ze.ExtractToFile(fi.FullName)
                End If
                pbSyncProg.Value += 1
            Next
        End Using

        ToolStrip1.Invoke(Sub()
                              lblSyncProg.Visible = False
                              pbSyncProg.Visible = False
                              btnSync.Visible = True
                          End Sub)
    End Sub

    Private Sub ApplyMaxCash(SelectedFM As String)
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
        If GameVersion <> "T3" Then
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
        ApplyMaxCash("")
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
            ToolStrip1.Invoke(Sub()
                                  btnSync.Visible = False
                                  pbSyncProg.Visible = True
                                  pbSyncProg.Maximum = e.FileCount - 1
                                  pbSyncProg.Value = If(e.Index < 0, 0, e.Index)
                                  lblSyncProg.Visible = True
                                  lblSyncProg.Text = "(" & e.Index + 1 & " of " & e.FileCount & ") " & e.Filename
                              End Sub)
        Else
            ToolStrip1.Invoke(Sub()
                                  pbSyncProg.Visible = False
                                  lblSyncProg.Visible = False
                                  btnSync.Visible = True
                                  AddHandler dtMissions.RowChanged, AddressOf dtMissions_RowChanged
                              End Sub)
        End If
    End Sub

    Private Sub gridFMs_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridFMs.CellFormatting
        If e.ColumnIndex = 2 Then
            e.Value = FormatFileSize(e.Value)
            'ElseIf e.ColumnIndex = 4 Then
            'Select Case e.Value.ToString
            '    Case "SystemShock2" : e.Value = "SS2"
            '    Case "Thief1" : e.Value = "T1"
            '    Case "Thief2" : e.Value = "T2"
            '    Case "Thief3" : e.Value = "T3"
            '    Case "Unknown" : e.Value = "Unk"
            'End Select
        ElseIf e.ColumnIndex = 6 Then
            If e.Value IsNot Nothing Then
                If IsDate(e.Value.ToString) Then
                    e.Value = CDate(e.Value).ToString("d", CultureInfo.CurrentCulture)
                End If
            End If
        End If
    End Sub

    Private Sub UpdateCounts()
        lblTotalMissionFiles.Text = TotalRowCount.ToString("N0", CultureInfo.CurrentCulture)
        lblTotalDisplayed.Text = FilteredRowCount.ToString("N0", CultureInfo.CurrentCulture)
    End Sub

    Dim lastRowId As Integer = -1
    Dim lastRow As Integer = -1
    Private Sub gridFMs_SelectionChanged(sender As Object, e As EventArgs) Handles gridFMs.SelectionChanged
        If gridFMs.SelectedCells.Count > 0 AndAlso gridFMs.SelectedCells(0).RowIndex <> lastRow Then
            If UserNoteDirty Then
                Dim tp As TabPage = tabsDocs.TabPages.Item(tabsDocs.TabPages.Count - 1)
                Dim txt As TextBox = tp.Controls.Item(0)
                SaveUserNote(lastRowId, txt.Text)
                UserNoteDirty = False
            End If
            lastRow = gridFMs.SelectedCells(0).RowIndex
            lastRowId = gridFMs.Rows(lastRow).Cells(0).Value
            With CType(gridFMs.Rows.Item(gridFMs.SelectedCells(0).RowIndex), DataGridViewRow)
                Dim nv As NameValueCollection = SelectInfoFiles(CInt(.Cells(0).Value))
                UpdateInfoTabs(lastRowId, nv)
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
        gridFMs.Columns.Item(4).Visible = ViewAllMissions
        SaveFMSelCfg()
    End Sub

End Class