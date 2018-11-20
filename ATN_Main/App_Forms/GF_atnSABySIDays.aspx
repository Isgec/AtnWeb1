<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_atnSABySIDays.aspx.vb" Inherits="GF_atnSABySIDays" title="Maintain List: Site Attendance Days" %>
<asp:Content ID="CPHatnSABySIDays" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnSABySIDays" runat="server" Text="&nbsp;List: Site Attendance Days"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnSABySIDays" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnSABySIDays"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnSABySIDays.aspx"
      AddUrl = "~/ATN_Main/App_Create/AF_atnSABySIDays.aspx"
      AddPostBack = "True"
      ValidationGroup = "atnSABySIDays"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnSABySIDays" runat="server" AssociatedUpdatePanelID="UPNLatnSABySIDays" DisplayAfter="100">
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
          <b><asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_SerialNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESerialNo_Selected"
            OnClientPopulating="ACESerialNo_Populating"
            OnClientPopulated="ACESerialNo_Populated"
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
    <asp:GridView ID="GVatnSABySIDays" SkinID="gv_silver" runat="server" DataSourceID="ODSatnSABySIDays" DataKeyNames="SerialNo,CardNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees2_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CardNo") %>' Text='<%# Eval("HRM_Employees2_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="01" SortExpression="D01">
          <ItemTemplate>
            <asp:Label ID="LabelD01" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D01") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="02" SortExpression="D02">
          <ItemTemplate>
            <asp:Label ID="LabelD02" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D02") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="03" SortExpression="D03">
          <ItemTemplate>
            <asp:Label ID="LabelD03" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D03") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="04" SortExpression="D04">
          <ItemTemplate>
            <asp:Label ID="LabelD04" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D04") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="05" SortExpression="D05">
          <ItemTemplate>
            <asp:Label ID="LabelD05" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D05") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="06" SortExpression="D06">
          <ItemTemplate>
            <asp:Label ID="LabelD06" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D06") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="07" SortExpression="D07">
          <ItemTemplate>
            <asp:Label ID="LabelD07" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D07") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="08" SortExpression="D08">
          <ItemTemplate>
            <asp:Label ID="LabelD08" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D08") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="09" SortExpression="D09">
          <ItemTemplate>
            <asp:Label ID="LabelD09" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D09") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="10" SortExpression="D10">
          <ItemTemplate>
            <asp:Label ID="LabelD10" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D10") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="11" SortExpression="D11">
          <ItemTemplate>
            <asp:Label ID="LabelD11" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D11") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="12" SortExpression="D12">
          <ItemTemplate>
            <asp:Label ID="LabelD12" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D12") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="13" SortExpression="D13">
          <ItemTemplate>
            <asp:Label ID="LabelD13" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D13") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="14" SortExpression="D14">
          <ItemTemplate>
            <asp:Label ID="LabelD14" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D14") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="15" SortExpression="D15">
          <ItemTemplate>
            <asp:Label ID="LabelD15" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D15") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="16" SortExpression="D16">
          <ItemTemplate>
            <asp:Label ID="LabelD16" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D16") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="17" SortExpression="D17">
          <ItemTemplate>
            <asp:Label ID="LabelD17" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D17") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="18" SortExpression="D18">
          <ItemTemplate>
            <asp:Label ID="LabelD18" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D18") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="19" SortExpression="D19">
          <ItemTemplate>
            <asp:Label ID="LabelD19" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D19") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="20" SortExpression="D20">
          <ItemTemplate>
            <asp:Label ID="LabelD20" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D20") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="21" SortExpression="D21">
          <ItemTemplate>
            <asp:Label ID="LabelD21" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D21") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="22" SortExpression="D22">
          <ItemTemplate>
            <asp:Label ID="LabelD22" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D22") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="23" SortExpression="D23">
          <ItemTemplate>
            <asp:Label ID="LabelD23" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D23") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="24" SortExpression="D24">
          <ItemTemplate>
            <asp:Label ID="LabelD24" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D24") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="25" SortExpression="D25">
          <ItemTemplate>
            <asp:Label ID="LabelD25" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D25") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="26" SortExpression="D26">
          <ItemTemplate>
            <asp:Label ID="LabelD26" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D26") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="27" SortExpression="D27">
          <ItemTemplate>
            <asp:Label ID="LabelD27" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D27") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="28" SortExpression="D28">
          <ItemTemplate>
            <asp:Label ID="LabelD28" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D28") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="29" SortExpression="D29">
          <ItemTemplate>
            <asp:Label ID="LabelD29" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D29") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="30" SortExpression="D30">
          <ItemTemplate>
            <asp:Label ID="LabelD30" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D30") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="31" SortExpression="D31">
          <ItemTemplate>
            <asp:Label ID="LabelD31" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D31") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSatnSABySIDays"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnSABySIDays"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "atnSABySIDaysSelectList"
      TypeName = "SIS.ATN.atnSABySIDays"
      SelectCountMethod = "atnSABySIDaysSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVatnSABySIDays" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
