Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnApproverChangeRequest
    Private Shared _RecordCount As Integer
    Private _RequestID As Int32
    Private _UserID As String
    Private _VerificationRequired As Boolean
    Private _VerifierID As String
    Private _ApprovalRequired As Boolean
    Private _ApproverID As String
    Private _Requested As Boolean
    Private _RequestedOn As String
    Private _Executed As Boolean
    Private _ExecutedOn As String
    Private _UserIDHRM_Employees As SIS.ATN.atnEmployees
    Private _VerifierIDHRM_Employees As SIS.ATN.atnEmployees
    Private _VerifierIDEmployeeName As String
    Private _ApproverIDHRM_Employees As SIS.ATN.atnEmployees
    Private _ApproverIDEmployeeName As String
    Public Property RequestID() As Int32
      Get
        Return _RequestID
      End Get
      Set(ByVal value As Int32)
        _RequestID = value
      End Set
    End Property
    Public Property UserID() As String
      Get
        Return _UserID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UserID = ""
				 Else
					 _UserID = value
			   End If
      End Set
    End Property
    Public Property VerificationRequired() As Boolean
      Get
        Return _VerificationRequired
      End Get
      Set(ByVal value As Boolean)
        _VerificationRequired = value
      End Set
    End Property
    Public Property VerifierID() As String
      Get
        Return _VerifierID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VerifierID = ""
				 Else
					 _VerifierID = value
			   End If
      End Set
    End Property
    Public Property ApprovalRequired() As Boolean
      Get
        Return _ApprovalRequired
      End Get
      Set(ByVal value As Boolean)
        _ApprovalRequired = value
      End Set
    End Property
    Public Property ApproverID() As String
      Get
        Return _ApproverID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApproverID = ""
				 Else
					 _ApproverID = value
			   End If
      End Set
    End Property
    Public Property Requested() As Boolean
      Get
        Return _Requested
      End Get
      Set(ByVal value As Boolean)
        _Requested = value
      End Set
    End Property
    Public Property RequestedOn() As String
      Get
        If Not _RequestedOn = String.Empty Then
          Return Convert.ToDateTime(_RequestedOn).ToString("dd/MM/yyyy")
        End If
        Return _RequestedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RequestedOn = ""
				 Else
					 _RequestedOn = value
			   End If
      End Set
    End Property
    Public Property Executed() As Boolean
      Get
        Return _Executed
      End Get
      Set(ByVal value As Boolean)
        _Executed = value
      End Set
    End Property
    Public Property ExecutedOn() As String
      Get
        If Not _ExecutedOn = String.Empty Then
          Return Convert.ToDateTime(_ExecutedOn).ToString("dd/MM/yyyy")
        End If
        Return _ExecutedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExecutedOn = ""
				 Else
					 _ExecutedOn = value
			   End If
      End Set
    End Property
    Public ReadOnly Property UserIDHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _UserIDHRM_Employees Is Nothing Then
          _UserIDHRM_Employees = SIS.ATN.atnEmployees.GetByID(_UserID)
        End If
        Return _UserIDHRM_Employees
      End Get
    End Property
    Public ReadOnly Property VerifierIDHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _VerifierIDHRM_Employees Is Nothing Then
          _VerifierIDHRM_Employees = SIS.ATN.atnEmployees.GetByID(_VerifierID)
        End If
        Return _VerifierIDHRM_Employees
      End Get
    End Property
    Public Property VerifierIDEmployeeName() As String
      Get
        Return _VerifierIDEmployeeName
      End Get
      Set(ByVal value As String)
        _VerifierIDEmployeeName = value
      End Set
    End Property
    Public ReadOnly Property ApproverIDHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _ApproverIDHRM_Employees Is Nothing Then
          _ApproverIDHRM_Employees = SIS.ATN.atnEmployees.GetByID(_ApproverID)
        End If
        Return _ApproverIDHRM_Employees
      End Get
    End Property
    Public Property ApproverIDEmployeeName() As String
      Get
        Return _ApproverIDEmployeeName
      End Get
      Set(ByVal value As String)
        _ApproverIDEmployeeName = value
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal RequestID As Int32) As SIS.ATN.atnApproverChangeRequest
      Dim Results As SIS.ATN.atnApproverChangeRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnApproverChangeRequest(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnApproverChangeRequest)
      Dim Results As List(Of SIS.ATN.atnApproverChangeRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnApproverChangeRequestSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnApproverChangeRequestSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnApproverChangeRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnApproverChangeRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnApproverChangeRequest) As Int32
      Dim _Result As Int32 = Record.RequestID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired",SqlDbType.Bit,3, Record.VerificationRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierID",SqlDbType.NVarChar,9, Iif(Record.VerifierID= "" ,Convert.DBNull, Record.VerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired",SqlDbType.Bit,3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID",SqlDbType.NVarChar,9, Iif(Record.ApproverID= "" ,Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Requested",SqlDbType.Bit,3, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Now)
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_RequestID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnApproverChangeRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired",SqlDbType.Bit,3, Record.VerificationRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierID",SqlDbType.NVarChar,9, Iif(Record.VerifierID= "" ,Convert.DBNull, Record.VerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired",SqlDbType.Bit,3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID",SqlDbType.NVarChar,9, Iif(Record.ApproverID= "" ,Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Requested",SqlDbType.Bit,3, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Now)
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
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnApproverChangeRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,Record.RequestID.ToString.Length, Record.RequestID)
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
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RequestID = Ctype(Reader("RequestID"),Int32)
      If Convert.IsDBNull(Reader("UserID")) Then
        _UserID = String.Empty
      Else
        _UserID = Ctype(Reader("UserID"), String)
      End If
      _VerificationRequired = Ctype(Reader("VerificationRequired"),Boolean)
      If Convert.IsDBNull(Reader("VerifierID")) Then
        _VerifierID = String.Empty
      Else
        _VerifierID = Ctype(Reader("VerifierID"), String)
      End If
      _ApprovalRequired = Ctype(Reader("ApprovalRequired"),Boolean)
      If Convert.IsDBNull(Reader("ApproverID")) Then
        _ApproverID = String.Empty
      Else
        _ApproverID = Ctype(Reader("ApproverID"), String)
      End If
      _Requested = Ctype(Reader("Requested"),Boolean)
      If Convert.IsDBNull(Reader("RequestedOn")) Then
        _RequestedOn = String.Empty
      Else
        _RequestedOn = Ctype(Reader("RequestedOn"), String)
      End If
      _Executed = Ctype(Reader("Executed"),Boolean)
      If Convert.IsDBNull(Reader("ExecutedOn")) Then
        _ExecutedOn = String.Empty
      Else
        _ExecutedOn = Ctype(Reader("ExecutedOn"), String)
      End If
      _UserIDHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees1",Reader)
      If Convert.IsDBNull(Reader("VerifierID")) Then
        _VerifierIDEmployeeName = String.Empty
      Else
        _VerifierIDEmployeeName = Reader("HRM_Employees2_EmployeeName") & " [" & Ctype(Reader("VerifierID"), String) & "]"
      End If
      _VerifierIDHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees2",Reader)
      If Convert.IsDBNull(Reader("ApproverID")) Then
        _ApproverIDEmployeeName = String.Empty
      Else
        _ApproverIDEmployeeName = Reader("HRM_Employees3_EmployeeName") & " [" & Ctype(Reader("ApproverID"), String) & "]"
      End If
      _ApproverIDHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees3",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RequestID = Ctype(Reader(AliasName & "_RequestID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_UserID")) Then
        _UserID = String.Empty
      Else
        _UserID = Ctype(Reader(AliasName & "_UserID"), String)
      End If
      _VerificationRequired = Ctype(Reader(AliasName & "_VerificationRequired"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_VerifierID")) Then
        _VerifierID = String.Empty
      Else
        _VerifierID = Ctype(Reader(AliasName & "_VerifierID"), String)
      End If
      _ApprovalRequired = Ctype(Reader(AliasName & "_ApprovalRequired"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ApproverID")) Then
        _ApproverID = String.Empty
      Else
        _ApproverID = Ctype(Reader(AliasName & "_ApproverID"), String)
      End If
      _Requested = Ctype(Reader(AliasName & "_Requested"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_RequestedOn")) Then
        _RequestedOn = String.Empty
      Else
        _RequestedOn = Ctype(Reader(AliasName & "_RequestedOn"), String)
      End If
      _Executed = Ctype(Reader(AliasName & "_Executed"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ExecutedOn")) Then
        _ExecutedOn = String.Empty
      Else
        _ExecutedOn = Ctype(Reader(AliasName & "_ExecutedOn"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
