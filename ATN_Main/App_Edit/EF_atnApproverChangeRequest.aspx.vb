Imports System.Web.Script.Serialization
Partial Class EF_atnApproverChangeRequest
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSatnApproverChangeRequest_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnApproverChangeRequest.Selected
    Dim tmp As SIS.ATN.atnApproverChangeRequest = CType(e.ReturnValue, SIS.ATN.atnApproverChangeRequest)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVatnApproverChangeRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnApproverChangeRequest.Init
    DataClassName = "EatnApproverChangeRequest"
    SetFormView = FVatnApproverChangeRequest
  End Sub
  Protected Sub TBLatnApproverChangeRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnApproverChangeRequest.Init
    SetToolBar = TBLatnApproverChangeRequest
  End Sub
  Protected Sub FVatnApproverChangeRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnApproverChangeRequest.PreRender
    TBLatnApproverChangeRequest.EnableSave = Editable
    TBLatnApproverChangeRequest.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_atnApproverChangeRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnApproverChangeRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnApproverChangeRequest", mStr)
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
