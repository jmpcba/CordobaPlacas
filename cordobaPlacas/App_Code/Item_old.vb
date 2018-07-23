Imports System.Data
Public Class Item_old
    'DEPRECADO

    Public hoja As Hoja
    Public marco As Marco
    Public madera As Madera
    Public chapa As Chapa
    Public mano As Mano
    Public idPedido As Integer
    Public linea As linea

    'NUEVO
    Public id As Integer
    Public producto As Producto
    Public cant As Integer
    Public precio As Decimal
    Public estado As Estado
    Public fechaModificacion As Date
    Private db As DbHelper

    Public Sub New(ByVal _hoja As Hoja, ByVal _marco As Marco, ByVal _madera As Madera, ByVal _chapa As Chapa, ByVal _cant As Integer, ByVal _mano As Mano, ByVal _linea As linea)
        'Crear objecto desde cero
        hoja = _hoja
        marco = _marco
        madera = _madera
        chapa = _chapa
        cant = _cant
        mano = _mano
        linea = _linea
        db = New DbHelper("items")
        precio = calcularPrecio()
        precio = Math.Round(precio, 2)
        estado = New Estado(0)
    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _hoja As Hoja, ByVal _marco As Marco, ByVal _madera As Madera, ByVal _chapa As Chapa, ByVal _cant As Integer, ByVal _mano As Mano, ByVal _idPedido As Integer, ByVal _linea As linea, ByVal _estado As Estado)
        'Crear objeto con items desde la DB
        id = _id
        hoja = _hoja
        marco = _marco
        madera = _madera
        chapa = _chapa
        cant = _cant
        mano = _mano
        idPedido = _idPedido
        linea = _linea
        precio = calcularPrecio()
        precio = Math.Round(precio, 2)
        estado = _estado
        db = New DbHelper("items")
    End Sub

    Public Sub insert()
        Dim idHoja = hoja.id
        Dim idMarco = marco.id
        Dim idMadera = madera.id
        Dim idChapa = chapa.id
        Dim idLinea = linea.id
        Try
            db.insertarItem(hoja.id, marco.id, madera.id, chapa.id, cant, precio, mano.id, idPedido, idLinea)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Try
            db.actualizarItem(id, hoja.id, marco.id, madera.id, chapa.id, cant, precio, mano.id, linea.id, estado.id)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function calcularPrecio() As Decimal
        Dim precio As Decimal = 0
        Const PRECIO_LIVIANA_MURO10 = 575
        Const PRECIO_LIVIANA_MURO17 = 600.8
        Const PRECIO_INTERMEDIA = 648
        Const PRECIO_PESADA_EUCALIPTO = 755
        Const PRECIO_PRESADA_CEDRO = 1131

        Select Case linea.id
            'LINEA LIVIANA
            Case 1
                'MARCO 6 Y 10
                If marco.id < 2 Then
                    precio = PRECIO_LIVIANA_MURO10
                Else
                    'MARCO 15 Y 17
                    precio = PRECIO_LIVIANA_MURO17
                End If
            'LINEA INTERMEDIA
            Case 2
                precio = PRECIO_INTERMEDIA
            Case 3
                If madera.id < 2 Then
                    precio = PRECIO_PESADA_EUCALIPTO
                Else
                    precio = PRECIO_PRESADA_CEDRO
                End If
            Case 4
                Select Case hoja.id
                    Case 4
                        Select Case madera.id
                            Case 0
                                precio = 1341.25
                            Case 2
                                precio = 1404.37
                        End Select
                    Case 5
                        Select Case madera.id
                            Case 0
                                precio = 1349.6
                            Case 2
                                precio = 1503.68
                        End Select
                    Case 6
                        Select Case madera.id
                            Case 0
                                precio = 1595.58
                            Case 2
                                precio = 1732.02
                        End Select
                    Case 7
                        Select Case madera.id
                            Case 0
                                precio = 1773.79
                            Case 2
                                precio = 1939.94
                        End Select
                    Case 8
                        Select Case madera.id
                            Case 0
                                precio = 1837.37
                            Case 2
                                precio = 2055.96
                        End Select
                    Case 9
                        Select Case madera.id
                            Case 0
                                precio = 1780.29
                            Case 2
                                precio = 1942.72
                        End Select
                    Case 10
                        Select Case madera.id
                            Case 0
                                precio = 1958.5
                            Case 2
                                precio = 2137.64
                        End Select
                    Case 11
                        Select Case madera.id
                            Case 0
                                precio = 2200.76
                            Case 2
                                precio = 2459.73
                        End Select
                    Case 12
                        Select Case madera.id
                            Case 0
                                precio = 2461.59
                            Case 2
                                precio = 2722.41
                        End Select
                    Case 13
                        Select Case madera.id
                            Case 0
                                precio = 2511.71
                            Case 2
                                precio = 2836.58
                        End Select
                End Select
        End Select

        If linea.id < 4 Then
            'HOJAS DE 80 Y 90
            If hoja.id > 1 Then
                precio = precio * 1.1
            End If
        End If

        'GANANCIA
        precio = precio * 1.3

        'IVA
        precio = precio * 1.21

        Return precio * cant
    End Function
End Class
