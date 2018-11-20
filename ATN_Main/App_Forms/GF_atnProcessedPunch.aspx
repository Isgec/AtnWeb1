<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnProcessedPunch.aspx.vb" Inherits="GF_atnProcessedPunch" title="Maintain List: Processed Punch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
	<div id="div1" class="page">
    <div id="div2" class="caption">
				<asp:Label ID="LabelatnProcessedPunch" runat="server" Text="List Processed Punch" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<LGM:ToolBar0 ID="ToolBar0_1" ToolType="lgNMGrid" EnableAdd="False" ValidationGroup="atnProcessedPunch" SearchContext="atnProcessedPunch" runat="server" />
				<hr />
				<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
					<ProgressTemplate>
						<span style="color: #ff0033">Loading...</span>
					</ProgressTemplate>
				</asp:UpdateProgress>
				<hr />
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
				<asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="AttenID">
					<Columns>
						<asp:TemplateField>
							<ItemTemplate>
								<table>
									<tr>
										<td>
											<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." Visible='<%# EVal("Enabled") %>' SkinID="Edit" CommandArgument='<%# Bind("AttenID") %>' OnClick="Edit_Click" />
										</td>
<%--
										<td>
											<asp:ImageButton ID="cmdProcessed" runat="server" AlternateText="Processed" ToolTip="Rectify Interweaving Holidays after Processing." ImageUrl="~/App_Themes/Default/Images/Processed.png" CommandArgument='<%# Bind("AttenID") %>' OnClick="cmdProcessed_Click" />
										</td>
--%>
									</tr>
								</table>
							</ItemTemplate>
							<HeaderStyle Width="80px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="ID" SortExpression="AttenID">
							<ItemTemplate>
								<asp:Label ID="LabelAttenID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AttenID") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Date" SortExpression="AttenDate">
							<ItemTemplate>
								<asp:Label ID="LabelAttenDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AttenDate") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle Width="80px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees1_EmployeeName">
							<ItemTemplate>
								<asp:Label ID="LabelCardNo" ToolTip='<%#Eval("CardNo") %>' runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
								<asp:Label ID="TextCardNoHidden" Style="display: none" runat="server" Text='<%# Bind("CardNo") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle Width="100px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Punch Time [1]" SortExpression="Punch1Time">
							<ItemTemplate>
								<asp:Label ID="LabelPunch1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Punch1Time") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="80px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Punch Time [2]" SortExpression="Punch2Time">
							<ItemTemplate>
								<asp:Label ID="LabelPunch2Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Punch2Time") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="80px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Punch Status" SortExpression="ATN_PunchStatus2_Description">
							<ItemTemplate>
								<asp:Label ID="LabelPunchStatusID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("PunchStatusIDATN_PunchStatus.Description") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle Width="100px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Punch Value" SortExpression="PunchValue">
							<ItemTemplate>
								<asp:Label ID="LabelPunchValue" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PunchValue") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="80px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Final Value" SortExpression="FinalValue">
							<ItemTemplate>
								<asp:Label ID="LabelFinalValue" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FinalValue") %>'></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="alignright" />
							<ItemStyle CssClass="alignright" />
							<HeaderStyle Width="80px" />
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
				<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIS.ATN.atnProcessedPunch" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectList" TypeName="SIS.ATN.atnProcessedPunch" SelectCountMethod="SelectCount" SortParameterName="OrderBy" EnablePaging="True">
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
