<%@ Page Title="ISGEC:Print LeaveCard" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnPrintEmployeeLC.aspx.vb" Inherits="GP_atnPrintEmployeeLC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="page" style="width: 600px">
    <div id="div2" class="caption">
      <asp:Label ID="LabelatnApproverChangeRequest" runat="server" Text="Print Leave Card Of Employee"></asp:Label>
    </div>
    <div id="div4" class="pagedata" style="min-height: 300px">
      <asp:UpdatePanel ID="UPNL1" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0 ID="ToolBar0_1" ToolType="lgNReport" EnableAdd="False" runat="server" />
          <table>
            <tr>
              <td class="alignright">
                <b>Card No :</b>
              </td>
              <td style="padding-left: 5px;">
                <script type="text/javascript">
                  function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {
                    var LC_CardNo1 = $get('<%= LC_CardNo1.ClientID %>');
                    LC_CardNo1.value = e.get_value();
                  }
                </script>
                <asp:TextBox ID="LC_CardNo1" runat="Server" AutoCompleteType="None" CssClass="mytxt" Style="display: none" Width="40px" />
                <asp:TextBox ID="LC_CardNoEmployeeName1" onfocus="return this.select();" runat="Server" AutoCompleteType="None" CssClass="mytxt" Width="200px" />
                <AJX:AutoCompleteExtender ID="LC_CardNo1_AutoCompleteExtender" runat="Server" CompletionInterval="100" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="10" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="LC_CardNo1_AutoCompleteExtender_Selected" ServiceMethod="CardNoCompletionList" TargetControlID="LC_CardNoEmployeeName1" />
              </td>
              <td>
                <asp:Button ID="cmdPrint" runat="server" Text="Print Leave Card" OnClientClick="return print_LeaveCard();" />
              </td>
            </tr>
          </table>
          <script type="text/javascript">
            var cnt = 0;
            function print_LeaveCard() {
              cnt = cnt + 1;
              var nam = 'wReport' + cnt;
              var url = self.location.href.replace('aspx', 'rptx');
              url = url + '?reportname=leavecard';
              url = url + '&emp=' + $get('<%= LC_CardNo1.ClientID %>').value;
              window.open(url, nam, 'left=20,top=20,width=650,height=500,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>
