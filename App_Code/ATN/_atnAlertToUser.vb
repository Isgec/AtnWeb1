Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnAlertToUser
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _AttenMonth As String = ""
    Private _EmployeeName As String = ""
    Private _SFinalValue As String = ""
    Private _Designation_Description As String = ""
    Private _Department_Description As String = ""
    Private _Office_Description As String = ""
    Private _FinYear As String = ""
    Private _EMailID As String = ""
    Private _FK_Dummy1 As SIS.ATN.atnMonths = Nothing
    Public Property OfficeID As String = ""
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property AttenMonth() As String
      Get
        Return _AttenMonth
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AttenMonth = ""
				 Else
					 _AttenMonth = value
			   End If
      End Set
    End Property
    Public Property EmployeeName() As String
      Get
        Return _EmployeeName
      End Get
      Set(ByVal value As String)
        _EmployeeName = value
      End Set
    End Property
    Public Property SFinalValue() As String
      Get
        Return _SFinalValue
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SFinalValue = ""
				 Else
					 _SFinalValue = value
			   End If
      End Set
    End Property
    Public Property Designation_Description() As String
      Get
        Return _Designation_Description
      End Get
      Set(ByVal value As String)
        _Designation_Description = value
      End Set
    End Property
    Public Property Department_Description() As String
      Get
        Return _Department_Description
      End Get
      Set(ByVal value As String)
        _Department_Description = value
      End Set
    End Property
    Public Property Office_Description() As String
      Get
        Return _Office_Description
      End Get
      Set(ByVal value As String)
        _Office_Description = value
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
    Public Property EMailID() As String
      Get
        Return _EMailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EMailID = ""
				 Else
					 _EMailID = value
			   End If
      End Set
    End Property
    Public Property DisplayField() As String
      Get
        Return ""
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property PrimaryKey() As String
      Get
        Return _CardNo & "|" & _AttenMonth
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_Dummy1() As SIS.ATN.atnMonths
      Get
        If _FK_Dummy1 Is Nothing Then
          _FK_Dummy1 = SIS.ATN.atnMonths.GetByID(_AttenMonth)
        End If
        Return _FK_Dummy1
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ATN.atnAlertToUser
      Dim Results As SIS.ATN.atnAlertToUser = Nothing
      Results = New SIS.ATN.atnAlertToUser()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CardNo As String, ByVal AttenMonth As Int32) As SIS.ATN.atnAlertToUser
      Dim Results As SIS.ATN.atnAlertToUser = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAlertToUserSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenMonth",SqlDbType.Int,AttenMonth.ToString.Length, AttenMonth)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnAlertToUser(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CardNo As String, ByVal AttenMonth As Int32, ByVal Filter_AttenMonth As Int32) As SIS.ATN.atnAlertToUser
      Return GetByID(CardNo, AttenMonth)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByAttenMonth(ByVal AttenMonth As Int32, ByVal OrderBy as String) As List(Of SIS.ATN.atnAlertToUser)
      Dim Results As List(Of SIS.ATN.atnAlertToUser) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CardNo"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnAlertToUserSelectByAttenMonth"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenMonth",SqlDbType.Int,AttenMonth.ToString.Length, AttenMonth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnAlertToUser)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnAlertToUser(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal AttenMonth As Int32, ByVal OfficeID As String) As List(Of SIS.ATN.atnAlertToUser)
      Dim Results As List(Of SIS.ATN.atnAlertToUser) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If orderBy = String.Empty Then orderBy = "CardNo"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnAlertToUserSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnAlertToUserSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AttenMonth", SqlDbType.Int, 10, IIf(AttenMonth = Nothing, 0, AttenMonth))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OfficeID", SqlDbType.Int, 10, IIf(OfficeID = "", 0, OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnAlertToUser)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnAlertToUser(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal AttenMonth As Int32, ByVal OfficeID As String) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
