<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnSABySI.aspx.vb" Inherits="EF_atnSABySI" title="Edit: Site Attendance" %>
<asp:Content ID="CPHatnSABySI" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelatnSABySI" runat="server" Text="&nbsp;Edit: Site Attendance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLatnSABySI" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLatnSABySI"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "atnSABySI"
    runat = "server" />
<asp:FormView ID="FVatnSABySI"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSatnSABySI"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MonthID" runat="server" Text="Month :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MonthID"
            Width="88px"
            Text='<%# Bind("MonthID") %>'
            Enabled = "False"
            ToolTip="Value of Month."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_MonthID_Display"
            Text='<%# Eval("ATN_Months3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            onblur= "script_atnSABySI.validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_atnSABySI.ACEProjectID_Selected"
            OnClientPopulating="script_atnSABySI.ACEProjectID_Populating"
            OnClientPopulated="script_atnSABySI.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SiteName" runat="server" Text="Site Name :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SiteName"
            Text='<%# Bind("SiteName") %>'
            Width="300px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="atnSABySI"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Site Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSiteName"
            runat = "server"
            ControlToValidate = "F_SiteName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "atnSABySI"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="250"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SAStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SAStatusID"
            Width="88px"
            Text='<%# Bind("SAStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SAStatusID_Display"
            Text='<%# Eval("ATN_ApplicationStatus1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerifiedBy" runat="server" Text="Verified By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_VerifiedBy"
            Width="72px"
            Text='<%# Bind("VerifiedBy") %>'
            Enabled = "False"
            ToolTip="Value of Verified By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_VerifiedBy_Display"
            Text='<%# Eval("HRM_Employees4_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerifiedOn" runat="server" Text="Verified On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VerifiedOn"
            Text='<%# Bind("VerifiedOn") %>'
            ToolTip="Value of Verified On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Upload File: " />
        </td>
        <td >
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <asp:FileUpload Enabled='<%# ChildAddable %>' ID="F_ReportFile" runat="server" Width="280px" ToolTip="Click to select file to be attached." />
              <asp:Button Enabled='<%# ChildAddable %>' ID="cmdUpload" runat="server" Text="Attach" CommandName="lgUpload" CommandArgument='<%# Eval("PrimaryKey") %>' OnClientClick="return confirm('Upload File ?');" ToolTip="Click to upload selected file." />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdUpload" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
        <td colspan="2">
          <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Italic="true" Text="<===== [Attatch Scanned Attendance Register]" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td>
          <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Attatched File: " />
        </td>
        <td>
          <asp:LinkButton ID="cmdDownload" runat="server" ForeColor="ForestGreen" Font-Bold="true" Font-Underline="true" Text='<%# Eval("FileName") %>' CommandName="lgDownload" CommandArgument='<%# Eval("PrimaryKey") %>' ToolTip="Click to download attacment." OnClientClick='<%# Eval("GetDownloadLinkSASR") %>' />
        </td>
        <td class="alignright">
          <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Delete Attached File: " />
        </td>
        <td >
          <asp:ImageButton Enabled='<%# ChildAddable %>' ID="cmdDelete" runat="server" AlternateText="delete" SkinID="delete" CommandName="lgDelete" CommandArgument='<%# Eval("PrimaryKey") %>' OnClientClick="return confirm('Delete attachment ?');" ToolTip="Click to remove uploaded file." />
        </td>
      </tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelatnSABySIDays" runat="server" Text="&nbsp;List: Site Attendance Days"></asp:Label>
