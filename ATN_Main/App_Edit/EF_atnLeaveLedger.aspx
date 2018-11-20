<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnLeaveLedger.aspx.vb" Inherits="EF_atnLeaveLedger" title="Edit: Leave Ledger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
<ContentTemplate>
    <asp:Label ID="LabelatnLeaveLedger" runat="server" Text="Edit Leave Ledger" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnLeaveLedger"
      SearchContext = "atnLeaveLedger"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnLeaveLedger.aspx"
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
				<td class="alignright" >
					<b><asp:Label ID="LabelTranType" runat="server" Text="Ledger Type :" /></b>
				</td>
        <td>
          <LGM:LC_atnTranType
            ID="LC_TranType1"
            SelectedValue='<%# Bind("TranType") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="TranType"
            IncludeDefault="true"
            DefaultText="-- Select --"
            CssClass="myddl"
						ValidationGroup = "atnLeaveLedger"
            RequiredFieldErrorMessage = "Ledger Type is required."
            Runat="Server" />
          </td>
			</tr>
      <tr>
        <td class="alignright" ><b>Employee :</b></td>
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
						Width = "200px"
						onfocus="return this.select();"
						AutoCompleteType = "None"
            ToolTip="Enter value for Employee."
						ValidationGroup = "atnLeaveLedger"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderCardNo"
						runat = "server"
            WatermarkText="[Enter Employee]"
						TargetControlID="LC_CardNoEmployeeName1" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorCardNo"
						runat = "server"
						ControlToValidate = "LC_CardNoEmployeeName1"
						Text = "Employee is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnLeaveLedger"
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
					<b><asp:Label ID="LabelLeaveTypeID" runat="server" Text="Leave Type :" /></b>
				</td>
        <td>
          <LGM:LC_atnLeaveTypes
            ID="LC_LeaveTypeID1"
            SelectedValue='<%# Bind("LeaveTypeID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="LeaveTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            CssClass="myddl"
						ValidationGroup = "atnLeaveLedger"
            RequiredFieldErrorMessage = "Leave Type is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelInProcessDays" runat="server" Text="In Process Days :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxInProcessDays"
						Text='<%# Bind("InProcessDays") %>'
						runat="server"
						ValidationGroup="atnLeaveLedger"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderInProcessDays"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxInProcessDays" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorInProcessDays"
						runat = "server"
						ControlToValidate = "TextBoxInProcessDays"
						ControlExtender = "MaskedEditExtenderInProcessDays"
						InvalidValueMessage = "Invalid value for Days."
						EmptyValueMessage = "Days is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Days."
						EnableClientScript = "true"
						ValidationGroup = "atnLeaveLedger"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelDays" runat="server" Text="Days :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxDays"
						Text='<%# Bind("Days") %>'
						runat="server"
						ValidationGroup="atnLeaveLedger"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderDays"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxDays" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorDays"
						runat = "server"
						ControlToValidate = "TextBoxDays"
						ControlExtender = "MaskedEditExtenderDays"
						InvalidValueMessage = "Invalid value for In Process Days."
						EmptyValueMessage = "In Process Days is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for In Process Days."
						EnableClientScript = "true"
						ValidationGroup = "atnLeaveLedger"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnLeaveLedger"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnLeaveLedger"
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
