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
    Public Enum tablas
        CHAPAS
        MADERAS
    End Enum

    Sub New(ByVal _table As String)
        table = _table
        cnn = New SqlConnection(conStr)
        cmd = New SqlCommand()
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        cmd.Connection = cnn
    End Sub

    Friend Sub eliminarPieza(_idProducto As Integer, _idPieza As Integer)
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = String.Format("DELETE FROM DESPIECE WHERE ID_PROD={0} AND ID_PIEZA={1}", _idProducto, _idPieza)

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Function getExcluidas(_tabla As tablas, _id As Integer) As DataTable
        cmd.CommandText = String.Format("SELECT * FROM {0} WHERE ID <> {1}", _tabla, _id)
        cmd.CommandType = CommandType.Text

        Try
            da.Fill(ds, _tabla)
            Return ds.Tables(_tabla)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Sub insertarPiezaProducto(_idProducto As Integer, _idPieza As Integer, _consumo As Decimal)
        Dim strConsumo = _consumo.ToString

        strConsumo = strConsumo.Replace(",", ".")
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = String.Format("INSERT INTO DESPIECE VALUES({0}, {1}, {2})", _idProducto, _idPieza, strConsumo)

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub actualizarDespiece(_idProducto As Integer, _idPieza As Integer, _consumo As Decimal)
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_UPDATE_DESPIECE"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@ID_PROD", _idProducto)
            cmd.Parameters.AddWithValue("@ID_PIEZA", _idPieza)
            cmd.Parameters.AddWithValue("@CONSUMO", _consumo)

            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS:    " & ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Sub New()
        cnn = New SqlConnection(conStr)
        cmd = New SqlCommand()
        cmd.Connection = cnn
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
    End Sub

    Friend Function getReporte(_idPedido As String, _tipo As GestorDatos.reportes, Optional _stock As Integer = 0) As DataTable
        Dim query As String
        cmd.CommandType = CommandType.Text

        If _tipo = GestorDatos.reportes.remito Then
            query = "SELECT * FROM VW_REMITOS WHERE PEDIDO=" & _idPedido
        ElseIf _tipo = GestorDatos.reportes.ordenTrabajo Then
            query = "SELECT * FROM VW_ORDENES WHERE PEDIDO=" & _idPedido
        ElseIf _tipo = GestorDatos.reportes.etiquetaDeposito Then
            query = "SELECT * FROM VW_ETIQUETAS WHERE ID=" & _idPedido
        ElseIf _tipo = GestorDatos.reportes.etiquetaDepositoUnica Then
            query = "SELECT * FROM VW_ETIQUETAS_SIMPLE WHERE ID=" & _idPedido
        ElseIf GestorDatos.reportes.etiquetaDepositoInterna Then
            query = "SELECT * FROM VW_ETIQUETAS_INTERNAS WHERE ID=" & _idPedido
        ElseIf _tipo = GestorDatos.reportes.etiquetaDepositoStock Then
            query = "SELECT * FROM VW_ETIQUETAS_STOCK WHERE ID=" & _idPedido
        End If

        cmd.CommandText = query

        Try
            da.Fill(ds, "REMITO")
            Return ds.Tables("REMITO")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS:  " & ex.Message)
        End Try
    End Function

    Friend Sub eliminarMaterial(_id As Integer)
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "DELETE FROM MATERIALES WHERE ID=" & _id

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub insertMaterial(_nombre As String, _unidad As String)
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = String.Format("INSERT INTO MATERIALES (NOMBRE, UNIDAD) VALUES ('{0}', '{1}')", _nombre, _unidad)

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try

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

    Friend Function buscarPedidos(_idLinea As Object, _idChapa As Object, _idHoja As Object, _idMarco As Object, _idMadera As Object, _idMano As Object) As DataTable
        Dim query = "SELECT ID, LINEA, CHAPA, HOJA, MARCO, MADERA, MANO, PRECIO, STOCK FROM VW_PRODUCTOS WHERE "
        Dim firstParam = True

        'LINEA
        If _idLinea <> 0 Then
            If Not firstParam Then
                query = query + " AND "
            End If

            query = query & "ID_LINEA=" & _idLinea.ToString()
            firstParam = False
        End If

        'CHAPA
        If _idChapa <> "" Then
            If Not firstParam Then
                query = query + " AND "
            End If
            query = query & "ID_CHAPA=" & _idChapa.ToString()
            firstParam = False
        End If

        'HOJA
        If _idHoja <> "" Then
            If Not firstParam Then
                query = query + " AND "
            End If
            query = query & "ID_HOJA=" & _idHoja.ToString()
        End If

        'MARCO
        If _idMarco <> "" Then
            If Not firstParam Then
                query = query + " AND "
            End If
            query = query & "ID_MARCO=" & _idMarco.ToString
            firstParam = False
        End If

        'MADERA
        If _idMadera <> "" Then
            If Not firstParam Then
                query = query + " AND "
            End If
            query = query & "ID_MADERA=" & _idMadera.ToString
            firstParam = False
        End If

        'MANO
        If _idMano <> "" Then
            If Not firstParam Then
                query = query + " AND "
            End If
            query = query & "ID_MANO=" & _idMano.ToString
            firstParam = False
        End If

        cmd.Connection = cnn
        cmd.CommandText = query
        Try
            da.Fill(ds, "PRODUCTOS")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

        Return ds.Tables("PRODUCTOS")

    End Function

    Friend Sub insertar(_cliente As Cliente)
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

    Friend Sub consumirMateriales(_piezas As DataTable, _cant As Double, Optional _depo As Boolean = False)

        cmd.Connection = cnn
        cmd.CommandText = "SP_UPDATE_STOCK_MATERIAL"
        cmd.CommandType = CommandType.StoredProcedure

        Try
            cnn.Open()
            For Each r As DataRow In _piezas.Rows

                cmd.Parameters.Clear()
                If _depo Then
                    cmd.Parameters.AddWithValue("@DEPO", 1)
                Else
                    cmd.Parameters.AddWithValue("@DEPO", 0)
                End If

                cmd.Parameters.AddWithValue("@ID_PIEZA", r("ID_PIEZA"))
                cmd.Parameters.AddWithValue("@CONSUMO", r("consumo"))
                cmd.Parameters.AddWithValue("@CANT", _cant)

                cmd.ExecuteNonQuery()
            Next

        Catch ex As SqlException
            Throw
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

    Public Sub updateMaterial(_idpieza As Integer, _cant As Decimal)
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_UPDATE_MATERIALES"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@ID_PIEZA", _idpieza)
            cmd.Parameters.AddWithValue("@CANT", _cant)

            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try

    End Sub

    Public Sub insertarItem(_idProducto As Integer, _idPedido As Integer, _cant As Integer, _monto As Decimal, _stock As Integer)

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_INSERT_ITEM"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
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

    Public Function insertar(_prod As Producto) As Integer
        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_INSERT_PRODUCTO"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@ID_LINEA", _prod.linea.id)
            cmd.Parameters.AddWithValue("@ID_CHAPA", _prod.chapa.id)
            cmd.Parameters.AddWithValue("@ID_HOJA", _prod.hoja.id)
            cmd.Parameters.AddWithValue("@ID_MARCO", _prod.marco.id)
            cmd.Parameters.AddWithValue("@ID_MADERA", _prod.madera.id)
            cmd.Parameters.AddWithValue("@ID_MANO", _prod.mano.id)
            cmd.Parameters.AddWithValue("@PRECIO", _prod.precioUnitario)

            cnn.Open()
            Return cmd.ExecuteScalar()

        Catch ex As SqlException
            Throw
        Finally
            cnn.Close()
        End Try



    End Function

    Public Sub insertar(_item As Item)

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_INSERT_ITEM"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", _item.getProducto().id)
            cmd.Parameters.AddWithValue("@ID_PEDIDO", _item.idPedido)
            cmd.Parameters.AddWithValue("@CANT", _item.getCant())
            cmd.Parameters.AddWithValue("@MONTO", _item.monto)
            cmd.Parameters.AddWithValue("@STOCK", _item.stock)

            cnn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Function insertar(_pedido As Pedido) As Integer

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_INSERT_PEDIDO"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@CLIENTE", _pedido.cliente.id)
            cmd.Parameters.AddWithValue("@CANT", _pedido.cantTotal)
            cmd.Parameters.AddWithValue("@PRECIO", _pedido.precioTotal)

            cnn.Open()

            Return cmd.ExecuteScalar()

        Catch ex As SqlException
            Throw
        Finally
            cnn.Close()
        End Try
    End Function

    Public Sub insertDespiece(_idProducto As Integer, _despiece As DataTable)
        cmd.CommandType = CommandType.Text
        cnn.Open()

        Try
            For Each r As DataRow In _despiece.Rows
                Dim query = String.Format("INSERT INTO DESPIECE VALUES ({0}, {1}, {2})", _idProducto, r("ID_PIEZA"), r("CONSUMO"))
                cmd.CommandText = query
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Function getItemsBusqueda(_idPedido As Integer) As DataTable
        Dim query = "SELECT * FROM VW_ITEMS WHERE ID_PEDIDO=" & _idPedido

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "ITEMS")
            Return ds.Tables("ITEMS")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
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
        Dim query = "select P.id AS 'Nro Pedido', C.nombre as Cliente, P.cant_total as Cantidad, P.precio_total as Precio, E.ID as ID_ESTADO, E.nombre as Estado, P.fecha_recibido as 'Fecha Recibido', 
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

    Public Sub actualizar(_item As Item)
        Dim strPrecio = _item.monto.ToString()

        strPrecio = strPrecio.Replace(",", ".")


        cmd.Connection = cnn
        cmd.CommandText = "SP_UPDATE_ITEM"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ID_ITEM", _item.id)
        cmd.Parameters.AddWithValue("@ID_PRODUCTO", _item.getProducto().id)
        cmd.Parameters.AddWithValue("@CANT", _item.getCant)
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

    Public Sub actualizar(_pedido As Pedido)
        Dim strPrecio = _pedido.precioTotal.ToString()

        strPrecio = strPrecio.Replace(",", ".")


        cmd.Connection = cnn
        cmd.CommandText = "SP_UPDATE_PEDIDO"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Clear()
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

    Public Sub actualizar(_producto As Producto)
        Dim strPrecio = _producto.precioUnitario.ToString()

        strPrecio = strPrecio.Replace(",", ".")


        cmd.Connection = cnn
        cmd.CommandText = "SP_UPDATE_PRODUCTO"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@ID_PRODUCTO", _producto.id)
        cmd.Parameters.AddWithValue("@PRECIO", _producto.precioUnitario)
        cmd.Parameters.AddWithValue("@STOCK", _producto.stock)

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw
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

    Public Function getDespiece(_pedido As Pedido) As DataTable

        ds = New DataSet

        cmd.Connection = cnn
        cmd.CommandText = "SP_DESPIECE_PEDIDO"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@ID_PEDIDO", _pedido.id)

        Try
            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getDespiece(_prod As Producto) As DataTable

        ds = New DataSet

        cmd.Connection = cnn
        cmd.CommandText = "SP_GET_MATERIALES"
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@ID_CHAPA", _prod.chapa.id)
        cmd.Parameters.AddWithValue("@ID_MADERA", _prod.madera.id)

        Try
            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")

        Catch ex As SqlException
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function buscar(_cliente As Cliente) As DataTable
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

    Public Function getProductos() As DataTable
        Dim query = "SELECT * FROM VW_PRODUCTOS"

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "PRODUCTOS")
            Return ds.Tables("PRODUCTOS")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function buscar(_producto As Producto) As DataTable
        ds = New DataSet

        Try
            cmd.Connection = cnn
            cmd.CommandText = "SP_GET_PRODUCTO"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@LINEA", _producto.linea.id)
            cmd.Parameters.AddWithValue("@CHAPA", _producto.chapa.id)
            cmd.Parameters.AddWithValue("@HOJA", _producto.hoja.id)
            cmd.Parameters.AddWithValue("@MARCO", _producto.marco.id)
            cmd.Parameters.AddWithValue("@MADERA", _producto.madera.id)
            cmd.Parameters.AddWithValue("@MANO", _producto.mano.id)

            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")

        Catch ex As SqlException
            Throw
        End Try
    End Function
End Class