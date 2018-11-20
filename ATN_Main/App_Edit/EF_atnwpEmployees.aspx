<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnwpEmployees.aspx.vb" Inherits="EF_atnwpEmployees" title="Edit: Create Employee From WP" %>
<asp:Content ID="CPHatnwpEmployees" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnwpEmployees" runat="server" Text="&nbsp;Edit: Create Employee From WP"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnwpEmployees" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnwpEmployees"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "atnwpEmployees"
    runat = "server" />
<asp:FormView ID="FVatnwpEmployees"
  runat = "server"
  DataKeyNames = "CardNo"
  DataSourceID = "ODSatnwpEmployees"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="Card No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CardNo"
            Text='<%# Bind("CardNo") %>'
            ToolTip="Value of Card No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="56px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Salute" runat="server" Text="Salute :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Salute"
            Text='<%# Bind("Salute") %>'
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
          <asp:Label ID="L_Gender" runat="server" Text="Gender :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_Gender"
            Text='<%# Bind("Gender") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_DateOfJoining" runat="server" Text="Date Of Joining :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_C_DateOfJoining"
            Text='<%# Bind("C_DateOfJoining") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_CompanyID" runat="server" Text="Company :" />&nbsp;
        </td>
        <td>
          <asp:Label
            ID = "F_C_CompanyID"
            Text='<%# Bind("C_CompanyID") %>'
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_C_CompanyID_Display"
            Text='<%# Eval("HRM_Companies2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_DivisionID" runat="server" Text="Division :" />&nbsp;
        </td>
        <td>
          <asp:Label
            ID = "F_C_DivisionID"
            Text='<%# Bind("C_DivisionID") %>'
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_C_DivisionID_Display"
            Text='<%# Eval("HRM_Divisions12_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DepartmentID" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <asp:Label
            ID = "F_C_DepartmentID"
            Text='<%# Bind("C_DepartmentID") %>'
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_C_DepartmentID_Display"
            Text='<%# Eval("HRM_Departments6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_DesignationID" runat="server" Text="Designation :" />&nbsp;
        </td>
        <td>
          <asp:Label
            ID = "F_C_DesignationID"
            Text='<%# Bind("C_DesignationID") %>'
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_C_DesignationID_Display"
            Text='<%# Eval("HRM_Designations9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ActiveState" runat="server" Text="ActiveState :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ActiveState"
            Checked='<%# Bind("ActiveState") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DateOfBirth" runat="server" Text="Date Of Birth :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_DateOfBirth"
            Text='<%# Bind("DateOfBirth") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FatherName" runat="server" Text="Father Name :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_FatherName"
            Text='<%# Bind("FatherName") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PFNumber" runat="server" Text="PF Number :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_PFNumber"
            Text='<%# Bind("PFNumber") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ESINumber" runat="server" Text="ESI Number :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_ESINumber"
            Text='<%# Bind("ESINumber") %>'
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
          <asp:Label ID="L_EMailID" runat="server" Text="E Mail ID :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_EMailID"
            Text='<%# Bind("EMailID") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Freezed" runat="server" Text="Freezed :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Freezed"
            Checked='<%# Bind("Freezed") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModifiedBy" runat="server" Text="Modified By :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_ModifiedBy"
            Text='<%# Bind("ModifiedBy") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ModifiedOn" runat="server" Text="Modified On :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_ModifiedOn"
            Text='<%# Bind("ModifiedOn") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModifiedEvent" runat="server" Text="Modified Event :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_ModifiedEvent"
            Text='<%# Bind("ModifiedEvent") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerificationRequired" runat="server" Text="Verification Required :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_VerificationRequired"
            Checked='<%# Bind("VerificationRequired") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerifierID" runat="server" Text="Verifier ID :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_VerifierID"
            Text='<%# Bind("VerifierID") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovalRequired" runat="server" Text="Approval Required :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ApprovalRequired"
            Checked='<%# Bind("ApprovalRequired") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApproverID" runat="server" Text="Approver ID :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_ApproverID"
            Text='<%# Bind("ApproverID") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryID" runat="server" Text="Category :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:Label
            ID = "F_CategoryID"
            Text='<%# Bind("CategoryID") %>'
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CategoryID_Display"
            Text='<%# Eval("TA_Categories34_cmba") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="atnwpEmployees_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Other Details</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AliasName" runat="server" Text="Alias Name :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_AliasName"
            Text='<%# Bind("AliasName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="atnwpEmployees"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Alias Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAliasName"
            runat = "server"
            ControlToValidate = "F_AliasName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnwpEmployees"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ContactNumbers" runat="server" Text="Contact Numbers :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ContactNumbers"
            Text='<%# Bind("ContactNumbers") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="atnwpEmployees"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Numbers."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVContactNumbers"
            runat = "server"
            ControlToValidate = "F_ContactNumbers"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnwpEmployees"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NonTechnical" runat="server" Text="Non Technical :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_NonTechnical"
            Checked='<%# Bind("NonTechnical") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Contractual" runat="server" Text="Contractual :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Contractual"
            Checked='<%# Bind("Contractual") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_OfficeID" runat="server" Text="Office :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_hrmOffices
            ID="F_C_OfficeID"
            SelectedValue='<%# Bind("C_OfficeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "atnwpEmployees"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_C_ProjectSiteID" runat="server" Text="Project Site :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_C_ProjectSiteID"
            CssClass = "myfktxt"
            Text='<%# Bind("C_ProjectSiteID") %>'
            AutoCompleteType = "None"
            Width="42px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project Site."
            ValidationGroup = "atnwpEmployees"
            onblur= "script_atnwpEmployees.validate_C_ProjectSiteID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVC_ProjectSiteID"
            runat = "server"
            ControlToValidate = "F_C_ProjectSiteID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnwpEmployees"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_C_ProjectSiteID_Display"
            Text='<%# Eval("IDM_Projects30_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEC_ProjectSiteID"
            BehaviorID="B_ACEC_ProjectSiteID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="C_ProjectSiteIDCompletionList"
            TargetControlID="F_C_ProjectSiteID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnwpEmployees.ACEC_ProjectSiteID_Selected"
            OnClientPopulating="script_atnwpEmployees.ACEC_ProjectSiteID_Populating"
            OnClientPopulated="script_atnwpEmployees.ACEC_ProjectSiteID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="atnwpEmployees_1"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Resignation</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Resigned" runat="server" Text="Resigned :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Resigned"
            Checked='<%# Bind("Resigned") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_ResignedOn" runat="server" Text="Resigned On :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_C_ResignedOn"
            Text='<%# Bind("C_ResignedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="atnwpEmployees"
            runat="server" />
          <asp:Image ID="ImageButtonC_ResignedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEC_ResignedOn"
            TargetControlID="F_C_ResignedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonC_ResignedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEC_ResignedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_C_ResignedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVC_ResignedOn"
            runat = "server"
            ControlToValidate = "F_C_ResignedOn"
            ControlExtender = "MEEC_ResignedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnwpEmployees"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DateOfReleaving" runat="server" Text="Date Of Releaving :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_C_DateOfReleaving"
            Text='<%# Bind("C_DateOfReleaving") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="atnwpEmployees"
            runat="server" />
          <asp:Image ID="ImageButtonC_DateOfReleaving" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEC_DateOfReleaving"
            TargetControlID="F_C_DateOfReleaving"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonC_DateOfReleaving" />
          <AJX:MaskedEditExtender 
            ID = "MEEC_DateOfReleaving"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_C_DateOfReleaving" />
          <AJX:MaskedEditValidator 
            ID = "MEVC_DateOfReleaving"
            runat = "server"
            ControlToValidate = "F_C_DateOfReleaving"
            ControlExtender = "MEEC_DateOfReleaving"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnwpEmployees"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_ResignedRemark" runat="server" Text="Resigned Remark :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_C_ResignedRemark"
            Text='<%# Bind("C_ResignedRemark") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="atnwpEmployees"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Resigned Remark."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVC_ResignedRemark"
            runat = "server"
            ControlToValidate = "F_C_ResignedRemark"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnwpEmployees"
            SetFocusOnError="true" />
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
  ID = "ODSatnwpEmployees"
  DataObjectTypeName = "SIS.ATN.atnwpEmployees"
  SelectMethod = "atnwpEmployeesGetByID"
  UpdateMethod="UZ_atnwpEmployeesUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnwpEmployees"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
