Imports System.Data
Public Class Marco
    Public id As Integer
    Public nombre As String
    Private db As DbHelper

    Public Sub New()
        db = New DbHelper("marcos")
    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
        db = New DbHelper("marcos")
    End Sub
    Public Sub New(ByVal _id As Integer)
        id = _id
        db = New DbHelper("marcos")

        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("nombre")
    End Sub
    Public Function getMarcos() As DataTable
        Try
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Sub insertar()
        Try
            If nombre <> "" Then
                Dim marcos = getMarcos()
                If marcos.Select("NOMBRE='" & nombre & "'").Count > 0 Then
                    Throw New Exception("YA EXISTE UN MARCO CON ESE NOMBRE")
                Else
                    db.insertar(Me)
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
