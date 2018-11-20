Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnWebPayNewEmp
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _Salute As String = ""
    Private _Gender As String = ""
    Private _EmployeeName As String = ""
    Private _FatherName As String = ""
    Private _CostCompany As String = ""
    Private _Unit As String = ""
    Private _Category As String = ""
    Private _DesignationCode As String = ""
    Private _Designation As String = ""
    Private _DOB As String = ""
    Private _DOJ As String = ""
    Private _DOL As String = ""
    Private _EMail As String = ""
    Private _PFNO As String = ""
    Private _PAN As String = ""
    Private _Department As String = ""
    Private _Finalized As String = ""
    Private _PensionNo As String = ""
    Private _SeatingLocation As String = ""
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
    Public Property Salute() As String
      Get
        Return _Salute
      End Get
      Set(ByVal value As String)
        _Salute = value
      End Set
    End Property
    Public Property Gender() As String
      Get
        Return _Gender
      End Get
      Set(ByVal value As String)
        _Gender = value
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
    Public Property FatherName() As String
      Get
        Return _FatherName
      End Get
      Set(ByVal value As String)
        _FatherName = value
      End Set
    End Property
    Public Property CostCompany() As String
      Get
        Return _CostCompany
      End Get
      Set(ByVal value As String)
        _CostCompany = value
      End Set
    End Property
    Public Property Unit() As String
      Get
        Return _Unit
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Unit = ""
         Else
           _Unit = value
         End If
      End Set
    End Property
    Public Property Category() As String
      Get
        Return _Category
      End Get
      Set(ByVal value As String)
        _Category = value
      End Set
    End Property
    Public Property DesignationCode() As String
      Get
        Return _DesignationCode
      End Get
      Set(ByVal value As String)
        _DesignationCode = value
      End Set
    End Property
    Public Property Designation() As String
      Get
        Return _Designation
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Designation = ""
         Else
           _Designation = value
         End If
      End Set
    End Property
    Public Property DOB() As String
      Get
        If Not _DOB = String.Empty Then
          Return Convert.ToDateTime(_DOB).ToString("dd/MM/yyyy")
        End If
        Return _DOB
      End Get
      Set(ByVal value As String)
         _DOB = value
      End Set
    End Property
    Public Property DOJ() As String
      Get
        If Not _DOJ = String.Empty Then
          Return Convert.ToDateTime(_DOJ).ToString("dd/MM/yyyy")
        End If
        Return _DOJ
      End Get
      Set(ByVal value As String)
         _DOJ = value
      End Set
    End Property
    Public Property DOL() As String
      Get
        If Not _DOL = String.Empty Then
          Return Convert.ToDateTime(_DOL).ToString("dd/MM/yyyy")
        End If
        Return _DOL
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DOL = ""
         Else
           _DOL = value
         End If
      End Set
    End Property
    Public Property EMail() As String
      Get
        Return _EMail
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EMail = ""
         Else
           _EMail = value
         End If
      End Set
    End Property
    Public Property PFNO() As String
      Get
        Return _PFNO
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PFNO = ""
         Else
           _PFNO = value
         End If
      End Set
    End Property
    Public Property PAN() As String
      Get
        Return _PAN
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAN = ""
         Else
           _PAN = value
         End If
      End Set
    End Property
    Public Property Department() As String
      Get
        Return _Department
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Department = ""
         Else
           _Department = value
         End If
      End Set
    End Property
    Public Property Finalized() As String
      Get
        Return _Finalized
      End Get
      Set(ByVal value As String)
        _Finalized = value
      End Set
    End Property
    Public Property PensionNo() As String
      Get
        Return _PensionNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PensionNo = ""
         Else
           _PensionNo = value
         End If
      End Set
    End Property
    Public Property SeatingLocation() As String
      Get
        Return _SeatingLocation
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SeatingLocation = ""
         Else
           _SeatingLocation = value
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
    Public Class PKatnWebPayNewEmp
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnWebPayNewEmpGetNewRecord() As SIS.ATN.atnWebPayNewEmp
      Return New SIS.ATN.atnWebPayNewEmp()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnWebPayNewEmpGetByID(ByVal CardNo As String) As SIS.ATN.atnWebPayNewEmp
      Dim Results As SIS.ATN.atnWebPayNewEmp = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnWebPayNewEmpSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.VarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnWebPayNewEmp(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnWebPayNewEmpSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnWebPayNewEmp)
      Dim Results As List(Of SIS.ATN.atnWebPayNewEmp) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnWebPayNewEmpSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnWebPayNewEmpSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.VarChar,10, IIf(CardNo Is Nothing, String.Empty,CardNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnWebPayNewEmp)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnWebPayNewEmp(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnWebPayNewEmpSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnWebPayNewEmpGetByID(ByVal CardNo As String, ByVal Filter_CardNo As String) As SIS.ATN.atnWebPayNewEmp
      Return atnWebPayNewEmpGetByID(CardNo)
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
