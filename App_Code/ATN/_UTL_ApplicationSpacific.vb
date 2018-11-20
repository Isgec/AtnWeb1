Imports System.Data.SqlClient
Imports System.Data
Namespace SIS.SYS.Utilities
	'Public Class IPayRoll
	'	Private _DefaultPath As String = ""
	'	Public Sub UpdateDBF(ByVal ForMonth As Integer)
	'		Dim wd As webdbf.mondata = New webdbf.mondata
	'		wd.DEFAULTPATH = _DefaultPath
	'		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
	'			Using Cmd As SqlCommand = Con.CreateCommand()
	'				Dim mSql As String = "SELECT * FROM [MONDATA]"
	'				Cmd.CommandType = System.Data.CommandType.Text
	'				Cmd.CommandText = mSql
	'				Con.Open()
	'				Dim Reader As SqlDataReader = Cmd.ExecuteReader
	'				While (Reader.Read())
	'					With wd
	'						.EMPCD = Reader("EmpCD")
	'						.DATE = Reader("Date")
	'						.ABS = Reader("Abs")
	'						.insert()
	'					End With
	'				End While
	'				Reader.Close()
	'			End Using
	'		End Using
	'	End Sub
	'	Public Sub New(ByVal DefaultPath As String)
	'		_DefaultPath = DefaultPath
	'	End Sub
	'	Public Sub New()
	'		'dummy
	'	End Sub
	'End Class

  Public Class ApplicationSpacific
    Public Shared ReadOnly Property NextLinkNo As Integer
      Get
        Dim mRet As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select top 1 LinkSrNo from ATN_LogSrNo"
            mRet = Cmd.ExecuteScalar()
          End Using
          mRet = mRet + 1
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Update ATN_LogSrNo set LinkSrNo =" & mRet
            Cmd.ExecuteNonQuery()
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public Shared ReadOnly Property NextMailNo As Integer
      Get
        Dim mRet As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select top 1 MailSrNo from ATN_LogSrNo"
            mRet = Cmd.ExecuteScalar()
          End Using
          mRet = mRet + 1
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Update ATN_LogSrNo set MailSrNo =" & mRet
            Cmd.ExecuteNonQuery()
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public Shared ReadOnly Property IsTesting As Boolean
      Get
        Return Convert.ToBoolean(ConfigurationManager.AppSettings("Testing"))
      End Get
    End Property
    Public Shared Function ContentType(ByVal FileName As String) As String
      Dim mRet As String = "application/octet-stream"
      Dim Extn As String = IO.Path.GetExtension(FileName).ToLower.Replace(".", "")
      Select Case Extn
        Case "pdf", "rtf"
          mRet = "application/" & Extn
        Case "doc", "docx"
          mRet = "application/vnd.ms-works"
        Case "xls", "xlsx"
          mRet = "application/vnd.ms-excel"
        Case "gif", "jpg", "jpeg", "png", "tif", "bmp"
          mRet = "image/" & Extn
        Case "pot", "ppt", "pps", "pptx", "ppsx"
          mRet = "application/vnd.ms-powerpoint"
        Case "htm", "html"
          mRet = "text/HTML"
        Case "txt"
          mRet = "text/plain"
        Case "zip"
          mRet = "application/zip"
        Case "rar", "tar", "tgz"
          mRet = "application/x-compressed"
        Case Else
          mRet = "application/octet-stream"
      End Select
      Return mRet
    End Function
    Public Shared Function GetPostBackControlId(ByVal page As Page) As String
      If Not page.IsPostBack Then
        Return ""
      End If
      Dim control As Control = Nothing
      Dim ControlName As String = page.Request.Params("__EVENTTARGET")
      If Not String.IsNullOrEmpty(ControlName) Then
        control = page.FindControl(ControlName)
      Else
        Dim ControlID As String = ""
        Dim FoundControl As Control = Nothing
        For Each ctl As String In page.Request.Form
          If ctl.EndsWith(".x") OrElse ctl.EndsWith(".y") Then
            ControlID = ctl.Substring(0, ctl.Length - 2)
            FoundControl = page.FindControl(ControlID)
          Else
            FoundControl = page.FindControl(ctl)
          End If
          If Not TypeOf (FoundControl) Is IButtonControl Then Continue For
          control = FoundControl
          Exit For
        Next

      End If
      If control IsNot Nothing Then
        Return control.ID
      Else
        Return ""
      End If
    End Function

    Public Shared Function GetOfficeID(ByVal OfficeID As Integer) As Integer
      Dim mRet As Integer = 1
      Select Case OfficeID
        Case 4
          mRet = 4
        Case 5
          mRet = 5
        Case 6
          mRet = 6
        Case Else
          mRet = 1
      End Select
      Return mRet
    End Function
    Public Shared cLink As Boolean = False
    Public Shared OnC As Boolean = False
    Public Shared LGMInit As Boolean = False
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 7
        .Session("Redirected") = False
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
        .Session("FinYear") = ReadActiveFinYear
        .Session("ActiveFinYear") = ReadActiveFinYear
        .Session("EditAllowedDays") = Convert.ToInt32(ConfigurationManager.AppSettings("EditAllowedDays"))
        Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(HttpContext.Current.Session("LoginID"))
        If Not oEmp Is Nothing Then
          .Session("ProjectID") = oEmp.C_ProjectSiteID
          .Session("OnContract") = oEmp.Contractual
        Else
          'Logeed in user is not in employee master, he may be on Contract basis
          .Session("ProjectID") = ""
          .Session("OnContract") = True
        End If

        'If HttpContext.Current.Session("ContractualLink") = False Then
        '  If oEmp Is Nothing Then
        '    System.Web.Security.FormsAuthentication.SignOut()
        '    Try
        '      Throw New ApplicationException("Contractual employee can not be logged in here. Pl. click on the separate link provided in Intranet.")
        '    Catch ex As Exception
        '      HttpContext.Current.Session("myError") = ex.Message
        '      HttpContext.Current.Response.Redirect("~/ErrorPage.aspx")
        '    End Try
        '  Else
        '    If oEmp.Contractual = True Then
        '      System.Web.Security.FormsAuthentication.SignOut()
        '      Try
        '        Throw New ApplicationException("Contractual employee can not be logged in here. Pl. click on the separate link provided in Intranet.")
        '      Catch ex As Exception
        '        HttpContext.Current.Session("myError") = ex.Message
        '        HttpContext.Current.Response.Redirect("~/ErrorPage.aspx")
        '      End Try
        '    End If
        '  End If
        'Else
        '  If oEmp IsNot Nothing Then
        '    If oEmp.Contractual = False Then
        '      System.Web.Security.FormsAuthentication.SignOut()
        '      Try
        '        Throw New ApplicationException("Employee can not be logged in here. Pl. click on the separate link provided in Intranet.")
        '      Catch ex As Exception
        '        HttpContext.Current.Session("myError") = ex.Message
        '        HttpContext.Current.Response.Redirect("~/ErrorPage.aspx")
        '      End Try
        '    End If
        '  Else

        '  End If
        'End If

      End With
    End Sub
    Public Shared ReadOnly Property LastProcessedDate() As String
      Get
        Dim _Result As DateTime
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            'Dim mSql As String = "SELECT MAX([ATN_ProcessPunch].[ProcessDate]) FROM [ATN_ProcessPunch] WHERE [ATN_ProcessPunch].[FinYear] = " & HttpContext.Current.Session("FinYear")
            Dim mSql As String = "SELECT MAX([ATN_Attendance].[AttenDate]) FROM [ATN_Attendance] WHERE [ATN_Attendance].[FinYear] = " & HttpContext.Current.Session("FinYear")
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return Now.AddDays(-1).ToString("dd/MM/yyyy")
        Return _Result.ToString("dd/MM/yyyy")
      End Get
    End Property
    Public Shared Function LastWorkingDateForFP(ByVal CardNo As String, ByVal Days As Integer) As DateTime
      Dim cnt As Integer = 0
      Dim Deadlock As Integer = 0
      Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
      Dim _Result As DateTime = Convert.ToDateTime(LastProcessedDate, ci)
      Dim oAtnd As SIS.ATN.atnAttendance = Nothing
      Do
        _Result = _Result.AddDays(-1)
        oAtnd = SIS.ATN.atnAttendance.GetAttendanceByCardNoDate(CardNo, _Result)
        If Not oAtnd Is Nothing Then
          If oAtnd.Punch1Time > 0 Then
            cnt += 1
          End If
        Else
          Deadlock += 1
        End If
        If Deadlock > 100 Then
          Exit Do
        End If
      Loop While cnt < Days
      Return _Result
    End Function
    Public Shared Function LastWorkingDate(ByVal OfficeID As Integer, ByVal Days As Integer) As DateTime
      Dim cnt As Integer = 0
      Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
      Dim _Result As DateTime = Convert.ToDateTime(LastProcessedDate, ci)
      Dim oHld As SIS.ATN.atnHolidays = Nothing
      Do
        _Result = _Result.AddDays(-1)
        oHld = SIS.ATN.atnHolidays.GetByHoliday(_Result, OfficeID)
        If oHld Is Nothing Then
          cnt += 1
        End If
      Loop While cnt < Days
      Return _Result
    End Function
    Public Shared ReadOnly Property FinYearStartDate() As String
      Get
        Dim _Result As DateTime
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [ATN_FinYear].[StartDate] FROM [ATN_FinYear] WHERE [ATN_FinYear].[Active] = 1"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result.ToString("dd/MM/yyyy")
      End Get
    End Property
    Public Shared ReadOnly Property FinYearEndDate() As String
      Get
        Dim _Result As DateTime
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [ATN_FinYear].[EndDate] FROM [ATN_FinYear] WHERE [ATN_FinYear].[Active] = 1"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result.ToString("dd/MM/yyyy")
      End Get
    End Property
    Public Shared ReadOnly Property ReadActiveFinYear() As Integer
      Get
        Dim _Result As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [ATN_FinYear].[FinYear] FROM [ATN_FinYear] WHERE [ATN_FinYear].[Active] = 1"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result
      End Get
    End Property
    Public Shared ReadOnly Property ActiveFinYear() As Integer
      Get
        Return Convert.ToInt32(HttpContext.Current.Session("FinYear"))
      End Get
    End Property
    Public Shared Function ActivePunchConfig(ByVal ProcessingDate As DateTime, ByVal OfficeID As String) As Integer
      Dim _Result As Integer = 0
      'Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
      '	Using Cmd As SqlCommand = Con.CreateCommand()
      '		Dim mSql As String = "SELECT TOP 1 [ATN_PunchConfig].[RecordID] FROM [ATN_PunchConfig] WHERE (convert(datetime,'" & ProcessingDate & "',103) BETWEEN ActiveFrom AND ActiveTill) AND '" & OfficeID & "' in (LocationList) AND [ATN_PunchConfig].[FinYear] = " & Global.System.Web.HttpContext.Current.Session("FinYear")
      '		Cmd.CommandType = System.Data.CommandType.Text
      '		Cmd.CommandText = mSql
      '		Con.Open()
      '		_Result = Cmd.ExecuteScalar()
      '	End Using
      'End Using
      _Result = 6
      If ProcessingDate > Convert.ToDateTime("06/09/2015") Then
        _Result = "7"
        If OfficeID = "4" Or OfficeID = "5" Or OfficeID = "6" Or OfficeID = "7" Or OfficeID = "8" Then
          _Result = 6
          If ProcessingDate > Convert.ToDateTime("01/03/2018") Then
            If OfficeID = "5" Then
              _Result = "7"
            End If
          End If
        End If
      End If
      Return _Result
    End Function
    Public Shared ReadOnly Property ActivePunchConfig_Old() As Integer
      Get
        'i.e. before 7th Sep 2015
        Dim _Result As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [ATN_PunchConfig].[RecordID] FROM [ATN_PunchConfig] WHERE [ATN_PunchConfig].[FinYear] = " & Global.System.Web.HttpContext.Current.Session("FinYear")
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result
      End Get
    End Property
    Public Shared Sub ApplicationReports(ByVal Context As HttpContext)
      If Not Context.Request.QueryString("ReportName") Is Nothing Then
        Select Case (Context.Request.QueryString("ReportName").ToLower)
          Case "shnotcompensated"
            Dim oRep As RPT_atnSHNotCompensated = New RPT_atnSHNotCompensated(Context)
            oRep.GenerateReport()
          Case "punchanalysis"
            Dim oRep As RPT_atnFirstPunchAnalysis = New RPT_atnFirstPunchAnalysis(Context)
            oRep.GenerateReport()
          Case "tsreport"
            Dim oRep As RPT_atnTSReport = New RPT_atnTSReport(Context)
            oRep.GenerateReport()
          Case "fpreport"
            Dim oRep As RPT_atnFPReport = New RPT_atnFPReport(Context)
            oRep.GenerateReport()
          Case "odreport"
            Dim oRep As RPT_atnODReport = New RPT_atnODReport(Context)
            oRep.GenerateReport()
          Case "extrahours"
            Dim oRep As RPT_atnExtraHours = New RPT_atnExtraHours(Context)
            oRep.GenerateReport()
          Case "punctualityreport"
            Dim oRep As RPT_atnPunctualityReport = New RPT_atnPunctualityReport(Context)
            oRep.GenerateReport()
          Case "leavecard"
            Dim oRep As RPT_atnLeaveCard = New RPT_atnLeaveCard(Context)
            oRep.GenerateReport()
          Case "ledger"
            Dim oRep As RPT_atnLeaveLedger = New RPT_atnLeaveLedger(Context)
            oRep.GenerateReport()
          Case "pendingregularization"
            Dim oRep As RPT_atnPendingRegularization = New RPT_atnPendingRegularization(Context)
            oRep.GenerateReport()
          Case "attendancesheet"
            Dim oRep As RPT_atnAttendanceSheet = New RPT_atnAttendanceSheet(Context)
            oRep.GenerateReport()
          Case "attendancensheet"
            Dim oRep As RPT_atnAttendanceNSheet = New RPT_atnAttendanceNSheet(Context)
            oRep.GenerateReport()
          Case "averagedelayinregularization"
            Dim oRep As RPT_atnAverageDelayInRegularization = New RPT_atnAverageDelayInRegularization(Context)
            oRep.GenerateReport()
          Case "agingsummary"
            Dim oRep As RPT_atnFirstPunchAging = New RPT_atnFirstPunchAging(Context)
            oRep.GenerateReport()
          Case "agingdetail"
            Dim oRep As RPT_atnFirstPunchAgingDetail = New RPT_atnFirstPunchAgingDetail(Context)
            oRep.GenerateReport()
        End Select
      End If
    End Sub
    Public Shared Sub RemoveAttendanceAfterReleavingDate(ByVal CardNo As String)
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
      If oEmp.C_DateOfReleaving <> String.Empty Then
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "spatn_LG_RemoveAttendanceAfterReleaving"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfReleaving", SqlDbType.DateTime, 20, oEmp.C_DateOfReleaving)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining", SqlDbType.DateTime, 20, oEmp.C_DateOfJoining)
            Con.Open()
            Cmd.ExecuteNonQuery()
          End Using
        End Using
      End If
    End Sub
  End Class
	Public Class ProcessCardPunch
		Private Shared Function GetProcessedPunch(ByVal CardNo As String, ByVal DataDate As DateTime) As SIS.ATN.atnProcessedPunch
			Dim oAtnd As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, DataDate)
			If oAtnd Is Nothing Then
				oAtnd = New SIS.ATN.atnProcessedPunch
				With oAtnd
					.CardNo = CardNo
					.AttenDate = DataDate
					.Punch1Time = 0
					.Punch2Time = 0
					.PunchStatusID = "AD"
					.PunchValue = 0
					.FinalValue = 0
					.NeedsRegularization = True
				End With
				oAtnd.AttenID = SIS.ATN.atnProcessedPunch.Insert(oAtnd)
			End If
			Return oAtnd
		End Function
		Private Shared Function UpdateProcessedPunchForAdvApplFromRawPunch(ByVal oAtnd As SIS.ATN.atnProcessedPunch, ByVal OfficeID As Integer) As SIS.ATN.atnProcessedPunch
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
			Dim CardNo As String = oAtnd.CardNo
			Dim DataDate As DateTime = Convert.ToDateTime(oAtnd.AttenDate, ci)
			Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(DataDate, oAtnd.CardNoHRM_Employees.C_OfficeID))
			'Get Raw Punch
			Dim oRaw As SIS.ATN.atnRawPunch = SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(CardNo, DataDate)
			If Not oRaw Is Nothing Then
				If oAtnd.Punch1Time > 0 Then
					If oRaw.Punch1Time < oAtnd.Punch1Time Then
						oAtnd.Punch1Time = oRaw.Punch1Time
					End If
				Else
					oAtnd.Punch1Time = oRaw.Punch1Time
				End If
				If oRaw.Punch2Time > oAtnd.Punch2Time Then
					oAtnd.Punch2Time = oRaw.Punch2Time
				End If
			End If
			Dim OnePunchFound As Boolean = False
			If oAtnd.Punch1Time = 0 And oAtnd.Punch2Time = 0 Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
			ElseIf oAtnd.Punch1Time = 0 And oAtnd.Punch2Time < oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time = 0 And oAtnd.Punch2Time >= oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AF"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time <= oCnf.Range1End And oAtnd.Punch2Time < oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AS"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time <= oCnf.Range1End And oAtnd.Punch2Time >= oCnf.Range2Start Then
				oAtnd.PunchStatusID = "PR"
				oAtnd.PunchValue = 1
				oAtnd.FinalValue = 1
				oAtnd.NeedsRegularization = False
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time <= oCnf.Range1End And oAtnd.Punch2Time = 0 Then
				oAtnd.PunchStatusID = "AS"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time > oCnf.Range1End And oAtnd.Punch2Time >= oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AF"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time > oCnf.Range1End And oAtnd.Punch2Time = 0 Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time > oCnf.Range1End And oAtnd.Punch2Time < oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
				'Conver all to Min
				If oCnf.EnableMinHrs Then
					Dim ForHalfDayPresent As Integer = System.Decimal.Truncate(oCnf.MinHrsHalfPresent) * 60 + (oCnf.MinHrsHalfPresent - System.Decimal.Truncate(oCnf.MinHrsHalfPresent)) * 100
					Dim ForFullDayPresent As Integer = System.Decimal.Truncate(oCnf.MinHrsFullPresent) * 60 + (oCnf.MinHrsFullPresent - System.Decimal.Truncate(oCnf.MinHrsFullPresent)) * 100
					Dim Punch1Minutes As Integer = System.Decimal.Truncate(oAtnd.Punch1Time) * 60 + (oAtnd.Punch1Time - System.Decimal.Truncate(oAtnd.Punch1Time)) * 100
					Dim Punch2Minutes As Integer = System.Decimal.Truncate(oAtnd.Punch2Time) * 60 + (oAtnd.Punch2Time - System.Decimal.Truncate(oAtnd.Punch2Time)) * 100
					Dim WorkingMinutes = Punch2Minutes - Punch1Minutes
					If WorkingMinutes >= ForFullDayPresent Then
						oAtnd.PunchStatusID = "PR"
						oAtnd.PunchValue = 1
						oAtnd.FinalValue = 1
						oAtnd.NeedsRegularization = False
					ElseIf WorkingMinutes >= ForHalfDayPresent Then
						oAtnd.PunchStatusID = "AF"
						oAtnd.PunchValue = 0.5
						oAtnd.FinalValue = 0.5
						oAtnd.NeedsRegularization = True
					Else
						oAtnd.PunchStatusID = "AD"
						oAtnd.PunchValue = 0
						oAtnd.FinalValue = 0
						oAtnd.NeedsRegularization = True
					End If
				End If
			End If
			'Get Punch Required Settings
			Dim oPunchReq As SIS.ATN.atnPunchRequired = SIS.ATN.atnPunchRequired.GetPunchRequiredByCardNo(CardNo)
			If Not oPunchReq Is Nothing Then
				If oPunchReq.OnePunch Then
					If OnePunchFound Then
						With oAtnd
							.PunchStatusID = "PR"
							.PunchValue = 1
							.FinalValue = 1
							.NeedsRegularization = False
						End With
					End If
				End If
			End If
			SIS.ATN.atnProcessedPunch.Update(oAtnd)
			Return oAtnd
		End Function
		Private Shared Function UpdateProcessedPunchFromRawPunch(ByVal oAtnd As SIS.ATN.atnProcessedPunch, ByVal OfficeID As Integer) As SIS.ATN.atnProcessedPunch
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
			Dim CardNo As String = oAtnd.CardNo
			Dim DataDate As DateTime = Convert.ToDateTime(oAtnd.AttenDate, ci)
			'Get Calender
			Dim oHld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(DataDate, OfficeID)
			If Not oHld Is Nothing Then
				With oAtnd
					.Punch1Time = 0
					.Punch2Time = 0
					.PunchStatusID = oHld.PunchStatusID
					.PunchValue = 1
					.FinalValue = 1
					.NeedsRegularization = False
				End With
				SIS.ATN.atnProcessedPunch.Update(oAtnd)
				Return oAtnd
			End If
			'Process Logic
			Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(DataDate, oAtnd.CardNoHRM_Employees.C_OfficeID))
			'Get Punch Required Settings
			Dim oPunchReq As SIS.ATN.atnPunchRequired = SIS.ATN.atnPunchRequired.GetPunchRequiredByCardNo(CardNo)
			If Not oPunchReq Is Nothing Then
				If oPunchReq.NoPunch Then
					With oAtnd
						.Punch1Time = oCnf.STD1Time
						.Punch2Time = oCnf.STD2Time
						.PunchStatusID = "PR"
						.PunchValue = 1
						.FinalValue = 1
						.NeedsRegularization = False
					End With
					SIS.ATN.atnProcessedPunch.Update(oAtnd)
					Return oAtnd
				End If
			End If
			'Get Raw Punch
			Dim oRaw As SIS.ATN.atnRawPunch = SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(CardNo, DataDate)
			If oRaw Is Nothing Then
				With oAtnd
					.Punch1Time = 0
					.Punch2Time = 0
					.PunchStatusID = "AD"
					.PunchValue = 0
					.FinalValue = 0
					.NeedsRegularization = True
				End With
				SIS.ATN.atnProcessedPunch.Update(oAtnd)
				Return oAtnd
			End If
			If oAtnd.Punch1Time > 0 Then
				If oRaw.Punch1Time < oAtnd.Punch1Time Then
					oAtnd.Punch1Time = oRaw.Punch1Time
				End If
			Else
				oAtnd.Punch1Time = oRaw.Punch1Time
			End If
			If oRaw.Punch2Time > oAtnd.Punch2Time Then
				oAtnd.Punch2Time = oRaw.Punch2Time
			End If
			Dim OnePunchFound As Boolean = False
			If oAtnd.Punch1Time = 0 And oAtnd.Punch2Time = 0 Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
			ElseIf oAtnd.Punch1Time = 0 And oAtnd.Punch2Time < oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time = 0 And oAtnd.Punch2Time >= oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AF"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time <= oCnf.Range1End And oAtnd.Punch2Time < oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AS"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time <= oCnf.Range1End And oAtnd.Punch2Time >= oCnf.Range2Start Then
				oAtnd.PunchStatusID = "PR"
				oAtnd.PunchValue = 1
				oAtnd.FinalValue = 1
				oAtnd.NeedsRegularization = False
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time <= oCnf.Range1End And oAtnd.Punch2Time = 0 Then
				oAtnd.PunchStatusID = "AS"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time > oCnf.Range1End And oAtnd.Punch2Time >= oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AF"
				oAtnd.PunchValue = 0.5
				oAtnd.FinalValue = 0.5
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time > oCnf.Range1End And oAtnd.Punch2Time = 0 Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
			ElseIf oAtnd.Punch1Time > oCnf.Range1End And oAtnd.Punch2Time < oCnf.Range2Start Then
				oAtnd.PunchStatusID = "AD"
				oAtnd.PunchValue = 0
				oAtnd.FinalValue = 0
				oAtnd.NeedsRegularization = True
				OnePunchFound = True
				'Conver all to Min
				If oCnf.EnableMinHrs Then
					Dim ForHalfDayPresent As Integer = System.Decimal.Truncate(oCnf.MinHrsHalfPresent) * 60 + (oCnf.MinHrsHalfPresent - System.Decimal.Truncate(oCnf.MinHrsHalfPresent)) * 100
					Dim ForFullDayPresent As Integer = System.Decimal.Truncate(oCnf.MinHrsFullPresent) * 60 + (oCnf.MinHrsFullPresent - System.Decimal.Truncate(oCnf.MinHrsFullPresent)) * 100
					Dim Punch1Minutes As Integer = System.Decimal.Truncate(oAtnd.Punch1Time) * 60 + (oAtnd.Punch1Time - System.Decimal.Truncate(oAtnd.Punch1Time)) * 100
					Dim Punch2Minutes As Integer = System.Decimal.Truncate(oAtnd.Punch2Time) * 60 + (oAtnd.Punch2Time - System.Decimal.Truncate(oAtnd.Punch2Time)) * 100
					Dim WorkingMinutes = Punch2Minutes - Punch1Minutes
					If WorkingMinutes >= ForFullDayPresent Then
						oAtnd.PunchStatusID = "PR"
						oAtnd.PunchValue = 1
						oAtnd.FinalValue = 1
						oAtnd.NeedsRegularization = False
					ElseIf WorkingMinutes >= ForHalfDayPresent Then
						oAtnd.PunchStatusID = "AF"
						oAtnd.PunchValue = 0.5
						oAtnd.FinalValue = 0.5
						oAtnd.NeedsRegularization = True
					Else
						oAtnd.PunchStatusID = "AD"
						oAtnd.PunchValue = 0
						oAtnd.FinalValue = 0
						oAtnd.NeedsRegularization = True
					End If
				End If
			End If
			If Not oPunchReq Is Nothing Then
				If oPunchReq.OnePunch Then
					If OnePunchFound Then
						With oAtnd
							.PunchStatusID = "PR"
							.PunchValue = 1
							.FinalValue = 1
							.NeedsRegularization = False
						End With
					End If
				End If
			End If
			SIS.ATN.atnProcessedPunch.Update(oAtnd)
			Return oAtnd
		End Function
		Private Shared Function UpdateLedgerForAdvanceApplication(ByVal AttenID As Integer) As SIS.ATN.atnAttendance
			Dim _atnd As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(AttenID)
			Dim _Lgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(_atnd.AttenID)
			'There is no Change, POST the application line
			If _atnd.PunchValue = 0 Then
				_atnd.Posted = True
				_atnd.ApplStatusID = 6
				_atnd.FinalValue = 1
				SIS.ATN.atnAttendance.Update(_atnd)
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
				SIS.ATN.atnAttendance.Update(_atnd)
				For Each _lgr As SIS.ATN.atnLeaveLedger In _Lgrs
					SIS.ATN.atnLeaveLedger.Delete(_lgr)
				Next
				Dim _tmps As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(_aplHeaderID)
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
						Else ' Punch Status ID = AS
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
					Else	'Punch Status ID = AS
						.Applied1LeaveTypeID = ""
						.Posted1LeaveTypeID = ""
					End If
					.AppliedValue = 0.5
					.Posted = True
					.ApplStatusID = 6
					.FinalValue = 1
				End With
				SIS.ATN.atnAttendance.Update(_atnd)
			End If
			'Update Header
			'If Not complete change and header record is there
			If _atnd.ApplHeaderID <> String.Empty Then
				Dim _hdr As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(_atnd.ApplHeaderID)
				With _hdr
					Dim Found As Boolean = False
					Dim oAplDet As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(_hdr.LeaveApplID)
					For Each _det As SIS.ATN.atnAttendance In oAplDet
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
			Return _atnd
		End Function
		Public Shared Sub ProcessIndividual(ByVal DataDate As DateTime, ByVal oEmp As SIS.ATN.atnEmployees)
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
			Dim OfficeID As Integer = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(oEmp.C_OfficeID)
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
			Dim oPP As SIS.ATN.atnProcessedPunch = GetProcessedPunch(oEmp.CardNo, DataDate)
			Dim AttenID As Integer = oPP.AttenID
			'Update Punch Time and Status by New Values from Raw Punch
			'1. Only when user has not applied
			'2. User has applied but in advance
			'   2.1. This record is not posted
			If oPP.Applied Then
				If oPP.AdvanceApplication Then
					Dim _atnd As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(AttenID)
					If Not _atnd.Posted Then
						oPP = UpdateProcessedPunchForAdvApplFromRawPunch(oPP, OfficeID)
						If _atnd.ApplStatusID <> 5 Then	' Not Under Posting
							'Attendance Times and status are updated, 
							'delete the corresponding Ledger Record
							'and remove the application details from punch record, as it was not applied
							'delete the application header, if it was last record in application
							Dim _Lgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(AttenID)
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
							SIS.ATN.atnAttendance.Update(_atnd)
							'check there are records left in application
							Dim _tmps As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(_aplHeaderID)
							If _tmps.Count = 0 Then
								Dim _hdr As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(_aplHeaderID)
								SIS.ATN.atnApplHeader.Delete(_hdr)
							End If
							UpdateInterweavingLeaveAfterProcessing(AttenID)
						Else 'Under Posting
							'Post the Ledger
							_atnd = UpdateLedgerForAdvanceApplication(AttenID)
							UpdateInterweavingLeaveAfterPosting(AttenID)
						End If 'Not Under Posting
					End If 'Not Posted
				End If 'Advance Application
			Else 'Not Applied, then update
				oPP = UpdateProcessedPunchFromRawPunch(oPP, OfficeID)
				UpdateInterweavingLeaveAfterProcessing(AttenID)
			End If 'End of Applied
		End Sub

		Public Shared Sub ForcedUpdateInterweavingLeaveAfterProcessing(ByVal AttenID As Integer)
			'In normal processing system works fine, without forced,
			'In case of wrong processed value, Forced=True is used, for complete verification of data
			'Which is time taking
			'Forced does following things
			'1. It do not skip for holidays
			'2. It process on the Punch Value not on the final Value
			'SINCE Forced works on Punch Value
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)

			Dim oAtnd As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(AttenID)
			If oAtnd Is Nothing Then Exit Sub

			Dim DataDate As DateTime = Convert.ToDateTime(oAtnd.AttenDate, ci)
			Dim CardNo As String = oAtnd.CardNo
			Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
			Dim OfficeID As Integer = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(oEmp.C_OfficeID)

			Dim oHld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(DataDate, OfficeID)

			'Other Processing Variables
			Dim PrevDt As DateTime
			Dim NextDt As DateTime
			Dim mValue As Single = 0
			Dim mCompareWith As Single = 0
			'End Other Vars
			If oHld Is Nothing Then
			Else
			End If

			mValue = oAtnd.FinalValue

			If Not oHld Is Nothing Then
				mCompareWith = 1
			End If
			mValue = oAtnd.PunchValue

			If mValue = mCompareWith Then
				PrevDt = DataDate.AddDays(-1)
				oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
				If Not oHld Is Nothing Then
					Do While Not oHld Is Nothing
						PrevDt = PrevDt.AddDays(-1)
						oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
					Loop
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, PrevDt)
					If Not oTmp Is Nothing Then
						If oTmp.PunchValue = 0 Then
							RAbsentHLD(CardNo, DataDate, OfficeID)
						End If
					End If
				End If

				NextDt = DataDate.AddDays(1)
				oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
				If Not oHld Is Nothing Then
					Do While Not oHld Is Nothing
						NextDt = NextDt.AddDays(1)
						oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
					Loop
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, NextDt)
					If Not oTmp Is Nothing Then
						If oTmp.PunchValue = 0 Then
							FAbsentHLD(CardNo, DataDate, OfficeID)
						End If
					End If
				End If
			Else
				'During Reprocessing if CardPunch Found 
				'then it should correct The Values
				RRevertHLD(DataDate, CardNo, OfficeID)
				FRevertHLD(DataDate, CardNo, OfficeID)
			End If
		End Sub

		Public Shared Sub UpdateInterweavingLeaveAfterProcessing(ByVal AttenID As Integer)
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)

			Dim oAtnd As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(AttenID)
			If oAtnd Is Nothing Then Exit Sub

			Dim DataDate As DateTime = Convert.ToDateTime(oAtnd.AttenDate, ci)
			Dim CardNo As String = oAtnd.CardNo
			Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
			Dim OfficeID As Integer = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(oEmp.C_OfficeID)

			Dim oHld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(DataDate, OfficeID)
			If Not oHld Is Nothing Then Exit Sub 'Data Date is Holiday

			'Other Processing Variables
			Dim PrevDt As DateTime
			Dim NextDt As DateTime
			'End Other Vars


			If oAtnd.FinalValue = 0 Then
				PrevDt = DataDate.AddDays(-1)
				oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
				If Not oHld Is Nothing Then
					Do While Not oHld Is Nothing
						PrevDt = PrevDt.AddDays(-1)
						oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
					Loop
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, PrevDt)
					If Not oTmp Is Nothing Then
						If oTmp.FinalValue = 0 Then
							RAbsentHLD(CardNo, DataDate, OfficeID)
						End If
					End If
				End If

				NextDt = DataDate.AddDays(1)
				oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
				If Not oHld Is Nothing Then
					Do While Not oHld Is Nothing
						NextDt = NextDt.AddDays(1)
						oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
					Loop
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, NextDt)
					If Not oTmp Is Nothing Then
						If oTmp.FinalValue = 0 Then
							FAbsentHLD(CardNo, DataDate, OfficeID)
						End If
					End If
				End If
			Else
				'During Reprocessing if CardPunch Found 
				'then it should correct The Values
				RRevertHLD(DataDate, CardNo, OfficeID)
				FRevertHLD(DataDate, CardNo, OfficeID)
			End If
		End Sub
		Public Shared Sub UpdateInterweavingLeaveAfterPosting(ByVal AttenID As Integer)
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)

			Dim oAtnd As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(AttenID)
			If oAtnd Is Nothing Then Exit Sub
			If oAtnd.FinalValue = 0 Then Exit Sub

			Dim DataDate As DateTime = Convert.ToDateTime(oAtnd.AttenDate, ci)
			Dim CardNo As String = oAtnd.CardNo
			Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
			Dim OfficeID As Integer = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(oEmp.C_OfficeID)


			Dim oHld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(DataDate, OfficeID)
			If Not oHld Is Nothing Then Exit Sub 'Data Date is Holiday

			'Other Processing Variables
			Dim PrevDt As DateTime
			Dim NextDt As DateTime
			'End Other Vars

			If oAtnd.Applied1LeaveTypeID = "OD" Or oAtnd.Applied1LeaveTypeID = "SP" Or oAtnd.Applied1LeaveTypeID = "CO" Or oAtnd.Applied2LeaveTypeID = "OD" Or oAtnd.Applied2LeaveTypeID = "SP" Or oAtnd.Applied2LeaveTypeID = "CO" Then
				If oAtnd.ApplStatusID = 6 Then ' posted
					RRevertHLD(DataDate, CardNo, OfficeID)
					FRevertHLD(DataDate, CardNo, OfficeID)
				End If
			Else
				If oAtnd.Applied2LeaveTypeID = "CL" Then
					NextDt = DataDate.AddDays(1)
					oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
					If Not oHld Is Nothing Then
						PrevDt = DataDate.AddDays(-1)
						Dim MayRevert As Boolean = False
						Do While True
							Dim _Tmp As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetAttendanceByCardNoDate(CardNo, PrevDt)
							If _Tmp Is Nothing Then
								MayRevert = True
								Exit Do
							Else
								If Not _Tmp.NeedsRegularization Then
									MayRevert = True
									Exit Do
								Else
									If _Tmp.Applied1LeaveTypeID = "OD" Or _Tmp.Applied1LeaveTypeID = "SP" Or _Tmp.Applied1LeaveTypeID = "CO" Or _Tmp.Applied2LeaveTypeID = "OD" Or _Tmp.Applied2LeaveTypeID = "SP" Or _Tmp.Applied2LeaveTypeID = "CO" Then
										If _Tmp.ApplStatusID = 6 Then	'Posted
											MayRevert = True
											Exit Do
										Else
											Exit Do
										End If
									Else
										If _Tmp.Applied2LeaveTypeID <> "CL" Then
											Exit Do
										Else
											If _Tmp.ApplStatusID <> 6 Then
												Exit Do
											End If
										End If
									End If
								End If
							End If
							PrevDt = PrevDt.AddDays(-1)
						Loop
						If MayRevert Then
							FRevertHLD(DataDate, CardNo, OfficeID)
						End If
					End If
				Else
					PrevDt = DataDate.AddDays(-1)
					oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
					If Not oHld Is Nothing Then
						Do While Not oHld Is Nothing
							PrevDt = PrevDt.AddDays(-1)
							oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
						Loop
						Dim MayRevert As Boolean = False
						Do While True
							Dim _Tmp As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetAttendanceByCardNoDate(CardNo, PrevDt)
							If _Tmp Is Nothing Then
								MayRevert = True
								Exit Do
							Else
								If Not _Tmp.NeedsRegularization Then
									MayRevert = True
									Exit Do
								Else
									If _Tmp.Applied1LeaveTypeID = "OD" Or _Tmp.Applied1LeaveTypeID = "SP" Or _Tmp.Applied1LeaveTypeID = "CO" Or _Tmp.Applied2LeaveTypeID = "OD" Or _Tmp.Applied2LeaveTypeID = "SP" Or _Tmp.Applied2LeaveTypeID = "CO" Then
										If _Tmp.ApplStatusID = 6 Then	'Posted
											MayRevert = True
											Exit Do
										Else
											Exit Do
										End If
									Else
										If _Tmp.Applied2LeaveTypeID <> "CL" Then
											Exit Do
										Else
											If _Tmp.ApplStatusID <> 6 Then	' 
												Exit Do
											End If
										End If
									End If
								End If
							End If
							PrevDt = PrevDt.AddDays(-1)
						Loop
						If MayRevert Then
							RRevertHLD(DataDate, CardNo, OfficeID)
						End If
					End If
				End If
			End If
		End Sub
		Private Shared Sub FRevertHLD(ByVal DataDate As DateTime, ByVal CardNo As String, ByVal OfficeID As Integer)
			Dim NextDt As DateTime
			Dim oHld As SIS.ATN.atnHolidays
			NextDt = DataDate.AddDays(1)
			oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
			If Not oHld Is Nothing Then
				Do While Not oHld Is Nothing
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, NextDt)
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
					NextDt = NextDt.AddDays(1)
					oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
				Loop
			End If
		End Sub
		Private Shared Sub RRevertHLD(ByVal DataDate As DateTime, ByVal CardNo As String, ByVal OfficeID As Integer)
			Dim PrevDt As DateTime
			Dim oHld As SIS.ATN.atnHolidays
			PrevDt = DataDate.AddDays(-1)
			oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
			If Not oHld Is Nothing Then
				Do While Not oHld Is Nothing
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, PrevDt)
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
					PrevDt = PrevDt.AddDays(-1)
					oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
				Loop
			End If
		End Sub
		Private Shared Sub FAbsentHLD(ByVal CardNo As String, ByVal DataDate As DateTime, ByVal OfficeID As Integer)
			Dim NextDt As DateTime
			Dim oHld As SIS.ATN.atnHolidays
			NextDt = DataDate.AddDays(1)
			oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
			If Not oHld Is Nothing Then
				Do While Not oHld Is Nothing
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, NextDt)
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
					NextDt = NextDt.AddDays(1)
					oHld = SIS.ATN.atnHolidays.GetByHoliday(NextDt, OfficeID)
				Loop
			End If
		End Sub
		Private Shared Sub RAbsentHLD(ByVal CardNo As String, ByVal DataDate As DateTime, ByVal OfficeID As Integer)
			Dim PrevDt As DateTime
			Dim oHld As SIS.ATN.atnHolidays
			PrevDt = DataDate.AddDays(-1)
			oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
			If Not oHld Is Nothing Then
				Do While Not oHld Is Nothing
					Dim oTmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, PrevDt)
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
					PrevDt = PrevDt.AddDays(-1)
					oHld = SIS.ATN.atnHolidays.GetByHoliday(PrevDt, OfficeID)
				Loop
			End If
		End Sub

		Public Shared Sub ProcessForIndividualDate(ByVal dt As DateTime, ByVal oEmp As SIS.ATN.atnEmployees)
			Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(dt, oEmp.C_OfficeID))
			Dim dtStr As String = dt.ToString("ddMMyy")
			Dim oFiles() As String = IO.Directory.GetFiles(oCnf.DataFileLocation, "*" & dtStr & ".txt", IO.SearchOption.TopDirectoryOnly)
			For Each mFile As String In oFiles
				ProcessIndividualFile(mFile, dt, oCnf.MeanTime, oEmp.CardNo)
			Next
			ProcessIndividual(dt, oEmp)
		End Sub
		Private Shared Sub ProcessIndividualFile(ByVal FileName As String, ByVal DataDate As DateTime, ByVal MeanTime As Decimal, ByVal pCardNo As String)
			Dim oTR As IO.StreamReader = New IO.StreamReader(FileName)
			Dim mStr As String = oTR.ReadLine
			Do While Not mStr Is Nothing
				Dim aStr() As String = mStr.Split("     ".ToCharArray)
				Dim CardNo As String = aStr(1).Trim
				If CardNo <> pCardNo Then
					mStr = oTR.ReadLine
					Continue Do
				End If
				Dim strPunchTime As String = ""
				If strPunchTime = "" Then
					strPunchTime = aStr(5)
				End If
				If strPunchTime = "" Then
					strPunchTime = aStr(6)
				End If
				If strPunchTime = "" Then
					strPunchTime = aStr(7)
				End If
				If strPunchTime = "" Then
					strPunchTime = aStr(8)
				End If
				If strPunchTime = "" Then
					strPunchTime = "00:00"
				End If
				Dim PunchTime As Decimal = Convert.ToDecimal(strPunchTime.Replace(":", "."))
				Dim oRawPunch As SIS.ATN.atnRawPunch = SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(CardNo, DataDate)
				If Not oRawPunch Is Nothing Then
					With oRawPunch
						If PunchTime <= MeanTime Then
							If .Punch1Time > 0 Then
								If PunchTime < .Punch1Time Then
									.Punch1Time = PunchTime
								End If
							Else
								.Punch1Time = PunchTime
							End If
						Else
							If PunchTime > .Punch2Time Then
								.Punch2Time = PunchTime
							End If
						End If
					End With
					SIS.ATN.atnRawPunch.Update(oRawPunch)
				Else
					oRawPunch = New SIS.ATN.atnRawPunch
					With oRawPunch
						.CardNo = CardNo
						.PunchDate = DataDate
						.FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
						.Processed = False
						If PunchTime <= MeanTime Then
							.Punch1Time = PunchTime
						Else
							.Punch2Time = PunchTime
						End If
					End With
					SIS.ATN.atnRawPunch.Insert(oRawPunch)
				End If
				mStr = oTR.ReadLine
			Loop
			oTR.Close()
		End Sub
		Private Shared Sub ProcessPunch(ByVal DataDate As DateTime, Optional ByVal OnlyChennai As Boolean = False)
			Dim oEmps As List(Of SIS.ATN.atnEmployees) = SIS.ATN.atnEmployees.SelectList("CardNo")
			For Each oEmp As SIS.ATN.atnEmployees In oEmps
				ProcessIndividual(DataDate, oEmp)
			Next
		End Sub
		Public Shared Sub ProcessForDate(ByVal RecordID As Integer, Optional ByVal OnlyChennai As Boolean = False)
			Dim oPD As SIS.ATN.atnProcessPunch = SIS.ATN.atnProcessPunch.GetByID(RecordID)
			'Hardcoded 1 for Filelocation, mean time is picked up accurately latter
			'E=>For Location wise Rule 18-09-2015
			Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(oPD.ProcessDate, 1))
			Dim dtStr As String = Convert.ToDateTime(oPD.ProcessDate).ToString("ddMMyy")
			Dim oFiles() As String = IO.Directory.GetFiles(oCnf.DataFileLocation, "*" & dtStr & ".txt", IO.SearchOption.TopDirectoryOnly)
			For Each mFile As String In oFiles
				ProcessFile(mFile, oPD.ProcessDate, oCnf.MeanTime)
			Next
			ProcessPunch(oPD.ProcessDate, OnlyChennai)
			oPD.Processed = True
			SIS.ATN.atnProcessPunch.Update(oPD)
		End Sub
		Private Shared Sub ProcessFile(ByVal FileName As String, ByVal DataDate As DateTime, ByVal MeanTime As Decimal)
			Dim oTR As IO.StreamReader = New IO.StreamReader(FileName)
			Dim mStr As String = oTR.ReadLine
			Do While Not mStr Is Nothing
				Dim aStr() As String = mStr.Split("     ".ToCharArray)
				Dim CardNo As String = aStr(1).Trim
				'Get Card Replacment
				Dim oRepl As SIS.ATN.atnCardReplacement = SIS.ATN.atnCardReplacement.GetByID(CardNo)
				If Not oRepl Is Nothing Then
					CardNo = oRepl.CardNo
				End If
				'S=>For Location wise Rule 18-09-2015
				Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
				Dim oCnf As SIS.ATN.atnPunchConfig = SIS.ATN.atnPunchConfig.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActivePunchConfig(DataDate, oEmp.C_OfficeID))
				MeanTime = oCnf.MeanTime
				'E=>For Location wise Rule 18-09-2015
				'End of Card Replacement
				Dim strPunchTime As String = ""
				If strPunchTime = "" Then
					strPunchTime = aStr(5)
				End If
				If strPunchTime = "" Then
					strPunchTime = aStr(6)
				End If
				If strPunchTime = "" Then
					strPunchTime = aStr(7)
				End If
				If strPunchTime = "" Then
					strPunchTime = aStr(8)
				End If
				If strPunchTime = "" Then
					strPunchTime = "00:00"
				End If
				Dim PunchTime As Decimal = Convert.ToDecimal(strPunchTime.Replace(":", "."))
				Dim oRawPunch As SIS.ATN.atnRawPunch = SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(CardNo, DataDate)
				If Not oRawPunch Is Nothing Then
					With oRawPunch
						If PunchTime <= MeanTime Then
							If .Punch1Time > 0 Then
								If PunchTime < .Punch1Time Then
									.Punch1Time = PunchTime
								End If
							Else
								.Punch1Time = PunchTime
							End If
						Else
							If PunchTime > .Punch2Time Then
								.Punch2Time = PunchTime
							End If
						End If
					End With
					SIS.ATN.atnRawPunch.Update(oRawPunch)
				Else
					oRawPunch = New SIS.ATN.atnRawPunch
					With oRawPunch
						.CardNo = CardNo
						.PunchDate = DataDate
						.FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
						.Processed = False
						If PunchTime <= MeanTime Then
							.Punch1Time = PunchTime
						Else
							.Punch2Time = PunchTime
						End If
					End With
					SIS.ATN.atnRawPunch.Insert(oRawPunch)
				End If
				mStr = oTR.ReadLine
			Loop
			oTR.Close()
		End Sub
	End Class
