Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnProcessedPunch
		Private _Remarks As String = "Register entry"
		Private _HoliDay As Boolean = False
		Public Property HoliDay() As Boolean
			Get
				Return _HoliDay
			End Get
			Set(ByVal value As Boolean)
				_HoliDay = value
			End Set
		End Property
		Public Property Remarks() As String
			Get
				Return _Remarks
			End Get
			Set(ByVal value As String)
				_Remarks = value
			End Set
		End Property
		Private Shared Sub SetPunch9Time(ByVal Record As SIS.ATN.atnProcessedPunch)
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
		Public Property ForeColor() As System.Drawing.Color
			Get
				If Enabled Then
					Return Drawing.Color.Magenta
				ElseIf MannuallyCorrected Then
					Return Drawing.Color.FromArgb(255, 0, 0)
				Else
					Return Drawing.Color.SeaGreen
				End If
			End Get
			Set(ByVal value As System.Drawing.Color)

			End Set
		End Property
		Public Property NotApplied() As Boolean
			Get
				If Convert.ToDecimal(_FinalValue < 1) And _Applied = False Then
					Return True
				End If
				Return False
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		Public Property Enabled() As Boolean
			Get
				If Convert.ToDecimal(_Punch1Time) = 0 And Convert.ToDecimal(_Punch2Time) = 0 And Convert.ToDecimal(_FinalValue = 0) And _Applied = False Then
					Return True
				End If
				Return False
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		Public Property Editable() As Boolean
			Get
				If Convert.ToDateTime(_AttenDate) < SIS.SYS.Utilities.ApplicationSpacific.LastWorkingDate(SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(_CardNoHRM_Employees.C_OfficeID), 3) And _Applied = False Then
					Return False
				End If
				Return True
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		<DataObjectMethod(DataObjectMethodType.Insert, True)> _
		Public Shared Function Insert(ByVal Record As SIS.ATN.atnProcessedPunch) As Int32
			Dim _Result As Int32 = Record.AttenID
			SIS.ATN.atnProcessedPunch.SetPunch9Time(Record)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnProcessedPunchInsert"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch1Time", SqlDbType.Decimal, 9, IIf(Record.Punch1Time = "", Convert.DBNull, Record.Punch1Time))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch2Time", SqlDbType.Decimal, 9, IIf(Record.Punch2Time = "", Convert.DBNull, Record.Punch2Time))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID", SqlDbType.NVarChar, 3, Record.PunchStatusID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch9Time", SqlDbType.Decimal, 9, IIf(Record.Punch9Time = "", Convert.DBNull, Record.Punch9Time))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchValue", SqlDbType.Decimal, 9, IIf(Record.PunchValue = "", Convert.DBNull, Record.PunchValue))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalValue", SqlDbType.Decimal, 9, IIf(Record.FinalValue = "", Convert.DBNull, Record.FinalValue))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NeedsRegularization", SqlDbType.Bit, 3, Record.NeedsRegularization)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 5, Global.System.Web.HttpContext.Current.Session("FinYear"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication", SqlDbType.Bit, 3, Record.AdvanceApplication)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MannuallyCorrected", SqlDbType.Bit, 3, Record.MannuallyCorrected)
					Cmd.Parameters.Add("@Return_AttenID", SqlDbType.Int, 10)
					Cmd.Parameters("@Return_AttenID").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@Return_AttenID").Value
				End Using
			End Using
			Return _Result
		End Function
		<DataObjectMethod(DataObjectMethodType.Update, True)> _
		Public Shared Function Update(ByVal Record As SIS.ATN.atnProcessedPunch) As Int32
			Dim _Result As Integer = 0
			SIS.ATN.atnProcessedPunch.SetPunch9Time(Record)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnProcessedPunchUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttenID", SqlDbType.Int, 11, Record.AttenID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch1Time", SqlDbType.Decimal, 9, IIf(Record.Punch1Time = "", Convert.DBNull, Record.Punch1Time))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch2Time", SqlDbType.Decimal, 9, IIf(Record.Punch2Time = "", Convert.DBNull, Record.Punch2Time))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID", SqlDbType.NVarChar, 3, Record.PunchStatusID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch9Time", SqlDbType.Decimal, 9, IIf(Record.Punch9Time = "", Convert.DBNull, Record.Punch9Time))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchValue", SqlDbType.Decimal, 9, IIf(Record.PunchValue = "", Convert.DBNull, Record.PunchValue))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalValue", SqlDbType.Decimal, 9, IIf(Record.FinalValue = "", Convert.DBNull, Record.FinalValue))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NeedsRegularization", SqlDbType.Bit, 3, Record.NeedsRegularization)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MannuallyCorrected", SqlDbType.Bit, 3, Record.MannuallyCorrected)
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return _Result
		End Function
		Public Shared Function UZ_Update(ByVal Record As SIS.ATN.atnProcessedPunch) As Int32
      If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
        Return 0
        Exit Function
      End If
      Dim Result As Integer = 0
			'Check Whether Time is actually Changed
			Dim tmp As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetByID(Record.AttenID)
			If Not tmp.MannuallyCorrected Then
				If Record.Punch1Time <> tmp.Punch1Time Then
					Record.MannuallyCorrected = True
				ElseIf Record.Punch2Time <> tmp.Punch2Time Then
					Record.MannuallyCorrected = True
				End If
			Else
				Record.MannuallyCorrected = tmp.MannuallyCorrected
			End If
			If Record.MannuallyCorrected Then
				'Insert Original Record in history
				Dim oHst As SIS.ATN.atnMannualCorrectionHistory = New SIS.ATN.atnMannualCorrectionHistory
				With oHst
					.AttenID = tmp.AttenID
					.AttenDate = tmp.AttenDate
					.CardNo = tmp.CardNo
					.Punch1Time = tmp.Punch1Time
					.Punch2Time = tmp.Punch2Time
					.NewPunch1Time = Record.Punch1Time
					.NewPunch2Time = Record.Punch2Time
					.Remarks = Record.Remarks
					.PunchStatusID = tmp.PunchStatusID
				End With
				SIS.ATN.atnMannualCorrectionHistory.Insert(oHst)
				'===============
				Result = SIS.ATN.atnProcessedPunch.Update(Record)
				SIS.SYS.Utilities.NewAttendanceRules.UpdateAttendanceStatusByTime(Record.AttenID)
			End If
			Return Result
		End Function

		Public Shared Function GetProcessedPunchByCardNoDate(ByVal CardNo As String, ByVal AttenDate As DateTime) As SIS.ATN.atnProcessedPunch
			Dim Results As SIS.ATN.atnProcessedPunch = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_ProcessedPunchByCardNoDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, AttenDate)
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = New SIS.ATN.atnProcessedPunch(Reader)
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetAllIncompleteAttendance(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_ProcessedPunchAllIncompleteAttendance"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetAllIncompleteAttendanceWithoutFilter(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_ProcessedPunchAllIncompleteAttendanceWithoutFilter"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewGetAllIncompleteAttendance(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewProcessedPunchAllIncompleteAttendance"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewGetAllIncompleteAttendanceWithoutFilter(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewProcessedPunchAllIncompleteAttendanceWithoutFilter"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewGetAllFPAttendance(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewProcessedPunchAllFPAttendance"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewGetAllFPAttendanceWithoutFilter(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewProcessedPunchAllFPAttendanceWithoutFilter"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewODGetAllIncompleteAttendance(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewODProcessedPunchAllIncompleteAttendance"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewODGetAllIncompleteAttendanceWithoutFilter(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewODProcessedPunchAllIncompleteAttendanceWithoutFilter"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewODGetAllIncompleteAttendanceWithoutFilter_1(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewODProcessedPunchAllIncompleteAttendanceWithoutFilter_1"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewTSGetAllIncompleteAttendance(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewTSProcessedPunchAllIncompleteAttendance"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function NewTSGetAllIncompleteAttendanceWithoutFilter(ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewTSProcessedPunchAllIncompleteAttendanceWithoutFilter"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnProcessedPunch)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetAttendanceByCardNoDateRange(ByVal FCardNo As String, ByVal TCardNo As String, ByVal FAttenDate As DateTime, ByVal TAttenDate As DateTime, ByVal OrderBy As String) As List(Of SIS.ATN.atnProcessedPunch)
			Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_NewProcessedPunchByCardNoDateRange"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FCardNo", SqlDbType.NVarChar, FCardNo.ToString.Length, FCardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCardNo", SqlDbType.NVarChar, TCardNo.ToString.Length, TCardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FAttenDate", SqlDbType.DateTime, 21, FAttenDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAttenDate", SqlDbType.DateTime, 21, TAttenDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					_RecordCount = -1
					Con.Open()
					Results = New List(Of SIS.ATN.atnProcessedPunch)
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
	End Class
End Namespace
