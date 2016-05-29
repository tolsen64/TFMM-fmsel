Imports Microsoft.WindowsAPICodePack.Dialogs

Imports System.Windows.Forms

Module WinApiDialogs

    Public Function GetFolderChoice(ByRef ChosenFolders As IEnumerable(Of String), Title As String, Optional MultiSelect As Boolean = False, Optional InitialFolder As String = Nothing) As Boolean
        Try
            Dim rslt As CommonFileDialogResult = Nothing
            With New CommonOpenFileDialog() With {.InitialDirectory = InitialFolder, .IsFolderPicker = True, .Multiselect = MultiSelect, .Title = Title}
                rslt = .ShowDialog()
                If rslt = CommonFileDialogResult.Ok Then
                    ChosenFolders = .FileNames
                End If
            End With
            Return If(rslt = CommonFileDialogResult.Ok, True, False)
        Catch
            Dim rslt As DialogResult = Nothing
            With New FolderBrowserDialog() With {.Description = Title, .SelectedPath = InitialFolder}
                rslt = .ShowDialog
                If rslt = DialogResult.OK Then
                    Dim cf(0) As String
                    cf(0) = .SelectedPath
                    ChosenFolders = cf
                End If
            End With
            Return If(rslt = DialogResult.OK, True, False)
        End Try
    End Function

End Module
