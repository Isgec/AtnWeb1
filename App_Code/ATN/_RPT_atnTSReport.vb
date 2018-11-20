Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_atnTSReport
	Inherits SIS.SYS.ReportBase

	Private FEmp As String = ""
	Private TEmp As String = ""
	Private Mon As String = ""

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
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise Time Short Analysis</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise Time Short Analysis</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise Time Short Analysis</u></td></tr></table>")
		End Select
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
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">COUNT</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">TOTAL</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">%</td>")
		Print("</tr>")

		Dim LDept As String = ""
		Dim LEmpName As String = ""
		Dim ReaderValue As String = ""

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True
		Dim TotRec As Integer = 0
		Dim TotCnt As Integer = 0
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
					Case "l"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
					Case "c"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
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
								Print("<td style=""text-align:right"">" & TotCnt.ToString("n") & "</td>")
								Print("<td style=""text-align:right"">" & TotRec & "</td>")
								Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
								Print("</tr>")
							End If
						End If
						First = False
						TotRec = 0
						TotCnt = 0
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
						sn = 0
					End If
					TotRec += 1
					If Reader("PunchStatusID").ToString = "TS" Then
						TotCnt += 1
					End If
				End While
				Reader.Close()
				If Not First Then
					If TotCnt > 0 Then
						sn += 1
						Print("<tr>")
						Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
						Print("<td >" & LEmpName & "</td>")
						Print("<td style=""text-align:right"">" & TotCnt.ToString("n") & "</td>")
						Print("<td style=""text-align:right"">" & TotRec & "</td>")
						Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
						Print("</tr>")
						Print("</table>")
						Print("</br>")
					End If
				End If
			End Using
		End Using
	End Sub
	Private Sub SummaryReport(ByVal wise As String)
		Select Case wise.ToLower
			Case "d"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise Time Short Analysis Summary</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise Time Short Analysis Summary</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise Time Short Analysis Summary</u></td></tr></table>")
		End Select
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
		Dim LEmp As String = ""
		Dim LEmpName As String = ""
		Dim ReaderValue As String = ""

		Dim TotRec As Integer = 0
		Dim TotCnt As Integer = 0
		Dim TotOD As Integer = 0
		Dim TotTW As Integer = 0
		Dim TotTC As Integer = 0


		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
					Case "l"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
					Case "c"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
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
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & TotCnt & "</td>")
								Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
								Print("<td style=""text-align:right"">" & TotRec & "</td>")
								Print("<td style=""text-align:right"">" & TotTW & "</td>")
								Print("<td style=""text-align:right"">" & TotTC & "</td>")
								Print("<td style=""text-align:right"">" & TotOD & "</td>")
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
								Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""7"">" & Reader("Department_Description") & "</td>")
							Case "l"
								Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""7"">" & Reader("Office_Description") & "</td>")
							Case "c"
								Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""7"">" & Reader("Category_Description") & "</td>")
						End Select
						Print("</tr>")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">TS</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">%</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">TOTAL</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">TW</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">TC</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">OD</td>")
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
						TotRec = 0
						TotCnt = 0
						TotOD = 0
						TotTW = 0
						TotTC = 0
						LEmp = Reader("CardNo")
						LEmpName = Reader("EmployeeName")
					End If
					If LEmp = Reader("CardNo") Then
						TotRec += 1
						If Convert.ToString(Reader("PunchStatusID")) = "TS" Then
							TotCnt += 1
							If Convert.ToBoolean(Reader("Applied")) Then
								Select Case Reader("TSStatus").ToString
									Case "TW"
										TotTW += 1
									Case "TC"
										TotTC += 1
									Case Else
										TotOD += 1
								End Select
							End If
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
							If TotCnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & TotCnt & "</td>")
								Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
								Print("<td style=""text-align:right"">" & TotRec & "</td>")
								Print("<td style=""text-align:right"">" & TotTW & "</td>")
								Print("<td style=""text-align:right"">" & TotTC & "</td>")
								Print("<td style=""text-align:right"">" & TotOD & "</td>")
								Print("</tr>")
							End If
							TotRec = 0
							TotCnt = 0
							TotOD = 0
							TotTC = 0
							TotTW = 0
							LEmp = Reader("CardNo")
							LEmpName = Reader("EmployeeName")
						End If
					End If
				End While
				Reader.Close()
				If Not First Then
					If TotCnt > 0 Then
						sn += 1
						Print("<tr>")
						Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
						Print("<td >" & LEmp & "</td>")
						Print("<td >" & LEmpName & "</td>")
						Print("<td style=""text-align:right"">" & TotCnt & "</td>")
						Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
						Print("<td style=""text-align:right"">" & TotRec & "</td>")
						Print("<td style=""text-align:right"">" & TotTW & "</td>")
						Print("<td style=""text-align:right"">" & TotTC & "</td>")
						Print("<td style=""text-align:right"">" & TotOD & "</td>")
						Print("</tr>")
					End If
					Print("</table>")
					Print("</br>")
					TotRec = 0
					TotCnt = 0
					TotOD = 0
					TotTC = 0
					TotTW = 0
				End If
			End Using
		End Using
	End Sub
	Private Sub DetailReport(ByVal wise As String)
		Select Case wise.ToLower
			Case "d"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise Pending Time Short Detail</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise Pending Time Short Detail</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise Pending Time Short Detail</u></td></tr></table>")
		End Select
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
		Dim ReaderValue As String = ""
		Dim Printed As Boolean = False

		Dim TotRec As Integer = 0
		Dim TotCnt As Integer = 0



		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim FirstDept As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo, AttenDate"
					Case "l"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo, AttenDate"
					Case "c"
						mSql = "SELECT * FROM ATNv_TimeShortAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo, AttenDate"
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
								Print("<td colspan=""4"" style=""text-align:right""><b>TOTAL :</b></td>")
								Print("<td style=""text-align:center""><b>" & TotCnt & "</b></td>")
								Print("</tr>")
								Print("<tr>")
								Print("<td colspan=""4"" style=""text-align:right""><b>% :</b></td>")
								Print("<td style=""text-align:center""><b>" & ((TotCnt / TotRec) * 100).ToString("n") & "</b></td>")
								Print("</tr>")
							End If
							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Select Case wise.ToLower
							Case "d"
								Print("<td style=""font-size: 12px;font-weight:bold;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">DEPARTMENT:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""3"">" & Reader("Department_Description") & "</td>")
							Case "l"
								Print("<td style=""font-size: 12px;font-weight:bold;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""3"">" & Reader("Office_Description") & "</td>")
							Case "c"
								Print("<td style=""font-size: 12px;font-weight:bold;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""3"">" & Reader("Category_Description") & "</td>")
						End Select
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:50px;vertical-align: top"" >TS</td>")
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
						TotRec = 0
						TotCnt = 0
						LEmp = Reader("CardNo")
						Printed = False
					End If
					If LEmp = Reader("CardNo") Then
						TotRec += 1
						If Convert.ToString(Reader("PunchStatusID")) = "TS" And Convert.ToBoolean(Reader("Applied")) = False Then
							TotCnt += 1
							If Not Printed Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & Reader("CardNo") & "</td>")
								Print("<td >" & Reader("EmployeeName") & "</td>")
								Print("<td style=""text-align:right" & IIf(Convert.ToBoolean(Reader("Applied")), "", ";color:red") & """>" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & IIf(Convert.ToBoolean(Reader("Applied")), "", "*") & "</td>")
								Print("<td style=""text-align:center"">1</td>")
								Print("</tr>")
								Printed = True
							Else
								Print("<tr>")
								Print("<td style=""text-align:right"">&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td style=""text-align:right" & IIf(Convert.ToBoolean(Reader("Applied")), "", ";color:red") & """>" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & IIf(Convert.ToBoolean(Reader("Applied")), "", "*") & "</td>")
								Print("<td style=""text-align:center"">1</td>")
								Print("</tr>")
							End If
						End If
					Else
						LEmp = Reader("CardNo")
						If Printed Then
							Print("<tr>")
							Print("<td colspan=""4"" style=""text-align:right""><b>TOTAL :</b></td>")
							Print("<td style=""text-align:center""><b>" & TotCnt & "</b></td>")
							Print("</tr>")
							Print("<tr>")
							Print("<td colspan=""4"" style=""text-align:right""><b>% :</b></td>")
							Print("<td style=""text-align:center""><b>" & ((TotCnt / TotRec) * 100).ToString("n") & "</b></td>")
							Print("</tr>")
							TotRec = 0
							TotCnt = 0
							Printed = False
						End If
						TotRec += 1
						If Convert.ToString(Reader("PunchStatusID")) = "TS" And Convert.ToBoolean(Reader("Applied")) = False Then
							TotCnt += 1
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & Reader("CardNo") & "</td>")
							Print("<td >" & Reader("EmployeeName") & "</td>")
							Print("<td style=""text-align:right" & IIf(Convert.ToBoolean(Reader("Applied")), "", ";color:red") & """>" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & IIf(Convert.ToBoolean(Reader("Applied")), "", "*") & "</td>")
							Print("<td style=""text-align:center"">1</td>")
							Print("</tr>")
							Printed = True
						End If
					End If
				End While
				Reader.Close()
				If Not FirstDept Then
					If Printed Then
						Print("<tr>")
						Print("<td colspan=""4"" style=""text-align:right""><b>TOTAL :</b></td>")
						Print("<td style=""text-align:center""><b>" & TotCnt & "</b></td>")
						Print("</tr>")
						Print("<tr>")
						Print("<td colspan=""4"" style=""text-align:right""><b>% :</b></td>")
						Print("<td style=""text-align:center""><b>" & ((TotCnt / TotRec) * 100).ToString("n") & "</b></td>")
						Print("</tr>")
						TotRec = 0
						TotCnt = 0
						Printed = False
					End If
					Print("</table>")
					Print("</br>")
				End If
			End Using
		End Using
	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
