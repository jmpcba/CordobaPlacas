Public Class impresionOrdenes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rpt = New ordenes
        rpt.SetParameterValue("@ID_ITEM", 5)
        rpt.Load(Server.MapPath("ordenes.rpt"))
        CrystalReportViewer1.ReportSource = rpt
    End Sub

End Class