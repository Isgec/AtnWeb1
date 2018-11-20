<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnApproverChangeRequest.aspx.vb" Inherits="EF_atnApproverChangeRequest" title="Edit: Approver/Verifier Change Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
    <asp:Label ID="LabelatnApproverChangeRequest" runat="server" Text="Edit Approver/Verifier Change Request" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNL1" runat="server" >
<ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnApproverChangeRequest"
      SearchContext = "atnApproverChangeRequest"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnApproverChangeRequest.aspx"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "RequestID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRequestID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextRequestID" runat="server" Text='<%# Bind("RequestID") %>' />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelVerificationRequired" runat="server" Text="Verification Required :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxVerificationRequired"
						  Checked='<%# Bind("VerificationRequired") %>'
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnApproverChangeRequest"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnApproverChangeRequest"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="RequestID" Type="Int32" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="RequestID" Type="Int32" />
</UpdateParameters>
</asp:ObjectDataSource>
    </div>
</div>
</asp:Content>
