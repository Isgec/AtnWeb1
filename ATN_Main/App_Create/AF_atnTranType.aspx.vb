Partial Class AF_atnTranType
  Inherits SIS.SYS.InsertBase
  Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Init
    DataClassName = Page.GetType().Name
    SetFormView = FormView1
  End Sub
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oValidate_TranType As TextBox = FormView1.FindControl("TextBoxTranType")
    Dim validateScript As String = "<script type=""text/javascript"">" & _
     "  function validate_TranType(o) {" & _
     "    PageMethods.validate_TranType(o.value, validated_TranType);" & _
     "  }" & _
     "  function validated_TranType(result) {" & _
     "    var p = result.split('|');" & _
     "    if(p[0]=='1'){" & _
     "      alert(p[1]);" & _
     "      var o = $get('" & oValidate_TranType.ClientID & "');" & _
     "      o.value='';" & _
     "      o.focus();" & _
     "    }" & _
     "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTranType") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTranType", validateScript)
    End If
  End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function validate_TranType(ByVal value As String) As String
		Dim mRet As String = "0|"
		Dim oVar As SIS.ATN.atnTranType = SIS.ATN.atnTranType.GetByID(value)
		If Not oVar Is Nothing Then
			mRet = "1|Record for " & value & " allready exists."
		End If
		Return mRet
	End Function
End Class
