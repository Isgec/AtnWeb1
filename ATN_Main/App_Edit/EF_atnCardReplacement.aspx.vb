Partial Class EF_atnCardReplacement
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
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
  End Function
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oLC_CardNo As TextBox = FormView1.FindControl("LC_CardNo1")
		Dim strScriptCardNo As String = "<script type=""text/javascript""> " & _
			"function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {" & _
			"  var LC_CardNo1 = $get('" & oLC_CardNo.ClientID & "');" & _
			"  LC_CardNo1.value = e.get_value();" & _
			"}" & _
			"</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("LC_CardNo1") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "LC_CardNo1", strScriptCardNo)
    End If
  End Sub
End Class
