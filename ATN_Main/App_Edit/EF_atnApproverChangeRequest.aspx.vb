Partial Class EF_atnApproverChangeRequest
  Inherits SIS.SYS.UpdateBase
  Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Init
    DataClassName = Page.GetType().Name
    SetFormView = FormView1
  End Sub
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  <System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function VerifierIDCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    Return SIS.ATN.atnEmployees.SelectatnActiveEmployeesAutoCompleteList(prefixText, count)
  End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    Return SIS.ATN.atnEmployees.SelectatnActiveEmployeesAutoCompleteList(prefixText, count)
  End Function
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oLC_VerifierID As TextBox = FormView1.FindControl("LC_VerifierID1")
		Dim strScriptVerifierID As String = "<script type=""text/javascript""> " & _
			"function LC_VerifierID1_AutoCompleteExtender_Selected(sender, e) {" & _
			"  var LC_VerifierID1 = $get('" & oLC_VerifierID.ClientID & "');" & _
			"  LC_VerifierID1.value = e.get_value();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("LC_VerifierID1") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "LC_VerifierID1", strScriptVerifierID)
			End If
    Dim oLC_ApproverID As TextBox = FormView1.FindControl("LC_ApproverID1")
		Dim strScriptApproverID As String = "<script type=""text/javascript""> " & _
			"function LC_ApproverID1_AutoCompleteExtender_Selected(sender, e) {" & _
			"  var LC_ApproverID1 = $get('" & oLC_ApproverID.ClientID & "');" & _
			"  LC_ApproverID1.value = e.get_value();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("LC_ApproverID1") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "LC_ApproverID1", strScriptApproverID)
			End If
  End Sub
End Class
