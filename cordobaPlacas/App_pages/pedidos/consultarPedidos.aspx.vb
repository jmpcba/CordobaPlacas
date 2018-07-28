Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim gestorDatos As GestorDatos
    Dim cliente = New Cliente
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gestorDatos = New GestorDatos()
        cliente.id = 1

        pnlMsg.Visible = False
        pnlDetalle.Visible = False

        If Not IsPostBack Then
            Try
                gestorDatos.getCombos(dpFiltroEstados, GestorDatos.combos.estados)
                gestorDatos.getCombos(dpClientes, GestorDatos.combos.clientes)


                dpFiltroEstados.Items.Add("TODOS")
                dpFiltroEstados.SelectedIndex = dpFiltroEstados.Items.Count - 1

                dpClientes.Items.Add("TODOS")
                dpClientes.SelectedIndex = dpClientes.Items.Count - 1

            Catch ex As Exception
                errorPanel(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim idPedido = Nothing
        Dim fecRecDesde = Nothing
        Dim fecRecHasta = Nothing
        Dim fecModDesde = Nothing
        Dim fecModHasta = Nothing
        Dim idCliente = Nothing
        Dim idEstado = Nothing
        Dim table As DataTable

        pnlResultadoBusqueda.Visible = True
        grResultadoBusqueda.SelectedIndex = -1

        If txtPedido.Text <> "" Then
            idPedido = txtPedido.Text
        End If

        If txtFecRecDesde.Text <> "" Then
            fecRecDesde = txtFecRecDesde.Text
        End If

        If txtFecRecHasta.Text <> "" Then
            fecRecHasta = txtFecRecHasta.Text
        End If

        If txtFecModDesde.Text <> "" Then
            fecModDesde = txtFecModDesde.Text
        End If

        If txtFecModHasta.Text <> "" Then
            fecModHasta = txtFecModHasta.Text
        End If

        If dpClientes.SelectedValue <> "TODOS" Then
            idCliente = dpClientes.SelectedValue
        End If

        If dpFiltroEstados.SelectedValue <> "TODOS" Then
            idEstado = dpFiltroEstados.SelectedValue
        End If

        grResultadoBusqueda.DataSource = Nothing
        grResultadoBusqueda.DataBind()

        Try
            table = gestorDatos.buscarPedidos(idPedido, fecRecDesde, fecRecHasta, fecModDesde, fecModHasta, idCliente, idEstado)
            grResultadoBusqueda.DataSourceID = Nothing
            grResultadoBusqueda.DataSource = table
            grResultadoBusqueda.DataBind()

            Dim msg = "Resultados de busqueda - CARGADOS"
            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub msgPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Green
    End Sub

    Private Sub errorPanel(ByVal _msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Red
    End Sub

    Protected Sub grResultadoBusqueda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grResultadoBusqueda.SelectedIndexChanged
        Try
            pnlDetalle.Visible = True
            Dim row = grResultadoBusqueda.SelectedRow
            Dim idPedido = row.Cells(1).Text
            Dim gestorPedidos = New GestorPedidos(idPedido)
            Dim pedido As Pedido
            Dim gestorDatos = New GestorDatos()
            Session.Add("gestorPedido", gestorPedidos)
            pedido = gestorPedidos.pedido

            gestorDatos.consultarPedido(pedido, grDetalleBusqueda)

            msgPanel(String.Format("Datos pedido {0} CARGADOS", idPedido))
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub
End Class