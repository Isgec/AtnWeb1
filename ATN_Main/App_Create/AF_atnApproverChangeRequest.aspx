<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnApproverChangeRequest.aspx.vb" Inherits="AF_atnApproverChangeRequest" title="Add: Approver/Verifier Change Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
	<div id="div2" class="page" style="width:600px">
    <div id="div3" class="caption">
			<asp:Label ID="LabelatnAppliedApplications" runat="server"  Text="&nbsp;Create Approver/Verifier Change Request"></asp:Label>
    </div>
    <div id="div4" class="pagedata" style="min-height:300px">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "atnApproverChangeRequest"
      runat = "server" />
 <asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "RequestID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
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
					<b><asp:Label ID="LabelRequestID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextRequestID" runat="server" Text="0" />
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
        <td>
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
						onfocus = "return this.select();"
						Width = "200px"
						AutoCompleteType = "None"
					  Enabled='<%# Eval("VerificationRequired") %>'
            ToolTip="Enter value for Verifier."
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderVerifierID"
						runat = "server"
            WatermarkText="[Enter Verifier]"
            WatermarkCssClass="watermark"
						TargetControlID="LC_VerifierIDEmployeeName1" />
          <AJX:AutoCompleteExtender
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
        <td>
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
						onfocus = "return this.select();"
						Width = "200px"
						AutoCompleteType = "None"
					  Enabled='<%# Eval("ApprovalRequired") %>'
            ToolTip="Enter value for Approver."
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderApproverID"
						runat = "server"
            WatermarkText="[Enter Approver]"
            WatermarkCssClass="watermark"
						TargetControlID="LC_ApproverIDEmployeeName1" />
          <AJX:AutoCompleteExtender
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
		</table>
	</InsertItemTemplate>
</asp:FormView>

 </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnApproverChangeRequest"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnApproverChangeRequest"
  SelectMethod = "GetByID"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" Name="RequestID" QueryStringField="Code" Type="Int32" />
</SelectParameters>
<InsertParameters>
  <asp:Parameter Name="RequestID" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
