Partial Class GD_atnVerifyApplication
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = Page.GetType().Name
    SetGridView = GridView1
  End Sub
  Protected Sub LC_CardNo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_CardNo1.TextChanged
    Session("LC_CardNo") = LC_CardNo1.Text
    Session("LC_CardNoEmployeeName") = LC_CardNoEmployeeName1.Text
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    Session("PageNo_" & FileName) = 0
  End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
		Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
	End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    If Not Session("LC_CardNo") Is Nothing Then
      LC_CardNo1.Text = Session("LC_CardNo").ToString
      LC_CardNoEmployeeName1.Text = Session("LC_CardNoEmployeeName").ToString
    Else
      LC_CardNo1.Text = String.Empty
    End If
  End Sub
  Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    If e.CommandName = "Verified" Then
      For Each row As GridViewRow In GridView1.Rows
        If CType(row.Cells(6).Controls(1), ImageButton).CommandArgument = e.CommandArgument Then
          Dim Remarks As String = CType(row.Cells(5).Controls(1), TextBox).Text
          SIS.ATN.atnApplHeader.ForwardApplication(e.CommandArgument, Remarks)
          Exit For
        End If
      Next
      GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
    End If
    If e.CommandName = "Rejected" Then
      Dim oGV As GridView = GridView1
      For Each row As GridViewRow In GridView1.Rows
        If CType(row.Cells(6).Controls(1), ImageButton).CommandArgument = e.CommandArgument Then
          Dim Remarks As String = CType(row.Cells(5).Controls(1), TextBox).Text
          SIS.ATN.atnApplHeader.RejectApplication(e.CommandArgument, Remarks)
          Exit For
        End If
      Next
      GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
    End If
  End Sub
End Class
