Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "About " & GameName & " Fan Mission Selector"
        LogoPictureBox.Image = My.Resources.ResourceManager.GetObject(GameVersion & "box")
        txtTips.Text = My.Settings.AboutText
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub linkTwitch_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkTwitch.LinkClicked
        Process.Start("https://www.twitchalerts.com/donate/tolsen64")
    End Sub

    Private Sub linkPayPal_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkPayPal.LinkClicked
        Process.Start("https://www.paypal.me/tolsen64")
    End Sub
End Class
