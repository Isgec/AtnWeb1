<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgToolBar.ascx.vb" Inherits="lgToolBar" %>
<div id="tbldiv" runat="server" clientidmode="Static" class="sis_tbl">
	<table width="100%">
		<tr>
			<td id="tdDefault" runat="server" align="left" >
				<table>
					<tr>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdExit" ToolTip="Exit" AccessKey="X" runat="server" ImageUrl="~/TblImages/can0.png" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdSave" ToolTip="Save" AccessKey="S" runat="server" ImageUrl="~/TblImages/sav0.png" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdAdd" ToolTip="Add new record" AccessKey="A" runat="server" ImageUrl="~/TblImages/add0.png" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdDelete" ToolTip="Delete record" AccessKey="D" runat="server" ImageUrl="~/TblImages/del0.png" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdForward" ToolTip="Forword" AccessKey="F" runat="server" ImageUrl="~/TblImages/fwd0.png" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdReturn" ToolTip="Return" AccessKey="R" runat="server" ImageUrl="~/TblImages/ret0.png" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdPrint" ToolTip="Print data" AccessKey="O" runat="server" ImageUrl="~/TblImages/prt1.png"  OnClientClick="return print_report(this);" Enabled="false" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="cmdHome" runat="server" ImageUrl="~/TblImages/home.png" AlternateText="Home" ToolTip="Click to home" />
						</td>
					</tr>
				</table>
			</td>
			<td width="18%" style="text-align:center" >
			</td>
			<td id="tdPage" runat="server" align="center">
				<table>
					<tr>
						<td class="mnu_but">
							<asp:ImageButton ID="navFirst" ToolTip="First" AccessKey="T" runat="server" ImageUrl="~/TblImages/first0.png" onmouseover="this.src='../../tblimages/first2.png';" onmouseout="this.src='../../tblimages/first0.png';" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="navPrev" ToolTip="Previous" AccessKey="P" runat="server" ImageUrl="~/TblImages/prev0.png" onmouseover="this.src='../../tblimages/prev2.png';" onmouseout="this.src='../../tblimages/prev0.png';" />
						</td>
						<td>
							<asp:TextBox ID="_CurrentPage" runat="server" CssClass="mytxt" MaxLength="5" Width="40px" Font-Bold="True" Font-Names="vardana" Font-Size="9px" Text="1" ValidationGroup="currentpage" Style="text-align: right" AutoPostBack="True" />
							<AJX:MaskedEditExtender ID="MaskedEditExtenderCurrentPage" BehaviorID="meeCP" runat="server" Mask="99999" AcceptNegative="None" MaskType="Number" MessageValidatorTip="false" InputDirection="RightToLeft" ErrorTooltipEnabled="false" TargetControlID="_CurrentPage" PromptCharacter="" />
						</td>
						<td class="mnu_but">
							<asp:Label ID="Label1" runat="server" Font-Bold="True"  Font-Size="9px" Text="#of" />
						</td>
						<td class="mnu_but">
							<asp:Label ID="_TotalPages" runat="server" Font-Bold="True" Font-Size="9px"  Width="25px" Style="text-align: right" />
						</td>
						<td>
							<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="9px"  Text="Pages" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="navNext" ToolTip="Next" AccessKey="N" runat="server" ImageUrl="~/TblImages/next0.png" onmouseover="this.src='../../tblimages/next2.png';" onmouseout="this.src='../../tblimages/next0.png';" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="navLast" ToolTip="Last" AccessKey="L" runat="server" ImageUrl="~/TblImages/last0.png" onmouseover="this.src='../../tblimages/last2.png';" onmouseout="this.src='../../tblimages/last0.png';" />
						</td>
						<td>
							<asp:TextBox ID="_PageSize" runat="server" CssClass="mytxt" MaxLength="5" Width="40px" Font-Bold="True" Font-Size="9px" ValidationGroup="currentpage" Style="text-align: right" />
							<AJX:MaskedEditExtender ID="MaskedEditExtenderPageSize" BehaviorID="meePS" runat="server" Mask="99999" AcceptNegative="None" MaskType="Number" MessageValidatorTip="false" InputDirection="RightToLeft" ErrorTooltipEnabled="false" TargetControlID="_PageSize" PromptCharacter="" />
							<AJX:MaskedEditValidator ID="MaskedEditValidatorPageSize" runat="server" ControlToValidate="_PageSize" ControlExtender="MaskedEditExtenderPageSize" InvalidValueMessage="" EmptyValueMessage="" EmptyValueBlurredText="" Display="Dynamic" TooltipMessage="" EnableClientScript="true" ValidationGroup="currentpage" IsValidEmpty="false" MinimumValue="2" MaximumValue="99999" SetFocusOnError="true" />
						</td>
						<td class="mnu_but">
							<asp:LinkButton ID="_PageSizeButton" runat="server" CausesValidation="False" ForeColor="Wheat" CommandName="PageSize" ValidationGroup="currentpage" Font-Bold="True" Font-Size="9px" Text="/Page"/>
						</td>
					</tr>
				</table>
			</td>
			<td width="18%" style="text-align:center" >
			</td>
			<td id="tdSearch" runat="server" align="right">
				<table>
					<tr>
						<td class="mnu_but">
							<asp:CheckBox ID="DisableSearch" runat="server" Enabled="false" AutoPostBack="true" ToolTip="Uncheck for normal view." />
						</td>
						<td>
							<asp:TextBox ID="SearchTextBox" runat="server" CssClass="mytxt" ToolTip="Enter keywords to search." Font-Names="vardana" ValidationGroup="searchvalidationgroup" Width="80px" Font-Size="9px" MaxLength="250" />
							<AJX:TextBoxWatermarkExtender ID="Wm1" runat="server" TargetControlID="SearchTextBox" WatermarkText="[Search]">
							</AJX:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="rfvst" runat="server" ControlToValidate="SearchTextBox" Display="none" EnableClientScript="true" ValidationGroup="searchvalidationgroup" SetFocusOnError="true" />
						</td>
						<td class="mnu_but">
							<asp:ImageButton ID="CmdSearch" runat="server" ImageUrl="~/TblImages/srh0.png" onmouseover="this.src='../../tblimages/srh2.png';" onmouseout="this.src='../../tblimages/srh0.png';" AlternateText="Search" ToolTip="Click to search" ValidationGroup="searchvalidationgroup" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</div>
