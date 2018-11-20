<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taTPInvoicing.aspx.vb" Inherits="EF_taTPInvoicing" title="Edit: Travel Invoices" %>
<asp:Content ID="CPHtaTPInvoicing" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaTPInvoicing" runat="server" Text="&nbsp;Edit: Travel Invoices"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaTPInvoicing" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaTPInvoicing"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_taTPInvoicing.aspx?pk="
    ValidationGroup = "taTPInvoicing"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVtaTPInvoicing"
  runat = "server"
  DataKeyNames = "InvoiceNo"
  DataSourceID = "ODStaTPInvoicing"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_InvoiceNo" runat="server" ForeColor="#CC6633" Text="Invoice No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceNo"
            Text='<%# Bind("InvoiceNo") %>'
            ToolTip="Value of Invoice No."
            Enabled = "False"
            Width="105px"
            CssClass = "dmypktxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InvoiceDate" runat="server" Text="Invoice Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceDate"
            Text='<%# Bind("InvoiceDate") %>'
            ToolTip="Value of Invoice Date."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PAXName" runat="server" Text="PAX Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PAXName"
            Text='<%# Bind("PAXName") %>'
            ToolTip="Value of PAX Name."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Sector" runat="server" Text="Sector :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Sector"
            Text='<%# Bind("Sector") %>'
            ToolTip="Value of Sector."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BookingDate" runat="server" Text="Booking Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BookingDate"
            Text='<%# Bind("BookingDate") %>'
            ToolTip="Value of Booking Date."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TravelDate" runat="server" Text="Travel Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TravelDate"
            Text='<%# Bind("TravelDate") %>'
            ToolTip="Value of Travel Date."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AirlinesName" runat="server" Text="Airlines Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AirlinesName"
            Text='<%# Bind("AirlinesName") %>'
            ToolTip="Value of Airlines Name."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TicketNo" runat="server" Text="Ticket No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TicketNo"
            Text='<%# Bind("TicketNo") %>'
            ToolTip="Value of Ticket No."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NetAmount" runat="server" Text="Net Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NetAmount"
            Text='<%# Bind("NetAmount") %>'
            ToolTip="Value of Net Amount."
            Enabled = "False"
            Width="56px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EmployeeCode" runat="server" Text="Employee Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeCode"
            Width="56px"
            Text='<%# Bind("EmployeeCode") %>'
            Enabled = "False"
            ToolTip="Value of Employee Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeCode_Display"
            Text='<%# Eval("HRM_Employees1_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Sanction" runat="server" Text="Sanction :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Sanction"
            Text='<%# Bind("Sanction") %>'
            ToolTip="Value of Sanction."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AirlineType" runat="server" Text="Airline Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AirlineType"
            Text='<%# Bind("AirlineType") %>'
            ToolTip="Value of Airline Type."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaTPInvoicing"
  DataObjectTypeName = "SIS.TA.taTPInvoicing"
  SelectMethod = "taTPInvoicingGetByID"
  UpdateMethod="UZ_taTPInvoicingUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taTPInvoicing"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="InvoiceNo" Name="InvoiceNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
