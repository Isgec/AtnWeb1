<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_atnApproverChangeRequest.aspx.vb" Inherits="GF_atnApproverChangeRequest" title="Maintain List: Approver/Verifier Change Request" %>
<asp:Content ID="CPHatnApproverChangeRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnApproverChangeRequest" runat="server" Text="&nbsp;List: Approver/Verifier Change Request"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnApproverChangeRequest" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnApproverChangeRequest"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnApproverChangeRequest.aspx"
      AddUrl = "~/ATN_Main/App_Create/AF_atnApproverChangeRequest.aspx"
      ValidationGroup = "atnApproverChangeRequest"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnApproverChangeRequest" runat="server" AssociatedUpdatePanelID="UPNLatnApproverChangeRequest" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVatnApproverChangeRequest" SkinID="gv_silver" runat="server" DataSourceID="ODSatnApproverChangeRequest" DataKeyNames="RequestID">
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
        <asp:TemplateField HeaderText="TA Bill Santioning Authority" SortExpression="[HRM_Employees6].[EmployeeName]">
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
        <asp:TemplateField HeaderText="Executed On" SortExpression="[ATN_ApproverChangeRequest].[ExecutedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelExecutedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExecutedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executed" SortExpression="[ATN_ApproverChangeRequest].[Executed]">
          <ItemTemplate>
            <asp:Label ID="LabelExecuted" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Executed") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
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
      ID = "ODSatnApproverChangeRequest"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnApproverChangeRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_atnApproverChangeRequestSelectList"
      TypeName = "SIS.ATN.atnApproverChangeRequest"
      SelectCountMethod = "atnApproverChangeRequestSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVatnApproverChangeRequest" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
