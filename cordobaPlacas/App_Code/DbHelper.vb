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
    End Sub

    Sub New()
        cnn = New SqlConnection(conStr)
        cmd = New SqlCommand()
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

            cnn.Open()
            cmd.ExecuteNonQuery()

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
        da.Fill(ds, table)

        Return ds.Tables("pedidos")

        'dt.Columns.Add("Nro Pedido", GetType(Integer))
        'dt.Columns.Add("Cliente", GetType(String))
        'dt.Columns.Add("Cantidad", GetType(Integer))
        'dt.Columns.Add("Precio", GetType(Decimal))
        'dt.Columns.Add("Estado", GetType(String))
        'dt.Columns.Add("Fecha Recibido", GetType(String))
        'dt.Columns.Add("Ultima Modificacion", GetType(String))
        'dt.Columns.Add("Fecha entregado", GetType(String))

        'For Each r As DataRow In rt.Rows
        '    Dim newRow = dt.NewRow()
        '    Dim fechaRecibido As Date
        '    Dim fechaModificado As Date
        '    Dim fechaEntregado As Date
        '    newRow("Nro Pedido") = r("Nro Pedido")
        '    newRow("Cliente") = r("Cliente")
        '    newRow("Cantidad") = r("Cantidad")
        '    newRow("Precio") = r("Precio")
        '    newRow("Estado") = r("Estado")
        '    fechaRecibido = r.Item(5)
        '    newRow("Fecha Recibido") = fechaRecibido.ToShortDateString()

        '    If IsDBNull(r.Item(6)) Then
        '        newRow("Ultima Modificacion") = r("Ultima Modificacion")
        '    Else
        '        fechaModificado = r.Item(6)
        '        newRow("Ultima Modificacion") = fechaModificado.ToShortDateString()
        '    End If

        '    If IsDBNull(r.Item(7)) Then
        '        newRow("Fecha entregado") = r("Fecha entregado")
        '    Else
        '        fechaEntregado = r.Item(7)
        '        newRow("Fecha entregado") = fechaEntregado.ToShortDateString()
        '    End If

        '    dt.Rows.Add(newRow)
        'Next

        'Return dt

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

    Public Sub actualizarItem(ByVal _idItem As Integer, ByVal _idHoja As Integer, ByVal _idMarco As Integer, ByVal _idMadera As Integer, ByVal _idChapa As Integer, ByVal _cant As Integer, ByVal _precio As Decimal, _idMano As Integer, ByVal _idLinea As Integer, ByVal _estado As Integer)
        Dim strPrecio = _precio.ToString()
        strPrecio = strPrecio.Replace(",", ".")

        Dim query = String.Format("UPDATE {0} SET idHoja={1}, idMarco={2}, idMadera={3}, idChapa={4}, cantidad={5}, precio={6}, idMano={7}, idLinea={8}, idEstado={9} WHERE id={10}", table, _idHoja, _idMarco, _idMadera, _idChapa, _cant, strPrecio, _idMano, _idLinea, _estado, _idItem)
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
        cmd.Parameters.AddWithValue("@ID_PRODUCTO", _item.producto.id)
        cmd.Parameters.AddWithValue("@CANT", _item.cant)
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
        Dim strPrecio = _pedido.cantTotal.ToString()

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



End Class
