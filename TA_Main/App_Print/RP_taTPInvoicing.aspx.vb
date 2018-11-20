Partial Class RP_taTPInvoicing
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taTPInvoicing.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?InvoiceNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim InvoiceNo As String = CType(aVal(0),String)
    Dim oVar As SIS.TA.taTPInvoicing = SIS.TA.taTPInvoicing.taTPInvoicingGetByID(InvoiceNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    oTbl.GridLines = GridLines.Both
    oTbl.Style.Add("margin-top", "15px")
    oTbl.Style.Add("margin-left", "30px")
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Invoice No"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.InvoiceNo
      oCol.Style.Add("text-align","left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Invoice Date"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.InvoiceDate
      oCol.Style.Add("text-align","center")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)
  End Sub
End Class
