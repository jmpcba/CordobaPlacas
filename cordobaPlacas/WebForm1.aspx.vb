Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim rpt As rptCliente

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim da = New pedidosTableAdapters.CLIENTESTableAdapter
        Dim ds = New pedidos
        Dim dt = ds.Tables("clientes")
        da.Fill(dt)

        rpt = New rptCliente()
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
        Session.Add("rpt", rpt)
    End Sub

    Private Sub WebForm1_Init(sender As Object, e As EventArgs) Handles Me.Init
        CrystalReportViewer1.ReportSource = Session("rpt")
    End Sub
End Class