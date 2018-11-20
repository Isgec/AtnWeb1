Partial Class AF_atnSiteAttendance
  Inherits SIS.SYS.InsertBase
  Protected Sub FVatnSiteAttendance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSiteAttendance.Init
    DataClassName = "AatnSiteAttendance"
    SetFormView = FVatnSiteAttendance
  End Sub
  Protected Sub TBLatnSiteAttendance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSiteAttendance.Init
    SetToolBar = TBLatnSiteAttendance
  End Sub
  Protected Sub FVatnSiteAttendance_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSiteAttendance.DataBound
    SIS.ATN.atnSiteAttendance.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVatnSiteAttendance_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSiteAttendance.PreRender
    Dim oF_FinYear_Display As Label  = FVatnSiteAttendance.FindControl("F_FinYear_Display")
    Dim oF_FinYear As TextBox  = FVatnSiteAttendance.FindControl("F_FinYear")
    Dim oF_MonthID As LC_atnMonths = FVatnSiteAttendance.FindControl("F_MonthID")
    oF_MonthID.Enabled = True
    oF_MonthID.SelectedValue = String.Empty
    If Not Session("F_MonthID") Is Nothing Then
      If Session("F_MonthID") <> String.Empty Then
        oF_MonthID.SelectedValue = Session("F_MonthID")
      End If
    End If
    Dim oF_CardNo_Display As Label  = FVatnSiteAttendance.FindControl("F_CardNo_Display")
    Dim oF_CardNo As TextBox  = FVatnSiteAttendance.FindControl("F_CardNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Create") & "/AF_atnSiteAttendance.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnSiteAttendance") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnSiteAttendance", mStr)
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVatnSiteAttendance.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVatnSiteAttendance.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
    If Request.QueryString("MonthID") IsNot Nothing Then
      CType(FVatnSiteAttendance.FindControl("F_MonthID"), TextBox).Text = Request.QueryString("MonthID")
      CType(FVatnSiteAttendance.FindControl("F_MonthID"), TextBox).Enabled = False
    End If
    If Request.QueryString("CardNo") IsNot Nothing Then
      CType(FVatnSiteAttendance.FindControl("F_CardNo"), TextBox).Text = Request.QueryString("CardNo")
      CType(FVatnSiteAttendance.FindControl("F_CardNo"), TextBox).Enabled = False
    End If
  End Sub
  '<System.Web.Services.WebMethod()>
  '<System.Web.Script.Services.ScriptMethod()>
  'Public Shared Function FinYearCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
  '  Return SIS.ATN.atnFinYear.SelectatnFinYearAutoCompleteList(prefixText, count, contextKey)
  'End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  '<System.Web.Services.WebMethod()>
  'Public Shared Function validate_FK_ATN_SiteAttendance_FinYear(ByVal value As String) As String
  '  Dim aVal() As String = value.Split(",".ToCharArray)
  '  Dim mRet As String = "0|" & aVal(0)
  '  Dim FinYear As String = CType(aVal(1), String)
  '  Dim oVar As SIS.ATN.atnFinYear = SIS.ATN.atnFinYear.atnFinYearGetByID(FinYear)
  '  If oVar Is Nothing Then
  '    mRet = "1|" & aVal(0) & "|Record not found."
  '  Else
  '    mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
  '  End If
  '  Return mRet
  'End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ATN_SiteAttendance_CardNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CardNo As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(CardNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
