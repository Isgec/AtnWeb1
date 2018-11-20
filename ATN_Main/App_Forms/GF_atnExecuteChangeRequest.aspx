<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnExecuteChangeRequest.aspx.vb" Inherits="GF_atnExecuteChangeRequest" title="Maintain List: Approver/Verifier Change Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
			<asp:Label ID="LabelatnAppliedApplications" runat="server" Font-Bold="true" Font-Size="14px" Text="List Approver/Verifier Change Request"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "atnExecuteChangeRequest"
      SearchContext = "atnExecuteChangeRequest"
      runat = "server" />
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright" ><b>User :</b></td>
        <td style="Padding-left: 5px;">
					<script type="text/javascript">
						function LC_UserID1_AutoCompleteExtender_Selected(sender, e) {
							var LC_UserID1 = $get('<%= LC_UserID1.ClientID %>');
							LC_UserID1.value = e.get_value();
							__doPostBack('<%= LC_UserID1.ClientID %>', e.get_value());
						}
					</script>
					<asp:TextBox
						ID = "LC_UserID1"
						CssClass = "mytxt"
						Width = "40px"
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_UserIDEmployeeName1"
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="LC_UserID1_AutoCompleteExtender"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="LC_UserIDEmployeeName1"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_UserID1_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Label ID="L_Error" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" DataSourceID="ObjectDataSource1" DataKeyNames="RequestID">
      <Columns>
        <asp:TemplateField HeaderText="ID" SortExpression="RequestID">
          <ItemTemplate>
            <asp:Label ID="LabelRequestID" runat="server" Text='<%# Bind("RequestID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="80px" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested By" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelUserID" ToolTip='<%#Eval("UserID") %>'  runat="server" Text='<%# Eval("UserIDHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verifier" SortExpression="HRM_Employees2_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelVerifierID" ToolTip='<%#Eval("VerifierID") %>' runat="server" Text='<%# Eval("VerifierIDHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approver" SortExpression="HRM_Employees3_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelApproverID" ToolTip='<%#Eval("ApproverID") %>' runat="server" Text='<%# Eval("ApproverIDHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested On" SortExpression="RequestedOn">
          <ItemTemplate>
            <asp:Label ID="LabelRequestedOn" runat="server" Text='<%# Bind("RequestedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Execute">
          <ItemTemplate>
						<asp:ImageButton ID="Execute" Visible='<%#Eval("EnableEdit") %>' runat="server" ToolTip="Click to Execute" ImageUrl="~/App_Themes/Default/Images/docok.png" CommandName="Execute" CommandArgument='<%# Container.DataItemIndex %>'  />
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="80px" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
						<asp:ImageButton ID="cmdDelete" Visible='<%#Eval("EnableEdit") %>' runat="server" ToolTip="Click to Delete" ImageUrl="~/App_Themes/Default/Images/docreject.png" CommandName="lgDelete" CommandArgument='<%# Container.DataItemIndex %>'/>
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="80px" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnExecuteChangeRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnExecuteChangeRequest"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="LC_UserID1" PropertyName="Text" Name="UserID" Type="String" Size="8" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
    <asp:AsyncPostBackTrigger ControlID="LC_UserID1" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
