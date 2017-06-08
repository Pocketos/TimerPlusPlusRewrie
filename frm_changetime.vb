Public Class frm_changetime
    '///LIBRARIES
    'Gets the keystate library for splitting with the ENETER key.
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    '///VARIABLES
    Dim newtime As String = "0"

    '///SUBS
    Private Sub changeworktime()
        newtime = mtb_worktime.Text.ToString

        If IsDate(newtime) Then
            frmMain.SplitsDataTableDataGridView.Rows(frmMain.SplitsDataTableDataGridView.CurrentCell.RowIndex).Cells("DataGridViewTimeWorkedColumn").Value = newtime
            Close()
        Else
            MsgBox(newtime & "Is an invalid Time!")
        End If

    End Sub

    Private Sub frm_changetime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtb_worktime.Text = frmMain.SplitsDataTableDataGridView.CurrentCell.Value.ToString
    End Sub

    Private Sub txtdesc_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mtb_worktime.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            changeworktime()
        End If
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        changeworktime()
    End Sub
End Class