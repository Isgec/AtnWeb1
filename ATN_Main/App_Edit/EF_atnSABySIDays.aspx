<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnSABySIDays.aspx.vb" Inherits="EF_atnSABySIDays" title="Edit: Site Attendance Days" %>
<asp:Content ID="CPHatnSABySIDays" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnSABySIDays" runat="server" Text="&nbsp;Edit: Site Attendance Days"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnSABySIDays" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnSABySIDays"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "atnSABySIDays"
    runat = "server" />
<asp:FormView ID="FVatnSABySIDays"
  runat = "server"
  DataKeyNames = "SerialNo,CardNo"
  DataSourceID = "ODSatnSABySIDays"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Serial No."
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("ATN_SABySI1_SiteName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="Card No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            Width="72px"
            Text='<%# Bind("CardNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Card No."
            Runat="Server" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text='<%# Eval("HRM_Employees2_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="250"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
<%--      <tr>
        <td class="alignright">
          <asp:Label ID="L_D01" runat="server" Text="01 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D01"
            Text='<%# Bind("D01") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 01."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D02" runat="server" Text="02 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D02"
            Text='<%# Bind("D02") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 02."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D03" runat="server" Text="03 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D03"
            Text='<%# Bind("D03") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 03."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D04" runat="server" Text="04 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D04"
            Text='<%# Bind("D04") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 04."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D05" runat="server" Text="05 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D05"
            Text='<%# Bind("D05") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 05."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D06" runat="server" Text="06 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D06"
            Text='<%# Bind("D06") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 06."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D07" runat="server" Text="07 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D07"
            Text='<%# Bind("D07") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 07."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D08" runat="server" Text="08 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D08"
            Text='<%# Bind("D08") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 08."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D09" runat="server" Text="09 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D09"
            Text='<%# Bind("D09") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 09."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D10" runat="server" Text="10 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D10"
            Text='<%# Bind("D10") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 10."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D11" runat="server" Text="11 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D11"
            Text='<%# Bind("D11") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 11."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D12" runat="server" Text="12 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D12"
            Text='<%# Bind("D12") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 12."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D13" runat="server" Text="13 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D13"
            Text='<%# Bind("D13") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 13."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D14" runat="server" Text="14 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D14"
            Text='<%# Bind("D14") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 14."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D15" runat="server" Text="15 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D15"
            Text='<%# Bind("D15") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 15."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D16" runat="server" Text="16 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D16"
            Text='<%# Bind("D16") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 16."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D17" runat="server" Text="17 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D17"
            Text='<%# Bind("D17") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 17."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D18" runat="server" Text="18 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D18"
            Text='<%# Bind("D18") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 18."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D19" runat="server" Text="19 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D19"
            Text='<%# Bind("D19") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 19."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D20" runat="server" Text="20 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D20"
            Text='<%# Bind("D20") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 20."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D21" runat="server" Text="21 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D21"
            Text='<%# Bind("D21") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 21."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D22" runat="server" Text="22 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D22"
            Text='<%# Bind("D22") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 22."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D23" runat="server" Text="23 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D23"
            Text='<%# Bind("D23") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 23."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D24" runat="server" Text="24 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D24"
            Text='<%# Bind("D24") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 24."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D25" runat="server" Text="25 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D25"
            Text='<%# Bind("D25") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 25."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D26" runat="server" Text="26 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D26"
            Text='<%# Bind("D26") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 26."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D27" runat="server" Text="27 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D27"
            Text='<%# Bind("D27") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 27."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D28" runat="server" Text="28 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D28"
            Text='<%# Bind("D28") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 28."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D29" runat="server" Text="29 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D29"
            Text='<%# Bind("D29") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 29."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_D30" runat="server" Text="30 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D30"
            Text='<%# Bind("D30") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 30."
            MaxLength="2"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_D31" runat="server" Text="31 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_D31"
            Text='<%# Bind("D31") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 31."
            MaxLength="2"
            runat="server" />
        </td>
      <td></td><td></td></tr>--%>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSatnSABySIDays"
  DataObjectTypeName = "SIS.ATN.atnSABySIDays"
  SelectMethod = "atnSABySIDaysGetByID"
  UpdateMethod="UZ_atnSABySIDaysUpdate"
  DeleteMethod="UZ_atnSABySIDaysDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnSABySIDays"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
