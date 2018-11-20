Imports Microsoft.VisualBasic
Public Class RPT_atnFirstPunchAging
	Inherits SIS.SYS.ReportBase
	Public Overrides Sub ProcessReport()
		Dim Dept As Boolean = IIf(Request.QueryString("dept") = "true", True, False)
		If Dept Then
			DepartmentWiseReport()
			Return
		End If

		Dim Loca As Boolean = IIf(Request.QueryString("loca") = "true", True, False)
		If Loca Then
			LocationWiseReport()
			Return
		End If

		Dim FEmp As String = Request.QueryString("femp")
		Dim TEmp As String = Request.QueryString("temp")
		Dim Fdt As String = Request.QueryString("fdt")
		Dim Tdt As String = Request.QueryString("tdt")

		Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		Dim FDate As DateTime = Now
		Dim TDate As DateTime = Now

		If FEmp = "" And TEmp = "" Then
			FEmp = "0001"
			TEmp = "9999"
		End If
		If Fdt = "" And Tdt = "" Then
			FDate = Now.AddDays(-1 * (Now.Day))
			TDate = Now.AddMonths(1).AddDays(-1 * Now.AddMonths(1).Day)
		Else
			FDate = Convert.ToDateTime(Fdt, ci)
			TDate = Convert.ToDateTime(Tdt, ci)
		End If

		Dim cnt1 As Integer = 0
		Dim cnt2 As Integer = 0
		Dim cnt3 As Integer = 0
		Dim cnt4 As Integer = 0
		Dim cnt5 As Integer = 0
		Dim cnt6 As Integer = 0

		Dim tcnt1 As Integer = 0
		Dim tcnt2 As Integer = 0
		Dim tcnt3 As Integer = 0
		Dim tcnt4 As Integer = 0
		Dim tcnt5 As Integer = 0
		Dim tcnt6 As Integer = 0

		Dim pcnt1 As Decimal = 0
		Dim pcnt2 As Decimal = 0
		Dim pcnt3 As Decimal = 0
		Dim pcnt4 As Decimal = 0
		Dim pcnt5 As Decimal = 0
		Dim pcnt6 As Decimal = 0

		Dim ptcnt1 As Decimal = 0
		Dim ptcnt2 As Decimal = 0
		Dim ptcnt3 As Decimal = 0
		Dim ptcnt4 As Decimal = 0
		Dim ptcnt5 As Decimal = 0
		Dim ptcnt6 As Decimal = 0


		Dim dtCtr As Integer = 0
		Dim pnCtr As Integer = 0

		Dim sn As Integer = 0

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Attendance Analysis Summary</u></td></tr></table>")
		Print("</br>")

		Print("<table width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">From Date.:</td>")
		Print("<td style=""font-size: 12px"">" & FDate.ToString("dd/MM/yyyy") & "</td>")
		Print("<td style=""font-size: 12px;font-weight:bold"">To Date:</td>")
		Print("<td style=""font-size: 12px"">" & TDate.ToString("dd/MM/yyyy") & "</td>")
		Print("</tr>")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">From CardNo.:</td>")
		Print("<td style=""font-size: 12px"">" & FEmp & "</td>")
		Print("<td style=""font-size: 12px;font-weight:bold"">To CardNo:</td>")
		Print("<td style=""font-size: 12px"">" & TEmp & "</td>")
		Print("</tr>")

		Print("</table>")

		Print("</br>")
		Print("</br>")

		Print("<table border=""1"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top"" rowspan=""2"">S.N.</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">DATE</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&lt;= 09:15</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:16 TO 09:30</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:31 TO 10:30</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&gt; 10:30</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">FP</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">TS</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" rowspan=""2"">TOTAL</td>")
		Print("</tr>")
		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
		Print("</tr>")


		Dim Ldate As String = ""
		Dim oAtnds As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDateRange(FEmp, TEmp, FDate, TDate, "Summary")
		For Each oAt As SIS.ATN.atnNewAttendance In oAtnds
			If Ldate = "" Then
				Ldate = oAt.AttenDate
			End If

			If Ldate <> oAt.AttenDate Then
				'Print Line
				'Add To Totals
				'Init sTots

				dtCtr += 1

				pcnt1 = (cnt1 / pnCtr) * 100
				pcnt2 = (cnt2 / pnCtr) * 100
				pcnt3 = (cnt3 / pnCtr) * 100
				pcnt4 = (cnt4 / pnCtr) * 100
				pcnt5 = (cnt5 / pnCtr) * 100
				pcnt6 = (cnt6 / pnCtr) * 100



				sn += 1
				Print("<tr>")
				Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
				Print("<td>" & Ldate & "</td>")
				Print("<td style=""text-align:center"">" & cnt1 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt1.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt2 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt2.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt3 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt3.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt4 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt4.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt5 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt5.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt6 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt6.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & pnCtr & "</td>")
				Print("</tr>")

				tcnt1 += cnt1
				tcnt2 += cnt2
				tcnt3 += cnt3
				tcnt4 += cnt4
				tcnt5 += cnt5
				tcnt6 += cnt6

				cnt1 = 0
				cnt2 = 0
				cnt3 = 0
				cnt4 = 0
				cnt5 = 0
				cnt6 = 0

				ptcnt1 += pcnt1
				ptcnt2 += pcnt2
				ptcnt3 += pcnt3
				ptcnt4 += pcnt4
				ptcnt5 += pcnt5
				ptcnt6 += pcnt6

				pcnt1 = 0
				pcnt2 = 0
				pcnt3 = 0
				pcnt4 = 0
				pcnt5 = 0
				pcnt6 = 0



				pnCtr = 0

				Ldate = oAt.AttenDate
			End If


			With oAt
				If Convert.ToDecimal(.Punch2Time) = 0 Then
					cnt5 += 1
				End If
				If .PunchStatusID = "TS" Then
					cnt6 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) <= 9.15 Then
					cnt1 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 9.15 And Convert.ToDecimal(.Punch1Time) <= 9.3 Then
					cnt2 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 9.3 And Convert.ToDecimal(.Punch1Time) <= 10.3 Then
					cnt3 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 10.3 Then
					cnt4 += 1
				End If
			End With

			pnCtr += 1
		Next

		dtCtr += 1

		pcnt1 = (cnt1 / pnCtr) * 100
		pcnt2 = (cnt2 / pnCtr) * 100
		pcnt3 = (cnt3 / pnCtr) * 100
		pcnt4 = (cnt4 / pnCtr) * 100
		pcnt5 = (cnt5 / pnCtr) * 100
		pcnt6 = (cnt6 / pnCtr) * 100



		sn += 1
		Print("<tr>")
		Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
		Print("<td>" & Ldate & "</td>")
		Print("<td style=""text-align:center"">" & cnt1 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt1.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt2 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt2.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt3 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt3.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt4 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt4.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt5 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt5.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt6 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt6.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & pnCtr & "</td>")
		Print("</tr>")

		tcnt1 += cnt1
		tcnt2 += cnt2
		tcnt3 += cnt3
		tcnt4 += cnt4
		tcnt5 += cnt5
		tcnt6 += cnt6

		ptcnt1 += pcnt1
		ptcnt2 += pcnt2
		ptcnt3 += pcnt3
		ptcnt4 += pcnt4
		ptcnt5 += pcnt5
		ptcnt6 += pcnt6


		Print("<tr>")
		Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
		Print("<td><b>TOTAL</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt1 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt1.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt2 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt2.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt3 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt3.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt4 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt4.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt5 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt5.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt6 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt6.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center"">&nbsp;</td>")
		Print("</tr>")

		Print("<tr>")
		Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
		Print("<td><b>AVG</b></td>")
		Print("<td style=""text-align:center"">" & (tcnt1 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt1 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt2 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt2 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt3 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt3 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt4 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt4 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt5 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt5 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt6 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt6 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">&nbsp;</td>")
		Print("</tr>")


		Print("</table>")

	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
	Private Sub DepartmentWiseReport()
		Dim FEmp As String = Request.QueryString("femp")
		Dim TEmp As String = Request.QueryString("temp")
		Dim Fdt As String = Request.QueryString("fdt")
		Dim Tdt As String = Request.QueryString("tdt")

		Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		Dim FDate As DateTime = Now
		Dim TDate As DateTime = Now

		If FEmp = "" And TEmp = "" Then
			FEmp = "0001"
			TEmp = "9999"
		End If
		If Fdt = "" And Tdt = "" Then
			FDate = Now.AddDays(-1 * (Now.Day))
			TDate = Now.AddMonths(1).AddDays(-1 * Now.AddMonths(1).Day)
		Else
			FDate = Convert.ToDateTime(Fdt, ci)
			TDate = Convert.ToDateTime(Tdt, ci)
		End If

		Dim cnt1 As Integer = 0
		Dim cnt2 As Integer = 0
		Dim cnt3 As Integer = 0
		Dim cnt4 As Integer = 0
		Dim cnt5 As Integer = 0
		Dim cnt6 As Integer = 0

		Dim tcnt1 As Integer = 0
		Dim tcnt2 As Integer = 0
		Dim tcnt3 As Integer = 0
		Dim tcnt4 As Integer = 0
		Dim tcnt5 As Integer = 0
		Dim tcnt6 As Integer = 0

		Dim pcnt1 As Decimal = 0
		Dim pcnt2 As Decimal = 0
		Dim pcnt3 As Decimal = 0
		Dim pcnt4 As Decimal = 0
		Dim pcnt5 As Decimal = 0
		Dim pcnt6 As Decimal = 0

		Dim ptcnt1 As Decimal = 0
		Dim ptcnt2 As Decimal = 0
		Dim ptcnt3 As Decimal = 0
		Dim ptcnt4 As Decimal = 0
		Dim ptcnt5 As Decimal = 0
		Dim ptcnt6 As Decimal = 0


		Dim dtCtr As Integer = 0
		Dim pnCtr As Integer = 0

		Dim sn As Integer = 0

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Attendance Analysis Department wise Summary</u></td></tr></table>")
		Print("</br>")

		Print("<table width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">From Date.:</td>")
		Print("<td style=""font-size: 12px"">" & FDate.ToString("dd/MM/yyyy") & "</td>")
		Print("<td style=""font-size: 12px;font-weight:bold"">To Date:</td>")
		Print("<td style=""font-size: 12px"">" & TDate.ToString("dd/MM/yyyy") & "</td>")
		Print("</tr>")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">From CardNo.:</td>")
		Print("<td style=""font-size: 12px"">" & FEmp & "</td>")
		Print("<td style=""font-size: 12px;font-weight:bold"">To CardNo:</td>")
		Print("<td style=""font-size: 12px"">" & TEmp & "</td>")
		Print("</tr>")

		Print("</table>")

		Print("</br>")
		Print("</br>")


		Dim LDept As String = ""
		Dim Ldate As String = ""
		Dim DeptChanged As Boolean = False
		Dim oAtnds As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.GetAttendanceByCardNoDateRange(FEmp, TEmp, FDate, TDate, "DepartmentWiseSummary")
		For Each oAt As SIS.ATN.atnProcessedPunch In oAtnds
			If Ldate = "" Then
				Ldate = oAt.AttenDate


				Print("<table border=""1"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")


				Dim oDept As SIS.ATN.hrmDepartments = SIS.ATN.hrmDepartments.GetByID(oAt.CardNoHRM_Employees.C_DepartmentID)
				Print("<tr>")
				If Not oDept Is Nothing Then
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""13"">" & oDept.Description & "</td>")
				Else
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""13"">N/A</td>")
				End If
				Print("</tr>")
				LDept = oAt.CardNoHRM_Employees.C_DepartmentID


				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top"" rowspan=""2"">S.N.</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">DATE</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&lt;= 09:15</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:16 TO 09:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:31 TO 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&gt; 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">FP</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">TS</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" rowspan=""2"">TOTAL</td>")
				Print("</tr>")
				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("</tr>")


			End If

			If LDept <> oAt.CardNoHRM_Employees.C_DepartmentID Then
				DeptChanged = True
			End If

			If Ldate <> oAt.AttenDate Or DeptChanged Then

				dtCtr += 1

				pcnt1 = (cnt1 / pnCtr) * 100
				pcnt2 = (cnt2 / pnCtr) * 100
				pcnt3 = (cnt3 / pnCtr) * 100
				pcnt4 = (cnt4 / pnCtr) * 100
				pcnt5 = (cnt5 / pnCtr) * 100
				pcnt6 = (cnt6 / pnCtr) * 100



				sn += 1
				Print("<tr>")
				Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
				Print("<td>" & Ldate & "</td>")
				Print("<td style=""text-align:center"">" & cnt1 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt1.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt2 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt2.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt3 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt3.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt4 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt4.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt5 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt5.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt6 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt6.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & pnCtr & "</td>")
				Print("</tr>")

				tcnt1 += cnt1
				tcnt2 += cnt2
				tcnt3 += cnt3
				tcnt4 += cnt4
				tcnt5 += cnt5
				tcnt6 += cnt6

				cnt1 = 0
				cnt2 = 0
				cnt3 = 0
				cnt4 = 0
				cnt5 = 0
				cnt6 = 0

				ptcnt1 += pcnt1
				ptcnt2 += pcnt2
				ptcnt3 += pcnt3
				ptcnt4 += pcnt4
				ptcnt5 += pcnt5
				ptcnt6 += pcnt6

				pcnt1 = 0
				pcnt2 = 0
				pcnt3 = 0
				pcnt4 = 0
				pcnt5 = 0
				pcnt6 = 0



				pnCtr = 0

				Ldate = oAt.AttenDate
			End If

			If DeptChanged Then


				Print("<tr>")
				Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
				Print("<td><b>TOTAL</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt1 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt1.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt2 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt2.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt3 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt3.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt4 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt4.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt5 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt5.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt6 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt6.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center"">&nbsp;</td>")
				Print("</tr>")

				Print("<tr>")
				Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
				Print("<td><b>AVG</b></td>")
				Print("<td style=""text-align:center"">" & (tcnt1 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt1 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt2 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt2 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt3 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt3 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt4 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt4 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt5 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt5 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt6 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt6 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">&nbsp;</td>")
				Print("</tr>")

				tcnt1 = 0
				tcnt2 = 0
				tcnt3 = 0
				tcnt4 = 0
				tcnt5 = 0
				tcnt6 = 0

				ptcnt1 = 0
				ptcnt2 = 0
				ptcnt3 = 0
				ptcnt4 = 0
				ptcnt5 = 0
				ptcnt6 = 0


				dtCtr = 0

				sn = 0
				DeptChanged = False


				Print("</table>")


				Print("</br>")

				Print("<table border=""1"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")

				Dim oDept As SIS.ATN.hrmDepartments = SIS.ATN.hrmDepartments.GetByID(oAt.CardNoHRM_Employees.C_DepartmentID)
				Print("<tr>")
				If Not oDept Is Nothing Then
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""13"">" & oDept.Description & "</td>")
				Else
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""13"">N/A</td>")
				End If
				Print("</tr>")
				LDept = oAt.CardNoHRM_Employees.C_DepartmentID



				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top"" rowspan=""2"">S.N.</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">DATE</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&lt;= 09:15</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:16 TO 09:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:31 TO 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&gt; 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">FP</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">TS</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" rowspan=""2"">TOTAL</td>")
				Print("</tr>")
				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("</tr>")


			End If

			With oAt
				If Convert.ToDecimal(.Punch2Time) = 0 Then
					cnt5 += 1
				End If
				If .PunchStatusID = "TS" Then
					cnt6 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) <= 9.15 Then
					cnt1 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 9.15 And Convert.ToDecimal(.Punch1Time) <= 9.3 Then
					cnt2 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 9.3 And Convert.ToDecimal(.Punch1Time) <= 10.3 Then
					cnt3 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 10.3 Then
					cnt4 += 1
				End If
			End With

			pnCtr += 1
		Next

		dtCtr += 1

		pcnt1 = (cnt1 / pnCtr) * 100
		pcnt2 = (cnt2 / pnCtr) * 100
		pcnt3 = (cnt3 / pnCtr) * 100
		pcnt4 = (cnt4 / pnCtr) * 100
		pcnt5 = (cnt5 / pnCtr) * 100
		pcnt6 = (cnt6 / pnCtr) * 100



		sn += 1
		Print("<tr>")
		Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
		Print("<td>" & Ldate & "</td>")
		Print("<td style=""text-align:center"">" & cnt1 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt1.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt2 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt2.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt3 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt3.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt4 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt4.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt5 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt5.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt6 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt6.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & pnCtr & "</td>")
		Print("</tr>")

		tcnt1 += cnt1
		tcnt2 += cnt2
		tcnt3 += cnt3
		tcnt4 += cnt4
		tcnt5 += cnt5
		tcnt6 += cnt6

		ptcnt1 += pcnt1
		ptcnt2 += pcnt2
		ptcnt3 += pcnt3
		ptcnt4 += pcnt4
		ptcnt5 += pcnt5
		ptcnt6 += pcnt6


		Print("<tr>")
		Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
		Print("<td><b>TOTAL</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt1 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt1.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt2 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt2.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt3 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt3.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt4 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt4.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt5 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt5.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt6 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt6.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center"">&nbsp;</td>")
		Print("</tr>")

		Print("<tr>")
		Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
		Print("<td><b>AVG</b></td>")
		Print("<td style=""text-align:center"">" & (tcnt1 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt1 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt2 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt2 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt3 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt3 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt4 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt4 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt5 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt5 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt6 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt6 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">&nbsp;</td>")
		Print("</tr>")


		Print("</table>")

	End Sub
	Private Sub LocationWiseReport()
		Dim FEmp As String = Request.QueryString("femp")
		Dim TEmp As String = Request.QueryString("temp")
		Dim Fdt As String = Request.QueryString("fdt")
		Dim Tdt As String = Request.QueryString("tdt")

		Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		Dim FDate As DateTime = Now
		Dim TDate As DateTime = Now

		If FEmp = "" And TEmp = "" Then
			FEmp = "0001"
			TEmp = "9999"
		End If
		If Fdt = "" And Tdt = "" Then
			FDate = Now.AddDays(-1 * (Now.Day))
			TDate = Now.AddMonths(1).AddDays(-1 * Now.AddMonths(1).Day)
		Else
			FDate = Convert.ToDateTime(Fdt, ci)
			TDate = Convert.ToDateTime(Tdt, ci)
		End If

		Dim cnt1 As Integer = 0
		Dim cnt2 As Integer = 0
		Dim cnt3 As Integer = 0
		Dim cnt4 As Integer = 0
		Dim cnt5 As Integer = 0
		Dim cnt6 As Integer = 0

		Dim tcnt1 As Integer = 0
		Dim tcnt2 As Integer = 0
		Dim tcnt3 As Integer = 0
		Dim tcnt4 As Integer = 0
		Dim tcnt5 As Integer = 0
		Dim tcnt6 As Integer = 0

		Dim pcnt1 As Decimal = 0
		Dim pcnt2 As Decimal = 0
		Dim pcnt3 As Decimal = 0
		Dim pcnt4 As Decimal = 0
		Dim pcnt5 As Decimal = 0
		Dim pcnt6 As Decimal = 0

		Dim ptcnt1 As Decimal = 0
		Dim ptcnt2 As Decimal = 0
		Dim ptcnt3 As Decimal = 0
		Dim ptcnt4 As Decimal = 0
		Dim ptcnt5 As Decimal = 0
		Dim ptcnt6 As Decimal = 0


		Dim dtCtr As Integer = 0
		Dim pnCtr As Integer = 0

		Dim sn As Integer = 0

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Attendance Analysis Location Wise Summary</u></td></tr></table>")
		Print("</br>")

		Print("<table width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">From Date.:</td>")
		Print("<td style=""font-size: 12px"">" & FDate.ToString("dd/MM/yyyy") & "</td>")
		Print("<td style=""font-size: 12px;font-weight:bold"">To Date:</td>")
		Print("<td style=""font-size: 12px"">" & TDate.ToString("dd/MM/yyyy") & "</td>")
		Print("</tr>")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">From CardNo.:</td>")
		Print("<td style=""font-size: 12px"">" & FEmp & "</td>")
		Print("<td style=""font-size: 12px;font-weight:bold"">To CardNo:</td>")
		Print("<td style=""font-size: 12px"">" & TEmp & "</td>")
		Print("</tr>")

		Print("</table>")

		Print("</br>")
		Print("</br>")


		Dim LOfic As String = ""
		Dim Ldate As String = ""
		Dim OficChanged As Boolean = False
		Dim oAtnds As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.GetAttendanceByCardNoDateRange(FEmp, TEmp, FDate, TDate, "OfficeWiseSummary")
		For Each oAt As SIS.ATN.atnProcessedPunch In oAtnds
			If Ldate = "" Then
				Ldate = oAt.AttenDate


				Print("<table border=""1"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")


				Dim oOfic As SIS.ATN.hrmOffices = SIS.ATN.hrmOffices.GetByID(oAt.CardNoHRM_Employees.C_OfficeID)
				Print("<tr>")
				If Not oOfic Is Nothing Then
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""13"">" & oOfic.Description & "</td>")
				Else
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""13"">N/A</td>")
				End If
				Print("</tr>")
				LOfic = oAt.CardNoHRM_Employees.C_OfficeID


				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top"" rowspan=""2"">S.N.</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">DATE</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&lt;= 09:15</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:16 TO 09:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:31 TO 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&gt; 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">FP</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">TS</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" rowspan=""2"">TOTAL</td>")
				Print("</tr>")
				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("</tr>")


			End If

			If LOfic <> oAt.CardNoHRM_Employees.C_OfficeID Then
				OficChanged = True
			End If

			If Ldate <> oAt.AttenDate Or OficChanged Then

				dtCtr += 1

				pcnt1 = (cnt1 / pnCtr) * 100
				pcnt2 = (cnt2 / pnCtr) * 100
				pcnt3 = (cnt3 / pnCtr) * 100
				pcnt4 = (cnt4 / pnCtr) * 100
				pcnt5 = (cnt5 / pnCtr) * 100
				pcnt6 = (cnt6 / pnCtr) * 100



				sn += 1
				Print("<tr>")
				Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
				Print("<td>" & Ldate & "</td>")
				Print("<td style=""text-align:center"">" & cnt1 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt1.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt2 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt2.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt3 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt3.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt4 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt4.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt5 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt5.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & cnt6 & "</td>")
				Print("<td style=""text-align:center"">" & pcnt6.ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & pnCtr & "</td>")
				Print("</tr>")

				tcnt1 += cnt1
				tcnt2 += cnt2
				tcnt3 += cnt3
				tcnt4 += cnt4
				tcnt5 += cnt5
				tcnt6 += cnt6

				cnt1 = 0
				cnt2 = 0
				cnt3 = 0
				cnt4 = 0
				cnt5 = 0
				cnt6 = 0

				ptcnt1 += pcnt1
				ptcnt2 += pcnt2
				ptcnt3 += pcnt3
				ptcnt4 += pcnt4
				ptcnt5 += pcnt5
				ptcnt6 += pcnt6

				pcnt1 = 0
				pcnt2 = 0
				pcnt3 = 0
				pcnt4 = 0
				pcnt5 = 0
				pcnt6 = 0



				pnCtr = 0

				Ldate = oAt.AttenDate
			End If

			If OficChanged Then


				Print("<tr>")
				Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
				Print("<td><b>TOTAL</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt1 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt1.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt2 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt2.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt3 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt3.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt4 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt4.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt5 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt5.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center""><b>" & tcnt6 & "</b></td>")
				Print("<td style=""text-align:center""><b>" & ptcnt6.ToString("n") & "</b></td>")
				Print("<td style=""text-align:center"">&nbsp;</td>")
				Print("</tr>")

				Print("<tr>")
				Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
				Print("<td><b>AVG</b></td>")
				Print("<td style=""text-align:center"">" & (tcnt1 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt1 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt2 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt2 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt3 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt3 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt4 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt4 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt5 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt5 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (tcnt6 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">" & (ptcnt6 / dtCtr).ToString("n") & "</td>")
				Print("<td style=""text-align:center"">&nbsp;</td>")
				Print("</tr>")

				tcnt1 = 0
				tcnt2 = 0
				tcnt3 = 0
				tcnt4 = 0
				tcnt5 = 0
				tcnt6 = 0

				ptcnt1 = 0
				ptcnt2 = 0
				ptcnt3 = 0
				ptcnt4 = 0
				ptcnt5 = 0
				ptcnt6 = 0


				dtCtr = 0

				sn = 0
				OficChanged = False


				Print("</table>")


				Print("</br>")

				Print("<table border=""1"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")

				Dim oOfic As SIS.ATN.hrmOffices = SIS.ATN.hrmOffices.GetByID(oAt.CardNoHRM_Employees.C_OfficeID)
				Print("<tr>")
				If Not oOfic Is Nothing Then
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""13"">" & oOfic.Description & "</td>")
				Else
					Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""13"">N/A</td>")
				End If
				Print("</tr>")
				LOfic = oAt.CardNoHRM_Employees.C_OfficeID



				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top"" rowspan=""2"">S.N.</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">DATE</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&lt;= 09:15</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:16 TO 09:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">09:31 TO 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" colspan=""2"">&gt; 10:30</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">FP</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2"">TS</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" rowspan=""2"">TOTAL</td>")
				Print("</tr>")
				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">Count</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:30px;vertical-align: top"">%</td>")
				Print("</tr>")


			End If

			With oAt
				If Convert.ToDecimal(.Punch2Time) = 0 Then
					cnt5 += 1
				End If
				If .PunchStatusID = "TS" Then
					cnt6 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) <= 9.15 Then
					cnt1 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 9.15 And Convert.ToDecimal(.Punch1Time) <= 9.3 Then
					cnt2 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 9.3 And Convert.ToDecimal(.Punch1Time) <= 10.3 Then
					cnt3 += 1
				ElseIf Convert.ToDecimal(.Punch1Time) > 10.3 Then
					cnt4 += 1
				End If
			End With

			pnCtr += 1
		Next

		dtCtr += 1

		pcnt1 = (cnt1 / pnCtr) * 100
		pcnt2 = (cnt2 / pnCtr) * 100
		pcnt3 = (cnt3 / pnCtr) * 100
		pcnt4 = (cnt4 / pnCtr) * 100
		pcnt5 = (cnt5 / pnCtr) * 100
		pcnt6 = (cnt6 / pnCtr) * 100



		sn += 1
		Print("<tr>")
		Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
		Print("<td>" & Ldate & "</td>")
		Print("<td style=""text-align:center"">" & cnt1 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt1.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt2 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt2.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt3 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt3.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt4 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt4.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt5 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt5.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & cnt6 & "</td>")
		Print("<td style=""text-align:center"">" & pcnt6.ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & pnCtr & "</td>")
		Print("</tr>")

		tcnt1 += cnt1
		tcnt2 += cnt2
		tcnt3 += cnt3
		tcnt4 += cnt4
		tcnt5 += cnt5
		tcnt6 += cnt6

		ptcnt1 += pcnt1
		ptcnt2 += pcnt2
		ptcnt3 += pcnt3
		ptcnt4 += pcnt4
		ptcnt5 += pcnt5
		ptcnt6 += pcnt6


		Print("<tr>")
		Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
		Print("<td><b>TOTAL</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt1 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt1.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt2 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt2.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt3 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt3.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt4 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt4.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt5 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt5.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center""><b>" & tcnt6 & "</b></td>")
		Print("<td style=""text-align:center""><b>" & ptcnt6.ToString("n") & "</b></td>")
		Print("<td style=""text-align:center"">&nbsp;</td>")
		Print("</tr>")

		Print("<tr>")
		Print("<td style=""text-align:right;height:20px"">&nbsp;</td>")
		Print("<td><b>AVG</b></td>")
		Print("<td style=""text-align:center"">" & (tcnt1 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt1 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt2 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt2 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt3 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt3 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt4 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt4 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt5 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt5 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (tcnt6 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">" & (ptcnt6 / dtCtr).ToString("n") & "</td>")
		Print("<td style=""text-align:center"">&nbsp;</td>")
		Print("</tr>")


		Print("</table>")

	End Sub
End Class
