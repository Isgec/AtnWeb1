<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnAlertToUser.aspx.vb" Inherits="GD_atnAlertToUser" title="Display List: Alert to user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
	<div id="div2" class="page">
    <div id="div3" class="caption">
			<asp:Label ID="LabelatnAppliedApplications" runat="server"  Text="&nbsp;Send E-Mail Alert to User"></asp:Label>
    </div>
    <div id="div4" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnAlertToUser"
      SearchContext = "atnAlertToUser"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <table>
      <tr>
        <td colspan="4" style="Padding-left: 15px;">
          From 22nd of Last Month till 21st of selected Month
        </td>
      </tr>
      <tr>
        <td class="alignright" style="Padding: 15px;"><b>Attendance Month :</b></td>
        <td style="Padding: 15px;">
          <LGM:LC_atnMonths
            ID="LC_AttenMonth1"
            OrderBy="MonthID"
            DataTextField="Description"
            DataValueField="MonthID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            AutoPostBack="true"
            CssClass="myddl"
            Runat="Server" />
        </td>
        <td class="alignright" style="Padding: 15px;"><b>Location :</b></td>
        <td style="Padding: 15px;">
          <LGM:LC_hrmOffices
            ID="LC_hrmOffices1"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="OfficeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            AutoPostBack="true"
            CssClass="myddl"
            Runat="Server" />
        </td>
      </tr>
    </table>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="CardNo, AttenMonth">
      <Columns>
        <asp:TemplateField HeaderText="E-Mail">
          <ItemTemplate>
            <asp:ImageButton ID="cmdSend" runat="server" AlternateText="SendMail" ToolTip="Click to Send Mail." src="../../App_Themes/Default/Images/Mail-send.png" CommandName="SendMail" CommandArgument='<%# String.Format("{0}|{1}|{2}|{3}|{4}",EVal("CardNo"),EVal("EmployeeName"),EVal("SFinalValue"),EVal("EMailID"),EVal("AttenMonth")) %>' OnClick="SendMail_Click" />
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="CardNo">
          <ItemTemplate>
            <asp:Label ID="LabelCardNo" runat="server" Text='<%# Bind("CardNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Name" SortExpression="EmployeeName">
          <ItemTemplate>
            <asp:Label ID="LabelEmployeeName" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Days" SortExpression="SFinalValue">
          <ItemTemplate>
            <asp:Label ID="LabelSFinalValue" runat="server" Text='<%# Bind("SFinalValue") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation" SortExpression="Designation_Description">
          <ItemTemplate>
            <asp:Label ID="LabelDesignation_Description" runat="server" Text='<%# Bind("Designation_Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department" SortExpression="Department_Description">
          <ItemTemplate>
            <asp:Label ID="LabelDepartment_Description" runat="server" Text='<%# Bind("Department_Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location" SortExpression="Office_Description">
          <ItemTemplate>
            <asp:Label ID="LabelOffice_Description" runat="server" Text='<%# Bind("Office_Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="E-Mail ID" SortExpression="EMailID">
          <ItemTemplate>
            <asp:Label ID="LabelEMailID" runat="server" Text='<%# Bind("EMailID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
      <RowStyle BackColor="PaleGoldenrod" />
      <PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
      <HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" />
      <AlternatingRowStyle BackColor="Bisque" />
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnAlertToUser"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnAlertToUser"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="LC_AttenMonth1" PropertyName="SelectedValue" Name="AttenMonth" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="LC_hrmOffices1" PropertyName="SelectedValue" Name="OfficeID" Type="String" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="LC_AttenMonth1" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
