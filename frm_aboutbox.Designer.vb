<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_aboutbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_aboutbox))
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.panel_about_info = New System.Windows.Forms.Panel()
        Me.RichTextBox_GNU = New System.Windows.Forms.RichTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panel_about_info.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(3, 0)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(72, 13)
        Me.lblProductName.TabIndex = 0
        Me.lblProductName.Text = "ProductName"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(3, 13)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyName.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCompanyName.Location = New System.Drawing.Point(3, 39)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(79, 13)
        Me.lblCompanyName.TabIndex = 2
        Me.lblCompanyName.Text = "CompanyName"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Location = New System.Drawing.Point(3, 26)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(51, 13)
        Me.lblCopyright.TabIndex = 3
        Me.lblCopyright.Text = "Copyright"
        '
        'panel_about_info
        '
        Me.panel_about_info.Controls.Add(Me.lblProductName)
        Me.panel_about_info.Controls.Add(Me.lblCompanyName)
        Me.panel_about_info.Controls.Add(Me.lblCopyright)
        Me.panel_about_info.Controls.Add(Me.lblVersion)
        Me.panel_about_info.Location = New System.Drawing.Point(70, 6)
        Me.panel_about_info.Name = "panel_about_info"
        Me.panel_about_info.Size = New System.Drawing.Size(165, 56)
        Me.panel_about_info.TabIndex = 4
        '
        'RichTextBox_GNU
        '
        Me.RichTextBox_GNU.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RichTextBox_GNU.Location = New System.Drawing.Point(9, 68)
        Me.RichTextBox_GNU.MaxLength = 0
        Me.RichTextBox_GNU.Name = "RichTextBox_GNU"
        Me.RichTextBox_GNU.ReadOnly = True
        Me.RichTextBox_GNU.Size = New System.Drawing.Size(281, 103)
        Me.RichTextBox_GNU.TabIndex = 5
        Me.RichTextBox_GNU.Text = resources.GetString("RichTextBox_GNU.Text")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Timer__.My.Resources.Resources.Korkscrew_logo
        Me.PictureBox1.Location = New System.Drawing.Point(9, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'frm_aboutbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 180)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RichTextBox_GNU)
        Me.Controls.Add(Me.panel_about_info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_aboutbox"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frm_aboutbox"
        Me.panel_about_info.ResumeLayout(False)
        Me.panel_about_info.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblProductName As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblCompanyName As Label
    Friend WithEvents lblCopyright As Label
    Friend WithEvents panel_about_info As Panel
    Friend WithEvents RichTextBox_GNU As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
