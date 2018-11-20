Partial Class GD_atnPostApplication
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnPostApplication"
    SetGridView = GridView1
  End Sub

  Protected Sub LC_CardNo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_CardNo1.TextChanged
    Session("LC_CardNo") = LC_CardNo1.Text
    Session("LC_CardNoEmployeeName") = LC_CardNoEmployeeName1.Text
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
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
		If e.CommandName.ToLower = "rejected" Then
			Dim oRow As GridViewRow = GridView1.Rows(e.CommandArgument)
			Dim Remarks As String = CType(oRow.FindControl("F_Remarks"), TextBox).Text
			Dim LeaveApplID As Integer = GridView1.DataKeys(e.CommandArgument).Values("LeaveApplID")
			SIS.ATN.atnApplHeader.RejectApplication(LeaveApplID, Remarks)
			GridView1.DataBind()
		End If
		If e.CommandName.ToLower = "posted" Then
			Dim oRow As GridViewRow = GridView1.Rows(e.CommandArgument)
			Dim Remarks As String = CType(oRow.FindControl("F_Remarks"), TextBox).Text
			Dim LeaveApplID As Integer = GridView1.DataKeys(e.CommandArgument).Values("LeaveApplID")
			SIS.ATN.atnApplHeader.ForwardApplication(LeaveApplID, Remarks)
			GridView1.DataBind()
		End If
	End Sub

  Protected Sub cmdPostAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPostAll.Click
    Dim mStart As Integer = 0
    Dim mRows As Integer = 20
    Try
      mRows = Convert.ToInt32(F_PostCount.Text)
    Catch ex As Exception
      mRows = 20
    End Try
    Dim oApls As List(Of SIS.ATN.atnPostApplication) = SIS.ATN.atnPostApplication.SelectList(mStart, mRows, "", False, "", "")
    Do While oApls.Count > 0
      For Each oApl As SIS.ATN.atnPostApplication In oApls
        SIS.ATN.atnApplHeader.ForwardApplication(oApl.LeaveApplID, "Posted by bulk processing")
      Next
      GridView1.DataBind()
      Exit Do
      'mStart += mRows
      'oApls = SIS.ATN.atnPostApplication.SelectList(mStart, mRows, "", False, "", "")
    Loop
  End Sub
End Class
