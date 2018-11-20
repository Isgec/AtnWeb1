Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_atnExtraHours
	Inherits SIS.SYS.ReportBase

	Private FEmp As String = ""
	Private TEmp As String = ""
	Private Mon As String = ""

	Private WorkingHours As Double = 9.0
	Private ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
	Public Overrides Sub ProcessReport()
		Dim Dept As Boolean = IIf(Request.QueryString("dept") = "true", True, False)
		Dim Loca As Boolean = IIf(Request.QueryString("loca") = "true", True, False)
		Dim Cate As Boolean = IIf(Request.QueryString("cate") = "true", True, False)
		Dim typ As String = Request.QueryString("typ")

		FEmp = Request.QueryString("femp")
		TEmp = Request.QueryString("temp")
		Mon = Request.QueryString("mon")

		If FEmp = "" And TEmp = "" Then
			FEmp = "0001"
			TEmp = "9999"
		End If

		If typ = "a" Then
			If Loca Then
				AnalysisReport("L")
			ElseIf Dept Then
				AnalysisReport("D")
			Else
				AnalysisReport("C")
			End If
		ElseIf typ = "s" Then
			If Loca Then
				SummaryReport("L")
			ElseIf Dept Then
				SummaryReport("D")
			Else
				SummaryReport("C")
			End If
		ElseIf (typ = "d") Then
			If Loca Then
				DetailReport("L")
			ElseIf Dept Then
				DetailReport("D")
			Else
				DetailReport("C")
			End If
		End If
		Print("<hr />")
	End Sub
	Private Sub AnalysisReport(ByVal wise As String)
		Select Case wise.ToLower
			Case "d"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Department wise Analysis</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Location wise Analysis</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Category wise Analysis</u></td></tr></table>")
		End Select
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 12px;font-weight:bold"">[Working Hrs. > " & WorkingHours & "]</td></tr></table>")
		Print("</br>")

		Print("<table width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">For Month:</td>")
		Print("<td style=""font-size: 12px"" colspan=""3"">" & MonthName(Mon) & "</td>")
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
		Dim LEmpName As String = ""
		Dim ReaderValue As String = ""

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True
		Dim TotRec As Integer = 0
		Dim TotCnt As Integer = 0

		Dim TotHrs As Double = 0
		Dim GTotHrs As Double = 0

		'Calculate Total Extra Hrs
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
					Case "l"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
					Case "c"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
				End Select
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If Convert.ToDecimal(Reader("Punch1Time")) > 0 And Convert.ToDecimal(Reader("Punch2Time")) > 0 Then
						Dim hrs As Double = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(Reader("Punch1Time"), Reader("Punch2Time"))
						If hrs > WorkingHours Then
							GTotHrs = SIS.SYS.Utilities.NewAttendanceRules.AddTime(GTotHrs, SIS.SYS.Utilities.NewAttendanceRules.DiffTime(WorkingHours, hrs))
						End If
					End If
				End While
				Reader.Close()
			End Using
		End Using
		'End of Total hrs
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 12px;font-weight:bold"">Total Extra Hrs. : " & GTotHrs.ToString("n") & "]</td></tr></table>")
		Print("</br>")


		Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
		Select Case wise.ToLower
			Case "d"
				Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">DEPARTMENT</td>")
			Case "l"
				Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">LOCATION</td>")
			Case "c"
				Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">CATEGORY</td>")
		End Select
		Print("<td style=""font-size: 12px;font-weight:bold;width:50px;vertical-align: top;text-align:right"">COUNT</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:50px;vertical-align: top;text-align:right"">TOTAL</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:50px;vertical-align: top;text-align:right"">%</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:50px;vertical-align: top;text-align:right"">Hrs.</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">%</td>")
		Print("</tr>")

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
					Case "l"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
					Case "c"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
				End Select
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					Select Case wise.ToLower
						Case "d"
							ReaderValue = Reader("C_DepartmentID")
						Case "l"
							ReaderValue = Reader("C_OfficeID").ToString
						Case "c"
							ReaderValue = Reader("CategoryID").ToString
					End Select
					If LDept <> ReaderValue Then
						If Not First Then
							If TotCnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & TotCnt & "</td>")
								Print("<td style=""text-align:right"">" & TotRec & "</td>")
								Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
								Print("<td style=""text-align:right"">" & TotHrs.ToString("n") & "</td>")
								Print("<td style=""text-align:right"">" & ((TotHrs / GTotHrs) * 100).ToString("n") & "</td>")
								Print("</tr>")
							End If
						End If
						First = False
						TotRec = 0
						TotCnt = 0
						TotHrs = 0
						sn = 0
						Select Case wise.ToLower
							Case "d"
								LDept = Reader("C_DepartmentID")
								LEmpName = Reader("Department_Description")
							Case "l"
								LDept = Reader("C_OfficeID").ToString
								LEmpName = Reader("Office_Description")
							Case "c"
								LDept = Reader("CategoryID").ToString
								LEmpName = Reader("Category_Description")
						End Select
					End If
					TotRec += 1
					If Convert.ToDecimal(Reader("Punch1Time")) > 0 And Convert.ToDecimal(Reader("Punch2Time")) > 0 Then
						Dim hrs As Double = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(Reader("Punch1Time"), Reader("Punch2Time"))
						If hrs > WorkingHours Then
							TotCnt += 1
							TotHrs = SIS.SYS.Utilities.NewAttendanceRules.AddTime(TotHrs, SIS.SYS.Utilities.NewAttendanceRules.DiffTime(WorkingHours, hrs))
						End If
					End If
				End While
				Reader.Close()
				If Not First Then
					If TotCnt > 0 Then
						sn += 1
						Print("<tr>")
						Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
						Print("<td >" & LEmpName & "</td>")
						Print("<td style=""text-align:right"">" & TotCnt & "</td>")
						Print("<td style=""text-align:right"">" & TotRec & "</td>")
						Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
						Print("<td style=""text-align:right"">" & TotHrs.ToString("n") & "</td>")
						Print("<td style=""text-align:right"">" & ((TotHrs / GTotHrs) * 100).ToString("n") & "</td>")
						Print("</tr>")
						Print("</table>")
					End If
					Print("</br>")
				End If
			End Using
		End Using
	End Sub
	Private Sub SummaryReport(ByVal wise As String)
		Select Case wise.ToLower
			Case "d"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Department wise Summary</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Location wise Summary</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Category wise Summary</u></td></tr></table>")
		End Select
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 12px;font-weight:bold"">[Working Hrs. > " & WorkingHours & "]</td></tr></table>")
		Print("</br>")

		Print("<table width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">For Month:</td>")
		Print("<td style=""font-size: 12px"" colspan=""3"">" & MonthName(Mon) & "</td>")
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
		Dim Ecnt As Integer = 0
		Dim LEmp As String = ""
		Dim LEmpName As String = ""
		Dim EHrs As Double = 0
		Dim ReaderValue As String = ""

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
					Case "l"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
					Case "c"
						mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
				End Select
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					Select Case wise.ToLower
						Case "d"
							ReaderValue = Reader("C_DepartmentID")
						Case "l"
							ReaderValue = Reader("C_OfficeID").ToString
						Case "c"
							ReaderValue = Reader("CategoryID").ToString
					End Select
					If LDept <> ReaderValue Then
						If Not First Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt & "</td>")
								Print("<td style=""text-align:right"">" & EHrs.ToString("n") & "</td>")
								Print("</tr>")
							End If
							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Select Case wise.ToLower
							Case "d"
								Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">DEPARTMENT:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""3"">" & Reader("Department_Description") & "</td>")
							Case "l"
								Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""3"">" & Reader("Office_Description") & "</td>")
							Case "c"
								Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""3"">" & Reader("Category_Description") & "</td>")
						End Select
						Print("</tr>")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">COUNT</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">TOTAL Hrs.</td>")
						Print("</tr>")
						First = False
						Select Case wise.ToLower
							Case "d"
								LDept = Reader("C_DepartmentID")
							Case "l"
								LDept = Reader("C_OfficeID").ToString
							Case "c"
								LDept = Reader("CategoryID").ToString
						End Select
						sn = 0
						Ecnt = 0
						EHrs = 0
						LEmp = Reader("CardNo")
						LEmpName = Reader("EmployeeName")
					End If
					If LEmp = Reader("CardNo") Then
						Dim hrs As Double = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(Reader("Punch1Time"), Reader("Punch2Time"))
						If hrs > WorkingHours Then
							Ecnt += 1
							EHrs = SIS.SYS.Utilities.NewAttendanceRules.AddTime(EHrs, SIS.SYS.Utilities.NewAttendanceRules.DiffTime(WorkingHours, hrs))
						End If
					Else
						Select Case wise.ToLower
							Case "d"
								ReaderValue = Reader("C_DepartmentID")
							Case "l"
								ReaderValue = Reader("C_OfficeID").ToString
							Case "c"
								ReaderValue = Reader("CategoryID").ToString
						End Select
						If LDept = ReaderValue Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt & "</td>")
								Print("<td style=""text-align:right"">" & EHrs.ToString("n") & "</td>")
								Print("</tr>")
							End If
							Ecnt = 0
							EHrs = 0
							LEmp = Reader("CardNo")
							LEmpName = Reader("EmployeeName")
						End If
					End If
				End While
				Reader.Close()
				If Not First Then
					If Ecnt > 0 Then
						sn += 1
						Print("<tr>")
						Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
						Print("<td >" & LEmp & "</td>")
						Print("<td >" & LEmpName & "</td>")
						Print("<td style=""text-align:right"">" & Ecnt & "</td>")
						Print("<td style=""text-align:right"">" & EHrs.ToString("n") & "</td>")
						Print("</tr>")
					End If
					Print("</table>")
					Print("</br>")
					Ecnt = 0
					EHrs = 0
				End If
			End Using
		End Using
	End Sub
	Private Sub DetailReport(ByVal wise As String)
		'Dim aEmp() As String = "1577,1698,1658,1628,1620,1626,1606,1601,1557,1758,1724,1721,1636,1767,1712,1811,1711,1817,1593,1745,1735,1610,1713,1405,1411,1794,1795,1696,1403,1409,1753,1691,1609,1578,1400,1408,1641,1738,1737,1725,1812,1797,1643,1650,1652,1653,1544,1690,1608,1612,1857,1869,1819,1859,1837,1826,1834,1766,1720,1727,1597,1729,1771,1618,1404,1569,1598,1838".Split(",".ToCharArray)
		Dim aEmp() As String = "0144,0692,1325,0996,1525".Split(",".ToCharArray)

		Select Case wise.ToLower
			Case "d"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Department wise Detail</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Location wise Detail</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Extra Hours Category wise Detail</u></td></tr></table>")
		End Select
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 12px;font-weight:bold"">[Working Hrs. > " & WorkingHours & "]</td></tr></table>")
		Print("</br>")
		Print("<table width=""" & ReportWidth & "px"">")
		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold"">For Month:</td>")
		Print("<td style=""font-size: 12px"" colspan=""3"">" & MonthName(Mon) & "</td>")
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
		For Each eemp As String In aEmp
			FEmp = eemp
			TEmp = eemp

			For iMon As Integer = 1 To 10
				Mon = iMon
				Dim LDept As String = ""
				Dim Ecnt As Integer = 0
				Dim LEmp As String = ""
				Dim EHrs As Double = 0
				Dim TEHrs As Double = 0
				Dim ReaderValue As String = ""
				Dim Printed As Boolean = False

				Dim Reader As SqlDataReader = Nothing
				Dim mSql As String = ""
				Dim sn As Integer = 0
				Dim FirstDept As Boolean = True

				Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
					Using Cmd As SqlCommand = Con.CreateCommand()
						Cmd.CommandType = CommandType.Text
						Select Case wise.ToLower
							Case "d"
								mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo, AttenDate"
							Case "l"
								mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo, AttenDate"
							Case "c"
								mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo, AttenDate"
						End Select
						Cmd.CommandText = mSql
						Con.Open()
						Reader = Cmd.ExecuteReader()
						While (Reader.Read())
							Select Case wise.ToLower
								Case "d"
									ReaderValue = Reader("C_DepartmentID")
								Case "l"
									ReaderValue = Reader("C_OfficeID").ToString
								Case "c"
									ReaderValue = Reader("CategoryID").ToString
							End Select
							If LDept <> ReaderValue Then
								If Not FirstDept Then
									If Printed Then
										Print("<tr>")
										Print("<td colspan=""2""><b>COUNT :</b></td>")
										Print("<td style=""text-align:center""><b>" & Ecnt & "</b></td>")
										Print("<td colspan=""2""><b>TOTAL :</b></td>")
										Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
										Print("</tr>")
									End If
									Print("</table>")
									Print("</br>")
								End If
								Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
								Print("<tr>")
								Select Case wise.ToLower
									Case "d"
										Print("<td style=""font-size: 12px;font-weight:bold;width:80px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">DEPARTMENT:</td>")
										Print("<td style=""font-size: 12px;font-weight:bold;width:400px;vertical-align: top"" colspan=""5"">" & Reader("Department_Description") & "</td>")
									Case "l"
										Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
										Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""5"">" & Reader("Office_Description") & "</td>")
									Case "c"
										Print("<td style=""font-size: 12px;font-weight:bold;width:80px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
										Print("<td style=""font-size: 12px;font-weight:bold;width:400px;vertical-align: top"" colspan=""5"">" & Reader("Category_Description") & "</td>")
								End Select
								Print("</tr>")
								Print("<tr>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">CARD NO</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">1st PUNCH</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">2nd PUNCH</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">Hrs. [>9.45]</td>")
								Print("</tr>")
								FirstDept = False
								Select Case wise.ToLower
									Case "d"
										LDept = Reader("C_DepartmentID")
									Case "l"
										LDept = Reader("C_OfficeID").ToString
									Case "c"
										LDept = Reader("CategoryID").ToString
								End Select
								sn = 0
								Ecnt = 0
								TEHrs = 0
								LEmp = Reader("CardNo")
								Printed = False
							End If
							If LEmp = Reader("CardNo") Then
								Dim hrs As Double = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(Reader("Punch1Time"), Reader("Punch2Time"))
								If hrs > WorkingHours Then
									Ecnt += 1
									EHrs = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(WorkingHours, hrs)
									TEHrs = SIS.SYS.Utilities.NewAttendanceRules.AddTime(TEHrs, EHrs)
									If Not Printed Then
										sn += 1
										Print("<tr>")
										Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
										Print("<td >" & Reader("CardNo") & "</td>")
										Print("<td >" & Reader("EmployeeName") & "</td>")
										Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
										Print("<td style=""text-align:right"">" & Reader("Punch1Time") & "</td>")
										Print("<td style=""text-align:right"">" & Reader("Punch2Time") & "</td>")
										Print("<td style=""text-align:right"">" & EHrs.ToString("n") & "</td>")
										Print("</tr>")
										Printed = True
									Else
										Print("<tr>")
										Print("<td style=""text-align:right"">&nbsp;</td>")
										Print("<td >&nbsp;</td>")
										Print("<td >&nbsp;</td>")
										Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
										Print("<td style=""text-align:right"">" & Reader("Punch1Time") & "</td>")
										Print("<td style=""text-align:right"">" & Reader("Punch2Time") & "</td>")
										Print("<td style=""text-align:right"">" & EHrs.ToString("n") & "</td>")
										Print("</tr>")
									End If
								End If
							Else
								LEmp = Reader("CardNo")
								If Printed Then
									Print("<tr>")
									Print("<td colspan=""2""><b>COUNT :</b></td>")
									Print("<td style=""text-align:center""><b>" & Ecnt & "</b></td>")
									Print("<td colspan=""2""><b>TOTAL :</b></td>")
									Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
									Print("</tr>")
									TEHrs = 0
									Ecnt = 0
									Printed = False
								End If
								Dim hrs As Double = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(Reader("Punch1Time"), Reader("Punch2Time"))
								If hrs > WorkingHours Then
									Ecnt += 1
									EHrs = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(WorkingHours, hrs)
									TEHrs = SIS.SYS.Utilities.NewAttendanceRules.AddTime(TEHrs, EHrs)
									sn += 1
									Print("<tr>")
									Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
									Print("<td >" & Reader("CardNo") & "</td>")
									Print("<td >" & Reader("EmployeeName") & "</td>")
									Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
									Print("<td style=""text-align:right"">" & Reader("Punch1Time") & "</td>")
									Print("<td style=""text-align:right"">" & Reader("Punch2Time") & "</td>")
									Print("<td style=""text-align:right"">" & EHrs.ToString("n") & "</td>")
									Print("</tr>")
									Printed = True
								End If
							End If
						End While
						Reader.Close()
						If Not FirstDept Then
							If Printed Then
								Print("<tr>")
								Print("<td colspan=""2""><b>COUNT :</b></td>")
								Print("<td style=""text-align:center""><b>" & Ecnt & "</b></td>")
								Print("<td colspan=""2""><b>TOTAL :</b></td>")
								Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
								Print("</tr>")
								TEHrs = 0
								Ecnt = 0
								Printed = False
							End If
							Print("</table>")
							Print("</br>")
						End If
					End Using
				End Using
			Next
		Next
	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
