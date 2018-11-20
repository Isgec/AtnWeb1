<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnPunchConfig.aspx.vb" Inherits="EF_atnPunchConfig" title="Edit: Punch Configuration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnPunchConfig" runat="server" Text="Edit Punch Configuration" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnPunchConfig"
      SearchContext = "atnPunchConfig"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnPunchConfig.aspx"
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
					<b><asp:Label ID="LabelDescription" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxDescription"
						Text='<%# Bind("Description") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfig"
            ToolTip="Enter value for Description."
            Width="200px"
						MaxLength="50" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderDescription"
						runat = "server"
            WatermarkText="[Enter Description]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxDescription" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorDescription"
						runat = "server"
						ControlToValidate = "TextBoxDescription"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelSTD1Time" runat="server" Text="First Punch Standard Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxSTD1Time"
						Text='<%# Bind("STD1Time") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderSTD1Time"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxSTD1Time" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorSTD1Time"
						runat = "server"
						ControlToValidate = "TextBoxSTD1Time"
						ControlExtender = "MaskedEditExtenderSTD1Time"
						InvalidValueMessage = "Invalid value for First Punch Standard Time."
						EmptyValueMessage = "First Punch Standard Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for First Punch Standard Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "First Punch Standard Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRange1Start" runat="server" Text="First Punch Start Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxRange1Start"
						Text='<%# Bind("Range1Start") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderRange1Start"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxRange1Start" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorRange1Start"
						runat = "server"
						ControlToValidate = "TextBoxRange1Start"
						ControlExtender = "MaskedEditExtenderRange1Start"
						InvalidValueMessage = "Invalid value for First Punch Start Time."
						EmptyValueMessage = "First Punch Start Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for First Punch Start Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "First Punch Start Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRange1End" runat="server" Text="First Punch End Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxRange1End"
						Text='<%# Bind("Range1End") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderRange1End"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxRange1End" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorRange1End"
						runat = "server"
						ControlToValidate = "TextBoxRange1End"
						ControlExtender = "MaskedEditExtenderRange1End"
						InvalidValueMessage = "Invalid value for First Punch End Time."
						EmptyValueMessage = "First Punch End Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for First Punch End Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "First Punch End Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelMeanTime" runat="server" Text="MeanTime to Resolve Between Ist and 2nd Punch :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxMeanTime"
						Text='<%# Bind("MeanTime") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderMeanTime"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxMeanTime" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorMeanTime"
						runat = "server"
						ControlToValidate = "TextBoxMeanTime"
						ControlExtender = "MaskedEditExtenderMeanTime"
						InvalidValueMessage = "Invalid value for MeanTime to Resolve Between Ist and 2nd Punch."
						EmptyValueMessage = "MeanTime to Resolve Between Ist and 2nd Punch is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for MeanTime to Resolve Between Ist and 2nd Punch."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "MeanTime to Resolve Between Ist and 2nd Punch should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelSTD2Time" runat="server" Text="Second Punch Standard Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxSTD2Time"
						Text='<%# Bind("STD2Time") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderSTD2Time"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxSTD2Time" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorSTD2Time"
						runat = "server"
						ControlToValidate = "TextBoxSTD2Time"
						ControlExtender = "MaskedEditExtenderSTD2Time"
						InvalidValueMessage = "Invalid value for Second Punch Standard Time."
						EmptyValueMessage = "Second Punch Standard Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Second Punch Standard Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Second Punch Standard Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRange2Start" runat="server" Text="Second Punch Start Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxRange2Start"
						Text='<%# Bind("Range2Start") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderRange2Start"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxRange2Start" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorRange2Start"
						runat = "server"
						ControlToValidate = "TextBoxRange2Start"
						ControlExtender = "MaskedEditExtenderRange2Start"
						InvalidValueMessage = "Invalid value for Second Punch Start Time."
						EmptyValueMessage = "Second Punch Start Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Second Punch Start Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Second Punch Start Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRange2End" runat="server" Text="Second Punch End Time :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxRange2End"
						Text='<%# Bind("Range2End") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderRange2End"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxRange2End" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorRange2End"
						runat = "server"
						ControlToValidate = "TextBoxRange2End"
						ControlExtender = "MaskedEditExtenderRange2End"
						InvalidValueMessage = "Invalid value for Second Punch End Time."
						EmptyValueMessage = "Second Punch End Time is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Second Punch End Time."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Second Punch End Time should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelEnableMinHrs" runat="server" Text="Enable Min. Working Hours :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxEnableMinHrs"
						  Checked='<%# Bind("EnableMinHrs") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelMinHrsFullPresent" runat="server" Text="Min. Hours to Mark Full Day Present :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxMinHrsFullPresent"
						Text='<%# Bind("MinHrsFullPresent") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderMinHrsFullPresent"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxMinHrsFullPresent" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorMinHrsFullPresent"
						runat = "server"
						ControlToValidate = "TextBoxMinHrsFullPresent"
						ControlExtender = "MaskedEditExtenderMinHrsFullPresent"
						InvalidValueMessage = "Invalid value for Min. Hours to Mark Full Day Present."
						EmptyValueMessage = "Min. Hours to Mark Full Day Present is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Min. Hours to Mark Full Day Present."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Min. Hours to Mark Full Day Present should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelMinHrsHalfPresent" runat="server" Text="Min. Hours to Mark Half Day Present :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxMinHrsHalfPresent"
						Text='<%# Bind("MinHrsHalfPresent") %>'
						runat="server"
						ValidationGroup="atnPunchConfig"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderMinHrsHalfPresent"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxMinHrsHalfPresent" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorMinHrsHalfPresent"
						runat = "server"
						ControlToValidate = "TextBoxMinHrsHalfPresent"
						ControlExtender = "MaskedEditExtenderMinHrsHalfPresent"
						InvalidValueMessage = "Invalid value for Min. Hours to Mark Half Day Present."
						EmptyValueMessage = "Min. Hours to Mark Half Day Present is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Min. Hours to Mark Half Day Present."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Min. Hours to Mark Half Day Present should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelActive" runat="server" Text="Active :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxActive"
						  Checked='<%# Bind("Active") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelDataFileLocation" runat="server" Text="Data File Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxDataFileLocation"
						Text='<%# Bind("DataFileLocation") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnPunchConfig"
            ToolTip="Enter value for Data File Location."
            Width="300px" Height="40px" TextMode="MultiLine"
						MaxLength="250" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderDataFileLocation"
						runat = "server"
            WatermarkText="[Enter Data File Location]"
            WatermarkCssClass="watermark"
						TargetControlID="TextBoxDataFileLocation" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorDataFileLocation"
						runat = "server"
						ControlToValidate = "TextBoxDataFileLocation"
						Text = "Data File Location is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnPunchConfig"
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
  DataObjectTypeName = "SIS.ATN.atnPunchConfig"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnPunchConfig"
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
