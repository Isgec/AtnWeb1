Partial Class AF_atnPunchStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Init
    DataClassName = Page.GetType().Name
    SetFormView = FormView1
  End Sub
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oValidate_PunchStatusID As TextBox = FormView1.FindControl("TextBoxPunchStatusID")
    Dim validateScript As String = "<script type=""text/javascript"">" & _
     "  function validate_PunchStatusID(o) {" & _
     "    PageMethods.validate_PunchStatusID(o.value, validated_PunchStatusID);" & _
     "  }" & _
     "  function validated_PunchStatusID(result) {" & _
     "    var p = result.split('|');" & _
     "    if(p[0]=='1'){" & _
     "      alert(p[1]);" & _
     "      var o = $get('" & oValidate_PunchStatusID.ClientID & "');" & _
     "      o.value='';" & _
     "      o.focus();" & _
     "    }" & _
     "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePunchStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePunchStatusID", validateScript)
    End If
  End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function validate_PunchStatusID(ByVal value As String) As String
		Dim mRet As String = "0|"
		Dim oVar As SIS.ATN.atnPunchStatus = SIS.ATN.atnPunchStatus.GetByID(value)
		If Not oVar Is Nothing Then
			mRet = "1|Record for " & value & " allready exists."
		End If
		Return mRet
	End Function
End Class
