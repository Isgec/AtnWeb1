Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_atnODReport
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
				LocationWiseAnalysis()
			ElseIf Dept Then
				DepartmentWiseAnalysis()
			Else
				CategoryWiseAnalysis()
			End If
		ElseIf typ = "s" Then
			If Loca Then
				LocationWiseSummary()
			ElseIf Dept Then
				DepartmentWiseSummary()
			Else
				CategoryWiseSummary()
			End If
		ElseIf (typ = "d") Then
			If Loca Then
				LocationWiseDetail()
			ElseIf Dept Then
				DepartmentWiseDetail()
			Else
				CategoryWiseDetail()
			End If
		End If

		Print("<hr />")

	End Sub
	Private Sub DepartmentWiseAnalysis()
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise OD Analysis</u></td></tr></table>")
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
		Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">DEPARTMENT</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">COUNT</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">TOTAL</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">%</td>")
		Print("</tr>")

		Dim LDept As String = ""
		Dim LEmpName As String = ""

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True
		Dim TotRec As Integer = 0
		Dim TotCnt As Decimal = 0

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				'AND (Applied1LeaveTypeID = 'OD' OR Applied2LeaveTypeID = 'OD') 
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("C_DepartmentID") Then
						If Not First Then
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & LEmpName & "</td>")
							Print("<td style=""text-align:right"">" & TotCnt.ToString("n") & "</td>")
							Print("<td style=""text-align:right"">" & TotRec & "</td>")
							Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
							Print("</tr>")

						End If

						First = False
						TotRec = 0
						TotCnt = 0
						LDept = Reader("C_DepartmentID")
						sn = 0
						LEmpName = Reader("Department_Description")
					End If
					TotRec += 1
					If Reader("Applied1LeaveTypeID") = "OD" Then
						TotCnt += 0.5
					End If
					If Reader("Applied2LeaveTypeID") = "OD" Then
						TotCnt += 0.5
					End If

				End While
				Reader.Close()
				If Not First Then
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
			End Using
		End Using

	End Sub
	Private Sub DepartmentWiseSummary()
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise OD Summary</u></td></tr></table>")
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
		Dim Ecnt As Decimal = 0
		Dim LEmp As String = ""
		Dim LEmpName As String = ""

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("C_DepartmentID") Then
						If Not First Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("</tr>")

							End If

							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">DEPARTMENT:</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""3"">" & Reader("Department_Description") & "</td>")
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">DAYS</td>")
						Print("</tr>")

						First = False

						LDept = Reader("C_DepartmentID")
						sn = 0
						Ecnt = 0
						LEmp = Reader("CardNo")
						LEmpName = Reader("EmployeeName")
					End If
					If LEmp = Reader("CardNo") Then
						If Reader("Applied1LeaveTypeID") = "OD" Then
							Ecnt += 0.5
						End If
						If Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt += 0.5
						End If
					Else
						If LDept = Reader("C_DepartmentID") Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("</tr>")

							End If

							Ecnt = 0
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
						Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
						Print("</tr>")

					End If

					Print("</table>")
					Print("</br>")

					Ecnt = 0
				End If
			End Using
		End Using

	End Sub
	Private Sub DepartmentWiseDetail()
		ReportWidth = 1150
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Department wise OD Detail</u></td></tr></table>")
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
		Dim Ecnt As Decimal = 0
		Dim LEmp As String = ""
		Dim TEHrs As Double = 0
		Dim Printed As Boolean = False

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim FirstDept As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_DepartmentID, CardNo, AttenDate"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("C_DepartmentID") Then
						If Not FirstDept Then
							If Printed Then
								Print("<tr>")
								Print("<td colspan=""2"">&nbsp;</td>")
								Print("<td style=""text-align:center"">&nbsp;</td>")
								Print("<td colspan=""2""><b>TOTAL :</b></td>")
								Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
								Print("<td colspan=""2"">&nbsp;</td>")
								Print("</tr>")
							End If
							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">DEPARTMENT:</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:400px;vertical-align: top"" colspan=""7"">" & Reader("Department_Description") & "</td>")
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">1st HALF</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">2nd HALF</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">VALUE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">DESTINATION</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">PURPOSE</td>")
						Print("</tr>")

						FirstDept = False

						LDept = Reader("C_DepartmentID")
						sn = 0
						Ecnt = 0
						TEHrs = 0
						LEmp = Reader("CardNo")
						Printed = False
					End If
					If LEmp = Reader("CardNo") Then
						If Reader("Applied1LeaveTypeID") = "OD" Or Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt = 0
							If Reader("Applied1LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							If Reader("Applied2LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							TEHrs += Ecnt
							If Not Printed Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & Reader("CardNo") & "</td>")
								Print("<td >" & Reader("EmployeeName") & "</td>")
								Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("<td >" & Reader("Destination") & "</td>")
								Print("<td >" & Reader("Purpose") & "</td>")
								Print("</tr>")
								Printed = True
							Else
								Print("<tr>")
								Print("<td style=""text-align:right"">&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("<td >" & Reader("Destination") & "</td>")
								Print("<td >" & Reader("Purpose") & "</td>")
								Print("</tr>")
							End If
						End If
					Else
						LEmp = Reader("CardNo")
						If Printed Then
							Print("<tr>")
							Print("<td colspan=""2"">&nbsp;</td>")
							Print("<td style=""text-align:center"">&nbsp;</td>")
							Print("<td colspan=""2""><b>TOTAL :</b></td>")
							Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
							Print("<td colspan=""2"">&nbsp;</td>")
							Print("</tr>")
							TEHrs = 0
							Ecnt = 0
							Printed = False
						End If
						If Reader("Applied1LeaveTypeID") = "OD" Or Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt = 0
							If Reader("Applied1LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							If Reader("Applied2LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							TEHrs += Ecnt
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & Reader("CardNo") & "</td>")
							Print("<td >" & Reader("EmployeeName") & "</td>")
							Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
							Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
							Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
							Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
							Print("<td >" & Reader("Destination") & "</td>")
							Print("<td >" & Reader("Purpose") & "</td>")
							Print("</tr>")
							Printed = True
						End If
					End If
				End While
				Reader.Close()
				If Not FirstDept Then
					If Printed Then
						Print("<tr>")
						Print("<td colspan=""2"">&nbsp;</td>")
						Print("<td style=""text-align:center"">&nbsp;</td>")
						Print("<td colspan=""2""><b>TOTAL :</b></td>")
						Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
						Print("<td colspan=""2"">&nbsp;</td>")
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
	End Sub
	Private Sub LocationWiseAnalysis()
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise OD Analysis</u></td></tr></table>")
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
		Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">LOCATION</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">COUNT</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">TOTAL</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">%</td>")
		Print("</tr>")


		Dim LDept As String = ""
		Dim LEmpName As String = ""
		Dim TotRec As Integer = 0
		Dim TotCnt As Decimal = 0

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("C_OfficeID").ToString Then
						If Not First Then
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & LEmpName & "</td>")
							Print("<td style=""text-align:right"">" & TotCnt.ToString("n") & "</td>")
							Print("<td style=""text-align:right"">" & TotRec & "</td>")
							Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
							Print("</tr>")

						End If

						First = False

						LDept = Reader("C_OfficeID").ToString
						sn = 0
						TotRec = 0
						TotCnt = 0
						LEmpName = Reader("Office_Description")
					End If
					TotRec += 1
					If Reader("Applied1LeaveTypeID") = "OD" Then
						TotCnt += 0.5
					End If
					If Reader("Applied2LeaveTypeID") = "OD" Then
						TotCnt += 0.5
					End If

				End While
				Reader.Close()
				If Not First Then
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
			End Using
		End Using

	End Sub
	Private Sub LocationWiseSummary()
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise OD Summary</u></td></tr></table>")
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
		Dim Ecnt As Decimal = 0
		Dim LEmp As String = ""
		Dim LEmpName As String = ""
		Dim EHrs As Double = 0

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("C_OfficeID").ToString Then
						If Not First Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("</tr>")
							End If

							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""3"">" & Reader("Office_Description") & "</td>")
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">DAYS</td>")
						Print("</tr>")

						First = False

						LDept = Reader("C_OfficeID").ToString
						sn = 0
						Ecnt = 0
						EHrs = 0
						LEmp = Reader("CardNo")
						LEmpName = Reader("EmployeeName")
					End If
					If LEmp = Reader("CardNo") Then
						If Reader("Applied1LeaveTypeID") = "OD" Then
							Ecnt += 0.5
						End If
						If Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt += 0.5
						End If
					Else
						If LDept = Reader("C_OfficeID").ToString Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
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
						Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
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
	Private Sub LocationWiseDetail()
		ReportWidth = 1150
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Location wise OD Detail</u></td></tr></table>")
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
		Dim Ecnt As Decimal = 0
		Dim LEmp As String = ""
		Dim TEHrs As Double = 0
		Dim Printed As Boolean = False

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim FirstDept As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY C_OfficeID, CardNo, AttenDate"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("C_OfficeID").ToString Then
						If Not FirstDept Then
							If Printed Then
								Print("<tr>")
								Print("<td colspan=""2"">&nbsp;</td>")
								Print("<td style=""text-align:center"">&nbsp;</td>")
								Print("<td colspan=""2""><b>TOTAL :</b></td>")
								Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
								Print("<td colspan=""2"">&nbsp;</td>")
								Print("</tr>")
								Printed = False
							End If
							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">LOCATION:</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""7"">" & Reader("Office_Description") & "</td>")
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">1st HALF</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">2nd HALF</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">VALUE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">DESTINATION</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">PURPOSE</td>")
						Print("</tr>")

						FirstDept = False

						LDept = Reader("C_OfficeID").ToString
						sn = 0
						Ecnt = 0
						TEHrs = 0
						LEmp = Reader("CardNo")
					End If
					If LEmp = Reader("CardNo") Then
						If Reader("Applied1LeaveTypeID") = "OD" Or Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt = 0
							If Reader("Applied1LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							If Reader("Applied2LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							TEHrs += Ecnt
							If Not Printed Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & Reader("CardNo") & "</td>")
								Print("<td >" & Reader("EmployeeName") & "</td>")
								Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("<td >" & Reader("Destination") & "</td>")
								Print("<td >" & Reader("Purpose") & "</td>")
								Print("</tr>")
								Printed = True
							Else
								Print("<tr>")
								Print("<td style=""text-align:right"">&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("<td >" & Reader("Destination") & "</td>")
								Print("<td >" & Reader("Purpose") & "</td>")
								Print("</tr>")
							End If
						End If
					Else
						LEmp = Reader("CardNo")
						If Printed Then
							Print("<tr>")
							Print("<td colspan=""2"">&nbsp;</td>")
							Print("<td style=""text-align:center"">&nbsp;</td>")
							Print("<td colspan=""2""><b>TOTAL :</b></td>")
							Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
							Print("<td colspan=""2"">&nbsp;</td>")
							Print("</tr>")
							TEHrs = 0
							Ecnt = 0
							Printed = False
						End If
						If Reader("Applied1LeaveTypeID") = "OD" Or Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt = 0
							If Reader("Applied1LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							If Reader("Applied2LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							TEHrs += Ecnt
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & Reader("CardNo") & "</td>")
							Print("<td >" & Reader("EmployeeName") & "</td>")
							Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
							Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
							Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
							Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
							Print("<td >" & Reader("Destination") & "</td>")
							Print("<td >" & Reader("Purpose") & "</td>")
							Print("</tr>")
							Printed = True
						End If
					End If
				End While
				Reader.Close()
				If Not FirstDept Then
					If Printed Then
						Print("<tr>")
						Print("<td colspan=""2"">&nbsp;</td>")
						Print("<td style=""text-align:center"">&nbsp;</td>")
						Print("<td colspan=""2""><b>TOTAL :</b></td>")
						Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
						Print("<td colspan=""2"">&nbsp;</td>")
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
	End Sub
	Private Sub CategoryWiseAnalysis()
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise OD Analysis</u></td></tr></table>")
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
		Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">CATEGORY</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">COUNT</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">TOTAL</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">%</td>")
		Print("</tr>")


		Dim LDept As String = ""
		Dim LEmpName As String = ""
		Dim TotRec As Integer = 0
		Dim TotCnt As Decimal = 0

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("CategoryID").ToString Then
						If Not First Then
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & LEmpName & "</td>")
							Print("<td style=""text-align:right"">" & TotCnt.ToString("n") & "</td>")
							Print("<td style=""text-align:right"">" & TotRec & "</td>")
							Print("<td style=""text-align:right"">" & ((TotCnt / TotRec) * 100).ToString("n") & "</td>")
							Print("</tr>")

						End If

						First = False

						LDept = Reader("CategoryID").ToString
						sn = 0
						TotRec = 0
						TotCnt = 0
						LEmpName = Reader("Category_Description")
					End If
					TotRec += 1
					If Reader("Applied1LeaveTypeID") = "OD" Then
						TotCnt += 0.5
					End If
					If Reader("Applied2LeaveTypeID") = "OD" Then
						TotCnt += 0.5
					End If

				End While
				Reader.Close()
				If Not First Then
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
			End Using
		End Using

	End Sub
	Private Sub CategoryWiseSummary()
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise OD Summary</u></td></tr></table>")
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
		Dim Ecnt As Decimal = 0
		Dim LEmp As String = ""
		Dim LEmpName As String = ""
		Dim EHrs As Double = 0

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("CategoryID").ToString Then
						If Not First Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("</tr>")

							End If

							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:120px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:360px;vertical-align: top"" colspan=""3"">" & Reader("Category_Description") & "</td>")
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">DAYS</td>")
						Print("</tr>")

						First = False

						LDept = Reader("CategoryID").ToString
						sn = 0
						Ecnt = 0
						EHrs = 0
						LEmp = Reader("CardNo")
						LEmpName = Reader("EmployeeName")
					End If
					If LEmp = Reader("CardNo") Then
						If Reader("Applied1LeaveTypeID") = "OD" Then
							Ecnt += 0.5
						End If
						If Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt += 0.5
						End If
					Else
						If LDept = Reader("CategoryID").ToString Then
							If Ecnt > 0 Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & LEmp & "</td>")
								Print("<td >" & LEmpName & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
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
						Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
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
	Private Sub CategoryWiseDetail()
		ReportWidth = 1150
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Category wise OD Detail</u></td></tr></table>")
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
		Dim Ecnt As Decimal = 0
		Dim LEmp As String = ""
		Dim TEHrs As Double = 0
		Dim Printed As Boolean = False

		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim FirstDept As Boolean = True

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				mSql = "SELECT * FROM ATNv_AttendanceData WHERE CardNo >= '" & FEmp & "' AND CardNo <= '" & TEmp & "' AND MONTH(AttenDate) = " & Mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY CategoryID, CardNo, AttenDate"
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					If LDept <> Reader("CategoryID").ToString Then
						If Not FirstDept Then
							If Printed Then
								Print("<tr>")
								Print("<td colspan=""2"">&nbsp;</td>")
								Print("<td style=""text-align:center"">&nbsp;</td>")
								Print("<td colspan=""2""><b>TOTAL :</b></td>")
								Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
								Print("<td colspan=""2"">&nbsp;</td>")
								Print("</tr>")
							End If
							Print("</table>")
							Print("</br>")
						End If
						Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;text-align:right;vertical-align: top;padding-right: 8px"" colspan=""2"">CATEGORY:</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:400px;vertical-align: top"" colspan=""7"">" & Reader("Category_Description") & "</td>")
						Print("</tr>")

						Print("<tr>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top"">CARD NO</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">NAME</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top"">DATE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">1st HALF</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">2nd HALF</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;text-align:right"">VALUE</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">DESTINATION</td>")
						Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">PURPOSE</td>")
						Print("</tr>")

						FirstDept = False

						LDept = Reader("CategoryID").ToString
						sn = 0
						Ecnt = 0
						TEHrs = 0
						LEmp = Reader("CardNo")
						Printed = False
					End If
					If LEmp = Reader("CardNo") Then
						If Reader("Applied1LeaveTypeID") = "OD" Or Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt = 0
							If Reader("Applied1LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							If Reader("Applied2LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							TEHrs += Ecnt
							If Not Printed Then
								sn += 1
								Print("<tr>")
								Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
								Print("<td >" & Reader("CardNo") & "</td>")
								Print("<td >" & Reader("EmployeeName") & "</td>")
								Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("<td >" & Reader("Destination") & "</td>")
								Print("<td >" & Reader("Purpose") & "</td>")
								Print("</tr>")
								Printed = True
							Else
								Print("<tr>")
								Print("<td style=""text-align:right"">&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td >&nbsp;</td>")
								Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
								Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
								Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
								Print("<td >" & Reader("Destination") & "</td>")
								Print("<td >" & Reader("Purpose") & "</td>")
								Print("</tr>")
							End If
						End If
					Else
						LEmp = Reader("CardNo")
						If Printed Then
							Print("<tr>")
							Print("<td colspan=""2"">&nbsp;</td>")
							Print("<td style=""text-align:center"">&nbsp;</td>")
							Print("<td colspan=""2""><b>TOTAL :</b></td>")
							Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
							Print("<td colspan=""2"">&nbsp;</td>")
							Print("</tr>")
							TEHrs = 0
							Ecnt = 0
							Printed = False
						End If
						If Reader("Applied1LeaveTypeID") = "OD" Or Reader("Applied2LeaveTypeID") = "OD" Then
							Ecnt = 0
							If Reader("Applied1LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							If Reader("Applied2LeaveTypeID") = "OD" Then
								Ecnt += 0.5
							End If
							TEHrs += Ecnt
							sn += 1
							Print("<tr>")
							Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
							Print("<td >" & Reader("CardNo") & "</td>")
							Print("<td >" & Reader("EmployeeName") & "</td>")
							Print("<td style=""text-align:right"">" & Convert.ToDateTime(Reader("AttenDate"), ci).ToString("dd/MM/yyyy") & "</td>")
							Print("<td style=""text-align:center"">" & Reader("Applied1LeaveTypeID") & "</td>")
							Print("<td style=""text-align:center"">" & Reader("Applied2LeaveTypeID") & "</td>")
							Print("<td style=""text-align:right"">" & Ecnt.ToString("n") & "</td>")
							Print("<td >" & Reader("Destination") & "</td>")
							Print("<td >" & Reader("Purpose") & "</td>")
							Print("</tr>")
							Printed = True
						End If
					End If
				End While
				Reader.Close()
				If Not FirstDept Then
					If Printed Then
						Print("<tr>")
						Print("<td colspan=""2"">&nbsp;</td>")
						Print("<td style=""text-align:center"">&nbsp;</td>")
						Print("<td colspan=""2""><b>TOTAL :</b></td>")
						Print("<td colspan=""2"" style=""text-align:right""><b>" & TEHrs.ToString("n") & "</b></td>")
						Print("<td colspan=""2"">&nbsp;</td>")
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
	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
	Private Function GetTotDays(ByVal OfficeID As Integer, ByVal mon As Integer) As Integer
		OfficeID = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(OfficeID)
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = "SELECT COUNT(*) FROM ATN_Holidays WHERE OfficeID = " & OfficeID & " AND MONTH(Holiday) = " & mon & " AND FinYear = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear

				Con.Open()
			End Using
    End Using
    Return 0
	End Function
End Class
