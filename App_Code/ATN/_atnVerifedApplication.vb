Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnVerifedApplication
    Private Shared _RecordCount As Integer
    Private _LeaveApplID As Int32
    Private _CardNo As String
    Private _Remarks As String
    Private _AppliedOn As String
    Private _ApplStatusID As Int32
    Private _VerificationRemark As String
    Private _VerificationOn As String
    Private _VerifiedBy As String
    Private _ApprovalRequired As Boolean
    Private _SanctionRequired As Boolean
    Private _FinYear As String
    Private _CardNoHRM_Employees As SIS.ATN.atnEmployees
    Private _CardNoEmployeeName As String
    Private _ApplStatusIDATN_ApplicationStatus As SIS.ATN.atnApplicationStatus
    Private _VerifiedByHRM_Employees As SIS.ATN.atnEmployees
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
    Public Property ApplStatusID() As Int32
      Get
        Return _ApplStatusID
      End Get
      Set(ByVal value As Int32)
        _ApplStatusID = value
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
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
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
    Public Property CardNoEmployeeName() As String
      Get
        Return _CardNoEmployeeName
      End Get
      Set(ByVal value As String)
        _CardNoEmployeeName = value
      End Set
    End Property
    Public ReadOnly Property ApplStatusIDATN_ApplicationStatus() As SIS.ATN.atnApplicationStatus
      Get
        If _ApplStatusIDATN_ApplicationStatus Is Nothing Then
          _ApplStatusIDATN_ApplicationStatus = SIS.ATN.atnApplicationStatus.GetByID(_ApplStatusID)
        End If
        Return _ApplStatusIDATN_ApplicationStatus
      End Get
    End Property
    Public ReadOnly Property VerifiedByHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _VerifiedByHRM_Employees Is Nothing Then
          _VerifiedByHRM_Employees = SIS.ATN.atnEmployees.GetByID(_VerifiedBy)
        End If
        Return _VerifiedByHRM_Employees
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveApplID As Int32) As SIS.ATN.atnVerifedApplication
      Dim Results As SIS.ATN.atnVerifedApplication = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnVerifedApplicationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveApplID",SqlDbType.Int,LeaveApplID.ToString.Length, LeaveApplID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnVerifedApplication(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveApplID As Int32, ByVal CardNo As String) As SIS.ATN.atnVerifedApplication
      Return GetByID(LeaveApplID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCardNo(ByVal CardNo As String, ByVal OrderBy as String) As List(Of SIS.ATN.atnVerifedApplication)
      Dim Results As List(Of SIS.ATN.atnVerifedApplication) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CardNo"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnVerifedApplicationSelectByCardNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID",SqlDbType.Int,10, 3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnVerifedApplication)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnVerifedApplication(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnVerifedApplication)
      Dim Results As List(Of SIS.ATN.atnVerifedApplication) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CardNo"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnVerifedApplicationSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnVerifedApplicationSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID",SqlDbType.Int,10, 3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnVerifedApplication)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnVerifedApplication(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _LeaveApplID = Ctype(Reader("LeaveApplID"),Int32)
      _CardNo = Ctype(Reader("CardNo"),String)
      If Convert.IsDBNull(Reader("Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader("Remarks"), String)
      End If
      If Convert.IsDBNull(Reader("AppliedOn")) Then
        _AppliedOn = String.Empty
      Else
        _AppliedOn = Ctype(Reader("AppliedOn"), String)
      End If
      _ApplStatusID = Ctype(Reader("ApplStatusID"),Int32)
      If Convert.IsDBNull(Reader("VerificationRemark")) Then
        _VerificationRemark = String.Empty
      Else
        _VerificationRemark = Ctype(Reader("VerificationRemark"), String)
      End If
      If Convert.IsDBNull(Reader("VerificationOn")) Then
        _VerificationOn = String.Empty
      Else
        _VerificationOn = Ctype(Reader("VerificationOn"), String)
      End If
      If Convert.IsDBNull(Reader("VerifiedBy")) Then
        _VerifiedBy = String.Empty
      Else
        _VerifiedBy = Ctype(Reader("VerifiedBy"), String)
      End If
      _ApprovalRequired = Ctype(Reader("ApprovalRequired"),Boolean)
      _SanctionRequired = Ctype(Reader("SanctionRequired"),Boolean)
      _FinYear = Ctype(Reader("FinYear"),String)
      _CardNoEmployeeName = Reader("HRM_Employees1_EmployeeName") & " [" & Ctype(Reader("CardNo"), String) & "]"
      _CardNoHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees1",Reader)
      _ApplStatusIDATN_ApplicationStatus = New SIS.ATN.atnApplicationStatus("ATN_ApplicationStatus2",Reader)
      _VerifiedByHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees3",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _LeaveApplID = Ctype(Reader(AliasName & "_LeaveApplID"),Int32)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      If Convert.IsDBNull(Reader(AliasName & "_Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader(AliasName & "_Remarks"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_AppliedOn")) Then
        _AppliedOn = String.Empty
      Else
        _AppliedOn = Ctype(Reader(AliasName & "_AppliedOn"), String)
      End If
      _ApplStatusID = Ctype(Reader(AliasName & "_ApplStatusID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_VerificationRemark")) Then
        _VerificationRemark = String.Empty
      Else
        _VerificationRemark = Ctype(Reader(AliasName & "_VerificationRemark"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_VerificationOn")) Then
        _VerificationOn = String.Empty
      Else
        _VerificationOn = Ctype(Reader(AliasName & "_VerificationOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_VerifiedBy")) Then
        _VerifiedBy = String.Empty
      Else
        _VerifiedBy = Ctype(Reader(AliasName & "_VerifiedBy"), String)
      End If
      _ApprovalRequired = Ctype(Reader(AliasName & "_ApprovalRequired"),Boolean)
      _SanctionRequired = Ctype(Reader(AliasName & "_SanctionRequired"),Boolean)
      _FinYear = Ctype(Reader(AliasName & "_FinYear"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
