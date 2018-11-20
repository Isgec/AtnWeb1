Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.IJT
	Partial Public Class ijtAttendance
		Public Shared Function SelectListHR(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal C_ProjectSiteID As String, ByVal DataMonth As Int32, ByVal VerificationStatus As String) As List(Of SIS.IJT.ijtAttendance)
			Dim Results As List(Of SIS.IJT.ijtAttendance) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spijtAttendanceSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spijt_LG_AttendanceSelectListFilteresHR"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.NVarChar, 8, IIf(CardNo Is Nothing, String.Empty, CardNo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_ProjectSiteID", SqlDbType.NVarChar, 6, IIf(C_ProjectSiteID Is Nothing, String.Empty, C_ProjectSiteID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DataMonth", SqlDbType.Int, 10, IIf(DataMonth = Nothing, 0, DataMonth))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VerificationStatus", SqlDbType.NVarChar, 3, IIf(VerificationStatus Is Nothing, String.Empty, VerificationStatus))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.IJT.ijtAttendance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.IJT.ijtAttendance(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Private Function ISEnabled(ByVal cDay As Integer) As Boolean
			Try
				If DateDiff(DateInterval.Day, Convert.ToDateTime(cDay.ToString.PadLeft(2, "0") & "/" & _DataMonth.ToString.PadLeft(2, "0") & "/" & FinYear), Now) <= HttpContext.Current.Session("EditAllowedDays") Then
					Dim Val As String = CallByName(Me, "D" & cDay, CallType.Get)
					If "PR,AD,HD".IndexOf(Val) <= -1 Then
						Return False
					End If
					Return True
				End If
				Return False
			Catch ex As Exception
			End Try
			Return False
		End Function
		Public ReadOnly Property Enabled1() As Boolean
			Get
				Return ISEnabled(1)
			End Get
		End Property
		Public ReadOnly Property Enabled2() As Boolean
			Get
				Return ISEnabled(2)
			End Get
		End Property
		Public ReadOnly Property Enabled3() As Boolean
			Get
				Return ISEnabled(3)
			End Get
		End Property
		Public ReadOnly Property Enabled4() As Boolean
			Get
				Return ISEnabled(4)
			End Get
		End Property
		Public ReadOnly Property Enabled5() As Boolean
			Get
				Return ISEnabled(5)
			End Get
		End Property
		Public ReadOnly Property Enabled6() As Boolean
			Get
				Return ISEnabled(6)
			End Get
		End Property
		Public ReadOnly Property Enabled7() As Boolean
			Get
				Return ISEnabled(7)
			End Get
		End Property
		Public ReadOnly Property Enabled8() As Boolean
			Get
				Return ISEnabled(8)
			End Get
		End Property
		Public ReadOnly Property Enabled9() As Boolean
			Get
				Return ISEnabled(9)
			End Get
		End Property
		Public ReadOnly Property Enabled10() As Boolean
			Get
				Return ISEnabled(10)
			End Get
		End Property
		Public ReadOnly Property Enabled11() As Boolean
			Get
				Return ISEnabled(11)
			End Get
		End Property
		Public ReadOnly Property Enabled12() As Boolean
			Get
				Return ISEnabled(12)
			End Get
		End Property
		Public ReadOnly Property Enabled13() As Boolean
			Get
				Return ISEnabled(13)
			End Get
		End Property
		Public ReadOnly Property Enabled14() As Boolean
			Get
				Return ISEnabled(14)
			End Get
		End Property
		Public ReadOnly Property Enabled15() As Boolean
			Get
				Return ISEnabled(15)
			End Get
		End Property
		Public ReadOnly Property Enabled16() As Boolean
			Get
				Return ISEnabled(16)
			End Get
		End Property
		Public ReadOnly Property Enabled17() As Boolean
			Get
				Return ISEnabled(17)
			End Get
		End Property
		Public ReadOnly Property Enabled18() As Boolean
			Get
				Return ISEnabled(18)
			End Get
		End Property
		Public ReadOnly Property Enabled19() As Boolean
			Get
				Return ISEnabled(19)
			End Get
		End Property
		Public ReadOnly Property Enabled20() As Boolean
			Get
				Return ISEnabled(20)
			End Get
		End Property
		Public ReadOnly Property Enabled21() As Boolean
			Get
				Return ISEnabled(21)
			End Get
		End Property
		Public ReadOnly Property Enabled22() As Boolean
			Get
				Return ISEnabled(22)
			End Get
		End Property
		Public ReadOnly Property Enabled23() As Boolean
			Get
				Return ISEnabled(23)
			End Get
		End Property
		Public ReadOnly Property Enabled24() As Boolean
			Get
				Return ISEnabled(24)
			End Get
		End Property
		Public ReadOnly Property Enabled25() As Boolean
			Get
				Return ISEnabled(25)
			End Get
		End Property
		Public ReadOnly Property Enabled26() As Boolean
			Get
				Return ISEnabled(26)
			End Get
		End Property
		Public ReadOnly Property Enabled27() As Boolean
			Get
				Return ISEnabled(27)
			End Get
		End Property
		Public ReadOnly Property Enabled28() As Boolean
			Get
				Return ISEnabled(28)
			End Get
		End Property
		Public ReadOnly Property Enabled29() As Boolean
			Get
				Return ISEnabled(29)
			End Get
		End Property
		Public ReadOnly Property Enabled30() As Boolean
			Get
				Return ISEnabled(30)
			End Get
		End Property
		Public ReadOnly Property Enabled31() As Boolean
			Get
				Return ISEnabled(31)
			End Get
		End Property
		Public Property ForeColor(ByVal _day As String) As System.Drawing.Color
			Get
				Dim _sts As String = CallByName(Me, _day, CallType.Get)
				Select Case _sts.ToUpper
					Case "PR"
						Return Drawing.Color.Blue
					Case "AD", "AF", "AS"
						Return Drawing.Color.Red
					Case Else
						Return Drawing.Color.Green
				End Select
			End Get
			Set(ByVal value As System.Drawing.Color)

			End Set
		End Property
		Public Shared Function VerifiySiteAttendance(ByVal CardNo As String, ByVal DataMonth As Integer) As Integer
			Dim mRet As Integer = 0
			Dim oAtnds As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.GetUnVerifiedSiteAttendanceByCardNoDataMonth(CardNo, DataMonth)
			For Each atnd As SIS.ATN.atnNewAttendance In oAtnds
				With atnd
					Select Case atnd.PunchStatusID
						Case "PR"
							.FinalValue = 1
					End Select
					.SiteAttendanceVerified = True
					.SiteAttendanceVerifiedOn = Now
					.SiteAttendanceVerifiedBy = HttpContext.Current.Session("LoginID")
				End With
				SIS.ATN.atnNewAttendance.Update(atnd)
				mRet += 1
			Next
			Return mRet
		End Function
		Public Shared Function Update(ByVal Context As String) As String
			Dim aVal() As String = Context.Split("|".ToCharArray)(0).Split(",".ToCharArray)
			Dim CardNo As String = aVal(0)
			Dim FinYear As String = aVal(1)
			Dim DataMonth As String = aVal(2).PadLeft(2, "0")
			Dim DataDay As String = aVal(3).Replace("D", "").PadLeft(2, "0")
			Dim NewValue As String = aVal(4)
			Dim DataDate As String = DataDay & "/" & DataMonth & "/" & FinYear
			Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetAttendanceByCardNoDate(CardNo, DataDate)
			If Not oAtnd Is Nothing Then
				With oAtnd
					Select Case NewValue
						Case "PR"
							.Punch1Time = 9.0
							.Punch2Time = 17.45
							.PunchStatusID = "PR"
							.PunchValue = 1
							.FinalValue = 1
							.NeedsRegularization = False
							.HoliDay = False
						Case "AD"
							.Punch1Time = 0
							.Punch2Time = 0
							.PunchStatusID = "AD"
							.PunchValue = 0
							.FinalValue = 0
							.NeedsRegularization = True
							.HoliDay = False
						Case "HD"
							.Punch1Time = 0
							.Punch2Time = 0
							.PunchStatusID = "HD"
							.PunchValue = 1
							.FinalValue = 1
							.NeedsRegularization = False
							.HoliDay = True
					End Select
					.SiteAttendanceVerified = True
					.SiteAttendanceVerifiedBy = HttpContext.Current.Session("LoginID")
					.SiteAttendanceVerifiedOn = Now
				End With
				SIS.ATN.atnNewAttendance.Update(oAtnd)
			End If
			Return Context
		End Function
		Public Shared Function GetByCardNoMonth(ByVal CardNo As String, ByVal MonthID As Int32, ByVal FinYear As Integer) As SIS.IJT.ijtAttendance
			Dim Results As SIS.IJT.ijtAttendance = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spijt_LG_AttendanceSheetByCardNoMonthYear"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DataMonth", SqlDbType.Int, 11, MonthID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 5, FinYear)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.IJT.ijtAttendance(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function

	End Class
End Namespace
