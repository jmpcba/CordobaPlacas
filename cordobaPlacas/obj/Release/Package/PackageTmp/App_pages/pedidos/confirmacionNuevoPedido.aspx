<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="confirmacionNuevoPedido.aspx.vb" Inherits="cordobaPlacas.confirmacionNuevoPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>Su pedido fue recibido y sera procesado a la brevedad.</p> 
    <p>Utilice la opcion "Mis Pedidos" para ver el progreso del mismo</p>
    <table>
        <tr>
            <td colspan="2"><p>DETALLE:</p></td>
        </tr>
        <tr>
            <td><h3>NUMERO DE PEDIDO:</h3></td>
            <td><asp:Label ID="lblNroPedido" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><h3>CANTIDAD TOTAL:</h3></td>
            <td><asp:Label ID="lblCant" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><h3>PRECIO TOTAL:</h3></td>
            <td><asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
    <br>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/App_pages/nuevoPedido.aspx">Volver</asp:HyperLink>
</asp:Content>
