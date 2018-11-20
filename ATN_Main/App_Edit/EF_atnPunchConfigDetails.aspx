<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnPunchConfigDetails.aspx.vb" Inherits="EF_atnPunchConfigDetails" title="Edit: Punch Config Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnPunchConfigDetails" runat="server" Text="Edit Punch Config Details" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnPunchConfigDetails"
      SearchContext = "atnPunchConfigDetails"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnPunchConfigDetails.aspx"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelSerialNo" runat="server" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:Label ID="TextSerialNo" runat="server" Text='<%# Bind("SerialNo") %>' />
				</td>
			</tr>
			<tr>
				<td class="alignright" style="Padding-top: 15px;">
					<b><asp:Label ID="LabelConfigID" runat="server" Text="Config :" /></b>
				</td>
        <td style="Padding-top: 15px;">
          <LGM:LC_atnPunchConfig
            ID="LC_ConfigID1"
            SelectedValue='<%# Bind("ConfigID") %>'
            OrderBy=""
            DataTextField=""
            DataValueField="RecordID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            CssClass="myddl"
						ValidationGroup = "atnPunchConfigDetails"
            RequiredFieldErrorMessage = "Config is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelFPStartTime" runat="server" Text="First Punch Start Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxFPStartTime"
						Text='<%# Bind("FPStartTime") %>'
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderFPStartTime"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxFPStartTime" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorFPStartTime"
						runat = "server"
						ControlToValidate = "TextBoxFPStartTime"
						ControlExtender = "MaskedEditExtenderFPStartTime"
						InvalidValueMessage = "Invalid value for First Punch Start Time."
						EmptyValueMessage = "First Punch Start Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for First Punch Start Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "First Punch Start Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelFPEndTime" runat="server" Text="First Punch End Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxFPEndTime"
						Text='<%# Bind("FPEndTime") %>'
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderFPEndTime"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxFPEndTime" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorFPEndTime"
						runat = "server"
						ControlToValidate = "TextBoxFPEndTime"
						ControlExtender = "MaskedEditExtenderFPEndTime"
						InvalidValueMessage = "Invalid value for First Punch End Time."
						EmptyValueMessage = "First Punch End Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for First Punch End Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "First Punch End Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelUseDefined" runat="server" Text="Use Defined Time For Calculation :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxUseDefined"
						  Checked='<%# Bind("UseDefined") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelDefinedTime" runat="server" Text="Defined Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxDefinedTime"
						Text='<%# Bind("DefinedTime") %>'
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderDefinedTime"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxDefinedTime" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorDefinedTime"
						runat = "server"
						ControlToValidate = "TextBoxDefinedTime"
						ControlExtender = "MaskedEditExtenderDefinedTime"
						InvalidValueMessage = "Invalid value for Defined Time."
						EmptyValueMessage = "Defined Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Defined Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelSPStartTime" runat="server" Text="Second Punch Start Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxSPStartTime"
						Text='<%# Bind("SPStartTime") %>'
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderSPStartTime"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxSPStartTime" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorSPStartTime"
						runat = "server"
						ControlToValidate = "TextBoxSPStartTime"
						ControlExtender = "MaskedEditExtenderSPStartTime"
						InvalidValueMessage = "Invalid value for Second Punch Start Time."
						EmptyValueMessage = "Second Punch Start Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Second Punch Start Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Second Punch Start Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelSPEndTime" runat="server" Text="Second Punch End Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxSPEndTime"
						Text='<%# Bind("SPEndTime") %>'
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderSPEndTime"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxSPEndTime" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorSPEndTime"
						runat = "server"
						ControlToValidate = "TextBoxSPEndTime"
						ControlExtender = "MaskedEditExtenderSPEndTime"
						InvalidValueMessage = "Invalid value for Second Punch End Time."
						EmptyValueMessage = "Second Punch End Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Second Punch End Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Second Punch End Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelCalculateHours" runat="server" Text="Calculate Hours :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxCalculateHours"
						  Checked='<%# Bind("CalculateHours") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelHoursStatus" runat="server" Text="Hours Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxHoursStatus"
						Text='<%# Bind("HoursStatus") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
            ToolTip="Enter value for Hours Status."
            Width="60px"
						MaxLength="2" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderHoursStatus"
						runat = "server"
            WatermarkText="[Enter Hours Status]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxHoursStatus" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelHoursValue" runat="server" Text="Hours Value :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxHoursValue"
						Text='<%# Bind("HoursValue") %>'
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderHoursValue"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxHoursValue" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorHoursValue"
						runat = "server"
						ControlToValidate = "TextBoxHoursValue"
						ControlExtender = "MaskedEditExtenderHoursValue"
						InvalidValueMessage = "Invalid value for Hours Value."
						EmptyValueMessage = "Hours Value is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Hours Value."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelLimitedAllowed" runat="server" Text="Limited Allowed :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxLimitedAllowed"
						  Checked='<%# Bind("LimitedAllowed") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelLimitCount" runat="server" Text="Limit Count :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxLimitCount"
						Text='<%# Bind("LimitCount") %>'
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
						MaxLength="10"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderLimitCount"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxLimitCount" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorLimitCount"
						runat = "server"
						ControlToValidate = "TextBoxLimitCount"
						ControlExtender = "MaskedEditExtenderLimitCount"
						InvalidValueMessage = "Invalid value for Limit Count."
						EmptyValueMessage = "Limit Count is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Limit Count."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelLimitPunchStatus" runat="server" Text="Limit Punch Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxLimitPunchStatus"
						Text='<%# Bind("LimitPunchStatus") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
            ToolTip="Enter value for Limit Punch Status."
            Width="60px"
						MaxLength="2" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderLimitPunchStatus"
						runat = "server"
            WatermarkText="[Enter Limit Punch Status]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxLimitPunchStatus" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelNormalPunchStatus" runat="server" Text="Normal Punch Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxNormalPunchStatus"
						Text='<%# Bind("NormalPunchStatus") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
            ToolTip="Enter value for Normal Punch Status."
            Width="60px"
						MaxLength="2" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderNormalPunchStatus"
						runat = "server"
            WatermarkText="[Enter Normal Punch Status]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxNormalPunchStatus" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelLimitedLeaveTypes" runat="server" Text="Limited Leave Types :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxLimitedLeaveTypes"
						Text='<%# Bind("LimitedLeaveTypes") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
            ToolTip="Enter value for Limited Leave Types."
            Width="300px"
						MaxLength="100" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderLimitedLeaveTypes"
						runat = "server"
            WatermarkText="[Enter Limited Leave Types]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxLimitedLeaveTypes" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelNormalLeaveTypes" runat="server" Text="Normal Leave Types :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxNormalLeaveTypes"
						Text='<%# Bind("NormalLeaveTypes") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
            ToolTip="Enter value for Normal Leave Types."
            Width="300px"
						MaxLength="100" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderNormalLeaveTypes"
						runat = "server"
            WatermarkText="[Enter Normal Leave Types]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxNormalLeaveTypes" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelExceptionRule" runat="server" Text="Exception Rule :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxExceptionRule"
						  Checked='<%# Bind("ExceptionRule") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelConfigStatus" runat="server" Text="ConfigStatus :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxConfigStatus"
						Text='<%# Bind("ConfigStatus") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfigDetails"
            ToolTip="Enter value for ConfigStatus."
            Width="60px"
						MaxLength="2" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderConfigStatus"
						runat = "server"
            WatermarkText="[Enter ConfigStatus]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxConfigStatus" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorConfigStatus"
						runat = "server"
						ControlToValidate = "TextBoxConfigStatus"
						Text = "ConfigStatus is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfigDetails"
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
  DataObjectTypeName = "SIS.ATN.atnPunchConfigDetails"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnPunchConfigDetails"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="SerialNo" Type="Int32" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="SerialNo" Type="Int32" />
</UpdateParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
