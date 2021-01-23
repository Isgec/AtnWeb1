Imports System.Web.Script.Serialization

Partial Class GF_WFHConfig
  Inherits SIS.SYS.GridBase
  Private st As Long = HttpContext.Current.Server.ScriptTimeout

  Protected Sub GVWFHConfig_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVWFHConfig.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVWFHConfig.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLWFHConfig.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim FromDate As DateTime = CType(GVWFHConfig.Rows(e.CommandArgument).FindControl("F_FromDate"), TextBox).Text
        Dim ToDate As DateTime = CType(GVWFHConfig.Rows(e.CommandArgument).FindControl("F_ToDate"), TextBox).Text
        Dim OpenedFor As String = CType(GVWFHConfig.Rows(e.CommandArgument).FindControl("F_OpenedFor"), TextBox).Text
        Dim Active As Boolean = CType(GVWFHConfig.Rows(e.CommandArgument).FindControl("F_Active"), CheckBox).Checked
        Dim AllowProcessed As Boolean = CType(GVWFHConfig.Rows(e.CommandArgument).FindControl("F_AllowProcessed"), CheckBox).Checked
        Dim SerialNo As Int32 = GVWFHConfig.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.ATN.WFHConfig.InitiateWF(SerialNo, FromDate, ToDate, OpenedFor, Active, AllowProcessed)
        GVWFHConfig.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
      Try
        Dim SerialNo As Int32 = GVWFHConfig.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim r As SIS.ATN.wResp = New JavaScriptSerializer().Deserialize((New WfhService).GenerateRooster(SerialNo), GetType(SIS.ATN.wResp))
        If r.err Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(r.msg) & "');", True)
        End If
        GVWFHConfig.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
      HttpContext.Current.Server.ScriptTimeout = st
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
      Try
        Dim SerialNo As Int32 = GVWFHConfig.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim r As SIS.ATN.wResp = New JavaScriptSerializer().Deserialize((New WfhService).DeleteRooster(SerialNo), GetType(SIS.ATN.wResp))
        If r.err Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(r.msg) & "');", True)
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
      HttpContext.Current.Server.ScriptTimeout = st
    End If
  End Sub
  Protected Sub GVWFHConfig_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVWFHConfig.Init
    DataClassName = "GWFHConfig"
    SetGridView = GVWFHConfig
  End Sub
  Protected Sub TBLWFHConfig_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLWFHConfig.Init
    SetToolBar = TBLWFHConfig
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub





End Class
