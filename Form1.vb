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
    Public worktime As Integer = 0
    Private filename As String
    Private alertshowing As Boolean = False

    '///FORM LOAD
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datecheck()

        '////LOAD SETTINGS
        ToolTip.Active = My.Settings.tooltips
        ColorPicker.Color = My.Settings.defaultcolor
        btnpause.Enabled = My.Settings.pausebutton

        '/////Color picker custom colors. Use https://www.shodor.org/stella2java/rgbint.html as a reference
        ColorPicker.CustomColors = New Integer() {16698816, 12645624, 13104052, 1836924,
        3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294,
        3102017, 7324121, 14993507, 11730944}
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
        tsslFilePath.ToolTipText = My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename

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
                WriteHighlight(255, 255, 255)
                txtdesc.Clear()
                tmMain.Enabled = True
                If btnendsplit.Enabled = False Then
                    btnendsplit.Enabled = True
                End If
            Else
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewStopTimeColumn").Value = Now.ToShortTimeString
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeWorkedColumn").Value = SecondsToTime(worktime)
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewRecordedColumn").Value = SplitsDataTableDataGridView(5, splits).Value
                SaveSplits()
                splits += 1
                worktime = 0
                SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
                SplitsDataTableDataGridView.CurrentCell = Me.SplitsDataTableDataGridView(0, splits)
                txtdesc.Clear()
                WriteHighlight(255, 255, 255)
                Me.SplitsDataSet.WriteXml("Days\" & filename)
                If My.Settings.pausebutton = True Then
                    btnpause.Enabled = True
                End If
                lblwktm.BackColor = Control.DefaultBackColor
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 16, My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub EndSplit()
        Try
            If tmMain.Enabled = True Then
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewStopTimeColumn").Value = Now.ToShortTimeString
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeWorkedColumn").Value = SecondsToTime(worktime)
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewRecordedColumn").Value = SplitsDataTableDataGridView(5, splits).Value
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewColorColumn").Value = SplitsDataTableDataGridView(6, splits).Value.ToString
                SaveSplits()
                txtdesc.Clear()
                splits += 1
                worktime = 0
                lblwktm.Text = "00:00:00"
                tmMain.Stop()
                Me.SplitsDataSet.WriteXml("Days\" & filename)
                If My.Settings.pausebutton = True Then
                    btnpause.Enabled = True
                End If
                lblwktm.BackColor = Control.DefaultBackColor
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 16, My.Application.Info.AssemblyName.ToString)
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
            If My.Settings.pausebutton = True Then
                btnpause.Text = "Pause"
                btnpause.Enabled = True
            End If
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
            tsslFilePath.Text = My.Computer.FileSystem.CurrentDirectory & "\Days" & filename
            tsslLastSaved.Text = "File not yet saved"
            btnpause.Enabled = False
        End If
    End Sub

    Private Sub WriteHighlight(r As Integer, g As Integer, b As Integer)
        SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewColorColumn").Value = r.ToString & "," & g.ToString & "," & g.ToString
    End Sub

    Private Sub updatehighlight()
        For Each row As DataGridViewRow In SplitsDataTableDataGridView.Rows
            Dim ColorString As String = row.Cells("DataGridViewColorColumn").Value
            Dim ColorArray() As String = ColorString.Split(",")
            row.DefaultCellStyle.BackColor = Color.FromArgb(ColorArray(0), ColorArray(1), ColorArray(2))
        Next row
    End Sub

    Private Sub tmMain_Tick(sender As Object, e As EventArgs) Handles tmMain.Tick
        lbltimertext.Text = DateAndTime.Now
        worktime = worktime + 1
        Dim time = New TimeSpan(0, 0, worktime).ToString("c")
        lblwktm.Text = time

        'Check if the timer has been running an exact multiple of the set time.  If it has, create a message box to split now or continue.
        If worktime Mod (My.Settings.warntime * 60) = 0 Then
            Me.Activate()
            lblwktm.BackColor = Color.Red
            If alertshowing = False Then
                alertshowing = True
                Dim tmalertboxresult As Integer = MessageBox.Show("Create a new split?", "Work time exceeds threshold!", MessageBoxButtons.YesNo)
                If tmalertboxresult = DialogResult.Yes Then
                    Split()
                    lblwktm.BackColor = Control.DefaultBackColor
                End If
                alertshowing = False
            End If
        End If
    End Sub

    'Logic for highlighing the currenetly selected cell
    Private Sub Highlight(color As Color)
        If SplitsDataTableDataGridView.CurrentCell Is Nothing Then
            MsgBox("No row selected!", 16, My.Application.Info.AssemblyName.ToString)
        Else
            SplitsDataTableDataGridView.CurrentRow.DefaultCellStyle.BackColor = color
            SplitsDataTableDataGridView.CurrentRow.Cells("DataGridViewColorColumn").Value = color.R & "," & color.G & "," & color.B
        End If
    End Sub

    Private Sub checksplitwarning()
        If My.Settings.warntime * 60 < worktime Then
            lblwktm.BackColor = Color.Red
        Else
            lblwktm.BackColor = Control.DefaultBackColor
        End If
    End Sub

    Private Sub frmmain_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        EndSplit()
    End Sub

    '///FUNCTIONS

    'converts seconds to minutes
    Private Function SecondsToTime(worktime As Integer)
        Dim worktime_span As TimeSpan = TimeSpan.FromSeconds(Convert.ToDouble(worktime))
        Return worktime_span
    End Function

    'converts a formated time string (00:00:00) to seconds
    Private Function TimeToSeconds(newworktime As String)
        Try
            Dim seconds As TimeSpan = TimeSpan.Parse(newworktime)
            Return seconds.TotalSeconds.ToString
        Catch
            Return 0
        End Try
    End Function

    'adds total time minus void out color (DimGrey)
    Private Function addalltime()
        Dim combinedtime As Integer = 0
        For Each DataRow In SplitsDataTableDataGridView.Rows
            If Not IsDBNull(TimeToSeconds(DataRow.Cells("DataGridViewTimeWorkedColumn").Value.ToString)) Then
                Select Case DataRow.Cells("DataGridViewColorColumn").Value
                    Case Is = "105,105,105"
                    Case Else
                        Try
                            combinedtime = combinedtime + TimeToSeconds(DataRow.Cells("DataGridViewTimeworkedColumn").Value.ToString)
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
            If Not IsDBNull(TimeToSeconds(DataRow.Cells("DataGridViewTimeWorkedColumn").Value.ToString)) Then
                Select Case DataRow.Cells("DataGridViewColorColumn").Value
                    Case Is = "255,255,255"
                    Case Is = "105,105,105"
                    Case Is = SearchColor
                        Try
                            combinedtime = combinedtime + TimeToSeconds(DataRow.Cells("DataGridViewTimeWorkedColumn").Value.ToString)
                            If My.Settings.markrecorded = True Then
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

    '///Total Group Time
    Private Sub TotalGroupTime()
        If SplitsDataTableDataGridView.SelectedCells.Count > 0 Then
            If (addtime(SplitsDataTableDataGridView.CurrentRow.Cells("DataGridViewColorColumn").Value)) > 0 Then
                tsslactionstatus.Text = SecondsToTime(addtime(SplitsDataTableDataGridView.CurrentRow.Cells("DataGridViewColorColumn").Value)).ToString
            Else
                MsgBox("Row is not a supported group type!", 16, My.Application.Info.AssemblyName.ToString)
            End If
        Else
            MsgBox("No selected row", 16, My.Application.Info.AssemblyName.ToString)
        End If
    End Sub

    '///FORM CONTROLS

    Private Sub Btnpause_Click(sender As Object, e As EventArgs) Handles btnpause.Click
        If tmMain.Enabled = True Then
            tmMain.Enabled = False
            lbltimertext.Text = "PAUSED"
            btnpause.Text = "Resume"
            txtdesc.Enabled = False
            btnSplit.Enabled = False
        Else
            If btnpause.Text = "Pause" Then
            Else
                tmMain.Enabled = True
                txtdesc.Enabled = True
                btnSplit.Enabled = True
                btnpause.Text = "Pause"
            End If
        End If
    End Sub

    Private Sub btnSplit_Click(sender As Object, e As EventArgs) Handles btnSplit.Click
        Split()
    End Sub

    Private Sub Txtdesc_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (e.KeyCode And Not Keys.Modifiers) = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
                e.SuppressKeyPress = True
                EndSplit()
            Else
                e.SuppressKeyPress = True
                Split()
            End If
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
        EndSplit()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        ImportSplits()
    End Sub

    Private Sub ClearSplitsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSplitsToolStripMenuItem.Click
        Clear()
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

    Private Sub TotalGroupTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalGroupTimeToolStripMenuItem.Click
        TotalGroupTime()
    End Sub

    Private Sub TotalWorkTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalWorkTimeToolStripMenuItem.Click
        If addalltime() > 0 Then
            MsgBox(SecondsToTime(addalltime()).ToString, 64, "Total Work Time")
            tsslactionstatus.Text = SecondsToTime(addalltime()).ToString & " - Total"
        Else
            MsgBox("No Time Worked exists in current set!", 16, My.Application.Info.AssemblyName.ToString)
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        frm_help.ShowDialog()
    End Sub

    Private Sub EndSplitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EndSplitToolStripMenuItem.Click
        If tmMain.Enabled = True Then
            EndSplit()
        Else
            MsgBox("No Running Splits!")
        End If
    End Sub

    Private Sub SplitsDataTableDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitsDataTableDataGridView.DoubleClick
        Try
            If SplitsDataTableDataGridView.CurrentCell.ColumnIndex = 0 Then
                If ColorPicker.ShowDialog() = DialogResult.OK Then
                    Highlight(ColorPicker.Color)
                End If
            End If

            If SplitsDataTableDataGridView.CurrentCell.ColumnIndex = 4 Then
                frm_changetime.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub QuickHighlightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickHighlightToolStripMenuItem.Click
        Highlight(ColorPicker.Color)
    End Sub

    Private Sub cmsSplitsGridView_Opening(sender As Object, e As CancelEventArgs) Handles cmsSplitsGridView.Opening
        QuickHighlightToolStripMenuItem.BackColor = ColorPicker.Color
    End Sub

    Private Sub btnendsplit_Click(sender As Object, e As EventArgs) Handles btnendsplit.Click
        EndSplit()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        settings.ShowDialog()
    End Sub

    Private Sub EditDBFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDBFileToolStripMenuItem.Click
        System.Diagnostics.Process.Start(My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename)
    End Sub

    Private Sub OpenSplitLocationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenSplitLocationToolStripMenuItem1.Click
        Try
            Process.Start(My.Computer.FileSystem.CurrentDirectory & "\Days")
        Catch
            MsgBox("Could not open the file path", 16, My.Application.Info.AssemblyName.ToString)
        End Try
    End Sub

    Private Sub TotalGroupTimeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TotalGroupTimeToolStripMenuItem1.Click
        TotalGroupTime()
    End Sub
End Class
