<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnEmployees.aspx.vb" Inherits="GF_atnEmployees" title="Maintain List: Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelatnEmployees" runat="server" Text="List Employees"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0 ID="ToolBar0_1" ToolType="lgNMGrid" EnableAdd="False" ValidationGroup="atnEmployees" SearchContext="atnEmployees" runat="server" />
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
            <ProgressTemplate>
              <span style="color: #ff0033">Loading...</span>
            </ProgressTemplate>
          </asp:UpdateProgress>
          <table>
          </table>
          <script type="text/javascript">
            function LC_VerifierID2_AutoCompleteExtender_Selected(sender, e) {
              var LC_VerifierID2 = $get('<%= LC_VerifierID2.ClientID %>');
              LC_VerifierID2.value = e.get_value();
            }
          </script>
          <asp:TextBox ID="LC_VerifierID2" CssClass="mytxt" Width="40px" AutoCompleteType="None" Style="display: none" runat="Server" />
          <script type="text/javascript">
            function LC_ApproverID2_AutoCompleteExtender_Selected(sender, e) {
              var LC_ApproverID2 = $get('<%= LC_ApproverID2.ClientID %>');
              LC_ApproverID2.value = e.get_value();
            }
          </script>
          <asp:TextBox ID="LC_ApproverID2" CssClass="mytxt" Width="40px" AutoCompleteType="None" Style="display: none" runat="Server" />
          <asp:GridView SkinID="gv_silver" ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" DataKeyNames="CardNo">
            <Columns>
              <asp:TemplateField>
                <ItemTemplate>
                  <asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandArgument='<%# Bind("CardNo") %>' OnClick="Edit_Click" />
                  &nbsp;
                  <asp:ImageButton ID="FastEdit" runat="server" AlternateText="InLineEdit" ToolTip="Inlie Edit the record." SkinID="FastEdit" CommandArgument='<%# Bind("CardNo") %>' CommandName="Edit" />
                </ItemTemplate>
                <HeaderStyle Width="70px" />
                <EditItemTemplate>
                  <asp:ImageButton ID="Save" runat="server" AlternateText="Save" ToolTip="Save changes." SkinID="save" CommandArgument='<%# Bind("CardNo") %>' CommandName="Update" ValidationGroup="atnEmployees" />
                  &nbsp;
                  <asp:ImageButton ID="Cancel" runat="server" AlternateText="Cancel" ToolTip="Cancel changes." SkinID="cancel" CommandArgument='<%# Bind("CardNo") %>' CommandName="Cancel" />
                </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                  <asp:ImageButton ID="Info" runat="server" AlternateText="Info" ToolTip="Detailed Information." SkinID="Info" CommandArgument='<%# Bind("CardNo") %>' OnClick="Info_Click" />
                </ItemTemplate>
                <HeaderStyle Width="30px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Card No" SortExpression="CardNo">
                <ItemTemplate>
                  <asp:Label ID="LabelCardNo" runat="server" Text='<%# Bind("CardNo") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="50px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Employee Name" SortExpression="EmployeeName">
                <ItemTemplate>
                  <asp:Label ID="LabelEmployeeName" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Verification Required" SortExpression="VerificationRequired">
                <ItemTemplate>
                  <asp:Label ID="LabelVerificationRequired" runat="server" Text='<%# Bind("VerificationRequired") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="50px" />
                <EditItemTemplate>
                  <asp:CheckBox ID="CheckBoxVerificationRequired" Checked='<%# Bind("VerificationRequired") %>' runat="server" />
                </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Verifier" SortExpression="HRM_Employees1_EmployeeName">
                <ItemTemplate>
                  <asp:Label ID="LabelVerifierID" runat="server" Text='<%# Eval("VerifierIDHRM_Employees.EmployeeName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <EditItemTemplate>
                  <asp:TextBox ID="LC_VerifierID2" CssClass="mytxt" Width="40px" Text='<%# Bind("VerifierID") %>' AutoCompleteType="None" Style="display: none" runat="Server" />
                  <asp:TextBox ID="LC_VerifierIDEmployeeName2" Text='<%# Bind("VerifierIDEmployeeName") %>' CssClass="mytxt" Width="200px" AutoCompleteType="None" ToolTip="Enter value for Verifier." ValidationGroup="atnEmployees" runat="Server" />
                  <AJX:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderVerifierID1" runat="server" WatermarkText="[Enter Verifier]" TargetControlID="LC_VerifierIDEmployeeName2" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidatorVerifierID1" runat="server" ControlToValidate="LC_VerifierIDEmployeeName2" Text="Verifier is required." ErrorMessage="[Required!]" Display="Dynamic" EnableClientScript="true" ValidationGroup="atnEmployees" SetFocusOnError="true" />
                  <AJX:AutoCompleteExtender ID="LC_VerifierID2_AutoCompleteExtender" ServiceMethod="VerifierIDCompletionList" TargetControlID="LC_VerifierIDEmployeeName2" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_VerifierID2_AutoCompleteExtender_Selected" CompletionSetCount="10" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" runat="Server" />
                </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Approval Required" SortExpression="ApprovalRequired">
                <ItemTemplate>
                  <asp:Label ID="LabelApprovalRequired" runat="server" Text='<%# Bind("ApprovalRequired") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="50px" />
                <EditItemTemplate>
                  <asp:CheckBox ID="CheckBoxApprovalRequired" Checked='<%# Bind("ApprovalRequired") %>' runat="server" />
                </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Approver" SortExpression="HRM_Employees2_EmployeeName">
                <ItemTemplate>
                  <asp:Label ID="LabelApproverID" runat="server" Text='<%# Eval("ApproverIDHRM_Employees.EmployeeName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <EditItemTemplate>
                  <asp:TextBox ID="LC_ApproverID2" CssClass="mytxt" Width="40px" Text='<%# Bind("ApproverID") %>' AutoCompleteType="None" Style="display: none" runat="Server" />
                  <asp:TextBox ID="LC_ApproverIDEmployeeName2" Text='<%# Bind("ApproverIDEmployeeName") %>' CssClass="mytxt" Width="200px" AutoCompleteType="None" ToolTip="Enter value for Approver." ValidationGroup="atnEmployees" runat="Server" />
                  <AJX:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderApproverID1" runat="server" WatermarkText="[Enter Approver]" TargetControlID="LC_ApproverIDEmployeeName2" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidatorApproverID1" runat="server" ControlToValidate="LC_ApproverIDEmployeeName2" Text="Approver is required." ErrorMessage="[Required!]" Display="Dynamic" EnableClientScript="true" ValidationGroup="atnEmployees" SetFocusOnError="true" />
                  <AJX:AutoCompleteExtender ID="LC_ApproverID2_AutoCompleteExtender" ServiceMethod="ApproverIDCompletionList" TargetControlID="LC_ApproverIDEmployeeName2" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_ApproverID2_AutoCompleteExtender_Selected" CompletionSetCount="10" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" runat="Server" />
                </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Releaved On" SortExpression="C_DateOfReleaving">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkC_DateOfReleaving" runat="server" Text='<%# Bind("C_DateOfReleaving") %>' OnClick="cmdRemove_Click" CommandArgument='<%# Eval("CardNo") %>' />
                </ItemTemplate>
                <HeaderStyle Width="50px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Create OPB">
                <ItemTemplate>
                  <asp:ImageButton ID="cmdOPBal" runat="server" AlternateText="OpBal" ToolTip="Click to create Opening Balance." SkinID="update" CommandName="OpeningBalance" CommandArgument='<%# Bind("CardNo") %>' />
                </ItemTemplate>
                <HeaderStyle Width="70px" />
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
            </EmptyDataTemplate>
          </asp:GridView>
          <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIS.ATN.atnEmployees" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectList" UpdateMethod="Update" TypeName="SIS.ATN.atnEmployees" SelectCountMethod="SelectCount" SortParameterName="OrderBy" EnablePaging="True">
            <SelectParameters>
              <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
              <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
            </SelectParameters>
          </asp:ObjectDataSource>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>
