Imports System.Data
Public Class Estado
    Public id As Integer
    Public nombre As String
    Private db As DbHelper

    Enum estados
        recibido = 0
        enCola = 1
        enProduccion = 2
        deposito = 3
        enviado = 4
        entregado = 5
        stock = 6
        cancelado = 7
    End Enum

    Public Sub New()

    End Sub

    Public Sub New(ByVal _id As Integer)
        id = _id
        db = New DbHelper("estados")
        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("nombre")
    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
    End Sub

    Public Function getEstados() As DataTable
        Try
            db = New DbHelper("estados")
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try
    End Function

    'PARA BORRAR
    Public Function getEstadosPosibles() As String()
        Dim r As DataRow
        Dim dt As DataTable
        Dim posStr As String
        db = New DbHelper("estados")

        dt = db.getRow(id)
        r = dt.Rows(0)
        posStr = r("sig_estado")
        Return posStr.Split(";")
    End Function
End Class
