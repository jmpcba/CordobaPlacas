Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class impresion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim R = New ReportDocument()

        If Request.QueryString("reporte") = "remito" Then
            Dim idPedido = Request.QueryString("idPedido")
            Dim db = New DbHelper()
            Dim dt = db.getRemito(idPedido)

            R.Load(Server.MapPath("../../reportes/remitos.rpt"))
            R.SetDataSource(dt)
            visorCR.ReportSource = R
        End If
    End Sub


End Class