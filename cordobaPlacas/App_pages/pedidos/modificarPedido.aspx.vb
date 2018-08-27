Public Class modificarPedido_simple
    Inherits System.Web.UI.Page

    Dim gp As GestorPedidos
    Dim gd As GestorDatos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gd = New GestorDatos()
        pnlDetalle.Visible = False
        pnlAgregar.Visible = False
        btnAgregar.Visible = True

        If Not IsPostBack Then
            gd.getComboLineas(cbLinea)
            llenarGrillaPedido()
        End If


    End Sub

    Private Sub llenarGrillaPedido()
        grPedidos.DataSource = gd.getGrilla(GestorDatos.grillas.pedidosModificar)
        grPedidos.DataBind()
    End Sub

    Protected Sub grPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grPedidos.SelectedIndexChanged
        Try
            Dim row = grPedidos.SelectedRow
            Dim idItem = row.Cells(1).Text

            pnlPedidos.Visible = False
            pnlDetalle.Visible = True
            pnlAgregar.Visible = True
            gp = New GestorPedidos(idItem)

            Session("gestorPedidos") = gp

            llenarGrillaDetalle()

            If gp.pedido.estado.id > Estado.estados.recibido Then
                For Each r As GridViewRow In grDetalle.Rows
                    Dim btnEditar As ImageButton
                    btnEditar = r.FindControl("btnEditar")
                    btnEditar.Visible = False
                Next
            End If

            If gp.pedido.estado.id > Estado.estados.deposito Then
                btnAgregar.Visible = False
            End If

            lblDetalle.Text = String.Format("Detalle Pedido: {0}", gp.pedido.id)

            msgPanel(String.Format("Detalle Pedido {0} - CARGADO", gp.pedido.id))
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub llenarGrillaDetalle()

        gp = Session("gestorPedidos")
        grDetalle.DataSource = gd.getItemsModificar(gp.pedido.id)
        grDetalle.DataBind()
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

    Protected Sub grDetalle_RowEditing(sender As Object, e As GridViewEditEventArgs)
        Dim idItem = Convert.ToInt32(grDetalle.DataKeys(e.NewEditIndex).Value.ToString())

        gp = Session("gestorPedidos")

        pnlDetalle.Visible = True

        Session("idLinea") = gp.pedido.items(gp.pedido.itemIndex(idItem)).getProducto().linea.id
        ViewState("editIndex") = e.NewEditIndex

        grDetalle.EditIndex = e.NewEditIndex

        llenarGrillaDetalle()
        pnlAgregar.Visible = True
        btnAgregar.Visible = False
        msgPanel(String.Format("Editando Item {0}", idItem))

    End Sub

    Protected Sub grDetalle_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        pnlDetalle.Visible = True
        grDetalle.EditIndex = -1
        llenarGrillaDetalle()
        pnlAgregar.Visible = True
        msgPanel("Modo Edicion Cancelado")
    End Sub

    Protected Sub grDetalle_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        gp = Session("gestorPedidos")
        Dim idItem = Convert.ToInt32(grDetalle.DataKeys(e.RowIndex).Value.ToString())
        Dim itemIndex = gp.pedido.itemIndex(idItem)
        Dim txtCant As TextBox = grDetalle.Rows(e.RowIndex).FindControl("txtCant")
        Dim cant = txtCant.Text.Trim
        Dim cbMadera As DropDownList
        Dim cbHoja As DropDownList
        Dim cbMarco As DropDownList
        Dim cbChapa As DropDownList
        Dim cbMano As DropDownList
        Dim producto As Producto

        cbMadera = grDetalle.Rows(e.RowIndex).FindControl("cbmadera")
        cbHoja = grDetalle.Rows(e.RowIndex).FindControl("cbHoja")
        cbMarco = grDetalle.Rows(e.RowIndex).FindControl("cbMarco")
        cbChapa = grDetalle.Rows(e.RowIndex).FindControl("cbChapa")
        cbMano = grDetalle.Rows(e.RowIndex).FindControl("cbMano")

        Dim chapa = New Chapa(cbChapa.SelectedItem.Value, cbChapa.SelectedItem.Text)
        Dim marco = New Marco(cbMarco.SelectedItem.Value, cbMarco.SelectedItem.Text)
        Dim madera = New Madera(cbMadera.SelectedItem.Value, cbMadera.SelectedItem.Text)
        Dim hoja = New Hoja(cbHoja.SelectedItem.Value, cbHoja.SelectedItem.Text)
        Dim mano = New Mano(cbMano.SelectedItem.Value, cbMano.SelectedItem.Text)
        Dim linea = gp.pedido.items(gp.pedido.itemIndex(idItem)).getProducto().linea

        producto = New Producto(hoja, marco, madera, chapa, mano, linea)

        Try
            gp.pedido.items(itemIndex).setProducto(producto)
            gp.pedido.items(itemIndex).setCant(cant)
            gp.pedido.items(itemIndex).actualizar()
            pnlDetalle.Visible = True
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

        Dim msg = String.Format("Pedido {0} - ACTUALIZADO", gp.pedido.id)
        msgPanel(msg)

        grDetalle.EditIndex = -1
        llenarGrillaDetalle()

        Session("gestorPedidos") = gp
        pnlAgregar.Visible = True

    End Sub

    Protected Sub grDetalle_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim idItem = Convert.ToInt32(grDetalle.DataKeys(e.RowIndex).Value.ToString())
        gp = Session("gestorPedidos")
        Dim itemIndex = gp.pedido.itemIndex(idItem)


        Try
            gp.cancelarItem(idItem)
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

        msgPanel(String.Format("ITEM {0}- CANCELADO", idItem))
        pnlDetalle.Visible = True
        'TODO IMPRIMIR ETIQUETAS DE DEPOSITO Y NOTIFICACION PARA PRODUCCION
        pnlAgregar.Visible = True
    End Sub

    Protected Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub grPedidos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grPedidos.RowDeleting
        Dim idPedido = Convert.ToInt32(grPedidos.DataKeys(e.RowIndex).Value.ToString())
        gp = New GestorPedidos(idPedido)

        Try
            gp.cancelarPedido()
            llenarGrillaPedido()
            msgPanel(String.Format("Pedido {0} - CANCELADO", idPedido))
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Protected Sub cbLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLinea.SelectedIndexChanged
        pnlDetalle.Visible = True
        pnlAgregar.Visible = True
        gd.fillCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)
        btnAgregar_ModalPopupExtender.Show()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        gp = Session("gestorPedidos")
        Dim chapa = New Chapa(cbChapa.SelectedItem.Value, cbChapa.SelectedItem.Text)
        Dim marco = New Marco(cbMarco.SelectedItem.Value, cbMarco.SelectedItem.Text)
        Dim madera = New Madera(cbMadera.SelectedItem.Value, cbMadera.SelectedItem.Text)
        Dim hoja = New Hoja(cbHoja.SelectedItem.Value, cbHoja.SelectedItem.Text)
        Dim mano = New Mano(cbMano.SelectedItem.Value, cbMano.SelectedItem.Text)
        Dim cant = txtCant.Text.Trim()
        Dim linea = New linea(cbLinea.SelectedItem.Value, cbLinea.SelectedItem.Text)
        Dim producto = New Producto(hoja, marco, madera, chapa, mano, linea)

        Dim item = New Item(producto, cant)
        gp.addItem(item, True)

        Dim msg = String.Format("Nuevo Item Agregado")
        msgPanel(msg)

        pnlDetalle.Visible = True
        pnlAgregar.Visible = True
        llenarGrillaDetalle()

    End Sub

    Protected Sub [select](sender As Object, e As CommandEventArgs)

    End Sub
End Class