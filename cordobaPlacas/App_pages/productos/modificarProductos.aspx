<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="modificarProductos.aspx.vb" Inherits="cordobaPlacas.modificarProductos" theme="default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlProductos" runat="server">
             <table class="center">
            <tr>
                <td>Linea</td>
                <td>
                    <asp:DropDownList ID="dpLinea" runat="server" DataSourceID="DSLineas" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSLineas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [lineas]"></asp:SqlDataSource>
                </td>
                <td>Chapa</td>
                <td>
                    <asp:DropDownList ID="dpChapa" runat="server" DataSourceID="DSChapa" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSChapa" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [chapas]"></asp:SqlDataSource>
                </td>
                <td>Hoja</td>
                <td>
                    <asp:DropDownList ID="dpHoja" runat="server" DataSourceID="DSHoja" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSHoja" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [hojas]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>Marco</td>
                <td><asp:DropDownList ID="dpMarco" runat="server" DataSourceID="DSMarco" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSMarco" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [marcos]"></asp:SqlDataSource>
                </td>
                <td>Madera</td>
                <td><asp:DropDownList ID="dpMadera" runat="server" DataSourceID="DSMadera" DataTextField="NOMBRE" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSMadera" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [maderas]"></asp:SqlDataSource>
                </td>
                <td>Mano</td>
                <td><asp:DropDownList ID="dpMano" runat="server" DataSourceID="DSMano" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSMano" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [manos]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="btnLimpiar" runat="server" Text="limpiar Filtros" ToolTip="Limpiar Filtros" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="grProductos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="LINEA" HeaderText="LINEA" SortExpression="LINEA" ReadOnly="True" />
                <asp:BoundField DataField="MADERA" HeaderText="MADERA" ReadOnly="True" SortExpression="MADERA" />
                <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" SortExpression="CHAPA" ReadOnly="True" />
                <asp:BoundField DataField="HOJA" HeaderText="HOJA" SortExpression="HOJA" ReadOnly="True" />
                <asp:BoundField DataField="MARCO" HeaderText="MARCO" SortExpression="MARCO" ReadOnly="True" />
                <asp:BoundField DataField="MANO" HeaderText="MANO" SortExpression="MANO" ReadOnly="True" />
                <asp:TemplateField HeaderText="PRECIO" SortExpression="PRECIO">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("PRECIO", "{0:f2}") %>' ValidationGroup="vgEditProducto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrecio" CssClass="validators" ErrorMessage="Ingrese un valor" ValidationGroup="vgEditProducto">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPrecio" CssClass="validators" ErrorMessage="ingrese un valor numerico - separe decimales con &quot;,&quot;" ValidationExpression="\d+\,?(\d{2}|\d{1})?" ValidationGroup="vgEditProducto">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PRECIO", "{0:C2}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="numCols" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STOCK" SortExpression="STOCK">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind("STOCK") %>' ValidationGroup="vgEditProducto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStock" CssClass="validators" ErrorMessage="Ingrese un valor" ValidationGroup="vgEditProducto">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtStock" CssClass="validators" ErrorMessage="Solo se permiten valores numericos enteros" ValidationExpression="\d+" ValidationGroup="vgEditProducto">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("STOCK") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="numCols" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="update" CssClass="imageButtons" ImageUrl="~/images/save.png" ToolTip="Guardar cambios" ValidationGroup="vgEditProducto" />
                        <ajaxToolkit:ConfirmButtonExtender ID="btnUpdate_ConfirmButtonExtender" runat="server" ConfirmText="Guardar cambios?" TargetControlID="btnUpdate" />
                        <asp:ImageButton ID="btnCancel" runat="server" CommandName="cancel" CssClass="imageButtons" ImageUrl="~/images/cancel.png" ToolTip="Cancelar edicion" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" CommandName="edit" CssClass="imageButtons" ImageUrl="~/images/edit-512.png" ToolTip="Editar Producto" />
                        <asp:ImageButton ID="btnDespiece" runat="server" CommandName="Select" CssClass="imageButtons" ImageUrl="~/images/despiece.png" ToolTip="Ver Despiece" />
                        <asp:ImageButton ID="btnBorrar" runat="server" CommandName="delete" CssClass="imageButtons" ImageUrl="~/images/delete.png" ToolTip="Borrar Producto" />
                        <ajaxToolkit:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="Se borrara el producto" TargetControlID="btnBorrar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="DSPRoductos" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [VW_PRODUCTOS]"></asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="pnlDespiece" runat="server">
        <asp:ImageButton ID="ImageButton5" runat="server" CssClass="imageButtons" ImageUrl="~/images/arrow_left-512.png" ToolTip="volver" Width="30px" />
        <br />
        <asp:GridView ID="grDespiece" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_PIEZA" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="ID_PIEZA" HeaderText="ID PIEZA" ReadOnly="True" />
                <asp:TemplateField HeaderText="NOMBRE">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="cbNombre" runat="server" DataSourceID="DSnombreMat" DataTextField="NOMBRE" DataValueField="id">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DSnombreMat" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [MATERIALES]"></asp:SqlDataSource>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CONSUMO">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtConsumo" runat="server" Text='<%# Bind("CONSUMO") %>' ValidationGroup="vgEdit"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConsumo" CssClass="validators" ErrorMessage="Ingrese un valor" ValidationGroup="vgEdit">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConsumo" CssClass="validators" ErrorMessage="ingrese valores numericos - separe decimales con &quot;,&quot;" ValidationExpression="\d+\,?(\d{2}|\d{1})?" ValidationGroup="vgEdit">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtConsumo" runat="server" ValidationGroup="vgInsert"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConsumo" CssClass="validators" ErrorMessage="Ingrese un valor" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConsumo" CssClass="validators" ErrorMessage="ingrese valores numericos - separe decimales con &quot;,&quot;" ValidationExpression="\d+\,?(\d{2}|\d{1})?" ValidationGroup="vgInsert">*</asp:RegularExpressionValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CONSUMO") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="numCols" />
                </asp:TemplateField>
                <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD" ReadOnly="True" />
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton8" runat="server" CommandArgument='<%# Eval("ID_PIEZA") %>' CommandName="update" CssClass="imageButtons" ImageUrl="~/images/save.png" ValidationGroup="vgEdit" ToolTip="Guardar cambios" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton8_ConfirmButtonExtender" runat="server" ConfirmText="Guardar Cambios?" TargetControlID="ImageButton8" />
                        <asp:ImageButton ID="ImageButton9" runat="server" CommandArgument='<%# Eval("ID_PIEZA") %>' CommandName="cancel" CssClass="imageButtons" ImageUrl="~/images/cancel.png" ToolTip="Cancelar" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ID="ImageButton10" runat="server" CommandName="insert" CssClass="imageButtons" ImageUrl="~/images/add-512.png" ValidationGroup="vgInsert" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton10_ConfirmButtonExtender" runat="server" ConfirmText="Agregar nueva pieza al producto?" TargetControlID="ImageButton10" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton6" runat="server" CommandArgument='<%# Eval("ID_PIEZA") %>' CommandName="edit" CssClass="imageButtons" ImageUrl="~/images/edit-512.png" ToolTip="Editar Consumo"/>
                        <asp:ImageButton ID="ImageButton7" runat="server" CommandArgument='<%# Eval("ID_PIEZA") %>' CommandName="delete" CssClass="imageButtons" ImageUrl="~/images/delete.png" ToolTip="Eliminar material del despiece" />
                        <ajaxToolkit:ConfirmButtonExtender ID="ImageButton7_ConfirmButtonExtender" runat="server" ConfirmText="Desea eliminar esta pieza del producto?" TargetControlID="ImageButton7" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        
    </asp:Panel>
    <asp:Panel ID="pnlValidadores" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validators" DisplayMode="List" ValidationGroup="vgInsert" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validators" DisplayMode="List" ValidationGroup="vgEdit" />
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="validators" DisplayMode="List" ValidationGroup="vgEditProducto" />
    </asp:Panel>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
