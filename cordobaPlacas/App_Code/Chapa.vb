Imports System.Data
Public Class Chapa
    Public id As Integer
    Public nombre As String
    Public codMat As Integer
    Private db As New DbHelper("chapas")

    Public Sub New()

    End Sub

    Public Sub New(ByVal _id As Integer, ByVal _nombre As String)
        id = _id
        nombre = _nombre
    End Sub

    Public Sub New(ByVal _id As Integer)
        id = _id
        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("nombre")
        codMat = t.Rows(0)("COD_MAT")
    End Sub

    Public Function getChapas() As DataTable
        Try
            Return db.getTable()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Sub insertar()
        Try
            If nombre <> "" Then
                Dim chapas = getChapas()
                If chapas.Select("NOMBRE='" & nombre & "'").Count > 0 Then
                    Throw New Exception("YA EXISTE UNA CHAPA CON ESE NOMBRE")
                Else
                    db.insertar(Me)
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
