<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="productoNuevo.aspx.vb" Inherits="cordobaPlacas.productoNuevo" Theme="default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" DisplayCancelButton="True">
        <NavigationStyle BorderStyle="Solid" BorderWidth="1px" />
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
</asp:Content>
