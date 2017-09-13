Public Class settings
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ckbx_pause.Checked = My.Settings.pausebutton
        ckbx_tooltips.Checked = My.Settings.tooltips
        ckbx_recorded.Checked = My.Settings.markrecorded
        splitwarn_trackbar.Value = My.Settings.warntime
        lbl_settings_warn_track.Text = splitwarn_trackbar.Value
    End Sub

    Private Sub btn_settings_save_Click(sender As Object, e As EventArgs) Handles btn_settings_save.Click
        '///Pause button
        If ckbx_pause.Checked = True Then
            If frmMain.tmMain.Enabled = True Then
                If My.Settings.pausebutton = False Then
                    My.Settings.pausebutton = True
                    frmMain.btnpause.Enabled = True
                Else
                    If frmMain.btnpause.Text = "Pause" Then
                        My.Settings.pausebutton = False
                        frmMain.btnpause.Enabled = False
                    Else
                        MsgBox("The pause button cannot be disabled while the timer is inactive", , My.Application.Info.AssemblyName.ToString)
                        My.Settings.pausebutton = False
                    End If
                End If
            Else
                MsgBox("The pause button state cannot be changed while the timer is inactive", , My.Application.Info.AssemblyName.ToString)
            End If
        Else
            My.Settings.pausebutton = False
        End If

        '///Tooltip
        My.Settings.tooltips = ckbx_tooltips.Checked

        '///Mark splits as recorded after adding group time
        My.Settings.markrecorded = ckbx_recorded.Checked

        '///Split warning timer
        My.Settings.warntime = splitwarn_trackbar.Value
        frmMain.SplitWarningToolStripMenuItem.ToolTipText = My.Settings.warntime & " Minute"

        '///Close the settings window
        Close()
    End Sub

    Private Sub splitwarn_trackbar_ValueChanged(sender As Object, e As EventArgs) Handles splitwarn_trackbar.Scroll
        lbl_settings_warn_track.Text = splitwarn_trackbar.Value
    End Sub
End Class