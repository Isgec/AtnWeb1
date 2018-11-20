<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnAlertToVerifier.aspx.vb" Inherits="GD_atnAlertToVerifier" title="Display List: Alerts to Verifier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <asp:Label ID="dummy" runat="server"></asp:Label>
		<asp:Panel ID="pnlContainer" runat="server" style="background-color:Black; display:none; width: 600px; color:White; position:absolute; z-index: 108" >
			<asp:Panel ID="pnlHandle" runat="server" Style="background-color:Navy; height: 20px; width: 100%; color: White; font-weight:bold; cursor:move">
			  <table style="width: 100%">
					<tr>
						<td style="text-align:left; padding-left: 2px">
							<asp:Label ID="lblTitle" runat="server" Text="Application Details"></asp:Label>
						</td>
						<td style="text-align: right; padding-right: 2px">
						  <input type="image" alt="Close" src="../../App_Themes/Default/Images/closewindow.png" onclick="closeWindow(); return false;" style="height: 18px; width: 18px; cursor: pointer" />
						</td>
					</tr>
			  </table>
			</asp:Panel>
			<asp:Panel ID="pnlDetails" runat="server" style="max-height: 400px" ScrollBars="Auto" ></asp:Panel>
		</asp:Panel>
		<AJX:DynamicPopulateExtender 
			ID="DPEpnlDetails" 
		  BehaviorID="dp1"
			runat="server" 
			PopulateTriggerControlID="dummy" 
			ClearContentsDuringUpdate="true"
			ServicePath="~/App_Services/_atnWebServices.asmx"
			ServiceMethod="PendingApplicationsUnderVerification" 
			TargetControlID="pnlDetails">
			</AJX:DynamicPopulateExtender>
		<AJX:DragPanelExtender ID="DragPE" runat="server" DragHandleID="pnlHandle" TargetControlID="pnlContainer"></AJX:DragPanelExtender>
	<div id="div2" class="page">
    <div id="div3" class="caption">
			<asp:Label ID="LabelatnAppliedApplications" runat="server"  Text="&nbsp;Send E-Mail Alert to Verifier"></asp:Label>
    </div>
    <div id="div4" class="pagedata">

