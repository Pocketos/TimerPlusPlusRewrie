Public Class frmMain
    'Gets the keystate library for splitting with the ENETER key.
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    'Declare the muber of splits, recorded worktime, and the file name.
    Private splits As Integer = 0
    Private worktime As Integer = 0
    Private filename As String

    'Settings
    Private EnablePause As Integer = 0
    Private EnableToolips As Integer = 1

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
        Else
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewStopTimeColumn").Value = Now.ToShortTimeString
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeInSecondsColumn").Value = worktime
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeWorkedColumn").Value = SecondsToTime(worktime)
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewRecordedColumn").Value = SplitsDataTableDataGridView(5, splits).Value
            SaveSplits()
            splits = splits + 1
            worktime = 0
            SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
            SplitsDataTableDataGridView.CurrentCell = Me.SplitsDataTableDataGridView(0, splits)
            txtdesc.Clear()
            Me.SplitsDataSet.WriteXml("Days\" & filename)
            If EnablePause = 1 Then
                btnpause.Enabled = True
            End If
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
            lblwktm.Text = "00:00:00"
            If EnablePause = 1 Then
                btnpause.Text = "Pause"
                btnpause.Enabled = True
                EnablePauseToolStripMenuItem.Checked = True
            End If
            Me.Icon = My.Resources.stopwatch
            btnpause.Enabled = False
            EnablePauseToolStripMenuItem.Checked = False
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

    Private Function SecondsToTime(worktime As Integer)
        Dim worktime_span As TimeSpan = TimeSpan.FromSeconds(Convert.ToDouble(worktime))
        Return worktime_span
    End Function

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
            tsslFilePath.Text = My.Computer.FileSystem.CurrentDirectory & "\Days" & filename
            tsslLastSaved.Text = "File not yet saved"
            btnpause.Enabled = False
        End If
    End Sub

    Private Function addtime(SearchColor As String)
        Dim combinedtime As Integer = 0
        For Each DataRow In SplitsDataTableDataGridView.Rows
            If Not IsDBNull(DataRow.Cells("DataGridViewColorColumn").Value) Then
                If Not DataRow.Cells("DataGridViewColorColumn").Value = "White" Then
                    If Not IsDBNull(DataRow.Cells("DataGridViewTimeInSecondsColumn").Value) Then
                        If (DataRow.Cells("DataGridViewColorColumn").Value) = SearchColor Then
                            Try
                                combinedtime = combinedtime + DataRow.Cells("DataGridViewTimeInSecondsColumn").Value
                                DataRow.Cells("DataGridViewRecordedColumn").Value = 1
                            Catch
                                MsgBox("Split contains no work time.", 16, "Data not Found")
                            End Try
                        End If
                    End If
                End If
            End If
        Next
        Return combinedtime
    End Function

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
        Else
            tmMain.Enabled = True
            txtdesc.Enabled = True
            btnSplit.Enabled = True
            btnpause.Text = "Pause"
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
        MsgBox("Exit?", 64, My.Application.Info.AssemblyName.ToString)
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
        MsgBox(My.Application.Info.Description.ToString() & Environment.NewLine & "Version " & My.Application.Info.Version.ToString() & Environment.NewLine & "Early Beta - Expect bugs!" & Environment.NewLine & My.Application.Info.Trademark.ToString & Environment.NewLine & My.Application.Info.Copyright.ToString, , My.Application.Info.AssemblyName.ToString)
    End Sub

    Private Sub ImportFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFromFileToolStripMenuItem.Click
        OpenFile()
    End Sub

    Private Sub DeleteLastSplitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteLastSplitToolStripMenuItem.Click
        If tmMain.Enabled = False And worktime <= 0 Then
            Try
                SplitsDataSet.SplitsDataTable.Rows(splits - 1).Delete()
                splits = SplitsDataSet.SplitsDataTable.Rows(SplitsDataSet.SplitsDataTable.Rows.Count - 1).Item("ID") + 1
                tmMain.Enabled = False
                worktime = 0
                lblwktm.Text = "00:00:00"
            Catch
                MsgBox("Error removing row" & splits, , My.Application.Info.AssemblyName.ToString)
            End Try
        Else
            MsgBox("Cannot repair the file while the timer is running.  Please close and open the file without starting the timer.", , My.Application.Info.AssemblyName.ToString)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveSplits()
    End Sub

    'Logic for highlighing the currenetly selected cell

    Private Sub Highlight(color As Color)
        If SplitsDataTableDataGridView.CurrentCell Is Nothing Then
            MsgBox("No row selected!")
        Else
            SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor = color
            SplitsDataTableDataGridView.CurrentRow.Cells("DataGridViewColorColumn").Value = SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor
        End If
    End Sub

    Private Sub highlight_red_Click(sender As Object, e As EventArgs) Handles highlight_red.Click
        Try
            Highlight(Color.LightCoral)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub highlight_cyan_Click(sender As Object, e As EventArgs) Handles highlight_cyan.Click
        Try
            Highlight(Color.Cyan)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub highlight_green_Click(sender As Object, e As EventArgs) Handles highlight_green.Click
        Try
            Highlight(Color.LawnGreen)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub highlight_purple_Click(sender As Object, e As EventArgs) Handles highlight_purple.Click
        Try
            Highlight(Color.Thistle)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub highlight_yellow_Click(sender As Object, e As EventArgs) Handles highlight_yellow.Click
        Try
            Highlight(Color.Yellow)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub highlight_blue_Click(sender As Object, e As EventArgs) Handles highlight_blue.Click
        Try
            Highlight(Color.LightSteelBlue)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub highlight_tan_Click(sender As Object, e As EventArgs) Handles highlight_tan.Click
        Try
            Highlight(Color.NavajoWhite)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub highlight_voidout_Click(sender As Object, e As EventArgs) Handles highlight_voidout.Click
        Try
            Highlight(Color.DimGray)
        Catch
            MsgBox("!!!", , My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub RemoveHighlightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveHighlightToolStripMenuItem.Click
        Highlight(Color.White)
    End Sub

    Private Sub EnablePauseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnablePauseToolStripMenuItem.Click
        If tmMain.Enabled = True Then
            If EnablePause = 0 Then
                EnablePauseToolStripMenuItem.Checked = True
                EnablePause = 1
                btnpause.Enabled = True
            Else
                If btnpause.Text = "Pause" Then
                    EnablePauseToolStripMenuItem.Checked = False
                    EnablePause = 0
                    btnpause.Enabled = False
                Else
                    MsgBox("The pause button cannot be disabled while the timer is inactive.", , My.Application.Info.AssemblyName.ToString)
                End If
            End If
        Else
            MsgBox("The pause button cannot be disabled while the timer is inactive.", , My.Application.Info.AssemblyName.ToString)
        End If
    End Sub

    Private Sub OpenSplitLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSplitLocationToolStripMenuItem.Click
        Try
            Process.Start(My.Computer.FileSystem.CurrentDirectory & "\Days")
        Catch
            MsgBox("Could not open the file path", 16, My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub ToolTipsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolTipsToolStripMenuItem.Click
        If EnableToolips = 1 Then
            ToolTip.Active = False
            ToolTipsToolStripMenuItem.Checked = False
            EnableToolips = 0
        Else
            ToolTip.Active = True
            ToolTipsToolStripMenuItem.Checked = True
            EnableToolips = 1
        End If
    End Sub

    Private Sub ShowCombinedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowCombinedToolStripMenuItem.Click
        If (addtime(SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor.ToKnownColor.ToString)) > 0 Then
            MsgBox(SecondsToTime(addtime(SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor.ToKnownColor.ToString)).ToString, 64, "Total of Color " & SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor.ToKnownColor.ToString)
        Else
            MessageBox.Show("Could not find a value to parse", My.Application.Info.AssemblyName.ToString, MessageBoxButtons.YesNo)
        End If
    End Sub
End Class