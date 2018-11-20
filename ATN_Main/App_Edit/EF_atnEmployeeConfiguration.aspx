<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnEmployeeConfiguration.aspx.vb" Inherits="EF_atnEmployeeConfiguration" title="Edit: Employee Configuration" %>
<asp:Content ID="CPHatnEmployeeConfiguration" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnEmployeeConfiguration" runat="server" Text="&nbsp;Edit: Employee Configuration"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnEmployeeConfiguration" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnEmployeeConfiguration"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "atnEmployeeConfiguration"
    runat = "server" />
<asp:FormView ID="FVatnEmployeeConfiguration"
  runat = "server"
  DataKeyNames = "CardNo"
  DataSourceID = "ODSatnEmployeeConfiguration"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="Card No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            Width="56px"
            Text='<%# Bind("CardNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Card No."
            Runat="Server" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text='<%# Eval("HRM_Employees1_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SendVerifyMail" runat="server" Text="Send Leave Verification Mail :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_SendVerifyMail"
            Checked='<%# Bind("SendVerifyMail") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SendApproveMail" runat="server" Text="Send Leave Approval Mail :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_SendApproveMail"
            Checked='<%# Bind("SendApproveMail") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSatnEmployeeConfiguration"
  DataObjectTypeName = "SIS.ATN.atnEmployeeConfiguration"
  SelectMethod = "atnEmployeeConfigurationGetByID"
  UpdateMethod="UZ_atnEmployeeConfigurationUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnEmployeeConfiguration"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
