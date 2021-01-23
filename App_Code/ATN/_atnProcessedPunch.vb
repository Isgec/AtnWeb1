Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnProcessedPunch
    Private Shared _RecordCount As Integer = 0
    Public Property AttenID As Int32 = 0
    Private _AttenDate As String = ""
    Public Property CardNo As String = ""
    Public Property Punch1Time As String = ""
    Public Property Punch2Time As String = ""
    Public Property PunchStatusID As String = ""
    Public Property Punch9Time As String = ""
    Public Property PunchValue As String = ""
    Public Property FinalValue As String = ""
    Public Property Applied As Boolean = False
    Public Property NeedsRegularization As Boolean = False
    Public Property FinYear As String = ""
    Public Property AdvanceApplication As Boolean = False
    Public Property MannuallyCorrected As Boolean = False
    Public Property HoliDay As Boolean = False
    Public Property Remarks As String = "Register Entry"

    Private _CardNoHRM_Employees As SIS.ATN.atnEmployees = Nothing
    Private _PunchStatusIDATN_PunchStatus As SIS.ATN.atnPunchStatus = Nothing
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
    Public ReadOnly Property CardNoHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _CardNoHRM_Employees Is Nothing Then
          _CardNoHRM_Employees = SIS.ATN.atnEmployees.GetByID(_CardNo)
        End If
        Return _CardNoHRM_Employees
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
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
