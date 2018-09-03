Public Class productoNuevo
    Inherits System.Web.UI.Page
    Dim gd As GestorDatos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gd = New GestorDatos
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

                gp.producto.precioUnitario = txtPrecio.Text.Trim
                Session("gp") = gp

                grDespiece.DataSource = gd.getDespiece(gp.producto)
                grDespiece.DataBind()

                pnlAgregarLinea.Visible = False
                pnlAgregarChapa.Visible = False
                pnlAgregarHoja.Visible = False
                pnlAgregarMarco.Visible = False
                pnlAgregarMadera.Visible = False
                pnlAgregarMano.Visible = False

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

    Protected Sub Wizard1_PreviousButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.PreviousButtonClick
        If e.NextStepIndex = 0 Then
            Session.Remove("gp")
            pnlAgregarLinea.Visible = True
            pnlAgregarChapa.Visible = True
            pnlAgregarHoja.Visible = True
            pnlAgregarMarco.Visible = True
            pnlAgregarMadera.Visible = True
            pnlAgregarMano.Visible = True
        End If
    End Sub

    Protected Sub lsLinea_DataBound(sender As Object, e As EventArgs) Handles lsLinea.DataBound
        lsLinea.Items.RemoveAt(0)
    End Sub

    Protected Sub btnNvaLinea_Click(sender As Object, e As EventArgs) Handles btnNvaLinea.Click
        Try
            Dim linea As Linea
            linea = New Linea()
            linea.nombre = txtNvaLinea.Text.Trim
            linea.insertar()
            msgPanel("Nueva linea - AGREGADA")
            lsLinea.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnNvaChapa_Click(sender As Object, e As EventArgs) Handles btnNvaChapa.Click
        Try
            Dim chapa = New Chapa()
            chapa.nombre = txtNvaChapa.Text.Trim
            chapa.insertar()
            msgPanel("Nueva chapa - AGREGADA")
            lsChapa.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnNvaHoja_Click(sender As Object, e As EventArgs) Handles btnNvaHoja.Click
        Try
            Dim hoja = New Hoja()
            hoja.nombre = txtNvoAnchoHoja.Text.Trim
            hoja.insertar()
            msgPanel("Nuevo ancho de hoja - AGREGADO")
            lsHoja.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnNvoMarco_Click(sender As Object, e As EventArgs) Handles btnNvoMarco.Click
        Try
            Dim marco = New Marco()
            marco.nombre = txtNvoMarco.Text.Trim
            marco.insertar()
            msgPanel("Nuevo ancho de marco - AGREGADO")
            lsMarco.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnNvaMadera_Click(sender As Object, e As EventArgs) Handles btnNvaMadera.Click
        Try
            Dim madera = New Madera()
            madera.nombre = txtMadera.Text.Trim
            madera.insertar()
            msgPanel("Nueva madera - AGREGADA")
            lsMaderas.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnNvaMano_Click(sender As Object, e As EventArgs) Handles btnNvaMano.Click
        Try
            Dim mano = New Mano()
            mano.nombre = txtNvaMano.Text.Trim
            mano.insertar()
            msgPanel("Nueva mano - AGREGADA")
            lsManos.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub Wizard1_CancelButtonClick(sender As Object, e As EventArgs) Handles Wizard1.CancelButtonClick
        Response.Redirect(Request.Url.AbsoluteUri)
        Session.Remove("gp")
    End Sub
End Class