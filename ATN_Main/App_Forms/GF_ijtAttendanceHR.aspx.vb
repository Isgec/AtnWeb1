Partial Class GF_ijtAttendanceHR
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GijtAttendanceHR"
    SetGridView = GridView1
  End Sub
  Protected Sub Days_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oBut As Button = CType(sender, Button)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim CardNo As Integer = aVal(0)
    Dim DataMonth As String = aVal(1).PadLeft(2, "0")
    Dim DayID As String = aVal(2).Replace("D", "").PadLeft(2, "0")
    Dim FinYear As String = HttpContext.Current.Session("FinYear")
    Dim DataDate As String = DayID & "/" & DataMonth & "/" & FinYear
    Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDate(CardNo, DataDate)
    If Not oAtnd Is Nothing Then
      If oAtnd.PunchStatusID <> oBut.Text Then
        Select Case oBut.Text.ToUpper
          Case "PR"
            With oAtnd
              .Punch1Time = 9.0
              .Punch2Time = 17.45
              .PunchStatusID = "PR"
              .PunchValue = 1
              .FinalValue = 1
              .NeedsRegularization = False
            End With
          Case "AD"
            With oAtnd
              .Punch1Time = 0
              .Punch2Time = 0
              .PunchStatusID = "AD"
              .PunchValue = 0
              .FinalValue = 0
              .NeedsRegularization = True
            End With
          Case "HD"
            With oAtnd
              .Punch1Time = 0
              .Punch2Time = 0
              .PunchStatusID = "HD"
              .PunchValue = 1
              .FinalValue = 1
              .NeedsRegularization = False
            End With
        End Select
        SIS.ATN.atnNewAttendance.Update(oAtnd)
        GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
      End If
    End If
  End Sub
	Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
		If e.CommandName.ToLower = "forward" Then
			Dim aVal() As String = e.CommandArgument.ToString.Split(",".ToCharArray)
			Dim CardNo As String = aVal(0)
			Dim DataMonth As Integer = aVal(1)

			If SIS.IJT.ijtAttendance.VerifiySiteAttendance(CardNo, DataMonth) > 0 Then
				'GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
				GridView1.DataBind()
			End If
		End If
	End Sub

	Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
		Session("F_CardNo") = F_CardNo.Text
		Session("F_CardNo_Display") = F_CardNo_Display.Text
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	Protected Sub F_C_ProjectSiteID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_ProjectSiteID.TextChanged
		Session("F_C_ProjectSiteID") = F_C_ProjectSiteID.Text
		Session("F_C_ProjectSiteID_Display") = F_C_ProjectSiteID_Display.Text
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
 <System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function C_ProjectSiteIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.HRM.hrmProjects.SelecthrmProjectsAutoCompleteList(prefixText, count)
	End Function
	Protected Sub F_DataMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DataMonth.SelectedIndexChanged
		Session("F_DataMonth") = F_DataMonth.SelectedValue
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		F_CardNo_Display.Text = String.Empty
		If Not Session("F_CardNo_Display") Is Nothing Then
			If Session("F_CardNo_Display") <> String.Empty Then
				F_CardNo_Display.Text = Session("F_CardNo_Display")
			End If
		End If
		F_CardNo.Text = String.Empty
		If Not Session("F_CardNo") Is Nothing Then
			If Session("F_CardNo") <> String.Empty Then
				F_CardNo.Text = Session("F_CardNo")
			End If
		End If
		Dim strScriptCardNo As String = "<script type=""text/javascript""> " & _
		 "function ACECardNo_Selected(sender, e) {" & _
		 "  var F_CardNo = $get('" & F_CardNo.ClientID & "');" & _
		 "  var F_CardNo_Display = $get('" & F_CardNo_Display.ClientID & "');" & _
		 "  var retval = e.get_value();" & _
		 "  var p = retval.split('|');" & _
		 "  F_CardNo.value = p[0];" & _
		 "  F_CardNo_Display.innerHTML = e.get_text();" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNo", strScriptCardNo)
		End If
		Dim strScriptPopulatingCardNo As String = "<script type=""text/javascript""> " & _
		 "function ACECardNo_Populating(o,e) {" & _
		 "  var p = $get('" & F_CardNo.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat= 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACECardNo_Populated(o,e) {" & _
		 "  var p = $get('" & F_CardNo.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNoPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNoPopulating", strScriptPopulatingCardNo)
		End If
		F_C_ProjectSiteID_Display.Text = String.Empty
		If Not Session("F_C_ProjectSiteID_Display") Is Nothing Then
			If Session("F_C_ProjectSiteID_Display") <> String.Empty Then
				F_C_ProjectSiteID_Display.Text = Session("F_C_ProjectSiteID_Display")
			End If
		End If
		F_C_ProjectSiteID.Text = String.Empty
		If Not Session("F_C_ProjectSiteID") Is Nothing Then
			If Session("F_C_ProjectSiteID") <> String.Empty Then
				F_C_ProjectSiteID.Text = Session("F_C_ProjectSiteID")
			End If
		End If
		Dim strScriptC_ProjectSiteID As String = "<script type=""text/javascript""> " & _
		 "function ACEC_ProjectSiteID_Selected(sender, e) {" & _
		 "  var F_C_ProjectSiteID = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
		 "  var F_C_ProjectSiteID_Display = $get('" & F_C_ProjectSiteID_Display.ClientID & "');" & _
		 "  var retval = e.get_value();" & _
		 "  var p = retval.split('|');" & _
		 "  F_C_ProjectSiteID.value = p[0];" & _
		 "  F_C_ProjectSiteID_Display.innerHTML = e.get_text();" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_C_ProjectSiteID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_C_ProjectSiteID", strScriptC_ProjectSiteID)
		End If
		Dim strScriptPopulatingC_ProjectSiteID As String = "<script type=""text/javascript""> " & _
		 "function ACEC_ProjectSiteID_Populating(o,e) {" & _
		 "  var p = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat= 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACEC_ProjectSiteID_Populated(o,e) {" & _
		 "  var p = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_C_ProjectSiteIDPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_C_ProjectSiteIDPopulating", strScriptPopulatingC_ProjectSiteID)
		End If

		F_DataMonth.SelectedValue = String.Empty
		If Not Session("F_DataMonth") Is Nothing Then
			If Session("F_DataMonth") <> String.Empty Then
				F_DataMonth.SelectedValue = Session("F_DataMonth")
			End If
		Else
			F_DataMonth.SelectedValue = Now.Month
		End If
		Dim validateScriptCardNo As String = "<script type=""text/javascript"">" & _
		 "  function validate_CardNo(o) {" & _
		 "    validated_FK_IJT_Attendance_HRM_Employees.main = true;" & _
		 "    validate_FK_IJT_Attendance_HRM_Employees(o);" & _
		 "  }" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCardNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCardNo", validateScriptCardNo)
		End If
		Dim validateScriptFK_IJT_Attendance_HRM_Employees As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_IJT_Attendance_HRM_Employees(o) {" & _
		 "    var value = o.id;" & _
		 "    var CardNo = $get('" & F_CardNo.ClientID & "');" & _
		 "    try{" & _
		 "    if(CardNo.value==''){" & _
		 "      if(validated_FK_IJT_Attendance_HRM_Employees.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "    }" & _
		 "    value = value + ',' + CardNo.value ;" & _
		 "    }catch(ex){}" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_IJT_Attendance_HRM_Employees(value, validated_FK_IJT_Attendance_HRM_Employees);" & _
		 "  }" & _
		 "  validated_FK_IJT_Attendance_HRM_Employees.main = false;" & _
		 "  function validated_FK_IJT_Attendance_HRM_Employees(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_IJT_Attendance_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_IJT_Attendance_HRM_Employees", validateScriptFK_IJT_Attendance_HRM_Employees)
		End If
		Dim validateScriptC_ProjectSiteID As String = "<script type=""text/javascript"">" & _
		 "  function validate_C_ProjectSiteID(o) {" & _
		 "    validated_FK_IJT_Attendance_DCM_Projects.main = true;" & _
		 "    validate_FK_IJT_Attendance_DCM_Projects(o);" & _
		 "  }" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateC_ProjectSiteID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateC_ProjectSiteID", validateScriptC_ProjectSiteID)
		End If
		Dim validateScriptFK_IJT_Attendance_DCM_Projects As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_IJT_Attendance_DCM_Projects(o) {" & _
		 "    var value = o.id;" & _
		 "    var C_ProjectSiteID = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
		 "    try{" & _
		 "    if(C_ProjectSiteID.value==''){" & _
		 "      if(validated_FK_IJT_Attendance_DCM_Projects.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "    }" & _
		 "    value = value + ',' + C_ProjectSiteID.value ;" & _
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
	 Public Shared Function validate_FK_IJT_Attendance_HRM_Employees(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim CardNo As String = CType(aVal(1), String)
		Dim oVar As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_IJT_Attendance_DCM_Projects(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim C_ProjectSiteID As String = CType(aVal(1), String)
		Dim oVar As SIS.HRM.hrmProjects = SIS.HRM.hrmProjects.GetByID(C_ProjectSiteID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function

	Protected Function EnabledHR(ByVal value As String) As Boolean
		Select Case value
			Case "PR", "HD", "AD"
				Return True
		End Select
		Return False
	End Function
	<System.Web.Services.WebMethod()> _
	Public Shared Function update_attendance(ByVal value As String) As String
		Return SIS.IJT.ijtAttendance.Update(value)
	End Function
	'Protected Sub dd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dd.SelectedIndexChanged
	'	GridView1.DataBind()
	'End Sub

  Protected Sub cmdVerifyAll_Click(sender As Object, e As System.EventArgs) Handles cmdVerifyAll.Click
    Dim LastTimeOut As Integer = 60
    Dim oSM As ScriptManager = Me.Master.FindControl("ToolkitScriptManager1")
    If Not oSM Is Nothing Then
      LastTimeOut = oSM.AsyncPostBackTimeout
      oSM.AsyncPostBackTimeout = 3600
    End If
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 3600

    Dim page As Integer = 0
    Dim size As Integer = 50
    Dim DataMonth As Integer = F_DataMonth.SelectedValue
    Dim oRecs As List(Of SIS.IJT.ijtAttendance) = SIS.IJT.ijtAttendance.SelectListHR(page, size, "CardNo", False, "", "", "", DataMonth, "")
    Do While oRecs.Count > 0
      For Each rec As SIS.IJT.ijtAttendance In oRecs
        Try
          SIS.IJT.ijtAttendance.VerifiySiteAttendance(rec.CardNo, rec.DataMonth)
        Catch ex As Exception
        End Try
      Next
      page = page + size
      oRecs = SIS.IJT.ijtAttendance.SelectListHR(page, size, "CardNo", False, "", "", "", DataMonth, "")
    Loop
    GridView1.DataBind()
    If Not oSM Is Nothing Then
      oSM.AsyncPostBackTimeout = LastTimeOut
    End If
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
  End Sub
End Class
