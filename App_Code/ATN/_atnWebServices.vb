Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class _atnWebServices
	Inherits System.Web.Services.WebService

	<WebMethod(EnableSession:=True)> _
 Public Function PendingApplicationsUnderVerification(ByVal contextKey As String) As String
		Return SIS.ATN.atnAttendanceUnderVerification.GetHTMLAttendanceUnderVerification(contextKey)
	End Function
	<WebMethod(EnableSession:=True)> _
 Public Function PendingApplicationsUnderApproval(ByVal contextKey As String) As String
		Return SIS.ATN.atnAttendanceUnderApproval.GetHTMLAttendanceUnderApproval(contextKey)
	End Function
	<WebMethod(EnableSession:=True)> _
 Public Function ShowAppliedDays(ByVal context As String) As String
		Return SIS.ATN.atnAttendance.GetHTMLAttendanceByApplHeaderID(context)
	End Function
	<WebMethod(EnableSession:=True)> _
 Public Function ShowLeaveCard(ByVal context As String) As String
		Return SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(context))
	End Function

End Class
