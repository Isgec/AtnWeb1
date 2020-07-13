Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Serialization

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://cloud.isgec.co.in/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class WfhService
  Inherits System.Web.Services.WebService
  Private atnUser As SIS.ATN.newHrmEmployees = Nothing
#Region " ValidateSession "
  Private Function ValidateSession() As Boolean
    Try
      atnUser = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(HttpContext.Current.Session("LoginID"))
    Catch ex As Exception
    End Try
    If atnUser Is Nothing Then Return False
    Return True
  End Function
#End Region
#Region " SessionExpired "
  Private Function SessionExpired() As String
    Return New JavaScriptSerializer().Serialize(New With {
           .err = True,
           .msg = "Session Expired, Login again."
       })
  End Function
#End Region
#Region " Error Do Nothing  "
  Private Function ErrorDoNothing() As String
    Dim mRet As New SIS.ATN.wResp
    mRet.err = True
    Return New JavaScriptSerializer().Serialize(mRet)
  End Function
#End Region
#Region " Return Error Message  "
  Private Function ErrorMessage(strMsg As String) As String
    Dim mRet As New SIS.ATN.wResp
    mRet.err = True
    mRet.msg = strMsg
    Return New JavaScriptSerializer().Serialize(mRet)
  End Function
#End Region
#Region " Return Message  "
  Private Function Message(strMsg As String) As String
    Dim mRet As New SIS.ATN.wResp
    mRet.err = False
    mRet.msg = strMsg
    Return New JavaScriptSerializer().Serialize(mRet)
  End Function
#End Region
#Region " LoadEmp "
  <WebMethod(EnableSession:=True)>
  Public Function LoadEmp(ByVal context As String) As String
    If Not ValidateSession() Then Return SessionExpired()

    Dim User As String = ""
    Dim Level As Integer = 0
    Dim confSr As Integer = 0

    Dim aCon As String() = context.Split("_".ToCharArray)
    If aCon.Count > 2 Then
      'aCon(0) = "e"
      User = aCon(1)
      Level = aCon(2)
      confSr = aCon(3)
    Else
      User = HttpContext.Current.Session("LoginID")
      confSr = aCon(1)
    End If
    Dim Active As Boolean = False
    Dim currentDate As DateTime = Now.Date
    Dim Conf As SIS.ATN.WFHConfig = SIS.ATN.WFHConfig.WFHConfigGetByID(confSr)
    Dim x As SIS.ATN.wResp = Nothing
    x = SIS.ATN.wResp.GetResp(User, Conf, Level)
    x.lpd = SIS.SYS.Utilities.ApplicationSpacific.LastProcessedDate
    Dim jxx As New JavaScriptSerializer()
    jxx.MaxJsonLength = Integer.MaxValue
    Dim tmp As String = jxx.Serialize(x)
    Return tmp
  End Function
#End Region
#Region " ChangeStatus "
  <WebMethod(EnableSession:=True)>
  Public Function ChangeStatus(ByVal context As String) As String
    If Not ValidateSession() Then Return SessionExpired()

    Dim User As String = ""
    Dim AttenDate As String = ""
    Dim x As New SIS.ATN.wResp
    x.id = context
    If context = "" Then Return ErrorMessage("Request is blank.")
    Dim aCon As String() = context.Split("_".ToCharArray)
    AttenDate = aCon(0)
    User = aCon(1)
    If Not SIS.ATN.WFHConfig.IsDateOpenForEmp(atnUser.CardNo, AttenDate) Then
      Return New JavaScriptSerializer().Serialize(New With {
            .err = True,
            .msg = "Date is not open to modify by user or Data is processed..",
            .id = x.id
         })
    End If
    Dim hist As SIS.ATN.WFHRoosterHistory = Nothing
    Try
      hist = SIS.ATN.WFHRooster.ChangeStatus(AttenDate, User, atnUser.CardNo, "By clicking on roster.")
      x.s = hist.WFHFullDay
      x.msg = "Roster status changed for: " & AttenDate
    Catch ex As Exception
      x.err = True
      x.msg = ex.Message
    End Try
    Dim jxx As New JavaScriptSerializer()
    jxx.MaxJsonLength = Integer.MaxValue
    Return jxx.Serialize(New With {
          .err = x.err,
          .msg = x.msg,
          .id = x.id,
          .cno = User,
          .s = x.s,
          .rsnm = hist.StatusName,
          .h = hist.HRM_Employees1_EmployeeName & " - " & hist.ModifiedOn
       })
  End Function
#End Region

  <WebMethod(EnableSession:=True)>
  Public Function GenerateRooster(context As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    If Not SIS.ATN.WFHRooster.IsAdmin(atnUser.CardNo) Then Return ErrorMessage("Only Admin can generate rooster.")
    Dim x As New SIS.ATN.wResp
    Try
      SIS.ATN.WFHRooster.CreateRooster(context)
      x.msg = "Roster Generated"
    Catch ex As Exception
      x.err = True
      x.msg = ex.Message
    End Try
    Dim jxx As New JavaScriptSerializer()
    jxx.MaxJsonLength = Integer.MaxValue
    Return jxx.Serialize(x)
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function DeleteRooster(context As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    If Not SIS.ATN.WFHRooster.IsAdmin(atnUser.CardNo) Then Return ErrorMessage("Only Admin can delete rooster.")
    Dim x As New SIS.ATN.wResp
    Try
      SIS.ATN.WFHRooster.DeleteRooster(context)
      x.msg = "Roster Deleted"
    Catch ex As Exception
      x.err = True
      x.msg = ex.Message
    End Try
    Dim jxx As New JavaScriptSerializer()
    jxx.MaxJsonLength = Integer.MaxValue
    Return jxx.Serialize(x)
  End Function

End Class
