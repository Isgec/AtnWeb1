<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_newHrmEmployees.aspx.vb" Inherits="GF_newHrmEmployees" title="Maintain List: Employee" %>
<asp:Content ID="CPHnewHrmEmployees" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnewHrmEmployees" runat="server" Text="&nbsp;List: Employee"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnewHrmEmployees" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnewHrmEmployees"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_newHrmEmployees.aspx"
      AddUrl = "~/ATN_Main/App_Create/AF_newHrmEmployees.aspx"
      ValidationGroup = "newHrmEmployees"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnewHrmEmployees" runat="server" AssociatedUpdatePanelID="UPNLnewHrmEmployees" DisplayAfter="100">
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
            MaxLength="8"
            Width="72px"
            AutoPostBack="true"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_OfficeID" runat="server" Text="Office ID :" /></b>
        </td>
        <td>
          <LGM:LC_hrmOffices
            ID="F_C_OfficeID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="OfficeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_DepartmentID" runat="server" Text="Department ID :" /></b>
        </td>
        <td>
          <LGM:LC_hrmDepartments
            ID="F_C_DepartmentID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DepartmentID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_DesignationID" runat="server" Text="Designation ID :" /></b>
        </td>
        <td>
          <LGM:LC_hrmDesignations
            ID="F_C_DesignationID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DesignationID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" /></b>
        </td>
        <td>
          <LGM:LC_taCategories
            ID="F_CategoryID"
            OrderBy="CategoryDescription"
            DataTextField="CategoryDescription"
            DataValueField="CategoryID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVnewHrmEmployees" SkinID="gv_silver" runat="server" DataSourceID="ODSnewHrmEmployees" DataKeyNames="CardNo">
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
        <asp:TemplateField HeaderText="Division ID" SortExpression="HRM_Divisions12_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DivisionID") %>' Text='<%# Eval("HRM_Divisions12_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Office ID" SortExpression="HRM_Offices26_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_OfficeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_OfficeID") %>' Text='<%# Eval("HRM_Offices26_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department ID" SortExpression="HRM_Departments6_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DepartmentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DepartmentID") %>' Text='<%# Eval("HRM_Departments6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation ID" SortExpression="HRM_Designations9_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DesignationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DesignationID") %>' Text='<%# Eval("HRM_Designations9_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active State" SortExpression="ActiveState">
          <ItemTemplate>
            <asp:Label ID="LabelActiveState" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ActiveState") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category ID" SortExpression="TA_Categories40_CategoryDescription">
          <ItemTemplate>
             <asp:Label ID="L_CategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategoryID") %>' Text='<%# Eval("TA_Categories40_CategoryDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnewHrmEmployees"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.newHrmEmployees"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_newHrmEmployeesSelectList"
      TypeName = "SIS.ATN.newHrmEmployees"
      SelectCountMethod = "newHrmEmployeesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_C_OfficeID" PropertyName="SelectedValue" Name="C_OfficeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_C_DepartmentID" PropertyName="SelectedValue" Name="C_DepartmentID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_DesignationID" PropertyName="SelectedValue" Name="C_DesignationID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CategoryID" PropertyName="SelectedValue" Name="CategoryID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnewHrmEmployees" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
    <asp:AsyncPostBackTrigger ControlID="F_C_OfficeID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DepartmentID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DesignationID" />
    <asp:AsyncPostBackTrigger ControlID="F_CategoryID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
