<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taBillUtility.aspx.vb" Inherits="GF_taTravelUtility" title="TA: Travel Bill Utility" %>
<asp:Content ID="CPHatnEmployeeConfiguration" ContentPlaceHolderID="cph1" runat="Server">
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelatnEmployeeConfiguration" runat="server" Text="&nbsp;TA: Travel Bill Utility"></asp:Label>
    </div>
    <div class="pagedata">
      <LGM:ToolBar0 ID="TBLatnEmployeeConfiguration" ToolType="lgNReport" runat="server" />
      <div style="vertical-align: middle; height: 200px; width: 39%; margin: 10px auto 10px auto; float: right" class="ui-widget-content ui-corner-all">
        <h3 class="ui-widget-header ui-corner-all" style="margin: 0; padding: 0.4em; text-align: center;">
          Import Travel Bill XL-File</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
            <div id="F_Upload" runat="server" style="width: 90%; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" class="file_upload">
              <table>
                <tr>
                  <td>
                    <input type="text" id="fileName" style="width: 185px" class="file_input_textbox" readonly="readonly">
                  </td>
                  <td>
                    <div class="file_input_div">
                      <input type="button" value="Search" class="file_input_button" />
                      <asp:FileUpload ID="F_FileUpload" runat="server" Width="80px" class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Upload Item Template" />
                    </div>
                  </td>
                  <td>
                    <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" OnClientClick="return this.style.display='none';true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                  </td>
                </tr>
              </table>
            </div>
            <asp:Button ID="cmdDownload" CssClass="file_upload_button" Text="Download" runat="server" ToolTip="Click to download template file." CommandName="Download" CommandArgument="" />
            <asp:Label runat="server" ID="errMsg" ForeColor="Red" Text="" />
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdFileUpload" />
            <asp:PostBackTrigger ControlID="cmdDownload" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
    </div>
  </div>
</asp:Content>
