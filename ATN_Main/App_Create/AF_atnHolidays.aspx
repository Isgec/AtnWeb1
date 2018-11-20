<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnHolidays.aspx.vb" Inherits="AF_atnHolidays" title="Add: Holidays" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnHolidays" runat="server" Text="Add Holidays" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "atnHolidays"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "RecordID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelRecordID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextRecordID" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelHoliday" runat="server" Text="Holiday :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxHoliday"
						Text='<%# Bind("Holiday") %>'
						ValidationGroup="atnHolidays"
            Width="70px"
            CssClass="mytxt"
						runat="server" />
						<asp:Image ID="ImageButton1" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CalendarExtenderHoliday"
            TargetControlID="TextBoxHoliday"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButton1" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderHoliday"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxHoliday" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorHoliday"
						runat = "server"
						ControlToValidate = "TextBoxHoliday"
						ControlExtender = "MaskedEditExtenderHoliday"
						InvalidValueMessage = "Invalid value for Holiday."
						EmptyValueMessage = "Holiday is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Holiday."
						EnableClientScript = "true"
						ValidationGroup = "atnHolidays"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright" style="Padding-top: 15px;">
					<b><asp:Label ID="LabelOfficeID" runat="server" Text="Office :" /></b>
				</td>
        <td style="Padding-top: 15px;">
          <LGM:LC_hrmOffices
            ID="LC_OfficeID1"
            SelectedValue='<%# Bind("OfficeID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="OfficeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            CssClass="myddl"
						ValidationGroup = "atnHolidays"
            RequiredFieldErrorMessage = "Office is required."
            Runat="Server" />
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
						ValidationGroup="atnHolidays"
            ToolTip="Enter value for Description."
            Width="100px"
						MaxLength="30" />
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
						ValidationGroup = "atnHolidays"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright" style="Padding-top: 15px;">
					<b><asp:Label ID="LabelPunchStatusID" runat="server" Text="Punch Status :" /></b>
				</td>
        <td style="Padding-top: 15px;">
          <LGM:LC_atnPunchStatus
            ID="LC_PunchStatusID1"
            SelectedValue='<%# Bind("PunchStatusID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="PunchStatusID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            CssClass="myddl"
						ValidationGroup = "atnHolidays"
            RequiredFieldErrorMessage = "Punch Status is required."
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
  DataObjectTypeName = "SIS.ATN.atnHolidays"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnHolidays"
  SelectMethod = "GetByID"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" Name="RecordID" QueryStringField="Code" Type="Int32" />
</SelectParameters>
<InsertParameters>
  <asp:Parameter Name="RecordID" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
