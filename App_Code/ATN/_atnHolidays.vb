Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnHolidays
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32
    Private _Holiday As String
    Private _OfficeID As String
    Private _Description As String
    Private _PunchStatusID As String
    Private _FinYear As String
    Private _OfficeIDHRM_Offices As SIS.ATN.hrmOffices
    Private _PunchStatusIDATN_PunchStatus As SIS.ATN.atnPunchStatus
    Private _FinYearATN_FinYear As SIS.ATN.atnFinYear
    Public Property RecordID() As Int32
      Get
        Return _RecordID
      End Get
      Set(ByVal value As Int32)
        _RecordID = value
      End Set
    End Property
    Public Property Holiday() As String
      Get
        If Not _Holiday = String.Empty Then
          Return Convert.ToDateTime(_Holiday).ToString("dd/MM/yyyy")
        End If
        Return _Holiday
      End Get
      Set(ByVal value As String)
			   _Holiday = value
      End Set
    End Property
    Public Property OfficeID() As String
      Get
        Return _OfficeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OfficeID = ""
				 Else
					 _OfficeID = value
			   End If
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
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
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
      End Set
    End Property
    Public ReadOnly Property OfficeIDHRM_Offices() As SIS.ATN.hrmOffices
      Get
        If _OfficeIDHRM_Offices Is Nothing Then
          _OfficeIDHRM_Offices = SIS.ATN.hrmOffices.GetByID(_OfficeID)
        End If
        Return _OfficeIDHRM_Offices
      End Get
    End Property
    Public ReadOnly Property PunchStatusIDATN_PunchStatus() As SIS.ATN.atnPunchStatus
      Get
        If _PunchStatusIDATN_PunchStatus Is Nothing Then
          _PunchStatusIDATN_PunchStatus = SIS.ATN.atnPunchStatus.GetByID(_PunchStatusID)
        End If
        Return _PunchStatusIDATN_PunchStatus
      End Get
    End Property
    Public ReadOnly Property FinYearATN_FinYear() As SIS.ATN.atnFinYear
      Get
        If _FinYearATN_FinYear Is Nothing Then
          _FinYearATN_FinYear = SIS.ATN.atnFinYear.GetByID(_FinYear)
        End If
        Return _FinYearATN_FinYear
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal RecordID As Int32) As SIS.ATN.atnHolidays
      Dim Results As SIS.ATN.atnHolidays = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnHolidaysSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnHolidays(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal RecordID As Int32, ByVal OfficeID As Int32) As SIS.ATN.atnHolidays
      Return GetByID(RecordID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OfficeID As Int32) As List(Of SIS.ATN.atnHolidays)
      Dim Results As List(Of SIS.ATN.atnHolidays) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnHolidaysSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnHolidaysSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OfficeID",SqlDbType.Int,10, IIf(OfficeID = Nothing, 0,OfficeID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnHolidays)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnHolidays(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnHolidays) As Int32
      Dim _Result As Int32 = Record.RecordID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnHolidaysInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Holiday",SqlDbType.DateTime,21, Record.Holiday)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,11, Iif(Record.OfficeID= "" ,Convert.DBNull, Record.OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,31, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID",SqlDbType.NVarChar,3, Record.PunchStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@Return_RecordID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_RecordID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_RecordID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnHolidays) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnHolidaysUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Holiday",SqlDbType.DateTime,21, Record.Holiday)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,11, Iif(Record.OfficeID= "" ,Convert.DBNull, Record.OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,31, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID",SqlDbType.NVarChar,3, Record.PunchStatusID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnHolidays) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnHolidaysDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,Record.RecordID.ToString.Length, Record.RecordID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OfficeID As Int32) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader("RecordID"),Int32)
      _Holiday = Ctype(Reader("Holiday"),DateTime)
      If Convert.IsDBNull(Reader("OfficeID")) Then
        _OfficeID = String.Empty
      Else
        _OfficeID = Ctype(Reader("OfficeID"), String)
      End If
      _Description = Ctype(Reader("Description"),String)
      _PunchStatusID = Ctype(Reader("PunchStatusID"),String)
      _FinYear = Ctype(Reader("FinYear"),String)
      _OfficeIDHRM_Offices = New SIS.ATN.hrmOffices("HRM_Offices1",Reader)
      _PunchStatusIDATN_PunchStatus = New SIS.ATN.atnPunchStatus("ATN_PunchStatus2",Reader)
      _FinYearATN_FinYear = New SIS.ATN.atnFinYear("ATN_FinYear3",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader(AliasName & "_RecordID"),Int32)
      _Holiday = Ctype(Reader(AliasName & "_Holiday"),DateTime)
      If Convert.IsDBNull(Reader(AliasName & "_OfficeID")) Then
        _OfficeID = String.Empty
      Else
        _OfficeID = Ctype(Reader(AliasName & "_OfficeID"), String)
      End If
      _Description = Ctype(Reader(AliasName & "_Description"),String)
      _PunchStatusID = Ctype(Reader(AliasName & "_PunchStatusID"),String)
      _FinYear = Ctype(Reader(AliasName & "_FinYear"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
