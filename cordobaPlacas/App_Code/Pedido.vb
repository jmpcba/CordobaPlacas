Imports System.Data
Public Class Pedido
    Public id As Integer
    Public items As List(Of Item)
    Public cliente As Cliente
    Public recibido As Date
    Public modificado As Date
    Public entregado As Date
    Public precioTotal As Decimal
    Public cantTotal As Integer
    Public estado As Estado
    Private db As DbHelper

    Sub New()
        Dim today = Date.Today
        recibido = CDate(today.ToShortDateString)
        items = New List(Of Item)
        db = New DbHelper("pedidos")
        precioTotal = 0
        cantTotal = 0
        cliente = New Cliente()
    End Sub

    Sub New(_cliente As Cliente)
        Dim today = Date.Today
        recibido = CDate(today.ToShortDateString)
        items = New List(Of Item)
        db = New DbHelper("pedidos")
        precioTotal = 0
        cantTotal = 0
        cliente = _cliente
    End Sub

    Public Sub New(ByVal _id As Integer)
        Try
            Dim dbPedidos = New DbHelper("pedidos")
            Dim dbItems = New DbHelper("items")
            Dim tPedido = dbPedidos.getRow(_id)
            Dim tItems As DataTable
            Dim row = tPedido.Rows(0)
            Dim today = Date.Today
            items = New List(Of Item)
            precioTotal = 0
            cantTotal = 0

            id = row("id")
            'cliente.id = row("ID_CLIENTE")
            recibido = row("fecha_recibido")
            cliente = New Cliente(row("ID_CLIENTE"))

            If Not IsDBNull(row("fecha_entregado")) Then
                entregado = row("fecha_entregado")
            End If

            If Not IsDBNull(row("fecha_modificado")) Then
                modificado = row("fecha_modificado")
            End If

            estado = New Estado(row("ID_ESTADO"))

            tItems = dbItems.getRange("ID_PEDIDO", id)
            For Each r As DataRow In tItems.Rows
                Dim item = New Item(r("id"))
                items.Add(item)
                precioTotal += item.monto
                cantTotal += item.cant
            Next

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub agregarItem(ByVal _item As Item)
        Dim encontro = False

        For Each i As Item In items
            If i.producto.id = _item.producto.id Then
                i.cant += _item.cant
                i.monto += _item.monto
                encontro = True
                Exit For
            End If
        Next

        If Not encontro Then
            items.Add(_item)
        End If

        precioTotal += _item.monto
        cantTotal += _item.cant

    End Sub

    Public Sub enviarPedido()
        Try
            id = db.insertPedido(cliente.id, cantTotal, precioTotal)

            For Each item As Item In items
                item.idPedido = id
                item.insertarItem()
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Friend Sub actualizar(Optional _updateItems As Boolean = False)
        Dim db = New DbHelper("pedidos")

        If _updateItems Then
            For Each i As Item In items
                i.actualizar()
            Next
        End If

        db.actualizarPedido(Me)
    End Sub

    Public Function getItemById(_ItemId As Integer) As Item
        Dim retItem As Item

        For Each item As Item In items
            If item.id = _ItemId Then
                retItem = item
                Exit For
            End If
        Next

        Return retItem

    End Function

    Public Function calcularMateriales() As DataTable
        Dim dt = New DataTable
        Dim dts = New List(Of DataTable)


        For Each i As Item In items
            Dim desp = i.CalcularMateriales()

            If dt.Rows.Count = 0 Then
                dt = desp.Clone()
            End If

            For Each r As DataRow In desp.Rows
                Dim id = r("ID_PIEZA")
                Dim encontro = False
                r("CONSUMO") = r("CONSUMO") * (i.cant - i.stock)
                For Each j As DataRow In dt.Rows
                    If j("ID_PIEZA") = id Then
                        j("CONSUMO") = j("CONSUMO") + r("CONSUMO")
                        encontro = True
                        Exit For
                    End If
                Next

                If Not encontro Then
                    dt.ImportRow(r)
                End If
            Next
        Next
        Return dt
    End Function

    Friend Sub eliminarItem(_index As Integer)
        Dim i As Item
        i = items(_index)
        items.Remove(i)
        cantTotal -= i.cant
        precioTotal -= i.monto
    End Sub

    Public Function calcularMateriales(_stock As Integer) As DataTable
        Dim dt = New DataTable
        Dim dts = New List(Of DataTable)


        For Each i As Item In items
            Dim desp = i.CalcularMateriales()

            If dt.Rows.Count = 0 Then
                dt = desp.Clone()
            End If

            For Each r As DataRow In desp.Rows
                Dim id = r("ID_PIEZA")
                Dim encontro = False
                r("CONSUMO") = r("CONSUMO") * (i.cant - _stock)
                For Each j As DataRow In dt.Rows
                    If j("ID_PIEZA") = id Then
                        j("CONSUMO") = j("CONSUMO") + r("CONSUMO")
                        encontro = True
                        Exit For
                    End If
                Next

                If Not encontro Then
                    dt.ImportRow(r)
                End If
            Next
        Next
        Return dt
    End Function

    Public Sub updateItem(_id As Integer, _item As Item)
        For Each i As Item In items
            If i.id = _id Then
                i.clone(_item)
            End If
        Next
    End Sub

    Public Function itemIndex(_id As Integer) As Integer
        Dim result = -1
        Dim j = 0
        For Each i As Item In items
            If i.id = _id Then
                result = j
                Exit For
            End If
            j += 1
        Next

        Return result

    End Function

End Class
