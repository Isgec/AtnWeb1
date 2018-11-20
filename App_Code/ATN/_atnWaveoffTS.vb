Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnWaveoffTS
    Private Shared _RecordCount As Integer
    Private _AttenID As Int32
    Private _AttenDate As String
    Private _CardNo As String
    Private _Punch1Time As String
    Private _Punch2Time As String
    Private _Punch9Time As String
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
    Private _MannuallyCorrected As Boolean
    Private _Destination As String
    Private _Purpose As String
    Private _ConfigID As String
    Private _ConfigDetailID As String
    Private _ConfigStatus As String
    Private _TSStatus As String
    Private _TSStatusBy As String
    Private _TSStatusOn As String
    Private _CardNoHRM_Employees As SIS.ATN.atnEmployees
    Private _CardNoEmployeeName As String
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
    Public Property Punch9Time() As String
      Get
        Return _Punch9Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Punch9Time = ""
				 Else
					 _Punch9Time = value
			   End If
      End Set
    End Property
    Public Property PunchStatusID() As String
      Get
        Return _PunchStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
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
				 If Convert.IsDBNull(Value) Then
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
				 If Convert.IsDBNull(Value) Then
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
				 If Convert.IsDBNull(Value) Then
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
    Public Property FinalValue() As String
      Get
        Return _FinalValue
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
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
    Public Property MannuallyCorrected() As Boolean
      Get
        Return _MannuallyCorrected
      End Get
      Set(ByVal value As Boolean)
        _MannuallyCorrected = value
      End Set
    End Property
    Public Property Destination() As String
      Get
        Return _Destination
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
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
				 If Convert.IsDBNull(Value) Then
					 _Purpose = ""
				 Else
					 _Purpose = value
			   End If
      End Set
    End Property
    Public Property ConfigID() As String
      Get
        Return _ConfigID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ConfigID = ""
				 Else
					 _ConfigID = value
			   End If
      End Set
    End Property
    Public Property ConfigDetailID() As String
      Get
        Return _ConfigDetailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ConfigDetailID = ""
				 Else
					 _ConfigDetailID = value
			   End If
      End Set
    End Property
    Public Property ConfigStatus() As String
      Get
        Return _ConfigStatus
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ConfigStatus = ""
				 Else
					 _ConfigStatus = value
			   End If
      End Set
    End Property
    Public Property TSStatus() As String
      Get
        Return _TSStatus
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TSStatus = ""
				 Else
					 _TSStatus = value
			   End If
      End Set
    End Property
    Public Property TSStatusBy() As String
      Get
        Return _TSStatusBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TSStatusBy = ""
				 Else
					 _TSStatusBy = value
			   End If
      End Set
    End Property
    Public Property TSStatusOn() As String
      Get
        If Not _TSStatusOn = String.Empty Then
          Return Convert.ToDateTime(_TSStatusOn).ToString("dd/MM/yyyy")
        End If
        Return _TSStatusOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TSStatusOn = ""
				 Else
					 _TSStatusOn = value
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
    Public Property CardNoEmployeeName() As String
      Get
        Return _CardNoEmployeeName
      End Get
      Set(ByVal value As String)
        _CardNoEmployeeName = value
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal AttenID As Int32) As SIS.ATN.atnWaveoffTS
      Dim Results As SIS.ATN.atnWaveoffTS = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnWaveoffTSSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID",SqlDbType.Int,AttenID.ToString.Length, AttenID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnWaveoffTS(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal AttenID As Int32, ByVal CardNo As String) As SIS.ATN.atnWaveoffTS
      Return GetByID(AttenID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnWaveoffTS)
      Dim Results As List(Of SIS.ATN.atnWaveoffTS) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AttenDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnWaveoffTSSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnWaveoffTSSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID",SqlDbType.NVarChar,2, "TS")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnWaveoffTS)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnWaveoffTS(Reader))
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
      If Convert.IsDBNull(Reader("Punch9Time")) Then
        _Punch9Time = String.Empty
      Else
        _Punch9Time = Ctype(Reader("Punch9Time"), String)
      End If
      If Convert.IsDBNull(Reader("PunchStatusID")) Then
        _PunchStatusID = String.Empty
      Else
        _PunchStatusID = Ctype(Reader("PunchStatusID"), String)
      End If
      If Convert.IsDBNull(Reader("PunchValue")) Then
        _PunchValue = String.Empty
      Else
        _PunchValue = Ctype(Reader("PunchValue"), String)
      End If
      _NeedsRegularization = Ctype(Reader("NeedsRegularization"),Boolean)
      If Convert.IsDBNull(Reader("FinYear")) Then
        _FinYear = String.Empty
      Else
        _FinYear = Ctype(Reader("FinYear"), String)
      End If
      _Applied = Ctype(Reader("Applied"),Boolean)
      If Convert.IsDBNull(Reader("AppliedValue")) Then
        _AppliedValue = String.Empty
      Else
        _AppliedValue = Ctype(Reader("AppliedValue"), String)
      End If
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
      _Posted = Ctype(Reader("Posted"),Boolean)
      If Convert.IsDBNull(Reader("Posted1LeaveTypeID")) Then
        _Posted1LeaveTypeID = String.Empty
      Else
        _Posted1LeaveTypeID = Ctype(Reader("Posted1LeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader("Posted2LeaveTypeID")) Then
        _Posted2LeaveTypeID = String.Empty
      Else
        _Posted2LeaveTypeID = Ctype(Reader("Posted2LeaveTypeID"), String)
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
      If Convert.IsDBNull(Reader("FinalValue")) Then
        _FinalValue = String.Empty
      Else
        _FinalValue = Ctype(Reader("FinalValue"), String)
      End If
      _AdvanceApplication = Ctype(Reader("AdvanceApplication"),Boolean)
      _MannuallyCorrected = Ctype(Reader("MannuallyCorrected"),Boolean)
      If Convert.IsDBNull(Reader("Destination")) Then
        _Destination = String.Empty
      Else
        _Destination = Ctype(Reader("Destination"), String)
      End If
      If Convert.IsDBNull(Reader("Purpose")) Then
        _Purpose = String.Empty
      Else
        _Purpose = Ctype(Reader("Purpose"), String)
      End If
      If Convert.IsDBNull(Reader("ConfigID")) Then
        _ConfigID = String.Empty
      Else
        _ConfigID = Ctype(Reader("ConfigID"), String)
      End If
      If Convert.IsDBNull(Reader("ConfigDetailID")) Then
        _ConfigDetailID = String.Empty
      Else
        _ConfigDetailID = Ctype(Reader("ConfigDetailID"), String)
      End If
      If Convert.IsDBNull(Reader("ConfigStatus")) Then
        _ConfigStatus = String.Empty
      Else
        _ConfigStatus = Ctype(Reader("ConfigStatus"), String)
      End If
      If Convert.IsDBNull(Reader("TSStatus")) Then
        _TSStatus = String.Empty
      Else
        _TSStatus = Ctype(Reader("TSStatus"), String)
      End If
      If Convert.IsDBNull(Reader("TSStatusBy")) Then
        _TSStatusBy = String.Empty
      Else
        _TSStatusBy = Ctype(Reader("TSStatusBy"), String)
      End If
      If Convert.IsDBNull(Reader("TSStatusOn")) Then
        _TSStatusOn = String.Empty
      Else
        _TSStatusOn = Ctype(Reader("TSStatusOn"), String)
      End If
      _CardNoEmployeeName = Reader("HRM_Employees1_EmployeeName") & " [" & Ctype(Reader("CardNo"), String) & "]"
      _CardNoHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees1",Reader)
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
      If Convert.IsDBNull(Reader(AliasName & "_Punch9Time")) Then
        _Punch9Time = String.Empty
      Else
        _Punch9Time = Ctype(Reader(AliasName & "_Punch9Time"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_PunchStatusID")) Then
        _PunchStatusID = String.Empty
      Else
        _PunchStatusID = Ctype(Reader(AliasName & "_PunchStatusID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_PunchValue")) Then
        _PunchValue = String.Empty
      Else
        _PunchValue = Ctype(Reader(AliasName & "_PunchValue"), String)
      End If
      _NeedsRegularization = Ctype(Reader(AliasName & "_NeedsRegularization"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_FinYear")) Then
        _FinYear = String.Empty
      Else
        _FinYear = Ctype(Reader(AliasName & "_FinYear"), String)
      End If
      _Applied = Ctype(Reader(AliasName & "_Applied"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_AppliedValue")) Then
        _AppliedValue = String.Empty
      Else
        _AppliedValue = Ctype(Reader(AliasName & "_AppliedValue"), String)
      End If
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
      _Posted = Ctype(Reader(AliasName & "_Posted"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_Posted1LeaveTypeID")) Then
        _Posted1LeaveTypeID = String.Empty
      Else
        _Posted1LeaveTypeID = Ctype(Reader(AliasName & "_Posted1LeaveTypeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Posted2LeaveTypeID")) Then
        _Posted2LeaveTypeID = String.Empty
      Else
        _Posted2LeaveTypeID = Ctype(Reader(AliasName & "_Posted2LeaveTypeID"), String)
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
      If Convert.IsDBNull(Reader(AliasName & "_FinalValue")) Then
        _FinalValue = String.Empty
      Else
        _FinalValue = Ctype(Reader(AliasName & "_FinalValue"), String)
      End If
      _AdvanceApplication = Ctype(Reader(AliasName & "_AdvanceApplication"),Boolean)
      _MannuallyCorrected = Ctype(Reader(AliasName & "_MannuallyCorrected"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_Destination")) Then
        _Destination = String.Empty
      Else
        _Destination = Ctype(Reader(AliasName & "_Destination"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Purpose")) Then
        _Purpose = String.Empty
      Else
        _Purpose = Ctype(Reader(AliasName & "_Purpose"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ConfigID")) Then
        _ConfigID = String.Empty
      Else
        _ConfigID = Ctype(Reader(AliasName & "_ConfigID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ConfigDetailID")) Then
        _ConfigDetailID = String.Empty
      Else
        _ConfigDetailID = Ctype(Reader(AliasName & "_ConfigDetailID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ConfigStatus")) Then
        _ConfigStatus = String.Empty
      Else
        _ConfigStatus = Ctype(Reader(AliasName & "_ConfigStatus"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_TSStatus")) Then
        _TSStatus = String.Empty
      Else
        _TSStatus = Ctype(Reader(AliasName & "_TSStatus"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_TSStatusBy")) Then
        _TSStatusBy = String.Empty
      Else
        _TSStatusBy = Ctype(Reader(AliasName & "_TSStatusBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_TSStatusOn")) Then
        _TSStatusOn = String.Empty
      Else
        _TSStatusOn = Ctype(Reader(AliasName & "_TSStatusOn"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
