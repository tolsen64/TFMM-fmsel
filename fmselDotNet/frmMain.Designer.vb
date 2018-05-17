<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Me.btnUninstallFanMission = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbSyncProg = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblSyncProg = New System.Windows.Forms.ToolStripLabel()
        Me.btnSync = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridFMs = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVer = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFileSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMissionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAuthor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReleased = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRating = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colCompleted = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colFileTypes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDirectory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInstallFolder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuPlayFanMission = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuPlayOriginalMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuUninstallFanMission = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabsDocs = New System.Windows.Forms.TabControl()
        Me.tabDoc1 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlayFanMission = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlayOriginalMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUninstallFanMission = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOpenMissionNotes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReturnToTFMM = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaxCash = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExitGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAllMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOnlyGameMissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.SwitchGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SS2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.T1GoldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.T2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.T3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowGameInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tabsMain.SuspendLayout()
        Me.tabFanMissions.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridFMs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.lblTotalMissionFiles, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.lblTotalDisplayed, Me.ToolStripSeparator2, Me.ToolStripLabel3, Me.txtFilter, Me.btnPlay, Me.pbSyncProg, Me.lblSyncProg, Me.btnSync})
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
        Me.btnPlay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPlayOriginalMissions, Me.btnUninstallFanMission})
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
        'btnUninstallFanMission
        '
        Me.btnUninstallFanMission.Name = "btnUninstallFanMission"
        Me.btnUninstallFanMission.Size = New System.Drawing.Size(190, 22)
        Me.btnUninstallFanMission.Text = "Uninstall Fan Mission"
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
        Me.gridFMs.AllowDrop = True
        Me.gridFMs.AllowUserToAddRows = False
        Me.gridFMs.AllowUserToDeleteRows = False
        Me.gridFMs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFMs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colVer, Me.colFileName, Me.colFileSize, Me.colMissionName, Me.colAuthor, Me.colReleased, Me.colRating, Me.colCompleted, Me.colFileTypes, Me.colDirectory, Me.colInstallFolder, Me.colHash})
        Me.gridFMs.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridFMs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridFMs.Location = New System.Drawing.Point(0, 0)
        Me.gridFMs.MultiSelect = False
        Me.gridFMs.Name = "gridFMs"
        Me.gridFMs.RowHeadersVisible = False
        Me.gridFMs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridFMs.Size = New System.Drawing.Size(622, 668)
        Me.gridFMs.TabIndex = 0
        '
        'colId
        '
        Me.colId.DataPropertyName = "rowid"
        Me.colId.HeaderText = "id"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        '
        'colVer
        '
        Me.colVer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.colVer.DataPropertyName = "Ver"
        Me.colVer.HeaderText = "Ver"
        Me.colVer.Name = "colVer"
        Me.colVer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colVer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colVer.Width = 5
        '
        'colFileName
        '
        Me.colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.colFileName.DataPropertyName = "Filename"
        Me.colFileName.HeaderText = "FileName"
        Me.colFileName.Name = "colFileName"
        Me.colFileName.ReadOnly = True
        Me.colFileName.Width = 5
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
        'colMissionName
        '
        Me.colMissionName.DataPropertyName = "MissionName"
        Me.colMissionName.HeaderText = "MissionName"
        Me.colMissionName.Name = "colMissionName"
        Me.colMissionName.Width = 200
        '
        'colAuthor
        '
        Me.colAuthor.DataPropertyName = "Author"
        Me.colAuthor.HeaderText = "Author"
        Me.colAuthor.Name = "colAuthor"
        Me.colAuthor.Width = 200
        '
        'colReleased
        '
        Me.colReleased.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.colReleased.DataPropertyName = "ReleaseDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colReleased.DefaultCellStyle = DataGridViewCellStyle2
        Me.colReleased.HeaderText = "Released"
        Me.colReleased.Name = "colReleased"
        Me.colReleased.Width = 5
        '
        'colRating
        '
        Me.colRating.DataPropertyName = "Rating"
        Me.colRating.HeaderText = "Rating"
        Me.colRating.Name = "colRating"
        Me.colRating.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRating.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colCompleted
        '
        Me.colCompleted.DataPropertyName = "Completed"
        Me.colCompleted.HeaderText = "Completed"
        Me.colCompleted.Items.AddRange(New Object() {"No", "Yes", "Normal", "Hard", "Expert"})
        Me.colCompleted.Name = "colCompleted"
        Me.colCompleted.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCompleted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colFileTypes
        '
        Me.colFileTypes.DataPropertyName = "FileTypes"
        Me.colFileTypes.HeaderText = "FileTypes"
        Me.colFileTypes.Name = "colFileTypes"
        Me.colFileTypes.ReadOnly = True
        '
        'colDirectory
        '
        Me.colDirectory.DataPropertyName = "Directory"
        Me.colDirectory.HeaderText = "Directory"
        Me.colDirectory.Name = "colDirectory"
        Me.colDirectory.ReadOnly = True
        '
        'colInstallFolder
        '
        Me.colInstallFolder.DataPropertyName = "InstallFolder"
        Me.colInstallFolder.HeaderText = "InstallFolder"
        Me.colInstallFolder.Name = "colInstallFolder"
        Me.colInstallFolder.ReadOnly = True
        '
        'colHash
        '
        Me.colHash.DataPropertyName = "Hash"
        Me.colHash.HeaderText = "Hash"
        Me.colHash.Name = "colHash"
        Me.colHash.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuPlayFanMission, Me.cmnuPlayOriginalMissions, Me.cmnuUninstallFanMission})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(191, 70)
        '
        'cmnuPlayFanMission
        '
        Me.cmnuPlayFanMission.Name = "cmnuPlayFanMission"
        Me.cmnuPlayFanMission.Size = New System.Drawing.Size(190, 22)
        Me.cmnuPlayFanMission.Text = "Play Fan Mission"
        '
        'cmnuPlayOriginalMissions
        '
        Me.cmnuPlayOriginalMissions.Name = "cmnuPlayOriginalMissions"
        Me.cmnuPlayOriginalMissions.Size = New System.Drawing.Size(190, 22)
        Me.cmnuPlayOriginalMissions.Text = "Play Original Missions"
        '
        'cmnuUninstallFanMission
        '
        Me.cmnuUninstallFanMission.Name = "cmnuUninstallFanMission"
        Me.cmnuUninstallFanMission.Size = New System.Drawing.Size(190, 22)
        Me.cmnuUninstallFanMission.Text = "Uninstall Fan Mission"
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.SwitchGameToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1264, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlayFanMission, Me.mnuPlayOriginalMissions, Me.mnuUninstallFanMission, Me.ToolStripMenuItem3, Me.mnuOpenMissionNotes, Me.mnuReturnToTFMM, Me.mnuMaxCash, Me.ToolStripMenuItem1, Me.SettingsToolStripMenuItem1, Me.ToolStripMenuItem2, Me.mnuExitGame})
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
        'mnuUninstallFanMission
        '
        Me.mnuUninstallFanMission.Name = "mnuUninstallFanMission"
        Me.mnuUninstallFanMission.Size = New System.Drawing.Size(190, 22)
        Me.mnuUninstallFanMission.Text = "Uninstall Fan Mission"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(187, 6)
        '
        'mnuOpenMissionNotes
        '
        Me.mnuOpenMissionNotes.CheckOnClick = True
        Me.mnuOpenMissionNotes.Name = "mnuOpenMissionNotes"
        Me.mnuOpenMissionNotes.Size = New System.Drawing.Size(190, 22)
        Me.mnuOpenMissionNotes.Text = "Open Mission Notes"
        '
        'mnuReturnToTFMM
        '
        Me.mnuReturnToTFMM.CheckOnClick = True
        Me.mnuReturnToTFMM.Name = "mnuReturnToTFMM"
        Me.mnuReturnToTFMM.Size = New System.Drawing.Size(190, 22)
        Me.mnuReturnToTFMM.Text = "Return to TFMM"
        '
        'mnuMaxCash
        '
        Me.mnuMaxCash.CheckOnClick = True
        Me.mnuMaxCash.Name = "mnuMaxCash"
        Me.mnuMaxCash.Size = New System.Drawing.Size(190, 22)
        Me.mnuMaxCash.Text = "Max Cash"
        Me.mnuMaxCash.Visible = False
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
        'SwitchGameToolStripMenuItem
        '
        Me.SwitchGameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SS2ToolStripMenuItem, Me.T1GoldToolStripMenuItem, Me.T2ToolStripMenuItem, Me.T3ToolStripMenuItem})
        Me.SwitchGameToolStripMenuItem.Name = "SwitchGameToolStripMenuItem"
        Me.SwitchGameToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.SwitchGameToolStripMenuItem.Text = "Switch Game"
        '
        'SS2ToolStripMenuItem
        '
        Me.SS2ToolStripMenuItem.Name = "SS2ToolStripMenuItem"
        Me.SS2ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SS2ToolStripMenuItem.Text = "System Shock 2"
        '
        'T1GoldToolStripMenuItem
        '
        Me.T1GoldToolStripMenuItem.Name = "T1GoldToolStripMenuItem"
        Me.T1GoldToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.T1GoldToolStripMenuItem.Text = "Thief 1/Gold"
        '
        'T2ToolStripMenuItem
        '
        Me.T2ToolStripMenuItem.Name = "T2ToolStripMenuItem"
        Me.T2ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.T2ToolStripMenuItem.Text = "Thief 2"
        '
        'T3ToolStripMenuItem
        '
        Me.T3ToolStripMenuItem.Name = "T3ToolStripMenuItem"
        Me.T3ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.T3ToolStripMenuItem.Text = "Thief 3"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowGameInfoToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ShowGameInfoToolStripMenuItem
        '
        Me.ShowGameInfoToolStripMenuItem.Name = "ShowGameInfoToolStripMenuItem"
        Me.ShowGameInfoToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ShowGameInfoToolStripMenuItem.Text = "Show Game Info"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AboutToolStripMenuItem.Text = "About && Tips"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.DataGridViewImageColumn1.DataPropertyName = "Ver"
        Me.DataGridViewImageColumn1.HeaderText = "Ver"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.DataPropertyName = "Rating"
        Me.DataGridViewImageColumn2.HeaderText = "Rating"
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        Me.ContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents ViewToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAllMissions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOnlyGameMissions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SwitchGameToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewImageColumn1 As Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As Windows.Forms.DataGridViewImageColumn
    Friend WithEvents mnuMaxCash As Windows.Forms.ToolStripMenuItem
    Friend WithEvents colId As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVer As Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colFileName As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFileSize As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMissionName As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAuthor As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReleased As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRating As Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colCompleted As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFileTypes As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDirectory As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInstallFolder As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHash As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuPlayFanMission As Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuPlayOriginalMissions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuUninstallFanMission As Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUninstallFanMission As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUninstallFanMission As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SS2ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents T1GoldToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents T2ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents T3ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowGameInfoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReturnToTFMM As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenMissionNotes As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As Windows.Forms.ToolStripSeparator
End Class
