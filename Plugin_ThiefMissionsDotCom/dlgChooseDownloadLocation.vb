Imports System.Windows.Forms

Public Class dlgChooseDownloadLocation

    Public Property SelectedLocation As String

    Private lst As List(Of String)

    Public Sub New(FMLocations As List(Of String))
        InitializeComponent()
        lst = FMLocations
    End Sub

    Private Sub dlgChooseDownloadLocation_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboLocations.DataSource = lst
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cboLocations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocations.SelectedIndexChanged
        SelectedLocation = cboLocations.SelectedItem
    End Sub
End Class
