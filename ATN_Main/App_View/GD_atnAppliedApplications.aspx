<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnAppliedApplications.aspx.vb" Inherits="GD_atnAppliedApplications" title="Display List: Applied Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <script type="text/javascript" src="../../App_Scripts/ShowApplicationDays.js"></script>
    <LGM:LGMessage 
			ID="LGMessage1" 
		  Width = "600"
			runat="server" />
	<div id="div2" class="page">
    <div id="div3" class="caption">
			<asp:Label ID="Label1" runat="server"  Text="&nbsp;List Applied Applications"></asp:Label>
    </div>
    <div id="div4" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnAppliedApplications"
      SearchContext = "atnAppliedApplications"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="LeaveApplID">
      <Columns>
        <asp:TemplateField HeaderText="Detail">
          <ItemTemplate>
						<input type="image" id='<%#Eval("LeaveApplID","cmdInfo{0}") %>' alt='<%# Eval("LeaveApplID") %>' title="Detailed Information." src="../../App_Themes/Default/Images/Info.png" onclick="showDetails(this);return false;" />
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TO RE-APPLY DELETE">
          <ItemTemplate>
						<asp:ImageButton ID="cmdDelete" Enabled='<%# Eval("EnableDelete") %>' runat="server" AlternateText='<%# Bind("LeaveApplID") %>' ToolTip="Delete Rejected Application to RE-APPLY." ImageUrl='<%#Eval("DelImageUrl") %>' CommandArgument='<%# Bind("LeaveApplID") %>' CommandName="Delete" OnClientClick="return confirm('Delete rejected application ?');" />
          </ItemTemplate>
          <HeaderStyle Width="80px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="LeaveApplID">
          <ItemTemplate>
            <asp:Label ID="LabelLeaveApplID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("LeaveApplID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Applied On" SortExpression="AppliedOn">
          <ItemTemplate>
            <asp:Label ID="LabelAppliedOn" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("AppliedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Application Status" SortExpression="ATN_ApplicationStatus1_Description">
          <ItemTemplate>
             <asp:Label ID="LabelApplStatusID"  ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("ApplStatusIDATN_ApplicationStatus.Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comments" >
          <ItemTemplate>
            <asp:Label ID="LabelVerificationRemark" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("StatusDetails") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="250px" />
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
      DataObjectTypeName = "SIS.ATN.atnAppliedApplications"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      DeleteMethod = "UZ_Delete"
      TypeName = "SIS.ATN.atnAppliedApplications"
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
