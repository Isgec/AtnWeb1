<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnChangeAppliedLeaveType.aspx.vb" Inherits="GT_atnChangeAppliedLeaveType" title="Change Applied Leave Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
	<div id="div1" class="page">
    <div id="div2" class="caption">
				<asp:Label ID="LabelatnProcessedPunch" runat="server" Text="Change Applied Leave Type After Posting" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<LGM:ToolBar0 ID="ToolBar0_1" ToolType="lgNMGrid" EnableAdd="False" ValidationGroup="atnProcessedPunch" SearchContext="atnProcessedPunch" runat="server" />
				<table>
					<tr>
						<td class="alignright">
							<b>Card No :</b>
						</td>
						<td style="padding-left: 5px;">

							<script type="text/javascript">
								function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
									var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
									LC_CardNo1.value = e.get_value();
									__doPostBack('<%= LC_CardNo1.ClientID %>', e.get_value());
								}
							</script>

							<asp:TextBox ID="LC_CardNo1" CssClass="mytxt" Width="40px" AutoCompleteType="None" Style="display: none" runat="Server" />
							<asp:TextBox ID="LC_CardNoEmployeeName1" CssClass="mytxt" Width="200px" AutoCompleteType="None" runat="Server" />
							<AJX:AutoCompleteExtender ID="LC_CardNo1_AutoCompleteExtender" ServiceMethod="CardNoCompletionList" TargetControlID="LC_CardNoEmployeeName1" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected" CompletionSetCount="10" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" runat="Server" />
						</td>
					</tr>
				</table>
				<asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="AttenID">
					<Columns>
						<asp:TemplateField>
							<ItemTemplate>
								<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandArgument='<%# Bind("AttenID") %>' CommandName="Edit" />
							</ItemTemplate>
							<EditItemTemplate>
								<table>
									<tr>
										<td>
											<asp:ImageButton ID="cmdSave" runat="server" AlternateText="Save" ToolTip="Click to save" SkinID="save" CommandName="Update" CommandArgument='<%# Bind("AttenID") %>' />
										</td>
										<td>
											<asp:ImageButton ID="cmdCancel" runat="server" AlternateText="Cancel" ToolTip="Click to cancel" SkinID="cancel" CommandName="Cancel" CommandArgument='<%# Bind("AttenID") %>' />
										</td>
									</tr>
								</table>
							</EditItemTemplate>
							<HeaderStyle Width="40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="AttenID" SortExpression="AttenID">
							<ItemTemplate>
								<asp:Label ID="LabelAttenID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AttenID") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Date" SortExpression="AttenDate">
							<ItemTemplate>
								<asp:Label ID="LabelAttenDate" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("AttenDate") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle Width="80px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Card No" SortExpression="CardNo">
							<ItemTemplate>
								<asp:Label ID="LabelCardNo" ToolTip='<%#Eval("CardNo") %>' runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("CardNo") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle Width="40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Time1" SortExpression="Punch1Time">
							<ItemTemplate>
								<asp:Label ID="LabelPunch1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("Punch1Time") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Time2" SortExpression="Punch2Time">
							<ItemTemplate>
								<asp:Label ID="LabelPunch2Time" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("Punch2Time") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Status" SortExpression="PunchStatusID">
							<ItemTemplate>
								<asp:Label ID="LabelPunchStatusID" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("PunchStatusID") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle Width="40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Applied1" SortExpression="Applied1LeaveTypeID">
							<ItemTemplate>
								<asp:Label ID="LabelApplied1LeaveTypeID" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("Applied1LeaveTypeID") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="50px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Applied2" SortExpression="Applied2LeaveTypeID">
							<ItemTemplate>
								<asp:Label ID="LabelApplied2LeaveTypeID" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("Applied2LeaveTypeID") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="50px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Posted1" SortExpression="Posted1LeaveTypeID">
							<ItemTemplate>
								<asp:Label ID="LabelPosted1LeaveTypeID" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("Posted1LeaveTypeID") %>'></asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="F_Posted1LeaveTypeID" Width="40px" runat="server" Text='<%# Bind("Posted1LeaveTypeID") %>'></asp:TextBox>
							</EditItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="50px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Posted2" SortExpression="Posted2LeaveTypeID">
							<ItemTemplate>
								<asp:Label ID="LabelPosted2LeaveTypeID" runat="server" ForeColor='<%# Eval("ForeColor") %>'  Text='<%# Bind("Posted2LeaveTypeID") %>'></asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="F_Posted2LeaveTypeID" Width="40px" runat="server" Text='<%# Bind("Posted2LeaveTypeID") %>'></asp:TextBox>
							</EditItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="50px" />
						</asp:TemplateField>
					</Columns>
					<EmptyDataTemplate>
						<asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
					</EmptyDataTemplate>
					<RowStyle BackColor="PaleGoldenrod" />
					<PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
					<HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" />
					<AlternatingRowStyle BackColor="Bisque" />
				</asp:GridView>
				<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIS.ATN.atnNewAttendance" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAppliedList" UpdateMethod="UpdatePostedLeaveTypeID" TypeName="SIS.ATN.atnNewAttendance" SelectCountMethod="SelectAppliedCount" SortParameterName="OrderBy" EnablePaging="True">
					<SelectParameters>
						<asp:ControlParameter ControlID="LC_CardNo1" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
						<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
						<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
					</SelectParameters>
				</asp:ObjectDataSource>
			</ContentTemplate>
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
				<asp:AsyncPostBackTrigger ControlID="LC_CardNo1" />
			</Triggers>
		</asp:UpdatePanel>
    </div>
	</div>
</asp:Content>
