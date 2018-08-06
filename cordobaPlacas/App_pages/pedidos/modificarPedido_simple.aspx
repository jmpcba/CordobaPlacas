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
            onrowediting="grDetalle_RowEditing"
            onrowcancelingedit="grDetalle_RowCancelingEdit"
            onrowUpdating="grDetalle_RowUpdating"
            onrowdeleting="grDetalle_RowDeleting" DataSourceID="dsItems" DataKeyNames="ITEM"
            >

            <Columns>
                <asp:BoundField DataField="ITEM" HeaderText="ITEM" ReadOnly="true" InsertVisible="False" SortExpression="ITEM"/>
                <asp:BoundField DataField="LINEA" HeaderText="LINEA" ReadOnly="True" SortExpression="LINEA" />
                <asp:TemplateField HeaderText="CANT" SortExpression="CANT">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCant" runat="server" Text='<%# Bind("CANT") %>' Width="50px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CANT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MADERA" SortExpression="MADERA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbMadera" runat="server" DataSourceID="dsMadera" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%# Bind("ID_MADERA") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsMadera" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_MADERA" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("MADERA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HOJA" SortExpression="HOJA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbHoja" runat="server" DataSourceID="dsHoja" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%# Bind("ID_HOJA") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsHoja" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_HOJA" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("HOJA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MARCO" SortExpression="MARCO">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbMarco" runat="server" DataSourceID="dsMarcos" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%# Bind("ID_MARCO") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsMarcos" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_MARCO" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("MARCO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CHAPA" SortExpression="CHAPA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbChapa" runat="server" DataSourceID="dsChapa" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%# Bind("ID_CHAPA") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsChapa" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_CHAPA" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("CHAPA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MANO" SortExpression="MANO">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbMano" runat="server" DataSourceID="dsManos" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%# Bind("ID_MANO") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsManos" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_MANO" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("MANO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" ReadOnly="True" />
                <asp:BoundField DataField="ID_MADERA" HeaderText="ID_MADERA" ReadOnly="True" SortExpression="ID_MADERA" Visible="False" />
                <asp:BoundField DataField="ID_HOJA" HeaderText="ID_HOJA" ReadOnly="True" SortExpression="ID_HOJA" Visible="False" />
                <asp:BoundField DataField="ID_MARCO" HeaderText="ID_MARCO" ReadOnly="True" SortExpression="ID_MARCO" Visible="False" />
                <asp:BoundField DataField="ID_CHAPA" HeaderText="ID_CHAPA" ReadOnly="True" SortExpression="ID_CHAPA" Visible="False" />
                <asp:BoundField DataField="ID_MANO" HeaderText="ID_MANO" ReadOnly="True" SortExpression="ID_MANO" Visible="False" />
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/images/save.png">
                <ControlStyle Height="20px" Width="20px" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="dsItems" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_ITEMS_PEDIDO_MODIFICAR" SelectCommandType="StoredProcedure">
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

