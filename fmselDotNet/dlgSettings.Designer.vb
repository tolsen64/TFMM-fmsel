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
        Me.chkReturnToTFMMDefault = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGameExeT3 = New System.Windows.Forms.Button()
        Me.btnGameExeT2 = New System.Windows.Forms.Button()
        Me.btnGameExeT1 = New System.Windows.Forms.Button()
        Me.btnGameExeSS2 = New System.Windows.Forms.Button()
        Me.txtGameExeT3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGameExeT2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGameExeT1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGameExeSS2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkMaxCashDefault = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 358)
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
        Me.grpSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.grpSettings.Controls.Add(Me.lstFMDirs)
        Me.grpSettings.Controls.Add(Me.btnAddDir)
        Me.grpSettings.Controls.Add(Me.btnRemoveDir)
        Me.grpSettings.Location = New System.Drawing.Point(12, 224)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(411, 125)
        Me.grpSettings.TabIndex = 11
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Fan Mission Archive Directories (Use Add button or drag directory into list box)"
        '
        'lstFMDirs
        '
        Me.lstFMDirs.AllowDrop = True
        Me.lstFMDirs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFMDirs.FormattingEnabled = True
        Me.lstFMDirs.Location = New System.Drawing.Point(6, 19)
        Me.lstFMDirs.Name = "lstFMDirs"
        Me.lstFMDirs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
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
        Me.btnRemoveDir.Text = "Remove Selected"
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
        Me.txtModPath.Location = New System.Drawing.Point(69, 45)
        Me.txtModPath.Name = "txtModPath"
        Me.txtModPath.ReadOnly = True
        Me.txtModPath.Size = New System.Drawing.Size(336, 20)
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
        Me.txtFmPath.Location = New System.Drawing.Point(69, 19)
        Me.txtFmPath.Name = "txtFmPath"
        Me.txtFmPath.ReadOnly = True
        Me.txtFmPath.Size = New System.Drawing.Size(336, 20)
        Me.txtFmPath.TabIndex = 1
        '
        'lblFmPath
        '
        Me.lblFmPath.AutoSize = True
        Me.lblFmPath.Location = New System.Drawing.Point(15, 22)
        Me.lblFmPath.Name = "lblFmPath"
        Me.lblFmPath.Size = New System.Drawing.Size(48, 13)
        Me.lblFmPath.TabIndex = 0
        Me.lblFmPath.Text = "fm_path:"
        '
        'chkReturnToTFMMDefault
        '
        Me.chkReturnToTFMMDefault.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkReturnToTFMMDefault.AutoSize = True
        Me.chkReturnToTFMMDefault.Location = New System.Drawing.Point(12, 365)
        Me.chkReturnToTFMMDefault.Name = "chkReturnToTFMMDefault"
        Me.chkReturnToTFMMDefault.Size = New System.Drawing.Size(141, 17)
        Me.chkReturnToTFMMDefault.TabIndex = 13
        Me.chkReturnToTFMMDefault.Text = "Return to TFMM Default"
        Me.chkReturnToTFMMDefault.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGameExeT3)
        Me.GroupBox2.Controls.Add(Me.btnGameExeT2)
        Me.GroupBox2.Controls.Add(Me.btnGameExeT1)
        Me.GroupBox2.Controls.Add(Me.btnGameExeSS2)
        Me.GroupBox2.Controls.Add(Me.txtGameExeT3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtGameExeT2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtGameExeT1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtGameExeSS2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(411, 124)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Game EXE's (Use buttons to browse or drag EXE's to appropriate box)"
        '
        'btnGameExeT3
        '
        Me.btnGameExeT3.Location = New System.Drawing.Point(380, 97)
        Me.btnGameExeT3.Name = "btnGameExeT3"
        Me.btnGameExeT3.Size = New System.Drawing.Size(25, 20)
        Me.btnGameExeT3.TabIndex = 13
        Me.btnGameExeT3.Text = "..."
        Me.btnGameExeT3.UseVisualStyleBackColor = True
        '
        'btnGameExeT2
        '
        Me.btnGameExeT2.Location = New System.Drawing.Point(380, 71)
        Me.btnGameExeT2.Name = "btnGameExeT2"
        Me.btnGameExeT2.Size = New System.Drawing.Size(25, 20)
        Me.btnGameExeT2.TabIndex = 12
        Me.btnGameExeT2.Text = "..."
        Me.btnGameExeT2.UseVisualStyleBackColor = True
        '
        'btnGameExeT1
        '
        Me.btnGameExeT1.Location = New System.Drawing.Point(380, 45)
        Me.btnGameExeT1.Name = "btnGameExeT1"
        Me.btnGameExeT1.Size = New System.Drawing.Size(25, 20)
        Me.btnGameExeT1.TabIndex = 11
        Me.btnGameExeT1.Text = "..."
        Me.btnGameExeT1.UseVisualStyleBackColor = True
        '
        'btnGameExeSS2
        '
        Me.btnGameExeSS2.Location = New System.Drawing.Point(380, 19)
        Me.btnGameExeSS2.Name = "btnGameExeSS2"
        Me.btnGameExeSS2.Size = New System.Drawing.Size(25, 20)
        Me.btnGameExeSS2.TabIndex = 10
        Me.btnGameExeSS2.Text = "..."
        Me.btnGameExeSS2.UseVisualStyleBackColor = True
        '
        'txtGameExeT3
        '
        Me.txtGameExeT3.AllowDrop = True
        Me.txtGameExeT3.Location = New System.Drawing.Point(42, 97)
        Me.txtGameExeT3.Name = "txtGameExeT3"
        Me.txtGameExeT3.ReadOnly = True
        Me.txtGameExeT3.Size = New System.Drawing.Size(332, 20)
        Me.txtGameExeT3.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "T3:"
        '
        'txtGameExeT2
        '
        Me.txtGameExeT2.AllowDrop = True
        Me.txtGameExeT2.Location = New System.Drawing.Point(42, 71)
        Me.txtGameExeT2.Name = "txtGameExeT2"
        Me.txtGameExeT2.ReadOnly = True
        Me.txtGameExeT2.Size = New System.Drawing.Size(332, 20)
        Me.txtGameExeT2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "T2:"
        '
        'txtGameExeT1
        '
        Me.txtGameExeT1.AllowDrop = True
        Me.txtGameExeT1.Location = New System.Drawing.Point(42, 45)
        Me.txtGameExeT1.Name = "txtGameExeT1"
        Me.txtGameExeT1.ReadOnly = True
        Me.txtGameExeT1.Size = New System.Drawing.Size(332, 20)
        Me.txtGameExeT1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "T1:"
        '
        'txtGameExeSS2
        '
        Me.txtGameExeSS2.AllowDrop = True
        Me.txtGameExeSS2.Location = New System.Drawing.Point(42, 19)
        Me.txtGameExeSS2.Name = "txtGameExeSS2"
        Me.txtGameExeSS2.ReadOnly = True
        Me.txtGameExeSS2.Size = New System.Drawing.Size(332, 20)
        Me.txtGameExeSS2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SS2:"
        '
        'chkMaxCashDefault
        '
        Me.chkMaxCashDefault.AutoSize = True
        Me.chkMaxCashDefault.Location = New System.Drawing.Point(161, 365)
        Me.chkMaxCashDefault.Name = "chkMaxCashDefault"
        Me.chkMaxCashDefault.Size = New System.Drawing.Size(110, 17)
        Me.chkMaxCashDefault.TabIndex = 15
        Me.chkMaxCashDefault.Text = "Max Cash Default"
        Me.chkMaxCashDefault.UseVisualStyleBackColor = True
        '
        'dlgSettings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 399)
        Me.Controls.Add(Me.chkMaxCashDefault)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkReturnToTFMMDefault)
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents chkReturnToTFMMDefault As Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents btnGameExeT3 As Windows.Forms.Button
    Friend WithEvents btnGameExeT2 As Windows.Forms.Button
    Friend WithEvents btnGameExeT1 As Windows.Forms.Button
    Friend WithEvents btnGameExeSS2 As Windows.Forms.Button
    Friend WithEvents txtGameExeT3 As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txtGameExeT2 As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtGameExeT1 As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtGameExeSS2 As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents chkMaxCashDefault As Windows.Forms.CheckBox
End Class
