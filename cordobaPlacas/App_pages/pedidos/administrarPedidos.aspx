<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="administrarPedidos.aspx.vb" Inherits="cordobaPlacas.administrarPedidos" Theme="default"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function exportPDF() {
            var url = "../impresion/impresion.aspx"
            window.open(url, '_blank')
        }
    </script>
    <ajaxToolkit:TabContainer ID="TabContainer1" 
        runat="server"
        Height="100%"
        Width="100%"
        ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="Recibidos" ID="tbNuevos" CssClass="tabContainer">
             <ContentTemplate>
                 <asp:Panel ID="pnlNvos" runat="server">
                    <h2>Pedidos Nuevos</h2>
                    <p>
                        <asp:ImageButton ID="btnRefreshNv" runat="server" Height="34px" ImageUrl="~/images/refresh-button-icon.png" Width="34px" ImageAlign="Middle" ToolTip="Refrescar" CssClass="imageButtons" />
                    </p>
                    <hr />
                    <asp:GridView ID="grNvos" runat="server" AutoGenerateColumns="False" DataKeyNames="Nro Pedido" DataSourceID="dsNvos" ToolTip="Pedidos en estado RECIBIDO"><Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" ShowSelectButton="True">
                        <ControlStyle Height="20px" Width="20px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nro Pedido" />
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                        <asp:BoundField DataField="Fecha Recibido" HeaderText="Fecha Recibido" SortExpression="Fecha Recibido" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="Ultima Modificacion" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" DataFormatString="{0:d}" />
                        </Columns>
                        </asp:GridView>
                    <asp:SqlDataSource ID="dsNvos" runat="server" ConnectionString="Data Source=USER-PC;Initial Catalog=cbaPlacas;Integrated Security=True" SelectCommand="SP_PEDIDOS_RECIBIDOS" SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                </asp:Panel>
                    <asp:Panel ID="pnlDetalleNvo" runat="server" Visible="False">
                            <hr />
                            <h4>Detalles Pedido</h4>
                            <asp:GridView ID="grDetalleNvo" runat="server" AutoGenerateColumns="False" ToolTip="Detalles del Pedido">
                                <Columns>
                                    <asp:CommandField SelectText="Detalle" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" >
                                    <ControlStyle Height="20px" Width="20px" />
                                    </asp:CommandField>
                                    <asp:BoundField HeaderText="ITEM" DataField="ITEM" />
                                    <asp:BoundField HeaderText="LINEA" DataField="LINEA" />
                                    <asp:BoundField HeaderText="MADERA" DataField="MADERA" />
                                    <asp:BoundField HeaderText="HOJA" DataField="HOJA" />
                                    <asp:BoundField HeaderText="MARCO" DataField="MARCO" />
                                    <asp:BoundField HeaderText="CHAPA" DataField="CHAPA" />
                                    <asp:BoundField HeaderText="MANO" DataField="MANO" />
                                    <asp:BoundField HeaderText="ESTADO" DataField="ESTADO" />
                                    <asp:BoundField HeaderText="CANT" DataField="CANT" >
                                    <ItemStyle CssClass="numCols" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="STOCK" DataField="STOCK" >
                                    <ItemStyle CssClass="numCols" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="USAR STOCK">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtStockRow" runat="server" Height="17px" Width="35px" ValidationGroup="vgStock" ToolTip="Seleccione cuantas puertas cubrir con stock existente"></asp:TextBox>
                                            <ajaxToolkit:NumericUpDownExtender ID="txtStockRow_NumericUpDownExtender" runat="server" TargetControlID="txtStockRow" Width="50" Minimum="0"  />
                                            <asp:RangeValidator ID="rvStockNvo" runat="server" ControlToValidate="txtStockRow" ErrorMessage="No puede superar Stock o Cantidad" ForeColor="Red" MinimumValue="0" ValidationGroup="vgStock" Type="Integer">*</asp:RangeValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnRecalcularPedido" runat="server" Text="Recalcular Materiales" ValidationGroup="vgStock" ToolTip="Recalcular Materiales utilizando Stock existente" />
                            <asp:panel id="pnlVal" runat="server">
                                <asp:ValidationSummary ID="vsNvos" runat="server" ValidationGroup="vgStock" DisplayMode="List" ForeColor="Red" ShowMessageBox="True" />
                            </asp:panel>
                    </asp:Panel>
                    <asp:Panel ID="pnlStockNvo" runat="server" Visible="False">
                        <div>
                            <br />
                            <hr />
                            <h4><asp:Label ID="lbltituloMat" runat="server"></asp:Label>
                            </h4>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkPiezas" Text="Dispone de materiales suficientes" runat="server" Enabled="False" />
                                        <asp:GridView ID="grMateriales" runat="server" ToolTip="Despiece"></asp:GridView>
                                    </td>
                                    <td>
                                        <asp:Panel ID="pnlBtnCompras" runat="server" Visible="False">
                                            <h5>Imprimir pedido para piezas faltantes</h5><br/>
                                            <asp:Button ID="btnPedidoCompras" runat="server" Text="Imprimir" ToolTip="Imprimir orden de compra de los materiales faltantes" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <asp:Button ID="btnImprimir" runat="server" Text="Enviar a Produccion" ValidateRequestMode="Enabled" ValidationGroup="vgStock" ToolTip="Imprimir Ordenes de trabajo y enviar el pedido a estado EN COLA" />
                            <ajaxToolkit:ConfirmButtonExtender ID="btnImprimir_ConfirmButtonExtender" runat="server" BehaviorID="_content_btnImprimir_ConfirmButtonExtender" ConfirmText="" TargetControlID="btnImprimir" />
                            <asp:Button ID="btnCancelarRecibido" runat="server" Text="Cancelar" />
                        </div>
                    </asp:Panel>   
    </ContentTemplate>
</ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tbEnCurso" runat="server" HeaderText="En Curso">
            <ContentTemplate>
                <h2>Pedidos En Curso</h2>
                <p>
                    <asp:ImageButton ID="btnRefreshEnCurso" runat="server" Height="34px" ImageUrl="~/images/refresh-button-icon.png" Width="34px" CssClass="imageButtons" />
                </p>
                <hr />
                <asp:GridView ID="grEnCurso" runat="server" AutoGenerateColumns="False" DataKeyNames="Nro Pedido" DataSourceID="dsEnCurso" ToolTip="Pedidos EN COLA y EN PRODUCCION">
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" ShowSelectButton="True">
                        <ControlStyle Height="20px" Width="20px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nro Pedido" />
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                        <asp:BoundField DataField="Fecha Recibido" DataFormatString="{0:d}" HeaderText="Fecha Recibido" SortExpression="Fecha Recibido" />
                        <asp:BoundField DataField="Ultima Modificacion" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" DataFormatString="{0:d}" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="dsEnCurso" runat="server" SelectCommand="sp_PEDIDOS_EN_CURSO" SelectCommandType="StoredProcedure" ConnectionString="Data Source=USER-PC;Initial Catalog=cbaPlacas;Integrated Security=True"></asp:SqlDataSource>
                <asp:Panel ID="pnlDetalleEnCurso" runat="server" Visible="False">
                    <hr />
                    <h4>Detalle Pedido</h4>
                    <asp:GridView ID="grDetalleEnCurso" runat="server" AutoGenerateColumns="False" ToolTip="Detalle pedido">
                        <Columns>
                            <asp:BoundField DataField="ITEM" HeaderText="ITEM" />
                            <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
                            <asp:BoundField DataField="MADERA" HeaderText="MADERA" />
                            <asp:BoundField DataField="HOJA" HeaderText="HOJA" />
                            <asp:BoundField DataField="MARCO" HeaderText="MARCO" />
                            <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" />
                            <asp:BoundField DataField="MANO" HeaderText="MANO" />
                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                            <asp:BoundField DataField="CANT" HeaderText="CANT" >
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle Font-Bold="True" CssClass="numCols" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STOCK" HeaderText="EN STOCK" >
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle Font-Bold="True" CssClass="numCols" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="HOJAS TERMINADAS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHojasTerminadas" runat="server" Height="17px" Width="35px" Text='<%# Bind("HOJAS_TER") %>' ToolTip="Hojas fabricadas"></asp:TextBox>
                                    <ajaxToolkit:NumericUpDownExtender ID="txtHojasTerminadas_NumericUpDownExtender" Minimum="0" Maximum='<%#Eval("CANT") - Eval("STOCK") %>' runat="server" Width="50" TargetControlID="txtHojasTerminadas" />
                                    <asp:RangeValidator ID="rvHojasTer" runat="server" MinimumValue="0" MaximumValue='<%#Eval("CANT") - Eval("STOCK") %>' BorderStyle="None" ControlToValidate="txtHojasTerminadas" ErrorMessage="El Maximo no puede ser mayor a CANT - STOCK" ForeColor="Red" ValidationGroup="vgEnCurso" Type="Integer">*</asp:RangeValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MARCOS TERMINADOS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMarcosTerminados" runat="server" Height="17px" Width="35px" Text='<%# Bind("MARCO_TER") %>' ToolTip="marcos fabricados"></asp:TextBox>
                                    <ajaxToolkit:NumericUpDownExtender ID="txtMarcosTerminados_NumericUpDownExtender" Minimum="0" Maximum='<%#Eval("CANT") - Eval("STOCK") %>' Width="50" runat="server" TargetControlID="txtMarcosTerminados" />
                                    <asp:RangeValidator ID="rvMarcosTer" runat="server" ControlToValidate="txtMarcosTerminados" MinimumValue="0" MaximumValue='<%#Eval("CANT") - Eval("STOCK") %>' ErrorMessage="El Maximo no puede ser mayor a CANT - STOCK" ForeColor="Red" Type="Integer" ValidationGroup="vgEnCurso">*</asp:RangeValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ENSAMBLADAS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEnsambladas" runat="server" Height="17px" Width="35px" Text='<%# Bind("ENSAMBLADOS") %>' ToolTip="Puertas terminadas"></asp:TextBox>
                                    <ajaxToolkit:NumericUpDownExtender ID="txtEnsambladas_NumericUpDownExtender" Minimum="0" Maximum='<%#Eval("CANT") - Eval("STOCK") %>' runat="server" Width="50" TargetControlID="txtEnsambladas" />
                                    <asp:RangeValidator ID="rvEnsambladas" runat="server" ControlToValidate="txtEnsambladas" MinimumValue="0" MaximumValue='<%#Eval("CANT") - Eval("STOCK") %>' ErrorMessage="El Maximo no puede ser mayor a CANT - STOCK" ForeColor="Red" ValidationGroup="vgEnCurso" Type="Integer">*</asp:RangeValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:TextBox ID="txtTest" runat="server"></asp:TextBox>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <br />
                    <asp:ValidationSummary ID="vsEnCurso" runat="server" DisplayMode="List" ForeColor="Red" ValidationGroup="vgEnCurso"/>
                    <br />
                    <asp:Button ID="btnActualizarEnCurso" runat="server" Text="ActualizarPedido" ValidationGroup="vgEnCurso" ToolTip="Actualizar los datos del pedido" /> 
                    <asp:Button ID="btnCancelarEnCurso" runat="server" Text="Cancelar"/> 
                </asp:Panel>
