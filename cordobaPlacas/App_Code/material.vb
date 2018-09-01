Imports System.Data
Public Class Material
    Public id As Integer
    Public nombre As String
    Public stock As Decimal
    Public stockReservado As Decimal
    Public unidad As String
    Private db As DbHelper

    Public Sub New()
        db = New DbHelper("MATERIALES")
    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
        stock = 0
        stockReservado = 0
        db = New DbHelper("MATERIALES")
    End Sub

    Public Sub New(ByVal _id As Integer)
        db = New DbHelper("MATERIALES")
        Try
            Dim t = db.getRow(_id)

            id = _id
            nombre = t.Rows(0)("NOMBRE")
            unidad = t.Rows(0)("UNIDAD")
            stockReservado = t.Rows(0)("STOCK_RESERVADO")
            stock = t.Rows(0)("STOCK_DISPONIBLE")
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getMateriales() As DataTable
        Try
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub agregarMaterial(_nombre As String, _unidad As String)
        Dim dt = New DataTable
        Dim flag As Boolean = True
        Try
            dt = getMateriales()

            For Each r As DataRow In dt.Rows
                If _nombre = r("NOMBRE") Then
                    flag = False
                    Throw New Exception("El nombre ya existe")
                End If
            Next

            If flag Then
                db.insertMaterial(_nombre, _unidad)
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Friend Sub eliminar()
        Try
            db.eliminarMaterial(id)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
