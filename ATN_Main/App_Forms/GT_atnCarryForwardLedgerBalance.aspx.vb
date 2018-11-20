Partial Class GT_atnCarryForwardLedgerBalance
	Inherits System.Web.UI.Page
	Protected Sub cmdIndividual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIndividual.Click
		Dim LastTimeOut As Integer = 60
    Dim oSM As ScriptManager = Me.Master.FindControl("ToolkitScriptManager1")
		If Not oSM Is Nothing Then
			LastTimeOut = oSM.AsyncPostBackTimeout
			oSM.AsyncPostBackTimeout = 1200
		End If
		Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
		HttpContext.Current.Server.ScriptTimeout = 1200
		Dim obt As New SIS.SYS.Utilities.BalanceTransfer
		If F_FEmp.Text <> "" Then
			If F_FEmp.Text = F_TEmp.Text Then
				obt.Transfer(F_FEmp.Text, SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear())
			Else
				obt.Transfer(F_FEmp.Text, F_TEmp.Text, SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear())
			End If
		End If
		If Not oSM Is Nothing Then
			oSM.AsyncPostBackTimeout = LastTimeOut
		End If
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
	End Sub
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim SelectedFinYear As Integer = Convert.ToInt32(Session("FinYear"))
		Dim ActiveFinYear As Integer = SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear()
		cmdIndividual.Enabled = False
		If ActiveFinYear - 1 = SelectedFinYear Then
			cmdIndividual.Enabled = True
		End If
		F_FinYear.Text = SelectedFinYear
		T_FinYear.Text = ActiveFinYear
	End Sub
End Class
