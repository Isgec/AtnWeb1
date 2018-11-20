<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnCardReplacement.aspx.vb" Inherits="GF_atnCardReplacement" title="Maintain List: Card Replacement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
    <asp:Label ID="LabelatnCardReplacement" runat="server" Text="List Card Replacement"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "atnCardReplacement"
      SearchContext = "atnCardReplacement"
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
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="ReplacedCardNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandArgument='<%# Bind("ReplacedCardNo") %>' OnClick="Edit_Click" />
						&nbsp;
            <asp:ImageButton ID="FastEdit" runat="server" AlternateText="InLineEdit" ToolTip="Inlie Edit the record." SkinID="FastEdit" CommandArgument='<%# Bind("ReplacedCardNo") %>' CommandName="Edit" />
          </ItemTemplate>
          <HeaderStyle Width="70px" />
					<EditItemTemplate>
						<asp:ImageButton ID="Save" runat="server" AlternateText="Save" ToolTip="Save changes." SkinID="save" CommandArgument='<%# Bind("ReplacedCardNo") %>' commandName="Update" ValidationGroup = "atnCardReplacement" />
						&nbsp;
						<asp:ImageButton ID="Cancel" runat="server" AlternateText="Cancel" ToolTip="Cancel changes." SkinID="cancel" CommandArgument='<%# Bind("ReplacedCardNo") %>' commandname="Cancel" />
					</EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:ImageButton ID="Info" runat="server" AlternateText="Info" ToolTip="Detailed Information." SkinID="Info" CommandArgument='<%# Bind("ReplacedCardNo") %>' OnClick="Info_Click" />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Replaced Card No" SortExpression="ReplacedCardNo">
          <ItemTemplate>
            <asp:Label ID="LabelReplacedCardNo" runat="server" Text='<%# Bind("ReplacedCardNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees1_EmployeeName">
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
						Width = "200px"
						AutoCompleteType = "None"
            ToolTip="Enter value for Card No."
						ValidationGroup = "atnCardReplacement"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderCardNo1"
						runat = "server"
            WatermarkText="[Enter Card No]"
						TargetControlID="LC_CardNoEmployeeName2" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorCardNo1"
						runat = "server"
						ControlToValidate = "LC_CardNoEmployeeName2"
						Text = "Card No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnCardReplacement"
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
      DataObjectTypeName = "SIS.ATN.atnCardReplacement"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      UpdateMethod = "Update"
      TypeName = "SIS.ATN.atnCardReplacement"
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
