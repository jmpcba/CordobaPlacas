<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ImprimirOrdenDeTrabajo.aspx.vb" Inherits="cordobaPlacas.ImprimirOrdenDeTrabajo" Theme="default"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Panel ID="pnlBusquedas" runat="server" Visible="false">
            <table style="width: 100%;" align="center">
                <tr>
                    <td colspan="6" align="right"><h4>BIENVENIDO
                        <asp:LoginName ID="LoginName1" runat="server" /></h4>
                    </td>
                </tr>
                <tr >
                    <td colspan="6" align="center"><h1>ACTUALIZAR PEDIDO</h1></td>
                </tr>
                <tr class="combos">
                    <td>Numero de Pedido</td>
                    <td>
                        <asp:TextBox ID="txtPedido" runat="server"></asp:TextBox>
                    </td>
                    <td>Cliente</td>
                    <td>
                        <asp:DropDownList ID="cbCliente" runat="server"></asp:DropDownList>
                    </td>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="dpFiltroEstados" runat="server"></asp:DropDownList></td>
                </tr>
                <tr class="combos">
                    <td style="text-align: center;"><p>Fecha Desde</p></td>
                    <td>
                        <asp:TextBox ID="txtFecDesde" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecDesde_CalendarExtender" runat="server" TargetControlID="txtFecDesde" format="dd/MM/yyyy"/>
                    
                    </td>
                    <td>Fecha Hasta</td>
                    <td>
                        <asp:TextBox ID="txtFecHasta" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecHasta_CalendarExtender" runat="server" TargetControlID="txtFecHasta" format="dd/MM/yyyy"/>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Filtros" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="pnlPedidos" runat="server" Visible="True">
            <asp:GridView ID="grPedidos" runat="server" AutoGenerateSelectButton="True"></asp:GridView>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="pnlDetalle" runat="server" Visible="false">
            <table style="width: 100%;" align="center">
                <tr>
                    <td colspan="8" align="center" style="height: 41px">
                        <h4>DETALLE</h4>
                    </td>
                </tr>
                <tr style="border-bottom: 1px solid #ddd;">
                    <td colspan="8">
                        <asp:GridView ID="grPedidoDetalle" runat="server"></asp:GridView> 
                        <br />
                        <asp:GridView ID="grDetalle" runat="server" AutoGenerateSelectButton="True"></asp:GridView> 
                        <asp:Button ID="btnAtras" runat="server" Text="Atras" />
                    </td>
                </tr>
                </table>
            </asp:Panel> 
        </div>
        <asp:Panel ID="pnlCombos" runat="server" Visible="False">   
            <table style="width: 100%;" align="center>
            <tr>
                <td colspan="3">
                    <caption>
                        <h6>
                            <asp:Label ID="lblModificar" runat="server" Text=""></asp:Label>
                        </h6>
                        </td>
                        </tr>
                        <tr class="combos">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Nuevo Estado"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dpEstados" runat="server">
                                </asp:DropDownList>
                                <br>
                                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Estado" />
                            </td>
                            <td>
                                <h5>En Stock</h5>
                                <asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Utilizar stock para este item" />
                            </td>
                        </tr>
                        <tr style="border-bottom: 1px solid #ddd;">
                            <td align="right" colspan="3">&nbsp;</td>
                        </tr>
                    </caption>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Visible="False" CssClass="error">
        <h5>OCURRIO UN ERROR:</h5><br>
        <h6><asp:Label ID="lblError" runat="server" Text="Label"></asp:Label></h6>
    </asp:Panel>
</asp:Content>
