Partial Class EF_atnSiteAttendance
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
  Protected Sub ODSatnSiteAttendance_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnSiteAttendance.Selected
    Dim tmp As SIS.ATN.atnSiteAttendance = CType(e.ReturnValue, SIS.ATN.atnSiteAttendance)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVatnSiteAttendance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSiteAttendance.Init
    DataClassName = "EatnSiteAttendance"
    SetFormView = FVatnSiteAttendance
  End Sub
  Protected Sub TBLatnSiteAttendance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSiteAttendance.Init
    SetToolBar = TBLatnSiteAttendance
  End Sub
  Protected Sub FVatnSiteAttendance_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSiteAttendance.PreRender
    TBLatnSiteAttendance.EnableSave = Editable
    TBLatnSiteAttendance.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_atnSiteAttendance.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnSiteAttendance") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnSiteAttendance", mStr)
    End If
  End Sub

End Class
