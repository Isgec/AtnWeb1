Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnAppliedApplications
    Private Shared _RecordCount As Integer
    Private _LeaveApplID As Int32
    Private _CardNo As String
    Private _AppliedOn As String
    Private _Remarks As String
    Private _ApplStatusID As Int32
    Private _VerificationRemark As String
    Private _FinYear As String
    Private _VerificationOn As String
    Private _ApprovalOn As String
    Private _SanctionOn As String
    Private _PostedOn As String
    Private _VerificationRequired As Boolean
    Private _ApprovalRequired As Boolean
    Private _SanctionRequired As Boolean
    Private _ApprovalRemark As String
    Private _SanctionRemark As String
		Private _ApplStatusIDATN_ApplicationStatus As SIS.ATN.atnApplicationStatus
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
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
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
		Public ReadOnly Property ApplStatusIDATN_ApplicationStatus() As SIS.ATN.atnApplicationStatus
			Get
				If _ApplStatusIDATN_ApplicationStatus Is Nothing Then
					_ApplStatusIDATN_ApplicationStatus = SIS.ATN.atnApplicationStatus.GetByID(_ApplStatusID)
				End If
				Return _ApplStatusIDATN_ApplicationStatus
			End Get
		End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveApplID As Int32) As SIS.ATN.atnAppliedApplications
      Dim Results As SIS.ATN.atnAppliedApplications = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAppliedApplicationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveApplID",SqlDbType.Int,LeaveApplID.ToString.Length, LeaveApplID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnAppliedApplications(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnAppliedApplications)
      Dim Results As List(Of SIS.ATN.atnAppliedApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AppliedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnAppliedApplicationsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnAppliedApplicationsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnAppliedApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnAppliedApplications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnAppliedApplications) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAppliedApplicationsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveApplID",SqlDbType.Int,Record.LeaveApplID.ToString.Length, Record.LeaveApplID)
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
      _LeaveApplID = Ctype(Reader("LeaveApplID"),Int32)
      _CardNo = Ctype(Reader("CardNo"),String)
      If Convert.IsDBNull(Reader("AppliedOn")) Then
        _AppliedOn = String.Empty
      Else
        _AppliedOn = Ctype(Reader("AppliedOn"), String)
      End If
      If Convert.IsDBNull(Reader("Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader("Remarks"), String)
      End If
      _ApplStatusID = Ctype(Reader("ApplStatusID"),Int32)
      If Convert.IsDBNull(Reader("VerificationRemark")) Then
        _VerificationRemark = String.Empty
      Else
        _VerificationRemark = Ctype(Reader("VerificationRemark"), String)
      End If
      _FinYear = Ctype(Reader("FinYear"),String)
      If Convert.IsDBNull(Reader("VerificationOn")) Then
        _VerificationOn = String.Empty
      Else
        _VerificationOn = Ctype(Reader("VerificationOn"), String)
      End If
      If Convert.IsDBNull(Reader("ApprovalOn")) Then
        _ApprovalOn = String.Empty
      Else
        _ApprovalOn = Ctype(Reader("ApprovalOn"), String)
      End If
      If Convert.IsDBNull(Reader("SanctionOn")) Then
        _SanctionOn = String.Empty
      Else
        _SanctionOn = Ctype(Reader("SanctionOn"), String)
      End If
      If Convert.IsDBNull(Reader("PostedOn")) Then
        _PostedOn = String.Empty
      Else
        _PostedOn = Ctype(Reader("PostedOn"), String)
      End If
      _VerificationRequired = Ctype(Reader("VerificationRequired"),Boolean)
      _ApprovalRequired = Ctype(Reader("ApprovalRequired"),Boolean)
      _SanctionRequired = Ctype(Reader("SanctionRequired"),Boolean)
      If Convert.IsDBNull(Reader("ApprovalRemark")) Then
        _ApprovalRemark = String.Empty
      Else
        _ApprovalRemark = Ctype(Reader("ApprovalRemark"), String)
      End If
      If Convert.IsDBNull(Reader("SanctionRemark")) Then
        _SanctionRemark = String.Empty
      Else
        _SanctionRemark = Ctype(Reader("SanctionRemark"), String)
      End If
			_ApplStatusIDATN_ApplicationStatus = New SIS.ATN.atnApplicationStatus("ATN_ApplicationStatus1", Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _LeaveApplID = Ctype(Reader(AliasName & "_LeaveApplID"),Int32)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      If Convert.IsDBNull(Reader(AliasName & "_AppliedOn")) Then
        _AppliedOn = String.Empty
      Else
        _AppliedOn = Ctype(Reader(AliasName & "_AppliedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader(AliasName & "_Remarks"), String)
      End If
      _ApplStatusID = Ctype(Reader(AliasName & "_ApplStatusID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_VerificationRemark")) Then
        _VerificationRemark = String.Empty
      Else
        _VerificationRemark = Ctype(Reader(AliasName & "_VerificationRemark"), String)
      End If
      _FinYear = Ctype(Reader(AliasName & "_FinYear"),String)
      If Convert.IsDBNull(Reader(AliasName & "_VerificationOn")) Then
        _VerificationOn = String.Empty
      Else
        _VerificationOn = Ctype(Reader(AliasName & "_VerificationOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ApprovalOn")) Then
        _ApprovalOn = String.Empty
      Else
        _ApprovalOn = Ctype(Reader(AliasName & "_ApprovalOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_SanctionOn")) Then
        _SanctionOn = String.Empty
      Else
        _SanctionOn = Ctype(Reader(AliasName & "_SanctionOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_PostedOn")) Then
        _PostedOn = String.Empty
      Else
        _PostedOn = Ctype(Reader(AliasName & "_PostedOn"), String)
      End If
      _VerificationRequired = Ctype(Reader(AliasName & "_VerificationRequired"),Boolean)
      _ApprovalRequired = Ctype(Reader(AliasName & "_ApprovalRequired"),Boolean)
      _SanctionRequired = Ctype(Reader(AliasName & "_SanctionRequired"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ApprovalRemark")) Then
        _ApprovalRemark = String.Empty
      Else
        _ApprovalRemark = Ctype(Reader(AliasName & "_ApprovalRemark"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_SanctionRemark")) Then
        _SanctionRemark = String.Empty
      Else
        _SanctionRemark = Ctype(Reader(AliasName & "_SanctionRemark"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
