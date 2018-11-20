Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://cloud.isgec.co.in/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class atnWebService
  Inherits System.Web.Services.WebService

  <WebMethod(EnableSession:=True)>
  Public Function ForwardLeaveApplication(ByVal LeaveApplID As Integer, ByVal Remarks As String, ByVal LoginID As String) As String
    Try
      HttpContext.Current.Session("LoginID") = LoginID
      HttpContext.Current.Session("FinYear") = SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear
      SIS.ATN.atnApplHeader.ForwardApplication(LeaveApplID, Remarks)
    Catch ex As Exception
    End Try
    Return ""
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function RejectLeaveApplication(ByVal LeaveApplID As Integer, ByVal Remarks As String, ByVal LoginID As String) As String
    Try
      HttpContext.Current.Session("LoginID") = LoginID
      HttpContext.Current.Session("FinYear") = SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear
      SIS.ATN.atnApplHeader.RejectApplication(LeaveApplID, Remarks)
    Catch ex As Exception
    End Try
    Return ""
  End Function

End Class