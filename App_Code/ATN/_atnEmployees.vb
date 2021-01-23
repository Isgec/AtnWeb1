Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnEmployees
    Private Shared _RecordCount As Integer
    Private _CardNo As String
    Private _EmployeeName As String
    Private _VerificationRequired As Boolean
    Private _VerifierID As String
    Private _ApprovalRequired As Boolean
    Private _ApproverID As String
    Private _C_DateOfJoining As String
    Private _C_DateOfReleaving As String
    Private _C_CompanyID As String
    Private _C_DivisionID As String
    Private _C_OfficeID As String
    Private _C_DepartmentID As String
    Private _C_DesignationID As String
    Private _ActiveState As Boolean
		Private _C_ConfirmedOn As String
		Private _Contractual As Boolean = False
    Private _VerifierIDHRM_Employees As SIS.ATN.atnEmployees
    Private _VerifierIDEmployeeName As String
    Private _ApproverIDHRM_Employees As SIS.ATN.atnEmployees
    Private _ApproverIDEmployeeName As String
    Private _C_CompanyIDHRM_Companies As SIS.ATN.hrmCompanies
    Private _C_DivisionIDHRM_Divisions As SIS.ATN.hrmDivisions
    Private _C_OfficeIDHRM_Offices As SIS.ATN.hrmOffices
    Private _C_DepartmentIDHRM_Departments As SIS.ATN.hrmDepartments
		Private _C_DesignationIDHRM_Designations As SIS.ATN.hrmDesignations
    Private _C_ProjectSiteID As String = ""
    Private _CategoryID As String = ""
    Private _EMailID As String = ""
    Public Property CreditQuarterly As Boolean = False
    Public Property EMailID As String
      Get
        Return _EMailID
      End Get
      Set(value As String)
        If Convert.IsDBNull(value) Then
          _EMailID = ""
        Else
          _EMailID = value
        End If
      End Set
    End Property
    Public Property CategoryID As String
      Get
        Return _CategoryID
      End Get
      Set(value As String)
        If IsDBNull(value) Then
          _CategoryID = ""
        Else
          _CategoryID = value
        End If
      End Set
    End Property
    Public Property Contractual() As Boolean
      Get
        Return _Contractual
      End Get
      Set(ByVal value As Boolean)
        _Contractual = value
      End Set
    End Property
    Public Property C_ProjectSiteID() As String
      Get
        Return _C_ProjectSiteID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_ProjectSiteID = ""
        Else
          _C_ProjectSiteID = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return _EmployeeName
      End Get
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
    Public Property C_DateOfJoining() As String
      Get
        If Not _C_DateOfJoining = String.Empty Then
          Return Convert.ToDateTime(_C_DateOfJoining).ToString("dd/MM/yyyy")
        End If
        Return _C_DateOfJoining
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_DateOfJoining = ""
        Else
          _C_DateOfJoining = value
        End If
      End Set
    End Property
    Public Property C_DateOfReleaving() As String
      Get
        If Not _C_DateOfReleaving = String.Empty Then
          Return Convert.ToDateTime(_C_DateOfReleaving).ToString("dd/MM/yyyy")
        End If
        Return _C_DateOfReleaving
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_DateOfReleaving = ""
        Else
          _C_DateOfReleaving = value
        End If
      End Set
    End Property
    Public Property C_CompanyID() As String
      Get
        Return _C_CompanyID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_CompanyID = ""
        Else
          _C_CompanyID = value
        End If
      End Set
    End Property
    Public Property C_DivisionID() As String
      Get
        Return _C_DivisionID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_DivisionID = ""
        Else
          _C_DivisionID = value
        End If
      End Set
    End Property
    Public Property C_OfficeID() As String
      Get
        Return _C_OfficeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_OfficeID = ""
        Else
          _C_OfficeID = value
        End If
      End Set
    End Property
    Public Property C_DepartmentID() As String
      Get
        Return _C_DepartmentID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_DepartmentID = ""
        Else
          _C_DepartmentID = value
        End If
      End Set
    End Property
    Public Property C_DesignationID() As String
      Get
        Return _C_DesignationID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_DesignationID = ""
        Else
          _C_DesignationID = value
        End If
      End Set
    End Property
    Public Property ActiveState() As Boolean
      Get
        Return _ActiveState
      End Get
      Set(ByVal value As Boolean)
        _ActiveState = value
      End Set
    End Property
    Public Property C_ConfirmedOn() As String
      Get
        If Not _C_ConfirmedOn = String.Empty Then
          Return Convert.ToDateTime(_C_ConfirmedOn).ToString("dd/MM/yyyy")
        End If
        Return _C_ConfirmedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _C_ConfirmedOn = ""
        Else
          _C_ConfirmedOn = value
        End If
      End Set
    End Property
    Public ReadOnly Property VerifierIDHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _VerifierIDHRM_Employees Is Nothing Then
          _VerifierIDHRM_Employees = SIS.ATN.atnEmployees.GetByID(_VerifierID)
        End If
        Return _VerifierIDHRM_Employees
      End Get
    End Property
    'Public Property VerifierIDEmployeeName() As String
    '  Get
    '    Return _VerifierIDEmployeeName
    '  End Get
    '  Set(ByVal value As String)
    '    _VerifierIDEmployeeName = value
    '  End Set
    'End Property
    Public ReadOnly Property ApproverIDHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _ApproverIDHRM_Employees Is Nothing Then
          _ApproverIDHRM_Employees = SIS.ATN.atnEmployees.GetByID(_ApproverID)
        End If
        Return _ApproverIDHRM_Employees
      End Get
    End Property
    'Public Property ApproverIDEmployeeName() As String
    '  Get
    '    Return _ApproverIDEmployeeName
    '  End Get
    '  Set(ByVal value As String)
    '    _ApproverIDEmployeeName = value
    '  End Set
    'End Property
    Public ReadOnly Property C_CompanyIDHRM_Companies() As SIS.ATN.hrmCompanies
      Get
        If _C_CompanyIDHRM_Companies Is Nothing Then
          _C_CompanyIDHRM_Companies = SIS.ATN.hrmCompanies.GetByID(_C_CompanyID)
        End If
        Return _C_CompanyIDHRM_Companies
      End Get
    End Property
    Public ReadOnly Property C_DivisionIDHRM_Divisions() As SIS.ATN.hrmDivisions
      Get
        If _C_DivisionIDHRM_Divisions Is Nothing Then
          _C_DivisionIDHRM_Divisions = SIS.ATN.hrmDivisions.GetByID(_C_DivisionID)
        End If
        Return _C_DivisionIDHRM_Divisions
      End Get
    End Property
    Public ReadOnly Property C_OfficeIDHRM_Offices() As SIS.ATN.hrmOffices
      Get
        If _C_OfficeIDHRM_Offices Is Nothing Then
          _C_OfficeIDHRM_Offices = SIS.ATN.hrmOffices.GetByID(_C_OfficeID)
        End If
        Return _C_OfficeIDHRM_Offices
      End Get
    End Property
    Public ReadOnly Property C_DepartmentIDHRM_Departments() As SIS.ATN.hrmDepartments
      Get
        If _C_DepartmentIDHRM_Departments Is Nothing Then
          _C_DepartmentIDHRM_Departments = SIS.ATN.hrmDepartments.GetByID(_C_DepartmentID)
        End If
        Return _C_DepartmentIDHRM_Departments
      End Get
    End Property
    Public ReadOnly Property C_DesignationIDHRM_Designations() As SIS.ATN.hrmDesignations
      Get
        If _C_DesignationIDHRM_Designations Is Nothing Then
          _C_DesignationIDHRM_Designations = SIS.ATN.hrmDesignations.GetByID(_C_DesignationID)
        End If
        Return _C_DesignationIDHRM_Designations
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ATN.atnEmployees)
      Dim Results As List(Of SIS.ATN.atnEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnEmployeesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 2, 1)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetCardNoList(ByVal orderBy As String) As List(Of String)
      Dim Results As List(Of String) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_EmployeesCardNoSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 2, 1)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(Reader("CardNo"))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnEmployeesGetByID(ByVal CardNo As String) As SIS.ATN.atnEmployees
      Return GetByID(CardNo)
    End Function
    Public Shared Function GetByID(ByVal CardNo As String) As SIS.ATN.atnEmployees
      Dim Results As SIS.ATN.atnEmployees = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnEmployeesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnEmployees(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnEmployees)
      Dim Results As List(Of SIS.ATN.atnEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnEmployeesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnEmployeesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 2, 1)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnEmployees) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnEmployeesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired", SqlDbType.Bit, 3, Record.VerificationRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierID", SqlDbType.NVarChar, 9, Iif(Record.VerifierID = "", Convert.DBNull, Record.VerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired", SqlDbType.Bit, 3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID", SqlDbType.NVarChar, 9, Iif(Record.ApproverID = "", Convert.DBNull, Record.ApproverID))
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
    Public Shared Function SelectatnActiveEmployeesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer) As String()
      Dim Results As List(Of String) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_ActiveEmployeesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 2, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
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
    Public Shared Function SelectatnEmployeesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, Optional ByVal x As String = "") As String()
      Dim Results As List(Of String) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnEmployeesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 2, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
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
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CardNo = CType(Reader(AliasName & "_CardNo"), String)
      _EmployeeName = CType(Reader(AliasName & "_EmployeeName"), String)
      _VerificationRequired = CType(Reader(AliasName & "_VerificationRequired"), Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_VerifierID")) Then
        _VerifierID = String.Empty
      Else
        _VerifierID = CType(Reader(AliasName & "_VerifierID"), String)
      End If
      _ApprovalRequired = CType(Reader(AliasName & "_ApprovalRequired"), Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ApproverID")) Then
        _ApproverID = String.Empty
      Else
        _ApproverID = CType(Reader(AliasName & "_ApproverID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DateOfJoining")) Then
        _C_DateOfJoining = String.Empty
      Else
        _C_DateOfJoining = CType(Reader(AliasName & "_C_DateOfJoining"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DateOfReleaving")) Then
        _C_DateOfReleaving = String.Empty
      Else
        _C_DateOfReleaving = CType(Reader(AliasName & "_C_DateOfReleaving"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_CompanyID")) Then
        _C_CompanyID = String.Empty
      Else
        _C_CompanyID = CType(Reader(AliasName & "_C_CompanyID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DivisionID")) Then
        _C_DivisionID = String.Empty
      Else
        _C_DivisionID = CType(Reader(AliasName & "_C_DivisionID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_OfficeID")) Then
        _C_OfficeID = String.Empty
      Else
        _C_OfficeID = CType(Reader(AliasName & "_C_OfficeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DepartmentID")) Then
        _C_DepartmentID = String.Empty
      Else
        _C_DepartmentID = CType(Reader(AliasName & "_C_DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DesignationID")) Then
        _C_DesignationID = String.Empty
      Else
        _C_DesignationID = CType(Reader(AliasName & "_C_DesignationID"), String)
      End If
      _ActiveState = CType(Reader(AliasName & "_ActiveState"), Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_C_ConfirmedOn")) Then
        _C_ConfirmedOn = String.Empty
      Else
        _C_ConfirmedOn = CType(Reader(AliasName & "_C_ConfirmedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_ProjectSiteID")) Then
        _C_ProjectSiteID = String.Empty
      Else
        _C_ProjectSiteID = CType(Reader(AliasName & "_C_ProjectSiteID"), String)
      End If
      _Contractual = CType(Reader(AliasName & "_Contractual"), Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_CategoryID")) Then
        _CategoryID = ""
      Else
        _CategoryID = CType(Reader(AliasName & "_CategoryID"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
