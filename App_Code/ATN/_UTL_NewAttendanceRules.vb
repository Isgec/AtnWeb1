Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Namespace SIS.SYS.Utilities
	Public Class NewAttendanceRules
		Private Shared FileUnderProcess As String = ""
		Private Shared ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		Private Shared LocationWiseCardPunchDate As String = ""
		Private Shared ProcessingDate As DateTime
		Private Shared Sub DeleteAdvanceApplication(ByVal _atnd As SIS.ATN.atnNewAttendance)
			'Attendance Times and status are updated, 
			'delete the corresponding Ledger Record
			'and remove the application details from punch record, as it was not applied
			'delete the application header, if it was last record in application
			Dim _Lgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(_atnd.AttenID)
			'There may be two records in ledger for Ist half and IInd Half
			For Each _lgr As SIS.ATN.atnLeaveLedger In _Lgrs
				SIS.ATN.atnLeaveLedger.Delete(_lgr)
			Next
			Dim _aplHeaderID As Integer = _atnd.ApplHeaderID
			With _atnd
				.Applied = False
				.AdvanceApplication = False
				.ApplHeaderID = ""
				.Applied1LeaveTypeID = ""
				.Applied2LeaveTypeID = ""
				.AppliedValue = ""
				.ApplStatusID = ""
				.Posted = False
				.Posted1LeaveTypeID = ""
				.Posted2LeaveTypeID = ""
				.FinalValue = .PunchValue
			End With
			SIS.ATN.atnNewAttendance.Update(_atnd)
			'check there are records left in application
			Dim _tmps As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.GetAttendanceByApplHeaderID(_aplHeaderID)
			If _tmps.Count = 0 Then
				Dim _hdr As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(_aplHeaderID)
				SIS.ATN.atnApplHeader.Delete(_hdr)
			End If
		End Sub
		Private Shared Sub PostAdvanceApplication(ByVal _atnd As SIS.ATN.atnNewAttendance)
			Dim _Lgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(_atnd.AttenID)
			'There is no Change, POST the application line
			If _atnd.PunchValue = 0 Then
				_atnd.Posted = True
				_atnd.ApplStatusID = 6
				_atnd.FinalValue = 1
				SIS.ATN.atnNewAttendance.Update(_atnd)
				For Each _lgr As SIS.ATN.atnLeaveLedger In _Lgrs
					_lgr.Days = -1 * _lgr.InProcessDays
					_lgr.InProcessDays = 0
					_lgr.TranDate = Now
					SIS.ATN.atnLeaveLedger.Update(_lgr)
				Next
			End If
			'There is Full Change, Employee Present
			If _atnd.PunchValue = 1 Then
				Dim _aplHeaderID As Integer = _atnd.ApplHeaderID
				With _atnd
					.Applied = False
					.AdvanceApplication = False
					.ApplHeaderID = ""
					.Applied1LeaveTypeID = ""
					.Applied2LeaveTypeID = ""
					.AppliedValue = ""
					.ApplStatusID = ""
					.Posted = False
					.Posted1LeaveTypeID = ""
					.Posted2LeaveTypeID = ""
					.FinalValue = 1
				End With
				SIS.ATN.atnNewAttendance.Update(_atnd)
				For Each _lgr As SIS.ATN.atnLeaveLedger In _Lgrs
					SIS.ATN.atnLeaveLedger.Delete(_lgr)
				Next
				'Delete the Header, If there is no more line in Application
				Dim _tmps As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.GetAttendanceByApplHeaderID(_aplHeaderID)
				If _tmps.Count = 0 Then
					Dim _tmp As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(_aplHeaderID)
					SIS.ATN.atnApplHeader.Delete(_tmp)
				End If
			End If
			'There is Partial Change
			If _atnd.PunchValue = 0.5 Then
				If _Lgrs.Count > 1 Then
					For Each _lgr As SIS.ATN.atnLeaveLedger In _Lgrs
						If _atnd.PunchStatusID = "AF" Then
							If _lgr.LeaveTypeID = _atnd.Posted2LeaveTypeID Then
								SIS.ATN.atnLeaveLedger.Delete(_lgr)
							End If
							If _lgr.LeaveTypeID = _atnd.Posted1LeaveTypeID Then
								_lgr.Days = -0.5
								_lgr.InProcessDays = 0
								_lgr.TranDate = Now
								SIS.ATN.atnLeaveLedger.Update(_lgr)
							End If
						Else ' Punch Status ID = AS,TS
							If _lgr.LeaveTypeID = _atnd.Posted1LeaveTypeID Then
								SIS.ATN.atnLeaveLedger.Delete(_lgr)
							End If
							If _lgr.LeaveTypeID = _atnd.Posted2LeaveTypeID Then
								_lgr.Days = -0.5
								_lgr.InProcessDays = 0
								_lgr.TranDate = Now
								SIS.ATN.atnLeaveLedger.Update(_lgr)
							End If
						End If
					Next
				Else 'Lgr.Count = 1
					For Each _lgr As SIS.ATN.atnLeaveLedger In _Lgrs
						_lgr.Days = -0.5
						_lgr.InProcessDays = 0
						_lgr.TranDate = Now
						SIS.ATN.atnLeaveLedger.Update(_lgr)
					Next
				End If
				With _atnd
					If _atnd.PunchStatusID = "AF" Then
						.Applied2LeaveTypeID = ""
						.Posted2LeaveTypeID = ""
					Else	'Punch Status ID = AS,TS
						.Applied1LeaveTypeID = ""
						.Posted1LeaveTypeID = ""
					End If
					.AppliedValue = 0.5
					.Posted = True
					.ApplStatusID = 6
					.FinalValue = 1
				End With
				SIS.ATN.atnNewAttendance.Update(_atnd)
			End If
			'Update Header
			'If Not complete change and header record is there
			If _atnd.ApplHeaderID <> String.Empty Then
				Dim _hdr As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(_atnd.ApplHeaderID)
				With _hdr
					Dim Found As Boolean = False
					Dim oAplDet As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.GetAttendanceByApplHeaderID(_hdr.LeaveApplID)
					For Each _det As SIS.ATN.atnNewAttendance In oAplDet
						If Not _det.Posted Then
							Found = True
							Exit For
						End If
					Next
					If Found Then
						.ApplStatusID = 5
						.ExecutionState = 2
					Else
						.ApplStatusID = 6
						.ExecutionState = 3
					End If
					.PostingRemark = "Auto Posted"
					.PostedOn = Now
					.PostedBy = HttpContext.Current.Session("LoginID")
				End With
				SIS.ATN.atnApplHeader.Update(_hdr)
			End If
		End Sub
		Private Shared Sub ActualProcess(ByVal DataDate As DateTime, ByVal oEmp As SIS.ATN.atnEmployees, ByVal ImportRawData As Boolean)
			ProcessingDate = DataDate
			If oEmp.C_DateOfJoining = String.Empty Then
				Exit Sub
			End If
			'=>Delete Punch Records of Before Joining
			'Do not process records of Not Joined By date
			If DateDiff(DateInterval.Day, DataDate, Convert.ToDateTime(oEmp.C_DateOfJoining, ci)) > 0 Then
				Exit Sub
			End If
			If oEmp.C_DateOfReleaving <> String.Empty Then
				'=>Delete Punch Data of After Releaving
				'Do not process Records of Releaved Employees by Releaving Date
				If DateDiff(DateInterval.Day, Convert.ToDateTime(oEmp.C_DateOfReleaving, ci), DataDate) > 0 Then
					Exit Sub
				End If
			End If
			Dim CardNo As String = oEmp.CardNo
			'For Contractual Employee
			If oEmp.Contractual Then
				'Check Credited Leave record for the Month is created or not
				Dim oLgr As SIS.ATN.atnBalanceTransfer = SIS.ATN.atnBalanceTransfer.GetOPBRecordForMonth(oEmp.CardNo, Month(DataDate))
				'Credit 2 CL for Month
				'On prorate with DOJ
				Dim crDays As Single = 0
				If Month(oEmp.C_DateOfJoining) = Month(DataDate) And Year(oEmp.C_DateOfJoining) = Year(DataDate) Then
					Select Case Convert.ToDateTime(oEmp.C_DateOfJoining).Day
						Case Is >= 24
							crDays = 2
						Case Is >= 17
							crDays = 1.5
						Case Is >= 12
							crDays = 1
						Case Is >= 4
							crDays = 0.5
					End Select
				Else
					If Convert.ToDateTime(oEmp.C_DateOfJoining, ci) < Convert.ToDateTime(DataDate, ci) Then
						crDays = 2
					End If
				End If
				If oLgr Is Nothing Then
					oLgr = New SIS.ATN.atnBalanceTransfer
					With oLgr
						.CardNo = oEmp.CardNo
						.TranType = "OPB"
						.SubTranType = "MC"
						.TranDate = DataDate
						.LeaveTypeID = "CL"
						.FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
						.Remarks = "Monthly Credit " & crDays & " CL for " & MonthName(DataDate.Month, True)
						.Days = crDays
					End With
					SIS.ATN.atnBalanceTransfer.Insert(oLgr)
				Else
					With oLgr
						.CardNo = oEmp.CardNo
						.TranType = "OPB"
						.SubTranType = "MC"
						.TranDate = DataDate
						.LeaveTypeID = "CL"
						.FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
						.Remarks = "Monthly Credit " & crDays & " CL for " & MonthName(DataDate.Month, True)
						.Days = crDays
					End With
					SIS.ATN.atnBalanceTransfer.MonthlyCreditUpdate(oLgr)
				End If
			End If
			'End For Contractual Employee

			Dim OfficeID As Integer = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(oEmp.C_OfficeID)
			Dim oHld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(DataDate, OfficeID)

			Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDate(CardNo, DataDate)
			If oAtnd Is Nothing Then
				oAtnd = New SIS.ATN.atnNewAttendance
				With oAtnd
					.CardNo = CardNo
					.AttenDate = DataDate
					.Punch1Time = 0
					.Punch2Time = 0
					.PunchStatusID = "AD"
					.PunchValue = 0
					.FinalValue = 0
					.NeedsRegularization = True
					.HoliDay = IIf(oHld Is Nothing, False, True)
				End With
				oAtnd.AttenID = SIS.ATN.atnNewAttendance.Insert(oAtnd)
			Else

				oAtnd.HoliDay = IIf(oHld Is Nothing, False, True)
				SIS.ATN.atnNewAttendance.Update(oAtnd)
			End If

			'Update Punch Time and Status by New Values from Raw Punch
			'1. Only when user has not applied
			'2. User has applied but in advance
			'   2.1. This record is not posted
			'3. Attendance Record is not Mannually Edited
			'
			If Not oAtnd.MannuallyCorrected Then
				If Not oAtnd.Applied Then
					If ImportRawData Then
						UpdateAttendanceFromRawData(oAtnd, OfficeID)
					End If
				Else
					If oAtnd.AdvanceApplication Then
						If Not oAtnd.Posted Then
							'Check If the Advance Application is Approved or not
							'If not Approved, Delete It,
							'If not under posting, i.e. not approved
							If oAtnd.ApplStatusID = 5 Then	'Under Posting
								If ImportRawData Then
									UpdateAttendanceFromRawData(oAtnd, OfficeID)
								End If
								PostAdvanceApplication(oAtnd)
							Else
								If ImportRawData Then
									UpdateAttendanceFromRawData(oAtnd, OfficeID)
								End If
								'Delete this Application Line, or complete Application
								'This Delete is Stopped in new system
								'*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
								'DeleteAdvanceApplication(oAtnd)
								'*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
							End If
						End If
					End If
				End If
			Else ' Mannually Corrected
				'Do not update card punch data from file
				'for this just delete the import line in coped logic
				If oAtnd.Applied Then
					If oAtnd.AdvanceApplication Then
						If Not oAtnd.Posted Then
							'Check If the Advance Application is Approved or not
							'If not Approved, Delete It,
							'If not under posting, i.e. not approved
							If oAtnd.ApplStatusID = 5 Then	'Under Posting
								PostAdvanceApplication(oAtnd)
							Else
								'Delete this Application Line, or complete Application
								'This Delete is Stopped in new system
								'*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
								'DeleteAdvanceApplication(oAtnd)
								'*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
							End If
						End If
					End If
				End If
			End If
			'========================================
			'In All Case
			UpdateInterweavingHolidays(oAtnd.AttenID)
			'========================================
		End Sub
		Private Shared Function IsValidPunchLocation(ByVal OfficeID As Integer, ByVal PunchLocation As Integer) As Boolean
			Dim mRet As Boolean = False
			If OfficeID = PunchLocation Then Return True
			'Site Employee can Punch in any Office
			If OfficeID = 6 Then Return True
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT * FROM ATN_PunchLocationsByOffice WHERE OfficeID = " & OfficeID & " AND AllowedPunchLocation = " & PunchLocation
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						mRet = True
					End If
					Reader.Close()
				End Using
			End Using
			Return mRet
		End Function
		Private Shared Sub UpdateAttendanceFromRawData(ByVal oAtnd As SIS.ATN.atnNewAttendance, ByVal OfficeID As Integer)
			Try

				Dim CardNo As String = oAtnd.CardNo
				Dim DataDate As DateTime = Convert.ToDateTime(oAtnd.AttenDate, ci)

				Dim AtndWasTS As Boolean = IIf(oAtnd.PunchStatusID = "TS", True, False)
				Dim AtndWasFP As Boolean = IIf(oAtnd.ConfigStatus = "FP" Or oAtnd.ConfigStatus = "LF", True, False)

				'Get Raw Punch
        Dim oRaw As SIS.ATN.atnRawPunch = SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(CardNo, oAtnd.AttenDate)
				'Punch Required
				Dim oPunchReq As SIS.ATN.atnPunchRequired = SIS.ATN.atnPunchRequired.GetPunchRequiredByCardNo(CardNo)
				Dim UseException As Boolean = False
				If Not oPunchReq Is Nothing Then
					UseException = oPunchReq.RuleException
				End If
				'Active Configuration
				Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(DataDate, OfficeID))
				'Get Calender
				Dim oHld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(DataDate, OfficeID)
        If Not oAtnd.AdvanceApplication Then
          '1.
          If Not oHld Is Nothing Then
            With oAtnd
              .Punch1Time = 0
              .Punch2Time = 0
              .PunchStatusID = oHld.PunchStatusID
              .PunchValue = 1
              .FinalValue = 1
              .NeedsRegularization = False
              .FirstPunchMachine = ""
              .SecondPunchMachine = ""
            End With
            SIS.ATN.atnNewAttendance.Update(oAtnd)
            Return  '**********
          End If
          '2.
          If Not oPunchReq Is Nothing Then
            If oPunchReq.NoPunch Then
              With oAtnd
                .Punch1Time = oCnf.STD1Time
                .Punch2Time = oCnf.STD2Time
                .PunchStatusID = "PR"
                .PunchValue = 1
                .FinalValue = 1
                .NeedsRegularization = False
                .FirstPunchMachine = ""
                .SecondPunchMachine = ""
              End With
              SIS.ATN.atnNewAttendance.Update(oAtnd)
              Return  '**********
            End If
          End If
          '3.
          If oRaw Is Nothing Then
            With oAtnd
              If OfficeID = 6 Then
                'For Site Employees
                '=======Commented on 31st Dec 2017========'
                '.Punch1Time = 9
                '.Punch2Time = 17.45
                '.PunchStatusID = "PR"
                '.PunchValue = 1
                '.FinalValue = 0
                '.NeedsRegularization = False
                '.SiteAttendance = True
                '========End Commented===================='
                '========New Values======================='
                .Punch1Time = 0
                .Punch2Time = 0
                .PunchStatusID = "AD"
                .PunchValue = 0
                .FinalValue = 0
                .NeedsRegularization = True
                .SiteAttendance = True
                '===============End New Value=============='
                .FirstPunchMachine = ""
                .SecondPunchMachine = ""
              Else
                .Punch1Time = 0
                .Punch2Time = 0
                .PunchStatusID = "AD"
                .PunchValue = 0
                .FinalValue = 0
                .NeedsRegularization = True
                .FirstPunchMachine = ""
                .SecondPunchMachine = ""
              End If
            End With
            SIS.ATN.atnNewAttendance.Update(oAtnd)
            Return  '**********
          End If
        End If 'End NOT Advance Application

        If Not oRaw Is Nothing Then
					'----Location Wise Card Punch Restriction of First Punch----
					'----Started from 19th March 2012----
					If LocationWiseCardPunchDate <> String.Empty Then
						Dim ImplementedOn As DateTime = Convert.ToDateTime(LocationWiseCardPunchDate, ci)
						If DataDate > ImplementedOn Then
							Dim MachineID As Integer = Convert.ToUInt32(oRaw.FirstPunchMachine.Split("-".ToCharArray)(0))
							'====================================
							' Read Actual Office ID from Employee Table, Not the parameter passed to this function,
							' Which is converted office ID for Holidays List
							Dim tEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
							'====================================
							'Location wise punch checking validation
							If Not oPunchReq Is Nothing Then
								If oPunchReq.AllLocation Then
									oAtnd.Punch1Time = oRaw.Punch1Time
									oAtnd.Punch2Time = oRaw.Punch2Time
								Else
                  If Not IsValidPunchLocation(IIf(oAtnd.OfficeID = "", tEmp.C_OfficeID, oAtnd.OfficeID), MachineID) Then
                    oAtnd.Punch1Time = oRaw.Punch2Time
                    oAtnd.Punch2Time = 0.0
                  Else
                    oAtnd.Punch1Time = oRaw.Punch1Time
                    oAtnd.Punch2Time = oRaw.Punch2Time
                  End If
								End If
							Else
                If Not IsValidPunchLocation(IIf(oAtnd.OfficeID = "", tEmp.C_OfficeID, oAtnd.OfficeID), MachineID) Then
                  oAtnd.Punch1Time = oRaw.Punch2Time
                  oAtnd.Punch2Time = 0.0
                Else
                  oAtnd.Punch1Time = oRaw.Punch1Time
                  oAtnd.Punch2Time = oRaw.Punch2Time
                End If
							End If
							'Location Wise
						Else
							oAtnd.Punch1Time = oRaw.Punch1Time
							oAtnd.Punch2Time = oRaw.Punch2Time
						End If
					Else
						oAtnd.Punch1Time = oRaw.Punch1Time
						oAtnd.Punch2Time = oRaw.Punch2Time
					End If
					'----End Of Locationwise Card Punch Checking----
					oAtnd.FirstPunchMachine = oRaw.FirstPunchMachine
					oAtnd.SecondPunchMachine = oRaw.SecondPunchMachine
					SIS.ATN.atnNewAttendance.Update(oAtnd)

					'If Convert.ToDecimal(oAtnd.Punch1Time) > 0 Then
					'	If Convert.ToDecimal(oRaw.Punch1Time) < Convert.ToDecimal(oAtnd.Punch1Time) Then
					'		oAtnd.Punch1Time = oRaw.Punch1Time
					'	End If
					'Else
					'	oAtnd.Punch1Time = oRaw.Punch1Time
					'End If
					'If Convert.ToDecimal(oRaw.Punch2Time) > Convert.ToDecimal(oAtnd.Punch2Time) Then
					'	oAtnd.Punch2Time = oRaw.Punch2Time
					'End If
				End If

				'This is again if not adv applied
				If Not oAtnd.AdvanceApplication Then
					If Not oPunchReq Is Nothing Then
						If oPunchReq.OnePunch Then
							If Convert.ToDecimal(oAtnd.Punch1Time) > 0 Or Convert.ToDecimal(oAtnd.Punch2Time) > 0 Then
								With oAtnd
									.Punch1Time = oCnf.STD1Time
									.Punch2Time = oCnf.STD2Time
									.PunchStatusID = "PR"
									.PunchValue = 1
									.FinalValue = 1
									.NeedsRegularization = False
									.FirstPunchMachine = ""
									.SecondPunchMachine = ""
								End With
								SIS.ATN.atnNewAttendance.Update(oAtnd)
								Return	 '**********
							End If
						End If
					End If
				End If


				Dim oConfs As List(Of SIS.ATN.atnPunchConfigDetails) = SIS.ATN.atnPunchConfigDetails.GetByConfigID(oCnf.RecordID, "")
				For Each cnf As SIS.ATN.atnPunchConfigDetails In oConfs
					If Not UseException Then
						If cnf.ExceptionRule Then Continue For
					Else
						If Not cnf.ExceptionRule Then Continue For
					End If
					If Convert.ToDecimal(oAtnd.Punch1Time) >= Convert.ToDecimal(cnf.FPStartTime) And Convert.ToDecimal(oAtnd.Punch1Time) <= Convert.ToDecimal(cnf.FPEndTime) Then
						If Convert.ToDecimal(oAtnd.Punch2Time) >= Convert.ToDecimal(cnf.SPStartTime) And Convert.ToDecimal(oAtnd.Punch2Time) <= Convert.ToDecimal(cnf.SPEndTime) Then
							Dim Matched As Boolean = True
							If cnf.CalculateHours Then
								Dim HrsWorked As Double = 0
								If cnf.UseDefined Then
									HrsWorked = DiffTime(cnf.DefinedTime, oAtnd.Punch2Time)
								Else
									HrsWorked = DiffTime(oAtnd.Punch1Time, oAtnd.Punch2Time)
								End If
								Select Case cnf.HoursStatus
									Case "<"
										If HrsWorked >= Convert.ToDecimal(cnf.HoursValue) Then
											Matched = False
										End If
									Case ">="
										If HrsWorked < Convert.ToDecimal(cnf.HoursValue) Then
											Matched = False
										End If
								End Select
							End If
							If Matched Then
								oAtnd.ConfigID = cnf.ConfigID
								oAtnd.ConfigDetailID = cnf.SerialNo
								oAtnd.ConfigStatus = cnf.ConfigStatus
								If cnf.LimitedAllowed Then
									'first update oatnd then get count
									SIS.ATN.atnNewAttendance.Update(oAtnd)
									Dim LimitCount As Integer = SIS.ATN.atnNewAttendance.GetConfigCount(CardNo, DataDate, cnf.ConfigStatus)
									Dim Availed As Integer = SIS.ATN.atnNewAttendance.GetFPAvailed(CardNo, DataDate)
									If LimitCount <= Convert.ToInt32(cnf.LimitCount) Then
										oAtnd.PunchStatusID = cnf.LimitPunchStatus
									Else
										oAtnd.PunchStatusID = cnf.NormalPunchStatus
									End If
									'To Send Mail In Case of FP

									If cnf.ConfigStatus = "FP" Or cnf.ConfigStatus = "LF" Then
										If Not AtndWasFP Then
											Dim EMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(oAtnd.CardNo)
											If EMailID <> "" Then
												Try
													Dim oClient As SmtpClient = New SmtpClient()
													Dim oMsg As New System.Net.Mail.MailMessage
													Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(oAtnd.CardNo)
													With oMsg
														.IsBodyHtml = True
														.To.Add(EMailID)
														.CC.Add("tsld@isgec.co.in")
														.Subject = "SIS Attendance System [FP]"
														Dim mStr As String = "<table border=""0"" cellspacing=""0"" cellpadding=""0"">"
														mStr = mStr & "<tr><td><b>Dear " & oEmp.EmployeeName & ",</b></td></tr>"
														mStr = mStr & "<tr><td><b>Attendance Date :</b>" & oAtnd.AttenDate & "</td></tr>"
														mStr = mStr & "<tr><td><b>Ist Punch Time :</b>" & oAtnd.Punch1Time & "</td></tr>"
														mStr = mStr & "<tr><td><b>IInd Punch Time :</b>00.00</td></tr>"
														mStr = mStr & "<tr><td>Your IInd card punch not found.</td></tr>"
														If Availed <= Convert.ToInt32(cnf.LimitCount) Then
															mStr = mStr & "<tr><td>Clear your absent status using Regularize Forget Punch.</td></tr>"
															mStr = mStr & "<tr><td>Your can Regularize FP upto <b>" & cnf.LimitCount & "</b> times. Allready used : <b>" & Availed & "</b></td></tr>"
														End If
														mStr = mStr & "<tr><td>For further clarification in this regard, you may contact to Time Office.</td></tr>"
														mStr = mStr & "<tr><td>Thanx.</td></tr>"
														mStr = mStr & "</table>"
														.Body = mStr
													End With
													oClient.Send(oMsg)

												Catch ex As Exception

												End Try
											End If
										End If
									End If
									'End Of FP Mail
								Else 'No Limit
									oAtnd.PunchStatusID = cnf.NormalPunchStatus
								End If
								'It Is Hard Coded Must Be Picked From ATN_PunchStatus
								' Add One More Field in NeedsRegularization
								Select Case oAtnd.PunchStatusID
									Case "PR"
										oAtnd.PunchValue = 1
										oAtnd.FinalValue = 1
										oAtnd.NeedsRegularization = False
									Case "AF", "AS"
										oAtnd.PunchValue = 0.5
										oAtnd.FinalValue = 0.5
										oAtnd.NeedsRegularization = True
									Case "AD"
										oAtnd.PunchValue = 0
										oAtnd.FinalValue = 0
										oAtnd.NeedsRegularization = True
									Case "TS"
										oAtnd.PunchValue = 0.5
										oAtnd.FinalValue = 0.5		 'Auto Leave Not Posted
										oAtnd.NeedsRegularization = False
										oAtnd.TSStatus = "TS"
                End Select
                If oAtnd.AdvanceApplication Then
                  oAtnd.AppliedValue = 1 - oAtnd.FinalValue
                End If
								SIS.ATN.atnNewAttendance.Update(oAtnd)

								If oAtnd.PunchStatusID <> "TS" Then
									''If AtndWasTS Then
									''	'Delete Autoposted Lgr Record
									''	Dim _Lgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(oAtnd.AttenID)
									''	For Each _lgr As SIS.ATN.atnLeaveLedger In _Lgrs
									''		SIS.ATN.atnLeaveLedger.Delete(_lgr)
									''	Next
									''End If
								Else
									If Not AtndWasTS Then
										' ''Create Autoposted LgrRecord
										''Dim _lgr As New SIS.ATN.atnLeaveLedger
										''With _lgr
										''	.ApplDetailID = oAtnd.AttenID
										''	.ApplHeaderID = ""
										''	.CardNo = oAtnd.CardNo
										''	.Days = -0.5
										''	.InProcessDays = 0
										''	.LeaveTypeID = "CL"	'Get user's balance leaves
										''	.TranDate = oAtnd.AttenDate
										''	.TranType = "TRN"
										''End With
										''SIS.ATN.atnLeaveLedger.Insert(_lgr)
										'Send Mail
										'Copy must be send to common ID
										Dim EMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(oAtnd.CardNo)
										If EMailID <> "" Then
											Try
												Dim oClient As SmtpClient = New SmtpClient()
												Dim oMsg As New System.Net.Mail.MailMessage
												Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(oAtnd.CardNo)
												With oMsg
													.IsBodyHtml = True
													.To.Add(EMailID)
													.CC.Add("tsld@isgec.co.in")
													.Subject = "SIS Attendance System [TS]"
													Dim mStr As String = "<table border=""0"" cellspacing=""0"" cellpadding=""0"">"
													mStr = mStr & "<tr><td><b>Dear " & oEmp.EmployeeName & ",</b></td></tr>"
													mStr = mStr & "<tr><td><b>Attendance Date :</b>" & oAtnd.AttenDate & "</td></tr>"
													mStr = mStr & "<tr><td><b>Ist Punch Time :</b>" & oAtnd.Punch1Time & "</td></tr>"
													mStr = mStr & "<tr><td><b>IInd Punch Time :</b>" & oAtnd.Punch2Time & "</td></tr>"
													mStr = mStr & "<tr><td>Required working hours/day is short.</td></tr>"
													mStr = mStr & "<tr><td>For further clarification in this regard, you may contact to Time Office.</td></tr>"
													mStr = mStr & "<tr><td>Thanx.</td></tr>"
													mStr = mStr & "</table>"
													.Body = mStr
												End With
												oClient.Send(oMsg)

											Catch ex As Exception

											End Try
										End If
									End If
								End If
								'When Matched Exit Loop
								Exit For
							End If 'End of Matched
						End If
					End If
				Next
			Catch ex As Exception
				Throw ex
			End Try
		End Sub
		Private Shared Sub ReadRawDataFiles(ByVal DataDate As String)
			Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(DataDate, 1))
			Dim dtStr As String = Convert.ToDateTime(DataDate, ci).ToString("ddMMyy")
			Dim oFiles() As String = IO.Directory.GetFiles(oCnf.DataFileLocation, "*" & dtStr & ".txt", IO.SearchOption.TopDirectoryOnly)
			If oFiles.Count > 0 Then
				'Clean All the Data For Date
				SIS.ATN.atnRawPunch.DeleteRawPunchByDate(DataDate)
			End If
			For Each mFile As String In oFiles
				FileUnderProcess = IO.Path.GetFileName(mFile)
				ReadRawDataFile(mFile, DataDate)
			Next
		End Sub
		Private Shared Sub ReadRawDataFiles(ByVal DataDate As String, ByVal CardNo As String)
			Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(DataDate, 1))
			Dim dtStr As String = Convert.ToDateTime(DataDate, ci).ToString("ddMMyy")
			Dim oFiles() As String = IO.Directory.GetFiles(oCnf.DataFileLocation, "*" & dtStr & ".txt", IO.SearchOption.TopDirectoryOnly)
			If oFiles.Count > 0 Then
				'Clean All the Data For Date For Employee
				SIS.ATN.atnRawPunch.DeleteRawPunchByCardNoAndDate(CardNo, DataDate)
			End If
			For Each mFile As String In oFiles
				FileUnderProcess = IO.Path.GetFileName(mFile)
				ReadRawDataFile(mFile, DataDate, CardNo)
			Next
		End Sub
		Private Shared Sub ReadRawDataFile(ByVal FileName As String, ByVal DataDate As DateTime, ByVal CardNo As String)
			Dim oTR As IO.StreamReader = New IO.StreamReader(FileName)
			Dim mStr As String = oTR.ReadLine

			'Get Card Replacment
			Dim ReplacedCardNo As String = CardNo
			Dim oRepl As SIS.ATN.atnCardReplacement = SIS.ATN.atnCardReplacement.GetByCardNo(CardNo)
			If Not oRepl Is Nothing Then
				ReplacedCardNo = oRepl.ReplacedCardNo
			End If
			'End of Card Replacement

			Do While Not mStr Is Nothing
				Dim aStr() As String = mStr.Split(" ".ToCharArray)
				Dim _CardNo As String = ""
				'aStr(1).Trim()
				Dim _PunchTime As String = ""
				Dim _Found As Integer = 0
				For Each _str As String In aStr
					If _str <> String.Empty Then
						If _Found = 0 Then
							_CardNo = _str
							_Found = 1
						Else
							_PunchTime = _str
							Exit For
						End If
					End If
				Next

				If _CardNo <> ReplacedCardNo Then
					mStr = oTR.ReadLine
					Continue Do
				End If

				Dim strPunchTime As String = _PunchTime
				If strPunchTime = "" Then
					strPunchTime = "00:00"
				End If

				Dim PunchTime As Decimal = Convert.ToDecimal(strPunchTime.Replace(":", "."))

				Dim oRawPunch As SIS.ATN.atnRawPunch = SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(CardNo, DataDate)
				Dim Found As Boolean = True
				If oRawPunch Is Nothing Then
					oRawPunch = New SIS.ATN.atnRawPunch
					With oRawPunch
						.CardNo = CardNo
						.PunchDate = DataDate
						.FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
						.Processed = False
					End With
					Found = False
				End If

				With oRawPunch
					If .Punch1Time <= 0 Then
						.Punch1Time = PunchTime
						.FirstPunchMachine = FileUnderProcess
					Else
						If .Punch2Time <= 0 Then
							If PunchTime >= .Punch1Time Then
								.Punch2Time = PunchTime
								.SecondPunchMachine = FileUnderProcess
							Else
								.Punch2Time = .Punch1Time
								.SecondPunchMachine = .FirstPunchMachine
								.Punch1Time = PunchTime
								.FirstPunchMachine = FileUnderProcess
							End If
						Else
							If PunchTime > .Punch2Time Then
								.Punch2Time = PunchTime
								.SecondPunchMachine = FileUnderProcess
							Else
								If PunchTime < .Punch1Time Then
									.Punch1Time = PunchTime
									.FirstPunchMachine = FileUnderProcess
								End If
							End If
						End If
					End If
				End With

				If Found Then
					SIS.ATN.atnRawPunch.Update(oRawPunch)
				Else
					SIS.ATN.atnRawPunch.Insert(oRawPunch)
				End If

				mStr = oTR.ReadLine
			Loop
			oTR.Close()
		End Sub
		Private Shared Sub ReadRawDataFile(ByVal FileName As String, ByVal DataDate As DateTime)
			Dim oTR As IO.StreamReader = New IO.StreamReader(FileName)
			Dim mStr As String = oTR.ReadLine
			Do While Not mStr Is Nothing
				Dim aStr() As String = mStr.Split(" ".ToCharArray)

				Dim _CardNo As String = ""
				Dim _PunchTime As String = ""
				Dim _Found As Integer = 0
				For Each _str As String In aStr
					If _str <> String.Empty Then
						If _Found = 0 Then
							_CardNo = _str
							_Found = 1
						Else
							_PunchTime = _str
							Exit For
						End If
					End If
				Next


				Dim ReplacedCardNo As String = _CardNo
				Dim CardNo As String = ReplacedCardNo

				'Get Card Replacment
				Dim oRepl As SIS.ATN.atnCardReplacement = SIS.ATN.atnCardReplacement.GetByID(ReplacedCardNo)
				If Not oRepl Is Nothing Then
					CardNo = oRepl.CardNo
				End If
				'End of Card Replacement

				Dim strPunchTime As String = ""
				If strPunchTime = "" Then
					strPunchTime = _PunchTime
				End If
				If strPunchTime = "" Then
					strPunchTime = "00:00"
				End If

				Dim PunchTime As Decimal = Convert.ToDecimal(strPunchTime.Replace(":", "."))

				Dim oRawPunch As SIS.ATN.atnRawPunch = SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(CardNo, DataDate)
				Dim Found As Boolean = True
				If oRawPunch Is Nothing Then
					oRawPunch = New SIS.ATN.atnRawPunch
					With oRawPunch
						.CardNo = CardNo
						.PunchDate = DataDate
						.FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
						.Processed = False
					End With
					Found = False
				End If

				With oRawPunch
					If .Punch1Time <= 0 Then
						.Punch1Time = PunchTime
						.FirstPunchMachine = FileUnderProcess
					Else
						If .Punch2Time <= 0 Then
							If PunchTime >= .Punch1Time Then
								.Punch2Time = PunchTime
								.SecondPunchMachine = FileUnderProcess
							Else
								.Punch2Time = .Punch1Time
								.SecondPunchMachine = .FirstPunchMachine
								.Punch1Time = PunchTime
								.FirstPunchMachine = FileUnderProcess
							End If
						Else
							If PunchTime > .Punch2Time Then
								.Punch2Time = PunchTime
								.SecondPunchMachine = FileUnderProcess
							Else
								If PunchTime < .Punch1Time Then
									.Punch1Time = PunchTime
									.FirstPunchMachine = FileUnderProcess
								End If
							End If
						End If
					End If
				End With

				If Found Then
					SIS.ATN.atnRawPunch.Update(oRawPunch)
				Else
					SIS.ATN.atnRawPunch.Insert(oRawPunch)
				End If

				mStr = oTR.ReadLine
			Loop
			oTR.Close()
		End Sub
		Private Shared Function GetStatus(ByVal _atn As SIS.ATN.atnNewAttendance, ByRef _old As String) As String
			With _atn
				If .PunchValue > 0 Then
					Return "PR"
				Else 'Absent
					If .ApplStatusID < 6 Then	'Not Posted
						Return "AD"
					Else 'Application is posted
						Select Case .Applied1LeaveTypeID Or .Applied2LeaveTypeID
							Case "CL"
								Select Case _old
									Case ""
								End Select
						End Select

					End If

				End If
			End With
			Return "AD"
		End Function

		Private Shared Sub RevertHLD(ByVal _sts As AtnSts)
			Dim oHld As SIS.ATN.atnHolidays = Nothing
			oHld = SIS.ATN.atnHolidays.GetByHoliday(_sts.AttenDate, _sts.OfficeID)
			If Not oHld Is Nothing Then
				Do While Not oHld Is Nothing
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(_sts.CardNo, _sts.AttenDate)
					If Not oTmp Is Nothing Then
						If Not oTmp.Applied Then
							If oTmp.FinalValue = 0 Then
								With oTmp
									.Punch1Time = 0
									.Punch2Time = 0
									.PunchStatusID = oHld.PunchStatusID
									.PunchValue = 1
									.FinalValue = 1
									.NeedsRegularization = False
								End With
								SIS.ATN.atnProcessedPunch.Update(oTmp)
							End If
						End If
					End If
					_sts = GetPSts(_sts)
					If _sts Is Nothing Then
						Exit Do
					End If
					oHld = SIS.ATN.atnHolidays.GetByHoliday(_sts.AttenDate, _sts.OfficeID)
				Loop
			End If
		End Sub
		Private Shared Sub AbsentHLD(ByVal _sts As AtnSts)
			Dim oHld As SIS.ATN.atnHolidays = Nothing
			oHld = SIS.ATN.atnHolidays.GetByHoliday(_sts.AttenDate, _sts.OfficeID)
			If Not oHld Is Nothing Then
				Do While Not oHld Is Nothing
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(_sts.CardNo, _sts.AttenDate)
					If Not oTmp Is Nothing Then
						If Not oTmp.Applied Then
							If oTmp.FinalValue = 1 Then
								With oTmp
									.PunchStatusID = "AD"
									.PunchValue = 0
									.FinalValue = 0
									.NeedsRegularization = True
								End With
								SIS.ATN.atnProcessedPunch.Update(oTmp)
							End If
						End If
					End If
					_sts = GetPSts(_sts)
					If _sts Is Nothing Then
						Exit Do
					End If
					oHld = SIS.ATN.atnHolidays.GetByHoliday(_sts.AttenDate, _sts.OfficeID)
				Loop
			End If
		End Sub
    Private Shared Function GetNSts(ByVal cSts As AtnSts, Optional ByVal LeaveClubbing As Boolean = False) As AtnSts
      Dim _atnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDate(cSts.CardNo, Convert.ToDateTime(cSts.AttenDate, ci).AddDays(1))
      If Not _atnd Is Nothing Then
        Return New AtnSts(_atnd, cSts.OfficeID, cSts.CategoryID, cSts.Contractual, LeaveClubbing)
      End If
      Return New AtnSts
    End Function
    Private Shared Function GetPSts(ByVal cSts As AtnSts, Optional ByVal LeaveClubbing As Boolean = False) As AtnSts
      Dim _atnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDate(cSts.CardNo, Convert.ToDateTime(cSts.AttenDate, ci).AddDays(-1))
      If Not _atnd Is Nothing Then
        Return New AtnSts(_atnd, cSts.OfficeID, cSts.CategoryID, cSts.Contractual, LeaveClubbing)
      End If
      Return New AtnSts
    End Function
    Public Shared Function AddTime(ByVal T1 As Double, ByVal T2 As Double) As Double
			Dim T1Minutes As Integer = System.Decimal.Truncate(T1) * 60 + (T1 - System.Decimal.Truncate(T1)) * 100
			Dim T2Minutes As Integer = System.Decimal.Truncate(T2) * 60 + (T2 - System.Decimal.Truncate(T2)) * 100
			Dim T3Minutes As Integer = T1Minutes + T2Minutes
			Dim T4 As Double = Math.Floor(T3Minutes / 60) + ((T3Minutes Mod 60) / 100)
			Return T4
		End Function
		Public Shared Function DiffTime(ByVal T1 As Double, ByVal T2 As Double) As Double
			Dim d1 As DateTime = DateAndTime.TimeSerial(Math.Floor(T1), (T1 - Math.Floor(T1)) * 100, 0)
			Dim d2 As DateTime = DateAndTime.TimeSerial(Math.Floor(T2), (T2 - Math.Floor(T2)) * 100, 0)
			Dim t3 As Integer = DateDiff(DateInterval.Minute, d1, d2)
			Dim t4 As Integer = Math.Floor(t3 / 60)
			Dim t5 As Integer = t3 Mod 60
			Dim t6 As Double = Convert.ToInt32(t4) + (t5 / 100)
			Return t6
		End Function
		Public Shared Sub ConvertPR2AD(ByVal AttenID As Integer)
			Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(AttenID)
			If Not oAtnd Is Nothing Then
				If oAtnd.PunchStatusID = "PR" Or oAtnd.PunchStatusID = "WO" Or oAtnd.PunchStatusID = "HD" Then
					With oAtnd
						.Punch1Time = 0
						.Punch2Time = 0
						.Punch9Time = 0
						.PunchStatusID = "AD"
						.NeedsRegularization = True
						.PunchValue = 0
						.FinalValue = 0
						.MannuallyCorrected = True
					End With
					SIS.ATN.atnNewAttendance.Update(oAtnd)
				End If
			End If
		End Sub
		Public Shared Sub UpdateAttendanceStatusByTime(ByVal AttenID As Integer)
			Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(AttenID)
			Dim CardNo As String = oAtnd.CardNo
			Dim DataDate As DateTime = Convert.ToDateTime(oAtnd.AttenDate, ci)

			Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(DataDate, SIS.ATN.atnEmployees.GetByID(oAtnd.CardNo).C_OfficeID))

			Dim oConfs As List(Of SIS.ATN.atnPunchConfigDetails) = SIS.ATN.atnPunchConfigDetails.GetByConfigID(oCnf.RecordID, "")
			For Each cnf As SIS.ATN.atnPunchConfigDetails In oConfs
				If cnf.ExceptionRule Then Continue For
				If Convert.ToDecimal(oAtnd.Punch1Time) >= Convert.ToDecimal(cnf.FPStartTime) And Convert.ToDecimal(oAtnd.Punch1Time) <= Convert.ToDecimal(cnf.FPEndTime) Then
					If Convert.ToDecimal(oAtnd.Punch2Time) >= Convert.ToDecimal(cnf.SPStartTime) And Convert.ToDecimal(oAtnd.Punch2Time) <= Convert.ToDecimal(cnf.SPEndTime) Then
						Dim Matched As Boolean = True
						If cnf.CalculateHours Then
							Dim HrsWorked As Double = 0
							If cnf.UseDefined Then
								HrsWorked = DiffTime(cnf.DefinedTime, oAtnd.Punch2Time)
							Else
								HrsWorked = DiffTime(oAtnd.Punch1Time, oAtnd.Punch2Time)
							End If
							Select Case cnf.HoursStatus
								Case "<"
									If HrsWorked >= Convert.ToDecimal(cnf.HoursValue) Then
										Matched = False
									End If
								Case ">="
									If HrsWorked < Convert.ToDecimal(cnf.HoursValue) Then
										Matched = False
									End If
							End Select
						End If
						If Matched Then
							oAtnd.ConfigID = cnf.ConfigID
							oAtnd.ConfigDetailID = cnf.SerialNo
							oAtnd.ConfigStatus = cnf.ConfigStatus
							If cnf.LimitedAllowed Then
								'first update oatnd then get count
								SIS.ATN.atnNewAttendance.Update(oAtnd)
								Dim LimitCount As Integer = SIS.ATN.atnNewAttendance.GetConfigCount(CardNo, DataDate, cnf.ConfigStatus)
								If LimitCount <= Convert.ToInt32(cnf.LimitCount) Then
									oAtnd.PunchStatusID = cnf.LimitPunchStatus
								Else
									oAtnd.PunchStatusID = cnf.NormalPunchStatus
								End If
							Else 'No Limit
								oAtnd.PunchStatusID = cnf.NormalPunchStatus
							End If
							'It Is Hard Coded Must Be Picked From ATN_PunchStatus
							' Add One More Field in NeedsRegularization
							Select Case oAtnd.PunchStatusID
								Case "PR"
									oAtnd.PunchValue = 1
									oAtnd.FinalValue = 1
									oAtnd.NeedsRegularization = False
								Case "AF", "AS"
									oAtnd.PunchValue = 0.5
									oAtnd.FinalValue = 0.5
									oAtnd.NeedsRegularization = True
								Case "AD"
									oAtnd.PunchValue = 0
									oAtnd.FinalValue = 0
									oAtnd.NeedsRegularization = True
								Case "TS"
									oAtnd.PunchValue = 0.5
									oAtnd.FinalValue = 0.5		 'Auto Leave Not Posted
									oAtnd.NeedsRegularization = False
									oAtnd.TSStatus = "TS"
							End Select
							SIS.ATN.atnNewAttendance.Update(oAtnd)
							UpdateInterweavingHolidays(oAtnd.AttenID)
							Exit For
						End If 'End of Matched
					End If
				End If
			Next
		End Sub
		Public Shared Sub UpdateLateComing(ByVal AttenID As Integer)
			Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(AttenID)
			If oAtnd Is Nothing Then Exit Sub
			If Not oAtnd.NeedsRegularization Then Exit Sub
			If oAtnd.Applied Then Exit Sub
			If oAtnd.Punch1Time <= 0 Then Exit Sub
			If oAtnd.Punch2Time < 17.45 Then Exit Sub
			If oAtnd.Punch1Time > 10.3 Then Exit Sub
			With oAtnd
				.PunchStatusID = "PR"
				.PunchValue = 1
				.NeedsRegularization = False
				.FinalValue = 1
				.MannuallyCorrected = True
				.Purpose = "Late Coming Manually Corrected By: " & Global.System.Web.HttpContext.Current.Session("LoginID") & " ON: " & Now.ToString
			End With
			SIS.ATN.atnNewAttendance.Update(oAtnd)
		End Sub

    'Public Shared Sub newUpdateInterweavingHolidays(ByVal AttenID As Integer, Optional ByVal cSts As AtnSts = Nothing, Optional ByVal xSts As AtnSts = Nothing)
    '  Dim tSts As AtnSts = Nothing
    '  Dim pSts As AtnSts = Nothing
    '  Dim hSts As AtnSts = Nothing
    '  Try
    '    If cSts Is Nothing Then
    '      cSts = New AtnSts(SIS.ATN.atnNewAttendance.GetByID(AttenID))
    '      xSts = cSts
    '    End If
    '    Select Case cSts.Status
    '      Case "PR"
    '        pSts = GetPSts(cSts)
    '        Select Case pSts.Status
    '          Case "PR"
    '            'do nothing
    '          Case "HD"
    '            'do nothing
    '          Case "AD"
    '            If pSts.Holiday Then
    '              RevertHLD(pSts)
    '            End If
    '        End Select
    '      Case "HD"
    '        pSts = GetPSts(cSts)
    '        Select Case pSts.Status
    '          Case "PR"
    '            'do nothing
    '          Case "HD"
    '            UpdateInterweavingHolidays(0, pSts, xSts)
    '          Case "AD"
    '            If pSts.LeaveType <> "CL" Then
    '              AbsentHLD(xSts)
    '            ElseIf pSts.LeaveType = "CL" Then
    '              tSts = GetPSts(pSts)
    '              Do While Not tSts Is Nothing
    '                If tSts.LeaveType <> "CL" Then
    '                  Exit Do
    '                End If
    '                tSts = GetPSts(tSts)
    '              Loop
    '              If Not tSts Is Nothing Then
    '                If tSts.Status = "AD" Then
    '                  AbsentHLD(xSts)
    '                ElseIf tSts.Status = "HD" Then
    '                  UpdateInterweavingHolidays(0, tSts, xSts)
    '                End If
    '              End If
    '            End If
    '        End Select
    '      Case "AD"
    '        pSts = GetPSts(cSts)
    '        Select Case pSts.Status
    '          Case "PR"
    '            If xSts.Holiday Then
    '              RevertHLD(xSts)
    '            End If
    '          Case "AD"
    '            UpdateInterweavingHolidays(0, pSts, xSts)
    '          Case "HD"
    '            UpdateInterweavingHolidays(0, pSts, xSts)
    '        End Select
    '    End Select
    '  Catch ex As Exception
    '    Throw ex
    '  End Try
    'End Sub


    Public Shared Sub UpdateInterweavingHolidays(ByVal AttenID As Integer)
      Dim tSts As AtnSts = Nothing
      Dim pSts As AtnSts = Nothing
      Dim hSts As AtnSts = Nothing
      Try
        Dim cSts As AtnSts = New AtnSts(SIS.ATN.atnNewAttendance.GetByID(AttenID))

        Select Case cSts.Status
          Case "PR"
            pSts = GetPSts(cSts)
            If pSts.Status = "PR" Then
              'do nothing
            ElseIf pSts.Status = "HD" Then
              'do nothing
            ElseIf pSts.Status = "AD" Then
              If pSts.Holiday Then
                RevertHLD(pSts)
              End If
            End If
          Case "HD"
            pSts = GetPSts(cSts)
            If pSts.Status = "PR" Then
              'allready HD
              'do nothing
            ElseIf pSts.Status = "HD" Then
              'allready HD
              'do nothing
            ElseIf pSts.Status = "AD" Then
              If pSts.LeaveType <> "CL" Then 'Any Leave Type or Not Applied or OD
                AbsentHLD(cSts)
              ElseIf pSts.LeaveType = "CL" Then
                tSts = GetPSts(pSts)
                Do While Not tSts Is Nothing
                  If tSts.LeaveType <> "CL" Then
                    Exit Do
                  End If
                  tSts = GetPSts(tSts)
                Loop
                If Not tSts Is Nothing Then
                  If tSts.Status = "AD" Then
                    If tSts.LeaveType <> "OD" Then  'not applied or any other Leavetype
                      AbsentHLD(cSts)
                    End If
                  End If
                End If
              End If
            End If
          Case "AD"
            pSts = GetPSts(cSts)
            If pSts.Status = "PR" Then
              'do nothing
            ElseIf pSts.Status = "HD" Then
              'check to convert HD -> AD
              'in both cases Applied/Not Applied
              If cSts.LeaveType = "OD" Then   '$$$$Or cSts.LeaveType = "CL"
                'do nothing
              Else 'not applied or any other leave type
                tSts = GetPSts(pSts)
                Do While Not tSts Is Nothing
                  If tSts.Status <> "HD" Then
                    Exit Do
                  End If
                  tSts = GetPSts(tSts)
                Loop
                If Not tSts Is Nothing Then
                  If tSts.Status = "AD" Then
                    If tSts.LeaveType <> "OD" And tSts.LeaveType <> "CL" Then
                      AbsentHLD(pSts)
                    ElseIf tSts.LeaveType = "CL" Then
                      hSts = GetPSts(tSts)
                      Do While Not hSts Is Nothing
                        If hSts.LeaveType <> "CL" Then
                          Exit Do
                        End If
                        hSts = GetPSts(hSts)
                      Loop
                      If Not hSts Is Nothing Then
                        If hSts.Status = "AD" Then
                          If hSts.LeaveType <> "OD" Then
                            AbsentHLD(pSts)
                          End If
                        End If
                      End If
                    End If
                  End If
                End If
              End If
            ElseIf pSts.Status = "AD" Then
              If pSts.Holiday Then
                'check to convert AD -> HD
                'in both cases Applied/Not Applied
                If cSts.LeaveType = "OD" Or cSts.LeaveType = "CL" Then
                  RevertHLD(pSts)
                Else ' Not Applied or any Other Leave Type, then check Other end of holiday
                  tSts = GetPSts(pSts)
                  Do While Not tSts Is Nothing
                    If Not tSts.Holiday Then
                      Exit Do
                    End If
                    tSts = GetPSts(tSts)
                  Loop
                  If Not tSts Is Nothing Then
                    If tSts.Status = "PR" Or tSts.Status = "HD" Then
                      RevertHLD(pSts)
                    ElseIf tSts.Status = "AD" Then
                      If tSts.LeaveType = "OD" Then
                        RevertHLD(pSts)
                      ElseIf tSts.LeaveType = "CL" Then
                        hSts = GetPSts(tSts)
                        Do While Not hSts Is Nothing
                          If hSts.LeaveType <> "CL" Then
                            Exit Do
                          End If
                          hSts = GetPSts(hSts)
                        Loop
                        If Not hSts Is Nothing Then
                          If hSts.Status = "PR" Or hSts.Status = "HD" Then
                            RevertHLD(pSts)
                          ElseIf hSts.Status = "AD" Then
                            If hSts.LeaveType = "OD" Then
                              RevertHLD(pSts)
                            End If
                          End If
                        Else
                          RevertHLD(pSts)
                        End If
                      End If
                    End If
                  Else
                    RevertHLD(pSts)
                  End If
                End If
              End If
            End If
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Private Shared Function ApplyLeaveContext(ByVal cSts As AtnSts, ByVal lvContext As SIS.ATN.LeaveContext) As AtnSts
      If cSts IsNot Nothing Then
        If cSts.LeaveType = String.Empty Then
          For Each lcd As SIS.ATN.LeaveContextDetail In lvContext.LeaveContextDetails
            If cSts.AttenID = lcd.AttenID Then
              If lcd.LeaveType1 = "PL" Or lcd.LeaveType2 = "PL" Then
                cSts.LeaveType = "PL"
              End If
              If lcd.LeaveType1 = "SL" Or lcd.LeaveType2 = "SL" Then
                cSts.LeaveType = "SL"
              End If
              If lcd.LeaveType1 = "CL" Or lcd.LeaveType2 = "CL" Then
                cSts.LeaveType = "CL"
              End If
              If lcd.LeaveType1 = "" And lcd.LeaveType2 <> "" Then
                cSts.LeaveType = lcd.LeaveType2
              End If
              If lcd.LeaveType1 <> "" And lcd.LeaveType2 = "" Then
                cSts.LeaveType = lcd.LeaveType1
              End If
              If lcd.LeaveType1 = "OD" Or lcd.LeaveType2 = "OD" Then
                cSts.LeaveType = "OD"
                cSts.Status = "PR"
              End If
              If lcd.LeaveType1 = "FP" Or lcd.LeaveType2 = "FP" Then
                cSts.LeaveType = "FP"
                cSts.Status = "PR"
              End If
              Exit For
            End If
          Next
        End If
      End If
      Return cSts
    End Function
    Public Shared Function CheckLeaveByCombination(ByVal lcd As SIS.ATN.LeaveContextDetail, ByVal lvContext As SIS.ATN.LeaveContext) As atnRetVal
      Dim oAtnd As SIS.ATN.atnNewAttendance = Nothing
      If lvContext.IsAdvance Then
        oAtnd = New SIS.ATN.atnNewAttendance
        With oAtnd
          .AttenDate = lcd.AttenDate
          .AttenID = lcd.AttenID
          .Applied1LeaveTypeID = lcd.LeaveType1
          .Applied2LeaveTypeID = lcd.LeaveType2
          .Destination = lcd.Destination
          .Purpose = lcd.Purpose
          .AdvanceApplication = True
          .CardNo = lvContext.CardNo
        End With
      Else
        oAtnd = SIS.ATN.atnNewAttendance.GetByID(lcd.AttenID)
      End If
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(oAtnd.CardNo)
      Dim mRet As atnRetVal = New atnRetVal
      Dim tSts As AtnSts = Nothing
      Dim pSts As AtnSts = Nothing
      Dim nSts As AtnSts = Nothing
      Dim cbLT As String = "OD,ML,FP,CO,SH,SP,ST" 'Continuity Breaker Leave Types
      Dim cbST As String = "PR,AF,AS,TS,NH" 'Continuity Breaker Status
      Dim NAbCL As String = "AD,AL,AP,AS,LT,PL,SL" 'Not Allowed Before CL
      Dim stsDate As String = ""
      mRet.IsValid = True
      Try
        Dim cSts As AtnSts = ApplyLeaveContext(New AtnSts(oAtnd, True), lvContext)

        If cSts.Status = "AD" Then
          If cbLT.IndexOf(cSts.LeaveType) >= 0 Then
            'DO Nothing as it will breake the continuity
            mRet.IsValid = True
            Return mRet
          Else
            If cSts.LeaveType = "CL" Then
              'Then check previous days Leaves
              If Convert.ToDateTime(cSts.AttenDate) > Convert.ToDateTime(oEmp.C_DateOfJoining) Then
                stsDate = Convert.ToDateTime(cSts.AttenDate).AddDays(-1).ToString("dd/MM/yyyy")
                pSts = ApplyLeaveContext(GetPSts(cSts, True), lvContext)
              Else
                mRet.IsValid = True
                Return mRet
              End If
              Do While pSts IsNot Nothing
                'Continuity breaker Status
                If cbST.IndexOf(pSts.Status) >= 0 Then
                  mRet.IsValid = True
                  Return mRet
                Else
                  'continuity not breaked by status
                  'check continuity breaker Leave Types
                  If pSts.LeaveType <> String.Empty And cbLT.IndexOf(pSts.LeaveType) >= 0 Then
                    mRet.IsValid = True
                    Return mRet
                  Else
                    'If Not Allowed Leave Type found, Then Return False
                    If pSts.LeaveType <> String.Empty And NAbCL.IndexOf(pSts.LeaveType) >= 0 Then
                      mRet.IsValid = False
                      mRet.Message = "CL can not be applied on " & cSts.AttenDate & " because " & pSts.LeaveType & " is applied on " & stsDate
                      Return mRet
                    Else
                      'Either Not Applied or CL Applied, then continue checking to previous day
                      If Convert.ToDateTime(pSts.AttenDate) > Convert.ToDateTime(oEmp.C_DateOfJoining) Then
                        stsDate = Convert.ToDateTime(pSts.AttenDate).AddDays(-1).ToString("dd/MM/yyyy")
                        pSts = ApplyLeaveContext(GetPSts(pSts, True), lvContext)
                      Else
                        mRet.IsValid = True
                        Return mRet
                      End If
                    End If
                  End If
                End If
              Loop
              If pSts Is Nothing Then
                If Not lvContext.IsAdvance Then
                  mRet.IsValid = False
                  mRet.Message = "Attendance Data is missing for Date: " & stsDate & " Leave can not be applied."
                  Return mRet
                End If
              End If
            Else 'if NOT CL
              If NAbCL.IndexOf(cSts.LeaveType) >= 0 Then 'There should not be any CL after this
                'Then check next days Leaves
                stsDate = Convert.ToDateTime(cSts.AttenDate).AddDays(1).ToString("dd/MM/yyyy")
                nSts = ApplyLeaveContext(GetNSts(cSts, True), lvContext)
                Do While nSts IsNot Nothing
                  If cbST.IndexOf(nSts.Status) >= 0 Then
                    mRet.IsValid = True
                    Return mRet
                  Else
                    If nSts.LeaveType <> String.Empty And cbLT.IndexOf(nSts.LeaveType) >= 0 Then
                      mRet.IsValid = True
                      Return mRet
                    Else
                      If nSts.LeaveType = "CL" Then
                        mRet.IsValid = False
                        mRet.Message = cSts.LeaveType & " can not be applied on " & cSts.AttenDate & " because CL is applied on " & stsDate
                        Return mRet
                      Else
                        stsDate = Convert.ToDateTime(nSts.AttenDate).AddDays(1).ToString("dd/MM/yyyy")
                        nSts = ApplyLeaveContext(GetNSts(nSts, True), lvContext)
                      End If
                    End If
                  End If
                Loop
                If nSts Is Nothing Then
                  mRet.IsValid = True
                  Return mRet
                End If
              End If
            End If 'End of CL
          End If ' End of CBLT
        End If 'End of AD
      Catch ex As Exception
        mRet.IsValid = False
        mRet.Message = ex.Message
      End Try
      Return mRet
    End Function
    Public Shared Sub PostUnpostedAdavanceApplication(ByVal dt As DateTime, ByVal CardNo As String)
      Dim oAtnds As New List(Of SIS.ATN.atnNewAttendance)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "SELECT * FROM ATNv_UnpostedAdvanceApplication WHERE CardNo = '" & CardNo & "' AND AttenDate <= CONVERT(DATETIME,'" & dt.ToString("dd/MM/yyyy") & "', 103) AND FinYear = " & HttpContext.Current.Session("FinYear")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            oAtnds.Add(New SIS.ATN.atnNewAttendance(Reader))
          End If
          Reader.Close()
        End Using
      End Using
      For Each oAtnd As SIS.ATN.atnNewAttendance In oAtnds
        If oAtnd.AdvanceApplication Then
          If Not oAtnd.Posted Then
            'Check If the Advance Application is Approved or not
            'If not Approved, Delete It,
            'If not under posting, i.e. not approved
            '====
            Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(oAtnd.CardNo)
            Dim ImportRawData As Boolean = True
            Dim OfficeID As Integer = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(oEmp.C_OfficeID)
            '====
            If oAtnd.ApplStatusID = 5 Then  'Under Posting
              If ImportRawData Then
                UpdateAttendanceFromRawData(oAtnd, OfficeID)
              End If
              PostAdvanceApplication(oAtnd)
              UpdateInterweavingHolidays(oAtnd.AttenID)
            Else
              If ImportRawData Then
                UpdateAttendanceFromRawData(oAtnd, OfficeID)
              End If
              UpdateInterweavingHolidays(oAtnd.AttenID)
              'Delete this Application Line, or complete Application
              'This Delete is Stopped in new system
              '*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
              'DeleteAdvanceApplication(oAtnd)
              '*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
              'UpdateInterweavingHolidays(oAtnd.AttenID)
            End If
          End If
        End If
      Next
    End Sub

		Public Shared Function ProcessData(ByVal FromDate As String, ByVal ToDate As String, Optional ByVal CardNo As String = "", Optional ByVal ImportRawData As Boolean = False) As String
			Dim ErrStr As String = ""
			Dim LastProcessedData As String = ""
			Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
			HttpContext.Current.Server.ScriptTimeout = 1200
			LocationWiseCardPunchDate = ConfigurationManager.AppSettings("LocationWiseCardPunchDate")

			Dim fdt As DateTime = Convert.ToDateTime(FromDate, ci)
			Dim tdt As DateTime = Convert.ToDateTime(ToDate, ci)
			Dim xdt As DateTime = fdt
			'Without Employee Code
			If CardNo = "" Then
				If ImportRawData Then
					While xdt <= tdt
						Dim DataDate As String = xdt.ToString("dd/MM/yyyy")
						ReadRawDataFiles(DataDate)
						xdt = xdt.AddDays(1)
					End While
				End If
				Dim StartRow As Integer = 0
				Dim MaxRow As Integer = 10
				Dim oEmps As List(Of SIS.ATN.atnEmployees) = SIS.ATN.atnEmployees.SelectList(StartRow, MaxRow, "CardNo", False, "")
				Do While oEmps.Count > 0
					For Each oEmp As SIS.ATN.atnEmployees In oEmps
						LastProcessedData = oEmp.CardNo
						'================================
						'If C_OfficeID is blank then skip
						'================================
						If oEmp.C_OfficeID = "" Then
							If ErrStr = "" Then
								ErrStr = xdt.ToString("dd/MM/yyyy") & ", " & oEmp.CardNo & ", " & "Not Verified, Current Location is Blank"
							Else
								ErrStr = ErrStr & "|" & xdt.ToString("dd/MM/yyyy") & ", " & oEmp.CardNo & ", " & "Not Verified, Current Location is Blank"
							End If
							Continue For
						End If
						'================================
						Try
							xdt = fdt
							While xdt <= tdt
								LastProcessedData = oEmp.CardNo & ", " & xdt.ToString("dd/MM/yyyy")
                'ActualProcess(xdt, oEmp, ImportRawData)
                ActualProcess(xdt, oEmp, True)
                xdt = xdt.AddDays(1)
							End While
              '=====================
              'Process Advance Application
              Try
                PostUnpostedAdavanceApplication(tdt, oEmp.CardNo)
              Catch ex As Exception
                If ErrStr = "" Then
                  ErrStr = ex.Message
                Else
                  ErrStr = ErrStr & "|" & "<b>Error during Posting of Unposted Advance Application.</b>"
                End If
              End Try
              '=====================
            Catch ex As Exception
              If ErrStr = "" Then
                ErrStr = xdt.ToString("dd/MM/yyyy") & ", " & oEmp.CardNo & ", " & ex.Message
              Else
                ErrStr = ErrStr & "|" & xdt.ToString("dd/MM/yyyy") & ", " & oEmp.CardNo & ", " & ex.Message
              End If
						End Try
					Next
					StartRow += MaxRow
					oEmps = SIS.ATN.atnEmployees.SelectList(StartRow, MaxRow, "CardNo", False, "")
				Loop
			Else
				'With Employee Code
				If ImportRawData Then
					While xdt <= tdt
						Dim DataDate As String = xdt.ToString("dd/MM/yyyy")
						ReadRawDataFiles(DataDate, CardNo)
						xdt = xdt.AddDays(1)
					End While
				End If
				Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
				xdt = fdt
				While xdt <= tdt
          'ActualProcess(xdt, oEmp, ImportRawData)
          ActualProcess(xdt, oEmp, True)
          xdt = xdt.AddDays(1)
				End While
        '=====================
        'Process Advance Application
        Try
          PostUnpostedAdavanceApplication(tdt, oEmp.CardNo)
        Catch ex As Exception
          If ErrStr = "" Then
            ErrStr = ex.Message
          Else
            ErrStr = ErrStr & "|" & "<b>Error during Posting of Unposted Advance Application.</b>"
          End If
        End Try
        '=====================
      End If
			'=====================
      If ErrStr = "" Then
        ErrStr = LastProcessedData
      Else
        ErrStr = ErrStr & "|" & LastProcessedData
      End If
			HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
			Return ErrStr
		End Function

	End Class
	Public Class AtnSts
		Private _CardNo As String = ""
		Private _OfficeID As Integer = 1
		Private _AttenID As Integer
		Private _Status As String = ""
		Private _LeaveType As String = ""
		Private _AttenDate As String = ""
		Private _Holiday As Boolean = False
		Private _CategoryID As String = ""
		Private _Contractual As Boolean = False
    Public Property Contractual() As Boolean
      Get
        Return _Contractual
      End Get
      Set(ByVal value As Boolean)
        _Contractual = value
      End Set
    End Property
		Public Property CategoryID() As String
			Get
				Return _CategoryID
			End Get
			Set(ByVal value As String)
				_CategoryID = value
			End Set
		End Property
		Public Property OfficeID() As Integer
			Get
				Return _OfficeID
			End Get
			Set(ByVal value As Integer)
				_OfficeID = value
			End Set
		End Property
		Public Property CardNo() As String
			Get
				Return _CardNo
			End Get
			Set(ByVal value As String)
				_CardNo = value
			End Set
		End Property
		Public Property AttenID() As Integer
			Get
				Return _AttenID
			End Get
			Set(ByVal value As Integer)
				_AttenID = value
			End Set
		End Property
		Public Property Holiday() As Boolean
			Get
				Return _Holiday
			End Get
			Set(ByVal value As Boolean)
				_Holiday = value
			End Set
		End Property
		Public Property AttenDate() As String
			Get
				Return _AttenDate
			End Get
			Set(ByVal value As String)
				_AttenDate = value
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
		Public Property Status() As String
			Get
				Return _Status
			End Get
			Set(ByVal value As String)
				_Status = value
			End Set
		End Property
		Public Sub New()
			'dummy
    End Sub
    'New Init Me
    'Private Sub InitMe(ByVal pAtnd As SIS.ATN.atnNewAttendance, ByVal pOfficeID As Integer, ByVal pCategoryID As String, ByVal pContractual As Boolean)
    '  _AttenID = pAtnd.AttenID
    '  _AttenDate = pAtnd.AttenDate
    '  _Status = pAtnd.PunchStatusID
    '  _CardNo = pAtnd.CardNo
    '  _OfficeID = pOfficeID
    '  _CategoryID = pCategoryID
    '  _Contractual = pContractual
    '  _LeaveType = ""
    '  _Holiday = False
    '  Select Case pAtnd.PunchStatusID
    '    Case "AS", "AF", "TS", "PR", "NH"
    '      _Status = "PR"
    '    Case "WO", "HD"
    '      _Status = "HD"
    '      _Holiday = True
    '    Case "AD"
    '      If _CategoryID = "18" Or _CategoryID = "19" Or _Contractual Then
    '        _Status = "PR"
    '      ElseIf pAtnd.Applied And pAtnd.ApplStatusID = "6" Then
    '        If pAtnd.Applied1LeaveTypeID = "PL" Or pAtnd.Applied2LeaveTypeID = "PL" Then
    '          _LeaveType = "PL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "AD" Or pAtnd.Applied2LeaveTypeID = "AD" Then
    '          _LeaveType = "PL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "AL" Or pAtnd.Applied2LeaveTypeID = "AL" Then
    '          _LeaveType = "PL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "AP" Or pAtnd.Applied2LeaveTypeID = "AP" Then
    '          _LeaveType = "PL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "LT" Or pAtnd.Applied2LeaveTypeID = "LT" Then
    '          _LeaveType = "PL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "SL" Or pAtnd.Applied2LeaveTypeID = "SL" Then
    '          _LeaveType = "SL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "AS" Or pAtnd.Applied2LeaveTypeID = "AS" Then
    '          _LeaveType = "SL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "CL" Or pAtnd.Applied2LeaveTypeID = "CL" Then
    '          _LeaveType = "CL"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "OD" Or pAtnd.Applied2LeaveTypeID = "OD" Then
    '          _LeaveType = "OD"
    '          _Status = "PR"
    '        ElseIf pAtnd.Applied1LeaveTypeID = "FP" Or pAtnd.Applied2LeaveTypeID = "FP" Then
    '          _LeaveType = "FP"
    '          _Status = "PR"
    '        Else
    '          _LeaveType = pAtnd.Applied1LeaveTypeID
    '          _Status = "PR"
    '        End If
    '      End If
    '      Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
    '      Dim _hld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(Convert.ToDateTime(pAtnd.AttenDate, ci), OfficeID)
    '      If Not _hld Is Nothing Then
    '        _Holiday = True
    '      End If
    '  End Select
    'End Sub
    Private Sub InitMe(ByVal pAtnd As SIS.ATN.atnNewAttendance, ByVal pOfficeID As Integer, ByVal pCategoryID As String, ByVal pContractual As Boolean, Optional ByVal LeaveClubbing As Boolean = False)
      _AttenID = pAtnd.AttenID
      _AttenDate = pAtnd.AttenDate
      _Status = pAtnd.PunchStatusID
      _CardNo = pAtnd.CardNo
      _OfficeID = pOfficeID
      _CategoryID = pCategoryID
      _Contractual = pContractual
      _LeaveType = ""
      _Holiday = False
      Select Case pAtnd.PunchStatusID
        Case "AS", "AF", "TS", "PR", "NH"
          _Status = "PR"
        Case "WO", "HD"
          _Status = "HD"
          _Holiday = True
        Case "AD"
          If _CategoryID = "18" Or _CategoryID = "19" Or _Contractual Then
            _Status = "PR"
          Else
            If LeaveClubbing Then
              If pAtnd.Applied Then
                If pAtnd.Applied1LeaveTypeID = "PL" Or pAtnd.Applied2LeaveTypeID = "PL" Then
                  _LeaveType = "PL"
                End If
                If pAtnd.Applied1LeaveTypeID = "SL" Or pAtnd.Applied2LeaveTypeID = "SL" Then
                  _LeaveType = "SL"
                End If
                If pAtnd.Applied1LeaveTypeID = "CL" Or pAtnd.Applied2LeaveTypeID = "CL" Then
                  _LeaveType = "CL"
                End If
                If pAtnd.Applied1LeaveTypeID = "" And pAtnd.Applied2LeaveTypeID <> "" Then
                  _LeaveType = pAtnd.Applied2LeaveTypeID
                End If
                If pAtnd.Applied1LeaveTypeID <> "" And pAtnd.Applied2LeaveTypeID = "" Then
                  _LeaveType = pAtnd.Applied1LeaveTypeID
                End If
                If pAtnd.Applied1LeaveTypeID = "OD" Or pAtnd.Applied2LeaveTypeID = "OD" Then
                  _LeaveType = "OD"
                  _Status = "PR"
                End If
                If pAtnd.Applied1LeaveTypeID = "FP" Or pAtnd.Applied2LeaveTypeID = "FP" Then
                  _LeaveType = "FP"
                  _Status = "PR"
                End If
              End If
            Else
              If pAtnd.Applied And pAtnd.ApplStatusID = "6" Then
                If pAtnd.Applied1LeaveTypeID = "PL" Or pAtnd.Applied2LeaveTypeID = "PL" Then
                  _LeaveType = "PL"
                End If
                If pAtnd.Applied1LeaveTypeID = "SL" Or pAtnd.Applied2LeaveTypeID = "SL" Then
                  _LeaveType = "SL"
                End If
                If pAtnd.Applied1LeaveTypeID = "CL" Or pAtnd.Applied2LeaveTypeID = "CL" Then
                  _LeaveType = "CL"
                End If
                If pAtnd.Applied1LeaveTypeID = "" And pAtnd.Applied2LeaveTypeID <> "" Then
                  _LeaveType = pAtnd.Applied2LeaveTypeID
                End If
                If pAtnd.Applied1LeaveTypeID <> "" And pAtnd.Applied2LeaveTypeID = "" Then
                  _LeaveType = pAtnd.Applied1LeaveTypeID
                End If
                If pAtnd.Applied1LeaveTypeID = "OD" Or pAtnd.Applied2LeaveTypeID = "OD" Then
                  _LeaveType = "OD"
                  _Status = "PR"
                End If
                If pAtnd.Applied1LeaveTypeID = "FP" Or pAtnd.Applied2LeaveTypeID = "FP" Then
                  _LeaveType = "FP"
                  _Status = "PR"
                End If
              End If
            End If
            End If
          Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
          Dim _hld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(Convert.ToDateTime(pAtnd.AttenDate, ci), OfficeID)
          If Not _hld Is Nothing Then
            _Holiday = True
          End If
      End Select
    End Sub
    Public Sub New(ByVal pAtnd As SIS.ATN.atnNewAttendance, Optional ByVal LeaveClubbing As Boolean = False)
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(pAtnd.CardNo)
      InitMe(pAtnd, SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(oEmp.C_OfficeID), SIS.SYS.Utilities.BalanceTransfer.GetCategoryID(pAtnd.CardNo), oEmp.Contractual, LeaveClubbing)
    End Sub
    Public Sub New(ByVal pAtnd As SIS.ATN.atnNewAttendance, ByVal pOfficeID As Integer, Optional ByVal LeaveClubbing As Boolean = False)
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(pAtnd.CardNo)
      InitMe(pAtnd, pOfficeID, SIS.SYS.Utilities.BalanceTransfer.GetCategoryID(pAtnd.CardNo), oEmp.Contractual, LeaveClubbing)
    End Sub
    Public Sub New(ByVal pAtnd As SIS.ATN.atnNewAttendance, ByVal pOfficeID As Integer, ByVal pCategoryID As String, Optional ByVal LeaveClubbing As Boolean = False)
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(pAtnd.CardNo)
      InitMe(pAtnd, pOfficeID, pCategoryID, oEmp.Contractual, LeaveClubbing)
    End Sub
    Public Sub New(ByVal pAtnd As SIS.ATN.atnNewAttendance, ByVal pOfficeID As Integer, ByVal pCategoryID As String, ByVal pContractual As Boolean, Optional ByVal LeaveClubbing As Boolean = False)
      InitMe(pAtnd, pOfficeID, pCategoryID, pContractual, LeaveClubbing)
    End Sub
  End Class
  Public Class atnRetVal
    Public Property IsValid As Boolean = False
    Public Property Message As String = ""
  End Class

End Namespace
