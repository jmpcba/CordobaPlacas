Imports System.Net.Mail
Imports System.Net

Public Class mail
    Dim client = New SmtpClient()
    Dim NetworkCred As NetworkCredential = New System.Net.NetworkCredential()

    Public Sub New()
        client.EnableSsl = True
        client.Host = "smtp.gmail.com"
        client.Port = 587
        NetworkCred.UserName = "jmpcba@gmail.com"
        NetworkCred.Password = "Newuser1!"
        client.UseDefaultCredentials = True
        client.Credentials = NetworkCred
    End Sub

    Public Sub send(_body As String)
        Try
            Dim mm As MailMessage = New MailMessage()

            mm.From = New MailAddress("cordobaplacasyplacares@yahoo.com.ar")
            mm.Subject = "PEDIDO CORDOBA PLACAS Y PLACARES"
            mm.Body = _body
            mm.To.Add(New MailAddress("jmpcba@gmail.com"))
            client.send(mm)
        Catch ex As Exception

        End Try

    End Sub

End Class
