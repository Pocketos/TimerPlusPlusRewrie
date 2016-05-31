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
        Me.lbltimertext = New System.Windows.Forms.Label()
        Me.tmMain = New System.Windows.Forms.Timer(Me.components)
        Me.btnpause = New System.Windows.Forms.Button()
        Me.btnSplit = New System.Windows.Forms.Button()
        Me.txtdesc = New System.Windows.Forms.TextBox()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.lblwktm = New System.Windows.Forms.Label()
        Me.chkbxrecorded = New System.Windows.Forms.CheckBox()
        Me.btnMinusTime = New System.Windows.Forms.Button()
        Me.btnAddTime = New System.Windows.Forms.Button()
        Me.SplitsDataTableDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewStartTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewStopTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTimeWorkedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewRecordedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SplitsDataTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitsDataSet = New Timer__.SplitsDataSet()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearSplitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmPaused = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SplitsDataTableDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitsDataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbltimertext
        '
        Me.lbltimertext.AutoSize = True
        Me.lbltimertext.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltimertext.Location = New System.Drawing.Point(5, 25)
        Me.lbltimertext.Name = "lbltimertext"
        Me.lbltimertext.Size = New System.Drawing.Size(119, 30)
        Me.lbltimertext.TabIndex = 0
        Me.lbltimertext.Text = "Not Started"
        '
        'tmMain
        '
        Me.tmMain.Interval = 1000
        '
        'btnpause
        '
        Me.btnpause.Enabled = False
        Me.btnpause.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpause.Location = New System.Drawing.Point(359, 311)
        Me.btnpause.Name = "btnpause"
        Me.btnpause.Size = New System.Drawing.Size(335, 48)
        Me.btnpause.TabIndex = 2
        Me.btnpause.Text = "Pause"
        Me.btnpause.UseVisualStyleBackColor = True
        '
        'btnSplit
        '
        Me.btnSplit.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSplit.Location = New System.Drawing.Point(10, 311)
        Me.btnSplit.Name = "btnSplit"
        Me.btnSplit.Size = New System.Drawing.Size(335, 48)
        Me.btnSplit.TabIndex = 7
        Me.btnSplit.Text = "Split"
        Me.btnSplit.UseVisualStyleBackColor = True
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(10, 59)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(536, 20)
        Me.txtdesc.TabIndex = 8
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.Location = New System.Drawing.Point(589, 21)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(63, 30)
        Me.lbltime.TabIndex = 9
        Me.lbltime.Text = "Time:"
        '
        'lblwktm
        '
        Me.lblwktm.AutoSize = True
        Me.lblwktm.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblwktm.Location = New System.Drawing.Point(579, 46)
        Me.lblwktm.Name = "lblwktm"
        Me.lblwktm.Size = New System.Drawing.Size(89, 30)
        Me.lblwktm.TabIndex = 10
        Me.lblwktm.Text = "00:00:00"
        '
        'chkbxrecorded
        '
        Me.chkbxrecorded.AutoSize = True
        Me.chkbxrecorded.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbxrecorded.Location = New System.Drawing.Point(324, 28)
        Me.chkbxrecorded.Name = "chkbxrecorded"
        Me.chkbxrecorded.Size = New System.Drawing.Size(227, 29)
        Me.chkbxrecorded.TabIndex = 13
        Me.chkbxrecorded.Text = "Mark split as recorded?"
        Me.chkbxrecorded.UseVisualStyleBackColor = True
        '
        'btnMinusTime
        '
        Me.btnMinusTime.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinusTime.Location = New System.Drawing.Point(552, 25)
        Me.btnMinusTime.Name = "btnMinusTime"
        Me.btnMinusTime.Size = New System.Drawing.Size(26, 54)
        Me.btnMinusTime.TabIndex = 14
        Me.btnMinusTime.Text = "-"
        Me.btnMinusTime.UseVisualStyleBackColor = True
        '
        'btnAddTime
        '
        Me.btnAddTime.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTime.Location = New System.Drawing.Point(668, 25)
        Me.btnAddTime.Name = "btnAddTime"
        Me.btnAddTime.Size = New System.Drawing.Size(26, 54)
        Me.btnAddTime.TabIndex = 15
        Me.btnAddTime.Text = "+"
        Me.btnAddTime.UseVisualStyleBackColor = True
        '
        'SplitsDataTableDataGridView
        '
        Me.SplitsDataTableDataGridView.AllowUserToAddRows = False
        Me.SplitsDataTableDataGridView.AllowUserToDeleteRows = False
        Me.SplitsDataTableDataGridView.AutoGenerateColumns = False
        Me.SplitsDataTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SplitsDataTableDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewIDColumn, Me.DataGridViewDescriptionColumn, Me.DataGridViewStartTimeColumn, Me.DataGridViewStopTimeColumn, Me.DataGridViewTimeWorkedColumn, Me.DataGridViewRecordedColumn})
        Me.SplitsDataTableDataGridView.DataSource = Me.SplitsDataTableBindingSource
        Me.SplitsDataTableDataGridView.Location = New System.Drawing.Point(10, 85)
        Me.SplitsDataTableDataGridView.Name = "SplitsDataTableDataGridView"
        Me.SplitsDataTableDataGridView.RowHeadersVisible = False
        Me.SplitsDataTableDataGridView.Size = New System.Drawing.Size(684, 220)
        Me.SplitsDataTableDataGridView.TabIndex = 16
        '
        'DataGridViewIDColumn
        '
        Me.DataGridViewIDColumn.DataPropertyName = "ID"
        Me.DataGridViewIDColumn.HeaderText = "ID"
        Me.DataGridViewIDColumn.MinimumWidth = 30
        Me.DataGridViewIDColumn.Name = "DataGridViewIDColumn"
        Me.DataGridViewIDColumn.ReadOnly = True
        Me.DataGridViewIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewIDColumn.Width = 30
        '
        'DataGridViewDescriptionColumn
        '
        Me.DataGridViewDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewDescriptionColumn.DataPropertyName = "Description"
        Me.DataGridViewDescriptionColumn.HeaderText = "Description"
        Me.DataGridViewDescriptionColumn.Name = "DataGridViewDescriptionColumn"
        Me.DataGridViewDescriptionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewStartTimeColumn
        '
        Me.DataGridViewStartTimeColumn.DataPropertyName = "StartTime"
        Me.DataGridViewStartTimeColumn.HeaderText = "StartTime"
        Me.DataGridViewStartTimeColumn.Name = "DataGridViewStartTimeColumn"
        Me.DataGridViewStartTimeColumn.ReadOnly = True
        Me.DataGridViewStartTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewStartTimeColumn.Width = 75
        '
        'DataGridViewStopTimeColumn
        '
        Me.DataGridViewStopTimeColumn.DataPropertyName = "StopTime"
        Me.DataGridViewStopTimeColumn.HeaderText = "StopTime"
        Me.DataGridViewStopTimeColumn.Name = "DataGridViewStopTimeColumn"
        Me.DataGridViewStopTimeColumn.ReadOnly = True
        Me.DataGridViewStopTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewStopTimeColumn.Width = 75
        '
        'DataGridViewTimeWorkedColumn
        '
        Me.DataGridViewTimeWorkedColumn.DataPropertyName = "TimeWorked"
        Me.DataGridViewTimeWorkedColumn.HeaderText = "TimeWorked"
        Me.DataGridViewTimeWorkedColumn.Name = "DataGridViewTimeWorkedColumn"
        Me.DataGridViewTimeWorkedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTimeWorkedColumn.Width = 75
        '
        'DataGridViewRecordedColumn
        '
        Me.DataGridViewRecordedColumn.DataPropertyName = "Recorded"
        Me.DataGridViewRecordedColumn.HeaderText = "Recorded"
        Me.DataGridViewRecordedColumn.MinimumWidth = 75
        Me.DataGridViewRecordedColumn.Name = "DataGridViewRecordedColumn"
        Me.DataGridViewRecordedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRecordedColumn.Width = 75
        '
        'SplitsDataTableBindingSource
        '
        Me.SplitsDataTableBindingSource.DataMember = "SplitsDataTable"
        Me.SplitsDataTableBindingSource.DataSource = Me.SplitsDataSet
        '
        'SplitsDataSet
        '
        Me.SplitsDataSet.DataSetName = "SplitsDataSet"
        Me.SplitsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SplitsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(704, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SplitsToolStripMenuItem
        '
        Me.SplitsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ReviewToolStripMenuItem, Me.ClearSplitsToolStripMenuItem})
        Me.SplitsToolStripMenuItem.Name = "SplitsToolStripMenuItem"
        Me.SplitsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.SplitsToolStripMenuItem.Text = "Splits"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ReviewToolStripMenuItem
        '
        Me.ReviewToolStripMenuItem.Name = "ReviewToolStripMenuItem"
        Me.ReviewToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ReviewToolStripMenuItem.Text = "Review"
        '
        'ClearSplitsToolStripMenuItem
        '
        Me.ClearSplitsToolStripMenuItem.Name = "ClearSplitsToolStripMenuItem"
        Me.ClearSplitsToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ClearSplitsToolStripMenuItem.Text = "Clear Splits"
        '
        'tmPaused
        '
        Me.tmPaused.Interval = 750
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 369)
        Me.Controls.Add(Me.SplitsDataTableDataGridView)
        Me.Controls.Add(Me.btnAddTime)
        Me.Controls.Add(Me.btnMinusTime)
        Me.Controls.Add(Me.chkbxrecorded)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lblwktm)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.txtdesc)
        Me.Controls.Add(Me.btnSplit)
        Me.Controls.Add(Me.btnpause)
        Me.Controls.Add(Me.lbltimertext)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(720, 408)
        Me.MinimumSize = New System.Drawing.Size(720, 408)
        Me.Name = "frmMain"
        Me.Text = "Timer++"
        CType(Me.SplitsDataTableDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitsDataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltimertext As Label
    Friend WithEvents tmMain As Timer
    Friend WithEvents btnpause As Button
    Friend WithEvents btnSplit As Button
    Friend WithEvents txtdesc As TextBox
    Friend WithEvents lbltime As Label
    Friend WithEvents lblwktm As Label
    Friend WithEvents chkbxrecorded As CheckBox
    Friend WithEvents btnMinusTime As Button
    Friend WithEvents btnAddTime As Button
    Friend WithEvents SplitsDataSet As SplitsDataSet
    Friend WithEvents SplitsDataTableBindingSource As BindingSource
    Friend WithEvents SplitsDataTableDataGridView As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearSplitsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tmPaused As Timer
    Friend WithEvents DataGridViewIDColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDescriptionColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewStartTimeColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewStopTimeColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTimeWorkedColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewRecordedColumn As DataGridViewCheckBoxColumn
End Class
