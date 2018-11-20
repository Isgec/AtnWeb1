Partial Class GF_atnExecuteChangeRequest
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnExecuteChangeRequest"
    SetGridView = GridView1
  End Sub
  Protected Sub LC_UserID1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_UserID1.TextChanged
    Session("LC_UserID") = LC_UserID1.Text
    Session("LC_UserIDEmployeeName") = LC_UserIDEmployeeName1.Text
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
		Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
	End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    If Not Session("LC_UserID") Is Nothing Then
      LC_UserID1.Text = Session("LC_UserID").ToString
      LC_UserIDEmployeeName1.Text = Session("LC_UserIDEmployeeName").ToString
    Else
      LC_UserID1.Text = String.Empty
    End If
  End Sub
  Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    L_Error.Text = ""
    If e.CommandName.ToLower = "Execute".ToLower Then
      Dim mErr As String = SIS.ATN.atnExecuteChangeRequest.UZ_Update(GridView1.DataKeys(e.CommandArgument).Values("RequestID"))
      If Convert.ToInt32(mErr.Substring(0, 1)) > 0 Then
        L_Error.Text = mErr.Split("|".ToCharArray)(1)
      End If
      GridView1.DataBind()
    End If
    If e.CommandName.ToLower = "lgDelete".ToLower Then
      Dim x As Integer = SIS.ATN.atnExecuteChangeRequest.UZ_Delete(GridView1.DataKeys(e.CommandArgument).Values("RequestID"))
      GridView1.DataBind()
    End If
  End Sub
End Class
