<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnSiteAttendance.aspx.vb" Inherits="EF_atnSiteAttendance" title="Edit: Consolidated Site Attendance" %>
<asp:Content ID="CPHatnSiteAttendance" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnSiteAttendance" runat="server" Text="&nbsp;Edit: Consolidated Site Attendance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnSiteAttendance" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnSiteAttendance"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "atnSiteAttendance"
    runat = "server" />
<asp:FormView ID="FVatnSiteAttendance"
  runat = "server"
  DataKeyNames = "FinYear,MonthID,CardNo"
  DataSourceID = "ODSatnSiteAttendance"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="40px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("ATN_FinYear2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_MonthID" runat="server" ForeColor="#CC6633" Text="Month :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_MonthID"
            Width="88px"
            Text='<%# Bind("MonthID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Month."
            Runat="Server" />
          <asp:Label
            ID = "F_MonthID_Display"
            Text='<%# Eval("ATN_Months3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SAStatusID" runat="server" Text="Submitted Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SAStatusID"
            Width="88px"
            Text='<%# Bind("SAStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Submitted Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SAStatusID_Display"
            Text='<%# Eval("ATN_SAStatus4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ATNStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ATNStatusID"
            Width="88px"
            Text='<%# Bind("ATNStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ATNStatusID_Display"
            Text='<%# Eval("ATN_ApplicationStatus1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="Card No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
<%--      <tr>
        <td class="alignright">
          <asp:Label ID="L_VD01" runat="server" Text="01 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD01"
            Text='<%# Bind("VD01") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 01."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD02" runat="server" Text="02 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD02"
            Text='<%# Bind("VD02") %>'
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
          <asp:Label ID="L_VD03" runat="server" Text="03 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD03"
            Text='<%# Bind("VD03") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 03."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD04" runat="server" Text="04 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD04"
            Text='<%# Bind("VD04") %>'
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
          <asp:Label ID="L_VD05" runat="server" Text="05 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD05"
            Text='<%# Bind("VD05") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 05."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD06" runat="server" Text="06 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD06"
            Text='<%# Bind("VD06") %>'
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
          <asp:Label ID="L_VD07" runat="server" Text="07 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD07"
            Text='<%# Bind("VD07") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 07."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD08" runat="server" Text="08 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD08"
            Text='<%# Bind("VD08") %>'
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
          <asp:Label ID="L_VD09" runat="server" Text="09 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD09"
            Text='<%# Bind("VD09") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 09."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD10" runat="server" Text="10 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD10"
            Text='<%# Bind("VD10") %>'
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
          <asp:Label ID="L_VD11" runat="server" Text="11 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD11"
            Text='<%# Bind("VD11") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 11."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD12" runat="server" Text="12 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD12"
            Text='<%# Bind("VD12") %>'
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
          <asp:Label ID="L_VD13" runat="server" Text="13 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD13"
            Text='<%# Bind("VD13") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 13."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD14" runat="server" Text="14 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD14"
            Text='<%# Bind("VD14") %>'
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
          <asp:Label ID="L_VD15" runat="server" Text="15 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD15"
            Text='<%# Bind("VD15") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 15."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD16" runat="server" Text="16 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD16"
            Text='<%# Bind("VD16") %>'
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
          <asp:Label ID="L_VD17" runat="server" Text="17 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD17"
            Text='<%# Bind("VD17") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 17."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD18" runat="server" Text="18 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD18"
            Text='<%# Bind("VD18") %>'
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
          <asp:Label ID="L_VD19" runat="server" Text="19 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD19"
            Text='<%# Bind("VD19") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 19."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD20" runat="server" Text="20 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD20"
            Text='<%# Bind("VD20") %>'
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
          <asp:Label ID="L_VD21" runat="server" Text="21 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD21"
            Text='<%# Bind("VD21") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 21."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD22" runat="server" Text="22 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD22"
            Text='<%# Bind("VD22") %>'
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
          <asp:Label ID="L_VD23" runat="server" Text="23 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD23"
            Text='<%# Bind("VD23") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 23."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD24" runat="server" Text="24 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD24"
            Text='<%# Bind("VD24") %>'
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
          <asp:Label ID="L_VD25" runat="server" Text="25 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD25"
            Text='<%# Bind("VD25") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 25."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD26" runat="server" Text="26 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD26"
            Text='<%# Bind("VD26") %>'
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
          <asp:Label ID="L_VD27" runat="server" Text="27 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD27"
            Text='<%# Bind("VD27") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 27."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD28" runat="server" Text="28 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD28"
            Text='<%# Bind("VD28") %>'
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
          <asp:Label ID="L_VD29" runat="server" Text="29 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD29"
            Text='<%# Bind("VD29") %>'
            Width="24px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 29."
            MaxLength="2"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD30" runat="server" Text="30 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD30"
            Text='<%# Bind("VD30") %>'
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
          <asp:Label ID="L_VD31" runat="server" Text="31 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD31"
            Text='<%# Bind("VD31") %>'
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerifierRemarks" runat="server" Text="Verifier Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_VerifierRemarks"
            Text='<%# Bind("VerifierRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Verifier Remarks."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSatnSiteAttendance"
  DataObjectTypeName = "SIS.ATN.atnSiteAttendance"
  SelectMethod = "atnSiteAttendanceGetByID"
  UpdateMethod="UZ_atnSiteAttendanceUpdate"
  DeleteMethod="UZ_atnSiteAttendanceDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnSiteAttendance"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MonthID" Name="MonthID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
