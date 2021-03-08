Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnExecuteChangeRequest
    Inherits SIS.ATN.atnApproverChangeRequest
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnExecuteChangeRequestGetNewRecord() As SIS.ATN.atnExecuteChangeRequest
      Return New SIS.ATN.atnExecuteChangeRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnExecuteChangeRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As List(Of SIS.ATN.atnExecuteChangeRequest)
      Dim Results As List(Of SIS.ATN.atnExecuteChangeRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnExecuteChangeRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnExecuteChangeRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID", SqlDbType.NVarChar, 8, IIf(UserID Is Nothing, String.Empty, UserID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Requested", SqlDbType.Bit, 2, True)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Executed", SqlDbType.Bit, 2, False)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.ATN.atnExecuteChangeRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnExecuteChangeRequest(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function atnExecuteChangeRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnExecuteChangeRequestGetByID(ByVal RequestID As Int32) As SIS.ATN.atnExecuteChangeRequest
      Dim Results As SIS.ATN.atnExecuteChangeRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnApproverChangeRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID", SqlDbType.Int, RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnExecuteChangeRequest(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function atnExecuteChangeRequestGetByID(ByVal RequestID As Int32, ByVal Filter_UserID As String) As SIS.ATN.atnExecuteChangeRequest
      Dim Results As SIS.ATN.atnExecuteChangeRequest = SIS.ATN.atnExecuteChangeRequest.atnExecuteChangeRequestGetByID(RequestID)
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
