Public Class materiales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gd = New GestorDatos()
    End Sub

    Protected Sub grMateriales_DataBound(sender As Object, e As EventArgs) Handles grMateriales.DataBound
        For Each r As GridViewRow In grMateriales.Rows
            Dim val As RangeValidator
            Dim num As AjaxControlToolkit.NumericUpDownExtender

            Dim min = Convert.ToDouble(r.Cells(3).Text) * -1

            val = r.FindControl("rvTxtAgregar")
            num = r.FindControl("txtAgregar_NumericUpDownExtender")

            val.Type = ValidationDataType.Double
            val.MinimumValue = min
            num.Minimum = min
        Next
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim gd = New GestorDatos
        Dim lineasActualizadas = New List(Of Integer)

        Try
            lineasActualizadas = gd.actualizarMateriales(grMateriales)
            msgPanel("Lista de materiales actualizada")
            grMateriales.DataBind()

            For Each i In lineasActualizadas
                grMateriales.Rows(i).ForeColor = Drawing.Color.Green
            Next

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

    Protected Sub btnGuardarNuevo_Click(sender As Object, e As EventArgs) Handles btnGuardarNuevo.Click
        Try
            Dim mat = New Material
            mat.agregarMaterial(txtNombreMaterial.Text.Trim.ToUpper, dpUnidadMaterial.SelectedValue)
            msgPanel("Nuevo Material - AGREGADO")
            grMateriales.DataBind()
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnGuardarBorrar_Click(sender As Object, e As EventArgs) Handles btnGuardarBorrar.Click
        Dim mat = New Material(dpMateriales.SelectedItem.Value)
        Try
            mat.eliminar()
            grMateriales.DataBind()
            msgPanel("Material - ELIMINADO")
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub
End Class