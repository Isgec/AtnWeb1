<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_UpdateAttendance.ascx.vb" Inherits="LC_UpdateAttendance" %>
<script type="text/javascript">
	var lc_updatn = {
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
		  try {
		    if (aaR[5] == 'BLANK') {
		      $get(aaR[1]).innerHTML = '--';
		      lc_updatn.targetControl.innerHTML = "--";
		    }else{
			    $get(aaR[1]).innerHTML = aaR[5];
			    lc_updatn.targetControl.innerHTML = aaR[5];
		    }
		  } catch (e) { alert(e.message); }
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
    <asp:Panel ID="pnlIpir" runat="server" Height="150px" Width="780px"  CssClass="modalPopup">
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
				<td class="alignleft" colspan="2">
      		<asp:Label ID="F_ErrMsg" ForeColor="Red" Font-Size="10px" style="display:block" runat="server" Text="" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="Label3" runat="server" Text="Select :" /></b>
				</td>
				<td>
					<table width="100%">
						<tr>
							<td>
								<input type="button" id="PR" value="PR" onclick="lc_updatn.updatnSave(this);" title="Present" />
							</td>
							<td>
								<input type="button" id="AD" value="AD" onclick="lc_updatn.updatnSave(this);" title="Absent Full Day" />
							</td>
							<td>
								<input type="button" id="OD" value="OD" onclick="lc_updatn.updatnSave(this);" title="On Duty" />
							</td>
							<td>
								<input type="button" id="CL" value="CL" onclick="lc_updatn.updatnSave(this);" title="Casual Leave" />
							</td>
							<td>
								<input type="button" id="SL" value="SL" onclick="lc_updatn.updatnSave(this);" title="Sick Leave" />
							</td>
							<td>
								<input type="button" id="PL" value="PL" onclick="lc_updatn.updatnSave(this);" title="Priviledge Leave" />
							</td>
							<td>
								<input type="button" id="ST" value="ST" onclick="lc_updatn.updatnSave(this);" title="Site Transfer" />
							</td>
							<td>
								<input type="button" id="HO" value="HO" onclick="lc_updatn.updatnSave(this);" title="Head Office" />
							</td>
							<td>
								<input type="button" id="TR" value="TR" onclick="lc_updatn.updatnSave(this);" title="Travelling" />
							</td>
							<td>
								<input type="button" id="NH" value="NH" onclick="lc_updatn.updatnSave(this);" title="National Holiday" />
							</td>
							<td>
								<input type="button" id="WO" value="WO" onclick="lc_updatn.updatnSave(this);" title="Weekly Off" />
							</td>
							<td>
								<input type="button" id="HD" value="HD" onclick="lc_updatn.updatnSave(this);" title="Holiday" />
							</td>
							<td>
								<input type="button" id="AP" value="AP" onclick="lc_updatn.updatnSave(this);" title="Accumulated PL" />
							</td>
							<td>
								<input type="button" id="AS" value="AS" onclick="lc_updatn.updatnSave(this);" title="Accumulated Sick" />
							</td>
							<td>
								<input type="button" id="Z8" value="Z8" onclick="lc_updatn.updatnSave(this);" title="#*PL-2020" />
							</td>
							<td>
								<input type="button" id="BLANK" value="--" onclick="lc_updatn.updatnSave(this);" title="Not known" />
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
          <input type="button" value="Cancel" onclick="lc_updatn.hidePop();" style="background-color:silver; color: Red" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:ModalPopupExtender BehaviorID="mpeIpir" PopupControlID="pnlIpir" OkControlID="closeIpir" CancelControlID="closeIpir" ID="ModalPopupExtender2" runat="server" TargetControlID="dummy" BackgroundCssClass="modalBackground" DropShadow="true" />

<%--PopupDragHandleControlID="dragIpir"--%>
