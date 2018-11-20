<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnTimeShort.aspx.vb" Inherits="GD_atnTimeShort" title="Display List: Time Short" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
	<div id="div2" class="page">
    <div id="div3" class="caption">
			<asp:Label ID="LabelatnAppliedApplications" runat="server"  Text="&nbsp;List Time Short"></asp:Label>
    </div>
    <div id="div4" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnTimeShort"
      SearchContext = "atnTimeShort"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="AttenID">
      <Columns>
        <asp:TemplateField HeaderText="Attendance Date" SortExpression="AttenDate">
          <ItemTemplate>
            <asp:Label ID="LabelAttenDate" runat="server" Text='<%# Bind("AttenDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="150px" CssClass="alignCenter" />
        <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="First Punch Time" SortExpression="Punch1Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch1Time" runat="server" Text='<%# Bind("Punch1Time") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="150px" CssClass="alignCenter" />
        <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Second Punch Time" SortExpression="Punch2Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch2Time" runat="server" Text='<%# Bind("Punch2Time") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="150px" CssClass="alignCenter" />
        <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        
				<asp:TemplateField HeaderText="Punch Status" SortExpression="PunchStatusID">
          <ItemTemplate>
            <asp:Label ID="LabelPunchStatusID" runat="server" Text='<%# Bind("PunchStatusID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="150px" CssClass="alignCenter" />
        <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="TS Status" SortExpression="TSStatus">
          <ItemTemplate>
            <asp:Label ID="LabelTSStatus" runat="server" Text='<%# Bind("TSStatus") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
--%>      
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
      DataObjectTypeName = "SIS.ATN.atnTimeShort"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnTimeShort"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
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
</asp:Content>
