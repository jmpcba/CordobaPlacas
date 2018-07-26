Public Class busquedaCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim c As Cliente
        Dim gd As GestorDatos
        c = New Cliente(txtCuit.Text.Trim, txtNombre.Text.Trim, txtTel.Text.Trim, txtMail.Text.Trim, txtDir.Text.Trim, txtCiudad.Text.Trim, txtProvincia.Text.Trim)
        gd = New GestorDatos

        Try
            gd.buscarCliente(c, grResultado)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub grResultado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grResultado.SelectedIndexChanged
        Dim row = grResultado.SelectedRow
        Dim id = row.Cells(1).Text

        Response.Redirect("modificarCliente.aspx?IDCliente=" & id)
    End Sub
End Class