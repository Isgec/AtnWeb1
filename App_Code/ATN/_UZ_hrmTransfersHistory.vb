Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.HRM
	Partial Public Class hrmTransfersHistory
		Private _CreateEvent As Boolean = False
		Public Property CreateEvent() As Boolean
			Get
				Return _CreateEvent
			End Get
			Set(ByVal value As Boolean)
				_CreateEvent = value
			End Set
		End Property
		'Public Shared Function UZ_Update(ByVal Record As SIS.HRM.hrmTransfersHistory) As Int32
		'	Dim _Result As Integer = 0
		'	If Record.Executed Or Record.Cancelled Then
		'		If Record.Cancelled Then
		'			Dim oTransfer As SIS.HRM.hrmTransfers = SIS.HRM.hrmTransfers.GetByID(Record.CardNo)
		'			With oTransfer
		'				.U_UnderTransfer = False
		'				.ModifiedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
		'				.ModifiedOn = Now
		'				.ModifiedEvent = "Transfer Cancelled"
		'			End With
		'			SIS.HRM.hrmTransfers.Update(oTransfer)
		'		ElseIf Record.Executed Then
		'			Dim oTransfer As SIS.HRM.hrmTransfers = SIS.HRM.hrmTransfers.GetByID(Record.CardNo)
		'			SIS.HRM.hrmTransfers.TransferExecuted(oTransfer)
		'		End If
		'		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
		'			Using Cmd As SqlCommand = Con.CreateCommand()
		'				Cmd.CommandType = CommandType.StoredProcedure
		'				Cmd.CommandText = "sphrmTransfersHistoryUpdate"
		'				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TransferID", SqlDbType.Int, 11, Record.TransferID)
		'				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Executed", SqlDbType.Bit, 3, Record.Executed)
		'				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cancelled", SqlDbType.Bit, 3, Record.Cancelled)
		'				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy", SqlDbType.NVarChar, 9, Global.System.Web.HttpContext.Current.Session("LoginID"))
		'				SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn", SqlDbType.DateTime, 21, Now)
		'				Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
		'				Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
		'				Con.Open()
		'				Cmd.ExecuteNonQuery()
		'				_Result = Cmd.Parameters("@RowCount").Value
		'			End Using
		'		End Using
		'	End If
		'	Return _Result
		'End Function
	End Class
End Namespace
