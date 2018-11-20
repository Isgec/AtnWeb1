Partial Class AF_atnLeaveTypes
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
  Public Shared Function SpecialSanctionByCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
  End Function
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oLC_ForwardToLeaveTypeID As LC_atnLeaveTypes = FormView1.FindControl("LC_ForwardToLeaveTypeID1")
    oLC_ForwardToLeaveTypeID.Enabled = True
    oLC_ForwardToLeaveTypeID.SelectedValue = String.Empty
    If Not Session("LC_ForwardToLeaveTypeID") Is Nothing Then
      If Session("LC_ForwardToLeaveTypeID") <> String.Empty Then
        oLC_ForwardToLeaveTypeID.SelectedValue = Session("LC_ForwardToLeaveTypeID")
      End If
    End If
    Dim oLC_SpecialSanctionByEmployeeName As TextBox  = FormView1.FindControl("LC_SpecialSanctionByEmployeeName1")
    oLC_SpecialSanctionByEmployeeName.Enabled = True
    oLC_SpecialSanctionByEmployeeName.Text = String.Empty
    If Not Session("LC_SpecialSanctionByEmployeeName") Is Nothing Then
      If Session("LC_SpecialSanctionByEmployeeName") <> String.Empty Then
        oLC_SpecialSanctionByEmployeeName.Text = Session("LC_SpecialSanctionByEmployeeName")
      End If
    End If
    Dim oLC_SpecialSanctionBy As TextBox  = FormView1.FindControl("LC_SpecialSanctionBy1")
    oLC_SpecialSanctionBy.Enabled = True
    oLC_SpecialSanctionBy.Text = String.Empty
    If Not Session("LC_SpecialSanctionBy") Is Nothing Then
      If Session("LC_SpecialSanctionBy") <> String.Empty Then
        oLC_SpecialSanctionBy.Text = Session("LC_SpecialSanctionBy")
      End If
    End If
		Dim strScriptSpecialSanctionBy As String = "<script type=""text/javascript""> " & _
			"function LC_SpecialSanctionBy1_AutoCompleteExtender_Selected(sender, e) {" & _
			"  var LC_SpecialSanctionBy1 = $get('" & oLC_SpecialSanctionBy.ClientID & "');" & _
			"  LC_SpecialSanctionBy1.value = e.get_value();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("LC_SpecialSanctionBy1") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "LC_SpecialSanctionBy1", strScriptSpecialSanctionBy)
			End If
    Dim oLC_PostedLeaveTypeID As LC_atnLeaveTypes = FormView1.FindControl("LC_PostedLeaveTypeID1")
    oLC_PostedLeaveTypeID.Enabled = True
    oLC_PostedLeaveTypeID.SelectedValue = String.Empty
    If Not Session("LC_PostedLeaveTypeID") Is Nothing Then
      If Session("LC_PostedLeaveTypeID") <> String.Empty Then
        oLC_PostedLeaveTypeID.SelectedValue = Session("LC_PostedLeaveTypeID")
      End If
    End If
    Dim oValidate_LeaveTypeID As TextBox = FormView1.FindControl("TextBoxLeaveTypeID")
		Dim validateScript As String = "<script type=""text/javascript"">" & _
			"  function validate_LeaveTypeID(o) {" & _
			"    PageMethods.validate_LeaveTypeID(o.value, validated_LeaveTypeID);" & _
			"  }" & _
			"  function validated_LeaveTypeID(result) {" & _
			"    var p = result.split('|');" & _
			"    if(p[0]=='1'){" & _
			"      alert(p[1]);" & _
			"      var o = $get('" & oValidate_LeaveTypeID.ClientID & "');" & _
			"      o.value='';" & _
			"      o.focus();" & _
			"    }" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateLeaveTypeID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateLeaveTypeID", validateScript)
		End If
  End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function validate_LeaveTypeID(ByVal value As String) As String
		Dim mRet As String = "0|"
		Dim oVar As SIS.ATN.atnLeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(value)
		If Not oVar Is Nothing Then
			mRet = "1|Record for " & value & " allready exists."
		End If
		Return mRet
	End Function
End Class
