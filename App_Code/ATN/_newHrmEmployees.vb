Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class newHrmEmployees
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _EmployeeName As String = ""
    Private _C_DivisionID As String = ""
    Private _C_OfficeID As String = ""
    Private _C_DepartmentID As String = ""
    Private _C_DesignationID As String = ""
    Private _ActiveState As Boolean = False
    Private _CategoryID As String = ""
    Private _Salute As String = ""
    Private _Gender As String = ""
    Private _C_DateOfJoining As String = ""
    Private _C_ProjectSiteID As String = ""
    Private _C_BasicSalary As String = "0.00"
    Private _C_StatusID As String = ""
    Private _Resigned As Boolean = False
    Private _C_ResignedOn As String = ""
    Private _C_DateOfReleaving As String = ""
    Private _C_ResignedRemark As String = ""
    Private _Confirmed As Boolean = False
    Private _C_ConfirmedOn As String = ""
    Private _C_ConfirmationRemark As String = ""
    Private _DateOfBirth As String = ""
    Private _FatherName As String = ""
    Private _ContactNumbers As String = ""
    Private _OfficeFileNumber As String = ""
    Private _PFNumber As String = ""
    Private _PAN As String = ""
    Private _ModifiedBy As String = ""
    Private _Freezed As Boolean = False
    Private _ESINumber As String = ""
    Private _VerifierID As String = ""
    Private _VerificationRequired As Boolean = False
    Private _C_CompanyID As String = ""
    Private _ApprovalRequired As Boolean = False
    Private _ModifiedOn As String = ""
    Private _EMailID As String = ""
    Private _ApproverID As String = ""
    Private _Contractual As Boolean = False
    Private _SiteAllowanceApprover As String = ""
    Private _TASelfApproval As Boolean = False
    Private _NonTechnical As Boolean = False
    Private _TAVerifier As String = ""
    Private _TASanctioningAuthority As String = ""
    Private _TAApprover As String = ""
    Private _HRM_Companies2_Description As String = ""
    Private _HRM_Departments6_Description As String = ""
    Private _HRM_Designations9_Description As String = ""
    Private _HRM_Divisions12_Description As String = ""
    Private _HRM_Employees15_EmployeeName As String = ""
    Private _HRM_Employees16_EmployeeName As String = ""
    Private _HRM_Employees17_EmployeeName As String = ""
    Private _HRM_Employees18_EmployeeName As String = ""
    Private _HRM_Employees19_EmployeeName As String = ""
    Private _HRM_Employees20_EmployeeName As String = ""
    Private _HRM_Offices26_Description As String = ""
    Private _IDM_Projects36_Description As String = ""
    Private _TA_Categories40_CategoryDescription As String = ""
    Private _FK_HRM_Employees_HRM_Companies As SIS.ATN.hrmCompanies = Nothing
    Private _FK_HRM_Employees_HRM_Departments As SIS.ATN.hrmDepartments = Nothing
    Private _FK_HRM_Employees_HRM_Designations As SIS.ATN.hrmDesignations = Nothing
    Private _FK_HRM_Employees_HRM_Divisions As SIS.ATN.hrmDivisions = Nothing
    Private _FK_HRM_Employees_SiteAllowanceApprover As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_HRM_Employees_VerifierID As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_HRM_Employees_ApproverID As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_HRM_Employees_TAVerifier As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_HRM_Employees_TAApprover As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_HRM_Employees_TASanctioningAuthority As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_HRM_Employees_HRM_Offices As SIS.ATN.hrmOffices = Nothing
    Private _FK_HRM_C_ProjectSiteID As SIS.ATN.idmProjects = Nothing
    Private _FK_HRM_Employees_CategoryID As SIS.ATN.taCategories = Nothing
    Public Property FieldExpeditor As Boolean = False
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
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
    Public Property C_DivisionID() As String
      Get
        Return _C_DivisionID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
          _ActiveState = False
        Else
          _ActiveState = value
        End If
      End Set
    End Property
    Public Property CategoryID() As String
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CategoryID = ""
        Else
          _CategoryID = value
        End If
      End Set
    End Property
    Public Property Salute() As String
      Get
        Return _Salute
      End Get
      Set(ByVal value As String)
        _Salute = value
      End Set
    End Property
    Public Property Gender() As String
      Get
        Return _Gender
      End Get
      Set(ByVal value As String)
        _Gender = value
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
        If Convert.IsDBNull(value) Then
          _C_DateOfJoining = ""
        Else
          _C_DateOfJoining = value
        End If
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
    Public Property C_BasicSalary() As String
      Get
        Return _C_BasicSalary
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_BasicSalary = "0.00"
        Else
          _C_BasicSalary = value
        End If
      End Set
    End Property
    Public Property C_StatusID() As String
      Get
        Return _C_StatusID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_StatusID = ""
        Else
          _C_StatusID = value
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
    Public Property C_ResignedOn() As String
      Get
        If Not _C_ResignedOn = String.Empty Then
          Return Convert.ToDateTime(_C_ResignedOn).ToString("dd/MM/yyyy")
        End If
        Return _C_ResignedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_ResignedOn = ""
        Else
          _C_ResignedOn = value
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
        If Convert.IsDBNull(value) Then
          _C_DateOfReleaving = ""
        Else
          _C_DateOfReleaving = value
        End If
      End Set
    End Property
    Public Property C_ResignedRemark() As String
      Get
        Return _C_ResignedRemark
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_ResignedRemark = ""
        Else
          _C_ResignedRemark = value
        End If
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
    Public Property C_ConfirmedOn() As String
      Get
        If Not _C_ConfirmedOn = String.Empty Then
          Return Convert.ToDateTime(_C_ConfirmedOn).ToString("dd/MM/yyyy")
        End If
        Return _C_ConfirmedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_ConfirmedOn = ""
        Else
          _C_ConfirmedOn = value
        End If
      End Set
    End Property
    Public Property C_ConfirmationRemark() As String
      Get
        Return _C_ConfirmationRemark
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_ConfirmationRemark = ""
        Else
          _C_ConfirmationRemark = value
        End If
      End Set
    End Property
    Public Property DateOfBirth() As String
      Get
        If Not _DateOfBirth = String.Empty Then
          Return Convert.ToDateTime(_DateOfBirth).ToString("dd/MM/yyyy")
        End If
        Return _DateOfBirth
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DateOfBirth = ""
        Else
          _DateOfBirth = value
        End If
      End Set
    End Property
    Public Property FatherName() As String
      Get
        Return _FatherName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _FatherName = ""
        Else
          _FatherName = value
        End If
      End Set
    End Property
    Public Property ContactNumbers() As String
      Get
        Return _ContactNumbers
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ContactNumbers = ""
        Else
          _ContactNumbers = value
        End If
      End Set
    End Property
    Public Property OfficeFileNumber() As String
      Get
        Return _OfficeFileNumber
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OfficeFileNumber = ""
        Else
          _OfficeFileNumber = value
        End If
      End Set
    End Property
    Public Property PFNumber() As String
      Get
        Return _PFNumber
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PFNumber = ""
        Else
          _PFNumber = value
        End If
      End Set
    End Property
    Public Property PAN() As String
      Get
        Return _PAN
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAN = ""
        Else
          _PAN = value
        End If
      End Set
    End Property
    Public Property ModifiedBy() As String
      Get
        Return _ModifiedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModifiedBy = ""
        Else
          _ModifiedBy = value
        End If
      End Set
    End Property
    Public Property Freezed() As Boolean
      Get
        Return _Freezed
      End Get
      Set(ByVal value As Boolean)
        _Freezed = value
      End Set
    End Property
    Public Property ESINumber() As String
      Get
        Return _ESINumber
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ESINumber = ""
        Else
          _ESINumber = value
        End If
      End Set
    End Property
    Public Property VerifierID() As String
      Get
        Return _VerifierID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifierID = ""
        Else
          _VerifierID = value
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
    Public Property C_CompanyID() As String
      Get
        Return _C_CompanyID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _C_CompanyID = ""
        Else
          _C_CompanyID = value
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
    Public Property ModifiedOn() As String
      Get
        If Not _ModifiedOn = String.Empty Then
          Return Convert.ToDateTime(_ModifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _ModifiedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModifiedOn = ""
        Else
          _ModifiedOn = value
        End If
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _EMailID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _EMailID = ""
        Else
          _EMailID = value
        End If
      End Set
    End Property
    Public Property ApproverID() As String
      Get
        Return _ApproverID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApproverID = ""
        Else
          _ApproverID = value
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
    Public Property SiteAllowanceApprover() As String
      Get
        Return _SiteAllowanceApprover
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SiteAllowanceApprover = ""
        Else
          _SiteAllowanceApprover = value
        End If
      End Set
    End Property
    Public Property TASelfApproval() As Boolean
      Get
        Return _TASelfApproval
      End Get
      Set(ByVal value As Boolean)
        _TASelfApproval = value
      End Set
    End Property
    Public Property NonTechnical() As Boolean
      Get
        Return _NonTechnical
      End Get
      Set(ByVal value As Boolean)
        If Convert.IsDBNull(value) Then
          _NonTechnical = False
        Else
          _NonTechnical = value
        End If
      End Set
    End Property
    Public Property TAVerifier() As String
      Get
        Return _TAVerifier
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TAVerifier = ""
        Else
          _TAVerifier = value
        End If
      End Set
    End Property
    Public Property TASanctioningAuthority() As String
      Get
        Return _TASanctioningAuthority
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TASanctioningAuthority = ""
        Else
          _TASanctioningAuthority = value
        End If
      End Set
    End Property
    Public Property TAApprover() As String
      Get
        Return _TAApprover
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TAApprover = ""
        Else
          _TAApprover = value
        End If
      End Set
    End Property
    Public Property HRM_Companies2_Description() As String
      Get
        Return _HRM_Companies2_Description
      End Get
      Set(ByVal value As String)
        _HRM_Companies2_Description = value
      End Set
    End Property
    Public Property HRM_Departments6_Description() As String
      Get
        Return _HRM_Departments6_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments6_Description = value
      End Set
    End Property
    Public Property HRM_Designations9_Description() As String
      Get
        Return _HRM_Designations9_Description
      End Get
      Set(ByVal value As String)
        _HRM_Designations9_Description = value
      End Set
    End Property
    Public Property HRM_Divisions12_Description() As String
      Get
        Return _HRM_Divisions12_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions12_Description = value
      End Set
    End Property
    Public Property HRM_Employees15_EmployeeName() As String
      Get
        Return _HRM_Employees15_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees15_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees16_EmployeeName() As String
      Get
        Return _HRM_Employees16_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees16_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees17_EmployeeName() As String
      Get
        Return _HRM_Employees17_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees17_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees18_EmployeeName() As String
      Get
        Return _HRM_Employees18_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees18_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees19_EmployeeName() As String
      Get
        Return _HRM_Employees19_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees19_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees20_EmployeeName() As String
      Get
        Return _HRM_Employees20_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees20_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Offices26_Description() As String
      Get
        Return _HRM_Offices26_Description
      End Get
      Set(ByVal value As String)
        _HRM_Offices26_Description = value
      End Set
    End Property
    Public Property IDM_Projects36_Description() As String
      Get
        Return _IDM_Projects36_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects36_Description = value
      End Set
    End Property
    Public Property TA_Categories40_CategoryDescription() As String
      Get
        Return _TA_Categories40_CategoryDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Categories40_CategoryDescription = ""
        Else
          _TA_Categories40_CategoryDescription = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _EmployeeName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _CardNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKnewHrmEmployees
      Private _CardNo As String = ""
      Public Property CardNo() As String
        Get
          Return _CardNo
        End Get
        Set(ByVal value As String)
          _CardNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_HRM_Employees_HRM_Companies() As SIS.ATN.hrmCompanies
      Get
        If _FK_HRM_Employees_HRM_Companies Is Nothing Then
          _FK_HRM_Employees_HRM_Companies = SIS.ATN.hrmCompanies.GetByID(_C_CompanyID)
        End If
        Return _FK_HRM_Employees_HRM_Companies
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Departments() As SIS.ATN.hrmDepartments
      Get
        If _FK_HRM_Employees_HRM_Departments Is Nothing Then
          _FK_HRM_Employees_HRM_Departments = SIS.ATN.hrmDepartments.GetByID(_C_DepartmentID)
        End If
        Return _FK_HRM_Employees_HRM_Departments
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Designations() As SIS.ATN.hrmDesignations
      Get
        If _FK_HRM_Employees_HRM_Designations Is Nothing Then
          _FK_HRM_Employees_HRM_Designations = SIS.ATN.hrmDesignations.GetByID(_C_DesignationID)
        End If
        Return _FK_HRM_Employees_HRM_Designations
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Divisions() As SIS.ATN.hrmDivisions
      Get
        If _FK_HRM_Employees_HRM_Divisions Is Nothing Then
          _FK_HRM_Employees_HRM_Divisions = SIS.ATN.hrmDivisions.GetByID(_C_DivisionID)
        End If
        Return _FK_HRM_Employees_HRM_Divisions
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_SiteAllowanceApprover() As SIS.ATN.newHrmEmployees
      Get
        If _FK_HRM_Employees_SiteAllowanceApprover Is Nothing Then
          _FK_HRM_Employees_SiteAllowanceApprover = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_SiteAllowanceApprover)
        End If
        Return _FK_HRM_Employees_SiteAllowanceApprover
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_VerifierID() As SIS.ATN.newHrmEmployees
      Get
        If _FK_HRM_Employees_VerifierID Is Nothing Then
          _FK_HRM_Employees_VerifierID = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_VerifierID)
        End If
        Return _FK_HRM_Employees_VerifierID
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_ApproverID() As SIS.ATN.newHrmEmployees
      Get
        If _FK_HRM_Employees_ApproverID Is Nothing Then
          _FK_HRM_Employees_ApproverID = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_ApproverID)
        End If
        Return _FK_HRM_Employees_ApproverID
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_TAVerifier() As SIS.ATN.newHrmEmployees
      Get
        If _FK_HRM_Employees_TAVerifier Is Nothing Then
          _FK_HRM_Employees_TAVerifier = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_TAVerifier)
        End If
        Return _FK_HRM_Employees_TAVerifier
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_TAApprover() As SIS.ATN.newHrmEmployees
      Get
        If _FK_HRM_Employees_TAApprover Is Nothing Then
          _FK_HRM_Employees_TAApprover = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_TAApprover)
        End If
        Return _FK_HRM_Employees_TAApprover
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_TASanctioningAuthority() As SIS.ATN.newHrmEmployees
      Get
        If _FK_HRM_Employees_TASanctioningAuthority Is Nothing Then
          _FK_HRM_Employees_TASanctioningAuthority = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_TASanctioningAuthority)
        End If
        Return _FK_HRM_Employees_TASanctioningAuthority
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Offices() As SIS.ATN.hrmOffices
      Get
        If _FK_HRM_Employees_HRM_Offices Is Nothing Then
          _FK_HRM_Employees_HRM_Offices = SIS.ATN.hrmOffices.GetByID(_C_OfficeID)
        End If
        Return _FK_HRM_Employees_HRM_Offices
      End Get
    End Property
    Public ReadOnly Property FK_HRM_C_ProjectSiteID() As SIS.ATN.idmProjects
      Get
        If _FK_HRM_C_ProjectSiteID Is Nothing Then
          _FK_HRM_C_ProjectSiteID = SIS.ATN.idmProjects.idmProjectsGetByID(_C_ProjectSiteID)
        End If
        Return _FK_HRM_C_ProjectSiteID
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_CategoryID() As SIS.ATN.taCategories
      Get
        If _FK_HRM_Employees_CategoryID Is Nothing Then
          _FK_HRM_Employees_CategoryID = SIS.ATN.taCategories.taCategoriesGetByID(_CategoryID)
        End If
        Return _FK_HRM_Employees_CategoryID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function newHrmEmployeesSelectList(ByVal OrderBy As String) As List(Of SIS.ATN.newHrmEmployees)
      Dim Results As List(Of SIS.ATN.newHrmEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "EmployeeName"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnewHrmEmployeesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.newHrmEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.newHrmEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function newHrmEmployeesGetNewRecord() As SIS.ATN.newHrmEmployees
      Return New SIS.ATN.newHrmEmployees()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function newHrmEmployeesGetByID(ByVal CardNo As String) As SIS.ATN.newHrmEmployees
      Dim Results As SIS.ATN.newHrmEmployees = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnewHrmEmployeesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.newHrmEmployees(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function newHrmEmployeesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal C_OfficeID As Int32, ByVal C_DepartmentID As String, ByVal C_DesignationID As Int32, ByVal CategoryID As Int32) As List(Of SIS.ATN.newHrmEmployees)
      Dim Results As List(Of SIS.ATN.newHrmEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "EmployeeName"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnewHrmEmployeesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnewHrmEmployeesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.NVarChar, 8, IIf(CardNo Is Nothing, String.Empty, CardNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_OfficeID", SqlDbType.Int, 10, IIf(C_OfficeID = Nothing, 0, C_OfficeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DepartmentID", SqlDbType.NVarChar, 6, IIf(C_DepartmentID Is Nothing, String.Empty, C_DepartmentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DesignationID", SqlDbType.Int, 10, IIf(C_DesignationID = Nothing, 0, C_DesignationID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryID", SqlDbType.Int, 10, IIf(CategoryID = Nothing, 0, CategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.newHrmEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.newHrmEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function newHrmEmployeesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal C_OfficeID As Int32, ByVal C_DepartmentID As String, ByVal C_DesignationID As Int32, ByVal CategoryID As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function newHrmEmployeesGetByID(ByVal CardNo As String, ByVal Filter_CardNo As String, ByVal Filter_C_OfficeID As Int32, ByVal Filter_C_DepartmentID As String, ByVal Filter_C_DesignationID As Int32, ByVal Filter_CategoryID As Int32) As SIS.ATN.newHrmEmployees
      Return newHrmEmployeesGetByID(CardNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function newHrmEmployeesInsert(ByVal Record As SIS.ATN.newHrmEmployees) As SIS.ATN.newHrmEmployees
      Dim _Rec As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetNewRecord()
      With _Rec
        .CardNo = Record.CardNo
        .EmployeeName = Record.EmployeeName
        .C_DivisionID = Record.C_DivisionID
        .C_OfficeID = Record.C_OfficeID
        .C_DepartmentID = Record.C_DepartmentID
        .C_DesignationID = Record.C_DesignationID
        .ActiveState = Record.ActiveState
        .CategoryID = Record.CategoryID
        .Salute = Record.Salute
        .Gender = Record.Gender
        .C_DateOfJoining = Record.C_DateOfJoining
        .C_ProjectSiteID = Record.C_ProjectSiteID
        .C_BasicSalary = Record.C_BasicSalary
        .C_StatusID = Record.C_StatusID
        .Resigned = Record.Resigned
        .C_ResignedOn = Record.C_ResignedOn
        .C_DateOfReleaving = Record.C_DateOfReleaving
        .C_ResignedRemark = Record.C_ResignedRemark
        .Confirmed = Record.Confirmed
        .C_ConfirmedOn = Record.C_ConfirmedOn
        .C_ConfirmationRemark = Record.C_ConfirmationRemark
        .DateOfBirth = Record.DateOfBirth
        .FatherName = Record.FatherName
        .ContactNumbers = Record.ContactNumbers
        .OfficeFileNumber = Record.OfficeFileNumber
        .PFNumber = Record.PFNumber
        .PAN = Record.PAN
        .ModifiedBy = Record.ModifiedBy
        .Freezed = Record.Freezed
        .ESINumber = Record.ESINumber
        .VerifierID = Record.VerifierID
        .VerificationRequired = Record.VerificationRequired
        .C_CompanyID = Record.C_CompanyID
        .ApprovalRequired = Record.ApprovalRequired
        .ModifiedOn = Record.ModifiedOn
        .EMailID = Record.EMailID
        .ApproverID = Record.ApproverID
        .Contractual = Record.Contractual
        .SiteAllowanceApprover = Record.SiteAllowanceApprover
        .TASelfApproval = Record.TASelfApproval
        .NonTechnical = Record.NonTechnical
        .TAVerifier = Record.TAVerifier
        .TASanctioningAuthority = Record.TASanctioningAuthority
        .TAApprover = Record.TAApprover
        .FieldExpeditor = Record.FieldExpeditor
      End With
      Return SIS.ATN.newHrmEmployees.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.newHrmEmployees) As SIS.ATN.newHrmEmployees
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnewHrmEmployeesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeName", SqlDbType.NVarChar, 51, Record.EmployeeName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID", SqlDbType.NVarChar, 7, IIf(Record.C_DivisionID = "", Convert.DBNull, Record.C_DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID", SqlDbType.Int, 11, IIf(Record.C_OfficeID = "", Convert.DBNull, Record.C_OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.C_DepartmentID = "", Convert.DBNull, Record.C_DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID", SqlDbType.Int, 11, IIf(Record.C_DesignationID = "", Convert.DBNull, Record.C_DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 3, Record.ActiveState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID", SqlDbType.Int, 11, IIf(Record.CategoryID = "", Convert.DBNull, Record.CategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Salute", SqlDbType.NVarChar, 51, Record.Salute)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Gender", SqlDbType.NVarChar, 2, Record.Gender)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining", SqlDbType.DateTime, 21, IIf(Record.C_DateOfJoining = "", Convert.DBNull, Record.C_DateOfJoining))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ProjectSiteID", SqlDbType.NVarChar, 7, IIf(Record.C_ProjectSiteID = "", Convert.DBNull, Record.C_ProjectSiteID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_BasicSalary", SqlDbType.Decimal, 15, IIf(Record.C_BasicSalary = "", Convert.DBNull, Record.C_BasicSalary))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_StatusID", SqlDbType.NVarChar, 3, IIf(Record.C_StatusID = "", Convert.DBNull, Record.C_StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Resigned", SqlDbType.Bit, 3, Record.Resigned)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ResignedOn", SqlDbType.DateTime, 21, IIf(Record.C_ResignedOn = "", Convert.DBNull, Record.C_ResignedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfReleaving", SqlDbType.DateTime, 21, IIf(Record.C_DateOfReleaving = "", Convert.DBNull, Record.C_DateOfReleaving))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ResignedRemark", SqlDbType.NVarChar, 251, IIf(Record.C_ResignedRemark = "", Convert.DBNull, Record.C_ResignedRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Confirmed", SqlDbType.Bit, 3, Record.Confirmed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ConfirmedOn", SqlDbType.DateTime, 21, IIf(Record.C_ConfirmedOn = "", Convert.DBNull, Record.C_ConfirmedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ConfirmationRemark", SqlDbType.NVarChar, 251, IIf(Record.C_ConfirmationRemark = "", Convert.DBNull, Record.C_ConfirmationRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DateOfBirth", SqlDbType.DateTime, 21, IIf(Record.DateOfBirth = "", Convert.DBNull, Record.DateOfBirth))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FatherName", SqlDbType.NVarChar, 51, IIf(Record.FatherName = "", Convert.DBNull, Record.FatherName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContactNumbers", SqlDbType.NVarChar, 101, IIf(Record.ContactNumbers = "", Convert.DBNull, Record.ContactNumbers))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeFileNumber", SqlDbType.NVarChar, 51, IIf(Record.OfficeFileNumber = "", Convert.DBNull, Record.OfficeFileNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PFNumber", SqlDbType.NVarChar, 51, IIf(Record.PFNumber = "", Convert.DBNull, Record.PFNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PAN", SqlDbType.NVarChar, 21, IIf(Record.PAN = "", Convert.DBNull, Record.PAN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy", SqlDbType.NVarChar, 21, IIf(Record.ModifiedBy = "", Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Freezed", SqlDbType.Bit, 3, Record.Freezed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESINumber", SqlDbType.NVarChar, 51, IIf(Record.ESINumber = "", Convert.DBNull, Record.ESINumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierID", SqlDbType.NVarChar, 9, IIf(Record.VerifierID = "", Convert.DBNull, Record.VerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired", SqlDbType.Bit, 3, Record.VerificationRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID", SqlDbType.NVarChar, 7, IIf(Record.C_CompanyID = "", Convert.DBNull, Record.C_CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired", SqlDbType.Bit, 3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn", SqlDbType.DateTime, 21, IIf(Record.ModifiedOn = "", Convert.DBNull, Record.ModifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID", SqlDbType.NVarChar, 51, IIf(Record.EMailID = "", Convert.DBNull, Record.EMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID", SqlDbType.NVarChar, 9, IIf(Record.ApproverID = "", Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual", SqlDbType.Bit, 3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAllowanceApprover", SqlDbType.NVarChar, 9, IIf(Record.SiteAllowanceApprover = "", Convert.DBNull, Record.SiteAllowanceApprover))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASelfApproval", SqlDbType.Bit, 3, Record.TASelfApproval)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonTechnical", SqlDbType.Bit, 3, Record.NonTechnical)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAVerifier", SqlDbType.NVarChar, 9, IIf(Record.TAVerifier = "", Convert.DBNull, Record.TAVerifier))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASanctioningAuthority", SqlDbType.NVarChar, 9, IIf(Record.TASanctioningAuthority = "", Convert.DBNull, Record.TASanctioningAuthority))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAApprover", SqlDbType.NVarChar, 9, IIf(Record.TAApprover = "", Convert.DBNull, Record.TAApprover))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FieldExpeditor", SqlDbType.Bit, 3, Record.FieldExpeditor)
          Cmd.Parameters.Add("@Return_CardNo", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_CardNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.CardNo = Cmd.Parameters("@Return_CardNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function newHrmEmployeesUpdate(ByVal Record As SIS.ATN.newHrmEmployees) As SIS.ATN.newHrmEmployees
      Dim _Rec As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(Record.CardNo)
      With _Rec
        .EmployeeName = Record.EmployeeName
        .C_DivisionID = Record.C_DivisionID
        .C_OfficeID = Record.C_OfficeID
        .C_DepartmentID = Record.C_DepartmentID
        .C_DesignationID = Record.C_DesignationID
        .ActiveState = Record.ActiveState
        .CategoryID = Record.CategoryID
        .Salute = Record.Salute
        .Gender = Record.Gender
        .C_DateOfJoining = Record.C_DateOfJoining
        .C_ProjectSiteID = Record.C_ProjectSiteID
        .C_BasicSalary = Record.C_BasicSalary
        .C_StatusID = Record.C_StatusID
        .Resigned = Record.Resigned
        .C_ResignedOn = Record.C_ResignedOn
        .C_DateOfReleaving = Record.C_DateOfReleaving
        .C_ResignedRemark = Record.C_ResignedRemark
        .Confirmed = Record.Confirmed
        .C_ConfirmedOn = Record.C_ConfirmedOn
        .C_ConfirmationRemark = Record.C_ConfirmationRemark
        .DateOfBirth = Record.DateOfBirth
        .FatherName = Record.FatherName
        .ContactNumbers = Record.ContactNumbers
        .OfficeFileNumber = Record.OfficeFileNumber
        .PFNumber = Record.PFNumber
        .PAN = Record.PAN
        .ModifiedBy = Record.ModifiedBy
        .Freezed = Record.Freezed
        .ESINumber = Record.ESINumber
        .VerifierID = Record.VerifierID
        .VerificationRequired = Record.VerificationRequired
        .C_CompanyID = Record.C_CompanyID
        .ApprovalRequired = Record.ApprovalRequired
        .ModifiedOn = Record.ModifiedOn
        .EMailID = Record.EMailID
        .ApproverID = Record.ApproverID
        .Contractual = Record.Contractual
        .SiteAllowanceApprover = Record.SiteAllowanceApprover
        .TASelfApproval = Record.TASelfApproval
        .NonTechnical = Record.NonTechnical
        .TAVerifier = Record.TAVerifier
        .TASanctioningAuthority = Record.TASanctioningAuthority
        .TAApprover = Record.TAApprover
        .FieldExpeditor = Record.FieldExpeditor
      End With
      Return SIS.ATN.newHrmEmployees.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.newHrmEmployees) As SIS.ATN.newHrmEmployees
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnewHrmEmployeesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeName", SqlDbType.NVarChar, 51, Record.EmployeeName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID", SqlDbType.NVarChar, 7, IIf(Record.C_DivisionID = "", Convert.DBNull, Record.C_DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID", SqlDbType.Int, 11, IIf(Record.C_OfficeID = "", Convert.DBNull, Record.C_OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.C_DepartmentID = "", Convert.DBNull, Record.C_DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID", SqlDbType.Int, 11, IIf(Record.C_DesignationID = "", Convert.DBNull, Record.C_DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 3, Record.ActiveState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID", SqlDbType.Int, 11, IIf(Record.CategoryID = "", Convert.DBNull, Record.CategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Salute", SqlDbType.NVarChar, 51, Record.Salute)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Gender", SqlDbType.NVarChar, 2, Record.Gender)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining", SqlDbType.DateTime, 21, IIf(Record.C_DateOfJoining = "", Convert.DBNull, Record.C_DateOfJoining))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ProjectSiteID", SqlDbType.NVarChar, 7, IIf(Record.C_ProjectSiteID = "", Convert.DBNull, Record.C_ProjectSiteID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_BasicSalary", SqlDbType.Decimal, 15, IIf(Record.C_BasicSalary = "", Convert.DBNull, Record.C_BasicSalary))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_StatusID", SqlDbType.NVarChar, 3, IIf(Record.C_StatusID = "", Convert.DBNull, Record.C_StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Resigned", SqlDbType.Bit, 3, Record.Resigned)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ResignedOn", SqlDbType.DateTime, 21, IIf(Record.C_ResignedOn = "", Convert.DBNull, Record.C_ResignedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfReleaving", SqlDbType.DateTime, 21, IIf(Record.C_DateOfReleaving = "", Convert.DBNull, Record.C_DateOfReleaving))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ResignedRemark", SqlDbType.NVarChar, 251, IIf(Record.C_ResignedRemark = "", Convert.DBNull, Record.C_ResignedRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Confirmed", SqlDbType.Bit, 3, Record.Confirmed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ConfirmedOn", SqlDbType.DateTime, 21, IIf(Record.C_ConfirmedOn = "", Convert.DBNull, Record.C_ConfirmedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ConfirmationRemark", SqlDbType.NVarChar, 251, IIf(Record.C_ConfirmationRemark = "", Convert.DBNull, Record.C_ConfirmationRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DateOfBirth", SqlDbType.DateTime, 21, IIf(Record.DateOfBirth = "", Convert.DBNull, Record.DateOfBirth))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FatherName", SqlDbType.NVarChar, 51, IIf(Record.FatherName = "", Convert.DBNull, Record.FatherName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContactNumbers", SqlDbType.NVarChar, 101, IIf(Record.ContactNumbers = "", Convert.DBNull, Record.ContactNumbers))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeFileNumber", SqlDbType.NVarChar, 51, IIf(Record.OfficeFileNumber = "", Convert.DBNull, Record.OfficeFileNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PFNumber", SqlDbType.NVarChar, 51, IIf(Record.PFNumber = "", Convert.DBNull, Record.PFNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PAN", SqlDbType.NVarChar, 21, IIf(Record.PAN = "", Convert.DBNull, Record.PAN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy", SqlDbType.NVarChar, 21, IIf(Record.ModifiedBy = "", Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Freezed", SqlDbType.Bit, 3, Record.Freezed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESINumber", SqlDbType.NVarChar, 51, IIf(Record.ESINumber = "", Convert.DBNull, Record.ESINumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierID", SqlDbType.NVarChar, 9, IIf(Record.VerifierID = "", Convert.DBNull, Record.VerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired", SqlDbType.Bit, 3, Record.VerificationRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID", SqlDbType.NVarChar, 7, IIf(Record.C_CompanyID = "", Convert.DBNull, Record.C_CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired", SqlDbType.Bit, 3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn", SqlDbType.DateTime, 21, IIf(Record.ModifiedOn = "", Convert.DBNull, Record.ModifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID", SqlDbType.NVarChar, 51, IIf(Record.EMailID = "", Convert.DBNull, Record.EMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID", SqlDbType.NVarChar, 9, IIf(Record.ApproverID = "", Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual", SqlDbType.Bit, 3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAllowanceApprover", SqlDbType.NVarChar, 9, IIf(Record.SiteAllowanceApprover = "", Convert.DBNull, Record.SiteAllowanceApprover))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASelfApproval", SqlDbType.Bit, 3, Record.TASelfApproval)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonTechnical", SqlDbType.Bit, 3, Record.NonTechnical)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAVerifier", SqlDbType.NVarChar, 9, IIf(Record.TAVerifier = "", Convert.DBNull, Record.TAVerifier))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASanctioningAuthority", SqlDbType.NVarChar, 9, IIf(Record.TASanctioningAuthority = "", Convert.DBNull, Record.TASanctioningAuthority))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAApprover", SqlDbType.NVarChar, 9, IIf(Record.TAApprover = "", Convert.DBNull, Record.TAApprover))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FieldExpeditor", SqlDbType.Bit, 3, Record.FieldExpeditor)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function newHrmEmployeesDelete(ByVal Record As SIS.ATN.newHrmEmployees) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnewHrmEmployeesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, Record.CardNo.ToString.Length, Record.CardNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    '    Autocomplete Method
    Public Shared Function SelectnewHrmEmployeesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnewHrmEmployeesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "), ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.ATN.newHrmEmployees = New SIS.ATN.newHrmEmployees(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
