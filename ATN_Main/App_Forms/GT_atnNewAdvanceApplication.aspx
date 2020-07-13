<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnNewAdvanceApplication.aspx.vb" Inherits="GT_atnNewAdvanceApplication" Title="ISGEC:Leave Application[Advance]" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <LGM:LGMessage
    ID="LGMessage1"
    Width="400"
    OnBeforeCancel="lgValidate.AppliedLeaveStatusCancel()"
    runat="server" />
  <div id="div1" class="page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelatnAppliedApplications" runat="server" Font-Bold="True" Font-Size="14px" Text="Apply Leave in Advance"></asp:Label>
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
          <div id="frmdiv" class="ui-widget-content minipage">
            <table style="margin: auto">
              <tr>
                <td class="cancel_button">
                  <LGM:LC_LeaveCard ID="LC_LeaveCard1" runat="server" />
                </td>
                <td class="cancel_button">
                  <asp:Label ID="NextDaysLabel" runat="server" Font-Bold="true" Text="Next Days :"></asp:Label>
                  <asp:TextBox ID="F_NextDays" runat="server" CssClass="mytxt" MaxLength="3" Width="40px" Text="20" Style="text-align: right" ToolTip="Enter next days" ValidationGroup="F_NextDays"></asp:TextBox>
                  <AJX:MaskedEditExtender ID="MaskedEditExtenderNextDays" runat="server" AcceptNegative="None" ErrorTooltipEnabled="false" InputDirection="RightToLeft" Mask="999" MaskType="Number" MessageValidatorTip="false" PromptCharacter="0" TargetControlID="F_NextDays" />
                  <AJX:MaskedEditValidator ID="MaskedEditValidatorNextDays" runat="server" ControlExtender="MaskedEditExtenderNextDays" ControlToValidate="F_NextDays" Display="Dynamic" EmptyValueBlurredText="" EmptyValueMessage="" EnableClientScript="true" InvalidValueMessage="" IsValidEmpty="false" MaximumValue="365" MinimumValue="1" SetFocusOnError="true" TooltipMessage="" ValidationGroup="F_NextDays" />
                  <asp:ImageButton ID="CmdImport" runat="server" ImageUrl="~/App_Themes/Default/Images/import.png" ValidationGroup="F_NextDays" />
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
                  <table style="margin: auto">
                    <tr>
                      <td style="width: 80px; vertical-align: top;">
                        <b>REASON :<font color="red">*</font> </b>
                      </td>
                      <td style="width: 300px">
                        <textarea id="F_Remarks" rows="2" cols="40" class="mytxt"  onkeypress="if (this.value.length > 100) { return false; }"
                          onblur="this.value=this.value.replace(/\'/g,'');"
                          style="width: 300px; height: 50px"></textarea>
                      </td>
                      <td style="text-align: center;">
                        <table style="width: 80px">
                          <tr>
                            <td class="sis_info" style="text-align: center; border: solid 1pt purple; height: 22px; vertical-align: middle">
                              <input id="cmdSubmit" alt="imgSubmit" onclick="lgValidate.cmdSubmit_Click(this); return false;" src="../../App_Themes/Default/Images/save.png" style="height: 18px" title="Click to submit" type="image" />
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
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="CmdImport" EventName="Click" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>

