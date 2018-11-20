Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_atnPunctualityReport
	Inherits SIS.SYS.ReportBase
	Public Overrides Sub ProcessReport()
		Dim Dept As Boolean = IIf(Request.QueryString("dept") = "true", True, False)
		Dim Loca As Boolean = IIf(Request.QueryString("loca") = "true", True, False)

		Dim FEmp As String = Request.QueryString("femp")
		Dim TEmp As String = Request.QueryString("temp")

		If FEmp = "" And TEmp = "" Then
			FEmp = "0001"
			TEmp = "9999"
		End If

		Dim Mon As String = Request.QueryString("mon")

		Dim Typ As String = ""
		If Not Request.QueryString("Typ") Is Nothing Then
			Typ = Request.QueryString("Typ")
		End If


		Print("<h3><u>Punctuality Report</u></h3>")
		Print("<h5>For the Month of :" & MonthName(Mon) & "</h5>")

		Print("<hr />")

		ReportHeader()

		Dim Reader As SqlDataReader = Nothing
		Dim sn As Integer = 0
		Dim pagelength As Integer = 30
		Dim mSql As String = ""
		If Typ = String.Empty Then
			mSql = "SELECT cardno,EmployeeName,C_DepartmentID,C_OfficeID,[D1],[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[D11],[D12],[D13],[D14],[D15],[D16],[D17],[D18],[D19],[D20],[D21],[D22],[D23],[D24],[D25],[D26],[D27],[D28],[D29],[D30],[D31] "
			mSql = mSql & "FROM (SELECT cardno,D_Day,PStatus,EmployeeName,C_DepartmentID,C_OfficeID "
			mSql = mSql & "    FROM ATN_PivotPunctuality WHERE D_Mon=" & Mon & " AND CardNo >= " & FEmp & " AND CardNo <= " & TEmp & ") AS atnd1 "
			mSql = mSql & "PIVOT "
			mSql = mSql & "( "
			mSql = mSql & " max(PStatus) "
			mSql = mSql & "FOR D_Day IN ([D1],[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[D11],[D12],[D13],[D14],[D15],[D16],[D17],[D18],[D19],[D20],[D21],[D22],[D23],[D24],[D25],[D26],[D27],[D28],[D29],[D30],[D31]) "
			mSql = mSql & ") as pt "
		Else
			mSql = "SELECT cardno,EmployeeName,C_DepartmentID,C_OfficeID,[D1],[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[D11],[D12],[D13],[D14],[D15],[D16],[D17],[D18],[D19],[D20],[D21],[D22],[D23],[D24],[D25],[D26],[D27],[D28],[D29],[D30],[D31] "
			mSql = mSql & "FROM (SELECT cardno,D_Day,PStatus,EmployeeName,C_DepartmentID,C_OfficeID "
			If Typ = "vrf" Then
				mSql = mSql & "    FROM ATN_PivotPunctuality WHERE D_Mon=" & Mon & " AND (VrfID = " & fEmp & " OR CardNo = " & fEmp & ")) AS atnd1 "
			Else
				mSql = mSql & "    FROM ATN_PivotPunctuality WHERE D_Mon=" & Mon & " AND (AprID = " & fEmp & " OR CardNo = " & fEmp & ")) AS atnd1 "
			End If
			mSql = mSql & "PIVOT "
			mSql = mSql & "( "
			mSql = mSql & " max(PStatus) "
			mSql = mSql & "FOR D_Day IN ([D1],[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[D11],[D12],[D13],[D14],[D15],[D16],[D17],[D18],[D19],[D20],[D21],[D22],[D23],[D24],[D25],[D26],[D27],[D28],[D29],[D30],[D31]) "
			mSql = mSql & ") as pt "

		End If
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = mSql
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
					Print("<td >" & Reader("CardNo") & "</td>")
					Print("<td >" & Reader("EmployeeName") & "</td>")
					For I As Integer = 1 To 31
						Dim aValue() As String
						If IsDBNull(Reader("D" & I)) Then aValue = "-,-,-".Split(",".ToCharArray) Else aValue = Reader("D" & I).split(",".ToCharArray)
						Select Case aValue(0)
							Case "PR"
								Print("<td style=""width: 30px;text-align:center;color:green"">" & aValue(0) & "</td>")
							Case "AD", "AS", "AF"
								Print("<td style=""width: 30px;text-align:center;color:red"">" & aValue(0) & "</td>")
							Case "WO", "HD"
								Print("<td style=""width: 30px;text-align:center;color:blue"">" & aValue(0) & "</td>")
							Case Else
								Print("<td style=""width: 30px;text-align:center;color:orange"">" & aValue(0) & "</td>")
						End Select
					Next
					Print("</tr>")

					Print("<tr>")
					Print("<td style=""text-align:right""></td>")
					Print("<td ></td>")
					Print("<td >1st Punch</td>")
					For I As Integer = 1 To 31
						Dim aValue() As String
						If IsDBNull(Reader("D" & I)) Then aValue = "-,-,-".Split(",".ToCharArray) Else aValue = Reader("D" & I).split(",".ToCharArray)
						Select Case aValue(0)
							Case "PR"
								Print("<td style=""width: 30px;text-align:center;color:green"">" & aValue(1) & "</td>")
							Case "AD", "AS", "AF"
								Print("<td style=""width: 30px;text-align:center;color:red"">" & aValue(1) & "</td>")
							Case "WO", "HD"
								Print("<td style=""width: 30px;text-align:center;color:blue"">" & aValue(1) & "</td>")
							Case Else
								Print("<td style=""width: 30px;text-align:center;color:orange"">" & aValue(1) & "</td>")
						End Select
					Next
					Print("</tr>")

					Print("<tr>")
					Print("<td style=""text-align:right""></td>")
					Print("<td ></td>")
					Print("<td >2nd Punch</td>")
					For I As Integer = 1 To 31
						Dim aValue() As String
						If IsDBNull(Reader("D" & I)) Then aValue = "-,-,-".Split(",".ToCharArray) Else aValue = Reader("D" & I).split(",".ToCharArray)
						Select Case aValue(0)
							Case "PR"
								Print("<td style=""width: 30px;text-align:center;color:green"">" & aValue(2) & "</td>")
							Case "AD", "AS", "AF"
								Print("<td style=""width: 30px;text-align:center;color:red"">" & aValue(2) & "</td>")
							Case "WO", "HD"
								Print("<td style=""width: 30px;text-align:center;color:blue"">" & aValue(2) & "</td>")
							Case Else
								Print("<td style=""width: 30px;text-align:center;color:orange"">" & aValue(2) & "</td>")
						End Select
					Next
					Print("</tr>")

					If sn = 25 Then
						Print("</table>")
						Print("<hr style=""page-break-after:always"" />")
						ReportHeader()
					End If
					If sn Mod pagelength = 0 Then
						If sn > pagelength Then
							Print("</table>")
							Print("<hr style=""page-break-after:always"" />")
							ReportHeader()
						End If
					End If
				End While
				Reader.Close()
			End Using
		End Using

		Print("</table>")

		Print("<hr />")

		'		SELECT cardno,EmployeeName,[D1],[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[D11],[D12],[D13],[D14],[D15],[D16],[D17],[D18],[D19],[D20],[D21],[D22],[D23],[D24],[D25],[D26],[D27],[D28],[D29],[D30],[D31] 
		'FROM
		'(SELECT cardno,D_Day,PStatus,EmployeeName    
		'    FROM ATN_PivotNAttendance WHERE D_Mon=4) AS atnd1
		'PIVOT
		'(
		' max(PStatus) 
		'FOR D_Day IN ([D1],[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[D11],[D12],[D13],[D14],[D15],[D16],[D17],[D18],[D19],[D20],[D21],[D22],[D23],[D24],[D25],[D26],[D27],[D28],[D29],[D30],[D31])
		') as pt
	End Sub
	Private Sub ReportHeader()
		Print("<table style=""width: 100%"" border=""1"" cellspacing=""0"" cellpadding=""0"">")
		Print("<tr>")

		Print("<td style=""width: 40px;text-align:right""><b>S.N.</b></td>")
		Print("<td style=""width: 60px""><b>Card No.</b></td>")
		Print("<td style=""width: 200px""><b>Employee Name</b></td>")
		For I As Integer = 1 To 31
			Print("<td style=""width: 30px;text-align:center""><b>" & I.ToString & "</b></td>")
		Next

		Print("</tr>")

	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
