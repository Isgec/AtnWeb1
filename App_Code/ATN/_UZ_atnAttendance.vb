Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnAttendance
		Private _Punch9Time As String
		Public Property Punch9Time() As String
			Get
				Return _Punch9Time
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Punch9Time = ""
				Else
					_Punch9Time = value
				End If
			End Set
		End Property
		Private Shared Sub SetPunch9Time(ByVal Record As SIS.ATN.atnAttendance)
			With Record
				If .Punch2Time <> String.Empty Then
					If .Punch2Time > "18.15" Then
						If .Punch9Time >= "17.45" And .Punch9Time <= "18.15" Then
							'do nothing,time has allready  been derived
						Else
							'Else derive time
							Dim aa As Random = New Random
							Dim bb As Double = 0
							Do While True
								bb = aa.NextDouble()
								If bb > 0.46 And bb <= 0.6 Then
									Exit Do
								End If
								If bb > 0.01 And bb <= 0.15 Then
									Exit Do
								End If
							Loop
							If bb > 0.01 And bb <= 0.15 Then
								.Punch9Time = FormatNumber(18 + bb, 2)
							Else
								.Punch9Time = FormatNumber(17 + bb, 2)
							End If
						End If
					Else
						.Punch9Time = .Punch2Time
					End If
				Else
					.Punch9Time = ""
				End If
			End With
		End Sub
		Public Shared Function GetAttendanceByApplHeaderID(ByVal ApplHeaderID As Int32) As List(Of SIS.ATN.atnAttendance)
			Dim Results As List(Of SIS.ATN.atnAttendance) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_AttendanceByApplHeaderID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID", SqlDbType.Int, ApplHeaderID.ToString.Length, ApplHeaderID)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnAttendance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnAttendance(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetHTMLAttendanceByApplHeaderID(ByVal ApplHeaderID As Int32) As String
			Dim mRet As String = ""
			Dim oDays As List(Of SIS.ATN.atnAttendance) = SIS.ATN.atnAttendance.GetAttendanceByApplHeaderID(ApplHeaderID)
			mRet = mRet & "<table width=""600px"">"
			mRet = mRet & "<tr>"
			mRet = mRet & "<td class=""bar_greenHeader"" height=""25px"" style=""text-align:left""><b>DATE</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right""><b>STATUS</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right""><b>Ist HALF</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right""><b>IInd HALF</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:left""><b>Destination</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:left""><b>Purpose</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "</tr>"
			For Each oDy As SIS.ATN.atnAttendance In oDays
				mRet = mRet & "<tr>"
				mRet = mRet & "<td>" & oDy.AttenDate
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:right;padding-right: 2px" & IIf(oDy.Posted, ";color:red", "") & """>" & oDy.PunchStatusIDATN_PunchStatus.Description
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:right;padding-right: 2px" & IIf(oDy.Posted, ";color:red", "") & """>" & oDy.Applied1LeaveTypeIDATN_LeaveTypes.Description
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:right;padding-right: 2px" & IIf(oDy.Posted, ";color:red", "") & """>" & oDy.Applied2LeaveTypeIDATN_LeaveTypes.Description
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:left;padding-right: 2px" & IIf(oDy.Posted, ";color:red", "") & """>" & oDy.Destination
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:left;padding-right: 2px" & IIf(oDy.Posted, ";color:red", "") & """>" & oDy.Purpose
				mRet = mRet & "</td>"
				mRet = mRet & "</tr>"
			Next
			mRet = mRet & "</table>"
			Return mRet
		End Function
		Public Shared Function GetAttendanceByCardNoDate(ByVal CardNo As String, ByVal AttenDate As DateTime) As SIS.ATN.atnAttendance
			Dim Results As SIS.ATN.atnAttendance = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_AttendanceByCardNoDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, AttenDate)
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = New SIS.ATN.atnAttendance(Reader)
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
	End Class
End Namespace
