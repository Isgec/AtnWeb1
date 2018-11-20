<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_atnMonths.aspx.vb" Inherits="AF_atnMonths" title="Add: Months" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNL1" runat="server" >
  <ContentTemplate>
    <asp:Label ID="LabelatnMonths" runat="server" Text="Add Months" ></asp:Label>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "atnMonths"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "MonthID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonthID" ForeColor="#CC6633" runat="server" Text="Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MonthID"
						Text='<%# Bind("MonthID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="atnMonths"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Type."
						MaxLength="3"
            Width="21px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVMonthID"
						runat = "server"
						ControlToValidate = "F_MonthID"
						Text = "Type is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "atnMonths"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ShortName" runat="server" Text="Short Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ShortName"
						Text='<%# Bind("ShortName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="atnMonths"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Short Name."
						MaxLength="3"
            Width="21px"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="atnMonths"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
            Width="210px"
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
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ATN.atnMonths"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ATN.atnMonths"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
