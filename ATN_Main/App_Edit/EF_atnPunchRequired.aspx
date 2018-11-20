<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnPunchRequired.aspx.vb" Inherits="EF_atnPunchRequired" title="Edit: Punch Required" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnPunchRequired"
      SearchContext = "atnPunchRequired"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnPunchRequired.aspx"
   runat = "server" />
   <asp:Label ID="LabelatnPunchRequired" runat="server" Text="Edit Punch Required" ></asp:Label>
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "RecordID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRecordID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextRecordID" runat="server" Text='<%# Bind("RecordID") %>' />
				</td>
			</tr>
      <tr>
        <td class="alignright" ><b>CardNo :</b></td>
        <td>
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
						onfocus = "return this.select();"
						Width = "200px"
						AutoCompleteType = "None"
            ToolTip="Enter value for CardNo."
						ValidationGroup = "atnPunchRequired"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderCardNo"
						runat = "server"
            WatermarkText="[Enter CardNo]"
            WatermarkCssClass="watermark"
						TargetControlID="LC_CardNoEmployeeName1" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorCardNo"
						runat = "server"
						ControlToValidate = "LC_CardNoEmployeeName1"
						Text = "CardNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnPunchRequired"
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
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelNoPunch" runat="server" Text="No Card Punch Required :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxNoPunch"
						  Checked='<%# Bind("NoPunch") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelOnePunch" runat="server" Text="Only One Punch Required :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxOnePunch"
						  Checked='<%# Bind("OnePunch") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRuleException" runat="server" Text="Use Exception Punch Rules :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxRuleException"
						  Checked='<%# Bind("RuleException") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelAllLocation" runat="server" Text="Punch at Any Location :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxAllLocation"
						  Checked='<%# Bind("AllLocation") %>'
              runat="server" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnPunchRequired"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnPunchRequired"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="RecordID" Type="Int32" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="RecordID" Type="Int32" />
</UpdateParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
