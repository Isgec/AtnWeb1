Partial Class EF_hrmSiteTransfers
  Inherits SIS.SYS.UpdateBase
  Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Init
    DataClassName = Page.GetType().Name
    SetFormView = FormView1
  End Sub
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim F_U_ProjectSiteID_Display As Label = FormView1.FindControl("F_U_ProjectSiteID_Display")
    Dim F_U_ProjectSiteID As TextBox = FormView1.FindControl("F_U_ProjectSiteID")
    Dim strScriptU_ProjectSiteID As String = "<script type=""text/javascript""> " & _
    "function ACEU_ProjectSiteID_Selected(sender, e) {" & _
    "  var F_U_ProjectSiteID = $get('" & F_U_ProjectSiteID.ClientID & "');" & _
    "  var F_U_ProjectSiteID_Display = $get('" & F_U_ProjectSiteID_Display.ClientID & "');" & _
    "  var retval = e.get_value();" & _
    "  var p = retval.split('|');" & _
    "  F_U_ProjectSiteID.value = p[0];" & _
    "  F_U_ProjectSiteID_Display.innerHTML = e.get_text();" & _
    "}" & _
    "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_U_ProjectSiteID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_U_ProjectSiteID", strScriptU_ProjectSiteID)
    End If
    Dim strScriptPopulatingU_ProjectSiteID As String = "<script type=""text/javascript""> " & _
    "function ACEU_ProjectSiteID_Populating(o,e) {" & _
    "  var p = $get('" & F_U_ProjectSiteID.ClientID & "');" & _
    "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
    "  p.style.backgroundRepeat= 'no-repeat';" & _
    "  p.style.backgroundPosition = 'right';" & _
    "  o._contextKey = '';" & _
    "}" & _
    "function ACEU_ProjectSiteID_Populated(o,e) {" & _
    "  var p = $get('" & F_U_ProjectSiteID.ClientID & "');" & _
    "  p.style.backgroundImage  = 'none';" & _
    "}" & _
    "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_U_ProjectSiteIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_U_ProjectSiteIDPopulating", strScriptPopulatingU_ProjectSiteID)
    End If
    Dim validateScriptU_ProjectSiteID As String = "<script type=""text/javascript"">" & _
    "  function validate_U_ProjectSiteID(o) {" & _
    "    validated_FK_IJT_Attendance_DCM_Projects.main = true;" & _
    "    validate_FK_IJT_Attendance_DCM_Projects(o);" & _
    "  }" & _
    "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateU_ProjectSiteID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateU_ProjectSiteID", validateScriptU_ProjectSiteID)
    End If
    Dim validateScriptFK_IJT_Attendance_DCM_Projects As String = "<script type=""text/javascript"">" & _
     "  function validate_FK_IJT_Attendance_DCM_Projects(o) {" & _
     "    var value = o.id;" & _
     "    var U_ProjectSiteID = $get('" & F_U_ProjectSiteID.ClientID & "');" & _
     "    try{" & _
     "    if(U_ProjectSiteID.value==''){" & _
     "      if(validated_FK_IJT_Attendance_DCM_Projects.main){" & _
     "        var o_d = $get(o.id +'_Display');" & _
     "        try{o_d.innerHTML = '';}catch(ex){}" & _
     "      }" & _
     "    }" & _
     "    value = value + ',' + U_ProjectSiteID.value ;" & _
     "    }catch(ex){}" & _
     "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
     "    o.style.backgroundRepeat= 'no-repeat';" & _
     "    o.style.backgroundPosition = 'right';" & _
     "    PageMethods.validate_FK_IJT_Attendance_DCM_Projects(value, validated_FK_IJT_Attendance_DCM_Projects);" & _
     "  }" & _
     "  validated_FK_IJT_Attendance_DCM_Projects.main = false;" & _
     "  function validated_FK_IJT_Attendance_DCM_Projects(result) {" & _
     "    var p = result.split('|');" & _
     "    var o = $get(p[1]);" & _
     "    var o_d = $get(p[1]+'_Display');" & _
     "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
     "    o.style.backgroundImage  = 'none';" & _
     "    if(p[0]=='1'){" & _
     "      o.value='';" & _
     "      try{o_d.innerHTML = '';}catch(ex){}" & _
     "      __doPostBack(o.id, o.value);" & _
     "    }" & _
     "    else" & _
     "      __doPostBack(o.id, o.value);" & _
     "  }" & _
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_IJT_Attendance_DCM_Projects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_IJT_Attendance_DCM_Projects", validateScriptFK_IJT_Attendance_DCM_Projects)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function U_ProjectSiteIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.HRM.hrmProjects.SelecthrmProjectsAutoCompleteList(prefixText, count)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_IJT_Attendance_DCM_Projects(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim U_ProjectSiteID As String = CType(aVal(1), String)
		Dim oVar As SIS.HRM.hrmProjects = SIS.HRM.hrmProjects.GetByID(U_ProjectSiteID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	Dim oData As SIS.HRM.hrmTransfers = Nothing
	Protected Sub ObjectDataSource1_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Selected
		oData = e.ReturnValue
	End Sub
End Class
