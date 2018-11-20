<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnWebPayNewEmp.aspx.vb" Inherits="EF_atnWebPayNewEmp" title="Edit: WebPay Employee" %>
<asp:Content ID="CPHatnWebPayNewEmp" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnWebPayNewEmp" runat="server" Text="&nbsp;Edit: WebPay Employee"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnWebPayNewEmp" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnWebPayNewEmp"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "atnWebPayNewEmp"
    runat = "server" />
<asp:FormView ID="FVatnWebPayNewEmp"
  runat = "server"
  DataKeyNames = "CardNo"
  DataSourceID = "ODSatnWebPayNewEmp"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="Card No :" />&nbsp;</b>
        </td>
        <td>
          <asp:Label ID="F_CardNo"
            Text='<%# Bind("CardNo") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Salute" runat="server" Text="Salute :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Salute"
            Text='<%# Bind("Salute") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Gender" runat="server" Text="Gender :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Gender"
            Text='<%# Bind("Gender") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EmployeeName" runat="server" Text="Employee Name :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_EmployeeName"
            Text='<%# Bind("EmployeeName") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FatherName" runat="server" Text="Father`s Name :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_FatherName"
            Text='<%# Bind("FatherName") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CostCompany" runat="server" Text="Cost Company :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_CostCompany"
            Text='<%# Bind("CostCompany") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Unit" runat="server" Text="Unit :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Unit"
            Text='<%# Bind("Unit") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Category" runat="server" Text="Category :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Category"
            Text='<%# Bind("Category") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DesignationCode" runat="server" Text="Designation Code :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_DesignationCode"
            Text='<%# Bind("DesignationCode") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Designation" runat="server" Text="Designation :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Designation"
            Text='<%# Bind("Designation") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DOB" runat="server" Text="DOB :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_DOB"
            Text='<%# Bind("DOB") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DOJ" runat="server" Text="DOJ :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_DOJ"
            Text='<%# Bind("DOJ") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DOL" runat="server" Text="DOL :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_DOL"
            Text='<%# Bind("DOL") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EMail" runat="server" Text="E-Mail ID :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_EMail"
            Text='<%# Bind("EMail") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PFNO" runat="server" Text="PF NO :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_PFNO"
            Text='<%# Bind("PFNO") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PAN" runat="server" Text="PAN :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_PAN"
            Text='<%# Bind("PAN") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Department" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Department"
            Text='<%# Bind("Department") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Finalized" runat="server" Text="Finalized :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Finalized"
            Text='<%# Bind("Finalized") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PensionNo" runat="server" Text="Pension No :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_PensionNo"
            Text='<%# Bind("PensionNo") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SeatingLocation" runat="server" Text="Seating Location :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_SeatingLocation"
            Text='<%# Bind("SeatingLocation") %>'
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
  ID = "ODSatnWebPayNewEmp"
  DataObjectTypeName = "SIS.ATN.atnWebPayNewEmp"
  SelectMethod = "atnWebPayNewEmpGetByID"
  UpdateMethod="atnWebPayNewEmpUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnWebPayNewEmp"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