</ContentTemplate>
</ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tbEnsamblados" runat="server" HeaderText="Ensamblados">
            <ContentTemplate>
                <asp:Panel ID="pnlEnsamblados" runat="server">
                    <div>
                        <h2>Items Ensamblados</h2>
                        <p>
                            <asp:ImageButton ID="btnRefreshEnsamblado" runat="server" Height="34px" ImageUrl="~/images/refresh-button-icon.png" Width="34px" CssClass="imageButtons" />
                        </p>
                        <hr />
                        <asp:GridView ID="grEnsamblados" runat="server" AutoGenerateColumns="False" DataKeyNames="Nro Pedido" DataSourceID="dsEnsamblados" ToolTip="Pedidos con items a la espera de ser recibidos en el deposito">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" ShowSelectButton="True">
                                <ControlStyle Height="20px" Width="20px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nro Pedido" />
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                <asp:BoundField DataField="Fecha Recibido" DataFormatString="{0:d}" HeaderText="Fecha Recibido" SortExpression="Fecha Recibido" />
                                <asp:BoundField DataField="Ultima Modificacion" DataFormatString="{0:d}" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" />
                                <asp:BoundField DataField="A_ALMACENAR" HeaderText="P/ Almancenar">
                                <ItemStyle Font-Bold="True" CssClass="numCols" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnAlmacenar" runat="server" CommandArgument='<%# Eval("nro pedido") %>' CommandName="almacenar" CssClass="imageButtons" ImageUrl="~/images/stock.png" ToolTip="Imprimir etiquetas de deposito para items ensamblados" Visible="False" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="btnAlmacenar_ConfirmButtonExtender" runat="server" ConfirmText="Imprimir etiquetas de deposito?" TargetControlID="btnAlmacenar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsEnsamblados" runat="server" ConnectionString="Data Source=USER-PC;Initial Catalog=cbaPlacas;Integrated Security=True" SelectCommand="SP_PEDIDOS_ITEMS_ENSAMBLADO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlDetalleEnsamblados" runat="server" Visible="False">
                        <hr />
                        <h4>Detalles Pedido</h4>
                        <asp:GridView ID="grDetalleEnsamblados" runat="server" AutoGenerateColumns="False" ToolTip="Detalle pedido">
                            <Columns>
                                <asp:BoundField DataField="ITEM" HeaderText="ITEM" />
                                <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
                                <asp:BoundField DataField="MADERA" HeaderText="MADERA" />
                                <asp:BoundField DataField="HOJA" HeaderText="HOJA" />
                                <asp:BoundField DataField="MARCO" HeaderText="MARCO" />
                                <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" />
                                <asp:BoundField DataField="MANO" HeaderText="MANO" />
                                <asp:BoundField DataField="CANT" HeaderText="CANT" >
                                <ItemStyle CssClass="numCols" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="STOCK" HeaderText="STOCK" >
                                <ItemStyle CssClass="numCols" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ENSAMBLADAS" HeaderText="ENSAMBLADAS" >
                                <ItemStyle CssClass="numCols" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DEPOSITO" HeaderText="DEPOSITO" >
                                <ItemStyle CssClass="numCols" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PARA ALMACENAR" HeaderText="P/ ALMANCENAR" >
                                <ItemStyle Font-Bold="True" CssClass="numCols" HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </asp:Panel>
