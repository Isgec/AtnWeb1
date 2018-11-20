Partial Class GT_atnChangeAppliedLeaveType
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnChangeAppliedLeaveType"
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

	Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
		If e.Row.RowState = 5 Or e.Row.RowState = DataControlRowState.Edit Then
			Dim oTxt As TextBox = e.Row.FindControl("F_Posted1LeaveTypeID")
			If oTxt.Text = "" Then
				oTxt.Visible = False
			End If
			Dim oTxt1 As TextBox = e.Row.FindControl("F_Posted2LeaveTypeID")
			If oTxt1.Text = "" Then
				oTxt1.Visible = False
			End If
		End If
	End Sub
	Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
		If e.CommandName.ToLower = "update" Then
			For Each row As GridViewRow In GridView1.Rows
				Dim img As ImageButton = row.FindControl("cmdsave")
				If Not img Is Nothing Then
					If img.CommandArgument = e.CommandArgument Then
						Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(e.CommandArgument)
						Select Case oAtnd.PunchStatusID
							Case "AF"
								oAtnd.Posted1LeaveTypeID = CType(row.FindControl("F_Posted1LeaveTypeID"), TextBox).Text
								oAtnd.Applied1LeaveTypeID = CType(row.FindControl("F_Posted1LeaveTypeID"), TextBox).Text
							Case "AS", "TS"
								oAtnd.Posted2LeaveTypeID = CType(row.FindControl("F_Posted2LeaveTypeID"), TextBox).Text
								oAtnd.Applied2LeaveTypeID = CType(row.FindControl("F_Posted2LeaveTypeID"), TextBox).Text
							Case "AD"
								oAtnd.Applied1LeaveTypeID = CType(row.FindControl("F_Posted1LeaveTypeID"), TextBox).Text
								oAtnd.Applied2LeaveTypeID = CType(row.FindControl("F_Posted2LeaveTypeID"), TextBox).Text
								oAtnd.Posted1LeaveTypeID = CType(row.FindControl("F_Posted1LeaveTypeID"), TextBox).Text
								oAtnd.Posted2LeaveTypeID = CType(row.FindControl("F_Posted2LeaveTypeID"), TextBox).Text
						End Select
						SIS.ATN.atnNewAttendance.UpdatePostedLeaveTypeID(oAtnd)
						Exit For
					End If
				End If
			Next
			GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
		End If
	End Sub

	'Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
	'	If e.Row.RowState = DataControlRowState.Edit Then
	'		Dim oTxt As TextBox = e.Row.FindControl("F_Posted1LeaveTypeID")
	'		If oTxt.Text = "" Then
	'			oTxt.Visible = False
	'		End If
	'		Dim oTxt1 As TextBox = e.Row.FindControl("F_Posted2LeaveTypeID")
	'		If oTxt1.Text = "" Then
	'			oTxt1.Visible = False
	'		End If
	'	End If

	'End Sub
End Class
