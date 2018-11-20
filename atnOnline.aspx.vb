Imports System.Data.SqlClient
Imports System.Data
Partial Class atnOnline
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    Dim id As String = ""
    Dim val As String = ""
    Dim stopEMail As String = ""
    Try
      id = Request.QueryString("id")
      val = Request.QueryString("val")
    Catch ex As Exception
      id = ""
      val = ""
    End Try
    Try
      stopEMail = Request.QueryString("stopEMail")
    Catch ex As Exception
      stopEMail = ""
    End Try
    If stopEMail Is Nothing Then stopEMail = ""
    Dim apl As SIS.ATN.atnNewApplHeader = Nothing
    If id <> String.Empty Then
      HttpContext.Current.Session("LoginID") = ""
      apl = SIS.ATN.atnNewApplHeader.GetbyApplication(id)
    End If
    '===============
    Try
      If CreateLog(id, val, stopEMail, apl) Then
        Exit Sub
      End If
    Catch ex As Exception
    End Try
    '==============
    If apl Is Nothing Then
      msg.Text = "E-Mail Request is already EXECUTED."
      msg.ForeColor = Drawing.Color.Green
    Else
      HttpContext.Current.Session("FinYear") = SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear
      If apl.ApplStatusID = 2 Then
        HttpContext.Current.Session("LoginID") = apl.VerifiedBy
      ElseIf apl.ApplStatusID = 3 Then
        HttpContext.Current.Session("LoginID") = apl.ApprovedBy
      End If
      If val = apl.Approved Then
        Try
          SIS.ATN.atnApplHeader.ForwardApplication(apl.LeaveApplID, "Approved via E-Mail")
          apl = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(apl.LeaveApplID)
          apl.Application = ""
          apl.Approved = ""
          apl.Rejected = ""
          SIS.ATN.atnNewApplHeader.UpdateData(apl)
          msg.Text = "Approved successfully"
          msg.ForeColor = Drawing.Color.Green
        Catch ex As Exception
        End Try
      ElseIf val = apl.Rejected Then
        Try
          SIS.ATN.atnApplHeader.RejectApplication(apl.LeaveApplID, "Rejected via E-Mail")
          apl = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(apl.LeaveApplID)
          apl.Application = ""
          apl.Approved = ""
          apl.Rejected = ""
          SIS.ATN.atnNewApplHeader.UpdateData(apl)
          msg.Text = "Rejected Successfully"
          msg.ForeColor = Drawing.Color.Red
        Catch ex As Exception
        End Try
      Else
        msg.Text = "Invalid E-Mail"
        msg.ForeColor = Drawing.Color.Red
      End If
    End If
    'If stopEMail <> String.Empty Then
    '  HttpContext.Current.Session("LoginID") = ""
    '  apl = SIS.ATN.atnNewApplHeader.GetbyApplication(stopEMail)
    '  If apl IsNot Nothing Then
    '    Dim tmp As SIS.ATN.atnEmployeeConfiguration = Nothing
    '    If apl.ApplStatusID = 2 Then
    '      HttpContext.Current.Session("LoginID") = apl.VerifiedBy
    '      tmp = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetByID(apl.VerifiedBy)
    '      If tmp IsNot Nothing Then
    '        tmp.SendVerifyMail = False
    '        SIS.ATN.atnEmployeeConfiguration.UpdateData(tmp)
    '        apl.Application = ""
    '        apl.Approved = ""
    '        apl.Rejected = ""
    '        SIS.ATN.atnNewApplHeader.UpdateData(apl)
    '        msg.Text = "Stop E-Mail Notification for Leave Verification executed."
    '        msg.ForeColor = Drawing.Color.Green
    '      Else
    '        msg.Text = "Stop E-Mail Notification execution Error."
    '        msg.ForeColor = Drawing.Color.Red
    '      End If
    '    ElseIf apl.ApplStatusID = 3 Then
    '      HttpContext.Current.Session("LoginID") = apl.ApprovedBy
    '      tmp = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetByID(apl.ApprovedBy)
    '      If tmp IsNot Nothing Then
    '        tmp.SendApproveMail = False
    '        SIS.ATN.atnEmployeeConfiguration.UpdateData(tmp)
    '        apl.Application = ""
    '        apl.Approved = ""
    '        apl.Rejected = ""
    '        SIS.ATN.atnNewApplHeader.UpdateData(apl)
    '        msg.Text = "Stop E-Mail Notification for Leave Approval executed."
    '        msg.ForeColor = Drawing.Color.Green
    '      Else
    '        msg.Text = "Stop E-Mail Notification execution Error."
    '        msg.ForeColor = Drawing.Color.Red
    '      End If
    '    End If
    '  Else
    '    msg.Text = "Stop E-Mail Notification CAN NOT be executed."
    '    msg.ForeColor = Drawing.Color.Red
    '  End If
    'End If
  End Sub
  Protected Function CreateLog(ByVal id As String, ByVal val As String, ByVal toStop As String, ByVal apl As SIS.ATN.atnNewApplHeader) As Boolean
    Dim Blocked As Boolean = False
    Dim Prop As String = ""
    Dim head As String = ""
    Dim Req As String = "0"
    Dim emp As String = ""
    Dim action As String = ""
    Dim mMailID As String = "0"
    Dim mLinkID As String = "0"

    For Each pi As System.Reflection.PropertyInfo In Request.GetType.GetProperties
      If pi.MemberType = Reflection.MemberTypes.Property Then
        Try
          Prop &= "<br/> " & pi.Name & " : " & pi.GetValue(Request, Nothing)
        Catch ex As Exception
        End Try
      End If
    Next
    For I As Integer = 0 To Request.Headers.Count - 1
      head &= "<br/> " & Request.Headers.Keys(I) & " : " & Request.Headers.Item(I)
    Next
    If toStop <> "" Then
      action = "StopMail"
    End If
    If apl IsNot Nothing Then
      If apl.ApplStatusID = 2 Then
        action = "Verify"
        emp = apl.VerifiedBy
      ElseIf apl.ApplStatusID = 3 Then
        action = "Approve"
        emp = apl.ApprovedBy
      End If
      Req = apl.LeaveApplID
      If val = apl.Approved Then
        Prop = "APPROVE " & Prop
      ElseIf val = apl.Rejected Then
        Prop = "REJECT " & Prop
      End If
    End If
    Dim RemoteIP As String = ""
    Dim ip As String = String.Empty
    ip = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
    If Not String.IsNullOrEmpty(ip) Then
      Dim ipRange As String() = ip.Split(","c)
      Dim le As Integer = ipRange.Length - 1
      RemoteIP = ipRange(le)
    Else
      RemoteIP = Request.ServerVariables("REMOTE_ADDR")
    End If
    If Request.QueryString("MailID") IsNot Nothing Then
      mMailID = Request.QueryString("MailID")
    End If
    If Request.QueryString("LinkID") IsNot Nothing Then
      mLinkID = Request.QueryString("LinkID")
    End If

    If head.Trim.StartsWith("<br/> Accept : */*") Then
      Blocked = True
    End If

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
    mSql &= "'" & emp & "',"
    mSql &= "'" & action & "',"
    mSql &= Req & ",GetDate()"
    mSql &= ",'" & Prop & "',"
    If Blocked Then
      mSql &= "'BLOCKED " & head & "REMOTE_ADDRESS : " & RemoteIP & "',"
    Else
      mSql &= "'" & head & "REMOTE_ADDRESS : " & RemoteIP & "',"
    End If
    mSql &= mMailID & ","
    mSql &= mLinkID
    mSql &= ")"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = mSql
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
    End Using
    Return Blocked
  End Function

End Class
