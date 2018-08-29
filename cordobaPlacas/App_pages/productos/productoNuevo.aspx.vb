Public Class productoNuevo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Wizard1_FinishButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick
        Try
            If e.NextStepIndex = 1 Then

                Dim linea = New Linea(lsLinea.SelectedValue)
                Dim chapa = New Chapa(lsChapa.SelectedValue)
                Dim hoja = New Hoja(lsHoja.SelectedValue)
                Dim marco = New Marco(lsMarco.SelectedValue)
                Dim madera = New Madera(lsMaderas.SelectedValue)
                Dim mano = New Mano(lsManos.SelectedValue)
                Dim gp = New GestorProductos(hoja, marco, madera, chapa, mano, linea)
                gp.producto.precioUnitario = txtPrecio.Text.Trim
                Session("gp") = gp

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
End Class