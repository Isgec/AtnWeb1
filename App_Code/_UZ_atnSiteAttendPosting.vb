Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnSiteAttendPosting
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case ATNStatusID
            Case atnAplStates.UnderPosting
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function RejectWF(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal PostingRemarks As String) As SIS.ATN.atnSiteAttendPosting
      Dim Results As SIS.ATN.atnSiteAttendPosting = atnSiteAttendPostingGetByID(FinYear, MonthID, CardNo)
      With Results
        .PostedBy = HttpContext.Current.Session("LoginID")
        .PostedOn = Now
        .ATNStatusID = atnAplStates.SubmittedToHO
        .PostingRemarks = PostingRemarks
      End With
      Results = SIS.ATN.atnSiteAttendPosting.UpdateData(Results)
      Return Results
    End Function
    Public Shared Shadows Function InitiateWF(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal PostingRemarks As String) As String ' SIS.ATN.atnSiteAttendPosting
      Try
        HttpContext.Current.Session("EmployeeUnderProcess") = CardNo
        Dim context As String = GetContextString(FinYear, MonthID, CardNo, PostingRemarks)
        Dim oContext As LeaveContext = New LeaveContext(context)
        oContext.CardNo = CardNo
        Dim oLgrs As List(Of SIS.ATN.lgLedgerBalance) = GetLedgerBalance(oContext)
        '1. Validate By Leave Balance
        Dim ErrByLeaveBalance As Boolean = False
        For Each tmp As lgLedgerBalance In oLgrs
          If Not tmp.MayApply Then
            ErrByLeaveBalance = True
            Exit For
          End If
        Next
        If ErrByLeaveBalance Then
          Return GetStrByLeaveBalance(oLgrs, context)
        End If
        '2. Validate By LeaveCombination
        Dim ErrByLeaveCombination As Boolean = False
        Dim mRet As New SIS.SYS.Utilities.atnRetVal
        For Each lcd As LeaveContextDetail In oContext.LeaveContextDetails
          mRet = SIS.SYS.Utilities.NewAttendanceRules.CheckLeaveByCombination(lcd, oContext)
          If Not mRet.IsValid Then
            ErrByLeaveCombination = True
            lcd.ErrorMessage = mRet.Message
          End If
        Next
        If ErrByLeaveCombination Then
          Return GetStrErrByLeaveCombination(oContext)
        End If
        '3. Final Return To Submit
        Return GetStrByLeaveBalance(oLgrs, context)

      Catch ex As Exception
        Return ex.Message
      End Try

    End Function
    Public Shared Function UZ_atnSiteAttendPostingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String, ByVal Posted As Boolean) As List(Of SIS.ATN.atnSiteAttendPosting)
      Dim Results As List(Of SIS.ATN.atnSiteAttendPosting) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "MonthID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatn_LG_SiteAttendPostingSelectListSearch"
            'Cmd.CommandText = "spatnSiteAttendPostingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatn_LG_SiteAttendPostingSelectListFilteres"
            'Cmd.CommandText = "spatnSiteAttendPostingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_MonthID", SqlDbType.Int, 10, IIf(MonthID = Nothing, 0, MonthID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApprovedBy", SqlDbType.NVarChar, 8, IIf(ApprovedBy Is Nothing, String.Empty, ApprovedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted", SqlDbType.Bit, 3, Posted)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.ATN.atnSiteAttendPosting)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSiteAttendPosting(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnSiteAttendPostingSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String, ByVal Posted As Boolean) As Integer
      Return RecordCount
    End Function
    Public Shared Function UZ_atnSiteAttendPostingUpdate(ByVal Record As SIS.ATN.atnSiteAttendPosting) As SIS.ATN.atnSiteAttendPosting
      Dim _Result As SIS.ATN.atnSiteAttendPosting = atnSiteAttendance.UpdateData(Record)
      Return _Result
    End Function
    Public Shared Function UpdateAppliedLeaveStatus(ByVal Context As String) As String
      Try
        Dim oContext As LeaveContext = New LeaveContext(Context, True)
        oContext.CardNo = HttpContext.Current.Session("EmployeeUnderProcess")
        Dim oLgrs As List(Of SIS.ATN.lgLedgerBalance) = GetLedgerBalance(oContext)
        ''1. Validate By Leave Balance
        'Dim ErrByLeaveBalance As Boolean = False
        'For Each tmp As lgLedgerBalance In oLgrs
        '  If Not tmp.MayApply Then
        '    ErrByLeaveBalance = True
        '    Exit For
        '  End If
        'Next
        'If ErrByLeaveBalance Then
        '  Return GetStrByLeaveBalance(oLgrs, Context)
        'End If
        ''2. Validate By LeaveCombination
        'Dim ErrByLeaveCombination As Boolean = False
        'Dim mRet As New SIS.SYS.Utilities.atnRetVal
        'For Each lcd As LeaveContextDetail In oContext.LeaveContextDetails
        '  mRet = SIS.SYS.Utilities.NewAttendanceRules.CheckLeaveByCombination(lcd, oContext)
        '  If Not mRet.IsValid Then
        '    ErrByLeaveCombination = True
        '    lcd.ErrorMessage = mRet.Message
        '  End If
        'Next
        'If ErrByLeaveCombination Then
        '  Return GetStrErrByLeaveCombination(oContext)
        'End If

        '3. When NO Error Found, Create Leave Application, Create Ledger Record

        Dim oCon As SIS.ATN.LeaveContext = oContext
        Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(oCon.CardNo)

        Dim oAppl As New SIS.ATN.atnApplHeader
        Dim ApplStatus As Integer = 1
        With oAppl
          .CardNo = oEmp.CardNo
          If oEmp.VerifierID <> "" Then
            .VerificationRequired = oEmp.VerificationRequired
            .VerifiedBy = oEmp.VerifierID
          End If
          If oEmp.ApproverID <> "" Then
            .ApprovalRequired = oEmp.ApprovalRequired
            .ApprovedBy = oEmp.ApproverID
          End If
          .AppliedOn = Now
          .Remarks = oCon.Remarks
          .SanctionRequired = oCon.SanctionRequired
          .SanctionedBy = oCon.SanctionBy
          .AdvanceApplication = False
          .ExecutionState = 1
          ApplStatus = 5 'Under Posting
          .ApplStatusID = ApplStatus
        End With
        oAppl.LeaveApplID = SIS.ATN.atnApplHeader.Insert(oAppl)

        For Each apl As SIS.ATN.LeaveContextDetail In oCon.LeaveContextDetails
          Dim oPP As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDate(oCon.CardNo, apl.AttenDate)
          If oPP Is Nothing Then Continue For
          oPP.Applied = True
          oPP.ApplStatusID = ApplStatus
          oPP.ApplHeaderID = oAppl.LeaveApplID
          If oPP.PunchStatusID = "AF" Then
            oPP.Applied1LeaveTypeID = apl.LeaveType1
            oPP.Posted1LeaveTypeID = apl.LeaveType1
            oPP.AppliedValue = 0.5
          ElseIf oPP.PunchStatusID = "AS" Or oPP.PunchStatusID = "TS" Then
            oPP.Applied2LeaveTypeID = apl.LeaveType1
            oPP.Posted2LeaveTypeID = apl.LeaveType1
            oPP.AppliedValue = 0.5
          ElseIf oPP.PunchStatusID = "AD" Then
            Select Case apl.LeaveType1
              Case "PR"
                oPP.PunchStatusID = "PR"
                oPP.Punch1Time = "09.00"
                oPP.Punch2Time = "17.45"
                oPP.NeedsRegularization = False
                oPP.PunchValue = 1
                oPP.FinalValue = 1
                oPP.Applied = True
                oPP.ApplStatusID = ""
                oPP.Posted = True 'To Skip Posting Actual Posting
              Case "WO", "HD"
                oPP.PunchStatusID = apl.LeaveType1
                oPP.NeedsRegularization = False
                oPP.PunchValue = 1
                oPP.FinalValue = 1
                oPP.Applied = True
                oPP.ApplStatusID = ""
                oPP.Posted = True 'To Skip Posting Actual Posting
              Case "AD"
                'Do Nothing
              Case "OD"
                oPP.Applied1LeaveTypeID = apl.LeaveType1
                oPP.Applied2LeaveTypeID = apl.LeaveType1
                oPP.Posted1LeaveTypeID = apl.LeaveType1
                oPP.Posted2LeaveTypeID = apl.LeaveType1
                oPP.AppliedValue = 1
                If apl.LeaveType2 <> String.Empty Then
                  oPP.Applied2LeaveTypeID = apl.LeaveType2
                  oPP.Posted2LeaveTypeID = apl.LeaveType2
                End If
                oPP.Destination = apl.Destination
                oPP.Purpose = apl.Purpose
              Case Else
                oPP.Applied1LeaveTypeID = apl.LeaveType1
                oPP.Applied2LeaveTypeID = apl.LeaveType1
                oPP.Posted1LeaveTypeID = apl.LeaveType1
                oPP.Posted2LeaveTypeID = apl.LeaveType1
                oPP.AppliedValue = 1
                If apl.LeaveType2 <> String.Empty Then
                  oPP.Applied2LeaveTypeID = apl.LeaveType2
                  oPP.Posted2LeaveTypeID = apl.LeaveType2
                End If
            End Select
          End If
          SIS.ATN.atnNewAttendance.Update(oPP)
          'Update InProcess Ledger
          If oPP.PunchStatusID = "AF" Then
            Dim oLgr As New SIS.ATN.atnLeaveLedger
            With oLgr
              .CardNo = oEmp.CardNo
              .ApplHeaderID = oAppl.LeaveApplID
              .ApplDetailID = oPP.AttenID
              .InProcessDays = 0.5
              .LeaveTypeID = apl.LeaveType1
              .TranType = "TRN"
            End With
            SIS.ATN.atnLeaveLedger.Insert(oLgr)
          ElseIf oPP.PunchStatusID = "AS" Or oPP.PunchStatusID = "TS" Then
            Dim oLgr As New SIS.ATN.atnLeaveLedger
            With oLgr
              .CardNo = oEmp.CardNo
              .ApplHeaderID = oAppl.LeaveApplID
              .ApplDetailID = oPP.AttenID
              .InProcessDays = 0.5
              .LeaveTypeID = apl.LeaveType1
              .TranType = "TRN"
            End With
            SIS.ATN.atnLeaveLedger.Insert(oLgr)
          ElseIf oPP.PunchStatusID = "AD" Then
            Select Case apl.LeaveType1
              Case "AD"
              Case Else
                If apl.LeaveType2 <> String.Empty Then
                  Dim oLgr As New SIS.ATN.atnLeaveLedger
                  With oLgr
                    .CardNo = oEmp.CardNo
                    .ApplHeaderID = oAppl.LeaveApplID
                    .ApplDetailID = oPP.AttenID
                    .InProcessDays = 0.5
                    .LeaveTypeID = apl.LeaveType1
                    .TranType = "TRN"
                  End With
                  SIS.ATN.atnLeaveLedger.Insert(oLgr)
                  oLgr = New SIS.ATN.atnLeaveLedger
                  With oLgr
                    .CardNo = oEmp.CardNo
                    .ApplHeaderID = oAppl.LeaveApplID
                    .ApplDetailID = oPP.AttenID
                    .InProcessDays = 0.5
                    .LeaveTypeID = apl.LeaveType2
                    .TranType = "TRN"
                  End With
                  SIS.ATN.atnLeaveLedger.Insert(oLgr)
                Else
                  Dim oLgr As New SIS.ATN.atnLeaveLedger
                  With oLgr
                    .CardNo = oEmp.CardNo
                    .ApplHeaderID = oAppl.LeaveApplID
                    .ApplDetailID = oPP.AttenID
                    .InProcessDays = 1
                    .LeaveTypeID = apl.LeaveType1
                    .TranType = "TRN"
                  End With
                  SIS.ATN.atnLeaveLedger.Insert(oLgr)
                End If
            End Select
          End If
        Next
        '4. Post Application
        SIS.ATN.atnApplHeader.ForwardApplication(oAppl.LeaveApplID, "")
        '5. Update Site Attendance Record
        Dim Results As SIS.ATN.atnSiteAttendPosting = atnSiteAttendPostingGetByID(oCon.FinYear, oCon.MonthID, oCon.CardNo)
        With Results
          .PostedBy = HttpContext.Current.Session("LoginID")
          .PostedOn = Now
          .ATNStatusID = atnAplStates.Posted
          .PostingRemarks = oCon.Remarks
        End With
        Results = SIS.ATN.atnSiteAttendPosting.UpdateData(Results)
      Catch ex As Exception
        Return ex.Message
      End Try
      Return "true"
    End Function

    Private Shared Function GetStrByLeaveBalance(ByVal oBals As List(Of SIS.ATN.lgLedgerBalance), ByVal context As String) As String
      Dim err As Boolean = False
      Dim mRet As String = ""
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
            err = True
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
              err = True
            End If
            mRet = mRet & "</td>"
            mRet = mRet & "</tr>"
          Next
        End If
      Next
      mRet = mRet & "<tr>"
      If context IsNot Nothing Then
        mRet = mRet & "<td colspan=""3"" style=""text-align: right"">"
        mRet = mRet & "<input type=""button"" onclick=""cancelMessage();"" value=""Cancel"" />"
        mRet = mRet & "</td>"
        mRet = mRet & "<td colspan=""2"" style=""text-align: right"">"
        If Not err Then
          If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
            mRet = mRet & "<input type=""button"" disabled=""true"" value=""Submit"" />"
          Else
            mRet = mRet & "<input type=""button"" onclick=""lgValidate.UpdateAppliedLeaves('" & context & "');"" value=""Submit"" />"
          End If
        Else
          mRet = mRet & "<input type=""button"" disabled=""true"" value=""Submit"" />"
        End If
        mRet = mRet & "</td>"
      End If
      mRet = mRet & "</tr>"
      mRet = mRet & "</table>"
      mRet = mRet & ""
      Return mRet
    End Function
    Private Shared Function GetStrErrByLeaveCombination(ByVal lvContext As LeaveContext) As String
      Dim mRet As String = ""
      mRet = mRet & "<table width=""400px"">"
      mRet = mRet & "<tr>"
      mRet = mRet & "<td color=""bar_greenHeader"" height=""25px"" style=""text-align:left""><b><span style=""color:red"">LEAVE CAN NOT BE SUBMITTED</span></b>"
      mRet = mRet & "<ul>"

      Dim cnt As Integer = 0
      For Each lcd As LeaveContextDetail In lvContext.LeaveContextDetails
        If lcd.ErrorMessage <> String.Empty Then
          mRet = mRet & "<li style=""color:red"">" & lcd.ErrorMessage
          mRet = mRet & "</li>"
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
    End Function
    Private Shared Function GetLedgerBalance(ByVal oContext As LeaveContext) As List(Of SIS.ATN.lgLedgerBalance)
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
      Return oLgrs
    End Function
    Private Shared Function GetContextString(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal PostingRemarks As String) As String
      Dim Results As SIS.ATN.atnSiteAttendPosting = atnSiteAttendPostingGetByID(FinYear, MonthID, CardNo)
      Dim context As String = ""
      If Results.For22to31Dec Then
        For I As Integer = 22 To 31
          Dim tmp As String = ""
          Dim dy As String = I.ToString.PadLeft(2, "0")
          Dim md As String = "12"
          Dim yy As String = FinYear
          Dim Pprop As String = "PD" & dy
          tmp = CallByName(Results, Pprop, CallType.Get)
          '=====TR, HO Converted to OD
          Select Case tmp
            Case "HO", "TR"
              tmp = "OD"
          End Select
          '===========================
          If tmp <> "" Then
            Dim tmpDt As String = dy & "/" & md & "/" & yy
            If IsDate(tmpDt) Then
              If context <> "" Then
                context &= "±"
              End If
              context &= tmpDt & "|" & tmp & "|AD|Site|Site"
            End If
          End If
        Next
      Else
        For I As Integer = 1 To 31
          Dim tmp As String = ""
          Dim dy As String = I.ToString.PadLeft(2, "0")
          Dim md As String = ""
          Dim yy As String = FinYear
          If I >= 22 Then
            If MonthID = 1 Then
              'skip Dec attendance from 22nd to 31
              Continue For
              md = "12"
              yy = Convert.ToInt32(FinYear) - 1
            Else
              md = (MonthID - 1).ToString.PadLeft(2, "0")
              yy = FinYear
            End If
          Else
            md = (MonthID).ToString.PadLeft(2, "0")
            yy = FinYear
          End If
          Dim Pprop As String = "PD" & dy
          tmp = CallByName(Results, Pprop, CallType.Get)
          '=====TR, HO Converted to OD
          Select Case tmp
            Case "HO", "TR"
              tmp = "OD"
          End Select
          '===========================
          If tmp <> "" Then
            Dim tmpDt As String = dy & "/" & md & "/" & yy
            If IsDate(tmpDt) Then
              If context <> "" Then
                context &= "±"
              End If
              context &= tmpDt & "|" & tmp & "|AD|Site|Site"
            End If
          End If
        Next
      End If
      context = context & ":" & Results.PostingRemarks
      context = context & ":" & Results.FinYear
      context = context & ":" & Results.MonthID
      context = context & ":" & Results.CardNo
      context = context & ":" & Results.For22to31Dec
      Return context
    End Function
  End Class
End Namespace
