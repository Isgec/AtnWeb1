Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnPunchConfigDetails
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32
    Private _ConfigID As Int32
    Private _FPStartTime As String
    Private _FPEndTime As String
    Private _UseDefined As Boolean
    Private _DefinedTime As String
    Private _SPStartTime As String
    Private _SPEndTime As String
    Private _CalculateHours As Boolean
    Private _HoursStatus As String
    Private _HoursValue As String
    Private _LimitedAllowed As Boolean
    Private _LimitCount As String
    Private _LimitPunchStatus As String
    Private _NormalPunchStatus As String
    Private _LimitedLeaveTypes As String
    Private _NormalLeaveTypes As String
    Private _ExceptionRule As Boolean
    Private _ConfigStatus As String
    Private _ConfigIDATN_PunchConfig As SIS.ATN.atnPunchConfig
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property ConfigID() As Int32
      Get
        Return _ConfigID
      End Get
      Set(ByVal value As Int32)
        _ConfigID = value
      End Set
    End Property
    Public Property FPStartTime() As String
      Get
        Return _FPStartTime
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FPStartTime = ""
				 Else
					 _FPStartTime = value
			   End If
      End Set
    End Property
    Public Property FPEndTime() As String
      Get
        Return _FPEndTime
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FPEndTime = ""
				 Else
					 _FPEndTime = value
			   End If
      End Set
    End Property
    Public Property UseDefined() As Boolean
      Get
        Return _UseDefined
      End Get
      Set(ByVal value As Boolean)
        _UseDefined = value
      End Set
    End Property
    Public Property DefinedTime() As String
      Get
        Return _DefinedTime
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DefinedTime = ""
				 Else
					 _DefinedTime = value
			   End If
      End Set
    End Property
    Public Property SPStartTime() As String
      Get
        Return _SPStartTime
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SPStartTime = ""
				 Else
					 _SPStartTime = value
			   End If
      End Set
    End Property
    Public Property SPEndTime() As String
      Get
        Return _SPEndTime
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SPEndTime = ""
				 Else
					 _SPEndTime = value
			   End If
      End Set
    End Property
    Public Property CalculateHours() As Boolean
      Get
        Return _CalculateHours
      End Get
      Set(ByVal value As Boolean)
        _CalculateHours = value
      End Set
    End Property
    Public Property HoursStatus() As String
      Get
        Return _HoursStatus
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _HoursStatus = ""
				 Else
					 _HoursStatus = value
			   End If
      End Set
    End Property
    Public Property HoursValue() As String
      Get
        Return _HoursValue
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _HoursValue = ""
				 Else
					 _HoursValue = value
			   End If
      End Set
    End Property
    Public Property LimitedAllowed() As Boolean
      Get
        Return _LimitedAllowed
      End Get
      Set(ByVal value As Boolean)
        _LimitedAllowed = value
      End Set
    End Property
    Public Property LimitCount() As String
      Get
        Return _LimitCount
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LimitCount = ""
				 Else
					 _LimitCount = value
			   End If
      End Set
    End Property
    Public Property LimitPunchStatus() As String
      Get
        Return _LimitPunchStatus
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LimitPunchStatus = ""
				 Else
					 _LimitPunchStatus = value
			   End If
      End Set
    End Property
    Public Property NormalPunchStatus() As String
      Get
        Return _NormalPunchStatus
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _NormalPunchStatus = ""
				 Else
					 _NormalPunchStatus = value
			   End If
      End Set
    End Property
    Public Property LimitedLeaveTypes() As String
      Get
        Return _LimitedLeaveTypes
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LimitedLeaveTypes = ""
				 Else
					 _LimitedLeaveTypes = value
			   End If
      End Set
    End Property
    Public Property NormalLeaveTypes() As String
      Get
        Return _NormalLeaveTypes
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _NormalLeaveTypes = ""
				 Else
					 _NormalLeaveTypes = value
			   End If
      End Set
    End Property
    Public Property ExceptionRule() As Boolean
      Get
        Return _ExceptionRule
      End Get
      Set(ByVal value As Boolean)
        _ExceptionRule = value
      End Set
    End Property
    Public Property ConfigStatus() As String
      Get
        Return _ConfigStatus
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ConfigStatus = ""
				 Else
					 _ConfigStatus = value
			   End If
      End Set
    End Property
    Public ReadOnly Property ConfigIDATN_PunchConfig() As SIS.ATN.atnPunchConfig
      Get
        If _ConfigIDATN_PunchConfig Is Nothing Then
          _ConfigIDATN_PunchConfig = SIS.ATN.atnPunchConfig.GetByID(_ConfigID)
        End If
        Return _ConfigIDATN_PunchConfig
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SerialNo As Int32) As SIS.ATN.atnPunchConfigDetails
      Dim Results As SIS.ATN.atnPunchConfigDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnPunchConfigDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SerialNo As Int32, ByVal ConfigID As Int32) As SIS.ATN.atnPunchConfigDetails
      Return GetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByConfigID(ByVal ConfigID As Int32, ByVal OrderBy as String) As List(Of SIS.ATN.atnPunchConfigDetails)
      Dim Results As List(Of SIS.ATN.atnPunchConfigDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigDetailsSelectByConfigID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigID",SqlDbType.Int,ConfigID.ToString.Length, ConfigID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnPunchConfigDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnPunchConfigDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ConfigID As Int32) As List(Of SIS.ATN.atnPunchConfigDetails)
      Dim Results As List(Of SIS.ATN.atnPunchConfigDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnPunchConfigDetailsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnPunchConfigDetailsSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ConfigID",SqlDbType.Int,10, IIf(ConfigID = Nothing, 0,ConfigID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnPunchConfigDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnPunchConfigDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnPunchConfigDetails) As Int32
      Dim _Result As Int32 = Record.SerialNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigID",SqlDbType.Int,11, Record.ConfigID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FPStartTime",SqlDbType.Decimal,9, Iif(Record.FPStartTime= "" ,Convert.DBNull, Record.FPStartTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FPEndTime",SqlDbType.Decimal,9, Iif(Record.FPEndTime= "" ,Convert.DBNull, Record.FPEndTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseDefined",SqlDbType.Bit,3, Record.UseDefined)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefinedTime",SqlDbType.Decimal,9, Iif(Record.DefinedTime= "" ,Convert.DBNull, Record.DefinedTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPStartTime",SqlDbType.Decimal,9, Iif(Record.SPStartTime= "" ,Convert.DBNull, Record.SPStartTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPEndTime",SqlDbType.Decimal,9, Iif(Record.SPEndTime= "" ,Convert.DBNull, Record.SPEndTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculateHours",SqlDbType.Bit,3, Record.CalculateHours)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoursStatus",SqlDbType.NVarChar,3, Iif(Record.HoursStatus= "" ,Convert.DBNull, Record.HoursStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoursValue",SqlDbType.Decimal,9, Iif(Record.HoursValue= "" ,Convert.DBNull, Record.HoursValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitedAllowed",SqlDbType.Bit,3, Record.LimitedAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitCount",SqlDbType.Int,11, Iif(Record.LimitCount= "" ,Convert.DBNull, Record.LimitCount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitPunchStatus",SqlDbType.NVarChar,3, Iif(Record.LimitPunchStatus= "" ,Convert.DBNull, Record.LimitPunchStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NormalPunchStatus",SqlDbType.NVarChar,3, Iif(Record.NormalPunchStatus= "" ,Convert.DBNull, Record.NormalPunchStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitedLeaveTypes",SqlDbType.NVarChar,101, Iif(Record.LimitedLeaveTypes= "" ,Convert.DBNull, Record.LimitedLeaveTypes))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NormalLeaveTypes",SqlDbType.NVarChar,101, Iif(Record.NormalLeaveTypes= "" ,Convert.DBNull, Record.NormalLeaveTypes))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExceptionRule",SqlDbType.Bit,3, Record.ExceptionRule)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigStatus",SqlDbType.NVarChar,3, Iif(Record.ConfigStatus= "" ,Convert.DBNull, Record.ConfigStatus))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnPunchConfigDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigID",SqlDbType.Int,11, Record.ConfigID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FPStartTime",SqlDbType.Decimal,9, Iif(Record.FPStartTime= "" ,Convert.DBNull, Record.FPStartTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FPEndTime",SqlDbType.Decimal,9, Iif(Record.FPEndTime= "" ,Convert.DBNull, Record.FPEndTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseDefined",SqlDbType.Bit,3, Record.UseDefined)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefinedTime",SqlDbType.Decimal,9, Iif(Record.DefinedTime= "" ,Convert.DBNull, Record.DefinedTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPStartTime",SqlDbType.Decimal,9, Iif(Record.SPStartTime= "" ,Convert.DBNull, Record.SPStartTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPEndTime",SqlDbType.Decimal,9, Iif(Record.SPEndTime= "" ,Convert.DBNull, Record.SPEndTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculateHours",SqlDbType.Bit,3, Record.CalculateHours)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoursStatus",SqlDbType.NVarChar,3, Iif(Record.HoursStatus= "" ,Convert.DBNull, Record.HoursStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoursValue",SqlDbType.Decimal,9, Iif(Record.HoursValue= "" ,Convert.DBNull, Record.HoursValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitedAllowed",SqlDbType.Bit,3, Record.LimitedAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitCount",SqlDbType.Int,11, Iif(Record.LimitCount= "" ,Convert.DBNull, Record.LimitCount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitPunchStatus",SqlDbType.NVarChar,3, Iif(Record.LimitPunchStatus= "" ,Convert.DBNull, Record.LimitPunchStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NormalPunchStatus",SqlDbType.NVarChar,3, Iif(Record.NormalPunchStatus= "" ,Convert.DBNull, Record.NormalPunchStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LimitedLeaveTypes",SqlDbType.NVarChar,101, Iif(Record.LimitedLeaveTypes= "" ,Convert.DBNull, Record.LimitedLeaveTypes))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NormalLeaveTypes",SqlDbType.NVarChar,101, Iif(Record.NormalLeaveTypes= "" ,Convert.DBNull, Record.NormalLeaveTypes))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExceptionRule",SqlDbType.Bit,3, Record.ExceptionRule)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigStatus",SqlDbType.NVarChar,3, Iif(Record.ConfigStatus= "" ,Convert.DBNull, Record.ConfigStatus))
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
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnPunchConfigDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ConfigID As Int32) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _ConfigID = Ctype(Reader("ConfigID"),Int32)
      If Convert.IsDBNull(Reader("FPStartTime")) Then
        _FPStartTime = String.Empty
      Else
        _FPStartTime = Ctype(Reader("FPStartTime"), String)
      End If
      If Convert.IsDBNull(Reader("FPEndTime")) Then
        _FPEndTime = String.Empty
      Else
        _FPEndTime = Ctype(Reader("FPEndTime"), String)
      End If
      _UseDefined = Ctype(Reader("UseDefined"),Boolean)
      If Convert.IsDBNull(Reader("DefinedTime")) Then
        _DefinedTime = String.Empty
      Else
        _DefinedTime = Ctype(Reader("DefinedTime"), String)
      End If
      If Convert.IsDBNull(Reader("SPStartTime")) Then
        _SPStartTime = String.Empty
      Else
        _SPStartTime = Ctype(Reader("SPStartTime"), String)
      End If
      If Convert.IsDBNull(Reader("SPEndTime")) Then
        _SPEndTime = String.Empty
      Else
        _SPEndTime = Ctype(Reader("SPEndTime"), String)
      End If
      _CalculateHours = Ctype(Reader("CalculateHours"),Boolean)
      If Convert.IsDBNull(Reader("HoursStatus")) Then
        _HoursStatus = String.Empty
      Else
        _HoursStatus = Ctype(Reader("HoursStatus"), String)
      End If
      If Convert.IsDBNull(Reader("HoursValue")) Then
        _HoursValue = String.Empty
      Else
        _HoursValue = Ctype(Reader("HoursValue"), String)
      End If
      _LimitedAllowed = Ctype(Reader("LimitedAllowed"),Boolean)
      If Convert.IsDBNull(Reader("LimitCount")) Then
        _LimitCount = String.Empty
      Else
        _LimitCount = Ctype(Reader("LimitCount"), String)
      End If
      If Convert.IsDBNull(Reader("LimitPunchStatus")) Then
        _LimitPunchStatus = String.Empty
      Else
        _LimitPunchStatus = Ctype(Reader("LimitPunchStatus"), String)
      End If
      If Convert.IsDBNull(Reader("NormalPunchStatus")) Then
        _NormalPunchStatus = String.Empty
      Else
        _NormalPunchStatus = Ctype(Reader("NormalPunchStatus"), String)
      End If
      If Convert.IsDBNull(Reader("LimitedLeaveTypes")) Then
        _LimitedLeaveTypes = String.Empty
      Else
        _LimitedLeaveTypes = Ctype(Reader("LimitedLeaveTypes"), String)
      End If
      If Convert.IsDBNull(Reader("NormalLeaveTypes")) Then
        _NormalLeaveTypes = String.Empty
      Else
        _NormalLeaveTypes = Ctype(Reader("NormalLeaveTypes"), String)
      End If
      _ExceptionRule = Ctype(Reader("ExceptionRule"),Boolean)
      If Convert.IsDBNull(Reader("ConfigStatus")) Then
        _ConfigStatus = String.Empty
      Else
        _ConfigStatus = Ctype(Reader("ConfigStatus"), String)
      End If
      _ConfigIDATN_PunchConfig = New SIS.ATN.atnPunchConfig("ATN_PunchConfig1",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader(AliasName & "_SerialNo"),Int32)
      _ConfigID = Ctype(Reader(AliasName & "_ConfigID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_FPStartTime")) Then
        _FPStartTime = String.Empty
      Else
        _FPStartTime = Ctype(Reader(AliasName & "_FPStartTime"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_FPEndTime")) Then
        _FPEndTime = String.Empty
      Else
        _FPEndTime = Ctype(Reader(AliasName & "_FPEndTime"), String)
      End If
      _UseDefined = Ctype(Reader(AliasName & "_UseDefined"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_DefinedTime")) Then
        _DefinedTime = String.Empty
      Else
        _DefinedTime = Ctype(Reader(AliasName & "_DefinedTime"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_SPStartTime")) Then
        _SPStartTime = String.Empty
      Else
        _SPStartTime = Ctype(Reader(AliasName & "_SPStartTime"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_SPEndTime")) Then
        _SPEndTime = String.Empty
      Else
        _SPEndTime = Ctype(Reader(AliasName & "_SPEndTime"), String)
      End If
      _CalculateHours = Ctype(Reader(AliasName & "_CalculateHours"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_HoursStatus")) Then
        _HoursStatus = String.Empty
      Else
        _HoursStatus = Ctype(Reader(AliasName & "_HoursStatus"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_HoursValue")) Then
        _HoursValue = String.Empty
      Else
        _HoursValue = Ctype(Reader(AliasName & "_HoursValue"), String)
      End If
      _LimitedAllowed = Ctype(Reader(AliasName & "_LimitedAllowed"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_LimitCount")) Then
        _LimitCount = String.Empty
      Else
        _LimitCount = Ctype(Reader(AliasName & "_LimitCount"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_LimitPunchStatus")) Then
        _LimitPunchStatus = String.Empty
      Else
        _LimitPunchStatus = Ctype(Reader(AliasName & "_LimitPunchStatus"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_NormalPunchStatus")) Then
        _NormalPunchStatus = String.Empty
      Else
        _NormalPunchStatus = Ctype(Reader(AliasName & "_NormalPunchStatus"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_LimitedLeaveTypes")) Then
        _LimitedLeaveTypes = String.Empty
      Else
        _LimitedLeaveTypes = Ctype(Reader(AliasName & "_LimitedLeaveTypes"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_NormalLeaveTypes")) Then
        _NormalLeaveTypes = String.Empty
      Else
        _NormalLeaveTypes = Ctype(Reader(AliasName & "_NormalLeaveTypes"), String)
      End If
      _ExceptionRule = Ctype(Reader(AliasName & "_ExceptionRule"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ConfigStatus")) Then
        _ConfigStatus = String.Empty
      Else
        _ConfigStatus = Ctype(Reader(AliasName & "_ConfigStatus"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
