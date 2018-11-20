Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnBalanceTransfer
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32
    Private _TranType As String = ""
    Private _SubTranType As String = ""
    Private _FinYear As String = ""
    Private _LeaveTypeID As String = ""
    Private _CardNo As String = ""
    Private _TranDate As String = ""
    Private _Days As Decimal
    Private _Remarks As String = ""
    Public Property RecordID() As Int32
      Get
        Return _RecordID
      End Get
      Set(ByVal value As Int32)
        _RecordID = value
      End Set
    End Property
    Public Property TranType() As String
      Get
        Return _TranType
      End Get
      Set(ByVal value As String)
        _TranType = value
      End Set
    End Property
    Public Property SubTranType() As String
      Get
        Return _SubTranType
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SubTranType = ""
				 Else
					 _SubTranType = value
			   End If
      End Set
    End Property
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
      End Set
    End Property
    Public Property LeaveTypeID() As String
      Get
        Return _LeaveTypeID
      End Get
      Set(ByVal value As String)
        _LeaveTypeID = value
      End Set
    End Property
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property TranDate() As String
      Get
        If Not _TranDate = String.Empty Then
          Return Convert.ToDateTime(_TranDate).ToString("dd/MM/yyyy")
        End If
        Return _TranDate
      End Get
      Set(ByVal value As String)
			   _TranDate = value
      End Set
    End Property
    Public Property Days() As Decimal
      Get
        Return _Days
      End Get
      Set(ByVal value As Decimal)
        _Days = value
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Remarks = ""
				 Else
					 _Remarks = value
			   End If
      End Set
    End Property
    Public Property DisplayField() As String
      Get
        Return ""
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property PrimaryKey() As String
      Get
        Return _TranType & "|" & _SubTranType & "|" & _FinYear & "|" & _LeaveTypeID & "|" & _CardNo
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ATN.atnBalanceTransfer
      Dim Results As SIS.ATN.atnBalanceTransfer = Nothing
      Results = New SIS.ATN.atnBalanceTransfer()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal TranType As String, ByVal SubTranType As String, ByVal FinYear As String, ByVal LeaveTypeID As String, ByVal CardNo As String) As SIS.ATN.atnBalanceTransfer
      Dim Results As SIS.ATN.atnBalanceTransfer = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnBalanceTransferSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType",SqlDbType.NVarChar,TranType.ToString.Length, TranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubTranType",SqlDbType.NVarChar,SubTranType.ToString.Length, SubTranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID",SqlDbType.NVarChar,LeaveTypeID.ToString.Length, LeaveTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnBalanceTransfer(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnBalanceTransfer) As String
      Dim _Result As String = Record.TranType
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnBalanceTransferInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType",SqlDbType.NVarChar,4, Record.TranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubTranType",SqlDbType.NVarChar,4, Iif(Record.SubTranType= "" ,Convert.DBNull, Record.SubTranType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID",SqlDbType.NVarChar,3, Record.LeaveTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate",SqlDbType.DateTime,21, Record.TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Days",SqlDbType.Decimal,9, Record.Days)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,257, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          Cmd.Parameters.Add("@Return_TranType", SqlDbType.NVarChar, 3)
          Cmd.Parameters("@Return_TranType").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_TranType").Value
        End Using
      End Using
      Return _Result
    End Function
		<DataObjectMethod(DataObjectMethodType.Update, True)> _
		Public Shared Function MonthlyCreditUpdate(ByVal Record As SIS.ATN.atnBalanceTransfer) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnBalanceTransferMonthlyCreditUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID", SqlDbType.Int, 11, Record.RecordID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TranType", SqlDbType.NVarChar, 4, Record.TranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SubTranType", SqlDbType.NVarChar, 4, Record.SubTranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear", SqlDbType.NVarChar, 5, Record.FinYear)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveTypeID", SqlDbType.NVarChar, 3, Record.LeaveTypeID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, Record.TranDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Days", SqlDbType.Decimal, 9, Record.Days)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 257, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return _Result
		End Function
		Public Shared Function Update(ByVal Record As SIS.ATN.atnBalanceTransfer) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnBalanceTransferUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID", SqlDbType.Int, 11, Record.RecordID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TranType", SqlDbType.NVarChar, 4, Record.TranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SubTranType", SqlDbType.NVarChar, 4, Record.SubTranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear", SqlDbType.NVarChar, 5, Record.FinYear)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveTypeID", SqlDbType.NVarChar, 3, Record.LeaveTypeID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, Record.TranDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Days", SqlDbType.Decimal, 9, Record.Days)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 257, Iif(Record.Remarks = "", Convert.DBNull, Record.Remarks))
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return _Result
		End Function
		<DataObjectMethod(DataObjectMethodType.Delete, True)> _
		Public Shared Function Delete(ByVal Record As SIS.ATN.atnBalanceTransfer) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnBalanceTransferDelete"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TranType", SqlDbType.NVarChar, Record.TranType.ToString.Length, Record.TranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SubTranType", SqlDbType.NVarChar, Record.SubTranType.ToString.Length, Record.SubTranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear", SqlDbType.NVarChar, Record.FinYear.ToString.Length, Record.FinYear)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveTypeID", SqlDbType.NVarChar, Record.LeaveTypeID.ToString.Length, Record.LeaveTypeID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, Record.CardNo.ToString.Length, Record.CardNo)
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return _Result
		End Function
		Public Shared Function GetOPBRecordForMonth(ByVal CardNo As String, ByVal ForMonth As Integer) As SIS.ATN.atnBalanceTransfer
			Dim Results As SIS.ATN.atnBalanceTransfer = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_GetOPBRecordForMonth"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.Int, 3, ForMonth)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubTranType", SqlDbType.NVarChar, 2, "MC")
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					_RecordCount = -1
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results = New SIS.ATN.atnBalanceTransfer(Reader)
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
			Return _RecordCount
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader("RecordID"),Int32)
      _TranType = Ctype(Reader("TranType"),String)
      If Convert.IsDBNull(Reader("SubTranType")) Then
        _SubTranType = String.Empty
      Else
        _SubTranType = Ctype(Reader("SubTranType"), String)
      End If
      _FinYear = Ctype(Reader("FinYear"),String)
      _LeaveTypeID = Ctype(Reader("LeaveTypeID"),String)
      _CardNo = Ctype(Reader("CardNo"),String)
      _TranDate = Ctype(Reader("TranDate"),DateTime)
      _Days = Ctype(Reader("Days"),Decimal)
      If Convert.IsDBNull(Reader("Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader("Remarks"), String)
      End If
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader(AliasName & "_RecordID"),Int32)
      _TranType = Ctype(Reader(AliasName & "_TranType"),String)
      If Convert.IsDBNull(Reader(AliasName & "_SubTranType")) Then
        _SubTranType = String.Empty
      Else
        _SubTranType = Ctype(Reader(AliasName & "_SubTranType"), String)
      End If
      _FinYear = Ctype(Reader(AliasName & "_FinYear"),String)
      _LeaveTypeID = Ctype(Reader(AliasName & "_LeaveTypeID"),String)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      _TranDate = Ctype(Reader(AliasName & "_TranDate"),DateTime)
      _Days = Ctype(Reader(AliasName & "_Days"),Decimal)
      If Convert.IsDBNull(Reader(AliasName & "_Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader(AliasName & "_Remarks"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
