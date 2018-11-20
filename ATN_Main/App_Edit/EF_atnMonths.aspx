<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_atnMonths.aspx.vb" Inherits="EF_atnMonths" title="Edit: Months" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
<ContentTemplate>
    <asp:Label ID="LabelatnMonths" runat="server" Text="Edit Months" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "atnMonths"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "MonthID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonthID" ForeColor="#CC6633" runat="server" Text="Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MonthID"
						Text='<%# Bind("MonthID") %>'
            Width="21px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ShortName" runat="server" Text="Short Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ShortName"
						Text='<%# Bind("ShortName") %>'
            Width="21px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="atnMonths"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Short Name."
						MaxLength="3"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVShortName"
						runat = "server"
						ControlToValidate = "F_ShortName"
						Text = "Short Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnMonths"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="atnMonths"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnMonths"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnMonths"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnMonths"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MonthID" Name="MonthID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
