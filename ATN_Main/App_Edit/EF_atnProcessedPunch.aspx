<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnProcessedPunch.aspx.vb" Inherits="EF_atnProcessedPunch" title="Edit: Processed Punch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      EnableDelete = "False"
      ValidationGroup = "atnProcessedPunch"
      SearchContext = "atnProcessedPunch"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnProcessedPunch.aspx"
      runat = "server" />
    <asp:Label ID="LabelatnProcessedPunch" runat="server" Text="Edit Processed Punch" ></asp:Label>
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "AttenID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelAttenID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextAttenID" runat="server" Text='<%# Bind("AttenID") %>' />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelAttenDate" runat="server" Text="Date :" /></b>
				</td>
        <td>
          <asp:Label ID="TextAttenDate" runat="server" Text='<%# Bind("AttenDate") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelCardNo" runat="server" Text="Card No :" /></b>
				</td>
        <td>
          <asp:Label ID="TextCardNo" runat="server" Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
          <asp:Label ID="TextCardNoHidden" style="display:none" runat="server" Text='<%# Bind("CardNo") %>'></asp:Label>
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
						ValidationGroup="atnProcessedPunch"
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
						ValidationGroup = "atnProcessedPunch"
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
						ValidationGroup="atnProcessedPunch"
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
						ValidationGroup = "atnProcessedPunch"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Reason :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="atnProcessedPunch"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter reason for change."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRemarks"
						runat = "server"
						ControlToValidate = "F_Remarks"
						Text = "Reason is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnProcessedPunch"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelPunchStatusID" runat="server" Text="Punch Status :" /></b>
				</td>
        <td>
          <asp:Label ID="TextPunchStatusID" runat="server" Text='<%# Eval("PunchStatusIDATN_PunchStatus.Description") %>'></asp:Label>
          <asp:Label ID="TextPunchStatusIDHidden" style="display:none" runat="server" Text='<%# Bind("PunchStatusID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelPunchValue" runat="server" Text="Punch Value :" /></b>
				</td>
        <td>
          <asp:Label ID="TextPunchValue" runat="server" Text='<%# Bind("PunchValue") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelFinalValue" runat="server" Text="Final Value :" /></b>
				</td>
        <td>
          <asp:Label ID="TextFinalValue" runat="server" Text='<%# Bind("FinalValue") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelNeedsRegularization" runat="server" Text="Needs Regularization :" /></b>
				</td>
        <td>
          <asp:Label ID="TextNeedsRegularization" runat="server" Text='<%# Bind("NeedsRegularization") %>'></asp:Label>
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnProcessedPunch"
  SelectMethod = "GetByID"
  UpdateMethod="UZ_Update"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnProcessedPunch"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="AttenID" Type="Int32" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="AttenID" Type="Int32" />
</UpdateParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
