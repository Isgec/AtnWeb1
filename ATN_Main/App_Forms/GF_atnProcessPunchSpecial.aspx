<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnProcessPunchSpecial.aspx.vb" Inherits="GF_atnProcessPunchSpecial" title="Special Process Punch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
			<asp:Label ID="LabelatnProcessPunch" runat="server" Text="Special Process Punch" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
        <LGM:ToolBar0 
          ID="ToolBar0_1" 
          ToolType="lgNReport"
          EnableAdd="False" 
          runat="server" />
     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
    	var lemp = '';
    	var ldt = '';
    	function femp_onfocus(o) {
    		lemp = o.value;
    	}
    	function femp_onblur(o) {
    		if (lemp != o.value) {
    			$get('<%=F_TEmp.ClientID %>').value = o.value;
    			lemp = o.value;
    		}
    	}
    	function fdt_onfocus(o) {
    		ldt = o.value;
    	}
    	function fdt_onblur(o) {
    		if (ldt != o.value) {
    			$get('<%=F_TDate.ClientID %>').value = o.value;
    			ldt = o.value;
    		}
    	}
    </script>
<div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto">
			<tr>
				<td>
					<asp:Label ID="fromemplabel" runat="server" Text="From Employee:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_FEmp" runat="server" onfocus="return femp_onfocus(this);" onblur="return femp_onblur(this);" Width="60px" Text="0340"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label1" runat="server" Text="To Employee:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_TEmp" runat="server" Width="60px" Text="0340"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label2" runat="server" Text="Process From Raw Punch:"></asp:Label>
				</td>
				<td>
					<asp:CheckBox ID="F_RawPunch" Checked="false" Enabled="false" runat="server" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server" Text="From Date:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_FDate" runat="server" Width="70px" onfocus="return fdt_onfocus(this);" onblur="return fdt_onblur(this);" ValidationGroup="Process" ></asp:TextBox>
            <asp:Image ID="ImgFDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
            <AJX:CalendarExtender 
              ID = "CEFdate"
              TargetControlID="F_FDate"
              Format="dd/MM/yyyy"
              runat = "server" CssClass="MyCalendar" PopupButtonID="ImgFDate" />
					  <AJX:MaskedEditExtender 
						  ID = "MEEFDate"
						  runat = "server"
						  mask = "99/99/9999"
						  MaskType="Date"
              CultureName = "en-GB"
						  MessageValidatorTip="true"
						  InputDirection="LeftToRight"
						  ErrorTooltipEnabled="true"
						  TargetControlID="F_FDate" />
            <AJX:MaskedEditValidator 
						  ID = "MEVFDate"
						  runat = "server"
						  ControlToValidate = "F_FDate"
						  ControlExtender = "MEEFDate"
						  InvalidValueMessage = "Invalid From Date."
						  EmptyValueMessage = "From Date is required."
						  EmptyValueBlurredText = "[Required!]"
						  Display = "Dynamic"
						  TooltipMessage = "Enter From Date."
						  EnableClientScript = "true"
						  ValidationGroup = "Process"
						  IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label4" runat="server" Text="To Date:"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_TDate" runat="server" Width="70px" ></asp:TextBox>
            <asp:Image ID="ImgTDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
            <AJX:CalendarExtender 
              ID = "CETDate"
              TargetControlID="F_TDate"
              Format="dd/MM/yyyy"
              runat = "server" CssClass="MyCalendar" PopupButtonID="ImgTDate" />
					  <AJX:MaskedEditExtender 
						  ID = "MEETDate"
						  runat = "server"
						  mask = "99/99/9999"
						  MaskType="Date"
              CultureName = "en-GB"
						  MessageValidatorTip="true"
						  InputDirection="LeftToRight"
						  ErrorTooltipEnabled="true"
						  TargetControlID="F_TDate" />
            <AJX:MaskedEditValidator 
						  ID = "MEVTDate"
						  runat = "server"
						  ControlToValidate = "F_TDate"
						  ControlExtender = "MEETDate"
						  InvalidValueMessage = "Invalid To Date."
						  EmptyValueMessage = "To Date is required."
						  EmptyValueBlurredText = "[Required!]"
						  Display = "Dynamic"
						  TooltipMessage = "Enter To Date."
						  EnableClientScript = "true"
						  ValidationGroup = "Process"
						  IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td>
				</td>
				<td>
					<asp:Button ID="cmdIndividual" runat="server" Text="Process" ValidationGroup="Process" />
				</td>
			</tr>
      <tr>
        <td><b>When processing for all employees, Remember to VERIFY the attendance for SITE Employees.</b>
        </td>
      </tr>
    </table>
</div>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="cmdIndividual" EventName="Click" />
  </Triggers>
</asp:UpdatePanel>
   </div>
</div>
</asp:Content>
