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

    Friend Sub insertar()
        Try
            If nombre <> "" Then
                Dim manos = getManos()
                If manos.Select("NOMBRE='" & nombre & "'").Count > 0 Then
                    Throw New Exception("YA EXISTE UNA MANO CON ESE NOMBRE")
                Else
                    db.insertar(Me)
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
