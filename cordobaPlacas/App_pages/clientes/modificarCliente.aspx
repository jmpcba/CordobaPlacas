<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="modificarCliente.aspx.vb" Inherits="cordobaPlacas.modificarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">  
        <table>
            <tr>
                <td style="vertical-align: top; text-align: left">
                        <h4>Modificar Cliente</h4>  
                        <p>Seleccione el cliente de la lista y haga click en Editar</p>
                        <br />
                        <asp:Panel ID="Panel2" runat="server" DefaultButton="btnEditar">
                            <asp:ListBox ID="lstClientes" runat="server"></asp:ListBox>
                            <ajaxToolkit:ListSearchExtender ID="lstClientes_ListSearchExtender" runat="server" BehaviorID="lstClientes_ListSearchExtender" TargetControlID="lstClientes">
                            </ajaxToolkit:ListSearchExtender>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" />
                        </asp:Panel>
                </td>
                <td style="text-align: left">
                    <asp:Panel ID="pnlDatosCliente" runat="server" DefaultButton="btnGuardar" ScrollBars="Auto">
                        <table cellpadding="5" style="border-collapse: collapse; border-style: solid; border-width: 1px">
                        <tr>
                            <td colspan="2" style="text-align: left"><h5>Detalle</h5></td>
                        <tr>
                            <td>CUIT</td>
                            <td style="width: 441px; text-align: justify;" class="text-right">
                                <asp:TextBox ID="txtCuit" runat="server" EnableViewState="False" Width="254px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="txtCuit_MaskedEditExtender" runat="server" AutoCompleteValue="-" BehaviorID="txtCuit_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" ErrorTooltipCssClass="validators" ErrorTooltipEnabled="True" Mask="99-99999999-9" TargetControlID="txtCuit" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNombre" CssClass="validators" ErrorMessage="Ingrese un valor en CUIT">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCuit" CssClass="validators" ErrorMessage="El CUIT debe empezar con 30, 33 o 34 y estar seguido de 9 numeros" ValidationExpression="3[0|3|4]\d{9}">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
            <tr>
                    <td>Nombre</td>
                    <td style="width: 441px; text-align: justify;" class="text-right">
                        <asp:TextBox ID="txtNombre" runat="server" Width="254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" CssClass="validators" ErrorMessage="Ingrese un valor en nombre">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Telefono</td>
                    <td style="width: 441px; text-align: justify;" class="text-right">
                        <asp:TextBox ID="txtTel" runat="server" Width="254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTel" CssClass="validators" ErrorMessage="Ingrese un valor en Telefono">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Mail</td>
                    <td style="width: 441px; text-align: justify;" class="text-right">
                        <asp:TextBox ID="txtMail" runat="server" Width="254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMail" CssClass="validators" ErrorMessage="Ingrese un valor en Mail">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMail" CssClass="validators" ErrorMessage="Formato de mail invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Direccion</td>
                    <td style="width: 441px; text-align: justify;" class="text-right">
                        <asp:TextBox ID="txtDir" runat="server" Width="254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDir" CssClass="validators" ErrorMessage="Ingrese un valor en Dreccion">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad</td>
                    <td style="width: 441px; text-align: justify;" class="text-right">
                        <asp:TextBox ID="txtCiudad" runat="server" Width="254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCiudad" CssClass="validators" ErrorMessage="Ingrese un valor en ciudad">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Provincia</td>
                    <td style="width: 441px; text-align: justify;" class="text-right">
                        <asp:TextBox ID="txtProvincia" runat="server" Width="254px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProvincia" CssClass="validators" ErrorMessage="Ingrese un valor en provincia">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                        <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" ConfirmText="Desea guardar los cambios?" TargetControlID="btnGuardar" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validators" DisplayMode="List" Width="234px" />
            </asp:Panel>
                </td>
            </tr>
        </table>
            <asp:Panel ID="pnlMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
            </asp:Panel>
        </asp:Panel>
</asp:Content>
