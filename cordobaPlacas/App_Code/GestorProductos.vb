Imports System.Data
Public Class GestorProductos
    Public producto As Producto
    Dim despiece As DataTable
    Dim gd As GestorDatos
    Dim db As DbHelper
    Public Sub New(_idProducto As Integer)
        gd = New GestorDatos
        producto = New Producto(_idProducto)
        despiece = gd.getDespieceProducto(_idProducto)
    End Sub

    Public Sub New(hoja As Hoja, marco As Marco, madera As Madera, chapa As Chapa, mano As Mano, linea As Linea)
        despiece = New DataTable
        producto = New Producto(hoja, marco, madera, chapa, mano, linea)
        db = New DbHelper("productos")
        despiece.Columns.Add("ID_PIEZA", GetType(Integer))
        despiece.Columns.Add("CONSUMO", GetType(Decimal))
    End Sub

    Public Sub eliminarPieza(_idPieza As Integer)
        Try
            db = New DbHelper()
            db.eliminarPieza(producto.id, _idPieza)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub agregarPieza(_idPieza As Integer, _consumo As Decimal)
        db = New DbHelper()

        For Each r As DataRow In despiece.Rows
            If r("ID_PIEZA") = _idPieza Then
                Throw New Exception("La pieza ya existe en el despiece de este producto")
            End If
        Next

        Try
            db.insertarPiezaProducto(producto.id, _idPieza, _consumo)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Friend Sub actualizarDespiece(_idPieza As Integer, _consumo As Decimal)
        db = New DbHelper()
        db.actualizarDespiece(producto.id, _idPieza, _consumo)
    End Sub

    Public Sub agregarProducto()
        Try
            Dim testProd = New Producto(producto.hoja, producto.marco, producto.madera, producto.chapa, producto.mano, producto.linea)
            If testProd.id = 0 Then
                producto.insertar()
            Else
                Throw New Exception("YA EXISTE UN PRODUCTO CON ESTAS CARACTERISTICAS")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub setDespiece(_gr As GridView)

        For Each r As GridViewRow In _gr.Rows
            Dim txtconsumo As TextBox
            txtconsumo = r.FindControl("txtConsumo")
            Dim consumo = txtconsumo.Text.Trim()



            If consumo > 0 Then
                Dim idPieza = Convert.ToInt32(_gr.DataKeys(r.RowIndex).Value.ToString)
                Dim resultado = despiece.Select(String.Format("ID_PIEZA ={0}", idPieza))

                Dim d As DataRow
                d = despiece.NewRow

                d("ID_PIEZA") = idPieza
                d("CONSUMO") = consumo

                despiece.Rows.Add(d)

            End If
        Next
        producto.despiece = despiece
    End Sub
End Class
