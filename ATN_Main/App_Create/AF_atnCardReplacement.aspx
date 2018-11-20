<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnCardReplacement.aspx.vb" Inherits="AF_atnCardReplacement" title="Add: Card Replacement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnCardReplacement" runat="server" Text="Add Card Replacement" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "atnCardReplacement"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ReplacedCardNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
		<table>
			<tr>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelReplacedCardNo" runat="server" Text="Replaced Card No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxReplacedCardNo"
						Text='<%# Bind("ReplacedCardNo") %>'
            CssClass="mytxt"
						runat="server"
            onblur= "validate_ReplacedCardNo(this);"
						ValidationGroup="atnCardReplacement"
            ToolTip="Enter value for Replaced Card No."
            Width="60px"
						MaxLength="8" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderReplacedCardNo"
						runat = "server"
            WatermarkText="[Enter Replaced Card No]"
						TargetControlID="TextBoxReplacedCardNo" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorReplacedCardNo"
						runat = "server"
						ControlToValidate = "TextBoxReplacedCardNo"
						Text = "Replaced Card No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnCardReplacement"
						SetFocusOnError="true" />
				</td>
			</tr>
      <tr>
        <td class="alignright" ><b>Card No :</b></td>
        <td style="Padding-left: 5px;">
					<asp:TextBox
						ID = "LC_CardNo1"
						CssClass = "mytxt"
						Width = "40px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_CardNoEmployeeName1"
						Text='<%# Bind("CardNoEmployeeName") %>'
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
            ToolTip="Enter value for Card No."
						ValidationGroup = "atnCardReplacement"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderCardNo"
						runat = "server"
            WatermarkText="[Enter Card No]"
						TargetControlID="LC_CardNoEmployeeName1" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorCardNo"
						runat = "server"
						ControlToValidate = "LC_CardNoEmployeeName1"
						Text = "Card No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnCardReplacement"
						SetFocusOnError="true" />
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
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnCardReplacement"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnCardReplacement"
  SelectMethod = "GetByID"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" Name="ReplacedCardNo" QueryStringField="Code" Type="String" />
</SelectParameters>
<InsertParameters>
  <asp:Parameter Name="ReplacedCardNo" Type="String" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
