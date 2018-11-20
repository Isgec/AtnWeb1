Partial Class AF_newHrmEmployees
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnewHrmEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnewHrmEmployees.Init
    DataClassName = "AnewHrmEmployees"
    SetFormView = FVnewHrmEmployees
  End Sub
  Protected Sub TBLnewHrmEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnewHrmEmployees.Init
    SetToolBar = TBLnewHrmEmployees
  End Sub
  Protected Sub FVnewHrmEmployees_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnewHrmEmployees.DataBound
    SIS.ATN.newHrmEmployees.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnewHrmEmployees_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnewHrmEmployees.PreRender
    Dim oF_C_OfficeID As LC_hrmOffices = FVnewHrmEmployees.FindControl("F_C_OfficeID")
    oF_C_OfficeID.Enabled = True
    oF_C_OfficeID.SelectedValue = String.Empty
    If Not Session("F_C_OfficeID") Is Nothing Then
      If Session("F_C_OfficeID") <> String.Empty Then
        oF_C_OfficeID.SelectedValue = Session("F_C_OfficeID")
      End If
    End If
    Dim oF_C_DepartmentID As LC_hrmDepartments = FVnewHrmEmployees.FindControl("F_C_DepartmentID")
    oF_C_DepartmentID.Enabled = True
    oF_C_DepartmentID.SelectedValue = String.Empty
    If Not Session("F_C_DepartmentID") Is Nothing Then
      If Session("F_C_DepartmentID") <> String.Empty Then
        oF_C_DepartmentID.SelectedValue = Session("F_C_DepartmentID")
      End If
    End If
    Dim oF_C_DesignationID As LC_hrmDesignations = FVnewHrmEmployees.FindControl("F_C_DesignationID")
    oF_C_DesignationID.Enabled = True
    oF_C_DesignationID.SelectedValue = String.Empty
    If Not Session("F_C_DesignationID") Is Nothing Then
      If Session("F_C_DesignationID") <> String.Empty Then
        oF_C_DesignationID.SelectedValue = Session("F_C_DesignationID")
      End If
    End If
    Dim oF_CategoryID As LC_taCategories = FVnewHrmEmployees.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_C_ProjectSiteID_Display As Label  = FVnewHrmEmployees.FindControl("F_C_ProjectSiteID_Display")
    Dim oF_C_ProjectSiteID As TextBox  = FVnewHrmEmployees.FindControl("F_C_ProjectSiteID")
    Dim oF_VerifierID_Display As Label  = FVnewHrmEmployees.FindControl("F_VerifierID_Display")
    Dim oF_VerifierID As TextBox  = FVnewHrmEmployees.FindControl("F_VerifierID")
    Dim oF_ApproverID_Display As Label  = FVnewHrmEmployees.FindControl("F_ApproverID_Display")
    Dim oF_ApproverID As TextBox  = FVnewHrmEmployees.FindControl("F_ApproverID")
    Dim oF_SiteAllowanceApprover_Display As Label  = FVnewHrmEmployees.FindControl("F_SiteAllowanceApprover_Display")
    Dim oF_SiteAllowanceApprover As TextBox  = FVnewHrmEmployees.FindControl("F_SiteAllowanceApprover")
    Dim oF_TAVerifier_Display As Label  = FVnewHrmEmployees.FindControl("F_TAVerifier_Display")
    Dim oF_TAVerifier As TextBox  = FVnewHrmEmployees.FindControl("F_TAVerifier")
    Dim oF_TASanctioningAuthority_Display As Label  = FVnewHrmEmployees.FindControl("F_TASanctioningAuthority_Display")
    Dim oF_TASanctioningAuthority As TextBox  = FVnewHrmEmployees.FindControl("F_TASanctioningAuthority")
    Dim oF_TAApprover_Display As Label  = FVnewHrmEmployees.FindControl("F_TAApprover_Display")
    Dim oF_TAApprover As TextBox  = FVnewHrmEmployees.FindControl("F_TAApprover")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Create") & "/AF_newHrmEmployees.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnewHrmEmployees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnewHrmEmployees", mStr)
    End If
    If Request.QueryString("CardNo") IsNot Nothing Then
      CType(FVnewHrmEmployees.FindControl("F_CardNo"), TextBox).Text = Request.QueryString("CardNo")
      CType(FVnewHrmEmployees.FindControl("F_CardNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function C_ProjectSiteIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.idmProjects.SelectidmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function VerifierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteAllowanceApproverCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TAVerifierCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TASanctioningAuthorityCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TAApproverCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_newHrmEmployees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CardNo As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(CardNo)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_SiteAllowanceApprover(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SiteAllowanceApprover As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(SiteAllowanceApprover)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_VerifierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim VerifierID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(VerifierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_ApproverID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ApproverID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(ApproverID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_TAVerifier(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TAVerifier As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(TAVerifier)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_TAApprover(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TAApprover As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(TAApprover)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_TASanctioningAuthority(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TASanctioningAuthority As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(TASanctioningAuthority)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_C_ProjectSiteID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim C_ProjectSiteID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.idmProjects = SIS.ATN.idmProjects.idmProjectsGetByID(C_ProjectSiteID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
