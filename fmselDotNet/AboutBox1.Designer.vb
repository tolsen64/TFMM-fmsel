<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
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

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents OKButton As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.linkPayPal = New System.Windows.Forms.LinkLabel()
        Me.linkTwitch = New System.Windows.Forms.LinkLabel()
        Me.txtTips = New System.Windows.Forms.TextBox()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
        Me.TableLayoutPanel.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.Label2, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Label3, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Panel1, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.txtTips, 1, 4)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(396, 258)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(318, 232)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(133, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Thief Fan Mission Manager: The NewDark Age"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(133, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "by Terry R. Olsen ( tolsen64 )"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(133, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "If you like this program, please consider a donation!"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.linkPayPal)
        Me.Panel1.Controls.Add(Me.linkTwitch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(133, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 19)
        Me.Panel1.TabIndex = 4
        '
        'linkPayPal
        '
        Me.linkPayPal.Location = New System.Drawing.Point(135, 4)
        Me.linkPayPal.Name = "linkPayPal"
        Me.linkPayPal.Size = New System.Drawing.Size(122, 15)
        Me.linkPayPal.TabIndex = 1
        Me.linkPayPal.TabStop = True
        Me.linkPayPal.Text = "Donate via PayPal!"
        Me.linkPayPal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linkTwitch
        '
        Me.linkTwitch.Location = New System.Drawing.Point(4, 4)
        Me.linkTwitch.Name = "linkTwitch"
        Me.linkTwitch.Size = New System.Drawing.Size(125, 15)
        Me.linkTwitch.TabIndex = 0
        Me.linkTwitch.TabStop = True
        Me.linkTwitch.Text = "Donate via Twitch!"
        Me.linkTwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTips
        '
        Me.txtTips.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTips.Location = New System.Drawing.Point(133, 103)
        Me.txtTips.Multiline = True
        Me.txtTips.Name = "txtTips"
        Me.txtTips.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTips.Size = New System.Drawing.Size(260, 123)
        Me.txtTips.TabIndex = 5
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
        Me.LogoPictureBox.Size = New System.Drawing.Size(124, 252)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'AboutBox1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(414, 276)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox1"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AboutBox1"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents linkPayPal As Windows.Forms.LinkLabel
    Friend WithEvents linkTwitch As Windows.Forms.LinkLabel
    Friend WithEvents txtTips As Windows.Forms.TextBox
End Class
