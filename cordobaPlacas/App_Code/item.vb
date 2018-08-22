Imports System.Data
Public Class Item
    Public id As Integer
    Public idPedido As Integer
    Private producto As Producto
    Private cant As Integer
    Public monto As Decimal
    Private estado As Estado
    Private db As DbHelper
    Public marcosTerminados As Integer
    Public hojasTerminadas As Integer
    Private ensamblados As Integer
    Private enDeposito As Integer
    Public stock As Integer
    Public despiece As DataTable

    Public Sub New(_prod As Producto, _cant As Integer)
        db = New DbHelper("ITEMS")

        producto = _prod
        cant = _cant
        monto = cant * producto.precioUnitario
        estado = New Estado(0)
    End Sub

    Public Sub New(_id As Integer)
        'CONSTRUCTOR PARA CONSTRUIR UN ITEM DESDE LA DB
        Dim dt = New DataTable()
        db = New DbHelper("items")
        dt = db.getRow(_id)

        id = _id
        producto = New Producto(dt(0)(1))
        idPedido = dt(0)(2)
        cant = dt(0)(3)
        monto = dt(0)(4)
        estado = New Estado(dt(0)(5))
        marcosTerminados = dt(0)(6)
        hojasTerminadas = dt(0)(7)
        ensamblados = dt(0)(8)
        enDeposito = dt(0)(9)
        stock = dt(0)(10)
    End Sub
    Public Sub setCant(_cant As Integer)
        cant = _cant
        monto = producto.precioUnitario * cant
    End Sub

    Public Function getCant() As Integer
        Return cant
    End Function

    Public Sub setProducto(_prod As Producto)
        producto = _prod
        monto = producto.precioUnitario * cant
    End Sub

    Public Function getProducto() As Producto
        Return producto
    End Function

    Public Sub setEnDeposito(_val As Integer)
        enDeposito = _val
        If enDeposito = cant - stock Then
            setEstado(New Estado(3))
        End If
    End Sub

    Public Function getEnDeposito() As Integer
        Return enDeposito
    End Function

    Public Sub setEstado(_est As Estado)
        estado = _est
        db = New DbHelper()
        'DESCUENTA MATERIALES DE LA DB SI SE MUEVE EL PEDIDO A ESTADO "EN PRODUCCION" Y ACTUALIZA EL STOCK DEL PRODUCTO
        'PARA ESTADO CANCELADO SE MUEVEN LOS PRODUCTOS ENSAMBLADOS A STOCK CON UN TRIGGER DE LA DB EN LA TABLA ITEMS
        If estado.id = Estado.estados.enCola Then
            CalcularMateriales()
            Try
                db.consumirMateriales(despiece, cant - stock)
            Catch ex As Exception
                Throw
            End Try
        ElseIf estado.id = Estado.estados.cancelado Then
            despiece = CalcularMateriales()
            db.consumirMateriales(despiece, ensamblados * -1)
        End If
    End Sub

    Public Function getEstado() As Estado
        Return estado
    End Function

    Public Function getEnsamblados() As Integer
        Return ensamblados
    End Function

    Public Sub setEnsamblados(_val As Integer)
        db = New DbHelper()
        CalcularMateriales()
        db.consumirMateriales(despiece, _val - ensamblados, True)
        ensamblados = _val
    End Sub

    Public Sub insertarItem()
        db.insertarItem(producto.id, idPedido, cant, monto, stock)
    End Sub

    Public Sub actualizar()
        db = New DbHelper()
        db.actualizarItem(Me)
    End Sub

    Public Function CalcularMateriales() As DataTable

        db = New DbHelper()
        despiece = db.getDespiece(producto.id)
        Return despiece
    End Function

    Public Sub clone(_item As Item)
        producto = _item.producto
        cant = _item.cant
        monto = _item.monto
        setEstado(_item.estado)
        marcosTerminados = _item.marcosTerminados
        hojasTerminadas = _item.hojasTerminadas
        ensamblados = _item.ensamblados
        enDeposito = _item.enDeposito
        stock = _item.stock
        despiece = _item.despiece
    End Sub

    Public Sub setStock(_newStock As Integer)
        db = New DbHelper
        stock = _newStock
        db.updateStock(id, stock)
    End Sub

End Class
