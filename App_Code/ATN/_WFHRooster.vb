Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Public Class CardCount
    Public Property CardNo As String = ""
    Public Property Cnt As Integer = 0
    Sub New()

    End Sub
    Sub New(x As String, y As Integer)
      CardNo = x
      Cnt = y
    End Sub
  End Class
  <DataObject()>
  Partial Public Class WFHRooster
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _AttenDate As String = ""
    Private _WFH1stHalf As Boolean = False
    Private _WFH2ndHalf As Boolean = False
    Private _WFHFullDay As Boolean = False
    Private _NonWorkingDay As Boolean = False
    Private _EmployeeNotActive As Boolean = False
    Private _RoosterStatus As Int32 = 0
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _CreaterRemarks As String = ""
    Private _ModifiedBy As String = ""
    Private _ModifiedOn As String = ""
    Private _ModifierRemarks As String = ""
    Private _LockedBy As String = ""
    Private _LockedOn As String = ""
    Private _LockerRemarks As String = ""
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _FK_ATN_WFHRooster_CardNo As SIS.ATN.newHrmEmployees = Nothing
    Public Property DepartmentName As String = ""
    Public Property Level As Integer = 0
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
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
    Public Property WFH1stHalf() As Boolean
      Get
        Return _WFH1stHalf
      End Get
      Set(ByVal value As Boolean)
        _WFH1stHalf = value
      End Set
    End Property
    Public Property WFH2ndHalf() As Boolean
      Get
        Return _WFH2ndHalf
      End Get
      Set(ByVal value As Boolean)
        _WFH2ndHalf = value
      End Set
    End Property
    Public Property WFHFullDay() As Boolean
      Get
        Return _WFHFullDay
      End Get
      Set(ByVal value As Boolean)
        _WFHFullDay = value
      End Set
    End Property
    Public Property NonWorkingDay() As Boolean
      Get
        Return _NonWorkingDay
      End Get
      Set(ByVal value As Boolean)
        _NonWorkingDay = value
      End Set
    End Property
    Public Property EmployeeNotActive() As Boolean
      Get
        Return _EmployeeNotActive
      End Get
      Set(ByVal value As Boolean)
        _EmployeeNotActive = value
      End Set
    End Property
    Public Property RoosterStatus() As Int32
      Get
        Return _RoosterStatus
      End Get
      Set(ByVal value As Int32)
        _RoosterStatus = value
      End Set
    End Property
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CreatedBy = ""
        Else
          _CreatedBy = value
        End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CreatedOn = ""
        Else
          _CreatedOn = value
        End If
      End Set
    End Property
    Public Property CreaterRemarks() As String
      Get
        Return _CreaterRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CreaterRemarks = ""
        Else
          _CreaterRemarks = value
        End If
      End Set
    End Property
    Public Property ModifiedBy() As String
      Get
        Return _ModifiedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModifiedBy = ""
        Else
          _ModifiedBy = value
        End If
      End Set
    End Property
    Public Property ModifiedOn() As String
      Get
        If Not _ModifiedOn = String.Empty Then
          Return Convert.ToDateTime(_ModifiedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ModifiedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModifiedOn = ""
        Else
          _ModifiedOn = value
        End If
      End Set
    End Property
    Public Property ModifierRemarks() As String
      Get
        Return _ModifierRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModifierRemarks = ""
        Else
          _ModifierRemarks = value
        End If
      End Set
    End Property
    Public Property LockedBy() As String
      Get
        Return _LockedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _LockedBy = ""
        Else
          _LockedBy = value
        End If
      End Set
    End Property
    Public Property LockedOn() As String
      Get
        If Not _LockedOn = String.Empty Then
          Return Convert.ToDateTime(_LockedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _LockedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _LockedOn = ""
        Else
          _LockedOn = value
        End If
      End Set
    End Property
    Public Property LockerRemarks() As String
      Get
        Return _LockerRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _LockerRemarks = ""
        Else
          _LockerRemarks = value
        End If
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
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _CardNo & "|" & _AttenDate
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
    Public Class PKWFHRooster
      Private _CardNo As String = ""
      Private _AttenDate As String = ""
      Public Property CardNo() As String
        Get
          Return _CardNo
        End Get
        Set(ByVal value As String)
          _CardNo = value
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
    End Class
    Public ReadOnly Property FK_ATN_WFHRooster_CardNo() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_WFHRooster_CardNo Is Nothing Then
          _FK_ATN_WFHRooster_CardNo = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_CardNo)
        End If
        Return _FK_ATN_WFHRooster_CardNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function WFHRoosterGetNewRecord() As SIS.ATN.WFHRooster
      Return New SIS.ATN.WFHRooster()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function WFHRoosterGetByID(ByVal CardNo As String, ByVal AttenDate As DateTime) As SIS.ATN.WFHRooster
      Dim Results As SIS.ATN.WFHRooster = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, AttenDate.ToString.Length, AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.WFHRooster(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function WFHRoosterSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.WFHRooster)
      Dim Results As List(Of SIS.ATN.WFHRooster) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spWFHRoosterSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spWFHRoosterSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.WFHRooster)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.WFHRooster(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function WFHRoosterSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function WFHRoosterInsert(ByVal Record As SIS.ATN.WFHRooster) As SIS.ATN.WFHRooster
      Dim _Rec As SIS.ATN.WFHRooster = SIS.ATN.WFHRooster.WFHRoosterGetNewRecord()
      With _Rec
        .CardNo = Record.CardNo
        .AttenDate = Record.AttenDate
        .WFH1stHalf = Record.WFH1stHalf
        .WFH2ndHalf = Record.WFH2ndHalf
        .WFHFullDay = Record.WFHFullDay
        .NonWorkingDay = Record.NonWorkingDay
        .EmployeeNotActive = Record.EmployeeNotActive
        .RoosterStatus = Record.RoosterStatus
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .CreaterRemarks = Record.CreaterRemarks
        .ModifiedBy = Record.ModifiedBy
        .ModifiedOn = Record.ModifiedOn
        .ModifierRemarks = Record.ModifierRemarks
        .LockedBy = Record.LockedBy
        .LockedOn = Record.LockedOn
        .LockerRemarks = Record.LockerRemarks
      End With
      Return SIS.ATN.WFHRooster.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.WFHRooster) As SIS.ATN.WFHRooster
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH1stHalf", SqlDbType.Bit, 3, Record.WFH1stHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH2ndHalf", SqlDbType.Bit, 3, Record.WFH2ndHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFHFullDay", SqlDbType.Bit, 3, Record.WFHFullDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonWorkingDay", SqlDbType.Bit, 3, Record.NonWorkingDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeNotActive", SqlDbType.Bit, 3, Record.EmployeeNotActive)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoosterStatus", SqlDbType.Int, 11, Record.RoosterStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreaterRemarks", SqlDbType.NVarChar, 251, IIf(Record.CreaterRemarks = "", Convert.DBNull, Record.CreaterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy", SqlDbType.NVarChar, 9, IIf(Record.ModifiedBy = "", Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn", SqlDbType.DateTime, 21, IIf(Record.ModifiedOn = "", Convert.DBNull, Record.ModifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifierRemarks", SqlDbType.NVarChar, 251, IIf(Record.ModifierRemarks = "", Convert.DBNull, Record.ModifierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedBy", SqlDbType.NVarChar, 9, IIf(Record.LockedBy = "", Convert.DBNull, Record.LockedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedOn", SqlDbType.DateTime, 21, IIf(Record.LockedOn = "", Convert.DBNull, Record.LockedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockerRemarks", SqlDbType.NVarChar, 251, IIf(Record.LockerRemarks = "", Convert.DBNull, Record.LockerRemarks))
          Cmd.Parameters.Add("@Return_CardNo", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_CardNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_AttenDate", SqlDbType.DateTime, 21)
          Cmd.Parameters("@Return_AttenDate").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.CardNo = Cmd.Parameters("@Return_CardNo").Value
          Record.AttenDate = Cmd.Parameters("@Return_AttenDate").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function WFHRoosterUpdate(ByVal Record As SIS.ATN.WFHRooster) As SIS.ATN.WFHRooster
      Dim _Rec As SIS.ATN.WFHRooster = SIS.ATN.WFHRooster.WFHRoosterGetByID(Record.CardNo, Record.AttenDate)
      With _Rec
        .WFH1stHalf = Record.WFH1stHalf
        .WFH2ndHalf = Record.WFH2ndHalf
        .WFHFullDay = Record.WFHFullDay
        .NonWorkingDay = Record.NonWorkingDay
        .EmployeeNotActive = Record.EmployeeNotActive
        .RoosterStatus = Record.RoosterStatus
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .CreaterRemarks = Record.CreaterRemarks
        .ModifiedBy = Record.ModifiedBy
        .ModifiedOn = Record.ModifiedOn
        .ModifierRemarks = Record.ModifierRemarks
        .LockedBy = Record.LockedBy
        .LockedOn = Record.LockedOn
        .LockerRemarks = Record.LockerRemarks
      End With
      Return SIS.ATN.WFHRooster.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.WFHRooster) As SIS.ATN.WFHRooster
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH1stHalf", SqlDbType.Bit, 3, Record.WFH1stHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH2ndHalf", SqlDbType.Bit, 3, Record.WFH2ndHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFHFullDay", SqlDbType.Bit, 3, Record.WFHFullDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonWorkingDay", SqlDbType.Bit, 3, Record.NonWorkingDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeNotActive", SqlDbType.Bit, 3, Record.EmployeeNotActive)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoosterStatus", SqlDbType.Int, 11, Record.RoosterStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreaterRemarks", SqlDbType.NVarChar, 251, IIf(Record.CreaterRemarks = "", Convert.DBNull, Record.CreaterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy", SqlDbType.NVarChar, 9, IIf(Record.ModifiedBy = "", Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn", SqlDbType.DateTime, 21, IIf(Record.ModifiedOn = "", Convert.DBNull, Record.ModifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifierRemarks", SqlDbType.NVarChar, 251, IIf(Record.ModifierRemarks = "", Convert.DBNull, Record.ModifierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedBy", SqlDbType.NVarChar, 9, IIf(Record.LockedBy = "", Convert.DBNull, Record.LockedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedOn", SqlDbType.DateTime, 21, IIf(Record.LockedOn = "", Convert.DBNull, Record.LockedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockerRemarks", SqlDbType.NVarChar, 251, IIf(Record.LockerRemarks = "", Convert.DBNull, Record.LockerRemarks))
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
    Public Shared Function WFHRoosterDelete(ByVal Record As SIS.ATN.WFHRooster) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, Record.CardNo.ToString.Length, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttenDate", SqlDbType.DateTime, Record.AttenDate.ToString.Length, Record.AttenDate)
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
    Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
    Public Sub New()
    End Sub
    Public Shared Function GetByCardDate(cardno As String, attendate As String) As SIS.ATN.WFHRooster
      Dim tmp As SIS.ATN.WFHRooster = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ATN_WFHRooster where CardNo='" & cardno & "' and attendate=convert(datetime,'" & attendate & "',103)"
          Dim rd As SqlDataReader = Cmd.ExecuteReader()
          While (rd.Read())
            tmp = New SIS.ATN.WFHRooster(rd)
          End While
          rd.Close()
        End Using
      End Using
      Return tmp
    End Function
    Public Shared Function CreateRooster(SerialNo As String) As Boolean
      Dim mRet As Boolean = True
      Dim conf As SIS.ATN.WFHConfig = Nothing
      Try
        conf = SIS.ATN.WFHConfig.WFHConfigGetByID(SerialNo)
      Catch ex As Exception
        Throw New Exception("Error in searching configuration.")
      End Try
      If conf Is Nothing Then
        Throw New Exception("Configuration ID not found to generate roster.")
      End If
      If Not conf.Active Then
        Throw New Exception("Configuration is not Active to be generated.")
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_WFHRoosterCreate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Cmd.ExecuteNonQuery()
        End Using
        Dim sDt As DateTime = Convert.ToDateTime(conf.FromDate)
        Dim aOffice As Array = {1, 4, 5}
        While sDt <= Convert.ToDateTime(conf.ToDate)
          For Each ofc As Integer In aOffice
            Dim hld As SIS.ATN.atnHolidays = SIS.ATN.atnHolidays.GetByHoliday(sDt, ofc)
            If hld IsNot Nothing Then
              Dim Sql As String = ""
              Select Case ofc
                Case 4, 5
                  Sql &= " update ATN_WFHRooster set NonWorkingDay = 1 "
                  Sql &= " where "
                  Sql &= " attendate = convert(datetime,'" & sDt.ToString("dd/MM/yyyy") & "',103) "
                  Sql &= " and cardno in ("
                  Sql &= " select cardno from hrm_employees where activestate=1 and c_officeid=" & ofc
                  Sql &= " )"
                Case Else
                  Sql &= " update ATN_WFHRooster set NonWorkingDay = 1 "
                  Sql &= " where "
                  Sql &= " attendate = convert(datetime,'" & sDt.ToString("dd/MM/yyyy") & "',103) "
                  Sql &= " and cardno in ("
                  Sql &= " select cardno from hrm_employees where activestate=1 and c_officeid not in (4,5) "
                  Sql &= " )"
              End Select
              Using Cmd As SqlCommand = Con.CreateCommand()
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
              End Using
            End If
          Next
          sDt = sDt.AddDays(1)
        End While
      End Using
      Return mRet
    End Function
    Public Shared Function DeleteRooster(SerialNo As String) As Boolean
      Dim mRet As Boolean = True
      Dim conf As SIS.ATN.WFHConfig = Nothing
      Try
        conf = SIS.ATN.WFHConfig.WFHConfigGetByID(SerialNo)
      Catch ex As Exception
        Throw New Exception("Error in searching configuration.")
      End Try
      If conf Is Nothing Then
        Throw New Exception("Configuration ID not found to delete roster.")
      End If
      If Not conf.Active Then
        Throw New Exception("Configuration is not Active to be deleted.")
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Dim Sql As String = ""
        Sql &= " delete ATN_WFHRoosterHistory "
        Sql &= " where "
        Sql &= " attendate >= convert(datetime,'" & conf.FromDate & "',103) "
        Sql &= " and attendate <= convert(datetime,'" & conf.ToDate & "',103) "
        Sql &= " delete ATN_WFHRooster "
        Sql &= " where "
        Sql &= " attendate >= convert(datetime,'" & conf.FromDate & "',103) "
        Sql &= " and attendate <= convert(datetime,'" & conf.ToDate & "',103) "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function IsAdmin(cardno As String) As Boolean
      Dim x As String = ConfigurationManager.AppSettings("Admin")
      x = x.Replace(" ", "")
      If x.IndexOf(cardno) >= 0 Then
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetRooster(cardno As String, conf As SIS.ATN.WFHConfig, Level As Integer) As List(Of SIS.ATN.WFHRooster)
      Dim tmp As New List(Of SIS.ATN.WFHRooster)
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Sql &= " select rst.*,  "
        Sql &= Level & " as Level,  "
        Sql &= " emp.employeename as HRM_Employees1_EmployeeName,  "
        Sql &= " dpt.description as DepartmentName  "
        Sql &= " from ATN_WFHRooster as rst "
        Sql &= " inner join HRM_Employees as emp on rst.CardNo = emp.CardNo "
        Sql &= " left outer join HRM_Departments as dpt on dpt.departmentid = emp.c_departmentid "
        Sql &= " where rst.attendate>=convert(datetime,'" & conf.FromDate & "',103) "
        Sql &= " and rst.attendate<=convert(datetime,'" & conf.ToDate & "',103)"
        Sql &= " and rst.CardNo ='" & cardno & "'"
        Sql &= " order by rst.attendate "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 600
          Dim rd As SqlDataReader = Cmd.ExecuteReader()
          While (rd.Read())
            tmp.Add(New SIS.ATN.WFHRooster(rd))
          End While
          rd.Close()
        End Using
      End Using
      Return tmp
    End Function
    Public Shared Function GetChildEmployees(cardno As String, Level As Integer, Optional isReport As Boolean = False) As List(Of SIS.ATN.CardCount)
      Dim tmp As New List(Of SIS.ATN.CardCount)
      Dim Sql As String = ""
      Dim IsAdmin As Boolean = SIS.ATN.WFHRooster.IsAdmin(cardno)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Sql &= " select aa.CardNo "
        If Not isReport Then
          Sql &= ", (select isnull(count(*),0) from hrm_employees as bb where bb.activestate=1 and bb.c_officeid<>6 and (bb.verifierid=aa.cardno or bb.approverid=aa.cardno)) as cnt "
        End If
        Sql &= " from HRM_Employees as aa "
        Sql &= " where aa.activestate = 1 "
        Sql &= " and aa.c_officeid <> 6 "
        If IsAdmin AndAlso Level = 1 Then
          Sql &= " and ("
          Sql &= "      aa.verifierid is null "
          Sql &= "      and aa.approverid is null "
          Sql &= "     )"
        Else
          Sql &= " and ("
          Sql &= "      aa.verifierid='" & cardno & "' "
          Sql &= "      or aa.approverid='" & cardno & "' "
          'Sql &= "      or aa.TASanctioningAuthority='" & cardno & "'"
          Sql &= "     )"
        End If
        Sql &= " order by aa.cardno "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim rd As SqlDataReader = Cmd.ExecuteReader()
          While (rd.Read())
            If Not isReport Then
              tmp.Add(New SIS.ATN.CardCount(rd("CardNo"), rd("cnt")))
            Else
              tmp.Add(New SIS.ATN.CardCount(rd("CardNo"), 0))
            End If
          End While
          rd.Close()
        End Using
      End Using
      Return tmp
    End Function
    ''' <summary>
    ''' Called by modifier of status, NOT Creater or Locker, Inserts Updated Status in History
    ''' </summary>
    ''' <param name="AttenDate"></param>
    ''' <param name="cardno"></param>
    ''' <returns></returns>
    Public Shared Function ChangeStatus(AttenDate As String, cardno As String, Optional LoginID As String = "", Optional Remarks As String = "") As SIS.ATN.WFHRoosterHistory
      Dim tmp As Boolean = True
      If LoginID = "" Then LoginID = HttpContext.Current.Session("LoginID")
      If Remarks = "" Then Remarks = "By clicking on Roster."
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Sql &= " Update "
        Sql &= " ATN_WFHRooster "
        Sql &= " Set WFHFullDay = 1-WFHFullDay, "
        Sql &= " RoosterStatus = " & enumRoosterStatus.Updated & ","
        Sql &= " ModifiedBy = '" & LoginID & "',"
        Sql &= " ModifiedOn = GetDate(),"
        Sql &= " ModifierRemarks = '" & Remarks & "'"
        Sql &= " where AttenDate=convert(datetime,'" & AttenDate & "',103) "
        Sql &= " and CardNo='" & cardno & "'"
        Sql &= " Select isnull(WFHFullDay,0) "
        Sql &= " From ATN_WFHRooster "
        Sql &= " where AttenDate=convert(datetime,'" & AttenDate & "',103) "
        Sql &= " and CardNo='" & cardno & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          tmp = Cmd.ExecuteScalar
        End Using
      End Using
      'Insert in History
      Dim x As SIS.ATN.WFHRoosterHistory = SIS.ATN.WFHRoosterHistory.InsertData(SIS.ATN.WFHRoosterHistory.GetHistoryObject(SIS.ATN.WFHRooster.GetByCardDate(cardno, AttenDate)))
      x = SIS.ATN.WFHRoosterHistory.WFHRoosterHistoryGetByID(x.SerialNo)
      Return x
    End Function

  End Class
End Namespace
