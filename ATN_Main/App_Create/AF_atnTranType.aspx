<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnTranType.aspx.vb" Inherits="AF_atnTranType" title="Add: Transaction Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
    <asp:Label ID="LabelatnTranType" runat="server" Text="Add Transaction Type" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "atnTranType"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "TranType"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="LabelTranType" runat="server" Text="Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="TextBoxTranType"
						Text='<%# Bind("TranType") %>'
            CssClass="mytxt"
						runat="server"
            onblur= "validate_TranType(this);"
						ValidationGroup="atnTranType"
            ToolTip="Enter value for Type."
            Width="60px"
						MaxLength="3" />
					<AJX:TextBoxWatermarkExtender 
						ID = "TextBoxWatermarkExtenderTranType"
						runat = "server"
            WatermarkText="[Enter Type]"
						TargetControlID="TextBoxTranType" />
					<asp:RequiredFieldValidator 
						ID = "RequiredFieldValidatorTranType"
						runat = "server"
						ControlToValidate = "TextBoxTranType"
						Text = "Type is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnTranType"
						SetFocusOnError="true" />
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
						ValidationGroup="atnTranType"
            ToolTip="Enter value for Description."
            Width="100px"
						MaxLength="30" />
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
						ValidationGroup = "atnTranType"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
    </div>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnTranType"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnTranType"
  SelectMethod = "GetByID"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" Name="TranType" QueryStringField="Code" Type="String" />
</SelectParameters>
<InsertParameters>
  <asp:Parameter Name="TranType" Type="String" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
