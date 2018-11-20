Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.IJT
  <DataObject()> _
  Partial Public Class ijtAttendance
    Private Shared _RecordCount As Integer
		Private _RecordID As String = ""
		Private _CardNo As String = ""
		Private _DataMonth As Int32 = 0
		Private _C_ProjectSiteID As String = ""
		Private _FinYear As String = ""
		Private _UnVerified As Boolean = False
		Private _UnverifiedCount As Integer = 0
    Private _D1 As String = ""
    Private _D2 As String = ""
    Private _D3 As String = ""
    Private _D4 As String = ""
    Private _D5 As String = ""
    Private _D6 As String = ""
    Private _D7 As String = ""
    Private _D8 As String = ""
    Private _D9 As String = ""
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
		Private _FK_IJT_Attendance_HRM_Employees As SIS.ATN.atnEmployees = Nothing
		Public Property UnVerified() As Boolean
			Get
				Return _UnVerified
			End Get
			Set(ByVal value As Boolean)
				If Convert.IsDBNull(value) Then
					_UnVerified = True
				Else
					_UnVerified = value
				End If
			End Set
		End Property
		Public Property UnVerifiedCount() As Integer
			Get
				Return _UnverifiedCount
			End Get
			Set(ByVal value As Integer)
				If Convert.IsDBNull(value) Then
					_UnverifiedCount = 1
				Else
					_UnverifiedCount = value
				End If
			End Set
		End Property
		Public Property RecordID() As String
			Get
				Return _RecordID
			End Get
			Set(ByVal value As String)
				_RecordID = value
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
    Public Property DataMonth() As Int32
      Get
        Return _DataMonth
      End Get
      Set(ByVal value As Int32)
        _DataMonth = value
      End Set
    End Property
		Public Property C_ProjectSiteID() As String
			Get
				Return _C_ProjectSiteID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_C_ProjectSiteID = ""
				Else
					_C_ProjectSiteID = value
				End If
			End Set
		End Property
		Public Property FinYear() As String
			Get
				Return _FinYear
			End Get
			Set(ByVal value As String)
				_FinYear = value
			End Set
		End Property
    Public Property D1() As String
      Get
        Return _D1
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D1 = ""
				 Else
					 _D1 = value
			   End If
      End Set
    End Property
    Public Property D2() As String
      Get
        Return _D2
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D2 = ""
				 Else
					 _D2 = value
			   End If
      End Set
    End Property
    Public Property D3() As String
      Get
        Return _D3
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D3 = ""
				 Else
					 _D3 = value
			   End If
      End Set
    End Property
    Public Property D4() As String
      Get
        Return _D4
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D4 = ""
				 Else
					 _D4 = value
			   End If
      End Set
    End Property
    Public Property D5() As String
      Get
        Return _D5
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D5 = ""
				 Else
					 _D5 = value
			   End If
      End Set
    End Property
    Public Property D6() As String
      Get
        Return _D6
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D6 = ""
				 Else
					 _D6 = value
			   End If
      End Set
    End Property
    Public Property D7() As String
      Get
        Return _D7
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D7 = ""
				 Else
					 _D7 = value
			   End If
      End Set
    End Property
    Public Property D8() As String
      Get
        Return _D8
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D8 = ""
				 Else
					 _D8 = value
			   End If
      End Set
    End Property
    Public Property D9() As String
      Get
        Return _D9
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _D9 = ""
				 Else
					 _D9 = value
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
		Public Property DisplayField() As String
			Get
				Return ""
			End Get
			Set(ByVal value As String)
			End Set
		End Property
    Public Property PrimaryKey() As String
      Get
        Return _RecordID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
		Public ReadOnly Property FK_IJT_Attendance_HRM_Employees() As SIS.ATN.atnEmployees
			Get
				If _FK_IJT_Attendance_HRM_Employees Is Nothing Then
					_FK_IJT_Attendance_HRM_Employees = SIS.ATN.atnEmployees.GetByID(_CardNo)
				End If
				Return _FK_IJT_Attendance_HRM_Employees
			End Get
		End Property
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal RecordID As String) As SIS.IJT.ijtAttendance
			Dim Results As SIS.IJT.ijtAttendance = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spijtAttendanceSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID", SqlDbType.NVarChar, RecordID.Length, RecordID)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.IJT.ijtAttendance(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
      'Select By ID One Record Filtered Overloaded GetByID
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal RecordID As String, ByVal Filter_CardNo As String, ByVal Filter_DataMonth As Int32) As SIS.IJT.ijtAttendance
			Return GetByID(RecordID)
		End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal DataMonth As Int32) As List(Of SIS.IJT.ijtAttendance)
      Dim Results As List(Of SIS.IJT.ijtAttendance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spijtAttendanceSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spijtAttendanceSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DataMonth",SqlDbType.Int,10, IIf(DataMonth = Nothing, 0,DataMonth))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 6, Global.System.Web.HttpContext.Current.Session("ProjectID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.IJT.ijtAttendance)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.IJT.ijtAttendance(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
		Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal DataMonth As Int32) As Integer
			Return _RecordCount
		End Function
		Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal C_ProjectSiteID As String, ByVal DataMonth As Int32, ByVal VerificationStatus As String) As Integer
			Return _RecordCount
		End Function
		Public Sub New(ByVal Reader As SqlDataReader)
			On Error Resume Next
			_RecordID = CType(Reader("RecordID"), String)
			_CardNo = CType(Reader("CardNo"), String)
			_DataMonth = CType(Reader("DataMonth"), Int32)
			_FinYear = CType(Reader("FinYear"), String)
			If Convert.IsDBNull(Reader("D1")) Then
				_D1 = String.Empty
			Else
				_D1 = CType(Reader("D1"), String)
			End If
			If Convert.IsDBNull(Reader("D2")) Then
				_D2 = String.Empty
			Else
				_D2 = CType(Reader("D2"), String)
			End If
			If Convert.IsDBNull(Reader("D3")) Then
				_D3 = String.Empty
			Else
				_D3 = CType(Reader("D3"), String)
			End If
			If Convert.IsDBNull(Reader("D4")) Then
				_D4 = String.Empty
			Else
				_D4 = CType(Reader("D4"), String)
			End If
			If Convert.IsDBNull(Reader("D5")) Then
				_D5 = String.Empty
			Else
				_D5 = CType(Reader("D5"), String)
			End If
			If Convert.IsDBNull(Reader("D6")) Then
				_D6 = String.Empty
			Else
				_D6 = CType(Reader("D6"), String)
			End If
			If Convert.IsDBNull(Reader("D7")) Then
				_D7 = String.Empty
			Else
				_D7 = CType(Reader("D7"), String)
			End If
			If Convert.IsDBNull(Reader("D8")) Then
				_D8 = String.Empty
			Else
				_D8 = CType(Reader("D8"), String)
			End If
			If Convert.IsDBNull(Reader("D9")) Then
				_D9 = String.Empty
			Else
				_D9 = CType(Reader("D9"), String)
			End If
			If Convert.IsDBNull(Reader("D10")) Then
				_D10 = String.Empty
			Else
				_D10 = CType(Reader("D10"), String)
			End If
			If Convert.IsDBNull(Reader("D11")) Then
				_D11 = String.Empty
			Else
				_D11 = CType(Reader("D11"), String)
			End If
			If Convert.IsDBNull(Reader("D12")) Then
				_D12 = String.Empty
			Else
				_D12 = CType(Reader("D12"), String)
			End If
			If Convert.IsDBNull(Reader("D13")) Then
				_D13 = String.Empty
			Else
				_D13 = CType(Reader("D13"), String)
			End If
			If Convert.IsDBNull(Reader("D14")) Then
				_D14 = String.Empty
			Else
				_D14 = CType(Reader("D14"), String)
			End If
			If Convert.IsDBNull(Reader("D15")) Then
				_D15 = String.Empty
			Else
				_D15 = CType(Reader("D15"), String)
			End If
			If Convert.IsDBNull(Reader("D16")) Then
				_D16 = String.Empty
			Else
				_D16 = CType(Reader("D16"), String)
			End If
			If Convert.IsDBNull(Reader("D17")) Then
				_D17 = String.Empty
			Else
				_D17 = CType(Reader("D17"), String)
			End If
			If Convert.IsDBNull(Reader("D18")) Then
				_D18 = String.Empty
			Else
				_D18 = CType(Reader("D18"), String)
			End If
			If Convert.IsDBNull(Reader("D19")) Then
				_D19 = String.Empty
			Else
				_D19 = CType(Reader("D19"), String)
			End If
			If Convert.IsDBNull(Reader("D20")) Then
				_D20 = String.Empty
			Else
				_D20 = CType(Reader("D20"), String)
			End If
			If Convert.IsDBNull(Reader("D21")) Then
				_D21 = String.Empty
			Else
				_D21 = CType(Reader("D21"), String)
			End If
			If Convert.IsDBNull(Reader("D22")) Then
				_D22 = String.Empty
			Else
				_D22 = CType(Reader("D22"), String)
			End If
			If Convert.IsDBNull(Reader("D23")) Then
				_D23 = String.Empty
			Else
				_D23 = CType(Reader("D23"), String)
			End If
			If Convert.IsDBNull(Reader("D24")) Then
				_D24 = String.Empty
			Else
				_D24 = CType(Reader("D24"), String)
			End If
			If Convert.IsDBNull(Reader("D25")) Then
				_D25 = String.Empty
			Else
				_D25 = CType(Reader("D25"), String)
			End If
			If Convert.IsDBNull(Reader("D26")) Then
				_D26 = String.Empty
			Else
				_D26 = CType(Reader("D26"), String)
			End If
			If Convert.IsDBNull(Reader("D27")) Then
				_D27 = String.Empty
			Else
				_D27 = CType(Reader("D27"), String)
			End If
			If Convert.IsDBNull(Reader("D28")) Then
				_D28 = String.Empty
			Else
				_D28 = CType(Reader("D28"), String)
			End If
			If Convert.IsDBNull(Reader("D29")) Then
				_D29 = String.Empty
			Else
				_D29 = CType(Reader("D29"), String)
			End If
			If Convert.IsDBNull(Reader("D30")) Then
				_D30 = String.Empty
			Else
				_D30 = CType(Reader("D30"), String)
			End If
			If Convert.IsDBNull(Reader("D31")) Then
				_D31 = String.Empty
			Else
				_D31 = CType(Reader("D31"), String)
			End If
			If Convert.IsDBNull(Reader("C_ProjectSiteID")) Then
				_C_ProjectSiteID = String.Empty
			Else
				_C_ProjectSiteID = CType(Reader("C_ProjectSiteID"), String)
			End If
			If Convert.IsDBNull(Reader("UnVerified")) Then
				_UnVerified = True
			Else
				_UnVerified = Reader("UnVerified")
			End If
			If Convert.IsDBNull(Reader("UnVerifiedCount")) Then
				_UnverifiedCount = 1
			Else
				_UnverifiedCount = Reader("UnVerifiedCount")
			End If
			_FK_IJT_Attendance_HRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees3", Reader)
		End Sub
		Public Sub New()
		End Sub
  End Class
End Namespace
