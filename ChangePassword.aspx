<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" title="ISGEC: Change Your Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
			<asp:Label ID="LabelatnProcessPunch" runat="server" Text="Change Password" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType="lgNReport"
      EnableAdd = "false"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="ui-widget-content minipage">
    <table style="margin:auto">
    <tr>
      <td>
        <LGM:ChangePass ID="ChangePass1" runat="server" />
      </td>
    </tr>
    </table>
   </div>
  </ContentTemplate>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>

