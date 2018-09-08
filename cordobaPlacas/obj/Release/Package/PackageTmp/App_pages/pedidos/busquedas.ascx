<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="busquedas.ascx.vb" Inherits="cordobaPlacas.busquedas" %>
<asp:Panel ID="pnlBusquedas" runat="server">
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
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Filtros" />
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
    <asp:GridView ID="grResultadoBusqueda" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" ToolTip="Resultados de busqueda">
        <Columns>
            <asp:BoundField DataField="Nro Pedido" HeaderText="Nro" />
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Precio" DataFormatString="{0:F2}" HeaderText="Precio" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Fecha Recibido" DataFormatString="{0:d}" HeaderText="Fecha Recibido" />
            <asp:BoundField DataField="Ultima Modificacion" DataFormatString="{0:d}" HeaderText="Fecha Modificado" />
            <asp:BoundField />
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:Panel ID="pnlMsg" runat="server">
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Panel>
 
