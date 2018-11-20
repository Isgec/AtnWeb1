<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_atnSiteAttendApproval.aspx.vb" Inherits="GF_atnSiteAttendApproval" title="Maintain List: Site Attendance Approval" %>
<asp:Content ID="CPHatnSiteAttendApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelatnSiteAttendApproval" runat="server" Text="&nbsp;List: Site Attendance Approval"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLatnSiteAttendApproval" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLatnSiteAttendApproval"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_atnSiteAttendApproval.aspx"
      EnableAdd = "False"
      ValidationGroup = "atnSiteAttendApproval"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnSiteAttendApproval" runat="server" AssociatedUpdatePanelID="UPNLatnSiteAttendApproval" DisplayAfter="100">
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
    <script type="text/javascript"> 
   var script_ApproverRemarks = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVatnSiteAttendApproval" SkinID="gv_silver" runat="server" DataSourceID="ODSatnSiteAttendApproval" DataKeyNames="FinYear,MonthID,CardNo">
      <Columns>
        <asp:TemplateField HeaderText="Month" SortExpression="ATN_Months3_Description">
          <ItemTemplate>
             <asp:Label ID="L_MonthID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("MonthID") %>' Text='<%# Eval("ATN_Months3_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees5_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CardNo") %>' Text='<%# Eval("HRM_Employees5_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="22" SortExpression="AD22">
          <ItemTemplate>
            <asp:Label ID="LabelAD22" runat="server" ForeColor='<%# Eval("aForeColor22") %>' Text='<%# Bind("AD22") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="23" SortExpression="AD23">
          <ItemTemplate>
            <asp:Label ID="LabelAD23" runat="server" ForeColor='<%# Eval("aForeColor23") %>' Text='<%# Bind("AD23") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="24" SortExpression="AD24">
          <ItemTemplate>
            <asp:Label ID="LabelAD24" runat="server" ForeColor='<%# Eval("aForeColor24") %>' Text='<%# Bind("AD24") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="25" SortExpression="AD25">
          <ItemTemplate>
            <asp:Label ID="LabelAD25" runat="server" ForeColor='<%# Eval("aForeColor25") %>' Text='<%# Bind("AD25") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="26" SortExpression="AD26">
          <ItemTemplate>
            <asp:Label ID="LabelAD26" runat="server" ForeColor='<%# Eval("aForeColor26") %>' Text='<%# Bind("AD26") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="27" SortExpression="AD27">
          <ItemTemplate>
            <asp:Label ID="LabelAD27" runat="server" ForeColor='<%# Eval("aForeColor27") %>' Text='<%# Bind("AD27") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="28" SortExpression="AD28">
          <ItemTemplate>
            <asp:Label ID="LabelAD28" runat="server" ForeColor='<%# Eval("aForeColor28") %>' Text='<%# Bind("AD28") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="29" SortExpression="AD29">
          <ItemTemplate>
            <asp:Label ID="LabelAD29" runat="server" ForeColor='<%# Eval("aForeColor29") %>' Text='<%# Bind("AD29") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="30" SortExpression="AD30">
          <ItemTemplate>
            <asp:Label ID="LabelAD30" runat="server" ForeColor='<%# Eval("aForeColor30") %>' Text='<%# Bind("AD30") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="31" SortExpression="AD31">
          <ItemTemplate>
            <asp:Label ID="LabelAD31" runat="server" ForeColor='<%# Eval("aForeColor31") %>' Text='<%# Bind("AD31") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="01" SortExpression="AD01">
          <ItemTemplate>
            <asp:Label ID="LabelAD01" runat="server" ForeColor='<%# Eval("aForeColor01") %>' Text='<%# Bind("AD01") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="02" SortExpression="AD02">
          <ItemTemplate>
            <asp:Label ID="LabelAD02" runat="server" ForeColor='<%# Eval("aForeColor02") %>' Text='<%# Bind("AD02") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="03" SortExpression="AD03">
          <ItemTemplate>
            <asp:Label ID="LabelAD03" runat="server" ForeColor='<%# Eval("aForeColor03") %>' Text='<%# Bind("AD03") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="04" SortExpression="AD04">
          <ItemTemplate>
            <asp:Label ID="LabelAD04" runat="server" ForeColor='<%# Eval("aForeColor04") %>' Text='<%# Bind("AD04") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="05" SortExpression="AD05">
          <ItemTemplate>
            <asp:Label ID="LabelAD05" runat="server" ForeColor='<%# Eval("aForeColor05") %>' Text='<%# Bind("AD05") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="06" SortExpression="AD06">
          <ItemTemplate>
            <asp:Label ID="LabelAD06" runat="server" ForeColor='<%# Eval("aForeColor06") %>' Text='<%# Bind("AD06") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="07" SortExpression="AD07">
          <ItemTemplate>
            <asp:Label ID="LabelAD07" runat="server" ForeColor='<%# Eval("aForeColor07") %>' Text='<%# Bind("AD07") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="08" SortExpression="AD08">
          <ItemTemplate>
            <asp:Label ID="LabelAD08" runat="server" ForeColor='<%# Eval("aForeColor08") %>' Text='<%# Bind("AD08") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="09" SortExpression="AD09">
          <ItemTemplate>
            <asp:Label ID="LabelAD09" runat="server" ForeColor='<%# Eval("aForeColor09") %>' Text='<%# Bind("AD09") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="10" SortExpression="AD10">
          <ItemTemplate>
            <asp:Label ID="LabelAD10" runat="server" ForeColor='<%# Eval("aForeColor10") %>' Text='<%# Bind("AD10") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="11" SortExpression="AD11">
          <ItemTemplate>
            <asp:Label ID="LabelAD11" runat="server" ForeColor='<%# Eval("aForeColor11") %>' Text='<%# Bind("AD11") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="12" SortExpression="AD12">
          <ItemTemplate>
            <asp:Label ID="LabelAD12" runat="server" ForeColor='<%# Eval("aForeColor12") %>' Text='<%# Bind("AD12") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="13" SortExpression="AD13">
          <ItemTemplate>
            <asp:Label ID="LabelAD13" runat="server" ForeColor='<%# Eval("aForeColor13") %>' Text='<%# Bind("AD13") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="14" SortExpression="AD14">
          <ItemTemplate>
            <asp:Label ID="LabelAD14" runat="server" ForeColor='<%# Eval("aForeColor14") %>' Text='<%# Bind("AD14") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="15" SortExpression="AD15">
          <ItemTemplate>
            <asp:Label ID="LabelAD15" runat="server" ForeColor='<%# Eval("aForeColor15") %>' Text='<%# Bind("AD15") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="16" SortExpression="AD16">
          <ItemTemplate>
            <asp:Label ID="LabelAD16" runat="server" ForeColor='<%# Eval("aForeColor16") %>' Text='<%# Bind("AD16") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="17" SortExpression="AD17">
          <ItemTemplate>
            <asp:Label ID="LabelAD17" runat="server" ForeColor='<%# Eval("aForeColor17") %>' Text='<%# Bind("AD17") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="18" SortExpression="AD18">
          <ItemTemplate>
            <asp:Label ID="LabelAD18" runat="server" ForeColor='<%# Eval("aForeColor18") %>' Text='<%# Bind("AD18") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="19" SortExpression="AD19">
          <ItemTemplate>
            <asp:Label ID="LabelAD19" runat="server" ForeColor='<%# Eval("aForeColor19") %>' Text='<%# Bind("AD19") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="20" SortExpression="AD20">
          <ItemTemplate>
            <asp:Label ID="LabelAD20" runat="server" ForeColor='<%# Eval("aForeColor20") %>' Text='<%# Bind("AD20") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="21" SortExpression="AD21">
          <ItemTemplate>
            <asp:Label ID="LabelAD21" runat="server" ForeColor='<%# Eval("aForeColor21") %>' Text='<%# Bind("AD21") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approver Remarks" SortExpression="ApproverRemarks">
          <ItemTemplate>
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            Width="150px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Approver Remarks."
            MaxLength="250"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVApproverRemarks"
						runat = "server"
						ControlToValidate = "F_ApproverRemarks"
						Text = "Remark is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
						SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Return">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField>
          <ItemTemplate>
            </td>
            </tr>
            <tr style="background-color:antiquewhite">
              <td colspan="25"></td>
              <td colspan="6" style="text-align:right">
                <asp:Label ID="Label_VR" runat="server" Text="Verifier Remarks : " ForeColor="Gray" Font-Bold="true" Font-Italic="true" />
              </td>
              <td colspan="5">
                <asp:Label ID="L_VerifierRemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("VerifierRemarks") %>' />
              </td>
              <td></td>
            </tr>
          </ItemTemplate>
          <HeaderStyle Width="5px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSatnSiteAttendApproval"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnSiteAttendApproval"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_atnSiteAttendApprovalSelectList"
      TypeName = "SIS.ATN.atnSiteAttendApproval"
      SelectCountMethod = "atnSiteAttendApprovalSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVatnSiteAttendApproval" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_MonthID" />
    <asp:AsyncPostBackTrigger ControlID="F_ApprovedBy" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
