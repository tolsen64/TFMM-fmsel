Imports System.Windows.Forms

Public Class dlgGameVer

    Public Sub New(CurrentVerValue As String)
        InitializeComponent()
        Select Case CurrentVerValue
            Case "SS2" : rdoSS2.Checked = True
            Case "T1" : rdoT1.Checked = True
            Case "T2" : rdoT2.Checked = True
            Case "T3" : rdoT3.Checked = True
            Case "err" : rdoUnk.Checked = True
        End Select
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public ReadOnly Property SelectedValue As String
        Get
            Return Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True).Tag
        End Get
    End Property

End Class