End Namespace
Public Class LeaveCard
	Private _LeaveTypeID As String
	Private _Description As String
	Private _Days As Decimal
	Private _InProcessDays As Decimal
	Private _Requested As Decimal
	Private _AdvanceApplicable As Boolean

	Public ReadOnly Property Balance() As Decimal
		Get
			Return _Days - _InProcessDays - _Requested
		End Get
	End Property
	Public ReadOnly Property IsError() As Boolean
		Get
			If (_Days - _InProcessDays - _Requested) < 0 Then
				If Not _AdvanceApplicable Then
					Return True
				End If
			End If
			Return False
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
	Public Property Requested() As Decimal
		Get
			Return _Requested
		End Get
		Set(ByVal value As Decimal)
			_Requested = value
		End Set
	End Property
	Public Property InProcessDays() As Decimal
		Get
			Return _InProcessDays
		End Get
		Set(ByVal value As Decimal)
			_InProcessDays = value
		End Set
	End Property
	Public Property Days() As Decimal
		Get
			Return _Days
		End Get
		Set(ByVal value As Decimal)
			_Days = value
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
	Public Property LeaveTypeID() As String
		Get
			Return _LeaveTypeID
		End Get
		Set(ByVal value As String)
			_LeaveTypeID = value
		End Set
	End Property
