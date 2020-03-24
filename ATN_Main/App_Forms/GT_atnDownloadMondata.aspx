<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_atnDownloadMondata.aspx.vb" Inherits="GT_atnDownloadMondata" Title="ISGEC:Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelatnAppliedApplications" runat="server" Font-Bold="True" Font-Size="14px" Text="Downloads Salary Data for WebPay"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <LGM:ToolBar0 ID="ToolBar0_1" ToolType="lgNReport" EnableAdd="False" runat="server" />
      <div id="frmdiv" class="ui-widget-content minipage">
        <table style="margin: auto">
          <tr>
            <td>
              <asp:Button ID="Jan" runat="server" Text="Jan" ClientIDMode="Static" CommandArgument="1" />
            </td>
            <td>
              <asp:Button ID="Feb" runat="server" Text="Feb" ClientIDMode="Static" CommandArgument="2" />
            </td>
            <td>
              <asp:Button ID="Mar" runat="server" Text="Mar" ClientIDMode="Static" CommandArgument="3" />
            </td>
            <td>
              <asp:Button ID="Apr" runat="server" Text="Apr" ClientIDMode="Static" CommandArgument="4" />
            </td>
            <td>
              <asp:Button ID="May" runat="server" Text="May" ClientIDMode="Static" CommandArgument="5" />
            </td>
            <td>
              <asp:Button ID="Jun" runat="server" Text="Jun" ClientIDMode="Static" CommandArgument="6" />
            </td>
            <td>
              <asp:Button ID="Jul" runat="server" Text="Jul" ClientIDMode="Static" CommandArgument="7" />
            </td>
            <td>
              <asp:Button ID="Aug" runat="server" Text="Aug" ClientIDMode="Static" CommandArgument="8" />
            </td>
            <td>
              <asp:Button ID="Sep" runat="server" Text="Sep" ClientIDMode="Static" CommandArgument="9" />
            </td>
            <td>
              <asp:Button ID="Oct" runat="server" Text="Oct" ClientIDMode="Static" CommandArgument="10" />
            </td>
            <td>
              <asp:Button ID="Nov" runat="server" Text="Nov" ClientIDMode="Static" CommandArgument="11" />
            </td>
            <td>
              <asp:Button ID="Dec" runat="server" Text="Dec" ClientIDMode="Static" CommandArgument="12" />
            </td>
          </tr>
        </table>
      </div>
       <div  class="ui-widget-content minipage">
        <table style="margin: auto">
          <tr>
            <td>
              <asp:Label ID="Label5" runat="server" Text="View Absents: " />
            </td>
            <td>
		          <script type="text/javascript">
			          var cnt = 0;
			          function print_abs() {
				          cnt = cnt + 1;
				          var nam = 'wReport' + cnt;
				          var url = self.location.href.replace('App_Forms/GT_atnDownloadMondata.aspx', 'App_Print/Print_abs.aspx');
				          url = url + '?y=1';
				          url = url + '&mon=' + $get('F_absMonth').value;
				          window.open(url, nam, 'left=20,top=20,width=650,height=500,toolbar=1,resizable=1,scrollbars=1');
				          return false;
			          }
		          </script>		

              <asp:DropDownList
                id="F_absMonth"
                ClientIDMode="Static"
                runat="server">
                <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
              </asp:DropDownList>
            </td>
            <td>
              <asp:Button ID="cmdAbsReport" runat="server" Text="Absent on Sat/Sun" OnClientClick="return print_abs();" />
            </td>
          </tr>
        </table>
      </div>
       <div id="Div5" class="ui-widget-content minipage">
        <table style="margin: auto">
          <tr>
            <td>
              <asp:Label ID="Label2" runat="server" Text="Sync. Employee Master from WebPay: " />
            </td>
            <td>
              <asp:Button ID="cmdEmp" runat="server" Enabled="false" Text="Sync. Employees" />
            </td>
          </tr>
        </table>
      </div>
     <div id="Div4" class="ui-widget-content minipage">
        <table style="margin: auto">
          <tr>
            <td>
              <asp:Label runat="server" ID="label1" text="Step 1." ForeColor="Green" Font-Bold="true" />
            </td>
            <td colspan="3">
              <asp:Button ID="cmdAtnd" runat="server" Text="Download Attendance Template" />
            </td>
            </tr>
            <tr>
            <td>
              <asp:Label runat="server" ID="label4" text="Step 2." ForeColor="Green" Font-Bold="true" />
            </td>
            <td>
              <asp:Label runat="server" ID="label3" text="Upload Updated Excel: " ForeColor="Green" Font-Bold="true" />
            </td>
            <td>
              <asp:FileUpload ID="atndUpload" runat="server" ClientIDMode="Static"  />
            </td>
            <td>
              <asp:Button ID="cmdUpload" runat="server" Text="Upload" />
            </td>
          </tr>
        </table>
      </div>
    </div>
  </div>
</asp:Content>
