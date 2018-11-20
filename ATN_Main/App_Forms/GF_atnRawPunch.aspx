<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnRawPunch.aspx.vb" Inherits="GF_atnRawPunch" title="Maintain List: Raw Punch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
    <asp:Label ID="LabelatnRawPunch" runat="server" Text="List Raw Punch" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "atnRawPunch"
      SearchContext = "atnRawPunch"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <table>
      <tr>
        <td class="alignright" ><b>Card No :</b></td>
        <td style="Padding-left: 5px;">
					<script type="text/javascript">
						function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
							var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
							LC_CardNo1.value = e.get_value();
							__doPostBack('<%= LC_CardNo1.ClientID %>', e.get_value());
						}
					</script>
					<asp:TextBox
						ID = "LC_CardNo1"
						CssClass = "mytxt"
						Width = "40px"
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_CardNoEmployeeName1"
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
						Runat="Server" />
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
    </table>
		<script type="text/javascript">
		  function LC_CardNo2_AutoCompleteExtender_Selected(sender, e) {
				var LC_CardNo2 = $get('<%= LC_CardNo2.ClientID %>');
				LC_CardNo2.value = e.get_value();
		 }
		</script>
		<asp:TextBox
			ID = "LC_CardNo2"
			CssClass = "mytxt"
			Width = "40px"
			AutoCompleteType = "None"
			Style="display:none"
			Runat="Server" />
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="RecordID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandArgument='<%# Bind("RecordID") %>' OnClick="Edit_Click" />
						&nbsp;
            <asp:ImageButton ID="FastEdit" runat="server" AlternateText="InLineEdit" ToolTip="Inlie Edit the record." SkinID="FastEdit" CommandArgument='<%# Bind("RecordID") %>' CommandName="Edit" />
          </ItemTemplate>
          <HeaderStyle Width="70px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
					<EditItemTemplate>
						<asp:ImageButton ID="Save" runat="server" AlternateText="Save" ToolTip="Save changes." SkinID="save" CommandArgument='<%# Bind("RecordID") %>' commandName="Update" ValidationGroup = "atnRawPunch" />
						&nbsp;
						<asp:ImageButton ID="Cancel" runat="server" AlternateText="Cancel" ToolTip="Cancel changes." SkinID="cancel" CommandArgument='<%# Bind("RecordID") %>' commandname="Cancel" />
					</EditItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="ID" SortExpression="RecordID">
          <ItemTemplate>
            <asp:Label ID="LabelRecordID" runat="server" Text='<%# Bind("RecordID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="50px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="PunchDate">
          <ItemTemplate>
            <asp:Label ID="LabelPunchDate" runat="server" Text='<%# Bind("PunchDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        <EditItemTemplate>
            <asp:TextBox ID="TextBoxPunchDate"
						  Text='<%# Bind("PunchDate") %>'
						  ValidationGroup="atnRawPunch"
              Width="70px"
              CssClass="mytxt"
						  runat="server" />
            <asp:Image ID="DateButtonPunchDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
            <AJX:CalendarExtender 
              ID = "CalendarExtenderPunchDate"
              TargetControlID="TextBoxPunchDate"
              Format="dd/MM/yyyy"
              runat = "server" CssClass="MyCalendar" PopupButtonID="DateButtonPunchDate" />
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
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelCardNo" ToolTip='<%#Eval("CardNo") %>' runat="server" Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        <EditItemTemplate>
					<asp:TextBox
						ID = "LC_CardNo2"
						CssClass = "mytxt"
						Width = "40px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_CardNoEmployeeName2"
						Text='<%# Bind("CardNoEmployeeName") %>'
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
            ToolTip="Enter value for Card No."
						ValidationGroup = "atnRawPunch"
						Runat="Server" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderCardNo1"
						runat = "server"
            WatermarkText="[Enter Card No]"
						TargetControlID="LC_CardNoEmployeeName2" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorCardNo1"
						runat = "server"
						ControlToValidate = "LC_CardNoEmployeeName2"
						Text = "Card No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnRawPunch"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="LC_CardNo2_AutoCompleteExtender"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="LC_CardNoEmployeeName2"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_CardNo2_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch Time [1]" SortExpression="Punch1Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch1Time" runat="server" Text='<%# Bind("Punch1Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="70px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        <EditItemTemplate>
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
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch Time [2]" SortExpression="Punch2Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch2Time" runat="server" Text='<%# Bind("Punch2Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="70px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        <EditItemTemplate>
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
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Processed" SortExpression="Processed">
          <ItemTemplate>
            <asp:Label ID="LabelProcessed" runat="server" Text='<%# Bind("Processed") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="70px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBoxProcessed"
						  Checked='<%# Bind("Processed") %>'
              runat="server" />
        </EditItemTemplate>
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
      <RowStyle BackColor="PaleGoldenrod" />
      <PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
      <HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" />
      <AlternatingRowStyle BackColor="Bisque" />
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnRawPunch"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      UpdateMethod = "Update"
      TypeName = "SIS.ATN.atnRawPunch"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="LC_CardNo1" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="LC_CardNo1" />
  </Triggers>
</asp:UpdatePanel>
   </div>
</div>
</asp:Content>
