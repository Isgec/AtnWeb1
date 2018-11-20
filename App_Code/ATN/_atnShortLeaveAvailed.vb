Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnShortLeaveAvailed
    Private Shared _RecordCount As Integer
    Private _AttenID As Int32 = 0
    Private _AttenDate As String = ""
    Private _CardNo As String = ""
    Private _Punch1Time As String = ""
    Private _Punch2Time As String = ""
    Private _p1t As String = ""
    Private _p2t As String = ""
    Private _difmin As String = ""
    Private _EmployeeName As String = ""
    Private _Designation As String = ""
    Private _Department As String = ""
    Private _Division As String = ""
    Private _Location As String = ""
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
    Public Property AttenID() As Int32
      Get
        Return _AttenID
      End Get
      Set(ByVal value As Int32)
        _AttenID = value
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
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property Punch1Time() As String
      Get
        Return _Punch1Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Punch1Time = ""
				 Else
					 _Punch1Time = value
			   End If
      End Set
    End Property
    Public Property Punch2Time() As String
      Get
        Return _Punch2Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Punch2Time = ""
				 Else
					 _Punch2Time = value
			   End If
      End Set
    End Property
    Public Property p1t() As String
      Get
        If Not _p1t = String.Empty Then
          Return Convert.ToDateTime(_p1t).ToString("dd/MM/yyyy")
        End If
        Return _p1t
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _p1t = ""
				 Else
					 _p1t = value
			   End If
      End Set
    End Property
    Public Property p2t() As String
      Get
        If Not _p2t = String.Empty Then
          Return Convert.ToDateTime(_p2t).ToString("dd/MM/yyyy")
        End If
        Return _p2t
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _p2t = ""
				 Else
					 _p2t = value
			   End If
      End Set
    End Property
    Public Property difmin() As String
      Get
        Return _difmin
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _difmin = ""
				 Else
					 _difmin = value
			   End If
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
    Public Property Division() As String
      Get
        Return _Division
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Division = ""
				 Else
					 _Division = value
			   End If
      End Set
    End Property
    Public Property Location() As String
      Get
        Return _Location
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Location = ""
				 Else
					 _Location = value
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
        Return _AttenID
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
    Public Class PKatnShortLeaveAvailed
			Private _AttenID As Int32 = 0
			Public Property AttenID() As Int32
				Get
					Return _AttenID
				End Get
				Set(ByVal value As Int32)
					_AttenID = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnShortLeaveAvailedGetNewRecord() As SIS.ATN.atnShortLeaveAvailed
      Return New SIS.ATN.atnShortLeaveAvailed()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnShortLeaveAvailedGetByID(ByVal AttenID As Int32) As SIS.ATN.atnShortLeaveAvailed
      Dim Results As SIS.ATN.atnShortLeaveAvailed = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnShortLeaveAvailedSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID",SqlDbType.Int,AttenID.ToString.Length, AttenID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ATN.atnShortLeaveAvailed(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
	Public Shared Function atnShortLeaveAvailedSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnShortLeaveAvailed)
			Dim Results As List(Of SIS.ATN.atnShortLeaveAvailed) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnShortLeaveAvailedSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnShortLeaveAvailedSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnShortLeaveAvailed)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnShortLeaveAvailed(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
    Public Shared Function atnShortLeaveAvailedSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _AttenID = Ctype(Reader("AttenID"),Int32)
      _AttenDate = Ctype(Reader("AttenDate"),DateTime)
      _CardNo = Ctype(Reader("CardNo"),String)
      If Convert.IsDBNull(Reader("Punch1Time")) Then
        _Punch1Time = String.Empty
      Else
        _Punch1Time = Ctype(Reader("Punch1Time"), String)
      End If
      If Convert.IsDBNull(Reader("Punch2Time")) Then
        _Punch2Time = String.Empty
      Else
        _Punch2Time = Ctype(Reader("Punch2Time"), String)
      End If
      If Convert.IsDBNull(Reader("p1t")) Then
        _p1t = String.Empty
      Else
        _p1t = Ctype(Reader("p1t"), String)
      End If
      If Convert.IsDBNull(Reader("p2t")) Then
        _p2t = String.Empty
      Else
        _p2t = Ctype(Reader("p2t"), String)
      End If
      If Convert.IsDBNull(Reader("difmin")) Then
        _difmin = String.Empty
      Else
        _difmin = Ctype(Reader("difmin"), String)
      End If
      _EmployeeName = Ctype(Reader("EmployeeName"),String)
      If Convert.IsDBNull(Reader("Designation")) Then
        _Designation = String.Empty
      Else
        _Designation = Ctype(Reader("Designation"), String)
      End If
      If Convert.IsDBNull(Reader("Department")) Then
        _Department = String.Empty
      Else
        _Department = Ctype(Reader("Department"), String)
      End If
      If Convert.IsDBNull(Reader("Division")) Then
        _Division = String.Empty
      Else
        _Division = Ctype(Reader("Division"), String)
      End If
      If Convert.IsDBNull(Reader("Location")) Then
        _Location = String.Empty
      Else
        _Location = Ctype(Reader("Location"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
