Partial Class GF_taTPUserInvoicing
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taTPUserInvoicing.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?InvoiceNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaTPUserInvoicing_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaTPUserInvoicing.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim InvoiceNo As String = GVtaTPUserInvoicing.DataKeys(e.CommandArgument).Values("InvoiceNo")  
        Dim RedirectUrl As String = TBLtaTPUserInvoicing.EditUrl & "?InvoiceNo=" & InvoiceNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaTPUserInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaTPUserInvoicing.Init
    DataClassName = "GtaTPUserInvoicing"
    SetGridView = GVtaTPUserInvoicing
  End Sub
  Protected Sub TBLtaTPUserInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTPUserInvoicing.Init
    SetToolBar = TBLtaTPUserInvoicing
  End Sub
  Protected Sub F_BookingDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BookingDate.TextChanged
    Session("F_BookingDate") = F_BookingDate.Text
    InitGridPage()
  End Sub
  Protected Sub F_TravelDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TravelDate.TextChanged
    Session("F_TravelDate") = F_TravelDate.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub

  Protected Sub GVtaTPUserInvoicing_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GVtaTPUserInvoicing.RowDataBound
    If e.Row.RowType = DataControlRowType.Footer Then
      CType(e.Row.FindControl("LabelTotalAmount"), Label).Text = SIS.TA.taTPInvoicing.TotalAmount
    End If
  End Sub
End Class
