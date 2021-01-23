<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgMessage.ascx.vb" Inherits="lgMessage" %>
<script type="text/javascript">
	function cancelMessage() {
		try {
			var tmp = '<%=OnBeforeCancel %>';
			eval(tmp);
		} catch (ex) { }
		var mPB = $find('mpe1');
		mPB.hide();
		try {
			var tmp = '<%=OnAfterCancel %>';
			eval(tmp);
		} catch (ex) { }

		return '<%=GetReturnTrueOnCancel %>';
	}
	function hideMessageMPV() {
		var mPB = $find('mpe1');
		mPB.hide();
		return false;
	}
	function showMessageMPV(ev) {
		var mPB = $find('mpe1');
		if (ev)
			$get('<%=dynamicData.ClientID %>').innerHTML = ev;
		mPB.show();
		return false;
	}
	function dynamicMessage(msg) {
		$get('<%=dynamicData.ClientID %>').style.display = 'block';
		$get('<%=dynamicData.ClientID %>').innerHTML = msg;
	}
	function backgroundColor(color) {
<%--		$get('<%=dynamicData.ClientID %>').style.backgroundColor = color;--%>
	}
</script>
<asp:Label ID="dummy" runat="server" Style="display: none"></asp:Label>
<asp:Panel ID="pnl1" runat="server" Style="display: none;border-radius:8px;border:1pt solid #0478cb; min-height: 100px; min-width: 400px">
  <asp:Panel id="tdTitle" runat="server" style="display:flex; flex-direction:row; justify-content:space-between;background-color:#0094ff;color:white;padding:4px;border-top-left-radius:inherit;border-top-right-radius:inherit;">
    <div>
			<asp:Image ID="imgerr" runat="server" AlternateText="Message" ToolTip="Message" ImageUrl="~/App_Themes/Default/Images/Error1.gif" />
    </div>
    <div style="text-align:left;font-weight:bold;font-size:12px;">
      <table><tr><td id="todrag" runat="server" style="cursor:move;">
      <asp:Label runat="server" Text="Attendance System"></asp:Label>
      </td></tr></table>
    </div>
    <div>
			<asp:ImageButton ID="cmdClose0" runat="server" Height="18px" Width="18px" OnClientClick="return cancelMessage();" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
    </div>
  </asp:Panel>
	<div id="dynamicData" runat="server" style="color:black;background-color:white; min-height:100px; min-width:400px;display:inline-block;border-bottom-left-radius:inherit;border-bottom-right-radius:inherit;" ></div>
</asp:Panel>
<AJX:ModalPopupExtender ID="mPopup" DropShadow="true" TargetControlID="dummy" BackgroundCssClass="modalBackground" BehaviorID="mpe1" CancelControlID="cmdClose0" OkControlID="cmdClose0" PopupControlID="pnl1" PopupDragHandleControlID="todrag" runat="server">
</AJX:ModalPopupExtender>
