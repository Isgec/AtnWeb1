Imports System.Data
Imports System.Data.SqlClient
Public Class RPT_atnPendingRegularization
	Inherits SIS.SYS.ReportBase

	Public Overrides Sub ProcessReport()
		Dim Mon As String = Request.QueryString("mon")

		Print("<h3><u>Pending Regularization</u></h3>")
		Print("<h5>For the Month of :" & MonthName(Mon) & "</h5>")
		Print("<h5>As On :" & Now.ToString("d") & "</h5>")

		Print("<br />")
		Print("<hr />")

		Print("<table style=""width:" & ReportWidth & """>")

		Print("<tr>")

		Print("<td style=""width: 40px;text-align:right""><b>S.N.</b></td>")
		Print("<td style=""width: 60px""><b>Card No.</b></td>")
		Print("<td style=""width: 200px""><b>Employee Name:</b></td>")
		Print("<td style=""width: 50px;text-align:right""><b>Days</b></td>")
		Print("<td style=""width: 100px""><b>Designation</b></td>")
		Print("<td style=""width: 100px""><b>Department</b></td>")
		Print("<td style=""width: 100px""><b>Location</b></td>")

		Print("<td style=""width: 40px""><b>CL</b></td>")
		Print("<td style=""width: 40px""><b>SL</b></td>")
		Print("<td style=""width: 40px""><b>PL</b></td>")

		Print("</tr>")

		Dim Reader As SqlDataReader = Nothing
		Dim I As Integer = 0
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = "SELECT * FROM ATNv_PendingRegularization WHERE AttenMonth = " & Mon & " And FinYear = " & HttpContext.Current.Session("FinYear") & " ORDER BY SFinalValue, CardNo"
				Con.Open()
				Reader = Cmd.ExecuteReader()
				While (Reader.Read())
					I += 1
					Print("<tr>")
					Print("<td style=""text-align:right"">" & I.ToString & "</td>")
					Print("<td >" & Reader("CardNo") & "</td>")
					Print("<td >" & Reader("EmployeeName") & "</td>")
          Print("<td style=""text-align:right"">")
          Try
            Print(Reader("SFinalValue"))
          Catch ex As Exception
          End Try
          Print("</td>")
          Print("<td >")
          Try
            Print(Reader("Designation_Description"))
          Catch ex As Exception
          End Try
          Print("</td>")
          Print("<td >")
          Try
            Print(Reader("Department_Description"))
          Catch ex As Exception
          End Try
          Print("</td>")
          Print("<td >")
          Try
            Print(Reader("Office_Description"))
          Catch ex As Exception
          End Try
          Print("</td>")

          Dim clB As Double = 0
					Dim slB As Decimal = 0
          Dim plB As Decimal = 0
          Dim oBals As List(Of SIS.ATN.lgLedgerBalance) = New List(Of SIS.ATN.lgLedgerBalance)
          Try
            oBals = SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(Reader("CardNo"))

          Catch ex As Exception

          End Try
          Try
            For Each _bl As SIS.ATN.lgLedgerBalance In oBals
              If _bl.LeaveType = "CL" Then
                Try
                  clB = _bl.Balance

                Catch ex As Exception

                End Try
              End If
              If _bl.LeaveType = "SL" Then
                Try
                  slB = _bl.Balance

                Catch ex As Exception

                End Try
              End If
              If _bl.LeaveType = "AP" Or _bl.LeaveType = "AL" Or _bl.LeaveType = "PL" Or _bl.LeaveType = "LT" Then
                Try
                  plB += _bl.Balance

                Catch ex As Exception

                End Try
              End If
            Next

          Catch ex As Exception

          End Try

          Print("<td >" & IIf(clB = 0, "-", clB.ToString("n")) & "</td>")
					Print("<td >" & IIf(slB = 0, "-", slB.ToString("n")) & "</td>")
					Print("<td >" & IIf(plB = 0, "-", plB.ToString("n")) & "</td>")

					Print("</tr>")
				End While
				Reader.Close()
			End Using
		End Using

		Print("</table>")

		Print("<hr />")

	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
