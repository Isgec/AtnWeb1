Partial Class EF_atnwpEmployees
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
  Protected Sub ODSatnwpEmployees_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnwpEmployees.Selected
    Dim tmp As SIS.ATN.atnwpEmployees = CType(e.ReturnValue, SIS.ATN.atnwpEmployees)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVatnwpEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnwpEmployees.Init
    DataClassName = "EatnwpEmployees"
    SetFormView = FVatnwpEmployees
  End Sub
  Protected Sub TBLatnwpEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnwpEmployees.Init
    SetToolBar = TBLatnwpEmployees
  End Sub
  Protected Sub FVatnwpEmployees_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnwpEmployees.PreRender
    TBLatnwpEmployees.EnableSave = Editable
    TBLatnwpEmployees.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_atnwpEmployees.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnwpEmployees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnwpEmployees", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function C_ProjectSiteIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.idmProjects.SelectidmProjectsAutoCompleteList(prefixText, count, contextKey)
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
