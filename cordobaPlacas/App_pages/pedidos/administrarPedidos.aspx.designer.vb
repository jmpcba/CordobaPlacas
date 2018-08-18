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


Partial Public Class administrarPedidos
    
    '''<summary>
    '''Control TabContainer1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TabContainer1 As Global.AjaxControlToolkit.TabContainer
    
    '''<summary>
    '''Control tbNuevos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbNuevos As Global.AjaxControlToolkit.TabPanel
    
    '''<summary>
    '''Control pnlNvos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlNvos As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control btnRefreshNv.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRefreshNv As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control grNvos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grNvos As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control dsNvos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dsNvos As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control pnlDetalleNvo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDetalleNvo As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grDetalleNvo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grDetalleNvo As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control btnRecalcularPedido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRecalcularPedido As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnImprimirEtiquetasDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnImprimirEtiquetasDeposito As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control pnlVal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlVal As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control vsNvos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents vsNvos As Global.System.Web.UI.WebControls.ValidationSummary
    
    '''<summary>
    '''Control btnImprimirEtiquetasDeposito_ConfirmButtonExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnImprimirEtiquetasDeposito_ConfirmButtonExtender As Global.AjaxControlToolkit.ConfirmButtonExtender
    
    '''<summary>
    '''Control pnlStockNvo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlStockNvo As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control lbltituloMat.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbltituloMat As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control chkPiezas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chkPiezas As Global.System.Web.UI.WebControls.CheckBox
    
    '''<summary>
    '''Control grMateriales.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grMateriales As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control pnlBtnCompras.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlBtnCompras As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control btnPedidoCompras.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnPedidoCompras As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnImprimir.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnImprimir As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnImprimir_ConfirmButtonExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnImprimir_ConfirmButtonExtender As Global.AjaxControlToolkit.ConfirmButtonExtender
    
    '''<summary>
    '''Control btnCancelarRecibido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelarRecibido As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control tbEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbEnCurso As Global.AjaxControlToolkit.TabPanel
    
    '''<summary>
    '''Control btnRefreshEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRefreshEnCurso As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control grEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grEnCurso As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control dsEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dsEnCurso As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control pnlDetalleEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDetalleEnCurso As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grDetalleEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grDetalleEnCurso As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control vsEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents vsEnCurso As Global.System.Web.UI.WebControls.ValidationSummary
    
    '''<summary>
    '''Control btnActualizarEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnActualizarEnCurso As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnCancelarEnCurso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelarEnCurso As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control tbEnsamblados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbEnsamblados As Global.AjaxControlToolkit.TabPanel
    
    '''<summary>
    '''Control pnlEnsamblados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlEnsamblados As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control btnRefreshEnsamblado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRefreshEnsamblado As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control grEnsamblados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grEnsamblados As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control dsEnsamblados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dsEnsamblados As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control pnlDetalleEnsamblados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDetalleEnsamblados As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grDetalleEnsamblados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grDetalleEnsamblados As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control btnAlmacenar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAlmacenar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnAlmacenar_ConfirmButtonExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAlmacenar_ConfirmButtonExtender As Global.AjaxControlToolkit.ConfirmButtonExtender
    
    '''<summary>
    '''Control btnCancelarEnsambladas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelarEnsambladas As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control tbDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbDeposito As Global.AjaxControlToolkit.TabPanel
    
    '''<summary>
    '''Control pnlDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDeposito As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control btnRefreshDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRefreshDeposito As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control grDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grDeposito As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control dsPedidosDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dsPedidosDeposito As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control pnlDetalleDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDetalleDeposito As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grDetalleDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grDetalleDeposito As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control btnEnviarStock.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnEnviarStock As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnEnviarCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnEnviarCliente As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnEnviarCliente_ConfirmButtonExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnEnviarCliente_ConfirmButtonExtender As Global.AjaxControlToolkit.ConfirmButtonExtender
    
    '''<summary>
    '''Control btnRecibido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRecibido As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control ConfirmButtonExtender1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ConfirmButtonExtender1 As Global.AjaxControlToolkit.ConfirmButtonExtender
    
    '''<summary>
    '''Control btnCancelarDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelarDeposito As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control pnlRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlRemito As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control btnVolverRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnVolverRemito As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control CRVRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CRVRemito As Global.CrystalDecisions.Web.CrystalReportViewer
    
    '''<summary>
    '''Control tbBuscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbBuscar As Global.AjaxControlToolkit.TabPanel
    
    '''<summary>
    '''Control pnlBusquedas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlBusquedas As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control txtPedido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtPedido As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control revNroPedido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents revNroPedido As Global.System.Web.UI.WebControls.RegularExpressionValidator
    
    '''<summary>
    '''Control dpClientes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dpClientes As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control dpFiltroEstados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dpFiltroEstados As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control txtFecRecDesde.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecRecDesde As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtFecRecDesde_MaskedEditExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecRecDesde_MaskedEditExtender As Global.AjaxControlToolkit.MaskedEditExtender
    
    '''<summary>
    '''Control txtFecRecDesde_CalendarExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecRecDesde_CalendarExtender As Global.AjaxControlToolkit.CalendarExtender
    
    '''<summary>
    '''Control CVFecRecDesde.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CVFecRecDesde As Global.System.Web.UI.WebControls.CompareValidator
    
    '''<summary>
    '''Control txtFecRecHasta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecRecHasta As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtFecRecHasta_MaskedEditExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecRecHasta_MaskedEditExtender As Global.AjaxControlToolkit.MaskedEditExtender
    
    '''<summary>
    '''Control txtFecRecHasta_CalendarExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecRecHasta_CalendarExtender As Global.AjaxControlToolkit.CalendarExtender
    
    '''<summary>
    '''Control CompareValidator1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CompareValidator1 As Global.System.Web.UI.WebControls.CompareValidator
    
    '''<summary>
    '''Control txtFecModDesde.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecModDesde As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtFecModDesde_MaskedEditExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecModDesde_MaskedEditExtender As Global.AjaxControlToolkit.MaskedEditExtender
    
    '''<summary>
    '''Control txtFecModDesde_CalendarExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecModDesde_CalendarExtender As Global.AjaxControlToolkit.CalendarExtender
    
    '''<summary>
    '''Control CompareValidator2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CompareValidator2 As Global.System.Web.UI.WebControls.CompareValidator
    
    '''<summary>
    '''Control txtFecModHasta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecModHasta As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtFecModHasta_MaskedEditExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecModHasta_MaskedEditExtender As Global.AjaxControlToolkit.MaskedEditExtender
    
    '''<summary>
    '''Control txtFecModHasta_CalendarExtender2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFecModHasta_CalendarExtender2 As Global.AjaxControlToolkit.CalendarExtender
    
    '''<summary>
    '''Control CompareValidator3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CompareValidator3 As Global.System.Web.UI.WebControls.CompareValidator
    
    '''<summary>
    '''Control btnBuscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnBuscar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnLimpiar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnLimpiar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control pnlValidacionBusqueda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlValidacionBusqueda As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control VSBuscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents VSBuscar As Global.System.Web.UI.WebControls.ValidationSummary
    
    '''<summary>
    '''Control pnlResultadoBusqueda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlResultadoBusqueda As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grResultadoBusqueda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grResultadoBusqueda As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control pnlBuscarBotones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlBuscarBotones As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grDetalleBusqueda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grDetalleBusqueda As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control btnBuscarOrdenes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnBuscarOrdenes As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnBuscarEtiquetasDeposito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnBuscarEtiquetasDeposito As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnBuscarRemitos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnBuscarRemitos As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnCancelarBuscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelarBuscar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control pnlCrystalReport.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlCrystalReport As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control btnVolverEtiquetas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnVolverEtiquetas As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control btnPrintCrystal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnPrintCrystal As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control CRV.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CRV As Global.CrystalDecisions.Web.CrystalReportViewer
    
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
