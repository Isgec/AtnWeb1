<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnWaveoffTS.aspx.vb" Inherits="GD_atnWaveoffTS" title="Display List: Waveoff Time Short" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnWaveoffTS"
      SearchContext = "atnWaveoffTS"
      runat = "server" />
    <hr />
    <asp:Label ID="LabelatnWaveoffTS" runat="server" Text="List Waveoff Time Short" ></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table width="100%">
			<tr>
				<td style="text-align: right;width:80%">
					<b><asp:Label ID="LabelatnAttendanceStatus" runat="server" Text="Waveoff all TS for :" ></asp:Label></b>
				</td>
				<td style="text-align: right">
					<asp:DropDownList ID="F_Mon" runat="server">
						<asp:ListItem Value="1" Text="Jan"></asp:ListItem>
						<asp:ListItem Value="2" Text="Feb"></asp:ListItem>
						<asp:ListItem Value="3" Text="Mar"></asp:ListItem>
						<asp:ListItem Value="4" Text="Apr"></asp:ListItem>
						<asp:ListItem Value="5" Text="May"></asp:ListItem>
						<asp:ListItem Value="6" Text="Jun"></asp:ListItem>
						<asp:ListItem Value="7" Text="Jul"></asp:ListItem>
						<asp:ListItem Value="8" Text="Aug"></asp:ListItem>
						<asp:ListItem Value="9" Text="Sep"></asp:ListItem>
						<asp:ListItem Value="10" Text="Oct"></asp:ListItem>
						<asp:ListItem Value="11" Text="Nov"></asp:ListItem>
						<asp:ListItem Value="12" Text="Dec"></asp:ListItem>
					</asp:DropDownList>
					<asp:Button ID="cmdWaveOffMonth" runat="server" Text="Waveoff" OnClientClick="return confirm('Waveoff all TS ?');" />
				</td>
			</tr>
    </table>
    <table>
      <tr>
        <td class="alignright" ><b>Employee :</b></td>
        <td style="Padding-left: 5px;">
					<script type="text/javascript">
						function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
							var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
							LC_CardNo1.value = e.get_value();
							__doPostBack('<%= LC_CardNo1.ClientID %>', e.get_value());
						}
					</script>
					<asp:TextBox
						ID = "LC_CardNo1"
						CssClass = "mytxt"
						Width = "40px"
						AutoCompleteType = "None"
						Style="display:none"
						Runat="Server" />
					<asp:TextBox
						ID = "LC_CardNoEmployeeName1"
						CssClass = "mytxt"
						Width = "200px"
						AutoCompleteType = "None"
						onfocus = "return this.select();"
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="LC_CardNo1_AutoCompleteExtender"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="LC_CardNoEmployeeName1"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="AttenID">
      <Columns>
        <asp:TemplateField HeaderText="WaveOff">
          <ItemTemplate>
            <asp:ImageButton ID="cmdWaveoff" runat="server" Visible='<%# Eval("Visible") %>' AlternateText="Waveoff" ToolTip="Click to waveoff Posted Leave." ImageUrl="~/App_Themes/Default/Images/Ok.png" CommandArgument='<%# Bind("AttenID") %>' CommandName="WaveOff"  OnClientClick="return confirm('Are you sure to waveoff Leave ?');" />
          </ItemTemplate>
          <HeaderStyle Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="AttenID">
          <ItemTemplate>
            <asp:Label ID="LabelAttenID" runat="server" Text='<%# Bind("AttenID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="AttenDate">
          <ItemTemplate>
            <asp:Label ID="LabelAttenDate" runat="server" Text='<%# Bind("AttenDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelCardNo" runat="server" Text='<%# Eval("CardNoHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch [1]" SortExpression="Punch1Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch1Time" runat="server" Text='<%# Bind("Punch1Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch [2]" SortExpression="Punch2Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch2Time" runat="server" Text='<%# Bind("Punch2Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Punch Status" SortExpression="PunchStatusID">
          <ItemTemplate>
            <asp:Label ID="LabelPunchStatusID" runat="server" Text='<%# Bind("PunchStatusID") %>'></asp:Label>
          </ItemTemplate>
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
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnWaveoffTS"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnWaveoffTS"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
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
</asp:Content>
