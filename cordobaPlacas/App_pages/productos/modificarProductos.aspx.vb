Public Class modificarProductos
    Inherits System.Web.UI.Page
    Dim gd As GestorDatos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gd = New GestorDatos()

        pnlDespiece.Visible = False

        If Not IsPostBack Then
            llenarGrillaProductos()
            dpChapa.Items.Insert(0, "")
            dpHoja.Items.Insert(0, "")
            dpMadera.Items.Insert(0, "")
            dpMano.Items.Insert(0, "")
            dpMarco.Items.Insert(0, "")
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
            grProductos.DataSource = gd.getGrilla(GestorDatos.grillas.productos)
            grProductos.DataBind()
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
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub grProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grProductos.SelectedIndexChanged
        Dim idProducto = grProductos.DataKeys(grProductos.SelectedIndex).Value.ToString()

        pnlProductos.Visible = False
        pnlDespiece.Visible = True

        Try
            grDespiece.DataSource = gd.getDespieceProducto(idProducto)
            grDespiece.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub
End Class