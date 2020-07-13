Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class WFHRoosterHistory
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _CardNo As String = ""
    Private _AttenDate As String = ""
    Private _WFH1stHalf As Boolean = False
    Private _WFH2ndHalf As Boolean = False
    Private _WFHFullDay As Boolean = False
    Private _NonWorkingDay As Boolean = False
    Private _EmployeeNotActive As Boolean = False
    Private _RoosterStatus As Int32 = 0
    Private _ModifiedBy As String = ""
    Private _ModifiedOn As String = ""
    Private _ModifierRemarks As String = ""
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _FK_ATN_WFHRoosterHistory_ModifiedBy As SIS.ATN.newHrmEmployees = Nothing
    Public ReadOnly Property StatusName As String
      Get
        Return System.Enum.GetName(GetType(enumRoosterStatus), _RoosterStatus)
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
         If Convert.IsDBNull(Value) Then
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
         If Convert.IsDBNull(Value) Then
           _ModifierRemarks = ""
         Else
           _ModifierRemarks = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
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
    Public Class PKWFHRoosterHistory
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
    Public ReadOnly Property FK_ATN_WFHRoosterHistory_ModifiedBy() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_WFHRoosterHistory_ModifiedBy Is Nothing Then
          _FK_ATN_WFHRoosterHistory_ModifiedBy = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_ModifiedBy)
        End If
        Return _FK_ATN_WFHRoosterHistory_ModifiedBy
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function WFHRoosterHistoryGetNewRecord() As SIS.ATN.WFHRoosterHistory
      Return New SIS.ATN.WFHRoosterHistory()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function WFHRoosterHistoryGetByID(ByVal SerialNo As Int32) As SIS.ATN.WFHRoosterHistory
      Dim Results As SIS.ATN.WFHRoosterHistory = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterHistorySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.WFHRoosterHistory(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function WFHRoosterHistorySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.WFHRoosterHistory)
      Dim Results As List(Of SIS.ATN.WFHRoosterHistory) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spWFHRoosterHistorySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spWFHRoosterHistorySelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.WFHRoosterHistory)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.WFHRoosterHistory(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function WFHRoosterHistorySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    Public Shared Function GetHistoryObject(Record As SIS.ATN.WFHRooster, Optional byWhom As Integer = 1) As SIS.ATN.WFHRoosterHistory
      Dim mRet As New SIS.ATN.WFHRoosterHistory
      With mRet
        .CardNo = Record.CardNo
        .AttenDate = Record.AttenDate
        .WFH1stHalf = Record.WFH1stHalf
        .WFH2ndHalf = Record.WFH2ndHalf
        .WFHFullDay = Record.WFHFullDay
        .NonWorkingDay = Record.NonWorkingDay
        .EmployeeNotActive = Record.EmployeeNotActive
        .RoosterStatus = Record.RoosterStatus
        Select Case byWhom
          Case 0
            .ModifiedBy = Record.CreatedBy
            .ModifiedOn = Record.CreatedOn
            .ModifierRemarks = Record.CreaterRemarks
          Case 1
            .ModifiedBy = Record.ModifiedBy
            .ModifiedOn = Record.ModifiedOn
            .ModifierRemarks = Record.ModifierRemarks
          Case 2
            .ModifiedBy = Record.LockedBy
            .ModifiedOn = Record.LockedOn
            .ModifierRemarks = Record.LockerRemarks
        End Select
      End With
      Return mRet
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function WFHRoosterHistoryInsert(ByVal Record As SIS.ATN.WFHRoosterHistory) As SIS.ATN.WFHRoosterHistory
      Dim _Rec As SIS.ATN.WFHRoosterHistory = SIS.ATN.WFHRoosterHistory.WFHRoosterHistoryGetNewRecord()
      With _Rec
        .CardNo = Record.CardNo
        .AttenDate = Record.AttenDate
        .WFH1stHalf = Record.WFH1stHalf
        .WFH2ndHalf = Record.WFH2ndHalf
        .WFHFullDay = Record.WFHFullDay
        .NonWorkingDay = Record.NonWorkingDay
        .EmployeeNotActive = Record.EmployeeNotActive
        .RoosterStatus = Record.RoosterStatus
        .ModifiedBy = Record.ModifiedBy
        .ModifiedOn = Record.ModifiedOn
        .ModifierRemarks = Record.ModifierRemarks
      End With
      Return SIS.ATN.WFHRoosterHistory.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.WFHRoosterHistory) As SIS.ATN.WFHRoosterHistory
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterHistoryInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH1stHalf", SqlDbType.Bit, 3, Record.WFH1stHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH2ndHalf", SqlDbType.Bit, 3, Record.WFH2ndHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFHFullDay", SqlDbType.Bit, 3, Record.WFHFullDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonWorkingDay", SqlDbType.Bit, 3, Record.NonWorkingDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeNotActive", SqlDbType.Bit, 3, Record.EmployeeNotActive)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoosterStatus", SqlDbType.Int, 11, Record.RoosterStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy", SqlDbType.NVarChar, 9, IIf(Record.ModifiedBy = "", Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn", SqlDbType.DateTime, 21, Iif(Record.ModifiedOn = "", Convert.DBNull, Record.ModifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifierRemarks", SqlDbType.NVarChar, 251, Iif(Record.ModifierRemarks = "", Convert.DBNull, Record.ModifierRemarks))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function

    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function WFHRoosterHistoryUpdate(ByVal Record As SIS.ATN.WFHRoosterHistory) As SIS.ATN.WFHRoosterHistory
      Dim _Rec As SIS.ATN.WFHRoosterHistory = SIS.ATN.WFHRoosterHistory.WFHRoosterHistoryGetByID(Record.SerialNo)
      With _Rec
        .CardNo = Record.CardNo
        .AttenDate = Record.AttenDate
        .WFH1stHalf = Record.WFH1stHalf
        .WFH2ndHalf = Record.WFH2ndHalf
        .WFHFullDay = Record.WFHFullDay
        .NonWorkingDay = Record.NonWorkingDay
        .EmployeeNotActive = Record.EmployeeNotActive
        .RoosterStatus = Record.RoosterStatus
        .ModifiedBy = Record.ModifiedBy
        .ModifiedOn = Record.ModifiedOn
        .ModifierRemarks = Record.ModifierRemarks
      End With
      Return SIS.ATN.WFHRoosterHistory.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.WFHRoosterHistory) As SIS.ATN.WFHRoosterHistory
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterHistoryUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate",SqlDbType.DateTime,21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH1stHalf",SqlDbType.Bit,3, Record.WFH1stHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFH2ndHalf",SqlDbType.Bit,3, Record.WFH2ndHalf)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFHFullDay",SqlDbType.Bit,3, Record.WFHFullDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonWorkingDay",SqlDbType.Bit,3, Record.NonWorkingDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeNotActive",SqlDbType.Bit,3, Record.EmployeeNotActive)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoosterStatus", SqlDbType.Int, 11, Record.RoosterStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy", SqlDbType.NVarChar, 9, IIf(Record.ModifiedBy = "", Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn",SqlDbType.DateTime,21, Iif(Record.ModifiedOn= "" ,Convert.DBNull, Record.ModifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifierRemarks",SqlDbType.NVarChar,251, Iif(Record.ModifierRemarks= "" ,Convert.DBNull, Record.ModifierRemarks))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function WFHRoosterHistoryDelete(ByVal Record As SIS.ATN.WFHRoosterHistory) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spWFHRoosterHistoryDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
    Public Shared Function GetLatestByCardDate(cardno As String, attendate As String) As SIS.ATN.WFHRoosterHistory
      Dim tmp As SIS.ATN.WFHRoosterHistory = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Dim Sql As String = ""
        Sql &= " select Top 1 aa.*, cc.EmployeeName as HRM_Employees1_EmployeeName from ATN_WFHRoosterHistory as aa inner join hrm_employees as cc on cc.cardno=aa.modifiedby where aa.CardNo='" & cardno & "' and aa.attendate=convert(datetime,'" & attendate & "',103)"
        Sql &= " and aa.ModifiedOn = (select max(bb.modifiedon) from ATN_WFHRoosterHistory as bb where aa.CardNo=bb.CardNo and aa.attendate=bb.attendate)"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim rd As SqlDataReader = Cmd.ExecuteReader()
          While (rd.Read())
            tmp = New SIS.ATN.WFHRoosterHistory(rd)
          End While
          rd.Close()
        End Using
      End Using
      Return tmp
    End Function
    Public Shared Function GetLatestByCardConfig(cardno As String, fromDate As String, toDate As String) As SIS.ATN.WFHRoosterHistory
      Dim tmp As SIS.ATN.WFHRoosterHistory = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Dim Sql As String = ""
        Sql &= " select Top 1 aa.*, cc.EmployeeName as HRM_Employees1_EmployeeName  from ATN_WFHRoosterHistory as aa inner join hrm_employees as cc on cc.cardno=aa.modifiedby where aa.CardNo='" & cardno & "' and aa.attendate>=convert(datetime,'" & fromDate & "',103) and aa.attendate<=convert(datetime,'" & toDate & "',103)"
        Sql &= " and aa.ModifiedOn = (select max(bb.modifiedon) from ATN_WFHRoosterHistory as bb where aa.CardNo=bb.CardNo and bb.attendate>=convert(datetime,'" & fromDate & "',103) and bb.attendate<=convert(datetime,'" & toDate & "',103))"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim rd As SqlDataReader = Cmd.ExecuteReader()
          While (rd.Read())
            tmp = New SIS.ATN.WFHRoosterHistory(rd)
          End While
          rd.Close()
        End Using
      End Using
      Return tmp
    End Function

  End Class
End Namespace
