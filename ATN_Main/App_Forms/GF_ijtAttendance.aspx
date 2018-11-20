<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_ijtAttendance.aspx.vb" Inherits="GF_ijtAttendance" title="Maintain List: Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<style type="text/css">
	.PR 
	{
	 color:Blue;
	}
	
	.OD
	{
		color:Blue;
		font-weight:bold;
	}
	
	.CL, .SL, .PL, .AP, .ST
	{
	 color:Purple;
	 font-weight:bold;
	}
	.AD, .AF, .AS
	{
	 color:Red;
	}
	
	.WO, .HD
	{
	 color:Green;
 	 font-weight:bold;
	}
</style>
<div id="div1" class="page">
    <div id="div2" class="caption">
    <asp:Label ID="LabelijtAttendance" runat="server" Text="Maintain Site Attendance" ></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      EnableAdd = "False"
      ValidationGroup = "ijtAttendance"
      runat = "server" />
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
					<b><asp:Label ID="L_CardNo" runat="server" Text="Card No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("CardNo") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_CardNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_CardNo_Display"
						Text='<%# Eval("CardNoHRM_Employees.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECardNo_Selected"
            OnClientPopulating="ACECardNo_Populating"
            OnClientPopulated="ACECardNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DataMonth" runat="server" Text="Month :" /></b>
				</td>
        <td>
          <LGM:LC_ijtMonths
            ID="F_DataMonth"
            SelectedValue='<%# Bind("DataMonth") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="MonthID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
          </td>
			</tr>
    </table>
<asp:Label ID="dummy" runat="server" Style="display: none"></asp:Label>
<asp:Panel ID="pnl1" runat="server" BackColor="gray" Style="display: none; height: 100px; width: 400px">
	<table style="width:400">
		<tr>
			<td style="background-color:Navy; min-width:400px">
				<asp:Image ID="imgerr" runat="server" AlternateText="Message" ToolTip="Message" ImageUrl="~/App_Themes/Default/Images/Error1.gif" />
			</td>
			<td id="tdTitle" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: White">
				Attendance System
			</td>
			<td style="background-color: Navy">
				<asp:ImageButton ID="cmdClose0" runat="server" Height="18px" Width="18px" OnClientClick="return closeMP();" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
			</td>
		</tr>
	</table>
	<div id="dynamicData" runat="server" style="color:White; min-height:100px; min-width:400px;display:block" >
	<table width="100%">
		<tr>
			<td><b>Card No:</b></td>
			<td id="cardno"></td>
		</tr>
		<tr>
			<td><b>Date:</b></td>
			<td id="date"></td>
		</tr>
		<tr>
			<td><b>Status:</b></td>
			<td>
				<asp:DropDownList id="F_AttendanceStatus" runat="server"> 
					<asp:ListItem value="PR" >PR-Present</asp:ListItem> 
					<asp:ListItem value="AD" >AD-Absent</asp:ListItem>
					<asp:ListItem value="HD" >HD-Holiday</asp:ListItem>
				</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="cmdSubmit" OnClientClick="return update_attendance(this);" runat="server" style="height:20px;cursor:pointer" Text="Update" FontBold="True" ForeColor="Blue" onmouseover="this.style.color='red';" onmouseout="this.style.color='blue';" />
			</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td align="center">
			</td>
		</tr>
	</table>
	</div>
