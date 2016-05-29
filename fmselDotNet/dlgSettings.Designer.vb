<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgSettings
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.grpSettings = New System.Windows.Forms.GroupBox()
        Me.lstFMDirs = New System.Windows.Forms.ListBox()
        Me.btnAddDir = New System.Windows.Forms.Button()
        Me.btnRemoveDir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtModPath = New System.Windows.Forms.TextBox()
        Me.lblModPath = New System.Windows.Forms.Label()
        Me.txtFmPath = New System.Windows.Forms.TextBox()
        Me.lblFmPath = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkAlwaysStartFMSEL = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 226)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'grpSettings
        '
        Me.grpSettings.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.grpSettings.Controls.Add(Me.lstFMDirs)
        Me.grpSettings.Controls.Add(Me.btnAddDir)
        Me.grpSettings.Controls.Add(Me.btnRemoveDir)
        Me.grpSettings.Location = New System.Drawing.Point(12, 93)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(411, 125)
        Me.grpSettings.TabIndex = 11
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Fan Mission Archive Directories"
        '
        'lstFMDirs
        '
        Me.lstFMDirs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFMDirs.FormattingEnabled = True
        Me.lstFMDirs.Location = New System.Drawing.Point(6, 19)
        Me.lstFMDirs.Name = "lstFMDirs"
        Me.lstFMDirs.Size = New System.Drawing.Size(399, 69)
        Me.lstFMDirs.TabIndex = 1
        '
        'btnAddDir
        '
        Me.btnAddDir.Location = New System.Drawing.Point(6, 94)
        Me.btnAddDir.Name = "btnAddDir"
        Me.btnAddDir.Size = New System.Drawing.Size(98, 23)
        Me.btnAddDir.TabIndex = 2
        Me.btnAddDir.Text = "Add Directories"
        Me.btnAddDir.UseVisualStyleBackColor = True
        '
        'btnRemoveDir
        '
        Me.btnRemoveDir.Location = New System.Drawing.Point(291, 94)
        Me.btnRemoveDir.Name = "btnRemoveDir"
        Me.btnRemoveDir.Size = New System.Drawing.Size(114, 23)
        Me.btnRemoveDir.TabIndex = 3
        Me.btnRemoveDir.Text = "Remove Directory"
        Me.btnRemoveDir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtModPath)
        Me.GroupBox1.Controls.Add(Me.lblModPath)
        Me.GroupBox1.Controls.Add(Me.txtFmPath)
        Me.GroupBox1.Controls.Add(Me.lblFmPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 75)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "cam_mod.ini"
        '
        'txtModPath
        '
        Me.txtModPath.Enabled = False
        Me.txtModPath.Location = New System.Drawing.Point(96, 45)
        Me.txtModPath.Name = "txtModPath"
        Me.txtModPath.ReadOnly = True
        Me.txtModPath.Size = New System.Drawing.Size(309, 20)
        Me.txtModPath.TabIndex = 5
        '
        'lblModPath
        '
        Me.lblModPath.AutoSize = True
        Me.lblModPath.Location = New System.Drawing.Point(6, 48)
        Me.lblModPath.Name = "lblModPath"
        Me.lblModPath.Size = New System.Drawing.Size(57, 13)
        Me.lblModPath.TabIndex = 4
        Me.lblModPath.Text = "mod_path:"
        '
        'txtFmPath
        '
        Me.txtFmPath.Enabled = False
        Me.txtFmPath.Location = New System.Drawing.Point(96, 19)
        Me.txtFmPath.Name = "txtFmPath"
        Me.txtFmPath.ReadOnly = True
        Me.txtFmPath.Size = New System.Drawing.Size(309, 20)
        Me.txtFmPath.TabIndex = 1
        '
        'lblFmPath
        '
        Me.lblFmPath.AutoSize = True
        Me.lblFmPath.Location = New System.Drawing.Point(6, 22)
        Me.lblFmPath.Name = "lblFmPath"
        Me.lblFmPath.Size = New System.Drawing.Size(48, 13)
        Me.lblFmPath.TabIndex = 0
        Me.lblFmPath.Text = "fm_path:"
        '
        'chkAlwaysStartFMSEL
        '
        Me.chkAlwaysStartFMSEL.AutoSize = True
        Me.chkAlwaysStartFMSEL.Location = New System.Drawing.Point(12, 233)
        Me.chkAlwaysStartFMSEL.Name = "chkAlwaysStartFMSEL"
        Me.chkAlwaysStartFMSEL.Size = New System.Drawing.Size(195, 17)
        Me.chkAlwaysStartFMSEL.TabIndex = 13
        Me.chkAlwaysStartFMSEL.Text = "Always start FMSEL after game exit."
        Me.chkAlwaysStartFMSEL.UseVisualStyleBackColor = True
        '
        'dlgSettings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 267)
        Me.Controls.Add(Me.chkAlwaysStartFMSEL)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpSettings.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents grpSettings As Windows.Forms.GroupBox
    Friend WithEvents lstFMDirs As Windows.Forms.ListBox
    Friend WithEvents btnAddDir As Windows.Forms.Button
    Friend WithEvents btnRemoveDir As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents txtFmPath As Windows.Forms.TextBox
    Friend WithEvents lblFmPath As Windows.Forms.Label
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents txtModPath As Windows.Forms.TextBox
    Friend WithEvents lblModPath As Windows.Forms.Label
    Friend WithEvents chkAlwaysStartFMSEL As Windows.Forms.CheckBox
End Class
