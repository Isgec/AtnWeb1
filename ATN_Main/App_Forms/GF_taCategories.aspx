<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taCategories.aspx.vb" Inherits="GF_taCategories" title="Maintain List: TA Categories" %>
<asp:Content ID="CPHtaCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCategories" runat="server" Text="&nbsp;List: TA Categories"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCategories" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCategories"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_taCategories.aspx"
      EnableAdd = "False"
      ValidationGroup = "taCategories"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCategories" runat="server" AssociatedUpdatePanelID="UPNLtaCategories" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCategories" SkinID="gv_silver" runat="server" DataSourceID="ODStaCategories" DataKeyNames="CategoryID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CategoryCode" SortExpression="CategoryCode">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CategoryDescription" SortExpression="CategoryDescription">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CategorySequence" SortExpression="CategorySequence">
          <ItemTemplate>
            <asp:Label ID="LabelCategorySequence" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategorySequence") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="cmba" SortExpression="cmba">
          <ItemTemplate>
            <asp:Label ID="Labelcmba" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("cmba") %>'></asp:Label>
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
      ID = "ODStaCategories"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.taCategories"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taCategoriesSelectList"
      TypeName = "SIS.ATN.taCategories"
      SelectCountMethod = "taCategoriesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaCategories" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
