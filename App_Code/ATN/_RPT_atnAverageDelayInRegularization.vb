Imports System.Data
Imports System.Data.SqlClient
Public Class RPT_atnAverageDelayInRegularization
	Inherits SIS.SYS.ReportBase

	Public Overrides Sub ProcessReport()
		Dim Mon As String = Request.QueryString("mon")
		Dim LvT As String = Request.QueryString("lvt")
		Dim Det As String = Request.QueryString("det")

		If Det = 0 Then
			PrintSummary(Mon, LvT)
		Else
			PrintDetail(Mon, LvT)
		End If

	End Sub
	Private Sub PrintDetail(ByVal Mon As Integer, ByVal LvT As String)
		Print("<table width=""650px""><tr><td style=""text-align:center""><h5><u>Average Delay In Regularization</u></h5></td></tr></table>")
		Print("<table width=""650px""><tr><td style=""text-align:right;width:325px""><b>For the Month of :</b></td><td>" & MonthName(Mon) & "</td></tr></table>")
		Print("<table width=""650px""><tr><td style=""text-align:right;width:325px""><b>As On :</b></td><td>" & Now.ToString("d") & "</td></tr></table>")
		Print("<table width=""650px""><tr><td style=""text-align:right;width:325px""><b>Leave Types :</b></td><td>" & LvT & "</td></tr></table>")

		Print("<br />")

		ReportHeader()

		Dim Reader As SqlDataReader = Nothing
		Dim I As Integer = 0
		Dim sn As Integer = 0
		Dim pagelength As Integer = 55
		Dim totDays As Integer = 0
		Dim totRecs As Integer = 0
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.StoredProcedure
				Cmd.CommandText = "spatn_LG_atnAverageDelayInRegularizationDetail"
				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.Int, 10, Mon)
				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForLeaveTypes", SqlDbType.NVarChar, 100, LvT)
				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
					Print("<td >" & Reader("CardNo") & "</td>")
					Print("<td >" & Reader("EmployeeName") & "</td>")
					Print("<td >" & Reader("Description") & "</td>")
					Print("<td >" & Convert.ToDateTime(Reader("AttenDate")).ToString("d") & "</td>")
					Print("<td >" & Convert.ToDateTime(Reader("AppliedOn")).ToString("d") & "</td>")
					Print("<td style=""text-align:right"">" & Reader("DelayInDays") & "</td>")

					Print("</tr>")
					totRecs += 1
					totDays += Reader("DelayInDays")
					If sn = 50 Then
						Print("</table>")
						Print("<div style=""page-break-after:always"" />")
						ReportHeader()
					End If
					If sn Mod pagelength = 0 Then
						If sn > pagelength Then
							Print("</table>")
							Print("<div style=""page-break-after:always"" />")
							ReportHeader()
						End If
					End If
				End While
				Reader.Close()
			End Using
		End Using

		Print("</table>")

		Print("<table style=""width: 650px"">")
		Print("<tr>")
		Print("<td style=""text-align:right""><b>TOTAL DAYS :</b></td>")
		Print("<td style=""width: 80px;text-align:right""><b>" & totDays & "</b></td>")
		Print("</tr>")
		Print("<tr>")
		Print("<td style=""text-align:right""><b>TOTAL INSTANCES :</b></td>")
		Print("<td style=""width: 80px;text-align:right""><b>" & totRecs & "</b></td>")
		Print("</tr>")
		Print("<tr>")
		Print("<td style=""text-align:right""><b>AVERAGE :</b></td>")
		Print("<td style=""width: 80px;text-align:right""><b>" & FormatNumber(totDays / totRecs, 2) & "</b></td>")
		Print("</tr>")
		Print("</table>")

		Print("<hr />")

	End Sub
	Private Sub PrintSummary(ByVal Mon As Integer, ByVal LvT As String)
		Print("<table width=""650px""><tr><td style=""text-align:center""><h5><u>Average Delay In Regularization</u></h5></td></tr></table>")
		Print("<table width=""650px""><tr><td style=""text-align:right;width:325px""><b>For the Month of :</b></td><td>" & MonthName(Mon) & "</td></tr></table>")
		Print("<table width=""650px""><tr><td style=""text-align:right;width:325px""><b>As On :</b></td><td>" & Now.ToString("d") & "</td></tr></table>")
		Print("<table width=""650px""><tr><td style=""text-align:right;width:325px""><b>Leave Types :</b></td><td>" & LvT & "</td></tr></table>")

		Print("<br />")

		ReportHeaderS()

		Dim Reader As SqlDataReader = Nothing
		Dim I As Integer = 0
		Dim sn As Integer = 0
		Dim pagelength As Integer = 55
		Dim totDays As Integer = 0
		Dim totRecs As Integer = 0
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.StoredProcedure
				Cmd.CommandText = "spatn_LG_atnAverageDelayInRegularization"
				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.Int, 10, Mon)
				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForLeaveTypes", SqlDbType.NVarChar, 100, LvT)
				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
					Print("<td >" & Reader("CardNo") & "</td>")
					Print("<td >" & Reader("EmployeeName") & "</td>")
					Print("<td >" & Reader("Description") & "</td>")
					Print("<td style=""text-align:right"">" & Reader("DelayInDays") & "</td>")

					Print("</tr>")
					totRecs += 1
					totDays += Reader("DelayInDays")
					If sn = 50 Then
						Print("</table>")
						Print("<div style=""page-break-after:always"" />")
						ReportHeaderS()
					End If
					If sn Mod pagelength = 0 Then
						If sn > pagelength Then
							Print("</table>")
							Print("<div style=""page-break-after:always"" />")
							ReportHeaderS()
						End If
					End If
				End While
				Reader.Close()
			End Using
		End Using

		Print("</table>")

		'Print("<table style=""width: 650px"">")
		'Print("<tr>")
		'Print("<td style=""text-align:right""><b>TOTAL DAYS :</b></td>")
		'Print("<td style=""width: 80px;text-align:right""><b>" & totDays & "</b></td>")
		'Print("</tr>")
		'Print("<tr>")
		'Print("<td style=""text-align:right""><b>TOTAL INSTANCES :</b></td>")
		'Print("<td style=""width: 80px;text-align:right""><b>" & totRecs & "</b></td>")
		'Print("</tr>")
		'Print("<tr>")
		'Print("<td style=""text-align:right""><b>AVERAGE :</b></td>")
		'Print("<td style=""width: 80px;text-align:right""><b>" & FormatNumber(totDays / totRecs, 2) & "</b></td>")
		'Print("</tr>")
		'Print("</table>")

		Print("<hr />")
	End Sub
	Private Sub ReportHeaderS()
		Print("<table style=""width: 650px"" border=""1"" cellspacing=""0"" cellpadding=""0"">")
		Print("<tr>")

		Print("<td style=""width: 40px;text-align:right""><b>S.N.</b></td>")
		Print("<td style=""width: 60px""><b>Card No.</b></td>")
		Print("<td style=""width: 300px""><b>Employee Name</b></td>")
		Print("<td style=""width: 150px""><b>Department</b></td>")
		Print("<td style=""width: 100px;text-align:right""><b>Delay Days</b></td>")

		Print("</tr>")

	End Sub
	Private Sub ReportHeader()
		Print("<table style=""width: 650px"" border=""1"" cellspacing=""0"" cellpadding=""0"">")
		Print("<tr>")

		Print("<td style=""width: 40px;text-align:right""><b>S.N.</b></td>")
		Print("<td style=""width: 60px""><b>Card No.</b></td>")
		Print("<td style=""width: 190px""><b>Employee Name</b></td>")
		Print("<td style=""width: 100px""><b>Department</b></td>")
		Print("<td style=""width: 100px""><b>Attendance Date</b></td>")
		Print("<td style=""width: 100px""><b>Applied On</b></td>")
		Print("<td style=""width: 60px;text-align:right""><b>Delay Days</b></td>")

		Print("</tr>")

	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
