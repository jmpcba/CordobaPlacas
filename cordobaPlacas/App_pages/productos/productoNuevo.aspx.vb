Public Class productoNuevo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Wizard1_FinishButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick
        Try
            Dim gp As GestorProductos
            gp = Session("gp")
            gp.setDespiece(grDespiece)
            gp.agregarProducto()
            lblNroProducto.Text = gp.producto.id
            Wizard1.ActiveStepIndex = 2
            msgPanel("Nuevo producto - AGREGADO")
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub errorPanel(ByVal _msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub msgPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Green
    End Sub

    Protected Sub Wizard1_NextButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.NextButtonClick
        Try
            If e.NextStepIndex = 1 Then

                Dim linea = New Linea(lsLinea.SelectedValue)
                Dim chapa = New Chapa(lsChapa.SelectedValue)
                Dim hoja = New Hoja(lsHoja.SelectedValue)
                Dim marco = New Marco(lsMarco.SelectedValue)
                Dim madera = New Madera(lsMaderas.SelectedValue)
                Dim mano = New Mano(lsManos.SelectedValue)
                Dim gp = New GestorProductos(hoja, marco, madera, chapa, mano, linea)
                Dim chapaEx = chapa.getExcluidas
                Dim maderaEx = madera.getExcluidas

                gp.producto.precioUnitario = txtPrecio.Text.Trim
                Session("gp") = gp

                For Each r As GridViewRow In grDespiece.Rows
                    'TODO: SI ESTA EN LA TABLA CHAPAS Y EN LA TABLA CHAPASEX BORRAR
                    'TODO: SI ESTA EN LA TABLA MADERAS Y EN LA TABLA MADERASEX BORRAR
                Next

            ElseIf e.NextStepIndex = 2 Then
                Dim gp = Session("gp")

                For Each r As GridViewRow In grDespiece.Rows
                    Dim txtConsumo As TextBox
                    Dim idPieza = Convert.ToInt32(grDespiece.DataKeys(r.RowIndex).Value.ToString)

                    txtConsumo = r.FindControl("txtConsumo")
                    gp.setDespiece()
                Next
            End If

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub
End Class