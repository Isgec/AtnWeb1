<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnFinYear.aspx.vb" Inherits="AF_atnFinYear" title="Add: Financial Year" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnFinYear" runat="server" Text="Add Financial Year" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "atnFinYear"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "FinYear"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelFinYear" runat="server" Text="FinYear :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxFinYear"
						Text='<%# Bind("FinYear") %>'
            CssClass="mytxt"
						runat="server"
            onblur= "validate_FinYear(this);"
						ValidationGroup="atnFinYear"
            ToolTip="Enter value for FinYear."
            Width="60px"
						MaxLength="4" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderFinYear"
						runat = "server"
            WatermarkText="[Enter FinYear]"
						TargetControlID="TextBoxFinYear" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorFinYear"
						runat = "server"
						ControlToValidate = "TextBoxFinYear"
						Text = "FinYear is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnFinYear"
						SetFocusOnError="true" />
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
						ValidationGroup="atnFinYear"
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
						ValidationGroup = "atnFinYear"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelStartDate" runat="server" Text="Start Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxStartDate"
						Text='<%# Bind("StartDate") %>'
						ValidationGroup="atnFinYear"
            Width="70px"
            CssClass="mytxt"
						runat="server" />
						<asp:Image ID="ImageButton1" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CalendarExtenderStartDate"
            TargetControlID="TextBoxStartDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButton1" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderStartDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxStartDate" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorStartDate"
						runat = "server"
						ControlToValidate = "TextBoxStartDate"
						ControlExtender = "MaskedEditExtenderStartDate"
						InvalidValueMessage = "Invalid value for Start Date."
						EmptyValueMessage = "Start Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Start Date."
						EnableClientScript = "true"
						ValidationGroup = "atnFinYear"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelEndDate" runat="server" Text="End Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxEndDate"
						Text='<%# Bind("EndDate") %>'
						ValidationGroup="atnFinYear"
            Width="70px"
            CssClass="mytxt"
						runat="server" />
						<asp:Image ID="ImageButton2" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CalendarExtenderEndDate"
            TargetControlID="TextBoxEndDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButton2" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderEndDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxEndDate" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorEndDate"
						runat = "server"
						ControlToValidate = "TextBoxEndDate"
						ControlExtender = "MaskedEditExtenderEndDate"
						InvalidValueMessage = "Invalid value for End Date."
						EmptyValueMessage = "End Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for End Date."
						EnableClientScript = "true"
						ValidationGroup = "atnFinYear"
						IsValidEmpty = "false"
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
		</table>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnFinYear"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnFinYear"
  SelectMethod = "GetByID"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" Name="FinYear" QueryStringField="Code" Type="String" />
</SelectParameters>
<InsertParameters>
  <asp:Parameter Name="FinYear" Type="String" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
