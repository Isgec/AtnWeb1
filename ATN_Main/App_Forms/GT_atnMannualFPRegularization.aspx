<%@ Page Title="ISGEC:Mannual Regularization" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnMannualFPRegularization.aspx.vb" Inherits="GT_MannualFPRegularization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
		<LGM:LGMessage
			 ID="LGMessage1"
			 Width="400"
			 OnBeforeCancel="lgValidate.AppliedLeaveStatusCancel()"
			 runat="server" />
<div id="div1" class="page">
    <div id="div2" class="caption">
					<asp:Label ID="LabelatnAppliedApplications" runat="server" Font-Bold="true" Font-Size="14px" Text="Mannual Forget Punch Regularization by HR"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
  <ContentTemplate>
        <LGM:ToolBar0 
          ID="ToolBar0_1" 
          ToolType="lgNReport"
          EnableAdd="False" 
          runat="server" />
		<script type="text/javascript" src="../../App_Scripts/ValidateRegularize.js"></script>
		<script type="text/javascript">
			lgValidate.SplitClickToggleTypes = false;
			lgValidate.ASCanBeApplied = false;
		</script>
<script type="text/javascript">
  var aLTs = new Array();
  aLTs[0]='FP';
</script>
<div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b>Card No :</b></td>
				<td style="Padding-left: 5px;">

					<script type="text/javascript">

						function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
							var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
							LC_CardNo1.value = e.get_value();
							__doPostBack('<%= LC_CardNo1.ClientID %>', e.get_value());
						}
					</script>

					<asp:TextBox ID="LC_CardNo1" Runat="Server" AutoCompleteType="None" CssClass="mytxt" Style="display:none" Width="40px" />
					<asp:TextBox ID="LC_CardNoEmployeeName1" Runat="Server" AutoCompleteType="None" CssClass="mytxt" Width="300px" onfocus='this.select();' />
					<AJX:AutoCompleteExtender ID="LC_CardNo1_AutoCompleteExtender" Runat="Server" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="10" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected" ServiceMethod="CardNoCompletionList" TargetControlID="LC_CardNoEmployeeName1" />
				</td>
				<td style="Padding-left: 5px;">
 					<LGM:LC_LeaveCard ID="LC_LeaveCard1" runat="server" />
        </td>
			</tr>
		</table>
		<hr />
		<asp:Table ID="tblDate" style="margin:auto" runat="server">
		</asp:Table>
		<table ID="tblRemarks" runat="server" style="margin:auto">
			<tr>
				<td ID="tdNoDataFound" runat="server" class="rowgrey1" style="text-align: center;display: none">
					<h4 style="color: #3366FF">
						No Incomplete Attendance Found. !!!</h4>
				</td>
			</tr>
			<tr>
				<td ID="tdRemarks" runat="server" class="rowgrey1" style="display:none">
					<table style="width: 100%">
						<tr>
							<td style="width: 80px; vertical-align: top;">
								<b>REASON :<font color="red">*</font> </b>
							</td>
							<td style="width: 300px">
								<input id="F_Remarks" class="mytxt" maxlength="100" 
							  onblur="this.value=this.value.replace(/\'/g,'');"
								style="width: 300px; height: 50px" type="text" />
							</td>
							<td style="text-align: center;">
								<table style="width: 80px">
									<tr>
										<td class="sis_info" style="text-align:center; border: solid 1pt purple; height: 22px; vertical-align: middle">
											<input id="cmdSubmit" alt="imgSubmit" onclick="lgValidate.cmdSubmit_Click(this);return false;" src="../../App_Themes/Default/Images/save.png" style="height:18px" title="Click to submit" type="image" />
										</td>
									</tr>
									<tr>
										<td class="sis_info" style="text-align:center; border: solid 1pt purple; height: 22px; vertical-align: middle">
											<input id="cmdCancel" alt="Cancel" onclick="return false;" src="../../App_Themes/Default/Images/closeWindow.png" style="width: 18px" title="Click to cancel" type="image" />
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<div id="external" class="sis_modal" style="display:none; z-index: 105">
		</div>
		<div id="internal" class="sis_msg" enableviewstate="false" style="display:none; border: 3pt outset #C0C0C0; background-color: #003300;  width:400px; min-height: 50px; text-align: center; vertical-align: middle">
		</div>
    </div>
  </ContentTemplate>
  <Triggers>
		<asp:AsyncPostBackTrigger ControlID="LC_CardNo1" EventName="TextChanged" />
  </Triggers>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>

