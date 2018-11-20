<%@ Page Title="ISGEC:Print Attendance Sheet" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnAttendanceSheet.aspx.vb" Inherits="GP_atnAttendanceSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" runat="server" class="page">
		<br />
		<table width="100%">
		<tr>
			<td align="left">
				<asp:Label ID="LabelatnAppliedApplications" runat="server" Text="Attendance Sheet" ></asp:Label>
			</td>
		</tr>
		</table>
		<table>
			<tr>
				<td class="alignright">
					<b>Card No :</b></td>
				<td style="Padding-left: 5px;">

					<script type="text/javascript">

						function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
							var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
							LC_CardNo1.value = e.get_value();
						}
					</script>

					<asp:TextBox ID="LC_CardNo1" Runat="Server" AutoCompleteType="None" CssClass="mytxt" Style="display:none" Width="40px" />
					<asp:TextBox ID="LC_CardNoEmployeeName1" onfocus="return this.select();" Runat="Server" AutoCompleteType="None" CssClass="mytxt" Width="200px" />
					<AJX:AutoCompleteExtender ID="LC_CardNo1_AutoCompleteExtender" Runat="Server" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="10" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected" ServiceMethod="CardNoCompletionList" TargetControlID="LC_CardNoEmployeeName1" />
				</td>
				</tr>
				<tr>
				<td class="alignright">
					<b>For Month :</b></td>
				<td>
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
			  <td colspan="2" align="center" >
					<asp:Button ID="cmdAtnd" runat="server" Text="Print Attendance Sheet" OnClientClick="return print_atndReport();" />
				</td>
			</tr>
		</table>
		
		<script type="text/javascript">
			var cnt = 0;
			function print_atndReport() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=attendancesheet';
				url = url + '&mon=' + $get('<%= F_Mon.ClientID %>').value;
				url = url + '&emp=' + $get('<%= LC_CardNo1.ClientID %>').value;
				window.open(url, nam, 'left=20,top=20,width=650,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>		
</div>
</asp:Content>

