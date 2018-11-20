<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_LeaveCard.ascx.vb" Inherits="LC_LeaveCard" %>
    <script type="text/javascript">
    	function showLeaveCard(context) {
    		showProcessingMPV();
    		//PageMethods.ShowLeaveCard(context, ShowLeaveCard);
    		Sys.Net.WebServiceProxy.invoke('../../App_Services/_atnWebServices.asmx', 'ShowLeaveCard', false, { context: context }, ShowLeaveCard, ShowError);
    		return false;
    	}
    	function ShowLeaveCard(result) {
    		hideProcessingMPV();
    		backgroundColor('silver');
    		dynamicMessage(result);
    		showMessageMPV(result);
    	}
    	function ShowError(error) {
    		hideProcessingMPV();
    		backgroundColor('black');
    		dynamicMessage('<b>SERVER ERROR:</b> ' + error.get_message());
    		showMessageMPV();
    	}
    </script>
    
    <asp:Label ID="CTL_LeaveCard" runat="server" ToolTip="" onclick="showLeaveCard('');return false;" ForeColor="MediumPurple" style="border: solid 1pt MediumPurple; background-color:Silver; cursor:help" Font-Bold="true" Text="LEAVE CARD"></asp:Label>
