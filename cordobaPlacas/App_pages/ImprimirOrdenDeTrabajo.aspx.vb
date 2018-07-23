Public Class ImprimirOrdenDeTrabajo
    Inherits System.Web.UI.Page
    Dim gestorDatos As GestorDatos
    Dim gestorPedidos As GestorPedidos
    Private idPedido As Integer
    'Dim estado = New Estado

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gestorDatos = New GestorDatos()
        btnActualizar.Enabled = False
        pnlCombos.Visible = False
        pnlBusquedas.Visible = True

        If Not IsPostBack Then
            Try

                gestorDatos.getCombos(dpFiltroEstados, GestorDatos.combos.estados)
                gestorDatos.getCombos(cbCliente, GestorDatos.combos.clientes)
                cbCliente.Items.Add("")
                cbCliente.SelectedIndex = cbCliente.Items.Count - 1
                dpFiltroEstados.Items.Add("")
                dpFiltroEstados.SelectedIndex = dpFiltroEstados.Items.Count - 1
            Catch ex As Exception
                errorPanel(ex.Message)
            End Try

        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscar()
    End Sub

    Protected Sub grPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grPedidos.SelectedIndexChanged
        Dim nt = New DataTable
        Dim ds = New DataTable
        Dim dtPedidos = New DataTable
        Try
            Dim row = grPedidos.SelectedRow
            pnlPedidos.Visible = False
            pnlDetalle.Visible = True
            idPedido = row.Cells(1).Text
            gestorPedidos = New GestorPedidos(idPedido)
            Session("gestorPedidos") = gestorPedidos
            dtPedidos = Session("dtPedidos")

            ds = gestorDatos.getItems(gestorPedidos.pedido.id)
            grDetalle.DataSource = ds
            grDetalle.DataBind()

            nt = dtPedidos.Clone
            For Each r As DataRow In dtPedidos.Rows
                If r("Nro Pedido") = idPedido Then
                    nt.ImportRow(r)
                    Exit For
                End If
            Next

            grPedidoDetalle.DataSource = nt
            grPedidoDetalle.DataBind()

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    'Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
    '    Dim row = grPedidos.SelectedRow
    '    gestorPedidos = Session("gestorPedidos")
    '    Try
    '        gestorPedidos.actualizarPedido(gestorPedidos.pedido.id, "estado", dpEstados.SelectedItem.Value)
    '        buscar()
    '    Catch ex As Exception
    '        errorPanel(ex.Message)
    '    End Try
    'End Sub

    Private Sub buscar()
        Dim dtPedidos = New DataTable
        Dim idPedido = Nothing
        Dim fecDesde = Nothing
        Dim fecHasta = Nothing
        Dim cliente = Nothing
        Dim estado = Nothing

        pnlPedidos.Visible = True
        pnlCombos.Visible = False
        pnlDetalle.Visible = False

        If cbCliente.SelectedItem.Value <> "" Then
            cliente = cbCliente.SelectedValue
        End If

        If txtPedido.Text <> "" Then
            idPedido = txtPedido.Text
        End If

        If dpFiltroEstados.SelectedItem.Value <> "" Then
            estado = dpFiltroEstados.SelectedItem.Value
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
            'dtPedidos = gestorDatos.buscarPedidos(idPedido, fecDesde, fecHasta, cliente, estado)
            grPedidos.DataSource = dtPedidos
            grPedidos.DataBind()
            Session("dtPedidos") = dtPedidos
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Public Sub errorPanel(ByVal _msg As String)
        pnlError.Visible = True
        lblError.Text = _msg
    End Sub

    Protected Sub grDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grDetalle.SelectedIndexChanged
        pnlPedidos.Visible = False
        pnlCombos.Visible = True
        gestorPedidos = Session("gestorPedidos")
        gestorDatos.cargarEstados(dpEstados, gestorPedidos.pedido.estado.id)
    End Sub

    Protected Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        pnlDetalle.Visible = False
        pnlPedidos.Visible = True
    End Sub
End Class