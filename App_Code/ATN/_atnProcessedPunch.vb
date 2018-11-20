Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnProcessedPunch
    Private Shared _RecordCount As Integer
    Private _AttenID As Int32
    Private _AttenDate As String
    Private _CardNo As String
    Private _Punch1Time As String
    Private _Punch2Time As String
    Private _PunchStatusID As String
    Private _Punch9Time As String
    Private _PunchValue As String
    Private _FinalValue As String
    Private _Applied As Boolean
    Private _NeedsRegularization As Boolean
    Private _FinYear As String
    Private _AdvanceApplication As Boolean
    Private _MannuallyCorrected As Boolean
    Private _CardNoHRM_Employees As SIS.ATN.atnEmployees
    Private _CardNoEmployeeName As String
    Private _PunchStatusIDATN_PunchStatus As SIS.ATN.atnPunchStatus
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
    Public Property Applied() As Boolean
      Get
        Return _Applied
      End Get
      Set(ByVal value As Boolean)
        _Applied = value
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
    Public ReadOnly Property PunchStatusIDATN_PunchStatus() As SIS.ATN.atnPunchStatus
      Get
        If _PunchStatusIDATN_PunchStatus Is Nothing Then
          _PunchStatusIDATN_PunchStatus = SIS.ATN.atnPunchStatus.GetByID(_PunchStatusID)
        End If
        Return _PunchStatusIDATN_PunchStatus
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal AttenID As Int32) As SIS.ATN.atnProcessedPunch
      Dim Results As SIS.ATN.atnProcessedPunch = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnProcessedPunchSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID",SqlDbType.Int,AttenID.ToString.Length, AttenID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnProcessedPunch(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal AttenID As Int32, ByVal CardNo As String) As SIS.ATN.atnProcessedPunch
      Return GetByID(AttenID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCardNo(ByVal CardNo As String, ByVal OrderBy as String) As List(Of SIS.ATN.atnProcessedPunch)
      Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AttenDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnProcessedPunchSelectByCardNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnProcessedPunch)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnProcessedPunch)
      Dim Results As List(Of SIS.ATN.atnProcessedPunch) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AttenDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnProcessedPunchSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnProcessedPunchSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnProcessedPunch)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnProcessedPunch(Reader))
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
      _PunchStatusID = Ctype(Reader("PunchStatusID"),String)
      If Convert.IsDBNull(Reader("Punch9Time")) Then
        _Punch9Time = String.Empty
      Else
        _Punch9Time = Ctype(Reader("Punch9Time"), String)
      End If
      If Convert.IsDBNull(Reader("PunchValue")) Then
        _PunchValue = String.Empty
      Else
        _PunchValue = Ctype(Reader("PunchValue"), String)
      End If
      If Convert.IsDBNull(Reader("FinalValue")) Then
        _FinalValue = String.Empty
      Else
        _FinalValue = Ctype(Reader("FinalValue"), String)
      End If
      _Applied = Ctype(Reader("Applied"),Boolean)
      _NeedsRegularization = Ctype(Reader("NeedsRegularization"),Boolean)
      If Convert.IsDBNull(Reader("FinYear")) Then
        _FinYear = String.Empty
      Else
        _FinYear = Ctype(Reader("FinYear"), String)
      End If
      _AdvanceApplication = Ctype(Reader("AdvanceApplication"),Boolean)
			_MannuallyCorrected = CType(Reader("MannuallyCorrected"), Boolean)
			_HoliDay = CType(Reader("HoliDay"), Boolean)
      _CardNoEmployeeName = Reader("HRM_Employees1_EmployeeName") & " [" & Ctype(Reader("CardNo"), String) & "]"
      _CardNoHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees1",Reader)
      _PunchStatusIDATN_PunchStatus = New SIS.ATN.atnPunchStatus("ATN_PunchStatus2",Reader)
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
      If Convert.IsDBNull(Reader(AliasName & "_Punch9Time")) Then
        _Punch9Time = String.Empty
      Else
        _Punch9Time = Ctype(Reader(AliasName & "_Punch9Time"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_PunchValue")) Then
        _PunchValue = String.Empty
      Else
        _PunchValue = Ctype(Reader(AliasName & "_PunchValue"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_FinalValue")) Then
        _FinalValue = String.Empty
      Else
        _FinalValue = Ctype(Reader(AliasName & "_FinalValue"), String)
      End If
      _Applied = Ctype(Reader(AliasName & "_Applied"),Boolean)
      _NeedsRegularization = Ctype(Reader(AliasName & "_NeedsRegularization"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_FinYear")) Then
        _FinYear = String.Empty
      Else
        _FinYear = Ctype(Reader(AliasName & "_FinYear"), String)
      End If
      _AdvanceApplication = Ctype(Reader(AliasName & "_AdvanceApplication"),Boolean)
			_MannuallyCorrected = CType(Reader(AliasName & "_MannuallyCorrected"), Boolean)
			_HoliDay = CType(Reader(AliasName & "_HoliDay"), Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
