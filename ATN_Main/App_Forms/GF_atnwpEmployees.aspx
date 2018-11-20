<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnwpEmployees.aspx.vb" Inherits="GF_atnwpEmployees" title="Maintain List: Create Employee From WP" %>
<asp:Content ID="CPHatnwpEmployees" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnwpEmployees" runat="server" Text="&nbsp;List: Create Employee From WP"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnwpEmployees" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnwpEmployees"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnwpEmployees.aspx"
      EnableAdd = "False"
      ValidationGroup = "atnwpEmployees"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnwpEmployees" runat="server" AssociatedUpdatePanelID="UPNLatnwpEmployees" DisplayAfter="100">
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
            Width="56px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_CompanyID" runat="server" Text="Company :" /></b>
        </td>
        <td>
          <LGM:LC_hrmCompanies
            ID="F_C_CompanyID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CompanyID"
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
          <b><asp:Label ID="L_C_DivisionID" runat="server" Text="Division :" /></b>
        </td>
        <td>
          <LGM:LC_hrmDivisions
            ID="F_C_DivisionID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DivisionID"
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
          <b><asp:Label ID="L_C_DepartmentID" runat="server" Text="Department :" /></b>
        </td>
        <td>
          <LGM:LC_hrmDepartments
            ID="F_C_DepartmentID"
            SelectedValue=""
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
          <b><asp:Label ID="L_C_DesignationID" runat="server" Text="Designation :" /></b>
        </td>
        <td>
          <LGM:LC_hrmDesignations
            ID="F_C_DesignationID"
            SelectedValue=""
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
          <b><asp:Label ID="L_C_OfficeID" runat="server" Text="Office :" /></b>
        </td>
        <td>
          <LGM:LC_hrmOffices
            ID="F_C_OfficeID"
            SelectedValue=""
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
          <b><asp:Label ID="L_C_ProjectSiteID" runat="server" Text="Project Site :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_C_ProjectSiteID"
            CssClass = "myfktxt"
            Width="42px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_C_ProjectSiteID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_C_ProjectSiteID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEC_ProjectSiteID"
            BehaviorID="B_ACEC_ProjectSiteID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="C_ProjectSiteIDCompletionList"
            TargetControlID="F_C_ProjectSiteID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEC_ProjectSiteID_Selected"
            OnClientPopulating="ACEC_ProjectSiteID_Populating"
            OnClientPopulated="ACEC_ProjectSiteID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVatnwpEmployees" SkinID="gv_silver" runat="server" DataSourceID="ODSatnwpEmployees" DataKeyNames="CardNo">
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
        <asp:TemplateField HeaderText="Date Of Joining" SortExpression="C_DateOfJoining">
          <ItemTemplate>
            <asp:Label ID="LabelC_DateOfJoining" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("C_DateOfJoining") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division" SortExpression="HRM_Divisions12_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DivisionID") %>' Text='<%# Eval("HRM_Divisions12_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Office" SortExpression="HRM_Offices20_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_OfficeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_OfficeID") %>' Text='<%# Eval("HRM_Offices20_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department" SortExpression="HRM_Departments6_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DepartmentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DepartmentID") %>' Text='<%# Eval("HRM_Departments6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation" SortExpression="HRM_Designations9_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DesignationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DesignationID") %>' Text='<%# Eval("HRM_Designations9_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date Of Releaving" SortExpression="C_DateOfReleaving">
          <ItemTemplate>
            <asp:Label ID="LabelC_DateOfReleaving" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("C_DateOfReleaving") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Process">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Process" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Process record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="wpSync">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="wpSync" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""wpSync record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSatnwpEmployees"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnwpEmployees"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "atnwpEmployeesSelectList"
      TypeName = "SIS.ATN.atnwpEmployees"
      SelectCountMethod = "atnwpEmployeesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_C_DivisionID" PropertyName="SelectedValue" Name="C_DivisionID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_OfficeID" PropertyName="SelectedValue" Name="C_OfficeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_C_DepartmentID" PropertyName="SelectedValue" Name="C_DepartmentID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_DesignationID" PropertyName="SelectedValue" Name="C_DesignationID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_C_ProjectSiteID" PropertyName="Text" Name="C_ProjectSiteID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_CompanyID" PropertyName="SelectedValue" Name="C_CompanyID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVatnwpEmployees" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DivisionID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_OfficeID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DepartmentID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DesignationID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_ProjectSiteID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_CompanyID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
