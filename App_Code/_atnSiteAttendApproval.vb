Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnSiteAttendApproval
    Inherits SIS.ATN.atnSiteAttendance
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendApprovalGetNewRecord() As SIS.ATN.atnSiteAttendApproval
      Return New SIS.ATN.atnSiteAttendApproval()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String) As List(Of SIS.ATN.atnSiteAttendApproval)
      Dim Results As List(Of SIS.ATN.atnSiteAttendApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "MonthID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnSiteAttendApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnSiteAttendApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_MonthID",SqlDbType.Int,10, IIf(MonthID = Nothing, 0,MonthID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApprovedBy",SqlDbType.NVarChar,8, IIf(ApprovedBy Is Nothing, String.Empty,ApprovedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
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
    Public Shared Function atnSiteAttendApprovalSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendApprovalGetByID(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String) As SIS.ATN.atnSiteAttendApproval
      Dim Results As SIS.ATN.atnSiteAttendApproval = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSiteAttendanceSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID",SqlDbType.Int,MonthID.ToString.Length, MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnSiteAttendApproval(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendApprovalGetByID(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal Filter_MonthID As Int32, ByVal Filter_ApprovedBy As String) As SIS.ATN.atnSiteAttendApproval
      Dim Results As SIS.ATN.atnSiteAttendApproval = SIS.ATN.atnSiteAttendApproval.atnSiteAttendApprovalGetByID(FinYear, MonthID, CardNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function atnSiteAttendApprovalInsert(ByVal Record As SIS.ATN.atnSiteAttendApproval) As SIS.ATN.atnSiteAttendApproval
      Dim _Rec As SIS.ATN.atnSiteAttendApproval = SIS.ATN.atnSiteAttendApproval.atnSiteAttendApprovalGetNewRecord()
      With _Rec
        .FinYear =  Global.System.Web.HttpContext.Current.Session("FinYear")
        .MonthID = Record.MonthID
        .CardNo = Record.CardNo
        .VD01 = Record.VD01
        .VD02 = Record.VD02
        .VD03 = Record.VD03
        .VD04 = Record.VD04
        .VD05 = Record.VD05
        .VD06 = Record.VD06
        .VD07 = Record.VD07
        .VD08 = Record.VD08
        .VD09 = Record.VD09
        .VD10 = Record.VD10
        .VD11 = Record.VD11
        .VD12 = Record.VD12
        .VD13 = Record.VD13
        .VD14 = Record.VD14
        .VD15 = Record.VD15
        .VD16 = Record.VD16
        .VD17 = Record.VD17
        .VD18 = Record.VD18
        .VD19 = Record.VD19
        .VD20 = Record.VD20
        .VD21 = Record.VD21
        .VD22 = Record.VD22
        .VD23 = Record.VD23
        .VD24 = Record.VD24
        .VD25 = Record.VD25
        .VD26 = Record.VD26
        .VD27 = Record.VD27
        .VD28 = Record.VD28
        .VD29 = Record.VD29
        .VD30 = Record.VD30
        .VD31 = Record.VD31
        .PD25 = Record.PD25
        .PD18 = Record.PD18
        .SAStatusID = Record.SAStatusID
        .PD07 = Record.PD07
        .PD08 = Record.PD08
        .PD06 = Record.PD06
        .PD29 = Record.PD29
        .PD05 = Record.PD05
        .PD19 = Record.PD19
        .PD30 = Record.PD30
        .PD11 = Record.PD11
        .PD03 = Record.PD03
        .PD20 = Record.PD20
        .PD24 = Record.PD24
        .PD27 = Record.PD27
        .SN09 = Record.SN09
        .SN08 = Record.SN08
        .SN07 = Record.SN07
        .PD17 = Record.PD17
        .PostedBy = Record.PostedBy
        .PD12 = Record.PD12
        .PD13 = Record.PD13
        .PostingRemarks = Record.PostingRemarks
        .ApprovedBy = Record.ApprovedBy
        .PD09 = Record.PD09
        .PD04 = Record.PD04
        .SN05 = Record.SN05
        .PD15 = Record.PD15
        .PD16 = Record.PD16
        .PD14 = Record.PD14
        .SN04 = Record.SN04
        .ApprovedOn = Record.ApprovedOn
        .PD02 = Record.PD02
        .PostedOn = Record.PostedOn
        .PD28 = Record.PD28
        .AD22 = Record.AD22
        .AD21 = Record.AD21
        .AD24 = Record.AD24
        .AD23 = Record.AD23
        .AD18 = Record.AD18
        .AD17 = Record.AD17
        .AD20 = Record.AD20
        .AD19 = Record.AD19
        .AD30 = Record.AD30
        .AD29 = Record.AD29
        .ApproverRemarks = Record.ApproverRemarks
        .AD31 = Record.AD31
        .AD26 = Record.AD26
        .AD25 = Record.AD25
        .AD28 = Record.AD28
        .AD27 = Record.AD27
        .AD16 = Record.AD16
        .AD05 = Record.AD05
        .AD04 = Record.AD04
        .AD07 = Record.AD07
        .AD06 = Record.AD06
        .AD01 = Record.AD01
        .ATNStatusID = Record.ATNStatusID
        .AD03 = Record.AD03
        .AD02 = Record.AD02
        .AD13 = Record.AD13
        .AD12 = Record.AD12
        .AD15 = Record.AD15
        .AD14 = Record.AD14
        .AD09 = Record.AD09
        .AD08 = Record.AD08
        .AD11 = Record.AD11
        .AD10 = Record.AD10
        .SN22 = Record.SN22
        .SN30 = Record.SN30
        .SN20 = Record.SN20
        .SN23 = Record.SN23
        .SN11 = Record.SN11
        .SN14 = Record.SN14
        .SN13 = Record.SN13
        .SN12 = Record.SN12
        .SN06 = Record.SN06
        .SN10 = Record.SN10
        .SN31 = Record.SN31
        .SN25 = Record.SN25
        .SN18 = Record.SN18
        .SN24 = Record.SN24
        .PD31 = Record.PD31
        .SN21 = Record.SN21
        .SN16 = Record.SN16
        .SN03 = Record.SN03
        .SN27 = Record.SN27
        .SN28 = Record.SN28
        .PD10 = Record.PD10
        .SN19 = Record.SN19
        .SN02 = Record.SN02
        .SN17 = Record.SN17
        .SN15 = Record.SN15
        .SN26 = Record.SN26
        .PD22 = Record.PD22
        .PD21 = Record.PD21
        .SN29 = Record.SN29
        .PD23 = Record.PD23
        .SN01 = Record.SN01
        .PD26 = Record.PD26
        .PD01 = Record.PD01
      End With
      Return SIS.ATN.atnSiteAttendApproval.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function atnSiteAttendApprovalUpdate(ByVal Record As SIS.ATN.atnSiteAttendApproval) As SIS.ATN.atnSiteAttendApproval
      Dim _Rec As SIS.ATN.atnSiteAttendApproval = SIS.ATN.atnSiteAttendApproval.atnSiteAttendApprovalGetByID(Record.FinYear, Record.MonthID, Record.CardNo)
      With _Rec
        .VD01 = Record.VD01
        .VD02 = Record.VD02
        .VD03 = Record.VD03
        .VD04 = Record.VD04
        .VD05 = Record.VD05
        .VD06 = Record.VD06
        .VD07 = Record.VD07
        .VD08 = Record.VD08
        .VD09 = Record.VD09
        .VD10 = Record.VD10
        .VD11 = Record.VD11
        .VD12 = Record.VD12
        .VD13 = Record.VD13
        .VD14 = Record.VD14
        .VD15 = Record.VD15
        .VD16 = Record.VD16
        .VD17 = Record.VD17
        .VD18 = Record.VD18
        .VD19 = Record.VD19
        .VD20 = Record.VD20
        .VD21 = Record.VD21
        .VD22 = Record.VD22
        .VD23 = Record.VD23
        .VD24 = Record.VD24
        .VD25 = Record.VD25
        .VD26 = Record.VD26
        .VD27 = Record.VD27
        .VD28 = Record.VD28
        .VD29 = Record.VD29
        .VD30 = Record.VD30
        .VD31 = Record.VD31
        .PD25 = Record.PD25
        .PD18 = Record.PD18
        .SAStatusID = Record.SAStatusID
        .PD07 = Record.PD07
        .PD08 = Record.PD08
        .PD06 = Record.PD06
        .PD29 = Record.PD29
        .PD05 = Record.PD05
        .PD19 = Record.PD19
        .PD30 = Record.PD30
        .PD11 = Record.PD11
        .PD03 = Record.PD03
        .PD20 = Record.PD20
        .PD24 = Record.PD24
        .PD27 = Record.PD27
        .SN09 = Record.SN09
        .SN08 = Record.SN08
        .SN07 = Record.SN07
        .PD17 = Record.PD17
        .PostedBy = Record.PostedBy
        .PD12 = Record.PD12
        .PD13 = Record.PD13
        .PostingRemarks = Record.PostingRemarks
        .ApprovedBy = Record.ApprovedBy
        .PD09 = Record.PD09
        .PD04 = Record.PD04
        .SN05 = Record.SN05
        .PD15 = Record.PD15
        .PD16 = Record.PD16
        .PD14 = Record.PD14
        .SN04 = Record.SN04
        .ApprovedOn = Record.ApprovedOn
        .PD02 = Record.PD02
        .PostedOn = Record.PostedOn
        .PD28 = Record.PD28
        .AD22 = Record.AD22
        .AD21 = Record.AD21
        .AD24 = Record.AD24
        .AD23 = Record.AD23
        .AD18 = Record.AD18
        .AD17 = Record.AD17
        .AD20 = Record.AD20
        .AD19 = Record.AD19
        .AD30 = Record.AD30
        .AD29 = Record.AD29
        .ApproverRemarks = Record.ApproverRemarks
        .AD31 = Record.AD31
        .AD26 = Record.AD26
        .AD25 = Record.AD25
        .AD28 = Record.AD28
        .AD27 = Record.AD27
        .AD16 = Record.AD16
        .AD05 = Record.AD05
        .AD04 = Record.AD04
        .AD07 = Record.AD07
        .AD06 = Record.AD06
        .AD01 = Record.AD01
        .ATNStatusID = Record.ATNStatusID
        .AD03 = Record.AD03
        .AD02 = Record.AD02
        .AD13 = Record.AD13
        .AD12 = Record.AD12
        .AD15 = Record.AD15
        .AD14 = Record.AD14
        .AD09 = Record.AD09
        .AD08 = Record.AD08
        .AD11 = Record.AD11
        .AD10 = Record.AD10
        .SN22 = Record.SN22
        .SN30 = Record.SN30
        .SN20 = Record.SN20
        .SN23 = Record.SN23
        .SN11 = Record.SN11
        .SN14 = Record.SN14
        .SN13 = Record.SN13
        .SN12 = Record.SN12
        .SN06 = Record.SN06
        .SN10 = Record.SN10
        .SN31 = Record.SN31
        .SN25 = Record.SN25
        .SN18 = Record.SN18
        .SN24 = Record.SN24
        .PD31 = Record.PD31
        .SN21 = Record.SN21
        .SN16 = Record.SN16
        .SN03 = Record.SN03
        .SN27 = Record.SN27
        .SN28 = Record.SN28
        .PD10 = Record.PD10
        .SN19 = Record.SN19
        .SN02 = Record.SN02
        .SN17 = Record.SN17
        .SN15 = Record.SN15
        .SN26 = Record.SN26
        .PD22 = Record.PD22
        .PD21 = Record.PD21
        .SN29 = Record.SN29
        .PD23 = Record.PD23
        .SN01 = Record.SN01
        .PD26 = Record.PD26
        .PD01 = Record.PD01
      End With
      Return SIS.ATN.atnSiteAttendApproval.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
