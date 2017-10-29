Public Class settings
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ckbx_pause.Checked = My.Settings.pausebutton
        ckbx_tooltips.Checked = My.Settings.tooltips
        ckbx_recorded.Checked = My.Settings.markrecorded
        splitwarn_trackbar.Value = My.Settings.warntime
        lbl_settings_warn_track.Text = splitwarn_trackbar.Value
        btn_settings_defcolor.BackColor = My.Settings.defaultcolor
        btn_settings_quickcolor2.BackColor = My.Settings.quickcolor2
        btn_settings_quickcolor3.BackColor = My.Settings.quickcolor3
    End Sub

    Private Sub btn_settings_save_Click(sender As Object, e As EventArgs) Handles btn_settings_save.Click
        '///Pause button
        If ckbx_pause.Checked = True Then
            frmMain.btnpause.Enabled = True
            My.Settings.pausebutton = True
        Else
            If frmMain.btnpause.Text = "Resume" Then
                MsgBox("Please unpause the timer before disabling the Pausae button!", , My.Application.Info.AssemblyName.ToString)
            Else
                frmMain.btnpause.Enabled = False
                My.Settings.pausebutton = False
            End If
        End If

        '///Tooltip
        If ckbx_tooltips.Checked = True Then
            frmMain.ToolTip.Active = True
            My.Settings.tooltips = True
        Else
            frmMain.ToolTip.Active = False
            My.Settings.tooltips = False
        End If

        '///Mark splits as recorded after adding group time
        If ckbx_recorded.Checked = True Then
            My.Settings.markrecorded = True
        Else
            My.Settings.markrecorded = False
        End If

        '///Split warning timer
        My.Settings.warntime = splitwarn_trackbar.Value

        If frmMain.worktime > (My.Settings.warntime * 60) Then
            frmMain.lblwktm.BackColor = Color.Red
        Else
            frmMain.lblwktm.BackColor = SystemColors.Control
        End If

        '///Color for buttons
        My.Settings.defaultcolor = btn_settings_defcolor.BackColor
        frmMain.ColorPicker.Color = My.Settings.defaultcolor

        My.Settings.quickcolor2 = btn_settings_quickcolor2.BackColor

        My.Settings.quickcolor3 = btn_settings_quickcolor3.BackCOlor


        '///Close the settings window
        Close()
    End Sub

    Private Sub splitwarn_trackbar_ValueChanged(sender As Object, e As EventArgs) Handles splitwarn_trackbar.Scroll
        lbl_settings_warn_track.Text = splitwarn_trackbar.Value
    End Sub

    Private Sub btn_settings_defcolor_Click(sender As Object, e As EventArgs) Handles btn_settings_defcolor.Click
        If frmMain.ColorPicker.ShowDialog() = DialogResult.OK Then
            btn_settings_defcolor.BackColor = frmMain.ColorPicker.Color
        End If
    End Sub

    Private Sub btn_settings_quickcolor2_Click(sender As Object, e As EventArgs) Handles btn_settings_quickcolor2.Click
        If frmMain.ColorPicker.ShowDialog() = DialogResult.OK Then
            btn_settings_quickcolor2.BackColor = frmMain.ColorPicker.Color
        End If
    End Sub

    Private Sub btn_settings_quickcolor3_Click(sender As Object, e As EventArgs) Handles btn_settings_quickcolor3.Click
        If frmMain.ColorPicker.ShowDialog() = DialogResult.OK Then
            btn_settings_quickcolor3.BackColor = frmMain.ColorPicker.Color
        End If
    End Sub
End Class