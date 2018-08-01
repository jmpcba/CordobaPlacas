<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ModificarPedidos.aspx.vb" Inherits="cordobaPlacas.ModificarPedidos" Theme="default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Modificar Pedidos</h2>
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="2">
        <WizardSteps>
            <asp:WizardStep runat="server" title="Seleccionar">
                <asp:Panel ID="pnlPedidos" runat="server">
                    <p>Seleccione el pedido que va a modificar</p>
                    <asp:GridView ID="grPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="Nro Pedido" DataSourceID="SqlDataSource1" AutoGenerateSelectButton="True">
                        <Columns>
                            <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nro Pedido" />
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Fecha Recibido" DataFormatString="{0:d}" HeaderText="Fecha Recibido" SortExpression="Fecha Recibido" />
                            <asp:BoundField DataField="Ultima Modificacion" DataFormatString="{0:d}" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="sp_PEDIDOS_EN_CURSO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </asp:Panel>
                <asp:Panel ID="pnldetallePedido" runat="server" Visible="false">
                    <hr />
                    <p>Detalle Pedido</p>
                    <asp:GridView ID="grDetalle" runat="server"></asp:GridView>
                </asp:Panel>
            </asp:WizardStep>
            <asp:WizardStep runat="server" title="Opciones">
                <asp:RadioButtonList ID="rbOpciones" runat="server">
                    <asp:ListItem Value="0">Modificar Pedido</asp:ListItem>
                    <asp:ListItem Value="1">Cancelar Pedido</asp:ListItem>
                </asp:RadioButtonList>
            </asp:WizardStep>
            <asp:WizardStep ID="modificarItem" runat="server" Title="Modificar">
                <asp:Panel ID="pnlGrilla" runat="server">
                    <asp:GridView ID="grDetalleModificar" runat="server" AutoGenerateSelectButton="True"></asp:GridView>
                </asp:Panel>
                <asp:Panel ID="pnlModificarCombos" runat="server">
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
                                <asp:TextBox ID="txtCant" runat="server" Width="85px"></asp:TextBox></td>
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
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Cancelar">
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Resumen">
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Complete" Title="Completo">
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>

</asp:Content>
