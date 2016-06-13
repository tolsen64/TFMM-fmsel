<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrFinishScoreReview
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrFinishScoreReview))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboYourScore = New System.Windows.Forms.ComboBox()
        Me.txtMissionReviewNotes = New System.Windows.Forms.TextBox()
        Me.btnFMKeywordsDownload = New System.Windows.Forms.Button()
        Me.btnFMKeywordsUpload = New System.Windows.Forms.Button()
        Me.pbViewAllFMScores = New System.Windows.Forms.PictureBox()
        Me.pbScoringGuidelines = New System.Windows.Forms.PictureBox()
        Me.btnFMScoresDownload = New System.Windows.Forms.Button()
        Me.btnFMScoresUpload = New System.Windows.Forms.Button()
        Me.clbFMKeywords = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCommunityScore = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        CType(Me.pbViewAllFMScores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbScoringGuidelines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(398, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "GarrettLoader's ""Finish, Score, Review"" Tab"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboYourScore
        '
        Me.cboYourScore.FormattingEnabled = True
        Me.cboYourScore.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboYourScore.Location = New System.Drawing.Point(75, 19)
        Me.cboYourScore.Name = "cboYourScore"
        Me.cboYourScore.Size = New System.Drawing.Size(44, 21)
        Me.cboYourScore.TabIndex = 1
        Me.cboYourScore.Tag = "FM Score"
        Me.ToolTip1.SetToolTip(Me.cboYourScore, resources.GetString("cboYourScore.ToolTip"))
        '
        'txtMissionReviewNotes
        '
        Me.txtMissionReviewNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMissionReviewNotes.Location = New System.Drawing.Point(3, 16)
        Me.txtMissionReviewNotes.Multiline = True
        Me.txtMissionReviewNotes.Name = "txtMissionReviewNotes"
        Me.txtMissionReviewNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMissionReviewNotes.Size = New System.Drawing.Size(386, 386)
        Me.txtMissionReviewNotes.TabIndex = 0
        Me.txtMissionReviewNotes.Tag = "Review / Notes"
        Me.ToolTip1.SetToolTip(Me.txtMissionReviewNotes, "Use this to record any notes you may have about this FM or a personal review of i" &
        "t for later reference." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This information is kept on your PC and is not sent anyw" &
        "here.")
        '
        'btnFMKeywordsDownload
        '
        Me.btnFMKeywordsDownload.Image = CType(resources.GetObject("btnFMKeywordsDownload.Image"), System.Drawing.Image)
        Me.btnFMKeywordsDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFMKeywordsDownload.Location = New System.Drawing.Point(96, 115)
        Me.btnFMKeywordsDownload.Name = "btnFMKeywordsDownload"
        Me.btnFMKeywordsDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnFMKeywordsDownload.TabIndex = 6
        Me.btnFMKeywordsDownload.Tag = "Download Current Tags"
        Me.btnFMKeywordsDownload.Text = "Download"
        Me.btnFMKeywordsDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnFMKeywordsDownload, "Downloads the tags assigned by community players and sets the checked items above" &
        ".")
        Me.btnFMKeywordsDownload.UseVisualStyleBackColor = True
        '
        'btnFMKeywordsUpload
        '
        Me.btnFMKeywordsUpload.Enabled = False
        Me.btnFMKeywordsUpload.Image = CType(resources.GetObject("btnFMKeywordsUpload.Image"), System.Drawing.Image)
        Me.btnFMKeywordsUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFMKeywordsUpload.Location = New System.Drawing.Point(6, 115)
        Me.btnFMKeywordsUpload.Name = "btnFMKeywordsUpload"
        Me.btnFMKeywordsUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnFMKeywordsUpload.TabIndex = 5
        Me.btnFMKeywordsUpload.Tag = "Apply Mission Tags"
        Me.btnFMKeywordsUpload.Text = "Upload"
        Me.ToolTip1.SetToolTip(Me.btnFMKeywordsUpload, "Uploads any changes you made to the community tag list for this mission.")
        Me.btnFMKeywordsUpload.UseVisualStyleBackColor = True
        '
        'pbViewAllFMScores
        '
        Me.pbViewAllFMScores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbViewAllFMScores.Image = CType(resources.GetObject("pbViewAllFMScores.Image"), System.Drawing.Image)
        Me.pbViewAllFMScores.Location = New System.Drawing.Point(125, 110)
        Me.pbViewAllFMScores.Name = "pbViewAllFMScores"
        Me.pbViewAllFMScores.Size = New System.Drawing.Size(28, 28)
        Me.pbViewAllFMScores.TabIndex = 9
        Me.pbViewAllFMScores.TabStop = False
        Me.pbViewAllFMScores.Tag = "Show All Group Scores"
        Me.ToolTip1.SetToolTip(Me.pbViewAllFMScores, resources.GetString("pbViewAllFMScores.ToolTip"))
        '
        'pbScoringGuidelines
        '
        Me.pbScoringGuidelines.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbScoringGuidelines.Image = CType(resources.GetObject("pbScoringGuidelines.Image"), System.Drawing.Image)
        Me.pbScoringGuidelines.Location = New System.Drawing.Point(172, 110)
        Me.pbScoringGuidelines.Name = "pbScoringGuidelines"
        Me.pbScoringGuidelines.Size = New System.Drawing.Size(28, 28)
        Me.pbScoringGuidelines.TabIndex = 8
        Me.pbScoringGuidelines.TabStop = False
        Me.pbScoringGuidelines.Tag = "How To Score FMs"
        Me.ToolTip1.SetToolTip(Me.pbScoringGuidelines, "This will provide you with useful guidelines" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of how to use the scoring system to" &
        " rate the FMs you play.")
        '
        'btnFMScoresDownload
        '
        Me.btnFMScoresDownload.Image = CType(resources.GetObject("btnFMScoresDownload.Image"), System.Drawing.Image)
        Me.btnFMScoresDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFMScoresDownload.Location = New System.Drawing.Point(125, 62)
        Me.btnFMScoresDownload.Name = "btnFMScoresDownload"
        Me.btnFMScoresDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnFMScoresDownload.TabIndex = 5
        Me.btnFMScoresDownload.Tag = "Download current community score"
        Me.btnFMScoresDownload.Text = "Download"
        Me.btnFMScoresDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnFMScoresDownload, "This will download the current score for this Fan Mission from the GarrettLoader " &
        "server." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Or Right Click to download all scores for all FMs.")
        Me.btnFMScoresDownload.UseVisualStyleBackColor = True
        '
        'btnFMScoresUpload
        '
        Me.btnFMScoresUpload.Image = CType(resources.GetObject("btnFMScoresUpload.Image"), System.Drawing.Image)
        Me.btnFMScoresUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFMScoresUpload.Location = New System.Drawing.Point(125, 17)
        Me.btnFMScoresUpload.Name = "btnFMScoresUpload"
        Me.btnFMScoresUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnFMScoresUpload.TabIndex = 4
        Me.btnFMScoresUpload.Tag = "Upload this score"
        Me.btnFMScoresUpload.Text = "Upload"
        Me.ToolTip1.SetToolTip(Me.btnFMScoresUpload, resources.GetString("btnFMScoresUpload.ToolTip"))
        Me.btnFMScoresUpload.UseVisualStyleBackColor = True
        '
        'clbFMKeywords
        '
        Me.clbFMKeywords.CheckOnClick = True
        Me.clbFMKeywords.FormattingEnabled = True
        Me.clbFMKeywords.Items.AddRange(New Object() {"Enemy-Guards", "Enemy-Hammerites", "Enemy-Keepers", "Enemy-Mages", "Enemy-Mechanist", "Enemy-Pagans", "Enemy-Thieves", "Enemy-Undead", "Location-Bank", "Location-Church", "Location-City", "Location-Crypt", "Location-Forest", "Location-Fortress", "Location-Mansion", "Location-Museum", "Location-Prison", "Location-Ruins", "Theme-Explore", "Theme-Fun", "Theme-General", "Theme-Horror", "Theme-Rescue", "Theme-Unusual", "Location-Prison", "Location-Forest", "Location-Ruins", "Location-Bank", "Theme-Rescue", "Theme-Explore", "Theme-Fun", "Theme-Unusual", "Theme-General", "Theme-Horror"})
        Me.clbFMKeywords.Location = New System.Drawing.Point(6, 15)
        Me.clbFMKeywords.Name = "clbFMKeywords"
        Me.clbFMKeywords.Size = New System.Drawing.Size(165, 94)
        Me.clbFMKeywords.TabIndex = 0
        Me.clbFMKeywords.Tag = "Tagging the Fan Mission"
        Me.ToolTip1.SetToolTip(Me.clbFMKeywords, "1. Click Download to get community assigned tags." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Check/Uncheck items to incr" &
        "ease accuracy." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. Click Upload to apply changes.")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnFMKeywordsDownload)
        Me.GroupBox2.Controls.Add(Me.btnFMKeywordsUpload)
        Me.GroupBox2.Controls.Add(Me.clbFMKeywords)
        Me.GroupBox2.Location = New System.Drawing.Point(218, 26)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(177, 145)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FM Tags:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Your Score:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Community Score:"
        '
        'lblCommunityScore
        '
        Me.lblCommunityScore.AutoSize = True
        Me.lblCommunityScore.Location = New System.Drawing.Point(104, 67)
        Me.lblCommunityScore.Name = "lblCommunityScore"
        Me.lblCommunityScore.Size = New System.Drawing.Size(13, 13)
        Me.lblCommunityScore.TabIndex = 3
        Me.lblCommunityScore.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "View All FM Scores:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbViewAllFMScores)
        Me.GroupBox1.Controls.Add(Me.pbScoringGuidelines)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnFMScoresDownload)
        Me.GroupBox1.Controls.Add(Me.btnFMScoresUpload)
        Me.GroupBox1.Controls.Add(Me.lblCommunityScore)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboYourScore)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 145)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mission Scores:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtMissionReviewNotes)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 177)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(392, 405)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mission Review / Notes"
        '
        'usrFinishScoreReview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "usrFinishScoreReview"
        Me.Size = New System.Drawing.Size(398, 585)
        CType(Me.pbViewAllFMScores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbScoringGuidelines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents clbFMKeywords As Windows.Forms.CheckedListBox
    Friend WithEvents btnFMKeywordsUpload As Windows.Forms.Button
    Friend WithEvents btnFMKeywordsDownload As Windows.Forms.Button
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cboYourScore As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents lblCommunityScore As Windows.Forms.Label
    Friend WithEvents btnFMScoresUpload As Windows.Forms.Button
    Friend WithEvents btnFMScoresDownload As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents pbScoringGuidelines As Windows.Forms.PictureBox
    Friend WithEvents pbViewAllFMScores As Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents txtMissionReviewNotes As Windows.Forms.TextBox
End Class
