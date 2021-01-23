<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnRules.aspx.vb" Inherits="GD_atnRules" title="ISGEC: Attendance Rules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelatnAppliedApplications" runat="server" Font-Bold="True" Font-Size="14px" Text="Leave Rules"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="ToolBar0_1"
            ToolType="lgNReport"
            EnableAdd="False"
            runat="server" />
          <div id="frmdiv" class="ui-widget-content minipage">
          </div>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>
