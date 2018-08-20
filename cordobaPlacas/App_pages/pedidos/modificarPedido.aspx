<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="modificarPedido.aspx.vb" Inherits="cordobaPlacas.modificarPedido_simple" Theme="default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlPedidos" runat="server">
        <h4>Seleccione un pedido</h4>
        <asp:GridView ID="grPedidos" 
            runat="server" 
            AutoGenerateColumns="False" 
            ToolTip="Pedidos en Curso" 
            DataKeyNames="Nro Pedido"
            onrowdeleting="grPedidos_RowDeleting">
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" ShowSelectButton="True">
                <ControlStyle Height="20px" Width="20px" />
                </asp:CommandField>
                <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" ReadOnly="True" SortExpression="Nro Pedido" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="Fecha Recibido" HeaderText="Fecha Recibido" SortExpression="Fecha Recibido" />
                <asp:BoundField DataField="Ultima Modificacion" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton6" runat="server" CommandName="delete" ImageUrl="~/images/delete.png" Width="20px" CssClass="imageButtons" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton6_ConfirmButtonExtender" runat="server" ConfirmText="Este pedido y todos sus items seran cancelados&#10;&#10;Los productos que hayan sido fabricados seran movidos al Stock&#10;&#10;Desea continuar?" TargetControlID="ImageButton6" />
                    </ItemTemplate>
                    <ControlStyle Height="20px" Width="20px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT [Nro Pedido], Cliente, Cantidad, Estado, [Fecha Recibido], [Ultima Modificacion] FROM VW_PEDIDOS_MODIFICAR ORDER BY 'FECHA RECIBIDO'"></asp:SqlDataSource>
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlDetalle" runat="server">
        <hr />
        <h4>
            <asp:Label ID="lblDetalle" runat="server" Text="Label"></asp:Label>
        </h4>
        <p>
            <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/arrow_left-512.png" ToolTip="volver" Width="30px" CssClass="imageButtons" />
        </p>
        <asp:GridView ID="grDetalle" runat="server" ToolTip="Detalle pedido" AutoGenerateColumns="False" 
            DataKeyNames="ITEM"
            onrowediting="grDetalle_RowEditing"
            onrowcancelingedit="grDetalle_RowCancelingEdit"
            onrowUpdating="grDetalle_RowUpdating"
            onrowdeleting="grDetalle_RowDeleting">
            <Columns>
                <asp:BoundField DataField="ITEM" HeaderText="ITEM" ReadOnly="true"/>
                <asp:BoundField DataField="LINEA" HeaderText="LINEA" ReadOnly="True" />
                <asp:TemplateField HeaderText="CANT">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCant" runat="server" Text='<%# Bind("CANT") %>' Width="50px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCant" runat="server" Text='<%# Bind("CANT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MADERA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbMadera" runat="server" DataSourceID="dsMaderas" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%# Bind("ID_MADERA") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsMaderas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_MADERA" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("MADERA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HOJA">
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
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("HOJA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MARCO">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbMarco" runat="server" DataSourceID="dsMarco" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%#Bind("ID_MARCO") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsMarco" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_MARCO" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("MARCO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CHAPA">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbChapa" runat="server" DataSourceID="dsChapas" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%#Bind("id_chapa") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsChapas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_CHAPA" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CHAPA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MANO">
                    <EditItemTemplate>
                        <asp:DropDownList ID="cbMano" runat="server" DataSourceID="dsManos" DataTextField="NOMBRE" DataValueField="id" SelectedValue='<%#Bind("id_mano") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsManos" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SP_COMBO_MANO" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="LINEA" SessionField="idLinea" Type="Int16" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("MANO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="update" Height="20px" ImageUrl="~/images/save.png" ToolTip="Guardar Cambios" Width="20px" CssClass="imageButtons" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton2_ConfirmButtonExtender" runat="server" ConfirmText="Desea Guardar los cambios?" TargetControlID="ImageButton2" />
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="cancel" Height="20px" ImageUrl="~/images/cancel.png" ToolTip="Cancelar Edicion" Width="20px" CssClass="imageButtons" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" CommandName="edit" Height="20px" ImageUrl="~/images/edit-512.png" Width="20px" CssClass="imageButtons" />
                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="delete" Height="20px" ImageUrl="~/images/delete.png" ToolTip="Borrar Item" Width="20px" CssClass="imageButtons" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton4_ConfirmButtonExtender" runat="server" ConfirmText="El item seran cancelado&#10;&#10;Los productos que fueron ensamblados seran movidos al stock&#10;&#10;Desea Continuar?" TargetControlID="ImageButton4" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID_LINEA" HeaderText="ID_LINEA" Visible="False" />
                <asp:BoundField DataField="ID_MADERA" HeaderText="ID_MADERA" Visible="False" />
                <asp:BoundField DataField="ID_HOJA" HeaderText="ID_HOJA" Visible="False" />
                <asp:BoundField DataField="ID_MARCO" HeaderText="ID_MARCO" Visible="False" />
                <asp:BoundField DataField="ID_CHAPA" HeaderText="ID_CHAPA" Visible="False" />
                <asp:BoundField DataField="ID_MANO" HeaderText="ID_MANO" Visible="False" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Item" />
        <ajaxToolkit:ModalPopupExtender ID="btnAgregar_ModalPopupExtender" runat="server" BehaviorID="btnAgregar_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnAgregar" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarAgregar" PopupControlID="pnlAgregar">
        </ajaxToolkit:ModalPopupExtender>
    </asp:Panel>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlAgregar" CssClass="modalPopUp" runat="server" ScrollBars="Auto" Style="display:none">
        <h4>Agregar Item</h4>
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
            </tr>
        </table>   
        <br />
        <br />
        <asp:Button ID="btnCancelarAgregar" runat="server" Text="Cancelar" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" ConfirmText="Agregar este Item al pedido?" TargetControlID="btnGuardar" />
    </asp:Panel>
</asp:Content>

