Imports System.Data

Public Class Cliente
    Public id As Integer
    Public nombre As String
    Public tel As String
    Public mail As String
    Public direccion As String
    Public ciudad As String
    Public provincia As String
    Public datos As DataTable
    Private db As New DbHelper("CLIENTES")

    Public Sub New()
        db = New DbHelper("CLIENTES")
    End Sub

    Public Sub New(ByVal _id As Integer)
        id = _id
        db = New DbHelper("CLIENTES")
        Dim t = db.getRow(_id)
        nombre = t.Rows(0)("NOMBRE").trim()
        tel = t.Rows(0)("TELEFONO").trim()
        mail = t.Rows(0)("MAIL").trim()
        direccion = t.Rows(0)("DIRECCION").trim()
        ciudad = t.Rows(0)("CIUDAD").trim()
        provincia = t.Rows(0)("PROVINCIA").trim()
        datos = t
    End Sub

    Public Sub New(_id As Integer, _nombre As String, _tel As String, _mail As String, _dir As String, _ciudad As String, _prov As String)
        id = _id
        nombre = _nombre
        tel = _tel
        mail = _mail
        direccion = _dir
        ciudad = _ciudad
        provincia = _prov
        db = New DbHelper("clientes")
    End Sub

    Public Function getClientes() As DataTable
        Return db.getTable()
    End Function

    Public Sub actualizar()
        db.actualizarCliente(Me)
    End Sub

End Class