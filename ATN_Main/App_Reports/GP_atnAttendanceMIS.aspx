<%@ Page Title="ISGEC:Print LeaveCard" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnAttendanceMIS.aspx.vb" Inherits="GP_atnAttendanceMIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
	<div id="div1" runat="server" class="page">
		<br />
		<table width="100%">
			<tr>
				<td colspan="2" style="text-align: center; font-size: x-large;">
					<b>ATTENDANCE ANALYSIS</b>
					<br />
				</td>
			</tr>
			<tr>
				<td style="font-size: medium; font-weight: bold; padding-top: 10px;text-align:right">
					<span >DEPARTMENT WISE:</span></td>
				<td width="50%" >
					<asp:CheckBox ID="F_Dept" runat="server" />
				</td>
			</tr>
			<tr>
				<td style="font-size: medium; font-weight: bold; padding-top: 10px;text-align:right">
					<span >LOCATION WISE:</span></td>
				<td>
					<asp:CheckBox ID="F_Loca" runat="server" />
				</td>
			</tr>
		</table>
		<script type="text/javascript">
			var lastcard = '';
			var lastdate = '';
			function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
				var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
				LC_CardNo1.value = e.get_value();
				if (LC_CardNo1.value != lastcard) {
					$get('<%= LC_CardNo2.ClientID %>').value = LC_CardNo1.value;
					lastcard = LC_CardNo1.value;
				}
			}
			function LC_CardNo2_AutoCompleteExtender_Selected(sender, e) {
				var LC_CardNo2 = $get('<%= LC_CardNo2.ClientID %>');
				LC_CardNo2.value = e.get_value();
			}
			function fdate_lostfocus(o) {
				if (o.value != lastdate) {
					$get('<%= T_Date.ClientID %>').value = o.value;
					lastdate = o.value;
				}
			}
		</script>
		<table>
			<tr>
				<td colspan="4" style="padding-top: 10px; padding-bottom: 5px">
					<br />
					&nbsp;<span style="font-size: medium; font-weight: bold; text-decoration: underline">SUMMARY REPORT</span>&nbsp;</td>
			</tr>
			<tr>
				<td class="alignright">
					<b>From Card No :</b>
				</td>
				<td>
					<asp:TextBox ID="LC_CardNo1" runat="Server" AutoCompleteType="None" CssClass="mytxt" Style="display: none" Width="40px" />
					<asp:TextBox ID="LC_CardNoEmployeeName1" onfocus="return this.select();" runat="Server" AutoCompleteType="None" CssClass="mytxt" Width="200px" />
					<AJX:AutoCompleteExtender ID="LC_CardNo1_AutoCompleteExtender" runat="Server" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="10" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected" ServiceMethod="CardNoCompletionList" TargetControlID="LC_CardNoEmployeeName1" />
				</td>
				<td class="alignright">
					<b>To Card No :</b>
				</td>
				<td>
					<asp:TextBox ID="LC_CardNo2" runat="Server" AutoCompleteType="None" CssClass="mytxt" Style="display: none" Width="40px" />
					<asp:TextBox ID="LC_CardNoEmployeeName2" onfocus="return this.select();" runat="Server" AutoCompleteType="None" CssClass="mytxt" Width="200px" />
					<AJX:AutoCompleteExtender ID="LC_CardNo2_AutoCompleteExtender" runat="Server" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="10" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_CardNo2_AutoCompleteExtender_Selected" ServiceMethod="CardNoCompletionList" TargetControlID="LC_CardNoEmployeeName2" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b>From Date :</b>
				</td>
				<td>
					<asp:TextBox ID="F_Date" ValidationGroup="atnFinYear" Width="70px" CssClass="mytxt" onblur="fdate_lostfocus(this);" runat="server" />
					<asp:Image ID="Img1" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer" ImageUrl="~/Images/cal.png" />
					<AJX:CalendarExtender ID="CalendarExtenderF_Date" TargetControlID="F_Date" Format="dd/MM/yyyy" runat="server" CssClass="MyCalendar" PopupButtonID="Img1" />
					<AJX:MaskedEditExtender ID="MaskedEditExtenderF_Date" runat="server" Mask="99/99/9999" MaskType="Date" CultureName="en-GB" MessageValidatorTip="true" InputDirection="LeftToRight" ErrorTooltipEnabled="true" TargetControlID="F_Date" />
					<AJX:MaskedEditValidator ID="MaskedEditValidatorF_Date" runat="server" ControlToValidate="F_Date" ControlExtender="MaskedEditExtenderF_Date" InvalidValueMessage="Invalid value for From Date." EmptyValueMessage="From Date is required." EmptyValueBlurredText="[Required!]" Display="Dynamic" TooltipMessage="Enter value for From Date." EnableClientScript="true" ValidationGroup="atnFinYear" IsValidEmpty="false" SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b>To Date :</b>
				</td>
				<td>
					<asp:TextBox ID="T_Date" ValidationGroup="atnFinYear" Width="70px" CssClass="mytxt" runat="server" />
					<asp:Image ID="Img2" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer" ImageUrl="~/Images/cal.png" />
					<AJX:CalendarExtender ID="CalendarExtenderT_Date" TargetControlID="T_Date" Format="dd/MM/yyyy" runat="server" CssClass="MyCalendar" PopupButtonID="Img2" />
					<AJX:MaskedEditExtender ID="MaskedEditExtenderT_Date" runat="server" Mask="99/99/9999" MaskType="Date" CultureName="en-GB" MessageValidatorTip="true" InputDirection="LeftToRight" ErrorTooltipEnabled="true" TargetControlID="T_Date" />
					<AJX:MaskedEditValidator ID="MaskedEditValidatorT_Date" runat="server" ControlToValidate="T_Date" ControlExtender="MaskedEditExtenderT_Date" InvalidValueMessage="Invalid value for To Date." EmptyValueMessage="To Date is required." EmptyValueBlurredText="[Required!]" Display="Dynamic" TooltipMessage="Enter value for To Date." EnableClientScript="true" ValidationGroup="atnFinYear" IsValidEmpty="false" SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align: center; padding-top: 10px; padding-bottom: 5px;">
					<asp:Button ID="cmdFPAS" runat="server" Text="Print First Punch Aging Summary" OnClientClick="return print_agingsummary();" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="padding-top: 10px; padding-bottom: 5px">
					<br />
					<br />
					&nbsp;<span style="font-size: medium; font-weight: bold; text-decoration: underline">FILTER FOR DETAIL REPORT</span>&nbsp;</td>
			</tr>
			<tr>
				<td class="alignright">
					<b>&lt;=09.15</b>
				</td>
				<td>
					<asp:CheckBox ID="F_chk1" runat="server" />
				</td>
				<td class="alignright">
					<b>09.16 To 09.30</b>
				</td>
				<td >
					<asp:CheckBox ID="F_chk2" runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b>09.31 To 10.30</b>
				</td>
				<td>
					<asp:CheckBox ID="F_chk3" runat="server" />
				</td>
				<td class="alignright">
					<b>&gt; 10.30</b>
				</td>
				<td>
					<asp:CheckBox ID="F_chk4" runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b>FP</b>
				</td>
				<td>
					<asp:CheckBox ID="F_chk5" runat="server" />
				</td>
				<td class="alignright">
					<b>TS</b>
				</td>
				<td>
					<asp:CheckBox ID="F_chk6" runat="server" />
				</td>
			</tr>
				<tr>
				<td colspan="4" style="text-align: center; padding-top: 10px; padding-bottom: 5px;">
					<asp:Button ID="cmdFPAD" runat="server" Text="Print First Punch Detailed" OnClientClick="return print_agingdetail();" CssClass="mytxt" />
				</td>
			</tr>
		</table>

		<script type="text/javascript">
			var cnt = 0;
			function print_agingsummary() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=agingsummary';
				url = url + '&femp=' + $get('<%= LC_CardNo1.ClientID %>').value;
				url = url + '&temp=' + $get('<%= LC_CardNo2.ClientID %>').value;
				url = url + '&fdt=' + $get('<%= F_Date.ClientID %>').value;
				url = url + '&tdt=' + $get('<%= T_Date.ClientID %>').value;
				url = url + '&dept=' + $get('<%= F_Dept.ClientID %>').checked;
				url = url + '&loca=' + $get('<%= F_Loca.ClientID %>').checked;
				window.open(url, nam, 'left=20,top=20,width=750,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
			function print_agingdetail() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=agingdetail';
				url = url + '&femp=' + $get('<%= LC_CardNo1.ClientID %>').value;
				url = url + '&temp=' + $get('<%= LC_CardNo2.ClientID %>').value;
				url = url + '&fdt=' + $get('<%= F_Date.ClientID %>').value;
				url = url + '&tdt=' + $get('<%= T_Date.ClientID %>').value;
				url = url + '&chk1=' + $get('<%= F_chk1.ClientID %>').checked;
				url = url + '&chk2=' + $get('<%= F_chk2.ClientID %>').checked;
				url = url + '&chk3=' + $get('<%= F_chk3.ClientID %>').checked;
				url = url + '&chk4=' + $get('<%= F_chk4.ClientID %>').checked;
				url = url + '&chk5=' + $get('<%= F_chk5.ClientID %>').checked;
				url = url + '&chk6=' + $get('<%= F_chk6.ClientID %>').checked;
				url = url + '&dept=' + $get('<%= F_Dept.ClientID %>').checked;
				url = url + '&loca=' + $get('<%= F_Loca.ClientID %>').checked;
				window.open(url, nam, 'left=20,top=20,width=750,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>

	</div>
</asp:Content>

