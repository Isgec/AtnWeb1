Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnSABySIDays
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _D01 As String = ""
    Private _D02 As String = ""
    Private _D03 As String = ""
    Private _D04 As String = ""
    Private _D05 As String = ""
    Private _D06 As String = ""
    Private _D07 As String = ""
    Private _D08 As String = ""
    Private _D09 As String = ""
    Private _D10 As String = ""
    Private _D11 As String = ""
    Private _D12 As String = ""
    Private _D13 As String = ""
    Private _D14 As String = ""
    Private _D15 As String = ""
    Private _D16 As String = ""
    Private _D17 As String = ""
    Private _D18 As String = ""
    Private _D19 As String = ""
    Private _D20 As String = ""
    Private _D21 As String = ""
    Private _D22 As String = ""
    Private _D23 As String = ""
    Private _D24 As String = ""
    Private _D25 As String = ""
    Private _D26 As String = ""
    Private _D27 As String = ""
    Private _D28 As String = ""
    Private _D29 As String = ""
    Private _D30 As String = ""
    Private _D31 As String = ""
    Private _SerialNo As Int32 = 0
    Private _Remarks As String = ""
    Private _ATN_SABySI1_SiteName As String = ""
    Private _HRM_Employees2_EmployeeName As String = ""
    Private _FK_ATN_SABySIDays_SerialNo As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SABySIDays_CardNo As SIS.ATN.newHrmEmployees = Nothing
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
    Public Property D01() As String
      Get
        Return _D01
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D01 = ""
         Else
           _D01 = value
         End If
      End Set
    End Property
    Public Property D02() As String
      Get
        Return _D02
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D02 = ""
         Else
           _D02 = value
         End If
      End Set
    End Property
    Public Property D03() As String
      Get
        Return _D03
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D03 = ""
         Else
           _D03 = value
         End If
      End Set
    End Property
    Public Property D04() As String
      Get
        Return _D04
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D04 = ""
         Else
           _D04 = value
         End If
      End Set
    End Property
    Public Property D05() As String
      Get
        Return _D05
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D05 = ""
         Else
           _D05 = value
         End If
      End Set
    End Property
    Public Property D06() As String
      Get
        Return _D06
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D06 = ""
         Else
           _D06 = value
         End If
      End Set
    End Property
    Public Property D07() As String
      Get
        Return _D07
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D07 = ""
         Else
           _D07 = value
         End If
      End Set
    End Property
    Public Property D08() As String
      Get
        Return _D08
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D08 = ""
         Else
           _D08 = value
         End If
      End Set
    End Property
    Public Property D09() As String
      Get
        Return _D09
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D09 = ""
         Else
           _D09 = value
         End If
      End Set
    End Property
    Public Property D10() As String
      Get
        Return _D10
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D10 = ""
         Else
           _D10 = value
         End If
      End Set
    End Property
    Public Property D11() As String
      Get
        Return _D11
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D11 = ""
         Else
           _D11 = value
         End If
      End Set
    End Property
    Public Property D12() As String
      Get
        Return _D12
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D12 = ""
         Else
           _D12 = value
         End If
      End Set
    End Property
    Public Property D13() As String
      Get
        Return _D13
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D13 = ""
         Else
           _D13 = value
         End If
      End Set
    End Property
    Public Property D14() As String
      Get
        Return _D14
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D14 = ""
         Else
           _D14 = value
         End If
      End Set
    End Property
    Public Property D15() As String
      Get
        Return _D15
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D15 = ""
         Else
           _D15 = value
         End If
      End Set
    End Property
    Public Property D16() As String
      Get
        Return _D16
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D16 = ""
         Else
           _D16 = value
         End If
      End Set
    End Property
    Public Property D17() As String
      Get
        Return _D17
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D17 = ""
         Else
           _D17 = value
         End If
      End Set
    End Property
    Public Property D18() As String
      Get
        Return _D18
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D18 = ""
         Else
           _D18 = value
         End If
      End Set
    End Property
    Public Property D19() As String
      Get
        Return _D19
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D19 = ""
         Else
           _D19 = value
         End If
      End Set
    End Property
    Public Property D20() As String
      Get
        Return _D20
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D20 = ""
         Else
           _D20 = value
         End If
      End Set
    End Property
    Public Property D21() As String
      Get
        Return _D21
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D21 = ""
         Else
           _D21 = value
         End If
      End Set
    End Property
    Public Property D22() As String
      Get
        Return _D22
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D22 = ""
         Else
           _D22 = value
         End If
      End Set
    End Property
    Public Property D23() As String
      Get
        Return _D23
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D23 = ""
         Else
           _D23 = value
         End If
      End Set
    End Property
    Public Property D24() As String
      Get
        Return _D24
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D24 = ""
         Else
           _D24 = value
         End If
      End Set
    End Property
    Public Property D25() As String
      Get
        Return _D25
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D25 = ""
         Else
           _D25 = value
         End If
      End Set
    End Property
    Public Property D26() As String
      Get
        Return _D26
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D26 = ""
         Else
           _D26 = value
         End If
      End Set
    End Property
    Public Property D27() As String
      Get
        Return _D27
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D27 = ""
         Else
           _D27 = value
         End If
      End Set
    End Property
    Public Property D28() As String
      Get
        Return _D28
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D28 = ""
         Else
           _D28 = value
         End If
      End Set
    End Property
    Public Property D29() As String
      Get
        Return _D29
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D29 = ""
         Else
           _D29 = value
         End If
      End Set
    End Property
    Public Property D30() As String
      Get
        Return _D30
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D30 = ""
         Else
           _D30 = value
         End If
      End Set
    End Property
    Public Property D31() As String
      Get
        Return _D31
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _D31 = ""
         Else
           _D31 = value
         End If
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Remarks = ""
         Else
           _Remarks = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI1_SiteName() As String
      Get
        Return _ATN_SABySI1_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI1_SiteName = ""
         Else
           _ATN_SABySI1_SiteName = value
         End If
      End Set
    End Property
    Public Property HRM_Employees2_EmployeeName() As String
      Get
        Return _HRM_Employees2_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees2_EmployeeName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _CardNo
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
    Public Class PKatnSABySIDays
      Private _SerialNo As Int32 = 0
      Private _CardNo As String = ""
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
    End Class
    Public ReadOnly Property FK_ATN_SABySIDays_SerialNo() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SABySIDays_SerialNo Is Nothing Then
          _FK_ATN_SABySIDays_SerialNo = SIS.ATN.atnSABySI.atnSABySIGetByID(_SerialNo)
        End If
        Return _FK_ATN_SABySIDays_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SABySIDays_CardNo() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_SABySIDays_CardNo Is Nothing Then
          _FK_ATN_SABySIDays_CardNo = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_CardNo)
        End If
        Return _FK_ATN_SABySIDays_CardNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSABySIDaysGetNewRecord() As SIS.ATN.atnSABySIDays
      Return New SIS.ATN.atnSABySIDays()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSABySIDaysGetByID(ByVal SerialNo As Int32, ByVal CardNo As String) As SIS.ATN.atnSABySIDays
      Dim Results As SIS.ATN.atnSABySIDays = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIDaysSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnSABySIDays(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSABySIDaysSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.ATN.atnSABySIDays)
      Dim Results As List(Of SIS.ATN.atnSABySIDays) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CardNo"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnSABySIDaysSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnSABySIDaysSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnSABySIDays)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSABySIDays(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnSABySIDaysSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSABySIDaysGetByID(ByVal SerialNo As Int32, ByVal CardNo As String, ByVal Filter_SerialNo As Int32) As SIS.ATN.atnSABySIDays
      Return atnSABySIDaysGetByID(SerialNo, CardNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function atnSABySIDaysInsert(ByVal Record As SIS.ATN.atnSABySIDays) As SIS.ATN.atnSABySIDays
      Dim _Rec As SIS.ATN.atnSABySIDays = SIS.ATN.atnSABySIDays.atnSABySIDaysGetNewRecord()
      With _Rec
        .CardNo = Record.CardNo
        .D01 = Record.D01
        .D02 = Record.D02
        .D03 = Record.D03
        .D04 = Record.D04
        .D05 = Record.D05
        .D06 = Record.D06
        .D07 = Record.D07
        .D08 = Record.D08
        .D09 = Record.D09
        .D10 = Record.D10
        .D11 = Record.D11
        .D12 = Record.D12
        .D13 = Record.D13
        .D14 = Record.D14
        .D15 = Record.D15
        .D16 = Record.D16
        .D17 = Record.D17
        .D18 = Record.D18
        .D19 = Record.D19
        .D20 = Record.D20
        .D21 = Record.D21
        .D22 = Record.D22
        .D23 = Record.D23
        .D24 = Record.D24
        .D25 = Record.D25
        .D26 = Record.D26
        .D27 = Record.D27
        .D28 = Record.D28
        .D29 = Record.D29
        .D30 = Record.D30
        .D31 = Record.D31
        .SerialNo = Record.SerialNo
        .Remarks = Record.Remarks
      End With
      Return SIS.ATN.atnSABySIDays.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.atnSABySIDays) As SIS.ATN.atnSABySIDays
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIDaysInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D01",SqlDbType.NVarChar,3, Iif(Record.D01= "" ,Convert.DBNull, Record.D01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D02",SqlDbType.NVarChar,3, Iif(Record.D02= "" ,Convert.DBNull, Record.D02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D03",SqlDbType.NVarChar,3, Iif(Record.D03= "" ,Convert.DBNull, Record.D03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D04",SqlDbType.NVarChar,3, Iif(Record.D04= "" ,Convert.DBNull, Record.D04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D05",SqlDbType.NVarChar,3, Iif(Record.D05= "" ,Convert.DBNull, Record.D05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D06",SqlDbType.NVarChar,3, Iif(Record.D06= "" ,Convert.DBNull, Record.D06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D07",SqlDbType.NVarChar,3, Iif(Record.D07= "" ,Convert.DBNull, Record.D07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D08",SqlDbType.NVarChar,3, Iif(Record.D08= "" ,Convert.DBNull, Record.D08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D09",SqlDbType.NVarChar,3, Iif(Record.D09= "" ,Convert.DBNull, Record.D09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D10",SqlDbType.NVarChar,3, Iif(Record.D10= "" ,Convert.DBNull, Record.D10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D11",SqlDbType.NVarChar,3, Iif(Record.D11= "" ,Convert.DBNull, Record.D11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D12",SqlDbType.NVarChar,3, Iif(Record.D12= "" ,Convert.DBNull, Record.D12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D13",SqlDbType.NVarChar,3, Iif(Record.D13= "" ,Convert.DBNull, Record.D13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D14",SqlDbType.NVarChar,3, Iif(Record.D14= "" ,Convert.DBNull, Record.D14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D15",SqlDbType.NVarChar,3, Iif(Record.D15= "" ,Convert.DBNull, Record.D15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D16",SqlDbType.NVarChar,3, Iif(Record.D16= "" ,Convert.DBNull, Record.D16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D17",SqlDbType.NVarChar,3, Iif(Record.D17= "" ,Convert.DBNull, Record.D17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D18",SqlDbType.NVarChar,3, Iif(Record.D18= "" ,Convert.DBNull, Record.D18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D19",SqlDbType.NVarChar,3, Iif(Record.D19= "" ,Convert.DBNull, Record.D19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D20",SqlDbType.NVarChar,3, Iif(Record.D20= "" ,Convert.DBNull, Record.D20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D21",SqlDbType.NVarChar,3, Iif(Record.D21= "" ,Convert.DBNull, Record.D21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D22",SqlDbType.NVarChar,3, Iif(Record.D22= "" ,Convert.DBNull, Record.D22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D23",SqlDbType.NVarChar,3, Iif(Record.D23= "" ,Convert.DBNull, Record.D23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D24",SqlDbType.NVarChar,3, Iif(Record.D24= "" ,Convert.DBNull, Record.D24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D25",SqlDbType.NVarChar,3, Iif(Record.D25= "" ,Convert.DBNull, Record.D25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D26",SqlDbType.NVarChar,3, Iif(Record.D26= "" ,Convert.DBNull, Record.D26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D27",SqlDbType.NVarChar,3, Iif(Record.D27= "" ,Convert.DBNull, Record.D27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D28",SqlDbType.NVarChar,3, Iif(Record.D28= "" ,Convert.DBNull, Record.D28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D29",SqlDbType.NVarChar,3, Iif(Record.D29= "" ,Convert.DBNull, Record.D29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D30",SqlDbType.NVarChar,3, Iif(Record.D30= "" ,Convert.DBNull, Record.D30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D31",SqlDbType.NVarChar,3, Iif(Record.D31= "" ,Convert.DBNull, Record.D31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CardNo", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_CardNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.CardNo = Cmd.Parameters("@Return_CardNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function atnSABySIDaysUpdate(ByVal Record As SIS.ATN.atnSABySIDays) As SIS.ATN.atnSABySIDays
      Dim _Rec As SIS.ATN.atnSABySIDays = SIS.ATN.atnSABySIDays.atnSABySIDaysGetByID(Record.SerialNo, Record.CardNo)
      With _Rec
        .D01 = Record.D01
        .D02 = Record.D02
        .D03 = Record.D03
        .D04 = Record.D04
        .D05 = Record.D05
        .D06 = Record.D06
        .D07 = Record.D07
        .D08 = Record.D08
        .D09 = Record.D09
        .D10 = Record.D10
        .D11 = Record.D11
        .D12 = Record.D12
        .D13 = Record.D13
        .D14 = Record.D14
        .D15 = Record.D15
        .D16 = Record.D16
        .D17 = Record.D17
        .D18 = Record.D18
        .D19 = Record.D19
        .D20 = Record.D20
        .D21 = Record.D21
        .D22 = Record.D22
        .D23 = Record.D23
        .D24 = Record.D24
        .D25 = Record.D25
        .D26 = Record.D26
        .D27 = Record.D27
        .D28 = Record.D28
        .D29 = Record.D29
        .D30 = Record.D30
        .D31 = Record.D31
        .Remarks = Record.Remarks
      End With
      Return SIS.ATN.atnSABySIDays.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.atnSABySIDays) As SIS.ATN.atnSABySIDays
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIDaysUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D01",SqlDbType.NVarChar,3, Iif(Record.D01= "" ,Convert.DBNull, Record.D01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D02",SqlDbType.NVarChar,3, Iif(Record.D02= "" ,Convert.DBNull, Record.D02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D03",SqlDbType.NVarChar,3, Iif(Record.D03= "" ,Convert.DBNull, Record.D03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D04",SqlDbType.NVarChar,3, Iif(Record.D04= "" ,Convert.DBNull, Record.D04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D05",SqlDbType.NVarChar,3, Iif(Record.D05= "" ,Convert.DBNull, Record.D05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D06",SqlDbType.NVarChar,3, Iif(Record.D06= "" ,Convert.DBNull, Record.D06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D07",SqlDbType.NVarChar,3, Iif(Record.D07= "" ,Convert.DBNull, Record.D07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D08",SqlDbType.NVarChar,3, Iif(Record.D08= "" ,Convert.DBNull, Record.D08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D09",SqlDbType.NVarChar,3, Iif(Record.D09= "" ,Convert.DBNull, Record.D09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D10",SqlDbType.NVarChar,3, Iif(Record.D10= "" ,Convert.DBNull, Record.D10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D11",SqlDbType.NVarChar,3, Iif(Record.D11= "" ,Convert.DBNull, Record.D11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D12",SqlDbType.NVarChar,3, Iif(Record.D12= "" ,Convert.DBNull, Record.D12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D13",SqlDbType.NVarChar,3, Iif(Record.D13= "" ,Convert.DBNull, Record.D13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D14",SqlDbType.NVarChar,3, Iif(Record.D14= "" ,Convert.DBNull, Record.D14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D15",SqlDbType.NVarChar,3, Iif(Record.D15= "" ,Convert.DBNull, Record.D15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D16",SqlDbType.NVarChar,3, Iif(Record.D16= "" ,Convert.DBNull, Record.D16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D17",SqlDbType.NVarChar,3, Iif(Record.D17= "" ,Convert.DBNull, Record.D17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D18",SqlDbType.NVarChar,3, Iif(Record.D18= "" ,Convert.DBNull, Record.D18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D19",SqlDbType.NVarChar,3, Iif(Record.D19= "" ,Convert.DBNull, Record.D19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D20",SqlDbType.NVarChar,3, Iif(Record.D20= "" ,Convert.DBNull, Record.D20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D21",SqlDbType.NVarChar,3, Iif(Record.D21= "" ,Convert.DBNull, Record.D21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D22",SqlDbType.NVarChar,3, Iif(Record.D22= "" ,Convert.DBNull, Record.D22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D23",SqlDbType.NVarChar,3, Iif(Record.D23= "" ,Convert.DBNull, Record.D23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D24",SqlDbType.NVarChar,3, Iif(Record.D24= "" ,Convert.DBNull, Record.D24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D25",SqlDbType.NVarChar,3, Iif(Record.D25= "" ,Convert.DBNull, Record.D25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D26",SqlDbType.NVarChar,3, Iif(Record.D26= "" ,Convert.DBNull, Record.D26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D27",SqlDbType.NVarChar,3, Iif(Record.D27= "" ,Convert.DBNull, Record.D27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D28",SqlDbType.NVarChar,3, Iif(Record.D28= "" ,Convert.DBNull, Record.D28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D29",SqlDbType.NVarChar,3, Iif(Record.D29= "" ,Convert.DBNull, Record.D29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D30",SqlDbType.NVarChar,3, Iif(Record.D30= "" ,Convert.DBNull, Record.D30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@D31",SqlDbType.NVarChar,3, Iif(Record.D31= "" ,Convert.DBNull, Record.D31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
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
    Public Shared Function atnSABySIDaysDelete(ByVal Record As SIS.ATN.atnSABySIDays) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySIDaysDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,Record.CardNo.ToString.Length, Record.CardNo)
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
