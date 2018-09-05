Public Class modificarProductos
    Inherits System.Web.UI.Page
    Dim gd As GestorDatos
    Dim filtros = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gd = New GestorDatos()

        pnlDespiece.Visible = False

        If Not IsPostBack Then
            llenarGrillaProductos()
        End If
    End Sub

    Protected Sub grProductos_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grProductos.RowEditing
        'Dim idProducto = Convert.ToInt32(grProductos.DataKeys(e.NewEditIndex).Value.ToString())
        grProductos.EditIndex = e.NewEditIndex
        llenarGrillaProductos()
        ViewState("editIndex") = e.NewEditIndex
        msgPanel("Editando Producto")
    End Sub

    Public Sub llenarGrillaProductos()
        Try
            If ViewState("filtro") Then
                buscar()
            Else
                grProductos.DataSource = gd.getGrilla(GestorDatos.grillas.productos)
                grProductos.DataBind()
            End If

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

    Protected Sub grProductos_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grProductos.RowCancelingEdit
        grProductos.EditIndex = -1
        llenarGrillaProductos()
        msgPanel("Modo Edicion Cancelado")
    End Sub

    Protected Sub grProductos_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grProductos.RowUpdating
        Try
            Dim idProducto = Convert.ToInt32(grProductos.DataKeys(e.RowIndex).Value.ToString())
            Dim producto = New Producto(idProducto)
            Dim txtStock As TextBox
            Dim txtPrecio As TextBox

            txtStock = grProductos.Rows(e.RowIndex).FindControl("txtStock")
            txtPrecio = grProductos.Rows(e.RowIndex).FindControl("txtPrecio")

            producto.stock = txtStock.Text.Trim
            producto.precioUnitario = txtPrecio.Text.Trim
            producto.actualizar()

            grProductos.EditIndex = -1
            llenarGrillaProductos()

            msgPanel("Producto - ACTUALIZADO")
            grProductos.Rows(e.RowIndex).ForeColor = Drawing.Color.Green

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Protected Sub dpchapa_DataBound(sender As Object, e As EventArgs) Handles dpChapa.DataBound
        dpChapa.Items.Insert(0, "")
    End Sub

    Protected Sub dpHoja_DataBound(sender As Object, e As EventArgs) Handles dpHoja.DataBound
        dpHoja.Items.Insert(0, "")
    End Sub

    Protected Sub dpMarco_DataBound(sender As Object, e As EventArgs) Handles dpMarco.DataBound
        dpMarco.Items.Insert(0, "")
    End Sub

    Protected Sub dpMadera_DataBound(sender As Object, e As EventArgs) Handles dpMadera.DataBound
        dpMadera.Items.Insert(0, "")
    End Sub

    Protected Sub dpMano_DataBound(sender As Object, e As EventArgs) Handles dpMano.DataBound
        dpMano.Items.Insert(0, "")
    End Sub

    Private Sub buscar()
        ViewState("filtro") = 1
        Dim idLinea = dpLinea.SelectedValue
        Dim idChapa = dpChapa.SelectedValue
        Dim idHoja = dpHoja.SelectedValue
        Dim idMarco = dpMarco.SelectedValue
        Dim idMadera = dpMadera.SelectedValue
        Dim idMano = dpMano.SelectedValue
        grProductos.DataSource = gd.buscarProductos(idLinea, idChapa, idHoja, idMarco, idMadera, idMano)
        grProductos.DataBind()
    End Sub

    Protected Sub dpLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpLinea.SelectedIndexChanged
        gd.fillCombos(dpLinea, dpChapa, dpMarco, dpMadera, dpHoja, dpMano)
        buscar()

    End Sub

    Protected Sub dpChapa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpChapa.SelectedIndexChanged
        buscar()

    End Sub

    Protected Sub dpHoja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpHoja.SelectedIndexChanged
        buscar()

    End Sub

    Protected Sub dpMarco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpMarco.SelectedIndexChanged
        buscar()

    End Sub

    Protected Sub dpMadera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpMadera.SelectedIndexChanged
        buscar()

    End Sub

    Protected Sub dpMano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpMano.SelectedIndexChanged
        buscar()

    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        ViewState("filtro") = 0
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub grProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grProductos.SelectedIndexChanged
        Dim idProducto = grProductos.DataKeys(grProductos.SelectedIndex).Value.ToString()

        pnlProductos.Visible = False
        pnlDespiece.Visible = True
        ViewState("idProducto") = idProducto
        llenarGrillaDespiece(idProducto)
        msgPanel("Despiece producto - CARGADO")
    End Sub

    Private Sub llenarGrillaDespiece(_idProducto)
        Try
            grDespiece.DataSource = gd.getDespieceProducto(_idProducto)
            grDespiece.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grDespiece_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grDespiece.RowEditing
        grDespiece.EditIndex = e.NewEditIndex
        llenarGrillaDespiece(ViewState("idProducto"))
        msgPanel("Editando Producto")
        pnlDespiece.Visible = True
    End Sub

    Protected Sub grDespiece_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grDespiece.RowCancelingEdit
        pnlDespiece.Visible = True
        grDespiece.EditIndex = -1
        llenarGrillaDespiece(ViewState("idProducto"))
    End Sub

    Protected Sub grDespiece_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grDespiece.RowDeleting

        Dim idPieza = grDespiece.DataKeys(e.RowIndex).Value.ToString()
        Dim idProducto = ViewState("idProducto")
        Dim gprod = New GestorProductos(idProducto)
        pnlDespiece.Visible = True
        Try
            gprod.eliminarPieza(idPieza)
            llenarGrillaDespiece(idProducto)
            msgPanel("Pieza aliminada del despiece - CORRECTAMENTE")
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grDespiece_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grDespiece.RowCommand
        If e.CommandName = "insert" Then
            Dim idProducto = ViewState("idProducto")
            Dim gprod = New GestorProductos(idProducto)
            Dim cbPieza As DropDownList
            Dim txtConsumo As TextBox

            Try
                cbPieza = grDespiece.FooterRow.FindControl("cbNombre")
                txtConsumo = grDespiece.FooterRow.FindControl("txtConsumo")

                pnlDespiece.Visible = True
                gprod.agregarPieza(cbPieza.SelectedValue, txtConsumo.Text.Trim)
                llenarGrillaDespiece(idProducto)
                msgPanel("Pieza agregada al despiece")
            Catch ex As Exception
                errorPanel(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        pnlDespiece.Visible = False
        pnlProductos.Visible = True
    End Sub

    Protected Sub grDespiece_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grDespiece.RowUpdating

        Try
            pnlDespiece.Visible = True
            Dim idProducto = ViewState("idProducto")
            Dim gprod = New GestorProductos(idProducto)
            Dim idPieza = grDespiece.DataKeys(e.RowIndex).Value.ToString()
            Dim txtConsumo As TextBox

            txtConsumo = grDespiece.Rows(e.RowIndex).FindControl("txtConsumo")
            gprod.actualizarDespiece(idPieza, txtConsumo.Text.Trim)
            msgPanel("Despiece - ACTUALIZADO")
            grDespiece.EditIndex = -1
            llenarGrillaDespiece(idProducto)
            grDespiece.Rows(e.RowIndex).ForeColor = Drawing.Color.Green
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grlineas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grlineas.RowCommand
        imgBtnConfig_ModalPopupExtender.Show()
    End Sub

    Protected Sub grMaderas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grMaderas.RowCommand
        imgBtnConfig_ModalPopupExtender.Show()
    End Sub

    Protected Sub grChapas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grChapas.RowCommand
        imgBtnConfig_ModalPopupExtender.Show()
    End Sub

    Protected Sub grHoja_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grHoja.RowCommand
        imgBtnConfig_ModalPopupExtender.Show()
    End Sub

    Protected Sub grMarcos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grMarcos.RowCommand
        imgBtnConfig_ModalPopupExtender.Show()
    End Sub

    Protected Sub grManos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grManos.RowCommand
        imgBtnConfig_ModalPopupExtender.Show()
    End Sub
End Class