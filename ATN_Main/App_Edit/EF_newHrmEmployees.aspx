<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_newHrmEmployees.aspx.vb" Inherits="EF_newHrmEmployees" title="Edit: Employee" %>
<asp:Content ID="CPHnewHrmEmployees" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnewHrmEmployees" runat="server" Text="&nbsp;Edit: Employee"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnewHrmEmployees" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnewHrmEmployees"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "newHrmEmployees"
    runat = "server" />
<asp:FormView ID="FVnewHrmEmployees"
  runat = "server"
  DataKeyNames = "CardNo"
  DataSourceID = "ODSnewHrmEmployees"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="Card No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_CardNo"
            Text='<%# Bind("CardNo") %>'
            ToolTip="Value of Card No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="72px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EmployeeName" runat="server" Text="Employee Name :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_EmployeeName"
            Text='<%# Bind("EmployeeName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="newHrmEmployees"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Employee Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVEmployeeName"
            runat = "server"
            ControlToValidate = "F_EmployeeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "newHrmEmployees"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DivisionID" runat="server" Text="Division ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_hrmDivisions
            ID="F_C_DivisionID"
            SelectedValue='<%# Bind("C_DivisionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_C_OfficeID" runat="server" Text="Office ID :" />&nbsp;
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
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DepartmentID" runat="server" Text="Department ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_hrmDepartments
            ID="F_C_DepartmentID"
            SelectedValue='<%# Bind("C_DepartmentID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_C_DesignationID" runat="server" Text="Designation ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_hrmDesignations
            ID="F_C_DesignationID"
            SelectedValue='<%# Bind("C_DesignationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ActiveState" runat="server" Text="Active State :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ActiveState"
            Checked='<%# Bind("ActiveState") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taCategories
            ID="F_CategoryID"
            SelectedValue='<%# Bind("CategoryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Salute" runat="server" Text="Salute :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Salute"
            Text='<%# Bind("Salute") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Salute."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Gender" runat="server" Text="Gender :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Gender"
            Text='<%# Bind("Gender") %>'
            Width="16px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Gender."
            MaxLength="1"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DateOfJoining" runat="server" Text="Date Of Joining :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_DateOfJoining"
            Text='<%# Bind("C_DateOfJoining") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonC_DateOfJoining" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEC_DateOfJoining"
            TargetControlID="F_C_DateOfJoining"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonC_DateOfJoining" />
          <AJX:MaskedEditExtender 
            ID = "MEEC_DateOfJoining"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_C_DateOfJoining" />
          <AJX:MaskedEditValidator 
            ID = "MEVC_DateOfJoining"
            runat = "server"
            ControlToValidate = "F_C_DateOfJoining"
            ControlExtender = "MEEC_DateOfJoining"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_ProjectSiteID" runat="server" Text="Project Site ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_C_ProjectSiteID"
            CssClass = "myfktxt"
            Text='<%# Bind("C_ProjectSiteID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project Site ID."
            onblur= "script_newHrmEmployees.validate_C_ProjectSiteID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_C_ProjectSiteID_Display"
            Text='<%# Eval("IDM_Projects36_Description") %>'
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
            OnClientItemSelected="script_newHrmEmployees.ACEC_ProjectSiteID_Selected"
            OnClientPopulating="script_newHrmEmployees.ACEC_ProjectSiteID_Populating"
            OnClientPopulated="script_newHrmEmployees.ACEC_ProjectSiteID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_BasicSalary" runat="server" Text="Basic Salary :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_BasicSalary"
            Text='<%# Bind("C_BasicSalary") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEC_BasicSalary"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_C_BasicSalary" />
          <AJX:MaskedEditValidator 
            ID = "MEVC_BasicSalary"
            runat = "server"
            ControlToValidate = "F_C_BasicSalary"
            ControlExtender = "MEEC_BasicSalary"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_StatusID" runat="server" Text="Status ID :" />&nbsp;
        </td>
        <td>
          <asp:DropDownList
            ID="F_C_StatusID"
            SelectedValue='<%# Bind("C_StatusID") %>'
            CssClass = "myddl"
            Width="200px"
            Runat="Server" >
            <asp:ListItem Value="CO">CONFIRMED</asp:ListItem>
            <asp:ListItem Value="PR">PROBATION</asp:ListItem>
            <asp:ListItem Value="RE">RESIGNED</asp:ListItem>
            <asp:ListItem Value="RL">RELEAVED</asp:ListItem>
            <asp:ListItem Value="TR">TRAINEE</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
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
          <asp:Label ID="L_C_ResignedOn" runat="server" Text="Resigned On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_ResignedOn"
            Text='<%# Bind("C_ResignedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
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
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DateOfReleaving" runat="server" Text="Date Of Releaving :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_DateOfReleaving"
            Text='<%# Bind("C_DateOfReleaving") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
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
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_ResignedRemark" runat="server" Text="Resigned Remark :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_ResignedRemark"
            Text='<%# Bind("C_ResignedRemark") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Resigned Remark."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Confirmed" runat="server" Text="Confirmed :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Confirmed"
            Checked='<%# Bind("Confirmed") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_ConfirmedOn" runat="server" Text="Confirmed On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_ConfirmedOn"
            Text='<%# Bind("C_ConfirmedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonC_ConfirmedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEC_ConfirmedOn"
            TargetControlID="F_C_ConfirmedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonC_ConfirmedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEC_ConfirmedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_C_ConfirmedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVC_ConfirmedOn"
            runat = "server"
            ControlToValidate = "F_C_ConfirmedOn"
            ControlExtender = "MEEC_ConfirmedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_ConfirmationRemark" runat="server" Text="Confirmation Remark :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_ConfirmationRemark"
            Text='<%# Bind("C_ConfirmationRemark") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Confirmation Remark."
            MaxLength="250"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DateOfBirth" runat="server" Text="Date Of Birth :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DateOfBirth"
            Text='<%# Bind("DateOfBirth") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDateOfBirth" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDateOfBirth"
            TargetControlID="F_DateOfBirth"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDateOfBirth" />
          <AJX:MaskedEditExtender 
            ID = "MEEDateOfBirth"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DateOfBirth" />
          <AJX:MaskedEditValidator 
            ID = "MEVDateOfBirth"
            runat = "server"
            ControlToValidate = "F_DateOfBirth"
            ControlExtender = "MEEDateOfBirth"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FatherName" runat="server" Text="Father Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FatherName"
            Text='<%# Bind("FatherName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Father Name."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ContactNumbers" runat="server" Text="Contact Numbers :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ContactNumbers"
            Text='<%# Bind("ContactNumbers") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Numbers."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OfficeFileNumber" runat="server" Text="Office File Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OfficeFileNumber"
            Text='<%# Bind("OfficeFileNumber") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Office File Number."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PFNumber" runat="server" Text="PF Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PFNumber"
            Text='<%# Bind("PFNumber") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PF Number."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PAN" runat="server" Text="PAN :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PAN"
            Text='<%# Bind("PAN") %>'
            Width="168px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PAN."
            MaxLength="20"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ModifiedBy" runat="server" Text="Modified By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ModifiedBy"
            Text='<%# Bind("ModifiedBy") %>'
            Width="168px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Modified By."
            MaxLength="20"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Freezed" runat="server" Text="Freezed :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Freezed"
            Checked='<%# Bind("Freezed") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ESINumber" runat="server" Text="ESI Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ESINumber"
            Text='<%# Bind("ESINumber") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ESI Number."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerifierID" runat="server" Text="Verifier ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_VerifierID"
            CssClass = "myfktxt"
            Text='<%# Bind("VerifierID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Verifier ID."
            onblur= "script_newHrmEmployees.validate_VerifierID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_VerifierID_Display"
            Text='<%# Eval("HRM_Employees16_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEVerifierID"
            BehaviorID="B_ACEVerifierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="VerifierIDCompletionList"
            TargetControlID="F_VerifierID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_newHrmEmployees.ACEVerifierID_Selected"
            OnClientPopulating="script_newHrmEmployees.ACEVerifierID_Populating"
            OnClientPopulated="script_newHrmEmployees.ACEVerifierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerificationRequired" runat="server" Text="Verification Required :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_VerificationRequired"
            Checked='<%# Bind("VerificationRequired") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_CompanyID" runat="server" Text="Company ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_hrmCompanies
            ID="F_C_CompanyID"
            SelectedValue='<%# Bind("C_CompanyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovalRequired" runat="server" Text="Approval Required :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ApprovalRequired"
            Checked='<%# Bind("ApprovalRequired") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModifiedOn" runat="server" Text="Modified On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ModifiedOn"
            Text='<%# Bind("ModifiedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonModifiedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEModifiedOn"
            TargetControlID="F_ModifiedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonModifiedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEModifiedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ModifiedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVModifiedOn"
            runat = "server"
            ControlToValidate = "F_ModifiedOn"
            ControlExtender = "MEEModifiedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EMailID" runat="server" Text="EMail ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_EMailID"
            Text='<%# Bind("EMailID") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for EMail ID."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverID" runat="server" Text="Approver ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApproverID"
            CssClass = "myfktxt"
            Text='<%# Bind("ApproverID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Approver ID."
            onblur= "script_newHrmEmployees.validate_ApproverID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ApproverID_Display"
            Text='<%# Eval("HRM_Employees17_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEApproverID"
            BehaviorID="B_ACEApproverID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApproverIDCompletionList"
            TargetControlID="F_ApproverID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_newHrmEmployees.ACEApproverID_Selected"
            OnClientPopulating="script_newHrmEmployees.ACEApproverID_Populating"
            OnClientPopulated="script_newHrmEmployees.ACEApproverID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
          <asp:Label ID="L_SiteAllowanceApprover" runat="server" Text="Site Allowance Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SiteAllowanceApprover"
            CssClass = "myfktxt"
            Text='<%# Bind("SiteAllowanceApprover") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Site Allowance Approver."
            onblur= "script_newHrmEmployees.validate_SiteAllowanceApprover(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SiteAllowanceApprover_Display"
            Text='<%# Eval("HRM_Employees15_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESiteAllowanceApprover"
            BehaviorID="B_ACESiteAllowanceApprover"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SiteAllowanceApproverCompletionList"
            TargetControlID="F_SiteAllowanceApprover"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_newHrmEmployees.ACESiteAllowanceApprover_Selected"
            OnClientPopulating="script_newHrmEmployees.ACESiteAllowanceApprover_Populating"
            OnClientPopulated="script_newHrmEmployees.ACESiteAllowanceApprover_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TASelfApproval" runat="server" Text="TA Self Approval :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_TASelfApproval"
            Checked='<%# Bind("TASelfApproval") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
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
          <asp:Label ID="L_TAVerifier" runat="server" Text="TA Verifier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TAVerifier"
            CssClass = "myfktxt"
            Text='<%# Bind("TAVerifier") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Verifier."
            onblur= "script_newHrmEmployees.validate_TAVerifier(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TAVerifier_Display"
            Text='<%# Eval("HRM_Employees18_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETAVerifier"
            BehaviorID="B_ACETAVerifier"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TAVerifierCompletionList"
            TargetControlID="F_TAVerifier"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_newHrmEmployees.ACETAVerifier_Selected"
            OnClientPopulating="script_newHrmEmployees.ACETAVerifier_Populating"
            OnClientPopulated="script_newHrmEmployees.ACETAVerifier_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TASanctioningAuthority" runat="server" Text="TA Sanctioning Authority :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TASanctioningAuthority"
            CssClass = "myfktxt"
            Text='<%# Bind("TASanctioningAuthority") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Sanctioning Authority."
            onblur= "script_newHrmEmployees.validate_TASanctioningAuthority(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TASanctioningAuthority_Display"
            Text='<%# Eval("HRM_Employees20_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETASanctioningAuthority"
            BehaviorID="B_ACETASanctioningAuthority"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TASanctioningAuthorityCompletionList"
            TargetControlID="F_TASanctioningAuthority"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_newHrmEmployees.ACETASanctioningAuthority_Selected"
            OnClientPopulating="script_newHrmEmployees.ACETASanctioningAuthority_Populating"
            OnClientPopulated="script_newHrmEmployees.ACETASanctioningAuthority_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TAApprover" runat="server" Text="TA Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TAApprover"
            CssClass = "myfktxt"
            Text='<%# Bind("TAApprover") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Approver."
            onblur= "script_newHrmEmployees.validate_TAApprover(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TAApprover_Display"
            Text='<%# Eval("HRM_Employees19_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETAApprover"
            BehaviorID="B_ACETAApprover"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TAApproverCompletionList"
            TargetControlID="F_TAApprover"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_newHrmEmployees.ACETAApprover_Selected"
            OnClientPopulating="script_newHrmEmployees.ACETAApprover_Populating"
            OnClientPopulated="script_newHrmEmployees.ACETAApprover_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
  ID = "ODSnewHrmEmployees"
  DataObjectTypeName = "SIS.ATN.newHrmEmployees"
  SelectMethod = "newHrmEmployeesGetByID"
  UpdateMethod="UZ_newHrmEmployeesUpdate"
  DeleteMethod="UZ_newHrmEmployeesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.newHrmEmployees"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
