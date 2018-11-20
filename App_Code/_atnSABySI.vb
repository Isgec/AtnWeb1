Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnSABySI
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _MonthID As String = ""
    Private _ProjectID As String = ""
    Private _SiteName As String = ""
    Private _Remarks As String = ""
    Private _VerifiedOn As String = ""
    Private _SAStatusID As String = ""
    Private _VerifiedBy As String = ""
    Private _FinYear As String = ""
    Private _ATN_ApplicationStatus1_Description As String = ""
    Private _ATN_FinYear2_Description As String = ""
    Private _ATN_Months3_Description As String = ""
    Private _HRM_Employees4_EmployeeName As String = ""
    Private _IDM_Projects5_Description As String = ""
    Private _FK_ATN_SABySI_SAStatusID As SIS.ATN.atnApplicationStatus = Nothing
    Private _FK_ATN_SABySI_FinYear As SIS.ATN.atnFinYear = Nothing
    Private _FK_ATN_SABySI_MonthID As SIS.ATN.atnMonths = Nothing
    Private _FK_ATN_SABySI_VerifiedBy As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_ATN_SABySI_ProjectID As SIS.ATN.idmProjects = Nothing
    Public Property FileName As String = ""
    Public Property DiskFileName As String = ""
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property MonthID() As String
      Get
        Return _MonthID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _MonthID = ""
        Else
          _MonthID = value
        End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ProjectID = ""
        Else
          _ProjectID = value
        End If
      End Set
    End Property
    Public Property SiteName() As String
      Get
        Return _SiteName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SiteName = ""
        Else
          _SiteName = value
        End If
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Remarks = ""
        Else
          _Remarks = value
        End If
      End Set
    End Property
    Public Property VerifiedOn() As String
      Get
        If Not _VerifiedOn = String.Empty Then
          Return Convert.ToDateTime(_VerifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _VerifiedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifiedOn = ""
        Else
          _VerifiedOn = value
        End If
      End Set
    End Property
    Public Property SAStatusID() As String
      Get
        Return _SAStatusID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SAStatusID = ""
        Else
          _SAStatusID = value
        End If
      End Set
    End Property
    Public Property VerifiedBy() As String
      Get
        Return _VerifiedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifiedBy = ""
        Else
          _VerifiedBy = value
        End If
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
    Public Property ATN_ApplicationStatus1_Description() As String
      Get
        Return _ATN_ApplicationStatus1_Description
      End Get
      Set(ByVal value As String)
        _ATN_ApplicationStatus1_Description = value
      End Set
    End Property
    Public Property ATN_FinYear2_Description() As String
      Get
        Return _ATN_FinYear2_Description
      End Get
      Set(ByVal value As String)
        _ATN_FinYear2_Description = value
      End Set
    End Property
    Public Property ATN_Months3_Description() As String
      Get
        Return _ATN_Months3_Description
      End Get
      Set(ByVal value As String)
        _ATN_Months3_Description = value
      End Set
    End Property
    Public Property HRM_Employees4_EmployeeName() As String
      Get
        Return _HRM_Employees4_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees4_EmployeeName = value
      End Set
    End Property
    Public Property IDM_Projects5_Description() As String
      Get
        Return _IDM_Projects5_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects5_Description = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _SiteName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKatnSABySI
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ATN_SABySI_SAStatusID() As SIS.ATN.atnApplicationStatus
      Get
        If _FK_ATN_SABySI_SAStatusID Is Nothing Then
          _FK_ATN_SABySI_SAStatusID = SIS.ATN.atnApplicationStatus.atnApplicationStatusGetByID(_SAStatusID)
        End If
        Return _FK_ATN_SABySI_SAStatusID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SABySI_FinYear() As SIS.ATN.atnFinYear
      Get
        If _FK_ATN_SABySI_FinYear Is Nothing Then
          _FK_ATN_SABySI_FinYear = SIS.ATN.atnFinYear.atnFinYearGetByID(_FinYear)
        End If
        Return _FK_ATN_SABySI_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SABySI_MonthID() As SIS.ATN.atnMonths
      Get
        If _FK_ATN_SABySI_MonthID Is Nothing Then
          _FK_ATN_SABySI_MonthID = SIS.ATN.atnMonths.atnMonthsGetByID(_MonthID)
        End If
        Return _FK_ATN_SABySI_MonthID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SABySI_VerifiedBy() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_SABySI_VerifiedBy Is Nothing Then
          _FK_ATN_SABySI_VerifiedBy = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_VerifiedBy)
        End If
        Return _FK_ATN_SABySI_VerifiedBy
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SABySI_ProjectID() As SIS.ATN.idmProjects
      Get
        If _FK_ATN_SABySI_ProjectID Is Nothing Then
          _FK_ATN_SABySI_ProjectID = SIS.ATN.idmProjects.idmProjectsGetByID(_ProjectID)
        End If
        Return _FK_ATN_SABySI_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnSABySISelectList(ByVal OrderBy As String) As List(Of SIS.ATN.atnSABySI)
      Dim Results As List(Of SIS.ATN.atnSABySI) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySISelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnSABySI)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSABySI(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnSABySIGetNewRecord() As SIS.ATN.atnSABySI
      Return New SIS.ATN.atnSABySI()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnSABySIGetByID(ByVal SerialNo As Int32) As SIS.ATN.atnSABySI
      Dim Results As SIS.ATN.atnSABySI = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySISelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnSABySI(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnSABySISelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ProjectID As String) As List(Of SIS.ATN.atnSABySI)
      Dim Results As List(Of SIS.ATN.atnSABySI) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnSABySISelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnSABySISelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_MonthID", SqlDbType.Int, 10, IIf(MonthID = Nothing, 0, MonthID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnSABySI)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSABySI(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnSABySISelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnSABySIGetByID(ByVal SerialNo As Int32, ByVal Filter_MonthID As Int32, ByVal Filter_ProjectID As String) As SIS.ATN.atnSABySI
      Return atnSABySIGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function atnSABySIInsert(ByVal Record As SIS.ATN.atnSABySI) As SIS.ATN.atnSABySI
      Dim _Rec As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetNewRecord()
      With _Rec
        .MonthID = Record.MonthID
        .ProjectID = Record.ProjectID
        .SiteName = Record.SiteName
        .Remarks = Record.Remarks
        .VerifiedOn = Record.VerifiedOn
        .SAStatusID = atnAplStates.Free
        .VerifiedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        .FileName = Record.FileName
        .DiskFileName = Record.DiskFileName
      End With
      Return SIS.ATN.atnSABySI.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.atnSABySI) As SIS.ATN.atnSABySI
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID", SqlDbType.Int, 11, IIf(Record.MonthID = "", Convert.DBNull, Record.MonthID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteName", SqlDbType.NVarChar, 51, IIf(Record.SiteName = "", Convert.DBNull, Record.SiteName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 251, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SAStatusID", SqlDbType.Int, 11, IIf(Record.SAStatusID = "", Convert.DBNull, Record.SAStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 5, IIf(Record.FinYear = "", Convert.DBNull, Record.FinYear))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName", SqlDbType.NVarChar, 100, IIf(Record.FileName = "", Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFileName", SqlDbType.NVarChar, 250, IIf(Record.DiskFileName = "", Convert.DBNull, Record.DiskFileName))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function atnSABySIUpdate(ByVal Record As SIS.ATN.atnSABySI) As SIS.ATN.atnSABySI
      Dim _Rec As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(Record.SerialNo)
      With _Rec
        .ProjectID = Record.ProjectID
        .SiteName = Record.SiteName
        .Remarks = Record.Remarks
        .FileName = Record.FileName
        .DiskFileName = Record.DiskFileName
      End With
      Return SIS.ATN.atnSABySI.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.atnSABySI) As SIS.ATN.atnSABySI
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID", SqlDbType.Int, 11, IIf(Record.MonthID = "", Convert.DBNull, Record.MonthID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteName", SqlDbType.NVarChar, 51, IIf(Record.SiteName = "", Convert.DBNull, Record.SiteName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 251, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SAStatusID", SqlDbType.Int, 11, IIf(Record.SAStatusID = "", Convert.DBNull, Record.SAStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 5, IIf(Record.FinYear = "", Convert.DBNull, Record.FinYear))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName", SqlDbType.NVarChar, 100, IIf(Record.FileName = "", Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFileName", SqlDbType.NVarChar, 250, IIf(Record.DiskFileName = "", Convert.DBNull, Record.DiskFileName))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function atnSABySIDelete(ByVal Record As SIS.ATN.atnSABySI) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    '    Autocomplete Method
    Public Shared Function SelectatnSABySIAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.ATN.atnSABySI = New SIS.ATN.atnSABySI(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
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
