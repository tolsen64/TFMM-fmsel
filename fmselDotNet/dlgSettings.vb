Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class dlgSettings

    Dim tmpLstFMDirs As List(Of String)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        fmselCfg.lstFMDirs = tmpLstFMDirs
        OpenMissionNotesDefault = chkOpenMissionNotesDefault.Checked
        ReturnToTFMMDefault = chkReturnToTFMMDefault.Checked
        MaxCashDefault = chkMaxCashDefault.Checked
        SS2GameExe = txtGameExeSS2.Text
        T1GameExe = txtGameExeT1.Text
        T2GameExe = txtGameExeT2.Text
        T3GameExe = txtGameExeT3.Text
        SaveFMSelCfg()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        If GameVersion = "T3" Then
            GroupBox1.Text = "Modify these settings in SneakyOptions.ini"
            lblFmPath.Text = "InstallPath"
            lblModPath.Text = "ModPaths"
        Else
            GroupBox1.Text = "Modify these settings in cam_mod.ini"
            lblFmPath.Text = "fm_path"
            lblModPath.Text = "mod_path"
        End If
        txtFmPath.Text = FMRootPath
        txtModPath.Text = ModExcludePaths
        txtGameExeSS2.Text = SS2GameExe
        txtGameExeT1.Text = T1GameExe
        txtGameExeT2.Text = T2GameExe
        txtGameExeT3.Text = T3GameExe
        tmpLstFMDirs = fmselCfg.lstFMDirs
        lstFMDirs.DataSource = tmpLstFMDirs
        chkOpenMissionNotesDefault.Checked = OpenMissionNotesDefault
        chkReturnToTFMMDefault.Checked = ReturnToTFMMDefault
        chkMaxCashDefault.Checked = MaxCashDefault
    End Sub

    Private Sub btn_fm_path_Click(sender As Object, e As EventArgs)
        Dim param As String = DirectCast(sender, Button).Name.Substring(3)
        Dim txtBox As TextBox = CType(Controls.Find("txt" & param, True)(0), TextBox)
        Dim ChosenFolders As IEnumerable(Of String) = Nothing
        If GetFolderChoice(ChosenFolders, "Select folder for: " & param, False, If(txtBox.Text <> "", txtBox.Text, Nothing)) Then
            txtBox.Text = ChosenFolders(0)
        End If
    End Sub

    Private Sub btnAddDir_Click(sender As Object, e As EventArgs) Handles btnAddDir.Click
        Dim ChosenFolders As IEnumerable(Of String) = Nothing
        If GetFolderChoice(ChosenFolders, "Select 1 or more " & GameName & " Fan Mission Archive Folder(s)", True) Then
            For Each s As String In ChosenFolders
                s = GetUniversalName(s)
                If Not tmpLstFMDirs.Contains(s) Then
                    tmpLstFMDirs.Add(s)
                    tmpLstFMDirs.Sort()
                End If
            Next
            lstFMDirs.DataSource = Nothing
            lstFMDirs.DataSource = tmpLstFMDirs
        End If
    End Sub

    Private Sub btnRemoveDir_Click(sender As Object, e As EventArgs) Handles btnRemoveDir.Click
        For Each o As Object In lstFMDirs.SelectedItems
            tmpLstFMDirs.Remove(o)
        Next
        lstFMDirs.DataSource = Nothing
        lstFMDirs.DataSource = tmpLstFMDirs
    End Sub

    Private Sub btnGameExe_Click(sender As Object, e As EventArgs) Handles btnGameExeSS2.Click, btnGameExeT1.Click, btnGameExeT2.Click, btnGameExeT3.Click
        Dim Title As String = ""
        Dim tb As TextBox = Nothing
        Select Case CType(sender, Button).Name.Replace("btnGameExe", "")
            Case "SS2"
                Title = "System Shock 2"
                tb = txtGameExeSS2
            Case "T1"
                Title = "Thief 1/Gold"
                tb = txtGameExeT1
            Case "T2"
                Title = "Thief 2"
                tb = txtGameExeT2
            Case "T3"
                Title = "Thief 3"
                tb = txtGameExeT3
        End Select
        Dim GameExe As String = ""
        With New CommonOpenFileDialog() With {.IsFolderPicker = False, .Multiselect = False, .Title = "Select Game EXE for " & Title}
            If .ShowDialog = CommonFileDialogResult.Ok Then GameExe = .FileName
        End With
        If GameExe <> "" Then tb.Text = GameExe
    End Sub

    Private Sub txtGameExe_DragEnter(sender As Object, e As DragEventArgs) Handles txtGameExeSS2.DragEnter, txtGameExeT1.DragEnter, txtGameExeT2.DragEnter, txtGameExeT3.DragEnter, lstFMDirs.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtGameExeSS2_DragDrop(sender As Object, e As DragEventArgs) Handles txtGameExeSS2.DragDrop, txtGameExeT1.DragDrop, txtGameExeT2.DragDrop, txtGameExeT3.DragDrop
        Dim dropped As String = e.Data.GetData(DataFormats.FileDrop, False)(0)
        If File.Exists(dropped) AndAlso dropped.ToLower.EndsWith(".exe") Then
            CType(sender, TextBox).Text = dropped
        Else
            MsgBox("Only EXE files are allowed to be dropped here.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub lstFMDirs_DragDrop(sender As Object, e As DragEventArgs) Handles lstFMDirs.DragDrop
        Dim dropped As IEnumerable(Of String) = e.Data.GetData(DataFormats.FileDrop, False)
        Dim MsgShown As Boolean = False
        For Each s As String In dropped
            s = GetUniversalName(s)
            If Directory.Exists(s) Then
                If Not tmpLstFMDirs.Contains(s) Then
                    tmpLstFMDirs.Add(s)
                    tmpLstFMDirs.Sort()
                End If
            Else
                If Not MsgShown Then
                    MsgBox("Only directories are allowed to be dropped here. One or more dropped files were not added.", MsgBoxStyle.Information)
                    MsgShown = True
                End If
            End If
        Next
        lstFMDirs.DataSource = Nothing
        lstFMDirs.DataSource = tmpLstFMDirs
    End Sub

End Class
