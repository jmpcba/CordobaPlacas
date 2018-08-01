Public Class ModificarPedidos
    Inherits System.Web.UI.Page

    Dim gestorDatos As GestorDatos
    Dim gestorPedidos As GestorPedidos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gestorDatos = New GestorDatos
        pnldetallePedido.Visible = False
        pnlModificarCombos.Visible = False


    End Sub

    Protected Sub grPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grPedidos.SelectedIndexChanged
        Dim row = grPedidos.SelectedRow
        Dim idPedido = row.Cells(1).Text

        pnldetallePedido.Visible = True
        rbOpciones.Items(0).Enabled = True
        rbOpciones.Items(1).Enabled = True

        gestorPedidos = New GestorPedidos(idPedido)
        Session("gestorPedidos") = gestorPedidos

        grDetalle.DataSource = gestorDatos.getItems(idPedido)
        grDetalle.DataBind()
        grDetalle.SelectedIndex = -1
    End Sub

    Protected Sub Wizard1_FinishButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick

    End Sub

    Private Sub Wizard1_NextButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.NextButtonClick
        gestorPedidos = Session("gestorPedidos")

        If e.CurrentStepIndex = 0 Then
            If gestorPedidos.pedido.estado.id > Estado.estados.enCola Then
                rbOpciones.Items(0).Enabled = False
            End If
        ElseIf e.CurrentStepIndex = 1 Then
            If rbOpciones.SelectedValue = 0 Then
                Wizard1.ActiveStepIndex = 2
                grDetalleModificar.DataSource = gestorDatos.getItems(gestorPedidos.pedido.id)
                grDetalleModificar.DataBind()
            Else
                Wizard1.ActiveStepIndex = 3
            End If


        End If
    End Sub

    Protected Sub grDetalleModificar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grDetalleModificar.SelectedIndexChanged
        Dim row = grDetalleModificar.SelectedRow
        Dim idItem = row.Cells(1).Text
        Dim item As Item
        gestorPedidos = Session("gestorPedidos")
        item = gestorPedidos.pedido.getItemById(idItem)

        pnlModificarCombos.Visible = True

        gestorDatos.getComboLineas(cbLinea)
        cbLinea.SelectedValue = item.producto.linea.id

        gestorDatos.fillCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)

        cbChapa.SelectedValue = item.producto.chapa.id
        cbHoja.SelectedValue = item.producto.hoja.id
        cbMadera.SelectedValue = item.producto.madera.id
        cbMano.SelectedValue = item.producto.mano.id
        cbMarco.SelectedValue = item.producto.marco.id
        txtCant.Text = item.cant

    End Sub

    Protected Sub cbLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLinea.SelectedIndexChanged
        pnlModificarCombos.Visible = True
        gestorDatos.fillCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)
    End Sub
End Class