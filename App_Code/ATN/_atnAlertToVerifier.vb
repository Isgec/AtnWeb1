Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnAlertToVerifier
    Private Shared _RecordCount As Integer
    Private _LeaveApplID As Int32
    Private _VerifiedBy As String
    Private _ApplStatusID As Int32
    Private _FinYear As String
    Private _VerifiedByHRM_Employees As SIS.ATN.atnEmployees
    Public Property LeaveApplID() As Int32
      Get
        Return _LeaveApplID
      End Get
      Set(ByVal value As Int32)
        _LeaveApplID = value
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
    Public Property ApplStatusID() As Int32
      Get
        Return _ApplStatusID
      End Get
      Set(ByVal value As Int32)
        _ApplStatusID = value
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
    Public ReadOnly Property VerifiedByHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _VerifiedByHRM_Employees Is Nothing Then
          _VerifiedByHRM_Employees = SIS.ATN.atnEmployees.GetByID(_VerifiedBy)
        End If
        Return _VerifiedByHRM_Employees
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveApplID As Int32) As SIS.ATN.atnAlertToVerifier
      Dim Results As SIS.ATN.atnAlertToVerifier = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAlertToVerifierSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveApplID",SqlDbType.Int,LeaveApplID.ToString.Length, LeaveApplID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnAlertToVerifier(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnAlertToVerifier)
      Dim Results As List(Of SIS.ATN.atnAlertToVerifier) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "VerifiedBy"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnAlertToVerifierSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnAlertToVerifierSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID",SqlDbType.Int,10, 2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnAlertToVerifier)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnAlertToVerifier(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    ' Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
    '   On Error Resume Next
    '   _LeaveApplID = Ctype(Reader(AliasName & "_LeaveApplID"),Int32)
    '   If Convert.IsDBNull(Reader(AliasName & "_VerifiedBy")) Then
    '     _VerifiedBy = String.Empty
    '   Else
    '     _VerifiedBy = Ctype(Reader(AliasName & "_VerifiedBy"), String)
    '   End If
    'If Convert.IsDBNull(Reader(AliasName & "_EMailID")) Then
    '	_EMailID = String.Empty
    'Else
    '	_EMailID = CType(Reader(AliasName & "_EMailID"), String)
    'End If
    '_ApplStatusID = CType(Reader(AliasName & "_ApplStatusID"), Int32)
    '_ApplicationCount = CType(Reader(AliasName & "_ApplicationCount"), Int32)
    '_FinYear = CType(Reader(AliasName & "_FinYear"), String)
    ' End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
