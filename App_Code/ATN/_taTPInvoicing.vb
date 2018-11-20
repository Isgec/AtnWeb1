Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taTPInvoicing
    Private Shared _RecordCount As Integer
    Private _InvoiceNo As String = ""
    Private _InvoiceDate As String = ""
    Private _PAXName As String = ""
    Private _Sector As String = ""
    Private _BookingDate As String = ""
    Private _TravelDate As String = ""
    Private _AirlinesName As String = ""
    Private _TicketNo As String = ""
    Private _NetAmount As String = "0.00"
    Private _EmployeeCode As String = ""
    Private _Sanction As String = ""
    Private _AirlineType As String = ""
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _FK_TA_TPInvoicing_EmployeeCode As SIS.ATN.atnEmployees = Nothing
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
    Public Property InvoiceNo() As String
      Get
        Return _InvoiceNo
      End Get
      Set(ByVal value As String)
        _InvoiceNo = value
      End Set
    End Property
    Public Property InvoiceDate() As String
      Get
        If Not _InvoiceDate = String.Empty Then
          Return Convert.ToDateTime(_InvoiceDate).ToString("dd/MM/yyyy")
        End If
        Return _InvoiceDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _InvoiceDate = ""
         Else
           _InvoiceDate = value
         End If
      End Set
    End Property
    Public Property PAXName() As String
      Get
        Return _PAXName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAXName = ""
         Else
           _PAXName = value
         End If
      End Set
    End Property
    Public Property Sector() As String
      Get
        Return _Sector
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Sector = ""
         Else
           _Sector = value
         End If
      End Set
    End Property
    Public Property BookingDate() As String
      Get
        If Not _BookingDate = String.Empty Then
          Return Convert.ToDateTime(_BookingDate).ToString("dd/MM/yyyy")
        End If
        Return _BookingDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BookingDate = ""
         Else
           _BookingDate = value
         End If
      End Set
    End Property
    Public Property TravelDate() As String
      Get
        If Not _TravelDate = String.Empty Then
          Return Convert.ToDateTime(_TravelDate).ToString("dd/MM/yyyy")
        End If
        Return _TravelDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TravelDate = ""
         Else
           _TravelDate = value
         End If
      End Set
    End Property
    Public Property AirlinesName() As String
      Get
        Return _AirlinesName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AirlinesName = ""
         Else
           _AirlinesName = value
         End If
      End Set
    End Property
    Public Property TicketNo() As String
      Get
        Return _TicketNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TicketNo = ""
         Else
           _TicketNo = value
         End If
      End Set
    End Property
    Public Property NetAmount() As String
      Get
        Return _NetAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _NetAmount = "0.00"
         Else
           _NetAmount = value
         End If
      End Set
    End Property
    Public Property EmployeeCode() As String
      Get
        Return _EmployeeCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EmployeeCode = ""
         Else
           _EmployeeCode = value
         End If
      End Set
    End Property
    Public Property Sanction() As String
      Get
        Return _Sanction
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Sanction = ""
         Else
           _Sanction = value
         End If
      End Set
    End Property
    Public Property AirlineType() As String
      Get
        Return _AirlineType
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AirlineType = ""
         Else
           _AirlineType = value
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
        Return "" & _Sector.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _InvoiceNo
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
    Public Class PKtaTPInvoicing
      Private _InvoiceNo As String = ""
      Public Property InvoiceNo() As String
        Get
          Return _InvoiceNo
        End Get
        Set(ByVal value As String)
          _InvoiceNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_TPInvoicing_EmployeeCode() As SIS.ATN.atnEmployees
      Get
        If _FK_TA_TPInvoicing_EmployeeCode Is Nothing Then
          _FK_TA_TPInvoicing_EmployeeCode = SIS.ATN.atnEmployees.atnEmployeesGetByID(_EmployeeCode)
        End If
        Return _FK_TA_TPInvoicing_EmployeeCode
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taTPInvoicingSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taTPInvoicing)
      Dim Results As List(Of SIS.TA.taTPInvoicing) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "InvoiceNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaTPInvoicingSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taTPInvoicing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taTPInvoicing(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taTPInvoicingGetNewRecord() As SIS.TA.taTPInvoicing
      Return New SIS.TA.taTPInvoicing()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taTPInvoicingGetByID(ByVal InvoiceNo As String) As SIS.TA.taTPInvoicing
      Dim Results As SIS.TA.taTPInvoicing = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaTPInvoicingSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceNo",SqlDbType.NVarChar,InvoiceNo.ToString.Length, InvoiceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taTPInvoicing(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByEmployeeCode(ByVal EmployeeCode As String, ByVal OrderBy as String) As List(Of SIS.TA.taTPInvoicing)
      Dim Results As List(Of SIS.TA.taTPInvoicing) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "InvoiceNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaTPInvoicingSelectByEmployeeCode"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeCode",SqlDbType.NVarChar,EmployeeCode.ToString.Length, EmployeeCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taTPInvoicing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taTPInvoicing(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taTPInvoicingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BookingDate As DateTime, ByVal TravelDate As DateTime, ByVal EmployeeCode As String) As List(Of SIS.TA.taTPInvoicing)
      Dim Results As List(Of SIS.TA.taTPInvoicing) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "InvoiceNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaTPInvoicingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaTPInvoicingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeCode",SqlDbType.NVarChar,8, IIf(EmployeeCode Is Nothing, String.Empty,EmployeeCode))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taTPInvoicing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taTPInvoicing(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taTPInvoicingSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BookingDate As DateTime, ByVal TravelDate As DateTime, ByVal EmployeeCode As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taTPInvoicingGetByID(ByVal InvoiceNo As String, ByVal Filter_BookingDate As DateTime, ByVal Filter_TravelDate As DateTime, ByVal Filter_EmployeeCode As String) As SIS.TA.taTPInvoicing
      Return taTPInvoicingGetByID(InvoiceNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taTPInvoicingInsert(ByVal Record As SIS.TA.taTPInvoicing) As SIS.TA.taTPInvoicing
      Dim _Rec As SIS.TA.taTPInvoicing = SIS.TA.taTPInvoicing.taTPInvoicingGetNewRecord()
      With _Rec
        .InvoiceNo = Record.InvoiceNo
        .InvoiceDate = Record.InvoiceDate
        .PAXName = Record.PAXName
        .Sector = Record.Sector
        .BookingDate = Record.BookingDate
        .TravelDate = Record.TravelDate
        .AirlinesName = Record.AirlinesName
        .TicketNo = Record.TicketNo
        .NetAmount = Record.NetAmount
        .EmployeeCode = Record.EmployeeCode
        .Sanction = Record.Sanction
        .AirlineType = Record.AirlineType
      End With
      Return SIS.TA.taTPInvoicing.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taTPInvoicing) As SIS.TA.taTPInvoicing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaTPInvoicingInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceNo",SqlDbType.NVarChar,16, Record.InvoiceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceDate",SqlDbType.DateTime,21, Iif(Record.InvoiceDate= "" ,Convert.DBNull, Record.InvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PAXName",SqlDbType.NVarChar,51, Iif(Record.PAXName= "" ,Convert.DBNull, Record.PAXName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sector",SqlDbType.NVarChar,51, Iif(Record.Sector= "" ,Convert.DBNull, Record.Sector))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BookingDate",SqlDbType.DateTime,21, Iif(Record.BookingDate= "" ,Convert.DBNull, Record.BookingDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelDate",SqlDbType.DateTime,21, Iif(Record.TravelDate= "" ,Convert.DBNull, Record.TravelDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirlinesName",SqlDbType.NVarChar,51, Iif(Record.AirlinesName= "" ,Convert.DBNull, Record.AirlinesName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TicketNo",SqlDbType.NVarChar,51, Iif(Record.TicketNo= "" ,Convert.DBNull, Record.TicketNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetAmount",SqlDbType.Decimal,9, Iif(Record.NetAmount= "" ,Convert.DBNull, Record.NetAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeCode",SqlDbType.NVarChar,9, Iif(Record.EmployeeCode= "" ,Convert.DBNull, Record.EmployeeCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sanction",SqlDbType.NVarChar,51, Iif(Record.Sanction= "" ,Convert.DBNull, Record.Sanction))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirlineType",SqlDbType.NVarChar,51, Iif(Record.AirlineType= "" ,Convert.DBNull, Record.AirlineType))
          Cmd.Parameters.Add("@Return_InvoiceNo", SqlDbType.NVarChar, 16)
          Cmd.Parameters("@Return_InvoiceNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.InvoiceNo = Cmd.Parameters("@Return_InvoiceNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taTPInvoicingUpdate(ByVal Record As SIS.TA.taTPInvoicing) As SIS.TA.taTPInvoicing
      Dim _Rec As SIS.TA.taTPInvoicing = SIS.TA.taTPInvoicing.taTPInvoicingGetByID(Record.InvoiceNo)
      With _Rec
        .InvoiceDate = Record.InvoiceDate
        .PAXName = Record.PAXName
        .Sector = Record.Sector
        .BookingDate = Record.BookingDate
        .TravelDate = Record.TravelDate
        .AirlinesName = Record.AirlinesName
        .TicketNo = Record.TicketNo
        .NetAmount = Record.NetAmount
        .EmployeeCode = Record.EmployeeCode
        .Sanction = Record.Sanction
        .AirlineType = Record.AirlineType
      End With
      Return SIS.TA.taTPInvoicing.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taTPInvoicing) As SIS.TA.taTPInvoicing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaTPInvoicingUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_InvoiceNo",SqlDbType.NVarChar,16, Record.InvoiceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceNo",SqlDbType.NVarChar,16, Record.InvoiceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceDate",SqlDbType.DateTime,21, Iif(Record.InvoiceDate= "" ,Convert.DBNull, Record.InvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PAXName",SqlDbType.NVarChar,51, Iif(Record.PAXName= "" ,Convert.DBNull, Record.PAXName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sector",SqlDbType.NVarChar,51, Iif(Record.Sector= "" ,Convert.DBNull, Record.Sector))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BookingDate",SqlDbType.DateTime,21, Iif(Record.BookingDate= "" ,Convert.DBNull, Record.BookingDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelDate",SqlDbType.DateTime,21, Iif(Record.TravelDate= "" ,Convert.DBNull, Record.TravelDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirlinesName",SqlDbType.NVarChar,51, Iif(Record.AirlinesName= "" ,Convert.DBNull, Record.AirlinesName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TicketNo",SqlDbType.NVarChar,51, Iif(Record.TicketNo= "" ,Convert.DBNull, Record.TicketNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetAmount",SqlDbType.Decimal,9, Iif(Record.NetAmount= "" ,Convert.DBNull, Record.NetAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeCode",SqlDbType.NVarChar,9, Iif(Record.EmployeeCode= "" ,Convert.DBNull, Record.EmployeeCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sanction",SqlDbType.NVarChar,51, Iif(Record.Sanction= "" ,Convert.DBNull, Record.Sanction))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirlineType",SqlDbType.NVarChar,51, Iif(Record.AirlineType= "" ,Convert.DBNull, Record.AirlineType))
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
    Public Shared Function taTPInvoicingDelete(ByVal Record As SIS.TA.taTPInvoicing) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaTPInvoicingDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_InvoiceNo",SqlDbType.NVarChar,Record.InvoiceNo.ToString.Length, Record.InvoiceNo)
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
    Public Shared Function SelecttaTPInvoicingAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaTPInvoicingAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taTPInvoicing = New SIS.TA.taTPInvoicing(Reader)
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
