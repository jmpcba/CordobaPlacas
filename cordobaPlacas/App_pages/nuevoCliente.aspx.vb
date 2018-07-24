Public Class nuevoCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlMsg.Visible = False
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cuit = txtCuit.Text.Trim().ToString
        cuit = cuit.Insert(2, "-")
        cuit = cuit.Insert(11, "-")
        Dim c = New Cliente(cuit, txtNombre.Text.Trim(), txtTel.Text.Trim(), txtMail.Text.Trim(), txtDir.Text.Trim(), txtCiudad.Text.Trim(), txtProvincia.Text.Trim())
        Try
            c.insertar()

            msgPanel("Nuevo Cliente Guardado")

            txtCuit.Text = ""
            txtNombre.Text = ""
            txtTel.Text = ""
            txtMail.Text = ""
            txtDir.Text = ""
            txtCiudad.Text = ""
            txtProvincia.Text = ""

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub errorPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub msgPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Green
    End Sub
End Class