Partial Class EF_taTPInvoicing
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
  Protected Sub ODStaTPInvoicing_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaTPInvoicing.Selected
    Dim tmp As SIS.TA.taTPInvoicing = CType(e.ReturnValue, SIS.TA.taTPInvoicing)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaTPInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTPInvoicing.Init
    DataClassName = "EtaTPInvoicing"
    SetFormView = FVtaTPInvoicing
  End Sub
  Protected Sub TBLtaTPInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTPInvoicing.Init
    SetToolBar = TBLtaTPInvoicing
  End Sub
  Protected Sub FVtaTPInvoicing_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTPInvoicing.PreRender
    TBLtaTPInvoicing.EnableSave = Editable
    TBLtaTPInvoicing.EnableDelete = Deleteable
    TBLtaTPInvoicing.PrintUrl &= Request.QueryString("InvoiceNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taTPInvoicing.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaTPInvoicing") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaTPInvoicing", mStr)
    End If
  End Sub

End Class
