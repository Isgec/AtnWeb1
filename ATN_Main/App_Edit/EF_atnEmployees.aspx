<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnEmployees.aspx.vb" Inherits="EF_atnEmployees" title="Edit: Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
    <asp:Label ID="LabelatnEmployees" runat="server" Text="Edit Employees" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNL1" runat="server" >
<ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      EnableDelete = "False"
      ValidationGroup = "atnEmployees"
      SearchContext = "atnEmployees"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnEmployees.aspx"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CardNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <script type="text/javascript">
    	function vrf_click(o) {
    	    var p = document.getElementById('cph1_FormView1_LC_VerifierID1');
    		var q = document.getElementById('cph1_FormView1_LC_VerifierIDEmployeeName1');
    		if (o.checked == false) {
    			p.value = '';
    			q.value = '';
    			q.disabled = true;
    		} else {
    			q.disabled = false;
    		}

    	}
    	function apr_click(o) {
    		var p = document.getElementById('cph1_FormView1_LC_ApproverID1');
    		var q = document.getElementById('cph1_FormView1_LC_ApproverIDEmployeeName1');
    		if (o.checked == false) {
    			p.value = '';
    			q.value = '';
    			q.disabled = true;
    		} else {
    			q.disabled = false;
    		}

    	}
    </script>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelCardNo" runat="server" Text="Card No :" /></b>
				</td>
				<td>
					<asp:Label ID="TextCardNo" runat="server" Text='<%# Bind("CardNo") %>' />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelEmployeeName" runat="server" Text="Employee Name :" /></b>
				</td>
        <td>
          <asp:Label ID="TextEmployeeName" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelVerificationRequired" runat="server" Text="Verification Required :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxVerificationRequired"
						  Checked='<%# Bind("VerificationRequired") %>'
						  onclick="return vrf_click(this);"
              runat="server" />
				</td>
			</tr>
      <tr>
        <td class="alignright" ><b>Verifier :</b></td>
        <td style="Padding-left: 5px;">
					<asp:TextBox
						ID = "LC_VerifierID1"
						CssClass = "mytxt"
						Width = "40px"
						Text='<%# Bind("VerifierID") %>'
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_VerifierIDEmployeeName1"
						Text='<%# Bind("VerifierIDEmployeeName") %>'
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
					  Enabled="false"
            ToolTip="Enter value for Verifier."
						ValidationGroup = "atnEmployees"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderVerifierID"
						runat = "server"
            WatermarkText="[Enter Verifier]"
						TargetControlID="LC_VerifierIDEmployeeName1" />
<%--					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorVerifierID"
						runat = "server"
						ControlToValidate = "LC_VerifierIDEmployeeName1"
						Text = "Verifier is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnEmployees"
						SetFocusOnError="true" />
--%>          <AJX:AutoCompleteExtender
            ID="LC_VerifierID1_AutoCompleteExtender"
            ServiceMethod="VerifierIDCompletionList"
            TargetControlID="LC_VerifierIDEmployeeName1"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_VerifierID1_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelApprovalRequired" runat="server" Text="Approval Required :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxApprovalRequired"
						  Checked='<%# Bind("ApprovalRequired") %>'
						  onclick="return apr_click(this);"
              runat="server" />
				</td>
			</tr>
      <tr>
        <td class="alignright" ><b>Approver :</b></td>
        <td style="Padding-left: 5px;">
					<asp:TextBox
						ID = "LC_ApproverID1"
						CssClass = "mytxt"
						Width = "40px"
						Text='<%# Bind("ApproverID") %>'
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_ApproverIDEmployeeName1"
						Text='<%# Bind("ApproverIDEmployeeName") %>'
						CssClass = "mytxt"
						Width = "200px"
					  Enabled="false"
						AutoCompleteType = "None"
            ToolTip="Enter value for Approver."
						ValidationGroup = "atnEmployees"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderApproverID"
						runat = "server"
            WatermarkText="[Enter Approver]"
						TargetControlID="LC_ApproverIDEmployeeName1" />
<%--					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorApproverID"
						runat = "server"
						ControlToValidate = "LC_ApproverIDEmployeeName1"
						Text = "Approver is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnEmployees"
						SetFocusOnError="true" />
--%>          <AJX:AutoCompleteExtender
            ID="LC_ApproverID1_AutoCompleteExtender"
            ServiceMethod="ApproverIDCompletionList"
            TargetControlID="LC_ApproverIDEmployeeName1"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_ApproverID1_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DateOfJoining" runat="server" Text="Date Of Joining :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DateOfJoining" runat="server" Text='<%# Bind("C_DateOfJoining") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DateOfReleaving" runat="server" Text="Date Of Releaving :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DateOfReleaving" runat="server" Text='<%# Bind("C_DateOfReleaving") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_CompanyID" runat="server" Text="Company :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_CompanyID" runat="server" Text='<%# Eval("C_CompanyIDHRM_Companies.Description") %>'></asp:Label>
          <asp:Label ID="TextC_CompanyIDHidden" style="display:none" runat="server" Text='<%# Bind("C_CompanyID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DivisionID" runat="server" Text="Division :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DivisionID" runat="server" Text='<%# Eval("C_DivisionIDHRM_Divisions.Description") %>'></asp:Label>
          <asp:Label ID="TextC_DivisionIDHidden" style="display:none" runat="server" Text='<%# Bind("C_DivisionID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_OfficeID" runat="server" Text="Office :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_OfficeID" runat="server" Text='<%# Eval("C_OfficeIDHRM_Offices.Description") %>'></asp:Label>
          <asp:Label ID="TextC_OfficeIDHidden" style="display:none" runat="server" Text='<%# Bind("C_OfficeID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DepartmentID" runat="server" Text="Department :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DepartmentID" runat="server" Text='<%# Eval("C_DepartmentIDHRM_Departments.Description") %>'></asp:Label>
          <asp:Label ID="TextC_DepartmentIDHidden" style="display:none" runat="server" Text='<%# Bind("C_DepartmentID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DesignationID" runat="server" Text="Designation :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DesignationID" runat="server" Text='<%# Eval("C_DesignationIDHRM_Designations.Description") %>'></asp:Label>
          <asp:Label ID="TextC_DesignationIDHidden" style="display:none" runat="server" Text='<%# Bind("C_DesignationID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelActiveState" runat="server" Text="Active State :" /></b>
				</td>
        <td>
          <asp:Label ID="TextActiveState" runat="server" Text='<%# Bind("ActiveState") %>'></asp:Label>
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnEmployees"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnEmployees"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="CardNo" Type="String" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="CardNo" Type="String" />
</UpdateParameters>
</asp:ObjectDataSource>
    </div>
</div>
</asp:Content>
