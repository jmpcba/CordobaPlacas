'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class pedidoNuevo
    
    '''<summary>
    '''Control Wizard1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Wizard1 As Global.System.Web.UI.WebControls.Wizard
    
    '''<summary>
    '''Control stepDatosCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents stepDatosCliente As Global.System.Web.UI.WebControls.WizardStep
    
    '''<summary>
    '''Control pnlClientes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlClientes As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control dpCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dpCliente As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control dpCliente_ListSearchExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dpCliente_ListSearchExtender As Global.AjaxControlToolkit.ListSearchExtender
    
    '''<summary>
    '''Control CompareValidator1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CompareValidator1 As Global.System.Web.UI.WebControls.CompareValidator
    
    '''<summary>
    '''Control pnlDatosCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDatosCliente As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control dvDetalleCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dvDetalleCliente As Global.System.Web.UI.WebControls.DetailsView
    
    '''<summary>
    '''Control btnActualizarCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnActualizarCliente As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnActualizarCliente_ModalPopupExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnActualizarCliente_ModalPopupExtender As Global.AjaxControlToolkit.ModalPopupExtender
    
    '''<summary>
    '''Control pnlUpdateCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlUpdateCliente As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control txtNombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNombre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control rfvNombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfvNombre As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txtTelefono.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTelefono As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control rfvTel.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfvTel As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txtMail.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtMail As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control rfvmail.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfvmail As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txtDireccion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtDireccion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control rfvDir.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfvDir As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txtCiudad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCiudad As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control rfvciudad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfvciudad As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txtProvincia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtProvincia As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control rfvProv.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfvProv As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control vsUpdateCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents vsUpdateCliente As Global.System.Web.UI.WebControls.ValidationSummary
    
    '''<summary>
    '''Control btnUpdateClienteCancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnUpdateClienteCancelar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnGuardarCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnGuardarCliente As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnGuardarCliente_ConfirmButtonExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnGuardarCliente_ConfirmButtonExtender As Global.AjaxControlToolkit.ConfirmButtonExtender
    
    '''<summary>
    '''Control Panel1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Panel1 As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control vgCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents vgCliente As Global.System.Web.UI.WebControls.ValidationSummary
    
    '''<summary>
    '''Control stepPedido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents stepPedido As Global.System.Web.UI.WebControls.WizardStep
    
    '''<summary>
    '''Control pnlCombos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlCombos As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control cbLinea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbLinea As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cbChapa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbChapa As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cbMarco.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbMarco As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control txtCant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCant As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control cbMadera.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbMadera As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cbHoja.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbHoja As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cbMano.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbMano As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control btnAgregar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control pnlDetalleNvo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDetalleNvo As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grPedido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grPedido As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control stepResumen.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents stepResumen As Global.System.Web.UI.WebControls.WizardStep
    
    '''<summary>
    '''Control lblDetalleNvo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblDetalleNvo As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblCantidadNvo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblCantidadNvo As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblPrecioNvo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblPrecioNvo As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control dvClienteConfirmar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dvClienteConfirmar As Global.System.Web.UI.WebControls.DetailsView
    
    '''<summary>
    '''Control grPepedidoConfirmar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grPepedidoConfirmar As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control pnlMsg.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlMsg As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control lblMsg.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblMsg As Global.System.Web.UI.WebControls.Label
End Class
