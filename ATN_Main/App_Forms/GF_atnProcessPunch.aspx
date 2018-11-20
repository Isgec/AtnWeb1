<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_atnProcessPunch.aspx.vb" Inherits="GF_atnProcessPunch" title="Maintain List: Process Punch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
			<asp:Label ID="LabelatnProcessPunch" runat="server" Text="List Process Punch" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      EnableAdd = "false"
      ValidationGroup = "atnProcessPunch"
      SearchContext = "atnProcessPunch"
      runat = "server" />
    <hr />
    <table width="100%">
    <tr>
    <td>
    </td>
    <td align="center" class="ok_button">
			<asp:ImageButton 
				ID="cmdInsert" 
				runat="server" 
				ImageUrl="~/App_Themes/Default/Images/import.png" 
				ToolTip="Click to add next process date." />
    </td>
    </tr>
    </table>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <asp:table id="tblerr" runat="server">
    </asp:table>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="RecordID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:ImageButton ID="cmdProcess" runat="server" AlternateText="Process" ToolTip="Process Card Punch." SkinID="update" CommandArgument='<%# Bind("RecordID") %>' OnClick="cmdProcess_Click" />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RecordID" SortExpression="RecordID">
          <ItemTemplate>
            <asp:Label ID="LabelRecordID" ForeColor='<%#Eval("ForeColor") %>' runat="server" Text='<%# Bind("RecordID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ProcessDate" SortExpression="ProcessDate">
          <ItemTemplate>
            <asp:Label ID="LabelProcessDate" ForeColor='<%#Eval("ForeColor") %>'  runat="server" Text='<%# Bind("ProcessDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Processed" SortExpression="Processed">
          <ItemTemplate>
            <asp:Label ID="LabelProcessed" ForeColor='<%#Eval("ForeColor") %>'  runat="server" Text='<%# Bind("Processed") %>'></asp:Label>
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
      DataObjectTypeName = "SIS.ATN.atnProcessPunch"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ATN.atnProcessPunch"
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
    <asp:AsyncPostBackTrigger ControlID="CmdInsert" EventName="Click" />
  </Triggers>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>