</ContentTemplate>
</ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tbDeposito" runat="server" HeaderText="Deposito">
            <ContentTemplate>
                    <asp:Panel ID="pnlDeposito" runat="server">
                    <h2>Pedidos en Deposito</h2>
                        <p>
                            <asp:ImageButton ID="btnRefreshDeposito" runat="server" Height="34px" ImageUrl="~/images/refresh-button-icon.png" Width="34px" CssClass="imageButtons" />
                        </p>
                    <asp:GridView ID="grDeposito" runat="server" AutoGenerateColumns="False" DataKeyNames="Nro Pedido" DataSourceID="dsPedidosDeposito" ToolTip="Pedidos recibidos en el deposito">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" ShowSelectButton="True">
                            <ControlStyle Height="20px" Width="20px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="Nro Pedido" HeaderText="Nro Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nro Pedido" />
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" >
                            <ItemStyle CssClass="numCols" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Fecha Recibido" DataFormatString="{0:d}" HeaderText="Fecha Recibido" SortExpression="Fecha Recibido" />
                            <asp:BoundField DataField="Ultima Modificacion" DataFormatString="{0:d}" HeaderText="Ultima Modificacion" SortExpression="Ultima Modificacion" />
                            <asp:BoundField DataField="ID_ESTADO" HeaderText="ID_ESTADO">
                            <HeaderStyle CssClass="hiddencol" />
                            <ItemStyle CssClass="hiddencol" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDepoEnviar" runat="server" CommandArgument='<%# Eval("nro pedido") %>' CommandName="enviar" CssClass="imageButtons" ImageUrl="~/images/enviar_flecha.png" ToolTip="Mover pedido a ENVIADO e imprimir remito" Visible="False" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnDepoEnviar_ConfirmButtonExtender" runat="server" ConfirmText="Eviar pedido al cliente e imprimir remito?" TargetControlID="btnDepoEnviar" />
                                    <asp:ImageButton ID="btnDepoStock" runat="server" CommandArgument='<%# Eval("nro pedido")%>' CommandName="stock" CssClass="imageButtons" ImageUrl="~/images/almacen.png" ToolTip="Mover Pedido al Stock Interno" Visible="False" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnDepoStock_ConfirmButtonExtender" runat="server" ConfirmText="Mover pedido al stock interno?" TargetControlID="btnDepoStock" />
                                    <asp:ImageButton ID="btnDepoEntregado" runat="server" CommandArgument='<%# Eval("nro pedido") %>' CommandName="entregado" CssClass="imageButtons" ImageUrl="~/images/recibido.png" ToolTip="Mover el pedido a ENTREGADO" Visible="False" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnDepoEntregado_ConfirmButtonExtender" runat="server" ConfirmText="El cliente recibio el pedido?" TargetControlID="btnDepoEntregado" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsPedidosDeposito" runat="server" ConnectionString="Data Source=USER-PC;Initial Catalog=cbaPlacas;Integrated Security=True" SelectCommand="SP_PEDIDOS_ITEMS_ENDEPOSITO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </asp:Panel>
                <asp:Panel ID="pnlDetalleDeposito" runat="server" Visible="False">
                    <hr />
                    <h4>Detalles Pedido</h4>
                    <asp:GridView ID="grDetalleDeposito" runat="server" ToolTip="Detalle pedido" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="ITEM" HeaderText="ITEM" />
                            <asp:BoundField DataField="CANT" HeaderText="CANT" >
                            <ItemStyle CssClass="numCols" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
                            <asp:BoundField DataField="MADERA" HeaderText="MADERA" />
                            <asp:BoundField DataField="HOJA" HeaderText="HOJA" />
                            <asp:BoundField DataField="MARCO" HeaderText="MARCO" />
                            <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" />
                            <asp:BoundField DataField="MANO" HeaderText="MANO" />
                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>  
