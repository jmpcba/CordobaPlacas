<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="buscarCliente.aspx.vb" Inherits="cordobaPlacas.buscarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:Panel ID="pnlBusqueda" runat="server">
        <table cellpadding="5" style="border-collapse: collapse; border-style: solid; border-width: 1px">
            <tr>
                <td colspan="2" style="text-align: left"><h5>Detalle</h5></td>
            <tr>
                <td>CUIT</td>
                <td style="width: 283px; text-align: justify;" class="text-right">
                    <asp:TextBox ID="txtCuit" runat="server" EnableViewState="False" Width="254px"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtCuit_MaskedEditExtender" runat="server" AutoCompleteValue="-" BehaviorID="txtCuit_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" ErrorTooltipCssClass="validators" ErrorTooltipEnabled="True" Mask="99-99999999-9" TargetControlID="txtCuit" />
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td style="width: 283px; text-align: justify;" class="text-right">
                    <asp:TextBox ID="txtNombre" runat="server" Width="254px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Telefono</td>
                <td style="width: 283px; text-align: justify;" class="text-right">
                    <asp:TextBox ID="txtTel" runat="server" Width="254px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mail</td>
                <td style="width: 283px; text-align: justify;" class="text-right">
                    <asp:TextBox ID="txtMail" runat="server" Width="254px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Direccion</td>
                <td style="width: 283px; text-align: justify;" class="text-right">
                    <asp:TextBox ID="txtDir" runat="server" Width="254px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciudad</td>
                <td style="width: 283px; text-align: justify;" class="text-right">
                    <asp:TextBox ID="txtCiudad" runat="server" Width="254px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Provincia</td>
                <td style="width: 283px; text-align: justify;" class="text-right">
                    <asp:TextBox ID="txtProvincia" runat="server" Width="254px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
            </td>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlResultado" runat="server">
                    <h4>Resultados</h4><br />
                    <asp:GridView ID="grResultado" runat="server"></asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
