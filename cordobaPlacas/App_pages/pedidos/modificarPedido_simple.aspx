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
            onrowdeleting="grDetalle_RowDeleting"
            >

            <Columns>
                <asp:BoundField DataField="ITEM" HeaderText="ITEM" ReadOnly="true"/>
                <asp:TemplateField HeaderText="CANT">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCant" runat="server" Text='<%# Bind("CANT") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCant" runat="server" Text='<%# Bind("CANT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LINEA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbLineas" runat="server" DataSourceID="Lineas" DataTextField="nombre" DataValueField="id" SelectedValue='<%# bind("LINEA") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Lineas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [lineas]"></asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LINEA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MADERA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbMadera" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("MADERA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="HOJA" HeaderText="HOJA" ReadOnly="true" />
                <asp:BoundField DataField="MARCO" HeaderText="MARCO" ReadOnly="true"/>
                <asp:BoundField DataField="MANO" HeaderText="CHAPA" ReadOnly="true"/>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="update" Height="20px" ImageUrl="~/images/save.png" Width="20px" ToolTip="Guardar Cambios" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton2_ConfirmButtonExtender" runat="server" ConfirmText="Desea Guardar los cambios?" TargetControlID="ImageButton2" />
                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="delete" Height="20px" ImageUrl="~/images/delete.png" ToolTip="Borrar Item" Width="20px" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton4_ConfirmButtonExtender" runat="server" ConfirmText="Borrar este item?" TargetControlID="ImageButton4" />
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="cancel" Height="20px" ImageUrl="~/images/cancel.png" Width="20px" ToolTip="Cancelar Edicion" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" CommandName="edit" Height="20px" ImageUrl="~/images/edit-512.png" Width="20px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
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

