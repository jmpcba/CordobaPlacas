Imports System.Data
Public Class GestorProductos
    Dim producto As Producto
    Dim despiece As DataTable
    Dim gd As GestorDatos
    Dim db As DbHelper
    Public Sub New(_idProducto As Integer)
        gd = New GestorDatos
        producto = New Producto(_idProducto)
        despiece = gd.getDespieceProducto(_idProducto)
    End Sub

    Public Sub eliminarPieza(_idPieza As Integer)
        Try
            db = New DbHelper()
            db.eliminarPieza(producto.id, _idPieza)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub agregarPieza(_idPieza As Integer, _consumo As Decimal)
        db = New DbHelper()

        For Each r As DataRow In despiece.Rows
            If r("ID_PIEZA") = _idPieza Then
                Throw New Exception("La pieza ya existe en el despiece de este producto")
            End If
        Next

        Try
            db.insertarPiezaProducto(producto.id, _idPieza, _consumo)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Friend Sub actualizarDespiece(_idPieza As Integer, _consumo As Decimal)
        db = New DbHelper()
        db.actualizarDespiece(producto.id, _idPieza, _consumo)
    End Sub
End Class
