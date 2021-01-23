<%@ Page Title="ISGEC:Regularize OD" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnRegularizeODAttendance.aspx.vb" Inherits="GT_atnRegularizeODAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <LGM:LGMessage
    ID="LGMessage1"
    Width="400"
    OnBeforeCancel="lgValidate.AppliedLeaveStatusCancel()"
    runat="server" />
  <div id="div1" class="page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelatnAppliedApplications" runat="server" Text="List Incomplete Attendance for OD regularization "></asp:Label>
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
			      lgValidate.SplitClickToggleTypes = true;
			      lgValidate.ASCanBeApplied = false;
			      lgValidate.MLCanBeApplied = false;
          </script>
          <div id="frmdiv" class="ui-widget-content minipage">
            <table style="margin: auto">
              <tr>
                <td>
                  <h2><b>NOTE: OD is strictly for Out of office for duty, for Work From Home use <u><a href="../../WFHRoster.aspx">WFH Roster</a></u> option.</b></h2>
                </td>
              </tr>

              <tr>
                <td style="text-align: center;">
                  <LGM:LC_LeaveCard ID="LC_LeaveCard1" runat="server" />
                </td>
              </tr>
            </table>
            <hr />
            <asp:Table ID="tblDate" Style="margin: auto" runat="server">
            </asp:Table>
            <table id="tblRemarks" runat="server" style="margin: auto">
              <tr>
                <td id="tdNoDataFound" runat="server" class="rowgrey1" style="text-align: center; display: none">
                  <h4 style="color: #3366FF">No Incomplete Attendance Found. !!!</h4>
                </td>
              </tr>
              <tr>
                <td id="tdRemarks" runat="server" class="rowgrey1" style="display: none">
                  <table style="width: 100%">
                    <tr>
                      <td style="width: 80px; vertical-align: top;">
                        <b>REASON :<font color="red">*</font> </b>
                      </td>
                      <td style="width: 300px">
                        <input id="F_Remarks" class="mytxt" maxlength="100" onblur="this.value=this.value.replace(/\'/g,'');" style="width: 300px; height: 50px" type="text" />
                      </td>
                      <td style="text-align: center;">
                        <table style="width: 80px">
                          <tr>
                            <td class="sis_info" style="text-align: center; border: solid 1pt purple; height: 22px; vertical-align: middle">
                              <input id="cmdSubmit" alt="imgSubmit" onclick="lgValidate.cmdSubmit_Click(this);return false;" src="../../App_Themes/Default/Images/save.png" style="height: 18px" title="Click to submit" type="image" />
                            </td>
                          </tr>
                          <tr>
                            <td class="sis_info" style="text-align: center; border: solid 1pt purple; height: 22px; vertical-align: middle">
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
          </div>
          <div id="external" class="sis_modal" style="display: none; z-index: 105">
          </div>
          <div id="internal" class="sis_msg" enableviewstate="false" style="display: none; border: 3pt outset #C0C0C0; background-color: #003300; width: 400px; min-height: 50px; text-align: center; vertical-align: middle">
          </div>
          </br>
        </ContentTemplate>
        <Triggers>
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>

