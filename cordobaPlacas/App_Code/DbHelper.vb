Imports System.Data

Imports System.Data.SqlClient
Imports cordobaPlacas

Public Class DbHelper
    Private cnn As SqlConnection
    Private cmd As SqlCommand
    Private da As SqlDataAdapter
    Private ds As DataSet
    Private table As String
    Private conStr As String = "Data Source=USER-PC;Initial Catalog=cbaPlacas;Integrated Security=True"

    Sub New(ByVal _table As String)
        table = _table
        cnn = New SqlConnection(conStr)
        cmd = New SqlCommand()
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        cmd.Connection = cnn
    End Sub

    Sub New()
        cnn = New SqlConnection(conStr)
        cmd = New SqlCommand()
        cmd.Connection = cnn
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
    End Sub

    Public Function getTable() As DataTable
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM " & table
            da.Fill(ds, table)
            Return ds.Tables(table)

        Catch ex As SqlException
            Throw
        End Try
    End Function

    Friend Function getPedidosModificar() As DataTable

        Dim query = "SELECT * FROM VW_PEDIDOS_MODIFICAR"
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "PEDIDOS_MODIFICAR")
            Return ds.Tables("PEDIDOS_MODIFICAR")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getRow(ByVal index As Integer) As DataTable
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM " & table & " WHERE ID=" & index.ToString()
            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Friend Sub actualizarCliente(_cliente As Cliente)
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_UPDATE_CLIENTE"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@ID", _cliente.id)
            cmd.Parameters.AddWithValue("@NOMBRE", _cliente.nombre)
            cmd.Parameters.AddWithValue("@TELEFONO", _cliente.tel)
            cmd.Parameters.AddWithValue("@MAIL", _cliente.mail)
            cmd.Parameters.AddWithValue("@DIRECCION", _cliente.direccion)
            cmd.Parameters.AddWithValue("@CIUDAD", _cliente.ciudad)
            cmd.Parameters.AddWithValue("@PROVINCIA", _cliente.provincia)
            cmd.Parameters.AddWithValue("@CUIT", _cliente.CUIT)

            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS:    " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub insertCliente(_cliente As Cliente)
        Try
            String.Format("SELECT COUNT(CUIT) FROM CLIENTES WHERE CUIT={0}", _cliente.CUIT)
            cmd.Connection = cnn
            cmd.CommandText = String.Format("SELECT NOMBRE FROM CLIENTES WHERE CUIT='{0}'", _cliente.CUIT)
            cmd.CommandType = CommandType.Text

            Dim dt = New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Throw New Exception(String.Format("El CUIT ya existe para el cliente {0}", dt(0)(0)))
            Else

                cmd.CommandText = "SP_INSERT_CLIENTE"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@NOMBRE", _cliente.nombre)
                cmd.Parameters.AddWithValue("@TELEFONO", _cliente.tel)
                cmd.Parameters.AddWithValue("@MAIL", _cliente.mail)
                cmd.Parameters.AddWithValue("@DIRECCION", _cliente.direccion)
                cmd.Parameters.AddWithValue("@CIUDAD", _cliente.ciudad)
                cmd.Parameters.AddWithValue("@PROVINCIA", _cliente.provincia)
                cmd.Parameters.AddWithValue("@CUIT", _cliente.CUIT)

                cnn.Open()
                cmd.ExecuteNonQuery()
            End If

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS:    " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub
    Friend Sub updateStock(_idItem As Integer, _stock As Integer)
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_UPDATE_STOCK"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@STOCK", _stock)
            cmd.Parameters.AddWithValue("@ID_ITEM", _idItem)

            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub consumirMateriales(_piezas As DataTable, _cant As Double, Optional _depo As Boolean = False)
        Dim query As String
        query = "UPDATE MATERIALES SET "
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text

        If _depo Then
            query = query & "STOCK_RESERVADO=STOCK_RESERVADO-[CANT] WHERE ID="
        Else
            query = query & "STOCK_RESERVADO=STOCK_RESERVADO+[CANT], STOCK_DISPONIBLE= STOCK_DISPONIBLE-[CANT] WHERE ID="
        End If

        Try
            cnn.Open()
            For Each r As DataRow In _piezas.Rows
                Dim formatQuery = query
                Dim cant = _cant * r("CONSUMO")
                cant = cant.ToString().Replace(",", ".")
                formatQuery = formatQuery.Replace("[CANT]", cant)

                formatQuery = formatQuery & r("ID_PIEZA")
                cmd.CommandText = formatQuery
                cmd.ExecuteNonQuery()
            Next

        Catch ex As SqlException
            Throw
        Finally
            cnn.Close()
        End Try


    End Sub

    Public Sub insertarItem(ByVal _hoja As Integer, ByVal _marco As Integer, ByVal _madera As Integer, ByVal _chapa As Integer, ByVal _cant As Integer, ByVal _precio As Decimal, ByVal _mano As Integer, ByVal _pedido As Integer, ByVal _idLinea As Integer)
        Dim strPrecio = _precio.ToString
        strPrecio = strPrecio.Replace(",", ".")
        Dim query = String.Format("INSERT INTO dbo.items (idHoja, idMarco, idMadera, idChapa, cantidad, precio, idMano, idPedido, idLinea) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})", _hoja, _marco, _madera, _chapa, _cant, strPrecio, _mano, _pedido, _idLinea)
        Try
            cmd.Connection = cnn
            cmd.CommandText = query
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Sub insertarItem(_idProducto As Integer, _idPedido As Integer, _cant As Integer, _monto As Decimal, _stock As Integer)

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_INSERT_ITEM"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@ID_PRODUCTO", _idProducto)
            cmd.Parameters.AddWithValue("@ID_PEDIDO", _idPedido)
            cmd.Parameters.AddWithValue("@CANT", _cant)
            cmd.Parameters.AddWithValue("@MONTO", _monto)
            cmd.Parameters.AddWithValue("@STOCK", _stock)

            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Function insertPedido(ByVal _cliente As Integer, ByVal _cant As Integer, ByVal _precio As Decimal) As Integer

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_INSERT_PEDIDO"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@CLIENTE", _cliente)
            cmd.Parameters.AddWithValue("@CANT", _cant)
            cmd.Parameters.AddWithValue("@PRECIO", _precio)

            cnn.Open()

            Return cmd.ExecuteScalar()

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        Finally
            cnn.Close()
        End Try

    End Function

    Public Function getRange(ByVal _column As String, ByVal _value As String) As DataTable
        Try
            cmd.Connection = cnn
            cmd.CommandText = String.Format("SELECT * FROM {0} WHERE {1}={2}", table, _column, _value)
            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getPedidos(ByVal _cliente As Integer) As DataTable
        Try
            cmd.Connection = cnn
            cmd.CommandText = String.Format("SELECT P.ID, P.FECHA, P.ESTADO FROM PEDIDOS P INNER JOIN clientes C ON p.cliente = C.id WHERE P.cliente={0}", _cliente.ToString())
            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getItems(ByVal _pedido As Integer) As DataTable
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_ITEMS_PEDIDO"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@idPedido", _pedido)

            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getItems(_pedido As Integer, _estado As Estado, Optional _stock As Boolean = False) As DataTable
        Try
            cmd.Connection = cnn
            If _stock Then
                cmd.CommandText = "SP_ITEMS_PEDIDO_ESTADO_STOCK"
            Else
                cmd.CommandText = "SP_ITEMS_PEDIDO_ESTADO"
            End If


            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@ID_PEDIDO", _pedido)
            cmd.Parameters.AddWithValue("@ID_ESTADO", _estado.id)

            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getItems(_pedido As Integer, Optional _enCurso As Boolean = False) As DataTable
        Try
            cmd.Connection = cnn
            If _enCurso Then
                cmd.CommandText = "SP_ITEMS_PEDIDO_ENCURSO"
            End If

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@ID_PEDIDO", _pedido)

            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getItemsModificar(_pedido As Integer) As DataTable
        Try
            cmd.Connection = cnn

            cmd.CommandText = "SP_ITEMS_PEDIDO_MODIFICAR"

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@idPedido", _pedido)

            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function buscarPedidos(ByVal _nroPedido As Integer, _fecRecDesde As Date, ByVal _fecRecHasta As Date, _fecModDesde As Date,
                                  ByVal _fecModHasta As Date, ByVal _cliente As Object, ByVal _estado As Object) As DataTable
        Dim dt = New DataTable
        Dim query = "select P.id AS 'Nro Pedido', C.nombre as Cliente, P.cant_total as Cantidad, P.precio_total as Precio, E.nombre as Estado, P.fecha_recibido as 'Fecha Recibido', 
                     P.fecha_modificado as 'Ultima Modificacion', P.fecha_entregado as 'Fecha entregado' from pedidos P 
                     inner join clientes C on p.id_cliente = c.id
                     inner join estados E on E.id = P.id_estado
                     where "
        Dim firstParam = True
        'NUMERO DE PEDIDO
        If _nroPedido Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & "P.id=" & _nroPedido.ToString
            firstParam = False
        End If

        'CLIENTE
        If Not IsNothing(_cliente) Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & "P.id_cliente=" & _cliente.ToString
            firstParam = False
        End If

        'ESTADO
        If Not IsNothing(_estado) Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & "P.id_estado = " & _estado
        Else
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & "P.id_estado not in (5, 6, 7)" 'estado no cancelado, entregado
            firstParam = False
        End If

        'FECHA RECEPCION PEDIDO
        If _fecRecDesde <> Date.MinValue And _fecRecHasta <> Date.MinValue Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & " P.fecha_recibido BETWEEN '" & _fecRecDesde & "' AND '" & _fecRecHasta & "'"
            firstParam = False

        ElseIf _fecRecHasta <> Date.MinValue Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & " P.fecha_recibido <= '" & _fecRecHasta & "'"
            firstParam = False

        ElseIf _fecRecDesde <> Date.MinValue Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & " P.fecha_recibido >= '" & _fecRecDesde & "'"
            firstParam = False
        End If

        'FECHA ULTIMA MODIFICACION
        If _fecModDesde <> Date.MinValue And _fecModHasta <> Date.MinValue Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & " P.fecha_modificado BETWEEN '" & _fecModDesde & "' AND '" & _fecModHasta & "'"
            firstParam = False

        ElseIf _fecModHasta <> Date.MinValue Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & " P.fecha_modificado <= '" & _fecModHasta & "'"
            firstParam = False

        ElseIf _fecModDesde <> Date.MinValue Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & " P.fecha_modificado >= '" & _fecModDesde & "'"
            firstParam = False
        End If

        cmd.Connection = cnn
        cmd.CommandText = query
        Try
            da.Fill(ds, table)
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

        Return ds.Tables("pedidos")
    End Function

    Public Sub updateById(ByVal _id As Integer, ByVal _col As String, ByVal _val As String)
        Dim query As String

        If IsNumeric(_val) Then
            _val = _val.Replace(",", ".")
            query = String.Format("UPDATE {0} SET {1} = {2} WHERE id={3}", table, _col, _val, _id)
        Else
            query = String.Format("UPDATE {0} SET {1} = '{2}' WHERE id={3}", table, _col, _val, _id)
        End If

        Try
            cmd.Connection = cnn
            cmd.CommandText = query
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Sub actualizarItem(_item As Item)
        Dim strPrecio = _item.monto.ToString()

        strPrecio = strPrecio.Replace(",", ".")


        cmd.Connection = cnn
        cmd.CommandText = "SP_UPDATE_ITEM"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ID_ITEM", _item.id)
        cmd.Parameters.AddWithValue("@ID_PRODUCTO", _item.getProducto().id)
        cmd.Parameters.AddWithValue("@CANT", _item.getcant)
        cmd.Parameters.AddWithValue("@MONTO", _item.monto)
        cmd.Parameters.AddWithValue("@ID_ESTADO", _item.getEstado().id)
        cmd.Parameters.AddWithValue("@MARCO_TER", _item.marcosTerminados)
        cmd.Parameters.AddWithValue("@HOJA_TER", _item.hojasTerminadas)
        cmd.Parameters.AddWithValue("@ENSAMBLADO", _item.getEnsamblados())
        cmd.Parameters.AddWithValue("@EN_DEPOSITO", _item.getEnDeposito())

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Function getStock(ByVal _idHoja As Integer, ByVal _idMarco As Integer, ByVal _idMadera As Integer, ByVal _idChapa As Integer, ByVal _idMano As Integer, ByVal _idLinea As Integer) As DataTable

        Try
            cmd.Connection = cnn
            cmd.CommandText = "sp_getStock"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@idHoja", _idHoja)
            cmd.Parameters.AddWithValue("@idMarco", _idMarco)
            cmd.Parameters.AddWithValue("@idMadera", _idMadera)
            cmd.Parameters.AddWithValue("@idChapa", _idChapa)
            cmd.Parameters.AddWithValue("@idMano", _idMano)
            cmd.Parameters.AddWithValue("@idLinea", _idLinea)

            da.Fill(ds, table)

            Return ds.Tables(table)
        Catch ex As SqlException
            Throw
        End Try
    End Function

    Friend Function getItemsEnsamblados(_id As Integer) As DataTable
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_ITEMS_PEDIDO_ENSAMBLADOS"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@ID_PEDIDO", _id)

            da.Fill(ds, "ENSAMBLADOS")

            Return ds.Tables("ENSAMBLADOS")
        Catch ex As SqlException
            Throw
        End Try
    End Function

    Public Function fillCombo(_spName As String, _IdLinea As Integer) As DataTable
        Try
            ds = New DataSet()
            cmd.Connection = cnn
            cmd.CommandText = _spName
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@LINEA", _IdLinea)

            da.Fill(ds, "tabla_combos")

            Return ds.Tables("tabla_combos")
        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getProducto(_linea As Integer, _chapa As Integer, _hoja As Integer, _marco As Integer, _madera As Integer, _mano As Integer) As DataTable
        ds = New DataSet

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_GET_PRODUCTO"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@LINEA", _linea)
            cmd.Parameters.AddWithValue("@CHAPA", _chapa)
            cmd.Parameters.AddWithValue("@HOJA", _hoja)
            cmd.Parameters.AddWithValue("@MARCO", _marco)
            cmd.Parameters.AddWithValue("@MADERA", _madera)
            cmd.Parameters.AddWithValue("@MANO", _mano)

            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getProducto(_id As Integer) As DataTable
        ds = New DataSet

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_GET_PRODUCTO_POR_ID"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@ID", _id)

            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Sub actualizarPedido(_pedido As Pedido)
        Dim strPrecio = _pedido.precioTotal.ToString()

        strPrecio = strPrecio.Replace(",", ".")


        cmd.Connection = cnn
        cmd.CommandText = "SP_UPDATE_PEDIDO"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ID_PEDIDO", _pedido.id)
        cmd.Parameters.AddWithValue("@ID_CLIENTE", _pedido.cliente.id)
        cmd.Parameters.AddWithValue("@CANT_TOTAL", _pedido.cantTotal)
        cmd.Parameters.AddWithValue("@PRECIO_TOTAL", strPrecio)
        cmd.Parameters.AddWithValue("@ID_ESTADO", _pedido.estado.id)

        If _pedido.entregado <> Date.MinValue Then
            cmd.Parameters.AddWithValue("@FECHA_ENTREGADO", _pedido.entregado)
        End If

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Function getDespiece(_idProducto As Integer) As DataTable

        ds = New DataSet

        cmd.Connection = cnn
        cmd.CommandText = "SP_DESPIECE_PRODUCTO"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ID_PROD", _idProducto)

        Try
            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function buscarClientes(_cliente As Cliente) As DataTable
        Dim query = "SELECT * FROM CLIENTES WHERE "
        Dim firstParam = True

        If _cliente.ciudad <> "" Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & String.Format("CIUDAD LIKE '%{0}%'", _cliente.ciudad)
            firstParam = False
        End If

        If _cliente.CUIT <> "" Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & String.Format("CUIT LIKE '%{0}%'", _cliente.CUIT)
            firstParam = False
        End If

        If _cliente.direccion <> "" Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & String.Format("DIRECCION LIKE '%{0}%'", _cliente.direccion)
            firstParam = False
        End If

        If _cliente.mail <> "" Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & String.Format("MAIL LIKE '%{0}%'", _cliente.mail)
            firstParam = False
        End If

        If _cliente.nombre <> "" Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & String.Format("NOMBRE LIKE '%{0}%'", _cliente.nombre)
            firstParam = False
        End If

        If _cliente.provincia <> "" Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & String.Format("PROVINCIA LIKE '%{0}%'", _cliente.provincia)
            firstParam = False
        End If

        If _cliente.tel <> "" Then
            If Not firstParam Then
                query = query & " AND "
            End If
            query = query & String.Format("TELEFONO LIKE '%{0}%'", _cliente.tel)
            firstParam = False
        End If

        'ELIMINA WHERE SI NO SE PASARON PARAMETROS
        If firstParam Then
            query = query.Replace(" WHERE ", "")
        End If

        cmd.CommandText = query

        Try
            da.Fill(ds, table)
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

        Return ds.Tables("CLIENTES")
    End Function

    Public Function getRegistroItem(_idItem As Integer) As DataTable
        Dim query = "SELECT FECHA, ENTRADA FROM REGISTRO_ITEMS WHERE ID_ITEM=" & _idItem

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "REGISTRO_ITEMS")
            Return ds.Tables("REGISTRO_ITEMS")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getRegistroPedido(_idPedido As Integer) As DataTable
        Dim query = "SELECT FECHA, ENTRADA FROM REGISTRO_PEDIDOS WHERE ID_PEDIDO=" & _idPedido

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "REGISTRO_PEDIDOS")
            Return ds.Tables("REGISTRO_PEDIDOS")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function
End Class
