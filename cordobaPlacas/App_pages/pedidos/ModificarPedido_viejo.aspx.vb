Public Class ModificarPedido_viejo
    Inherits System.Web.UI.Page
    Dim gestordatos As GestorDatos
    Dim gestorPedidos As GestorPedidos
    Dim idPedido As Integer
    Dim idItem As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gestordatos = New GestorDatos()
        pnlCombos.Visible = False
        pnlError.Visible = False
        lblDetalle.Text = ""

        Try
            If Not IsPostBack Then
                Dim cliente = New Cliente
                cbCliente.DataSource = cliente.getClientes()
                cbCliente.DataValueField = "id"
                cbCliente.DataTextField = "nombre"
                cbCliente.DataBind()
                cbCliente.Items.Add("")
                cbCliente.SelectedIndex = cbCliente.Items.Count - 1

                rfvLinea.Enabled = False
                rfvChapa.Enabled = False
                rfvMarco.Enabled = False
                rfvMadera.Enabled = False
                rfvHoja.Enabled = False
                rfvMano.Enabled = False
                rfvCantidad.Enabled = False
                rgxCantidad.Enabled = False
            End If
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscar()
    End Sub

    Private Sub buscar()
        Dim idPedido = Nothing
        Dim fecDesde = Nothing
        Dim fecHasta = Nothing
        Dim cliente = Nothing
        Dim estado = Nothing
        Dim table As DataTable
        Dim rowsToRemove = New List(Of DataRow)

        If cbCliente.SelectedItem.Value <> "" Then
            cliente = cbCliente.SelectedValue
        End If

        If txtPedido.Text <> "" Then
            idPedido = txtPedido.Text
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
            'table = gestordatos.buscarPedidos(idPedido, fecDesde, fecHasta, cliente, estado)
            'table.Columns(5)
            For Each row As DataRow In table.Rows
                If row("estado") = "EN CAMINO" Then
                    rowsToRemove.Add(row)
                End If
            Next

            For Each row As DataRow In rowsToRemove
                table.Rows.Remove(row)
            Next
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

        grPedidos.DataSource = table
        grPedidos.DataBind()

    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub grPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grPedidos.SelectedIndexChanged
        Try
            Dim row = grPedidos.SelectedRow
            Dim estado = row.Cells(3).Text
            idPedido = row.Cells(1).Text
            ViewState("idPedido") = idPedido

            Dim lbl = "MODIFICAR ESTADO PEDIDO " & idPedido

            grDetalle.DataSource = gestordatos.getItemsModificar(idPedido)
            grDetalle.DataBind()

            lblDetalle.Text = "DETALLE"
            Session("rowPedido") = grPedidos.SelectedRow

            gestorPedidos = New GestorPedidos(idPedido)
            Session("GestorPedidos") = gestorPedidos
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grDetalle.SelectedIndexChanged
        gestorPedidos = Session("GestorPedidos")
        Dim row = grDetalle.SelectedRow
        idItem = row.Cells(1).Text
        ViewState("idItem") = idItem
        Dim item As Item

        For Each i As Item In gestorPedidos.pedido.items
            If i.id = idItem Then
                item = i
                Exit For
            End If
        Next

        lblDetalle.Text = "DETALLE"
        pnlCombos.Visible = True
        rfvLinea.Enabled = True
        rfvChapa.Enabled = True
        rfvMarco.Enabled = True
        rfvMadera.Enabled = True
        rfvHoja.Enabled = True
        rfvMano.Enabled = True
        rfvCantidad.Enabled = True
        rgxCantidad.Enabled = True

        Try
            gestordatos.getComboLineas(cbLinea)
            cbLinea.SelectedValue = item.getProducto.linea.id

            'gestordatos.getCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

        cbChapa.SelectedValue = item.getProducto.chapa.id
        cbMarco.SelectedValue = item.getProducto.marco.id
        cbMadera.SelectedValue = item.getProducto.madera.id
        cbHoja.SelectedValue = item.getProducto.hoja.id
        cbMano.SelectedValue = item.getProducto.mano.id
        txtCantidad.Text = item.getCant()
        Session("GestorPedidos") = gestorPedidos
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            gestorPedidos = Session("GestorPedidos")
            idItem = ViewState("idItem")
            idPedido = gestorPedidos.pedido.id

            Dim chapa = New Chapa(cbChapa.SelectedItem.Value, cbChapa.SelectedItem.Text)
            Dim marco = New Marco(cbMarco.SelectedItem.Value, cbMarco.SelectedItem.Text)
            Dim madera = New Madera(cbMadera.SelectedItem.Value, cbMadera.SelectedItem.Text)
            Dim hoja = New Hoja(cbHoja.SelectedItem.Value, cbHoja.SelectedItem.Text)
            Dim mano = New Mano(cbMano.SelectedItem.Value, cbMano.SelectedItem.Text)
            Dim cant = txtCantidad.Text.Trim()
            Dim linea = New linea(cbLinea.SelectedItem.Value, cbLinea.SelectedItem.Text)
            Dim estado = New Estado(0)
            'Dim item = New Item_old(idItem, hoja, marco, madera, chapa, cant, mano, idPedido, linea, estado)

            'gestorPedidos.actualizarPedido(idPedido, Item)
            buscar()
            grDetalle.DataSource = gestordatos.getItemsModificar(idPedido)
            grDetalle.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Protected Sub cbLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLinea.SelectedIndexChanged
        Dim row = grDetalle.SelectedRow
        pnlCombos.Visible = True
        rfvLinea.Enabled = True
        rfvChapa.Enabled = True
        rfvMarco.Enabled = True
        rfvMadera.Enabled = True
        rfvHoja.Enabled = True
        rfvMano.Enabled = True
        rfvCantidad.Enabled = True
        rgxCantidad.Enabled = True

        Try
            'gestordatos.getCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Public Sub errorPanel(ByVal _msg As String)
        pnlError.Visible = True
        lblError.Text = _msg
    End Sub
End Class