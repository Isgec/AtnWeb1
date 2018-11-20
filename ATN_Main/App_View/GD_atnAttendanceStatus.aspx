<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnAttendanceStatus.aspx.vb" Inherits="GD_atnAttendanceStatus" title="Display List: Attendance Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaacBills" runat="server" Text="&nbsp;List: Attendance Status"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnAttendanceStatus"
      SearchContext = "atnAttendanceStatus"
      runat = "server" />
		<script type="text/javascript">
			var cnt = 0;
			function print_atndReport() {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=attendancesheet';
				url = url + '&mon=' + $get('<%= F_Mon.ClientID %>').value;
				url = url + '&emp=' + '<%= Session("LoginID") %>';
				window.open(url, nam, 'left=20,top=20,width=650,height=500,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>		
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
    <table width="100%">
			<tr>
				<td align="left">
					<asp:Label ID="LabelatnAttendanceStatus" runat="server" Text="Print Attendance Status" ></asp:Label>
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
					<asp:Button ID="cmdAtnd" runat="server" Text="Print" OnClientClick="return print_atndReport();" />
				</td>
			</tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView runat="server" SkinId="gv_silver" ID="GridView1" DataSourceID="ObjectDataSource1" DataKeyNames="AttenID">
      <Columns>
        <asp:TemplateField HeaderText="Date" SortExpression="AttenDate">
          <ItemTemplate>
            <asp:Label ID="LabelAttenDate" ForeColor='<%#Eval("ForeColor") %>' runat="server" Text='<%# Bind("AttenDate") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="80px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />

        </asp:TemplateField>
    
				<asp:TemplateField HeaderText="First Punch" SortExpression="Punch1Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch1Time" ForeColor='<%#Eval("LateColor") %>' runat="server" Text='<%# Bind("Punch1Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="80px" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Last Punch" SortExpression="Punch2Time">
          <ItemTemplate>
            <asp:Label ID="LabelPunch2Time" ForeColor='<%#Eval("ForeColor") %>' runat="server" Text='<%# Bind("Punch2Time") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="80px" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        
				<asp:TemplateField HeaderText="Status" SortExpression="ATN_PunchStatus1_Description">
          <ItemTemplate>
             <asp:Label ID="LabelPunchStatusID" ForeColor='<%#Eval("ForeColor") %>' runat="server" Text='<%# Eval("PunchStatusIDATN_PunchStatus.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ist Half" SortExpression="ATN_LeaveTypes2_Description">
          <ItemTemplate>
             <asp:Label ID="LabelApplied1LeaveTypeID" ForeColor='<%#Eval("ForeColor") %>' runat="server" Text='<%# Eval("Applied1LeaveTypeIDATN_LeaveTypes.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="100px" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IInd Half" SortExpression="ATN_LeaveTypes3_Description">
          <ItemTemplate>
             <asp:Label ID="LabelApplied2LeaveTypeID" ForeColor='<%#Eval("ForeColor") %>' runat="server" Text='<%# Eval("Applied2LeaveTypeIDATN_LeaveTypes.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="100px" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Application" SortExpression="ATN_ApplicationStatus4_Description">
          <ItemTemplate>
             <asp:Label ID="LabelApplStatusID" ForeColor='<%#Eval("ForeColor") %>' runat="server" Text='<%# Eval("ApplStatusIDATN_ApplicationStatus.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ATN.atnAttendanceStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnAttendanceStatus"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
