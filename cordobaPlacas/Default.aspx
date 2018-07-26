<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="cordobaPlacas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            <div class="jumbotron">
                <h1>Pedidos</h1>
                <p class="lead">Administre pedidos existentes y envie nuevos pedidos desde aqui.</p>
                <p><a href="App_pages/pedidos/pedidoNuevo.aspx" class="btn btn-primary btn-lg">Nuevo&raquo;</a></p>
                <p><a href="App_pages/pedidos/ModificarPedido.aspx" class="btn btn-primary btn-lg">Modificar&raquo;</a></p>
                <p><a href="App_pages/pedidos/consultarPedidos.aspx" class="btn btn-primary btn-lg">Mis Pedidos&raquo;</a></p>
                <p><a href="App_pages/pedidos/administrarPedidos.aspx" class="btn btn-primary btn-lg">Produccion&raquo;</a></p>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <h2>Productos</h2>
                    <p>
                        Administre desde aqui sus productos.</p>
                    <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Nuevo &raquo;</a></p>
                    <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Modificar &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h2>Clientes</h2>
                    <p>
                        Administracion de usuarios y roles.
                    </p>
                    <p><a class="btn btn-default" href="App_pages/clientes/busquedaCliente.aspx">Buscar &raquo;</a></p>
                    <p><a class="btn btn-default" href="App_pages/clientes/ModificarCliente">Modificar &raquo;</a></p>
                    <p><a class="btn btn-default" href="App_pages/clientes/nuevoCliente.aspx">Nuevo &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h2>Reportes</h2>
                    <p>
                        Informacion historica del sistema</p>
                    <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Ventas Por Provincia &raquo;</a></p>
                    <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Ventas Por Cliente &raquo;</a></p>
                </div>
            </div>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <h1>Inicie Session!!!</h1>
            <p><a runat="server" href="~/Account/Login">Iniciar sesión</a></p>
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>
