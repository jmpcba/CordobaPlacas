<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="reportePedidosProducto.aspx.vb" Inherits="cordobaPlacas.reportePedidosProducto" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlCrystalReport" runat="server">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="imageButtons" ImageUrl="~/images/arrow_left-512.png" ImageWidth="30px" NavigateUrl="~/Default.aspx">HyperLink</asp:HyperLink>
        <br />
        <br />
        <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" HasExportButton="False" ToolPanelView="ParameterPanel" HasToggleGroupTreeButton="False" ReportSourceID="CrystalReportSource1" />
        <br />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="C:\Users\Manuel\Documents\GitHub\cordobaPlacas\cordobaPlacas\reportes\pedidosProductos.rpt">
            </Report>
        </CR:CrystalReportSource>
    </asp:Panel>
</asp:Content>
