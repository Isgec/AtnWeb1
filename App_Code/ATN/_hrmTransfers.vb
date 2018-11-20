Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.HRM
  <DataObject()> _
  Partial Public Class hrmTransfers
    Private Shared _RecordCount As Integer
    Private _CardNo As String
    Private _EmployeeName As String
    Private _C_DateOfJoining As String
    Private _C_DesignationID As Int32
    Private _C_CompanyID As String
    Private _C_DivisionID As String
    Private _C_OfficeID As String
    Private _C_DepartmentID As String
    Private _C_ProjectSiteID As String
    Private _U_UnderTransfer As Boolean
    Private _U_CompanyID As String
    Private _U_DivisionID As String
    Private _U_OfficeID As String
    Private _U_DepartmentID As String
    Private _U_ProjectSiteID As String
    Private _U_ActiveState As Boolean
    Private _C_TransferedOn As String
    Private _C_TransferRemark As String
    Private _Resigned As Boolean
    Private _ActiveState As Boolean
    Private _Confirmed As Boolean
    Private _ModifiedBy As String
    Private _ModifiedOn As String
    Private _ModifiedEvent As String
    Private _ActiveStateEventName As String
		Private _C_DesignationIDHRM_Designations As SIS.ATN.hrmDesignations
		Private _C_CompanyIDHRM_Companies As SIS.ATN.hrmCompanies
		Private _C_DivisionIDHRM_Divisions As SIS.ATN.hrmDivisions
		Private _C_OfficeIDHRM_Offices As SIS.ATN.hrmOffices
		Private _C_DepartmentIDHRM_Departments As SIS.ATN.hrmDepartments
		Private _C_ProjectSiteIDDCM_Projects As SIS.HRM.hrmProjects
		Private _U_CompanyIDHRM_Companies As SIS.ATN.hrmCompanies
		Private _U_DivisionIDHRM_Divisions As SIS.ATN.hrmDivisions
		Private _U_OfficeIDHRM_Offices As SIS.ATN.hrmOffices
		Private _U_DepartmentIDHRM_Departments As SIS.ATN.hrmDepartments
    Private _U_ProjectSiteIDDCM_Projects As SIS.HRM.hrmProjects
    Private _ModifiedByaspnet_Users As SIS.HRM.hrmUsers
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
    Public Property C_DesignationID() As Int32
      Get
        Return _C_DesignationID
      End Get
      Set(ByVal value As Int32)
        _C_DesignationID = value
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
    Public Property C_ProjectSiteID() As String
      Get
        Return _C_ProjectSiteID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _C_ProjectSiteID = ""
				 Else
					 _C_ProjectSiteID = value
			   End If
      End Set
    End Property
    Public Property U_UnderTransfer() As Boolean
      Get
        Return _U_UnderTransfer
      End Get
      Set(ByVal value As Boolean)
        _U_UnderTransfer = value
      End Set
    End Property
    Public Property U_CompanyID() As String
      Get
        Return _U_CompanyID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _U_CompanyID = ""
				 Else
					 _U_CompanyID = value
			   End If
      End Set
    End Property
    Public Property U_DivisionID() As String
      Get
        Return _U_DivisionID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _U_DivisionID = ""
				 Else
					 _U_DivisionID = value
			   End If
      End Set
    End Property
    Public Property U_OfficeID() As String
      Get
        Return _U_OfficeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _U_OfficeID = ""
				 Else
					 _U_OfficeID = value
			   End If
      End Set
    End Property
    Public Property U_DepartmentID() As String
      Get
        Return _U_DepartmentID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _U_DepartmentID = ""
				 Else
					 _U_DepartmentID = value
			   End If
      End Set
    End Property
    Public Property U_ProjectSiteID() As String
      Get
        Return _U_ProjectSiteID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _U_ProjectSiteID = ""
				 Else
					 _U_ProjectSiteID = value
			   End If
      End Set
    End Property
    Public Property U_ActiveState() As Boolean
      Get
        Return _U_ActiveState
      End Get
      Set(ByVal value As Boolean)
        _U_ActiveState = value
      End Set
    End Property
    Public Property C_TransferedOn() As String
      Get
        If Not _C_TransferedOn = String.Empty Then
          Return Convert.ToDateTime(_C_TransferedOn).ToString("dd/MM/yyyy")
        End If
        Return _C_TransferedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _C_TransferedOn = ""
				 Else
					 _C_TransferedOn = value
			   End If
      End Set
    End Property
    Public Property C_TransferRemark() As String
      Get
        Return _C_TransferRemark
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _C_TransferRemark = ""
				 Else
					 _C_TransferRemark = value
			   End If
      End Set
    End Property
    Public Property Resigned() As Boolean
      Get
        Return _Resigned
      End Get
      Set(ByVal value As Boolean)
        _Resigned = value
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
    Public Property Confirmed() As Boolean
      Get
        Return _Confirmed
      End Get
      Set(ByVal value As Boolean)
        _Confirmed = value
      End Set
    End Property
    Public Property ModifiedBy() As String
      Get
        Return _ModifiedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ModifiedBy = ""
				 Else
					 _ModifiedBy = value
			   End If
      End Set
    End Property
    Public Property ModifiedOn() As String
      Get
        If Not _ModifiedOn = String.Empty Then
          Return Convert.ToDateTime(_ModifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _ModifiedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ModifiedOn = ""
				 Else
					 _ModifiedOn = value
			   End If
      End Set
    End Property
    Public Property ModifiedEvent() As String
      Get
        Return _ModifiedEvent
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ModifiedEvent = ""
				 Else
					 _ModifiedEvent = value
			   End If
      End Set
    End Property
    Public Property ActiveStateEventName() As String
      Get
        Return _ActiveStateEventName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ActiveStateEventName = ""
				 Else
					 _ActiveStateEventName = value
			   End If
      End Set
    End Property
		Public ReadOnly Property C_DesignationIDHRM_Designations() As SIS.ATN.hrmDesignations
			Get
				If _C_DesignationIDHRM_Designations Is Nothing Then
					_C_DesignationIDHRM_Designations = SIS.ATN.hrmDesignations.GetByID(_C_DesignationID)
				End If
				Return _C_DesignationIDHRM_Designations
			End Get
		End Property
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
    Public ReadOnly Property C_ProjectSiteIDDCM_Projects() As SIS.HRM.hrmProjects
      Get
        If _C_ProjectSiteIDDCM_Projects Is Nothing Then
          _C_ProjectSiteIDDCM_Projects = SIS.HRM.hrmProjects.GetByID(_C_ProjectSiteID)
        End If
        Return _C_ProjectSiteIDDCM_Projects
      End Get
    End Property
		Public ReadOnly Property U_CompanyIDHRM_Companies() As SIS.ATN.hrmCompanies
			Get
				If _U_CompanyIDHRM_Companies Is Nothing Then
					_U_CompanyIDHRM_Companies = SIS.ATN.hrmCompanies.GetByID(_U_CompanyID)
				End If
				Return _U_CompanyIDHRM_Companies
			End Get
		End Property
		Public ReadOnly Property U_DivisionIDHRM_Divisions() As SIS.ATN.hrmDivisions
			Get
				If _U_DivisionIDHRM_Divisions Is Nothing Then
					_U_DivisionIDHRM_Divisions = SIS.ATN.hrmDivisions.GetByID(_U_DivisionID)
				End If
				Return _U_DivisionIDHRM_Divisions
			End Get
		End Property
		Public ReadOnly Property U_OfficeIDHRM_Offices() As SIS.ATN.hrmOffices
			Get
				If _U_OfficeIDHRM_Offices Is Nothing Then
					_U_OfficeIDHRM_Offices = SIS.ATN.hrmOffices.GetByID(_U_OfficeID)
				End If
				Return _U_OfficeIDHRM_Offices
			End Get
		End Property
		Public ReadOnly Property U_DepartmentIDHRM_Departments() As SIS.ATN.hrmDepartments
			Get
				If _U_DepartmentIDHRM_Departments Is Nothing Then
					_U_DepartmentIDHRM_Departments = SIS.ATN.hrmDepartments.GetByID(_U_DepartmentID)
				End If
				Return _U_DepartmentIDHRM_Departments
			End Get
		End Property
    Public ReadOnly Property U_ProjectSiteIDDCM_Projects() As SIS.HRM.hrmProjects
      Get
        If _U_ProjectSiteIDDCM_Projects Is Nothing Then
          _U_ProjectSiteIDDCM_Projects = SIS.HRM.hrmProjects.GetByID(_U_ProjectSiteID)
        End If
        Return _U_ProjectSiteIDDCM_Projects
      End Get
    End Property
    Public ReadOnly Property ModifiedByaspnet_Users() As SIS.HRM.hrmUsers
      Get
        If _ModifiedByaspnet_Users Is Nothing Then
          _ModifiedByaspnet_Users = SIS.HRM.hrmUsers.GetByID(_ModifiedBy)
        End If
        Return _ModifiedByaspnet_Users
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CardNo As String) As SIS.HRM.hrmTransfers
      Dim Results As SIS.HRM.hrmTransfers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmTransfersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.HRM.hrmTransfers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.HRM.hrmTransfers)
      Dim Results As List(Of SIS.HRM.hrmTransfers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sphrmTransfersSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sphrmTransfersSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_UnderTransfer",SqlDbType.Bit,2, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Resigned",SqlDbType.Bit,2, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,2, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Confirmed",SqlDbType.Bit,2, 1)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.HRM.hrmTransfers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.HRM.hrmTransfers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.HRM.hrmTransfers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "sphrmTransfersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_UnderTransfer",SqlDbType.Bit,3, Record.U_UnderTransfer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_CompanyID",SqlDbType.NVarChar,7, Iif(Record.U_CompanyID= "" ,Convert.DBNull, Record.U_CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_DivisionID",SqlDbType.NVarChar,7, Iif(Record.U_DivisionID= "" ,Convert.DBNull, Record.U_DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_OfficeID",SqlDbType.Int,11, Iif(Record.U_OfficeID= "" ,Convert.DBNull, Record.U_OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_DepartmentID",SqlDbType.NVarChar,7, Iif(Record.U_DepartmentID= "" ,Convert.DBNull, Record.U_DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_ProjectSiteID",SqlDbType.NVarChar,7, Iif(Record.U_ProjectSiteID= "" ,Convert.DBNull, Record.U_ProjectSiteID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@U_ActiveState",SqlDbType.Bit,3, Record.U_ActiveState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_TransferedOn",SqlDbType.DateTime,21, Iif(Record.C_TransferedOn= "" ,Convert.DBNull, Record.C_TransferedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_TransferRemark",SqlDbType.NVarChar,251, Iif(Record.C_TransferRemark= "" ,Convert.DBNull, Record.C_TransferRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,3, Record.ActiveState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy",SqlDbType.NVarChar,21, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedEvent",SqlDbType.NVarChar,21, "Increment")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveStateEventName",SqlDbType.NVarChar,21, Iif(Record.ActiveStateEventName= "" ,Convert.DBNull, Record.ActiveStateEventName))
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
      _CardNo = Ctype(Reader("CardNo"),String)
      _EmployeeName = Ctype(Reader("EmployeeName"),String)
      If Convert.IsDBNull(Reader("C_DateOfJoining")) Then
        _C_DateOfJoining = String.Empty
      Else
        _C_DateOfJoining = Ctype(Reader("C_DateOfJoining"), String)
      End If
      _C_DesignationID = Ctype(Reader("C_DesignationID"),Int32)
      If Convert.IsDBNull(Reader("C_CompanyID")) Then
        _C_CompanyID = String.Empty
      Else
        _C_CompanyID = Ctype(Reader("C_CompanyID"), String)
      End If
      If Convert.IsDBNull(Reader("C_DivisionID")) Then
        _C_DivisionID = String.Empty
      Else
        _C_DivisionID = Ctype(Reader("C_DivisionID"), String)
      End If
      If Convert.IsDBNull(Reader("C_OfficeID")) Then
        _C_OfficeID = String.Empty
      Else
        _C_OfficeID = Ctype(Reader("C_OfficeID"), String)
      End If
      If Convert.IsDBNull(Reader("C_DepartmentID")) Then
        _C_DepartmentID = String.Empty
      Else
        _C_DepartmentID = Ctype(Reader("C_DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader("C_ProjectSiteID")) Then
        _C_ProjectSiteID = String.Empty
      Else
        _C_ProjectSiteID = Ctype(Reader("C_ProjectSiteID"), String)
      End If
      _U_UnderTransfer = Ctype(Reader("U_UnderTransfer"),Boolean)
      If Convert.IsDBNull(Reader("U_CompanyID")) Then
        _U_CompanyID = String.Empty
      Else
        _U_CompanyID = Ctype(Reader("U_CompanyID"), String)
      End If
      If Convert.IsDBNull(Reader("U_DivisionID")) Then
        _U_DivisionID = String.Empty
      Else
        _U_DivisionID = Ctype(Reader("U_DivisionID"), String)
      End If
      If Convert.IsDBNull(Reader("U_OfficeID")) Then
        _U_OfficeID = String.Empty
      Else
        _U_OfficeID = Ctype(Reader("U_OfficeID"), String)
      End If
      If Convert.IsDBNull(Reader("U_DepartmentID")) Then
        _U_DepartmentID = String.Empty
      Else
        _U_DepartmentID = Ctype(Reader("U_DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader("U_ProjectSiteID")) Then
        _U_ProjectSiteID = String.Empty
      Else
        _U_ProjectSiteID = Ctype(Reader("U_ProjectSiteID"), String)
      End If
      _U_ActiveState = Ctype(Reader("U_ActiveState"),Boolean)
      If Convert.IsDBNull(Reader("C_TransferedOn")) Then
        _C_TransferedOn = String.Empty
      Else
        _C_TransferedOn = Ctype(Reader("C_TransferedOn"), String)
      End If
      If Convert.IsDBNull(Reader("C_TransferRemark")) Then
        _C_TransferRemark = String.Empty
      Else
        _C_TransferRemark = Ctype(Reader("C_TransferRemark"), String)
      End If
      _Resigned = Ctype(Reader("Resigned"),Boolean)
      _ActiveState = Ctype(Reader("ActiveState"),Boolean)
      _Confirmed = Ctype(Reader("Confirmed"),Boolean)
      If Convert.IsDBNull(Reader("ModifiedBy")) Then
        _ModifiedBy = String.Empty
      Else
        _ModifiedBy = Ctype(Reader("ModifiedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ModifiedOn")) Then
        _ModifiedOn = String.Empty
      Else
        _ModifiedOn = Ctype(Reader("ModifiedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ModifiedEvent")) Then
        _ModifiedEvent = String.Empty
      Else
        _ModifiedEvent = Ctype(Reader("ModifiedEvent"), String)
      End If
      If Convert.IsDBNull(Reader("ActiveStateEventName")) Then
        _ActiveStateEventName = String.Empty
      Else
        _ActiveStateEventName = Ctype(Reader("ActiveStateEventName"), String)
      End If
			_C_DesignationIDHRM_Designations = New SIS.ATN.hrmDesignations("HRM_Designations1", Reader)
			_C_CompanyIDHRM_Companies = New SIS.ATN.hrmCompanies("HRM_Companies2", Reader)
			_C_DivisionIDHRM_Divisions = New SIS.ATN.hrmDivisions("HRM_Divisions3", Reader)
			_C_OfficeIDHRM_Offices = New SIS.ATN.hrmOffices("HRM_Offices4", Reader)
			_C_DepartmentIDHRM_Departments = New SIS.ATN.hrmDepartments("HRM_Departments5", Reader)
      _C_ProjectSiteIDDCM_Projects = New SIS.HRM.hrmProjects("DCM_Projects6",Reader)
			_U_CompanyIDHRM_Companies = New SIS.ATN.hrmCompanies("HRM_Companies7", Reader)
			_U_DivisionIDHRM_Divisions = New SIS.ATN.hrmDivisions("HRM_Divisions8", Reader)
			_U_OfficeIDHRM_Offices = New SIS.ATN.hrmOffices("HRM_Offices9", Reader)
			_U_DepartmentIDHRM_Departments = New SIS.ATN.hrmDepartments("HRM_Departments10", Reader)
      _U_ProjectSiteIDDCM_Projects = New SIS.HRM.hrmProjects("DCM_Projects11",Reader)
      _ModifiedByaspnet_Users = New SIS.HRM.hrmUsers("aspnet_Users12",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      _EmployeeName = Ctype(Reader(AliasName & "_EmployeeName"),String)
      If Convert.IsDBNull(Reader(AliasName & "_C_DateOfJoining")) Then
        _C_DateOfJoining = String.Empty
      Else
        _C_DateOfJoining = Ctype(Reader(AliasName & "_C_DateOfJoining"), String)
      End If
      _C_DesignationID = Ctype(Reader(AliasName & "_C_DesignationID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_C_CompanyID")) Then
        _C_CompanyID = String.Empty
      Else
        _C_CompanyID = Ctype(Reader(AliasName & "_C_CompanyID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DivisionID")) Then
        _C_DivisionID = String.Empty
      Else
        _C_DivisionID = Ctype(Reader(AliasName & "_C_DivisionID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_OfficeID")) Then
        _C_OfficeID = String.Empty
      Else
        _C_OfficeID = Ctype(Reader(AliasName & "_C_OfficeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DepartmentID")) Then
        _C_DepartmentID = String.Empty
      Else
        _C_DepartmentID = Ctype(Reader(AliasName & "_C_DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_ProjectSiteID")) Then
        _C_ProjectSiteID = String.Empty
      Else
        _C_ProjectSiteID = Ctype(Reader(AliasName & "_C_ProjectSiteID"), String)
      End If
      _U_UnderTransfer = Ctype(Reader(AliasName & "_U_UnderTransfer"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_U_CompanyID")) Then
        _U_CompanyID = String.Empty
      Else
        _U_CompanyID = Ctype(Reader(AliasName & "_U_CompanyID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_U_DivisionID")) Then
        _U_DivisionID = String.Empty
      Else
        _U_DivisionID = Ctype(Reader(AliasName & "_U_DivisionID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_U_OfficeID")) Then
        _U_OfficeID = String.Empty
      Else
        _U_OfficeID = Ctype(Reader(AliasName & "_U_OfficeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_U_DepartmentID")) Then
        _U_DepartmentID = String.Empty
      Else
        _U_DepartmentID = Ctype(Reader(AliasName & "_U_DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_U_ProjectSiteID")) Then
        _U_ProjectSiteID = String.Empty
      Else
        _U_ProjectSiteID = Ctype(Reader(AliasName & "_U_ProjectSiteID"), String)
      End If
      _U_ActiveState = Ctype(Reader(AliasName & "_U_ActiveState"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_C_TransferedOn")) Then
        _C_TransferedOn = String.Empty
      Else
        _C_TransferedOn = Ctype(Reader(AliasName & "_C_TransferedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_TransferRemark")) Then
        _C_TransferRemark = String.Empty
      Else
        _C_TransferRemark = Ctype(Reader(AliasName & "_C_TransferRemark"), String)
      End If
      _Resigned = Ctype(Reader(AliasName & "_Resigned"),Boolean)
      _ActiveState = Ctype(Reader(AliasName & "_ActiveState"),Boolean)
      _Confirmed = Ctype(Reader(AliasName & "_Confirmed"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ModifiedBy")) Then
        _ModifiedBy = String.Empty
      Else
        _ModifiedBy = Ctype(Reader(AliasName & "_ModifiedBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ModifiedOn")) Then
        _ModifiedOn = String.Empty
      Else
        _ModifiedOn = Ctype(Reader(AliasName & "_ModifiedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ModifiedEvent")) Then
        _ModifiedEvent = String.Empty
      Else
        _ModifiedEvent = Ctype(Reader(AliasName & "_ModifiedEvent"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ActiveStateEventName")) Then
        _ActiveStateEventName = String.Empty
      Else
        _ActiveStateEventName = Ctype(Reader(AliasName & "_ActiveStateEventName"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
