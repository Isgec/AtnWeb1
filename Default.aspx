<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="LGDefault" title="Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<asp:Label ID="tmp" runat="server" />
<div style="float:right;">
  <asp:Button 
    ID="cmdRooster" 
    runat="server" 
    Text="Update WFH Roster" 
    BorderColor="Maroon" 
    BackColor="Crimson" 
    ForeColor="White" 
    Font-Bold="true" 
    Font-Size="20px" 
    ClientIDMode="Static"
    BorderWidth="1px" 
    Visible="false"
    OnClick="cmdRooster_Click"
    style="padding:20px;border-radius:5px;box-shadow:5px 10px 8px #888888;"
    BorderStyle="Solid" />
</div>
<div style="float:left">
<%= abcd %>
</div>
</asp:Content>

