Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnAttendanceStatus
    Private Shared _RecordCount As Integer
    Private _AttenID As Int32
    Private _AttenDate As String
    Private _CardNo As String
    Private _Punch1Time As String
    Private _Punch2Time As String
    Private _PunchStatusID As String
    Private _PunchValue As String
    Private _NeedsRegularization As Boolean
    Private _Applied As Boolean
    Private _Applied1LeaveTypeID As String
    Private _Applied2LeaveTypeID As String
    Private _ApplHeaderID As String
    Private _ApplStatusID As String
    Private _Posted As Boolean
    Private _FinYear As String
    Private _PunchStatusIDATN_PunchStatus As SIS.ATN.atnPunchStatus
    Private _Applied1LeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _Applied2LeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _ApplStatusIDATN_ApplicationStatus As SIS.ATN.atnApplicationStatus
    Public Property AttenID() As Int32
      Get
        Return _AttenID
      End Get
      Set(ByVal value As Int32)
        _AttenID = value
      End Set
    End Property
    Public Property AttenDate() As String
      Get
        If Not _AttenDate = String.Empty Then
          Return Convert.ToDateTime(_AttenDate).ToString("dd/MM/yyyy")
        End If
        Return _AttenDate
      End Get
      Set(ByVal value As String)
			   _AttenDate = value
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
    Public Property Punch1Time() As String
      Get
        Return _Punch1Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Punch1Time = ""
				 Else
					 _Punch1Time = value
			   End If
      End Set
    End Property
    Public Property Punch2Time() As String
      Get
        Return _Punch2Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Punch2Time = ""
				 Else
					 _Punch2Time = value
			   End If
      End Set
    End Property
    Public Property PunchStatusID() As String
      Get
        Return _PunchStatusID
      End Get
      Set(ByVal value As String)
        _PunchStatusID = value
      End Set
    End Property
    Public Property PunchValue() As String
      Get
        Return _PunchValue
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PunchValue = ""
				 Else
					 _PunchValue = value
			   End If
      End Set
    End Property
    Public Property NeedsRegularization() As Boolean
      Get
        Return _NeedsRegularization
      End Get
      Set(ByVal value As Boolean)
        _NeedsRegularization = value
      End Set
    End Property
    Public Property Applied() As Boolean
      Get
        Return _Applied
      End Get
      Set(ByVal value As Boolean)
        _Applied = value
      End Set
    End Property
    Public Property Applied1LeaveTypeID() As String
      Get
        Return _Applied1LeaveTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Applied1LeaveTypeID = ""
				 Else
					 _Applied1LeaveTypeID = value
			   End If
      End Set
    End Property
    Public Property Applied2LeaveTypeID() As String
      Get
        Return _Applied2LeaveTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Applied2LeaveTypeID = ""
				 Else
					 _Applied2LeaveTypeID = value
			   End If
      End Set
    End Property
    Public Property ApplHeaderID() As String
      Get
        Return _ApplHeaderID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApplHeaderID = ""
				 Else
					 _ApplHeaderID = value
			   End If
      End Set
    End Property
    Public Property ApplStatusID() As String
      Get
        Return _ApplStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApplStatusID = ""
				 Else
					 _ApplStatusID = value
			   End If
      End Set
    End Property
    Public Property Posted() As Boolean
      Get
        Return _Posted
      End Get
      Set(ByVal value As Boolean)
        _Posted = value
      End Set
    End Property
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FinYear = ""
				 Else
					 _FinYear = value
			   End If
      End Set
    End Property
    Public ReadOnly Property PunchStatusIDATN_PunchStatus() As SIS.ATN.atnPunchStatus
      Get
        If _PunchStatusIDATN_PunchStatus Is Nothing Then
          _PunchStatusIDATN_PunchStatus = SIS.ATN.atnPunchStatus.GetByID(_PunchStatusID)
        End If
        Return _PunchStatusIDATN_PunchStatus
      End Get
    End Property
    Public ReadOnly Property Applied1LeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _Applied1LeaveTypeIDATN_LeaveTypes Is Nothing Then
          _Applied1LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Applied1LeaveTypeID)
        End If
        Return _Applied1LeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    Public ReadOnly Property Applied2LeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _Applied2LeaveTypeIDATN_LeaveTypes Is Nothing Then
          _Applied2LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Applied2LeaveTypeID)
        End If
        Return _Applied2LeaveTypeIDATN_LeaveTypes
      End Get
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
    Public Shared Function GetByID(ByVal AttenID As Int32) As SIS.ATN.atnAttendanceStatus
      Dim Results As SIS.ATN.atnAttendanceStatus = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAttendanceStatusSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID",SqlDbType.Int,AttenID.ToString.Length, AttenID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnAttendanceStatus(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnAttendanceStatus)
      Dim Results As List(Of SIS.ATN.atnAttendanceStatus) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AttenDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnAttendanceStatusSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnAttendanceStatusSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnAttendanceStatus)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnAttendanceStatus(Reader))
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
      On Error Resume Next
      _AttenID = Ctype(Reader("AttenID"),Int32)
      _AttenDate = Ctype(Reader("AttenDate"),DateTime)
      _CardNo = Ctype(Reader("CardNo"),String)
      If Convert.IsDBNull(Reader("Punch1Time")) Then
        _Punch1Time = String.Empty
      Else
        _Punch1Time = Ctype(Reader("Punch1Time"), String)
      End If
      If Convert.IsDBNull(Reader("Punch2Time")) Then
        _Punch2Time = String.Empty
      Else
        _Punch2Time = Ctype(Reader("Punch2Time"), String)
      End If
      _PunchStatusID = Ctype(Reader("PunchStatusID"),String)
      If Convert.IsDBNull(Reader("PunchValue")) Then
        _PunchValue = String.Empty
      Else
        _PunchValue = Ctype(Reader("PunchValue"), String)
      End If
      _NeedsRegularization = Ctype(Reader("NeedsRegularization"),Boolean)
      _Applied = Ctype(Reader("Applied"),Boolean)
      If Convert.IsDBNull(Reader("Applied1LeaveTypeID")) Then
        _Applied1LeaveTypeID = String.Empty
      Else
        _Applied1LeaveTypeID = Ctype(Reader("Applied1LeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader("Applied2LeaveTypeID")) Then
        _Applied2LeaveTypeID = String.Empty
      Else
        _Applied2LeaveTypeID = Ctype(Reader("Applied2LeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader("ApplHeaderID")) Then
        _ApplHeaderID = String.Empty
      Else
        _ApplHeaderID = Ctype(Reader("ApplHeaderID"), String)
      End If
      If Convert.IsDBNull(Reader("ApplStatusID")) Then
        _ApplStatusID = String.Empty
      Else
        _ApplStatusID = Ctype(Reader("ApplStatusID"), String)
      End If
      _Posted = Ctype(Reader("Posted"),Boolean)
      If Convert.IsDBNull(Reader("FinYear")) Then
        _FinYear = String.Empty
      Else
        _FinYear = Ctype(Reader("FinYear"), String)
      End If
      _PunchStatusIDATN_PunchStatus = New SIS.ATN.atnPunchStatus("ATN_PunchStatus1",Reader)
      _Applied1LeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes("ATN_LeaveTypes2",Reader)
      _Applied2LeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes("ATN_LeaveTypes3",Reader)
      _ApplStatusIDATN_ApplicationStatus = New SIS.ATN.atnApplicationStatus("ATN_ApplicationStatus4",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _AttenID = Ctype(Reader(AliasName & "_AttenID"),Int32)
      _AttenDate = Ctype(Reader(AliasName & "_AttenDate"),DateTime)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      If Convert.IsDBNull(Reader(AliasName & "_Punch1Time")) Then
        _Punch1Time = String.Empty
      Else
        _Punch1Time = Ctype(Reader(AliasName & "_Punch1Time"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Punch2Time")) Then
        _Punch2Time = String.Empty
      Else
        _Punch2Time = Ctype(Reader(AliasName & "_Punch2Time"), String)
      End If
      _PunchStatusID = Ctype(Reader(AliasName & "_PunchStatusID"),String)
      If Convert.IsDBNull(Reader(AliasName & "_PunchValue")) Then
        _PunchValue = String.Empty
      Else
        _PunchValue = Ctype(Reader(AliasName & "_PunchValue"), String)
      End If
      _NeedsRegularization = Ctype(Reader(AliasName & "_NeedsRegularization"),Boolean)
      _Applied = Ctype(Reader(AliasName & "_Applied"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_Applied1LeaveTypeID")) Then
        _Applied1LeaveTypeID = String.Empty
      Else
        _Applied1LeaveTypeID = Ctype(Reader(AliasName & "_Applied1LeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Applied2LeaveTypeID")) Then
        _Applied2LeaveTypeID = String.Empty
      Else
        _Applied2LeaveTypeID = Ctype(Reader(AliasName & "_Applied2LeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ApplHeaderID")) Then
        _ApplHeaderID = String.Empty
      Else
        _ApplHeaderID = Ctype(Reader(AliasName & "_ApplHeaderID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ApplStatusID")) Then
        _ApplStatusID = String.Empty
      Else
        _ApplStatusID = Ctype(Reader(AliasName & "_ApplStatusID"), String)
      End If
      _Posted = Ctype(Reader(AliasName & "_Posted"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_FinYear")) Then
        _FinYear = String.Empty
      Else
        _FinYear = Ctype(Reader(AliasName & "_FinYear"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
