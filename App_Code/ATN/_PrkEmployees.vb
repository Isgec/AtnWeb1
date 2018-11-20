Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PRK
  <DataObject()> _
  Partial Public Class PrkEmployees
    Private Shared _RecordCount As Integer
    Private _EmployeeID As Int32
    Private _CardNo As String
    Private _EmployeeName As String
    Private _CategoryID As Int32
    Private _PostedAt As String
    Private _VehicleType As String
    Private _Basic As Decimal
    Private _ESI As Boolean
    Private _DOJ As String
    Private _DOR As String
    Private _Department As String
    Private _Company As String
    Private _MaintenanceAllowed As Boolean
		Public Property EmployeeID() As Int32
			Get
				Return _EmployeeID
			End Get
			Set(ByVal value As Int32)
				_EmployeeID = value
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
    Public Property EmployeeName() As String
      Get
        Return _EmployeeName
      End Get
      Set(ByVal value As String)
        _EmployeeName = value
      End Set
    End Property
    Public Property CategoryID() As Int32
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As Int32)
        _CategoryID = value
      End Set
    End Property
    Public Property PostedAt() As String
      Get
        Return _PostedAt
      End Get
      Set(ByVal value As String)
        _PostedAt = value
      End Set
    End Property
    Public Property VehicleType() As String
      Get
        Return _VehicleType
      End Get
      Set(ByVal value As String)
        _VehicleType = value
      End Set
    End Property
    Public Property Basic() As Decimal
      Get
        Return _Basic
      End Get
      Set(ByVal value As Decimal)
        _Basic = value
      End Set
    End Property
    Public Property ESI() As Boolean
      Get
        Return _ESI
      End Get
      Set(ByVal value As Boolean)
        _ESI = value
      End Set
    End Property
    Public Property DOJ() As String
      Get
        If Not _DOJ = String.Empty Then
          Return Convert.ToDateTime(_DOJ).ToString("dd/MM/yyyy")
        End If
        Return _DOJ
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DOJ = ""
				 Else
					 _DOJ = value
			   End If
      End Set
    End Property
    Public Property DOR() As String
      Get
        If Not _DOR = String.Empty Then
          Return Convert.ToDateTime(_DOR).ToString("dd/MM/yyyy")
        End If
        Return _DOR
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DOR = ""
				 Else
					 _DOR = value
			   End If
      End Set
    End Property
    Public Property Department() As String
      Get
        Return _Department
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Department = ""
				 Else
					 _Department = value
			   End If
      End Set
    End Property
    Public Property Company() As String
      Get
        Return _Company
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Company = ""
				 Else
					 _Company = value
			   End If
      End Set
    End Property
    Public Property MaintenanceAllowed() As Boolean
      Get
        Return _MaintenanceAllowed
      End Get
      Set(ByVal value As Boolean)
        _MaintenanceAllowed = value
      End Set
    End Property
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.PRK.PrkEmployees)
			Dim Results As List(Of SIS.PRK.PrkEmployees) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spPrkEmployeesSelectList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.PRK.PrkEmployees)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.PRK.PrkEmployees(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal EmployeeID As Int32) As SIS.PRK.PrkEmployees
      Dim Results As SIS.PRK.PrkEmployees = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrkEmployeesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,EmployeeID.ToString.Length, EmployeeID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PRK.PrkEmployees(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCategoryID(ByVal CategoryID As Int32, ByVal OrderBy as String) As List(Of SIS.PRK.PrkEmployees)
      Dim Results As List(Of SIS.PRK.PrkEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrkEmployeesSelectByCategoryID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,CategoryID.ToString.Length, CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PRK.PrkEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PRK.PrkEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectTable(ByVal OrderBy As String) As DataTable
      Dim oDP As SqlDataAdapter = New SqlDataAdapter("spPrkEmployeesSelectTable", SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      oDP.SelectCommand.CommandType = CommandType.StoredProcedure
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(oDP.SelectCommand, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
      Dim oTbl As DataTable = New DataTable
      oDP.Fill(oTbl)
      Return oTbl
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String) As List(Of SIS.PRK.PrkEmployees)
      Dim Results As List(Of SIS.PRK.PrkEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrkEmployeesSelectListPaged"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PRK.PrkEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PRK.PrkEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.PRK.PrkEmployees) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrkEmployeesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeName",SqlDbType.NVarChar,41, Record.EmployeeName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Basic",SqlDbType.Decimal,13, Record.Basic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI",SqlDbType.Bit,3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOJ",SqlDbType.DateTime,21, Iif(Record.DOJ= "" ,Convert.DBNull, Record.DOJ))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOR",SqlDbType.DateTime,21, Iif(Record.DOR= "" ,Convert.DBNull, Record.DOR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Department",SqlDbType.NVarChar,31, Iif(Record.Department= "" ,Convert.DBNull, Record.Department))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Company",SqlDbType.NVarChar,51, Iif(Record.Company= "" ,Convert.DBNull, Record.Company))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintenanceAllowed",SqlDbType.Bit,3, Record.MaintenanceAllowed)
					Cmd.Parameters.Add("@Return_EmployeeID", SqlDbType.Int)
					Cmd.Parameters("@Return_EmployeeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@Return_EmployeeID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.PRK.PrkEmployees) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrkEmployeesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeName",SqlDbType.NVarChar,41, Record.EmployeeName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Basic",SqlDbType.Decimal,13, Record.Basic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI",SqlDbType.Bit,3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOJ",SqlDbType.DateTime,21, Iif(Record.DOJ= "" ,Convert.DBNull, Record.DOJ))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOR",SqlDbType.DateTime,21, Iif(Record.DOR= "" ,Convert.DBNull, Record.DOR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Department",SqlDbType.NVarChar,31, Iif(Record.Department= "" ,Convert.DBNull, Record.Department))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Company",SqlDbType.NVarChar,51, Iif(Record.Company= "" ,Convert.DBNull, Record.Company))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintenanceAllowed",SqlDbType.Bit,3, Record.MaintenanceAllowed)
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
    Public Shared Function Delete(ByVal Record As SIS.PRK.PrkEmployees) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrkEmployeesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EmployeeID",SqlDbType.Int,Record.EmployeeID.ToString.Length, Record.EmployeeID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount() As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _EmployeeID = Ctype(Reader("EmployeeID"),Int32)
      _CardNo = Ctype(Reader("CardNo"),String)
      _EmployeeName = Ctype(Reader("EmployeeName"),String)
      _CategoryID = Ctype(Reader("CategoryID"),Int32)
      _PostedAt = Ctype(Reader("PostedAt"),String)
      _VehicleType = Ctype(Reader("VehicleType"),String)
      _Basic = Ctype(Reader("Basic"),Decimal)
      _ESI = Ctype(Reader("ESI"),Boolean)
      If Convert.IsDBNull(Reader("DOJ")) Then
        _DOJ = String.Empty
      Else
        _DOJ = Ctype(Reader("DOJ"), String)
      End If
      If Convert.IsDBNull(Reader("DOR")) Then
        _DOR = String.Empty
      Else
        _DOR = Ctype(Reader("DOR"), String)
      End If
      If Convert.IsDBNull(Reader("Department")) Then
        _Department = String.Empty
      Else
        _Department = Ctype(Reader("Department"), String)
      End If
      If Convert.IsDBNull(Reader("Company")) Then
        _Company = String.Empty
      Else
        _Company = Ctype(Reader("Company"), String)
      End If
      _MaintenanceAllowed = Ctype(Reader("MaintenanceAllowed"),Boolean)
		End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _EmployeeID = Ctype(Reader(AliasName & "_EmployeeID"),Int32)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      _EmployeeName = Ctype(Reader(AliasName & "_EmployeeName"),String)
      _CategoryID = Ctype(Reader(AliasName & "_CategoryID"),Int32)
      _PostedAt = Ctype(Reader(AliasName & "_PostedAt"),String)
      _VehicleType = Ctype(Reader(AliasName & "_VehicleType"),String)
      _Basic = Ctype(Reader(AliasName & "_Basic"),Decimal)
      _ESI = Ctype(Reader(AliasName & "_ESI"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_DOJ")) Then
        _DOJ = String.Empty
      Else
        _DOJ = Ctype(Reader(AliasName & "_DOJ"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_DOR")) Then
        _DOR = String.Empty
      Else
        _DOR = Ctype(Reader(AliasName & "_DOR"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Department")) Then
        _Department = String.Empty
      Else
        _Department = Ctype(Reader(AliasName & "_Department"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Company")) Then
        _Company = String.Empty
      Else
        _Company = Ctype(Reader(AliasName & "_Company"), String)
      End If
      _MaintenanceAllowed = Ctype(Reader(AliasName & "_MaintenanceAllowed"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
