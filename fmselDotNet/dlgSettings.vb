Imports System.Windows.Forms
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class dlgSettings

    Dim tmpLstFMDirs As List(Of String)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        fmselCfg.lstFMDirs = tmpLstFMDirs
        AlwaysStartAfterExit = chkAlwaysStartFMSEL.Checked
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
        tmpLstFMDirs = fmselCfg.lstFMDirs
        lstFMDirs.DataSource = tmpLstFMDirs
        chkAlwaysStartFMSEL.Checked = AlwaysStartAfterExit
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
End Class
