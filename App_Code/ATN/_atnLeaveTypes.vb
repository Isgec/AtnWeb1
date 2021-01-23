Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnLeaveTypes
    Private Shared _RecordCount As Integer
    Public Property LeaveTypeID As String
    Public Property Description As String
    Public Property OBALApplicable As Boolean
    Public Property OBALMonthly As Boolean
    Public Property OpeningBalance As String
    Public Property CarryForward As Boolean
    Public Property ForwardToLeaveTypeID As String
    Public Property AdvanceApplicable As Boolean
    Public Property SpecialSanctionRequired As Boolean
    Public Property SpecialSanctionBy As String
    Public Property Applyiable As Boolean
    Public Property ApplyiableSite As Boolean = False
    Public Property ApplyiableOffice As Boolean = False
    Public Property Postable As Boolean
    Public Property PostedLeaveTypeID As String
    Public Property Sequence As String
    Public Property MainType As Boolean
    Public Property SpecialSanctionByEmployeeName As String
    Public Property ForSite As Boolean = False
    Public Property BaseType As String = ""
    Public Property DisplayType As String = ""

    Private _ForwardToLeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Private _SpecialSanctionByHRM_Employees As SIS.ATN.atnEmployees
    Private _PostedLeaveTypeIDATN_LeaveTypes As SIS.ATN.atnLeaveTypes
    Public ReadOnly Property ForwardToLeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _ForwardToLeaveTypeIDATN_LeaveTypes Is Nothing Then
          _ForwardToLeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_ForwardToLeaveTypeID)
        End If
        Return _ForwardToLeaveTypeIDATN_LeaveTypes
      End Get
    End Property
    Public ReadOnly Property SpecialSanctionByHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _SpecialSanctionByHRM_Employees Is Nothing Then
          _SpecialSanctionByHRM_Employees = SIS.ATN.atnEmployees.GetByID(_SpecialSanctionBy)
        End If
        Return _SpecialSanctionByHRM_Employees
      End Get
    End Property
    Public ReadOnly Property PostedLeaveTypeIDATN_LeaveTypes() As SIS.ATN.atnLeaveTypes
      Get
        If _PostedLeaveTypeIDATN_LeaveTypes Is Nothing Then
          _PostedLeaveTypeIDATN_LeaveTypes = SIS.ATN.atnLeaveTypes.GetByID(_PostedLeaveTypeID)
        End If
        Return _PostedLeaveTypeIDATN_LeaveTypes
      End Get
    End Property

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ATN.atnLeaveTypes)
      Dim Results As List(Of SIS.ATN.atnLeaveTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "Sequence"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveTypesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnLeaveTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnLeaveTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveTypeID As String) As SIS.ATN.atnLeaveTypes
      Dim Results As SIS.ATN.atnLeaveTypes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnLeaveTypesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveTypeID",SqlDbType.NVarChar,LeaveTypeID.ToString.Length, LeaveTypeID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnLeaveTypes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    '		Autocomplete Method
    Public Shared Function SelectatnLeaveTypesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer) As String()
			Dim Results As List(Of String) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnLeaveTypesAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---", ""))
					While (Reader.Read())
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Reader(0), Reader(1)))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
