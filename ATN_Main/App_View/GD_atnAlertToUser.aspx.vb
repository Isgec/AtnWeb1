Imports System.Net.Mail
Partial Class GD_atnAlertToUser
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnAlertToUser"
    SetGridView = GridView1
  End Sub
  Protected Sub SendMail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVals() As String = oBut.CommandArgument.ToString.Split("|".ToCharArray)
    Dim CardNo As String = aVals(0)
    Dim EmpName As String = aVals(1)
    Dim Days As String = aVals(2)
    Dim EMailID As String = aVals(3)
    Dim Mon As String = aVals(4)
    'Send Mail
    If Not EMailID Is Nothing Then
      If EMailID <> String.Empty Then
        Try
          Dim oClient As SmtpClient = New SmtpClient()
          Dim oMsg As New System.Net.Mail.MailMessage()
          With oMsg
            .IsBodyHtml = True
            .To.Add(EMailID)
            '.To.Add("lalitisgec.co.in")
            '.CC.Add("tsldisgec.co.in")
            .Subject = "Attendance Regularization"
            Dim mStr As String = "<table border=""0"" cellspacing=""0"" cellpadding=""0"">"
            mStr = mStr & "<tr><td><b>Dear " & EmpName & ",</b></td></tr>"
            mStr = mStr & "<tr><td style=""padding-top: 10px"">Your attendance status is absent for <b>" & Days & "</b> day(s) in the month of <b>" & MonthName(Mon) & "</b>.</td></tr>"
            mStr = mStr & "<tr><td>You are requested to regularize it today.</td></tr>"
            mStr = mStr & "<tr><td style=""padding-top: 10px"">Thanx.</td></tr>"
            mStr = mStr & "<tr><td style=""padding-top: 10px"">(for further queries contact HR.)</td></tr>"
            mStr = mStr & "</table>"
            .Body = mStr
          End With
          oClient.Send(oMsg)

        Catch ex As Exception

        End Try

      End If
    End If
  End Sub

  'Protected Sub LC_AttenMonth1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_AttenMonth1.SelectedIndexChanged
  '	Session("LC_AttenMonth") = LC_AttenMonth1.SelectedValue
  '	Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
  '	If Session("PageNoProvider") = True Then
  '		SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
  '	Else
  '		Session("PageNo_" & FileName) = 0
  '	End If
  'End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		If Not Session("LC_AttenMonth") Is Nothing Then
			LC_AttenMonth1.SelectedValue = Session("LC_AttenMonth").ToString
		Else
			LC_AttenMonth1.SelectedValue = String.Empty
		End If
	End Sub

End Class
