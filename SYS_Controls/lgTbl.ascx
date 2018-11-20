<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgTbl.ascx.vb" Inherits="lgTbl" %>
<div id="tbldiv" class="sis_tbl">
<table style="width:100%">
  <tr>
    <td id="tdDefault" runat="server">
      <table id="lg_tbl1">
        <tr>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center; height: 28px">
            <asp:ImageButton ID="CmdExit" ToolTip="Exit" runat="server" ImageUrl="~/TblImages/can0.png" /></td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center">
            <asp:ImageButton ID="CmdSave" ToolTip="Save" runat="server" ImageUrl="~/TblImages/sav0.png" /></td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center">
            <asp:ImageButton ID="CmdAdd" ToolTip="Add new record" runat="server" ImageUrl="~/TblImages/add0.png" /></td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center">
            <asp:ImageButton ID="CmdDelete" ToolTip="Delete record" runat="server" ImageUrl="~/TblImages/del0.png" /></td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center;">
            <asp:ImageButton ID="CmdForward" ToolTip="Forword data" runat="server" ImageUrl="~/TblImages/fwd0.png" /></td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center;">
            <asp:ImageButton ID="CmdReturn" ToolTip="Return data" runat="server" ImageUrl="~/TblImages/ret0.png" /></td>
        </tr>
      </table>
    </td>
    <td id="tdPage" runat="server">
      <table  id="lg_tbl2">
        <tr>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center;height: 28px">
            <asp:ImageButton ID="navFirst" ToolTip="First" runat="server" ImageUrl="~/TblImages/first0.png" /></td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center">
            <asp:ImageButton ID="navPrev" ToolTip="Previous" runat="server" ImageUrl="~/TblImages/prev0.png" /></td>
          <td class="lg_tbl" style="vertical-align: middle; text-align: center;">
            <asp:TextBox 
              ID="_CurrentPage" 
              runat="server" 
              CssClass="mytxt" 
              MaxLength="5"
              Width="40px" 
              Font-Bold="True" 
              Font-Names="vardana" 
              Font-Size="9px" 
              Text = "1"
              ValidationGroup="currentpage"
              style="text-align: right"
              AutoPostBack="True" />
						<AJX:MaskedEditExtender 
							ID = "MaskedEditExtenderCurrentPage"
							runat = "server"
							mask = "99999"
							AcceptNegative="None"
							MaskType="Number"
							MessageValidatorTip="false"
							InputDirection="RightToLeft"
							ErrorTooltipEnabled="false"
							TargetControlID="_CurrentPage" PromptCharacter="" />
          </td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: left">
            <asp:Label 
              ID="Label1" 
              runat="server" 
              Font-Bold="True"
              Font-Size="9px"  
              Text="#of" />
          </td>
           <td class="lg_tbl" style="vertical-align: middle; text-align: left">
             <asp:Label 
               ID="_TotalPages" 
               runat="server" 
               Font-Bold="True"
               Font-Size="9px"  
               Width="25px" 
               style="text-align: right" />
          </td>
           <td class="lg_tbl" style="vertical-align: middle; text-align: left; padding-left: 2px;">
             <asp:Label 
               ID="Label2" 
               runat="server" 
               Font-Bold="True"
               Font-Size="9px" 
               Text="Pages" />
          </td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center">
            <asp:ImageButton ID="navNext" ToolTip="Next" runat="server" ImageUrl="~/TblImages/next0.png" /></td>
          <td class="lg_tbl" style="width: 34px; vertical-align: middle; text-align: center">
            <asp:ImageButton ID="navLast" ToolTip="Last" runat="server" ImageUrl="~/TblImages/last0.png" /></td>
          <td class="lg_tbl" style="vertical-align: middle; text-align: center;">
            <asp:TextBox 
              ID="_PageSize" 
              runat="server" 
              CssClass="mytxt" 
              MaxLength="5"
              Width="40px" 
              Font-Bold="True" 
              Font-Size="9px" 
              ValidationGroup="currentpage"
              style="text-align: right" />
						<AJX:MaskedEditExtender 
							ID = "MaskedEditExtenderPageSize"
							runat = "server"
							mask = "99999"
							AcceptNegative="None"
							MaskType="Number"
							MessageValidatorTip="false"
							InputDirection="RightToLeft"
							ErrorTooltipEnabled="false"
							TargetControlID="_PageSize" PromptCharacter="" />
						<AJX:MaskedEditValidator 
							ID = "MaskedEditValidatorPageSize"
							runat = "server"
							ControlToValidate = "_PageSize"
							ControlExtender = "MaskedEditExtenderPageSize"
							InvalidValueMessage = ""
							EmptyValueMessage = ""
							EmptyValueBlurredText = ""
							Display = "Dynamic"
							TooltipMessage = ""
							EnableClientScript = "true"
							ValidationGroup = "currentpage"
							IsValidEmpty = "false"
							MinimumValue="2"
							MaximumValue="99999"
							SetFocusOnError="true" />
          </td>
          <td class="lg_tbl" style="width: 40px; vertical-align: middle; text-align: center;">
            <asp:LinkButton 
              ID="_PageSizeButton" 
              runat="server" 
              CausesValidation="False" 
              CommandName="PageSize" 
              ValidationGroup="currentpage"
              Font-Bold="True" 
              Font-Size="9px" 
              Text="/Page">
            </asp:LinkButton>
          </td>
          <td class="lg_tbl" style="width: 40px; vertical-align: middle; text-align: center;">
            <asp:ImageButton ID="cmdRefresh" ToolTip="Refresh data" runat="server" ImageUrl="~/TblImages/refresh.png" /></td>
        </tr>
      </table>
    </td>
    <td id="tdSearch" runat="server" align="right" style="text-align:right">
      <table  id="lg_tbl3">
        <tr>
          <td class="lg_tbl" style="vertical-align: middle; text-align: center;height: 28px">
						<asp:CheckBox
							ID="DisableSearch"
						  runat="server"
						  Enabled="false"
						  AutoPostBack="true"
						  ToolTip="Uncheck for normal view." />
					</td>
          <td class="lg_tbl" style="vertical-align: middle; text-align: center">
            <asp:TextBox 
              ID="SearchTextBox" 
              runat="server" 
              CssClass="mytxt" 
              ToolTip="Enter keywords to search." 
              Font-Names="vardana" 
						  ValidationGroup = "searchvalidationgroup"
						  Width="80px"
              Font-Size="9px" MaxLength="250" />
						<AJX:TextBoxWatermarkExtender 
							ID="Wm1" 
							runat="server" 
							TargetControlID="SearchTextBox"
							WatermarkText="[Search]">
						</AJX:TextBoxWatermarkExtender>
						<asp:RequiredFieldValidator 
							ID = "rfvst"
							runat = "server"
							ControlToValidate = "SearchTextBox"
							Display="none"
							EnableClientScript = "true"
							ValidationGroup = "searchvalidationgroup"
							SetFocusOnError="true" />
          </td>
          <td class="lg_tbl" style="vertical-align: middle; width: 34px; text-align: center">
            <asp:ImageButton 
              ID="CmdSearch" 
              runat="server" 
              ImageUrl="~/TblImages/srh0.png" 
              AlternateText="Search" 
              ToolTip="Click to search" 
		    ValidationGroup = "searchvalidationgroup" />
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
</div>