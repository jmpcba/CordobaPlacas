Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim db As DbHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        db = New DbHelper
        Dim DT As DataTable
        Dim r = New ReportDocument()

        DT = db.getProductos()
        r.Load(Server.MapPath("reportes/productos.rpt"))
        r.SetDataSource(DT)
        visorCR.ReportSource = r

    End Sub
End Class