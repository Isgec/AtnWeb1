Partial Class EF_atnWebPayNewEmp
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
  Protected Sub ODSatnWebPayNewEmp_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnWebPayNewEmp.Selected
    Dim tmp As SIS.ATN.atnWebPayNewEmp = CType(e.ReturnValue, SIS.ATN.atnWebPayNewEmp)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVatnWebPayNewEmp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnWebPayNewEmp.Init
    DataClassName = "EatnWebPayNewEmp"
    SetFormView = FVatnWebPayNewEmp
  End Sub
  Protected Sub TBLatnWebPayNewEmp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnWebPayNewEmp.Init
    SetToolBar = TBLatnWebPayNewEmp
  End Sub
  Protected Sub FVatnWebPayNewEmp_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnWebPayNewEmp.PreRender
    TBLatnWebPayNewEmp.EnableSave = Editable
    TBLatnWebPayNewEmp.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_atnWebPayNewEmp.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnWebPayNewEmp") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnWebPayNewEmp", mStr)
    End If
  End Sub

End Class
