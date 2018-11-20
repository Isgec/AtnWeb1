<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnWebPayNewEmp.aspx.vb" Inherits="GF_atnWebPayNewEmp" title="Maintain List: WebPay Employee" %>
<asp:Content ID="CPHatnWebPayNewEmp" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnWebPayNewEmp" runat="server" Text="&nbsp;List: WebPay Employee"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnWebPayNewEmp" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnWebPayNewEmp"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnWebPayNewEmp.aspx"
      EnableAdd = "False"
      ValidationGroup = "atnWebPayNewEmp"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnWebPayNewEmp" runat="server" AssociatedUpdatePanelID="UPNLatnWebPayNewEmp" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" Text="Card No :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_CardNo"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="10"
            Width="70px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVatnWebPayNewEmp" SkinID="gv_silver" runat="server" DataSourceID="ODSatnWebPayNewEmp" DataKeyNames="CardNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="CardNo">
          <ItemTemplate>
            <asp:Label ID="LabelCardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CardNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee Name" SortExpression="EmployeeName">
          <ItemTemplate>
            <asp:Label ID="LabelEmployeeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cost Company" SortExpression="CostCompany">
          <ItemTemplate>
            <asp:Label ID="LabelCostCompany" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CostCompany") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Unit" SortExpression="Unit">
          <ItemTemplate>
            <asp:Label ID="LabelUnit" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Unit") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
          <ItemTemplate>
            <asp:Label ID="LabelDesignation" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Designation") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DOJ" SortExpression="DOJ">
          <ItemTemplate>
            <asp:Label ID="LabelDOJ" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DOJ") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department" SortExpression="Department">
          <ItemTemplate>
            <asp:Label ID="LabelDepartment" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Department") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Seating Location" SortExpression="SeatingLocation">
          <ItemTemplate>
            <asp:Label ID="LabelSeatingLocation" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SeatingLocation") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Insert">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Insert" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Insert record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSatnWebPayNewEmp"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnWebPayNewEmp"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "atnWebPayNewEmpSelectList"
      TypeName = "SIS.ATN.atnWebPayNewEmp"
      SelectCountMethod = "atnWebPayNewEmpSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVatnWebPayNewEmp" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
