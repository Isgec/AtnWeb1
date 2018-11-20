Partial Class GP_atnAttendanceSheet
	Inherits System.Web.UI.Page
	<System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
 Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
		Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
	End Function
End Class
