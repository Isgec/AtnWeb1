Partial Class AF_atnApproverChangeRequest
  Inherits SIS.SYS.InsertBase
  Protected Sub FVatnApproverChangeRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnApproverChangeRequest.Init
    DataClassName = "AatnApproverChangeRequest"
    SetFormView = FVatnApproverChangeRequest
  End Sub
  Protected Sub TBLatnApproverChangeRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnApproverChangeRequest.Init
    SetToolBar = TBLatnApproverChangeRequest
  End Sub
  Protected Sub FVatnApproverChangeRequest_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnApproverChangeRequest.DataBound
    SIS.ATN.atnApproverChangeRequest.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVatnApproverChangeRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnApproverChangeRequest.PreRender
    Dim oF_VerifierID_Display As Label  = FVatnApproverChangeRequest.FindControl("F_VerifierID_Display")
    Dim oF_VerifierID As TextBox  = FVatnApproverChangeRequest.FindControl("F_VerifierID")
    Dim oF_ApproverID_Display As Label  = FVatnApproverChangeRequest.FindControl("F_ApproverID_Display")
    Dim oF_ApproverID As TextBox  = FVatnApproverChangeRequest.FindControl("F_ApproverID")
    Dim oF_TAVerifierID_Display As Label  = FVatnApproverChangeRequest.FindControl("F_TAVerifierID_Display")
    Dim oF_TAVerifierID As TextBox  = FVatnApproverChangeRequest.FindControl("F_TAVerifierID")
    Dim oF_TAApproverID_Display As Label  = FVatnApproverChangeRequest.FindControl("F_TAApproverID_Display")
    Dim oF_TAApproverID As TextBox  = FVatnApproverChangeRequest.FindControl("F_TAApproverID")
    Dim oF_TASA_Display As Label  = FVatnApproverChangeRequest.FindControl("F_TASA_Display")
    Dim oF_TASA As TextBox = FVatnApproverChangeRequest.FindControl("F_TASA")
    Dim oEmp As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(HttpContext.Current.Session("LoginID"))
    oF_VerifierID.Text = oEmp.VerifierID
    oF_ApproverID.Text = oEmp.ApproverID
    oF_TAVerifierID.Text = oEmp.TAVerifier
    oF_TAApproverID.Text = oEmp.TAApprover
    oF_TASA.Text = oEmp.TASanctioningAuthority
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Create") & "/AF_atnApproverChangeRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnApproverChangeRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnApproverChangeRequest", mStr)
    End If
    If Request.QueryString("RequestID") IsNot Nothing Then
      CType(FVatnApproverChangeRequest.FindControl("F_RequestID"), TextBox).Text = Request.QueryString("RequestID")
      CType(FVatnApproverChangeRequest.FindControl("F_RequestID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function VerifierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TAVerifierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TAApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TASACompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ATN_ApproverChangeRequest_VerifierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim VerifierID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.atnEmployeesGetByID(VerifierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ATN_ApproverChangeRequest_AppriverID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ApproverID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.atnEmployeesGetByID(ApproverID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ATN_ApproverChangeRequest_TAVerifierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TAVerifierID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.atnEmployeesGetByID(TAVerifierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ATN_ApproverChangeRequest_TAApproverID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TAApproverID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.atnEmployeesGetByID(TAApproverID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ATN_ApproverChangeRequest_TASA(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TASA As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.atnEmployeesGetByID(TASA)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
