<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="cordobaPlacas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Inicio" Value="Inicio"></asp:MenuItem>
                <asp:MenuItem Text="Pedidos" Value="Pedidos">
                    <asp:MenuItem NavigateUrl="~/App_pages/pedidos/pedidoNuevo.aspx" Text="Nuevo" Value="Nuevo"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Nuevo elemento" Value="Nuevo elemento"></asp:MenuItem>
                <asp:MenuItem Text="Nuevo elemento" Value="Nuevo elemento"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
    </form>
</body>
</html>
