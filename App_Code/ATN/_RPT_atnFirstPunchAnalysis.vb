Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_atnFirstPunchAnalysis
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
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise First Punch Analysis</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise First Punch Analysis</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise First Punch Analysis</u></td></tr></table>")
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
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top"" rowspan=""2"">S.N.</td>")
		Select Case wise.ToLower
			Case "d"
				Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">DEPARTMENT</td>")
			Case "l"
				Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">LOCATION</td>")
			Case "c"
				Print("<td style=""font-size: 12px;font-weight:bold;width:100px;vertical-align: top"" rowspan=""2"">CATEGORY</td>")
		End Select
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

		Dim LDept As String = ""
		Dim LEmpName As String = ""
		Dim ReaderValue As String = ""

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True
		Dim TotRec As Integer = 0
		Dim TotCnt(6) As Integer
		For I As Integer = 0 To 5
			TotCnt(I) = 0
		Next
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
					Case "l"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
					Case "c"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
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
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & LEmpName & "</td>")
							For I As Integer = 0 To 5
								Print("<td style=""text-align:right"">" & TotCnt(I) & "</td>")
								Print("<td style=""text-align:right"">" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</td>")
							Next
							Print("<td style=""text-align:right"">" & TotRec & "</td>")
							Print("</tr>")

						End If

						First = False
						TotRec = 0
						For I As Integer = 0 To 5
							TotCnt(I) = 0
						Next
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
					If Convert.ToDecimal(Reader("Punch2Time")) = 0 Then
						TotCnt(4) += 1
					End If
					If Reader("PunchStatusID") = "TS" Then
						TotCnt(5) += 1
					ElseIf Convert.ToDecimal(Reader("Punch1Time")) <= 9.15 Then
						TotCnt(0) += 1
					ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.15 And Convert.ToDecimal(Reader("Punch1Time")) <= 9.3 Then
						TotCnt(1) += 1
					ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.3 And Convert.ToDecimal(Reader("Punch1Time")) <= 10.3 Then
						TotCnt(2) += 1
					ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 10.3 Then
						TotCnt(3) += 1
					End If

				End While
				Reader.Close()
				If Not First Then
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
					Print("<td >" & LEmpName & "</td>")
					For I As Integer = 0 To 5
						Print("<td style=""text-align:right"">" & TotCnt(I) & "</td>")
						Print("<td style=""text-align:right"">" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</td>")
					Next
					Print("<td style=""text-align:right"">" & TotRec & "</td>")
					Print("</tr>")


					Print("</table>")
					Print("</br>")

				End If
			End Using
		End Using

	End Sub
	Private Sub SummaryReport(ByVal wise As String)
		ReportWidth = 750
		Select Case wise.ToLower
			Case "d"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise First Punch Analysis Summary</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise First Punch Analysis Summary</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise First Punch Analysis Summary</u></td></tr></table>")
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
		Dim TotCnt(6) As Integer
		For I As Integer = 0 To 5
			TotCnt(I) = 0
		Next


		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
					Case "l"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
					Case "c"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
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
							If TotRec > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								For I As Integer = 0 To 5
									Print("<td style=""text-align:right"">" & TotCnt(I) & "</td>")
									Print("<td style=""text-align:right"">" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</td>")
								Next
								Print("<td style=""text-align:right"">" & TotRec & "</td>")
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
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""16"">" & Reader("Department_Description") & "</td>")
							Case "l"
								Print("<td style=""font-size: 12px;font-weight:bold;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""16"">" & Reader("Office_Description") & "</td>")
							Case "c"
								Print("<td style=""font-size: 12px;font-weight:bold;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""16"">" & Reader("Category_Description") & "</td>")
						End Select
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top"" rowspan=""2"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"" rowspan=""2"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"" rowspan=""2"">NAME</td>")
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
						For I As Integer = 0 To 5
							TotCnt(I) = 0
						Next
						LEmp = Reader("CardNo")
						LEmpName = Reader("EmployeeName")
					End If
					If LEmp = Reader("CardNo") Then
						TotRec += 1
						If Convert.ToDecimal(Reader("Punch2Time")) = 0 Then
							TotCnt(4) += 1
						End If
						If Reader("PunchStatusID") = "TS" Then
							TotCnt(5) += 1
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) <= 9.15 Then
							TotCnt(0) += 1
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.15 And Convert.ToDecimal(Reader("Punch1Time")) <= 9.3 Then
							TotCnt(1) += 1
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.3 And Convert.ToDecimal(Reader("Punch1Time")) <= 10.3 Then
							TotCnt(2) += 1
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 10.3 Then
							TotCnt(3) += 1
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
							If TotRec > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								For I As Integer = 0 To 5
									Print("<td style=""text-align:right"">" & TotCnt(I) & "</td>")
									Print("<td style=""text-align:right"">" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</td>")
								Next
								Print("<td style=""text-align:right"">" & TotRec & "</td>")
								Print("</tr>")

							End If

							TotRec = 0
							For I As Integer = 0 To 5
								TotCnt(I) = 0
							Next
							LEmp = Reader("CardNo")
							LEmpName = Reader("EmployeeName")
						End If
					End If


				End While
				Reader.Close()
				If Not First Then
					If TotRec > 0 Then
						sn += 1
						Print("<tr>")
						Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
						Print("<td >" & LEmp & "</td>")
						Print("<td >" & LEmpName & "</td>")
						For I As Integer = 0 To 5
							Print("<td style=""text-align:right"">" & TotCnt(I) & "</td>")
							Print("<td style=""text-align:right"">" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</td>")
						Next
						Print("<td style=""text-align:right"">" & TotRec & "</td>")
						Print("</tr>")

					End If

					Print("</table>")
					Print("</br>")

					TotRec = 0
					For I As Integer = 0 To 5
						TotCnt(I) = 0
					Next
				End If
			End Using
		End Using

	End Sub
	Private Sub DetailReport(ByVal wise As String)
		ReportWidth = 800
		Select Case wise.ToLower
			Case "d"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise First Punch Detail</u></td></tr></table>")
			Case "l"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise First Punch Detail</u></td></tr></table>")
			Case "c"
				Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise First Punch Detail</u></td></tr></table>")
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
		Dim TotCnt(6) As Integer
		For I As Integer = 0 To 5
			TotCnt(I) = 0
		Next
		Dim Cnt As Integer = 0
		Dim fp As Boolean = False


		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim FirstDept As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Select Case wise.ToLower
					Case "d"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo, AttenDate"
					Case "l"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo, AttenDate"
					Case "c"
						mSql = "SELECT * FROM ATNv_FirstPunchAnalysis WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo, AttenDate"
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
								For I As Integer = 0 To 5
									Print("<td style=""text-align:center""><b>" & TotCnt(I) & "</b></td>")
								Next
								Print("</tr>")
								Print("<tr>")
								Print("<td colspan=""4"" style=""text-align:right""><b>% :</b></td>")
								For I As Integer = 0 To 5
									Print("<td style=""text-align:center""><b>" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</b></td>")
								Next
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
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""8"">" & Reader("Department_Description") & "</td>")
							Case "l"
								Print("<td style=""font-size: 12px;font-weight:bold;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""8"">" & Reader("Office_Description") & "</td>")
							Case "c"
								Print("<td style=""font-size: 12px;font-weight:bold;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
								Print("<td style=""font-size: 12px;font-weight:bold;vertical-align: top"" colspan=""8"">" & Reader("Category_Description") & "</td>")
						End Select
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:60px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" >&lt;= 09:15</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" >09:16 TO 09:30</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" >09:31 TO 10:30</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"" >&gt; 10:30</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:50px;vertical-align: top"" >FP</td>")
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
						Cnt = 0
						TotRec = 0
						For I As Integer = 0 To 5
							TotCnt(I) = 0
						Next
						LEmp = Reader("CardNo")
						Printed = False
					End If
					If LEmp = Reader("CardNo") Then
						TotRec += 1
						Cnt = -1
						fp = False
						If Convert.ToDecimal(Reader("Punch2Time")) = 0 Then
							TotCnt(4) += 1
							fp = True
						End If
						If Reader("PunchStatusID") = "TS" Then
							TotCnt(5) += 1
							Cnt = 5
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) <= 9.15 Then
							TotCnt(0) += 1
							Cnt = 0
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.15 And Convert.ToDecimal(Reader("Punch1Time")) <= 9.3 Then
							TotCnt(1) += 1
							Cnt = 1
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.3 And Convert.ToDecimal(Reader("Punch1Time")) <= 10.3 Then
							TotCnt(2) += 1
							Cnt = 2
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 10.3 Then
							TotCnt(3) += 1
							Cnt = 3
						End If
						If Not Printed Then
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & Reader("CardNo") & "</td>")
							Print("<td >" & Reader("EmployeeName") & "</td>")
							Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
							For I As Integer = 0 To 5
								If I = 4 Then
									If fp Then
										Print("<td style=""text-align:center"">1</td>")
									Else
										Print("<td style=""text-align:center"">&nbsp;</td>")
									End If
								Else
									If I = Cnt Then
										Print("<td style=""text-align:center"">1</td>")
									Else
										Print("<td style=""text-align:center"">&nbsp;</td>")
									End If
								End If
							Next
							Print("</tr>")
							Printed = True
						Else
							Print("<tr>")
							Print("<td style=""text-align:right"">&nbsp;</td>")
							Print("<td >&nbsp;</td>")
							Print("<td >&nbsp;</td>")
							Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
							For I As Integer = 0 To 5
								If I = 4 Then
									If fp Then
										Print("<td style=""text-align:center"">1</td>")
									Else
										Print("<td style=""text-align:center"">&nbsp;</td>")
									End If
								Else
									If I = Cnt Then
										Print("<td style=""text-align:center"">1</td>")
									Else
										Print("<td style=""text-align:center"">&nbsp;</td>")
									End If
								End If
							Next
							Print("</tr>")
						End If
					Else
						LEmp = Reader("CardNo")
						If Printed Then
							Print("<tr>")
							Print("<td colspan=""4"" style=""text-align:right""><b>TOTAL :</b></td>")
							For I As Integer = 0 To 5
								Print("<td style=""text-align:center""><b>" & TotCnt(I) & "</b></td>")
							Next
							Print("</tr>")
							Print("<tr>")
							Print("<td colspan=""4"" style=""text-align:right""><b>% :</b></td>")
							For I As Integer = 0 To 5
								Print("<td style=""text-align:center""><b>" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</b></td>")
							Next
							Print("</tr>")
							TotRec = 0
							For I As Integer = 0 To 5
								TotCnt(I) = 0
							Next
							Printed = False
						End If
						TotRec += 1
						Cnt = -1
						fp = False
						If Convert.ToDecimal(Reader("Punch2Time")) = 0 Then
							TotCnt(4) += 1
							fp = True
						End If
						If Reader("PunchStatusID") = "TS" Then
							TotCnt(5) += 1
							Cnt = 5
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) <= 9.15 Then
							TotCnt(0) += 1
							Cnt = 0
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.15 And Convert.ToDecimal(Reader("Punch1Time")) <= 9.3 Then
							TotCnt(1) += 1
							Cnt = 1
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 9.3 And Convert.ToDecimal(Reader("Punch1Time")) <= 10.3 Then
							TotCnt(2) += 1
							Cnt = 2
						ElseIf Convert.ToDecimal(Reader("Punch1Time")) > 10.3 Then
							TotCnt(3) += 1
							Cnt = 3
						End If
						sn += 1
						Print("<tr>")
						Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
						Print("<td >" & Reader("CardNo") & "</td>")
						Print("<td >" & Reader("EmployeeName") & "</td>")
						Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
						For I As Integer = 0 To 5
							If I = 4 Then
								If fp Then
									Print("<td style=""text-align:center"">1</td>")
								Else
									Print("<td style=""text-align:center"">&nbsp;</td>")
								End If
							Else
								If I = Cnt Then
									Print("<td style=""text-align:center"">1</td>")
								Else
									Print("<td style=""text-align:center"">&nbsp;</td>")
								End If
							End If
						Next
						Print("</tr>")
						Printed = True
					End If
				End While
				Reader.Close()
				If Not FirstDept Then
					If Printed Then
						Print("<tr>")
						Print("<td colspan=""4"" style=""text-align:right""><b>TOTAL :</b></td>")
						For I As Integer = 0 To 5
							Print("<td style=""text-align:center""><b>" & TotCnt(I) & "</b></td>")
						Next
						Print("</tr>")
						Print("<tr>")
						Print("<td colspan=""4"" style=""text-align:right""><b>% :</b></td>")
						For I As Integer = 0 To 5
							Print("<td style=""text-align:center""><b>" & ((TotCnt(I) / TotRec) * 100).ToString("n") & "</b></td>")
						Next
						Print("</tr>")
						TotRec = 0
						For I As Integer = 0 To 5
							TotCnt(I) = 0
						Next
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
