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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lbltimertext = New System.Windows.Forms.Label()
        Me.tmMain = New System.Windows.Forms.Timer(Me.components)
        Me.btnpause = New System.Windows.Forms.Button()
        Me.btnSplit = New System.Windows.Forms.Button()
        Me.txtdesc = New System.Windows.Forms.TextBox()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.lblwktm = New System.Windows.Forms.Label()
        Me.btnMinusTime = New System.Windows.Forms.Button()
        Me.btnAddTime = New System.Windows.Forms.Button()
        Me.SplitsDataTableDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewStartTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewStopTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTimeWorkedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewRecordedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewColorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTimeInSecondsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsSplitsGridView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.highlight_blue = New System.Windows.Forms.ToolStripMenuItem()
        Me.highlight_cyan = New System.Windows.Forms.ToolStripMenuItem()
        Me.highlight_green = New System.Windows.Forms.ToolStripMenuItem()
        Me.highlight_purple = New System.Windows.Forms.ToolStripMenuItem()
        Me.highlight_red = New System.Windows.Forms.ToolStripMenuItem()
        Me.highlight_tan = New System.Windows.Forms.ToolStripMenuItem()
        Me.highlight_yellow = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveHighlightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.highlight_voidout = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitsDataTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitsDataSet = New Timer__.SplitsDataSet()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnablePauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTipsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportFromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteLastSplitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearSplitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TotalWorkTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowCombinedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSplitLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ssBottomMain = New System.Windows.Forms.StatusStrip()
        Me.tsslFilePath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslLastSaved = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MarkRecordedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitsDataTableDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsSplitsGridView.SuspendLayout()
        CType(Me.SplitsDataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ssBottomMain.SuspendLayout()
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
        Me.ToolTip.SetToolTip(Me.lbltimertext, "Current system time and date.")
        '
        'tmMain
        '
        Me.tmMain.Interval = 1000
        '
        'btnpause
        '
        Me.btnpause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnpause.Enabled = False
        Me.btnpause.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpause.Location = New System.Drawing.Point(479, 368)
        Me.btnpause.Name = "btnpause"
        Me.btnpause.Size = New System.Drawing.Size(139, 48)
        Me.btnpause.TabIndex = 2
        Me.btnpause.Text = "Pause"
        Me.ToolTip.SetToolTip(Me.btnpause, "Pause the Work Time counter.")
        Me.btnpause.UseVisualStyleBackColor = True
        '
        'btnSplit
        '
        Me.btnSplit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSplit.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSplit.Location = New System.Drawing.Point(10, 368)
        Me.btnSplit.Name = "btnSplit"
        Me.btnSplit.Size = New System.Drawing.Size(454, 48)
        Me.btnSplit.TabIndex = 7
        Me.btnSplit.Text = "Split"
        Me.ToolTip.SetToolTip(Me.btnSplit, "Mark the current time in the split.")
        Me.btnSplit.UseVisualStyleBackColor = True
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(10, 59)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(410, 20)
        Me.txtdesc.TabIndex = 8
        Me.ToolTip.SetToolTip(Me.txtdesc, "A description for the next split.")
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.Location = New System.Drawing.Point(465, 25)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(112, 30)
        Me.lbltime.TabIndex = 9
        Me.lbltime.Text = "Work Time"
        '
        'lblwktm
        '
        Me.lblwktm.AutoSize = True
        Me.lblwktm.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblwktm.Location = New System.Drawing.Point(474, 50)
        Me.lblwktm.Name = "lblwktm"
        Me.lblwktm.Size = New System.Drawing.Size(89, 30)
        Me.lblwktm.TabIndex = 10
        Me.lblwktm.Text = "00:00:00"
        '
        'btnMinusTime
        '
        Me.btnMinusTime.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinusTime.Location = New System.Drawing.Point(424, 27)
        Me.btnMinusTime.Name = "btnMinusTime"
        Me.btnMinusTime.Size = New System.Drawing.Size(40, 52)
        Me.btnMinusTime.TabIndex = 14
        Me.btnMinusTime.Text = "-"
        Me.ToolTip.SetToolTip(Me.btnMinusTime, "Subtracts one minute from the Work Time timer.")
        Me.btnMinusTime.UseVisualStyleBackColor = True
        '
        'btnAddTime
        '
        Me.btnAddTime.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTime.Location = New System.Drawing.Point(578, 27)
        Me.btnAddTime.Name = "btnAddTime"
        Me.btnAddTime.Size = New System.Drawing.Size(40, 52)
        Me.btnAddTime.TabIndex = 15
        Me.btnAddTime.Text = "+"
        Me.ToolTip.SetToolTip(Me.btnAddTime, "Adds one minute to the Work Time timer.")
        Me.btnAddTime.UseVisualStyleBackColor = True
        '
        'SplitsDataTableDataGridView
        '
        Me.SplitsDataTableDataGridView.AllowUserToAddRows = False
        Me.SplitsDataTableDataGridView.AllowUserToDeleteRows = False
        Me.SplitsDataTableDataGridView.AllowUserToResizeColumns = False
        Me.SplitsDataTableDataGridView.AllowUserToResizeRows = False
        Me.SplitsDataTableDataGridView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.SplitsDataTableDataGridView.AutoGenerateColumns = False
        Me.SplitsDataTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SplitsDataTableDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewIDColumn, Me.DataGridViewDescriptionColumn, Me.DataGridViewStartTimeColumn, Me.DataGridViewStopTimeColumn, Me.DataGridViewTimeWorkedColumn, Me.DataGridViewRecordedColumn, Me.DataGridViewColorColumn, Me.DataGridViewTimeInSecondsColumn})
        Me.SplitsDataTableDataGridView.ContextMenuStrip = Me.cmsSplitsGridView
        Me.SplitsDataTableDataGridView.DataSource = Me.SplitsDataTableBindingSource
        Me.SplitsDataTableDataGridView.Location = New System.Drawing.Point(10, 86)
        Me.SplitsDataTableDataGridView.MultiSelect = False
        Me.SplitsDataTableDataGridView.Name = "SplitsDataTableDataGridView"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SplitsDataTableDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SplitsDataTableDataGridView.RowHeadersVisible = False
        Me.SplitsDataTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.SplitsDataTableDataGridView.Size = New System.Drawing.Size(608, 276)
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
        Me.DataGridViewIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewIDColumn.Width = 30
        '
        'DataGridViewDescriptionColumn
        '
        Me.DataGridViewDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewDescriptionColumn.DataPropertyName = "Description"
        Me.DataGridViewDescriptionColumn.FillWeight = 98.68021!
        Me.DataGridViewDescriptionColumn.HeaderText = "Description"
        Me.DataGridViewDescriptionColumn.Name = "DataGridViewDescriptionColumn"
        Me.DataGridViewDescriptionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDescriptionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewStartTimeColumn
        '
        Me.DataGridViewStartTimeColumn.DataPropertyName = "StartTime"
        Me.DataGridViewStartTimeColumn.HeaderText = "StartTime"
        Me.DataGridViewStartTimeColumn.MinimumWidth = 70
        Me.DataGridViewStartTimeColumn.Name = "DataGridViewStartTimeColumn"
        Me.DataGridViewStartTimeColumn.ReadOnly = True
        Me.DataGridViewStartTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewStartTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewStartTimeColumn.Width = 70
        '
        'DataGridViewStopTimeColumn
        '
        Me.DataGridViewStopTimeColumn.DataPropertyName = "StopTime"
        Me.DataGridViewStopTimeColumn.HeaderText = "StopTime"
        Me.DataGridViewStopTimeColumn.MinimumWidth = 70
        Me.DataGridViewStopTimeColumn.Name = "DataGridViewStopTimeColumn"
        Me.DataGridViewStopTimeColumn.ReadOnly = True
        Me.DataGridViewStopTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewStopTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewStopTimeColumn.Width = 70
        '
        'DataGridViewTimeWorkedColumn
        '
        Me.DataGridViewTimeWorkedColumn.DataPropertyName = "TimeWorked"
        Me.DataGridViewTimeWorkedColumn.HeaderText = "TimeWorked"
        Me.DataGridViewTimeWorkedColumn.MinimumWidth = 75
        Me.DataGridViewTimeWorkedColumn.Name = "DataGridViewTimeWorkedColumn"
        Me.DataGridViewTimeWorkedColumn.ReadOnly = True
        Me.DataGridViewTimeWorkedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTimeWorkedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTimeWorkedColumn.Width = 75
        '
        'DataGridViewRecordedColumn
        '
        Me.DataGridViewRecordedColumn.DataPropertyName = "Recorded"
        Me.DataGridViewRecordedColumn.HeaderText = "Recorded"
        Me.DataGridViewRecordedColumn.MinimumWidth = 60
        Me.DataGridViewRecordedColumn.Name = "DataGridViewRecordedColumn"
        Me.DataGridViewRecordedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRecordedColumn.Width = 60
        '
        'DataGridViewColorColumn
        '
        Me.DataGridViewColorColumn.DataPropertyName = "Color"
        Me.DataGridViewColorColumn.HeaderText = "Color"
        Me.DataGridViewColorColumn.Name = "DataGridViewColorColumn"
        Me.DataGridViewColorColumn.ReadOnly = True
        Me.DataGridViewColorColumn.Visible = False
        '
        'DataGridViewTimeInSecondsColumn
        '
        Me.DataGridViewTimeInSecondsColumn.DataPropertyName = "TimeInSeconds"
        Me.DataGridViewTimeInSecondsColumn.HeaderText = "TimeInSeconds"
        Me.DataGridViewTimeInSecondsColumn.Name = "DataGridViewTimeInSecondsColumn"
        Me.DataGridViewTimeInSecondsColumn.ReadOnly = True
        Me.DataGridViewTimeInSecondsColumn.Visible = False
        '
        'cmsSplitsGridView
        '
        Me.cmsSplitsGridView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.highlight_blue, Me.highlight_cyan, Me.highlight_green, Me.highlight_purple, Me.highlight_red, Me.highlight_tan, Me.highlight_yellow, Me.RemoveHighlightToolStripMenuItem, Me.highlight_voidout})
        Me.cmsSplitsGridView.Name = "cmsSplitsGridView"
        Me.cmsSplitsGridView.Size = New System.Drawing.Size(171, 202)
        '
        'highlight_blue
        '
        Me.highlight_blue.BackColor = System.Drawing.Color.LightSteelBlue
        Me.highlight_blue.Name = "highlight_blue"
        Me.highlight_blue.Size = New System.Drawing.Size(170, 22)
        Me.highlight_blue.Text = "Blue"
        '
        'highlight_cyan
        '
        Me.highlight_cyan.BackColor = System.Drawing.Color.Cyan
        Me.highlight_cyan.Name = "highlight_cyan"
        Me.highlight_cyan.Size = New System.Drawing.Size(170, 22)
        Me.highlight_cyan.Text = "Cyan"
        '
        'highlight_green
        '
        Me.highlight_green.BackColor = System.Drawing.Color.LawnGreen
        Me.highlight_green.Name = "highlight_green"
        Me.highlight_green.Size = New System.Drawing.Size(170, 22)
        Me.highlight_green.Text = "Green"
        '
        'highlight_purple
        '
        Me.highlight_purple.BackColor = System.Drawing.Color.Thistle
        Me.highlight_purple.Name = "highlight_purple"
        Me.highlight_purple.Size = New System.Drawing.Size(170, 22)
        Me.highlight_purple.Text = "Purple"
        '
        'highlight_red
        '
        Me.highlight_red.BackColor = System.Drawing.Color.LightCoral
        Me.highlight_red.Name = "highlight_red"
        Me.highlight_red.Size = New System.Drawing.Size(170, 22)
        Me.highlight_red.Text = "Red"
        '
        'highlight_tan
        '
        Me.highlight_tan.BackColor = System.Drawing.Color.NavajoWhite
        Me.highlight_tan.Name = "highlight_tan"
        Me.highlight_tan.Size = New System.Drawing.Size(170, 22)
        Me.highlight_tan.Text = "Tan"
        '
        'highlight_yellow
        '
        Me.highlight_yellow.BackColor = System.Drawing.Color.Yellow
        Me.highlight_yellow.Name = "highlight_yellow"
        Me.highlight_yellow.Size = New System.Drawing.Size(170, 22)
        Me.highlight_yellow.Text = "Yellow"
        '
        'RemoveHighlightToolStripMenuItem
        '
        Me.RemoveHighlightToolStripMenuItem.Name = "RemoveHighlightToolStripMenuItem"
        Me.RemoveHighlightToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.RemoveHighlightToolStripMenuItem.Text = "Remove Highlight"
        '
        'highlight_voidout
        '
        Me.highlight_voidout.BackColor = System.Drawing.Color.DimGray
        Me.highlight_voidout.Name = "highlight_voidout"
        Me.highlight_voidout.Size = New System.Drawing.Size(170, 22)
        Me.highlight_voidout.Text = "Void Out"
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SplitsToolStripMenuItem, Me.HelpToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(629, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnablePauseToolStripMenuItem, Me.ToolTipsToolStripMenuItem, Me.MarkRecordedToolStripMenuItem})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem3.Text = "Settings"
        '
        'EnablePauseToolStripMenuItem
        '
        Me.EnablePauseToolStripMenuItem.Name = "EnablePauseToolStripMenuItem"
        Me.EnablePauseToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.EnablePauseToolStripMenuItem.Text = "Pause Button"
        '
        'ToolTipsToolStripMenuItem
        '
        Me.ToolTipsToolStripMenuItem.Checked = True
        Me.ToolTipsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolTipsToolStripMenuItem.Name = "ToolTipsToolStripMenuItem"
        Me.ToolTipsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ToolTipsToolStripMenuItem.Text = "Tool Tips"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SplitsToolStripMenuItem
        '
        Me.SplitsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.ImportFromFileToolStripMenuItem, Me.DeleteLastSplitToolStripMenuItem, Me.ClearSplitsToolStripMenuItem, Me.ToolStripMenuItem2, Me.TotalWorkTimeToolStripMenuItem, Me.ShowCombinedToolStripMenuItem, Me.ToolStripSeparator1, Me.ReviewToolStripMenuItem, Me.OpenSplitLocationToolStripMenuItem})
        Me.SplitsToolStripMenuItem.Name = "SplitsToolStripMenuItem"
        Me.SplitsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.SplitsToolStripMenuItem.Text = "Splits"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ImportToolStripMenuItem.Text = "Import from Today"
        '
        'ImportFromFileToolStripMenuItem
        '
        Me.ImportFromFileToolStripMenuItem.Name = "ImportFromFileToolStripMenuItem"
        Me.ImportFromFileToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ImportFromFileToolStripMenuItem.Text = "Import from File..."
        '
        'DeleteLastSplitToolStripMenuItem
        '
        Me.DeleteLastSplitToolStripMenuItem.Name = "DeleteLastSplitToolStripMenuItem"
        Me.DeleteLastSplitToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.DeleteLastSplitToolStripMenuItem.Text = "Delete last Row"
        '
        'ClearSplitsToolStripMenuItem
        '
        Me.ClearSplitsToolStripMenuItem.Name = "ClearSplitsToolStripMenuItem"
        Me.ClearSplitsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ClearSplitsToolStripMenuItem.Text = "Clear Splits"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(175, 6)
        '
        'TotalWorkTimeToolStripMenuItem
        '
        Me.TotalWorkTimeToolStripMenuItem.Name = "TotalWorkTimeToolStripMenuItem"
        Me.TotalWorkTimeToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TotalWorkTimeToolStripMenuItem.Text = "Total Work Time"
        '
        'ShowCombinedToolStripMenuItem
        '
        Me.ShowCombinedToolStripMenuItem.Name = "ShowCombinedToolStripMenuItem"
        Me.ShowCombinedToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ShowCombinedToolStripMenuItem.Text = "Total Group Time"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(175, 6)
        '
        'ReviewToolStripMenuItem
        '
        Me.ReviewToolStripMenuItem.Name = "ReviewToolStripMenuItem"
        Me.ReviewToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ReviewToolStripMenuItem.Text = "Edit DB File"
        '
        'OpenSplitLocationToolStripMenuItem
        '
        Me.OpenSplitLocationToolStripMenuItem.Name = "OpenSplitLocationToolStripMenuItem"
        Me.OpenSplitLocationToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.OpenSplitLocationToolStripMenuItem.Text = "Open Split Location"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem, Me.AboutToolStripMenuItem1})
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.Timer__.My.Resources.Resources.save_bw
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(346, 27)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(74, 30)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip.SetToolTip(Me.btnSave, "Save the current set of splits to file.")
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'ssBottomMain
        '
        Me.ssBottomMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslFilePath, Me.tsslLastSaved})
        Me.ssBottomMain.Location = New System.Drawing.Point(0, 419)
        Me.ssBottomMain.Name = "ssBottomMain"
        Me.ssBottomMain.Size = New System.Drawing.Size(629, 22)
        Me.ssBottomMain.TabIndex = 19
        Me.ssBottomMain.Text = "ssBottom"
        Me.ToolTip.SetToolTip(Me.ssBottomMain, "File location and last saved time.")
        '
        'tsslFilePath
        '
        Me.tsslFilePath.Name = "tsslFilePath"
        Me.tsslFilePath.Size = New System.Drawing.Size(109, 17)
        Me.tsslFilePath.Text = "File Path Goes Here"
        '
        'tsslLastSaved
        '
        Me.tsslLastSaved.Name = "tsslLastSaved"
        Me.tsslLastSaved.Size = New System.Drawing.Size(505, 17)
        Me.tsslLastSaved.Spring = True
        Me.tsslLastSaved.Text = "File not yet saved"
        Me.tsslLastSaved.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MarkRecordedToolStripMenuItem
        '
        Me.MarkRecordedToolStripMenuItem.Checked = True
        Me.MarkRecordedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MarkRecordedToolStripMenuItem.Name = "MarkRecordedToolStripMenuItem"
        Me.MarkRecordedToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.MarkRecordedToolStripMenuItem.Text = "Mark Recorded"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 441)
        Me.Controls.Add(Me.ssBottomMain)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.SplitsDataTableDataGridView)
        Me.Controls.Add(Me.btnAddTime)
        Me.Controls.Add(Me.btnMinusTime)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lblwktm)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.txtdesc)
        Me.Controls.Add(Me.btnSplit)
        Me.Controls.Add(Me.btnpause)
        Me.Controls.Add(Me.lbltimertext)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(645, 920)
        Me.MinimumSize = New System.Drawing.Size(645, 480)
        Me.Name = "frmMain"
        Me.Text = "Timer++"
        CType(Me.SplitsDataTableDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsSplitsGridView.ResumeLayout(False)
        CType(Me.SplitsDataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ssBottomMain.ResumeLayout(False)
        Me.ssBottomMain.PerformLayout()
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
    Friend WithEvents btnMinusTime As Button
    Friend WithEvents btnAddTime As Button
    Friend WithEvents SplitsDataSet As SplitsDataSet
    Friend WithEvents SplitsDataTableBindingSource As BindingSource
    Friend WithEvents SplitsDataTableDataGridView As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearSplitsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ImportFromFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteLastSplitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnSave As Button
    Friend WithEvents ssBottomMain As StatusStrip
    Friend WithEvents tsslFilePath As ToolStripStatusLabel
    Friend WithEvents tsslLastSaved As ToolStripStatusLabel
    Friend WithEvents cmsSplitsGridView As ContextMenuStrip
    Friend WithEvents RemoveHighlightToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents OpenSplitLocationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents EnablePauseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTipsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents highlight_red As ToolStripMenuItem
    Friend WithEvents highlight_cyan As ToolStripMenuItem
    Friend WithEvents highlight_green As ToolStripMenuItem
    Friend WithEvents highlight_purple As ToolStripMenuItem
    Friend WithEvents highlight_yellow As ToolStripMenuItem
    Friend WithEvents highlight_blue As ToolStripMenuItem
    Friend WithEvents highlight_tan As ToolStripMenuItem
    Friend WithEvents highlight_voidout As ToolStripMenuItem
    Friend WithEvents ShowCombinedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridViewIDColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDescriptionColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewStartTimeColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewStopTimeColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTimeWorkedColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewRecordedColumn As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewColorColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTimeInSecondsColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalWorkTimeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents HelpToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MarkRecordedToolStripMenuItem As ToolStripMenuItem
End Class
