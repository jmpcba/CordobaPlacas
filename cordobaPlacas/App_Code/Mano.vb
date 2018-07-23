Imports System.Data
Public Class Mano
    Public id As Integer
    Public nombre As String
    Dim db As DbHelper

    Public Sub New()
        db = New DbHelper("manos")
    End Sub

    Public Sub New(ByVal _id As Integer)
        id = _id
        db = New DbHelper("manos")
        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("nombre")
    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
        db = New DbHelper("manos")
    End Sub

    Public Function getManos() As DataTable
        Try
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
