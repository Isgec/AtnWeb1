Partial Class LC_LeaveCard
	Inherits System.Web.UI.UserControl
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
		If HttpContext.Current.Session("EmployeeUnderProcess") IsNot Nothing Then
			CTL_LeaveCard.ToolTip = HttpContext.Current.Session("EmployeeUnderProcess")
		End If
		If CTL_LeaveCard.ToolTip = "" Then
			CTL_LeaveCard.ToolTip = HttpContext.Current.Session("LoginID")
		End If
	End Sub
End Class
