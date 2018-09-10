Public Class pedidoNuevo
    Inherits System.Web.UI.Page

    Dim gestorPedidos As GestorPedidos
    Dim gestorDatos As GestorDatos
    Dim masterPage = New SiteMaster()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        pnlUpdateCliente.Visible = False
        pnlDatosCliente.Visible = False
        chkStock.Checked = False

        Try
            gestorDatos = New GestorDatos()
            If IsPostBack Then
                'gestorPedidos = Session("GestorPedidos")
            Else
                Try
                    Session.Remove("gestorPedidos")
                    gestorDatos.getCombos(dpCliente, GestorDatos.combos.clientes)
                    dpCliente.Items.Add("")
                    dpCliente.SelectedIndex = dpCliente.Items.Count - 1
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub dpCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpCliente.SelectedIndexChanged
        Dim cliente = New Cliente(dpCliente.SelectedValue)
        pnlDatosCliente.Visible = True
        pnlUpdateCliente.Visible = True

        Try
            txtCUIT.Text = cliente.CUIT
            txtNombre.Text = cliente.nombre
            txtTelefono.Text = cliente.tel
            txtMail.Text = cliente.mail
            txtDireccion.Text = cliente.direccion
            txtCiudad.Text = cliente.ciudad
            txtProvincia.Text = cliente.provincia

            Session("cliente") = cliente

            gestorDatos.getCliente(dpCliente.SelectedValue, dvDetalleCliente)

            Dim msg = String.Format("Datos del cliente {0} - CARGADOS", dpCliente.SelectedItem.Text)

            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub Wizard1_FinishButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick
        Try
            gestorPedidos = Session("gestorPedidos")
            gestorPedidos.enviarPedido()
            lblConfirmacion.Text = gestorPedidos.pedido.id

            Dim msg = String.Format("Pedido {0} - ENVIADO", gestorPedidos.pedido.id)
            msgPanel(msg)

            Session.Remove("gestorPedidos")

            grPedido.DataSource = Nothing
            grPedido.DataBind()

            Wizard1.ActiveStepIndex = 3

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub Wizard1_NextButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.NextButtonClick

        gestorPedidos = Session("GestorPedidos")

        If e.CurrentStepIndex = 0 Then
            gestorDatos.getComboLineas(cbLinea)

            If dpCliente.SelectedItem.Text = "" Then
                errorPanel("Seleccione un Cliente de la lista")
                e.Cancel = True
            Else
                If IsNothing(gestorPedidos) Then
                    gestorPedidos = New GestorPedidos(New Cliente(dpCliente.SelectedValue))
                Else
                    gestorPedidos.pedido.cliente = New Cliente(dpCliente.SelectedValue)
                End If

                Session("GestorPedidos") = gestorPedidos
            End If

        ElseIf e.CurrentStepIndex = 1 Then

            If gestorPedidos.pedido.items.Count = 0 Then
                errorPanel("Agregue por lo menos un Item al Pedido")
                e.Cancel = True
            Else

                gestorDatos.getCliente(gestorPedidos.pedido.cliente.id, dvClienteConfirmar)
                gestorDatos.mostrarGrillaItems(grPepedidoConfirmar, gestorPedidos.pedido, True)
                lblCantidadNvo.Text = gestorPedidos.pedido.cantTotal
                lblPrecioNvo.Text = gestorPedidos.pedido.precioTotal
                lblDetalleNvo.Text = gestorPedidos.pedido.cliente.nombre

                Dim flag = True

                For Each r As GridViewRow In grPepedidoConfirmar.Rows
                    If Convert.ToInt32(r.Cells(6).Text) >= Convert.ToInt32(r.Cells(8).Text) Then
                        r.ForeColor = Drawing.Color.Red
                        flag = False
                    End If
                Next

                If flag Then
                    chkStock.Text = "Dispone de Stock para cubrir este pedido"
                    chkStock.ForeColor = Drawing.Color.Green
                    chkStock.Checked = True
                Else
                    chkStock.Text = "Este pedido debe ser fabricado"
                    chkStock.ForeColor = Drawing.Color.Red
                    chkStock.Checked = False
                End If
            End If
        Else
            gestorPedidos = Session("GestorPedidos")
        End If
    End Sub

    Protected Sub cbLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLinea.SelectedIndexChanged
        Try
            gestorDatos.fillCombos(cbLinea, cbChapa, cbMarco, cbMadera, cbHoja, cbMano)

            Dim msg = String.Format("Datos para linea {0} - CARGADOS", cbLinea.SelectedItem.Text)
            msgPanel(msg)

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim chapa = New Chapa(cbChapa.SelectedItem.Value, cbChapa.SelectedItem.Text)
            Dim marco = New Marco(cbMarco.SelectedItem.Value, cbMarco.SelectedItem.Text)
            Dim madera = New Madera(cbMadera.SelectedItem.Value, cbMadera.SelectedItem.Text)
            Dim hoja = New Hoja(cbHoja.SelectedItem.Value, cbHoja.SelectedItem.Text)
            Dim mano = New Mano(cbMano.SelectedItem.Value, cbMano.SelectedItem.Text)
            Dim cant = txtCant.Text.Trim()
            Dim linea = New Linea(cbLinea.SelectedItem.Value, cbLinea.SelectedItem.Text)
            Dim producto = New Producto(hoja, marco, madera, chapa, mano, linea)

            Dim item = New Item(producto, cant)
            gestorPedidos = Session("gestorPedidos")
            gestorPedidos.addItem(item)
            gestorDatos.mostrarGrillaItems(grPedido, gestorPedidos.pedido)

            Dim msg = String.Format("Nuevo Item Agregado")
            msgPanel(msg)
            Session("gestorPedidos") = gestorPedidos
        Catch ex As Exception
            errorPanel(ex.Message)
        End Try

    End Sub

    Private Sub grPedido_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grPedido.RowDeleting
        Dim r = e.RowIndex
        gestorPedidos = Session("gestorPedidos")
        gestorPedidos.eliminarItem(r)
        gestorDatos.mostrarGrillaItems(grPedido, gestorPedidos.pedido)

        Dim msg = String.Format("Item en fila {0} -ELIMINADO", r + 1)
        msgPanel(msg)
    End Sub

    Private Sub errorPanel(ByVal _msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub msgPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Green
    End Sub

    Protected Sub btnActualizarCliente_Click(sender As Object, e As EventArgs) Handles btnActualizarCliente.Click
        Dim cliente = New Cliente(dpCliente.SelectedValue)

        txtNombre.Text = cliente.nombre
        txtTelefono.Text = cliente.tel
        txtMail.Text = cliente.mail
        txtDireccion.Text = cliente.direccion
        txtCiudad.Text = cliente.ciudad
        txtProvincia.Text = cliente.provincia
        Session("cliente") = cliente
    End Sub

    Protected Sub btnGuardarCliente_Click(sender As Object, e As EventArgs) Handles btnGuardarCliente.Click
        Dim cliente As Cliente
        Dim cambio = False

        pnlUpdateCliente.Visible = True

        cliente = Session("cliente")

        btnActualizarCliente_ModalPopupExtender.Hide()
        Dim fcuit = txtCUIT.Text.Trim()

        fcuit = fcuit.Insert(2, "-")
        fcuit = fcuit.Insert(11, "-")

        If cliente.CUIT <> fcuit Then
            cliente.CUIT = fcuit
            cambio = True
        End If

        If cliente.nombre <> txtNombre.Text.Trim() Then
            cliente.nombre = txtNombre.Text.Trim()
            cambio = True
        End If

        If cliente.tel <> txtTelefono.Text.Trim() Then
            cliente.tel = txtTelefono.Text.Trim()
            cambio = True
        End If

        If cliente.mail <> txtMail.Text.Trim() Then
            cliente.mail = txtMail.Text.Trim()
            cambio = True
        End If

        If cliente.direccion <> txtDireccion.Text.Trim() Then
            cliente.direccion = txtDireccion.Text.Trim()
            cambio = True
        End If

        If cliente.ciudad <> txtCiudad.Text.Trim() Then
            cliente.ciudad = txtCiudad.Text.Trim()
            cambio = True
        End If

        If cliente.provincia <> txtProvincia.Text.Trim Then
            cliente.provincia = txtProvincia.Text.Trim
            cambio = True
        End If

        If cambio Then
            cliente.actualizar()
            gestorDatos.getCliente(cliente.id, dvDetalleCliente)
        End If

    End Sub

    Protected Sub Wizard1_CancelButtonClick(sender As Object, e As EventArgs) Handles Wizard1.CancelButtonClick
        Session.Remove("gestorPedidos")
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub Wizard1_PreviousButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles Wizard1.PreviousButtonClick

        If Not IsNothing(gestorPedidos) And e.CurrentStepIndex = 1 Then
            pnlUpdateCliente.Visible = True
        End If
    End Sub

    Protected Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Response.Redirect(Request.Url.AbsoluteUri)
        dpCliente.SelectedIndex = dpCliente.Items.Count - 1

    End Sub
End Class

