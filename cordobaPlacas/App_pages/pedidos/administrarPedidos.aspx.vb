Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class administrarPedidos
    Inherits System.Web.UI.Page
    Dim gestorDatos As GestorDatos
    Dim gestorPedidos As GestorPedidos
    Private idPedido As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gestorDatos = New GestorDatos()

        'PAGE_LOAD SE EJECUTA ANTES DE LOS METODOS DE EVENTO. CIERRA TODOS LOS PANELES, CADA EVENTO ABRE LO QUE NECESITA
        pnlDetalleDeposito.Visible = False
        pnlDetalleNvo.Visible = False
        pnlStockNvo.Visible = False
        pnlDetalleNvo.Visible = False
        pnlStockNvo.Visible = False
        pnlDetalleEnCurso.Visible = False
        pnlDetalleEnsamblados.Visible = False
        pnlMsg.Visible = False
        btnImprimir.Visible = False
        pnlResultadoBusqueda.Visible = False
        pnlBuscarBotones.Visible = False
        btnPedidoCompras.Visible = False

        If Not IsPostBack() Then
            gestorDatos.getCombos(dpFiltroEstados, GestorDatos.combos.estados)
            gestorDatos.getCombos(dpClientes, GestorDatos.combos.clientes)


            dpFiltroEstados.Items.Add("TODOS")
            dpFiltroEstados.SelectedIndex = dpFiltroEstados.Items.Count - 1

            dpClientes.Items.Add("TODOS")
            dpClientes.SelectedIndex = dpClientes.Items.Count - 1

        End If
    End Sub

    Protected Sub grNvos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grNvos.SelectedIndexChanged
        Dim estado As Estado
        Dim nt = New DataTable
        Dim ds = New DataTable
        Dim dtPedidos = New DataTable
        Dim materiales As Boolean

        Try
            Dim row = grNvos.SelectedRow

            grDetalleNvo.DataSource = Nothing
            grDetalleNvo.DataBind()

            pnlDetalleNvo.Visible = True
            pnlStockNvo.Visible = True

            idPedido = row.Cells(1).Text
            gestorPedidos = New GestorPedidos(idPedido)
            Session("gestorPedidos") = gestorPedidos

            estado = New Estado(Estado.estados.recibido)

            grDetalleNvo.DataSource = gestorDatos.getItems(idPedido, estado, True)
            grDetalleNvo.DataBind()

            materiales = gestorDatos.calcularMateriales(gestorPedidos.pedido, grMateriales)
            grDetalleNvo.SelectedIndex = -1

            For Each r As GridViewRow In grDetalleNvo.Rows
                Dim numUpDown As AjaxControlToolkit.NumericUpDownExtender
                Dim val As RangeValidator

                numUpDown = r.FindControl("txtStockRow_NumericUpDownExtender")
                val = r.FindControl("rvStockNvo")
                val.MinimumValue = 0

                If Convert.ToInt32(r.Cells(10).Text) > Convert.ToInt32(r.Cells(9).Text) Then
                    numUpDown.Maximum = r.Cells(9).Text
                    val.MaximumValue = r.Cells(9).Text
                    val.ErrorMessage = "No puede exceder el valor definido en la columna CANT"
                Else
                    numUpDown.Maximum = r.Cells(10).Text
                    val.MaximumValue = r.Cells(10).Text
                    val.ErrorMessage = "No puede exceder el valor definido en la columna STOCK"
                End If
            Next

            chkPiezas.Checked = materiales

            lbltituloMat.Text = "Lista de materiales Pedido: " & gestorPedidos.pedido.id

            If materiales Then
                btnImprimir.Visible = True
                chkPiezas.Text = "DISPONE DE MATERIALES SUFICIENTES"
                chkPiezas.ForeColor = Drawing.Color.Green
                chkPiezas.Checked = True
            Else
                chkPiezas.Text = "NO DISPONE DE MATERIALES SUFICIENTES"
                chkPiezas.Checked = False
                chkPiezas.ForeColor = Drawing.Color.Red
                btnPedidoCompras.Visible = True
            End If

            btnImprimir_ConfirmButtonExtender.ConfirmText = String.Format("Mover el pedido {0} a la cola de produccion \n&#10; E imprimir ordenes de trabajo?", gestorPedidos.pedido.id)

            Dim msg = String.Format("Carga de datos pedido {0} - CORRECTA", gestorPedidos.pedido.id)
            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub msgPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Green
    End Sub

    Protected Sub grDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grDetalleNvo.SelectedIndexChanged
        Dim row = grDetalleNvo.SelectedRow
        Dim idItem = row.Cells(1).Text
        Dim item As Item
        Dim ds As DataTable
        Dim materiales As Boolean

        pnlDetalleNvo.Visible = True
        pnlStockNvo.Visible = True
        gestorPedidos = Session("gestorPedidos")

        item = gestorPedidos.pedido.getItemById(idItem)

        Session("activeItem") = item

        ds = gestorDatos.getStock(item)

        materiales = gestorDatos.calcularMateriales(item, grMateriales)

        chkPiezas.Checked = materiales

        If materiales Then
            btnImprimir.Visible = True
            chkPiezas.Text = "DISPONE DE MATERIALES SUFICIENTES"
            chkPiezas.ForeColor = Drawing.Color.Green
            chkPiezas.Checked = True
        Else
            chkPiezas.Text = "NO DISPONE DE MATERIALES SUFICIENTES"
            chkPiezas.Checked = False
            chkPiezas.ForeColor = Drawing.Color.Red
            btnPedidoCompras.Visible = True
        End If

        lbltituloMat.Text = String.Format("Lista de materiales Pedido: {0} Item {1}", gestorPedidos.pedido.id, item.id)

        btnImprimir_ConfirmButtonExtender.ConfirmText = String.Format("Mover el pedido {0} a la cola de produccion \n&#10; E imprimir ordenes de trabajo?", gestorPedidos.pedido.id)
        Dim msg = String.Format("Carga de datos Item {0} - CORRECTA", item.id)
        msgPanel(msg)
    End Sub

    Private Sub errorPanel(ByVal _msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Red
    End Sub

    Protected Sub btnPedidoCompras_Click(sender As Object, e As EventArgs) Handles btnPedidoCompras.Click
        Dim desp = New DataTable()

        gestorPedidos = Session("gestorPedidos")

        crystalReport(GestorDatos.reportes.compras, gestorPedidos.pedido.id)
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim ds As New DataTable()
        Dim rd = New ReportDocument()
        Dim dt = New DataTable()
        Dim db = New DbHelper()

        gestorPedidos = Session("gestorPedidos")
        Try
            gestorPedidos.EnviarProduccion(grDetalleNvo)
            bindGrillas()
            grDetalleNvo.SelectedIndex = -1
            Dim msg = String.Format("Pedido {0} - ACTUALIZADO", gestorPedidos.pedido.id)
            msgPanel(msg)

            crystalReport(GestorDatos.reportes.ordenTrabajo, gestorPedidos.pedido.id)
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub bindGrillas()
        grNvos.DataBind()
        grEnCurso.DataBind()
        grEnsamblados.DataBind()
        grDeposito.DataBind()

        grNvos.SelectedIndex = -1
        grEnCurso.SelectedIndex = -1
        grEnsamblados.SelectedIndex = -1
        grDeposito.SelectedIndex = -1

    End Sub

    Protected Sub btnCancelarRecibido_Click(sender As Object, e As EventArgs) Handles btnCancelarRecibido.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub grEnCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grEnCurso.SelectedIndexChanged
        Dim nt = New DataTable()
        Dim dt = New DataTable()
        Dim dtPedidos = New DataTable()

        Try
            Dim row = grEnCurso.SelectedRow

            grDetalleEnCurso.DataSource = Nothing
            grDetalleEnCurso.DataBind()

            pnlDetalleEnCurso.Visible = True

            idPedido = row.Cells(1).Text
            gestorPedidos = New GestorPedidos(idPedido)
            Session("gestorPedidos") = gestorPedidos

            dt = gestorDatos.getItems(gestorPedidos.pedido.id, _enCurso:=True)

            grDetalleEnCurso.DataSource = dt
            grDetalleEnCurso.DataBind()
            grDetalleEnCurso.SelectedIndex = -1

            Dim msg = String.Format("Carga de datos pedido {0} - CORRECTA", gestorPedidos.pedido.id)
            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub


    Protected Sub grDeposito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grDeposito.SelectedIndexChanged
        Dim nt = New DataTable()
        Dim dt = New DataTable()
        Dim check = True

        Try
            Dim row = grDeposito.SelectedRow

            grDetalleDeposito.DataSource = Nothing
            grDetalleDeposito.DataBind()

            pnlDetalleDeposito.Visible = True

            idPedido = row.Cells(1).Text
            gestorPedidos = New GestorPedidos(idPedido)
            Dim pedido = gestorPedidos.pedido
            Session("gestorPedidos") = gestorPedidos

            dt = gestorDatos.getItemsModificar(pedido.id)

            If pedido.estado.id < Estado.estados.deposito Then
                dt.Columns.Add("EN DEPOSITO")
                dt.Columns.Add("PENDIENTES")

                For Each r As DataRow In dt.Rows
                    Dim item = pedido.getItemById(r("ITEM"))
                    r("EN DEPOSITO") = item.getEnDeposito()
                    r("PENDIENTES") = item.getCant() - item.stock - item.getEnDeposito()
                Next
            End If

            grDetalleDeposito.DataSource = dt
            grDetalleDeposito.DataBind()
            grDetalleDeposito.SelectedIndex = -1

            For Each r As GridViewRow In grDetalleDeposito.Rows
                If r.Cells(8).Text.Trim() <> "DEPOSITO" And r.Cells(8).Text.Trim() <> "ENVIADO" Then
                    r.ForeColor = Drawing.Color.Red
                End If
            Next

            Dim msg = String.Format("Carga de datos pedido {0} - CORRECTA", gestorPedidos.pedido.id)
            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grEnsamblados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grEnsamblados.SelectedIndexChanged
        Dim row = grEnsamblados.SelectedRow
        Dim idItem = row.Cells(1).Text
        Dim dt = New DataTable()

        Try
            pnlDetalleEnsamblados.Visible = True

            idPedido = row.Cells(1).Text
            gestorPedidos = New GestorPedidos(idPedido)
            Session("gestorPedidos") = gestorPedidos

            grDetalleEnsamblados.DataSource = Nothing
            grDetalleEnsamblados.DataBind()


            dt = gestorDatos.getItemsEnsamblados(gestorPedidos.pedido.id)

            grDetalleEnsamblados.DataSource = dt
            grDetalleEnsamblados.DataBind()
            grDetalleEnsamblados.SelectedIndex = -1

            Dim msg = String.Format("Carga de datos pedido {0} - CORRECTA", gestorPedidos.pedido.id)
            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Protected Sub btnRefreshEnCurso_Click(sender As Object, e As ImageClickEventArgs) Handles btnRefreshEnCurso.Click
        bindGrillas()
    End Sub

    Protected Sub btnRefreshEnsamblado_Click(sender As Object, e As ImageClickEventArgs) Handles btnRefreshEnsamblado.Click
        bindGrillas()
    End Sub

    Protected Sub btnRefreshDeposito_Click(sender As Object, e As ImageClickEventArgs) Handles btnRefreshDeposito.Click
        bindGrillas()
    End Sub

    Protected Sub btnRefreshNv_Click(sender As Object, e As ImageClickEventArgs) Handles btnRefreshNv.Click
        bindGrillas()
    End Sub

    Protected Sub btnRecalcularPedido_Click(sender As Object, e As EventArgs) Handles btnRecalcularPedido.Click
        Dim materiales As Boolean
        Dim pedido = New Pedido

        gestorPedidos = Session("gestorPedidos")
        grDetalleNvo.SelectedIndex = -1
        pnlDetalleNvo.Visible = True
        pnlStockNvo.Visible = True

        For Each r As GridViewRow In grDetalleNvo.Rows
            Dim item = gestorPedidos.pedido.getItemById(r.Cells(1).Text)
            Dim txstockGridView As TextBox
            Dim stock As Integer

            txstockGridView = r.FindControl("txtStockRow")
            stock = txstockGridView.Text
            item.stock = stock

            pedido.agregarItem(item)
        Next

        materiales = gestorDatos.calcularMateriales(pedido, grMateriales)

        chkPiezas.Checked = materiales

        If materiales Then
            btnImprimir.Visible = True
            chkPiezas.Text = "DISPONE DE MATERIALES SUFICIENTES"
            chkPiezas.ForeColor = Drawing.Color.Green
            chkPiezas.Checked = True
        Else
            chkPiezas.Text = "NO DISPONE DE MATERIALES SUFICIENTES"
            chkPiezas.Checked = False
            chkPiezas.ForeColor = Drawing.Color.Red
            btnPedidoCompras.Visible = True
        End If

    End Sub

    Protected Sub btnActualizarEnCurso_Click(sender As Object, e As EventArgs) Handles btnActualizarEnCurso.Click
        gestorPedidos = Session("gestorPedidos")
        Try
            gestorPedidos.actualizarEnCurso(grDetalleEnCurso)
            Dim msg = String.Format("Pedido {0} - Actualizacion - CORRECTA", gestorPedidos.pedido.id)
            msgPanel(msg)

            bindGrillas()

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim idPedido = Nothing
        Dim fecRecDesde = Nothing
        Dim fecRecHasta = Nothing
        Dim fecModDesde = Nothing
        Dim fecModHasta = Nothing
        Dim idCliente = Nothing
        Dim idEstado = Nothing
        Dim table As DataTable

        pnlResultadoBusqueda.Visible = True
        grResultadoBusqueda.SelectedIndex = -1

        If txtPedido.Text <> "" Then
            idPedido = txtPedido.Text
        End If

        If txtFecRecDesde.Text <> "" Then
            fecRecDesde = txtFecRecDesde.Text
        End If

        If txtFecRecHasta.Text <> "" Then
            fecRecHasta = txtFecRecHasta.Text
        End If

        If txtFecModDesde.Text <> "" Then
            fecModDesde = txtFecModDesde.Text
        End If

        If txtFecModHasta.Text <> "" Then
            fecModHasta = txtFecModHasta.Text
        End If

        If dpClientes.SelectedValue <> "TODOS" Then
            idCliente = dpClientes.SelectedValue
        End If

        If dpFiltroEstados.SelectedValue <> "TODOS" Then
            idEstado = dpFiltroEstados.SelectedValue
        End If

        grResultadoBusqueda.DataSource = Nothing
        grResultadoBusqueda.DataBind()

        Try
            table = gestorDatos.buscarPedidos(idPedido, fecRecDesde, fecRecHasta, fecModDesde, fecModHasta, idCliente, idEstado)
            grResultadoBusqueda.DataSource = table
            grResultadoBusqueda.DataBind()

            Dim i = 0
            For Each r As GridViewRow In grResultadoBusqueda.Rows
                Dim btnOrden As ImageButton
                Dim btnRemito As ImageButton
                Dim btnEtiquetaStockInterno As ImageButton

                btnOrden = r.FindControl("btnRePrintOrdenes")
                btnRemito = r.FindControl("btnRePrintRemito")
                btnEtiquetaStockInterno = r.FindControl("btnEtiquetaStock")

                If table.Rows(i)("ID_ESTADO") > Estado.estados.enCola And table.Rows(i)("ID_ESTADO") < Estado.estados.entregado Then
                    btnOrden.Visible = True
                End If

                If table.Rows(i)("ID_ESTADO") > Estado.estados.deposito And table.Rows(i)("ID_ESTADO") < Estado.estados.entregado Then
                    btnRemito.Visible = True
                End If

                If table.Rows(i)("ID_ESTADO") = Estado.estados.cancelado Then
                    btnEtiquetaStockInterno.Visible = True
                End If
                i += 1
            Next

            Dim msg = "Resultados de busqueda - CARGADOS"
            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grResultadoBusqueda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grResultadoBusqueda.SelectedIndexChanged
        Try
            Dim row = grResultadoBusqueda.SelectedRow
            Dim idPedido = row.Cells(1).Text
            Dim ped As Pedido
            Dim dt = New DataTable

            pnlBuscarBotones.Visible = True
            pnlResultadoBusqueda.Visible = True

            gestorPedidos = New GestorPedidos(idPedido)
            ped = gestorPedidos.pedido
            Session("gestorPedidos") = gestorPedidos

            Dim msg = String.Format("Carga de datos pedido {0} - CORRECTA", ped.id)
            msgPanel(msg)

            dt = gestorDatos.getItems(ped.id, GestorDatos.tipoItems.busqueda)
            grDetalleBusqueda.DataSource = dt
            grDetalleBusqueda.DataBind()


            If gestorPedidos.pedido.estado.id > Estado.estados.enCola And gestorPedidos.pedido.estado.id < Estado.estados.enviado Then
                For Each r As GridViewRow In grDetalleBusqueda.Rows
                    Dim btnEtiqueta As ImageButton
                    btnEtiqueta = r.FindControl("btnRePrintEtiqueta")
                    btnEtiqueta.Visible = True
                Next
            End If

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub btnCancelarEnCurso_Click(sender As Object, e As EventArgs) Handles btnCancelarEnCurso.Click
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub btnVolverEtiquetas_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverEtiquetas.Click
        TabContainer1.Visible = True
        pnlCrystalReport.Visible = False
    End Sub

    Protected Sub btnPrintCrystal_Click(sender As Object, e As ImageClickEventArgs) Handles btnPrintCrystal.Click
        Dim rd As ReportDocument
        Dim exFormat As ExportFormatType

        exFormat = ExportFormatType.PortableDocFormat
        rd = Session("CRD")

        Try
            rd.ExportToHttpResponse(exFormat, Response, True, "deposito.pdf")
        Catch ex As ThreadAbortException
            Thread.ResetAbort()
            Session.Remove("CRD")
        End Try
    End Sub

    Private Sub crystalReport(_rpt As GestorDatos.reportes, _idPedido As Integer)
        Dim rptPath As String
        Dim dt = New DataTable()
        Dim rd = New ReportDocument()

        pnlCrystalReport.Visible = True
        TabContainer1.Visible = False

        If _rpt = GestorDatos.reportes.etiquetaDeposito Or _rpt = GestorDatos.reportes.etiquetaDepositoUnica Or
            _rpt = GestorDatos.reportes.etiquetaDepositoStock Then

            rptPath = "../../reportes/etiquetas.rpt"
        ElseIf _rpt = GestorDatos.reportes.ordenTrabajo Then
            rptPath = "../../reportes/OrdenDeTrabajo.rpt"
        ElseIf _rpt = GestorDatos.reportes.remito Then
            rptPath = "../../reportes/remito_filtrado.rpt"
        ElseIf _rpt = GestorDatos.reportes.etiquetaDepositoInterna Then
            rptPath = "../../reportes/etiquetasInternas.rpt"
        ElseIf _rpt = GestorDatos.reportes.compras Then
            rptPath = "../../reportes/compras.rpt"
        End If

        Try
            If _rpt = GestorDatos.reportes.compras Then
                Dim rowsToDelete = New List(Of DataRow)
                gestorPedidos = Session("gestorPedidos")

                dt = gestorPedidos.pedido.despiece

                For Each r As DataRow In dt.Rows
                    If IsDBNull(r("FALTANTE")) Then
                        rowsToDelete.Add(r)
                    End If
                Next

                For Each r In rowsToDelete
                    dt.Rows.Remove(r)
                Next
            Else
                dt = gestorDatos.getReporte(_idPedido, _rpt)
            End If

            rd.Load(Server.MapPath(rptPath))
            rd.SetDataSource(dt)
            CRV.ReportSource = rd
            Session("CRD") = rd
            msgPanel("Vista previa de impresion - CARGADA")
        Catch ex As Exception
            btnPrintCrystal.Visible = False
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grResultadoBusqueda_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grResultadoBusqueda.RowCommand
        Try
            If e.CommandName = "printOrden" Then
                crystalReport(GestorDatos.reportes.ordenTrabajo, e.CommandArgument)
            ElseIf e.CommandName = "printRemito" Then
                crystalReport(GestorDatos.reportes.remito, e.CommandArgument)
            ElseIf e.CommandName = "stock" Then
                crystalReport(GestorDatos.reportes.etiquetaDepositoInterna, e.CommandArgument)
            End If
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Protected Sub grDetalleBusqueda_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grDetalleBusqueda.RowCommand
        Try
            If e.CommandName = "printEtiqueta" Then
                crystalReport(GestorDatos.reportes.etiquetaDepositoUnica, e.CommandArgument)
            End If
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub grDeposito_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grDeposito.RowCommand

        If e.CommandName <> "Select" Then
            Dim estado As Estado
            Dim idPedido = Convert.ToInt32(e.CommandArgument)
            gestorPedidos = New GestorPedidos(idPedido)
            Try
                'ENVIAR PEDIDO A CLIENTE
                If e.CommandName = "enviar" Then
                    estado = New Estado(Estado.estados.enviado)
                    gestorPedidos.actualizarEstado(estado)

                    Session("gestorPEdidos") = gestorPedidos

                    Dim msg = String.Format("Pedido {0} - Estado actualizado a ENVIADO", gestorPedidos.pedido.id)
                    msgPanel(msg)

                    crystalReport(GestorDatos.reportes.remito, gestorPedidos.pedido.id)

                    'ENVIAR A STOCK
                    'ElseIf e.CommandName = "stock" Then
                    '    estado = New Estado(Estado.estados.stock)

                    '    'EL STOCK DEL PRODUCTO SE INCREMENTA POR UN TRIGGER DE DB
                    '    gestorPedidos.actualizarEstado(estado)

                    '    Session("gestorPEdidos") = gestorPedidos

                    '    Dim msg = String.Format("Pedido {0} enviado a STOCK interno", gestorPedidos.pedido.id)
                    '    msgPanel(msg)

                    'PEDIDO ENTREGADO AL CLIENTE
                ElseIf e.CommandName = "entregado" Then
                    estado = New Estado(Estado.estados.entregado)

                    gestorPedidos.actualizarEstado(estado)

                    Dim msg = String.Format("Pedido {0} movido a estado ENREGADO", gestorPedidos.pedido.id)
                    msgPanel(msg)

                End If
            Catch ex As Exception
                errorPanel(ex.Message)
            Finally
                bindGrillas()
            End Try
        End If

    End Sub

    Protected Sub grDeposito_DataBound(sender As Object, e As EventArgs) Handles grDeposito.DataBound

        For Each r As GridViewRow In grDeposito.Rows
            Dim btnEnviar As ImageButton
            Dim btnEntregado As ImageButton

            btnEnviar = r.FindControl("btnDepoEnviar")
            btnEntregado = r.FindControl("btnDepoEntregado")

            If r.Cells(7).Text <> "" Then
                If r.Cells(7).Text = Estado.estados.deposito Then
                    btnEnviar.Visible = True
                ElseIf r.Cells(7).Text = Estado.estados.enviado Then
                    btnEntregado.Visible = True
                End If
            End If
        Next
    End Sub

    Protected Sub grEnsamblados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grEnsamblados.RowCommand

        If e.CommandName = "almacenar" Then
            Dim idPedido = Convert.ToInt32(e.CommandArgument)
            gestorPedidos = New GestorPedidos(idPedido)
            Try
                crystalReport(GestorDatos.reportes.etiquetaDeposito, gestorPedidos.pedido.id)
                gestorPedidos.enviarDeposito()
                bindGrillas()

                Dim msg = String.Format("Actualizacion Pedido {0} - CORRECTA", gestorPedidos.pedido.id)
                msgPanel(msg)
            Catch ex As Exception
                errorPanel(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub grEnsamblados_DataBound(sender As Object, e As EventArgs) Handles grEnsamblados.DataBound
        For Each r As GridViewRow In grEnsamblados.Rows
            If r.Cells(7).Text > 0 Then
                Dim btnAlmac As ImageButton
                btnAlmac = r.FindControl("btnAlmacenar")
                btnAlmac.Visible = True
            End If
        Next
    End Sub

    Protected Sub grDetalleNvo_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grDetalleNvo.RowCommand
        If e.CommandName <> "Select" Then
            Dim idPedido = e.CommandArgument
            Dim r As GridViewRow
            Dim txtstock As TextBox
            Dim stock As Integer

            r = e.CommandSource.parent.parent
            txtstock = r.FindControl("txtStockRow")
            stock = txtstock.Text.Trim
        End If
    End Sub

    Protected Sub grEnCurso_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grEnCurso.RowCommand
        If e.CommandName <> "Select" Then
            If e.CommandName = "etiquetaStock" Then
                crystalReport(GestorDatos.reportes.etiquetaDepositoStock, e.CommandArgument)
            End If
        End If
    End Sub

    Protected Sub grEnCurso_DataBound(sender As Object, e As EventArgs) Handles grEnCurso.DataBound
        For Each r As GridViewRow In grEnCurso.Rows
            Dim stock = Convert.ToInt32(r.Cells(7).Text)

            If stock > 0 Then
                Dim btn As ImageButton
                btn = r.FindControl("btnEtiquetaStock")
                btn.Visible = True
            End If
        Next
    End Sub
End Class