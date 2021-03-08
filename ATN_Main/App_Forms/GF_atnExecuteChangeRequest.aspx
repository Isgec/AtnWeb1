<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_atnExecuteChangeRequest.aspx.vb" Inherits="GF_atnExecuteChangeRequest" title="Maintain List: Execute Change Request" %>
<asp:Content ID="CPHatnExecuteChangeRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnExecuteChangeRequest" runat="server" Text="&nbsp;List: Execute Change Request"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnExecuteChangeRequest" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnExecuteChangeRequest"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnExecuteChangeRequest.aspx"
      EnableAdd = "False"
      ValidationGroup = "atnExecuteChangeRequest"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnExecuteChangeRequest" runat="server" AssociatedUpdatePanelID="UPNLatnExecuteChangeRequest" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
        <td class="alignright">
          <b><asp:Label ID="L_UserID" runat="server" Text="User :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_UserID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UserID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEUserID_Selected"
            OnClientPopulating="ACEUserID_Populating"
            OnClientPopulated="ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVatnExecuteChangeRequest" SkinID="gv_silver" runat="server" DataSourceID="ODSatnExecuteChangeRequest" DataKeyNames="RequestID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="[ATN_ApproverChangeRequest].[RequestID]">
          <ItemTemplate>
            <asp:Label ID="LabelRequestID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User" SortExpression="[HRM_Employees1].[EmployeeName]">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("HRM_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Leave Application Verifier" SortExpression="[HRM_Employees2].[EmployeeName]">
          <ItemTemplate>
             <asp:Label ID="L_VerifierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VerifierID") %>' Text='<%# Eval("HRM_Employees2_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Leave Application Approver" SortExpression="[HRM_Employees3].[EmployeeName]">
          <ItemTemplate>
             <asp:Label ID="L_ApproverID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ApproverID") %>' Text='<%# Eval("HRM_Employees3_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TA Bill Verifier" SortExpression="[HRM_Employees4].[EmployeeName]">
          <ItemTemplate>
             <asp:Label ID="L_TAVerifierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TAVerifierID") %>' Text='<%# Eval("HRM_Employees4_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TA Bill Approver" SortExpression="[HRM_Employees5].[EmployeeName]">
          <ItemTemplate>
             <asp:Label ID="L_TAApproverID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TAApproverID") %>' Text='<%# Eval("HRM_Employees5_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TA Bill Sanctioning Authority" SortExpression="[HRM_Employees6].[EmployeeName]">
          <ItemTemplate>
             <asp:Label ID="L_TASA" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TASA") %>' Text='<%# Eval("HRM_Employees6_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested On" SortExpression="[ATN_ApproverChangeRequest].[RequestedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelRequestedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSatnExecuteChangeRequest"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnExecuteChangeRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_atnExecuteChangeRequestSelectList"
      TypeName = "SIS.ATN.atnExecuteChangeRequest"
      SelectCountMethod = "atnExecuteChangeRequestSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UserID" PropertyName="Text" Name="UserID" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVatnExecuteChangeRequest" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_UserID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
