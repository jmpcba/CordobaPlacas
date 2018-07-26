<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ModificarPedido.aspx.vb" Inherits="cordobaPlacas.ModificarPedido" Theme="default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <div>
        <table style="width: 100%;" align="center" class="tablas">
            <tr>
                <td colspan="4" align="right"><h4>BIENVENIDO
                    <asp:LoginName ID="LoginName1" runat="server" /></h4>
                </td>
            </tr>
            <tr >
                <td colspan="4" align="center"><h1>MODIFICAR PEDIDO</h1></td>
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
            </tr>
            <tr class="combos">
                <td style="text-align: center;"><p>Fecha Desde</p></td>
                <td>
                    <asp:TextBox ID="txtFecDesde" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="clExtFecDesde" runat="server" TargetControlID="txtFecDesde" Format="dd/MM/yyyy" />
                </td>
                <td>Fecha Hasta</td>
                <td>
                    <asp:TextBox ID="txtFecHasta" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="clExtFecHasta" runat="server" TargetControlID="txtFecHasta" format="dd/MM/yyyy"/>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Filtros" CausesValidation="False" />
                </td>
            </tr>
        </table> 
    </div>
    <div>
        <table>
            <tr style="border-bottom: 1px solid #ddd;">
                <td colspan="4">
                    <asp:GridView ID="grPedidos" runat="server" AutoGenerateSelectButton="True" AllowPaging="True" AllowSorting="True"></asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <h4><asp:Label ID="lblDetalle" runat="server" Text=""></asp:Label></h4>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="grDetalle" runat="server" AutoGenerateSelectButton="True" AllowPaging="True" AllowSorting="True"></asp:GridView> 
                </td>
            </tr>
        </table> 
    </div>
    <asp:Panel ID="pnlCombos" runat="server" Visible="False">   
        <table style="width: 100%;" align="center" class="tablas">
            <tr class="combos">
                <td>Linea</td>
                <td>
                    <asp:DropDownList ID="cbLinea" AutoPostBack="true" runat="server"></asp:DropDownList>

                </td>
                <td>Chapa</td>
                <td>
                    <asp:DropDownList ID="cbChapa" runat="server"></asp:DropDownList>
                </td>
                <td>Ancho Marco</td>
                <td>
                    <asp:DropDownList ID="cbMarco" runat="server"></asp:DropDownList>
                </td>
                <td>Cantidad</td>
                <td>
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="combos" style="border-bottom: 1px solid #ddd;">
                <td>Madera</td>
                <td>
                    <asp:DropDownList ID="cbMadera" runat="server"></asp:DropDownList>
                </td>
                <td>Ancho Hoja</td>
                <td
                    ><asp:DropDownList ID="cbHoja" runat="server"></asp:DropDownList>
                </td>
                <td>Mano</td>
                <td>
                    <asp:DropDownList ID="cbMano" runat="server"></asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Guardar Cambios" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td colspan="8" class="error">
                    <asp:RequiredFieldValidator ID="rfvLinea" runat="server" ControlToValidate="cbLinea" ErrorMessage="Seleccione un valor en Linea"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="rfvChapa" runat="server" ControlToValidate="cbChapa" ErrorMessage="Seleccione un valor en Chapa"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="rfvMarco" runat="server" ControlToValidate="cbMarco" ErrorMessage="Seleccione un valor en Marco"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="rfvMadera" runat="server" ControlToValidate="cbMadera" ErrorMessage="Seleccione un valor en Madera"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="rfvHoja" runat="server" ControlToValidate="cbHoja" ErrorMessage="Seleccione un valor en Hoja"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="rfvMano" runat="server" ControlToValidate="cbHoja" ErrorMessage="Seleccione un valor en Mano"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Ingrese un valor en Cantidad"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="rgxCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Cantidad debe ser un valor numerico" ValidationExpression="\d*"></asp:RegularExpressionValidator><br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Visible="False" CssClass="error">
        <h5>OCURRIO UN ERROR:</h5><br>
        <h6><asp:Label ID="lblError" runat="server" Text="Label"></asp:Label></h6>
    </asp:Panel>
</asp:Content>