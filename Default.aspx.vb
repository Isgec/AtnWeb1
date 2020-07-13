Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class LGDefault
    Inherits System.Web.UI.Page
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function LoadUserControl(ByVal message As String) As String
    Using page As New Page()
      Dim userControl As UserControl = DirectCast(page.LoadControl("Message.ascx"), UserControl)
      TryCast(userControl.FindControl("lblMessage"), Label).Text = message
      page.Controls.Add(userControl)
      Using writer As New StringWriter()
        page.Controls.Add(userControl)
        HttpContext.Current.Server.Execute(page, writer, False)
        Return writer.ToString()
      End Using
    End Using
  End Function

  'Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
  '      Dim strPara As String = ""
  '      Dim cnt As Boolean = False
  '      Dim uVal As String = "1"
  '      If Request.QueryString("wpid") IsNot Nothing Then
  '          strPara = Request.QueryString("wpid")
  '      End If
  '      If Request.QueryString("cnt") IsNot Nothing Then
  '          cnt = True
  '      End If
  '      If Request.QueryString("uVal") IsNot Nothing Then
  '          uVal = Request.QueryString("uVal")
  '      End If
  '      Dim strUser As String = ""
  '      If strPara <> String.Empty Then
  '          Using Con As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
  '              Using Cmd As System.Data.SqlClient.SqlCommand = Con.CreateCommand()
  '                  Dim mSql As String = "select LoginID from aspnet_users where wp_user = '" & strPara & "'"
  '                  Cmd.CommandType = System.Data.CommandType.Text
  '                  Cmd.CommandText = mSql
  '                  Con.Open()
  '                  strUser = Cmd.ExecuteScalar()
  '                  Try
  '                      If strUser Is Nothing Then
  '                          strUser = ""
  '                      End If
  '                  Catch ex As Exception
  '                      strUser = ""
  '                  End Try
  '              End Using
  '              If strUser <> String.Empty Then
  '                  Using Cmd As System.Data.SqlClient.SqlCommand = Con.CreateCommand()
  '                      Dim mSql As String = "update aspnet_users set wp_user = '' where LoginID = '" & strUser & "'"
  '                      Cmd.CommandType = System.Data.CommandType.Text
  '                      Cmd.CommandText = mSql
  '                      Cmd.ExecuteNonQuery()
  '                  End Using
  '              End If
  '          End Using
  '          If strUser IsNot Nothing Then
  '              If strUser <> String.Empty Then
  '                  Dim pw As String = ""
  '                  Try
  '                      pw = SIS.SYS.Utilities.SessionManager.GetPassword(strUser)
  '                      If Membership.ValidateUser(strUser, pw) Then
  '                          Dim isPersistent As Boolean = True
  '                          Dim userData As String = "ApplicationSpecific data for this user."
  '                          Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1,
  '                            strUser,
  '                            DateTime.Now,
  '                            DateTime.Now.AddMinutes(30),
  '                            isPersistent,
  '                            userData,
  '                          FormsAuthentication.FormsCookiePath)
  '                          ' Encrypt the ticket.
  '                          Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
  '                          ' Create the cookie.
  '                          Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))
  '                          Dim x As HttpCookie = Response.Cookies.Get(0)
  '                          x.Values.Add("SameSite", "None")
  '                          x.Secure = True
  '                          SIS.SYS.Utilities.SessionManager.InitializeEnvironment(Page.User.Identity.Name)
  '                          'Redirect back to original URL.
  '                          HttpContext.Current.Session("Redirected") = True
  '                          'HttpContext.Current.Session("ApplicationDefaultPage") = "http://192.9.200.169/Webpay/Empuser/default.htm"
  '                          'Response.Redirect(FormsAuthentication.GetRedirectUrl(strUser, isPersistent))
  '                          If Not cnt Then
  '                              Response.Redirect("http://192.9.200.169/Webpay/Empuser/atnweb.aspx?cnt=1&uVal=" & uVal)
  '                          End If
  '                          If uVal = "2" Then
  '                              Response.Redirect("~/TA_Main/App_Forms/GF_taTPUserInvoicing.aspx")
  '                          End If
  '                      End If
  '                  Catch ex As Exception
  '                  End Try
  '              End If
  '          End If
  '      End If
  '  End Sub
  Public Property abcd As String = ""
  Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
    Dim strPara As String = ""
    Dim cnt As Boolean = False
    Dim uVal As String = "1"
    Dim strUser As String = ""
    If Request.QueryString("wpid") IsNot Nothing Then
      strPara = Request.QueryString("wpid")
    End If
    If Request.QueryString("cnt") IsNot Nothing Then
      cnt = True
    End If
    If Request.QueryString("uVal") IsNot Nothing Then
      uVal = Request.QueryString("uVal")
    End If
    If strPara <> String.Empty Then
      Using Con As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As System.Data.SqlClient.SqlCommand = Con.CreateCommand()
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = "select isnull(LoginID,'') as xx from aspnet_users where wp_user = '" & strPara & "'"
          Con.Open()
          strUser = Cmd.ExecuteScalar()
        End Using
        If strUser <> String.Empty Then
          Using Cmd As System.Data.SqlClient.SqlCommand = Con.CreateCommand()
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = "update aspnet_users set wp_user = '' where LoginID = '" & strUser & "'"
            Cmd.ExecuteNonQuery()
          End Using
        End If
      End Using
      If strUser <> "" Then
        If SIS.SYS.Utilities.SessionManager.DoLogin(strUser) Then
        End If
      End If
    End If

    If Page.User.Identity.IsAuthenticated Then
      cmdRooster.Visible = True
      abcd = "<fieldset class='ui-widget-content wp_page'>"
      abcd &= "<legend>"
      abcd &= "    <span>&nbsp;TODAY's Punch Time</span>"
      abcd &= "</legend>"
      abcd &= "<div class='wp_pagedata'>"
      Try
        abcd &= "<b>First Punch : </b>" & SIS.ATN.atnRawPunch.GetRawPunchByCardNoDate(Page.User.Identity.Name, Now.ToString("dd/MM/yyyy")).Punch1Time
      Catch ex As Exception
      End Try
      abcd &= "</div>"
      abcd &= "</fieldset>"

      Dim str As String = ""
      str &= "|~/ATN_Main/App_View/GD_atnAttendanceStatus.aspx|Attendance Status"
      str &= "|~/ATN_Main/App_Forms/GT_atnNewRegularizeAttendance.aspx|Regularize Attendance"
      str &= "|~/ATN_Main/App_Forms/GT_atnNewAdvanceApplication.aspx|Advance Application"
      'str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeFPAttendance.aspx|Regularize FP"
      str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeODAttendance.aspx|Regularize OD"
      str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeTSAttendance.aspx|Regularize TS"
      str &= "|~/ATN_Main/App_View/GD_atnTimeShort.aspx|Time Short"
      str &= "|~/ATN_Main/App_View/GD_atnAppliedApplications.aspx|My Application"
      str &= "|~/ATN_Main/App_Forms/GF_atnApproverChangeRequest.aspx|Change Approver"
      str &= "|~/ATN_Main/App_Reports/GP_atnPrintLeavecard.aspx|Leave Card"
      str &= "|~/ATN_Main/App_View/GD_atnRules.aspx|Leave Rules"
      str &= "|~/TA_Main/App_Forms/GF_taTPUserInvoicing.aspx|Travel Invoice"
      str &= "|~/WFHRoster.aspx|Update WFH"

      str = str.Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
      Dim astr() As String = str.Split("|".ToCharArray)

      abcd &= "<ul class='dashboardIcons'>"
      For i As Integer = 1 To astr.Length - 1 Step 2
        abcd &= "<fieldset id='fs" & i & "' class='ui-widget-content wp_page'>"
        'abcd &= "<legend>"
        'abcd &= "    <span>&nbsp;" & astr(i + 1) & "</span>"
        'abcd &= "</legend>"
        abcd &= "<div class='wp_pagedata'>"
        abcd &= "  <li title='" & astr(i + 1) & "'>"
        abcd &= "    <div class='frame'>"
        abcd &= "      <a href='" & astr(i) & "'>"
        abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
        abcd &= "        <span>" & astr(i + 1) & "</span>"
        abcd &= "      </a>"
        abcd &= "     </div>"
        abcd &= "  </li>"
        abcd &= "</div>"
        abcd &= "</fieldset>"
      Next
      abcd &= "</ul>"
    End If
  End Sub
  Protected Sub cmdRooster_Click(sender As Object, e As EventArgs)
    Response.Redirect("~/WFHRoster.aspx")
  End Sub
End Class
