<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_wpPayrollReports.aspx.vb" Inherits="GF_wpPayrollReports" title="Reports: WebPay PayRoll" %>
<asp:Content ID="CPHatnEmployeeConfiguration" ContentPlaceHolderID="cph1" runat="Server">
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelatnEmployeeConfiguration" runat="server" Text="&nbsp;Reports: WebPay Payroll"></asp:Label>
    </div>
    <div class="pagedata">
      <table style="width:100%">
        <tr>
          <td class="sis_formview">
            <LGM:ToolBar0 ID="TBLatnEmployeeConfiguration" ToolType="lgNReport" runat="server" />
            <table>
              <tr>
                <td><b>1.</b></td>
                <td><b>
                  PF </b>
                </td>
                <td>
                  <asp:DropDownList ID="F_Month" runat="server" ClientIDMode="Static">
                    <asp:ListItem Text="Jan" Value="1" />
                    <asp:ListItem Text="Feb" Value="2" />
                    <asp:ListItem Text="Mar" Value="3" />
                    <asp:ListItem Text="Apr" Value="4" />
                    <asp:ListItem Text="May" Value="5" />
                    <asp:ListItem Text="Jun" Value="6" />
                    <asp:ListItem Text="Jul" Value="7" />
                    <asp:ListItem Text="Aug" Value="8" />
                    <asp:ListItem Text="Sep" Value="9" />
                    <asp:ListItem Text="Oct" Value="10" />
                    <asp:ListItem Text="Nov" Value="11" />
                    <asp:ListItem Text="Dec" Value="12" />
                  </asp:DropDownList>
                </td>
                <td>
                  <asp:DropDownList ID="F_Year" runat="server" ClientIDMode="Static">
                    <asp:ListItem Text="2019" Value="2019" Selected="True" />
                    <asp:ListItem Text="2018" Value="2018"  />
                    <asp:ListItem Text="2017" Value="2017"  />
                  </asp:DropDownList>
                </td>
                <td>
                  <asp:Button ID="cmdPFLoanReport" runat="server" Text="PF Loan Report" />
                </td>
                <td>
                  <asp:Button ID="cmdPFStatement" runat="server" Text="PF Statement" />
                </td>
                <td>
                  <asp:Button ID="Button1" Text="Update PF Value" runat="server" CssClass="mytxt" OnClick="cmdUpdatePF" OnClientClick="return confirm('Do you want to Process ?');" />
                </td>
                <td>
                  <asp:TextBox ID="F_CardNo" runat="server" ClientIDMode="Static" CssClass="mytxt" Width="60px" MaxLength="8"></asp:TextBox>
                </td>
                <td>
                  <asp:CheckBox ID="F_Backup" runat="server" ClientIDMode="Static" CssClass="mychk" Text="Re-Backup" />
                </td>
              </tr>
              <tr>
                <td><b>2.</b>
                </td>
                <td><b>
                Employee Detail</b>
                </td>
                <td colspan="6">
                <asp:Button ID="cmdEmpList" runat="server" Text="Print Employee Details" />
                </td>
              </tr>
              <tr>
                <td><b>3.</b>
                </td>
                <td><b>
                Loan Detail</b>
                </td>
                <td colspan="6">
                <asp:Button ID="cmdLoanReport" runat="server" Text="Print Loan Details" />
                </td>
              </tr>
            </table>
            <br />
          </td>
        </tr>
      </table>


    </div>
  </div>
</asp:Content>
