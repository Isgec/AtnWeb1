Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_atnSHNotCompensated
	Inherits SIS.SYS.ReportBase

	Private ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
	Public Overrides Sub ProcessReport()
		Dim typ As String = Request.QueryString("typ")
		Me.NoPrintButton = True
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: left;font-size: 14px;font-weight:bold""><u>Short Leave NOT Compensated</u></td></tr></table>")
		Print("</br>")
		Print("</br>")

		Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:40px;text-align:right;vertical-align: top;padding-right: 8px"">S.N.</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">CARD NO</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">EMPLOYEE NAME</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:200px;vertical-align: top"">SH DATE</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">1st PUNCH</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">2nd PUNCH</td>")
		Print("<td style=""font-size: 12px;font-weight:bold;width:80px;vertical-align: top;text-align:right"">SH Min.</td>")
		Print("</tr>")


		Dim Reader As SqlDataReader = Nothing
		Dim mSql As String = ""
		Dim sn As Integer = 0
		Dim First As Boolean = True

		Dim mPage As Integer = 0
		Dim mSize As Integer = 20

		Dim oSHList As List(Of SIS.ATN.atnShortLeaveAvailed) = SIS.ATN.atnShortLeaveAvailed.atnShortLeaveAvailedSelectList(mPage, mSize, "", False, "")
		Do While oSHList.Count > 0
			For Each oSH As SIS.ATN.atnShortLeaveAvailed In oSHList
				Dim MaySkip As Boolean = True
				'Check Compensated or not
				Dim oComps As List(Of SIS.ATN.atnShortLeaveCompensated) = SIS.ATN.atnShortLeaveCompensated.atnShortLeaveCompensatedSelectList(oSH.CardNo, oSH.AttenDate)
				Dim cMinutes As Integer = 0
				For Each oCs As SIS.ATN.atnShortLeaveCompensated In oComps
					cMinutes += (Convert.ToInt32(oCs.difmin) * -1)
				Next
				If cMinutes < Convert.ToInt32(oSH.difmin) Then
					MaySkip = False
				End If
				If Not MaySkip Then
					sn += 1
					Print("<tr>")
					Print("<td style=""text-align:right"">" & sn.ToString & "</td>")
					Print("<td >" & oSH.CardNo & "</td>")
					Print("<td >" & oSH.EmployeeName & "</td>")
					Print("<td >" & oSH.AttenDate & "</td>")
					Print("<td style=""text-align:right"">" & oSH.Punch1Time & "</td>")
					Print("<td style=""text-align:right"">" & oSH.Punch2Time & "</td>")
					Print("<td style=""text-align:right"">" & oSH.difmin & "</td>")
					Print("</tr>")
					If typ = "d" Then
						For Each oCs As SIS.ATN.atnShortLeaveCompensated In oComps
							Print("<tr>")
							Print("<td >&nbsp;</td>")
							Print("<td >&nbsp;</td>")
							Print("<td >&nbsp;</td>")
							Print("<td >" & oCs.AttenDate & "</td>")
							Print("<td style=""text-align:right"">" & oCs.Punch1Time & "</td>")
							Print("<td style=""text-align:right"">" & oCs.Punch2Time & "</td>")
							Print("<td style=""text-align:right"">" & (Convert.ToInt32(oCs.difmin) * -1).ToString & "</td>")
							Print("</tr>")
						Next
						Print("<tr>")
						Print("<td >&nbsp;</td>")
						Print("<td >&nbsp;</td>")
						Print("<td >&nbsp;</td>")
						Print("<td >&nbsp;</td>")
						Print("<td colspan=""2"" style=""text-align:right"">Total Compensated:</td>")
						Print("<td style=""text-align:right"">" & cMinutes.ToString & "</td>")
						Print("</tr>")
					End If
				End If
			Next
			mPage += mSize
			oSHList = SIS.ATN.atnShortLeaveAvailed.atnShortLeaveAvailedSelectList(mPage, mSize, "", False, "")
			'Exit Do
		Loop
		Print("</ table>")
	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