</ContentTemplate>
</ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tbBuscar" runat="server" HeaderText="Buscar">
            <ContentTemplate>
                <asp:Panel ID="pnlBusquedas" runat="server">
                    <table>
                        <tr >
                            <td colspan="4" ><h2>Buscar Pedidos</h2></td>
                        </tr>
                        <tr class="combos">
                            <td colspan="4">Informacion del pedido</td>
                        </tr>
                        <tr>
                            <td>Numero de Pedido</td>
                            <td>
                                <asp:TextBox ID="txtPedido" runat="server" ToolTip="Buscar un numero de pedido"></asp:TextBox><asp:RegularExpressionValidator ID="revNroPedido" runat="server" ErrorMessage="Solo Se Aceptan Valores Numericos" Text="*" ControlToValidate="txtPedido" CssClass="validators" ValidationExpression="\d+" ValidationGroup="vgBuscar"></asp:RegularExpressionValidator>
                            </td>
                            <td>Cliente</td>
                            <td>
                                <asp:DropDownList ID="dpClientes" runat="server" ToolTip="Filtrar por cliente"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Estado</td>
                            <td>
                            <asp:DropDownList ID="dpFiltroEstados" runat="server" ToolTip="Filtrar por estado"></asp:DropDownList></td>
                        </tr>                    
                        <tr class="combos">
                            <td colspan="4"><hr /></td>
                        </tr>
                        <tr class="combos">
                            <td colspan="4">Fecha De Recepcion del Pedido</td>
                        </tr>
                        <tr>
                            <td style="text-align: center;"><p>Desde</p></td>
                            <td>
                                <asp:TextBox ID="txtFecRecDesde" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de recepcion"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender 
                                    ID="txtFecRecDesde_MaskedEditExtender" 
                                    runat="server" 
                                    TargetControlID="txtFecRecDesde"
                                    Mask="99/99/9999"
                                    Masktype="Date"
                                    BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                                    Century="2000" 
                                    CultureAMPMPlaceholder="" 
                                    CultureCurrencySymbolPlaceholder="" 
                                    CultureDateFormat="" 
                                    CultureDatePlaceholder="" 
                                    CultureDecimalPlaceholder="" 
                                    CultureThousandsPlaceholder="" 
                                    CultureTimePlaceholder="" />
                                <ajaxToolkit:CalendarExtender ID="txtFecRecDesde_CalendarExtender" runat="server" TargetControlID="txtFecRecDesde" format="dd/MM/yyyy" BehaviorID="_content_txtFecRecDesde_CalendarExtender"/>
                                <asp:CompareValidator ID="CVFecRecDesde" runat="server" ErrorMessage="Fecha Invalida" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtFecRecDesde" ForeColor="Red" ValidationGroup="vgBuscar" CssClass="validators">*</asp:CompareValidator>
                            </td>
                            <td>Hasta</td>
                            <td>
                                <asp:TextBox ID="txtFecRecHasta" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de recepcion"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="txtFecRecHasta_MaskedEditExtender"
                                    runat="server" 
                                    TargetControlID="txtFecRecHasta"
                                     Mask="99/99/9999"
                                    Masktype="Date"
                                    BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                                    Century="2000" 
                                    CultureAMPMPlaceholder="" 
                                    CultureCurrencySymbolPlaceholder="" 
                                    CultureDateFormat="" 
                                    CultureDatePlaceholder="" 
                                    CultureDecimalPlaceholder="" 
                                    CultureThousandsPlaceholder="" 
                                    CultureTimePlaceholder=""/>
                                <ajaxToolkit:CalendarExtender ID="txtFecRecHasta_CalendarExtender" runat="server" TargetControlID="txtFecRecHasta" format="dd/MM/yyyy" BehaviorID="_content_txtFecRecHasta_CalendarExtender"/>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFecRecHasta" ErrorMessage="Fecha Invalida" ForeColor="Red" Operator="DataTypeCheck" Type="Date" ValidationGroup="vgBuscar" CssClass="validators">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr class="combos">
                            <td colspan="4"><hr /></td>
                        </tr>
                        <tr class="combos">
                            <td colspan="4">Fecha de Ultima Modificacion Del Pedido</td>
                        </tr>
                        <tr>
                            <td style="text-align: center;"><p>Desde</p></td>
                            <td>
                                <asp:TextBox ID="txtFecModDesde" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de modificacion"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender 
                                    ID="txtFecModDesde_MaskedEditExtender"
                                    runat="server" 
                                    TargetControlID="txtFecModDesde"
                                    Mask="99/99/9999"
                                    Masktype="Date"
                                    BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                                    Century="2000" 
                                    CultureAMPMPlaceholder="" 
                                    CultureCurrencySymbolPlaceholder="" 
                                    CultureDateFormat="" 
                                    CultureDatePlaceholder="" 
                                    CultureDecimalPlaceholder="" 
                                    CultureThousandsPlaceholder="" 
                                    CultureTimePlaceholder=""/>
                                <ajaxToolkit:CalendarExtender ID="txtFecModDesde_CalendarExtender" runat="server" TargetControlID="txtFecModDesde" format="dd/MM/yyyy" BehaviorID="_content_txtFecModDesde_CalendarExtender"/>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtFecModDesde" ErrorMessage="Fecha Invalida" ForeColor="Red" Type="Date" ValidationGroup="vgBuscar" Operator="DataTypeCheck" CssClass="validators">*</asp:CompareValidator>
                            </td>
                            <td>Hasta</td>
                            <td>
                                <asp:TextBox ID="txtFecModHasta" runat="server" Width="100px" ValidationGroup="vgBuscar" ToolTip="Filtrar por fecha de modificacion"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="txtFecModHasta_MaskedEditExtender" 
                                    runat="server" 
                                    TargetControlID="txtFecModHasta"
                                    Mask="99/99/9999"
                                    Masktype="Date"
                                    BehaviorID="_content_txtFecRecDesde_MaskedEditExtender" 
                                    Century="2000" 
                                    CultureAMPMPlaceholder="" 
                                    CultureCurrencySymbolPlaceholder="" 
                                    CultureDateFormat="" 
                                    CultureDatePlaceholder="" 
                                    CultureDecimalPlaceholder="" 
                                    CultureThousandsPlaceholder="" 
                                    CultureTimePlaceholder="" />
                                <ajaxToolkit:CalendarExtender ID="txtFecModHasta_CalendarExtender2" runat="server" TargetControlID="txtFecModHasta" format="dd/MM/yyyy" BehaviorID="_content_txtFecModHasta_CalendarExtender2"/>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtFecModHasta" ErrorMessage="Fecha invalida" ForeColor="Red" Type="Date" ValidationGroup="vgBuscar" Operator="DataTypeCheck" CssClass="validators">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="vgBuscar" />
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Filtros" />
                            </td>
                        </tr>
                        <tr class="combos">
                            <td colspan="4"><hr /></td>
                        </tr>
                    </table>
                    <asp:Panel ID="pnlValidacionBusqueda" runat="server">
                        <asp:ValidationSummary ID="VSBuscar" runat="server" ValidationGroup="vgBuscar" DisplayMode="List" ForeColor="Red" />
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel ID="pnlResultadoBusqueda" runat="server">
                    <asp:GridView ID="grResultadoBusqueda" runat="server" AutoGenerateColumns="False" ToolTip="Resultados de busqueda" DataKeyNames="Nro Pedido">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/zoom_in.png" ShowSelectButton="True">
                            <ControlStyle Height="20px" Width="20px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="Nro Pedido" HeaderText="Nro" />
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" >
                            <ItemStyle CssClass="numCols" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Precio" DataFormatString="{0:F2}" HeaderText="Precio" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="Fecha Recibido" DataFormatString="{0:d}" HeaderText="Fecha Recibido" />
                            <asp:BoundField DataField="Ultima Modificacion" DataFormatString="{0:d}" HeaderText="Fecha Modificado" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnRePrintOrdenes" runat="server" CommandArgument='<%# Eval("nro pedido") %>' CommandName="printOrden" CssClass="imageButtons" ImageUrl="~/images/view-details.png" ToolTip="Imprimir orden de trabajo" Visible="False" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnRePrintOrdenes_ConfirmButtonExtender" runat="server" ConfirmText="Re-imprimir ordenes de trabajo?" TargetControlID="btnRePrintOrdenes" />
                                    <asp:ImageButton ID="btnRePrintRemito" runat="server" CssClass="imageButtons" ImageUrl="~/images/enviar.png" CommandArgument='<%# Eval("nro pedido") %>' CommandName="printRemito" ToolTip="Imprimir Remito" Visible="False" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnRePrintRemito_ConfirmButtonExtender" runat="server" ConfirmText="Re-imprimir remito?" TargetControlID="btnRePrintRemito" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Panel ID="pnlBuscarBotones" Visible="False" runat="server">
                    <hr />
                    <asp:GridView ID="grDetalleBusqueda" runat="server" ToolTip="Detalle pedido" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="ITEM" HeaderText="ITEM" />
                            <asp:BoundField DataField="CANT" HeaderText="CANT" >
                            <ItemStyle CssClass="numCols" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LINEA" HeaderText="LINEA" />
                            <asp:BoundField DataField="MADERA" HeaderText="MADERA" />
                            <asp:BoundField DataField="MARCO" HeaderText="MARCO" />
                            <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" />
                            <asp:BoundField DataField="MANO" HeaderText="MANO" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnRePrintEtiqueta" runat="server" CssClass="imageButtons" ImageUrl="~/images/stock.png" CommandArgument='<%# Eval("ITEM") %>' CommandName="printEtiqueta" ToolTip="Imprimir etiquetas p/ deposito" Visible="False" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnRePrintEtiqueta_ConfirmButtonExtender" runat="server" ConfirmText="Re-imprimir etiquetas de Deposito?" TargetControlID="btnRePrintEtiqueta" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                </asp:Panel>
    </ContentTemplate>
</ajaxToolkit:TabPanel>  
    </ajaxToolkit:TabContainer>
    <asp:Panel ID="pnlCrystalReport" runat="server" Visible="False">
        <asp:ImageButton ID="btnVolverEtiquetas" runat="server" CssClass="imageButtons" ImageUrl="~/images/arrow_left-512.png" ToolTip="volver" />
        <br />
        &nbsp;<br />
        <asp:ImageButton ID="btnPrintCrystal" runat="server" CssClass="printBtn" ImageUrl="~/images/print.png" Width="35px" />
        <br />
        <br />
        <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" HasExportButton="False" HasPrintButton="False" ToolPanelView="None" HasToggleGroupTreeButton="False" />
    </asp:Panel>
    <asp:Panel ID="pnlMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
     </asp:Panel>

</asp:Content>
