Partial Class AF_WFHConfig
  Inherits SIS.SYS.InsertBase
  Protected Sub FVWFHConfig_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVWFHConfig.Init
    DataClassName = "AWFHConfig"
    SetFormView = FVWFHConfig
  End Sub
  Protected Sub TBLWFHConfig_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLWFHConfig.Init
    SetToolBar = TBLWFHConfig
  End Sub
  Protected Sub FVWFHConfig_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVWFHConfig.DataBound
    SIS.ATN.WFHConfig.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVWFHConfig_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVWFHConfig.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Create") & "/AF_WFHConfig.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptWFHConfig") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptWFHConfig", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVWFHConfig.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVWFHConfig.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
