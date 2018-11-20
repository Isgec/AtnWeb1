Imports Microsoft.VisualBasic

Public Class RPT_atnLeaveCard
	Inherits SIS.SYS.ReportBase
	Public Overrides Sub ProcessReport()
		Dim Emp As String = Request.QueryString("emp")
		Dim ResignedCase As Boolean = False
		Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(Emp)
		Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		If oEmp.C_DateOfReleaving <> String.Empty Then ResignedCase = True

		Dim oBals As List(Of SIS.ATN.lgLedgerBalance) = SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(oEmp.CardNo)
		If ResignedCase Then
			oBals = SIS.ATN.lgLedgerBalance.FinalizeForResigned(oBals, oEmp.CardNo)
		End If

		Print("<h3><u>Leave Card</u></h3>")
		Print("<h5>As On :" & Now.ToString("d") & "</h5>")
		Print("<h5>Date of Releaving :" & oEmp.C_DateOfReleaving & "</h5>")


		Print("<br />")

		Print("<table style=""width: 100%"">")
		Print("<tr>")

		Print("<td style=""width: 120px;text-align:right"">Employee Name:")
		Print("</td>")

		Print("<td><b>" & oEmp.EmployeeName & " [" & oEmp.CardNo & "]</b>")
		Print("</td>")

		Print("<td style=""width: 120px;text-align:right"">Department:")
		Print("</td>")

		Print("<td><b>" & oEmp.C_DepartmentIDHRM_Departments.Description & "</b>")
		Print("</td>")

		Print("<td style=""width: 120px;text-align:right"">Designation:")
		Print("</td>")

		Print("<td><b>" & oEmp.C_DesignationIDHRM_Designations.Description & "</b>")
		Print("</td>")

		Print("</tr>")
		Dim MayPrint As Boolean = True
		If ResignedCase Then
			If Convert.ToDateTime(oEmp.C_DateOfReleaving, ci).Year <> SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear Then
				Print("<tr>")
				Print("<td colspan=""6"">Pl. change selected year to Employee's last working year.</td>")
				Print("</tr>")
				MayPrint = False
			End If
		End If
		Print("</table>")
		Print("<br />")
		If MayPrint Then
			Print(SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(oBals, Nothing))
		End If
	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