</legend>
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
      EnableExit = "false"
      ValidationGroup = "atnSABySIDays"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSatnSABySIDays" runat="server" AssociatedUpdatePanelID="UPNLatnSABySIDays" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
      <script type="text/javascript">
        function na() { alert('Not allowed, when data is submitted to HO');}
      </script>
    <asp:GridView ID="GVatnSABySIDays" SkinID="gv_silver" runat="server" DataSourceID="ODSatnSABySIDays" DataKeyNames="SerialNo,CardNo">
      <Columns>
        <asp:TemplateField HeaderText=" ">
          <ItemTemplate>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="5px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees2_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CardNo") %>' Text='<%# Eval("HRM_Employees2_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="22" SortExpression="D22">
          <ItemTemplate>
            <asp:Label ID="LabelD22" runat="server" ForeColor='<%# Eval("ForeColor22") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD22") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="23" SortExpression="D23">
          <ItemTemplate>
            <asp:Label ID="LabelD23" runat="server" ForeColor='<%# Eval("ForeColor23") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD23") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="24" SortExpression="D24">
          <ItemTemplate>
            <asp:Label ID="LabelD24" runat="server" ForeColor='<%# Eval("ForeColor24") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD24") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="25" SortExpression="D25">
          <ItemTemplate>
            <asp:Label ID="LabelD25" runat="server" ForeColor='<%# Eval("ForeColor25") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD25") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="26" SortExpression="D26">
          <ItemTemplate>
            <asp:Label ID="LabelD26" runat="server" ForeColor='<%# Eval("ForeColor26") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD26") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="27" SortExpression="D27">
          <ItemTemplate>
            <asp:Label ID="LabelD27" runat="server" ForeColor='<%# Eval("ForeColor27") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD27") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="28" SortExpression="D28">
          <ItemTemplate>
            <asp:Label ID="LabelD28" runat="server" ForeColor='<%# Eval("ForeColor28") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD28") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="29" SortExpression="D29">
          <ItemTemplate>
            <asp:Label ID="LabelD29" runat="server" ForeColor='<%# Eval("ForeColor29") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD29") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="30" SortExpression="D30">
          <ItemTemplate>
            <asp:Label ID="LabelD30" runat="server" ForeColor='<%# Eval("ForeColor30") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD30") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="31" SortExpression="D31">
          <ItemTemplate>
            <asp:Label ID="LabelD31" runat="server" ForeColor='<%# Eval("ForeColor31") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD31") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="01" SortExpression="D01">
          <ItemTemplate>
            <asp:Label ID="LabelD01" runat="server" ForeColor='<%# Eval("ForeColor01") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD01") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="02" SortExpression="D02">
          <ItemTemplate>
            <asp:Label ID="LabelD02" runat="server" ForeColor='<%# Eval("ForeColor02") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD02") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="03" SortExpression="D03">
          <ItemTemplate>
            <asp:Label ID="LabelD03" runat="server" ForeColor='<%# Eval("ForeColor03") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD03") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="04" SortExpression="D04">
          <ItemTemplate>
            <asp:Label ID="LabelD04" runat="server" ForeColor='<%# Eval("ForeColor04") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD04") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="05" SortExpression="D05">
          <ItemTemplate>
            <asp:Label ID="LabelD05" runat="server" ForeColor='<%# Eval("ForeColor05") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD05") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="06" SortExpression="D06">
          <ItemTemplate>
            <asp:Label ID="LabelD06" runat="server" ForeColor='<%# Eval("ForeColor06") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD06") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="07" SortExpression="D07">
          <ItemTemplate>
            <asp:Label ID="LabelD07" runat="server" ForeColor='<%# Eval("ForeColor07") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD07") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="08" SortExpression="D08">
          <ItemTemplate>
            <asp:Label ID="LabelD08" runat="server" ForeColor='<%# Eval("ForeColor08") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD08") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="09" SortExpression="D09">
          <ItemTemplate>
            <asp:Label ID="LabelD09" runat="server" ForeColor='<%# Eval("ForeColor09") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD09") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="10" SortExpression="D10">
          <ItemTemplate>
            <asp:Label ID="LabelD10" runat="server" ForeColor='<%# Eval("ForeColor10") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD10") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="11" SortExpression="D11">
          <ItemTemplate>
            <asp:Label ID="LabelD11" runat="server" ForeColor='<%# Eval("ForeColor11") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD11") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="12" SortExpression="D12">
          <ItemTemplate>
            <asp:Label ID="LabelD12" runat="server" ForeColor='<%# Eval("ForeColor12") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD12") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="13" SortExpression="D13">
          <ItemTemplate>
            <asp:Label ID="LabelD13" runat="server" ForeColor='<%# Eval("ForeColor13") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD13") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="14" SortExpression="D14">
          <ItemTemplate>
            <asp:Label ID="LabelD14" runat="server" ForeColor='<%# Eval("ForeColor14") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD14") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="15" SortExpression="D15">
          <ItemTemplate>
            <asp:Label ID="LabelD15" runat="server" ForeColor='<%# Eval("ForeColor15") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD15") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="16" SortExpression="D16">
          <ItemTemplate>
            <asp:Label ID="LabelD16" runat="server" ForeColor='<%# Eval("ForeColor16") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD16") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="17" SortExpression="D17">
          <ItemTemplate>
            <asp:Label ID="LabelD17" runat="server" ForeColor='<%# Eval("ForeColor17") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD17") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="18" SortExpression="D18">
          <ItemTemplate>
            <asp:Label ID="LabelD18" runat="server" ForeColor='<%# Eval("ForeColor18") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD18") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="19" SortExpression="D19">
          <ItemTemplate>
            <asp:Label ID="LabelD19" runat="server" ForeColor='<%# Eval("ForeColor19") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD19") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="20" SortExpression="D20">
          <ItemTemplate>
            <asp:Label ID="LabelD20" runat="server" ForeColor='<%# Eval("ForeColor20") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD20") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="21" SortExpression="D21">
          <ItemTemplate>
            <asp:Label ID="LabelD21" runat="server" ForeColor='<%# Eval("ForeColor21") %>' style="cursor:pointer" onclick ='<%# eval("ClientLink") %>' Text='<%# Bind("getD21") %>' ></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# Eval("ForeColor05") %>' style="cursor:pointer" Text='<%# EVal("Remarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignleft" />
          <HeaderStyle HorizontalAlign="Left" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DEL">
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
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSatnSABySI"
  DataObjectTypeName = "SIS.ATN.atnSABySI"
  SelectMethod = "atnSABySIGetByID"
  UpdateMethod="UZ_atnSABySIUpdate"
  DeleteMethod="UZ_atnSABySIDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnSABySI"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
<LGM:LC_UpdateSAAttendance ID="updAtn" runat="server" />
</asp:Content>
