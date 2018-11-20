Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnLeaveLedger
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32
    Private _TranType As String
    Private _TranDate As String
    Private _CardNo As String
    Private _LeaveTypeID As String
    Private _InProcessDays As Decimal
    Private _Days As Decimal
    Private _FinYear As String
    Private _ApplHeaderID As String
    Private _ApplDetailID As String
    Private _TranTypeATN_TranType As SIS.ATN.atnTranType
    Private _CardNoHRM_Employees As SIS.ATN.atnEmployees
    Private _CardNoEmployeeName As String
    Private _LeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _FinYearATN_FinYear As SIS.ATN.atnFinYear
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
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
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
    Public Property InProcessDays() As Decimal
      Get
        Return _InProcessDays
      End Get
      Set(ByVal value As Decimal)
        _InProcessDays = value
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
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
      End Set
    End Property
    Public Property ApplHeaderID() As String
      Get
        Return _ApplHeaderID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApplHeaderID = ""
				 Else
					 _ApplHeaderID = value
			   End If
      End Set
    End Property
    Public Property ApplDetailID() As String
      Get
        Return _ApplDetailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApplDetailID = ""
				 Else
					 _ApplDetailID = value
			   End If
      End Set
    End Property
    Public ReadOnly Property TranTypeATN_TranType() As SIS.ATN.atnTranType
      Get
        If _TranTypeATN_TranType Is Nothing Then
          _TranTypeATN_TranType = SIS.ATN.atnTranType.GetByID(_TranType)
        End If
        Return _TranTypeATN_TranType
      End Get
    End Property
    Public ReadOnly Property CardNoHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _CardNoHRM_Employees Is Nothing Then
          _CardNoHRM_Employees = SIS.ATN.atnEmployees.GetByID(_CardNo)
        End If
        Return _CardNoHRM_Employees
      End Get
    End Property
    Public Property CardNoEmployeeName() As String
      Get
        Return _CardNoEmployeeName
      End Get
      Set(ByVal value As String)
        _CardNoEmployeeName = value
      End Set
    End Property
    Public ReadOnly Property LeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _LeaveTypeIDATN_LeaveTypes Is Nothing Then
          _LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_LeaveTypeID)
        End If
        Return _LeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    Public ReadOnly Property FinYearATN_FinYear() As SIS.ATN.atnFinYear
      Get
        If _FinYearATN_FinYear Is Nothing Then
          _FinYearATN_FinYear = SIS.ATN.atnFinYear.GetByID(_FinYear)
        End If
        Return _FinYearATN_FinYear
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal RecordID As Int32) As SIS.ATN.atnLeaveLedger
      Dim Results As SIS.ATN.atnLeaveLedger = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveLedgerSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnLeaveLedger(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal RecordID As Int32, ByVal CardNo As String) As SIS.ATN.atnLeaveLedger
      Return GetByID(RecordID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCardNo(ByVal CardNo As String, ByVal OrderBy as String) As List(Of SIS.ATN.atnLeaveLedger)
      Dim Results As List(Of SIS.ATN.atnLeaveLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveLedgerSelectByCardNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnLeaveLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnLeaveLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnLeaveLedger)
      Dim Results As List(Of SIS.ATN.atnLeaveLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnLeaveLedgerSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnLeaveLedgerSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnLeaveLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnLeaveLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnLeaveLedger) As Int32
      Dim _Result As Int32 = Record.RecordID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveLedgerInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType",SqlDbType.NVarChar,4, Record.TranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID",SqlDbType.NVarChar,3, Record.LeaveTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InProcessDays",SqlDbType.Decimal,9, Record.InProcessDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Days",SqlDbType.Decimal,9, Record.Days)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID",SqlDbType.Int,11, Iif(Record.ApplHeaderID= "" ,Convert.DBNull, Record.ApplHeaderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplDetailID",SqlDbType.Int,11, Iif(Record.ApplDetailID= "" ,Convert.DBNull, Record.ApplDetailID))
          Cmd.Parameters.Add("@Return_RecordID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_RecordID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_RecordID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnLeaveLedger) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveLedgerUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType",SqlDbType.NVarChar,4, Record.TranType)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, Now)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID",SqlDbType.NVarChar,3, Record.LeaveTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InProcessDays",SqlDbType.Decimal,9, Record.InProcessDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Days",SqlDbType.Decimal,9, Record.Days)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID",SqlDbType.Int,11, Iif(Record.ApplHeaderID= "" ,Convert.DBNull, Record.ApplHeaderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplDetailID",SqlDbType.Int,11, Iif(Record.ApplDetailID= "" ,Convert.DBNull, Record.ApplDetailID))
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
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnLeaveLedger) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveLedgerDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,Record.RecordID.ToString.Length, Record.RecordID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader("RecordID"),Int32)
      _TranType = Ctype(Reader("TranType"),String)
      _TranDate = Ctype(Reader("TranDate"),DateTime)
      _CardNo = Ctype(Reader("CardNo"),String)
      _LeaveTypeID = Ctype(Reader("LeaveTypeID"),String)
      _InProcessDays = Ctype(Reader("InProcessDays"),Decimal)
      _Days = Ctype(Reader("Days"),Decimal)
      _FinYear = Ctype(Reader("FinYear"),String)
      If Convert.IsDBNull(Reader("ApplHeaderID")) Then
        _ApplHeaderID = String.Empty
      Else
        _ApplHeaderID = Ctype(Reader("ApplHeaderID"), String)
      End If
      If Convert.IsDBNull(Reader("ApplDetailID")) Then
        _ApplDetailID = String.Empty
      Else
        _ApplDetailID = Ctype(Reader("ApplDetailID"), String)
      End If
      _TranTypeATN_TranType = New SIS.ATN.atnTranType("ATN_TranType1",Reader)
      _CardNoEmployeeName = Reader("HRM_Employees2_EmployeeName") & " [" & Ctype(Reader("CardNo"), String) & "]"
      _CardNoHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees2",Reader)
      _LeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes("ATN_LeaveTypes3",Reader)
      _FinYearATN_FinYear = New SIS.ATN.atnFinYear("ATN_FinYear4",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader(AliasName & "_RecordID"),Int32)
      _TranType = Ctype(Reader(AliasName & "_TranType"),String)
      _TranDate = Ctype(Reader(AliasName & "_TranDate"),DateTime)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      _LeaveTypeID = Ctype(Reader(AliasName & "_LeaveTypeID"),String)
      _InProcessDays = Ctype(Reader(AliasName & "_InProcessDays"),Decimal)
      _Days = Ctype(Reader(AliasName & "_Days"),Decimal)
      _FinYear = Ctype(Reader(AliasName & "_FinYear"),String)
      If Convert.IsDBNull(Reader(AliasName & "_ApplHeaderID")) Then
        _ApplHeaderID = String.Empty
      Else
        _ApplHeaderID = Ctype(Reader(AliasName & "_ApplHeaderID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ApplDetailID")) Then
        _ApplDetailID = String.Empty
      Else
        _ApplDetailID = Ctype(Reader(AliasName & "_ApplDetailID"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
