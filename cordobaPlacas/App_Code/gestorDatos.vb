Imports System.Data
Imports System.Data.SqlClient
Public Class GestorDatos
    Public chapa As Chapa
    Public marco As Marco
    Public madera As Madera
    Public hoja As Hoja
    Public linea As linea
    Public mano As Mano

    Private cnn As SqlConnection
    Private cmd As SqlCommand
    Private da As SqlDataAdapter
    Private ds As DataSet
    Public Enum combos
        estados
        clientes
    End Enum
    Public Sub New()

        chapa = New Chapa()
        marco = New Marco()
        madera = New Madera()
        hoja = New Hoja()
        linea = New linea()
        mano = New Mano
    End Sub

    Friend Sub getCliente(_idCliente As Integer, _dv As DetailsView)
        Dim cliente = New Cliente(_idCliente)
        _dv.DataSource = cliente.datos
        _dv.DataBind()
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

    Public Sub getCombos(ByVal _cbLinea As DropDownList, ByVal _cbChapa As DropDownList, ByVal _cbMarco As DropDownList, ByVal _cbMadera As DropDownList, ByVal _cbHoja As DropDownList, ByVal _cbMano As DropDownList)

        Dim selMaderas() As Integer
        Dim selChapas() As Integer
        Dim selMarcos() As Integer
        Dim selHojas() As Integer
        Dim selManos() As Integer
        Dim maderas As DataTable
        Dim chapas As DataTable
        Dim marcos As DataTable
        Dim hojas As DataTable
        Dim manos As DataTable
        Dim rowsToDelete = New List(Of DataRow)

        Try
            maderas = madera.getMaderas()
            chapas = chapa.getChapas()
            marcos = marco.getMarcos()
            hojas = hoja.getHojas
            manos = mano.getManos()
        Catch ex As Exception
            Throw
        End Try

        Dim seleccion = _cbLinea.SelectedItem.Value

        Select Case seleccion

            Case 1 'linea liviana
                selMaderas = {0}
                selChapas = {0}
                selMarcos = {0, 1, 2}
                selHojas = {0, 1, 2, 3}
                selManos = {0, 1}
            Case 2 ' linea intrermedia
                selMaderas = {0, 1}
                selChapas = {1}
                selMarcos = {1, 2, 3, 4}
                selHojas = {0, 1, 2, 3}
                selManos = {0, 1}
            Case 3 'linea pesada
                selMaderas = {0, 1, 2}
                selChapas = {2}
                selMarcos = {1, 2, 3, 4}
                selHojas = {0, 1, 2, 3}
                selManos = {0, 1}
            Case 4 'frente placard
                selMaderas = {0, 2}
                selChapas = {2}
                selMarcos = {1}
                selHojas = {4, 5, 6, 7, 8, 9, 10, 11, 12, 13}
                selManos = {2}
            Case Else
                selMaderas = {0, 1, 2}
                selChapas = {0, 1, 2}
                selMarcos = {0, 1, 2, 3, 4}
                selHojas = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}
                selManos = {0, 1, 2}
        End Select

        If _cbLinea.SelectedValue <> 0 Then 'si no esta seleccionada la opcion vacia
            'ELIMINAR MADERAS QUE NO VAN CON LA LINEA SELECCIONADA
            For Each row As DataRow In maderas.Rows
                If Not selMaderas.Contains(row("id")) Then
                    rowsToDelete.Add(row)
                End If
            Next

            For Each i As DataRow In rowsToDelete
                maderas.Rows.Remove(i)
            Next

            'ELIMINAR CHAPAS QUE NO CORRESPONDEN CON LA LINEA
            rowsToDelete.Clear()

            For Each r As DataRow In chapas.Rows
                If Not selChapas.Contains(r("id")) Then
                    rowsToDelete.Add(r)
                End If
            Next

            For Each r As DataRow In rowsToDelete
                chapas.Rows.Remove(r)
            Next

            rowsToDelete.Clear()
            'ELIMINAR MARCOS QUE NO CORRESPONDEN CON LA LINEA
            For Each r As DataRow In marcos.Rows
                If Not selMarcos.Contains(r("id")) Then
                    rowsToDelete.Add(r)
                End If
            Next

            For Each r As DataRow In rowsToDelete
                marcos.Rows.Remove(r)
            Next

            rowsToDelete.Clear()
            'ELIMINAR ANCHOS DE HOJA QUE NO CORRESPONDEN CON LA LINEA
            For Each r As DataRow In hojas.Rows
                If Not selHojas.Contains(r("id")) Then
                    rowsToDelete.Add(r)
                End If
            Next

            For Each r As DataRow In rowsToDelete
                hojas.Rows.Remove(r)
            Next

            rowsToDelete.Clear()
            'ELIMINAR MANOS QUE NOS CORRESPONDEN CON LA LINEA
            For Each r As DataRow In manos.Rows
                If Not selManos.Contains(r("id")) Then
                    rowsToDelete.Add(r)
                End If
            Next

            For Each r As DataRow In rowsToDelete
                manos.Rows.Remove(r)
            Next

            _cbMarco.DataSource = marcos
            _cbMadera.DataSource = maderas
            _cbChapa.DataSource = chapas
            _cbHoja.DataSource = hojas
            _cbMano.DataSource = manos

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

            _cbChapa.DataBind()
            _cbMarco.DataBind()
            _cbMadera.DataBind()
            _cbHoja.DataBind()
            _cbMano.DataBind()

        Else

            _cbChapa.Items.Clear()
            _cbMarco.Items.Clear()
            _cbMadera.Items.Clear()
            _cbHoja.Items.Clear()
            _cbMano.Items.Clear()
        End If
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

        _cbChapa.DataBind()
        _cbMarco.DataBind()
        _cbMadera.DataBind()
        _cbHoja.DataBind()
        _cbMano.DataBind()

    End Sub

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

    Public Sub mostrarGrillaItems(ByVal _grilla As GridView, ByVal _pedido As Pedido)
        'definicion de tabla
        Dim dt = New DataTable()
        dt.Columns.Add("LINEA", GetType(String))
        dt.Columns.Add("HOJA", GetType(String))
        dt.Columns.Add("MARCO", GetType(String))
        dt.Columns.Add("MADERA", GetType(String))
        dt.Columns.Add("CHAPA", GetType(String))
        dt.Columns.Add("MANO", GetType(String))
        dt.Columns.Add("CANTIDAD", GetType(Integer))
        dt.Columns.Add("PRECIO", GetType(Decimal))

        'llenado de tabla
        For Each item As Item In _pedido.items
            Dim row = dt.NewRow()
            row("linea") = item.producto.linea.nombre
            row("hoja") = item.producto.hoja.nombre
            row("marco") = item.producto.marco.nombre
            row("madera") = item.producto.madera.nombre
            row("chapa") = item.producto.chapa.nombre
            row("cantidad") = item.cant
            row("precio") = item.monto
            row("mano") = item.producto.mano.nombre
            dt.Rows.Add(row)
        Next
        'actualizacion de grilla
        _grilla.DataSource = dt
        _grilla.DataBind()
    End Sub

    Public Function getPedidosCliente(ByVal _cliente As Integer) As DataTable
        Try
            Dim db = New DbHelper("pedidos")
            Return db.getPedidos(_cliente)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getItems(ByVal _pedido As Integer) As DataTable
        Try
            Dim db = New DbHelper("ITEMS")
            Return db.getItems(_pedido)
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

    Public Function getItems(_pedido As Integer, Optional _enCurso As Boolean = False) As DataTable
        Try
            Dim db = New DbHelper("ITEMS")
            Return db.getItems(_pedido, _enCurso = _enCurso)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub grDetalleNvos(_pedido As Pedido, _estado As Estado, _gr As GridView)
        Dim dt = New DataTable()
        Dim i = 0
        Dim db = New DbHelper("ITEMS")
        Dim redRows = New List(Of Integer)

        Try
            dt = db.getItems(_pedido.id, _estado, True)
            dt.Columns.Add("Usar Stock", GetType(Integer))
            dt.Columns.Add("Materiales", GetType(String))

            For Each r As DataRow In dt.Rows
                Dim id = r("ITEM")
                Dim item As Item

                item = _pedido.getItemById(r("item"))

                If Not calcularMateriales(item) Then
                    r("materiales") = "NO"
                    redRows.Add(i)
                Else
                    r("materiales") = "SI"
                End If
                i += 1
            Next

            _gr.DataSource = dt
            _gr.DataBind()

            For Each i In redRows
                _gr.Rows(i).ForeColor = Drawing.Color.Red
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

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
        Return db.getStock(_item.producto.hoja.id, _item.producto.marco.id, _item.producto.madera.id, _item.producto.chapa.id, _item.producto.mano.id, _item.producto.linea.id)
    End Function

    Public Function calcularMateriales(_item As Item, gr As GridView) As Boolean
        Dim materiales = _item.CalcularMateriales()
        Dim result = True
        Dim redRows = New List(Of Integer)

        materiales.Columns.Add("REQUERIDO", GetType(Decimal))
        materiales.Columns.Add("FALTANTE", GetType(Decimal))

        Dim i = 0

        For Each r As DataRow In materiales.Rows
            Dim requerido = r("CONSUMO") * _item.cant

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

    Public Function calcularMateriales(_item As Item) As Boolean
        Dim materiales = _item.CalcularMateriales()
        Dim result = True

        Dim i = 0

        For Each r As DataRow In materiales.Rows
            Dim requerido = r("CONSUMO") * _item.cant

            If requerido > r("STOCK_DISPONIBLE") Then
                result = False
            End If
            i += 1
        Next
        Return result
    End Function

    Public Function calcularMateriales(_item As Item, gr As GridView, _stock As Integer) As Boolean
        Dim materiales = _item.CalcularMateriales()
        Dim result = True
        Dim redRows = New List(Of Integer)

        materiales.Columns.Add("REQUERIDO", GetType(Decimal))
        materiales.Columns.Add("FALTANTE", GetType(Decimal))

        Dim i = 0

        For Each r As DataRow In materiales.Rows
            Dim requerido = r("CONSUMO") * (_item.cant - _stock)

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

    Public Function calcularMateriales(_item As Item, _stock As Integer) As Boolean
        Dim materiales = _item.CalcularMateriales()
        Dim result = True
        Dim redRows = New List(Of Integer)

        Dim i = 0

        For Each r As DataRow In materiales.Rows
            Dim requerido = r("CONSUMO") * (_item.cant - _stock)

            If requerido > r("STOCK_DISPONIBLE") Then
                result = False
                redRows.Add(i)
            End If
            i += 1
        Next
        Return result
    End Function

    Public Function calcularMateriales(_pedido As Pedido, _gr As GridView) As Boolean
        Dim materiales = _pedido.calcularMateriales()
        Dim result = True
        Dim redRows = New List(Of Integer)

        materiales.Columns.Add("FALTANTE", GetType(Decimal))

        Dim i = 0

        For Each r As DataRow In materiales.Rows
            Dim requerido = r("CONSUMO")

            If requerido > r("STOCK_DISPONIBLE") Then
                result = False
                r("FALTANTE") = r("STOCK_DISPONIBLE") - requerido
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

End Class
