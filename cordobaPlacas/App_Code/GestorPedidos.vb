Imports System.Data
Public Class GestorPedidos
    Public pedido As Pedido
    Private db As DbHelper

    Public Sub New()
        pedido = New Pedido()
        db = New DbHelper("pedidos")
    End Sub

    Public Sub New(ByVal _idPedido As Integer)
        pedido = New Pedido(_idPedido)
        db = New DbHelper("pedidos")
    End Sub

    Public Sub New(ByVal _cliente As Cliente)
        pedido = New Pedido(_cliente)
        db = New DbHelper("pedidos")
    End Sub

    Public Sub addItem(ByVal item As Item)
        pedido.agregarItem(item)
    End Sub

    Public Sub enviarPedido()
        Try
            pedido.enviarPedido()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizarPedido(ByVal _idPedido As Integer, ByVal _col As String, ByVal _val As String)
        Try
            db.updateById(_idPedido, _col, _val)
            db.updateById(_idPedido, "fecha_modificado", Today.Date.ToShortDateString)

            If _col = "estado" And _val = "ENTREGADO" Then
                db.updateById(_idPedido, "entregado", Today.Date.ToShortDateString)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub actualizarEnCurso(_gr As GridView)
        Dim cambio = False

        For Each r As GridViewRow In _gr.Rows
            Dim index = pedido.itemIndex(r.Cells(0).Text)
            Dim txtHojasGridView As TextBox
            Dim txtMarcosGridView As TextBox
            Dim txtEnsamGridView As TextBox
            Dim hojas As Integer
            Dim marcos As Integer
            Dim ensamblados As Integer

            txtHojasGridView = r.FindControl("txtHojasTerminadas")
            txtMarcosGridView = r.FindControl("txtMarcosTerminados")
            txtEnsamGridView = r.FindControl("txtEnsambladas")

            hojas = txtHojasGridView.Text.Trim
            marcos = txtMarcosGridView.Text.Trim
            ensamblados = txtEnsamGridView.Text.Trim

            If hojas <> pedido.items(index).hojasTerminadas Then
                pedido.items(index).hojasTerminadas = hojas
                cambio = True
            End If

            If marcos <> pedido.items(index).marcosTerminados Then
                pedido.items(index).marcosTerminados = marcos
                cambio = True
            End If

            If ensamblados <> pedido.items(index).getEnsamblados() Then
                pedido.items(index).setEnsamblados(ensamblados)
                cambio = True
            End If

            If cambio Then
                pedido.items(index).actualizar()
            End If
        Next

        If cambio Then
            If pedido.estado.id < Estado.estados.enProduccion Then
                pedido.estado = New Estado(Estado.estados.enProduccion)
                pedido.actualizar()
            End If
        End If

    End Sub

    Friend Sub eliminarItem(_index As Integer)
        pedido.eliminarItem(_index)
    End Sub

    Public Sub enviarDeposito(_gr As GridView)
        Dim flag As Boolean = True

        'ACTUALIZAR LOS ITEMS QUE SE MUESTRAN EN PANTALLA
        For Each r As GridViewRow In _gr.Rows
            Dim index = pedido.itemIndex(r.Cells(0).Text)
            pedido.items(index).setEnDeposito(pedido.items(index).getEnsamblados())
            Try
                pedido.items(index).actualizar()
            Catch ex As Exception
                Throw
            End Try

        Next

        'CONTROLAR SI TODOS LOS ITEMS DEL PEDIDO ESTAN EN DEPOSITO
        For Each i As Item In pedido.items
            If i.getEstado.id <> Estado.estados.deposito Then
                flag = False
            End If
        Next

        'SI ESTAN TODOS EN DEPOSITO MARCAR EL PEDIDO COMO ESTADO DEPOSITO
        If flag Then
            pedido.estado = New Estado(Estado.estados.deposito)
            Try
                pedido.actualizar()
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Public Sub EnviarProduccion(_gr As GridView)
        Dim flag = True
        'ACTUALIZAR STOCK EN CADA ITEM DEL PEDIDO
        For Each r As GridViewRow In _gr.Rows
            Dim index = pedido.itemIndex(r.Cells(1).Text)
            Dim txstockGridView As TextBox
            Dim stock As Integer

            txstockGridView = r.FindControl("txtStockRow")
            stock = txstockGridView.Text.Trim
            pedido.items(index).setStock(stock)


            'SI SE CUBRE 100% DEL PEDIDO CON STOCK CAMBIAR EL ESTADO
            If pedido.items(index).stock = pedido.items(index).cant Then
                pedido.items(index).setEstado(New Estado(Estado.estados.deposito))
            Else
                pedido.items(index).setEstado(New Estado(Estado.estados.enCola))
            End If
            pedido.items(index).actualizar()
        Next

        'SI ALGUN ITEM NO ESTA EN ESTADO PEDIDO MARCA LA FLAG EN FALSE
        For Each i As Item In pedido.items
            If i.getEstado().id <> Estado.estados.deposito Then
                flag = False
                Exit For
            End If
        Next

        'SI TODOS LOS ITEMS ESTAN EN ESTADO DEPOSITO MARCA EL PEDIDO COMO DEPOSITO. SI NO, EN COLA
        If flag Then
            pedido.estado = New Estado(Estado.estados.deposito)
        Else
            pedido.estado = New Estado(Estado.estados.enCola)
        End If
        pedido.actualizar()
    End Sub
End Class
