Imports System.Web.Script.Serialization
Partial Class EF_WFHConfig
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
  Protected Sub ODSWFHConfig_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSWFHConfig.Selected
    Dim tmp As SIS.ATN.WFHConfig = CType(e.ReturnValue, SIS.ATN.WFHConfig)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVWFHConfig_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVWFHConfig.Init
    DataClassName = "EWFHConfig"
    SetFormView = FVWFHConfig
  End Sub
  Protected Sub TBLWFHConfig_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLWFHConfig.Init
    SetToolBar = TBLWFHConfig
  End Sub
  Protected Sub FVWFHConfig_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVWFHConfig.PreRender
    TBLWFHConfig.EnableSave = Editable
    TBLWFHConfig.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_WFHConfig.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptWFHConfig") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptWFHConfig", mStr)
    End If
  End Sub

End Class
