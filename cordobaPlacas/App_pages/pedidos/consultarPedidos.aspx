<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="consultarPedidos.aspx.vb" Inherits="cordobaPlacas.WebForm2" Theme="default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlBusquedas" runat="server" CssClass="modalPopUp" DefaultButton="btnBuscar">
        <table>
            <tr >
                <td colspan="4" ><h2>Buscar Pedidos</h2></td>
            </tr>
            <tr class="combos">
                <td colspan="4">Informacion del pedido</td>
            </tr>
            <tr>
                <td>Numero de Pedido</td>
                <td>
                    <asp:TextBox ID="txtPedido" runat="server" ToolTip="Buscar un numero de pedido"></asp:TextBox><asp:RegularExpressionValidator ID="revNroPedido" runat="server" ErrorMessage="Solo Se Aceptan Valores Numericos" Text="*" ControlToValidate="txtPedido" CssClass="validators" ValidationExpression="\d+" ValidationGroup="vgBuscar"></asp:RegularExpressionValidator>
                </td>
                <td>Cliente</td>
                <td>
                    <asp:DropDownList ID="dpClientes" runat="server" ToolTip="Filtrar por cliente"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Estado</td>
                <td>
                <asp:DropDownList ID="dpFiltroEstados" runat="server" ToolTip="Filtrar por estado"></asp:DropDownList></td>
            </tr>                    
            <tr class="combos">
                <td colspan="4"><hr /></td>
            </tr>
            <tr class="combos">
                <td colspan="4">Fecha De Recepcion del Pedido</td>
            </tr>
            <tr>
                <td style="text-align: center;"><p>Desde</p></td>
                <td>
                    <asp:TextBox ID="txtFecRecDesde" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de recepcion"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender 
                        ID="txtFecRecDesde_MaskedEditExtender" 
                        runat="server" 
                        TargetControlID="txtFecRecDesde"
                        Mask="99/99/9999"
                        Masktype="Date"
                        BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                        Century="2000" 
                        CultureAMPMPlaceholder="" 
                        CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" 
                        CultureDatePlaceholder="" 
                        CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" 
                        CultureTimePlaceholder="" />
                    <ajaxToolkit:CalendarExtender ID="txtFecRecDesde_CalendarExtender" runat="server" TargetControlID="txtFecRecDesde" format="dd/MM/yyyy" BehaviorID="_content_txtFecRecDesde_CalendarExtender"/>
                    <asp:CompareValidator ID="CVFecRecDesde" runat="server" ErrorMessage="Fecha Invalida" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtFecRecDesde" ForeColor="Red" ValidationGroup="vgBuscar" CssClass="validators">*</asp:CompareValidator>
                </td>
                <td>Hasta</td>
                <td>
                    <asp:TextBox ID="txtFecRecHasta" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de recepcion"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtFecRecHasta_MaskedEditExtender"
                        runat="server" 
                        TargetControlID="txtFecRecHasta"
                            Mask="99/99/9999"
                        Masktype="Date"
                        BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                        Century="2000" 
                        CultureAMPMPlaceholder="" 
                        CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" 
                        CultureDatePlaceholder="" 
                        CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" 
                        CultureTimePlaceholder=""/>
                    <ajaxToolkit:CalendarExtender ID="txtFecRecHasta_CalendarExtender" runat="server" TargetControlID="txtFecRecHasta" format="dd/MM/yyyy" BehaviorID="_content_txtFecRecHasta_CalendarExtender"/>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFecRecHasta" ErrorMessage="Fecha Invalida" ForeColor="Red" Operator="DataTypeCheck" Type="Date" ValidationGroup="vgBuscar" CssClass="validators">*</asp:CompareValidator>
                </td>
            </tr>
            <tr class="combos">
                <td colspan="4"><hr /></td>
            </tr>
            <tr class="combos">
                <td colspan="4">Fecha de Ultima Modificacion Del Pedido</td>
            </tr>
            <tr>
                <td style="text-align: center;"><p>Desde</p></td>
                <td>
                    <asp:TextBox ID="txtFecModDesde" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de modificacion"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender 
                        ID="txtFecModDesde_MaskedEditExtender"
                        runat="server" 
                        TargetControlID="txtFecModDesde"
                        Mask="99/99/9999"
                        Masktype="Date"
                        BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                        Century="2000" 
                        CultureAMPMPlaceholder="" 
                        CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" 
                        CultureDatePlaceholder="" 
                        CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" 
                        CultureTimePlaceholder=""/>
                    <ajaxToolkit:CalendarExtender ID="txtFecModDesde_CalendarExtender" runat="server" TargetControlID="txtFecModDesde" format="dd/MM/yyyy" BehaviorID="_content_txtFecModDesde_CalendarExtender"/>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtFecModDesde" ErrorMessage="Fecha Invalida" ForeColor="Red" Type="Date" ValidationGroup="vgBuscar" Operator="DataTypeCheck" CssClass="validators">*</asp:CompareValidator>
                </td>
                <td>Hasta</td>
                <td>
                    <asp:TextBox ID="txtFecModHasta" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de modificacion"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtFecModHasta_MaskedEditExtender" 
                        runat="server" 
                        TargetControlID="txtFecModHasta"
                        Mask="99/99/9999"
                        Masktype="Date"
                        BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                        Century="2000" 
                        CultureAMPMPlaceholder="" 
                        CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" 
                        CultureDatePlaceholder="" 
                        CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" 
                        CultureTimePlaceholder="" />
                    <ajaxToolkit:CalendarExtender ID="txtFecModHasta_CalendarExtender2" runat="server" TargetControlID="txtFecModHasta" format="dd/MM/yyyy" BehaviorID="_content_txtFecModHasta_CalendarExtender2"/>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtFecModHasta" ErrorMessage="Fecha invalida" ForeColor="Red" Type="Date" ValidationGroup="vgBuscar" Operator="DataTypeCheck" CssClass="validators">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="vgBuscar" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                </td>
            </tr>
            <tr class="combos">
                <td colspan="4"><hr /></td>
            </tr>
        </table>
        <asp:Panel ID="pnlValidacionBusqueda" runat="server">
            <asp:ValidationSummary ID="VSBuscar" runat="server" ValidationGroup="vgBuscar" DisplayMode="List" ForeColor="Red" />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="pnlResultadoBusqueda" runat="server">
        <asp:Button ID="btnPnlBusqueda" runat="server" Text="Buscar" />
        <ajaxToolkit:ModalPopupExtender ID="btnPnlBusqueda_ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlBusquedas" TargetControlID="btnPnlBusqueda" CancelControlID="btnVolver">
        </ajaxToolkit:ModalPopupExtender>
        <br />
        <asp:GridView ID="grResultadoBusqueda" runat="server" AutoGenerateColumns="False" ToolTip="Resultados de busqueda" DataKeyNames="Nro Pedido" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" ShowSelectButton="True">
                <ControlStyle Height="20px" Width="20px" />
                </asp:CommandField>
                <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" ReadOnly="True" SortExpression="Nro Pedido" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="Fecha Recibido" HeaderText="Fecha Recibido" DataFormatString="{0:d}" SortExpression="Fecha Recibido" />
                <asp:BoundField DataField="Ultima Modificacion" DataFormatString="{0:d}" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM PEDIDOS_EN_CURSO order by 'FECHA RECIBIDO'"></asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="pnlDetalle" runat="server">
        <hr />
        <asp:GridView ID="grDetalleBusqueda" runat="server" ToolTip="Detalle pedido"></asp:GridView>
        <br />
        <asp:Button ID="btnRegistro" runat="server" Text="Ver Registro" />
        <ajaxToolkit:ModalPopupExtender ID="btnRegistro_ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="btnRegistro_ModalPopupExtender" CancelControlID="btnRegistroVolver" DynamicServicePath="" PopupControlID="pnlRegistro" TargetControlID="btnRegistro">
        </ajaxToolkit:ModalPopupExtender>
    </asp:Panel>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlRegistro" runat="server" CssClass="modalPopUp">
        <h4>Registro</h4>
        <hr />
        <asp:GridView ID="grRegistro" runat="server"></asp:GridView>
        <br />
        <asp:Button ID="btnRegistroVolver" runat="server" Text="Volver" />
    </asp:Panel>
</asp:Content>

