Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnHolidays
		Public Shared Function GetByHoliday(ByVal Holiday As DateTime, ByVal OfficeID As Integer) As SIS.ATN.atnHolidays
			Dim Results As SIS.ATN.atnHolidays = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_HolidaysByDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Holiday", SqlDbType.DateTime, 21, Holiday)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID", SqlDbType.Int, 10, OfficeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear)
          Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ATN.atnHolidays(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
	End Class
End Namespace
