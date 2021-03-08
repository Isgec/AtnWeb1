Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnTABills
    Private Shared _RecordCount As Integer
    Public Property TABillNo As Int32 = 0
    Public Property EmployeeID As String = ""
    Public Property ApprovedBy As String = ""
    Public Property ApprovedByCC As String = ""
    Public Property ApprovedBySA As String = ""
    Public Property VerifiedBy As String = ""
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _TABillNo
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
    Public Class PKatnTABills
      Private _TABillNo As Int32 = 0
      Public Property TABillNo() As Int32
        Get
          Return _TABillNo
        End Get
        Set(ByVal value As Int32)
          _TABillNo = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnTABillsGetNewRecord() As SIS.ATN.atnTABills
      Return New SIS.ATN.atnTABills()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnTABillsGetByID(ByVal TABillNo As Int32) As SIS.ATN.atnTABills
      Dim Results As SIS.ATN.atnTABills = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnTABillsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnTABills(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnTABillList(CardNo As String, StatusID As Integer) As List(Of SIS.ATN.atnTABills)
      '6 Under Approval
      '8 Under Sanction By Sanctioning Authority
      '10  Under Verification
      Dim Results As New List(Of SIS.ATN.atnTABills)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from TA_Bills where employeeid='" & CardNo & "' and BillStatusID=" & StatusID
          _RecordCount = -1
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnTABills(Reader))
          End While
          Reader.Close()
          _RecordCount = Results.Count
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnTABillsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function atnTABillsUpdate(ByVal Record As SIS.ATN.atnTABills) As SIS.ATN.atnTABills
      Dim _Rec As SIS.ATN.atnTABills = SIS.ATN.atnTABills.atnTABillsGetByID(Record.TABillNo)
      With _Rec
        .EmployeeID = Record.EmployeeID
        .ApprovedBy = Record.ApprovedBy
        .ApprovedByCC = Record.ApprovedByCC
        .ApprovedBySA = Record.ApprovedBySA
        .VerifiedBy = Record.VerifiedBy
      End With
      Return SIS.ATN.atnTABills.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.atnTABills) As SIS.ATN.atnTABills
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnTABillsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCC",SqlDbType.NVarChar,9, Iif(Record.ApprovedByCC= "" ,Convert.DBNull, Record.ApprovedByCC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySA",SqlDbType.NVarChar,9, Iif(Record.ApprovedBySA= "" ,Convert.DBNull, Record.ApprovedBySA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.NVarChar,9, Iif(Record.VerifiedBy= "" ,Convert.DBNull, Record.VerifiedBy))
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
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
