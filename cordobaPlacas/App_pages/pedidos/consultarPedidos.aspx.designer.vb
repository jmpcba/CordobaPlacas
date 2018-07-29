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


Partial Public Class WebForm2
    
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
    '''Control btnVolver.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnVolver As Global.System.Web.UI.WebControls.Button
    
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
    '''Control btnPnlBusqueda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnPnlBusqueda As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnPnlBusqueda_ModalPopupExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnPnlBusqueda_ModalPopupExtender As Global.AjaxControlToolkit.ModalPopupExtender
    
    '''<summary>
    '''Control grResultadoBusqueda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grResultadoBusqueda As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control SqlDataSource1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents SqlDataSource1 As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control pnlDetalle.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlDetalle As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grDetalleBusqueda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grDetalleBusqueda As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control btnRegistro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRegistro As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnRegistro_ModalPopupExtender.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRegistro_ModalPopupExtender As Global.AjaxControlToolkit.ModalPopupExtender
    
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
    
    '''<summary>
    '''Control pnlRegistro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlRegistro As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control grRegistro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grRegistro As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control btnRegistroVolver.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnRegistroVolver As Global.System.Web.UI.WebControls.Button
End Class
