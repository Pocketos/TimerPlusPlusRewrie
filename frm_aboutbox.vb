Public NotInheritable Class frm_aboutbox

    Private Sub frm_aboutbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        'Initialize all of the text displayed on the About Box.
        Me.lblProductName.Text = My.Application.Info.ProductName
        Me.lblVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.lblCopyright.Text = My.Application.Info.Copyright
        Me.lblCompanyName.Text = My.Application.Info.CompanyName
        Me.lblDesc.Text = My.Application.Info.Description
        'Add the license link
        lnk_gnu.Links.Add(0, 18, "https://www.gnu.org/licenses/gpl-3.0.txt")
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub RichTextBox_GNU_Link_Clicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs)
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub lblCompanyName_Click(sender As Object, e As EventArgs) Handles lblCompanyName.Click
        System.Diagnostics.Process.Start("https://www.korkscrewgaming.com")
    End Sub

    Private Sub lnk_gnu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_gnu.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub
End Class
