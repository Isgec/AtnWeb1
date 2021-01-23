<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_WFHConfig.aspx.vb" Inherits="AF_WFHConfig" title="Add: WFH Confiuration" %>
<asp:Content ID="CPHWFHConfig" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelWFHConfig" runat="server" Text="&nbsp;Add: WFH Confiuration"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLWFHConfig" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLWFHConfig"
    ToolType = "lgNMAdd"
    InsertAndStay = "True"
    ValidationGroup = "WFHConfig"
    runat = "server" />
<asp:FormView ID="FVWFHConfig"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSWFHConfig"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgWFHConfig" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="SerialNo :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FromDate" runat="server" Text="From Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="WFHConfig"
            onfocus = "return this.select();"
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
            ValidationGroup = "WFHConfig"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ToDate" runat="server" Text="To Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ToDate"
            Text='<%# Bind("ToDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="WFHConfig"
            onfocus = "return this.select();"
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
            ValidationGroup = "WFHConfig"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OpenedFor" runat="server" Text="Opened For [*=All] :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OpenedFor"
            Text='<%# Bind("OpenedFor") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="WFHConfig"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Opened For [*=All]."
            MaxLength="1000"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVOpenedFor"
            runat = "server"
            ControlToValidate = "F_OpenedFor"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "WFHConfig"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Open For Entry :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
           Checked='<%# Bind("Active") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AllowProcessed" runat="server" Text="Allow Update in Processed Date  :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_AllowProcessed"
           Checked='<%# Bind("AllowProcessed") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSWFHConfig"
  DataObjectTypeName = "SIS.ATN.WFHConfig"
  InsertMethod="UZ_WFHConfigInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.WFHConfig"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
