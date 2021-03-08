Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnExecuteChangeRequest
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      If Not Executed Then mRet = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      If Not Executed Then mRet = True
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        If Not Executed Then mRet = True
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal RequestID As Int32) As SIS.ATN.atnExecuteChangeRequest
      Dim Results As SIS.ATN.atnExecuteChangeRequest = atnExecuteChangeRequestGetByID(RequestID)
      SIS.ATN.atnExecuteChangeRequest.atnApproverChangeRequestDelete(Results)
      Return Results
    End Function
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        If Not Executed Then mRet = True
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function InitiateWF(ByVal RequestID As Int32) As SIS.ATN.atnExecuteChangeRequest
      Dim x As SIS.ATN.retVal = SIS.ATN.atnApproverChangeRequest.ValidateRequest(RequestID, False)
      If x.isErr Then
        Throw New Exception(x.msg)
      End If
      Dim Results As SIS.ATN.atnExecuteChangeRequest = atnExecuteChangeRequestGetByID(RequestID)
      Results.Executed = True
      Results.ExecutedOn = Now
      SIS.ATN.atnExecuteChangeRequest.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_atnExecuteChangeRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As List(Of SIS.ATN.atnExecuteChangeRequest)
      Dim Results As List(Of SIS.ATN.atnExecuteChangeRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatn_LG_ExecuteChangeRequestSelectListSearch"
            Cmd.CommandText = "spatnExecuteChangeRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatn_LG_ExecuteChangeRequestSelectListFilteres"
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
  End Class
End Namespace
