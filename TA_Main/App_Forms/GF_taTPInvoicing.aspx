<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taTPInvoicing.aspx.vb" Inherits="GF_taTPInvoicing" title="Maintain List: Travel Invoices" %>
<asp:Content ID="CPHtaTPInvoicing" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaTPInvoicing" runat="server" Text="&nbsp;List: Travel Invoices"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaTPInvoicing" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaTPInvoicing"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taTPInvoicing.aspx"
      EnableAdd = "False"
      ValidationGroup = "taTPInvoicing"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaTPInvoicing" runat="server" AssociatedUpdatePanelID="UPNLtaTPInvoicing" DisplayAfter="100">
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
          <b><asp:Label ID="L_BookingDate" runat="server" Text="From Date :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_BookingDate"
            Text=""
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonBookingDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEBookingDate"
            TargetControlID="F_BookingDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonBookingDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEBookingDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BookingDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVBookingDate"
            runat = "server"
            ControlToValidate = "F_BookingDate"
            ControlExtender = "MEEBookingDate"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TravelDate" runat="server" Text="To Date :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_TravelDate"
            Text=""
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTravelDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETravelDate"
            TargetControlID="F_TravelDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTravelDate" />
          <AJX:MaskedEditExtender 
            ID = "MEETravelDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TravelDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVTravelDate"
            runat = "server"
            ControlToValidate = "F_TravelDate"
            ControlExtender = "MEETravelDate"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_EmployeeCode" runat="server" Text="Employee Code :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeCode"
            CssClass = "myfktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_EmployeeCode(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeCode_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEmployeeCode"
            BehaviorID="B_ACEEmployeeCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EmployeeCodeCompletionList"
            TargetControlID="F_EmployeeCode"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEmployeeCode_Selected"
            OnClientPopulating="ACEEmployeeCode_Populating"
            OnClientPopulated="ACEEmployeeCode_Populated"
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
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVtaTPInvoicing" SkinID="gv_silver" runat="server" ShowFooter="true" DataSourceID="ODStaTPInvoicing" DataKeyNames="InvoiceNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
--%>        <asp:TemplateField HeaderText="Invoice No" SortExpression="InvoiceNo">
          <ItemTemplate>
            <asp:Label ID="LabelInvoiceNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("InvoiceNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PAX Name" SortExpression="PAXName">
          <ItemTemplate>
            <asp:Label ID="LabelPAXName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PAXName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sector" SortExpression="Sector">
          <ItemTemplate>
            <asp:Label ID="LabelSector" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Sector") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Date" SortExpression="TravelDate">
          <ItemTemplate>
            <asp:Label ID="LabelTravelDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TravelDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Airline Name / Currency Type" SortExpression="AirlinesName">
          <ItemTemplate>
            <asp:Label ID="LabelAirlinesName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AirlinesName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ticket No / Currency Amount" SortExpression="TicketNo">
          <ItemTemplate>
            <asp:Label ID="LabelTicketNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TicketNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Net Amount" SortExpression="NetAmount">
          <ItemTemplate>
            <asp:Label ID="LabelNetAmount" runat="server" ForeColor="Black" Text='<%# Bind("NetAmount") %>'></asp:Label>
          </ItemTemplate>
          <FooterTemplate>
            <div style="text-align: right;">
             <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="Black" Text="TOTAL : " ></asp:Label>
             <asp:Label ID="LabelTotalAmount" runat="server" Font-Bold="true" ForeColor="Black" ></asp:Label>
				    </div>
          </FooterTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee Code" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_EmployeeCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("EmployeeCode") %>' Text='<%# Eval("HRM_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sanction No" SortExpression="Sanction">
          <ItemTemplate>
            <asp:Label ID="LabelSanction" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Sanction") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaTPInvoicing"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taTPInvoicing"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taTPInvoicingSelectList"
      TypeName = "SIS.TA.taTPInvoicing"
      SelectCountMethod = "taTPInvoicingSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_BookingDate" PropertyName="Text" Name="BookingDate" Type="DateTime" Size="20" />
        <asp:ControlParameter ControlID="F_TravelDate" PropertyName="Text" Name="TravelDate" Type="DateTime" Size="20" />
        <asp:ControlParameter ControlID="F_EmployeeCode" PropertyName="Text" Name="EmployeeCode" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaTPInvoicing" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_BookingDate" />
    <asp:AsyncPostBackTrigger ControlID="F_TravelDate" />
    <asp:AsyncPostBackTrigger ControlID="F_EmployeeCode" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
