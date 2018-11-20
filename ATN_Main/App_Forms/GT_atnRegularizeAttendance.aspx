<%@ Page Title="ISGEC:Regularize Attendance" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnRegularizeAttendance.aspx.vb" Inherits="GT_atnRegularizeAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
		<LGM:LGMessage
			 ID="LGMessage1"
			 Width="400"
			 OnBeforeCancel="lgValidate.AppliedLeaveStatusCancel()"
			 runat="server" />
<div id="div1" class="page">
    <div id="div2" class="caption">
				<asp:Label ID="LabelatnAppliedApplications" runat="server" Text="List Incomplete Attendance" ></asp:Label>
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
		</br>
		<table width="100%">
		<tr>
			<td align="left">
			</td>
			<td align="right">
				<LGM:LC_LeaveCard ID="LC_LeaveCard1" runat="server" />
			</td>
		</tr>
		</table>
    <hr />
  	<asp:Table ID="tblDate" runat="server">
		</asp:Table>
  	<table id="tblRemarks" runat="server" style="width:100%;">
			<tr>
				<td id="tdNoDataFound" runat="server" class="rowgrey1" style="text-align: center;display: none">
					<h4 style="color: #3366FF">
						No Incomplete Attendance Found. !!!</h4>
				</td>
			</tr>
			<tr>
				<td class="rowgrey1" id="tdRemarks" runat="server" style="display:none">
				<table style="width: 100%">
					<tr>
						<td style="width: 80px; vertical-align: top;">
							<b>REASON :<font color="red">*</font> </b>
						</td>
						<td style="width: 300px">
							<input type="text"
								id="F_Remarks" 
								maxlength="100" 
							  onblur="this.value=this.value.replace(/\'/g,'');"
								class="mytxt" style="width: 300px; height: 50px" />
						</td>
						<td style="text-align: center;">
						<table style="width: 80px">
							<tr>
								<td style="text-align:center; border: solid 1pt purple; height: 22px; vertical-align: middle" class="sis_info">
									<input type="image" id="cmdSubmit" title="Click to submit" src="../../App_Themes/Default/Images/save.png" alt="imgSubmit" style="height:18px" onclick="lgValidate.cmdSubmit_Click(this);return false;" />
								</td>
							</tr>
							<tr>
								<td style="text-align:center; border: solid 1pt purple; height: 22px; vertical-align: middle" class="sis_info">
									<input type="image" id="cmdCancel" title="Click to cancel" style="width: 18px" onclick="return false;" alt="Cancel" src="../../App_Themes/Default/Images/closeWindow.png"/>
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
  </ContentTemplate>
  <Triggers>
  </Triggers>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>

