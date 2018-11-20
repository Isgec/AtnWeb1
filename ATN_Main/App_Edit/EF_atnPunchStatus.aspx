<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnPunchStatus.aspx.vb" Inherits="EF_atnPunchStatus" title="Edit: Punch Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnPunchStatus" runat="server" Text="Edit Punch Status" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnPunchStatus"
      SearchContext = "atnPunchStatus"
      SearchUrl = "~/ATN_Main/App_Edit/EF_atnPunchStatus.aspx"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "PunchStatusID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelPunchStatusID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextPunchStatusID" runat="server" Text='<%# Bind("PunchStatusID") %>' />
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
						ValidationGroup="atnPunchStatus"
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
						ValidationGroup = "atnPunchStatus"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelPunchValue" runat="server" Text="Punch Value :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxPunchValue"
						Text='<%# Bind("PunchValue") %>'
						runat="server"
						ValidationGroup="atnPunchStatus"
						MaxLength="8"
            Width="70px"
            CssClass="mytxt"
						style="text-align: right" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderPunchValue"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxPunchValue" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorPunchValue"
						runat = "server"
						ControlToValidate = "TextBoxPunchValue"
						ControlExtender = "MaskedEditExtenderPunchValue"
						InvalidValueMessage = "Invalid value for Punch Value."
						EmptyValueMessage = "Punch Value is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Punch Value."
						EnableClientScript = "true"
						ValidationGroup = "atnPunchStatus"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Punch Value should be greater than zero."
						MinimumValueMessage = "*"
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
  DataObjectTypeName = "SIS.ATN.atnPunchStatus"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnPunchStatus"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="PunchStatusID" Type="String" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="PunchStatusID" Type="String" />
</UpdateParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
