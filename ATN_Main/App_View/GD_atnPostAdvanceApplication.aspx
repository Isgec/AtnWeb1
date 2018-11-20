<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnPostAdvanceApplication.aspx.vb" Inherits="GD_atnPostAdvanceApplication" title="Display List: Post Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <script type="text/javascript" src="../../App_Scripts/ShowApplicationDays.js"></script>
    <LGM:LGMessage 
			ID="LGMessage1" 
		  Width = "600"
			runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnPostApplication"
      SearchContext = "atnPostApplication"
      runat = "server" />
    <hr />
    <asp:Label ID="LabelatnPostApplication" runat="server" Text="List Post Advance Application" ></asp:Label>
    <hr />
    <table>
      <tr>
        <td class="alignright" ><b>Employee :</b></td>
        <td style="Padding-left: 5px;">
					<script type="text/javascript">
						function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
							var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
							LC_CardNo1.value = e.get_value();
							__doPostBack('<%= LC_CardNo1.ClientID %>', e.get_value());
						}
					</script>
					<asp:TextBox
						ID = "LC_CardNo1"
						CssClass = "mytxt"
						Width = "40px"
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_CardNoEmployeeName1"
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="LC_CardNo1_AutoCompleteExtender"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="LC_CardNoEmployeeName1"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="LeaveApplID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<input type="image" id='<%#Eval("LeaveApplID","cmdInfo{0}") %>' alt='<%# Eval("LeaveApplID") %>' title="Detailed Information." src="../../App_Themes/Default/Images/Info.png" onclick="showDetails(this);return false;" />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="LeaveApplID">
          <ItemTemplate>
            <asp:Label ID="LabelLeaveApplID" runat="server" Text='<%# Bind("LeaveApplID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelCardNo" ToolTip='<%#Eval("CardNo") %>'  runat="server" Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location">
          <ItemTemplate>
             <asp:Label ID="LabelLocation" ToolTip='<%#Eval("CardNoHRM_Employees.C_OfficeID") %>'  runat="server" Text='<%# Eval("CardNoHRM_Employees.C_OfficeIDHRM_Offices.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Applied Remarks" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Applied On" SortExpression="AppliedOn">
          <ItemTemplate>
            <asp:Label ID="LabelAppliedOn" runat="server" Text='<%# Bind("AppliedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comments">
          <ItemTemplate>
						<asp:TextBox ID="F_Remarks" runat="server" CssClass="mytxt" Width="150px" MaxLength="100" ToolTip="Enter Comments" BehaviorID='<%# Eval("LeaveApplID") %>' Text='<%# Bind("PostingRemark") %>'></asp:TextBox>
          </ItemTemplate>
        <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Post">
          <ItemTemplate>
						<asp:ImageButton ID="Posted" runat="server" ToolTip="Click to Post" ImageUrl="~/App_Themes/Default/Images/docok.png" CommandName="Posted" CommandArgument='<%# Container.DataItemIndex %>'  />
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cancel">
          <ItemTemplate>
						<asp:ImageButton ID="Rejected" runat="server" ToolTip="Click to Cancel" ImageUrl="~/App_Themes/Default/Images/docreject.png"   CommandName="Rejected" CommandArgument='<%# Container.DataItemIndex %>'/>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Execution State" SortExpression="ATN_ExecutionStates3_Description">
          <ItemTemplate>
             <asp:Label ID="LabelExecutionState" runat="server" Text='<%# Eval("ExecutionStateATN_ExecutionStates.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
      <RowStyle BackColor="PaleGoldenrod" />
      <PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
      <HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" />
      <AlternatingRowStyle BackColor="Bisque" />
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnPostAdvanceApplication"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnPostAdvanceApplication"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="LC_CardNo1" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="LC_CardNo1" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
