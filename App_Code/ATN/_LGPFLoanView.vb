Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class LGPFLoanView
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _EmployeeName As String = ""
    Private _InstallmentAmount As String = "0.00"
    Private _PaidPrincipal As String = "0.00"
    Private _PaidInterest As String = "0.00"
    Private _BalancePrincipal As String = "0.00"
    Private _PayCode As String = ""
    Private _ForMonth As String = ""
    Private _ForYear As String = ""
    Private _Processed As String = ""
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
    Public Property EmployeeName() As String
      Get
        Return _EmployeeName
      End Get
      Set(ByVal value As String)
        _EmployeeName = value
      End Set
    End Property
    Public Property InstallmentAmount() As String
      Get
        Return _InstallmentAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _InstallmentAmount = "0.00"
         Else
           _InstallmentAmount = value
         End If
      End Set
    End Property
    Public Property PaidPrincipal() As String
      Get
        Return _PaidPrincipal
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PaidPrincipal = "0.00"
         Else
           _PaidPrincipal = value
         End If
      End Set
    End Property
    Public Property PaidInterest() As String
      Get
        Return _PaidInterest
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PaidInterest = "0.00"
         Else
           _PaidInterest = value
         End If
      End Set
    End Property
    Public Property BalancePrincipal() As String
      Get
        Return _BalancePrincipal
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BalancePrincipal = "0.00"
         Else
           _BalancePrincipal = value
         End If
      End Set
    End Property
    Public Property PayCode() As String
      Get
        Return _PayCode
      End Get
      Set(ByVal value As String)
        _PayCode = value
      End Set
    End Property
    Public Property ForMonth() As String
      Get
        Return _ForMonth
      End Get
      Set(ByVal value As String)
        _ForMonth = value
      End Set
    End Property
    Public Property ForYear() As String
      Get
        Return _ForYear
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ForYear = ""
         Else
           _ForYear = value
         End If
      End Set
    End Property
    Public Property Processed() As String
      Get
        Return _Processed
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Processed = ""
         Else
           _Processed = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CardNo & "|" & _ForMonth & "|" & _ForYear
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
    Public Class PKLGPFLoanView
      Private _CardNo As String = ""
      Private _ForMonth As String = ""
      Private _ForYear As String = ""
      Public Property CardNo() As String
        Get
          Return _CardNo
        End Get
        Set(ByVal value As String)
          _CardNo = value
        End Set
      End Property
      Public Property ForMonth() As String
        Get
          Return _ForMonth
        End Get
        Set(ByVal value As String)
          _ForMonth = value
        End Set
      End Property
      Public Property ForYear() As String
        Get
          Return _ForYear
        End Get
        Set(ByVal value As String)
          _ForYear = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function LGPFLoanViewGetNewRecord() As SIS.ATN.LGPFLoanView
      Return New SIS.ATN.LGPFLoanView()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function LGPFLoanViewGetByID(ByVal CardNo As String, ByVal ForMonth As String, ByVal ForYear As String) As SIS.ATN.LGPFLoanView
      Dim Results As SIS.ATN.LGPFLoanView = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWebPayConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "LG_PFLoanViewSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.VarChar, CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.VarChar, ForMonth.ToString.Length, ForMonth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForYear", SqlDbType.VarChar, ForYear.ToString.Length, ForYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.LGPFLoanView(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function LGPFLoanViewSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal ForMonth As String, ByVal ForYear As String) As List(Of SIS.ATN.LGPFLoanView)
      Dim Results As List(Of SIS.ATN.LGPFLoanView) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWebPayConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "LG_PFLoanViewSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "LG_PFLoanViewSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.VarChar, 10, IIf(CardNo Is Nothing, String.Empty, CardNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ForMonth", SqlDbType.VarChar, 2, IIf(ForMonth Is Nothing, String.Empty, ForMonth))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ForYear", SqlDbType.VarChar, 4, IIf(ForYear Is Nothing, String.Empty, ForYear))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.LGPFLoanView)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.LGPFLoanView(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function LGPFLoanViewSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal ForMonth As String, ByVal ForYear As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function LGPFLoanViewGetByID(ByVal CardNo As String, ByVal ForMonth As String, ByVal ForYear As String, ByVal Filter_CardNo As String, ByVal Filter_ForMonth As String, ByVal Filter_ForYear As String) As SIS.ATN.LGPFLoanView
      Return LGPFLoanViewGetByID(CardNo, ForMonth, ForYear)
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
