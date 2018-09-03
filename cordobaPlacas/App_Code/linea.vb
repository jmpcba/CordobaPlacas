Imports System.Data
Public Class Linea
    Public id As Integer
    Public nombre As String
    Private db As DbHelper

    Public Sub New()
        db = New DbHelper("lineas")
    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
        db = New DbHelper("lineas")
    End Sub

    Public Sub New(ByVal _id As Integer)
        db = New DbHelper("lineas")
        id = _id
        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("nombre")
    End Sub

    Public Function getLineas() As DataTable
        Try
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try

    End Function

    Friend Sub insertar()
        Try
            If nombre <> "" Then
                Dim lineas = getLineas()
                If lineas.Select("NOMBRE='" & nombre & "'").Count > 0 Then
                    Throw New Exception("YA EXISTE UNA LINEA CON ESE NOMBRE")
                Else
                    db.insertar(Me)
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class

