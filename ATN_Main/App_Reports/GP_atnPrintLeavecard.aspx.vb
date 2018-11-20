Partial Class GP_atnPrintLeavecard
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    'HttpContext.Current.Session("EmployeeUnderProcess") = HttpContext.Current.Session("LoginID")
    div221.InnerHtml = SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(HttpContext.Current.Session("LoginID")))
  End Sub
	Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
		If Session("onContract") = True Then
      'Me.MasterPageFile = "~/MasterCPage.master"
		End If

	End Sub
End Class
