Imports System.Net.Mail

Public Class Form1
    Private myMsg As New MailMessage
    Private smtpSender As New SmtpClient

    Private Sub createMessage()
        myMsg.From = New MailAddress(txtFrom.Text.Trim)
        myMsg.To.Add(txtTo.Text.Trim)
        myMsg.Subject = txtSubject.Text
        myMsg.Body = txtBody.Text
        myMsg.Priority = MailPriority.Normal
    End Sub

    Private Sub createSMTP()
        smtpSender.Credentials = New Net.NetworkCredential(txtFrom.Text.Trim, txtPassword.Text.Trim)
        smtpSender.EnableSsl = False
        smtpSender.Host = "Smtp.live.com"
        smtpSender.Port = "587"
    End Sub

    Private Sub sendMessage()
        Try
            smtpSender.Send(myMsg)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        createMessage()
        createSMTP()
        sendMessage()
    End Sub

    Private Sub btnResetFields_Click(sender As Object, e As EventArgs) Handles btnResetFields.Click
        txtBody.Clear()
        txtFrom.Clear()
        txtPassword.Clear()
        txtSubject.Clear()
        txtTo.Clear()
    End Sub
End Class
