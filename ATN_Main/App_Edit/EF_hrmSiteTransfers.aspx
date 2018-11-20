<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_hrmSiteTransfers.aspx.vb" Inherits="EF_hrmSiteTransfers" title="Edit: Transfers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelhrmTransfers" runat="server" Text="Edit Transfers" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      EnableDelete = "False"
      ValidationGroup = "hrmTransfers"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CardNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
	<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelCardNo" runat="server" Text="Card No :" /></b>
				</td>
				<td>
					<asp:Label ID="TextCardNo" runat="server" Text='<%# Bind("CardNo") %>' />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelEmployeeName" runat="server" Text="Employee Name :" /></b>
				</td>
        <td>
          <asp:Label ID="TextEmployeeName" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DateOfJoining" runat="server" Text="Date Of Joining :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DateOfJoining" runat="server" Text='<%# Bind("C_DateOfJoining") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DesignationID" runat="server" Text="Designation :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DesignationID" runat="server" Text='<%# Eval("C_DesignationIDHRM_Designations.Description") %>'></asp:Label>
          <asp:Label ID="TextC_DesignationIDHidden" style="display:none" runat="server" Text='<%# Bind("C_DesignationID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_CompanyID" runat="server" Text="Current Company :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_CompanyID" runat="server" Text='<%# Eval("C_CompanyIDHRM_Companies.Description") %>'></asp:Label>
          <asp:Label ID="TextC_CompanyIDHidden" style="display:none" runat="server" Text='<%# Bind("C_CompanyID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DivisionID" runat="server" Text="Current Division :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DivisionID" runat="server" Text='<%# Eval("C_DivisionIDHRM_Divisions.Description") %>'></asp:Label>
          <asp:Label ID="TextC_DivisionIDHidden" style="display:none" runat="server" Text='<%# Bind("C_DivisionID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_OfficeID" runat="server" Text="Current Office :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_OfficeID" runat="server" Text='<%# Eval("C_OfficeIDHRM_Offices.Description") %>'></asp:Label>
          <asp:Label ID="TextC_OfficeIDHidden" style="display:none" runat="server" Text='<%# Bind("C_OfficeID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_DepartmentID" runat="server" Text="Current Department :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_DepartmentID" runat="server" Text='<%# Eval("C_DepartmentIDHRM_Departments.Description") %>'></asp:Label>
          <asp:Label ID="TextC_DepartmentIDHidden" style="display:none" runat="server" Text='<%# Bind("C_DepartmentID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_ProjectSiteID" runat="server" Text="Current Project Site :" /></b>
				</td>
        <td>
          <asp:Label ID="TextC_ProjectSiteID" runat="server" Text='<%# Eval("C_ProjectSiteIDDCM_Projects.Description") %>'></asp:Label>
          <asp:Label ID="TextC_ProjectSiteIDHidden" style="display:none" runat="server" Text='<%# Bind("C_ProjectSiteID") %>'></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelU_UnderTransfer" runat="server" Text="Under Transfer :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="CheckBoxU_UnderTransfer"
						  Checked='<%# Bind("U_UnderTransfer") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright" style="Padding-top: 15px;">
					<b><asp:Label ID="LabelU_ProjectSiteID" runat="server" Text="New Project Site :" /></b>
				</td>
        <td style="Padding-top: 15px;">
					<asp:TextBox
						ID = "F_U_ProjectSiteID"
						CssClass = "mytxt"
						Width = "42px"
						Text='<%# Bind("U_ProjectSiteID") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_U_ProjectSiteID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_U_ProjectSiteID_Display"
						Text='<%# Eval("U_ProjectSiteIDDCM_Projects.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEU_ProjectSiteID"
            ContextKey=""
            UseContextKey="true"
            BehaviorID="B_ACEU_ProjectSiteID"
            ServiceMethod="U_ProjectSiteIDCompletionList"
            TargetControlID="F_U_ProjectSiteID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEU_ProjectSiteID_Selected"
            OnClientPopulating="ACEU_ProjectSiteID_Populating"
            OnClientPopulated="ACEU_ProjectSiteID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_TransferedOn" runat="server" Text="Transfered On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxC_TransferedOn"
						Text='<%# Bind("C_TransferedOn") %>'
						ValidationGroup="hrmTransfers"
            Width="70px"
            CssClass="mytxt"
						runat="server" />
						<asp:Image ID="ImageButton1" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CalendarExtenderC_TransferedOn"
            TargetControlID="TextBoxC_TransferedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButton1" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderC_TransferedOn"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxC_TransferedOn" />
					<AJX:MaskedEditValidator 
						ID = "MaskedEditValidatorC_TransferedOn"
						runat = "server"
						ControlToValidate = "TextBoxC_TransferedOn"
						ControlExtender = "MaskedEditExtenderC_TransferedOn"
						InvalidValueMessage = "Invalid value for Transfered On."
						EmptyValueMessage = "Transfered On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Transfered On."
						EnableClientScript = "true"
						ValidationGroup = "hrmTransfers"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelC_TransferRemark" runat="server" Text="Transfer Remark :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxC_TransferRemark"
						Text='<%# Bind("C_TransferRemark") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="hrmTransfers"
            ToolTip="Enter value for Transfer Remark."
            Width="300px" Height="40px" TextMode="MultiLine"
						MaxLength="250" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderC_TransferRemark"
						runat = "server"
            WatermarkText="[Enter Transfer Remark]"
						TargetControlID="TextBoxC_TransferRemark" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
	  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.HRM.hrmTransfers"
  SelectMethod = "GetByID"
  UpdateMethod="UZ_UpdateSite"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.HRM.hrmTransfers"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Code" Name="CardNo" Type="String" />
</SelectParameters>
<UpdateParameters>
  <asp:Parameter Name="CardNo" Type="String" />
</UpdateParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
