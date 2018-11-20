Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnLeaveTypes
    Private Shared _RecordCount As Integer
    Private _LeaveTypeID As String
    Private _Description As String
    Private _OBALApplicable As Boolean
    Private _OBALMonthly As Boolean
    Private _OpeningBalance As String
    Private _CarryForward As Boolean
    Private _ForwardToLeaveTypeID As String
    Private _AdvanceApplicable As Boolean
    Private _SpecialSanctionRequired As Boolean
    Private _SpecialSanctionBy As String
    Private _Applyiable As Boolean
    Private _Postable As Boolean
    Private _PostedLeaveTypeID As String
    Private _Sequence As String
    Private _MainType As Boolean
    Private _ForwardToLeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _SpecialSanctionByHRM_Employees As SIS.ATN.atnEmployees
    Private _SpecialSanctionByEmployeeName As String
    Private _PostedLeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Public Property LeaveTypeID() As String
      Get
        Return _LeaveTypeID
      End Get
      Set(ByVal value As String)
        _LeaveTypeID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property OBALApplicable() As Boolean
      Get
        Return _OBALApplicable
      End Get
      Set(ByVal value As Boolean)
        _OBALApplicable = value
      End Set
    End Property
    Public Property OBALMonthly() As Boolean
      Get
        Return _OBALMonthly
      End Get
      Set(ByVal value As Boolean)
        _OBALMonthly = value
      End Set
    End Property
    Public Property OpeningBalance() As String
      Get
        Return _OpeningBalance
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OpeningBalance = ""
				 Else
					 _OpeningBalance = value
			   End If
      End Set
    End Property
    Public Property CarryForward() As Boolean
      Get
        Return _CarryForward
      End Get
      Set(ByVal value As Boolean)
        _CarryForward = value
      End Set
    End Property
    Public Property ForwardToLeaveTypeID() As String
      Get
        Return _ForwardToLeaveTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ForwardToLeaveTypeID = ""
				 Else
					 _ForwardToLeaveTypeID = value
			   End If
      End Set
    End Property
    Public Property AdvanceApplicable() As Boolean
      Get
        Return _AdvanceApplicable
      End Get
      Set(ByVal value As Boolean)
        _AdvanceApplicable = value
      End Set
    End Property
    Public Property SpecialSanctionRequired() As Boolean
      Get
        Return _SpecialSanctionRequired
      End Get
      Set(ByVal value As Boolean)
        _SpecialSanctionRequired = value
      End Set
    End Property
    Public Property SpecialSanctionBy() As String
      Get
        Return _SpecialSanctionBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SpecialSanctionBy = ""
				 Else
					 _SpecialSanctionBy = value
			   End If
      End Set
    End Property
    Public Property Applyiable() As Boolean
      Get
        Return _Applyiable
      End Get
      Set(ByVal value As Boolean)
        _Applyiable = value
      End Set
    End Property
    Public Property Postable() As Boolean
      Get
        Return _Postable
      End Get
      Set(ByVal value As Boolean)
        _Postable = value
      End Set
    End Property
    Public Property PostedLeaveTypeID() As String
      Get
        Return _PostedLeaveTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PostedLeaveTypeID = ""
				 Else
					 _PostedLeaveTypeID = value
			   End If
      End Set
    End Property
    Public Property Sequence() As String
      Get
        Return _Sequence
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Sequence = ""
				 Else
					 _Sequence = value
			   End If
      End Set
    End Property
    Public Property MainType() As Boolean
      Get
        Return _MainType
      End Get
      Set(ByVal value As Boolean)
        _MainType = value
      End Set
    End Property
    Public ReadOnly Property ForwardToLeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _ForwardToLeaveTypeIDATN_LeaveTypes Is Nothing Then
          _ForwardToLeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_ForwardToLeaveTypeID)
        End If
        Return _ForwardToLeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    Public ReadOnly Property SpecialSanctionByHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _SpecialSanctionByHRM_Employees Is Nothing Then
          _SpecialSanctionByHRM_Employees = SIS.ATN.atnEmployees.GetByID(_SpecialSanctionBy)
        End If
        Return _SpecialSanctionByHRM_Employees
      End Get
    End Property
    Public Property SpecialSanctionByEmployeeName() As String
      Get
        Return _SpecialSanctionByEmployeeName
      End Get
      Set(ByVal value As String)
        _SpecialSanctionByEmployeeName = value
      End Set
    End Property
    Public ReadOnly Property PostedLeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _PostedLeaveTypeIDATN_LeaveTypes Is Nothing Then
          _PostedLeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_PostedLeaveTypeID)
        End If
        Return _PostedLeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ATN.atnLeaveTypes)
      Dim Results As List(Of SIS.ATN.atnLeaveTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "Sequence"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveTypesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnLeaveTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnLeaveTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveTypeID As String) As SIS.ATN.atnLeaveTypes
      Dim Results As SIS.ATN.atnLeaveTypes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveTypesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID",SqlDbType.NVarChar,LeaveTypeID.ToString.Length, LeaveTypeID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnLeaveTypes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnLeaveTypes)
      Dim Results As List(Of SIS.ATN.atnLeaveTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "Sequence"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnLeaveTypesSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnLeaveTypesSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnLeaveTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnLeaveTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnLeaveTypes) As String
      Dim _Result As String = Record.LeaveTypeID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveTypesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID",SqlDbType.NVarChar,3, Record.LeaveTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,31, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OBALApplicable",SqlDbType.Bit,3, Record.OBALApplicable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OBALMonthly",SqlDbType.Bit,3, Record.OBALMonthly)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OpeningBalance",SqlDbType.Int,11, Iif(Record.OpeningBalance= "" ,Convert.DBNull, Record.OpeningBalance))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CarryForward",SqlDbType.Bit,3, Record.CarryForward)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardToLeaveTypeID",SqlDbType.NVarChar,3, Iif(Record.ForwardToLeaveTypeID= "" ,Convert.DBNull, Record.ForwardToLeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplicable",SqlDbType.Bit,3, Record.AdvanceApplicable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecialSanctionRequired",SqlDbType.Bit,3, Record.SpecialSanctionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecialSanctionBy",SqlDbType.NVarChar,9, Iif(Record.SpecialSanctionBy= "" ,Convert.DBNull, Record.SpecialSanctionBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applyiable",SqlDbType.Bit,3, Record.Applyiable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Postable",SqlDbType.Bit,3, Record.Postable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedLeaveTypeID",SqlDbType.NVarChar,3, Iif(Record.PostedLeaveTypeID= "" ,Convert.DBNull, Record.PostedLeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Iif(Record.Sequence= "" ,Convert.DBNull, Record.Sequence))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainType",SqlDbType.Bit,3, Record.MainType)
          Cmd.Parameters.Add("@Return_LeaveTypeID", SqlDbType.NVarChar, 2)
          Cmd.Parameters("@Return_LeaveTypeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_LeaveTypeID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnLeaveTypes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveTypesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveTypeID",SqlDbType.NVarChar,3, Record.LeaveTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,31, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OBALApplicable",SqlDbType.Bit,3, Record.OBALApplicable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OBALMonthly",SqlDbType.Bit,3, Record.OBALMonthly)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OpeningBalance",SqlDbType.Int,11, Iif(Record.OpeningBalance= "" ,Convert.DBNull, Record.OpeningBalance))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CarryForward",SqlDbType.Bit,3, Record.CarryForward)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardToLeaveTypeID",SqlDbType.NVarChar,3, Iif(Record.ForwardToLeaveTypeID= "" ,Convert.DBNull, Record.ForwardToLeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplicable",SqlDbType.Bit,3, Record.AdvanceApplicable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecialSanctionRequired",SqlDbType.Bit,3, Record.SpecialSanctionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecialSanctionBy",SqlDbType.NVarChar,9, Iif(Record.SpecialSanctionBy= "" ,Convert.DBNull, Record.SpecialSanctionBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applyiable",SqlDbType.Bit,3, Record.Applyiable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Postable",SqlDbType.Bit,3, Record.Postable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedLeaveTypeID",SqlDbType.NVarChar,3, Iif(Record.PostedLeaveTypeID= "" ,Convert.DBNull, Record.PostedLeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Iif(Record.Sequence= "" ,Convert.DBNull, Record.Sequence))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainType",SqlDbType.Bit,3, Record.MainType)
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
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnLeaveTypes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveTypesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveTypeID",SqlDbType.NVarChar,Record.LeaveTypeID.ToString.Length, Record.LeaveTypeID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectatnLeaveTypesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer) As String()
			Dim Results As List(Of String) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnLeaveTypesAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---", ""))
					While (Reader.Read())
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Reader(0), Reader(1)))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _LeaveTypeID = Ctype(Reader("LeaveTypeID"),String)
      _Description = Ctype(Reader("Description"),String)
      _OBALApplicable = Ctype(Reader("OBALApplicable"),Boolean)
      _OBALMonthly = Ctype(Reader("OBALMonthly"),Boolean)
      If Convert.IsDBNull(Reader("OpeningBalance")) Then
        _OpeningBalance = String.Empty
      Else
        _OpeningBalance = Ctype(Reader("OpeningBalance"), String)
      End If
      _CarryForward = Ctype(Reader("CarryForward"),Boolean)
      If Convert.IsDBNull(Reader("ForwardToLeaveTypeID")) Then
        _ForwardToLeaveTypeID = String.Empty
      Else
        _ForwardToLeaveTypeID = Ctype(Reader("ForwardToLeaveTypeID"), String)
      End If
      _AdvanceApplicable = Ctype(Reader("AdvanceApplicable"),Boolean)
      _SpecialSanctionRequired = Ctype(Reader("SpecialSanctionRequired"),Boolean)
      If Convert.IsDBNull(Reader("SpecialSanctionBy")) Then
        _SpecialSanctionBy = String.Empty
      Else
        _SpecialSanctionBy = Ctype(Reader("SpecialSanctionBy"), String)
      End If
      _Applyiable = Ctype(Reader("Applyiable"),Boolean)
      _Postable = Ctype(Reader("Postable"),Boolean)
      If Convert.IsDBNull(Reader("PostedLeaveTypeID")) Then
        _PostedLeaveTypeID = String.Empty
      Else
        _PostedLeaveTypeID = Ctype(Reader("PostedLeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader("Sequence")) Then
        _Sequence = String.Empty
      Else
        _Sequence = Ctype(Reader("Sequence"), String)
      End If
      _MainType = Ctype(Reader("MainType"),Boolean)
      _ForwardToLeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes("ATN_LeaveTypes1",Reader)
      If Convert.IsDBNull(Reader("SpecialSanctionBy")) Then
        _SpecialSanctionByEmployeeName = String.Empty
      Else
        _SpecialSanctionByEmployeeName = Reader("HRM_Employees2_EmployeeName") & " [" & Ctype(Reader("SpecialSanctionBy"), String) & "]"
      End If
      _SpecialSanctionByHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees2",Reader)
      _PostedLeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes("ATN_LeaveTypes3",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _LeaveTypeID = Ctype(Reader(AliasName & "_LeaveTypeID"),String)
      _Description = Ctype(Reader(AliasName & "_Description"),String)
      _OBALApplicable = Ctype(Reader(AliasName & "_OBALApplicable"),Boolean)
      _OBALMonthly = Ctype(Reader(AliasName & "_OBALMonthly"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_OpeningBalance")) Then
        _OpeningBalance = String.Empty
      Else
        _OpeningBalance = Ctype(Reader(AliasName & "_OpeningBalance"), String)
      End If
      _CarryForward = Ctype(Reader(AliasName & "_CarryForward"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ForwardToLeaveTypeID")) Then
        _ForwardToLeaveTypeID = String.Empty
      Else
        _ForwardToLeaveTypeID = Ctype(Reader(AliasName & "_ForwardToLeaveTypeID"), String)
      End If
      _AdvanceApplicable = Ctype(Reader(AliasName & "_AdvanceApplicable"),Boolean)
      _SpecialSanctionRequired = Ctype(Reader(AliasName & "_SpecialSanctionRequired"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_SpecialSanctionBy")) Then
        _SpecialSanctionBy = String.Empty
      Else
        _SpecialSanctionBy = Ctype(Reader(AliasName & "_SpecialSanctionBy"), String)
      End If
      _Applyiable = Ctype(Reader(AliasName & "_Applyiable"),Boolean)
      _Postable = Ctype(Reader(AliasName & "_Postable"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_PostedLeaveTypeID")) Then
        _PostedLeaveTypeID = String.Empty
      Else
        _PostedLeaveTypeID = Ctype(Reader(AliasName & "_PostedLeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Sequence")) Then
        _Sequence = String.Empty
      Else
        _Sequence = Ctype(Reader(AliasName & "_Sequence"), String)
      End If
      _MainType = Ctype(Reader(AliasName & "_MainType"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
