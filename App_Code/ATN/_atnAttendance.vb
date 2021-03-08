Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()>
  Partial Public Class atnAttendance
    Private Shared _RecordCount As Integer
    Private _AttenID As Int32
    Private _AttenDate As String
    Private _CardNo As String
    Private _Punch1Time As String
    Private _Punch2Time As String
    Private _PunchStatusID As String
    Private _PunchValue As String
    Private _NeedsRegularization As Boolean
    Private _FinYear As String
    Private _Applied As Boolean
    Private _AppliedValue As String
    Private _Applied1LeaveTypeID As String
    Private _Applied2LeaveTypeID As String
    Private _Posted As Boolean
    Private _Posted1LeaveTypeID As String
    Private _Posted2LeaveTypeID As String
    Private _ApplHeaderID As String
    Private _ApplStatusID As String
    Private _FinalValue As String
    Private _AdvanceApplication As Boolean
    Private _Destination As String
    Private _Purpose As String
    Private _PunchStatusIDATN_PunchStatus As SIS.ATN.atnPunchStatus
    Private _Applied1LeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _Applied2LeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _Posted1LeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _Posted2LeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _ApplStatusIDATN_ApplicationStatus As SIS.ATN.atnApplicationStatus
    Public Property OfficeID As String = ""
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
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
          _PunchStatusID = ""
        Else
          _PunchStatusID = value
        End If
      End Set
    End Property
    Public Property PunchValue() As String
      Get
        Return _PunchValue
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _FinYear = ""
        Else
          _FinYear = value
        End If
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
    Public Property AppliedValue() As String
      Get
        Return _AppliedValue
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _AppliedValue = ""
        Else
          _AppliedValue = value
        End If
      End Set
    End Property
    Public Property Applied1LeaveTypeID() As String
      Get
        Return _Applied1LeaveTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
          _Applied2LeaveTypeID = ""
        Else
          _Applied2LeaveTypeID = value
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
    Public Property Posted1LeaveTypeID() As String
      Get
        Return _Posted1LeaveTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Posted1LeaveTypeID = ""
        Else
          _Posted1LeaveTypeID = value
        End If
      End Set
    End Property
    Public Property Posted2LeaveTypeID() As String
      Get
        Return _Posted2LeaveTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Posted2LeaveTypeID = ""
        Else
          _Posted2LeaveTypeID = value
        End If
      End Set
    End Property
    Public Property ApplHeaderID() As String
      Get
        Return _ApplHeaderID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
          _ApplStatusID = ""
        Else
          _ApplStatusID = value
        End If
      End Set
    End Property
    Public Property FinalValue() As String
      Get
        Return _FinalValue
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _FinalValue = ""
        Else
          _FinalValue = value
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
    Public Property Destination() As String
      Get
        Return _Destination
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Destination = ""
        Else
          _Destination = value
        End If
      End Set
    End Property
    Public Property Purpose() As String
      Get
        Return _Purpose
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Purpose = ""
        Else
          _Purpose = value
        End If
      End Set
    End Property
    Public ReadOnly Property Posted1LeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _Posted1LeaveTypeIDATN_LeaveTypes Is Nothing Then
          _Posted1LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Posted1LeaveTypeID)
        End If
        Return _Posted1LeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    Public ReadOnly Property Posted2LeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _Posted2LeaveTypeIDATN_LeaveTypes Is Nothing Then
          _Posted2LeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_Posted2LeaveTypeID)
        End If
        Return _Posted2LeaveTypeIDATN_LeaveTypes
      End Get
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
    Public Shared Function GetByID(ByVal AttenID As Int32) As SIS.ATN.atnAttendance
      Dim Results As SIS.ATN.atnAttendance = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAttendanceSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID", SqlDbType.Int, AttenID.ToString.Length, AttenID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnAttendance(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnAttendance)
      Dim Results As List(Of SIS.ATN.atnAttendance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If orderBy = String.Empty Then orderBy = "AttenDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnAttendanceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnAttendanceSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnAttendance)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnAttendance(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnAttendance) As Int32
      Dim _Result As Int32 = Record.AttenID
      SIS.ATN.atnAttendance.SetPunch9Time(Record)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAttendanceInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch1Time", SqlDbType.Decimal, 9, IIf(Record.Punch1Time = "", Convert.DBNull, Record.Punch1Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch2Time", SqlDbType.Decimal, 9, IIf(Record.Punch2Time = "", Convert.DBNull, Record.Punch2Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch9Time", SqlDbType.Decimal, 9, IIf(Record.Punch9Time = "", Convert.DBNull, Record.Punch9Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID", SqlDbType.NVarChar, 3, IIf(Record.PunchStatusID = "", Convert.DBNull, Record.PunchStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchValue", SqlDbType.Decimal, 9, IIf(Record.PunchValue = "", Convert.DBNull, Record.PunchValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NeedsRegularization", SqlDbType.Bit, 3, Record.NeedsRegularization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 5, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalValue", SqlDbType.Decimal, 9, IIf(Record.FinalValue = "", Convert.DBNull, Record.FinalValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication", SqlDbType.Bit, 3, Record.AdvanceApplication)
          Cmd.Parameters.Add("@Return_AttenID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_AttenID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_AttenID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function Update(ByVal Record As SIS.ATN.atnAttendance) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAttendanceUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttenID", SqlDbType.Int, 11, Record.AttenID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied", SqlDbType.Bit, 3, Record.Applied)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppliedValue", SqlDbType.Decimal, 9, IIf(Record.AppliedValue = "", Convert.DBNull, Record.AppliedValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied1LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Applied1LeaveTypeID = "", Convert.DBNull, Record.Applied1LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied2LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Applied2LeaveTypeID = "", Convert.DBNull, Record.Applied2LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted", SqlDbType.Bit, 3, Record.Posted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted1LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Posted1LeaveTypeID = "", Convert.DBNull, Record.Posted1LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted2LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Posted2LeaveTypeID = "", Convert.DBNull, Record.Posted2LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID", SqlDbType.Int, 11, IIf(Record.ApplHeaderID = "", Convert.DBNull, Record.ApplHeaderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID", SqlDbType.Int, 11, IIf(Record.ApplStatusID = "", Convert.DBNull, Record.ApplStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalValue", SqlDbType.Decimal, 9, IIf(Record.FinalValue = "", Convert.DBNull, Record.FinalValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication", SqlDbType.Bit, 3, Record.AdvanceApplication)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Destination", SqlDbType.NVarChar, 50, IIf(Record.Destination = "", Convert.DBNull, Record.Destination))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Purpose", SqlDbType.NVarChar, 250, IIf(Record.Purpose = "", Convert.DBNull, Record.Purpose))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnAttendance) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAttendanceDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttenID", SqlDbType.Int, Record.AttenID.ToString.Length, Record.AttenID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
