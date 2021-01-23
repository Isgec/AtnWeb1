Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnNewAttendance

    Public Property ForeColor() As System.Drawing.Color
      Get
        If _Applied1LeaveTypeID <> _Posted1LeaveTypeID Or _Applied2LeaveTypeID <> _Posted2LeaveTypeID Then
          Return Drawing.Color.Magenta
        End If
        Return Drawing.Color.Blue
      End Get
      Set(ByVal value As System.Drawing.Color)

      End Set
    End Property
    Private Function getLGType(ByVal SqlType As SqlDbType) As TypeCode
      Dim tmp As TypeCode
      Select Case SqlType
        Case SqlDbType.BigInt
          tmp = TypeCode.Int64
        Case SqlDbType.Bit
          tmp = TypeCode.Boolean
        Case SqlDbType.Char
          tmp = TypeCode.Char
        Case SqlDbType.DateTime
          tmp = TypeCode.DateTime
        Case SqlDbType.Decimal
          tmp = TypeCode.Decimal
        Case SqlDbType.Int
          tmp = TypeCode.Int32
        Case SqlDbType.NVarChar
          tmp = TypeCode.String
        Case SqlDbType.Float
          tmp = TypeCode.Single
      End Select
      Return tmp
    End Function

    Private Shared Sub SetPunch9Time(ByVal Record As SIS.ATN.atnNewAttendance)
      With Record
        If .Punch2Time <> String.Empty Then
          If .Punch2Time > "18.15" Then
            If .Punch9Time >= "17.45" And .Punch9Time <= "18.15" Then
              'do nothing, time has allready been derived
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

    Public Shared Function GetAttendanceByApplHeaderID(ByVal ApplHeaderID As Int32) As List(Of SIS.ATN.atnNewAttendance)
			Dim Results As List(Of SIS.ATN.atnNewAttendance) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewAttendanceByApplHeaderID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID", SqlDbType.Int, ApplHeaderID.ToString.Length, ApplHeaderID)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnNewAttendance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnNewAttendance(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetAttendanceByCardNoDate(ByVal CardNo As String, ByVal AttenDate As DateTime) As SIS.ATN.atnNewAttendance
			Dim Results As SIS.ATN.atnNewAttendance = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewAttendanceByCardNoDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, AttenDate)
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = New SIS.ATN.atnNewAttendance(Reader)
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetUnVerifiedSiteAttendanceByCardNoDataMonth(ByVal CardNo As String, ByVal DataMonth As Integer) As List(Of SIS.ATN.atnNewAttendance)
			Dim Results As New List(Of SIS.ATN.atnNewAttendance)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_UnVerifiedSiteAttendance"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DataMonth", SqlDbType.Int, 10, DataMonth)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnNewAttendance(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetConfigCount(ByVal CardNo As String, ByVal AttenDate As DateTime, ByVal ConfigStatus As String) As Integer
			Dim Results As Integer = 0
			'=========================
			If ConfigStatus = "FP" Then
				ConfigStatus = "'FP','LF'"
			ElseIf ConfigStatus = "LC" Then
				'ConfigStatus = "'LC','LF'"
				ConfigStatus = "'LC'"
			ElseIf ConfigStatus = "LF" Then
				ConfigStatus = "'LF','FP','LC'"
			End If
			'=========================
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT COUNT(*) FROM ATN_Attendance WHERE CardNo = '" & CardNo & "' AND MONTH(AttenDate) = " & AttenDate.Month & " AND AttenDate <= CONVERT(DateTime,'" & AttenDate.ToString("dd/MM/yyyy") & "',103) AND ConfigStatus IN (" & ConfigStatus & ") AND FinYear = '" & HttpContext.Current.Session("FinYear") & "'"
					Con.Open()
					Results = Cmd.ExecuteScalar
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetSHAvailed(ByVal CardNo As String, ByVal AttenDate As DateTime) As Integer
			Dim Results As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT COUNT(*) FROM ATN_Attendance WHERE CardNo = '" & CardNo & "' AND MONTH(AttenDate) = " & AttenDate.Month & " AND ((Posted1LeaveTypeID = 'SH' OR Posted2LeaveTypeID = 'SH') AND Posted = 1) AND FinYear = '" & HttpContext.Current.Session("FinYear") & "'"
					Con.Open()
					Results = Cmd.ExecuteScalar
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetSHInProcess(ByVal CardNo As String, ByVal AttenDate As DateTime) As Integer
			Dim Results As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT COUNT(*) FROM ATN_Attendance WHERE CardNo = '" & CardNo & "' AND MONTH(AttenDate) = " & AttenDate.Month & " AND ((Applied1LeaveTypeID = 'SH' OR Applied2LeaveTypeID = 'SH') AND Posted = 0) AND FinYear = '" & HttpContext.Current.Session("FinYear") & "'"
					Con.Open()
					Results = Cmd.ExecuteScalar
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetFPAvailed(ByVal CardNo As String, ByVal AttenDate As DateTime) As Integer
			Dim Results As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT COUNT(*) FROM ATN_Attendance WHERE CardNo = '" & CardNo & "' AND MONTH(AttenDate) = " & AttenDate.Month & " AND ((Posted1LeaveTypeID = 'FP' OR Posted2LeaveTypeID = 'FP') AND Posted = 1) AND FinYear = '" & HttpContext.Current.Session("FinYear") & "'"
					Con.Open()
					Results = Cmd.ExecuteScalar
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetFPInProcess(ByVal CardNo As String, ByVal AttenDate As DateTime) As Integer
			Dim Results As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "SELECT COUNT(*) FROM ATN_Attendance WHERE CardNo = '" & CardNo & "' AND MONTH(AttenDate) = " & AttenDate.Month & " AND ((Applied1LeaveTypeID = 'FP' OR Applied2LeaveTypeID = 'FP') AND Posted = 0) AND FinYear = '" & HttpContext.Current.Session("FinYear") & "'"
					Con.Open()
					Results = Cmd.ExecuteScalar
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function ALLTSToBeConvertedToTCForMonth(ByVal ForMonth As Integer) As List(Of SIS.ATN.atnNewAttendance)
			Dim Results As List(Of SIS.ATN.atnNewAttendance) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_AllTSToBeConvertedToTCForMonth"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.Int, -1, ForMonth)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnNewAttendance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnNewAttendance(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function ALLTSToBeWavedoffForMonth(ByVal ForMonth As Integer) As List(Of SIS.ATN.atnNewAttendance)
			Dim Results As List(Of SIS.ATN.atnNewAttendance) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_AllTSToBeWavedoffForMonth"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.Int, -1, ForMonth)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnNewAttendance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnNewAttendance(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetAttendanceByCardNoDateRange(ByVal FCardNo As String, ByVal TCardNo As String, ByVal FAttenDate As DateTime, ByVal TAttenDate As DateTime, ByVal OrderBy As String) As List(Of SIS.ATN.atnNewAttendance)
			Dim Results As List(Of SIS.ATN.atnNewAttendance) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewAttendanceByCardNoDateRange"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FCardNo", SqlDbType.NVarChar, FCardNo.ToString.Length, FCardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCardNo", SqlDbType.NVarChar, TCardNo.ToString.Length, TCardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FAttenDate", SqlDbType.DateTime, 21, FAttenDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAttenDate", SqlDbType.DateTime, 21, TAttenDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					_RecordCount = -1
					Con.Open()
					Results = New List(Of SIS.ATN.atnNewAttendance)
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnNewAttendance(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function SelectAppliedList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnNewAttendance)
			Dim Results As List(Of SIS.ATN.atnNewAttendance) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If orderBy = String.Empty Then orderBy = "AttenDate DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatn_LG_SelectAppliedListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatn_LG_SelectAppliedListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.NVarChar, 8, IIf(CardNo Is Nothing, String.Empty, CardNo))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnNewAttendance)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnNewAttendance(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function SelectAppliedCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
			Return _RecordCount
		End Function
		Public Shared Function UpdatePostedLeaveTypeID(ByVal Record As SIS.ATN.atnNewAttendance) As Int32
			Dim _Result As Integer = 1
			Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(Record.AttenID)
			If Not oAtnd Is Nothing Then
				Dim oLgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(Record.AttenID)
				If oLgrs.Count > 0 Then
					Select Case oAtnd.PunchStatusID
						Case "AF"
							oAtnd.Posted1LeaveTypeID = Record.Posted1LeaveTypeID
							oAtnd.Applied1LeaveTypeID = Record.Posted1LeaveTypeID
							oLgrs.Item(0).LeaveTypeID = Record.Posted1LeaveTypeID
						Case "AS", "TS"
							oAtnd.Posted2LeaveTypeID = Record.Posted2LeaveTypeID
							oAtnd.Applied2LeaveTypeID = Record.Posted2LeaveTypeID
							oLgrs.Item(0).LeaveTypeID = Record.Posted2LeaveTypeID
						Case "AD"
							If oLgrs.Count > 1 Then
								oAtnd.Posted1LeaveTypeID = Record.Posted1LeaveTypeID
								oAtnd.Applied1LeaveTypeID = Record.Posted1LeaveTypeID
								oAtnd.Applied2LeaveTypeID = Record.Posted2LeaveTypeID
								oLgrs.Item(0).LeaveTypeID = Record.Posted1LeaveTypeID
								oAtnd.Posted2LeaveTypeID = Record.Posted2LeaveTypeID
								oLgrs.Item(1).LeaveTypeID = Record.Posted2LeaveTypeID
							Else
								If Record.Posted1LeaveTypeID = Record.Posted2LeaveTypeID Then
									oAtnd.Posted1LeaveTypeID = Record.Posted1LeaveTypeID
									oAtnd.Posted2LeaveTypeID = Record.Posted2LeaveTypeID
									oAtnd.Applied1LeaveTypeID = Record.Posted1LeaveTypeID
									oAtnd.Applied2LeaveTypeID = Record.Posted2LeaveTypeID
									oLgrs.Item(0).LeaveTypeID = Record.Posted1LeaveTypeID
								Else
									oAtnd.Posted1LeaveTypeID = Record.Posted1LeaveTypeID
									oAtnd.Applied1LeaveTypeID = Record.Posted1LeaveTypeID
									oLgrs.Item(0).LeaveTypeID = Record.Posted1LeaveTypeID
									If oLgrs.Item(0).InProcessDays > 0 Then
										oLgrs.Item(0).InProcessDays = 0.5
									Else
										oLgrs.Item(0).Days = -0.5
									End If
									'Create One More Leadger Record
									Dim oLgr As New SIS.ATN.atnLeaveLedger
									With oLgr
										.CardNo = oAtnd.CardNo
										.ApplHeaderID = oLgrs.Item(0).ApplHeaderID
										.ApplDetailID = oLgrs.Item(0).ApplDetailID
										If oLgrs.Item(0).InProcessDays > 0 Then
											.InProcessDays = 0.5
										Else
											.Days = -0.5
										End If
										.LeaveTypeID = Record.Posted2LeaveTypeID
										.TranType = "TRN"
										.TranDate = oLgrs.Item(0).TranDate
									End With
									SIS.ATN.atnLeaveLedger.Insert(oLgr)
								End If
							End If
					End Select
					SIS.ATN.atnNewAttendance.Update(oAtnd)
					For Each lgr As SIS.ATN.atnLeaveLedger In oLgrs
						SIS.ATN.atnLeaveLedger.Update(lgr)
					Next
					'Update Interweaving Leaves
					SIS.SYS.Utilities.NewAttendanceRules.UpdateInterweavingHolidays(oAtnd.AttenID)
					'=========
					_Result = 0
				End If
			End If
			Return _Result
		End Function
	End Class
End Namespace
