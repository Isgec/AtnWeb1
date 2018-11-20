Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Namespace SIS.SYS.Utilities
	Public Class BalanceTransfer
		Private Shared ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		Dim oFyr As SIS.ATN.atnFinYear = SIS.ATN.atnFinYear.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
		Dim LastDate As DateTime = Convert.ToDateTime(oFyr.EndDate, ci)
		Dim advPL As Decimal = 0
		Public Sub Transfer(ByVal FCardNo As String, ByVal TCardNo As String, ByVal NewFinYear As Integer)
			Dim oEmps As List(Of SIS.ATN.atnEmployees) = SIS.ATN.atnEmployees.SelectList("CardNo")
			For Each oEmp As SIS.ATN.atnEmployees In oEmps
				If oEmp.CardNo >= FCardNo And oEmp.CardNo <= TCardNo Then
					Process(oEmp, NewFinYear)
				End If
			Next
		End Sub
		Public Sub Transfer(ByVal CardNo As String, ByVal NewFinYear As Integer)
			Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
			Process(oEmp, NewFinYear)
		End Sub
		Public Sub Transfer(ByVal NewFinYear As Integer)
			Dim oEmps As List(Of SIS.ATN.atnEmployees) = SIS.ATN.atnEmployees.SelectList("CardNo")
			For Each oEmp As SIS.ATN.atnEmployees In oEmps
				Process(oEmp, NewFinYear)
			Next
		End Sub
		Public Shared Function GetCategoryID(ByVal CardNo As String) As Integer
			Dim Results As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT CATEGORYID FROM PRK_EMPLOYEES WHERE CARDNO='" & CardNo & "'"
					Con.Open()
					Dim r As Object = Cmd.ExecuteScalar
					If Not r Is Nothing Then
						If Not r.ToString = String.Empty Then
							Results = Convert.ToInt32(r)
						End If
					End If
				End Using
			End Using
			Return Results
		End Function
		Private Function CalculateClosing(ByVal oBals As List(Of SIS.ATN.lgLedgerBalance), ByVal oEmp As SIS.ATN.atnEmployees, ByVal CategoryID As Integer) As List(Of SIS.ATN.lgLedgerBalance)
			Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
			advPL = 0
			For Each _lt As SIS.ATN.atnLeaveTypes In oLTs
				If _lt.CarryForward Then
					Dim LvBal As Decimal = 0
					For Each _bal As SIS.ATN.lgLedgerBalance In oBals
						If _bal.LeaveType = _lt.LeaveTypeID Then
							LvBal = _bal.Balance
						End If
					Next
					'If Advance PL Availed do not add in forwarded type
					'store this value and continue
					If _lt.LeaveTypeID = "AD" Then
						advPL = LvBal
						Continue For
					End If
					For Each _bal As SIS.ATN.lgLedgerBalance In oBals
						If _bal.LeaveType = _lt.ForwardToLeaveTypeID Then
							_bal.ClosingBalance += LvBal
						End If
						'AS Accumulation Check
						If _bal.LeaveType = "AS" Then	'Accumulated Sick
							If _bal.ClosingBalance > 30 Then
								_bal.ClosingBalance = 30
							End If
						End If
						'=============
					Next
				End If
				'======mistake correction==========
				If _lt.LeaveTypeID = "LT" Then
					Dim doit As Boolean = False
					If oEmp.C_DesignationID = "34" Or oEmp.C_DesignationID = "35" Or oEmp.C_DesignationID = "28" Then
						doit = True
					ElseIf oEmp.C_OfficeID = "6" Then
						doit = True
					ElseIf CategoryID = 19 Then
						doit = True
					ElseIf CategoryID = 18 Then
						doit = True
					End If
					If doit Then
						Dim LvBal As Decimal = 0
						For Each _bal As SIS.ATN.lgLedgerBalance In oBals
							If _bal.LeaveType = _lt.LeaveTypeID Then
								LvBal = _bal.Balance
							End If
						Next
						For Each _bal As SIS.ATN.lgLedgerBalance In oBals
							If _bal.LeaveType = "AP" Then
								_bal.ClosingBalance += LvBal
							End If
						Next
					End If
				End If
				'==================================
				If _lt.OBALApplicable Then
					For Each _bal As SIS.ATN.lgLedgerBalance In oBals
						If _bal.LeaveType = _lt.LeaveTypeID Then
							_bal.NewOpening = _lt.OpeningBalance
							_bal.OBALApplicable = True
							If _bal.LeaveType = "PL" Then
								'Overwrite Default Opening Balance of PL As per rule
								'IF GET, DET, ITI Trainee Eles Site Staff Else Cate XII Else Cate XI Else General Emp
								'G.E.T Designation ID =34, D.E.T. Designation ID = 35, ITI Trainee > 28
								'Site Emp C_OfficeID = 6
								'CategoryID XII => 19 F
								'CategoryID XI => 18 E
								If oEmp.C_DesignationID = "34" Or oEmp.C_DesignationID = "35" Or oEmp.C_DesignationID = "28" Then
									_bal.NewOpening = 15
								ElseIf oEmp.C_OfficeID = "6" Then
									_bal.NewOpening = 30
								ElseIf CategoryID = 19 Then
									_bal.NewOpening = 15
								ElseIf CategoryID = 18 Then
									_bal.NewOpening = 30
								End If
							End If
							If _bal.LeaveType = "LT" Then
								If oEmp.C_DesignationID = "34" Or oEmp.C_DesignationID = "35" Or oEmp.C_DesignationID = "28" Then
									_bal.NewOpening = 0
								ElseIf oEmp.C_OfficeID = "6" Then
									_bal.NewOpening = 0
								ElseIf CategoryID = 19 Then
									_bal.NewOpening = 0
								ElseIf CategoryID = 18 Then
									_bal.NewOpening = 0
								End If
							End If
						End If
					Next
				End If
			Next
			Return oBals
		End Function
		Private Sub Process(ByVal oEmp As SIS.ATN.atnEmployees, ByVal NewFinYear As Integer)
			'Mannuall Delete Contractual OPB Records from New Financial Year.
			'No Excel Macro is required
			'Manually Correct GET's who were confirmed last year.
			'================================
			'Skip transfer of Opening Balance
			If oEmp.C_DateOfJoining = String.Empty Then Exit Sub
			If DateDiff(DateInterval.Day, LastDate, Convert.ToDateTime(oEmp.C_DateOfJoining, ci)) > 0 Then Exit Sub
			If oEmp.C_DateOfReleaving <> String.Empty Then
				If DateDiff(DateInterval.Day, Convert.ToDateTime(oEmp.C_DateOfReleaving, ci), LastDate) > 0 Then Exit Sub
			End If
			'=================================
			'Get Employees Category
			Dim CardNo As String = oEmp.CardNo
			Dim CategoryID As Integer = SIS.SYS.Utilities.BalanceTransfer.GetCategoryID(CardNo)
			'==========================================================
			'Delete All OPB Records for BF,CR,DR Except Manual Entries
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "DELETE FROM ATN_LeaveLedger WHERE TRANTYPE = 'OPB' AND SUBTRANTYPE IN ('BF','CR','DB') AND CARDNO='" & CardNo & "' AND FINYEAR = " & NewFinYear
					Con.Open()
					Cmd.ExecuteNonQuery()
				End Using
			End Using
			'============================
			Dim oBals As List(Of SIS.ATN.lgLedgerBalance) = SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(oEmp.CardNo)
			oBals = CalculateClosing(oBals, oEmp, CategoryID)
			'=====================================
			'Proportionate PL and LTC based on DOJ
			If Convert.ToDateTime(oEmp.C_DateOfJoining, ci) > Convert.ToDateTime(oFyr.StartDate, ci) Then
				Dim WorkDays As Integer = 0
				Dim YrDays As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oFyr.StartDate, ci))
				WorkDays = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oEmp.C_DateOfJoining, ci))
				'Actual Work Days WorkDays Excluding LWP, Deduct LWP Days from WorkDays
				Dim ActualWorkDays As Single = 0
				ActualWorkDays = GetActualWorkDays(oEmp.CardNo, oFyr.FinYear)
				If ActualWorkDays < Math.Abs(WorkDays) Then
					WorkDays = -1 * ActualWorkDays
				End If
				'=============================
				For Each _bal As SIS.ATN.lgLedgerBalance In oBals
					If _bal.LeaveType = "PL" Or _bal.LeaveType = "LT" Then
						Dim tmp As Decimal = 0
						tmp = SIS.ATN.lgLedgerBalance.LvRoundof((_bal.NewOpening / YrDays) * WorkDays)
						_bal.NewOpening = tmp
					End If
				Next
			End If
			'=======================================
			'Insert /Update Opening Balance For New Year
			For Each _bal As SIS.ATN.lgLedgerBalance In oBals
				'===================================
				'Carry Forward
				If _bal.ClosingBalance > 0 Then
					Dim Found As Boolean = True
					Dim oBT As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "BF", NewFinYear, _bal.LeaveType, CardNo)
					If oBT Is Nothing Then
						Found = False
						oBT = SIS.ATN.atnBalanceTransfer.GetNewRecord()
						With oBT
							.TranType = "OPB"
							.SubTranType = "BF"
							.FinYear = NewFinYear
							.LeaveTypeID = _bal.LeaveType
							.CardNo = CardNo
							.Remarks = "Brought Forward"
							.TranDate = Now.ToString("dd/MM/yyyy")
						End With
					End If
					oBT.Days = _bal.ClosingBalance
					If Found Then SIS.ATN.atnBalanceTransfer.Update(oBT) Else SIS.ATN.atnBalanceTransfer.Insert(oBT)
				End If
				'=====================
				'New Openings
				If _bal.NewOpening > 0 Or _bal.LeaveType = "PL" Then
					Dim Found As Boolean = True
					Dim oBT As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "CR", NewFinYear, _bal.LeaveType, CardNo)
					If oBT Is Nothing Then
						Found = False
						oBT = SIS.ATN.atnBalanceTransfer.GetNewRecord()
						With oBT
							.TranType = "OPB"
							.SubTranType = "CR"
							.FinYear = NewFinYear
							.LeaveTypeID = _bal.LeaveType
							.CardNo = CardNo
							.Remarks = "Creditd this year"
							.TranDate = Now.ToString("dd/MM/yyyy")
						End With
					End If
					If _bal.LeaveType = "PL" Then
						oBT.Days = _bal.NewOpening - Math.Abs(advPL)
					Else
						oBT.Days = _bal.NewOpening
					End If
					If oBT.Days <> 0 Then
						If Found Then SIS.ATN.atnBalanceTransfer.Update(oBT) Else SIS.ATN.atnBalanceTransfer.Insert(oBT)
					End If
				End If
			Next
			'===============================
			'Paid EL Deduction
			Dim oPL As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "CR", NewFinYear, "PL", CardNo)
			Dim oAP As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "BF", NewFinYear, "AP", CardNo)
			Dim oAS As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "BF", NewFinYear, "AS", CardNo)
			Dim balPL As Decimal = 0
			Dim balAS As Decimal = 0
			Dim CompWith As Integer = 84
			If Not oAP Is Nothing Then
				balPL += oAP.Days
			End If
			If Not oPL Is Nothing Then
				balPL += oPL.Days
			End If
			'Compare With 90 for all these cases else with 84
			If oEmp.C_DesignationID = "34" Or oEmp.C_DesignationID = "35" Or oEmp.C_DesignationID = "28" Then
				CompWith = 90
			ElseIf oEmp.C_OfficeID = "6" Then
				CompWith = 90
			ElseIf CategoryID = 19 Then
				CompWith = 90
				If Not oAS Is Nothing Then
					balAS = oAS.Days
				End If
			ElseIf CategoryID = 18 Then
				CompWith = 90
				If Not oAS Is Nothing Then
					balAS = oAS.Days
				End If
			End If
			'================
			If balPL > CompWith Then
				Dim Found As Boolean = True
				Dim oDR As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "DR", NewFinYear, "AP", CardNo)
				If oDR Is Nothing Then
					Found = False
					oDR = SIS.ATN.atnBalanceTransfer.GetNewRecord()
					With oDR
						.TranType = "OPB"
						.SubTranType = "DR"
						.FinYear = NewFinYear
						.LeaveTypeID = "AP"
						.CardNo = CardNo
						.Remarks = "Debited for Encashment"
						.TranDate = Now.ToString("dd/MM/yyyy")
					End With
				End If
				oDR.Days = (-1) * (balPL - CompWith)
				If Found Then SIS.ATN.atnBalanceTransfer.Update(oDR) Else SIS.ATN.atnBalanceTransfer.Insert(oDR)
			Else
				'If balPL is < compwith then Find Encashment Record and delete
				Dim oDR As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "DR", NewFinYear, "AP", CardNo)
				If Not oDR Is Nothing Then
					SIS.ATN.atnBalanceTransfer.Delete(oDR)
				End If
			End If
			'============
			'Encashment of Acumulated Sick Leave in case of XI, XII
			'================
			If balAS > 0 Then
				Dim Found As Boolean = True
				Dim oDR As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "DR", NewFinYear, "AS", CardNo)
				If oDR Is Nothing Then
					Found = False
					oDR = SIS.ATN.atnBalanceTransfer.GetNewRecord()
					With oDR
						.TranType = "OPB"
						.SubTranType = "DR"
						.FinYear = NewFinYear
						.LeaveTypeID = "AS"
						.CardNo = CardNo
						.Remarks = "Debited for Encashment"
						.TranDate = Now.ToString("dd/MM/yyyy")
					End With
				End If
				oDR.Days = (-1) * (balAS)
				If Found Then SIS.ATN.atnBalanceTransfer.Update(oDR) Else SIS.ATN.atnBalanceTransfer.Insert(oDR)
			Else
				Dim oDR As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetByID("OPB", "DR", NewFinYear, "AS", CardNo)
				If Not oDR Is Nothing Then
					SIS.ATN.atnBalanceTransfer.Delete(oDR)
				End If
			End If
			'============
		End Sub
		Public Sub CreateOPBforNewJoinee(ByVal CardNo As String)
			Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
			If oEmp.Contractual Then Exit Sub
			If oEmp.ActiveState Then
				If Convert.ToDateTime(oEmp.C_DateOfJoining, ci) > Convert.ToDateTime(oFyr.StartDate, ci) Then
					Dim oLgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByCardNo(CardNo, "")
					For Each oLgr As SIS.ATN.atnLeaveLedger In oLgrs
						If oLgr.TranType = "OPB" Then
							If oLgr.LeaveTypeID = "CL" Or oLgr.LeaveTypeID = "SL" Then
								SIS.ATN.atnLeaveLedger.Delete(oLgr)
							End If
						End If
					Next
					Dim WorkDays As Integer = 0
					Dim YrDays As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oFyr.StartDate, ci))
					WorkDays = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oEmp.C_DateOfJoining, ci))
					Dim cCL As Single = SIS.ATN.lgLedgerBalance.LvRoundof((7 / YrDays) * WorkDays)
					Dim cSL As Single = SIS.ATN.lgLedgerBalance.LvRoundof((8 / YrDays) * WorkDays)
					Dim iLgr As SIS.ATN.atnLeaveLedger
					'Insert CL
					iLgr = New SIS.ATN.atnLeaveLedger
					With iLgr
						.CardNo = CardNo
						.Days = cCL
						.FinYear = SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear
						.InProcessDays = 0
						.LeaveTypeID = "CL"
						.TranDate = Now
						.TranType = "OPB"
					End With
					SIS.ATN.atnLeaveLedger.InsertOpeningBalance(iLgr)
					'Insert SL
					iLgr = New SIS.ATN.atnLeaveLedger
					With iLgr
						.CardNo = CardNo
						.Days = cSL
						.FinYear = SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear
						.InProcessDays = 0
						.LeaveTypeID = "SL"
						.TranDate = Now
						.TranType = "OPB"
					End With
					SIS.ATN.atnLeaveLedger.InsertOpeningBalance(iLgr)
				End If
			End If

		End Sub
		Private Shared Function GetActualWorkDays(ByVal CardNo As String, ByVal FinYear As String) As Single
			Dim mRet As Single = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT SUM(FinalValue) As WorkDays FROM ATN_Attendance WHERE CARDNO='" & CardNo & "' AND FINYEAR = " & FinYear
					Con.Open()
					mRet = Cmd.ExecuteScalar()
				End Using
			End Using
			Return mRet
		End Function
	End Class
End Namespace