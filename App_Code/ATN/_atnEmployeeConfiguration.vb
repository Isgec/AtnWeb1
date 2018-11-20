Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnEmployeeConfiguration
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _SendVerifyMail As Boolean = False
    Private _SendApproveMail As Boolean = False
    Private _AttendanceThroughExcel As Boolean = False
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _FK_ATN_EmployeeConfiguration_CardNo As SIS.ATN.atnEmployees = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property SendVerifyMail() As Boolean
      Get
        Return _SendVerifyMail
      End Get
      Set(ByVal value As Boolean)
        _SendVerifyMail = value
      End Set
    End Property
    Public Property SendApproveMail() As Boolean
      Get
        Return _SendApproveMail
      End Get
      Set(ByVal value As Boolean)
        _SendApproveMail = value
      End Set
    End Property
    Public Property AttendanceThroughExcel() As Boolean
      Get
        Return _AttendanceThroughExcel
      End Get
      Set(ByVal value As Boolean)
        _AttendanceThroughExcel = value
      End Set
    End Property
    Public Property HRM_Employees1_EmployeeName() As String
      Get
        Return _HRM_Employees1_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees1_EmployeeName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CardNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKatnEmployeeConfiguration
      Private _CardNo As String = ""
      Public Property CardNo() As String
        Get
          Return _CardNo
        End Get
        Set(ByVal value As String)
          _CardNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ATN_EmployeeConfiguration_CardNo() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_EmployeeConfiguration_CardNo Is Nothing Then
          _FK_ATN_EmployeeConfiguration_CardNo = SIS.ATN.atnEmployees.GetByID(_CardNo)
        End If
        Return _FK_ATN_EmployeeConfiguration_CardNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnEmployeeConfigurationGetNewRecord() As SIS.ATN.atnEmployeeConfiguration
      Return New SIS.ATN.atnEmployeeConfiguration()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnEmployeeConfigurationGetByID(ByVal CardNo As String) As SIS.ATN.atnEmployeeConfiguration
      Dim Results As SIS.ATN.atnEmployeeConfiguration = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnEmployeeConfigurationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnEmployeeConfiguration(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnEmployeeConfigurationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnEmployeeConfiguration)
      Dim Results As List(Of SIS.ATN.atnEmployeeConfiguration) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnEmployeeConfigurationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnEmployeeConfigurationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnEmployeeConfiguration)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnEmployeeConfiguration(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnEmployeeConfigurationSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnEmployeeConfigurationGetByID(ByVal CardNo As String, ByVal Filter_CardNo As String) As SIS.ATN.atnEmployeeConfiguration
      Return atnEmployeeConfigurationGetByID(CardNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function atnEmployeeConfigurationInsert(ByVal Record As SIS.ATN.atnEmployeeConfiguration) As SIS.ATN.atnEmployeeConfiguration
      Dim _Rec As SIS.ATN.atnEmployeeConfiguration = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetNewRecord()
      With _Rec
        .CardNo = Record.CardNo
        .SendVerifyMail = Record.SendVerifyMail
        .SendApproveMail = Record.SendApproveMail
        .AttendanceThroughExcel = Record.AttendanceThroughExcel
      End With
      Return SIS.ATN.atnEmployeeConfiguration.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.atnEmployeeConfiguration) As SIS.ATN.atnEmployeeConfiguration
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnEmployeeConfigurationInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendVerifyMail",SqlDbType.Bit,3, Record.SendVerifyMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendApproveMail",SqlDbType.Bit,3, Record.SendApproveMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttendanceThroughExcel",SqlDbType.Bit,3, Record.AttendanceThroughExcel)
          Cmd.Parameters.Add("@Return_CardNo", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_CardNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.CardNo = Cmd.Parameters("@Return_CardNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function atnEmployeeConfigurationUpdate(ByVal Record As SIS.ATN.atnEmployeeConfiguration) As SIS.ATN.atnEmployeeConfiguration
      Dim _Rec As SIS.ATN.atnEmployeeConfiguration = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetByID(Record.CardNo)
      With _Rec
        .SendVerifyMail = Record.SendVerifyMail
        .SendApproveMail = Record.SendApproveMail
      End With
      Return SIS.ATN.atnEmployeeConfiguration.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.atnEmployeeConfiguration) As SIS.ATN.atnEmployeeConfiguration
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnEmployeeConfigurationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendVerifyMail",SqlDbType.Bit,3, Record.SendVerifyMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendApproveMail",SqlDbType.Bit,3, Record.SendApproveMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttendanceThroughExcel",SqlDbType.Bit,3, Record.AttendanceThroughExcel)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
