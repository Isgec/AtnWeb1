Partial Class AF_atnCardReplacement
  Inherits SIS.SYS.InsertBase
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
    Dim oLC_CardNoEmployeeName As TextBox  = FormView1.FindControl("LC_CardNoEmployeeName1")
    oLC_CardNoEmployeeName.Enabled = True
    oLC_CardNoEmployeeName.Text = String.Empty
    If Not Session("LC_CardNoEmployeeName") Is Nothing Then
      If Session("LC_CardNoEmployeeName") <> String.Empty Then
        oLC_CardNoEmployeeName.Text = Session("LC_CardNoEmployeeName")
      End If
    End If
    Dim oLC_CardNo As TextBox  = FormView1.FindControl("LC_CardNo1")
    oLC_CardNo.Enabled = True
    oLC_CardNo.Text = String.Empty
    If Not Session("LC_CardNo") Is Nothing Then
      If Session("LC_CardNo") <> String.Empty Then
        oLC_CardNo.Text = Session("LC_CardNo")
      End If
    End If
		Dim strScriptCardNo As String = "<script type=""text/javascript""> " & _
			"function LC_CardNo1_AutoCompleteExtender_Selected(sender, e) {" & _
			"  var LC_CardNo1 = $get('" & oLC_CardNo.ClientID & "');" & _
			"  LC_CardNo1.value = e.get_value();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("LC_CardNo1") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "LC_CardNo1", strScriptCardNo)
			End If
    Dim oValidate_ReplacedCardNo As TextBox = FormView1.FindControl("TextBoxReplacedCardNo")
		Dim validateScript As String = "<script type=""text/javascript"">" & _
			"  function validate_ReplacedCardNo(o) {" & _
			"    PageMethods.validate_ReplacedCardNo(o.value, validated_ReplacedCardNo);" & _
			"  }" & _
			"  function validated_ReplacedCardNo(result) {" & _
			"    var p = result.split('|');" & _
			"    if(p[0]=='1'){" & _
			"      alert(p[1]);" & _
			"      var o = $get('" & oValidate_ReplacedCardNo.ClientID & "');" & _
			"      o.value='';" & _
			"      o.focus();" & _
			"    }" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateReplacedCardNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateReplacedCardNo", validateScript)
		End If
  End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function validate_ReplacedCardNo(ByVal value As String) As String
		Dim mRet As String = "0|"
		Dim oVar As SIS.ATN.atnCardReplacement = SIS.ATN.atnCardReplacement.GetByID(value)
		If Not oVar Is Nothing Then
			mRet = "1|Record for " & value & " allready exists."
		End If
		Return mRet
	End Function
End Class
