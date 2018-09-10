<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="pedidoNuevo.aspx.vb" Inherits="cordobaPlacas.pedidoNuevo" Theme="default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Nuevo Pedido</h2>
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" CellPadding="10" DisplayCancelButton="True" ValidateRequestMode="Enabled">
        <NavigationStyle BorderStyle="Solid" BorderWidth="1px" />
        <SideBarStyle BorderStyle="None" HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
        <StepStyle BorderStyle="Solid" BorderWidth="1px" CssClass="wizard" />
        <WizardSteps>
            <asp:WizardStep ID="stepDatosCliente" runat="server" Title="Datos del Cliente">
                <asp:Panel ID="pnlClientes" runat="server">
                        <h4>PASO 1 - Seleccione un cliente</h4>
                        <hr />
                        <asp:DropDownList ID="dpCliente" runat="server" AutoPostBack="True" ValidationGroup="vgCliente"></asp:DropDownList>
                        <ajaxToolkit:ListSearchExtender ID="dpCliente_ListSearchExtender" runat="server" BehaviorID="Wizard1_dpCliente_ListSearchExtender" TargetControlID="dpCliente">
                        </ajaxToolkit:ListSearchExtender>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dpCliente" CssClass="validators" ErrorMessage="Debe elegir un cliente de la lista" Operator="NotEqual" ValidationGroup="vgCliente" ValueToCompare="">*</asp:CompareValidator>
                    </asp:Panel>
                        <hr />
                    <asp:Panel ID="pnlDatosCliente" Visible="False" runat="server">
                        <h4>Detalle</h4>
                        <asp:DetailsView ID="dvDetalleCliente" runat="server" Height="50px" Width="125px"></asp:DetailsView>
                        <hr />
                        <asp:Button ID="btnActualizarCliente" runat="server" Text="Editar Cliente" />
                        <ajaxToolkit:ModalPopupExtender ID="btnActualizarCliente_ModalPopupExtender" runat="server" BehaviorID="btnActualizarCliente_ModalPopupExtender" DynamicServicePath="" PopupControlID="pnlUpdateCliente" TargetControlID="btnActualizarCliente" BackgroundCssClass="modalBackground" CancelControlID="btnUpdateClienteCancelar">
                        </ajaxToolkit:ModalPopupExtender>
                        <hr />
                    </asp:Panel>
                    <asp:Panel ID="pnlUpdateCliente" runat="server" CssClass="modalPopUp">
            <table>
                <tr>
                    <td colspan="2">
                        <h4>Actualizar Cliente</h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        CUIT
                    </td>
                    <td>
                        <asp:TextBox ID="txtCUIT" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un valor para CUIT" ControlToValidate="txtNombre" CssClass="validators" Text="*" ValidationGroup="vgUpdateCliente"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nombre
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese un valor para Nombre" ControlToValidate="txtNombre" CssClass="validators" Text="*" ValidationGroup="vgUpdateCliente"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Telefono
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTel" runat="server" ErrorMessage="Ingrese un valor para Telefono" CssClass="validators" ControlToValidate="txtTelefono" ValidationGroup="vgUpdateCliente">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mail
                    </td>
                    <td>
                        <asp:TextBox ID="txtMail" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvmail" runat="server" ErrorMessage="Ingrese un valor para Mail" Text="*" ControlToValidate="txtMail" CssClass="validators" ValidationGroup="vgUpdateCliente"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Direccion
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvDir" runat="server" ErrorMessage="Ingrese un valor en Direccion" Text="*" ControlToValidate="txtDireccion" CssClass="validators" ValidationGroup="vgUpdateCliente"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ciudad
                    </td>
                    <td>
                        <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvciudad" runat="server" ErrorMessage="Ingrese un valor para Ciudad" CssClass="validators" Text="*" ControlToValidate="txtCiudad" ValidationGroup="vgUpdateCliente"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Provincia
                    </td>
                    <td>
                        <asp:TextBox ID="txtProvincia" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvProv" runat="server" ErrorMessage="Ingrese un valor para Provincia" ControlToValidate="txtProvincia" CssClass="validators" ValidationGroup="vgUpdateCliente">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="vsUpdateCliente" runat="server" CssClass="validators" DisplayMode="List" ValidationGroup="vgUpdateCliente" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdateClienteCancelar" runat="server" Text="Cancelar" />
                        <asp:Button ID="btnGuardarCliente" runat="server" Text="Guardar" ValidationGroup="vgUpdateCliente" />
                        <ajaxToolkit:ConfirmButtonExtender ID="btnGuardarCliente_ConfirmButtonExtender" runat="server" ConfirmText="Guardar datos?" TargetControlID="btnGuardarCliente" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:ValidationSummary ID="vgCliente" runat="server" ValidationGroup="vgCliente" CssClass="validators" DisplayMode="List" />
                </asp:Panel>
            </asp:WizardStep>
            <asp:WizardStep ID="stepPedido" runat="server" Title="Pedido">
                <asp:Panel ID="pnlCombos" runat="server">
                    <h4>PASO 2 - Pedido</h4>
                    <hr />
                    <table>
                        <tr>
                            <td>Linea</td>
                            <td>
                                <asp:DropDownList ID="cbLinea" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </td>
                            <td colspan="5">
                                Seleccione una Linea para empezar
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7"><hr /></td>
                        </tr>
                        <tr>
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
                                <asp:TextBox ID="txtCant" runat="server" Width="85px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rgvCant" runat="server" ErrorMessage="Ingrese un valor numerico" ControlToValidate="txtCant" ValidationExpression="\d*" Display="Static" Text="*" CssClass="validators"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese un valor numerico" Text="*" ControlToValidate="txtCant" CssClass="validators"></asp:RequiredFieldValidator>
                            </td>
                            
                        </tr>
                        <tr>
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
                            <td>
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                            </td>
                        </tr>
                    </table>   
                </asp:Panel>
                <asp:Panel ID="pnlDetalleNvo" runat="server">
                    <hr />
                    <asp:GridView ID="grPedido" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.png" ShowDeleteButton="True">
                            <ControlStyle Width="20px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
                            <asp:BoundField DataField="HOJA" HeaderText="HOJA" />
                            <asp:BoundField DataField="MARCO" HeaderText="MARCO" />
                            <asp:BoundField DataField="MADERA" HeaderText="MADERA" />
                            <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" />
                            <asp:BoundField DataField="MANO" HeaderText="MANO" />
                            <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" >
                            <HeaderStyle CssClass="numCols" HorizontalAlign="Center" />
                            <ItemStyle CssClass="numCols" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MONTO" HeaderText="MONTO" DataFormatString="{0:C2}" >
                            <HeaderStyle CssClass="numCols" HorizontalAlign="Center" />
                            <ItemStyle CssClass="numCols" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Panel ID="pnlValidacion" runat="server" CssClass="validators">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
                </asp:Panel>
            </asp:WizardStep>
            <asp:WizardStep ID="stepResumen" runat="server" Title="Resumen" StepType="Finish">

                <h4> PASO 3 - Resumen</h4>
                <hr />
                <table class="combos">
                    <tr>
                        <td>
                            <b>Cliente</b>
                        </td>
                        <td>
                            <asp:Label ID="lblDetalleNvo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            <b>Cantidad</b>
                        </td>
                        <td>
                            <asp:Label ID="lblCantidadNvo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Monto</b>
                        </td>
                        <td>
                            <asp:Label ID="lblPrecioNvo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <hr />
                <h4>Datos De Cliente</h4>
                <asp:DetailsView ID="dvClienteConfirmar" runat="server" Height="50px" Width="125px"></asp:DetailsView>
                <hr />
                <h4>Detalle Del Pedido</h4>
                <br />
                <asp:CheckBox ID="chkStock" style="align-items:center;" runat="server" Enabled="False" />
                <br />
                <asp:GridView ID="grPepedidoConfirmar" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
                        <asp:BoundField DataField="HOJA" HeaderText="HOJA" />
                        <asp:BoundField DataField="MARCO" HeaderText="MARCO" />
                        <asp:BoundField DataField="MADERA" HeaderText="MADERA" />
                        <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" />
                        <asp:BoundField DataField="MANO" HeaderText="MANO" />
                        <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" >
                        <HeaderStyle CssClass="numCols" />
                        <ItemStyle CssClass="numCols" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MONTO" DataFormatString="{0:C2}" HeaderText="MONTO" >
                        <HeaderStyle CssClass="numCols" />
                        <ItemStyle CssClass="numCols" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STOCK" HeaderText="STOCK" ItemStyle-HorizontalAlign="Right" >
                        <HeaderStyle CssClass="numCols" />
<ItemStyle HorizontalAlign="Right" CssClass="numCols"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Complete" Title="Confirmacion">
                <h4>El pedido fue enviado, informe el numero de pedido al cliente <br /><br />NUMERO DE PEDIDO: <asp:Label ID="lblConfirmacion" runat="server" Text="Label"></asp:Label></h4>
                <asp:Button ID="btnIniciar" runat="server" Text="Volver al Inicio" />
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
