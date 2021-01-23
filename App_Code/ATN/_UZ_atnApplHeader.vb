Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail
Namespace SIS.ATN
  Partial Public Class atnApplHeader
    Public Shared Sub UnpostApplication(ByVal ApplHeaderID As Integer)
      If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
        Exit Sub
      End If
      Dim oApl As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(ApplHeaderID)
      oApl.ApplStatusID = 5
      oApl.PostingRemark = "Posting Reverted"
      oApl.PostedOn = Now
      oApl.PostedBy = HttpContext.Current.Session("LoginID")
      SIS.ATN.atnApplHeader.Update(oApl)
      Dim oDys As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(ApplHeaderID)
      For Each oDy As SIS.ATN.atnAttendance In oDys
        If Not oDy.Posted Then Continue For
        oDy.ApplStatusID = 5
        oDy.Posted = False
        oDy.FinalValue = oDy.PunchValue
        SIS.ATN.atnAttendance.Update(oDy)
        Dim oLgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(oDy.AttenID)
        For Each oLgr As SIS.ATN.atnLeaveLedger In oLgrs
          oLgr.InProcessDays = -1 * oLgr.Days
          oLgr.Days = 0
          oLgr.TranDate = Now
          SIS.ATN.atnLeaveLedger.Update(oLgr)
        Next
        SIS.SYS.Utilities.NewAttendanceRules.UpdateInterweavingHolidays(oDy.AttenID)
      Next
    End Sub
    Public Shared Sub ForwardApplication(ByVal ApplHeaderID As Integer, ByVal Remarks As String)
      If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
        Exit Sub
      End If
      Dim oApl As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(ApplHeaderID)
      Dim TmpApplStatusID As Integer = oApl.ApplStatusID
      Select Case TmpApplStatusID
        Case 2 ' Under Verification
          oApl.VerificationRemark = IIf(Remarks = String.Empty, "Verified", Remarks)
          oApl.VerificationOn = Now
          oApl.ApplStatusID = IIf(oApl.ApprovalRequired, 3, IIf(oApl.SanctionRequired, 4, 5))
        Case 3  'Under Approval
          oApl.ApprovalRemark = IIf(Remarks = String.Empty, "Approved", Remarks)
          oApl.ApprovalOn = Now
          oApl.ApplStatusID = IIf(oApl.SanctionRequired, 4, 5)
        Case 4  'Under Sanction
          oApl.SanctionRemark = IIf(Remarks = String.Empty, "Sanctioned", Remarks)
          oApl.SanctionOn = Now
          oApl.ApplStatusID = 5
        Case 5 'Under Posting
          oApl.PostingRemark = IIf(Remarks = String.Empty, "Posted", Remarks)
          oApl.PostedOn = Now
          oApl.ApplStatusID = 6
          oApl.PostedBy = HttpContext.Current.Session("LoginID")
      End Select
      SIS.ATN.atnApplHeader.Update(oApl)
      Dim oDys As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(ApplHeaderID)
      For Each oDy As SIS.ATN.atnAttendance In oDys
        If oDy.Posted Then Continue For
        oDy.ApplStatusID = oApl.ApplStatusID
        If oApl.ApplStatusID = 6 Then 'IF POSTING
          oDy.Posted = True
          Dim FinalValue As Decimal = 0
          If Not oDy.PunchValue = String.Empty Then
            FinalValue = Convert.ToDecimal(oDy.PunchValue)
          End If
          If Not oDy.AppliedValue = String.Empty Then
            FinalValue = FinalValue + Convert.ToDecimal(oDy.AppliedValue)
          End If
          oDy.FinalValue = FinalValue
        End If
        SIS.ATN.atnAttendance.Update(oDy)
        If oApl.ApplStatusID = 6 Then 'IF POSTING
          Dim oLgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(oDy.AttenID)
          For Each oLgr As SIS.ATN.atnLeaveLedger In oLgrs
            oLgr.Days = -1 * oLgr.InProcessDays
            oLgr.InProcessDays = 0
            oLgr.TranDate = Now
            SIS.ATN.atnLeaveLedger.Update(oLgr)
          Next
        End If
        'SIS.SYS.Utilities.ProcessCardPunch.UpdateInterweavingLeaveAfterPosting(oDy.AttenID)
        SIS.SYS.Utilities.NewAttendanceRules.UpdateInterweavingHolidays(oDy.AttenID)
      Next
      'Send E-Mail To Approver if It was under verification
      If TmpApplStatusID = 2 And oApl.ApplStatusID = 3 Then
        SendApplicationEMail(oApl.LeaveApplID)
      End If
    End Sub
    Public Shared Sub RejectApplication(ByVal ApplHeaderID As Integer, ByVal Remarks As String)
      If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
        Exit Sub
      End If
      Dim oApl As SIS.ATN.atnApplHeader = SIS.ATN.atnApplHeader.GetByID(ApplHeaderID)
      Dim TmpApplStatusID As Integer = oApl.ApplStatusID
      Select Case TmpApplStatusID
        Case 2 ' Under Verification
          oApl.VerificationRemark = IIf(Remarks = String.Empty, "NOT Verified", Remarks)
          oApl.VerificationOn = Now
        Case 3  'Under Approval
          oApl.ApprovalRemark = IIf(Remarks = String.Empty, "NOT Approved", Remarks)
          oApl.ApprovalOn = Now
        Case 4  'Under Sanction
          oApl.SanctionRemark = IIf(Remarks = String.Empty, "NOT Sanctioned", Remarks)
          oApl.SanctionOn = Now
        Case 5  'Under Posting
          oApl.PostingRemark = IIf(Remarks = String.Empty, "NOT Posted", Remarks)
          oApl.PostedOn = Now
          oApl.PostedBy = HttpContext.Current.Session("LoginID")
      End Select
      oApl.ApplStatusID = 7
      SIS.ATN.atnApplHeader.Update(oApl)
      Dim oDys As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(ApplHeaderID)
      For Each oDy As SIS.ATN.atnAttendance In oDys
        If Not oDy.Posted Then
          oDy.Applied = False
          oDy.ApplStatusID = 7
          oDy.AppliedValue = 0
          oDy.Applied1LeaveTypeID = ""
          oDy.Applied2LeaveTypeID = ""
          oDy.Posted1LeaveTypeID = ""
          oDy.Posted2LeaveTypeID = ""
          SIS.ATN.atnAttendance.Update(oDy)
          'Delete Ledger
          Dim oLgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(oDy.AttenID)
          For Each oLgr As SIS.ATN.atnLeaveLedger In oLgrs
            SIS.ATN.atnLeaveLedger.Delete(oLgr)
          Next
        End If
      Next
    End Sub
    Public Shared Function SelectApplicationsUnderVerification(ByVal CardNo As String) As List(Of SIS.ATN.atnApplHeader)
      Dim Results As List(Of SIS.ATN.atnApplHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_ApplicationsUnderVerification"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID", SqlDbType.Int, 2, 2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnApplHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnApplHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectApplicationsToBeApproved(ByVal CardNo As String) As List(Of SIS.ATN.atnApplHeader)
      Dim Results As List(Of SIS.ATN.atnApplHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_ApplicationsToBeApproved"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID", SqlDbType.Int, 2, 3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnApplHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnApplHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UpdateAppliedLeaveStatus(ByVal Context As String, Optional ByVal AdvanceApplication As Boolean = False) As String
      'Revalidate Before Posting
      Dim MaySubmit As Boolean = False
      SIS.ATN.atnLeaveLedger.NewCheckAppliedLeaves(Context, MaySubmit)
      If Not MaySubmit Then Return "true"
      'End of Revalidation

      Dim oCon As SIS.ATN.LeaveContext = New SIS.ATN.LeaveContext(Context, True)
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(HttpContext.Current.Session("EmployeeUnderProcess"))

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
        .AdvanceApplication = AdvanceApplication
        .ExecutionState = 1
        If .VerificationRequired Then
          ApplStatus = 2
        ElseIf .ApprovalRequired Then
          ApplStatus = 3
        ElseIf .SanctionRequired Then
          ApplStatus = 4
        Else
          ApplStatus = 5
        End If
        .ApplStatusID = ApplStatus
      End With
      oAppl.LeaveApplID = SIS.ATN.atnApplHeader.Insert(oAppl)

      For Each apl As SIS.ATN.LeaveContextDetail In oCon.LeaveContextDetails
        If AdvanceApplication Then
          Dim onPP As New SIS.ATN.atnProcessedPunch
          With onPP
            .AttenDate = apl.AttenDate
            .CardNo = oEmp.CardNo
            .NeedsRegularization = True
            .Punch1Time = 0
            .Punch2Time = 0
            .AdvanceApplication = True
            .PunchStatusID = "AD"
            .PunchValue = 0
            .FinalValue = 0
          End With
          onPP.AttenID = SIS.ATN.atnProcessedPunch.Insert(onPP)
          apl.AttenID = onPP.AttenID
        End If
        Dim oPP As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(apl.AttenID)
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
          oPP.Applied1LeaveTypeID = apl.LeaveType1
          oPP.Applied2LeaveTypeID = apl.LeaveType1
          oPP.Posted1LeaveTypeID = apl.LeaveType1
          oPP.Posted2LeaveTypeID = apl.LeaveType1
          oPP.AppliedValue = 1
          If apl.LeaveType2 <> String.Empty Then
            oPP.Applied2LeaveTypeID = apl.LeaveType2
            oPP.Posted2LeaveTypeID = apl.LeaveType2
          End If
        End If
        oPP.Destination = apl.Destination
        oPP.Purpose = apl.Purpose
        SIS.ATN.atnAttendance.Update(oPP)
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
        End If
      Next
      '===================
      SendApplicationEMail(oAppl.LeaveApplID)
      '===================
      Return "true"
    End Function
    Private Shared Sub SendApplicationEMail(ByVal aplID As Integer)
      Dim maySend As Boolean = False
      Dim subject As String = ""
      Dim ad As MailAddress = Nothing
      Dim apl As SIS.ATN.atnNewApplHeader = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(aplID)

      Select Case apl.ApplStatusID
        Case 2 'Under Verification
          Dim tmpConf As SIS.ATN.atnEmployeeConfiguration = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetByID(apl.VerifiedBy)
          If tmpConf.SendVerifyMail Then
            subject = "Verify Leave Application of "
            Try
              Dim tmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(apl.VerifiedBy)
              ad = New MailAddress(tmp.EMailID, tmp.EmployeeName)
              maySend = True
            Catch ex As Exception
            End Try
          End If
        Case 3 'Under Approval
          Dim tmpConf As SIS.ATN.atnEmployeeConfiguration = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetByID(apl.ApprovedBy)
          If tmpConf.SendApproveMail Then
            subject = "Approve Leave Application of "
            Try
              Dim tmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(apl.ApprovedBy)
              ad = New MailAddress(tmp.EMailID, tmp.EmployeeName)
              maySend = True
            Catch ex As Exception
            End Try
          End If
      End Select
      If maySend Then
        apl.Application = Guid.NewGuid.ToString
        apl.Approved = Guid.NewGuid.ToString
        apl.Rejected = Guid.NewGuid.ToString

        SIS.ATN.atnNewApplHeader.UpdateData(apl)

        Dim aplWord As String = IIf(apl.ApplStatusID = 2, "Verify", "Approve")

        Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(apl.CardNo)
        subject &= oEmp.EmployeeName
        Dim oClient As SmtpClient = New SmtpClient()
        Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
        If ad IsNot Nothing Then
          oMsg.To.Add(ad)
          'oMsg.To.Add("lalit@isgec.co.in")
        End If
        'From EMail
        If oEmp.EMailID <> String.Empty Then
          ad = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
          oMsg.From = ad
          'oMsg.CC.Add(ad)
        End If
        oMsg.Subject = subject
        oMsg.IsBodyHtml = True

        Dim oDys As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(apl.LeaveApplID)
        Dim mMailID As String = SIS.SYS.Utilities.ApplicationSpacific.NextMailNo
        Dim mLinkID As String = ""

        Dim sb As New StringBuilder
        With sb
          .AppendLine("<table style=""width:90%"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
          .AppendLine("<tr><td colspan=""2"" style='text-align:center;font-size:12px;font-weight:bold;background-color:#C0C0C0'>LEAVE APPLICATION</td></tr>")
          .AppendLine("<tr><td><b>Employee</b></td>")
          .AppendLine("<td>" & oEmp.EmployeeName & "</td></tr>")
          .AppendLine("<tr><td style='font-weight:bold;text-align:center;font-size:12px;background-color:#C0C0C0'>Date</td>")
          .AppendLine("<td style='font-weight:bold;text-align:center;font-size:12px;background-color:#C0C0C0'>Leave Type</td></tr>")
          For Each oDy As SIS.ATN.atnAttendance In oDys
            Dim tmp As String = IIf(oDy.PunchStatusID = "AD", "Full Day", IIf(oDy.PunchStatusID = "AF", "First Half", "Second Half"))
            Dim tmp2 As String = ""
            If oDy.Applied1LeaveTypeID = oDy.Applied2LeaveTypeID Then
              tmp2 = SIS.ATN.atnLeaveTypes.GetByID(oDy.Applied1LeaveTypeID).Description
            ElseIf oDy.Applied1LeaveTypeID = "" Then
              tmp2 = SIS.ATN.atnLeaveTypes.GetByID(oDy.Applied2LeaveTypeID).Description
            ElseIf oDy.Applied2LeaveTypeID = "" Then
              tmp2 = SIS.ATN.atnLeaveTypes.GetByID(oDy.Applied1LeaveTypeID).Description
            Else
              tmp2 = SIS.ATN.atnLeaveTypes.GetByID(oDy.Applied1LeaveTypeID).Description & ", " & SIS.ATN.atnLeaveTypes.GetByID(oDy.Applied2LeaveTypeID).Description
            End If
            .AppendLine("<tr><td>" & oDy.AttenDate & "</td><td>" & tmp & " " & tmp2 & "</td></tr>")
          Next
          .AppendLine("<tr><td><b>Reason</b></td>")
          .AppendLine("<td>" & apl.Remarks & "</td></tr>")
          mLinkID = SIS.SYS.Utilities.ApplicationSpacific.NextLinkNo
          .AppendLine("<tr><td style='font-weight:bold;text-align:center;font-size:12px;background-color:#66FF33'><a style='color:green' href='http://cloud.isgec.co.in/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Approved & "&MailID=" & mMailID & "&LinkID=" & mLinkID & "&Task=" & aplWord & "'>" & aplWord & "</a></td>")
          .AppendLine("<td style='font-weight:bold;text-align:center;font-size:12px;background-color:#FF99CC'><a style='color:red' href='http://cloud.isgec.co.in/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Rejected & "&MailID=" & mMailID & "&LinkID=" & mLinkID & "'>Reject</a></td></tr>")

          .AppendLine("<tr><td colspan=""2"" align=""center""><p>Above links are for Mobile users (Blackberry/Smartphone).</p><p>If you are on your computer or connected to office Network through VPN, Please use links given below.</p></td></tr>")

          .AppendLine("<tr><td style='text-align:center'><a style='color:green' href='http://192.9.200.146/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Approved & "&MailID=" & mMailID & "&LinkID=" & mLinkID & "&Task=" & aplWord & "'>" & aplWord & "</a></td>")
          .AppendLine("<td style='text-align:center'><a style='color:red' href='http://192.9.200.146/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Rejected & "&MailID=" & mMailID & "&LinkID=" & mLinkID & "'>Reject</a></td></tr>")

          .AppendLine("<tr><td colspan='2' style='font-style:italic'>This is auto generated E-Mail, DO NOT REPLY.</td></tr>")
          .AppendLine("</table>")
        End With
        Try
          Dim Header As String = ""
          Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
          Header = Header & "<head>"
          Header = Header & "<title></title>"
          Header = Header & "<style>"
          Header = Header & "table{"

          Header = Header & "border: solid 1pt black;"
          Header = Header & "border-collapse:collapse;"
          Header = Header & "font-family: Tahoma;}"

          Header = Header & "td{"
          Header = Header & "border: solid 1pt black;"
          Header = Header & "font-family: Tahoma;"
          Header = Header & "font-size: 12px;"
          Header = Header & "vertical-align:top;}"

          Header = Header & "</style>"
          Header = Header & "</head>"
          Header = Header & "<body>"
          Header &= "<a href='http://192.9.200.146/atnweb1/dummy.aspx'>.</a><br/>"
          Header = Header & sb.ToString
          Header = Header & "</body></html>"
          oMsg.Body = Header
          oMsg.Body &= "<br/>Mail-ID: " & mMailID

          oClient.Send(oMsg)
          Dim mSql As String = " INSERT ATN_Log "
          mSql &= " ("
          mSql &= " UserID,"
          mSql &= " Action,"
          mSql &= " RequestID,"
          mSql &= " LoggedOn,"
          mSql &= " RequestProp,"
          mSql &= " RequestHeader,"
          mSql &= " MailSrNo,"
          mSql &= " LinkSrNo"
          mSql &= " )"
          mSql &= " VALUES ("
          mSql &= "'" & apl.CardNo & "',"
          mSql &= "'Submit',"
          mSql &= apl.LeaveApplID & ",GetDate()"
          mSql &= ",'" & aplWord & "',"
          mSql &= "'',"
          mSql &= mMailID & ","
          mSql &= 0
          mSql &= ")"
          Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
            Using Cmd As SqlCommand = Con.CreateCommand()
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = mSql
              Con.Open()
              Cmd.ExecuteNonQuery()
            End Using
          End Using
        Catch ex As Exception
        End Try
      End If
    End Sub
    Public Shared Sub SendClubbedEMailForVerificationOrApproval(ByVal empID As String, Optional ByVal Approver As Boolean = False)
      Dim maySend As Boolean = False
      Dim subject As String = ""
      Dim ad As MailAddress = Nothing
      Dim emp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(empID)
      ad = New MailAddress(emp.EMailID, emp.EmployeeName)
      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      If ad IsNot Nothing Then
        oMsg.To.Add(ad)
        'oMsg.To.Add("lalit@isgec.co.in")
      End If
      ad = New MailAddress("leave@isgec.co.in", "ISGEC HRD")
      oMsg.From = ad
      oMsg.IsBodyHtml = True
      Dim mMailID As String = SIS.SYS.Utilities.ApplicationSpacific.NextMailNo
      Dim mLinkID As String = ""
      Dim sb As New StringBuilder
      With sb
        .AppendLine("<table style=""width:90%"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""5"" style='text-align:center;font-size:12px;font-weight:bold;background-color:#C0C0C0'>LIST OF LEAVE APPLICATION(s)</td></tr>")
        .AppendLine("<tr><td style='font-size:10px;font-weight:bold;background-color:#C0C0C0'>Employee Name</td><td style='font-size:10px;font-weight:bold;background-color:#C0C0C0'>Applied On</td><td style='font-size:10px;font-weight:bold;background-color:#C0C0C0'>Reason</td><td style='text-align:center;font-size:10px;font-weight:bold;background-color:#C0C0C0'>Approve</td><td style='text-align:center;font-size:10px;font-weight:bold;background-color:#C0C0C0'>Reject</td></tr>")
      End With
      Dim oVrfs As List(Of SIS.ATN.atnApplHeader) = Nothing
      If Not Approver Then
        oVrfs = SIS.ATN.atnApplHeader.SelectApplicationsUnderVerification(empID)
        subject = "Verify Leave Application(s)"
        For Each vrf As SIS.ATN.atnApplHeader In oVrfs
          maySend = True
          Dim apl As SIS.ATN.atnNewApplHeader = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(vrf.LeaveApplID)
          apl.Application = Guid.NewGuid.ToString
          apl.Approved = Guid.NewGuid.ToString
          apl.Rejected = Guid.NewGuid.ToString
          SIS.ATN.atnNewApplHeader.UpdateData(apl)
          With sb
            .AppendLine("<tr>")
            .AppendLine("<td>" & apl.HRM_Employees3_EmployeeName & "</td>")
            .AppendLine("<td>" & apl.AppliedOn & "</td>")
            .AppendLine("<td>" & apl.Remarks & "</td>")
            .AppendLine("<td style='text-align:center;font-weight:bold'><a style='color:green' href='http://cloud.isgec.co.in/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Approved & "&MailID=" & mMailID & "&LinkID=" & mLinkID & "'>Verify</a></td>")
            .AppendLine("<td style='text-align:center;font-weight:bold'><a style='color:red' href='http://cloud.isgec.co.in/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Rejected & "&MailID=" & mMailID & "&LinkID=" & mLinkID & "'>Reject</a></td>")
            .AppendLine("</tr>")
          End With
        Next
      Else
        oVrfs = SIS.ATN.atnApplHeader.SelectApplicationsToBeApproved(empID)
        subject = "Approve Leave Application(s)"
        For Each vrf As SIS.ATN.atnApplHeader In oVrfs
          maySend = True
          Dim apl As SIS.ATN.atnNewApplHeader = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(vrf.LeaveApplID)
          apl.Application = Guid.NewGuid.ToString
          apl.Approved = Guid.NewGuid.ToString
          apl.Rejected = Guid.NewGuid.ToString
          SIS.ATN.atnNewApplHeader.UpdateData(apl)
          With sb
            .AppendLine("<tr>")
            .AppendLine("<td>" & apl.HRM_Employees3_EmployeeName & "</td>")
            .AppendLine("<td>" & apl.AppliedOn & "</td>")
            .AppendLine("<td>" & apl.Remarks & "</td>")
            .AppendLine("<td style='text-align:center;font-weight:bold'><a style='color:green' href='http://cloud.isgec.co.in/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Approved & "'>Approve</a></td>")
            .AppendLine("<td style='text-align:center;font-weight:bold'><a style='color:red' href='http://cloud.isgec.co.in/atnweb1/atnOnline.aspx?id=" & apl.Application & "&val=" & apl.Rejected & "'>Reject</a></td>")
            .AppendLine("</tr>")
          End With
        Next
      End If
      oMsg.Subject = subject
      With sb
        .AppendLine("<tr><td colspan='5' style='font-style:italic'>This is auto generated E-Mail, DO NOT REPLY.</td></tr>")
        .AppendLine("</table>")
      End With
      Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 12px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header &= "<a href='http://192.9.200.146/atnweb1/dummy.aspx'>.</a><br/>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        oMsg.Body = Header
        oMsg.Body &= "<br/>Mail-ID: " & mMailID

        oClient.Send(oMsg)
        Dim mSql As String = " INSERT ATN_Log "
        mSql &= " ("
        mSql &= " UserID,"
        mSql &= " Action,"
        mSql &= " RequestID,"
        mSql &= " LoggedOn,"
        mSql &= " RequestProp,"
        mSql &= " RequestHeader,"
        mSql &= " MailSrNo,"
        mSql &= " LinkSrNo"
        mSql &= " )"
        mSql &= " VALUES ("
        mSql &= "'" & empID & "',"
        mSql &= "'Submit',"
        mSql &= 0 & ",GetDate()"
        mSql &= ",'" & subject & "',"
        mSql &= "'',"
        mSql &= mMailID & ","
        mSql &= 0
        mSql &= ")"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            Cmd.ExecuteNonQuery()
          End Using
        End Using
      Catch ex As Exception
      End Try
    End Sub
  End Class
End Namespace
