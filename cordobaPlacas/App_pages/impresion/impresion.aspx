<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="impresion.aspx.vb" Inherits="cordobaPlacas.impresion" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <CR:CrystalReportViewer ID="visorCR" runat="server" AutoDataBind="true" EnableParameterPrompt="False" />

</asp:Content>
