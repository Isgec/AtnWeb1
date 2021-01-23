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
          If _PunchStatusID <> "" Then
            _PunchStatusIDATN_PunchStatus = SIS.ATN.atnPunchStatus.GetByID(_PunchStatusID)
          Else
            _PunchStatusIDATN_PunchStatus = New SIS.ATN.atnPunchStatus
          End If
        Else
          If _PunchStatusID <> "" Then
            If _PunchStatusIDATN_PunchStatus.PunchStatusID <> _PunchStatusID Then
              _PunchStatusIDATN_PunchStatus = SIS.ATN.atnPunchStatus.GetByID(_PunchStatusID)
            End If
          Else
            _PunchStatusIDATN_PunchStatus = New SIS.ATN.atnPunchStatus
          End If
        End If
        Return _PunchStatusIDATN_PunchStatus
      End Get
    End Property
    Public ReadOnly Property Applied1LeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _Applied1LeaveTypeIDATN_LeaveTypes Is Nothing Then
          If _Applied1LeaveTypeID <> "" Then
            _Applied1LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Applied1LeaveTypeID)
          Else
            _Applied1LeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes
          End If
        Else
          If _Applied1LeaveTypeID <> "" Then
            If _Applied1LeaveTypeIDATN_LeaveTypes.LeaveTypeID <> _Applied1LeaveTypeID Then
              _Applied1LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Applied1LeaveTypeID)
            End If
          Else
            _Applied1LeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes
          End If
        End If
        Return _Applied1LeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    Public ReadOnly Property Applied2LeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _Applied2LeaveTypeIDATN_LeaveTypes Is Nothing Then
          If _Applied2LeaveTypeID <> "" Then
            _Applied2LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Applied2LeaveTypeID)
          Else
            _Applied2LeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes
          End If
        Else
          If _Applied2LeaveTypeID <> "" Then
            If _Applied2LeaveTypeIDATN_LeaveTypes.LeaveTypeID <> _Applied2LeaveTypeID Then
              _Applied2LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Applied2LeaveTypeID)
            End If
          Else
            _Applied2LeaveTypeIDATN_LeaveTypes = New SIS.ATN.atnLeaveTypes
          End If
        End If
        Return _Applied2LeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    Public ReadOnly Property ApplStatusIDATN_ApplicationStatus() As SIS.ATN.atnApplicationStatus
      Get
        If _ApplStatusIDATN_ApplicationStatus Is Nothing Then
          If _ApplStatusID <> "" Then
            _ApplStatusIDATN_ApplicationStatus = SIS.ATN.atnApplicationStatus.GetByID(_ApplStatusID)
          Else
            _ApplStatusIDATN_ApplicationStatus = New SIS.ATN.atnApplicationStatus
          End If
        Else
          If _ApplStatusID <> "" Then
            If _ApplStatusIDATN_ApplicationStatus.ApplStatusID <> _ApplStatusID Then
              _ApplStatusIDATN_ApplicationStatus = SIS.ATN.atnApplicationStatus.GetByID(_ApplStatusID)
            End If
          Else
            _ApplStatusIDATN_ApplicationStatus = New SIS.ATN.atnApplicationStatus
          End If

        End If
        Return _ApplStatusIDATN_ApplicationStatus
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByID(ByVal AttenID As Int32) As SIS.ATN.atnAttendanceStatus
      Dim Results As SIS.ATN.atnAttendanceStatus = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAttendanceStatusSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID", SqlDbType.Int, AttenID.ToString.Length, AttenID)
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
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
