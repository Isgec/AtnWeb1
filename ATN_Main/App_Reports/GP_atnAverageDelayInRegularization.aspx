<%@ Page Title="ISGEC:Print Average Delay In Regularization" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnAverageDelayInRegularization.aspx.vb" Inherits="GP_atnAverageDelayInRegularization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" runat="server" class="page">
		<br />
		<table width="100%">
		<tr>
			<td align="left">
				<asp:Label ID="LabelatnAppliedApplications" runat="server" Text="Average Delay In Regularization" ></asp:Label>
			</td>
		</tr>
		</table>
		<hr />
		<br />
		<table>
			<tr>
				<td align="right">
					<asp:Label ID="label1" runat="server" Font-Bold="true" Text="For Month:"></asp:Label>
				</td>
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
				<td align="right" valign="top">
					<asp:Label ID="label2" runat="server" Font-Bold="true" Text="Leave Types:"></asp:Label>
				</td>
				<td>
					<asp:Table ID="Tbl1" runat="server" BackColor="MistyRose" BorderColor="Brown" BorderStyle="Solid" BorderWidth="1pt" ></asp:Table>
				</td>
			</tr>
			<tr>
				<td align="right">
					<asp:Label ID="label3" runat="server" Font-Bold="true" Text="Summary:"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="F_Summary" runat="server">
						<asp:ListItem Value="1" Text="Detail"></asp:ListItem>
						<asp:ListItem Value="0" Text="Summary"></asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
				</td>
				<td align="center" style="padding-top: 10px">
					<asp:Button ID="cmdPrint" CssClass="mytxt" runat="server" Text="Print Report" OnClientClick="return print_Report();" />
				</td>
			</tr>
		</table>
		<script type="text/javascript">
			var cnt = 0;
			function print_Report() {
				if (lvtyp == '') {
					alert('Pl. select at leaset one Leave Type.');
					return false;
				}
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=averagedelayinregularization';
				url = url + '&mon=' + $get('<%= F_Mon.ClientID %>').value;
				url = url + '&lvt=' + lvtyp;
				url = url + '&det=' + $get('<%= F_Summary.ClientID %>').value;
				window.open(url, nam, 'left=20,top=20,width=650,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
			var lvtyp = '';
			function leavetype_click(o) {
				var aIDs = o.id.split('±');
				var lv = aIDs[aIDs.length - 1];
				if (o.checked == false) {
					var alvtyp = lvtyp.split(',');
					lvtyp = '';
					for (i = 0; i < alvtyp.length; i++) {
						if (alvtyp[i] != lv) {
							if (lvtyp == '')
								lvtyp = alvtyp[i];
							else
								lvtyp = lvtyp + ',' + alvtyp[i];
						}
					}
				}
				if (o.checked == true) {
					if (lvtyp == '')
						lvtyp = lv;
					else
						lvtyp = lvtyp + ',' + lv;
				}
			}
		</script>

</div>
</asp:Content>

