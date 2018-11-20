Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnAppliedApplications
		Public Property EnableDelete() As Boolean
			Get
				If _ApplStatusID = 7 Or _ApplStatusID = 1 Then
					Return True
				End If
				Return False
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		Public Property ForeColor() As Drawing.Color
			Get
				Dim cl As Drawing.Color = Drawing.Color.AliceBlue
				Select Case _ApplStatusID
					Case 1
						cl = Drawing.Color.Black
					Case 2, 3, 4, 5
						cl = Drawing.Color.SteelBlue
					Case 6
						cl = Drawing.Color.MediumPurple
					Case 7
						cl = Drawing.Color.Red
				End Select
				Return cl
			End Get
			Set(ByVal value As Drawing.Color)

			End Set
		End Property
		Public Property StatusDetails() As String
			Get
				Dim Ret As String = ""
				If Not _VerificationRemark = String.Empty Then
					Ret = Ret & "<li>" & _VerificationRemark & "</li>"
				End If
				If Not _ApprovalRemark = String.Empty Then
					Ret = Ret & "<li>" & _ApprovalRemark & "</li>"
				End If
				If Not _SanctionRemark = String.Empty Then
					Ret = Ret & "<li>" & _SanctionRemark & "</li>"
				End If
				Return Ret
			End Get
			Set(ByVal value As String)
			End Set
		End Property
		Public Property DelImageUrl() As String
			Get
				If _ApplStatusID = 7 Or _ApplStatusID = 1 Then
					Return "~/App_Themes/Default/Images/del0.png"
				Else
					Return "~/App_Themes/Default/Images/del2.png"
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property
		Public Shared Function UZ_Delete(ByVal Record As SIS.ATN.atnAppliedApplications) As Int32
			Dim dt As DateTime = SIS.SYS.Utilities.ApplicationSpacific.LastProcessedDate
			Dim oDys As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(Record.LeaveApplID)
			For Each oDy As SIS.ATN.atnAttendance In oDys
				If oDy.AdvanceApplication Then
					If Convert.ToDateTime(oDy.AttenDate) > dt Then
						SIS.ATN.atnAttendance.Delete(oDy)
					Else
						oDy.ApplHeaderID = ""
						oDy.AdvanceApplication = False
						SIS.ATN.atnAttendance.Update(oDy)
					End If
				Else
					oDy.ApplHeaderID = ""
					SIS.ATN.atnAttendance.Update(oDy)
				End If
			Next
			Return Delete(Record)
		End Function
	End Class
End Namespace
