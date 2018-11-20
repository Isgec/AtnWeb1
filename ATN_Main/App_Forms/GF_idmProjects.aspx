<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_idmProjects.aspx.vb" Inherits="GF_idmProjects" title="Maintain List: Projects" %>
<asp:Content ID="CPHidmProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelidmProjects" runat="server" Text="&nbsp;List: Projects"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLidmProjects" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLidmProjects"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_idmProjects.aspx"
      EnableAdd = "False"
      ValidationGroup = "idmProjects"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSidmProjects" runat="server" AssociatedUpdatePanelID="UPNLidmProjects" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVidmProjects" SkinID="gv_silver" runat="server" DataSourceID="ODSidmProjects" DataKeyNames="ProjectID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ProjectID" SortExpression="ProjectID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSidmProjects"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.idmProjects"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "idmProjectsSelectList"
      TypeName = "SIS.ATN.idmProjects"
      SelectCountMethod = "idmProjectsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVidmProjects" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
