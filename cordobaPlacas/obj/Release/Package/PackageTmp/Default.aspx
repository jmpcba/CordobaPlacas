<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="cordobaPlacas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <div class="jumbotron">
                <h1>Pedidos</h1>
                <p class="lead">Administre pedidos existentes y envie nuevos pedidos desde aqui.</p>
                <p><a href="App_pages/pedidos/pedidoNuevo.aspx" class="btn btn-primary btn-lg">Nuevo&raquo;</a></p>
                <p><a href="App_pages/pedidos/ModificarPedido.aspx" class="btn btn-primary btn-lg">Modificar&raquo;</a></p>
                <p><a href="App_pages/pedidos/consultarPedidos.aspx" class="btn btn-primary btn-lg">Consultar&raquo;</a></p>
                <p><a href="App_pages/pedidos/administrarPedidos.aspx" class="btn btn-primary btn-lg">Administrar&raquo;</a></p>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <h2>Productos</h2>
                    <p>
                        Administre desde aqui sus productos.</p>
                    <p><a class="btn btn-default" href="App_pages/productos/ProductoNuevo.aspx">Nuevo &raquo;</a></p>
                    <p><a class="btn btn-default" href="App_pages/productos/modificarProductos.aspx">Modificar &raquo;</a></p>
                    <p><a class="btn btn-default" href="App_pages/productos/materiales.aspx">Materiales&raquo;</a></p>
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
                    <p><a class="btn btn-default" href="App_pages/reportes/reportePedidosCliente.aspx">Ventas Por Cliente &raquo;</a></p>
                    <p><a class="btn btn-default" href="App_pages/reportes/reportePedidosProducto.aspx">Ventas Por Producto &raquo;</a></p>
                </div>
            </div>
</asp:Content>
