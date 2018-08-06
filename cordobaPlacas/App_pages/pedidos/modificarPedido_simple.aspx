<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="modificarPedido_simple.aspx.vb" Inherits="cordobaPlacas.modificarPedido_simple" Theme="default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlPedidos" runat="server">
        <h4>Seleccione un pedido</h4>
        <asp:GridView ID="grPedidos" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" ToolTip="Resultados de busqueda" DataKeyNames="Nro Pedido" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" ReadOnly="True" SortExpression="Nro Pedido" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="Fecha Recibido" HeaderText="Fecha Recibido" SortExpression="Fecha Recibido" />
                <asp:BoundField DataField="Ultima Modificacion" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT [Nro Pedido], Cliente, Cantidad, Estado, [Fecha Recibido], [Ultima Modificacion] FROM PEDIDOS_EN_CURSO WHERE ('ESTADO' &lt;&gt; 'ENTREGADO') ORDER BY 'FECHA RECIBIDO'"></asp:SqlDataSource>
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlDetalle" runat="server">
        <hr />
        <h4>Detalle</h4>
        <asp:GridView ID="grDetalle" runat="server" ToolTip="Detalle pedido" AutoGenerateColumns="False" 
            DataKeyNames="ITEM"
            onrowediting="grDetalle_RowEditing"
            onrowcancelingedit="grDetalle_RowCancelingEdit"
            onrowUpdating="grDetalle_RowUpdating"
            onrowdeleting="grDetalle_RowDeleting" DataSourceID="dsItems"
            >

            <Columns>
                <asp:BoundField DataField="ITEM" HeaderText="ITEM" ReadOnly="true" InsertVisible="False" SortExpression="ITEM"/>
                <asp:TemplateField HeaderText="CANT" SortExpression="CANT">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCant" runat="server" Text='<%# Bind("CANT", "{0}") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CANT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LINEA" SortExpression="LINEA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="dsLinea" runat="server">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsLineas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [lineas]"></asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LINEA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MADERA" HeaderText="MADERA" SortExpression="MADERA" />
                <asp:BoundField DataField="HOJA" HeaderText="HOJA" SortExpression="HOJA" />
                <asp:BoundField DataField="MARCO" HeaderText="MARCO" SortExpression="MARCO" />
                <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" SortExpression="CHAPA" />
                <asp:BoundField DataField="MANO" HeaderText="MANO" SortExpression="MANO" />
                <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" />
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowEditButton="True" UpdateImageUrl="~/images/save.png">
                <ControlStyle Height="20px" Width="20px" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="dsItems" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_ITEMS_PEDIDO" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="idPedido" SessionField="idPedido" Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Pedido" />
    </asp:Panel>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlCombos" CssClass="modalPopUp" runat="server" ScrollBars="Auto">
        panel combos
        <br />
        <asp:Button ID="btnCancelarCombos" runat="server" Text="Cancelar" />
    </asp:Panel>
</asp:Content>

