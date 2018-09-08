<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="productoNuevo.aspx.vb" Inherits="cordobaPlacas.productoNuevo" Theme="default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" DisplayCancelButton="True">
        <SideBarStyle BorderStyle="None" HorizontalAlign="Left" VerticalAlign="Top" />
        <StartNavigationTemplate>
            <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Siguiente" ValidationGroup="VGCar"/>
        </StartNavigationTemplate>
        <WizardSteps>
            <asp:WizardStep runat="server" title="Caracteristicas">
                <table>
                    <tr>
                        <td colspan="2" style="height: 24px">LINEA
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="lsLinea" runat="server" DataSourceID="DSLineas" DataTextField="nombre" DataValueField="id" ValidationGroup="VGCar"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lsLinea" CssClass="validators" ErrorMessage="Seleccione un Valor" ValidationGroup="VGCar">*</asp:RequiredFieldValidator>
                            <asp:SqlDataSource ID="DSLineas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [lineas]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarLinea" runat="server" Text="Agregar Linea" />
                            <ajaxToolkit:ModalPopupExtender ID="btnAgregarLinea_ModalPopupExtender" runat="server" BehaviorID="Wizard1_btnAgregarLinea_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnAgregarLinea" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarLinea" PopupControlID="pnlAgregarLinea">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">CHAPA
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="lsChapa" runat="server" DataSourceID="DSChapa" DataTextField="nombre" DataValueField="id" ValidationGroup="VGCar"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lsChapa" CssClass="validators" ErrorMessage="Seleccione un Valor" ValidationGroup="VGCar">*</asp:RequiredFieldValidator>
                            <asp:SqlDataSource ID="DSChapa" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [chapas]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarChapa" runat="server" Text="Agregar Chapa" />
                            <ajaxToolkit:ModalPopupExtender ID="btnAgregarChapa_ModalPopupExtender" runat="server" BehaviorID="Wizard1_btnAgregarChapa_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnAgregarChapa" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarChapa" PopupControlID="pnlAgregarChapa">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">ANCHO HOJA
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="lsHoja" runat="server" DataSourceID="DSHojas" DataTextField="nombre" DataValueField="id" ValidationGroup="VGCar"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lsHoja" CssClass="validators" ErrorMessage="Seleccione un Valor" ValidationGroup="VGCar">*</asp:RequiredFieldValidator>
                            <asp:SqlDataSource ID="DSHojas" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [hojas]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarHojas" runat="server" Text="Agregar Ancho Hoja" />
                            <ajaxToolkit:ModalPopupExtender ID="btnAgregarHojas_ModalPopupExtender" runat="server" BehaviorID="Wizard1_btnAgregarHojas_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnAgregarHojas" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarHoja" PopupControlID="pnlAgregarHoja">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">ANCHO MARCO
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="lsMarco" runat="server" DataSourceID="DSMarco" DataTextField="nombre" DataValueField="id" ValidationGroup="VGCar"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lsMaderas" CssClass="validators" ErrorMessage="Seleccione un Valor" ValidationGroup="VGCar">*</asp:RequiredFieldValidator>
                            <asp:SqlDataSource ID="DSMarco" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [marcos]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarAnchoMarco" runat="server" Text="Agregar Ancho Marco" />
                            <ajaxToolkit:ModalPopupExtender ID="btnAgregarAnchoMarco_ModalPopupExtender" runat="server" BehaviorID="Wizard1_btnAgregarAnchoMarco_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnAgregarAnchoMarco" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarMarco" PopupControlID="pnlAgregarMarco">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">MADERA
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="lsMaderas" runat="server" DataSourceID="DSMadera" DataTextField="NOMBRE" DataValueField="ID" ValidationGroup="VGCar"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="lsMaderas" CssClass="validators" ErrorMessage="Seleccione un Valor" ValidationGroup="VGCar">*</asp:RequiredFieldValidator>
                            <asp:SqlDataSource ID="DSMadera" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [maderas]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarMaderas" runat="server" Text="Agregar Madera" />
                            <ajaxToolkit:ModalPopupExtender ID="btnAgregarMaderas_ModalPopupExtender" runat="server" BehaviorID="Wizard1_btnAgregarMaderas_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnAgregarMaderas" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarMadera" PopupControlID="pnlAgregarMadera">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">MANO
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="lsManos" runat="server" DataSourceID="DSMano" DataTextField="nombre" DataValueField="id" ValidationGroup="VGCar"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="lsManos" CssClass="validators" ErrorMessage="Seleccione un Valor" ValidationGroup="VGCar">*</asp:RequiredFieldValidator>
                            <asp:SqlDataSource ID="DSMano" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString1 %>" SelectCommand="SELECT * FROM [manos]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarMano" runat="server" Text="Agregar Mano" />
                            <ajaxToolkit:ModalPopupExtender ID="btnAgregarMano_ModalPopupExtender" runat="server" BehaviorID="Wizard1_btnAgregarMano_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnAgregarMano" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarMano" PopupControlID="pnlAgregarMano">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            PRECIO
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrecio" CssClass="validators" ErrorMessage="Seleccione un Valor" ValidationGroup="VGCar">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPrecio" CssClass="validators" ErrorMessage="ingrese un valor numerico - separe decimales con &quot;,&quot;" ValidationExpression="\d+\,?(\d{2}|\d{1})?" ValidationGroup="VGCar">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validators" DisplayMode="List" ValidationGroup="VGCar" />
            </asp:WizardStep>
            <asp:WizardStep runat="server" title="Materiales">
                Ingrese los Materiales a Utilizar<br />
                <asp:GridView ID="grDespiece" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID PIEZA" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                        <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD" SortExpression="UNIDAD" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:TextBox ID="txtConsumo" runat="server"></asp:TextBox>
                                <ajaxToolkit:NumericUpDownExtender ID="txtConsumo_NumericUpDownExtender" runat="server" Minimum="0" TargetControlID="txtConsumo" Width="50" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Complete" Title="Confirmacion">
                <asp:Panel ID="Panel1" runat="server">
                    <h4>Producto Guardado</h4>
                    <h4>Nuevo Producto: </h4><asp:Label ID="lblNroProducto" runat="server" Text=""></asp:Label>
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                </asp:Panel>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlAgregarLinea" runat="server" CssClass="modalPopUp">
        <h4>Nueva Linea</h4>
        <br />
        <h5>Nombre</h5><asp:TextBox ID="txtNvaLinea" runat="server"></asp:TextBox>
        <asp:Button ID="btnNvaLinea" runat="server" Text="Agregar Linea" />
        <asp:Button ID="btnCancelarLinea" runat="server" Text="Cancelar" />
    </asp:Panel>
    <asp:Panel ID="pnlAgregarChapa" runat="server" CssClass="modalPopUp">
        <h4>Nueva Chapa</h4>
        <br />
        <h5>Nombre</h5><asp:TextBox ID="txtNvaChapa" runat="server"></asp:TextBox>
        <asp:Button ID="btnNvaChapa" runat="server" Text="Agregar Chapa" />
        <asp:Button ID="btnCancelarChapa" runat="server" Text="Cancelar" />
    </asp:Panel>
    <asp:Panel ID="pnlAgregarHoja" runat="server" CssClass="modalPopUp">
        <h4>Nuevo Ancho de Hoja</h4>
        <br />
        <h5>Nombre</h5><asp:TextBox ID="txtNvoAnchoHoja" runat="server"></asp:TextBox>
        <asp:Button ID="btnNvaHoja" runat="server" Text="Agregar Hoja" />
        <asp:Button ID="btnCancelarHoja" runat="server" Text="Cancelar" />
    </asp:Panel>
    <asp:Panel ID="pnlAgregarMarco" runat="server" CssClass="modalPopUp">
        <h4>Nuevo Ancho de Marco</h4>
        <br />
        <h5>Nombre</h5><asp:TextBox ID="txtNvoMarco" runat="server"></asp:TextBox>
        <asp:Button ID="btnNvoMarco" runat="server" Text="Agregar Marco" />
        <asp:Button ID="btnCancelarMarco" runat="server" Text="Cancelar" />
    </asp:Panel>
    <asp:Panel ID="pnlAgregarMadera" runat="server" CssClass="modalPopUp">
        <h4>Nueva Madera</h4>
        <br />
        <h5>Nombre</h5><asp:TextBox ID="txtMadera" runat="server"></asp:TextBox>
        <asp:Button ID="btnNvaMadera" runat="server" Text="Agregar Madera" />
        <asp:Button ID="btnCancelarMadera" runat="server" Text="Cancelar" />
    </asp:Panel>
    <asp:Panel ID="pnlAgregarMano" runat="server" CssClass="modalPopUp">
        <h4>Nueva Mano</h4>
        <br />
        <h5>Nombre</h5><asp:TextBox ID="txtNvaMano" runat="server"></asp:TextBox>
        <asp:Button ID="btnNvaMano" runat="server" Text="Agregar Mano" />
        <asp:Button ID="btnCancelarMano" runat="server" Text="Cancelar" />
    </asp:Panel>
</asp:Content>
