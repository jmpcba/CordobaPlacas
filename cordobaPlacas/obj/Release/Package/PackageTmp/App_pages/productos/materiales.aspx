<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="materiales.aspx.vb" Inherits="cordobaPlacas.materiales" Theme="default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlMateriales" runat="server">
        <table>
            <tr>
                <td>
                    <h4>Modificar Stock de Materiales </h4><asp:ImageButton ID="ImageButton1" runat="server" CssClass="imageButtons" ImageUrl="~/images/refresh.jpg" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grMateriales" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DSMateriales">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD" SortExpression="UNIDAD" />
                <asp:BoundField DataField="STOCK_DISPONIBLE" HeaderText="STOCK DISPONIBLE" SortExpression="STOCK_DISPONIBLE">
                <ItemStyle CssClass="numCols" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="AGREGAR">
                    <ItemTemplate>
                        <asp:TextBox ID="txtAgregar" runat="server" CssClass="gridTxt" Font-Size="Small">0</asp:TextBox>
                        <ajaxToolkit:NumericUpDownExtender ID="txtAgregar_NumericUpDownExtender" runat="server" TargetControlID="txtAgregar" Width="75" />
                        <asp:RangeValidator ID="rvTxtAgregar" runat="server" ControlToValidate="txtAgregar" CssClass="validators" ErrorMessage="No se puede restar mas que el stock existente" MaximumValue="1000000" Type="Double">*</asp:RangeValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAgregar" CssClass="validators" ErrorMessage="Ingrese un valor numerico" ValidationExpression="-?\d+(\.\d+)?">*</asp:RegularExpressionValidator>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="DSMateriales" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [MATERIALES]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Stock" ToolTip="Actualizar materiales" />
        <ajaxToolkit:ConfirmButtonExtender ID="btnActualizar_ConfirmButtonExtender" runat="server" ConfirmText="Actualizar lista de materiales?" TargetControlID="btnActualizar" />
        <asp:Button ID="btnAgregarMaterial" runat="server" Text="Nuevo Material" />
        <ajaxToolkit:ModalPopupExtender ID="btnAgregarMaterial_ModalPopupExtender" runat="server" TargetControlID="btnAgregarMaterial" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarNvo" PopupControlID="pnlNvoMaterial">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button ID="btnBorrarMaterial" runat="server" Text="Eliminar Material" />
        <ajaxToolkit:ModalPopupExtender ID="btnBorrarMaterial_ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="btnBorrarMaterial_ModalPopupExtender" DynamicServicePath="" PopupControlID="pnlBorrar" RepositionMode="RepositionOnWindowResizeAndScroll" TargetControlID="btnBorrarMaterial" CancelControlID="btnCancelarBorrar">
        </ajaxToolkit:ModalPopupExtender>
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validators" DisplayMode="List" />
    </asp:Panel>
    <asp:Panel ID="pnlNvoMaterial" runat="server" CssClass="modalPopUp">
        <table>
            <tr>
                <td colspan ="2"><h4>Agregar nuevo tipo de material</h4></td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombreMaterial" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Unidad</td>
                <td>
                    <asp:DropDownList ID="dpUnidadMaterial" runat="server" DataSourceID="DSDPMateriales" DataTextField="UNIDAD" DataValueField="UNIDAD"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSDPMateriales" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT DISTINCT [UNIDAD] FROM [MATERIALES]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnGuardarNuevo" runat="server" Text="Guardar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="btnGuardarNuevo_ConfirmButtonExtender" runat="server" ConfirmText="Se agregara este material a la lista" TargetControlID="btnGuardarNuevo" />
                    <asp:Button ID="btnCancelarNvo" runat="server" Text="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlBorrar" runat="server" CssClass="modalPopUp">
        <h4>Eliminar Material</h4>
        <table>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="dpMateriales" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOMBRE" DataValueField="id"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT [id], [NOMBRE] FROM [MATERIALES]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGuardarBorrar" runat="server" Text="Eliminar" />
                </td>
                <td>
                    <asp:Button ID="btnCancelarBorrar" runat="server" Text="Cancelar    " />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
     </asp:Panel>
</asp:Content>
