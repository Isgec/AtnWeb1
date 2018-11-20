Imports Microsoft.VisualBasic
Public Class RPT_atnFirstPunchAgingDetail
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

		Dim Chk1 As String = Request.QueryString("chk1")
		Dim Chk2 As String = Request.QueryString("chk2")
		Dim Chk3 As String = Request.QueryString("chk3")
		Dim Chk4 As String = Request.QueryString("chk4")
		Dim Chk5 As String = Request.QueryString("chk5")
		Dim Chk6 As String = Request.QueryString("chk6")

		Dim chk As Integer = 1

		If Chk6 = "true" Then chk = 6
		If Chk5 = "true" Then chk = 5
		If Chk4 = "true" Then chk = 4
		If Chk3 = "true" Then chk = 3
		If Chk2 = "true" Then chk = 2
		If Chk1 = "true" Then chk = 1

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

		Dim sn As Integer = 0

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Attendance Analysis Detail</u></td></tr></table>")
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

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">Option :</td>")
		Select Case chk
			Case 1
				Print("<td style=""font-size: 12px"">&lt;= 09:15</td>")
			Case 2
				Print("<td style=""font-size: 12px"">09:16 TO 09:30</td>")
			Case 3
				Print("<td style=""font-size: 12px"">09:31 TO 10:30</td>")
			Case 4
				Print("<td style=""font-size: 12px"">&gt; 10:30</td>")
			Case 5
				Print("<td style=""font-size: 12px"">FP</td>")
			Case 6
				Print("<td style=""font-size: 12px"">TS</td>")
		End Select
		Print("<td style=""font-size: 12px;font-weight:bold"">&nbsp;</td>")
		Print("<td style=""font-size: 12px"">&nbsp;</td>")
		Print("</tr>")

		Print("</table>")

		Print("</br>")
		Print("</br>")

		Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
		If chk = 6 Then
			Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">Ist PUNCH</td>")
			Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">IInd PUNCH</td>")
		Else
			Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">PUNCH TIME</td>")
		End If
		Print("</tr>")


		Dim oEmp As SIS.ATN.atnEmployees = Nothing
		Dim Printed As Boolean = False
		Dim oAtnds As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDateRange(FEmp, TEmp, FDate, TDate, "Detail")
		For Each oAt As SIS.ATN.atnNewAttendance In oAtnds
			If oEmp Is Nothing Then
				oEmp = SIS.ATN.atnEmployees.GetByID(oAt.CardNo)
			End If

			If oEmp.CardNo <> oAt.CardNo Then
				Printed = False
				oEmp = SIS.ATN.atnEmployees.GetByID(oAt.CardNo)
			End If

			Dim MayPrint As Boolean = False

			Select Case chk
				Case 1
					If Convert.ToDecimal(oAt.Punch1Time) <= 9.15 Then
						MayPrint = True
					End If
				Case 2
					If Convert.ToDecimal(oAt.Punch1Time) > 9.15 And Convert.ToDecimal(oAt.Punch1Time) <= 9.3 Then
						MayPrint = True
					End If
				Case 3
					If Convert.ToDecimal(oAt.Punch1Time) > 9.3 And Convert.ToDecimal(oAt.Punch1Time) <= 10.3 Then
						MayPrint = True
					End If
				Case 4
					If Convert.ToDecimal(oAt.Punch1Time) > 10.3 Then
						MayPrint = True
					End If
				Case 5
					If Convert.ToDecimal(oAt.Punch2Time) = 0 Then
						MayPrint = True
					End If
				Case 6
					If oAt.PunchStatusID = "TS" Then
						MayPrint = True
					End If
			End Select
			If MayPrint Then
				If Not Printed Then
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right;padding-right: 8px"">" & sn.ToString & "</td>")
					Print("<td>" & oEmp.CardNo & "</td>")
					Print("<td style=""text-align:left"">" & oEmp.EmployeeName & "</td>")
					Print("<td style=""text-align:left"">" & oAt.AttenDate & "</td>")
					If chk = 6 Then
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
						Print("<td style=""text-align:right"">" & oAt.Punch2Time & "</td>")
					Else
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
					End If
					Print("</tr>")
					Printed = True
				Else
					Print("<tr>")
					Print("<td style=""text-align:right"">&nbsp;</td>")
					Print("<td>&nbsp;</td>")
					Print("<td style=""text-align:center"">&nbsp;</td>")
					Print("<td style=""text-align:left"">" & oAt.AttenDate & "</td>")
					If chk = 6 Then
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
						Print("<td style=""text-align:right"">" & oAt.Punch2Time & "</td>")
					Else
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
					End If
					Print("</tr>")
				End If
			End If
		Next
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

		Dim Chk1 As String = Request.QueryString("chk1")
		Dim Chk2 As String = Request.QueryString("chk2")
		Dim Chk3 As String = Request.QueryString("chk3")
		Dim Chk4 As String = Request.QueryString("chk4")
		Dim Chk5 As String = Request.QueryString("chk5")
		Dim Chk6 As String = Request.QueryString("chk6")

		Dim chk As Integer = 1

		If Chk6 = "true" Then chk = 6
		If Chk5 = "true" Then chk = 5
		If Chk4 = "true" Then chk = 4
		If Chk3 = "true" Then chk = 3
		If Chk2 = "true" Then chk = 2
		If Chk1 = "true" Then chk = 1

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

		Dim sn As Integer = 0

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Attendance Analysis Department Wise Detail</u></td></tr></table>")
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

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">Option :</td>")
		Select Case chk
			Case 1
				Print("<td style=""font-size: 12px"">&lt;= 09:15</td>")
			Case 2
				Print("<td style=""font-size: 12px"">09:16 TO 09:30</td>")
			Case 3
				Print("<td style=""font-size: 12px"">09:31 TO 10:30</td>")
			Case 4
				Print("<td style=""font-size: 12px"">&gt; 10:30</td>")
			Case 5
				Print("<td style=""font-size: 12px"">FP</td>")
			Case 6
				Print("<td style=""font-size: 12px"">TS</td>")
		End Select
		Print("<td style=""font-size: 12px;font-weight:bold"">&nbsp;</td>")
		Print("<td style=""font-size: 12px"">&nbsp;</td>")
		Print("</tr>")

		Print("</table>")

		Print("</br>")



		Dim oEmp As SIS.ATN.atnEmployees = Nothing
		Dim LDept As String = "*"
		Dim Lname As String = ""
		Dim Printed As Boolean = False
		Dim oAtnds As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.GetAttendanceByCardNoDateRange(FEmp, TEmp, FDate, TDate, "DepartmentWiseDetail")
		For Each oAt As SIS.ATN.atnProcessedPunch In oAtnds
			oEmp = oAt.CardNoHRM_Employees

			If LDept <> oEmp.C_DepartmentID Then
				If LDept <> "*" Then
					Print("</table>")
				End If

				sn = 0
				Print("</br>")
				Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
				Dim oDept As SIS.ATN.hrmDepartments = SIS.ATN.hrmDepartments.GetByID(oEmp.C_DepartmentID)
				Print("<tr>")
				If chk <> "6" Then
					If Not oDept Is Nothing Then
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""4"">" & oDept.Description & "</td>")
					Else
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""4"">N/A</td>")
					End If
				Else
					If Not oDept Is Nothing Then
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""5"">" & oDept.Description & "</td>")
					Else
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Department : </b></td><td colspan=""5"">N/A</td>")
					End If
				End If
				Print("</tr>")
				LDept = oEmp.C_DepartmentID

				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
				If chk = 6 Then
					Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">Ist PUNCH</td>")
					Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">IInd PUNCH</td>")
				Else
					Print("<td style=""font-size:12px;font-weight:bold;width:90px;vertical-align: top;text-align:right"">PUNCH TIME</td>")
				End If
				Print("</tr>")
			End If

			If Lname <> oEmp.EmployeeName Then
				Printed = False
				Lname = oEmp.EmployeeName
			End If

			Dim MayPrint As Boolean = False

			Select Case chk
				Case 1
					If Convert.ToDecimal(oAt.Punch1Time) <= 9.15 Then
						MayPrint = True
					End If
				Case 2
					If Convert.ToDecimal(oAt.Punch1Time) > 9.15 And Convert.ToDecimal(oAt.Punch1Time) <= 9.3 Then
						MayPrint = True
					End If
				Case 3
					If Convert.ToDecimal(oAt.Punch1Time) > 9.3 And Convert.ToDecimal(oAt.Punch1Time) <= 10.3 Then
						MayPrint = True
					End If
				Case 4
					If Convert.ToDecimal(oAt.Punch1Time) > 10.3 Then
						MayPrint = True
					End If
				Case 5
					If Convert.ToDecimal(oAt.Punch2Time) = 0 Then
						MayPrint = True
					End If
				Case 6
					If oAt.PunchStatusID = "TS" Then
						MayPrint = True
					End If
			End Select
			If MayPrint Then
				If Not Printed Then
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right;padding-right: 8px"">" & sn.ToString & "</td>")
					Print("<td>" & oEmp.CardNo & "</td>")
					Print("<td style=""text-align:left"">" & oEmp.EmployeeName & "</td>")
					Print("<td style=""text-align:left"">" & oAt.AttenDate & "</td>")
					If chk = 6 Then
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
						Print("<td style=""text-align:right"">" & oAt.Punch2Time & "</td>")
					Else
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
					End If
					Print("</tr>")
					Printed = True
				Else
					Print("<tr>")
					Print("<td style=""text-align:right"">&nbsp;</td>")
					Print("<td>&nbsp;</td>")
					Print("<td style=""text-align:center"">&nbsp;</td>")
					Print("<td style=""text-align:left"">" & oAt.AttenDate & "</td>")
					If chk = 6 Then
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
						Print("<td style=""text-align:right"">" & oAt.Punch2Time & "</td>")
					Else
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
					End If
					Print("</tr>")
				End If
			End If
		Next

		Print("</table>")

	End Sub
	Private Sub LocationWiseReport()
		Dim FEmp As String = Request.QueryString("femp")
		Dim TEmp As String = Request.QueryString("temp")
		Dim Fdt As String = Request.QueryString("fdt")
		Dim Tdt As String = Request.QueryString("tdt")

		Dim Chk1 As String = Request.QueryString("chk1")
		Dim Chk2 As String = Request.QueryString("chk2")
		Dim Chk3 As String = Request.QueryString("chk3")
		Dim Chk4 As String = Request.QueryString("chk4")
		Dim Chk5 As String = Request.QueryString("chk5")
		Dim Chk6 As String = Request.QueryString("chk6")

		Dim chk As Integer = 1

		If Chk6 = "true" Then chk = 6
		If Chk5 = "true" Then chk = 5
		If Chk4 = "true" Then chk = 4
		If Chk3 = "true" Then chk = 3
		If Chk2 = "true" Then chk = 2
		If Chk1 = "true" Then chk = 1

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

		Dim sn As Integer = 0

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Attendance Analysis Location Wise Detail</u></td></tr></table>")
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

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">Option :</td>")
		Select Case chk
			Case 1
				Print("<td style=""font-size: 12px"">&lt;= 09:15</td>")
			Case 2
				Print("<td style=""font-size: 12px"">09:16 TO 09:30</td>")
			Case 3
				Print("<td style=""font-size: 12px"">09:31 TO 10:30</td>")
			Case 4
				Print("<td style=""font-size: 12px"">&gt; 10:30</td>")
			Case 5
				Print("<td style=""font-size: 12px"">FP</td>")
			Case 6
				Print("<td style=""font-size: 12px"">TS</td>")
		End Select
		Print("<td style=""font-size: 12px;font-weight:bold"">&nbsp;</td>")
		Print("<td style=""font-size: 12px"">&nbsp;</td>")
		Print("</tr>")

		Print("</table>")

		Print("</br>")



		Dim oEmp As SIS.ATN.atnEmployees = Nothing
		Dim LOfic As String = "*"
		Dim Lname As String = ""
		Dim Printed As Boolean = False
		Dim oAtnds As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.GetAttendanceByCardNoDateRange(FEmp, TEmp, FDate, TDate, "OfficeWiseDetail")
		For Each oAt As SIS.ATN.atnProcessedPunch In oAtnds
			oEmp = oAt.CardNoHRM_Employees

			If LOfic <> oEmp.C_OfficeID Then
				If LOfic <> "*" Then
					Print("</table>")
				End If

				sn = 0
				Print("</br>")
				Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
				Dim oOfic As SIS.ATN.hrmOffices = SIS.ATN.hrmOffices.GetByID(oEmp.C_OfficeID)
				Print("<tr>")
				If chk <> "6" Then
					If Not oOfic Is Nothing Then
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""4"">" & oOfic.Description & "</td>")
					Else
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""4"">N/A</td>")
					End If
				Else
					If Not oOfic Is Nothing Then
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""5"">" & oOfic.Description & "</td>")
					Else
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" colspan=""2""><b>Location : </b></td><td colspan=""5"">N/A</td>")
					End If
				End If
				Print("</tr>")
				LOfic = oEmp.C_OfficeID

				Print("<tr>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
				Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
				If chk = 6 Then
					Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">Ist PUNCH</td>")
					Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">IInd PUNCH</td>")
				Else
					Print("<td style=""font-size:12px;font-weight:bold;width:90px;vertical-align: top;text-align:right"">PUNCH TIME</td>")
				End If
				Print("</tr>")
			End If

			If Lname <> oEmp.EmployeeName Then
				Printed = False
				Lname = oEmp.EmployeeName
			End If

			Dim MayPrint As Boolean = False

			Select Case chk
				Case 1
					If Convert.ToDecimal(oAt.Punch1Time) <= 9.15 Then
						MayPrint = True
					End If
				Case 2
					If Convert.ToDecimal(oAt.Punch1Time) > 9.15 And Convert.ToDecimal(oAt.Punch1Time) <= 9.3 Then
						MayPrint = True
					End If
				Case 3
					If Convert.ToDecimal(oAt.Punch1Time) > 9.3 And Convert.ToDecimal(oAt.Punch1Time) <= 10.3 Then
						MayPrint = True
					End If
				Case 4
					If Convert.ToDecimal(oAt.Punch1Time) > 10.3 Then
						MayPrint = True
					End If
				Case 5
					If Convert.ToDecimal(oAt.Punch2Time) = 0 Then
						MayPrint = True
					End If
				Case 6
					If oAt.PunchStatusID = "TS" Then
						MayPrint = True
					End If
			End Select
			If MayPrint Then
				If Not Printed Then
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right;padding-right: 8px"">" & sn.ToString & "</td>")
					Print("<td>" & oEmp.CardNo & "</td>")
					Print("<td style=""text-align:left"">" & oEmp.EmployeeName & "</td>")
					Print("<td style=""text-align:left"">" & oAt.AttenDate & "</td>")
					If chk = 6 Then
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
						Print("<td style=""text-align:right"">" & oAt.Punch2Time & "</td>")
					Else
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
					End If
					Print("</tr>")
					Printed = True
				Else
					Print("<tr>")
					Print("<td style=""text-align:right"">&nbsp;</td>")
					Print("<td>&nbsp;</td>")
					Print("<td style=""text-align:center"">&nbsp;</td>")
					Print("<td style=""text-align:left"">" & oAt.AttenDate & "</td>")
					If chk = 6 Then
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
						Print("<td style=""text-align:right"">" & oAt.Punch2Time & "</td>")
					Else
						Print("<td style=""text-align:right"">" & oAt.Punch1Time & "</td>")
					End If
					Print("</tr>")
				End If
			End If
		Next

		Print("</table>")

	End Sub
End Class
