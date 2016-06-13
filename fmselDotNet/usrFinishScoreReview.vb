Imports System.IO
Imports System.Net
Imports System.Xml

Public Class usrFinishScoreReview

    Private Sub pbViewAllFMScores_Click(sender As Object, e As EventArgs) Handles pbViewAllFMScores.Click
        Process.Start("http://www.potterdevelopments.org.uk/fm/scores/results.pl")
    End Sub

    Private Sub pbScoringGuidelines_Click(sender As Object, e As EventArgs) Handles pbScoringGuidelines.Click
        With New frmScoringGuidelines
            .Icon = frmMain.ActiveForm.Icon
            .WebBrowser1.DocumentText = My.Settings.GLScoringGuidelines
            .Top = frmMain.ActiveForm.Top + 20
            .Left = frmMain.ActiveForm.Left + 20
            .Height = frmMain.ActiveForm.Height - 40
            .Width = frmMain.ActiveForm.Width - 40
            .Show()
        End With
    End Sub

    Private Sub btnDownload_MouseEnter(sender As Object, e As EventArgs) Handles clbFMKeywords.MouseEnter, btnFMScoresDownload.MouseEnter, btnFMScoresUpload.MouseEnter, btnFMKeywordsUpload.MouseEnter, btnFMKeywordsDownload.MouseEnter, pbScoringGuidelines.MouseEnter, pbViewAllFMScores.MouseEnter, cboYourScore.MouseEnter, txtMissionReviewNotes.MouseEnter, lblCommunityScore.MouseEnter
        ToolTip1.ToolTipTitle = CType(sender, System.Windows.Forms.Control).Tag
    End Sub

    Private Sub btnFMScoresDownload_Click(sender As Object, e As EventArgs) Handles btnFMScoresDownload.Click
        Dim rsp As String = DoHttpWebRequest("http://www.potterdevelopments.org.uk/fm/scores/show_scores.pl?zipname=" & WebUtility.UrlEncode(ZipName.ToUpper) & "&missionname=" & WebUtility.UrlEncode(MissionName.ToUpper))
        lblCommunityScore.Text = GetXmlValue(rsp, "SCORE")
        lblCommunityScore.Tag = "Community Score: " & lblCommunityScore.Text
        ToolTip1.SetToolTip(lblCommunityScore, "This mission has been rated by " & GetXmlValue(rsp, "SUBMISSIONS") & " players.")
    End Sub

    Private Sub btnFMKeywordsDownload_Click(sender As Object, e As EventArgs) Handles btnFMKeywordsDownload.Click
        Dim rsp As String = DoHttpWebRequest("http://www.potterdevelopments.org.uk/fm/scores/show_keywords.pl?zipname=" & WebUtility.UrlEncode(ZipName.ToUpper) & "&missionname=" & WebUtility.UrlEncode(MissionName.ToUpper))
        Dim s As String = GetXmlValue(rsp, "KEYWORDS")
        SetKeywords(s)
        btnFMKeywordsUpload.Enabled = True
    End Sub

    Public Property RandomId As String = ""
    Public Property ZipName As String = ""
    Public Property MissionName As String = ""
    Public Property Score As Integer
        Get
            Return CInt(cboYourScore.SelectedItem)
        End Get
        Set(value As Integer)
            cboYourScore.SelectedItem = value
        End Set
    End Property

    Private Function DoHttpWebRequest(url As String) As String
        With HttpWebRequest.Create(url)
            With .GetResponse
                DoHttpWebRequest = New StreamReader(.GetResponseStream).ReadToEnd
            End With
        End With
    End Function

    Private Function GetXmlValue(Xml As String, NodeName As String) As String
        GetXmlValue = ""
        With New XmlDocument()
            .LoadXml(Xml)
            For Each xn As XmlNode In .DocumentElement.ChildNodes()
                For Each cn As XmlNode In xn.ChildNodes
                    If cn.Name.ToUpper = NodeName.ToUpper Then GetXmlValue = cn.InnerText
                Next
            Next
        End With
    End Function

    Private Sub SetKeywords(keywords As String)
        Dim kw As String() = keywords.Split({ChrW(65533)}, StringSplitOptions.RemoveEmptyEntries)
        For i As Integer = 0 To clbFMKeywords.Items.Count - 1
            clbFMKeywords.SetItemChecked(i, kw.Contains(clbFMKeywords.Items(i)))
        Next
    End Sub

End Class
