Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class RPT_atnLeaveLedger
	Inherits SIS.SYS.ReportBase

	Private myCols As Integer = 5
	Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
	Public Overrides Sub ProcessReport()
		Dim FMon As Integer = Request.QueryString("fmon")
		Dim TMon As Integer = Request.QueryString("tmon")
		Dim FEmp As String = Request.QueryString("femp")
		Dim TEmp As String = Request.QueryString("temp")



		Dim sn As Integer = 0
		Dim i As Integer = 0

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align:center;font-size: 14px;font-weight:bold""><u>Leave Ledger</u></td></tr></table>")
		Print("</br>")

		If FMon = 0 Or TMon = 0 Then
			Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold"">Invalid Months</td></tr></table>")
			Return
		Else
			If FMon > TMon Then
				Dim tmp As Integer = TMon
				TMon = FMon
				FMon = tmp
			End If
		End If

		Dim fDt As DateTime = Convert.ToDateTime("01/01/" & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear, ci)
		Dim sDt As DateTime = Convert.ToDateTime("01/" & FMon.ToString.PadLeft("2", "0") & "/" & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear, ci)
		Dim tDt As DateTime = sDt.AddMonths(TMon - FMon + 1).AddDays(-1)

		Print("<table width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;text-align:center""><b>Year:</b>&nbsp;" & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & "</td>")
		Print("</tr>")

		Print("<tr>")
		Print("<td style=""font-size: 12px;text-align:center""><b>From:</b>&nbsp;&nbsp;" & MonthName(FMon, True) & "&nbsp;&nbsp;&nbsp;&nbsp;<b>To:</b>&nbsp;&nbsp;" & MonthName(TMon, True) & "</td>")
		Print("</tr>")

		Print("</table>")

		Print("</br>")

		Print("<table width=""" & ReportWidth & "px"">")
		Dim oLvTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
		i = 0
		For Each lvt As SIS.ATN.atnLeaveTypes In oLvTs
			If i Mod 3 = 0 Then
				Print("<tr>")
				If i = 0 Then
					Print("<td><b>Abbreviations:</b></td>")
				Else
					Print("<td>&nbsp;</td>")
				End If
			End If
			Print("<td><b>" & lvt.LeaveTypeID & "</b></td>")
			Print("<td>" & lvt.Description & ",</td>")
			i += 1
			If i Mod 3 = 0 Then
				Print("</tr>")
			End If
		Next
		If i Mod 3 <> 0 Then
			Do While i Mod myCols <> 0
				Print("<td>&nbsp;</td>")
				Print("<td>&nbsp;</td>")
				i += 1
			Loop
			Print("</tr>")
		End If
		Print("<tr><td colspan=""7""><hr /></td></tr>")
		Print("</table>")

		Print("</br>")
		Print("</br>")

		Dim oEmps As List(Of SIS.ATN.atnEmployees) = SIS.ATN.atnEmployees.SelectList("CardNo")


		For Each oEmp As SIS.ATN.atnEmployees In oEmps
			'Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(FEmp)

			If Not oEmp.ActiveState Then Continue For
			If oEmp.CardNo > TEmp Or oEmp.CardNo < FEmp Then Continue For

			Dim oLgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetRPTLeaveLedger(oEmp.CardNo, sDt, tDt)
			If oLgrs.Count > 0 Then
				Print("<table width=""" & ReportWidth & "px"">")
				'----Print Employe name
				Print("<tr>")
				Print("<td><b><u>" & oEmp.EmployeeName & "</u></b></td>")
				Print("<td>[" & oEmp.CardNo & "]</td>")
				Print("<td>&nbsp;</td>")
				Print("<td>&nbsp;</td>")
				Print("</tr>")
				'---------------
				Dim opbLgrs As List(Of opbLgr) = opbLgr.GetopbLgr(oEmp.CardNo, fDt, sDt)
				If opbLgrs.Count > 0 Then
					'Print OPBs
					Print("<tr>")
					Print("<td colspan=""4"">")
					Print("<table width=""100%"">")
					i = 0
					For Each olgr As opbLgr In opbLgrs
						If i Mod myCols = 0 Then
							Print("<tr>")
							If i = 0 Then
								Print("<td><b>Opening Bal:</b></td>")
							Else
								Print("<td>&nbsp;</td>")
							End If
						End If
						Print("<td><b>" & olgr.LeaveType & "</b></td>")
						Print("<td>" & olgr.Balance & ",</td>")
						i += 1
						If i Mod myCols = 0 Then
							Print("</tr>")
						End If
					Next
					If i Mod myCols <> 0 Then
						Do While i Mod myCols <> 0
							Print("<td>&nbsp;</td>")
							Print("<td>&nbsp;</td>")
							i += 1
						Loop
						Print("</tr>")
					End If
					Print("</table>")
					Print("</td>")
					Print("</tr>")
				Else
					'Print OPB: NIL
					Print("<tr>")
					Print("<td colspan=""4""><b>Opening Bal:</b>NIL</td>")
					Print("</tr>")
				End If
				Print("<tr>")
				Print("<td style=""vertical-align:top""><b>Transactions:</b></td>")
				Print("<td colspan=""3"">")
				'-----Print Transactions
				Print("<table width=""100%"">")
				Print("<tr>")
				Print("<td><u>Date</u></td>")
				Print("<td style=""text-align:center""><u>Leave Type</u></td>")
				Print("<td style=""text-align:right""><u>Credit</u></td>")
				Print("<td style=""text-align:right""><u>Debit</u></td>")
				Print("</tr>")
				For Each lgr As SIS.ATN.atnLeaveLedger In oLgrs
					Print("<tr>")
					Print("<td>" & lgr.TranDate & "</td>")
					Print("<td style=""text-align:center"">" & lgr.LeaveTypeID & "</td>")
					If lgr.Days > 0 Then
						Print("<td style=""text-align:right"">" & lgr.Days & "</td>")
						Print("<td>&nbsp;</td>")
					Else
						'Credited Leaves
						Print("<td>&nbsp;</td>")
						Print("<td style=""text-align:right"">" & Math.Abs(lgr.Days) & "</td>")
					End If
					Print("</tr>")
					'Update Closing Balance in opbLgrs
					Dim Found As Boolean = False
					For Each olgr As opbLgr In opbLgrs
						If olgr.LeaveType = lgr.LeaveTypeID Then
							Found = True
							olgr.Balance += lgr.Days
							Exit For
						End If
					Next
					If Not Found Then
						Dim tmp As New opbLgr
						tmp.LeaveType = lgr.LeaveTypeID
						tmp.Balance = lgr.Days
						opbLgrs.Add(tmp)
					End If
					'---End Closing Balance Updation
				Next
				Print("</table>")
				'----End Of Transaction Print
				Print("</td>")
				Print("</tr>")
				'-----Print Closing Balance
				'Print OPBs
				Print("<tr>")
				Print("<td colspan=""4"">")
				Print("<table width=""100%"">")
				i = 0
				For Each olgr As opbLgr In opbLgrs
					If i Mod myCols = 0 Then
						Print("<tr>")
						If i = 0 Then
							Print("<td><b>Closing Bal.:</b></td>")
						Else
							Print("<td>&nbsp;</td>")
						End If
					End If
					Print("<td><b>" & olgr.LeaveType & "</b></td>")
					Print("<td>" & olgr.Balance & ",</td>")
					i += 1
					If i Mod myCols = 0 Then
						Print("</tr>")
					End If
				Next
				If i Mod myCols <> 0 Then
					Do While i Mod myCols <> 0
						Print("<td>&nbsp;</td>")
						Print("<td>&nbsp;</td>")
						i += 1
					Loop
					Print("</tr>")
				End If
				Print("</table>")
				Print("</td>")
				Print("</tr>")
				Print("<tr><td colspan=""4""><hr /></td></tr>")
				Print("</table>")
				Print("</br>")
			End If
		Next
		Print("</br>")
	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
	Private Class opbLgr
		Private _LeaveType As String = ""
		Private _Balance As Double = 0
		Public Shared Function GetopbLgr(ByVal CardNo As String, ByVal fDT As DateTime, ByVal sDT As DateTime) As List(Of opbLgr)
			Dim Result As List(Of opbLgr) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT LEAVETYPEID, SUM(DAYS) AS SDAYS FROM ATN_LeaveLedger WHERE CardNo='" & CardNo & "' AND TranDate >= CONVERT(DATETIME,'" & fDT.ToString("dd/MM/yyyy") & "',103) AND TranDate < CONVERT(DATETIME,'" & sDT.ToString("dd/MM/yyyy") & "',103) AND DAYS <> 0 AND FINYEAR = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " GROUP BY LEAVETYPEID"
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					Result = New List(Of opbLgr)
					While (Reader.Read())
						Result.Add(New opbLgr(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Result
		End Function
		Public Property Balance() As Double
			Get
				Return _Balance
			End Get
			Set(ByVal value As Double)
				_Balance = value
			End Set
		End Property
		Public Property LeaveType() As String
			Get
				Return _LeaveType
			End Get
			Set(ByVal value As String)
				_LeaveType = value
			End Set
		End Property
		Sub New(ByVal rd As SqlDataReader)
			_LeaveType = rd("LeaveTypeID")
			_Balance = rd("sdays")
		End Sub
		Sub New()
			'dummy
		End Sub
	End Class
End Class
