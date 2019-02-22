Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnLeaveLedger
		Public Shared Function GetRPTLeaveLedger(ByVal CardNo As String, ByVal sDT As DateTime, ByVal tDT As DateTime) As List(Of SIS.ATN.atnLeaveLedger)
			Dim Results As List(Of SIS.ATN.atnLeaveLedger) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT * FROM ATN_LeaveLedger WHERE CardNo='" & CardNo & "' AND TranDate >= CONVERT(DATETIME,'" & sDT.ToString("dd/MM/yyyy") & "',103) AND TranDate <= CONVERT(DATETIME,'" & tDT.ToString("dd/MM/yyyy") & "',103) AND DAYS <> 0 AND FINYEAR = " & SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear & " ORDER BY TRANDATE,TRANTYPE"
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					Results = New List(Of SIS.ATN.atnLeaveLedger)
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnLeaveLedger(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetLeaveCardByCardNo1(ByVal CardNo As String, ByVal OrderBy As String) As List(Of SIS.ATN.atnLeaveLedger)
			Dim Results As List(Of SIS.ATN.atnLeaveLedger) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_LeaveCardByCardNo1"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnLeaveLedger)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnLeaveLedger(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetLeaveCardByCardNo(ByVal CardNo As String, ByVal OrderBy As String) As List(Of SIS.ATN.atnLeaveLedger)
			Dim Results As List(Of SIS.ATN.atnLeaveLedger) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_LeaveCardByCardNo"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnLeaveLedger)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnLeaveLedger(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetByApplDetailID(ByVal RecordID As Int32) As List(Of SIS.ATN.atnLeaveLedger)
			Dim Results As List(Of SIS.ATN.atnLeaveLedger) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_LeaveLedgerByApplDetailID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplDetailID", SqlDbType.Int, RecordID.ToString.Length, RecordID)
					Results = New List(Of SIS.ATN.atnLeaveLedger)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnLeaveLedger(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function InsertOpeningBalance(ByVal Record As SIS.ATN.atnLeaveLedger) As Int32
			Dim _Result As Int32 = Record.RecordID
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnLeaveLedgerInsert"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType", SqlDbType.NVarChar, 4, Record.TranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, Record.TranDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID", SqlDbType.NVarChar, 3, Record.LeaveTypeID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InProcessDays", SqlDbType.Decimal, 9, Record.InProcessDays)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Days", SqlDbType.Decimal, 9, Record.Days)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 5, Record.FinYear)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID", SqlDbType.Int, 11, IIf(Record.ApplHeaderID = "", Convert.DBNull, Record.ApplHeaderID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplDetailID", SqlDbType.Int, 11, IIf(Record.ApplDetailID = "", Convert.DBNull, Record.ApplDetailID))
					Cmd.Parameters.Add("@Return_RecordID", SqlDbType.Int, 10)
					Cmd.Parameters("@Return_RecordID").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@Return_RecordID").Value
				End Using
			End Using
			Return _Result
		End Function
		Public Shared Function GetLeaveBalByCardNoType(ByVal CardNo As String, ByVal LeaveType As String) As Decimal
			Dim Results As Decimal = 0.0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_LeaveBalByCardNoType"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveType", SqlDbType.NVarChar, 3, LeaveType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = Convert.ToDecimal(Reader("Balance"))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function CheckAppliedLeaves(ByVal Context As String) As String
			Dim oContext As LeaveContext = New LeaveContext(Context)
			Dim oLgrs As List(Of SIS.ATN.lgLedgerBalance) = SIS.ATN.lgLedgerBalance.GetLeadgerBalance(HttpContext.Current.Session("EmployeeUnderProcess"))
			For Each _detail In oContext.LeaveContextDetails
				For Each _lgr As lgLedgerBalance In oLgrs
					If _detail.AppliedDayType = "AD" Then
						If _detail.LeaveType1 = _lgr.LeaveType Then
							If _detail.LeaveType2 = String.Empty Then
								_lgr.InProcess += 1
								Exit For
							Else
								_lgr.InProcess += 0.5
							End If
						End If
						If _detail.LeaveType2 = _lgr.LeaveType Then
							_lgr.InProcess += 0.5
						End If
					Else
						If _detail.LeaveType1 = _lgr.LeaveType Then
							_lgr.InProcess += 0.5
							Exit For
						End If
					End If
				Next
			Next
			Return SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(oLgrs, Context)
		End Function
    Public Shared Function NewCheckAppliedLeaves(ByVal Context As String, Optional ByRef MaySubmit As Boolean = False) As String
      Try
        Dim oContext As LeaveContext = New LeaveContext(Context)
        oContext.CardNo = HttpContext.Current.Session("EmployeeUnderProcess")
        Dim oLgrs As List(Of SIS.ATN.lgLedgerBalance) = SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(HttpContext.Current.Session("EmployeeUnderProcess"))
        For Each _detail In oContext.LeaveContextDetails
          For Each _lgr As lgLedgerBalance In oLgrs
            If _lgr.MonthlyOpening Then
              If _detail.LeaveType1 = _lgr.LeaveType Or _detail.LeaveType2 = _lgr.LeaveType Then
                Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(_detail.AttenID)
                Dim Found As Boolean = False
                Dim _mBal As lgMonthlyLedgerBalance = Nothing
                For Each _mBal In _lgr.MonthlyData
                  If _mBal.ForMonth = Convert.ToDateTime(oAtnd.AttenDate).Month Then
                    Found = True
                    Exit For
                  End If
                Next
                If Not Found Then
                  _mBal = New lgMonthlyLedgerBalance
                  _mBal.OpeningBalance = _lgr.OpeningBalance
                  _mBal.ForMonth = Convert.ToDateTime(oAtnd.AttenDate).Month
                  _lgr.MonthlyData.Add(_mBal)
                End If
                _mBal.InProcess += 1
              End If
            Else
              If _detail.AppliedDayType = "AD" Then
                If _detail.LeaveType1 = _lgr.LeaveType Then
                  If _detail.LeaveType2 = String.Empty Then
                    _lgr.InProcess += 1
                    Exit For
                  Else
                    _lgr.InProcess += 0.5
                  End If
                End If
                If _detail.LeaveType2 = _lgr.LeaveType Then
                  _lgr.InProcess += 0.5
                End If
              Else
                If _detail.LeaveType1 = _lgr.LeaveType Then
                  _lgr.InProcess += 0.5
                  Exit For
                End If
                If _detail.LeaveType2 = _lgr.LeaveType Then
                  _lgr.InProcess += 0.5
                  Exit For
                End If
              End If
            End If
          Next
        Next
        MaySubmit = True
        Dim mRet As New SIS.SYS.Utilities.atnRetVal
        For Each lcd As LeaveContextDetail In oContext.LeaveContextDetails
          mRet = SIS.SYS.Utilities.NewAttendanceRules.CheckLeaveByCombination(lcd, oContext)
          If Not mRet.IsValid Then
            MaySubmit = False
            lcd.ErrorMessage = mRet.Message
          End If
        Next
        Return SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(oLgrs, Context, MaySubmit, oContext)
      Catch ex As Exception
        Return ex.Message
      End Try
    End Function
    Public Shared Function Backup_NewCheckAppliedLeaves(ByVal Context As String) As String
			Try
				Dim oContext As LeaveContext = New LeaveContext(Context)
				Dim oLgrs As List(Of SIS.ATN.lgLedgerBalance) = SIS.ATN.lgLedgerBalance.GetLeadgerBalance(HttpContext.Current.Session("EmployeeUnderProcess"))
				For Each _detail In oContext.LeaveContextDetails
					If _detail.LeaveType1 = "FP" Or _detail.LeaveType2 = "FP" Then
						'First Get Attendance Data, In Adv. Application FP is not available
						Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(_detail.AttenID)
						Dim oConfDet As SIS.ATN.atnPunchConfigDetails = SIS.ATN.atnPunchConfigDetails.GetByID(oAtnd.ConfigDetailID)
						Dim Availed As Integer = SIS.ATN.atnNewAttendance.GetFPAvailed(oAtnd.CardNo, oAtnd.AttenDate)
						Dim InProcess As Integer = SIS.ATN.atnNewAttendance.GetFPInProcess(oAtnd.CardNo, oAtnd.AttenDate)
						For Each _lgr As lgLedgerBalance In oLgrs
							If _lgr.LeaveType = "FP" Then
								With _lgr
									.OpeningBalance = oConfDet.LimitCount
									.Availed = Availed
									.InProcess = InProcess + 1
									.AdvanceApplicable = False
								End With
							End If
						Next
					ElseIf _detail.LeaveType1 = "SH" Or _detail.LeaveType2 = "SH" Then
						Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(_detail.AttenID)
						Dim SHobal As Integer = 0
						If Convert.ToDecimal(oAtnd.Punch1Time > 0 And oAtnd.Punch2Time > 0) Then
							If oAtnd.PunchStatusID = "AS" Or oAtnd.PunchStatusID = "AF" Or oAtnd.PunchStatusID = "TS" Then
								'For Morning Short Leave
								If Convert.ToDecimal(oAtnd.Punch2Time) >= 17.4 Then
									Dim hrs As Decimal = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(oAtnd.Punch1Time, 17.45)
									If hrs >= 6.45 Then
										SHobal = 2
									End If
								Else
									'Evening Short Time
									If Convert.ToDecimal(oAtnd.Punch1Time) <= 9.3 Then
										Dim FirstPunchTime As Decimal = 9.0
										If Convert.ToDecimal(oAtnd.Punch1Time) > 9.0 Then
											FirstPunchTime = oAtnd.Punch1Time
										End If
										Dim hrs As Decimal = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(FirstPunchTime, oAtnd.Punch2Time)
										If hrs >= 6.45 Then
											SHobal = 2
										End If
									End If
								End If
							End If
						End If
						Dim Availed As Integer = SIS.ATN.atnNewAttendance.GetSHAvailed(oAtnd.CardNo, oAtnd.AttenDate)
						Dim InProcess As Integer = SIS.ATN.atnNewAttendance.GetSHInProcess(oAtnd.CardNo, oAtnd.AttenDate)
						For Each _lgr As lgLedgerBalance In oLgrs
							If _lgr.LeaveType = "SH" Then
								With _lgr
									.OpeningBalance = SHobal
									.Availed = Availed
									.InProcess = InProcess + 1
									.AdvanceApplicable = False
								End With
							End If
						Next
					Else
						'OLD Rule
						For Each _lgr As lgLedgerBalance In oLgrs
							If _detail.AppliedDayType = "AD" Then
								If _detail.LeaveType1 = _lgr.LeaveType Then
									If _detail.LeaveType2 = String.Empty Then
										_lgr.InProcess += 1
										Exit For
									Else
										_lgr.InProcess += 0.5
									End If
								End If
								If _detail.LeaveType2 = _lgr.LeaveType Then
									_lgr.InProcess += 0.5
								End If
							Else
								If _detail.LeaveType1 = _lgr.LeaveType Then
									_lgr.InProcess += 0.5
									Exit For
								End If
								'======New Addition======
								If _detail.LeaveType2 = _lgr.LeaveType Then
									_lgr.InProcess += 0.5
									Exit For
								End If
								'======End New Addition======
							End If
						Next
					End If
				Next
				Return SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(oLgrs, Context)
			Catch ex As Exception
				Return ex.Message & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "<input type=""button"" onclick=""AppliedLeaveStatusOver('false');"" value=""Cancel"" />"
			End Try
		End Function
	End Class
	Public Class LeaveContext
		Private _Remarks As String = String.Empty
		Private _ContextDetails As New List(Of LeaveContextDetail)
		Private _SanctionRequired As Boolean = False
    Private _SanctionBy As String = String.Empty
    Public Property CardNo As String = ""
    Public Property FinYear As String = ""
    Public Property MonthID As String = ""
    Public Property For22to31Dec As Boolean = False
    Public Property SanctionBy() As String
      Get
        Return _SanctionBy
      End Get
      Set(ByVal value As String)
        _SanctionBy = value
      End Set
    End Property
    Public Property SanctionRequired() As Boolean
			Get
				Return _SanctionRequired
			End Get
			Set(ByVal value As Boolean)
				_SanctionRequired = value
			End Set
		End Property
		Public ReadOnly Property IsAdvance() As Boolean
			Get
				If _ContextDetails.Count > 0 Then
					If _ContextDetails(0).AttenID = 0 Then
						Return True
					End If
				End If
				Return False
			End Get
		End Property
		Public Property LeaveContextDetails() As List(Of LeaveContextDetail)
			Get
				Return _ContextDetails
			End Get
			Set(ByVal value As List(Of LeaveContextDetail))
				_ContextDetails = value
			End Set
		End Property
		Public Property Remarks() As String
			Get
				Return _Remarks
			End Get
			Set(ByVal value As String)
				_Remarks = value
			End Set
		End Property
		Public Sub New(ByVal Context As String, ByVal Detailed As Boolean)
			CreateIt(Context)
			If Detailed Then
				Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
				For Each ttmp As LeaveContextDetail In _ContextDetails
					For Each lt As SIS.ATN.atnLeaveTypes In oLTs
						If lt.LeaveTypeID = ttmp.LeaveType1 Then
							If lt.SpecialSanctionRequired Then
								_SanctionRequired = True
								_SanctionBy = lt.SpecialSanctionBy
							End If
						End If
						If lt.LeaveTypeID = ttmp.LeaveType2 Then
							If lt.SpecialSanctionRequired Then
								_SanctionRequired = True
								_SanctionBy = lt.SpecialSanctionBy
							End If
						End If
					Next
				Next
			End If
		End Sub
		Public Sub New(ByVal Context As String)
			CreateIt(Context)
		End Sub
		Public Sub New()
			'dummy
		End Sub
		Private Sub CreateIt(ByVal Context As String)
			Dim aContext() As String = Context.Split(":".ToCharArray)
			Dim aDays() As String = aContext(0).Split("±".ToCharArray)
      _Remarks = aContext(1)
      Try
        FinYear = aContext(2)
        MonthID = aContext(3)
        CardNo = aContext(4)
        For22to31Dec = aContext(5)
      Catch ex As Exception
      End Try
      For Each _day As String In aDays
				Dim aDetails() As String = _day.Split("|".ToCharArray)
				Dim _detail As New LeaveContextDetail
				With _detail
					If IsDate(aDetails(0)) Then
						.AttenDate = aDetails(0)
					Else
						.AttenID = aDetails(0)
					End If
					.AppliedDayType = aDetails(2)
					Dim aLeaveTypes() As String = aDetails(1).Split(",".ToCharArray)
					.LeaveType1 = aLeaveTypes(0)
					If aLeaveTypes.Length > 1 Then
						.LeaveType2 = aLeaveTypes(1)
					End If
					If .LeaveType1 = "OD" Or .LeaveType2 = "OD" Then
						.Destination = aDetails(3)
						.Purpose = aDetails(4)
					End If
				End With
				_ContextDetails.Add(_detail)
			Next
		End Sub
	End Class
	Public Class LeaveContextDetail
		Private _AttenID As Integer = 0
		Private _AttenDate As String = String.Empty
		Private _AppliedDayType As String = String.Empty
		Private _LeaveType1 As String = String.Empty
		Private _LeaveType2 As String = String.Empty
		Private _Destination As String = String.Empty
    Private _Purpose As String = String.Empty
    Public Property ErrorMessage As String = ""
		Public ReadOnly Property IsODPresent() As Boolean
			Get
				If _LeaveType1 = "OD" Or _LeaveType2 = "OD" Then
					Return True
				End If
				Return False
			End Get
		End Property
		Public Property Destination() As String
			Get
				Return _Destination
			End Get
			Set(ByVal value As String)
				_Destination = value
			End Set
		End Property
		Public Property Purpose() As String
			Get
				Return _Purpose
			End Get
			Set(ByVal value As String)
				_Purpose = value
			End Set
		End Property
		Public Property AppliedDayType() As String
			Get
				Return _AppliedDayType
			End Get
			Set(ByVal value As String)
				_AppliedDayType = value
			End Set
		End Property
		Public Property LeaveType1() As String
			Get
				Return _LeaveType1
			End Get
			Set(ByVal value As String)
				_LeaveType1 = value
			End Set
		End Property
		Public Property LeaveType2() As String
			Get
				Return _LeaveType2
			End Get
			Set(ByVal value As String)
				_LeaveType2 = value
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
		Public Property AttenID() As Integer
			Get
				Return _AttenID
			End Get
			Set(ByVal value As Integer)
				_AttenID = value
			End Set
		End Property
		Public Sub New(ByVal AttenID As Integer)
			_AttenID = AttenID
		End Sub
		Public Sub New(ByVal AttenDate As String)
			_AttenDate = AttenDate
		End Sub
		Public Sub New()
			'dummy
		End Sub
	End Class
	Public Class lgMonthlyLedgerBalance
		Private _OpeningBalance As Decimal = 0
		Private _Availed As Decimal = 0
		Private _InProcess As Decimal = 0
		Private _Balance As Decimal = 0
		Private _ForMonth As Integer = 0
		Public Property ForMonth() As Integer
			Get
				Return _ForMonth
			End Get
			Set(ByVal value As Integer)
				_ForMonth = value
			End Set
		End Property
		Public ReadOnly Property Balance() As Decimal
			Get
				Return _OpeningBalance - _Availed - InProcess
			End Get
		End Property
		Public Property InProcess() As Decimal
			Get
				Return _InProcess
			End Get
			Set(ByVal value As Decimal)
				_InProcess = value
			End Set
		End Property
		Public Property Availed() As Decimal
			Get
				Return _Availed
			End Get
			Set(ByVal value As Decimal)
				_Availed = value
			End Set
		End Property
		Public Property OpeningBalance() As Decimal
			Get
				Return _OpeningBalance
			End Get
			Set(ByVal value As Decimal)
				_OpeningBalance = value
			End Set
		End Property

	End Class
	Public Class lgLedgerBalance
		Private _ClosingBalance As Decimal = 0
		Private _NewOpening As Decimal = 0
		Private _OBALApplicable As Boolean = False
		Private _LeaveType As String = String.Empty
		Private _OpeningBalance As Decimal = 0
		Private _Availed As Decimal = 0
		Private _InProcess As Decimal = 0
		Private _Balance As Decimal = 0
		Private _Description As String = String.Empty
		Private _AdvanceApplicable As Boolean = False
		Private _MonthlyOpening As Boolean = False
		Private _MonthlyData As List(Of lgMonthlyLedgerBalance) = Nothing
		Public Property OBALApplicable() As Boolean
			Get
				Return _OBALApplicable
			End Get
			Set(ByVal value As Boolean)
				_OBALApplicable = value
			End Set
		End Property
		Public Property NewOpening() As Decimal
			Get
				Return _NewOpening
			End Get
			Set(ByVal value As Decimal)
				_NewOpening = value
			End Set
		End Property
		Public Property ClosingBalance() As Decimal
			Get
				Return _ClosingBalance
			End Get
			Set(ByVal value As Decimal)
				_ClosingBalance = value
			End Set
		End Property
		Public Property MonthlyData() As List(Of lgMonthlyLedgerBalance)
			Get
				Return _MonthlyData
			End Get
			Set(ByVal value As List(Of lgMonthlyLedgerBalance))
				_MonthlyData = value
			End Set
		End Property
		Public Property MonthlyOpening() As Boolean
			Get
				Return _MonthlyOpening
			End Get
			Set(ByVal value As Boolean)
				_MonthlyOpening = value
			End Set
		End Property
		Public ReadOnly Property MayApply() As Boolean
			Get
				If Not _AdvanceApplicable Then
					If _MonthlyOpening Then
						For Each _mb As lgMonthlyLedgerBalance In _MonthlyData
							If (_mb.OpeningBalance - _mb.Availed - _mb.InProcess) < 0 Then
								Return False
							End If
						Next
					Else
						If (_OpeningBalance - _Availed - _InProcess) < 0 Then
							Return False
						End If
					End If
				End If
				Return True
			End Get
		End Property
		Public Property AdvanceApplicable() As Boolean
			Get
				Return _AdvanceApplicable
			End Get
			Set(ByVal value As Boolean)
				_AdvanceApplicable = value
			End Set
		End Property
		Public Property Description() As String
			Get
				Return _Description
			End Get
			Set(ByVal value As String)
				_Description = value
			End Set
		End Property
		Public ReadOnly Property Balance() As Decimal
			Get
				Return _OpeningBalance - _Availed - InProcess
			End Get
		End Property
		Public Property InProcess() As Decimal
			Get
				Return _InProcess
			End Get
			Set(ByVal value As Decimal)
				_InProcess = value
			End Set
		End Property
		Public Property Availed() As Decimal
			Get
				Return _Availed
			End Get
			Set(ByVal value As Decimal)
				_Availed = value
			End Set
		End Property
		Public Property OpeningBalance() As Decimal
			Get
				Return _OpeningBalance
			End Get
			Set(ByVal value As Decimal)
				_OpeningBalance = value
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
		Public Shared Function GetLeadgerBalanceWithMonthlyData(ByVal CardNo As String) As List(Of SIS.ATN.lgLedgerBalance)
			Dim oBals As List(Of SIS.ATN.lgLedgerBalance) = New List(Of SIS.ATN.lgLedgerBalance)()

			Dim FinYear As String = SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear
			If CardNo = String.Empty Then
				CardNo = HttpContext.Current.Session("EmployeeUnderProcess")
				If CardNo = String.Empty Then
					CardNo = HttpContext.Current.Session("LoginID")
				End If
			End If

			'Create All Leave Objects
			Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
			For Each _lt As SIS.ATN.atnLeaveTypes In oLTs
				Dim _Bal As lgLedgerBalance = New lgLedgerBalance
				With _Bal
					.LeaveType = _lt.LeaveTypeID
					.Description = _lt.Description
					.AdvanceApplicable = _lt.AdvanceApplicable
					If _lt.OBALMonthly Then
						.MonthlyOpening = True
						.OpeningBalance = _lt.OpeningBalance
						.MonthlyData = New List(Of lgMonthlyLedgerBalance)
					End If
				End With
				oBals.Add(_Bal)
			Next
			'======================
			'Update from Transactions
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT * FROM ATNv_LedgerBalance WHERE CardNo = '" & CardNo & "' AND FinYear = '" & FinYear & "'"
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						For Each _Bal As lgLedgerBalance In oBals
							If _Bal.LeaveType = Reader("LeaveTypeID") Then
								With _Bal
									If .MonthlyOpening Then
										Dim Found As Boolean = False
										Dim _mBal As lgMonthlyLedgerBalance = Nothing
										For Each _mBal In .MonthlyData
											If _mBal.ForMonth = Convert.ToInt32(Reader("ForMonth")) Then
												Found = True
												Exit For
											End If
										Next
										If Not Found Then
											_mBal = New lgMonthlyLedgerBalance
											_mBal.OpeningBalance = .OpeningBalance
											_mBal.ForMonth = Convert.ToInt32(Reader("ForMonth"))
											.MonthlyData.Add(_mBal)
										End If
										'We Have to count Number of Times
										If Reader("TranType") = "TRN" Then
											If Convert.ToDecimal(Reader("Days")) <> 0 Then
												_mBal.Availed += 1
											Else
												_mBal.InProcess += 1
											End If
										End If
									Else ' Not Monthly Opening
										If Reader("TranType") = "OPB" Then
											.OpeningBalance += Convert.ToDecimal(Reader("Days"))
										Else
											.Availed += (-1 * Convert.ToDecimal(Reader("Days")))
											.InProcess += Convert.ToDecimal(Reader("InProcessDays"))
										End If
									End If 'End of Monthly Opening
								End With
								Exit For
							End If
						Next
					End While
					Reader.Close()
				End Using
			End Using
			Return oBals
		End Function
		Public Shared Function GetLeadgerBalance(ByVal CardNo As String) As List(Of SIS.ATN.lgLedgerBalance)
			Dim Results As List(Of SIS.ATN.lgLedgerBalance) = Nothing
			Dim FinYear As String = SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear
			If CardNo = String.Empty Then
				CardNo = HttpContext.Current.Session("EmployeeUnderProcess")
				If CardNo = String.Empty Then
					CardNo = HttpContext.Current.Session("LoginID")
				End If
			End If
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_LeaveCardByCardNo1"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, FinYear)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					Results = New List(Of SIS.ATN.lgLedgerBalance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Dim oBal As lgLedgerBalance = Nothing
						Dim _lt As String = Reader("LeaveTypeID")
						For Each _Bal As lgLedgerBalance In Results
							If _Bal.LeaveType = _lt Then
								oBal = _Bal
								Exit For
							End If
						Next
						If oBal Is Nothing Then
							oBal = New lgLedgerBalance
							oBal.LeaveType = _lt
							oBal.Description = Reader("Description")
							oBal.AdvanceApplicable = Reader("AdvanceApplicable")
							Results.Add(oBal)
						End If
						With oBal
							If Reader("TranType") = "OPB" Then
								.OpeningBalance += IIf(Convert.IsDBNull(Reader("Days")), 0.0, Convert.ToDecimal(Reader("Days")))
							Else
								.Availed += IIf(Convert.IsDBNull(Reader("Days")), 0.0, Convert.ToDecimal(Reader("Days")) * -1)
								.InProcess += IIf(Convert.IsDBNull(Reader("InProcessDays")), 0.0, Convert.ToDecimal(Reader("InProcessDays")))
							End If
						End With
					End While
					Reader.Close()
				End Using
			End Using
			Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
			For Each _lt As SIS.ATN.atnLeaveTypes In oLTs
				Dim oBal As lgLedgerBalance = Nothing
				For Each _Bal As lgLedgerBalance In Results
					If _Bal.LeaveType = _lt.LeaveTypeID Then
						oBal = _Bal
						Exit For
					End If
				Next
				If oBal Is Nothing Then
					oBal = New lgLedgerBalance
					oBal.LeaveType = _lt.LeaveTypeID
					oBal.Description = _lt.Description
					oBal.AdvanceApplicable = _lt.AdvanceApplicable
					oBal.OpeningBalance = 0
					oBal.Availed = 0
					oBal.InProcess = 0
					Results.Add(oBal)
				End If
			Next
			Return Results
		End Function
		Public Shared Function LvRoundof(ByVal nVal As Decimal) As Decimal
			Dim iVal As Integer = 0
			Dim fVal As Single = 0
			iVal = Int(nVal)
			fVal = nVal - iVal
			If fVal >= 0.75 Then
				fVal = 1
			Else
				If fVal >= 0.5 Then
					fVal = 0.5
				Else
					If fVal >= 0.25 Then
						fVal = 0.5
					Else
						fVal = 0
					End If
				End If
			End If
			nVal = iVal + fVal
			Return nVal
		End Function
		Public Shared Function GetNewLedgerBalance_Obsolete(ByVal CardNo As String) As List(Of lgLedgerBalance)
			'This is used only in Report
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
			Dim oBals As List(Of SIS.ATN.lgLedgerBalance) = Nothing
			Dim FinYear As String = SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear

			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_LeaveCardByCardNo1"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, FinYear)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					oBals = New List(Of SIS.ATN.lgLedgerBalance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Dim oBal As lgLedgerBalance = Nothing
						Dim _lt As String = Reader("LeaveTypeID")
						For Each _Bal As lgLedgerBalance In oBals
							If _Bal.LeaveType = _lt Then
								oBal = _Bal
								Exit For
							End If
						Next
						If oBal Is Nothing Then
							oBal = New lgLedgerBalance
							oBal.LeaveType = _lt
							oBal.Description = Reader("Description")
							oBal.AdvanceApplicable = Reader("AdvanceApplicable")
							oBals.Add(oBal)
						End If
						With oBal
							If Reader("TranType") = "OPB" Then
								.OpeningBalance += IIf(Convert.IsDBNull(Reader("Days")), 0.0, Convert.ToDecimal(Reader("Days")))
							Else
								.Availed += IIf(Convert.IsDBNull(Reader("Days")), 0.0, Convert.ToDecimal(Reader("Days")) * -1)
								.InProcess += IIf(Convert.IsDBNull(Reader("InProcessDays")), 0.0, Convert.ToDecimal(Reader("InProcessDays")))
							End If
						End With
					End While
					Reader.Close()
				End Using
			End Using
			Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
			For Each _lt As SIS.ATN.atnLeaveTypes In oLTs
				Dim oBal As lgLedgerBalance = Nothing
				For Each _Bal As lgLedgerBalance In oBals
					If _Bal.LeaveType = _lt.LeaveTypeID Then
						oBal = _Bal
						Exit For
					End If
				Next
				If oBal Is Nothing Then
					oBal = New lgLedgerBalance
					oBal.LeaveType = _lt.LeaveTypeID
					oBal.Description = _lt.Description
					oBal.AdvanceApplicable = _lt.AdvanceApplicable
					oBal.OpeningBalance = 0
					oBal.Availed = 0
					oBal.InProcess = 0
					oBals.Add(oBal)
				End If
			Next

			Dim ResignedCase As Boolean = False
			Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
			If oEmp.C_DateOfReleaving <> String.Empty Then
				ResignedCase = True
				Dim oFyr As SIS.ATN.atnFinYear = SIS.ATN.atnFinYear.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
				If Convert.ToDateTime(oEmp.C_DateOfReleaving, ci) < Convert.ToDateTime(oFyr.EndDate, ci) Then
					'Calculate Leave Balances
					Dim EmpSDays As Integer = 0
					Dim EmpTDays As Integer = 0
					Dim YrDays As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oFyr.StartDate, ci))
					If Convert.ToDateTime(oEmp.C_DateOfJoining, ci) <= Convert.ToDateTime(oFyr.StartDate, ci) Then
						EmpSDays = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oFyr.StartDate, ci))
						EmpTDays = DateDiff(DateInterval.Day, Convert.ToDateTime(oEmp.C_DateOfReleaving, ci), Convert.ToDateTime(oFyr.StartDate, ci))
					Else
						EmpSDays = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oEmp.C_DateOfJoining, ci))
						EmpTDays = DateDiff(DateInterval.Day, Convert.ToDateTime(oEmp.C_DateOfReleaving, ci), Convert.ToDateTime(oEmp.C_DateOfJoining, ci))
					End If
					For Each lgb As SIS.ATN.lgLedgerBalance In oBals
						If lgb.LeaveType = "CL" Then
							If lgb.OpeningBalance > 0 Then
								'lgb.OpeningBalance = LvRoundof((lgb.OpeningBalance / EmpSDays) * EmpTDays)
								lgb.OpeningBalance = LvRoundof((7 / YrDays) * EmpTDays)
							End If
						End If
						If lgb.LeaveType = "SL" Then
							If lgb.OpeningBalance > 0 Then
								'lgb.OpeningBalance = LvRoundof((lgb.OpeningBalance / EmpSDays) * EmpTDays)
								lgb.OpeningBalance = LvRoundof((8 / YrDays) * EmpTDays)
							End If
						End If
						If lgb.LeaveType = "PL" Then
							Dim tmp As Decimal = 0
							tmp = LvRoundof((24 / YrDays) * EmpTDays)
							lgb.OpeningBalance = lgb.OpeningBalance + tmp
						End If
						If lgb.LeaveType = "LT" Then
							Dim tmp As Decimal = 0
							tmp = LvRoundof((6 / YrDays) * EmpTDays)
							lgb.OpeningBalance = lgb.OpeningBalance + tmp
						End If
					Next
				End If
				'Arrange oBals for full n final.
				For Each lgb As SIS.ATN.lgLedgerBalance In oBals
					If lgb.LeaveType = "AP" Then	'accumulated priviledge
						For Each tmp As SIS.ATN.lgLedgerBalance In oBals
							If tmp.LeaveType = "PL" Then
								tmp.OpeningBalance += lgb.OpeningBalance
								tmp.Availed += lgb.Availed
								tmp.InProcess += lgb.InProcess
								lgb.OpeningBalance = 0
								lgb.Availed = 0
								lgb.InProcess = 0
								Exit For
							End If
						Next
					End If
					If lgb.LeaveType = "AD" Then	'advance priviledge
						For Each tmp As SIS.ATN.lgLedgerBalance In oBals
							If tmp.LeaveType = "PL" Then
								tmp.Availed += lgb.Availed
								tmp.InProcess += lgb.InProcess
								lgb.Availed = 0
								lgb.InProcess = 0
								Exit For
							End If
						Next
					End If
					If lgb.LeaveType = "AL" Then	'accumulated ltc
						For Each tmp As SIS.ATN.lgLedgerBalance In oBals
							If tmp.LeaveType = "LT" Then
								tmp.OpeningBalance += lgb.OpeningBalance
								tmp.Availed += lgb.Availed
								tmp.InProcess += lgb.InProcess
								lgb.OpeningBalance = 0
								lgb.Availed = 0
								lgb.InProcess = 0
								Exit For
							End If
						Next
					End If
				Next
				'Leave adjustment

				'Check for -ve CL or SL and adjust from PL
				For Each lgb As SIS.ATN.lgLedgerBalance In oBals
					If lgb.LeaveType = "CL" Then
						If lgb.Balance < 0 Then
							For Each tmp As SIS.ATN.lgLedgerBalance In oBals
								If tmp.LeaveType = "PL" Then
									tmp.Availed += Math.Abs(lgb.Balance)
									Exit For
								End If
							Next
						End If
					End If
				Next
				For Each lgb As SIS.ATN.lgLedgerBalance In oBals
					If lgb.LeaveType = "SL" Then
						If lgb.Balance < 0 Then
							For Each tmp As SIS.ATN.lgLedgerBalance In oBals
								If tmp.LeaveType = "PL" Then
									tmp.Availed += Math.Abs(lgb.Balance)
									Exit For
								End If
							Next
						End If
					End If
				Next
				'Compensate PL in Balance LTC
				For Each lgb As SIS.ATN.lgLedgerBalance In oBals
					If lgb.LeaveType = "LT" Then	'ltc
						If lgb.Balance > 0 Then
							For Each tmp As SIS.ATN.lgLedgerBalance In oBals
								If tmp.LeaveType = "PL" Then
									If tmp.Availed >= lgb.Balance Then
										tmp.Availed -= lgb.Balance
										lgb.Availed += lgb.Balance
									Else
										lgb.Availed += tmp.Availed
										tmp.Availed -= tmp.Availed
									End If
									Exit For
								End If
							Next
						End If
					End If
				Next
			End If

			If ResignedCase Then
				'Remove Other Leave Types
				For I As Integer = oBals.Count - 1 To 0 Step -1
					Dim lgb As SIS.ATN.lgLedgerBalance = oBals(I)
					Select Case lgb.LeaveType
						Case "CL", "SL", "PL", "LT"
						Case Else
							oBals.Remove(lgb)
					End Select
				Next
			End If

			Return oBals

		End Function
    Public Shared Function FinalizeForResigned(ByVal oBals As List(Of lgLedgerBalance), ByVal CardNo As String) As List(Of lgLedgerBalance)
      Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
      Dim ResignedCase As Boolean = False
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
      If oEmp.C_DateOfReleaving <> String.Empty Then ResignedCase = True
      If Not ResignedCase Then Return oBals
      Dim CategoryID As Integer = SIS.SYS.Utilities.BalanceTransfer.GetCategoryID(CardNo)

      Dim oFyr As SIS.ATN.atnFinYear = SIS.ATN.atnFinYear.GetByID(Convert.ToDateTime(oEmp.C_DateOfReleaving, ci).Year)
      If Convert.ToDateTime(oEmp.C_DateOfReleaving, ci) <= Convert.ToDateTime(oFyr.EndDate, ci) Then
        Dim opbPL As Decimal = 24
        Dim opbLT As Decimal = 6
        If oEmp.C_DesignationID = "34" Or oEmp.C_DesignationID = "35" Or oEmp.C_DesignationID = "28" Then
          opbPL = 15
          opbLT = 0
        ElseIf oEmp.C_OfficeID = "6" Then
          opbPL = 30
          opbLT = 0
        ElseIf CategoryID = 19 Then
          opbPL = 15
          opbLT = 0
        ElseIf CategoryID = 18 Then
          opbPL = 30
          opbLT = 0
        End If

        'Calculate Leave Balances
        Dim EmpTDays As Integer = 0
        Dim EmpPTDays As Integer = 0
        Dim YrDays As Integer = 1 + DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.StartDate, ci), Convert.ToDateTime(oFyr.EndDate, ci))
        If Convert.ToDateTime(oEmp.C_DateOfJoining, ci) <= Convert.ToDateTime(oFyr.StartDate, ci) Then
          EmpTDays = 1 + DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.StartDate, ci), Convert.ToDateTime(oEmp.C_DateOfReleaving, ci))
          EmpPTDays = GetPresentDaysByCardNoDate(CardNo, Convert.ToDateTime(oFyr.StartDate, ci), Convert.ToDateTime(oEmp.C_DateOfReleaving, ci))
        Else
          EmpTDays = 1 + DateDiff(DateInterval.Day, Convert.ToDateTime(oEmp.C_DateOfJoining, ci), Convert.ToDateTime(oEmp.C_DateOfReleaving, ci))
          EmpPTDays = GetPresentDaysByCardNoDate(CardNo, Convert.ToDateTime(oEmp.C_DateOfJoining, ci), Convert.ToDateTime(oEmp.C_DateOfReleaving, ci))
        End If
        For Each lgb As SIS.ATN.lgLedgerBalance In oBals
          If lgb.LeaveType = "CL" Then
            If lgb.OpeningBalance > 0 Then
              lgb.OpeningBalance = LvRoundof((7 / YrDays) * EmpTDays)
            End If
          End If
          If lgb.LeaveType = "SL" Then
            If lgb.OpeningBalance > 0 Then
              lgb.OpeningBalance = LvRoundof((8 / YrDays) * EmpTDays)
            End If
          End If
          'Credit Current Years PL & LTC
          If lgb.LeaveType = "PL" Then
            Dim tmp As Decimal = 0
            tmp = LvRoundof((opbPL / YrDays) * EmpPTDays)
            lgb.OpeningBalance = lgb.OpeningBalance + tmp
          End If
          If lgb.LeaveType = "LT" Then
            Dim tmp As Decimal = 0
            tmp = LvRoundof((opbLT / YrDays) * EmpPTDays)
            lgb.OpeningBalance = lgb.OpeningBalance + tmp
          End If
        Next
      End If
      'Arrange oBals for full n final.
      For Each lgb As SIS.ATN.lgLedgerBalance In oBals
        If lgb.LeaveType = "AP" Then  'accumulated priviledge
          For Each tmp As SIS.ATN.lgLedgerBalance In oBals
            If tmp.LeaveType = "PL" Then
              tmp.OpeningBalance += lgb.OpeningBalance
              tmp.Availed += lgb.Availed
              tmp.InProcess += lgb.InProcess
              lgb.OpeningBalance = 0
              lgb.Availed = 0
              lgb.InProcess = 0
              Exit For
            End If
          Next
        End If
        If lgb.LeaveType = "AD" Then  'advance priviledge
          For Each tmp As SIS.ATN.lgLedgerBalance In oBals
            If tmp.LeaveType = "PL" Then
              tmp.Availed += lgb.Availed
              tmp.InProcess += lgb.InProcess
              lgb.Availed = 0
              lgb.InProcess = 0
              Exit For
            End If
          Next
        End If
        If lgb.LeaveType = "AL" Then  'accumulated ltc
          For Each tmp As SIS.ATN.lgLedgerBalance In oBals
            If tmp.LeaveType = "LT" Then
              tmp.OpeningBalance += lgb.OpeningBalance
              tmp.Availed += lgb.Availed
              tmp.InProcess += lgb.InProcess
              lgb.OpeningBalance = 0
              lgb.Availed = 0
              lgb.InProcess = 0
              Exit For
            End If
          Next
        End If
      Next
      'Leave adjustment

      'Check for -ve CL or SL and adjust from PL
      For Each lgb As SIS.ATN.lgLedgerBalance In oBals
        If lgb.LeaveType = "CL" Then
          If lgb.Balance < 0 Then
            For Each tmp As SIS.ATN.lgLedgerBalance In oBals
              If tmp.LeaveType = "PL" Then
                tmp.Availed += Math.Abs(lgb.Balance)
                lgb.Availed = lgb.Availed + lgb.Balance
                Exit For
              End If
            Next
          End If
        End If
      Next
      For Each lgb As SIS.ATN.lgLedgerBalance In oBals
        If lgb.LeaveType = "SL" Then
          If lgb.Balance < 0 Then
            For Each tmp As SIS.ATN.lgLedgerBalance In oBals
              If tmp.LeaveType = "PL" Then
                tmp.Availed += Math.Abs(lgb.Balance)
                lgb.Availed = lgb.Availed + lgb.Balance
                Exit For
              End If
            Next
          End If
          Exit For
        End If
      Next
      'Compensate PL in Balance LTC
      For Each lgb As SIS.ATN.lgLedgerBalance In oBals
        If lgb.LeaveType = "LT" Then  'ltc
          If lgb.Balance > 0 Then
            For Each tmp As SIS.ATN.lgLedgerBalance In oBals
              If tmp.LeaveType = "PL" Then
                If tmp.Availed >= lgb.Balance Then
                  tmp.Availed -= lgb.Balance
                  lgb.Availed += lgb.Balance
                Else
                  lgb.Availed += tmp.Availed
                  tmp.Availed -= tmp.Availed
                End If
                Exit For
              End If
            Next
          End If
        End If
      Next
      'Remove Other Leave Types
      For I As Integer = oBals.Count - 1 To 0 Step -1
        Dim lgb As SIS.ATN.lgLedgerBalance = oBals(I)
        Select Case lgb.LeaveType
          Case "CL", "SL", "PL", "LT"
          Case Else
            oBals.Remove(lgb)
        End Select
      Next
      Return oBals
    End Function
    Public Shared Function GetPresentDaysByCardNoDate(ByVal CardNo As String, ByVal FromDate As DateTime, ByVal TillDate As DateTime) As Integer
      Dim pDays As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(sum(FinalValue),0) as pDays from ATN_Attendance where cardno='" & CardNo & "' and AttenDate Between convert(DateTime,'" & FromDate.ToString("dd/MM/yyyy") & "',103) and convert(dateTime,'" & TillDate.ToString("dd/MM/yyyy") & "',103)"
          Con.Open()
          Dim tmp As String = Cmd.ExecuteScalar()
          Try
            pDays = tmp
          Catch ex As Exception
          End Try
        End Using
      End Using
      Return pDays
    End Function

    Public Shared Function GetHTMLLeaveCard(ByVal oBals As List(Of SIS.ATN.lgLedgerBalance), Optional ByVal Context As String = Nothing, Optional ByRef MaySubmit As Boolean = False, Optional ByVal lvContext As LeaveContext = Nothing) As String
      Dim mRet As String = ""
      If Not MaySubmit And lvContext IsNot Nothing Then
        mRet = mRet & "<table width=""400px"">"
        mRet = mRet & "<tr>"
        mRet = mRet & "<td color=""bar_greenHeader"" height=""25px"" style=""text-align:left""><b><span style=""color:red"">LEAVE CAN NOT BE SUBMITTED</span></b>"
        mRet = mRet & "<ul>"
        'mRet = mRet & "</tr>"

        Dim cnt As Integer = 0
        For Each lcd As LeaveContextDetail In lvContext.LeaveContextDetails
          If lcd.ErrorMessage <> String.Empty Then
            'mRet = mRet & "<tr>"
            mRet = mRet & "<li style=""color:red"">" & lcd.ErrorMessage
            mRet = mRet & "</li>"
            'mRet = mRet & "</tr>"
          End If
        Next
        mRet = mRet & "</ul></td></tr>"
        mRet = mRet & "<tr>"
        mRet = mRet & "<td style=""text-align: center"">"
        mRet = mRet & "<input type=""button"" onclick=""cancelMessage();"" value=""Cancel"" />"
        mRet = mRet & "</td>"
        mRet = mRet & "</tr>"
        mRet = mRet & "</table>"
        Return mRet
      End If
      Dim MayApply As Boolean = True
      mRet = mRet & "<table width=""400px"">"
      mRet = mRet & "<tr>"
      mRet = mRet & "<td class=""bar_greenHeader"" height=""25px"" style=""text-align:left""><b>LEAVE TYPE</b>"
      mRet = mRet & "</td>"
      mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right""><b>OP BAL.</b>"
      mRet = mRet & "</td>"
      mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right""><b>AVAILED</b>"
      mRet = mRet & "</td>"
      mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right""><b>IN PROCESS</b>"
      mRet = mRet & "</td>"
      mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right""><b>BALANCE</b>"
      mRet = mRet & "</td>"
      mRet = mRet & "</tr>"
      For Each oBal As SIS.ATN.lgLedgerBalance In oBals
        If Not oBal.MonthlyOpening Then
          mRet = mRet & "<tr>"
          mRet = mRet & "<td>" & oBal.Description
          mRet = mRet & "</td>"
          mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & oBal.OpeningBalance
          mRet = mRet & "</td>"
          mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & oBal.Availed
          mRet = mRet & "</td>"
          mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & oBal.InProcess
          mRet = mRet & "</td>"
          If oBal.MayApply Then
            mRet = mRet & "<td style=""color:blue;text-align:right;padding-right: 2px"">" & oBal.Balance
          Else
            mRet = mRet & "<td style=""color:red;text-align:right;padding-right: 2px"">" & oBal.Balance
          End If
          mRet = mRet & "</td>"
          mRet = mRet & "</tr>"
        Else
          For Each omBal As lgMonthlyLedgerBalance In oBal.MonthlyData
            mRet = mRet & "<tr>"
            mRet = mRet & "<td>" & oBal.Description & "-<b>" & MonthName(omBal.ForMonth, True)
            mRet = mRet & "</b></td>"
            mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & omBal.OpeningBalance
            mRet = mRet & "</td>"
            mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & omBal.Availed
            mRet = mRet & "</td>"
            mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & omBal.InProcess
            mRet = mRet & "</td>"
            If oBal.MayApply Then
              mRet = mRet & "<td style=""color:green;text-align:right;padding-right: 2px"">" & omBal.Balance
            Else
              mRet = mRet & "<td style=""color:red;text-align:right;padding-right: 2px"">" & omBal.Balance
            End If
            mRet = mRet & "</td>"
            mRet = mRet & "</tr>"
            If MayApply Then
              MayApply = oBal.MayApply
            End If
          Next
        End If
        If MayApply Then
          MayApply = oBal.MayApply
        End If
      Next
      mRet = mRet & "<tr>"
      If Context IsNot Nothing Then
        mRet = mRet & "<td colspan=""3"" style=""text-align: right"">"
        mRet = mRet & "<input type=""button"" onclick=""cancelMessage();"" value=""Cancel"" />"
        mRet = mRet & "</td>"
        mRet = mRet & "<td colspan=""2"" style=""text-align: right"">"
        If MayApply Then
          If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
            mRet = mRet & "<input type=""button"" disabled=""true"" value=""Submit"" />"
          Else
            mRet = mRet & "<input type=""button"" onclick=""lgValidate.UpdateAppliedLeaves('" & Context & "');"" value=""Submit"" />"
          End If
        Else
          mRet = mRet & "<input type=""button"" disabled=""true"" value=""Submit"" />"
        End If
        mRet = mRet & "</td>"
      End If
      mRet = mRet & "</tr>"
      mRet = mRet & "</table>"
      mRet = mRet & ""
      MaySubmit = MayApply
      Return mRet
    End Function
	End Class
End Namespace
