<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnEmployeeConfiguration.aspx.vb" Inherits="GF_atnEmployeeConfiguration" title="Maintain List: Employee Configuration" %>
<asp:Content ID="CPHatnEmployeeConfiguration" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnEmployeeConfiguration" runat="server" Text="&nbsp;List: Employee Configuration"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnEmployeeConfiguration" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnEmployeeConfiguration"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnEmployeeConfiguration.aspx"
      EnableAdd = "False"
      ValidationGroup = "atnEmployeeConfiguration"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnEmployeeConfiguration" runat="server" AssociatedUpdatePanelID="UPNLatnEmployeeConfiguration" DisplayAfter="100">
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
          <b><asp:Label ID="L_CardNo" runat="server" Text="Card No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            CssClass = "mypktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CardNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECardNo_Selected"
            OnClientPopulating="ACECardNo_Populating"
            OnClientPopulated="ACECardNo_Populated"
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
    <script type="text/javascript"> 
   var script_SendVerifyMail = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_SendApproveMail = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_AttendanceThroughExcel = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVatnEmployeeConfiguration" SkinID="gv_silver" runat="server" DataSourceID="ODSatnEmployeeConfiguration" DataKeyNames="CardNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CardNo") %>' Text='<%# Eval("HRM_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send Leave Verification Mail" SortExpression="SendVerifyMail">
          <ItemTemplate>
          <asp:CheckBox ID="F_SendVerifyMail"
            Checked='<%# Bind("SendVerifyMail") %>'
            CssClass = "mychk"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send Leave Approval Mail" SortExpression="SendApproveMail">
          <ItemTemplate>
          <asp:CheckBox ID="F_SendApproveMail"
            Checked='<%# Bind("SendApproveMail") %>'
            CssClass = "mychk"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Attendance Through Excel" SortExpression="AttendanceThroughExcel">
          <ItemTemplate>
          <asp:CheckBox ID="F_AttendanceThroughExcel"
            Checked='<%# Bind("AttendanceThroughExcel") %>'
            CssClass = "mychk"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Save">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Save record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSatnEmployeeConfiguration"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnEmployeeConfiguration"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "atnEmployeeConfigurationSelectList"
      TypeName = "SIS.ATN.atnEmployeeConfiguration"
      SelectCountMethod = "atnEmployeeConfigurationSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVatnEmployeeConfiguration" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
