Partial Class GD_atnAttendanceStatus
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnAttendanceStatus"
    SetGridView = GridView1
  End Sub
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnAttendanceStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim RedirectUrl As String = _InfoUrl & "?Code=" & oBut.CommandArgument.ToString
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GridView1_PreRender(sender As Object, e As System.EventArgs) Handles GridView1.PreRender
    Me.GridView1.Columns(2).Visible = False
    Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(Page.User.Identity.Name)
    If oEmp.CategoryID <> String.Empty Then
      If Convert.ToInt32(oEmp.CategoryID) < 10 Then
        Me.GridView1.Columns(2).Visible = True
      End If
    End If
  End Sub
End Class
