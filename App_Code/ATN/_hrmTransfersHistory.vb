Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.HRM
  <DataObject()> _
  Partial Public Class hrmTransfersHistory
    Private Shared _RecordCount As Integer
    Private _TransferID As Int32
    Private _CardNo As String
    Private _CompanyID As String
    Private _DivisionID As String
    Private _OfficeID As Int32
    Private _DepartmentID As String
    Private _ProjectSiteID As String
    Private _TransferedOn As String
    Private _Remarks As String
    Private _ActiveState As Boolean
    Private _Executed As Boolean
    Private _Cancelled As Boolean
    Private _ProcessedBy As String
    Private _ProcessedOn As String
		Private _CardNoHRM_Employees As SIS.ATN.atnEmployees
		Private _CompanyIDHRM_Companies As SIS.ATN.hrmCompanies
		Private _DivisionIDHRM_Divisions As SIS.ATN.hrmDivisions
		Private _OfficeIDHRM_Offices As SIS.ATN.hrmOffices
		Private _DepartmentIDHRM_Departments As SIS.ATN.hrmDepartments
		Private _ProcessedByHRM_Employees As SIS.ATN.atnEmployees
    Public Property TransferID() As Int32
      Get
        Return _TransferID
      End Get
      Set(ByVal value As Int32)
        _TransferID = value
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
    Public Property CompanyID() As String
      Get
        Return _CompanyID
      End Get
      Set(ByVal value As String)
        _CompanyID = value
      End Set
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
        _DivisionID = value
      End Set
    End Property
    Public Property OfficeID() As Int32
      Get
        Return _OfficeID
      End Get
      Set(ByVal value As Int32)
        _OfficeID = value
      End Set
    End Property
    Public Property DepartmentID() As String
      Get
        Return _DepartmentID
      End Get
      Set(ByVal value As String)
        _DepartmentID = value
      End Set
    End Property
    Public Property ProjectSiteID() As String
      Get
        Return _ProjectSiteID
      End Get
      Set(ByVal value As String)
        _ProjectSiteID = value
      End Set
    End Property
    Public Property TransferedOn() As String
      Get
        If Not _TransferedOn = String.Empty Then
          Return Convert.ToDateTime(_TransferedOn).ToString("dd/MM/yyyy")
        End If
        Return _TransferedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TransferedOn = ""
				 Else
					 _TransferedOn = value
			   End If
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
        _Remarks = value
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
    Public Property Executed() As Boolean
      Get
        Return _Executed
      End Get
      Set(ByVal value As Boolean)
        _Executed = value
      End Set
    End Property
    Public Property Cancelled() As Boolean
      Get
        Return _Cancelled
      End Get
      Set(ByVal value As Boolean)
        _Cancelled = value
      End Set
    End Property
    Public Property ProcessedBy() As String
      Get
        Return _ProcessedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProcessedBy = ""
				 Else
					 _ProcessedBy = value
			   End If
      End Set
    End Property
    Public Property ProcessedOn() As String
      Get
        If Not _ProcessedOn = String.Empty Then
          Return Convert.ToDateTime(_ProcessedOn).ToString("dd/MM/yyyy")
        End If
        Return _ProcessedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProcessedOn = ""
				 Else
					 _ProcessedOn = value
			   End If
      End Set
    End Property
		Public ReadOnly Property CardNoHRM_Employees() As SIS.ATN.atnEmployees
			Get
				If _CardNoHRM_Employees Is Nothing Then
					_CardNoHRM_Employees = SIS.ATN.atnEmployees.GetByID(_CardNo)
				End If
				Return _CardNoHRM_Employees
			End Get
		End Property
		Public ReadOnly Property CompanyIDHRM_Companies() As SIS.ATN.hrmCompanies
			Get
				If _CompanyIDHRM_Companies Is Nothing Then
					_CompanyIDHRM_Companies = SIS.ATN.hrmCompanies.GetByID(_CompanyID)
				End If
				Return _CompanyIDHRM_Companies
			End Get
		End Property
		Public ReadOnly Property DivisionIDHRM_Divisions() As SIS.ATN.hrmDivisions
			Get
				If _DivisionIDHRM_Divisions Is Nothing Then
					_DivisionIDHRM_Divisions = SIS.ATN.hrmDivisions.GetByID(_DivisionID)
				End If
				Return _DivisionIDHRM_Divisions
			End Get
		End Property
		Public ReadOnly Property OfficeIDHRM_Offices() As SIS.ATN.hrmOffices
			Get
				If _OfficeIDHRM_Offices Is Nothing Then
					_OfficeIDHRM_Offices = SIS.ATN.hrmOffices.GetByID(_OfficeID)
				End If
				Return _OfficeIDHRM_Offices
			End Get
		End Property
		Public ReadOnly Property DepartmentIDHRM_Departments() As SIS.ATN.hrmDepartments
			Get
				If _DepartmentIDHRM_Departments Is Nothing Then
					_DepartmentIDHRM_Departments = SIS.ATN.hrmDepartments.GetByID(_DepartmentID)
				End If
				Return _DepartmentIDHRM_Departments
			End Get
		End Property
		Public ReadOnly Property ProcessedByHRM_Employees() As SIS.ATN.atnEmployees
			Get
				If _ProcessedByHRM_Employees Is Nothing Then
					_ProcessedByHRM_Employees = SIS.ATN.atnEmployees.GetByID(_ProcessedBy)
				End If
				Return _ProcessedByHRM_Employees
			End Get
		End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal TransferID As Int32) As SIS.HRM.hrmTransfersHistory
      Dim Results As SIS.HRM.hrmTransfersHistory = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmTransfersHistorySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransferID",SqlDbType.Int,TransferID.ToString.Length, TransferID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.HRM.hrmTransfersHistory(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.HRM.hrmTransfersHistory)
      Dim Results As List(Of SIS.HRM.hrmTransfersHistory) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sphrmTransfersHistorySelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sphrmTransfersHistorySelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Executed",SqlDbType.Bit,2, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cancelled",SqlDbType.Bit,2, 0)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.HRM.hrmTransfersHistory)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.HRM.hrmTransfersHistory(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.HRM.hrmTransfersHistory) As Int32
      Dim _Result As Int32 = Record.TransferID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmTransfersHistoryInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID",SqlDbType.NVarChar,7, Record.CompanyID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Record.DivisionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,11, Record.OfficeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Record.DepartmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectSiteID",SqlDbType.NVarChar,7, Record.ProjectSiteID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransferedOn",SqlDbType.DateTime,21, Iif(Record.TransferedOn= "" ,Convert.DBNull, Record.TransferedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Record.Remarks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,3, Record.ActiveState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Executed",SqlDbType.Bit,3, Record.Executed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cancelled",SqlDbType.Bit,3, Record.Cancelled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn",SqlDbType.DateTime,21, Now)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateEvent", SqlDbType.Bit, 3, Record.CreateEvent)
					Cmd.Parameters.Add("@Return_TransferID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_TransferID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_TransferID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.HRM.hrmTransfersHistory) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmTransfersHistoryUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TransferID",SqlDbType.Int,11, Record.TransferID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Executed",SqlDbType.Bit,3, Record.Executed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cancelled",SqlDbType.Bit,3, Record.Cancelled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn",SqlDbType.DateTime,21, Now)
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
      _TransferID = Ctype(Reader("TransferID"),Int32)
      _CardNo = Ctype(Reader("CardNo"),String)
      _CompanyID = Ctype(Reader("CompanyID"),String)
      _DivisionID = Ctype(Reader("DivisionID"),String)
      _OfficeID = Ctype(Reader("OfficeID"),Int32)
      _DepartmentID = Ctype(Reader("DepartmentID"),String)
      _ProjectSiteID = Ctype(Reader("ProjectSiteID"),String)
      If Convert.IsDBNull(Reader("TransferedOn")) Then
        _TransferedOn = String.Empty
      Else
        _TransferedOn = Ctype(Reader("TransferedOn"), String)
      End If
      _Remarks = Ctype(Reader("Remarks"),String)
      _ActiveState = Ctype(Reader("ActiveState"),Boolean)
			_Executed = CType(Reader("Executed"), Boolean)
			_CreateEvent = CType(Reader("CreateEvent"), Boolean)
			_Cancelled = CType(Reader("Cancelled"), Boolean)
      If Convert.IsDBNull(Reader("ProcessedBy")) Then
        _ProcessedBy = String.Empty
      Else
        _ProcessedBy = Ctype(Reader("ProcessedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ProcessedOn")) Then
        _ProcessedOn = String.Empty
      Else
        _ProcessedOn = Ctype(Reader("ProcessedOn"), String)
      End If
			_CardNoHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees1", Reader)
			_CompanyIDHRM_Companies = New SIS.ATN.hrmCompanies("HRM_Companies2", Reader)
			_DivisionIDHRM_Divisions = New SIS.ATN.hrmDivisions("HRM_Divisions3", Reader)
			_OfficeIDHRM_Offices = New SIS.ATN.hrmOffices("HRM_Offices4", Reader)
			_DepartmentIDHRM_Departments = New SIS.ATN.hrmDepartments("HRM_Departments5", Reader)
			_ProcessedByHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees6", Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _TransferID = Ctype(Reader(AliasName & "_TransferID"),Int32)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      _CompanyID = Ctype(Reader(AliasName & "_CompanyID"),String)
      _DivisionID = Ctype(Reader(AliasName & "_DivisionID"),String)
      _OfficeID = Ctype(Reader(AliasName & "_OfficeID"),Int32)
      _DepartmentID = Ctype(Reader(AliasName & "_DepartmentID"),String)
      _ProjectSiteID = Ctype(Reader(AliasName & "_ProjectSiteID"),String)
      If Convert.IsDBNull(Reader(AliasName & "_TransferedOn")) Then
        _TransferedOn = String.Empty
      Else
        _TransferedOn = Ctype(Reader(AliasName & "_TransferedOn"), String)
      End If
      _Remarks = Ctype(Reader(AliasName & "_Remarks"),String)
      _ActiveState = Ctype(Reader(AliasName & "_ActiveState"),Boolean)
      _Executed = Ctype(Reader(AliasName & "_Executed"),Boolean)
			_CreateEvent = CType(Reader(AliasName & "_CreateEvent"), Boolean)
			_Cancelled = CType(Reader(AliasName & "_Cancelled"), Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ProcessedBy")) Then
        _ProcessedBy = String.Empty
      Else
        _ProcessedBy = Ctype(Reader(AliasName & "_ProcessedBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ProcessedOn")) Then
        _ProcessedOn = String.Empty
      Else
        _ProcessedOn = Ctype(Reader(AliasName & "_ProcessedOn"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
