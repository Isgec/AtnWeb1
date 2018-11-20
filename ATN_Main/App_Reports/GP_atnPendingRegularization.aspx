<%@ Page Title="ISGEC:Print Pending Regularization" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnPendingRegularization.aspx.vb" Inherits="GP_atnPendingRegularization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" runat="server" class="page">
		<br />
		<table width="100%">
		<tr>
			<td align="left">
				<asp:Label ID="LabelatnAppliedApplications" runat="server" Text="Pending Regularization" ></asp:Label>
			</td>
		</tr>
		</table>
		<table>
			<tr>
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
				<td>
					<asp:Button ID="cmdPrint" runat="server" Text="Print Pending Regularization" OnClientClick="return print_Report();" />
				</td>
			</tr>
		</table>
		
		<script type="text/javascript">
			var cnt = 0;
			function print_Report() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=pendingregularization';
				url = url + '&mon=' + $get('<%= F_Mon.ClientID %>').value;
				window.open(url, nam, 'left=20,top=20,width=650,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>		

</div>
</asp:Content>

