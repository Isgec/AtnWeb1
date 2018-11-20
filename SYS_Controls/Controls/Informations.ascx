<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Informations.ascx.vb" Inherits="Informations" %>
<table id="TblEmp" runat="server">
  <tr>
    <td style="text-align: right;">
      <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Name:"></asp:Label>
    </td>
    <td>
      <asp:Label ID="F_EmployeeName" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label>
    </td>
    <td style="text-align: right;">
      <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Year:"></asp:Label>
    </td>
    <td>
      <LGM:LC_atnFinYear ID="LC_atnFinYear1" runat="server" DataTextField="FinYear" DataValueField="Finyear" OrderBy="FinYear" AutoPostBack="true" IncludeDefault="False" />
    </td>
  </tr>
  <tr>
    <td style="text-align: right;">
      <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Verifier:"></asp:Label>
    </td>
    <td colspan="3">
      <asp:Label ID="F_Verifier" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label>
    </td>
  </tr>
  <tr>
    <td style="text-align: right;">
      <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Approver:"></asp:Label>
    </td>
    <td colspan="3">
      <asp:Label ID="F_Approver" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label>
    </td>
  </tr>
</table>
<%--<table id="TblEmp" runat="server" style="color:White" >
<tr><td style="text-align: right;">
  <asp:Label ID="Label2" runat="server"  Text="Name:"></asp:Label></td>
	<td >
  	<asp:Label ID="F_EmployeeName" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr><tr>
	<td style="text-align: right;">
  	<asp:Label ID="Label4" runat="server"  Text="Department:"></asp:Label></td>
	<td >
  	<asp:Label ID="F_Department" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr><tr>
	<td style="text-align: right;">
  	<asp:Label ID="Label6" runat="server"  Text="Designation:"></asp:Label></td>
	<td >
  	<asp:Label ID="F_Designation" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr><tr>
	<td style="text-align: right;">
  	<asp:Label ID="Label3" runat="server"  Text="Verifier:"></asp:Label></td>
	<td >
  	<asp:Label ID="F_Verifier" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr><tr>
	<td style="text-align: right;">
  	<asp:Label ID="Label5" runat="server"  Text="Approver:"></asp:Label></td>
	<td >
  	<asp:Label ID="F_Approver" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr><tr>
	<td style="text-align: right;">
  <asp:Label ID="Label1" runat="server"  Text="Year:"></asp:Label></td>
<td>
	<LGM:LC_atnFinYear 
		ID="LC_atnFinYear1" 
		runat="server" 
		DataTextField="FinYear" 
		DataValueField="Finyear" 
	  OrderBy="FinYear"
	  AutoPostBack="true"
		IncludeDefault="False" 
		Width="80px" />
</td>
</tr>
</table>
--%>