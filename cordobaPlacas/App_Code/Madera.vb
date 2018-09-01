Imports System.Data
Public Class Madera
    Public id As Integer
    Public nombre As String
    Public codMat As Integer
    Dim db As DbHelper = New DbHelper("maderas")

    Public Sub New()

    End Sub

    Public Sub New(ByVal _id As Integer)
        id = _id
        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("nombre")
        codMat = t.Rows(0)("COD_MAT")
    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
    End Sub

    Public Function getMaderas() As DataTable
        Try
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getExcluidas() As DataTable
        Try
            Return db.getExcluidas(DbHelper.tablas.MADERAS, id)
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
