Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnSiteAttendApproval
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
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
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal ApproverRemarks As String) As SIS.ATN.atnSiteAttendApproval
      Dim Results As SIS.ATN.atnSiteAttendApproval = atnSiteAttendApprovalGetByID(FinYear, MonthID, CardNo)
      With Results
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .ATNStatusID = atnAplStates.UnderPosting
        .ApproverRemarks = ApproverRemarks
      End With
      Results = SIS.ATN.atnSiteAttendApproval.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal ApproverRemarks As String) As SIS.ATN.atnSiteAttendApproval
      Dim Results As SIS.ATN.atnSiteAttendApproval = atnSiteAttendApprovalGetByID(FinYear, MonthID, CardNo)
      With Results
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .ATNStatusID = atnAplStates.SubmittedToHO
        .ApproverRemarks = ApproverRemarks
      End With
      Results = SIS.ATN.atnSiteAttendApproval.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_atnSiteAttendApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String) As List(Of SIS.ATN.atnSiteAttendApproval)
      Dim Results As List(Of SIS.ATN.atnSiteAttendApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "MonthID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatn_LG_SiteAttendApprovalSelectListSearch"
            Cmd.CommandText = "spatnSiteAttendApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatn_LG_SiteAttendApprovalSelectListFilteres"
            Cmd.CommandText = "spatnSiteAttendApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_MonthID", SqlDbType.Int, 10, IIf(MonthID = Nothing, 0, MonthID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApprovedBy", SqlDbType.NVarChar, 8, IIf(ApprovedBy Is Nothing, String.Empty, ApprovedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.ATN.atnSiteAttendApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSiteAttendApproval(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_atnSiteAttendApprovalUpdate(ByVal Record As SIS.ATN.atnSiteAttendApproval) As SIS.ATN.atnSiteAttendApproval
      Dim _Result As SIS.ATN.atnSiteAttendApproval = atnSiteAttendApprovalUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
