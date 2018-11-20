<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnRawPunch.aspx.vb" Inherits="EF_atnRawPunch" title="Edit: Raw Punch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnRawPunch" runat="server" Text="Edit Raw Punch" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnRawPunch"
      SearchContext = "atnRawPunch"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnRawPunch.aspx"
      runat = "server" />
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
				<td class="alignright">
					<b><asp:Label ID="LabelPunchDate" runat="server" Text="Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxPunchDate"
						Text='<%# Bind("PunchDate") %>'
						ValidationGroup="atnRawPunch"
            Width="70px"
            CssClass="mytxt"
						runat="server" />
						<asp:Image ID="ImageButton1" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CalendarExtenderPunchDate"
            TargetControlID="TextBoxPunchDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButton1" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderPunchDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxPunchDate" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorPunchDate"
						runat = "server"
						ControlToValidate = "TextBoxPunchDate"
						ControlExtender = "MaskedEditExtenderPunchDate"
						InvalidValueMessage = "Invalid value for Date."
						EmptyValueMessage = "Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Date."
						EnableClientScript = "true"
						ValidationGroup = "atnRawPunch"
						IsValidEmpty = "false"
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
						ValidationGroup = "atnRawPunch"
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
						ValidationGroup = "atnRawPunch"
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
					<b><asp:Label ID="LabelPunch1Time" runat="server" Text="Punch Time [1] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxPunch1Time"
						Text='<%# Bind("Punch1Time") %>'
						runat="server"
						ValidationGroup="atnRawPunch"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderPunch1Time"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxPunch1Time" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorPunch1Time"
						runat = "server"
						ControlToValidate = "TextBoxPunch1Time"
						ControlExtender = "MaskedEditExtenderPunch1Time"
						InvalidValueMessage = "Invalid value for Punch Time [1]."
						EmptyValueMessage = "Punch Time [1] is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Punch Time [1]."
						EnableClientScript = "true"
						ValidationGroup = "atnRawPunch"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelPunch2Time" runat="server" Text="Punch Time [2] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxPunch2Time"
						Text='<%# Bind("Punch2Time") %>'
						runat="server"
						ValidationGroup="atnRawPunch"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderPunch2Time"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxPunch2Time" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorPunch2Time"
						runat = "server"
						ControlToValidate = "TextBoxPunch2Time"
						ControlExtender = "MaskedEditExtenderPunch2Time"
						InvalidValueMessage = "Invalid value for Punch Time [2]."
						EmptyValueMessage = "Punch Time [2] is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Punch Time [2]."
						EnableClientScript = "true"
						ValidationGroup = "atnRawPunch"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelProcessed" runat="server" Text="Processed :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxProcessed"
						  Checked='<%# Bind("Processed") %>'
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
  DataObjectTypeName = "SIS.ATN.atnRawPunch"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnRawPunch"
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
