Public Class frmMain

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Private Declare Function FlashWindow Lib "user32" Alias "FlashWindow" (ByVal wHandle As Long, ByVal invertStates As Boolean) As Long


    Public splits As Integer = 0
    Public worktime As Integer = 0
    Public filename As String

    Public Sub datecheck()
        Dim currentdate As Date = Today
        Dim currentmonth As String
        Dim currentday As String
        Dim currentyear As String
        currentmonth = Month(currentdate)
        currentday = DateAndTime.Day(currentdate)
        currentyear = Year(currentdate)

        filename = currentday & "-" & currentmonth & "-" & currentyear & ".xml"

        If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory & "\Days") Then
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename) = False Then
                Me.SplitsDataSet.WriteXml("Days\" & filename)
            Else
                Me.SplitsDataSet.ReadXml("Days\" & filename)
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

    Public Sub Split()
        If tmMain.Enabled = False Then
            SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
            txtdesc.Clear()
            tmMain.Enabled = True
            btnpause.Enabled = True
        Else
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewStopTimeColumn").Value = Now.ToShortTimeString
            Dim time = New TimeSpan(0, 0, worktime)
            SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewTimeWorkedColumn").Value = time
            If chkbxrecorded.Checked = True Then
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewRecordedColumn").Value = True
                chkbxrecorded.Checked = False
            Else
                SplitsDataTableDataGridView.Rows(splits).Cells("DataGridViewRecordedColumn").Value = False
            End If
            splits = splits + 1
            worktime = 0
            SplitsDataSet.SplitsDataTable.Rows.Add(splits, txtdesc.Text, Now.ToShortTimeString)
            txtdesc.Clear()
            Me.SplitsDataSet.WriteXml("Days\" & filename)
        End If
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
            Me.Icon = My.Resources.stopwatchpaused
            tmPaused.Enabled = True
        Else
            tmMain.Enabled = True
            txtdesc.Enabled = True
            btnSplit.Enabled = True
            btnpause.Text = "Pause"
            Me.Icon = My.Resources.stopwatch
            tmPaused.Enabled = False
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
        SplitsDataTableDataGridView.CurrentCell = Nothing
        Me.SplitsDataSet.WriteXml("Days\" & filename)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Version " & My.Application.Info.Version.ToString())
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click

        Dim importresult As Integer = MessageBox.Show("Importing Splits will delete the current set!", "Overwrite current splits?", MessageBoxButtons.OKCancel)
        If importresult = DialogResult.OK Then
            tmMain.Enabled = False
            worktime = 0
            SplitsDataSet.Clear()
            txtdesc.Enabled = True
            btnSplit.Enabled = True
            btnpause.Text = "Pause"
            Me.Icon = My.Resources.stopwatch
            btnpause.Enabled = False
            tmPaused.Enabled = False
            Me.SplitsDataSet.ReadXml("Days\" & filename)
            Try
                splits = SplitsDataSet.SplitsDataTable.Rows(SplitsDataSet.SplitsDataTable.Rows.Count - 1).Item("ID") + 1
            Catch
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ClearSplitsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSplitsToolStripMenuItem.Click
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
            tmPaused.Enabled = False
            lblwktm.Text = "00:00:00"
            btnpause.Enabled = False
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ReviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReviewToolStripMenuItem.Click
        System.Diagnostics.Process.Start(My.Computer.FileSystem.CurrentDirectory & "\Days\" & filename)
    End Sub

    Private Sub tmPaused_Tick(sender As Object, e As EventArgs) Handles tmPaused.Tick
        FlashWindow(Me.Handle, 1)
    End Sub
End Class