<asp:UpdatePanel ID="UpdatePanel1"  UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNDGrid"
      EnableAdd = "False"
      ValidationGroup = "atnAlertToVerifier"
      SearchContext = "atnAlertToVerifier"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
    	function showBody(o) {
    		var p = $get(o.id.replace('cmd', 'msg'));
    		if (p.style.display == 'block')
    			p.style.display = 'none';
    		else {
    			p.style.display = 'block';
    			DragHandler.attach(p);
    		}
    	}
    	function closeBody(o) {
    		$get(o.id.replace('cmdok', 'msg')).style.display='none';
    	}
    	function sendMail(o) {
    		o.src = '../../App_Themes/Default/Images/loadingleavecard.gif';
    		var p = $get(o.id.replace('cmdsend', 'msgbody'));
    		var context = o.id.replace('cmdsend', '') + '±' + $get(o.id.replace('cmdsend', 'email')).value + '±' +  p.value;
    		PageMethods.SendMail(context, mailsent);
    	}
    	function mailsent(result) {
    		var o = $get('cmdsend' + result);
    		o.src = '../../App_Themes/Default/Images/Mail-send.png';
    	}
    	var DragHandler = {
    		_oElem: null,
    		attach: function(oElem) {
    			oElem.onmousedown = DragHandler._dragBegin;
    			oElem.dragBegin = new Function();
    			oElem.drag = new Function();
    			oElem.dragEnd = new Function();
    			return oElem;
    		},
    		_dragBegin: function(e) {
    			var oElem = DragHandler._oElem = this;
    			var eXY = DragHandler._findPos(oElem);
    			if (isNaN(parseInt(oElem.style.left))) { oElem.style.left = eXY.x + 'px'; }
    			if (isNaN(parseInt(oElem.style.top))) { oElem.style.top = eXY.y + 'px'; }
    			var x = parseInt(oElem.style.left);
    			var y = parseInt(oElem.style.top);
    			e = e ? e : window.event;
    			oElem.mouseX = e.clientX;
    			oElem.mouseY = e.clientY;
    			oElem.dragBegin(oElem, x, y);
    			document.onmousemove = DragHandler._drag;
    			document.onmouseup = DragHandler._dragEnd;
    			return false;
    		},
    		_drag: function(e) {
    			var oElem = DragHandler._oElem;
    			var x = parseInt(oElem.style.left);
    			var y = parseInt(oElem.style.top);
    			e = e ? e : window.event;
    			oElem.style.left = x + (e.clientX - oElem.mouseX) + 'px';
    			oElem.style.top = y + (e.clientY - oElem.mouseY) + 'px';
    			oElem.mouseX = e.clientX;
    			oElem.mouseY = e.clientY;
    			oElem.drag(oElem, x, y);
    			return false;
    		},
    		_dragEnd: function() {
    			var oElem = DragHandler._oElem;
    			var x = parseInt(oElem.style.left);
    			var y = parseInt(oElem.style.top);
    			oElem.dragEnd(oElem, x, y);
    			document.onmousemove = null;
    			document.onmouseup = null;
    			DragHandler._oElem = null;
    		},
    		_findPos: function(e) {
    			var left = 0;
    			var top = 0;
    			while (e.offsetParent) {
    				left += e.offsetLeft;
    				top += e.offsetTop;
    				e = e.offsetParent;
    			}
    			left += e.offsetLeft;
    			top += e.offsetTop;
    			return { x: left, y: top };
    		}
    	};
    </script>
		<script  type="text/javascript">
    		function setContext(o,a,b) {
    			var behavior = $find('dp1');
    			if (behavior) {
    				$get('<%=lblTitle.ClientID %>').innerHTML = 'Application Details: ' + b;
    			  var p = $get('<%=pnlContainer.ClientID %>');
    			  p.style.display = 'block';
    			  var pos = DragHandler._findPos(o);
    			  p.style.left = pos.x;
    			  p.style.top = pos.y;
    				behavior.populate(o.alt);
    			}
    		}
    		function closeWindow() {
    			$get('<%=pnlContainer.ClientID %>').style.display = 'none';
    			return false;
    		}
    	
    </script>
    <asp:GridView runat="server"  SkinId="gv_silver" ID="GridView1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="LeaveApplID">
      <Columns>
        <asp:TemplateField HeaderText="Details">
          <ItemTemplate>
            <asp:ImageButton ID="cmdShowDetails" runat="server" OnClientClick='<%# String.Format("setContext(this,""{0}"",""{1}"");return false;",Eval("VerifiedBy"),Eval("VerifiedByHRM_Employees.EmployeeName")) %>'    AlternateText='<%#Eval("VerifiedBy") %>' ImageUrl="~/App_Themes/Default/Images/Flag-Green.png" />
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send Link E-Mail">
          <ItemTemplate>
            <asp:ImageButton runat="server" ID="cmdLinkSend" AlternateText="sendLink" ToolTip="Click to send Link E-Mail." ImageUrl="~/App_Themes/Default/Images/Mail-send.png" CommandName="sendLinkEMail" CommandArgument='<%# EVal("VerifiedBy") %>' />
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pending" >
          <ItemTemplate>
            <asp:Label ID="LabelApplStatusID" runat="server" Text='<%# Bind("ApplicationCount") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verifier" >
          <ItemTemplate>
             <asp:Label ID="LabelVerifiedBy" runat="server" Text='<%# Eval("VerifiedByHRM_Employees.EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="250px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="E-Mail" >
          <ItemTemplate>
            <asp:Label ID="LabelEMailID" runat="server" Text='<%# Bind("EMailID") %>'></asp:Label>
            <input type="hidden" id='<%# "email" & Eval("VerifiedBy") %>' value='<%# EVal("EMailID") %>' />
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edit E-Mail">
          <ItemTemplate>
            <input type="image" id='<%# "cmd" & Eval("VerifiedBy") %>' alt='Show Message' onclick="showBody(this); return false;" src="../../App_Themes/Default/Images/Info.png" title="Detailed Information." />
            <div id='<%# "msg" & Eval("VerifiedBy") %>' style="display:none; z-index: 105; position:absolute; background-color: Navy">
							<div style="height:18px; width:448px; background-color: Navy; cursor:move; border: solid 2pt black; color: White">
								<b><table width="100%"><tr><td align="left"><%#"E-Mail Message: [" & Eval("VerifiedByHRM_Employees.EmployeeName") & "]"%></td>
									<td align="right"><input type="image" id='<%# "cmdok" & Eval("VerifiedBy") %>' alt="close" onclick="closeBody(this); return false;" style="height:16px; width: 16px; cursor:default" src="../../App_Themes/Default/Images/closeWindow.png" title="Close" /></td></tr></table> </b>
							</div>
							<textarea id='<%# "msgbody" & Eval("VerifiedBy") %>' class="mytxt" rows="15" cols="60" style="height:300px; width:450px"><%# Eval("MessageBody") %></textarea>
            </div>
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send E-Mail">
          <ItemTemplate>
            <input type="image" id='<%# "cmdsend" & Eval("VerifiedBy") %>' alt='Show Message' visible='<%#Eval("Visible") %>' onclick="sendMail(this); return false;" src="../../App_Themes/Default/Images/Mail-send.png" title="Click to send e-Mail." />
          </ItemTemplate>
          <HeaderStyle Width="60px" CssClass="alignCenter" />
          <ItemStyle CssClass="alignCenter" />
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
      DataObjectTypeName = "SIS.ATN.atnAlertToVerifier"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "AlertSelectList"
      TypeName = "SIS.ATN.atnAlertToVerifier"
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
