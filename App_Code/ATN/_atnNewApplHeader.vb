Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnNewApplHeader
    Private Shared _RecordCount As Integer
    Private _LeaveApplID As Int32 = 0
    Private _CardNo As String = ""
    Private _Approved As String = ""
    Private _Rejected As String = ""
    Private _Application As String = ""
    Private _Remarks As String = ""
    Private _FinYear As String = ""
    Private _ApplStatusID As Int32 = 0
    Private _AppliedOn As String = ""
    Private _VerificationOn As String = ""
    Private _ApprovalOn As String = ""
    Private _SanctionOn As String = ""
    Private _PostedOn As String = ""
    Private _VerificationRequired As Boolean = False
    Private _ApprovalRequired As Boolean = False
    Private _SanctionRequired As Boolean = False
    Private _VerifiedBy As String = ""
    Private _ApprovedBy As String = ""
    Private _SanctionedBy As String = ""
    Private _PostedBy As String = ""
    Private _VerificationRemark As String = ""
    Private _ApprovalRemark As String = ""
    Private _SanctionRemark As String = ""
    Private _PostingRemark As String = ""
    Private _AdvanceApplication As Boolean = False
    Private _ExecutionState As String = ""
    Private _ATN_ApplicationStatus1_Description As String = ""
    Private _ATN_ExecutionStates2_Description As String = ""
    Private _HRM_Employees3_EmployeeName As String = ""
    Private _HRM_Employees4_EmployeeName As String = ""
    Private _HRM_Employees5_EmployeeName As String = ""
    Private _HRM_Employees6_EmployeeName As String = ""
    Private _HRM_Employees7_EmployeeName As String = ""
    Private _FK_ATN_ApplHeader_ATN_ApplicationStatus As SIS.ATN.atnApplicationStatus = Nothing
    Private _FK_ATN_ApplHeader_ATN_ExecutionStates As SIS.ATN.atnExecutionStates = Nothing
    Private _FK_ATN_ApplHeader_HRM_Employees As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApplHeader_HRM_Employees1 As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApplHeader_HRM_Employees2 As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApplHeader_HRM_Employees3 As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApplHeader_HRM_Employees4 As SIS.ATN.atnEmployees = Nothing
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
    Public Property LeaveApplID() As Int32
      Get
        Return _LeaveApplID
      End Get
      Set(ByVal value As Int32)
        _LeaveApplID = value
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
    Public Property Approved() As String
      Get
        Return _Approved
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Approved = ""
         Else
           _Approved = value
         End If
      End Set
    End Property
    Public Property Rejected() As String
      Get
        Return _Rejected
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Rejected = ""
         Else
           _Rejected = value
         End If
      End Set
    End Property
    Public Property Application() As String
      Get
        Return _Application
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Application = ""
         Else
           _Application = value
         End If
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
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
      End Set
    End Property
    Public Property ApplStatusID() As Int32
      Get
        Return _ApplStatusID
      End Get
      Set(ByVal value As Int32)
        _ApplStatusID = value
      End Set
    End Property
    Public Property AppliedOn() As String
      Get
        If Not _AppliedOn = String.Empty Then
          Return Convert.ToDateTime(_AppliedOn).ToString("dd/MM/yyyy")
        End If
        Return _AppliedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AppliedOn = ""
         Else
           _AppliedOn = value
         End If
      End Set
    End Property
    Public Property VerificationOn() As String
      Get
        If Not _VerificationOn = String.Empty Then
          Return Convert.ToDateTime(_VerificationOn).ToString("dd/MM/yyyy")
        End If
        Return _VerificationOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VerificationOn = ""
         Else
           _VerificationOn = value
         End If
      End Set
    End Property
    Public Property ApprovalOn() As String
      Get
        If Not _ApprovalOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovalOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovalOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovalOn = ""
         Else
           _ApprovalOn = value
         End If
      End Set
    End Property
    Public Property SanctionOn() As String
      Get
        If Not _SanctionOn = String.Empty Then
          Return Convert.ToDateTime(_SanctionOn).ToString("dd/MM/yyyy")
        End If
        Return _SanctionOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SanctionOn = ""
         Else
           _SanctionOn = value
         End If
      End Set
    End Property
    Public Property PostedOn() As String
      Get
        If Not _PostedOn = String.Empty Then
          Return Convert.ToDateTime(_PostedOn).ToString("dd/MM/yyyy")
        End If
        Return _PostedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedOn = ""
         Else
           _PostedOn = value
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
    Public Property ApprovalRequired() As Boolean
      Get
        Return _ApprovalRequired
      End Get
      Set(ByVal value As Boolean)
        _ApprovalRequired = value
      End Set
    End Property
    Public Property SanctionRequired() As Boolean
      Get
        Return _SanctionRequired
      End Get
      Set(ByVal value As Boolean)
        _SanctionRequired = value
      End Set
    End Property
    Public Property VerifiedBy() As String
      Get
        Return _VerifiedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VerifiedBy = ""
         Else
           _VerifiedBy = value
         End If
      End Set
    End Property
    Public Property ApprovedBy() As String
      Get
        Return _ApprovedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedBy = ""
         Else
           _ApprovedBy = value
         End If
      End Set
    End Property
    Public Property SanctionedBy() As String
      Get
        Return _SanctionedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SanctionedBy = ""
         Else
           _SanctionedBy = value
         End If
      End Set
    End Property
    Public Property PostedBy() As String
      Get
        Return _PostedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedBy = ""
         Else
           _PostedBy = value
         End If
      End Set
    End Property
    Public Property VerificationRemark() As String
      Get
        Return _VerificationRemark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VerificationRemark = ""
         Else
           _VerificationRemark = value
         End If
      End Set
    End Property
    Public Property ApprovalRemark() As String
      Get
        Return _ApprovalRemark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovalRemark = ""
         Else
           _ApprovalRemark = value
         End If
      End Set
    End Property
    Public Property SanctionRemark() As String
      Get
        Return _SanctionRemark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SanctionRemark = ""
         Else
           _SanctionRemark = value
         End If
      End Set
    End Property
    Public Property PostingRemark() As String
      Get
        Return _PostingRemark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostingRemark = ""
         Else
           _PostingRemark = value
         End If
      End Set
    End Property
    Public Property AdvanceApplication() As Boolean
      Get
        Return _AdvanceApplication
      End Get
      Set(ByVal value As Boolean)
        _AdvanceApplication = value
      End Set
    End Property
    Public Property ExecutionState() As String
      Get
        Return _ExecutionState
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExecutionState = ""
         Else
           _ExecutionState = value
         End If
      End Set
    End Property
    Public Property ATN_ApplicationStatus1_Description() As String
      Get
        Return _ATN_ApplicationStatus1_Description
      End Get
      Set(ByVal value As String)
        _ATN_ApplicationStatus1_Description = value
      End Set
    End Property
    Public Property ATN_ExecutionStates2_Description() As String
      Get
        Return _ATN_ExecutionStates2_Description
      End Get
      Set(ByVal value As String)
        _ATN_ExecutionStates2_Description = value
      End Set
    End Property
    Public Property HRM_Employees3_EmployeeName() As String
      Get
        Return _HRM_Employees3_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees3_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees4_EmployeeName() As String
      Get
        Return _HRM_Employees4_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees4_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees5_EmployeeName() As String
      Get
        Return _HRM_Employees5_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees5_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees6_EmployeeName() As String
      Get
        Return _HRM_Employees6_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees6_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees7_EmployeeName() As String
      Get
        Return _HRM_Employees7_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees7_EmployeeName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _LeaveApplID
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
    Public Class PKatnNewApplHeader
      Private _LeaveApplID As Int32 = 0
      Public Property LeaveApplID() As Int32
        Get
          Return _LeaveApplID
        End Get
        Set(ByVal value As Int32)
          _LeaveApplID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ATN_ApplHeader_ATN_ApplicationStatus() As SIS.ATN.atnApplicationStatus
      Get
        If _FK_ATN_ApplHeader_ATN_ApplicationStatus Is Nothing Then
          _FK_ATN_ApplHeader_ATN_ApplicationStatus = SIS.ATN.atnApplicationStatus.GetByID(_ApplStatusID)
        End If
        Return _FK_ATN_ApplHeader_ATN_ApplicationStatus
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApplHeader_ATN_ExecutionStates() As SIS.ATN.atnExecutionStates
      Get
        If _FK_ATN_ApplHeader_ATN_ExecutionStates Is Nothing Then
          _FK_ATN_ApplHeader_ATN_ExecutionStates = SIS.ATN.atnExecutionStates.GetByID(_ExecutionState)
        End If
        Return _FK_ATN_ApplHeader_ATN_ExecutionStates
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApplHeader_HRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApplHeader_HRM_Employees Is Nothing Then
          _FK_ATN_ApplHeader_HRM_Employees = SIS.ATN.atnEmployees.GetByID(_CardNo)
        End If
        Return _FK_ATN_ApplHeader_HRM_Employees
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApplHeader_HRM_Employees1() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApplHeader_HRM_Employees1 Is Nothing Then
          _FK_ATN_ApplHeader_HRM_Employees1 = SIS.ATN.atnEmployees.GetByID(_VerifiedBy)
        End If
        Return _FK_ATN_ApplHeader_HRM_Employees1
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApplHeader_HRM_Employees2() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApplHeader_HRM_Employees2 Is Nothing Then
          _FK_ATN_ApplHeader_HRM_Employees2 = SIS.ATN.atnEmployees.GetByID(_ApprovedBy)
        End If
        Return _FK_ATN_ApplHeader_HRM_Employees2
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApplHeader_HRM_Employees3() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApplHeader_HRM_Employees3 Is Nothing Then
          _FK_ATN_ApplHeader_HRM_Employees3 = SIS.ATN.atnEmployees.GetByID(_SanctionedBy)
        End If
        Return _FK_ATN_ApplHeader_HRM_Employees3
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApplHeader_HRM_Employees4() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApplHeader_HRM_Employees4 Is Nothing Then
          _FK_ATN_ApplHeader_HRM_Employees4 = SIS.ATN.atnEmployees.GetByID(_PostedBy)
        End If
        Return _FK_ATN_ApplHeader_HRM_Employees4
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnNewApplHeaderGetNewRecord() As SIS.ATN.atnNewApplHeader
      Return New SIS.ATN.atnNewApplHeader()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnNewApplHeaderGetByID(ByVal LeaveApplID As Int32) As SIS.ATN.atnNewApplHeader
      Dim Results As SIS.ATN.atnNewApplHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewApplHeaderSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveApplID",SqlDbType.Int,LeaveApplID.ToString.Length, LeaveApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnNewApplHeader(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnNewApplHeaderSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnNewApplHeader)
      Dim Results As List(Of SIS.ATN.atnNewApplHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnNewApplHeaderSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnNewApplHeaderSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnNewApplHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnNewApplHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnNewApplHeaderSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnNewApplHeaderGetByID(ByVal LeaveApplID As Int32, ByVal Filter_CardNo As String) As SIS.ATN.atnNewApplHeader
      Return atnNewApplHeaderGetByID(LeaveApplID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function atnNewApplHeaderInsert(ByVal Record As SIS.ATN.atnNewApplHeader) As SIS.ATN.atnNewApplHeader
      Dim _Rec As SIS.ATN.atnNewApplHeader = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetNewRecord()
      With _Rec
        .CardNo = Record.CardNo
        .Approved = Record.Approved
        .Rejected = Record.Rejected
        .Application = Record.Application
        .Remarks = Record.Remarks
        .FinYear =  Global.System.Web.HttpContext.Current.Session("FinYear")
        .ApplStatusID = Record.ApplStatusID
        .AppliedOn = Record.AppliedOn
        .VerificationRequired = Record.VerificationRequired
        .ApprovalRequired = Record.ApprovalRequired
        .SanctionRequired = Record.SanctionRequired
        .VerifiedBy = Record.VerifiedBy
        .ApprovedBy = Record.ApprovedBy
        .SanctionedBy = Record.SanctionedBy
        .AdvanceApplication = Record.AdvanceApplication
        .ExecutionState = Record.ExecutionState
      End With
      Return SIS.ATN.atnNewApplHeader.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.atnNewApplHeader) As SIS.ATN.atnNewApplHeader
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewApplHeaderInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved",SqlDbType.NVarChar,51, Iif(Record.Approved= "" ,Convert.DBNull, Record.Approved))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Rejected",SqlDbType.NVarChar,51, Iif(Record.Rejected= "" ,Convert.DBNull, Record.Rejected))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Application",SqlDbType.NVarChar,51, Iif(Record.Application= "" ,Convert.DBNull, Record.Application))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID",SqlDbType.Int,11, Record.ApplStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppliedOn",SqlDbType.DateTime,21, Iif(Record.AppliedOn= "" ,Convert.DBNull, Record.AppliedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationOn",SqlDbType.DateTime,21, Iif(Record.VerificationOn= "" ,Convert.DBNull, Record.VerificationOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalOn",SqlDbType.DateTime,21, Iif(Record.ApprovalOn= "" ,Convert.DBNull, Record.ApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionOn",SqlDbType.DateTime,21, Iif(Record.SanctionOn= "" ,Convert.DBNull, Record.SanctionOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired",SqlDbType.Bit,3, Record.VerificationRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired",SqlDbType.Bit,3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionRequired",SqlDbType.Bit,3, Record.SanctionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.NVarChar,9, Iif(Record.VerifiedBy= "" ,Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedBy",SqlDbType.NVarChar,9, Iif(Record.SanctionedBy= "" ,Convert.DBNull, Record.SanctionedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.NVarChar,9, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRemark",SqlDbType.NVarChar,101, Iif(Record.VerificationRemark= "" ,Convert.DBNull, Record.VerificationRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemark",SqlDbType.NVarChar,101, Iif(Record.ApprovalRemark= "" ,Convert.DBNull, Record.ApprovalRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionRemark",SqlDbType.NVarChar,101, Iif(Record.SanctionRemark= "" ,Convert.DBNull, Record.SanctionRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostingRemark",SqlDbType.NVarChar,101, Iif(Record.PostingRemark= "" ,Convert.DBNull, Record.PostingRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication",SqlDbType.Bit,3, Record.AdvanceApplication)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutionState",SqlDbType.Int,11, Iif(Record.ExecutionState= "" ,Convert.DBNull, Record.ExecutionState))
          Cmd.Parameters.Add("@Return_LeaveApplID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_LeaveApplID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.LeaveApplID = Cmd.Parameters("@Return_LeaveApplID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function atnNewApplHeaderUpdate(ByVal Record As SIS.ATN.atnNewApplHeader) As SIS.ATN.atnNewApplHeader
      Dim _Rec As SIS.ATN.atnNewApplHeader = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(Record.LeaveApplID)
      With _Rec
        .Approved = Record.Approved
        .Rejected = Record.Rejected
        .Application = Record.Application
        .ApplStatusID = Record.ApplStatusID
        .VerificationOn = Record.VerificationOn
        .ApprovalOn = Record.ApprovalOn
        .SanctionOn = Record.SanctionOn
        .PostedOn = Record.PostedOn
        .VerificationRequired = Record.VerificationRequired
        .ApprovalRequired = Record.ApprovalRequired
        .SanctionRequired = Record.SanctionRequired
        .VerifiedBy = Record.VerifiedBy
        .ApprovedBy = Record.ApprovedBy
        .SanctionedBy = Record.SanctionedBy
        .PostedBy = Record.PostedBy
        .VerificationRemark = Record.VerificationRemark
        .ApprovalRemark = Record.ApprovalRemark
        .SanctionRemark = Record.SanctionRemark
        .PostingRemark = Record.PostingRemark
        .ExecutionState = Record.ExecutionState
      End With
      Return SIS.ATN.atnNewApplHeader.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.atnNewApplHeader) As SIS.ATN.atnNewApplHeader
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewApplHeaderUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveApplID",SqlDbType.Int,11, Record.LeaveApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved",SqlDbType.NVarChar,51, Iif(Record.Approved= "" ,Convert.DBNull, Record.Approved))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Rejected",SqlDbType.NVarChar,51, Iif(Record.Rejected= "" ,Convert.DBNull, Record.Rejected))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Application",SqlDbType.NVarChar,51, Iif(Record.Application= "" ,Convert.DBNull, Record.Application))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID",SqlDbType.Int,11, Record.ApplStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppliedOn",SqlDbType.DateTime,21, Iif(Record.AppliedOn= "" ,Convert.DBNull, Record.AppliedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationOn",SqlDbType.DateTime,21, Iif(Record.VerificationOn= "" ,Convert.DBNull, Record.VerificationOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalOn",SqlDbType.DateTime,21, Iif(Record.ApprovalOn= "" ,Convert.DBNull, Record.ApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionOn",SqlDbType.DateTime,21, Iif(Record.SanctionOn= "" ,Convert.DBNull, Record.SanctionOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired",SqlDbType.Bit,3, Record.VerificationRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired",SqlDbType.Bit,3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionRequired",SqlDbType.Bit,3, Record.SanctionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.NVarChar,9, Iif(Record.VerifiedBy= "" ,Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedBy",SqlDbType.NVarChar,9, Iif(Record.SanctionedBy= "" ,Convert.DBNull, Record.SanctionedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.NVarChar,9, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRemark",SqlDbType.NVarChar,101, Iif(Record.VerificationRemark= "" ,Convert.DBNull, Record.VerificationRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemark",SqlDbType.NVarChar,101, Iif(Record.ApprovalRemark= "" ,Convert.DBNull, Record.ApprovalRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionRemark",SqlDbType.NVarChar,101, Iif(Record.SanctionRemark= "" ,Convert.DBNull, Record.SanctionRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostingRemark",SqlDbType.NVarChar,101, Iif(Record.PostingRemark= "" ,Convert.DBNull, Record.PostingRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication",SqlDbType.Bit,3, Record.AdvanceApplication)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutionState",SqlDbType.Int,11, Iif(Record.ExecutionState= "" ,Convert.DBNull, Record.ExecutionState))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function atnNewApplHeaderDelete(ByVal Record As SIS.ATN.atnNewApplHeader) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewApplHeaderDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveApplID",SqlDbType.Int,Record.LeaveApplID.ToString.Length, Record.LeaveApplID)
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
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
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
