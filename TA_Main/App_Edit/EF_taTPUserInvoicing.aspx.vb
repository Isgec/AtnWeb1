Partial Class EF_taTPUserInvoicing
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
  Protected Sub ODStaTPUserInvoicing_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaTPUserInvoicing.Selected
    Dim tmp As SIS.TA.taTPUserInvoicing = CType(e.ReturnValue, SIS.TA.taTPUserInvoicing)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaTPUserInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTPUserInvoicing.Init
    DataClassName = "EtaTPUserInvoicing"
    SetFormView = FVtaTPUserInvoicing
  End Sub
  Protected Sub TBLtaTPUserInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTPUserInvoicing.Init
    SetToolBar = TBLtaTPUserInvoicing
  End Sub
  Protected Sub FVtaTPUserInvoicing_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTPUserInvoicing.PreRender
    TBLtaTPUserInvoicing.EnableSave = Editable
    TBLtaTPUserInvoicing.EnableDelete = Deleteable
    TBLtaTPUserInvoicing.PrintUrl &= Request.QueryString("InvoiceNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taTPUserInvoicing.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaTPUserInvoicing") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaTPUserInvoicing", mStr)
    End If
  End Sub

End Class
