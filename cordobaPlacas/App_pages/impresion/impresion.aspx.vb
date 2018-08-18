Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class impresion
    Inherits System.Web.UI.Page

    Dim gd As GestorDatos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gd = New GestorDatos

        Dim dt = New DataTable
        Dim rd = New ReportDocument
        Dim exFormat As ExportFormatType
        exFormat = ExportFormatType.PortableDocFormat

        dt = gd.getReporte(228, GestorDatos.reportes.etiquetaDeposito)
        rd.Load(Server.MapPath("../../reportes/etiquetas.rpt"))
        rd.SetDataSource(dt)
        rd.ExportToHttpResponse(exFormat, Response, False, "deposito.pdf")
    End Sub


End Class