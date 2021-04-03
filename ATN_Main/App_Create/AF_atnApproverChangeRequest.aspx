<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnApproverChangeRequest.aspx.vb" Inherits="AF_atnApproverChangeRequest" title="Add: Approver/Verifier Change Request" %>
<asp:Content ID="CPHatnApproverChangeRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnApproverChangeRequest" runat="server" Text="&nbsp;Add: Approver/Verifier Change Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnApproverChangeRequest" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnApproverChangeRequest"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "atnApproverChangeRequest"
    runat = "server" />
<asp:FormView ID="FVatnApproverChangeRequest"
  runat = "server"
  DataKeyNames = "RequestID"
  DataSourceID = "ODSatnApproverChangeRequest"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgatnApproverChangeRequest" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" ForeColor="#CC6633" runat="server" Text="ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RequestID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerifierID" runat="server" Text="Leave Application Verifier :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_VerifierID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("VerifierID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Leave Application Verifier."
            onblur= "script_atnApproverChangeRequest.validate_VerifierID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_VerifierID_Display"
            Text='<%# Eval("HRM_Employees2_EmployeeName") %>'
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
            OnClientItemSelected="script_atnApproverChangeRequest.ACEVerifierID_Selected"
            OnClientPopulating="script_atnApproverChangeRequest.ACEVerifierID_Populating"
            OnClientPopulated="script_atnApproverChangeRequest.ACEVerifierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverID" runat="server" Text="Leave Application Approver :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ApproverID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ApproverID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Leave Application Approver."
            ValidationGroup = "atnApproverChangeRequest"
            onblur= "script_atnApproverChangeRequest.validate_ApproverID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVApproverID"
            runat = "server"
            ControlToValidate = "F_ApproverID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnApproverChangeRequest"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ApproverID_Display"
            Text='<%# Eval("HRM_Employees3_EmployeeName") %>'
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
            OnClientItemSelected="script_atnApproverChangeRequest.ACEApproverID_Selected"
            OnClientPopulating="script_atnApproverChangeRequest.ACEApproverID_Populating"
            OnClientPopulated="script_atnApproverChangeRequest.ACEApproverID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TAVerifierID" runat="server" Text="TA Bill Verifier :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TAVerifierID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("TAVerifierID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Bill Verifier."
            onblur= "script_atnApproverChangeRequest.validate_TAVerifierID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TAVerifierID_Display"
            Text='<%# Eval("HRM_Employees4_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETAVerifierID"
            BehaviorID="B_ACETAVerifierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TAVerifierIDCompletionList"
            TargetControlID="F_TAVerifierID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnApproverChangeRequest.ACETAVerifierID_Selected"
            OnClientPopulating="script_atnApproverChangeRequest.ACETAVerifierID_Populating"
            OnClientPopulated="script_atnApproverChangeRequest.ACETAVerifierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TAApproverID" runat="server" Text="TA Bill Approver :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TAApproverID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("TAApproverID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Bill Approver."
            ValidationGroup = "atnApproverChangeRequest"
            onblur= "script_atnApproverChangeRequest.validate_TAApproverID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTAApproverID"
            runat = "server"
            ControlToValidate = "F_TAApproverID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnApproverChangeRequest"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_TAApproverID_Display"
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETAApproverID"
            BehaviorID="B_ACETAApproverID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TAApproverIDCompletionList"
            TargetControlID="F_TAApproverID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnApproverChangeRequest.ACETAApproverID_Selected"
            OnClientPopulating="script_atnApproverChangeRequest.ACETAApproverID_Populating"
            OnClientPopulated="script_atnApproverChangeRequest.ACETAApproverID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td colspan="4">
          <asp:Label runat="server" Font-Bold="true" Font-Italic="true" Font-Size="12px" Text="To change sanctioning authority pl. contact HR."></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TASA" runat="server" Text="TA Bill Santioning Authority :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TASA"
            CssClass = "dmyfktxt"
            Enabled="false"
            Width="72px"
            Text='<%# Bind("TASA") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Bill Santioning Authority."
            onblur= "script_atnApproverChangeRequest.validate_TASA(this);"
            Runat="Server" />
<%--          <asp:RequiredFieldValidator 
            ID = "RFVTASA"
            runat = "server"
            ControlToValidate = "F_TASA"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnApproverChangeRequest"
            SetFocusOnError="true" />--%>
          <asp:Label
            ID = "F_TASA_Display"
            Text='<%# Eval("HRM_Employees6_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETASA"
            BehaviorID="B_ACETASA"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TASACompletionList"
            TargetControlID="F_TASA"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnApproverChangeRequest.ACETASA_Selected"
            OnClientPopulating="script_atnApproverChangeRequest.ACETASA_Populating"
            OnClientPopulated="script_atnApproverChangeRequest.ACETASA_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSatnApproverChangeRequest"
  DataObjectTypeName = "SIS.ATN.atnApproverChangeRequest"
  InsertMethod="atnApproverChangeRequestInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnApproverChangeRequest"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
