<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnProcessedPunchStatus.aspx.vb" Inherits="GD_atnProcessedPunchStatus" title="Display List: Processed Punch Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaacBills" runat="server" Text="&nbsp;List: Processed Punch Status"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnProcessedPunchStatus"
      SearchContext = "atnProcessedPunchStatus"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelAttenDate" runat="server" Text="Date :" /></b>
				</td>
				<td style="Padding-left: 5px;">
					<asp:TextBox ID="TextBoxAttenDate"
						Text='<%# Bind("AttenDate") %>'
            Width="70px"
            CssClass="mytxt"
            AutoPostBack="true"
						runat="server" />
						<asp:Image ID="ImageButton1" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CalendarExtenderAttenDate"
            TargetControlID="TextBoxAttenDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButton1" />
					<AJX:MaskedEditExtender 
						ID = "MaskedEditExtenderAttenDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="TextBoxAttenDate" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="Show Only Absent :" /></b>
				</td>
				<td>
					<asp:CheckBox ID="F_AbsentOnly" runat="server" />
				</td>
			</tr>
       <tr>
        <td class="alignright" ><b>Location :</b></td>
        <td style="Padding-left: 5px;">
          <LGM:LC_hrmOffices
            ID="LC_C_OfficeID1"
            SelectedValue='<%# Bind("C_OfficeID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="OfficeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            AutoPostBack="true"
            CssClass="myddl"
            RequiredFieldErrorMessage = ""
            Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="Label2" runat="server" Text="Since Last [Days] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Days" runat="server" Width="60px" MaxLength="2" Text="10" ></asp:TextBox>
				</td>
      </tr>
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
						Width = "300px"
						AutoCompleteType = "None"
						onfocus = "return this.select();"
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
				<td></td>
				<td>
					<asp:Button ID="cmdAbsent" runat="server" Text="Submit" />
				</td>
      </tr>
      <tr>
				<td colspan="2">
					<asp:Button ID="cmdSHReport" runat="server" Text="SH NOT Compensated" OnClientClick="return print_shNotCompensated('a');" />
				</td>
				<td colspan="2">
					<asp:Button ID="Button1" runat="server" Text="SH NOT Compensated-Detail" OnClientClick="return print_shNotCompensated('d');" />
				</td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_', 'App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="AttenID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<table>
							<tr>
								<td>
									<asp:ImageButton ID="cmdProcessed" runat="server" AlternateText="Processed" ToolTip="Check & Update Late Coming if within limits [3]." ImageUrl="~/App_Themes/Default/Images/Processed.png" CommandArgument='<%# Bind("AttenID") %>' OnClick="cmdProcessed_Click" OnClientClick="return confirm('Pl. manually check that it is within Late Coming Limit.');" />
								</td>
								<td>
									<asp:ImageButton ID="cmdPosted" runat="server" AlternateText="Posted" ToolTip="Forced Rectify Interweaving Holidays after Posting." ImageUrl="~/App_Themes/Default/Images/Posted.png" CommandArgument='<%# Bind("AttenID") %>' onclick="CmdPosted_Click" />
								</td>
							</tr>
						</table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="AttenDate">
          <ItemTemplate>
            <asp:Label ID="LabelAttenDate" ForeColor= '<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("AttenDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee Name" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelCardNo" ForeColor='<%# Eval("ForeColor") %>' ToolTip='<%#Eval("CardNo") %>' runat="server" Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="250px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch-1" SortExpression="Punch1Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch1Time" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("Punch1Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch-2" SortExpression="Punch2Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch2Time" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("Punch2Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="ATN_PunchStatus2_Description">
          <ItemTemplate>
             <asp:Label ID="LabelPunchStatusID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("PunchStatusIDATN_PunchStatus.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ist Half" SortExpression="ATN_LeaveTypes3_Description">
          <ItemTemplate>
             <asp:Label ID="LabelApplied1LeaveTypeID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("Applied1LeaveTypeIDATN_LeaveTypes.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IInd Half" SortExpression="ATN_LeaveTypes4_Description">
          <ItemTemplate>
             <asp:Label ID="LabelApplied2LeaveTypeID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("Applied2LeaveTypeIDATN_LeaveTypes.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Application" SortExpression="ATN_ApplicationStatus5_Description">
          <ItemTemplate>
             <asp:Label ID="LabelApplStatusID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("ApplStatusIDATN_ApplicationStatus.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnProcessedPunchStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnProcessedPunchStatus"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="LC_CardNo1" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:ControlParameter ControlID="LC_C_OfficeID1" PropertyName="SelectedValue" Name="C_OfficeID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="TextBoxAttenDate" PropertyName="Text" Name="AttenDate" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="LC_CardNo1" />
    <asp:AsyncPostBackTrigger ControlID="LC_C_OfficeID1" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="TextBoxAttenDate" EventName="TextChanged" />
  </Triggers>
</asp:UpdatePanel>
    </div>
		<script type="text/javascript">
			var cnt = 0;
			function print_shNotCompensated(o) {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=shNotCompensated';
				url = url + '&typ=' + o;
				window.open(url, nam, 'left=20,top=20,width=750,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>
</div>
</asp:Content>
