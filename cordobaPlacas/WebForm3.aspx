<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm3.aspx.vb" Inherits="cordobaPlacas.WebForm3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" HorizontalAlign="Center" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#428BCA" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="White" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" HorizontalAlign="Center" />
        </asp:Calendar>
            </td>
        </tr>
    </table>
        
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
    
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="LINEA" HeaderText="LINEA" SortExpression="LINEA" />
                <asp:BoundField DataField="CHAPA" HeaderText="CHAPA" SortExpression="CHAPA" />
                <asp:BoundField DataField="HOJA" HeaderText="HOJA" SortExpression="HOJA" />
                <asp:BoundField DataField="MARCO" HeaderText="MARCO" SortExpression="MARCO" />
                <asp:BoundField DataField="MADERA" HeaderText="MADERA" SortExpression="MADERA" />
                <asp:BoundField DataField="MANO" HeaderText="MANO" SortExpression="MANO" />
                <asp:BoundField DataField="PRECIO" HeaderText="PRECIO" SortExpression="PRECIO" />
                <asp:BoundField DataField="STOCK" HeaderText="STOCK" SortExpression="STOCK" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#428BCA" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" BorderStyle="Solid" BorderWidth="2px" BorderColor="Black" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#D1DDF1" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cbaPlacasConnectionString %>" SelectCommand="SP_LISTA_PRODUCTOS" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" BackColor="#428BCA" BorderColor="#428BCA" BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Button" />
    
        <input id="Reset1" class="button" type="reset" value="reset" /></div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1" DisplayCancelButton="True">
                <CancelButtonStyle BackColor="#428BCA" BorderColor="#428BCA" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                <FinishCompleteButtonStyle BackColor="#428BCA" BorderColor="#428BCA" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                <FinishPreviousButtonStyle BackColor="#428BCA" BorderColor="#428BCA" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                <StartNextButtonStyle BackColor="#428BCA" BorderColor="#428BCA" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                <StepNextButtonStyle BackColor="#428BCA" BorderColor="#428BCA" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                <StepPreviousButtonStyle BackColor="#428BCA" BorderColor="#428BCA" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                <WizardSteps>
                    <asp:WizardStep runat="server" title="Step 1">
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" title="Step 2">
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
            <br />
            <asp:DetailsView ID="DetailsView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="50px" Width="125px" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                <EditRowStyle BackColor="#2461BF" />
                <FieldHeaderStyle BackColor="#428BCA" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:DetailsView>
        </ContentTemplate>
        </asp:UpdatePanel>

    </form>

    </body>
</html>
