<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnPunchRequired.aspx.vb" Inherits="GF_atnPunchRequired" title="Maintain List: Punch Required" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
    <asp:Label ID="LabelatnPunchRequired" runat="server" Text="List Punch Required" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "atnPunchRequired"
      SearchContext = "atnPunchRequired"
      runat = "server" />
    <hr />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table>
    </table>
		<script type="text/javascript">
		  function LC_CardNo2_AutoCompleteExtender_Selected(sender, e) {
				var LC_CardNo2 = $get('<%= LC_CardNo2.ClientID %>');
				LC_CardNo2.value = e.get_value();
		 }
		</script>
		<asp:TextBox
			ID = "LC_CardNo2"
			CssClass = "mytxt"
			Width = "40px"
			AutoCompleteType = "None"
			Style="display:none"
			Runat="Server" />
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="RecordID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<table>
							<tr>
								<td>
									<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandArgument='<%# Bind("RecordID") %>' OnClick="Edit_Click" />
								</td>
								<td>
									<asp:ImageButton ID="FastEdit" runat="server" AlternateText="InLineEdit" ToolTip="Inlie Edit the record." SkinID="FastEdit" CommandArgument='<%# Bind("RecordID") %>' CommandName="Edit" />
								</td>
							</tr>
						</table>
          </ItemTemplate>
          <HeaderStyle Width="70px" />
					<EditItemTemplate>
						<table>
							<tr>
								<td>
									<asp:ImageButton ID="Save" runat="server" AlternateText="Save" ToolTip="Save changes." SkinID="save" CommandArgument='<%# Bind("RecordID") %>' commandName="Update" ValidationGroup = "atnPunchRequired" />
								</td>
								<td>
									<asp:ImageButton ID="Cancel" runat="server" AlternateText="Cancel" ToolTip="Cancel changes." SkinID="cancel" CommandArgument='<%# Bind("RecordID") %>' commandname="Cancel" />
								</td>
							</tr>
						</table>
					</EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="RecordID">
          <ItemTemplate>
            <asp:Label ID="LabelRecordID" runat="server" Text='<%# Bind("RecordID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CardNo" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelCardNo" runat="server" Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        <EditItemTemplate>
					<asp:TextBox
						ID = "LC_CardNo2"
						CssClass = "mytxt"
						Width = "40px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_CardNoEmployeeName2"
						Text='<%# Bind("CardNoEmployeeName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						Width = "200px"
						AutoCompleteType = "None"
            ToolTip="Enter value for CardNo."
						ValidationGroup = "atnPunchRequired"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderCardNo1"
						runat = "server"
            WatermarkText="[Enter CardNo]"
            WatermarkCssClass="watermark"
						TargetControlID="LC_CardNoEmployeeName2" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorCardNo1"
						runat = "server"
						ControlToValidate = "LC_CardNoEmployeeName2"
						Text = "CardNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnPunchRequired"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="LC_CardNo2_AutoCompleteExtender"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="LC_CardNoEmployeeName2"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_CardNo2_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No Card Punch Required" SortExpression="NoPunch">
          <ItemTemplate>
            <asp:Label ID="LabelNoPunch" runat="server" Text='<%# Bind("NoPunch") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBoxNoPunch"
						  Checked='<%# Bind("NoPunch") %>'
              runat="server" />
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Only One Punch Required" SortExpression="OnePunch">
          <ItemTemplate>
            <asp:Label ID="LabelOnePunch" runat="server" Text='<%# Bind("OnePunch") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBoxOnePunch"
						  Checked='<%# Bind("OnePunch") %>'
              runat="server" />
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Use Exception Punch Rules" SortExpression="RuleException">
          <ItemTemplate>
            <asp:Label ID="LabelRuleException" runat="server" Text='<%# Bind("RuleException") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBoxRuleException"
						  Checked='<%# Bind("RuleException") %>'
              runat="server" />
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch at Any Location" SortExpression="AllLocation">
          <ItemTemplate>
            <asp:Label ID="LabelAllLocation" runat="server" Text='<%# Bind("AllLocation") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBoxAllLocation"
						  Checked='<%# Bind("AllLocation") %>'
              runat="server" />
        </EditItemTemplate>
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
      DataObjectTypeName = "SIS.ATN.atnPunchRequired"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      UpdateMethod = "Update"
      TypeName = "SIS.ATN.atnPunchRequired"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>
