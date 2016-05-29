<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabsMain = New System.Windows.Forms.TabControl()
        Me.tabFanMissions = New System.Windows.Forms.TabPage()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblTotalMissionFiles = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblTotalDisplayed = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.txtFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.btnPlay = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnPlayOriginalMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbSyncProg = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblSyncProg = New System.Windows.Forms.ToolStripLabel()
        Me.btnSync = New System.Windows.Forms.ToolStripButton()
        Me.cboGamesys = New System.Windows.Forms.ToolStripComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridFMs = New System.Windows.Forms.DataGridView()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFileSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabsDocs = New System.Windows.Forms.TabControl()
        Me.tabDoc1 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlayFanMission = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlayOriginalMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExitGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAllMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOnlyGameMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabsMain.SuspendLayout()
        Me.tabFanMissions.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridFMs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsDocs.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabsMain
        '
        Me.tabsMain.Controls.Add(Me.tabFanMissions)
        Me.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsMain.Location = New System.Drawing.Point(0, 24)
        Me.tabsMain.Name = "tabsMain"
        Me.tabsMain.SelectedIndex = 0
        Me.tabsMain.Size = New System.Drawing.Size(1264, 737)
        Me.tabsMain.TabIndex = 2
        '
        'tabFanMissions
        '
        Me.tabFanMissions.Controls.Add(Me.ToolStrip1)
        Me.tabFanMissions.Controls.Add(Me.SplitContainer1)
        Me.tabFanMissions.Location = New System.Drawing.Point(4, 22)
        Me.tabFanMissions.Name = "tabFanMissions"
        Me.tabFanMissions.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFanMissions.Size = New System.Drawing.Size(1256, 711)
        Me.tabFanMissions.TabIndex = 0
        Me.tabFanMissions.Text = "Fan Missions"
        Me.tabFanMissions.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.lblTotalMissionFiles, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.lblTotalDisplayed, Me.ToolStripSeparator2, Me.ToolStripLabel3, Me.txtFilter, Me.btnPlay, Me.pbSyncProg, Me.lblSyncProg, Me.btnSync, Me.cboGamesys})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 677)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1250, 29)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(106, 26)
        Me.ToolStripLabel1.Text = "Total Mission Files:"
        '
        'lblTotalMissionFiles
        '
        Me.lblTotalMissionFiles.Name = "lblTotalMissionFiles"
        Me.lblTotalMissionFiles.Size = New System.Drawing.Size(13, 26)
        Me.lblTotalMissionFiles.Text = "0"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(90, 26)
        Me.ToolStripLabel2.Text = "Total Displayed:"
        '
        'lblTotalDisplayed
        '
        Me.lblTotalDisplayed.Name = "lblTotalDisplayed"
        Me.lblTotalDisplayed.Size = New System.Drawing.Size(13, 26)
        Me.lblTotalDisplayed.Text = "0"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(36, 26)
        Me.ToolStripLabel3.Text = "Filter:"
        '
        'txtFilter
        '
        Me.txtFilter.AutoSize = False
        Me.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(150, 23)
        '
        'btnPlay
        '
        Me.btnPlay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnPlay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPlayOriginalMissions})
        Me.btnPlay.Image = CType(resources.GetObject("btnPlay.Image"), System.Drawing.Image)
        Me.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(127, 26)
        Me.btnPlay.Text = "Play Fan Mission"
        '
        'btnPlayOriginalMissions
        '
        Me.btnPlayOriginalMissions.Name = "btnPlayOriginalMissions"
        Me.btnPlayOriginalMissions.Size = New System.Drawing.Size(190, 22)
        Me.btnPlayOriginalMissions.Text = "Play Original Missions"
        '
        'pbSyncProg
        '
        Me.pbSyncProg.Name = "pbSyncProg"
        Me.pbSyncProg.Size = New System.Drawing.Size(100, 26)
        Me.pbSyncProg.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbSyncProg.Visible = False
        '
        'lblSyncProg
        '
        Me.lblSyncProg.Name = "lblSyncProg"
        Me.lblSyncProg.Size = New System.Drawing.Size(70, 26)
        Me.lblSyncProg.Text = "lblSyncProg"
        Me.lblSyncProg.Visible = False
        '
        'btnSync
        '
        Me.btnSync.Image = CType(resources.GetObject("btnSync.Image"), System.Drawing.Image)
        Me.btnSync.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(98, 26)
        Me.btnSync.Text = "Sync FM Files"
        '
        'cboGamesys
        '
        Me.cboGamesys.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cboGamesys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGamesys.Name = "cboGamesys"
        Me.cboGamesys.Size = New System.Drawing.Size(121, 29)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 6)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridFMs)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabsDocs)
        Me.SplitContainer1.Size = New System.Drawing.Size(1244, 668)
        Me.SplitContainer1.SplitterDistance = 622
        Me.SplitContainer1.TabIndex = 0
        '
        'gridFMs
        '
        Me.gridFMs.AllowUserToAddRows = False
        Me.gridFMs.AllowUserToDeleteRows = False
        Me.gridFMs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFMs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.colVer, Me.Column1, Me.colFileSize, Me.Column2, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.gridFMs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridFMs.Location = New System.Drawing.Point(0, 0)
        Me.gridFMs.MultiSelect = False
        Me.gridFMs.Name = "gridFMs"
        Me.gridFMs.RowHeadersVisible = False
        Me.gridFMs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridFMs.Size = New System.Drawing.Size(622, 668)
        Me.gridFMs.TabIndex = 0
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "rowid"
        Me.Column9.HeaderText = "id"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'colVer
        '
        Me.colVer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.colVer.DataPropertyName = "ThiefVersion"
        Me.colVer.HeaderText = "Ver"
        Me.colVer.Name = "colVer"
        Me.colVer.Width = 5
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.Column1.DataPropertyName = "Filename"
        Me.Column1.HeaderText = "FileName"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 5
        '
        'colFileSize
        '
        Me.colFileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.colFileSize.DataPropertyName = "FileSize"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colFileSize.DefaultCellStyle = DataGridViewCellStyle1
        Me.colFileSize.HeaderText = "FileSize"
        Me.colFileSize.Name = "colFileSize"
        Me.colFileSize.ReadOnly = True
        Me.colFileSize.Width = 5
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "MissionName"
        Me.Column2.HeaderText = "MissionName"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Author"
        Me.Column4.HeaderText = "Author"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 200
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.Column5.DataPropertyName = "ReleaseDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Released"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 5
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Directory"
        Me.Column6.HeaderText = "Directory"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "InstallFolder"
        Me.Column7.HeaderText = "InstallFolder"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "Hash"
        Me.Column8.HeaderText = "Hash"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'tabsDocs
        '
        Me.tabsDocs.Controls.Add(Me.tabDoc1)
        Me.tabsDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsDocs.Location = New System.Drawing.Point(0, 0)
        Me.tabsDocs.Name = "tabsDocs"
        Me.tabsDocs.SelectedIndex = 0
        Me.tabsDocs.Size = New System.Drawing.Size(618, 668)
        Me.tabsDocs.TabIndex = 0
        '
        'tabDoc1
        '
        Me.tabDoc1.Location = New System.Drawing.Point(4, 22)
        Me.tabDoc1.Name = "tabDoc1"
        Me.tabDoc1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDoc1.Size = New System.Drawing.Size(610, 642)
        Me.tabDoc1.TabIndex = 0
        Me.tabDoc1.Text = "tabDoc1"
        Me.tabDoc1.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1264, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlayFanMission, Me.mnuPlayOriginalMissions, Me.ToolStripMenuItem1, Me.SettingsToolStripMenuItem1, Me.ToolStripMenuItem2, Me.mnuExitGame})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mnuPlayFanMission
        '
        Me.mnuPlayFanMission.Name = "mnuPlayFanMission"
        Me.mnuPlayFanMission.Size = New System.Drawing.Size(190, 22)
        Me.mnuPlayFanMission.Text = "Play Fan Mission"
        '
        'mnuPlayOriginalMissions
        '
        Me.mnuPlayOriginalMissions.Name = "mnuPlayOriginalMissions"
        Me.mnuPlayOriginalMissions.Size = New System.Drawing.Size(190, 22)
        Me.mnuPlayOriginalMissions.Text = "Play Original Missions"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(187, 6)
        '
        'SettingsToolStripMenuItem1
        '
        Me.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1"
        Me.SettingsToolStripMenuItem1.Size = New System.Drawing.Size(190, 22)
        Me.SettingsToolStripMenuItem1.Text = "Settings"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(187, 6)
        '
        'mnuExitGame
        '
        Me.mnuExitGame.Name = "mnuExitGame"
        Me.mnuExitGame.Size = New System.Drawing.Size(190, 22)
        Me.mnuExitGame.Text = "Exit Game"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAllMissions, Me.mnuOnlyGameMissions})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'mnuAllMissions
        '
        Me.mnuAllMissions.Name = "mnuAllMissions"
        Me.mnuAllMissions.Size = New System.Drawing.Size(165, 22)
        Me.mnuAllMissions.Text = "All Missions"
        '
        'mnuOnlyGameMissions
        '
        Me.mnuOnlyGameMissions.Name = "mnuOnlyGameMissions"
        Me.mnuOnlyGameMissions.Size = New System.Drawing.Size(165, 22)
        Me.mnuOnlyGameMissions.Text = "Only {0} Missions"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 761)
        Me.Controls.Add(Me.tabsMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "TFMM Fan Mission Selector"
        Me.tabsMain.ResumeLayout(False)
        Me.tabFanMissions.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridFMs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsDocs.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabsMain As Windows.Forms.TabControl
    Friend WithEvents tabFanMissions As Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents tabsDocs As Windows.Forms.TabControl
    Friend WithEvents tabDoc1 As Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As Windows.Forms.ToolStripLabel
    Friend WithEvents lblTotalMissionFiles As Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As Windows.Forms.ToolStripLabel
    Friend WithEvents lblTotalDisplayed As Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As Windows.Forms.ToolStripLabel
    Friend WithEvents txtFilter As Windows.Forms.ToolStripTextBox
    Friend WithEvents btnPlay As Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnPlayOriginalMissions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlayFanMission As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlayOriginalMissions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExitGame As Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbSyncProg As Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblSyncProg As Windows.Forms.ToolStripLabel
    Friend WithEvents gridFMs As Windows.Forms.DataGridView
    Friend WithEvents btnSync As Windows.Forms.ToolStripButton
    Friend WithEvents cboGamesys As Windows.Forms.ToolStripComboBox
    Friend WithEvents ViewToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAllMissions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOnlyGameMissions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents Column9 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVer As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFileSize As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As Windows.Forms.DataGridViewTextBoxColumn
End Class
