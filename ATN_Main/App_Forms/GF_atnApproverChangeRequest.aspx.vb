Imports System.Web.Script.Serialization
Partial Class GF_atnApproverChangeRequest
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnApproverChangeRequest.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVatnApproverChangeRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVatnApproverChangeRequest.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestID As Int32 = GVatnApproverChangeRequest.DataKeys(e.CommandArgument).Values("RequestID")  
        Dim RedirectUrl As String = TBLatnApproverChangeRequest.EditUrl & "?RequestID=" & RequestID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim RequestID As Int32 = GVatnApproverChangeRequest.DataKeys(e.CommandArgument).Values("RequestID")  
        SIS.ATN.atnApproverChangeRequest.InitiateWF(RequestID)
        GVatnApproverChangeRequest.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVatnApproverChangeRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVatnApproverChangeRequest.Init
    DataClassName = "GatnApproverChangeRequest"
    SetGridView = GVatnApproverChangeRequest
  End Sub
  Protected Sub TBLatnApproverChangeRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnApproverChangeRequest.Init
    SetToolBar = TBLatnApproverChangeRequest
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
