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

        gp = Session("gestorPedidos")

        pnlDetalle.Visible = True
        grDetalle.EditIndex = e.NewEditIndex
        grDetalle.DataBind()
        'llenarGrillaDetalle()
    End Sub

    Protected Sub grDetalle_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        pnlDetalle.Visible = True
        grDetalle.EditIndex = -1
        'llenarGrillaDetalle()
    End Sub

    Protected Sub grDetalle_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim idItem = Convert.ToInt32(grDetalle.DataKeys(e.RowIndex).Value.ToString())
        Dim txtCant As TextBox = grDetalle.Rows(e.RowIndex).FindControl("txtCant")
        Dim cant = txtCant.Text.Trim

        gp = Session("gestorPedidos")

        gp.pedido.items(gp.pedido.itemIndex(idItem)).setCant(cant)
        gp.pedido.items(gp.pedido.itemIndex(idItem)).actualizar()

        'llenarGrillaDetalle()

        Dim msg = String.Format("Carga de datos pedido {0} - CORRECTA", gp.pedido.id)
        msgPanel(msg)
    End Sub

    Protected Sub grDetalle_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub
End Class