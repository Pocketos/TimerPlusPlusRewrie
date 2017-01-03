<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_help
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_help))
        Me.tab_help_main = New System.Windows.Forms.TabControl()
        Me.tab_help_main_tab1 = New System.Windows.Forms.TabPage()
        Me.tab_help_main_tab1_txt = New System.Windows.Forms.RichTextBox()
        Me.tab_help_main_tab2 = New System.Windows.Forms.TabPage()
        Me.tab_help_main_tab2_txt = New System.Windows.Forms.RichTextBox()
        Me.tab_help_main_tab3 = New System.Windows.Forms.TabPage()
        Me.tab_help_main_tab3_txt = New System.Windows.Forms.RichTextBox()
        Me.tab_help_main.SuspendLayout()
        Me.tab_help_main_tab1.SuspendLayout()
        Me.tab_help_main_tab2.SuspendLayout()
        Me.tab_help_main_tab3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab_help_main
        '
        Me.tab_help_main.Controls.Add(Me.tab_help_main_tab1)
        Me.tab_help_main.Controls.Add(Me.tab_help_main_tab2)
        Me.tab_help_main.Controls.Add(Me.tab_help_main_tab3)
        Me.tab_help_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_help_main.Location = New System.Drawing.Point(0, 0)
        Me.tab_help_main.Name = "tab_help_main"
        Me.tab_help_main.SelectedIndex = 0
        Me.tab_help_main.Size = New System.Drawing.Size(616, 362)
        Me.tab_help_main.TabIndex = 0
        '
        'tab_help_main_tab1
        '
        Me.tab_help_main_tab1.Controls.Add(Me.tab_help_main_tab1_txt)
        Me.tab_help_main_tab1.Location = New System.Drawing.Point(4, 22)
        Me.tab_help_main_tab1.Name = "tab_help_main_tab1"
        Me.tab_help_main_tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_help_main_tab1.Size = New System.Drawing.Size(608, 336)
        Me.tab_help_main_tab1.TabIndex = 0
        Me.tab_help_main_tab1.Text = "Understanding Splits"
        Me.tab_help_main_tab1.UseVisualStyleBackColor = True
        '
        'tab_help_main_tab1_txt
        '
        Me.tab_help_main_tab1_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_help_main_tab1_txt.Location = New System.Drawing.Point(3, 3)
        Me.tab_help_main_tab1_txt.Name = "tab_help_main_tab1_txt"
        Me.tab_help_main_tab1_txt.ReadOnly = True
        Me.tab_help_main_tab1_txt.Size = New System.Drawing.Size(602, 330)
        Me.tab_help_main_tab1_txt.TabIndex = 0
        Me.tab_help_main_tab1_txt.Text = resources.GetString("tab_help_main_tab1_txt.Text")
        '
        'tab_help_main_tab2
        '
        Me.tab_help_main_tab2.Controls.Add(Me.tab_help_main_tab2_txt)
        Me.tab_help_main_tab2.Location = New System.Drawing.Point(4, 22)
        Me.tab_help_main_tab2.Name = "tab_help_main_tab2"
        Me.tab_help_main_tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_help_main_tab2.Size = New System.Drawing.Size(608, 336)
        Me.tab_help_main_tab2.TabIndex = 1
        Me.tab_help_main_tab2.Text = "Highlight Groups"
        Me.tab_help_main_tab2.UseVisualStyleBackColor = True
        '
        'tab_help_main_tab2_txt
        '
        Me.tab_help_main_tab2_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_help_main_tab2_txt.Location = New System.Drawing.Point(3, 3)
        Me.tab_help_main_tab2_txt.Name = "tab_help_main_tab2_txt"
        Me.tab_help_main_tab2_txt.ReadOnly = True
        Me.tab_help_main_tab2_txt.Size = New System.Drawing.Size(602, 330)
        Me.tab_help_main_tab2_txt.TabIndex = 0
        Me.tab_help_main_tab2_txt.Text = resources.GetString("tab_help_main_tab2_txt.Text")
        '
        'tab_help_main_tab3
        '
        Me.tab_help_main_tab3.Controls.Add(Me.tab_help_main_tab3_txt)
        Me.tab_help_main_tab3.Location = New System.Drawing.Point(4, 22)
        Me.tab_help_main_tab3.Name = "tab_help_main_tab3"
        Me.tab_help_main_tab3.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_help_main_tab3.Size = New System.Drawing.Size(608, 336)
        Me.tab_help_main_tab3.TabIndex = 2
        Me.tab_help_main_tab3.Text = "Fixing Errors"
        Me.tab_help_main_tab3.UseVisualStyleBackColor = True
        '
        'tab_help_main_tab3_txt
        '
        Me.tab_help_main_tab3_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_help_main_tab3_txt.Location = New System.Drawing.Point(3, 3)
        Me.tab_help_main_tab3_txt.Name = "tab_help_main_tab3_txt"
        Me.tab_help_main_tab3_txt.ReadOnly = True
        Me.tab_help_main_tab3_txt.Size = New System.Drawing.Size(602, 330)
        Me.tab_help_main_tab3_txt.TabIndex = 0
        Me.tab_help_main_tab3_txt.Text = resources.GetString("tab_help_main_tab3_txt.Text")
        '
        'frm_help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 362)
        Me.Controls.Add(Me.tab_help_main)
        Me.MaximumSize = New System.Drawing.Size(632, 401)
        Me.MinimumSize = New System.Drawing.Size(632, 401)
        Me.Name = "frm_help"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Using Timer++"
        Me.tab_help_main.ResumeLayout(False)
        Me.tab_help_main_tab1.ResumeLayout(False)
        Me.tab_help_main_tab2.ResumeLayout(False)
        Me.tab_help_main_tab3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tab_help_main As TabControl
    Friend WithEvents tab_help_main_tab1 As TabPage
    Friend WithEvents tab_help_main_tab2 As TabPage
    Friend WithEvents tab_help_main_tab3 As TabPage
    Friend WithEvents tab_help_main_tab1_txt As RichTextBox
    Friend WithEvents tab_help_main_tab2_txt As RichTextBox
    Friend WithEvents tab_help_main_tab3_txt As RichTextBox
End Class
