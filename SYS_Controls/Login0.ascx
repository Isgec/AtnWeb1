<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login0.ascx.vb" Inherits="Login0" %>
<div class="wp_login">
  <asp:LoginView ID="LoginFormView1" runat="server">
    <AnonymousTemplate>
      <asp:Login ID="Login0" OnLoggedIn="LoggedIn" OnLoginError="LoginError" OnLoggingIn="LoggingIn" runat="server">
        <LayoutTemplate>
          <asp:Panel ID="panel1" runat="server" DefaultButton="LoginButton">
            <table>
              <tr>
                <td>
                  <asp:Label runat="server" Text="Login ID:"></asp:Label>
                </td>
                <td style="height: 22px">
                  <asp:TextBox ID="UserName" runat="server" CssClass="mytxt" Font-Size="8pt" MaxLength="20" Width="60px"></asp:TextBox>
                </td>
                <td>
                  <asp:Label ID="Label1" runat="server" Text="Password:"></asp:Label>
                </td>
                <td style="height: 22px">
                  <asp:TextBox ID="Password" runat="server" CssClass="mytxt" Font-Size="8pt" MaxLength="20" TextMode="Password" Width="60px"></asp:TextBox>
                </td>
                <td style="height: 22px">
                  <asp:Button ID="LoginButton" CssClass="signin" runat="server" CommandName="Login" ValidationGroup="ctl00$ctl00$Login0" Text="Sign In" />
                </td>
              </tr>
              <tr>
                <td colspan="5" style=" text-align:center; color: #66FF66; font-weight: bold; background-color: Black">
                  <asp:Label ID="FailureText" runat="server" EnableViewState="False"></asp:Label>
                </td>
              </tr>
            </table>
          </asp:Panel>
        </LayoutTemplate>
      </asp:Login>
    </AnonymousTemplate>
    <LoggedInTemplate>
      <table>
        <td>
          <LGM:Informations ID="Informations1" Visible="false" runat="server" />
        </td>
        <td style="vertical-align:top"  >
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ChangePassword.aspx">Change Password</asp:LinkButton>
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" Height="16px" OnLoggedOut="LoggedOut" LoginText="Sign In" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" LogoutText="Sign Out" ToolTip="Sign Out" />
        </td>
      </table>
    </LoggedInTemplate>
  </asp:LoginView>
</div>
