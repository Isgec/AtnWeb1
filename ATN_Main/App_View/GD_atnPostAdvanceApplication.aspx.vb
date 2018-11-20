Partial Class GD_atnPostAdvanceApplication
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnPostAdvanceApplication"
    SetGridView = GridView1
  End Sub
 
	Protected Sub LC_CardNo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_CardNo1.TextChanged
		Session("LC_CardNo") = LC_CardNo1.Text
		Session("LC_CardNoEmployeeName") = LC_CardNoEmployeeName1.Text
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
		Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
	End Function
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		If Not Session("LC_CardNo") Is Nothing Then
			LC_CardNo1.Text = Session("LC_CardNo").ToString
			LC_CardNoEmployeeName1.Text = Session("LC_CardNoEmployeeName").ToString
		Else
			LC_CardNo1.Text = String.Empty
		End If
	End Sub
  Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    If e.CommandName.ToLower = "rejected" Then
      Dim oRow As GridViewRow = GridView1.Rows(e.CommandArgument)
      Dim Remarks As String = CType(oRow.FindControl("F_Remarks"), TextBox).Text
      Dim LeaveApplID As Integer = GridView1.DataKeys(e.CommandArgument).Values("LeaveApplID")
      SIS.ATN.atnApplHeader.RejectApplication(LeaveApplID, Remarks)
      GridView1.DataBind()
    End If
    If e.CommandName.ToLower = "posted" Then
      Dim oRow As GridViewRow = GridView1.Rows(e.CommandArgument)
      Dim Remarks As String = CType(oRow.FindControl("F_Remarks"), TextBox).Text
      Dim LeaveApplID As Integer = GridView1.DataKeys(e.CommandArgument).Values("LeaveApplID")
      SIS.ATN.atnApplHeader.ForwardApplication(LeaveApplID, Remarks)
      GridView1.DataBind()
    End If
  End Sub
End Class