</asp:Panel>
<AJX:ModalPopupExtender ID="mPopup" TargetControlID="dummy" BackgroundCssClass="modalBackground" BehaviorID="mpe1" CancelControlID="cmdClose0" OkControlID="cmdClose0" PopupControlID="pnl1" PopupDragHandleControlID="tdTitle" runat="server">
</AJX:ModalPopupExtender>
	<script type="text/javascript">
		var ltxt;
		var but;
		function update_attendance(b) {
			b.style.display = 'none';
			but = b;
			var o = $get('<%=F_AttendanceStatus.ClientID %>');
			//if (confirm('Update Attendance Status ?')) {
			try { ltxt.innerHTML = o.value; } catch (e) { };
			PageMethods.update_attendance(ltxt.title.split('|')[1] + ',' + o.value + '|' + o.id + '|' + ltxt.id, attendance_updated, attendance_error);
			//}
			//else {
			//	b.style.display = 'block';
			//	closeMP();
			//}
			return false;
		}
		function attendance_updated(r) {
			var p = r.split('|');
			var l = p[0].split(',');
			var t = $get(p[2]);
			try { t.innerHTML = l[4]; } catch (ex) { }
			but.style.display = 'block';
			closeMP();
		}
		function attendance_error(err) {
			alert(err);
			but.style.display = 'block';
			closeMP();
		}
		function ontxt_click(o) {
			if (o.disabled)
				return false;
			var dd = $get('<%=F_AttendanceStatus.ClientID %>');
			ltxt = o;
			try {
				for (var i = 0; i < dd.length; i++) {
					if (dd.options[i].value == o.outerText) {
						dd.options[i].selected = true;
						break;
					}
				}
			} catch (e) { };
			$get('cardno').innerHTML = ltxt.title.split('|')[0];
			var y = ltxt.title.split('|')[1].split(',');
			$get('date').innerHTML = y[3].replace('D', '') + '/' + y[2] + '/' + y[1];
			showMP();
		}
		function closeMP() {
			var mPB = $find('mpe1');
			mPB.hide();
			return false;
		}
		function showMP(ev) {
			var mPB = $find('mpe1');
			mPB.show();
			return false;
		}
	</script>
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="RecordID">
      <Columns>
        <asp:TemplateField HeaderText="Card No" SortExpression="HRM_Employees3_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ToolTip='<%# EVal("CardNo") %>' Text='<%# Eval("FK_IJT_Attendance_HRM_Employees.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="01" SortExpression="D1">
          <ItemTemplate>
            <asp:Label ID="LabelD1" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled1") %>' CssClass='<%# Eval("D1") %>' Text='<%# Bind("D1") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D1"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="02" SortExpression="D2">
          <ItemTemplate>
            <asp:Label ID="LabelD2" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled2") %>' CssClass='<%# Eval("D2") %>' Text='<%# Bind("D2") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D2"%>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="03" SortExpression="D3">
          <ItemTemplate>
            <asp:Label ID="LabelD3" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled3") %>' CssClass='<%# Eval("D3") %>' Text='<%# Bind("D3") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D3"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="04" SortExpression="D4">
          <ItemTemplate>
            <asp:Label ID="LabelD4" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled4") %>' CssClass='<%# Eval("D4") %>' Text='<%# Bind("D4") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D4"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="05" SortExpression="D5">
          <ItemTemplate>
            <asp:Label ID="LabelD5" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled5") %>' CssClass='<%# Eval("D5") %>' Text='<%# Bind("D5") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D5"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="06" SortExpression="D6">
          <ItemTemplate>
            <asp:Label ID="LabelD6" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled6") %>' CssClass='<%# Eval("D6") %>' Text='<%# Bind("D6") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D6"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="07" SortExpression="D7">
          <ItemTemplate>
            <asp:Label ID="LabelD7" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled7") %>' CssClass='<%# Eval("D7") %>' Text='<%# Bind("D7") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D7"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="08" SortExpression="D8">
          <ItemTemplate>
            <asp:Label ID="LabelD8" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled8") %>' CssClass='<%# Eval("D8") %>' Text='<%# Bind("D8") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D8"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="09" SortExpression="D9">
          <ItemTemplate>
            <asp:Label ID="LabelD9" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled9") %>' CssClass='<%# Eval("D9") %>' Text='<%# Bind("D9") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D9"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="10" SortExpression="D10">
          <ItemTemplate>
            <asp:Label ID="LabelD10" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled10") %>' CssClass='<%# Eval("D10") %>' Text='<%# Bind("D10") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D10"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="11" SortExpression="D11">
          <ItemTemplate>
            <asp:Label ID="LabelD11" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled11") %>' CssClass='<%# Eval("D11") %>' Text='<%# Bind("D11") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D11"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="12" SortExpression="D12">
          <ItemTemplate>
            <asp:Label ID="LabelD12" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled12") %>' CssClass='<%# Eval("D12") %>' Text='<%# Bind("D12") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D12"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="13" SortExpression="D13">
          <ItemTemplate>
            <asp:Label ID="LabelD13" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled13") %>' CssClass='<%# Eval("D13") %>' Text='<%# Bind("D13") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D13"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="14" SortExpression="D14">
          <ItemTemplate>
            <asp:Label ID="LabelD14" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled14") %>' CssClass='<%# Eval("D14") %>' Text='<%# Bind("D14") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D14"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="15" SortExpression="D15">
          <ItemTemplate>
            <asp:Label ID="LabelD15" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled15") %>' CssClass='<%# Eval("D15") %>' Text='<%# Bind("D15") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D15"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="16" SortExpression="D16">
          <ItemTemplate>
            <asp:Label ID="LabelD16" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled16") %>' CssClass='<%# Eval("D16") %>' Text='<%# Bind("D16") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D16"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="17" SortExpression="D17">
          <ItemTemplate>
            <asp:Label ID="LabelD17" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled17") %>' CssClass='<%# Eval("D17") %>' Text='<%# Bind("D17") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D17"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="18" SortExpression="D18">
          <ItemTemplate>
            <asp:Label ID="LabelD18" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled18") %>' CssClass='<%# Eval("D18") %>' Text='<%# Bind("D18") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D18"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="19" SortExpression="D19">
          <ItemTemplate>
            <asp:Label ID="LabelD19" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled19") %>' CssClass='<%# Eval("D19") %>' Text='<%# Bind("D19") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D19"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="20" SortExpression="D20">
          <ItemTemplate>
            <asp:Label ID="LabelD20" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled20") %>' CssClass='<%# Eval("D20") %>' Text='<%# Bind("D20") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D20"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="21" SortExpression="D21">
          <ItemTemplate>
            <asp:Label ID="LabelD21" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled21") %>' CssClass='<%# Eval("D21") %>' Text='<%# Bind("D21") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D21"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="22" SortExpression="D22">
          <ItemTemplate>
            <asp:Label ID="LabelD22" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled22") %>' CssClass='<%# Eval("D22") %>' Text='<%# Bind("D22") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D22"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="23" SortExpression="D23">
          <ItemTemplate>
            <asp:Label ID="LabelD23" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled23") %>' CssClass='<%# Eval("D23") %>' Text='<%# Bind("D23") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D23"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="24" SortExpression="D24">
          <ItemTemplate>
            <asp:Label ID="LabelD24" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled24") %>' CssClass='<%# Eval("D24") %>' Text='<%# Bind("D24") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D24"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="25" SortExpression="D25">
          <ItemTemplate>
            <asp:Label ID="LabelD25" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled25") %>' CssClass='<%# Eval("D25") %>' Text='<%# Bind("D25") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D25"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="26" SortExpression="D26">
          <ItemTemplate>
            <asp:Label ID="LabelD26" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled26") %>' CssClass='<%# Eval("D26") %>' Text='<%# Bind("D26") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D26"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="27" SortExpression="D27">
          <ItemTemplate>
            <asp:Label ID="LabelD27" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled27") %>' CssClass='<%# Eval("D27") %>' Text='<%# Bind("D27") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D27"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="28" SortExpression="D28">
          <ItemTemplate>
            <asp:Label ID="LabelD28" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled28") %>' CssClass='<%# Eval("D28") %>' Text='<%# Bind("D28") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D28"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="29" SortExpression="D29">
          <ItemTemplate>
            <asp:Label ID="LabelD29" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled29") %>' CssClass='<%# Eval("D29") %>' Text='<%# Bind("D29") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D29"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="30" SortExpression="D30">
          <ItemTemplate>
            <asp:Label ID="LabelD30" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled30") %>' CssClass='<%# Eval("D30") %>' Text='<%# Bind("D30") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D30"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="31" SortExpression="D31">
          <ItemTemplate>
            <asp:Label ID="LabelD31" runat="server" onclick="ontxt_click(this);"  style="cursor:pointer"  Enabled='<%# EVal("Enabled31") %>' CssClass='<%# Eval("D31") %>' Text='<%# Bind("D31") %>' ToolTip='<%# EVal("FK_IJT_Attendance_HRM_Employees.DisplayField") & "|" & EVal("RecordID") & ",D31"%>' ></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField>
          <ItemTemplate>
						<asp:ImageButton ID="cmdForward" runat="server" Visible='<%# Eval("UnVerified") %>' AlternateText="Verify" skinid="ok" ToolTip="Click to verify the attendance status." OnClientClick="return confirm('Attendance Status till date is OK ? ');" CommandName="forward" CommandArgument='<%# EVal("CardNo") & "," & EVal("DataMonth") %>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
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
      DataObjectTypeName = "SIS.IJT.ijtAttendance"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.IJT.ijtAttendance"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_DataMonth" PropertyName="SelectedValue" Name="DataMonth" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
    <asp:AsyncPostBackTrigger ControlID="F_DataMonth" />
  </Triggers>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>
