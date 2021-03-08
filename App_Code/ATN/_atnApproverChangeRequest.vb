Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnApproverChangeRequest
    Private Shared _RecordCount As Integer
    Public Property RequestID As Int32 = 0
    Public Property VerifierID As String = ""
    Public Property ApproverID As String = ""
    Public Property TAVerifierID As String = ""
    Public Property TAApproverID As String = ""
    Public Property TASA As String = ""
    Public Property UserID As String = ""
    Public Property Requested As Boolean = False
    Private _RequestedOn As String = ""
    Public Property Executed As Boolean = False
    Private _ExecutedOn As String = ""
    Public Property ApprovalRequired As Boolean = False
    Public Property VerificationRequired As Boolean = False
    Public Property HRM_Employees1_EmployeeName As String = ""
    Public Property HRM_Employees2_EmployeeName As String = ""
    Public Property HRM_Employees3_EmployeeName As String = ""
    Public Property HRM_Employees4_EmployeeName As String = ""
    Public Property HRM_Employees5_EmployeeName As String = ""
    Public Property HRM_Employees6_EmployeeName As String = ""
    Private _FK_ATN_ApproverChangeRequest_UserID As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApproverChangeRequest_VerifierID As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApproverChangeRequest_AppriverID As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApproverChangeRequest_TAVerifierID As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApproverChangeRequest_TAApproverID As SIS.ATN.atnEmployees = Nothing
    Private _FK_ATN_ApproverChangeRequest_TASA As SIS.ATN.atnEmployees = Nothing
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
    Public Property RequestedOn() As String
      Get
        If Not _RequestedOn = String.Empty Then
          Return Convert.ToDateTime(_RequestedOn).ToString("dd/MM/yyyy")
        End If
        Return _RequestedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _RequestedOn = ""
        Else
          _RequestedOn = value
        End If
      End Set
    End Property
    Public Property ExecutedOn() As String
      Get
        If Not _ExecutedOn = String.Empty Then
          Return Convert.ToDateTime(_ExecutedOn).ToString("dd/MM/yyyy")
        End If
        Return _ExecutedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ExecutedOn = ""
        Else
          _ExecutedOn = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _RequestID
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
    Public Class PKatnApproverChangeRequest
      Private _RequestID As Int32 = 0
      Public Property RequestID() As Int32
        Get
          Return _RequestID
        End Get
        Set(ByVal value As Int32)
          _RequestID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ATN_ApproverChangeRequest_UserID() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApproverChangeRequest_UserID Is Nothing Then
          _FK_ATN_ApproverChangeRequest_UserID = SIS.ATN.atnEmployees.atnEmployeesGetByID(_UserID)
        End If
        Return _FK_ATN_ApproverChangeRequest_UserID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApproverChangeRequest_VerifierID() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApproverChangeRequest_VerifierID Is Nothing Then
          _FK_ATN_ApproverChangeRequest_VerifierID = SIS.ATN.atnEmployees.atnEmployeesGetByID(_VerifierID)
        End If
        Return _FK_ATN_ApproverChangeRequest_VerifierID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApproverChangeRequest_AppriverID() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApproverChangeRequest_AppriverID Is Nothing Then
          _FK_ATN_ApproverChangeRequest_AppriverID = SIS.ATN.atnEmployees.atnEmployeesGetByID(_ApproverID)
        End If
        Return _FK_ATN_ApproverChangeRequest_AppriverID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApproverChangeRequest_TAVerifierID() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApproverChangeRequest_TAVerifierID Is Nothing Then
          _FK_ATN_ApproverChangeRequest_TAVerifierID = SIS.ATN.atnEmployees.atnEmployeesGetByID(_TAVerifierID)
        End If
        Return _FK_ATN_ApproverChangeRequest_TAVerifierID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApproverChangeRequest_TAApproverID() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApproverChangeRequest_TAApproverID Is Nothing Then
          _FK_ATN_ApproverChangeRequest_TAApproverID = SIS.ATN.atnEmployees.atnEmployeesGetByID(_TAApproverID)
        End If
        Return _FK_ATN_ApproverChangeRequest_TAApproverID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_ApproverChangeRequest_TASA() As SIS.ATN.atnEmployees
      Get
        If _FK_ATN_ApproverChangeRequest_TASA Is Nothing Then
          _FK_ATN_ApproverChangeRequest_TASA = SIS.ATN.atnEmployees.atnEmployeesGetByID(_TASA)
        End If
        Return _FK_ATN_ApproverChangeRequest_TASA
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnApproverChangeRequestGetNewRecord() As SIS.ATN.atnApproverChangeRequest
      Return New SIS.ATN.atnApproverChangeRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnApproverChangeRequestGetByID(ByVal RequestID As Int32) As SIS.ATN.atnApproverChangeRequest
      Dim Results As SIS.ATN.atnApproverChangeRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID", SqlDbType.Int, RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnApproverChangeRequest(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnApproverChangeRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnApproverChangeRequest)
      Dim Results As List(Of SIS.ATN.atnApproverChangeRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnApproverChangeRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnApproverChangeRequestSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnApproverChangeRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnApproverChangeRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnApproverChangeRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function atnApproverChangeRequestInsert(ByVal Record As SIS.ATN.atnApproverChangeRequest) As SIS.ATN.atnApproverChangeRequest
      Dim _Rec As SIS.ATN.atnApproverChangeRequest = SIS.ATN.atnApproverChangeRequest.atnApproverChangeRequestGetNewRecord()
      With _Rec
        .VerifierID = Record.VerifierID
        .ApproverID = Record.ApproverID
        .TAVerifierID = Record.TAVerifierID
        .TAApproverID = Record.TAApproverID
        .TASA = Record.TASA
        .UserID = Global.System.Web.HttpContext.Current.Session("LoginID")
        .Requested = Record.Requested
        .RequestedOn = Record.RequestedOn
        .Executed = Record.Executed
        .ExecutedOn = Record.ExecutedOn
        .ApprovalRequired = Record.ApprovalRequired
        .VerificationRequired = Record.VerificationRequired
      End With
      Return SIS.ATN.atnApproverChangeRequest.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.atnApproverChangeRequest) As SIS.ATN.atnApproverChangeRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierID", SqlDbType.NVarChar, 9, IIf(Record.VerifierID = "", Convert.DBNull, Record.VerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID", SqlDbType.NVarChar, 9, IIf(Record.ApproverID = "", Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAVerifierID", SqlDbType.NVarChar, 9, IIf(Record.TAVerifierID = "", Convert.DBNull, Record.TAVerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAApproverID", SqlDbType.NVarChar, 9, IIf(Record.TAApproverID = "", Convert.DBNull, Record.TAApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASA", SqlDbType.NVarChar, 9, IIf(Record.TASA = "", Convert.DBNull, Record.TASA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 9, IIf(Record.UserID = "", Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Requested", SqlDbType.Bit, 3, Record.Requested)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn", SqlDbType.DateTime, 21, IIf(Record.RequestedOn = "", Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Executed", SqlDbType.Bit, 3, Record.Executed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedOn", SqlDbType.DateTime, 21, IIf(Record.ExecutedOn = "", Convert.DBNull, Record.ExecutedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired", SqlDbType.Bit, 3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired", SqlDbType.Bit, 3, Record.VerificationRequired)
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RequestID = Cmd.Parameters("@Return_RequestID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function atnApproverChangeRequestUpdate(ByVal Record As SIS.ATN.atnApproverChangeRequest) As SIS.ATN.atnApproverChangeRequest
      Dim _Rec As SIS.ATN.atnApproverChangeRequest = SIS.ATN.atnApproverChangeRequest.atnApproverChangeRequestGetByID(Record.RequestID)
      With _Rec
        .VerifierID = Record.VerifierID
        .ApproverID = Record.ApproverID
        .TAVerifierID = Record.TAVerifierID
        .TAApproverID = Record.TAApproverID
        .TASA = Record.TASA
        .UserID = Global.System.Web.HttpContext.Current.Session("LoginID")
        .Requested = Record.Requested
        .RequestedOn = Record.RequestedOn
        .Executed = Record.Executed
        .ExecutedOn = Record.ExecutedOn
        .ApprovalRequired = Record.ApprovalRequired
        .VerificationRequired = Record.VerificationRequired
      End With
      Return SIS.ATN.atnApproverChangeRequest.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.atnApproverChangeRequest) As SIS.ATN.atnApproverChangeRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID", SqlDbType.Int, 11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierID", SqlDbType.NVarChar, 9, IIf(Record.VerifierID = "", Convert.DBNull, Record.VerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID", SqlDbType.NVarChar, 9, IIf(Record.ApproverID = "", Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAVerifierID", SqlDbType.NVarChar, 9, IIf(Record.TAVerifierID = "", Convert.DBNull, Record.TAVerifierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAApproverID", SqlDbType.NVarChar, 9, IIf(Record.TAApproverID = "", Convert.DBNull, Record.TAApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASA", SqlDbType.NVarChar, 9, IIf(Record.TASA = "", Convert.DBNull, Record.TASA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 9, IIf(Record.UserID = "", Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Requested", SqlDbType.Bit, 3, Record.Requested)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn", SqlDbType.DateTime, 21, IIf(Record.RequestedOn = "", Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Executed", SqlDbType.Bit, 3, Record.Executed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedOn", SqlDbType.DateTime, 21, IIf(Record.ExecutedOn = "", Convert.DBNull, Record.ExecutedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRequired", SqlDbType.Bit, 3, Record.ApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRequired", SqlDbType.Bit, 3, Record.VerificationRequired)
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
    Public Shared Function atnApproverChangeRequestDelete(ByVal Record As SIS.ATN.atnApproverChangeRequest) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID", SqlDbType.Int, Record.RequestID.ToString.Length, Record.RequestID)
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
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
