Partial Class GF_atnWebPayNewEmp
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnWebPayNewEmp.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CardNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVatnWebPayNewEmp_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVatnWebPayNewEmp.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CardNo As String = GVatnWebPayNewEmp.DataKeys(e.CommandArgument).Values("CardNo")  
        Dim RedirectUrl As String = TBLatnWebPayNewEmp.EditUrl & "?CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim CardNo As String = GVatnWebPayNewEmp.DataKeys(e.CommandArgument).Values("CardNo")  
        SIS.ATN.atnWebPayNewEmp.InitiateWF(CardNo)
        GVatnWebPayNewEmp.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVatnWebPayNewEmp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVatnWebPayNewEmp.Init
    DataClassName = "GatnWebPayNewEmp"
    SetGridView = GVatnWebPayNewEmp
  End Sub
  Protected Sub TBLatnWebPayNewEmp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnWebPayNewEmp.Init
    SetToolBar = TBLatnWebPayNewEmp
  End Sub
  Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
    Session("F_CardNo") = F_CardNo.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
