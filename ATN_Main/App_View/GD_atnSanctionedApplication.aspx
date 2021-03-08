<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnSanctionedApplication.aspx.vb" Inherits="GD_atnSanctionedApplication" title="Display List: Sanctioned Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <script type="text/javascript" src="../../App_Scripts/ShowApplicationDays.js"></script>
  <LGM:LGMessage
    ID="LGMessage1"
    Width="600"
    runat="server" />
  <div id="div2" class="page">
    <div id="div3" class="caption">
      <asp:Label ID="LabelatnAppliedApplications" runat="server" Text="&nbsp;List Sanctioned Applications"></asp:Label>
    </div>
    <div id="div4" class="pagedata">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="ToolBar0_1"
            ToolType="lgNDGrid"
            EnableAdd="False"
            ValidationGroup="atnSanctionedApplication"
            SearchContext="atnSanctionedApplication"
            runat="server" />
          <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
              <div style="float: left;">Filter Records </div>
              <div style="float: left; margin-left: 20px;">
                <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
              </div>
              <div style="float: right; vertical-align: middle;">
                <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
              </div>
            </div>
          </asp:Panel>
          <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
            <table>
              <tr>
                <td class="alignright"><b>Employee :</b></td>
                <td style="padding-left: 5px;">
                  <script type="text/javascript">
                    function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
                      var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
                    LC_CardNo1.value = e.get_value();
                    __doPostBack('<%= LC_CardNo1.ClientID %>', e.get_value());
                }
                  </script>
                  <asp:TextBox
                    ID="LC_CardNo1"
                    CssClass="mytxt"
                    Width="40px"
                    AutoCompleteType="None"
                    Style="display: none"
                    runat="Server" />
                  <asp:TextBox
                    ID="LC_CardNoEmployeeName1"
                    CssClass="mytxt"
                    Width="200px"
                    AutoCompleteType="None"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="LC_CardNo1_AutoCompleteExtender"
                    ServiceMethod="CardNoCompletionList"
                    TargetControlID="LC_CardNoEmployeeName1"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
            </table>
          </asp:Panel>
          <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
            <ProgressTemplate>
              <span style="color: #ff0033">Loading...</span>
            </ProgressTemplate>
          </asp:UpdateProgress>

          <asp:GridView runat="server" SkinID="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="LeaveApplID">
            <Columns>
              <asp:TemplateField HeaderText="View">
                <ItemTemplate>
                  <input type="image" id='<%#Eval("LeaveApplID", "cmdInfo{0}") %>' alt='<%# Eval("LeaveApplID") %>' title="Detailed Information." src="../../App_Themes/Default/Images/Info.png" onclick="showDetails(this); return false;" />
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="30px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="ID" SortExpression="LeaveApplID">
                <ItemTemplate>
                  <asp:Label ID="LabelLeaveApplID" runat="server" Text='<%# Bind("LeaveApplID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="40px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Employee" SortExpression="HRM_Employees1_EmployeeName">
                <ItemTemplate>
                  <asp:Label ID="LabelCardNo" runat="server" Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignleft" />
                <HeaderStyle CssClass="alignleft" Width="200px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Applied Remarks" SortExpression="Remarks">
                <ItemTemplate>
                  <asp:Label ID="LabelRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignleft" />
                <HeaderStyle CssClass="alignleft" Width="250px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Applied On" SortExpression="AppliedOn">
                <ItemTemplate>
                  <asp:Label ID="LabelAppliedOn" runat="server" Text='<%# Bind("AppliedOn") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sanction Remark" SortExpression="SanctionRemark">
                <ItemTemplate>
                  <asp:Label ID="LabelSanctionRemark" runat="server" Text='<%# Bind("SanctionRemark") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignleft" />
                <HeaderStyle CssClass="alignleft" Width="300px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sanction On" SortExpression="SanctionOn">
                <ItemTemplate>
                  <asp:Label ID="LabelSanctionOn" runat="server" Text='<%# Bind("SanctionOn") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="80px" />
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
            </EmptyDataTemplate>
          </asp:GridView>
          <asp:ObjectDataSource
            ID="ObjectDataSource1"
            runat="server"
            DataObjectTypeName="SIS.ATN.atnSanctionedApplication"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="SelectList"
            TypeName="SIS.ATN.atnSanctionedApplication"
            SelectCountMethod="SelectCount"
            SortParameterName="OrderBy" EnablePaging="True">
            <SelectParameters>
              <asp:ControlParameter ControlID="LC_CardNo1" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
              <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
              <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
            </SelectParameters>
          </asp:ObjectDataSource>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="LC_CardNo1" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>
