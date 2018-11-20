Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnRawPunch
		Public Shared Function DeleteRawPunchByCardNoAndDate(ByVal CardNo As String, ByVal PunchDate As DateTime) As SIS.ATN.atnRawPunch
			Dim Results As SIS.ATN.atnRawPunch = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_DeleteRawPunchByCardNoDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchDate", SqlDbType.DateTime, 21, PunchDate)
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = New SIS.ATN.atnRawPunch(Reader)
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function DeleteRawPunchByDate(ByVal PunchDate As DateTime) As SIS.ATN.atnRawPunch
			Dim Results As SIS.ATN.atnRawPunch = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_DeleteRawPunchByDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchDate", SqlDbType.DateTime, 21, PunchDate)
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = New SIS.ATN.atnRawPunch(Reader)
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetRawPunchByCardNoDate(ByVal CardNo As String, ByVal PunchDate As DateTime) As SIS.ATN.atnRawPunch
			Dim Results As SIS.ATN.atnRawPunch = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_RawPunchByCardNoDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchDate", SqlDbType.DateTime, 21, PunchDate)
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = New SIS.ATN.atnRawPunch(Reader)
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
	End Class
End Namespace
