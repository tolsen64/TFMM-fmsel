<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnLoadAvailableMissions = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblRowCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFilteredRowCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDownloadProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.progDownload = New System.Windows.Forms.ToolStripProgressBar()
        Me.gridMissions = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DownloadMissionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMissionInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.gridMissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLoadAvailableMissions, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.txtFilter, Me.ToolStripSeparator2, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(722, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnLoadAvailableMissions
        '
        Me.btnLoadAvailableMissions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLoadAvailableMissions.Image = CType(resources.GetObject("btnLoadAvailableMissions.Image"), System.Drawing.Image)
        Me.btnLoadAvailableMissions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoadAvailableMissions.Name = "btnLoadAvailableMissions"
        Me.btnLoadAvailableMissions.Size = New System.Drawing.Size(23, 22)
        Me.btnLoadAvailableMissions.Text = "ToolStripButton1"
        Me.btnLoadAvailableMissions.ToolTipText = "Get Mission List"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripLabel1.Text = "Search/Filter:"
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblRowCount, Me.lblFilteredRowCount, Me.lblDownloadProgress, Me.progDownload})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 522)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(722, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblRowCount
        '
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(0, 17)
        '
        'lblFilteredRowCount
        '
        Me.lblFilteredRowCount.Name = "lblFilteredRowCount"
        Me.lblFilteredRowCount.Size = New System.Drawing.Size(0, 17)
        '
        'lblDownloadProgress
        '
        Me.lblDownloadProgress.Name = "lblDownloadProgress"
        Me.lblDownloadProgress.Size = New System.Drawing.Size(84, 17)
        Me.lblDownloadProgress.Text = "Downloading: "
        Me.lblDownloadProgress.Visible = False
        '
        'progDownload
        '
        Me.progDownload.Name = "progDownload"
        Me.progDownload.Size = New System.Drawing.Size(100, 16)
        Me.progDownload.Visible = False
        '
        'gridMissions
        '
        Me.gridMissions.AllowUserToAddRows = False
        Me.gridMissions.AllowUserToDeleteRows = False
        Me.gridMissions.AllowUserToOrderColumns = True
        Me.gridMissions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridMissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridMissions.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridMissions.Location = New System.Drawing.Point(3, 28)
        Me.gridMissions.MultiSelect = False
        Me.gridMissions.Name = "gridMissions"
        Me.gridMissions.ReadOnly = True
        Me.gridMissions.RowHeadersVisible = False
        Me.gridMissions.Size = New System.Drawing.Size(716, 491)
        Me.gridMissions.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewMissionInfoToolStripMenuItem, Me.DownloadMissionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 70)
        '
        'DownloadMissionToolStripMenuItem
        '
        Me.DownloadMissionToolStripMenuItem.Name = "DownloadMissionToolStripMenuItem"
        Me.DownloadMissionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DownloadMissionToolStripMenuItem.Text = "Download Mission"
        '
        'ViewMissionInfoToolStripMenuItem
        '
        Me.ViewMissionInfoToolStripMenuItem.Name = "ViewMissionInfoToolStripMenuItem"
        Me.ViewMissionInfoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewMissionInfoToolStripMenuItem.Text = "View Mission Info"
        '
        'UserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gridMissions)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "UserControl"
        Me.Size = New System.Drawing.Size(722, 544)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.gridMissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents btnLoadAvailableMissions As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As Windows.Forms.ToolStripLabel
    Friend WithEvents txtFilter As Windows.Forms.ToolStripTextBox
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents lblRowCount As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gridMissions As Windows.Forms.DataGridView
    Friend WithEvents lblFilteredRowCount As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewMissionInfoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadMissionToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDownloadProgress As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents progDownload As Windows.Forms.ToolStripProgressBar
End Class
