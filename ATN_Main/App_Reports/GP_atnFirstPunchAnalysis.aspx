<%@ Page Title="ISGEC:Print First Punch Analysis" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnFirstPunchAnalysis.aspx.vb" Inherits="GP_atnFirstPunchAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
	<div id="div1" runat="server" class="page">
		<br />
		<table width="100%">
			<tr>
				<td colspan="2" style="text-align: center; font-size: x-large;">
					<b>FIRST PUNCH ANALYSIS</b>
					<br />
				</td>
			</tr>
			<tr>
				<td style="font-size: medium; font-weight: bold; padding-top: 10px;text-align:right">
					<span >DEPARTMENT</span></td>
				<td width="50%" >
					<asp:CheckBox ID="F_Dept" runat="server" />
				</td>
			</tr>
			<tr>
				<td style="font-size: medium; font-weight: bold; padding-top: 10px;text-align:right">
					<span >LOCATION</span></td>
				<td>
					<asp:CheckBox ID="F_Loca" runat="server" />
				</td>
			</tr>
			<tr>
				<td style="font-size: medium; font-weight: bold; padding-top: 10px;text-align:right">
					<span >CATEGORY</span></td>
				<td>
					<asp:CheckBox ID="F_Cate" runat="server" />
				</td>
			</tr>
		</table>
		<script type="text/javascript">
			var lastcard = '';
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
		</script>
		<table>
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
					<b>For Month :</b>
				</td>
				<td colspan="3">
					<asp:DropDownList ID="F_Mon" runat="server">
						<asp:ListItem Value="1" Text="Jan"></asp:ListItem>
						<asp:ListItem Value="2" Text="Feb"></asp:ListItem>
						<asp:ListItem Value="3" Text="Mar"></asp:ListItem>
						<asp:ListItem Value="4" Text="Apr"></asp:ListItem>
						<asp:ListItem Value="5" Text="May"></asp:ListItem>
						<asp:ListItem Value="6" Text="Jun"></asp:ListItem>
						<asp:ListItem Value="7" Text="Jul"></asp:ListItem>
						<asp:ListItem Value="8" Text="Aug"></asp:ListItem>
						<asp:ListItem Value="9" Text="Sep"></asp:ListItem>
						<asp:ListItem Value="10" Text="Oct"></asp:ListItem>
						<asp:ListItem Value="11" Text="Nov"></asp:ListItem>
						<asp:ListItem Value="12" Text="Dec"></asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align: center; padding-top: 10px; padding-bottom: 5px;">
					<asp:Button ID="Button2" runat="server" Text="Print Analysis" OnClientClick="return print_analysis();" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align: center; padding-top: 10px; padding-bottom: 5px;">
					<asp:Button ID="cmdFPAS" runat="server" Text="Print Summary" OnClientClick="return print_summary();" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align: center; padding-top: 10px; padding-bottom: 5px;">
					<asp:Button ID="Button1" runat="server" Text="Print Detail" OnClientClick="return print_detail();" CssClass="mytxt" />
				</td>
			</tr>
		</table>

		<script type="text/javascript">
			var cnt = 0;
			function print_analysis() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=punchanalysis';
				url = url + '&femp=' + $get('<%= LC_CardNo1.ClientID %>').value;
				url = url + '&temp=' + $get('<%= LC_CardNo2.ClientID %>').value;
				url = url + '&mon=' + $get('<%= F_Mon.ClientID %>').value;
				url = url + '&dept=' + $get('<%= F_Dept.ClientID %>').checked;
				url = url + '&loca=' + $get('<%= F_Loca.ClientID %>').checked;
				url = url + '&cate=' + $get('<%= F_Cate.ClientID %>').checked;
				url = url + '&typ=a';
				window.open(url, nam, 'left=20,top=20,width=750,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
			function print_summary() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=punchanalysis';
				url = url + '&femp=' + $get('<%= LC_CardNo1.ClientID %>').value;
				url = url + '&temp=' + $get('<%= LC_CardNo2.ClientID %>').value;
				url = url + '&mon=' + $get('<%= F_Mon.ClientID %>').value;
				url = url + '&dept=' + $get('<%= F_Dept.ClientID %>').checked;
				url = url + '&loca=' + $get('<%= F_Loca.ClientID %>').checked;
				url = url + '&cate=' + $get('<%= F_Cate.ClientID %>').checked;
				url = url + '&typ=s';
				window.open(url, nam, 'left=20,top=20,width=750,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
			function print_detail() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=punchanalysis';
				url = url + '&femp=' + $get('<%= LC_CardNo1.ClientID %>').value;
				url = url + '&temp=' + $get('<%= LC_CardNo2.ClientID %>').value;
				url = url + '&mon=' + $get('<%= F_Mon.ClientID %>').value;
				url = url + '&dept=' + $get('<%= F_Dept.ClientID %>').checked;
				url = url + '&loca=' + $get('<%= F_Loca.ClientID %>').checked;
				url = url + '&cate=' + $get('<%= F_Cate.ClientID %>').checked;
				url = url + '&typ=d';
				window.open(url, nam, 'left=20,top=20,width=750,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>

	</div>
</asp:Content>

