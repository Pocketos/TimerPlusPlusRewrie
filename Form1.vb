Imports System.ComponentModel
Imports System.Windows.Shell

Public Class frmMain
    '///LIBRARIES
    'Gets the keystate library for splitting with the ENETER key.
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Public Property TaskbarItemInfo As TaskbarItemInfo

    '///VARIABLES
    'Declare the muber of splits, recorded worktime, and the file name.
    Private splits As Integer = 0
    Private worktime As Integer = 0
    Private filename As String

    '///SETTIGS
    Private EnablePause As Integer = 0
    Private EnableToolips As Integer = 1
    Private EnablemarkRecordedOnGroupTime As Integer = 1

    '///FORM LOAD
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datecheck()
    End Sub

    '///SUBS
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
        tsslFilePath.Text = My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename

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
        Try
            If tmMain.Enabled = False Then
                SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
                SplitsDataTableDataGridView.CurrentCell = Me.SplitsDataTableDataGridView(0, splits)
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewColorColumn").Value = "White"
                txtdesc.Clear()
                tmMain.Enabled = True
            Else
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewStopTimeColumn").Value = Now.ToShortTimeString
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeInSecondsColumn").Value = worktime
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeWorkedColumn").Value = SecondsToTime(worktime)
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewRecordedColumn").Value = SplitsDataTableDataGridView(5, splits).Value
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewColorColumn").Value = SplitsDataTableDataGridView(6, splits).Value.ToString
                SaveSplits()
                splits = splits + 1
                worktime = 0
                SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
                SplitsDataTableDataGridView.CurrentCell = Me.SplitsDataTableDataGridView(0, splits)
                txtdesc.Clear()
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewColorColumn").Value = "White"
                Me.SplitsDataSet.WriteXml("Days\" & filename)
                If EnablePause = 1 Then
                    btnpause.Enabled = True
                End If
            End If
        Catch
            MsgBox("Exception generated why creating split", 16, My.Application.Info.AssemblyName.ToString)
        End Try
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

    Private Sub updatehighlight()
        For Each row As DataGridViewRow In SplitsDataTableDataGridView.Rows
            If Not IsDBNull(row.Cells("DataGridViewColorColumn").Value) Then
                row.DefaultCellStyle.BackColor = Color.FromName(row.Cells("DataGridViewColorColumn").Value)
            End If
        Next row
    End Sub

    Private Sub tmMain_Tick(sender As Object, e As EventArgs) Handles tmMain.Tick
        lbltimertext.Text = DateAndTime.Now
        worktime = worktime + 1
        Dim time = New TimeSpan(0, 0, worktime).ToString("c")
        lblwktm.Text = time
    End Sub

    'Logic for highlighing the currenetly selected cell
    Private Sub Highlight(color As Color)
        If SplitsDataTableDataGridView.CurrentCell Is Nothing Then
            MsgBox("No row selected!", 16, My.Application.Info.AssemblyName.ToString)
        Else
            SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor = color
            SplitsDataTableDataGridView.CurrentRow.Cells("DataGridViewColorColumn").Value = SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor
        End If
    End Sub

    '///FUNCTIONS

    Private Function SecondsToTime(worktime As Integer)
        Dim worktime_span As TimeSpan = TimeSpan.FromSeconds(Convert.ToDouble(worktime))
        Return worktime_span
    End Function
    'adds total time minus void out color (DimGrey)
    Private Function addalltime()
        Dim combinedtime As Integer = 0
        For Each DataRow In SplitsDataTableDataGridView.Rows
            If Not IsDBNull(DataRow.Cells("DataGridViewTimeInSecondsColumn").Value) Then
                Select Case DataRow.Cells("DataGridViewColorColumn").Value
                    Case Is = "DimGray"
                    Case Else
                        Try
                            combinedtime = combinedtime + DataRow.Cells("DataGridViewTimeInSecondsColumn").Value
                        Catch
                            MsgBox("Error", 16, "Data not Found")
                        End Try
                End Select
            End If
        Next
        Return combinedtime
    End Function
    'adds group time
    Private Function addtime(SearchColor As String)
        Dim combinedtime As Integer = 0
        For Each DataRow In SplitsDataTableDataGridView.Rows
            If Not IsDBNull(DataRow.Cells("DataGridViewTimeInSecondsColumn").Value) Then
                Select Case DataRow.Cells("DataGridViewColorColumn").Value
                    Case Is = "White"
                    Case Is = "DimGray"
                    Case Is = SearchColor
                        Try
                            combinedtime = combinedtime + DataRow.Cells("DataGridViewTimeInSecondsColumn").Value
                            If EnablemarkRecordedOnGroupTime = 1 Then
                                DataRow.Cells("DataGridViewRecordedColumn").Value = 1
                            End If
                        Catch
                            MsgBox("Split contains no work time", 16, "Data not Found")
                        End Try
                    Case Else
                End Select
            End If
        Next
        Return combinedtime
    End Function

    Private Function IsNumeric(keyChar As Object) As Boolean
        Throw New NotImplementedException()
    End Function

    '///FORM CONTROLS

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

    Private Sub btn_addtime10_Click(sender As Object, e As EventArgs) Handles btn_addtime10.Click
        worktime = worktime + 600
        Dim time = New TimeSpan(0, 0, worktime).ToString("c")
        lblwktm.Text = time
    End Sub

    Private Sub btn_zerotime_Click(sender As Object, e As EventArgs) Handles btn_zerotime.Click
        worktime = 0
        Dim time = New TimeSpan(0, 0, worktime).ToString("c")
        lblwktm.Text = time
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
        frm_aboutbox.ShowDialog()
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
                    MsgBox("The pause button cannot be disabled while the timer is inactive", , My.Application.Info.AssemblyName.ToString)
                End If
            End If
        Else
            MsgBox("The pause button state cannot be changed while the timer is inactive", , My.Application.Info.AssemblyName.ToString)
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

    Private Sub TotalGroupTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalGroupTimeToolStripMenuItem.Click
        If SplitsDataTableDataGridView.SelectedCells.Count > 0 Then
            If (addtime(SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor.ToKnownColor.ToString)) > 0 Then
                MsgBox(SecondsToTime(addtime(SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor.ToKnownColor.ToString)).ToString, 64, "Total of Color " & SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor.ToKnownColor.ToString)
            Else
                MsgBox("Could not find a WorkTime value", 16, My.Application.Info.AssemblyName.ToString)
            End If
        Else
            MsgBox("No selected row", 16, My.Application.Info.AssemblyName.ToString)
        End If
    End Sub

    Private Sub TotalWorkTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalWorkTimeToolStripMenuItem.Click
        If addalltime() > 0 Then
            MsgBox(SecondsToTime(addalltime()).ToString, 64, "Total Work Time")
        Else
            MsgBox("No Time Worked exists in current set!", 16, My.Application.Info.AssemblyName.ToString)
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        frm_help.ShowDialog()
    End Sub

    Private Sub MarkRecordedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkRecordedToolStripMenuItem.Click
        If EnablemarkRecordedOnGroupTime = 1 Then
            MarkRecordedToolStripMenuItem.Checked = False
            EnablemarkRecordedOnGroupTime = 0
        Else
            MarkRecordedToolStripMenuItem.Checked = True
            EnablemarkRecordedOnGroupTime = 1
        End If
    End Sub
End Class