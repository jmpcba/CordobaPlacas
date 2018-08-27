Imports System.Data
Imports System.Data.SqlClient
Public Class GestorDatos
    Public chapa As Chapa
    Public marco As Marco
    Public madera As Madera
    Public hoja As Hoja
    Public linea As linea
    Public mano As Mano
    Private db As DbHelper

    Public Enum combos
        estados
        clientes
        unidadMateriales
    End Enum

    Public Enum reportes
        ordenTrabajo
        remito
        compras
        etiquetaDeposito
        etiquetaDepositoUnica
        etiquetaDepositoInterna
        etiquetaDepositoStock
    End Enum

    Public Enum grillas
        productos
        pedidosModificar
    End Enum
    Public Enum tipoItems
        busqueda
        enCurso
        Ensamblados
        modificar
    End Enum

    Public Sub New()
        chapa = New Chapa()
        marco = New Marco()
        madera = New Madera()
        hoja = New Hoja()
        linea = New linea()
        mano = New Mano

    End Sub

    Friend Function actualizarMateriales(_grMateriales As GridView) As List(Of Integer)
        Dim db = New DbHelper()
        Dim lineasActualizadas = New List(Of Integer)

        For Each r As GridViewRow In _grMateriales.Rows
            Dim txt As TextBox
            Dim cant As Decimal
            Dim idPieza As Integer

            txt = r.FindControl("txtAgregar")
            cant = txt.Text.Trim
            idPieza = r.Cells(0).Text

            If cant <> 0 Then
                Try
                    db.updateMaterial(idPieza, cant)
                    lineasActualizadas.Add(r.RowIndex)
                Catch ex As Exception
                    Throw
                End Try
            End If
        Next

        Return lineasActualizadas

    End Function

    Friend Sub getCliente(_idCliente As Integer, _dv As DetailsView)
        Dim cliente = New Cliente(_idCliente)
        _dv.DataSource = cliente.datos
        _dv.DataBind()
    End Sub

    Friend Function getGrilla(_tipo As grillas) As DataTable
        Dim db = New DbHelper
        Dim dt = New DataTable()
        Try
            If _tipo = grillas.pedidosModificar Then
                dt = db.getPedidosModificar()
            ElseIf _tipo = grillas.productos Then
                dt = db.getProductos()
            End If
        Catch ex As Exception
            Throw
        End Try
        Return dt
    End Function

    Friend Sub buscarCliente(_cliente As Cliente, _gv As GridView)
        Dim dt As New DataTable
        db = New DbHelper("CLIENTES")

        Try
            dt = db.buscarClientes(_cliente)
            _gv.DataSource = dt
            _gv.DataBind()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getComboLineas(ByVal _cbLineas As DropDownList)
        Try
            _cbLineas.DataSource = linea.getLineas()
            _cbLineas.DataTextField = "nombre"
            _cbLineas.DataValueField = "id"
            _cbLineas.DataBind()

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub fillCombos(ByVal _cbLinea As DropDownList, ByVal _cbChapa As DropDownList, ByVal _cbMarco As DropDownList, ByVal _cbMadera As DropDownList, ByVal _cbHoja As DropDownList, ByVal _cbMano As DropDownList)
        Dim db = New DbHelper()

        _cbMarco.DataSource = db.fillCombo("SP_COMBO_MARCO", _cbLinea.SelectedValue)
        _cbMadera.DataSource = db.fillCombo("SP_COMBO_MADERA", _cbLinea.SelectedValue)
        _cbChapa.DataSource = db.fillCombo("SP_COMBO_CHAPA", _cbLinea.SelectedValue)
        _cbHoja.DataSource = db.fillCombo("SP_COMBO_HOJA", _cbLinea.SelectedValue)
        _cbMano.DataSource = db.fillCombo("SP_COMBO_MANO", _cbLinea.SelectedValue)

        _cbMano.DataTextField = "nombre"
        _cbMano.DataValueField = "id"

        _cbChapa.DataTextField = "nombre"
        _cbChapa.DataValueField = "id"

        _cbMarco.DataTextField = "nombre"
        _cbMarco.DataValueField = "id"

        _cbMadera.DataTextField = "nombre"
        _cbMadera.DataValueField = "id"

        _cbHoja.DataTextField = "nombre"
        _cbHoja.DataValueField = "id"

        _cbChapa.DataSourceID = Nothing
        _cbMarco.DataSourceID = Nothing
        _cbMadera.DataSourceID = Nothing
        _cbHoja.DataSourceID = Nothing
        _cbMano.DataSourceID = Nothing

        _cbChapa.DataBind()
        _cbMarco.DataBind()
        _cbMadera.DataBind()
        _cbHoja.DataBind()
        _cbMano.DataBind()

    End Sub

    Friend Function buscarProductos(_idLinea, _idChapa, _idHoja, _idMarco, _idMadera, _idMano) As DataTable
        db = New DbHelper()
        Return db.buscarPedidos(_idLinea, _idChapa, _idHoja, _idMarco, _idMadera, _idMano)
    End Function

    Public Sub getCombos(ByVal _cb As DropDownList, ByVal _comboName As combos)
        Try
            If _comboName = combos.estados Then

                Dim estado As New Estado()
                _cb.DataSource = estado.getEstados()
                _cb.DataTextField = "nombre"
                _cb.DataValueField = "id"
                _cb.DataBind()

            ElseIf _comboName = combos.clientes Then

                Dim cliente As New Cliente()
                _cb.DataSource = cliente.getClientes()
                _cb.DataTextField = "nombre"
                _cb.DataValueField = "id"
                _cb.DataBind()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getCombos(ByVal _lst As ListBox, ByVal _comboName As combos)
        Try
            If _comboName = combos.estados Then

                Dim estado As New Estado()
                _lst.DataSource = estado.getEstados()
                _lst.DataTextField = "nombre"
                _lst.DataValueField = "id"
                _lst.DataBind()

            ElseIf _comboName = combos.clientes Then

                Dim cliente As New Cliente()
                _lst.DataSource = cliente.getClientes()
                _lst.DataTextField = "nombre"
                _lst.DataValueField = "id"
                _lst.DataBind()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub mostrarGrillaItems(ByVal _grilla As GridView, ByVal _pedido As Pedido, Optional _withStock As Boolean = False)
        'definicion de tabla
        Dim dt = New DataTable()
        dt.Columns.Add("LINEA", GetType(String))
        dt.Columns.Add("HOJA", GetType(String))
        dt.Columns.Add("MARCO", GetType(String))
        dt.Columns.Add("MADERA", GetType(String))
        dt.Columns.Add("CHAPA", GetType(String))
        dt.Columns.Add("MANO", GetType(String))
        dt.Columns.Add("CANTIDAD", GetType(Integer))
        dt.Columns.Add("MONTO", GetType(Decimal))

        If _withStock Then
            dt.Columns.Add("STOCK", GetType(Decimal))
        End If

        'llenado de tabla
        For Each item As Item In _pedido.items
            Dim row = dt.NewRow()
            row("linea") = item.getProducto.linea.nombre
            row("hoja") = item.getProducto.hoja.nombre
            row("marco") = item.getProducto.marco.nombre
            row("madera") = item.getProducto.madera.nombre
            row("chapa") = item.getProducto.chapa.nombre
            row("cantidad") = item.getCant
            row("MONTO") = item.monto
            row("mano") = item.getProducto.mano.nombre

            If _withStock Then
                row("stock") = item.getProducto.stock
            End If

            dt.Rows.Add(row)
        Next
        'actualizacion de grilla
        _grilla.DataSource = dt
        _grilla.DataBind()
    End Sub

    Public Sub mostrarGrillaModificarItems(ByVal _grilla As GridView, ByVal _pedido As Pedido)
        'definicion de tabla
        Dim dt = New DataTable()
        dt.Columns.Add("CANT", GetType(Integer))
        dt.Columns.Add("LINEA", GetType(String))
        dt.Columns.Add("MADERA", GetType(String))
        dt.Columns.Add("HOJA", GetType(String))
        dt.Columns.Add("MARCO", GetType(String))
        dt.Columns.Add("CHAPA", GetType(String))
        dt.Columns.Add("MANO", GetType(String))
        dt.Columns.Add("MONTO", GetType(Decimal))

        'llenado de tabla
        For Each item As Item In _pedido.items
            Dim row = dt.NewRow()
            row("linea") = item.getProducto.linea.nombre
            row("hoja") = item.getProducto.hoja.nombre
            row("marco") = item.getProducto.marco.nombre
            row("madera") = item.getProducto.madera.nombre
            row("chapa") = item.getProducto.chapa.nombre
            row("CANT") = item.getCant
            row("MONTO") = item.monto
            row("mano") = item.getProducto.mano.nombre

            dt.Rows.Add(row)
        Next
        'actualizacion de grilla
        _grilla.DataSource = dt
        _grilla.DataBind()
    End Sub

    Public Function getItemsModificar(ByVal _pedido As Integer) As DataTable
        Try
            Dim db = New DbHelper("ITEMS")
            Return db.getItemsModificar(_pedido)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getItems(_pedido As Integer, _estado As Estado, Optional _stock As Boolean = False) As DataTable
        Try
            Dim db = New DbHelper("ITEMS")

            Return db.getItems(_pedido, _estado, _stock:=_stock)

        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function getReporte(_idPedido As Integer, _reporte As reportes) As DataTable
        db = New DbHelper()
        Return db.getReporte(_idPedido, _reporte)
    End Function

    Public Function getItems(_pedido As Integer, Optional _enCurso As Boolean = False) As DataTable
        Try
            Dim db = New DbHelper("ITEMS")
            Return db.getItems(_pedido, _enCurso = _enCurso)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getItems(_idPedido As Integer, _tipo As tipoItems) As DataTable
        Dim db = New DbHelper()
        If _tipo = tipoItems.busqueda Then
            Return db.getItemsBusqueda(_idPedido)
        End If
    End Function

    Public Function buscarPedidos(ByVal _nroPedido As Integer, _fecDesde As Date, ByVal _fecHasta As Date, _fecModDesde As Date, _fecModHasta As Date, ByVal _cliente As Object, ByVal _estado As Object) As DataTable

        Dim db = New DbHelper("pedidos")
        Try
            Return db.buscarPedidos(_nroPedido, _fecDesde, _fecHasta, _fecModDesde, _fecModHasta, _cliente, _estado)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub cargarEstados(ByVal _dpEstados As DropDownList, ByVal _actual As Integer)
        Try
            Dim estado = New Estado(_actual)
            Dim EstadosPosibles() As String
            Dim estados = estado.getEstados()
            Dim rowsToDelete = New List(Of DataRow)


            EstadosPosibles = estado.getEstadosPosibles()

            For Each r As DataRow In estados.Rows
                If Not EstadosPosibles.Contains(r("id")) Then
                    rowsToDelete.Add(r)
                End If
            Next

            For Each r As DataRow In rowsToDelete
                estados.Rows.Remove(r)
            Next

            _dpEstados.DataSource = estados
            _dpEstados.DataValueField = "id"
            _dpEstados.DataTextField = "nombre"
            _dpEstados.DataBind()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getStock(_item As Item) As DataTable
        Dim db = New DbHelper("Stock")
        Return db.getStock(_item.getProducto.hoja.id, _item.getProducto.marco.id, _item.getProducto.madera.id, _item.getProducto.chapa.id, _item.getProducto.mano.id, _item.getProducto.linea.id)
    End Function

    Public Function calcularMateriales(_item As Item, gr As GridView) As Boolean
        Dim materiales = _item.CalcularMateriales()
        Dim result = True
        Dim redRows = New List(Of Integer)

        materiales.Columns.Add("REQUERIDO", GetType(Decimal))
        materiales.Columns.Add("FALTANTE", GetType(Decimal))

        Dim i = 0

        For Each r As DataRow In materiales.Rows
            Dim requerido = r("CONSUMO") * _item.getCant()

            r("REQUERIDO") = requerido

            If requerido > r("STOCK_DISPONIBLE") Then
                result = False
                r("FALTANTE") = r("STOCK_DISPONIBLE") - requerido
                redRows.Add(i)
            End If
            i += 1
        Next

        gr.DataSource = materiales
        gr.DataBind()

        For Each i In redRows
            gr.Rows(i).ForeColor = Drawing.Color.Red
        Next

        Return result
    End Function

    Friend Function getItemsEnsamblados(_id As Integer) As DataTable
        Dim db = New DbHelper()
        Try
            Return db.getItemsEnsamblados(_id)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function calcularMateriales(_pedido As Pedido, _gr As GridView) As Boolean
        Dim materiales = _pedido.calcularMateriales()
        Dim result = True
        Dim redRows = New List(Of Integer)


        Dim i = 0

        For Each r As DataRow In materiales.Rows
            Dim requerido = r("CONSUMO")

            If requerido > r("STOCK_DISPONIBLE") Then
                result = False
                redRows.Add(i)
            End If
            i += 1
        Next

        _gr.DataSource = materiales
        _gr.DataBind()

        For Each i In redRows
            _gr.Rows(i).ForeColor = Drawing.Color.Red
        Next

        Return result
    End Function

    Public Sub consultarPedido(_pedido As Pedido, grDetalle As GridView, _grRegistro As GridView)
        Dim dt = New DataTable()

        'GRILLA DETALLE
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("ESTADO", GetType(String))
        dt.Columns.Add("LINEA", GetType(String))
        dt.Columns.Add("HOJA", GetType(String))
        dt.Columns.Add("MARCO", GetType(String))
        dt.Columns.Add("MADERA", GetType(String))
        dt.Columns.Add("CHAPA", GetType(String))
        dt.Columns.Add("MANO", GetType(String))
        dt.Columns.Add("MONTO", GetType(Decimal))
        dt.Columns.Add("CANTIDAD", GetType(Integer))
        dt.Columns.Add("STOCK", GetType(Decimal))
        dt.Columns.Add("ENSAMBLADAS", GetType(Decimal))
        dt.Columns.Add("PENDIENTES", GetType(Decimal))

        For Each item As Item In _pedido.items
            Dim row = dt.NewRow()
            row("ID") = item.id
            row("ESTADO") = item.getEstado().nombre
            row("LINEA") = item.getProducto.linea.nombre
            row("HOJA") = item.getProducto.hoja.nombre
            row("MARCO") = item.getProducto.marco.nombre
            row("MADERA") = item.getProducto.madera.nombre
            row("CHAPA") = item.getProducto.chapa.nombre
            row("MANO") = item.getProducto.mano.nombre
            row("CANTIDAD") = item.getCant()
            row("MONTO") = item.monto
            row("STOCK") = item.stock
            row("ENSAMBLADAS") = item.getEnsamblados
            row("PENDIENTES") = item.getCant() - item.getEnsamblados() - item.stock

            dt.Rows.Add(row)
        Next

        'actualizacion de grilla
        grDetalle.DataSource = dt
        grDetalle.DataBind()

        'GRILLA REGISTRO
        obtenerRegistro(_pedido, _grRegistro)
    End Sub

    Public Sub obtenerRegistro(_pedido As Pedido, _grRegistro As GridView)
        Dim DTR = New DataTable
        Dim dbRegistroPedido = New DbHelper()
        DTR = dbRegistroPedido.getRegistroPedido(_pedido.id)

        For Each item As Item In _pedido.items
            Dim dbRegistroItem = New DbHelper()
            Dim DTI As New DataTable
            DTI = dbRegistroItem.getRegistroItem(item.id)
            DTR.Merge(DTI)
            DTR.DefaultView.Sort = "FECHA"
        Next

        _grRegistro.DataSource = DTR
        _grRegistro.DataBind()
    End Sub

    Public Function getDespieceProducto(_idProducto As Integer) As DataTable
        Try
            db = New DbHelper()
            Return db.getDespiece(_idProducto)
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
