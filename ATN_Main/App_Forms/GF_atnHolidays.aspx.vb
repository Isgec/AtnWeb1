Partial Class GF_atnHolidays
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnApplicationStatus"
    SetGridView = GridView1
  End Sub
  Private _EditUrl As String = "~/ATN_Main/App_Edit/EF_atnHolidays.aspx"
  Private _AddUrl As String = "~/ATN_Main/App_Create/AF_atnHolidays.aspx"
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnHolidays.aspx"
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
    ToolBar0_1.AddUrl = _AddUrl
    ToolBar0_1.EditUrl = _EditUrl
  End Sub
  Protected Sub LC_OfficeID1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_OfficeID1.SelectedIndexChanged
    Session("LC_OfficeID") = LC_OfficeID1.SelectedValue
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    If Not Session("LC_OfficeID") Is Nothing Then
      LC_OfficeID1.SelectedValue = Session("LC_OfficeID").ToString
    Else
      LC_OfficeID1.SelectedValue = String.Empty
    End If
  End Sub
End Class
