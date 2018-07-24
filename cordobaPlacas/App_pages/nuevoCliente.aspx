<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="nuevoCliente.aspx.vb" Inherits="cordobaPlacas.nuevoCliente"  Theme="default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="258px">    
    <table cellpadding="5" style="border-collapse: collapse; border-style: solid; border-width: 1px">
        <tr>
                <td>CUIT</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtCuit" runat="server" EnableViewState="False"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtCuit_MaskedEditExtender" runat="server" AutoCompleteValue="-" BehaviorID="txtCuit_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" ErrorTooltipCssClass="validators" ErrorTooltipEnabled="True" Mask="99-99999999-9" TargetControlID="txtCuit" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNombre" CssClass="validators" ErrorMessage="Ingrese un valor en CUIT">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCuit" CssClass="validators" ErrorMessage="El CUIT debe empezar con 30, 33 o 34 y estar seguido de 9 numeros" ValidationExpression="3[0|3|4]\d{9}">*</asp:RegularExpressionValidator>
                </td>
            </tr>
        <tr>
                <td>Nombre</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" CssClass="validators" ErrorMessage="Ingrese un valor en nombre">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Telefono</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTel" CssClass="validators" ErrorMessage="Ingrese un valor en Telefono">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Mail</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMail" CssClass="validators" ErrorMessage="Ingrese un valor en Mail">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMail" CssClass="validators" ErrorMessage="Formato de mail invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Direccion</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtDir" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDir" CssClass="validators" ErrorMessage="Ingrese un valor en Dreccion">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Ciudad</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCiudad" CssClass="validators" ErrorMessage="Ingrese un valor en ciudad">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Provincia</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtProvincia" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProvincia" CssClass="validators" ErrorMessage="Ingrese un valor en provincia">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" /></td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validators" DisplayMode="List" Width="234px" />
        <br />
        <asp:Panel ID="pnlMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        </asp:Panel>
</asp:Content>
