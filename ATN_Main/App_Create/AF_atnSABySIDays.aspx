<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnSABySIDays.aspx.vb" Inherits="AF_atnSABySIDays" title="Add: Site Attendance Days" %>
<asp:Content ID="CPHatnSABySIDays" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnSABySIDays" runat="server" Text="&nbsp;Add: Site Attendance Days"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnSABySIDays" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnSABySIDays"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "atnSABySIDays"
    runat = "server" />
<asp:FormView ID="FVatnSABySIDays"
  runat = "server"
  DataKeyNames = "SerialNo,CardNo"
  DataSourceID = "ODSatnSABySIDays"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgatnSABySIDays" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            ValidationGroup = "atnSABySIDays"
            onblur= "script_atnSABySIDays.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnSABySIDays"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("ATN_SABySI1_SiteName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnSABySIDays.ACESerialNo_Selected"
            OnClientPopulating="script_atnSABySIDays.ACESerialNo_Populating"
            OnClientPopulated="script_atnSABySIDays.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" ForeColor="#CC6633" runat="server" Text="Card No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            CssClass = "mypktxt"
            Width="72px"
            Text='<%# Bind("CardNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Card No."
            onblur= "script_atnSABySIDays.validate_CardNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text='<%# Eval("HRM_Employees2_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnSABySIDays.ACECardNo_Selected"
            OnClientPopulating="script_atnSABySIDays.ACECardNo_Populating"
            OnClientPopulated="script_atnSABySIDays.ACECardNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </div>

<asp:UpdatePanel ID="UPNLnewHrmEmployees" runat="server">
  <ContentTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:GridView ID="GVnewHrmEmployees" SkinID="gv_lsilver" runat="server" DataSourceID="ODSnewHrmEmployees" DataKeyNames="CardNo">
      <Columns>
        <asp:TemplateField HeaderText="SELECT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" runat="server" Visible='<%# Eval("Visible") %>' AlternateText="Select" ToolTip="Select Employee for site attendance." SkinID="complete" CommandName="lgSelect" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirm('Add employee in site attendance list ?');" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="CardNo">
          <ItemTemplate>
            <asp:Label ID="LabelCardNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CardNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee Name" SortExpression="EmployeeName">
          <ItemTemplate>
            <asp:Label ID="LabelEmployeeName" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division ID" SortExpression="HRM_Divisions12_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DivisionID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("C_DivisionID") %>' Text='<%# Eval("HRM_Divisions12_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department ID" SortExpression="HRM_Departments6_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DepartmentID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("C_DepartmentID") %>' Text='<%# Eval("HRM_Departments6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation ID" SortExpression="HRM_Designations9_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DesignationID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("C_DesignationID") %>' Text='<%# Eval("HRM_Designations9_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    </div>
    <asp:ObjectDataSource 
      ID = "ODSnewHrmEmployees"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.newHrmEmployees"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_newHrmSiteEmployeesSelectList"
      TypeName = "SIS.ATN.atnSABySIDays"
      EnablePaging="False">
      <SelectParameters >
        <asp:QueryStringParameter QueryStringField="SerialNo" Name="SerialNo" Type="String" Size="10" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnewHrmEmployees" EventName="RowCommand" />
  </Triggers>
</asp:UpdatePanel>

  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSatnSABySIDays"
  DataObjectTypeName = "SIS.ATN.atnSABySIDays"
  InsertMethod="UZ_atnSABySIDaysInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnSABySIDays"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
