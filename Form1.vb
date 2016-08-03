Public Class frmMain
    'Gets the keystate library for splitting with the ENETER key.
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    'Declare the muber of splits, recorded worktime, and the file name.
    Private splits As Integer = 0
    Private worktime As Integer = 0
    Private filename As String

    'Sets the date and file name.  Loaded with the main form.
    Private Sub datecheck()
        Dim currentdate As Date = Today
        Dim currentmonth As String
        Dim currentday As String
        Dim currentyear As String
        currentmonth = Month(currentdate)
        currentday = DateAndTime.Day(currentdate)
        currentyear = Year(currentdate)

        filename = currentday & "-" & currentmonth & "-" & currentyear & ".xml"
        tsslFilePath.Text = My.Computer.FileSystem.CurrentDirectory & "\Days" & filename

        If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory & "\Days") Then
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename) = False Then
                Me.SplitsDataSet.WriteXml("Days\" & filename)
            Else
                Me.SplitsDataSet.ReadXml("Days\" & filename)
                updatehighlight()
                Try
                    splits = SplitsDataSet.SplitsDataTable.Rows(SplitsDataSet.SplitsDataTable.Rows.Count - 1).Item("ID") + 1
                Catch
                    Exit Sub
                End Try
                Exit Sub
            End If
        Else
            System.IO.Directory.CreateDirectory(My.Computer.FileSystem.CurrentDirectory & "\Days")
            datecheck()
        End If
    End Sub

    Private Sub Split()
        If tmMain.Enabled = False Then
            SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
            SplitsDataTableDataGridView.CurrentCell = Me.SplitsDataTableDataGridView(0, splits)
            txtdesc.Clear()
            tmMain.Enabled = True
            btnpause.Enabled = True
        Else
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewStopTimeColumn").Value = Now.ToShortTimeString
            Dim time = New TimeSpan(0, 0, worktime)
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeWorkedColumn").Value = time
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewRecordedColumn").Value = SplitsDataTableDataGridView(5, splits).Value
            SaveSplits()
            splits = splits + 1
            worktime = 0
            SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
            SplitsDataTableDataGridView.CurrentCell = Me.SplitsDataTableDataGridView(0, splits)
            txtdesc.Clear()
            Me.SplitsDataSet.WriteXml("Days\" & filename)
        End If
    End Sub

    Private Sub ImportSplits()
        Dim importresult As Integer = MessageBox.Show("Importing Splits will delete the current set!", "Overwrite current splits?", MessageBoxButtons.OKCancel)
        If importresult = DialogResult.OK Then
            SplitsDataSet.Clear()
            datecheck()
            tmMain.Enabled = False
            worktime = 0
            txtdesc.Enabled = True
            btnSplit.Enabled = True
            btnpause.Text = "Pause"
            Me.Icon = My.Resources.stopwatch
            btnpause.Enabled = False
            tsslLastSaved.Text = "File not yet saved"
            Try
                splits = SplitsDataSet.SplitsDataTable.Rows(SplitsDataSet.SplitsDataTable.Rows.Count - 1).Item("ID") + 1
            Catch
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub OpenFile()
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Choose splits file"
        fd.InitialDirectory = My.Computer.FileSystem.CurrentDirectory & "\Days"
        fd.Filter = "XML Files (*.xml)|*.xml"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            filename = fd.SafeFileName
            Clear()
            Me.SplitsDataSet.ReadXml(fd.FileName)
            updatehighlight()
            tsslFilePath.Text = My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename
            Try
                splits = SplitsDataSet.SplitsDataTable.Rows(SplitsDataSet.SplitsDataTable.Rows.Count - 1).Item("ID") + 1
            Catch
                SplitsDataSet.Clear()
            End Try
        End If
    End Sub

    Private Sub SaveSplits()
        SplitsDataTableDataGridView.CurrentCell = Nothing
        Me.SplitsDataSet.WriteXml("Days\" & filename)
        tsslLastSaved.Text = "Last saved: " & Now.ToShortTimeString
    End Sub

    Private Sub Clear()
        Dim clearresult As Integer = MessageBox.Show("Clearing Splits will delete the current set!", "Delete current splits?", MessageBoxButtons.OKCancel)
        If clearresult = DialogResult.OK Then
            tmMain.Enabled = False
            worktime = 0
            splits = 0
            SplitsDataSet.Clear()
            txtdesc.Enabled = True
            btnSplit.Enabled = True
            btnpause.Text = "Pause"
            Me.Icon = My.Resources.stopwatch
            lblwktm.Text = "00:00:00"
            btnpause.Enabled = False
            tsslFilePath.Text = My.Computer.FileSystem.CurrentDirectory & "\Days" & filename
            tsslLastSaved.Text = "File not yet saved"
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Highlight(color As Color)
        If SplitsDataTableDataGridView.CurrentCell Is Nothing Then
            MsgBox("No row selected!")
        Else
            SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor = color
            SplitsDataTableDataGridView.CurrentRow.Cells("DataGridViewColorColumn").Value = SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor
        End If
    End Sub

    Private Sub updatehighlight()
        For Each DataRow In SplitsDataTableDataGridView.Rows
            If Not IsDBNull(DataRow.Cells("DataGridViewColorColumn").Value) Then
                Dim rowcolor As Color = Color.FromName(DataRow.Cells("DataGridViewColorColumn").Value)
                DataRow.DefaultCellStyle.BackColor = rowcolor
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datecheck()
        HighlighColorBox.Text = "Yellow"
    End Sub

    Private Sub tmMain_Tick(sender As Object, e As EventArgs) Handles tmMain.Tick
        lbltimertext.Text = DateAndTime.Now
        worktime = worktime + 1
        Dim time = New TimeSpan(0, 0, worktime).ToString("c")
        lblwktm.Text = time
    End Sub

    Private Sub btnpause_Click(sender As Object, e As EventArgs) Handles btnpause.Click
        If tmMain.Enabled = True Then
            tmMain.Enabled = False
            lbltimertext.Text = "PAUSED"
            btnpause.Text = "Resume"
            txtdesc.Enabled = False
            btnSplit.Enabled = False
            Me.Icon = My.Resources.stopwatchpaused
        Else
            tmMain.Enabled = True
            txtdesc.Enabled = True
            btnSplit.Enabled = True
            btnpause.Text = "Pause"
            Me.Icon = My.Resources.stopwatch
        End If
    End Sub

    Private Sub btnSplit_Click(sender As Object, e As EventArgs) Handles btnSplit.Click
        Split()
    End Sub

    Private Sub txtdesc_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdesc.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            Split()
        Else
        End If
    End Sub

    Private Function IsNumeric(keyChar As Object) As Boolean
        Throw New NotImplementedException()
    End Function

    Private Sub btnAddTime_Click(sender As Object, e As EventArgs) Handles btnAddTime.Click
        worktime = worktime + 60
        Dim time = New TimeSpan(0, 0, worktime).ToString("c")
        lblwktm.Text = time
    End Sub

    Private Sub btnMinusTime_Click(sender As Object, e As EventArgs) Handles btnMinusTime.Click
        If worktime >= 60 Then
            worktime = worktime - 60
            Dim time = New TimeSpan(0, 0, worktime).ToString("c")
            lblwktm.Text = time
        Else
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveSplits()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        ImportSplits()
    End Sub

    Private Sub ClearSplitsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSplitsToolStripMenuItem.Click
        Clear()
    End Sub

    Private Sub ReviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReviewToolStripMenuItem.Click
        System.Diagnostics.Process.Start(My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename)
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        MsgBox("Version " & My.Application.Info.Version.ToString() & Environment.NewLine & "Early Alpha" & Environment.NewLine & "Copyright Korkscrewgaming 2016", , My.Application.Info.AssemblyName.ToString)
    End Sub

    Private Sub ImportFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFromFileToolStripMenuItem.Click
        OpenFile()
    End Sub

    Private Sub DeleteLastSplitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteLastSplitToolStripMenuItem.Click
        Try
            SplitsDataSet.SplitsDataTable.Rows(splits - 1).Delete()
            splits = SplitsDataSet.SplitsDataTable.Rows(SplitsDataSet.SplitsDataTable.Rows.Count - 1).Item("ID") + 1
        Catch
            MsgBox("Error removing row" & splits)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveSplits()
    End Sub

    Private Sub ContextMenuItemHighlight_Click(sender As Object, e As EventArgs) Handles ContextMenuItemHighlight.Click
        Try
            Highlight(Color.FromName(HighlighColorBox.Text))
        Catch
            MsgBox("!!!")
        End Try
    End Sub

    Private Sub RemoveHighlightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveHighlightToolStripMenuItem.Click
        Highlight(Color.White)
    End Sub

    Private Sub EnableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem.Click
        ToolTip.Active = True
        DisableToolStripMenuItem.Enabled = True
        EnableToolStripMenuItem.Enabled = False
    End Sub

    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click
        ToolTip.Active = False
        DisableToolStripMenuItem.Enabled = False
        EnableToolStripMenuItem.Enabled = True
    End Sub
End Class