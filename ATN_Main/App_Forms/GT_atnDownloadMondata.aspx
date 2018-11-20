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
              <asp:Button ID="Jan" runat="server" Text="Jan" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Feb" runat="server" Text="Feb" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Mar" runat="server" Text="Mar" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Apr" runat="server" Text="Apr" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="May" runat="server" Text="May" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Jun" runat="server" Text="Jun" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Jul" runat="server" Text="Jul" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Aug" runat="server" Text="Aug" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Sep" runat="server" Text="Sep" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Oct" runat="server" Text="Oct" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Nov" runat="server" Text="Nov" ClientIDMode="Static" />
            </td>
            <td>
              <asp:Button ID="Dec" runat="server" Text="Dec" ClientIDMode="Static" />
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
              <asp:Button ID="cmdEmp" runat="server" Text="Sync. Employees" />
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
