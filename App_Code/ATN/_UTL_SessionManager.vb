Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Net.Mail
Imports System.Net.Mail.SmtpClient
Imports System.Text
Imports System.Security.Cryptography
Namespace SIS.SYS.Utilities
  Public Class SessionManager
    Public Shared Function DoLogin(ByVal UserID As String) As Boolean
      Dim mRet As Boolean = False
      If Membership.ValidateUser(UserID, GetPassword(UserID)) Then
        FormsAuthentication.RedirectFromLoginPage(UserID, True)
        SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
        mRet = True
      End If
      Return mRet
    End Function

    Public Shared Sub CreateSessionEnvironement()
      With HttpContext.Current
        .Session("ApplicationID") = 0
        .Session("ApplicationDefaultPage") = ""
        .Session("LoginID") = Nothing
        .Session("PageSizeProvider") = False
        .Session("PageNoProvider") = False
      End With
    End Sub
    Public Shared Sub UpdateMD5Password(ByVal Uid As String, ByVal Upw As String)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "UPDATE aspnet_users SET md5Password = '" & getMD5(Upw) & "', pw = '" & Upw & "' WHERE UserName = '" & Uid & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
    Public Shared Function GetPassword(ByVal Uid As String) As String
      Dim mRet As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "Select ISNULL(pw,'') from aspnet_users WHERE UserName = '" & Uid & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          mRet = Cmd.ExecuteScalar()
          If mRet Is Nothing Then
            mRet = ""
          End If
        End Using
      End Using
      Return mRet
    End Function
    Private Shared Function GenerateHash(ByVal SourceText As String) As String
      'Create an encoding object to ensure the encoding standard for the source text
      Dim Ue As New UnicodeEncoding()
      'Retrieve a byte array based on the source text
      Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
      'Instantiate an MD5 Provider object
      Dim Md5 As New MD5CryptoServiceProvider()
      'Compute the hash value from the source
      Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
      'And convert it to String format for return
      Return Convert.ToBase64String(ByteHash)
    End Function
    Private Shared Function getMD5(ByVal value As String) As String
      Dim MD5 As MD5 = MD5.Create()
      Dim md5Bytes As Byte() = System.Text.Encoding.Default.GetBytes(value)
      Dim cryString As Byte() = MD5.ComputeHash(md5Bytes)
      Dim md5Str As String = String.Empty
      'To Return String of 32 Bytes
      'For i As Integer = 0 To cryString.Length - 1   'a608b9c44912c72db6855ad555397470
      'md5Str &= cryString(i).ToString("X")
      'Next
      'To return string of 24 Bytes
      md5Str = Convert.ToBase64String(cryString)
      Return md5Str
    End Function
    Public Shared Sub InitializeEnvironment()
      HttpContext.Current.Session("LoginID") = System.Web.HttpContext.Current.User.Identity.Name
      Dim allowedList As String = ConfigurationManager.AppSettings("allowedList")
      If allowedList <> "*" Then
        Dim aList() As String = allowedList.Split(",".ToCharArray)
        For Each lst As String In aList
          If lst = HttpContext.Current.Session("LoginID") Then
            CommonInitialize()
            Return
          End If
        Next
        System.Web.Security.FormsAuthentication.SignOut()
      Else
        CommonInitialize()
      End If
    End Sub
    Public Shared Sub InitializeEnvironment(ByVal UserID As String)
      HttpContext.Current.Session("LoginID") = UserID
      Dim allowedList As String = ConfigurationManager.AppSettings("allowedList")
      If allowedList <> "*" Then
        Dim aList() As String = allowedList.Split(",".ToCharArray)
        For Each lst As String In aList
          If lst = HttpContext.Current.Session("LoginID") Then
            CommonInitialize()
            Return
          End If
        Next
        System.Web.Security.FormsAuthentication.SignOut()
      Else
        CommonInitialize()
      End If
    End Sub
    Private Shared Sub CommonInitialize()
      With HttpContext.Current
        Dim PageNoProvider As String = ConfigurationManager.AppSettings("PageNoProvider")
        If Not PageNoProvider Is Nothing Then
          .Session("PageNoProvider") = Convert.ToBoolean(PageNoProvider)
        Else
          .Session("PageNoProvider") = True
        End If
        Dim PageSizeProvider As String = ConfigurationManager.AppSettings("PageSizeProvider")
        If Not PageSizeProvider Is Nothing Then
          .Session("PageSizeProvider") = Convert.ToBoolean(PageSizeProvider)
        Else
          .Session("PageSizeProvider") = True
        End If
      End With
      '===========
      InitNavBar()
      '===========
      '========================
      'Application Spacific Initializations
      '========================
      SIS.SYS.Utilities.ApplicationSpacific.Initialize()
    End Sub
    Public Shared Sub DestroySessionEnvironement()
      With HttpContext.Current
        Try
          .Session.Clear()
          .Session.Abandon()
        Catch ex As Exception

        End Try
      End With
    End Sub
    Public Class lgNavBar
      Public Property Target As String = ""
      Public Property Source As String = ""
      Public Sub New(ByVal targetUrl As String, ByVal sourceUrl As String)
        Target = targetUrl
        Source = sourceUrl
      End Sub
      Sub New()
        'dummy  
      End Sub
    End Class
    Public Shared Sub InitNavBar()
      HttpContext.Current.Session("NavBar") = New List(Of lgNavBar)
    End Sub
    Public Shared Sub PushNavBar(ByVal Target As String, ByVal Source As String)
      Dim tmpNav As List(Of lgNavBar) = HttpContext.Current.Session("NavBar")
      Dim SourceFoundInTarget As Boolean = False
      Dim SourceFound As Boolean = False
      Dim tmp As lgNavBar = Nothing
      If tmpNav.Count > 0 Then
        tmp = tmpNav(tmpNav.Count - 1)
        If tmp.Target <> Target Then
          If tmp.Source = Target Then
            tmpNav.Remove(tmp)
          Else
            tmpNav.Add(New lgNavBar(Target, Source))
            HttpContext.Current.Session("NavBar") = tmpNav
          End If
        End If
      Else
        tmpNav.Add(New lgNavBar(Target, Source))
        HttpContext.Current.Session("NavBar") = tmpNav
      End If
    End Sub
    Public Shared Function PopNavBar() As String
      Dim mRet As String = HttpContext.Current.Session("ApplicationDefaultPage")
      Dim tmp As lgNavBar = Nothing
      Dim tmpNav As List(Of lgNavBar) = HttpContext.Current.Session("NavBar")
      If tmpNav.Count > 0 Then
        Do While tmpNav.Count > 0
          tmp = tmpNav(tmpNav.Count - 1)
          If tmp.Source.IndexOf("AF_") > -1 Then
            tmpNav.Remove(tmp)
            tmp = Nothing
          Else
            Exit Do
          End If
        Loop
        If tmp IsNot Nothing Then
          mRet = tmp.Source
        End If
      End If
      HttpContext.Current.Session("NavBar") = tmpNav
      Return mRet
    End Function

    'Public Class lgNavBar
    '  Public Property Page As String = ""
    '  Public Property URL As String = ""
    '  Public Sub New(ByVal pg As String, ByVal ur As String)
    '    Page = pg
    '    URL = ur
    '  End Sub
    '  Sub New()
    '    'dummy  
    '  End Sub
    'End Class
    'Public Shared Sub InitNavBar()
    '  Dim abc As New List(Of lgNavBar)
    '  HttpContext.Current.Session("NavBar") = abc
    '  'With HttpContext.Current
    '  '  Dim abc(,) As String
    '  '  ReDim abc(1, 0)
    '  '  abc(0, 0) = ""
    '  '  abc(1, 0) = ""
    '  '  .Session("NavBar") = abc
    '  'End With
    'End Sub
    'Public Shared Sub PushNavBar(ByVal Page As String, ByVal url As String)
    '  If url.IndexOf("skip=1") > -1 Then Return
    '  If url.IndexOf("AF_") > -1 Then Return
    '  Dim abc As List(Of lgNavBar) = HttpContext.Current.Session("NavBar")
    '  Dim Found As Boolean = False
    '  For Each tmp As lgNavBar In abc
    '    If tmp.URL = url Then
    '      Found = True
    '      Exit For
    '    End If
    '  Next
    '  If Not Found Then
    '    abc.Add(New lgNavBar(Page, url))
    '  End If
    '  HttpContext.Current.Session("NavBar") = abc
    '  '  With HttpContext.Current
    '  '    Dim abc(,) As String = .Session("NavBar")
    '  '    Dim curSize As Integer = abc.GetLength(1)
    '  '    Dim Found As Boolean = False
    '  '    For I As Integer = 0 To curSize - 1
    '  '      If abc(0, I) = Page Then
    '  '        Found = True
    '  '        ReDim Preserve abc(1, I)
    '  '        Exit For
    '  '      End If
    '  '    Next
    '  '    If Not Found Then
    '  '      Dim newSize As Integer = abc.GetLength(1)
    '  '      ReDim Preserve abc(1, newSize)
    '  '      abc(0, newSize) = Page
    '  '      abc(1, newSize) = url
    '  '    End If
    '  '    .Session("NavBar") = abc
    '  '  End With
    'End Sub
    'Public Shared Function PopNavBar() As String
    '  Dim mRet As String = HttpContext.Current.Session("ApplicationDefaultPage")
    '  Dim abc As List(Of lgNavBar) = HttpContext.Current.Session("NavBar")
    '  If abc.Count > 0 Then
    '    mRet = abc(abc.Count - 1).URL
    '    abc.RemoveAt(abc.Count - 1)
    '  End If
    '  HttpContext.Current.Session("NavBar") = abc

    '  'With HttpContext.Current
    '  '  Dim abc(,) As String = .Session("NavBar")
    '  '  Dim curSize As Integer = abc.GetLength(1)
    '  '  If curSize > 1 Then
    '  '    mRet = abc(1, curSize - 1)
    '  '  End If
    '  '  .Session("NavBar") = abc
    '  'End With
    '  Return mRet
    'End Function
  End Class
  'Public Class clsBaan
  '	Const PARSEDLL As String = "otppdmdlldcm"
  '	Private oBaaN As Baan4.Baan4
  '	Public Function Execute(ByVal FunctionName As String, ByVal Arguments As String) As ReturnedValues
  '		SyncLock Me
  '			Dim oRet As New ReturnedValues
  '			Dim mSource As String = GetSource(FunctionName, Arguments)
  '			Dim mRet As Integer
  '			oRet.FunctionName = FunctionName
  '			oRet.Arguments = Arguments
  '			Try
  '				mRet = oBaaN.ParseExecFunction(PARSEDLL, mSource)
  '				If oBaaN.Error <> 0 Then
  '					Disconnect()
  '					oRet.RetVal = 1
  '					Select Case oBaaN.Error
  '						Case Is = -1
  '							oRet.RetStr = "DLL Unknown"
  '						Case Is = -2
  '							oRet.RetStr = "Function Unknown"
  '						Case Is = -3
  '							oRet.RetStr = "Syntax Error in Function Call"
  '					End Select
  '					oRet.RetStr = "BaaN Disconnected. Error : " & oRet.RetStr
  '				End If
  '			Catch ex As Exception
  '				Disconnect()
  '				oRet.RetVal = 2
  '				oRet.RetStr = "Fatal error. : BaaN Disconnected."
  '			End Try
  '			If Not oBaaN Is Nothing Then
  '				Dim aStr() As String = oBaaN.ReturnValue.Split("||".ToCharArray, 2)
  '				If aStr(0) > "0" Then
  '					oRet.RetVal = 1
  '					If aStr.Length > 1 Then
  '						oRet.RetStr = aStr(1)
  '					End If
  '				Else
  '					oRet.RetVal = 0
  '					oRet.DllRetStr = aStr(1)
  '				End If
  '			End If
  '			Return oRet
  '		End SyncLock
  '	End Function
  '	Public Function Connect() As ReturnedValues
  '		Dim oBW() As Process
  '		Dim t As Process
  '		Dim oRet As New ReturnedValues
  '		Dim _may As Boolean
  '		oBW = Process.GetProcessesByName("bw")
  '		For Each t In oBW
  '			If t.ProcessName = "bw" Then
  '				oRet.RetVal = 1
  '				oRet.RetStr = "BaaN is allready running !!! [Please Close BaaN]"
  '				_may = True
  '			End If
  '		Next
  '		If Not _may Then
  '			Try
  '				oBaaN = HttpContext.Current.Server.CreateObject("BaaN4.Application.lalit200")
  '				oRet.RetVal = 0
  '				oRet.RetStr = "Connected"
  '			Catch ex As Exception
  '				oRet.RetVal = 2
  '				oRet.RetStr = "Can Not Connect to BaaN." & " : " & ex.Message
  '				oBW = Process.GetProcessesByName("bw")
  '				For Each t In oBW
  '					If t.ProcessName = "bw" Then
  '						t.Kill()
  '					End If
  '				Next
  '			End Try
  '		End If
  '		oBW = Nothing
  '		Return oRet
  '	End Function
  '	Private Function GetSource(ByVal FunctionName As String, ByVal Arguments As String) As String
  '		Dim aArgs() As String
  '		Dim mSource As String
  '		Dim I As Integer
  '		mSource = ""
  '		If Arguments = "" Then
  '			mSource = FunctionName & "()"
  '		Else
  '			aArgs = Arguments.Split(",".ToCharArray)
  '			For I = 0 To aArgs.Length - 1
  '				If mSource = "" Then
  '					mSource = Chr(34) & aArgs(I) & Chr(34)
  '				Else
  '					mSource = mSource & "," & Chr(34) & aArgs(I) & Chr(34)
  '				End If
  '			Next
  '			mSource = FunctionName & "(" & mSource & ")"
  '		End If
  '		Return mSource
  '	End Function
  '	Public Sub Disconnect()
  '		Try
  '			oBaaN.Quit()
  '			oBaaN = Nothing
  '		Catch ex As Exception
  '			Try
  '				Dim oBW() As Process
  '				Dim t As Process
  '				oBW = Process.GetProcessesByName("bw")
  '				For Each t In oBW
  '					If t.ProcessName = "bw" Then
  '						t.Kill()
  '						Exit For
  '					End If
  '				Next
  '				oBaaN = Nothing
  '			Catch ex1 As Exception
  '			End Try
  '		End Try
  '	End Sub
  '	Public Sub Dispose()
  '		Try
  '			oBaaN.Quit()
  '			oBaaN = Nothing
  '		Catch ex As Exception
  '			Try
  '				Dim oBW() As Process
  '				Dim t As Process
  '				oBW = Process.GetProcessesByName("bw")
  '				For Each t In oBW
  '					If t.ProcessName = "bw" Then
  '						t.Kill()
  '						Exit For
  '					End If
  '				Next
  '				oBaaN = Nothing
  '			Catch ex1 As Exception
  '			End Try
  '		End Try
  '	End Sub
  'End Class
  Public Class ReturnedValues
    Private _RetVal As Integer
    Private _DllRetVal As Integer
    Private _RetStr As String
    Private _DllRetStr As String
    Private _FunctionName As String
    Private _Arguments As String
    Public Property RetVal() As Integer
      Get
        Return Me._RetVal
      End Get
      Set(ByVal Value As Integer)
        Me._RetVal = Value
      End Set
    End Property
    Public Property DllRetVal() As Integer
      Get
        Return Me._DllRetVal
      End Get
      Set(ByVal Value As Integer)
        Me._DllRetVal = Value
      End Set
    End Property
    Public Property RetStr() As String
      Get
        Return Me._RetStr
      End Get
      Set(ByVal Value As String)
        Me._RetStr = Value
      End Set
    End Property
    Public Property DllRetStr() As String
      Get
        Return Me._DllRetStr
      End Get
      Set(ByVal Value As String)
        Me._DllRetStr = Value
      End Set
    End Property
    Public Property FunctionName() As String
      Get
        Return Me._FunctionName
      End Get
      Set(ByVal Value As String)
        Me._FunctionName = Value
      End Set
    End Property
    Public Property Arguments() As String
      Get
        Return Me._Arguments
      End Get
      Set(ByVal Value As String)
        Me._Arguments = Value
      End Set
    End Property
  End Class
  Public Class GlobalVariables
    Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageNo] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = '" & HttpContext.Current.Session("ApplicationID") & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
          If _Result = 0 Then
            _Result = 0
          End If
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String, ByVal Position As Integer) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_SetPageNumber"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageNo", SqlDbType.Int, 10, Position)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageSize] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = " & HttpContext.Current.Session("ApplicationID")
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
          If _Result = 0 Then
            _Result = 10
          End If
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String, ByVal Size As Integer) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_SetPageSize"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageSize", SqlDbType.Int, 10, Size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function GetEMailID(ByVal LoginID As String) As String
      Dim _Result As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT ISNULL(EMailID,'') FROM [aspnet_Users] WHERE UserName = '" & LoginID & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
        End Using
      End Using
      Return _Result
    End Function
  End Class
  Public Class lgMail
    Private _To As String
    Private _Subject As String
    Private _Values As New Dictionary(Of String, String)
    Private _Links As New Dictionary(Of String, String)
    Private _Body As String
    Public Property Body() As String
      Get
        Return _Body
      End Get
      Set(ByVal value As String)
        _Body = value
      End Set
    End Property
    Public Sub Links(ByVal Key As String, ByVal Value As String)
      _Links.Add(Key, Value)
    End Sub
    Public Sub Values(ByVal Key As String, ByVal Value As String)
      _Values.Add(Key, Value)
    End Sub
    Public Property Subject() As String
      Get
        Return _Subject
      End Get
      Set(ByVal value As String)
        _Subject = value
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _To
      End Get
      Set(ByVal value As String)
        _To = value
      End Set
    End Property
    Public Sub Send()
      Dim oSMTP As New System.Net.Mail.SmtpClient
      Dim oMail As New System.Net.Mail.MailMessage
      With oMail
        .To.Add(New MailAddress(_To))
        .Subject = _Subject
        .Body = String.Empty
        .Body = "<table>"
        For Each Itm As KeyValuePair(Of String, String) In _Values
          .Body &= "<tr>"
          .Body &= "<td><B>" & Itm.Key & "<B></td><td>" & Itm.Value & "</td>"
          .Body &= "</tr>"
        Next
        For Each Itm As KeyValuePair(Of String, String) In _Links
          .Body &= "<tr>"
          .Body &= "<td colspan=""2""><a href=""http://" & Itm.Value & """>" & Itm.Key & "</a></td>"
          .Body &= "</tr>"
        Next
        .Body &= "<tr>"
        .Body &= "<td colspan=""2"">" & _Body & "</td>"
        .Body &= "</tr>"
        .Body &= "</table>"
        .IsBodyHtml = True
      End With
      oSMTP.Send(oMail)
    End Sub
  End Class
  Public Class ValidateURL
    Public Shared Function Validate(ByVal PageUrl As String) As Boolean
      Dim aParts() As String = PageUrl.Split("/".ToCharArray)
      If aParts.Length <= 3 Then
        Return True
      End If
      Return ValidateURL(PageUrl)
    End Function
    Private Shared Function ValidateURL(ByVal PageUrl As String) As Boolean
      Dim _Result As Boolean = False
      Dim afile() As String = PageUrl.Split("/".ToCharArray)
      Dim FileName As String = afile(afile.GetUpperBound(0)).ToString
      Dim UserCase As String = FileName.Substring(0, 3)
      Select Case UserCase
        Case "AF_"
          FileName = FileName.Replace("AF_", "GF_")
        Case "EF_"
          FileName = FileName.Replace("EF_", "GF_")
        Case "DF_"
          FileName = FileName.Replace("DF_", "GD_")
      End Select
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_VRSessionByUserFile"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName", SqlDbType.NVarChar, 251, FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName", SqlDbType.NVarChar, 20, HttpContext.Current.User.Identity.Name)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.NVarChar, 50, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Select Case UserCase
              Case "AF_"
                If Reader("InsertForm") Then
                  _Result = True
                End If
              Case "EF_"
                If Reader("UpdateForm") Then
                  _Result = True
                End If
              Case "DF_"
                If Reader("DisplayForm") Then
                  _Result = True
                End If
              Case "GD_"
                If Reader("DisplayGrid") Then
                  _Result = True
                End If
              Case Else    '"GF_", "GT_", "GU_", "GP_"
                If Reader("MaintainGrid") Then
                  _Result = True
                End If
            End Select
          End If
          Reader.Close()
        End Using
      End Using
      Return _Result
    End Function
  End Class
  'Public Class dbfHandler
  '  Implements IHttpHandler
  '  Private Const MULTIPART_BOUNDARY As String = "<q1w2e3r4t5y6u7i8o9p0>"
  '  Private Const MULTIPART_CONTENTTYPE As String = "multipart/byteranges; boundary=" & MULTIPART_BOUNDARY
  '  Private Const HTTP_HEADER_ACCEPT_RANGES As String = "Accept-Ranges"
  '  Private Const HTTP_HEADER_ACCEPT_RANGES_BYTES As String = "bytes"
  '  Private Const HTTP_HEADER_CONTENT_TYPE As String = "Content-Type"
  '  Private Const HTTP_HEADER_CONTENT_RANGE As String = "Content-Range"
  '  Private Const HTTP_HEADER_CONTENT_LENGTH As String = "Content-Length"
  '  Private Const HTTP_HEADER_ENTITY_TAG As String = "ETag"
  '  Private Const HTTP_HEADER_LAST_MODIFIED As String = "Last-Modified"
  '  Private Const HTTP_HEADER_RANGE As String = "Range"
  '  Private Const HTTP_HEADER_IF_RANGE As String = "If-Range"
  '  Private Const HTTP_HEADER_IF_MATCH As String = "If-Match"
  '  Private Const HTTP_HEADER_IF_NONE_MATCH As String = "If-None-Match"
  '  Private Const HTTP_HEADER_IF_MODIFIED_SINCE As String = "If-Modified-Since"
  '  Private Const HTTP_HEADER_IF_UNMODIFIED_SINCE As String = "If-Unmodified-Since"
  '  Private Const HTTP_HEADER_UNLESS_MODIFIED_SINCE As String = "Unless-Modified-Since"
  '  Private Const HTTP_METHOD_GET As String = "GET"
  '  Private Const HTTP_METHOD_HEAD As String = "HEAD"
  '  Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
  '    Get
  '      Return True
  '    End Get
  '  End Property
  '  Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
  '    Dim objResponse As HttpResponse = context.Response
  '    Dim objRequest As HttpRequest = context.Request
  '    Dim objFile As DownloadFileInformation
  '    Dim alRequestedRangesBegin() As Long
  '    Dim alRequestedRangesend() As Long
  '    Dim iResponseContentLength As Int32
  '    Dim objStream As System.IO.FileStream
  '    Dim iBytesToRead As Int32
  '    Dim iBufferSize As Int32 = 25000
  '    Dim bBuffer(iBufferSize) As Byte
  '    Dim iLengthOfReadChunk As Int32
  '    Dim bDownloadBroken As Boolean
  '    Dim bIsRangeRequest As Boolean
  '    Dim bMultipart As Boolean
  '    Dim iLoop As Int32
  '    objFile = New DownloadFileInformation(context.Server.MapPath("~/App_Downloads/mondata.dbf"))
  '    objResponse.Clear()
  '    If Not objRequest.HttpMethod.Equals(HTTP_METHOD_GET) And Not objRequest.HttpMethod.Equals(HTTP_METHOD_HEAD) Then
  '      objResponse.StatusCode = 501  ' Not implemented
  '    ElseIf Not objFile.Exists Then
  '      objResponse.StatusCode = 404  ' Not found
  '    ElseIf objFile.Length > Int32.MaxValue Then
  '      objResponse.StatusCode = 413  ' Request Entity Too Large
  '    ElseIf Not ParseRequestHeaderRange(objRequest, alRequestedRangesBegin, alRequestedRangesend, objFile.Length, bIsRangeRequest) Then
  '      objResponse.StatusCode = 400  ' Bad Request
  '    ElseIf Not CheckIfModifiedSince(objRequest, objFile) Then
  '      objResponse.StatusCode = 304  ' Not Modified
  '    ElseIf Not CheckIfUnmodifiedSince(objRequest, objFile) Then
  '      objResponse.StatusCode = 412  ' Precondition failed
  '    ElseIf Not CheckIfMatch(objRequest, objFile) Then
  '      objResponse.StatusCode = 412  ' Precondition failed
  '    ElseIf Not CheckIfNoneMatch(objRequest, objResponse, objFile) Then
  '    Else
  '      If bIsRangeRequest AndAlso CheckIfRange(objRequest, objFile) Then
  '        bMultipart = CBool(alRequestedRangesBegin.GetUpperBound(0) > 0)
  '        For iLoop = alRequestedRangesBegin.GetLowerBound(0) To alRequestedRangesBegin.GetUpperBound(0)
  '          iResponseContentLength += Convert.ToInt32(alRequestedRangesend(iLoop) - alRequestedRangesBegin(iLoop)) + 1
  '          If bMultipart Then
  '            iResponseContentLength += MULTIPART_BOUNDARY.Length
  '            iResponseContentLength += objFile.ContentType.Length
  '            iResponseContentLength += alRequestedRangesBegin(iLoop).ToString.Length
  '            iResponseContentLength += alRequestedRangesend(iLoop).ToString.Length
  '            iResponseContentLength += objFile.Length.ToString.Length
  '            iResponseContentLength += 49
  '          End If
  '        Next iLoop
  '        If bMultipart Then
  '          iResponseContentLength += MULTIPART_BOUNDARY.Length
  '          iResponseContentLength += 8
  '        Else
  '          objResponse.AppendHeader(HTTP_HEADER_CONTENT_RANGE, "bytes " & alRequestedRangesBegin(0).ToString & "-" & alRequestedRangesend(0).ToString & "/" & objFile.Length.ToString)
  '        End If
  '        objResponse.StatusCode = 206 ' Partial Response
  '      Else
  '        iResponseContentLength = Convert.ToInt32(objFile.Length)
  '        objResponse.StatusCode = 200
  '      End If
  '      objResponse.AppendHeader(HTTP_HEADER_CONTENT_LENGTH, iResponseContentLength.ToString)
  '      objResponse.AppendHeader(HTTP_HEADER_LAST_MODIFIED, objFile.LastWriteTimeUTC.ToString("r"))
  '      objResponse.AppendHeader(HTTP_HEADER_ACCEPT_RANGES, HTTP_HEADER_ACCEPT_RANGES_BYTES)
  '      objResponse.AppendHeader(HTTP_HEADER_ENTITY_TAG, """" & objFile.EntityTag & """")
  '      If bMultipart Then
  '        objResponse.ContentType = MULTIPART_CONTENTTYPE
  '      Else
  '        objResponse.ContentType = objFile.ContentType
  '      End If
  '      If objRequest.HttpMethod.Equals(HTTP_METHOD_HEAD) Then
  '      Else
  '        objResponse.Flush()
  '        objFile.State = DownloadFileInformation.DownloadState.fsDownloadInProgress
  '        objStream = New System.IO.FileStream(objFile.FullName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
  '        For iLoop = alRequestedRangesBegin.GetLowerBound(0) To alRequestedRangesBegin.GetUpperBound(0)
  '          objStream.Seek(alRequestedRangesBegin(iLoop), IO.SeekOrigin.Begin)
  '          iBytesToRead = Convert.ToInt32(alRequestedRangesend(iLoop) - alRequestedRangesBegin(iLoop)) + 1
  '          If bMultipart Then
  '            objResponse.Output.WriteLine("--" & MULTIPART_BOUNDARY)
  '            objResponse.Output.WriteLine(HTTP_HEADER_CONTENT_TYPE & ": " & objFile.ContentType)
  '            objResponse.Output.WriteLine(HTTP_HEADER_CONTENT_RANGE & ": bytes " & alRequestedRangesBegin(iLoop).ToString & "-" & alRequestedRangesend(iLoop).ToString & "/" & objFile.Length.ToString)
  '            objResponse.Output.WriteLine()
  '          End If
  '          While iBytesToRead > 0
  '            If objResponse.IsClientConnected Then
  '              iLengthOfReadChunk = objStream.Read(bBuffer, 0, Math.Min(bBuffer.Length, iBytesToRead))
  '              objResponse.OutputStream.Write(bBuffer, 0, iLengthOfReadChunk)
  '              objResponse.Flush()
  '              ReDim bBuffer(iBufferSize)
  '              iBytesToRead -= iLengthOfReadChunk
  '            Else
  '              iBytesToRead = -1
  '              bDownloadBroken = True
  '            End If
  '          End While
  '          If bMultipart Then objResponse.Output.WriteLine()
  '          If bDownloadBroken Then Exit For
  '        Next iLoop
  '        If bDownloadBroken Then
  '          objFile.State = DownloadFileInformation.DownloadState.fsDownloadBroken
  '        Else
  '          If bMultipart Then
  '            objResponse.Output.WriteLine("--" & MULTIPART_BOUNDARY & "--")
  '            objResponse.Output.WriteLine()
  '          End If
  '          objFile.State = DownloadFileInformation.DownloadState.fsDownloadFinished
  '        End If
  '        objStream.Close()
  '      End If
  '    End If
  '    objResponse.End()
  '  End Sub
  '  Private Function CheckIfRange(ByVal objRequest As HttpRequest, ByVal objFile As DownloadFileInformation) As Boolean
  '    Dim sRequestHeaderIfRange As String
  '    sRequestHeaderIfRange = RetrieveHeader(objRequest, HTTP_HEADER_IF_RANGE, objFile.EntityTag)
  '    Return sRequestHeaderIfRange.Equals(objFile.EntityTag)
  '  End Function
  '  Private Function CheckIfMatch(ByVal objRequest As HttpRequest, ByVal objFile As DownloadFileInformation) As Boolean
  '    Dim sRequestHeaderIfMatch As String
  '    Dim sEntityIDs() As String
  '    Dim bReturn As Boolean
  '    sRequestHeaderIfMatch = RetrieveHeader(objRequest, HTTP_HEADER_IF_MATCH, "*")
  '    If sRequestHeaderIfMatch.Equals("*") Then
  '      bReturn = True
  '    Else
  '      sEntityIDs = sRequestHeaderIfMatch.Replace("bytes=", "").Split(",".ToCharArray)
  '      For iLoop As Int32 = sEntityIDs.GetLowerBound(0) To sEntityIDs.GetUpperBound(0)
  '        If sEntityIDs(iLoop).Trim.Equals(objFile.EntityTag) Then
  '          bReturn = True
  '        End If
  '      Next iLoop
  '    End If
  '    Return bReturn
  '  End Function
  '  Private Function CheckIfNoneMatch(ByVal objRequest As HttpRequest, ByVal objResponse As HttpResponse, ByVal objFile As DownloadFileInformation) As Boolean
  '    Dim sRequestHeaderIfNoneMatch As String
  '    Dim sEntityIDs() As String
  '    Dim bReturn As Boolean = True
  '    Dim sReturn As String = String.Empty
  '    sRequestHeaderIfNoneMatch = RetrieveHeader(objRequest, HTTP_HEADER_IF_NONE_MATCH, String.Empty)
  '    If sRequestHeaderIfNoneMatch.Equals(String.Empty) Then
  '      bReturn = True
  '    ElseIf sRequestHeaderIfNoneMatch.Equals("*") Then
  '      objResponse.StatusCode = 412  ' Precondition failed
  '      bReturn = False
  '    Else
  '      sEntityIDs = sRequestHeaderIfNoneMatch.Replace("bytes=", "").Split(",".ToCharArray)
  '      For iLoop As Int32 = sEntityIDs.GetLowerBound(0) To sEntityIDs.GetUpperBound(0)
  '        If sEntityIDs(iLoop).Trim.Equals(objFile.EntityTag) Then
  '          sReturn = sEntityIDs(iLoop)
  '          bReturn = False
  '        End If
  '      Next iLoop
  '      If Not bReturn Then
  '        objResponse.AppendHeader("ETag", sReturn)
  '        objResponse.StatusCode = 304  ' Not Modified
  '      End If
  '    End If
  '    Return bReturn
  '  End Function
  '  Private Function CheckIfModifiedSince(ByVal objRequest As HttpRequest, ByVal objFile As DownloadFileInformation) As Boolean
  '    Dim sDate As String
  '    Dim dDate As Date
  '    Dim bReturn As Boolean
  '    sDate = RetrieveHeader(objRequest, HTTP_HEADER_IF_MODIFIED_SINCE, String.Empty)
  '    If sDate.Equals(String.Empty) Then
  '      bReturn = True
  '    Else
  '      Try
  '        dDate = DateTime.Parse(sDate)
  '        bReturn = objFile.LastWriteTimeUTC >= DateTime.Parse(sDate)
  '      Catch ex As Exception
  '        bReturn = False
  '      End Try
  '    End If
  '    Return bReturn
  '  End Function
  '  Private Function CheckIfUnmodifiedSince(ByVal objRequest As HttpRequest, ByVal objFile As DownloadFileInformation) As Boolean
  '    Dim sDate As String
  '    Dim dDate As Date
  '    Dim bReturn As Boolean
  '    sDate = RetrieveHeader(objRequest, HTTP_HEADER_IF_UNMODIFIED_SINCE, String.Empty)
  '    If sDate.Equals(String.Empty) Then
  '      sDate = RetrieveHeader(objRequest, HTTP_HEADER_UNLESS_MODIFIED_SINCE, String.Empty)
  '    End If
  '    If sDate.Equals(String.Empty) Then
  '      bReturn = True
  '    Else
  '      Try
  '        dDate = DateTime.Parse(sDate)
  '        bReturn = objFile.LastWriteTimeUTC < DateTime.Parse(sDate)
  '      Catch ex As Exception
  '        bReturn = False
  '      End Try
  '    End If
  '    Return bReturn
  '  End Function
  '  Private Function ParseRequestHeaderRange(ByVal objRequest As HttpRequest, ByRef lBegin() As Long, ByRef lEnd() As Long, ByVal lMax As Long, ByRef bRangeRequest As Boolean) As Boolean
  '    Dim bValidRanges As Boolean
  '    Dim sSource As String
  '    Dim iLoop As Int32
  '    Dim sRanges() As String
  '    sSource = RetrieveHeader(objRequest, HTTP_HEADER_RANGE, String.Empty)
  '    If sSource.Equals(String.Empty) Then
  '      ReDim lBegin(0)
  '      ReDim lEnd(0)
  '      lBegin(0) = 0
  '      lEnd(0) = lMax - 1
  '      bValidRanges = True
  '      bRangeRequest = False
  '    Else
  '      bValidRanges = True
  '      bRangeRequest = True
  '      sRanges = sSource.Replace("bytes=", "").Split(",".ToCharArray)
  '      ReDim lBegin(sRanges.GetUpperBound(0))
  '      ReDim lEnd(sRanges.GetUpperBound(0))
  '      For iLoop = sRanges.GetLowerBound(0) To sRanges.GetUpperBound(0)
  '        Dim sRange() As String = sRanges(iLoop).Split("-".ToCharArray)
  '        If sRange(1).Equals(String.Empty) Then
  '          lEnd(iLoop) = lMax - 1
  '        Else
  '          lEnd(iLoop) = Long.Parse(sRange(1))
  '        End If
  '        If sRange(0).Equals(String.Empty) Then
  '          lBegin(iLoop) = lMax - 1 - lEnd(iLoop)
  '          lEnd(iLoop) = lMax - 1
  '        Else
  '          lBegin(iLoop) = Long.Parse(sRange(0))
  '        End If
  '        If (lBegin(iLoop) > (lMax - 1)) Or (lEnd(iLoop) > (lMax - 1)) Then
  '          bValidRanges = False
  '        End If
  '        If (lBegin(iLoop) < 0) Or (lEnd(iLoop) < 0) Then
  '          bValidRanges = False
  '        End If
  '        If lEnd(iLoop) < lBegin(iLoop) Then
  '          bValidRanges = False
  '        End If
  '      Next iLoop
  '    End If
  '    Return bValidRanges
  '  End Function
  '  Private Function RetrieveHeader(ByVal objRequest As HttpRequest, ByVal sHeader As String, ByVal sDefault As String) As String
  '    Dim sReturn As String
  '    sReturn = objRequest.Headers.Item(sHeader)
  '    If (sReturn Is Nothing) OrElse sReturn.Equals(String.Empty) Then
  '      Return sDefault
  '    Else
  '      Return sReturn.Replace("""", "")
  '    End If
  '  End Function
  '  Private Function GenerateHash(ByVal objStream As System.IO.Stream, ByVal lBegin As Long, ByVal lEnd As Long) As String
  '    Dim bByte(Convert.ToInt32(lEnd)) As Byte
  '    objStream.Read(bByte, Convert.ToInt32(lBegin), Convert.ToInt32(lEnd - lBegin) + 1)
  '    Dim Md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
  '    Dim ByteHash() As Byte = Md5.ComputeHash(bByte)
  '    Return Convert.ToBase64String(ByteHash)
  '  End Function
  'End Class
  Public Class DownloadFileInformation
    Public Sub New(ByVal sPath As String)
      m_objFile = New System.IO.FileInfo(sPath)
    End Sub
    <Flags()> Enum DownloadState
      fsClear = 1
      fsLocked = 2
      fsDownloadInProgress = 6
      fsDownloadBroken = 10
      fsDownloadFinished = 18
    End Enum
    Private m_objFile As System.IO.FileInfo
    Private m_nState As DownloadState
    Public ReadOnly Property Exists() As Boolean
      Get
        ' ToDo - your code here (create the file dynamically)
        Return m_objFile.Exists
      End Get
    End Property
    Public ReadOnly Property FullName() As String
      Get
        Return m_objFile.FullName
      End Get
    End Property
    Public ReadOnly Property LastWriteTimeUTC() As Date
      Get
        Return m_objFile.LastWriteTimeUtc
      End Get
    End Property
    Public ReadOnly Property Length() As Long
      Get
        Return m_objFile.Length
      End Get
    End Property
    Public ReadOnly Property ContentType() As String
      Get
        'Return appropriate MIME Type
        Return "application/octet-stream"
      End Get
    End Property
    Public ReadOnly Property EntityTag() As String
      Get
        'Return Unique Entity Tag
        Return "lgMondataETag"
      End Get
    End Property
    Public Property State() As DownloadState
      Get
        Return m_nState
      End Get
      Set(ByVal nState As DownloadState)
        m_nState = nState
        ' If nState = DownloadState.fsDownloadFinished Then
        '   Clear()
        ' Else
        '   Save()
        ' End If
        Save()
      End Set
    End Property
    Public Sub Clear()
      If State = DownloadState.fsDownloadBroken Or State = DownloadState.fsDownloadInProgress Then
      Else
        m_objFile.Delete()
        State = DownloadState.fsClear
      End If
    End Sub
    Private Sub Save()
      ' (Save the state of this file's download to 
      ' a database or XML file...)
    End Sub
  End Class
  '  Public Class ZIPHandler
  '    '===================================================================================
  '    'The class implements IHTTPHandler so it can intercept .zip file requests and stream 
  '    'them back to the clients, providing you with information about the download, and 
  '    'resuming interrupted downloads seamlessly.  
  '    '====================================================================================
  '    Implements IHttpHandler
  '#Region "    Constants used for HTTP communication"
  '    '     The boundary is used in multipart/byteranges responses
  '    '     to separate each ranges content. It should be as unique
  '    '     as possible to avoid confusion with binary content.
  '    Private Const MULTIPART_BOUNDARY As String = "<q1w2e3r4t5y6u7i8o9p0>"
  '    Private Const MULTIPART_CONTENTTYPE As String = "multipart/byteranges; boundary=" & MULTIPART_BOUNDARY
  '    Private Const HTTP_HEADER_ACCEPT_RANGES As String = "Accept-Ranges"
  '    Private Const HTTP_HEADER_ACCEPT_RANGES_BYTES As String = "bytes"
  '    Private Const HTTP_HEADER_CONTENT_TYPE As String = "Content-Type"
  '    Private Const HTTP_HEADER_CONTENT_RANGE As String = "Content-Range"
  '    Private Const HTTP_HEADER_CONTENT_LENGTH As String = "Content-Length"
  '    Private Const HTTP_HEADER_ENTITY_TAG As String = "ETag"
  '    Private Const HTTP_HEADER_LAST_MODIFIED As String = "Last-Modified"
  '    Private Const HTTP_HEADER_RANGE As String = "Range"
  '    Private Const HTTP_HEADER_IF_RANGE As String = "If-Range"
  '    Private Const HTTP_HEADER_IF_MATCH As String = "If-Match"
  '    Private Const HTTP_HEADER_IF_NONE_MATCH As String = "If-None-Match"
  '    Private Const HTTP_HEADER_IF_MODIFIED_SINCE As String = "If-Modified-Since"
  '    Private Const HTTP_HEADER_IF_UNMODIFIED_SINCE As String = "If-Unmodified-Since"
  '    Private Const HTTP_HEADER_UNLESS_MODIFIED_SINCE As String = "Unless-Modified-Since"

  '    Private Const HTTP_METHOD_GET As String = "GET"
  '    Private Const HTTP_METHOD_HEAD As String = "HEAD"

  '#End Region

  '    Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
  '      Get
  '        ' Allow ASP.NET to reuse instances of this class...
  '        Return True
  '      End Get
  '    End Property

  '    Public Sub ProcessRequest(ByVal objContext As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
  '      Dim objResponse As HttpResponse = objContext.Response
  '      Dim objRequest As HttpRequest = objContext.Request

  '      ' File information object...
  '      Dim objFile As DownloadFileInformation

  '      ' Long Arrays for Range values:
  '      ' ...Begin() contains start positions for each 
  '      ' requested Range
  '      Dim alRequestedRangesBegin() As Long
  '      ' ...End() contains end positions for each requested Range
  '      Dim alRequestedRangesend() As Long

  '      ' Response Header value: Content Length...
  '      Dim iResponseContentLength As Int32

  '      ' The Stream we're using to download the file in chunks...
  '      Dim objStream As System.IO.FileStream
  '      ' Total Bytes to read (per requested range)
  '      Dim iBytesToRead As Int32
  '      ' Size of the Buffer for chunk-wise reading
  '      Dim iBufferSize As Int32 = 25000
  '      ' The Buffer itself
  '      Dim bBuffer(iBufferSize) As Byte
  '      ' Amount of Bytes read
  '      Dim iLengthOfReadChunk As Int32

  '      ' Indicates if the download was interrupted
  '      Dim bDownloadBroken As Boolean

  '      ' Indicates if this is a range request 
  '      Dim bIsRangeRequest As Boolean
  '      ' Indicates if this is a multipart range request
  '      Dim bMultipart As Boolean

  '      ' Loop counter used to iterate through the ranges
  '      Dim iLoop As Int32


  '      ' ToDo - your code here (Determine which file is requested)
  '      ' Using objRequest, determine which file is requested to
  '      ' be downloaded, and open objFile with that file:
  '      ' Example:
  '      ' objFile = New Download.FileInformation
  '      ' (<Full path to the requested file>)
  '      objFile = New DownloadFileInformation(objContext.Server.MapPath("~/download.zip"))


  '      ' Clear the current output content from the buffer
  '      objResponse.Clear()

  '      If Not objRequest.HttpMethod.Equals(HTTP_METHOD_GET) Or Not objRequest.HttpMethod.Equals(HTTP_METHOD_HEAD) Then
  '        ' Currently, only the GET and HEAD methods 
  '        ' are supported...
  '        objResponse.StatusCode = 501  ' Not implemented

  '      ElseIf Not objFile.Exists Then
  '        ' The requested file could not be retrieved...
  '        objResponse.StatusCode = 404  ' Not found

  '      ElseIf objFile.Length > Int32.MaxValue Then
  '        ' The file size is too large... 
  '        objResponse.StatusCode = 413  ' Request Entity Too Large

  '      ElseIf Not ParseRequestHeaderRange(objRequest, alRequestedRangesBegin, alRequestedRangesend, objFile.Length, bIsRangeRequest) Then
  '        ' The Range request contained bad entries
  '        objResponse.StatusCode = 400  ' Bad Request

  '      ElseIf Not CheckIfModifiedSince(objRequest, objFile) Then
  '        ' The entity is still unmodified...
  '        objResponse.StatusCode = 304  ' Not Modified

  '      ElseIf Not CheckIfUnmodifiedSince(objRequest, objFile) Then
  '        ' The entity was modified since the requested date... 
  '        objResponse.StatusCode = 412  ' Precondition failed

  '      ElseIf Not CheckIfMatch(objRequest, objFile) Then
  '        ' The entity does not match the request... 
  '        objResponse.StatusCode = 412  ' Precondition failed

  '      ElseIf Not CheckIfNoneMatch(objRequest, objResponse, objFile) Then
  '        ' The entity does match the none-match request, 
  '        ' the response code was set inside the CheckIfNoneMatch 
  '        ' function
  '      Else
  '        ' Preliminary checks where successful... 

  '        If bIsRangeRequest AndAlso CheckIfRange(objRequest, objFile) Then
  '          ' This is a Range request... 
  '          ' If the Range arrays contain more than one entry,
  '          ' it even is a multipart range request...
  '          bMultipart = CBool(alRequestedRangesBegin.GetUpperBound(0) > 0)

  '          ' Loop through each Range to calculate the entire 
  '          ' Response length
  '          For iLoop = alRequestedRangesBegin.GetLowerBound(0) To alRequestedRangesBegin.GetUpperBound(0)
  '            ' The length of the content (for this range)
  '            iResponseContentLength += Convert.ToInt32(alRequestedRangesend(iLoop) - alRequestedRangesBegin(iLoop)) + 1
  '            If bMultipart Then
  '              ' If this is a multipart range request, calculate 
  '              ' the length of the intermediate headers to send
  '              iResponseContentLength += MULTIPART_BOUNDARY.Length
  '              iResponseContentLength += objFile.ContentType.Length
  '              iResponseContentLength += alRequestedRangesBegin(iLoop).ToString.Length
  '              iResponseContentLength += alRequestedRangesend(iLoop).ToString.Length
  '              iResponseContentLength += objFile.Length.ToString.Length
  '              ' 49 is the length of line break and other 
  '              ' needed characters in one multipart header
  '              iResponseContentLength += 49
  '            End If
  '          Next iLoop
  '          If bMultipart Then
  '            ' If this is a multipart range request,  
  '            ' we must also calculate the length of 
  '            ' the last intermediate header we must send
  '            iResponseContentLength += MULTIPART_BOUNDARY.Length
  '            ' 8 is the length of dash and line break characters
  '            iResponseContentLength += 8
  '          Else
  '            ' This is no multipart range request, so
  '            ' we must indicate the response Range of 
  '            ' in the initial HTTP Header 
  '            objResponse.AppendHeader( _
  '             HTTP_HEADER_CONTENT_RANGE, "bytes " & alRequestedRangesBegin(0).ToString & "-" & alRequestedRangesend(0).ToString & "/" & objFile.Length.ToString)
  '          End If

  '          ' Range response 
  '          objResponse.StatusCode = 206 ' Partial Response


  '        Else
  '          ' This is not a Range request, or the requested 
  '          ' Range entity ID does not match the current entity 
  '          ' ID, so start a new download

  '          ' Indicate the file's complete size as content length
  '          iResponseContentLength = Convert.ToInt32(objFile.Length)

  '          ' Return a normal OK status...
  '          objResponse.StatusCode = 200
  '        End If


  '        ' Write the content length into the Response
  '        objResponse.AppendHeader(HTTP_HEADER_CONTENT_LENGTH, iResponseContentLength.ToString)

  '        ' Write the Last-Modified Date into the Response
  '        objResponse.AppendHeader(HTTP_HEADER_LAST_MODIFIED, objFile.LastWriteTimeUTC.ToString("r"))

  '        ' Tell the client software that we accept Range request
  '        objResponse.AppendHeader(HTTP_HEADER_ACCEPT_RANGES, HTTP_HEADER_ACCEPT_RANGES_BYTES)

  '        ' Write the file's Entity Tag into the Response 
  '        ' (in quotes!)
  '        objResponse.AppendHeader(HTTP_HEADER_ENTITY_TAG, """" & objFile.EntityTag & """")

  '        ' Write the Content Type into the Response
  '        If bMultipart Then
  '          ' Multipart messages have this special Type.
  '          ' In this case, the file's actual mime type is
  '          ' written into the Response at a later time...
  '          objResponse.ContentType = MULTIPART_CONTENTTYPE
  '        Else
  '          ' Single part messages have the files content type...
  '          objResponse.ContentType = objFile.ContentType
  '        End If

  '        If objRequest.HttpMethod.Equals(HTTP_METHOD_HEAD) Then
  '          ' Only the HEAD was requested, so we can quit the 
  '          ' Response right here... 
  '        Else
  '          ' Flush the HEAD information to the client...
  '          objResponse.Flush()

  '          ' Download is in progress...
  '          objFile.State = DownloadFileInformation.DownloadState.fsDownloadInProgress

  '          ' Open the file as filestream
  '          objStream = New System.IO.FileStream(objFile.FullName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)

  '          ' Now, for each requested range, stream the chunks 
  '          ' to the client:
  '          For iLoop = alRequestedRangesBegin.GetLowerBound(0) To alRequestedRangesBegin.GetUpperBound(0)

  '            ' Move the stream to the desired start position...
  '            objStream.Seek(alRequestedRangesBegin(iLoop), IO.SeekOrigin.Begin)

  '            ' Calculate the total amount of bytes for this range
  '            iBytesToRead = Convert.ToInt32(alRequestedRangesend(iLoop) - alRequestedRangesBegin(iLoop)) + 1

  '            If bMultipart Then
  '              ' If this is a multipart response, we must add 
  '              ' certain headers before streaming the content:

  '              ' The multipart boundary
  '              objResponse.Output.WriteLine("--" & MULTIPART_BOUNDARY)

  '              ' The mime type of this part of the content 
  '              objResponse.Output.WriteLine(HTTP_HEADER_CONTENT_TYPE & ": " & objFile.ContentType)

  '              ' The actual range
  '              objResponse.Output.WriteLine(HTTP_HEADER_CONTENT_RANGE & ": bytes " & alRequestedRangesBegin(iLoop).ToString & "-" & alRequestedRangesend(iLoop).ToString & "/" & objFile.Length.ToString)

  '              ' Indicating the end of the intermediate headers
  '              objResponse.Output.WriteLine()

  '            End If

  '            ' Now stream the range to the client...
  '            While iBytesToRead > 0

  '              If objResponse.IsClientConnected Then
  '                ' Read a chunk of bytes from the stream
  '                iLengthOfReadChunk = objStream.Read(bBuffer, 0, Math.Min(bBuffer.Length, iBytesToRead))

  '                ' Write the data to the current output stream.
  '                objResponse.OutputStream.Write(bBuffer, 0, iLengthOfReadChunk)

  '                ' Flush the data to the HTML output.
  '                objResponse.Flush()

  '                ' Clear the buffer
  '                ReDim bBuffer(iBufferSize)

  '                ' Reduce BytesToRead
  '                iBytesToRead -= iLengthOfReadChunk

  '              Else
  '                ' The client was or has disconnected from the 
  '                ' server... stop downstreaming...
  '                iBytesToRead = -1
  '                bDownloadBroken = True
  '              End If
  '            End While
  '            ' In Multipart responses, mark the end of the part 
  '            If bMultipart Then objResponse.Output.WriteLine()

  '            ' No need to proceed to the next part if the 
  '            ' client was disconnected
  '            If bDownloadBroken Then Exit For
  '          Next iLoop

  '          ' At this point, the response was finished 
  '          ' or cancelled... 

  '          If bDownloadBroken Then
  '            ' Download is broken...
  '            objFile.State = DownloadFileInformation.DownloadState.fsDownloadBroken

  '          Else
  '            If bMultipart Then
  '              ' In multipart responses, close the response 
  '              ' once more with the boundary and line breaks
  '              objResponse.Output.WriteLine("--" & MULTIPART_BOUNDARY & "--")
  '              objResponse.Output.WriteLine()
  '            End If

  '            ' The download was finished
  '            objFile.State = DownloadFileInformation.DownloadState.fsDownloadFinished
  '          End If
  '          objStream.Close()
  '        End If
  '      End If
  '      objResponse.End()
  '    End Sub
  '#Region "    Private helper functions"
  '    Private Function CheckIfRange( _
  '    ByVal objRequest As HttpRequest, _
  '    ByVal objFile As DownloadFileInformation) As Boolean
  '      Dim sRequestHeaderIfRange As String

  '      ' Checks the If-Range header if it was sent with the request.
  '      ' Returns True if the header value matches the file's 
  '      ' entity tag, or if no header was sent. 
  '      ' Returns False if a header was sent, but does not 
  '      ' match the file.


  '      ' Retrieve If-Range Header value from Request 
  '      ' (objFile.EntityTag if none is indicated)
  '      sRequestHeaderIfRange = RetrieveHeader( _
  '       objRequest, HTTP_HEADER_IF_RANGE, objFile.EntityTag)

  '      ' If the requested file entity matches the current
  '      ' file entity, return True
  '      Return sRequestHeaderIfRange.Equals(objFile.EntityTag)
  '    End Function
  '    Private Function CheckIfMatch(ByVal objRequest As HttpRequest, ByVal objFile As DownloadFileInformation) As Boolean
  '      Dim sRequestHeaderIfMatch As String
  '      Dim sEntityIDs() As String
  '      Dim bReturn As Boolean

  '      ' Checks the If-Match header if it was sent with the request.
  '      ' Returns True if one of the header values matches the file's 
  '      ' entity tag, or if no header was sent.
  '      ' Returns False if a header was sent, but does not match 
  '      ' the file.

  '      ' Retrieve If-Match Header value from Request 
  '      ' (*, meaning any, if none is indicated)
  '      sRequestHeaderIfMatch = RetrieveHeader( _
  '       objRequest, HTTP_HEADER_IF_MATCH, "*")

  '      If sRequestHeaderIfMatch.Equals("*") Then
  '        ' The server may perform the request as if the
  '        ' If-Match header does not exists...
  '        bReturn = True

  '      Else
  '        ' One or more Match IDs where sent by the client 
  '        ' software...
  '        sEntityIDs = sRequestHeaderIfMatch.Replace( _
  '         "bytes=", "").Split(",".ToCharArray)

  '        ' Loop through all entity IDs, finding one 
  '        ' which matches the current file's ID will
  '        ' be enough to satisfy the If-Match
  '        For iLoop As Int32 = sEntityIDs.GetLowerBound(0) To _
  '         sEntityIDs.GetUpperBound(0)
  '          If sEntityIDs(iLoop).Trim.Equals(objFile.EntityTag) Then
  '            bReturn = True
  '          End If
  '        Next iLoop
  '      End If

  '      ' Return the result...
  '      Return bReturn
  '    End Function
  '    Private Function CheckIfNoneMatch(ByVal objRequest As HttpRequest, ByVal objResponse As HttpResponse, ByVal objFile As DownloadFileInformation) As Boolean
  '      Dim sRequestHeaderIfNoneMatch As String
  '      Dim sEntityIDs() As String
  '      Dim bReturn As Boolean = True
  '      Dim sReturn As String = String.Empty

  '      ' Checks the If-None-Match header if it was sent with 
  '      ' the request.
  '      ' Returns True if one of the header values matches the 
  '      ' file's entity tag, or if "*" was sent.
  '      ' Returns False if a header was sent, but does not match 
  '      ' the file, or if no header was sent.

  '      ' Retrieve If-None-Match Header value from Request 
  '      ' (*, meaning any, if none is indicated)
  '      sRequestHeaderIfNoneMatch = RetrieveHeader( _
  '       objRequest, HTTP_HEADER_IF_NONE_MATCH, String.Empty)

  '      If sRequestHeaderIfNoneMatch.Equals(String.Empty) Then
  '        ' Perform the request normally...
  '        bReturn = True

  '      ElseIf sRequestHeaderIfNoneMatch.Equals("*") Then
  '        ' The server must not perform the request 
  '        objResponse.StatusCode = 412  ' Precondition failed
  '        bReturn = False

  '      Else
  '        ' One or more Match IDs were sent by the client...
  '        sEntityIDs = sRequestHeaderIfNoneMatch.Replace( _
  '         "bytes=", "").Split(",".ToCharArray)

  '        ' Loop through all entity IDs, finding one which 
  '        ' does not match the current file's ID will be
  '        ' enough to satisfy the If-None-Match
  '        For iLoop As Int32 = sEntityIDs.GetLowerBound(0) To _
  '         sEntityIDs.GetUpperBound(0)
  '          If sEntityIDs(iLoop).Trim.Equals(objFile.EntityTag) Then
  '            sReturn = sEntityIDs(iLoop)
  '            bReturn = False
  '          End If
  '        Next iLoop

  '        If Not bReturn Then
  '          ' One of the requested entities matches the current 
  '          ' file's tag,
  '          objResponse.AppendHeader("ETag", sReturn)
  '          objResponse.StatusCode = 304  ' Not Modified

  '        End If
  '      End If

  '      ' Return the result...
  '      Return bReturn
  '    End Function
  '    Private Function CheckIfModifiedSince(ByVal objRequest As HttpRequest, ByVal objFile As DownloadFileInformation) As Boolean
  '      Dim sDate As String
  '      Dim dDate As Date
  '      Dim bReturn As Boolean

  '      ' Checks the If-Modified header if it was sent with 
  '      ' the request.
  '      ' Returns True, if the file was modified since the 
  '      ' indicated date (RFC 1123 format), or if no header was sent.
  '      ' Returns False, if the file was not modified since
  '      ' the indicated date.

  '      ' Retrieve If-Modified-Since Header value from Request 
  '      ' (Empty if none is indicated)
  '      sDate = RetrieveHeader(objRequest, _
  '       HTTP_HEADER_IF_MODIFIED_SINCE, String.Empty)

  '      If sDate.Equals(String.Empty) Then
  '        ' No If-Modified-Since date was indicated, 
  '        ' so just give this as True 
  '        bReturn = True

  '      Else
  '        Try
  '          ' ... to parse the indicated sDate to a datetime value
  '          dDate = DateTime.Parse(sDate)
  '          ' Return True if the file was modified since or at 
  '          ' the indicated date...
  '          bReturn = objFile.LastWriteTimeUTC >= _
  '           DateTime.Parse(sDate)

  '        Catch ex As Exception
  '          ' Converting the indicated date value failed, 
  '          ' return False 
  '          bReturn = False

  '        End Try

  '      End If

  '      Return bReturn
  '    End Function
  '    Private Function CheckIfUnmodifiedSince(ByVal objRequest As HttpRequest, ByVal objFile As DownloadFileInformation) As Boolean
  '      Dim sDate As String
  '      Dim dDate As Date
  '      Dim bReturn As Boolean


  '      ' Checks the If-Unmodified or Unless-Modified-Since header, 
  '      ' if one was sent with the request.
  '      ' Returns True, if the file was not modified since the 
  '      ' indicated date (RFC 1123 format), or if no header was sent.
  '      ' Returns False, if the file was modified since the 
  '      ' indicated date


  '      ' Retrieve If-Unmodified-Since Header value from 
  '      ' Request (Empty if none is indicated)
  '      sDate = RetrieveHeader(objRequest, HTTP_HEADER_IF_UNMODIFIED_SINCE, String.Empty)

  '      If sDate.Equals(String.Empty) Then
  '        ' If-Unmodified-Since was not sent, check 
  '        ' Unless-Modified-Since... 
  '        sDate = RetrieveHeader(objRequest, HTTP_HEADER_UNLESS_MODIFIED_SINCE, String.Empty)
  '      End If


  '      If sDate.Equals(String.Empty) Then
  '        ' No date was indicated, 
  '        ' so just give this as True 
  '        bReturn = True

  '      Else
  '        Try
  '          ' ... to parse the indicated sDate to a datetime value
  '          dDate = DateTime.Parse(sDate)
  '          ' Return True if the file was not modified since 
  '          ' the indicated date...
  '          bReturn = objFile.LastWriteTimeUTC < DateTime.Parse(sDate)

  '        Catch ex As Exception
  '          ' Converting the indicated date value failed, 
  '          ' return False 
  '          bReturn = False

  '        End Try

  '      End If

  '      Return bReturn
  '    End Function
  '    Private Function ParseRequestHeaderRange(ByVal objRequest As HttpRequest, ByRef lBegin() As Long, ByRef lEnd() As Long, ByVal lMax As Long, ByRef bRangeRequest As Boolean) As Boolean
  '      Dim bValidRanges As Boolean
  '      Dim sSource As String
  '      Dim iLoop As Int32
  '      Dim sRanges() As String
  '      ' Parses the Range header from the Request (if there is one)
  '      ' Returns True, if the Range header was valid, or if there 
  '      ' was no Range header at all (meaning that the whole 
  '      ' file was requested)
  '      ' Returns False, if the Range header asked for unsatisfieable 
  '      ' ranges
  '      ' Retrieve Range Header value from Request (Empty if none 
  '      ' is indicated)
  '      sSource = RetrieveHeader(objRequest, HTTP_HEADER_RANGE, String.Empty)
  '      If sSource.Equals(String.Empty) Then
  '        ' No Range was requested, return the entire file range...
  '        ReDim lBegin(0)
  '        ReDim lEnd(0)
  '        lBegin(0) = 0
  '        lEnd(0) = lMax - 1
  '        ' A valid range is returned
  '        bValidRanges = True
  '        ' no Range request
  '        bRangeRequest = False
  '      Else
  '        ' A Range was requested... 
  '        ' Preset value...
  '        bValidRanges = True
  '        ' Return True for the bRange parameter, telling the caller
  '        ' that the Request is indeed a Range request...
  '        bRangeRequest = True
  '        ' Remove "bytes=" from the beginning, and split the 
  '        ' remaining string by comma characters
  '        sRanges = sSource.Replace("bytes=", "").Split(",".ToCharArray)
  '        ReDim lBegin(sRanges.GetUpperBound(0))
  '        ReDim lEnd(sRanges.GetUpperBound(0))
  '        ' Check each found Range request for consistency
  '        For iLoop = sRanges.GetLowerBound(0) To sRanges.GetUpperBound(0)
  '          ' Split this range request by the dash character, 
  '          ' sRange(0) contains the requested begin-value,
  '          ' sRange(1) contains the requested end-value...
  '          Dim sRange() As String = sRanges(iLoop).Split("-".ToCharArray)
  '          ' Determine the end of the requested range
  '          If sRange(1).Equals(String.Empty) Then
  '            ' No end was specified, take the entire range
  '            lEnd(iLoop) = lMax - 1
  '          Else
  '            ' An end was specified...
  '            lEnd(iLoop) = Long.Parse(sRange(1))
  '          End If
  '          ' Determine the begin of the requested range
  '          If sRange(0).Equals(String.Empty) Then
  '            ' No begin was specified, which means that
  '            ' the end value indicated to return the last n
  '            ' bytes of the file:
  '            ' Calculate the begin
  '            lBegin(iLoop) = lMax - 1 - lEnd(iLoop)
  '            ' ... to the end of the file...
  '            lEnd(iLoop) = lMax - 1
  '          Else
  '            ' A normal begin value was indicated...
  '            lBegin(iLoop) = Long.Parse(sRange(0))
  '          End If
  '          ' Check if the requested range values are valid, 
  '          ' return False if they are not.
  '          '
  '          ' Note:
  '          ' Do not clean invalid values up by fitting them into
  '          ' valid parameters using Math.Min and Math.Max, because
  '          ' some download clients (like Go!Zilla) might send 
  '          ' invalid (e.g. too large) range requests to determine 
  '          ' the file limits!
  '          ' Begin and end must not exceed the file size
  '          If (lBegin(iLoop) > (lMax - 1)) Or (lEnd(iLoop) > (lMax - 1)) Then
  '            bValidRanges = False
  '          End If
  '          ' Begin and end cannot be < 0
  '          If (lBegin(iLoop) < 0) Or (lEnd(iLoop) < 0) Then
  '            bValidRanges = False
  '          End If
  '          ' End must be larger or equal to begin value
  '          If lEnd(iLoop) < lBegin(iLoop) Then
  '            ' The requested Range is invalid...
  '            bValidRanges = False
  '          End If
  '        Next iLoop
  '      End If
  '      Return bValidRanges
  '    End Function
  '    Private Function RetrieveHeader(ByVal objRequest As HttpRequest, ByVal sHeader As String, ByVal sDefault As String) As String
  '      Dim sReturn As String

  '      ' Retrieves the indicated Header's value from the Request,
  '      ' if the header was not sent, sDefault is returned.
  '      ' If the value contains quote characters, they are removed.
  '      sReturn = objRequest.Headers.Item(sHeader)

  '      If (sReturn Is Nothing) OrElse sReturn.Equals( _
  '       String.Empty) Then
  '        ' The Header wos not found in the Request, 
  '        ' return the indicated default value...
  '        Return sDefault

  '      Else
  '        ' Return the found header value, stripped of any quote 
  '        ' characters...
  '        Return sReturn.Replace("""", "")

  '      End If

  '    End Function
  '    Private Function GenerateHash(ByVal objStream As System.IO.Stream, ByVal lBegin As Long, ByVal lEnd As Long) As String
  '      Dim bByte(Convert.ToInt32(lEnd)) As Byte

  '      objStream.Read(bByte, Convert.ToInt32(lBegin), Convert.ToInt32(lEnd - lBegin) + 1)

  '      'Instantiate an MD5 Provider object
  '      Dim Md5 As New System.Security.Cryptography.MD5CryptoServiceProvider

  '      'Compute the hash value from the source
  '      Dim ByteHash() As Byte = Md5.ComputeHash(bByte)

  '      'And convert it to String format for return
  '      Return Convert.ToBase64String(ByteHash)
  '    End Function
  '#End Region
  '  End Class
  Public Class rptxHandler
    Implements IHttpHandler
    Implements IRequiresSessionState

    Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
      Get
        Return True
      End Get
    End Property
    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
      SIS.SYS.Utilities.ApplicationSpacific.ApplicationReports(context)
    End Sub
  End Class
End Namespace
