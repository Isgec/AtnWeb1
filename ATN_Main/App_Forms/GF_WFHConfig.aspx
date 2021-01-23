<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_WFHConfig.aspx.vb" Inherits="GF_WFHConfig" title="Maintain List: WFH Confiuration" %>
<asp:Content ID="CPHWFHConfig" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelWFHConfig" runat="server" Text="&nbsp;List: WFH Confiuration"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLWFHConfig" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLWFHConfig"
      ToolType = "lgNMGrid"
      EditUrl = "~/ATN_Main/App_Edit/EF_WFHConfig.aspx"
      AddUrl = "~/ATN_Main/App_Create/AF_WFHConfig.aspx"
      ValidationGroup = "WFHConfig"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSWFHConfig" runat="server" AssociatedUpdatePanelID="UPNLWFHConfig" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVWFHConfig" SkinID="gv_silver" runat="server" DataSourceID="ODSWFHConfig" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SerialNo" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date" SortExpression="FromDate">
          <ItemTemplate>
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonFromDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFromDate"
            TargetControlID="F_FromDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFromDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFromDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FromDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVFromDate"
            runat = "server"
            ControlToValidate = "F_FromDate"
            ControlExtender = "MEEFromDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Initiate" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="To Date" SortExpression="ToDate">
          <ItemTemplate>
          <asp:TextBox ID="F_ToDate"
            Text='<%# Bind("ToDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonToDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEToDate"
            TargetControlID="F_ToDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonToDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEToDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ToDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVToDate"
            runat = "server"
            ControlToValidate = "F_ToDate"
            ControlExtender = "MEEToDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Initiate" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Opened For [*=All]" SortExpression="OpenedFor">
          <ItemTemplate>
          <asp:TextBox ID="F_OpenedFor"
            Text='<%# Bind("OpenedFor") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Opened For [*=All]."
            MaxLength="1000"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVOpenedFor"
            runat = "server"
            ControlToValidate = "F_OpenedFor"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Initiate" & Container.DataItemIndex %>'
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignleft" />
        <HeaderStyle CssClass="alignleft" Width="350px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Open For Entry" SortExpression="Active">
          <ItemTemplate>
          <asp:CheckBox ID="F_Active"
            Checked='<%# Bind("Active") %>'
            CssClass = "mychk"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Allow Update in Processed Date " SortExpression="AllowProcessed">
          <ItemTemplate>
          <asp:CheckBox ID="F_AllowProcessed"
            Checked='<%# Bind("AllowProcessed") %>'
            CssClass = "mychk"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Update">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save Record" SkinID="save" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Update record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Generate Roster">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Generate" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Generate Roster [Entries by user will intact] ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete Roster">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Delete Roster [all entry will be deleted] ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSWFHConfig"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.WFHConfig"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "WFHConfigSelectList"
      TypeName = "SIS.ATN.WFHConfig"
      SelectCountMethod = "WFHConfigSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVWFHConfig" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
