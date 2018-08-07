Public Class ModificarPedidos
    Inherits System.Web.UI.Page

    Dim gestorDatos As GestorDatos
    Dim gestorPedidos As GestorPedidos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gestorDatos = New GestorDatos
        'pnldetallePedido.Visible = False
        'pnlModificarCombos.Visible = False


    End Sub

    Protected Sub grPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grPedidos.SelectedIndexChanged
        Dim row = grPedidos.SelectedRow
        Dim idPedido = row.Cells(1).Text

        pnldetallePedido.Visible = True
        rbOpciones.Items(0).Enabled = True
        rbOpciones.Items(1).Enabled = True

        gestorPedidos = New GestorPedidos(idPedido)
        Session("gestorPedidos") = gestorPedidos

        grDetalle.DataSource = gestorDatos.getItemsModificar(idPedido)
        grDetalle.DataBind()
        grDetalle.SelectedIndex = -1
    End Sub

    Protected Sub Wizard1_FinishButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick

    End Sub

    Private Sub Wizard1_NextButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.NextButtonClick
        gestorPedidos = Session("gestorPedidos")

        If e.CurrentStepIndex = 0 Then
            Dim dt As New DataTable
            If rbOpciones.SelectedIndex = 0 Then

                dt = gestorDatos.buscarPedidos(Nothing, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, Nothing, Estado.estados.enCola)
                dt.Merge(gestorDatos.buscarPedidos(Nothing, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, Nothing, Estado.estados.recibido))
                dt.DefaultView.Sort = "Fecha Recibido"
                grPedidos.DataSource = dt
                grPedidos.DataBind()

            ElseIf rbOpciones.SelectedIndex = 1 Then
                dt = gestorDatos.buscarPedidos(Nothing, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, Nothing, Nothing)

                grPedidos.DataSource = dt
                grPedidos.DataBind()
            End If
        End If
    End Sub

    Protected Sub grDetalleModificar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grDetalleModificar.SelectedIndexChanged
        Dim row = grDetalleModificar.SelectedRow
        Dim idItem = row.Cells(1).Text
        Dim item As Item
        gestorPedidos = Session("gestorPedidos")

        item = gestorPedidos.pedido.getItemById(idItem)
        Session("itemActivo") = item

        pnlModificarCombos.Visible = True

        gestorDatos.getComboLineas(cbLinea)
        cbLinea.SelectedValue = item.getProducto.linea.id

        gestorDatos.fillCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)

        cbChapa.SelectedValue = item.getProducto.chapa.id
        cbHoja.SelectedValue = item.getProducto.hoja.id
        cbMadera.SelectedValue = item.getProducto.madera.id
        cbMano.SelectedValue = item.getProducto.mano.id
        cbMarco.SelectedValue = item.getProducto.marco.id
        txtCant.Text = item.getCant()

    End Sub

    Protected Sub cbLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLinea.SelectedIndexChanged
        pnlModificarCombos.Visible = True
        gestorDatos.fillCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim row = grDetalleModificar.SelectedRow
        Dim idItem = row.Cells(1).Text
        Dim itemOrig As Item

        Dim chapa = New Chapa(cbChapa.SelectedItem.Value, cbChapa.SelectedItem.Text)
        Dim marco = New Marco(cbMarco.SelectedItem.Value, cbMarco.SelectedItem.Text)
        Dim madera = New Madera(cbMadera.SelectedItem.Value, cbMadera.SelectedItem.Text)
        Dim hoja = New Hoja(cbHoja.SelectedItem.Value, cbHoja.SelectedItem.Text)
        Dim mano = New Mano(cbMano.SelectedItem.Value, cbMano.SelectedItem.Text)
        Dim cant = txtCant.Text.Trim()
        Dim linea = New linea(cbLinea.SelectedItem.Value, cbLinea.SelectedItem.Text)
        Dim producto = New Producto(hoja, marco, madera, chapa, mano, linea)
        Dim itemMod = New Item(producto, cant)

        gestorPedidos = Session("gestorPedidos")
        itemOrig = gestorPedidos.pedido.getItemById(idItem)
        gestorPedidos.pedido.modificarItem(idItem, itemMod)

        pnlModificarCombos.Visible = True

        gestorPedidos.pedido.modificarItem(idItem, itemMod)
        gestorDatos.mostrarGrillaModificarItems(grModificado, gestorPedidos.pedido)
    End Sub
End Class