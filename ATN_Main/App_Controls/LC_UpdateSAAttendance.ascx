<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_UpdateSAAttendance.ascx.vb" Inherits="LC_UpdateSAAttendance" %>
<script type="text/javascript">
	var lc_updSAatn = {
	  targetControl: '',
    param: '',
    updatnShow: function (o, p) {
      this.param = o;
	    this.targetControl = p;
			$find('mpeIpir').show();
		},
		updatnSave: function(o) {
			showProcessingMPV();
			PageMethods.UpdateAttendance(this.targetControl.id + '|' + this.param + '|' + o.id, this.updatnSaved, this.updatnError);
			__doPostBack(this.targetControl.id, 'RowCommand');
		},
		updatnSaved: function (r) {
		  var aaR = r.split('|');
		  if (aaR[0] == '0') {
		    try {
		      if (aaR[4] == 'BLANK') {
		        $get(aaR[1]).innerHTML = '--';
		        lc_updSAatn.targetControl.innerHTML = "--";
		      } else {
		        $get(aaR[1]).innerHTML = aaR[4];
		        lc_updSAatn.targetControl.innerHTML = aaR[4];
		      }
		    } catch (e) { alert(e.message); }
		  }
			hideProcessingMPV();
			$find('mpeIpir').hide();
		},
		updatnError: function(r) {
			$get('<%= F_ErrMsg.ClientID %>').innerHTML = r._message;
			hideProcessingMPV();
		},
		showPop: function() {
			var mPop = $find('mpeIpir');
			mPop.show();
		},
		hidePop: function() {
			var mPop = $find('mpeIpir');
			mPop.hide();
		}
	}
</script>
    <asp:Label ID="dummy" runat="server" Text="dummy" style="display:none" ></asp:Label>
    <asp:Panel ID="pnlIpir" runat="server" Height="150px" Width="500px" Style="display:none;" CssClass="modalPopup">
      <table style="width: 100%">
        <tr>
          <td style="background-color: Navy">
            <asp:Image ID="Image2" runat="server" AlternateText="Attendance" ToolTip="Update Status" ImageUrl="~/App_Themes/Default/Images/application.png" />
          </td>
          <td id="dragIpir" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: White; height: 24px">
            Update Attendance
          </td>
          <td style="background-color: Navy; text-align: right">
            <asp:ImageButton ID="closeIpir" runat="server" Height="20px" Width="20px" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
          </td>
        </tr>
      </table>
    <br />
		<asp:Label ID="F_Context" ForeColor="#CC6633" style="display:none" runat="server" Text="" />
		<table width="100%">
		  <tr>
				<td class="alignleft" colspan="4">
      		<asp:Label ID="F_ErrMsg" ForeColor="Red" Font-Size="10px" style="display:block" runat="server" Text="" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="Label3" runat="server" Text="Select :" /></b>
				</td>
				<td colspan="3">
					<table width="100%">
						<tr>
							<td>
								<input type="button" id="PR" value="PR" onclick="lc_updSAatn.updatnSave(this);" title="Present" />
							</td>
							<td>
								<input type="button" id="AD" value="AD" onclick="lc_updSAatn.updatnSave(this);" title="Absent Full Day" />
							</td>
							<td>
								<input type="button" id="OD" value="OD" onclick="lc_updSAatn.updatnSave(this);" title="On Duty" />
							</td>
							<td>
								<input type="button" id="CL" value="CL" onclick="lc_updSAatn.updatnSave(this);" title="Casual Leave" />
							</td>
							<td>
								<input type="button" id="SL" value="SL" onclick="lc_updSAatn.updatnSave(this);" title="Sick Leave" />
							</td>
							<td>
								<input type="button" id="PL" value="PL" onclick="lc_updSAatn.updatnSave(this);" title="Priviledge Leave" />
							</td>
							<td>
								<input type="button" id="ST" value="ST" onclick="lc_updSAatn.updatnSave(this);" title="Site Transfer" />
							</td>
							<td>
								<input type="button" id="HO" value="HO" onclick="lc_updSAatn.updatnSave(this);" title="Head Office" />
							</td>
							<td>
								<input type="button" id="TR" value="TR" onclick="lc_updSAatn.updatnSave(this);" title="Travelling" />
							</td>
							<td>
								<input type="button" id="NH" value="NH" onclick="lc_updSAatn.updatnSave(this);" title="National Holiday" />
							</td>
							<td>
								<input type="button" id="BLANK" value="--" onclick="lc_updSAatn.updatnSave(this);" title="Not known" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<br />
    <table width="100%">
      <tr>
        <td style="text-align:center">
          <input type="button" value="Cancel" onclick="lc_updSAatn.hidePop();" style="background-color:silver; color: Red" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:ModalPopupExtender BehaviorID="mpeIpir" PopupControlID="pnlIpir" OkControlID="closeIpir" CancelControlID="closeIpir" ID="ModalPopupExtender2" runat="server" TargetControlID="dummy" BackgroundCssClass="modalBackground" DropShadow="true" />

<%--PopupDragHandleControlID="dragIpir"--%>
