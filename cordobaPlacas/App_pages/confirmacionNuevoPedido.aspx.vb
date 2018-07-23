Public Class confirmacionNuevoPedido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idPedido = Request.QueryString("idPedido")
        Dim cant = Request.QueryString("cant")
        Dim precio = Request.QueryString("precio")

        If idPedido <> "" Then
            lblNroPedido.Text = idPedido
            'lblCant.Text = cant
            'lblPrecio.Text = precio
        Else
            lblNroPedido.Text = ""
            'lblCant.Text = ""
            'lblPrecio.Text = ""
        End If
    End Sub

End Class