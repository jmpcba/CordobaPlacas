Imports cordobaPlacas

Public Class modificarCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gestorDatos = New GestorDatos

        pnlDatosCliente.Visible = False
        pnlMsg.Visible = False

        If Not IsPostBack Then
            Try
                gestorDatos.getCombos(lstClientes, GestorDatos.combos.clientes)
            Catch ex As Exception
                errorPanel(ex.Message)
            End Try

            Dim idCliente = Request.QueryString("IDCliente")

            If Not IsNothing(idCliente) Then
                Try
                    Dim cliente = New Cliente(idCliente)
                    Session("cliente") = cliente

                    pnlDatosCliente.Visible = True

                    llenarCombos(cliente)

                    msgPanel(String.Format("Datos de cliente {0}- CARGADOS", cliente.nombre))

                Catch ex As Exception
                    errorPanel(ex.Message)
                End Try
            End If
        End If
    End Sub

    Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim cliente = New Cliente(lstClientes.SelectedValue)
            Session("cliente") = cliente

            pnlDatosCliente.Visible = True

            llenarCombos(cliente)

            msgPanel(String.Format("Datos de cliente {0}- CARGADOS", cliente.nombre))

        Catch ex As Exception
            errorPanel(ex.Message)
        End Try
    End Sub

    Private Sub llenarCombos(_cliente As Cliente)
        txtCuit.Text = _cliente.CUIT
        txtCiudad.Text = _cliente.ciudad
        txtDir.Text = _cliente.direccion
        txtMail.Text = _cliente.mail
        txtNombre.Text = _cliente.nombre
        txtProvincia.Text = _cliente.provincia
        txtTel.Text = _cliente.tel
    End Sub

    Private Sub errorPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub msgPanel(_msg As String)
        pnlMsg.Visible = True
        lblMsg.Text = _msg
        lblMsg.ForeColor = Drawing.Color.Green
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim fcuit = txtCuit.Text.Trim()
        Dim cliente As Cliente
        Dim cambio = False

        cliente = Session("cliente")

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

        If cliente.tel <> txtTel.Text.Trim() Then
            cliente.tel = txtTel.Text.Trim()
            cambio = True
        End If

        If cliente.mail <> txtMail.Text.Trim() Then
            cliente.mail = txtMail.Text.Trim()
            cambio = True
        End If

        If cliente.direccion <> txtDir.Text.Trim() Then
            cliente.direccion = txtDir.Text.Trim()
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
            Try
                cliente.actualizar()
            Catch ex As Exception
                errorPanel(ex.Message)
            End Try

            llenarCombos(cliente)
            msgPanel("Cliente Modificado con Exito")
        Else
            msgPanel("No se realizaron cambios")
        End If

    End Sub
End Class