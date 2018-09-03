Imports System.Data
Public Class Hoja
    Public id As Integer
    Public nombre As String
    Dim db As New DbHelper("hojas")

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(ByVal _id As Integer)
        id = _id
        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("nombre")
    End Sub

    Public Function getHojas() As DataTable
        Try
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Sub insertar()
        Try
            If nombre <> "" Then
                Dim hojas = getHojas()
                If hojas.Select("NOMBRE='" & nombre & "'").Count > 0 Then
                    Throw New Exception("YA EXISTE UNA HOJA CON ESE NOMBRE")
                Else
                    db.insertar(Me)
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
