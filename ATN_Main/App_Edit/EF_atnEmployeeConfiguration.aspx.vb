Partial Class EF_atnEmployeeConfiguration
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
  Protected Sub ODSatnEmployeeConfiguration_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnEmployeeConfiguration.Selected
    Dim tmp As SIS.ATN.atnEmployeeConfiguration = CType(e.ReturnValue, SIS.ATN.atnEmployeeConfiguration)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVatnEmployeeConfiguration_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnEmployeeConfiguration.Init
    DataClassName = "EatnEmployeeConfiguration"
    SetFormView = FVatnEmployeeConfiguration
  End Sub
  Protected Sub TBLatnEmployeeConfiguration_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnEmployeeConfiguration.Init
    SetToolBar = TBLatnEmployeeConfiguration
  End Sub
  Protected Sub FVatnEmployeeConfiguration_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnEmployeeConfiguration.PreRender
    TBLatnEmployeeConfiguration.EnableSave = Editable
    TBLatnEmployeeConfiguration.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_atnEmployeeConfiguration.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnEmployeeConfiguration") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnEmployeeConfiguration", mStr)
    End If
  End Sub

End Class
