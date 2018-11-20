Partial Class GF_taCategories
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_taCategories.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CategoryID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaCategories_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCategories.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CategoryID As Int32 = GVtaCategories.DataKeys(e.CommandArgument).Values("CategoryID")  
        Dim RedirectUrl As String = TBLtaCategories.EditUrl & "?CategoryID=" & CategoryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCategories.Init
    DataClassName = "GtaCategories"
    SetGridView = GVtaCategories
  End Sub
  Protected Sub TBLtaCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCategories.Init
    SetToolBar = TBLtaCategories
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
