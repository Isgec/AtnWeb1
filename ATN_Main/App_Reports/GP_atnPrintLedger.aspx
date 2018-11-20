<%@ Page Title="ISGEC:Print Ledger" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnPrintLedger.aspx.vb" Inherits="GP_atnPrintLedger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
	<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
  <ContentTemplate>
		<asp:Button ID="Button1" runat="server" Text="Update E-Mail ID" />
		<asp:Button ID="Button2" runat="server" Text="Update Punch 9 Time" />
		<br>
		<br></br>
		<br></br>
		<br></br>
		<br></br>
		<table width="100%">
			<tr>
				<td align="left">
					<asp:Label ID="LabelatnAppliedApplications" runat="server"  Text="Print Ledger"></asp:Label>
				</td>
			</tr>
		</table>
		<hr />
		<table width="100%">
			<tr>
				<td>
					<asp:Label ID="Label1" runat="server" Font-Bold="true" Text="From Month:"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="F_FMon" runat="server">
						<asp:ListItem Text="Jan" Value="1"></asp:ListItem>
						<asp:ListItem Text="Feb" Value="2"></asp:ListItem>
						<asp:ListItem Text="Mar" Value="3"></asp:ListItem>
						<asp:ListItem Text="Apr" Value="4"></asp:ListItem>
						<asp:ListItem Text="May" Value="5"></asp:ListItem>
						<asp:ListItem Text="Jun" Value="6"></asp:ListItem>
						<asp:ListItem Text="Jul" Value="7"></asp:ListItem>
						<asp:ListItem Text="Aug" Value="8"></asp:ListItem>
						<asp:ListItem Text="Sep" Value="9"></asp:ListItem>
						<asp:ListItem Text="Oct" Value="10"></asp:ListItem>
						<asp:ListItem Text="Nov" Value="11"></asp:ListItem>
						<asp:ListItem Text="Dec" Value="12"></asp:ListItem>
					</asp:DropDownList>
				</td>
				<td>
					<asp:Label ID="Label2" runat="server" Font-Bold="true" Text="To Month:"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="F_TMon" runat="server">
						<asp:ListItem Text="Jan" Value="1"></asp:ListItem>
						<asp:ListItem Text="Feb" Value="2"></asp:ListItem>
						<asp:ListItem Text="Mar" Value="3"></asp:ListItem>
						<asp:ListItem Text="Apr" Value="4"></asp:ListItem>
						<asp:ListItem Text="May" Value="5"></asp:ListItem>
						<asp:ListItem Text="Jun" Value="6"></asp:ListItem>
						<asp:ListItem Text="Jul" Value="7"></asp:ListItem>
						<asp:ListItem Text="Aug" Value="8"></asp:ListItem>
						<asp:ListItem Text="Sep" Value="9"></asp:ListItem>
						<asp:ListItem Text="Oct" Value="10"></asp:ListItem>
						<asp:ListItem Text="Nov" Value="11"></asp:ListItem>
						<asp:ListItem Text="Dec" Value="12"></asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="From Emp:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_FEmp" runat="server" Text="0000" Width="60px"></asp:TextBox>
				</td>
				<td>
					<asp:Label ID="Label4" runat="server" Font-Bold="true" Text="To Emp:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_TEmp" runat="server" Text="9999" Width="60px"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td colspan="4">
					<asp:Button ID="cmdPrint" runat="server" OnClientClick="return print_Ledger();" Text="Print Ledger" />
				</td>
			</tr>
		</table>

		<script type="text/javascript">

			var cnt = 0;
			function print_Ledger() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');  
				url = url + '?reportname=ledger';
				url = url + '&fmon=' + $get('<%=F_FMon.ClientID %>').value;
				url = url + '&tmon=' + $get('<%=F_TMon.ClientID %>').value;
				url = url + '&femp=' + $get('<%=F_FEmp.ClientID %>').value;
				url = url + '&temp=' + $get('<%=F_TEmp.ClientID %>').value;
				window.open(url, nam, 'left=20,top=20,width=750,height=600,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>

		</br>
  </ContentTemplate>
  <Triggers>
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>

