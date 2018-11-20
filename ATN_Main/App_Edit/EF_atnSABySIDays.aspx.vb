Partial Class EF_atnSABySIDays
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
  Protected Sub ODSatnSABySIDays_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnSABySIDays.Selected
    Dim tmp As SIS.ATN.atnSABySIDays = CType(e.ReturnValue, SIS.ATN.atnSABySIDays)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVatnSABySIDays_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySIDays.Init
    DataClassName = "EatnSABySIDays"
    SetFormView = FVatnSABySIDays
  End Sub
  Protected Sub TBLatnSABySIDays_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSABySIDays.Init
    SetToolBar = TBLatnSABySIDays
  End Sub
  Protected Sub FVatnSABySIDays_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySIDays.PreRender
    TBLatnSABySIDays.EnableSave = Editable
    TBLatnSABySIDays.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_atnSABySIDays.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnSABySIDays") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnSABySIDays", mStr)
    End If
  End Sub

End Class
