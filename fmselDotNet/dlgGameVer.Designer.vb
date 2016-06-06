<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgGameVer
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.rdoSS2 = New System.Windows.Forms.RadioButton()
        Me.rdoT1 = New System.Windows.Forms.RadioButton()
        Me.rdoT2 = New System.Windows.Forms.RadioButton()
        Me.rdoT3 = New System.Windows.Forms.RadioButton()
        Me.rdoUnk = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 132)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(163, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(7, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(88, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'rdoSS2
        '
        Me.rdoSS2.AutoSize = True
        Me.rdoSS2.Location = New System.Drawing.Point(12, 12)
        Me.rdoSS2.Name = "rdoSS2"
        Me.rdoSS2.Size = New System.Drawing.Size(102, 17)
        Me.rdoSS2.TabIndex = 1
        Me.rdoSS2.TabStop = True
        Me.rdoSS2.Tag = "SS2"
        Me.rdoSS2.Text = "System Shock 2"
        Me.rdoSS2.UseVisualStyleBackColor = True
        '
        'rdoT1
        '
        Me.rdoT1.AutoSize = True
        Me.rdoT1.Location = New System.Drawing.Point(12, 35)
        Me.rdoT1.Name = "rdoT1"
        Me.rdoT1.Size = New System.Drawing.Size(163, 17)
        Me.rdoT1.TabIndex = 2
        Me.rdoT1.TabStop = True
        Me.rdoT1.Tag = "T1"
        Me.rdoT1.Text = "Thief: The Dark Projet / Gold"
        Me.rdoT1.UseVisualStyleBackColor = True
        '
        'rdoT2
        '
        Me.rdoT2.AutoSize = True
        Me.rdoT2.Location = New System.Drawing.Point(12, 58)
        Me.rdoT2.Name = "rdoT2"
        Me.rdoT2.Size = New System.Drawing.Size(125, 17)
        Me.rdoT2.TabIndex = 3
        Me.rdoT2.TabStop = True
        Me.rdoT2.Tag = "T2"
        Me.rdoT2.Text = "Thief: The Metal Age"
        Me.rdoT2.UseVisualStyleBackColor = True
        '
        'rdoT3
        '
        Me.rdoT3.AutoSize = True
        Me.rdoT3.Location = New System.Drawing.Point(12, 81)
        Me.rdoT3.Name = "rdoT3"
        Me.rdoT3.Size = New System.Drawing.Size(135, 17)
        Me.rdoT3.TabIndex = 4
        Me.rdoT3.TabStop = True
        Me.rdoT3.Tag = "T3"
        Me.rdoT3.Text = "Thief: Deadly Shadows"
        Me.rdoT3.UseVisualStyleBackColor = True
        '
        'rdoUnk
        '
        Me.rdoUnk.AutoSize = True
        Me.rdoUnk.Location = New System.Drawing.Point(12, 104)
        Me.rdoUnk.Name = "rdoUnk"
        Me.rdoUnk.Size = New System.Drawing.Size(155, 17)
        Me.rdoUnk.TabIndex = 5
        Me.rdoUnk.TabStop = True
        Me.rdoUnk.Tag = "Unk"
        Me.rdoUnk.Text = "Unknown / Corrupt Archive"
        Me.rdoUnk.UseVisualStyleBackColor = True
        '
        'dlgGameVer
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(187, 173)
        Me.Controls.Add(Me.rdoUnk)
        Me.Controls.Add(Me.rdoT3)
        Me.Controls.Add(Me.rdoT2)
        Me.Controls.Add(Me.rdoT1)
        Me.Controls.Add(Me.rdoSS2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgGameVer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Set Mission Game Type"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents rdoSS2 As Windows.Forms.RadioButton
    Friend WithEvents rdoT1 As Windows.Forms.RadioButton
    Friend WithEvents rdoT2 As Windows.Forms.RadioButton
    Friend WithEvents rdoT3 As Windows.Forms.RadioButton
    Friend WithEvents rdoUnk As Windows.Forms.RadioButton
End Class