End Class
Public Class AppliedLeave
	Private _LeaveType As String = ""
	Private _Days As Decimal = 0
	Public Property Days() As Decimal
		Get
			Return _Days
		End Get
		Set(ByVal value As Decimal)
			_Days = value
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
End Class
Public Class lgContext
	Private _Remarks As String
	Private _Applieds As New List(Of lgApplied)
	Private _SanctionRequired As Boolean
	Private _SanctionBy As String
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
	Public Property Remarks() As String
		Get
			Return _Remarks
		End Get
		Set(ByVal value As String)
			_Remarks = value
		End Set
	End Property

	Public Property Applieds() As List(Of lgApplied)
		Get
			Return _Applieds
		End Get
		Set(ByVal value As List(Of lgApplied))
			_Applieds = value
		End Set
	End Property
	Public Sub New()
		'dummy
	End Sub
	Public Sub New(ByVal Context As String)
		Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
		Dim aTmp() As String = Context.Split(":".ToCharArray)
		_Remarks = aTmp(1)
		Context = aTmp(0)
		aTmp = Context.Split("±".ToCharArray)
		For Each tmp As String In aTmp
			Dim aTmp1() As String = tmp.Split("|".ToCharArray)
			Dim apl As New lgApplied
			Try
				apl.AttenID = aTmp1(0)
			Catch ex As Exception
				'Advance Leave Application
				apl.AttenDate = aTmp1(0)
			End Try
			Dim aTmp2() As String = aTmp1(1).Split(",".ToCharArray)
			For Each ttmp As String In aTmp2
				For Each lt As SIS.ATN.atnLeaveTypes In oLTs
					If lt.LeaveTypeID = ttmp Then
						If lt.SpecialSanctionRequired Then
							_SanctionRequired = True
							_SanctionBy = lt.SpecialSanctionBy
						End If
						apl.Leaves.Add(lt)
					End If
				Next
			Next
			Try
				apl.AppliedFor = aTmp1(2)
			Catch ex As Exception
			End Try
			For Each tmpstr As String In aTmp2
				If tmpstr = "OD" Then
					apl.Destination = aTmp1(2)
					apl.Purpose = aTmp1(3)
					Exit For
				End If
			Next
			_Applieds.Add(apl)
		Next
	End Sub
End Class
Public Class lgApplied
	Private _AttenID As Integer
	Private _Leaves As New List(Of SIS.ATN.atnLeaveTypes)
	Private _AttenDate As String
	Private _AppliedFor As String
	Private _Destination As String = ""
	Private _Purpose As String = ""
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
	Public Property AppliedFor() As String
		Get
			Return _AppliedFor
		End Get
		Set(ByVal value As String)
			_AppliedFor = value
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
	Public Property Leaves() As List(Of SIS.ATN.atnLeaveTypes)
		Get
			Return _Leaves
		End Get
		Set(ByVal value As List(Of SIS.ATN.atnLeaveTypes))
			_Leaves = value
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
