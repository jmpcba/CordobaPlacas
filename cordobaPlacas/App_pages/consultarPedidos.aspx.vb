Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim gestorDatos As GestorDatos
    Dim cliente = New Cliente
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gestorDatos = New GestorDatos()
        cliente.id = 1
        lblDetalle.Text = ""
        pnlError.Visible = False

        If Not IsPostBack Then
            Try
                gestorDatos.getCombos(dpFiltroEstados, GestorDatos.combos.estados)
                dpFiltroEstados.Items.Add("")
                dpFiltroEstados.SelectedIndex = dpFiltroEstados.Items.Count - 1
            Catch ex As Exception
                errorPanel(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub grPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grPedidos.SelectedIndexChanged
        gestorDatos = New GestorDatos()
        Dim row = grPedidos.SelectedRow
        Dim estado = row.Cells(3).Text
        Dim idPedido = row.Cells(1).Text
        Try
            lblDetalle.Text = "DETALLE"
            grDetalle.DataSource = gestorDatos.getItems(idPedido)
            grDetalle.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub buscar()
        Dim idPedido = Nothing
        Dim fecha = Nothing
        Dim estado = Nothing
        Dim fecDesde = Nothing
        Dim fecHasta = Nothing

        If txtPedido.Text <> "" Then
            idPedido = txtPedido.Text
        End If

        If dpFiltroEstados.SelectedItem.Value <> "" Then
            estado = dpFiltroEstados.SelectedValue
        End If

        If txtFecDesde.Text <> "" Then
            fecDesde = txtFecDesde.Text
        End If

        If txtFecHasta.Text <> "" Then
            fecHasta = txtFecHasta.Text
        End If

        grDetalle.DataSource = Nothing
        grDetalle.DataBind()

        Try
            'grPedidos.DataSource = gestorDatos.buscarPedidos(idPedido, fecDesde, fecHasta, cliente.id, estado)
            grPedidos.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscar()
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Public Sub errorPanel(ByVal _msg As String)
        pnlError.Visible = True
        lblError.Text = _msg
    End Sub
End Class