﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="modificarProductos.aspx.vb" Inherits="cordobaPlacas.modificarProductos" theme="default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlProductos" runat="server">
             <table class="center">
            <tr>
                <td>Linea</td>
                <td>
                    <asp:DropDownList ID="dpLinea" runat="server" DataSourceID="DSLineas" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSLineas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [lineas]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [lineas] WHERE [id] = @original_id " InsertCommand="INSERT INTO [lineas] ([nombre]) VALUES (@nombre)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [lineas] SET [nombre] = @nombre WHERE [id] = @original_id">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="grlineas" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="nombre" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="grlineas" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                            <asp:ControlParameter ControlID="grlineas" Name="original_nombre" PropertyName="SelectedValue" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>Chapa</td>
                <td>
                    <asp:DropDownList ID="dpChapa" runat="server" DataSourceID="DSChapa" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSChapa" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [chapas]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [chapas] WHERE [id] = @original_id" InsertCommand="INSERT INTO [chapas] ([nombre], [COD_MAT]) VALUES (@nombre, @COD_MAT)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [chapas] SET [nombre] = @nombre WHERE [id] = @original_id">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="grChapas" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="nombre" Type="String" />
                            <asp:Parameter Name="COD_MAT" Type="Int32" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="grChapas" Name="nombre" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grChapas" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>Hoja</td>
                <td>
                    <asp:DropDownList ID="dpHoja" runat="server" DataSourceID="DSHoja" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSHoja" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [hojas]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [hojas] WHERE [id] = @original_id" InsertCommand="INSERT INTO [hojas] ([nombre]) VALUES (@nombre)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [hojas] SET [nombre] = @nombre WHERE [id] = @original_id">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="grHoja" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="nombre" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="grHoja" Name="nombre" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grHoja" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>Marco</td>
                <td><asp:DropDownList ID="dpMarco" runat="server" DataSourceID="DSMarco" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSMarco" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [marcos]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [marcos] WHERE [id] = @original_id AND [nombre] = @original_nombre" InsertCommand="INSERT INTO [marcos] ([nombre]) VALUES (@nombre)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [marcos] SET [nombre] = @nombre WHERE [id] = @original_id">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="grMarcos" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="nombre" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="dpMarco" Name="nombre" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grMarcos" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>Madera</td>
                <td><asp:DropDownList ID="dpMadera" runat="server" DataSourceID="DSMadera" DataTextField="NOMBRE" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSMadera" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [maderas]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [maderas] WHERE [ID] = @original_ID" InsertCommand="INSERT INTO [maderas] ([NOMBRE], [COD_MAT]) VALUES (@NOMBRE, @COD_MAT)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [maderas] SET [NOMBRE] = @NOMBRE WHERE [ID] = @original_ID">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="grMaderas" Name="original_ID" PropertyName="SelectedDataKey" Type="Int16" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="NOMBRE" Type="String" />
                            <asp:Parameter Name="COD_MAT" Type="Int16" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="grMaderas" Name="NOMBRE" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grMaderas" Name="COD_MAT" PropertyName="SelectedDataKey" Type="Int16" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>Mano</td>
                <td><asp:DropDownList ID="dpMano" runat="server" DataSourceID="DSMano" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSMano" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [manos]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [manos] WHERE [id] = @original_id AND [nombre] = @original_nombre" InsertCommand="INSERT INTO [manos] ([nombre]) VALUES (@nombre)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [manos] SET [nombre] = @nombre WHERE [id] = @original_id">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="grManos" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="nombre" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="grManos" Name="nombre" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grManos" Name="original_id" PropertyName="SelectedDataKey" Type="Int16" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="btnLimpiar" runat="server" Text="limpiar Filtros" ToolTip="Limpiar Filtros" />
                </td>
            </tr>
        </table>
        <hr />
             <asp:ImageButton ID="imgBtnConfig" runat="server" style="float:right; " CssClass="imageButtons" ImageUrl="~/images/config.png" ToolTip="Modificar caracteristicas" />
             <ajaxToolkit:ModalPopupExtender ID="imgBtnConfig_ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnVolverCarac" PopupControlID="pnlCaracteristicas" TargetControlID="imgBtnConfig">
             </ajaxToolkit:ModalPopupExtender>
        <br />
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
    <asp:Panel ID="pnlCaracteristicas" runat="server" CssClass="modalPopUp" HorizontalAlign="Center" ScrollBars="Vertical">
        <table class="tablaCaracteristicas">
            <tr>
                <th style="height: 26px">LINEAS</th>
                <th style="height: 26px">MADERAS</th>
                <th style="height: 26px">CHAPAS</th>
                <th style="height: 26px">ANCHOS HOJA</th>
                <th style="height: 26px">ANCHOS MARCO</th>
                <th style="height: 26px">MANO</th>
                <th>
                    <asp:ImageButton ID="btnVolverCarac" runat="server" ImageUrl="~/images/arrow_left-512.png" CssClass="imageButtons" ToolTip="Cerrar" /></th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grlineas" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DSLineas">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="nombre" SortExpression="nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/images/save.png" ValidationGroup="vgCaracteristicas">
                            <ControlStyle CssClass="imageButtons" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="grMaderas" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DSMadera">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="nombre" SortExpression="nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/images/save.png" ValidationGroup="vgCaracteristicas">
                            <ControlStyle CssClass="imageButtons" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="grChapas" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DSChapa">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="nombre" SortExpression="nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/images/save.png" ValidationGroup="vgCaracteristicas">
                            <ControlStyle CssClass="imageButtons" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="grHoja" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DSHoja">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="nombre" SortExpression="nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/images/save.png" ValidationGroup="vgCaracteristicas">
                            <ControlStyle CssClass="imageButtons" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="grMarcos" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DSMarco">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="nombre" SortExpression="nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/images/save.png" ValidationGroup="vgCaracteristicas">
                            <ControlStyle CssClass="imageButtons" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="grManos" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DSMano">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="nombre" SortExpression="nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit-512.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/images/save.png" ValidationGroup="vgCaracteristicas">
                            <ControlStyle CssClass="imageButtons" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
