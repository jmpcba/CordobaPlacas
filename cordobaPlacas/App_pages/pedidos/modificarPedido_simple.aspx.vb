Public Class modificarPedido_simple
    Inherits System.Web.UI.Page

    Dim gp As GestorPedidos
    Dim gd As GestorDatos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gd = New GestorDatos()
        pnlDetalle.Visible = False
        pnlCombos.Visible = False

    End Sub

    Protected Sub grPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grPedidos.SelectedIndexChanged
        Try
            Dim row = grPedidos.SelectedRow
            Dim idItem = row.Cells(1).Text

            pnlPedidos.Visible = False
            pnlDetalle.Visible = True
            pnlCombos.Visible = True
            gp = New GestorPedidos(idItem)
            Session("gestorPedidos") = gp
            Session("idPedido") = gp.pedido.id
            'llenarGrillaDetalle()
            grDetalle.DataBind()
            msgPanel(String.Format("Detalle Pedido {0} - CARGADO", gp.pedido.id))
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub llenarGrillaDetalle()
        gp = Session("gestorPedidos")
        grDetalle.DataSource = gd.getItems(gp.pedido.id)
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
        Dim i As Item

        gp = Session("gestorPedidos")
        i = gp.pedido.getItemById(idItem)
        Session("idLinea") = i.getProducto().linea.id

        pnlDetalle.Visible = True
        grDetalle.EditIndex = e.NewEditIndex
        grDetalle.DataBind()
        ViewState("editIndex") = e.NewEditIndex

        Dim msg = "Modo Edicion"
        msgPanel(msg)

    End Sub

    Protected Sub grDetalle_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        pnlDetalle.Visible = True
        grDetalle.EditIndex = -1

    End Sub

    Protected Sub grDetalle_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim idItem = Convert.ToInt32(grDetalle.DataKeys(e.RowIndex).Value.ToString())
        Dim row As GridViewRow = grDetalle.Rows(e.RowIndex)
        Dim txtCant As TextBox = grDetalle.Rows(e.RowIndex).FindControl("txtCant")
        Dim cant = txtCant.Text.Trim

        Dim cbMadera As DropDownList
        Dim cbHoja As DropDownList
        Dim cbMarco As DropDownList
        Dim cbChapa As DropDownList
        Dim cbMano As DropDownList
        Dim producto As Producto

        gp = Session("gestorPedidos")

        cbMadera = grDetalle.Rows(ViewState("editIndex")).FindControl("cbmadera")
        cbHoja = grDetalle.Rows(ViewState("editIndex")).FindControl("cbHoja")
        cbMarco = grDetalle.Rows(ViewState("editIndex")).FindControl("cbMarco")
        cbChapa = grDetalle.Rows(ViewState("editIndex")).FindControl("cbChapa")
        cbMano = grDetalle.Rows(ViewState("editIndex")).FindControl("cbMano")

        Dim chapa = New Chapa(cbChapa.SelectedItem.Value, cbChapa.SelectedItem.Text)
        Dim marco = New Marco(cbMarco.SelectedItem.Value, cbMarco.SelectedItem.Text)
        Dim madera = New Madera(cbMadera.SelectedItem.Value, cbMadera.SelectedItem.Text)
        Dim hoja = New Hoja(cbHoja.SelectedItem.Value, cbHoja.SelectedItem.Text)
        Dim mano = New Mano(cbMano.SelectedItem.Value, cbMano.SelectedItem.Text)
        Dim linea = gp.pedido.items(gp.pedido.itemIndex(idItem)).getProducto().linea

        producto = New Producto(hoja, marco, madera, chapa, mano, linea)

        gp.pedido.items(gp.pedido.itemIndex(idItem)).setProducto(producto)
        gp.pedido.items(gp.pedido.itemIndex(idItem)).setCant(cant)

        Try
            gp.pedido.items(gp.pedido.itemIndex(idItem)).actualizar()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

        Dim msg = String.Format("Pedido {0} - ACTUALIZADO", gp.pedido.id)
        msgPanel(msg)
    End Sub

    Protected Sub grDetalle_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim row As GridViewRow = grDetalle.Rows(e.RowIndex)
        Dim idItem = row.Cells(0).Text
        gp = Session("gestorPedidos")

        Try
            gp.cancelarItem(idItem)
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

        Dim msg = String.Format("Item {0} - CANCELADO", idItem)
        msgPanel(msg)
    End Sub
End Class