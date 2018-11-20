<%@ Page Title="ISGEC:Regularize Attendance" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnRegularizeFPAttendance.aspx.vb" Inherits="GT_atnRegularizeFPAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
		<LGM:LGMessage
			 ID="LGMessage1"
			 Width="400"
			 OnBeforeCancel="lgValidate.AppliedLeaveStatusCancel()"
			 runat="server" />
	<div id="div1" class="page">
    <div id="div2" class="caption">
			<asp:Label ID="LabelatnAppliedApplications" runat="server"  Text="List Incomplete Attendance [Only One Punch]"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
  <ContentTemplate>
        <LGM:ToolBar0 
          ID="ToolBar0_1" 
          ToolType="lgNReport"
          EnableAdd="False" 
          ValidationGroup="none"
          runat="server" />
		<script type="text/javascript" src="../../App_Scripts/ValidateRegularize.js"></script>
		<script type="text/javascript">
			lgValidate.SplitClickToggleTypes = false;
			lgValidate.ASCanBeApplied = false;
		</script>
<div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td>
					<LGM:LC_LeaveCard ID="LC_LeaveCard1" runat="server" />
				</td>
			</tr>
		</table>
		<hr />
		<asp:Table ID="tblDate" style="margin:auto" runat="server">
		</asp:Table>
		<table ID="tblRemarks" runat="server" style="margin:auto">
			<tr>
				<td ID="tdNoDataFound" runat="server" class="rowgrey1" style="text-align: center;display: block">
					<h4 style="color: #3366FF">
						Forget Punch Feature in Attendance System is Discontinued from 1st August 2017</h4>
				</td>
			</tr>
			<tr>
				<td ID="tdRemarks" runat="server" class="rowgrey1" style="display:none">
					<table style="width: 100%">
						<tr>
							<td style="width: 80px; vertical-align: top;">
								<b>Punch Time [23.59] :<font color="red">*</font> </b>
							</td>
							<td style="width: 300px">
								<%--<input ID="F_OLDRemarks" class="mytxt" maxlength="5" style="width: 72px" type="text" />--%>
								<asp:TextBox ID="F_Remarks" runat="server" class="mytxt" MaxLength="5" style="width: 60px"></asp:TextBox>
								<AJX:MaskedEditExtender 
                  ID="MEEF_Remarks" 
                  runat="server" 
                  AcceptAMPM="false" 
                  AcceptNegative="None" 
                  BehaviorID="meetv" 
                  CultureName="en-GB" 
                  ErrorTooltipEnabled="true" 
                  InputDirection="RightToLeft" 
                  mask="99:99" 
                  MaskType="Time" 
                  MessageValidatorTip="true" 
                  TargetControlID="F_Remarks" 
                  UserTimeFormat="TwentyFourHour" />
								<AJX:MaskedEditValidator 
                  ID="MEVF_Remarks" 
                  runat="server" 
                  ControlExtender="MEEF_Remarks" 
                  ControlToValidate="F_Remarks" 
                  Display="Dynamic" 
                  EmptyValueBlurredText="[Required!]" 
                  EmptyValueMessage="Punch Time is required." 
                  EnableClientScript="true" 
                  InvalidValueMessage="Invalid value for Punch Time." 
                  IsValidEmpty="false" 
                  SetFocusOnError="true" 
                  ValidationGroup="fp"
                  TooltipMessage="Enter value for Punch Time." />
							</td>
							<td style="text-align: center;">
								<table style="width: 80px">
									<tr>
										<td class="sis_info" style="text-align:center; border: solid 1pt purple; height: 22px; vertical-align: middle">
											<input ID="cmdSubmit" alt="imgSubmit" onclick="lgValidate.cmdSubmit_Click(this);return false;" src="../../App_Themes/Default/Images/save.png" style="height:18px" title="Click to submit" type="image" />
										</td>
									</tr>
									<tr>
										<td class="sis_info" style="text-align:center; border: solid 1pt purple; height: 22px; vertical-align: middle">
											<input ID="cmdCancel" alt="Cancel" onclick="return false;" src="../../App_Themes/Default/Images/closeWindow.png" style="width: 18px" title="Click to cancel" type="image" />
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    </div>
		<div ID="external" class="sis_modal" style="display:none; z-index: 105">
		</div>
		<div ID="internal" class="sis_msg" enableviewstate="false" style="display:none; border: 3pt outset #C0C0C0; background-color: #003300;  width:400px; min-height: 50px; text-align: center; vertical-align: middle">
		</div>
		</ContentTemplate>
  <Triggers>
  </Triggers>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>

