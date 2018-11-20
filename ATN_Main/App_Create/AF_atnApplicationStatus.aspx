<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnApplicationStatus.aspx.vb" Inherits="AF_atnApplicationStatus" title="Add: Application Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "atnApplicationStatus"
      runat = "server" />
    <asp:Label ID="LabelatnApplicationStatus" runat="server" Text="Add Application Status" ></asp:Label>
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ApplStatusID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelApplStatusID" runat="server" Text="ID :" /></b>
				</td>
				<td>
					<asp:Label ID="TextApplStatusID" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelDescription" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxDescription"
						Text='<%# Bind("Description") %>'
            CssClass="mytxt"
						runat="server"
						ValidationGroup="atnApplicationStatus"
            ToolTip="Enter value for Description."
            Width="100px"
						MaxLength="20" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderDescription"
						runat = "server"
            WatermarkText="[Enter Description]"
						TargetControlID="TextBoxDescription" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorDescription"
						runat = "server"
						ControlToValidate = "TextBoxDescription"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnApplicationStatus"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnApplicationStatus"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnApplicationStatus"
  SelectMethod = "GetByID"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" Name="ApplStatusID" QueryStringField="Code" Type="Int32" />
</SelectParameters>
<InsertParameters>
  <asp:Parameter Name="ApplStatusID" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
