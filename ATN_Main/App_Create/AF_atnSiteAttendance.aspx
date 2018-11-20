<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnSiteAttendance.aspx.vb" Inherits="AF_atnSiteAttendance" title="Add: Consolidated Site Attendance" %>
<asp:Content ID="CPHatnSiteAttendance" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnSiteAttendance" runat="server" Text="&nbsp;Add: Consolidated Site Attendance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnSiteAttendance" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnSiteAttendance"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "atnSiteAttendance"
    runat = "server" />
<asp:FormView ID="FVatnSiteAttendance"
  runat = "server"
  DataKeyNames = "FinYear,MonthID,CardNo"
  DataSourceID = "ODSatnSiteAttendance"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgatnSiteAttendance" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="40px"
            Text='<%# Bind("FinYear") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Fin Year."
            ValidationGroup = "atnSiteAttendance"
            onblur= "script_atnSiteAttendance.validate_FinYear(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFinYear"
            runat = "server"
            ControlToValidate = "F_FinYear"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnSiteAttendance"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("ATN_FinYear2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFinYear"
            BehaviorID="B_ACEFinYear"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FinYearCompletionList"
            TargetControlID="F_FinYear"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnSiteAttendance.ACEFinYear_Selected"
            OnClientPopulating="script_atnSiteAttendance.ACEFinYear_Populating"
            OnClientPopulated="script_atnSiteAttendance.ACEFinYear_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_MonthID" ForeColor="#CC6633" runat="server" Text="Month :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <LGM:LC_atnMonths
            ID="F_MonthID"
            SelectedValue='<%# Bind("MonthID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "atnSiteAttendance"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" ForeColor="#CC6633" runat="server" Text="Card No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CardNo"
            CssClass = "mypktxt"
            Width="72px"
            Text='<%# Bind("CardNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Card No."
            ValidationGroup = "atnSiteAttendance"
            onblur= "script_atnSiteAttendance.validate_CardNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCardNo"
            runat = "server"
            ControlToValidate = "F_CardNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnSiteAttendance"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnSiteAttendance.ACECardNo_Selected"
            OnClientPopulating="script_atnSiteAttendance.ACECardNo_Populating"
            OnClientPopulated="script_atnSiteAttendance.ACECardNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VD01" runat="server" Text="01 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD01"
            Text='<%# Bind("VD01") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 01."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD02" runat="server" Text="02 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD02"
            Text='<%# Bind("VD02") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 02."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 03."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD04" runat="server" Text="04 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD04"
            Text='<%# Bind("VD04") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 04."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 05."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD06" runat="server" Text="06 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD06"
            Text='<%# Bind("VD06") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 06."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 07."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD08" runat="server" Text="08 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD08"
            Text='<%# Bind("VD08") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 08."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 09."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD10" runat="server" Text="10 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD10"
            Text='<%# Bind("VD10") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 10."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 11."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD12" runat="server" Text="12 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD12"
            Text='<%# Bind("VD12") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 12."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 13."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD14" runat="server" Text="14 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD14"
            Text='<%# Bind("VD14") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 14."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 15."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD16" runat="server" Text="16 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD16"
            Text='<%# Bind("VD16") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 16."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 17."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD18" runat="server" Text="18 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD18"
            Text='<%# Bind("VD18") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 18."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 19."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD20" runat="server" Text="20 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD20"
            Text='<%# Bind("VD20") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 20."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 21."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD22" runat="server" Text="22 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD22"
            Text='<%# Bind("VD22") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 22."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 23."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD24" runat="server" Text="24 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD24"
            Text='<%# Bind("VD24") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 24."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 25."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD26" runat="server" Text="26 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD26"
            Text='<%# Bind("VD26") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 26."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 27."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD28" runat="server" Text="28 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD28"
            Text='<%# Bind("VD28") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 28."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 29."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VD30" runat="server" Text="30 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VD30"
            Text='<%# Bind("VD30") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 30."
            MaxLength="2"
            Width="24px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for 31."
            MaxLength="2"
            Width="24px"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSatnSiteAttendance"
  DataObjectTypeName = "SIS.ATN.atnSiteAttendance"
  InsertMethod="UZ_atnSiteAttendanceInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnSiteAttendance"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
