Partial Class GF_idmProjects
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_idmProjects.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVidmProjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVidmProjects.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVidmProjects.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RedirectUrl As String = TBLidmProjects.EditUrl & "?ProjectID=" & ProjectID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVidmProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVidmProjects.Init
    DataClassName = "GidmProjects"
    SetGridView = GVidmProjects
  End Sub
  Protected Sub TBLidmProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLidmProjects.Init
    SetToolBar = TBLidmProjects
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
