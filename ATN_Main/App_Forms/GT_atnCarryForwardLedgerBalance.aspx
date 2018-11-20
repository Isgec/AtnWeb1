<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnCarryForwardLedgerBalance.aspx.vb" Inherits="GT_atnCarryForwardLedgerBalance" title="Carry Forward Ledger Balance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
			<asp:Label ID="LabelatnProcessPunch" runat="server" Text="Carry Forward Ledger Balance" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <script type="text/javascript">
    	var lemp = '';
    	function femp_onfocus(o) {
    		lemp = o.value;
    	}
    	function femp_onblur(o) {
    		if (lemp != o.value) {
    			$get('<%=F_TEmp.ClientID %>').value = o.value;
    			lemp = o.value;
    		}
    	}
    </script>
    <table>
			<tr>
				<td>
					<asp:Label ID="fromemplabel" runat="server" Text="From Employee:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_FEmp" runat="server" onfocus="return femp_onfocus(this);" onblur="return femp_onblur(this);" Width="60px" Text="0340"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label1" runat="server" Text="To Employee:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_TEmp" runat="server" Width="60px" Text="0340"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label2" runat="server" Text="From Selected Fin. Year:"></asp:Label>
				</td>
				<td><b><asp:Label ID="F_FinYear" runat="server" Text=""></asp:Label></b>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server" Text="To Active Fin. Year:"></asp:Label>
				</td>
				<td>
					<b>
					<asp:Label ID="T_FinYear" runat="server" Text=""></asp:Label>
					</b>
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td>
				</td>
			</tr>
			<tr>
				<td>
				</td>
				<td>
					<asp:Button ID="cmdIndividual" runat="server" Text="Transfer" ValidationGroup="Process" />
				</td>
			</tr>
    </table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="cmdIndividual" EventName="Click" />
  </Triggers>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>
