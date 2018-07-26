<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="consultarPedidos.aspx.vb" Inherits="cordobaPlacas.WebForm2" Theme="default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="width: 100%;" class="tablas">
            <tr>
                <td colspan="4" align="right"><h4>BIENVENIDO
                    <asp:LoginName ID="LoginName1" runat="server" /></h4>
                </td>
            </tr>
            <tr >
                <td colspan="4" align="center"><h1>MIS PEDIDOS</h1></td>
            </tr>
            <tr class="combos">
                <td>Numero de Pedido</td>
                <td>
                    <asp:TextBox ID="txtPedido" runat="server"></asp:TextBox>
                </td>
                <td>Estado</td>
                <td>
                    <asp:DropDownList ID="dpFiltroEstados" runat="server"></asp:DropDownList></td>
            </tr>
            <tr class="combos">
                    <td style="text-align: center;"><p>Fecha Desde</p></td>
                    <td>
                        <asp:TextBox ID="txtFecDesde" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecDesde_CalendarExtender" runat="server" TargetControlID="txtFecDesde" format="dd/MM/yyyy" />
                    
                    </td>
                    <td>Fecha Hasta</td>
                    <td>
                        <asp:TextBox ID="txtFecHasta" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecHasta_CalendarExtender" runat="server" TargetControlID="txtFecHasta" format="dd/MM/yyyy"/>
                    
                    </td>
                </tr>
                <tr>
                <td colspan="4">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Filtros" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="grPedidos" runat="server" AutoGenerateSelectButton="True"></asp:GridView>
    </div>
    <div>
        <asp:Label ID="lblDetalle" runat="server" Text=""></asp:Label>
        <asp:GridView ID="grDetalle" runat="server"></asp:GridView>
    </div>
    <asp:Panel ID="pnlError" runat="server" Visible="False" CssClass="error">
        <h5>OCURRIO UN ERROR:</h5><br>
        <h6><asp:Label ID="lblError" runat="server" Text="Label"></asp:Label></h6>
    </asp:Panel>  
</asp:Content>
