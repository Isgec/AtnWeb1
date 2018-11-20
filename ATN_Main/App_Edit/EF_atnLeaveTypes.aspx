<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnLeaveTypes.aspx.vb" Inherits="EF_atnLeaveTypes" title="Edit: Leave Types" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
<ContentTemplate>
    <asp:Label ID="LabelatnLeaveTypes" runat="server" Text="Edit Leave Types" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnLeaveTypes"
      SearchContext = "atnLeaveTypes"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnLeaveTypes.aspx"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "LeaveTypeID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelLeaveTypeID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextLeaveTypeID" runat="server" Text='<%# Bind("LeaveTypeID") %>' />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelDescription" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxDescription"
						Text='<%# Bind("Description") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnLeaveTypes"
            ToolTip="Enter value for Description."
            Width="100px"
						MaxLength="30" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderDescription"
						runat = "server"
            WatermarkText="[Enter Description]"
						TargetControlID="TextBoxDescription" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorDescription"
						runat = "server"
						ControlToValidate = "TextBoxDescription"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnLeaveTypes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelOBALApplicable" runat="server" Text="Opening Balance Applicable :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxOBALApplicable"
						  Checked='<%# Bind("OBALApplicable") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelOBALMonthly" runat="server" Text="Opening Balance Monthly :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxOBALMonthly"
						  Checked='<%# Bind("OBALMonthly") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelOpeningBalance" runat="server" Text="Opening Balance :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxOpeningBalance"
						Text='<%# Bind("OpeningBalance") %>'
						runat="server"
						ValidationGroup="atnLeaveTypes"
						MaxLength="10"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderOpeningBalance"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxOpeningBalance" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorOpeningBalance"
						runat = "server"
						ControlToValidate = "TextBoxOpeningBalance"
						ControlExtender = "MaskedEditExtenderOpeningBalance"
						InvalidValueMessage = "Invalid value for Opening Balance."
						EmptyValueMessage = "Opening Balance is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Opening Balance."
						EnableClientScript = "true"
						ValidationGroup = "atnLeaveTypes"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Opening Balance should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelCarryForward" runat="server" Text="Carry Forward :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxCarryForward"
						  Checked='<%# Bind("CarryForward") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright" style="Padding-top: 15px;">
					<b><asp:Label ID="LabelForwardToLeaveTypeID" runat="server" Text="Forward To Leave Type :" /></b>
				</td>
        <td style="Padding-top: 15px;">
          <LGM:LC_atnLeaveTypes
            ID="LC_ForwardToLeaveTypeID1"
            SelectedValue='<%# Bind("ForwardToLeaveTypeID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="LeaveTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            CssClass="myddl"
						ValidationGroup = "atnLeaveTypes"
            RequiredFieldErrorMessage = "Forward To Leave Type is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelAdvanceApplicable" runat="server" Text="Advance Applicable :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxAdvanceApplicable"
						  Checked='<%# Bind("AdvanceApplicable") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelSpecialSanctionRequired" runat="server" Text="Special Sanction Required :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxSpecialSanctionRequired"
						  Checked='<%# Bind("SpecialSanctionRequired") %>'
              runat="server" />
				</td>
			</tr>
      <tr>
        <td class="alignright" ><b>Special Sanction By :</b></td>
        <td style="Padding-left: 5px;">
					<asp:TextBox
						ID = "LC_SpecialSanctionBy1"
						CssClass = "mytxt"
						Width = "40px"
						Text='<%# Bind("SpecialSanctionBy") %>'
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_SpecialSanctionByEmployeeName1"
						Text='<%# Bind("SpecialSanctionByEmployeeName") %>'
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
            ToolTip="Enter value for Special Sanction By."
						ValidationGroup = "atnLeaveTypes"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderSpecialSanctionBy"
						runat = "server"
            WatermarkText="[Enter Special Sanction By]"
						TargetControlID="LC_SpecialSanctionByEmployeeName1" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorSpecialSanctionBy"
						runat = "server"
						ControlToValidate = "LC_SpecialSanctionByEmployeeName1"
						Text = "Special Sanction By is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnLeaveTypes"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="LC_SpecialSanctionBy1_AutoCompleteExtender"
            ServiceMethod="SpecialSanctionByCompletionList"
            TargetControlID="LC_SpecialSanctionByEmployeeName1"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_SpecialSanctionBy1_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelApplyiable" runat="server" Text="User can Apply :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxApplyiable"
						  Checked='<%# Bind("Applyiable") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelPostable" runat="server" Text="Postable :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxPostable"
						  Checked='<%# Bind("Postable") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright" style="Padding-top: 15px;">
					<b><asp:Label ID="LabelPostedLeaveTypeID" runat="server" Text="Posted Leave Type (if not postable) :" /></b>
				</td>
        <td style="Padding-top: 15px;">
          <LGM:LC_atnLeaveTypes
            ID="LC_PostedLeaveTypeID1"
            SelectedValue='<%# Bind("PostedLeaveTypeID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="LeaveTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            CssClass="myddl"
						ValidationGroup = "atnLeaveTypes"
            RequiredFieldErrorMessage = "Posted Leave Type (if not postable) is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelSequence" runat="server" Text="Sequence :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxSequence"
						Text='<%# Bind("Sequence") %>'
						runat="server"
						ValidationGroup="atnLeaveTypes"
						MaxLength="10"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderSequence"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxSequence" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorSequence"
						runat = "server"
						ControlToValidate = "TextBoxSequence"
						ControlExtender = "MaskedEditExtenderSequence"
						InvalidValueMessage = "Invalid value for Sequence."
						EmptyValueMessage = "Sequence is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Sequence."
						EnableClientScript = "true"
						ValidationGroup = "atnLeaveTypes"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Sequence should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelMainType" runat="server" Text="MainType :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxMainType"
						  Checked='<%# Bind("MainType") %>'
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
  DataObjectTypeName = "SIS.ATN.atnLeaveTypes"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnLeaveTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="LeaveTypeID" Type="String" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="LeaveTypeID" Type="String" />
</UpdateParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
