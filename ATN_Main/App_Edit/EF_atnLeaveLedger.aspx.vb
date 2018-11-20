Partial Class EF_atnLeaveLedger
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
'    Dim oLC_TranType As LC_atnTranType = FormView1.FindControl("LC_TranType1")
'    oLC_TranType.Enabled = True
'    oLC_TranType.SelectedValue = String.Empty
'    If Not Session("LC_TranType") Is Nothing Then
'      If Session("LC_TranType") <> String.Empty Then
'        oLC_TranType.SelectedValue = Session("LC_TranType")
'      End If
'    End If
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
'    Dim oLC_LeaveTypeID As LC_atnLeaveTypes = FormView1.FindControl("LC_LeaveTypeID1")
'    oLC_LeaveTypeID.Enabled = True
'    oLC_LeaveTypeID.SelectedValue = String.Empty
'    If Not Session("LC_LeaveTypeID") Is Nothing Then
'      If Session("LC_LeaveTypeID") <> String.Empty Then
'        oLC_LeaveTypeID.SelectedValue = Session("LC_LeaveTypeID")
'      End If
'    End If
'    Dim oLC_FinYear As LC_atnFinYear = FormView1.FindControl("LC_FinYear1")
'    oLC_FinYear.Enabled = True
'    oLC_FinYear.SelectedValue = String.Empty
'    If Not Session("LC_FinYear") Is Nothing Then
'      If Session("LC_FinYear") <> String.Empty Then
'        oLC_FinYear.SelectedValue = Session("LC_FinYear")
'      End If
'    End If
  End Sub
End Class
