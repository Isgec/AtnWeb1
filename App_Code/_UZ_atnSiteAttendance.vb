Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnSiteAttendance
    Public ReadOnly Property IfReturned As String
      Get
        Dim mRet As String = ""
        If ATNStatusID = atnAplStates.SubmittedToHO Then
          If PostedBy <> "" Then
            mRet = PostingRemarks
          ElseIf ApprovedBy <> "" Then
            mRet = ApproverRemarks
          End If
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ClientLink As String
      Get
        Return "return lc_updatn.updatnShow('" & PrimaryKey & "',this);"
      End Get
    End Property
    Public Function GetColor(ByVal str As String) As Drawing.Color
      Return SIS.ATN.atnSABySIDays.GetColor(str)
    End Function


    Private Function GetAtnStatus(ByVal atn As String) As String
      If atn = "" Then Return "--" Else Return atn
    End Function
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case ATNStatusID
            Case atnAplStates.UnderApproval, atnAplStates.UnderPosting
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property

    Public Shared Function RejectWF(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal VerifierRemarks As String) As SIS.ATN.atnSiteAttendance
      Dim Results As SIS.ATN.atnSiteAttendance = atnSiteAttendanceGetByID(FinYear, MonthID, CardNo)
      'Return By Verifier to Site Incharge is NOT implemented
      'Correction will be done verifier with offline co-ordination with site incharge
      'Results = SIS.ATN.atnSiteAttendance.UpdateData(Results)
      Return Results
    End Function

    Public Shared Function InitiateWF(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal VerifierRemarks As String) As SIS.ATN.atnSiteAttendance
      Dim Results As SIS.ATN.atnSiteAttendance = atnSiteAttendanceGetByID(FinYear, MonthID, CardNo)
      For I As Integer = 1 To 31
        Dim Vprop As String = "VD" & I.ToString.PadLeft(2, "0")
        Dim Aprop As String = "AD" & I.ToString.PadLeft(2, "0")
        Dim Pprop As String = "PD" & I.ToString.PadLeft(2, "0")
        CallByName(Results, Aprop, CallType.Let, CallByName(Results, Vprop, CallType.Get))
        CallByName(Results, Pprop, CallType.Let, CallByName(Results, Vprop, CallType.Get))
      Next
      With Results
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .VerifiedOn = Now
        .ATNStatusID = atnAplStates.UnderApproval
        .VerifierRemarks = VerifierRemarks
      End With
      Results = SIS.ATN.atnSiteAttendance.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_atnSiteAttendanceSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String) As List(Of SIS.ATN.atnSiteAttendance)
      Dim Results As List(Of SIS.ATN.atnSiteAttendance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "MonthID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatn_LG_SiteAttendanceSelectListSearch"
            Cmd.CommandText = "spatnSiteAttendanceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatn_LG_SiteAttendanceSelectListFilteres"
            Cmd.CommandText = "spatnSiteAttendanceSelectListFilteres"
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
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnSiteAttendance)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSiteAttendance(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_atnSiteAttendanceInsert(ByVal Record As SIS.ATN.atnSiteAttendance) As SIS.ATN.atnSiteAttendance
      Dim _Result As SIS.ATN.atnSiteAttendance = atnSiteAttendanceInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_atnSiteAttendanceUpdate(ByVal Record As SIS.ATN.atnSiteAttendance) As SIS.ATN.atnSiteAttendance
      Dim _Result As SIS.ATN.atnSiteAttendance = atnSiteAttendanceUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_atnSiteAttendanceDelete(ByVal Record As SIS.ATN.atnSiteAttendance) As Integer
      Dim _Result As Integer = atnSiteAttendanceDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_FinYear"), TextBox).Text = ""
          CType(.FindControl("F_FinYear_Display"), Label).Text = ""
          CType(.FindControl("F_MonthID"), Object).SelectedValue = ""
          CType(.FindControl("F_CardNo"), TextBox).Text = ""
          CType(.FindControl("F_CardNo_Display"), Label).Text = ""
          CType(.FindControl("F_VD01"), TextBox).Text = ""
          CType(.FindControl("F_VD02"), TextBox).Text = ""
          CType(.FindControl("F_VD03"), TextBox).Text = ""
          CType(.FindControl("F_VD04"), TextBox).Text = ""
          CType(.FindControl("F_VD05"), TextBox).Text = ""
          CType(.FindControl("F_VD06"), TextBox).Text = ""
          CType(.FindControl("F_VD07"), TextBox).Text = ""
          CType(.FindControl("F_VD08"), TextBox).Text = ""
          CType(.FindControl("F_VD09"), TextBox).Text = ""
          CType(.FindControl("F_VD10"), TextBox).Text = ""
          CType(.FindControl("F_VD11"), TextBox).Text = ""
          CType(.FindControl("F_VD12"), TextBox).Text = ""
          CType(.FindControl("F_VD13"), TextBox).Text = ""
          CType(.FindControl("F_VD14"), TextBox).Text = ""
          CType(.FindControl("F_VD15"), TextBox).Text = ""
          CType(.FindControl("F_VD16"), TextBox).Text = ""
          CType(.FindControl("F_VD17"), TextBox).Text = ""
          CType(.FindControl("F_VD18"), TextBox).Text = ""
          CType(.FindControl("F_VD19"), TextBox).Text = ""
          CType(.FindControl("F_VD20"), TextBox).Text = ""
          CType(.FindControl("F_VD21"), TextBox).Text = ""
          CType(.FindControl("F_VD22"), TextBox).Text = ""
          CType(.FindControl("F_VD23"), TextBox).Text = ""
          CType(.FindControl("F_VD24"), TextBox).Text = ""
          CType(.FindControl("F_VD25"), TextBox).Text = ""
          CType(.FindControl("F_VD26"), TextBox).Text = ""
          CType(.FindControl("F_VD27"), TextBox).Text = ""
          CType(.FindControl("F_VD28"), TextBox).Text = ""
          CType(.FindControl("F_VD29"), TextBox).Text = ""
          CType(.FindControl("F_VD30"), TextBox).Text = ""
          CType(.FindControl("F_VD31"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function UZ_atnSABySIDaysSubmittedData(ByVal MonthID As Integer, ByVal CardNo As String) As List(Of SIS.ATN.atnSABySIDays)
      Dim Results As List(Of SIS.ATN.atnSABySIDays) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_atnSABySIDaysSubmittedData"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID", SqlDbType.Int, -1, MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
          Results = New List(Of SIS.ATN.atnSABySIDays)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSABySIDays(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

#Region " Verifier Days "

    Public ReadOnly Property vForeColor01() As Drawing.Color
      Get
        Return GetColor(VD01)
      End Get
    End Property
    Public ReadOnly Property vForeColor02() As Drawing.Color
      Get
        Return GetColor(VD02)
      End Get
    End Property
    Public ReadOnly Property vForeColor03() As Drawing.Color
      Get
        Return GetColor(VD03)
      End Get
    End Property
    Public ReadOnly Property vForeColor04() As Drawing.Color
      Get
        Return GetColor(VD04)
      End Get
    End Property
    Public ReadOnly Property vForeColor05() As Drawing.Color
      Get
        Return GetColor(VD05)
      End Get
    End Property
    Public ReadOnly Property vForeColor06() As Drawing.Color
      Get
        Return GetColor(VD06)
      End Get
    End Property
    Public ReadOnly Property vForeColor07() As Drawing.Color
      Get
        Return GetColor(VD07)
      End Get
    End Property
    Public ReadOnly Property vForeColor08() As Drawing.Color
      Get
        Return GetColor(VD08)
      End Get
    End Property
    Public ReadOnly Property vForeColor09() As Drawing.Color
      Get
        Return GetColor(VD09)
      End Get
    End Property
    Public ReadOnly Property vForeColor10() As Drawing.Color
      Get
        Return GetColor(VD10)
      End Get
    End Property
    Public ReadOnly Property vForeColor11() As Drawing.Color
      Get
        Return GetColor(VD11)
      End Get
    End Property
    Public ReadOnly Property vForeColor12() As Drawing.Color
      Get
        Return GetColor(VD12)
      End Get
    End Property
    Public ReadOnly Property vForeColor13() As Drawing.Color
      Get
        Return GetColor(VD13)
      End Get
    End Property
    Public ReadOnly Property vForeColor14() As Drawing.Color
      Get
        Return GetColor(VD14)
      End Get
    End Property
    Public ReadOnly Property vForeColor15() As Drawing.Color
      Get
        Return GetColor(VD15)
      End Get
    End Property
    Public ReadOnly Property vForeColor16() As Drawing.Color
      Get
        Return GetColor(VD16)
      End Get
    End Property
    Public ReadOnly Property vForeColor17() As Drawing.Color
      Get
        Return GetColor(VD17)
      End Get
    End Property
    Public ReadOnly Property vForeColor18() As Drawing.Color
      Get
        Return GetColor(VD18)
      End Get
    End Property
    Public ReadOnly Property vForeColor19() As Drawing.Color
      Get
        Return GetColor(VD19)
      End Get
    End Property
    Public ReadOnly Property vForeColor20() As Drawing.Color
      Get
        Return GetColor(VD20)
      End Get
    End Property
    Public ReadOnly Property vForeColor21() As Drawing.Color
      Get
        Return GetColor(VD21)
      End Get
    End Property
    Public ReadOnly Property vForeColor22() As Drawing.Color
      Get
        Return GetColor(VD22)
      End Get
    End Property
    Public ReadOnly Property vForeColor23() As Drawing.Color
      Get
        Return GetColor(VD23)
      End Get
    End Property
    Public ReadOnly Property vForeColor24() As Drawing.Color
      Get
        Return GetColor(VD24)
      End Get
    End Property
    Public ReadOnly Property vForeColor25() As Drawing.Color
      Get
        Return GetColor(VD25)
      End Get
    End Property
    Public ReadOnly Property vForeColor26() As Drawing.Color
      Get
        Return GetColor(VD26)
      End Get
    End Property
    Public ReadOnly Property vForeColor27() As Drawing.Color
      Get
        Return GetColor(VD27)
      End Get
    End Property
    Public ReadOnly Property vForeColor28() As Drawing.Color
      Get
        Return GetColor(VD28)
      End Get
    End Property
    Public ReadOnly Property vForeColor29() As Drawing.Color
      Get
        Return GetColor(VD29)
      End Get
    End Property
    Public ReadOnly Property vForeColor30() As Drawing.Color
      Get
        Return GetColor(VD30)
      End Get
    End Property
    Public ReadOnly Property vForeColor31() As Drawing.Color
      Get
        Return GetColor(VD31)
      End Get
    End Property
    Public ReadOnly Property getVD01() As String
      Get
        Return IIf(VD01 = "", "--", VD01)
      End Get
    End Property
    Public ReadOnly Property getVD02() As String
      Get
        Return IIf(VD02 = "", "--", VD02)
      End Get
    End Property
    Public ReadOnly Property getVD03() As String
      Get
        Return IIf(VD03 = "", "--", VD03)
      End Get
    End Property
    Public ReadOnly Property getVD04() As String
      Get
        Return IIf(VD04 = "", "--", VD04)
      End Get
    End Property
    Public ReadOnly Property getVD05() As String
      Get
        Return IIf(VD05 = "", "--", VD05)
      End Get
    End Property
    Public ReadOnly Property getVD06() As String
      Get
        Return IIf(VD06 = "", "--", VD06)
      End Get
    End Property
    Public ReadOnly Property getVD07() As String
      Get
        Return IIf(VD07 = "", "--", VD07)
      End Get
    End Property
    Public ReadOnly Property getVD08() As String
      Get
        Return IIf(VD08 = "", "--", VD08)
      End Get
    End Property
    Public ReadOnly Property getVD09() As String
      Get
        Return IIf(VD09 = "", "--", VD09)
      End Get
    End Property
    Public ReadOnly Property getVD10() As String
      Get
        Return IIf(VD10 = "", "--", VD10)
      End Get
    End Property
    Public ReadOnly Property getVD11() As String
      Get
        Return IIf(VD11 = "", "--", VD11)
      End Get
    End Property
    Public ReadOnly Property getVD12() As String
      Get
        Return IIf(VD12 = "", "--", VD12)
      End Get
    End Property
    Public ReadOnly Property getVD13() As String
      Get
        Return IIf(VD13 = "", "--", VD13)
      End Get
    End Property
    Public ReadOnly Property getVD14() As String
      Get
        Return IIf(VD14 = "", "--", VD14)
      End Get
    End Property
    Public ReadOnly Property getVD15() As String
      Get
        Return IIf(VD15 = "", "--", VD15)
      End Get
    End Property
    Public ReadOnly Property getVD16() As String
      Get
        Return IIf(VD16 = "", "--", VD16)
      End Get
    End Property
    Public ReadOnly Property getVD17() As String
      Get
        Return IIf(VD17 = "", "--", VD17)
      End Get
    End Property
    Public ReadOnly Property getVD18() As String
      Get
        Return IIf(VD18 = "", "--", VD18)
      End Get
    End Property
    Public ReadOnly Property getVD19() As String
      Get
        Return IIf(VD19 = "", "--", VD19)
      End Get
    End Property
    Public ReadOnly Property getVD20() As String
      Get
        Return IIf(VD20 = "", "--", VD20)
      End Get
    End Property
    Public ReadOnly Property getVD21() As String
      Get
        Return IIf(VD21 = "", "--", VD21)
      End Get
    End Property
    Public ReadOnly Property getVD22() As String
      Get
        Return IIf(VD22 = "", "--", VD22)
      End Get
    End Property
    Public ReadOnly Property getVD23() As String
      Get
        Return IIf(VD23 = "", "--", VD23)
      End Get
    End Property
    Public ReadOnly Property getVD24() As String
      Get
        Return IIf(VD24 = "", "--", VD24)
      End Get
    End Property
    Public ReadOnly Property getVD25() As String
      Get
        Return IIf(VD25 = "", "--", VD25)
      End Get
    End Property
    Public ReadOnly Property getVD26() As String
      Get
        Return IIf(VD26 = "", "--", VD26)
      End Get
    End Property
    Public ReadOnly Property getVD27() As String
      Get
        Return IIf(VD27 = "", "--", VD27)
      End Get
    End Property
    Public ReadOnly Property getVD28() As String
      Get
        Return IIf(VD28 = "", "--", VD28)
      End Get
    End Property
    Public ReadOnly Property getVD29() As String
      Get
        Return IIf(VD29 = "", "--", VD29)
      End Get
    End Property
    Public ReadOnly Property getVD30() As String
      Get
        Return IIf(VD30 = "", "--", VD30)
      End Get
    End Property
    Public ReadOnly Property getVD31() As String
      Get
        Return IIf(VD31 = "", "--", VD31)
      End Get
    End Property

#End Region

#Region " APPROVER USER DAYS "
    Public ReadOnly Property aForeColor01() As Drawing.Color
      Get
        Return GetColor(AD01)
      End Get
    End Property
    Public ReadOnly Property aForeColor02() As Drawing.Color
      Get
        Return GetColor(AD02)
      End Get
    End Property
    Public ReadOnly Property aForeColor03() As Drawing.Color
      Get
        Return GetColor(AD03)
      End Get
    End Property
    Public ReadOnly Property aForeColor04() As Drawing.Color
      Get
        Return GetColor(AD04)
      End Get
    End Property
    Public ReadOnly Property aForeColor05() As Drawing.Color
      Get
        Return GetColor(AD05)
      End Get
    End Property
    Public ReadOnly Property aForeColor06() As Drawing.Color
      Get
        Return GetColor(AD06)
      End Get
    End Property
    Public ReadOnly Property aForeColor07() As Drawing.Color
      Get
        Return GetColor(AD07)
      End Get
    End Property
    Public ReadOnly Property aForeColor08() As Drawing.Color
      Get
        Return GetColor(AD08)
      End Get
    End Property
    Public ReadOnly Property aForeColor09() As Drawing.Color
      Get
        Return GetColor(AD09)
      End Get
    End Property
    Public ReadOnly Property aForeColor10() As Drawing.Color
      Get
        Return GetColor(AD10)
      End Get
    End Property
    Public ReadOnly Property aForeColor11() As Drawing.Color
      Get
        Return GetColor(AD11)
      End Get
    End Property
    Public ReadOnly Property aForeColor12() As Drawing.Color
      Get
        Return GetColor(AD12)
      End Get
    End Property
    Public ReadOnly Property aForeColor13() As Drawing.Color
      Get
        Return GetColor(AD13)
      End Get
    End Property
    Public ReadOnly Property aForeColor14() As Drawing.Color
      Get
        Return GetColor(AD14)
      End Get
    End Property
    Public ReadOnly Property aForeColor15() As Drawing.Color
      Get
        Return GetColor(AD15)
      End Get
    End Property
    Public ReadOnly Property aForeColor16() As Drawing.Color
      Get
        Return GetColor(AD16)
      End Get
    End Property
    Public ReadOnly Property aForeColor17() As Drawing.Color
      Get
        Return GetColor(AD17)
      End Get
    End Property
    Public ReadOnly Property aForeColor18() As Drawing.Color
      Get
        Return GetColor(AD18)
      End Get
    End Property
    Public ReadOnly Property aForeColor19() As Drawing.Color
      Get
        Return GetColor(AD19)
      End Get
    End Property
    Public ReadOnly Property aForeColor20() As Drawing.Color
      Get
        Return GetColor(AD20)
      End Get
    End Property
    Public ReadOnly Property aForeColor21() As Drawing.Color
      Get
        Return GetColor(AD21)
      End Get
    End Property
    Public ReadOnly Property aForeColor22() As Drawing.Color
      Get
        Return GetColor(AD22)
      End Get
    End Property
    Public ReadOnly Property aForeColor23() As Drawing.Color
      Get
        Return GetColor(AD23)
      End Get
    End Property
    Public ReadOnly Property aForeColor24() As Drawing.Color
      Get
        Return GetColor(AD24)
      End Get
    End Property
    Public ReadOnly Property aForeColor25() As Drawing.Color
      Get
        Return GetColor(AD25)
      End Get
    End Property
    Public ReadOnly Property aForeColor26() As Drawing.Color
      Get
        Return GetColor(AD26)
      End Get
    End Property
    Public ReadOnly Property aForeColor27() As Drawing.Color
      Get
        Return GetColor(AD27)
      End Get
    End Property
    Public ReadOnly Property aForeColor28() As Drawing.Color
      Get
        Return GetColor(AD28)
      End Get
    End Property
    Public ReadOnly Property aForeColor29() As Drawing.Color
      Get
        Return GetColor(AD29)
      End Get
    End Property
    Public ReadOnly Property aForeColor30() As Drawing.Color
      Get
        Return GetColor(AD30)
      End Get
    End Property
    Public ReadOnly Property aForeColor31() As Drawing.Color
      Get
        Return GetColor(AD31)
      End Get
    End Property

    Public ReadOnly Property getAD01() As String
      Get
        Return IIf(AD01 = "", "--", AD01)
      End Get
    End Property
    Public ReadOnly Property getAD02() As String
      Get
        Return IIf(AD02 = "", "--", AD02)
      End Get
    End Property
    Public ReadOnly Property getAD03() As String
      Get
        Return IIf(AD03 = "", "--", AD03)
      End Get
    End Property
    Public ReadOnly Property getAD04() As String
      Get
        Return IIf(AD04 = "", "--", AD04)
      End Get
    End Property
    Public ReadOnly Property getAD05() As String
      Get
        Return IIf(AD05 = "", "--", AD05)
      End Get
    End Property
    Public ReadOnly Property getAD06() As String
      Get
        Return IIf(AD06 = "", "--", AD06)
      End Get
    End Property
    Public ReadOnly Property getAD07() As String
      Get
        Return IIf(AD07 = "", "--", AD07)
      End Get
    End Property
    Public ReadOnly Property getAD08() As String
      Get
        Return IIf(AD08 = "", "--", AD08)
      End Get
    End Property
    Public ReadOnly Property getAD09() As String
      Get
        Return IIf(AD09 = "", "--", AD09)
      End Get
    End Property
    Public ReadOnly Property getAD10() As String
      Get
        Return IIf(AD10 = "", "--", AD10)
      End Get
    End Property
    Public ReadOnly Property getAD11() As String
      Get
        Return IIf(AD11 = "", "--", AD11)
      End Get
    End Property
    Public ReadOnly Property getAD12() As String
      Get
        Return IIf(AD12 = "", "--", AD12)
      End Get
    End Property
    Public ReadOnly Property getAD13() As String
      Get
        Return IIf(AD13 = "", "--", AD13)
      End Get
    End Property
    Public ReadOnly Property getAD14() As String
      Get
        Return IIf(AD14 = "", "--", AD14)
      End Get
    End Property
    Public ReadOnly Property getAD15() As String
      Get
        Return IIf(AD15 = "", "--", AD15)
      End Get
    End Property
    Public ReadOnly Property getAD16() As String
      Get
        Return IIf(AD16 = "", "--", AD16)
      End Get
    End Property
    Public ReadOnly Property getAD17() As String
      Get
        Return IIf(AD17 = "", "--", AD17)
      End Get
    End Property
    Public ReadOnly Property getAD18() As String
      Get
        Return IIf(AD18 = "", "--", AD18)
      End Get
    End Property
    Public ReadOnly Property getAD19() As String
      Get
        Return IIf(AD19 = "", "--", AD19)
      End Get
    End Property
    Public ReadOnly Property getAD20() As String
      Get
        Return IIf(AD20 = "", "--", AD20)
      End Get
    End Property
    Public ReadOnly Property getAD21() As String
      Get
        Return IIf(AD21 = "", "--", AD21)
      End Get
    End Property
    Public ReadOnly Property getAD22() As String
      Get
        Return IIf(AD22 = "", "--", AD22)
      End Get
    End Property
    Public ReadOnly Property getAD23() As String
      Get
        Return IIf(AD23 = "", "--", AD23)
      End Get
    End Property
    Public ReadOnly Property getAD24() As String
      Get
        Return IIf(AD24 = "", "--", AD24)
      End Get
    End Property
    Public ReadOnly Property getAD25() As String
      Get
        Return IIf(AD25 = "", "--", AD25)
      End Get
    End Property
    Public ReadOnly Property getAD26() As String
      Get
        Return IIf(AD26 = "", "--", AD26)
      End Get
    End Property
    Public ReadOnly Property getAD27() As String
      Get
        Return IIf(AD27 = "", "--", AD27)
      End Get
    End Property
    Public ReadOnly Property getAD28() As String
      Get
        Return IIf(AD28 = "", "--", AD28)
      End Get
    End Property
    Public ReadOnly Property getAD29() As String
      Get
        Return IIf(AD29 = "", "--", AD29)
      End Get
    End Property
    Public ReadOnly Property getAD30() As String
      Get
        Return IIf(AD30 = "", "--", AD30)
      End Get
    End Property
    Public ReadOnly Property getAD31() As String
      Get
        Return IIf(AD31 = "", "--", AD31)
      End Get
    End Property

#End Region

#Region " POSTING USER DAYS "
    Public ReadOnly Property pForeColor01() As Drawing.Color
      Get
        Return GetColor(PD01)
      End Get
    End Property
    Public ReadOnly Property pForeColor02() As Drawing.Color
      Get
        Return GetColor(PD02)
      End Get
    End Property
    Public ReadOnly Property pForeColor03() As Drawing.Color
      Get
        Return GetColor(PD03)
      End Get
    End Property
    Public ReadOnly Property pForeColor04() As Drawing.Color
      Get
        Return GetColor(PD04)
      End Get
    End Property
    Public ReadOnly Property pForeColor05() As Drawing.Color
      Get
        Return GetColor(PD05)
      End Get
    End Property
    Public ReadOnly Property pForeColor06() As Drawing.Color
      Get
        Return GetColor(PD06)
      End Get
    End Property
    Public ReadOnly Property pForeColor07() As Drawing.Color
      Get
        Return GetColor(PD07)
      End Get
    End Property
    Public ReadOnly Property pForeColor08() As Drawing.Color
      Get
        Return GetColor(PD08)
      End Get
    End Property
    Public ReadOnly Property pForeColor09() As Drawing.Color
      Get
        Return GetColor(PD09)
      End Get
    End Property
    Public ReadOnly Property pForeColor10() As Drawing.Color
      Get
        Return GetColor(PD10)
      End Get
    End Property
    Public ReadOnly Property pForeColor11() As Drawing.Color
      Get
        Return GetColor(PD11)
      End Get
    End Property
    Public ReadOnly Property pForeColor12() As Drawing.Color
      Get
        Return GetColor(PD12)
      End Get
    End Property
    Public ReadOnly Property pForeColor13() As Drawing.Color
      Get
        Return GetColor(PD13)
      End Get
    End Property
    Public ReadOnly Property pForeColor14() As Drawing.Color
      Get
        Return GetColor(PD14)
      End Get
    End Property
    Public ReadOnly Property pForeColor15() As Drawing.Color
      Get
        Return GetColor(PD15)
      End Get
    End Property
    Public ReadOnly Property pForeColor16() As Drawing.Color
      Get
        Return GetColor(PD16)
      End Get
    End Property
    Public ReadOnly Property pForeColor17() As Drawing.Color
      Get
        Return GetColor(PD17)
      End Get
    End Property
    Public ReadOnly Property pForeColor18() As Drawing.Color
      Get
        Return GetColor(PD18)
      End Get
    End Property
    Public ReadOnly Property pForeColor19() As Drawing.Color
      Get
        Return GetColor(PD19)
      End Get
    End Property
    Public ReadOnly Property pForeColor20() As Drawing.Color
      Get
        Return GetColor(PD20)
      End Get
    End Property
    Public ReadOnly Property pForeColor21() As Drawing.Color
      Get
        Return GetColor(PD21)
      End Get
    End Property
    Public ReadOnly Property pForeColor22() As Drawing.Color
      Get
        Return GetColor(PD22)
      End Get
    End Property
    Public ReadOnly Property pForeColor23() As Drawing.Color
      Get
        Return GetColor(PD23)
      End Get
    End Property
    Public ReadOnly Property pForeColor24() As Drawing.Color
      Get
        Return GetColor(PD24)
      End Get
    End Property
    Public ReadOnly Property pForeColor25() As Drawing.Color
      Get
        Return GetColor(PD25)
      End Get
    End Property
    Public ReadOnly Property pForeColor26() As Drawing.Color
      Get
        Return GetColor(PD26)
      End Get
    End Property
    Public ReadOnly Property pForeColor27() As Drawing.Color
      Get
        Return GetColor(PD27)
      End Get
    End Property
    Public ReadOnly Property pForeColor28() As Drawing.Color
      Get
        Return GetColor(PD28)
      End Get
    End Property
    Public ReadOnly Property pForeColor29() As Drawing.Color
      Get
        Return GetColor(PD29)
      End Get
    End Property
    Public ReadOnly Property pForeColor30() As Drawing.Color
      Get
        Return GetColor(PD30)
      End Get
    End Property
    Public ReadOnly Property pForeColor31() As Drawing.Color
      Get
        Return GetColor(PD31)
      End Get
    End Property

    Public ReadOnly Property getPD01() As String
      Get
        Return IIf(PD01 = "", "--", PD01)
      End Get
    End Property
    Public ReadOnly Property getPD02() As String
      Get
        Return IIf(PD02 = "", "--", PD02)
      End Get
    End Property
    Public ReadOnly Property getPD03() As String
      Get
        Return IIf(PD03 = "", "--", PD03)
      End Get
    End Property
    Public ReadOnly Property getPD04() As String
      Get
        Return IIf(PD04 = "", "--", PD04)
      End Get
    End Property
    Public ReadOnly Property getPD05() As String
      Get
        Return IIf(PD05 = "", "--", PD05)
      End Get
    End Property
    Public ReadOnly Property getPD06() As String
      Get
        Return IIf(PD06 = "", "--", PD06)
      End Get
    End Property
    Public ReadOnly Property getPD07() As String
      Get
        Return IIf(PD07 = "", "--", PD07)
      End Get
    End Property
    Public ReadOnly Property getPD08() As String
      Get
        Return IIf(PD08 = "", "--", PD08)
      End Get
    End Property
    Public ReadOnly Property getPD09() As String
      Get
        Return IIf(PD09 = "", "--", PD09)
      End Get
    End Property
    Public ReadOnly Property getPD10() As String
      Get
        Return IIf(PD10 = "", "--", PD10)
      End Get
    End Property
    Public ReadOnly Property getPD11() As String
      Get
        Return IIf(PD11 = "", "--", PD11)
      End Get
    End Property
    Public ReadOnly Property getPD12() As String
      Get
        Return IIf(PD12 = "", "--", PD12)
      End Get
    End Property
    Public ReadOnly Property getPD13() As String
      Get
        Return IIf(PD13 = "", "--", PD13)
      End Get
    End Property
    Public ReadOnly Property getPD14() As String
      Get
        Return IIf(PD14 = "", "--", PD14)
      End Get
    End Property
    Public ReadOnly Property getPD15() As String
      Get
        Return IIf(PD15 = "", "--", PD15)
      End Get
    End Property
    Public ReadOnly Property getPD16() As String
      Get
        Return IIf(PD16 = "", "--", PD16)
      End Get
    End Property
    Public ReadOnly Property getPD17() As String
      Get
        Return IIf(PD17 = "", "--", PD17)
      End Get
    End Property
    Public ReadOnly Property getPD18() As String
      Get
        Return IIf(PD18 = "", "--", PD18)
      End Get
    End Property
    Public ReadOnly Property getPD19() As String
      Get
        Return IIf(PD19 = "", "--", PD19)
      End Get
    End Property
    Public ReadOnly Property getPD20() As String
      Get
        Return IIf(PD20 = "", "--", PD20)
      End Get
    End Property
    Public ReadOnly Property getPD21() As String
      Get
        Return IIf(PD21 = "", "--", PD21)
      End Get
    End Property
    Public ReadOnly Property getPD22() As String
      Get
        Return IIf(PD22 = "", "--", PD22)
      End Get
    End Property
    Public ReadOnly Property getPD23() As String
      Get
        Return IIf(PD23 = "", "--", PD23)
      End Get
    End Property
    Public ReadOnly Property getPD24() As String
      Get
        Return IIf(PD24 = "", "--", PD24)
      End Get
    End Property
    Public ReadOnly Property getPD25() As String
      Get
        Return IIf(PD25 = "", "--", PD25)
      End Get
    End Property
    Public ReadOnly Property getPD26() As String
      Get
        Return IIf(PD26 = "", "--", PD26)
      End Get
    End Property
    Public ReadOnly Property getPD27() As String
      Get
        Return IIf(PD27 = "", "--", PD27)
      End Get
    End Property
    Public ReadOnly Property getPD28() As String
      Get
        Return IIf(PD28 = "", "--", PD28)
      End Get
    End Property
    Public ReadOnly Property getPD29() As String
      Get
        Return IIf(PD29 = "", "--", PD29)
      End Get
    End Property
    Public ReadOnly Property getPD30() As String
      Get
        Return IIf(PD30 = "", "--", PD30)
      End Get
    End Property
    Public ReadOnly Property getPD31() As String
      Get
        Return IIf(PD31 = "", "--", PD31)
      End Get
    End Property

#End Region

  End Class
End Namespace
