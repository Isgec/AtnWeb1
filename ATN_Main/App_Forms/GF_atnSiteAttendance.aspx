<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_atnSiteAttendance.aspx.vb" Inherits="GF_atnSiteAttendance" title="Maintain List: Site Attendance Verification" %>
<asp:Content ID="CPHatnSiteAttendance" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnSiteAttendance" runat="server" Text="&nbsp;List: Site Attendance Verification"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnSiteAttendance" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnSiteAttendance"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnSiteAttendance.aspx"
      AddUrl = "~/ATN_Main/App_Create/AF_atnSiteAttendance.aspx"
      ValidationGroup = "atnSiteAttendance"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnSiteAttendance" runat="server" AssociatedUpdatePanelID="UPNLatnSiteAttendance" DisplayAfter="100">
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
          <b><asp:Label ID="L_MonthID" runat="server" Text="Month :" /></b>
        </td>
        <td>
          <LGM:LC_atnMonths
            ID="F_MonthID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="MonthID"
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
          <b><asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ApprovedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEApprovedBy"
            BehaviorID="B_ACEApprovedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApprovedByCompletionList"
            TargetControlID="F_ApprovedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEApprovedBy_Selected"
            OnClientPopulating="ACEApprovedBy_Populating"
            OnClientPopulated="ACEApprovedBy_Populated"
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
    <asp:GridView ID="GVatnSiteAttendance" SkinID="gv_silverHeader" runat="server" DataSourceID="ODSatnSiteAttendance" DataKeyNames="FinYear,MonthID,CardNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Month" SortExpression="ATN_Months3_Description">
          <ItemTemplate>
             <asp:Label ID="L_MonthID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("MonthID") %>' Text='<%# Eval("ATN_Months3_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter"  />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees5_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CardNo") %>' Text='<%# Eval("HRM_Employees5_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="22" SortExpression="VD22">
          <ItemTemplate>
            <asp:Label ID="LabelVD22" runat="server" ForeColor='<%# Eval("vForeColor22") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD22") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="23" SortExpression="VD23">
          <ItemTemplate>
            <asp:Label ID="LabelVD23" runat="server" ForeColor='<%# Eval("vForeColor23") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD23") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="24" SortExpression="VD24">
          <ItemTemplate>
            <asp:Label ID="LabelVD24" runat="server" ForeColor='<%# Eval("vForeColor24") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD24") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="25" SortExpression="VD25">
          <ItemTemplate>
            <asp:Label ID="LabelVD25" runat="server" ForeColor='<%# Eval("vForeColor25") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD25") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="26" SortExpression="VD26">
          <ItemTemplate>
            <asp:Label ID="LabelVD26" runat="server" ForeColor='<%# Eval("vForeColor26") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD26") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="27" SortExpression="VD27">
          <ItemTemplate>
            <asp:Label ID="LabelVD27" runat="server" ForeColor='<%# Eval("vForeColor27") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD27") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="28" SortExpression="VD28">
          <ItemTemplate>
            <asp:Label ID="LabelVD28" runat="server" ForeColor='<%# Eval("vForeColor28") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD28") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="29" SortExpression="VD29">
          <ItemTemplate>
            <asp:Label ID="LabelVD29" runat="server" ForeColor='<%# Eval("vForeColor29") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD29") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="30" SortExpression="VD30">
          <ItemTemplate>
            <asp:Label ID="LabelVD30" runat="server" ForeColor='<%# Eval("vForeColor30") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD30") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="31" SortExpression="VD31">
          <ItemTemplate>
            <asp:Label ID="LabelVD31" runat="server" ForeColor='<%# Eval("vForeColor31") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD31") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="01" SortExpression="VD01">
          <ItemTemplate>
            <asp:Label ID="LabelVD01" runat="server" ForeColor='<%# Eval("vForeColor01") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD01") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="02" SortExpression="VD02">
          <ItemTemplate>
            <asp:Label ID="LabelVD02" runat="server" ForeColor='<%# Eval("vForeColor02") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD02") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="03" SortExpression="VD03">
          <ItemTemplate>
            <asp:Label ID="LabelVD03" runat="server" ForeColor='<%# Eval("vForeColor03") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD03") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="04" SortExpression="VD04">
          <ItemTemplate>
            <asp:Label ID="LabelVD04" runat="server" ForeColor='<%# Eval("vForeColor04") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD04") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="05" SortExpression="VD05">
          <ItemTemplate>
            <asp:Label ID="LabelVD05" runat="server" ForeColor='<%# Eval("vForeColor05") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD05") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="06" SortExpression="VD06">
          <ItemTemplate>
            <asp:Label ID="LabelVD06" runat="server" ForeColor='<%# Eval("vForeColor06") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD06") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="07" SortExpression="VD07">
          <ItemTemplate>
            <asp:Label ID="LabelVD07" runat="server" ForeColor='<%# Eval("vForeColor07") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD07") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="08" SortExpression="VD08">
          <ItemTemplate>
            <asp:Label ID="LabelVD08" runat="server" ForeColor='<%# Eval("vForeColor08") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD08") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="09" SortExpression="VD09">
          <ItemTemplate>
            <asp:Label ID="LabelVD09" runat="server" ForeColor='<%# Eval("vForeColor09") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD09") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="10" SortExpression="VD10">
          <ItemTemplate>
            <asp:Label ID="LabelVD10" runat="server" ForeColor='<%# Eval("vForeColor10") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD10") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="11" SortExpression="VD11">
          <ItemTemplate>
            <asp:Label ID="LabelVD11" runat="server" ForeColor='<%# Eval("vForeColor11") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD11") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="12" SortExpression="VD12">
          <ItemTemplate>
            <asp:Label ID="LabelVD12" runat="server" ForeColor='<%# Eval("vForeColor12") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD12") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="13" SortExpression="VD13">
          <ItemTemplate>
            <asp:Label ID="LabelVD13" runat="server" ForeColor='<%# Eval("vForeColor13") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD13") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="14" SortExpression="VD14">
          <ItemTemplate>
            <asp:Label ID="LabelVD14" runat="server" ForeColor='<%# Eval("vForeColor14") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD14") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="15" SortExpression="VD15">
          <ItemTemplate>
            <asp:Label ID="LabelVD15" runat="server" ForeColor='<%# Eval("vForeColor15") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD15") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="16" SortExpression="VD16">
          <ItemTemplate>
            <asp:Label ID="LabelVD16" runat="server" ForeColor='<%# Eval("vForeColor16") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD16") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="17" SortExpression="VD17">
          <ItemTemplate>
            <asp:Label ID="LabelVD17" runat="server" ForeColor='<%# Eval("vForeColor17") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD17") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="18" SortExpression="VD18">
          <ItemTemplate>
            <asp:Label ID="LabelVD18" runat="server" ForeColor='<%# Eval("vForeColor18") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD18") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="19" SortExpression="VD19">
          <ItemTemplate>
            <asp:Label ID="LabelVD19" runat="server" ForeColor='<%# Eval("vForeColor19") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD19") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="20" SortExpression="VD20">
          <ItemTemplate>
            <asp:Label ID="LabelVD20" runat="server" ForeColor='<%# Eval("vForeColor20") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD20") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="21" SortExpression="VD21">
          <ItemTemplate>
            <asp:Label ID="LabelVD21" runat="server" ForeColor='<%# Eval("vForeColor21") %>' style="cursor:pointer" onclick='<%# eval("ClientLink") %>' Text='<%# Bind("getVD21") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verifier Remarks" SortExpression="VerifierRemarks">
          <ItemTemplate>
          <asp:TextBox ID="F_VerifierRemarks"
            Text='<%# Bind("VerifierRemarks") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            MaxLength="250"
            runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVVerifierRemarks"
						runat = "server"
						ControlToValidate = "F_VerifierRemarks"
						Text = "Remark is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
						SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FWD">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible="false" Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
          <ItemTemplate>
            </td>
            </tr>
            <tr id="row2" runat="server">
              <td></td>
              <td></td>
              <td colspan="17" style="text-align:center">
                <asp:Label ID="L_AsPerSubmitted" runat="server" Font-Italic="true" Font-Size="9px" ForeColor="#BCBCC3" Text="As per submitted data from site" />
              </td>
              <td colspan="17" style="text-align:center">
                <asp:Label ID="Label1" runat="server" Font-Italic="true" Font-Size="9px" ForeColor="red" Text='<%# Eval("ifReturned") %>' />
              </td>
              <td></td>
              <td></td>
            </tr>
            <tr id="row1" runat="server">
              <td></td>
              <td></td>
              <td colspan="34" style="padding:4px 0px 8px 0px;">
                <div style="display:none">
                <asp:Label ID="Row_MonthID" runat="server" Text='<%# Eval("MonthID") %>'></asp:Label>
                <asp:Label ID="Row_CardNo" runat="server" Text='<%# Eval("CardNo") %>'></asp:Label>
                </div>
                <asp:GridView ID="GVatnSABySIDays" SkinID="gv_silverChild" runat="server" DataSourceID="ODSatnSABySIDays" DataKeyNames="SerialNo,CardNo">
                  <Columns>
                    <asp:TemplateField HeaderText="FROM SITE">
                      <ItemTemplate>
                        <asp:Label ID="LabelFromSite" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ATN_SABySI1_SiteName") %>' ToolTip="Click to download attacment." onclick='<%# Eval("GetDownloadLinkSASR") %>' style="cursor:pointer"  ></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="22" SortExpression="D22">
                      <ItemTemplate>
                        <asp:Label ID="LabelD22" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("D22") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="23" SortExpression="D23">
                      <ItemTemplate>
                        <asp:Label ID="LabelD23" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D23") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="24" SortExpression="D24">
                      <ItemTemplate>
                        <asp:Label ID="LabelD24" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D24") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="25" SortExpression="D25">
                      <ItemTemplate>
                        <asp:Label ID="LabelD25" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D25") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="26" SortExpression="D26">
                      <ItemTemplate>
                        <asp:Label ID="LabelD26" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D26") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="27" SortExpression="D27">
                      <ItemTemplate>
                        <asp:Label ID="LabelD27" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D27") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="28" SortExpression="D28">
                      <ItemTemplate>
                        <asp:Label ID="LabelD28" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D28") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="29" SortExpression="D29">
                      <ItemTemplate>
                        <asp:Label ID="LabelD29" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D29") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="30" SortExpression="D30">
                      <ItemTemplate>
                        <asp:Label ID="LabelD30" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D30") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="31" SortExpression="D31">
                      <ItemTemplate>
                        <asp:Label ID="LabelD31" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D31") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="01" SortExpression="D01">
                      <ItemTemplate>
                        <asp:Label ID="LabelD01" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D01") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="02" SortExpression="D02">
                      <ItemTemplate>
                        <asp:Label ID="LabelD02" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D02") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="03" SortExpression="D03">
                      <ItemTemplate>
                        <asp:Label ID="LabelD03" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D03") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="04" SortExpression="D04">
                      <ItemTemplate>
                        <asp:Label ID="LabelD04" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D04") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="05" SortExpression="D05">
                      <ItemTemplate>
                        <asp:Label ID="LabelD05" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D05") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="06" SortExpression="D06">
                      <ItemTemplate>
                        <asp:Label ID="LabelD06" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D06") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="07" SortExpression="D07">
                      <ItemTemplate>
                        <asp:Label ID="LabelD07" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D07") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="08" SortExpression="D08">
                      <ItemTemplate>
                        <asp:Label ID="LabelD08" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D08") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="09" SortExpression="D09">
                      <ItemTemplate>
                        <asp:Label ID="LabelD09" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D09") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="10" SortExpression="D10">
                      <ItemTemplate>
                        <asp:Label ID="LabelD10" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D10") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="11" SortExpression="D11">
                      <ItemTemplate>
                        <asp:Label ID="LabelD11" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D11") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="12" SortExpression="D12">
                      <ItemTemplate>
                        <asp:Label ID="LabelD12" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D12") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="13" SortExpression="D13">
                      <ItemTemplate>
                        <asp:Label ID="LabelD13" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D13") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="14" SortExpression="D14">
                      <ItemTemplate>
                        <asp:Label ID="LabelD14" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D14") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="15" SortExpression="D15">
                      <ItemTemplate>
                        <asp:Label ID="LabelD15" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D15") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="16" SortExpression="D16">
                      <ItemTemplate>
                        <asp:Label ID="LabelD16" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D16") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="17" SortExpression="D17">
                      <ItemTemplate>
                        <asp:Label ID="LabelD17" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D17") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="18" SortExpression="D18">
                      <ItemTemplate>
                        <asp:Label ID="LabelD18" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D18") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="19" SortExpression="D19">
                      <ItemTemplate>
                        <asp:Label ID="LabelD19" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D19") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="20" SortExpression="D20">
                      <ItemTemplate>
                        <asp:Label ID="LabelD20" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D20") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="21" SortExpression="D21">
                      <ItemTemplate>
                        <asp:Label ID="LabelD21" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("D21") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                      <ItemTemplate>
                        <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("Remarks") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle HorizontalAlign="Left" Width="100px" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Text="*** NO RECORD FOUND ***"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource 
                  ID = "ODSatnSABySIDays"
                  runat = "server"
                  DataObjectTypeName = "SIS.ATN.atnSABySIDays"
                  OldValuesParameterFormatString = "original_{0}"
                  SelectMethod = "UZ_atnSABySIDaysSubmittedData"
                  TypeName = "SIS.ATN.atnSiteAttendance">
                  <SelectParameters >
                    <asp:ControlParameter ControlID="Row_MonthID" PropertyName="Text" Name="MonthID" Type="Int32" Size="10" />
                    <asp:ControlParameter ControlID="Row_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </td>
              <td></td>
              <td></td>
            </tr>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="1px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSatnSiteAttendance"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnSiteAttendance"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_atnSiteAttendanceSelectList"
      TypeName = "SIS.ATN.atnSiteAttendance"
      SelectCountMethod = "atnSiteAttendanceSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_MonthID" PropertyName="SelectedValue" Name="MonthID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ApprovedBy" PropertyName="Text" Name="ApprovedBy" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVatnSiteAttendance" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_MonthID" />
    <asp:AsyncPostBackTrigger ControlID="F_ApprovedBy" />
  </Triggers>
</asp:UpdatePanel>
<LGM:LC_UpdateAttendance ID="updAtn" runat="server" />
</div>
</div>
</asp:Content>
