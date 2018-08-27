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
                        <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("PRECIO") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PRECIO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STOCK" SortExpression="STOCK">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind("STOCK") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("STOCK") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="update" CssClass="imageButtons" ImageUrl="~/images/save.png" ToolTip="Guardar cambios" />
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
        <asp:GridView ID="grDespiece" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID_PIEZA" HeaderText="ID PIEZA" />
                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                <asp:BoundField DataField="CONSUMO" HeaderText="CONSUMO" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
