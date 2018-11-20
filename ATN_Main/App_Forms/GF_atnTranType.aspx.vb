Partial Class GF_atnTranType
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnTranTypes"
    SetGridView = GridView1
  End Sub
  Private _EditUrl As String = "~/ATN_Main/App_Edit/EF_atnTranType.aspx"
  Private _AddUrl As String = "~/ATN_Main/App_Create/AF_atnTranType.aspx"
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnTranType.aspx"
  Private _DisplayEdit As Boolean = True
  Private _DisplayInfo As Boolean = False
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim RedirectUrl As String = _EditUrl & "?Code=" & oBut.CommandArgument.ToString
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim RedirectUrl As String = _InfoUrl & "?Code=" & oBut.CommandArgument.ToString
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    GridView1.Columns(0).Visible = _DisplayEdit
    GridView1.Columns(1).Visible = _DisplayInfo
    ToolBar0_1.AddUrl = _AddUrl
    ToolBar0_1.EditUrl = _EditUrl

    If Not _DisplayEdit Then
      ToolBar0_1.ToolType = lgToolBar.ToolTypes.lgNDGrid

    End If
  End Sub

End Class
