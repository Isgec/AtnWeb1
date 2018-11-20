Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnSABySIDays
    Public Shared Function GetColor(ByVal str As String) As Drawing.Color
      Dim mRet As Drawing.Color = Drawing.Color.Black
      Select Case str
        Case ""
          mRet = Drawing.Color.Black
        Case "PR", "NH", "OD"
          mRet = Drawing.Color.Green
        Case "AD"
          mRet = Drawing.Color.Red
        Case "CL", "SL", "PL"
          mRet = Drawing.Color.DarkCyan
        Case "HO", "TR", "ST"
          mRet = Drawing.Color.DarkGoldenrod
      End Select
      Return mRet
    End Function
    Public ReadOnly Property GetDownloadLinkSASR() As String
      Get
        Return FK_ATN_SABySIDays_SerialNo.GetDownloadLinkSASR
        'Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/ATN_Main/App_Downloads/filedownload.aspx?sasr=" & PrimaryKey & "', 'win" & _SerialNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property ClientLink As String
      Get
        If Not Editable Then
          Return "return na();"
        Else
          Return "return lc_updSAatn.updatnShow('" & PrimaryKey & "',this);"
        End If
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      Dim mRet As Boolean = False
      mRet = FK_ATN_SABySIDays_SerialNo.GetEditable
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      mRet = GetEditable()
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = GetEditable()
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
    Public Shared Function DeleteWF(ByVal SerialNo As Int32, ByVal CardNo As String) As SIS.ATN.atnSABySIDays
      Dim Results As SIS.ATN.atnSABySIDays = atnSABySIDaysGetByID(SerialNo, CardNo)
      UZ_atnSABySIDaysDelete(Results)
      Return Results
    End Function
    Public Shared Function UZ_atnSABySIDaysInsert(ByVal Record As SIS.ATN.atnSABySIDays) As SIS.ATN.atnSABySIDays
      Dim _Result As SIS.ATN.atnSABySIDays = atnSABySIDaysInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_atnSABySIDaysUpdate(ByVal Record As SIS.ATN.atnSABySIDays) As SIS.ATN.atnSABySIDays
      Dim _Result As SIS.ATN.atnSABySIDays = atnSABySIDaysUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_atnSABySIDaysDelete(ByVal Record As SIS.ATN.atnSABySIDays) As Integer
      If Record.FK_ATN_SABySIDays_SerialNo.SAStatusID = atnAplStates.SubmittedToHO Then
        Record.D01 = ""
        Record.D02 = ""
        Record.D03 = ""
        Record.D04 = ""
        Record.D05 = ""
        Record.D06 = ""
        Record.D07 = ""
        Record.D08 = ""
        Record.D09 = ""
        Record.D10 = ""
        Record.D11 = ""
        Record.D12 = ""
        Record.D13 = ""
        Record.D14 = ""
        Record.D15 = ""
        Record.D16 = ""
        Record.D17 = ""
        Record.D18 = ""
        Record.D19 = ""
        Record.D20 = ""
        Record.D21 = ""
        Record.D22 = ""
        Record.D23 = ""
        Record.D24 = ""
        Record.D25 = ""
        Record.D26 = ""
        Record.D27 = ""
        Record.D28 = ""
        Record.D29 = ""
        Record.D30 = ""
        Record.D31 = ""
        SIS.ATN.atnSABySI.CreateOrUpdateConsolidate(Record, False)
      End If
      Dim _Result As Integer = atnSABySIDaysDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_CardNo"), TextBox).Text = ""
          CType(.FindControl("F_CardNo_Display"), Label).Text = ""
          CType(.FindControl("F_D01"), TextBox).Text = ""
          CType(.FindControl("F_D02"), TextBox).Text = ""
          CType(.FindControl("F_D03"), TextBox).Text = ""
          CType(.FindControl("F_D04"), TextBox).Text = ""
          CType(.FindControl("F_D05"), TextBox).Text = ""
          CType(.FindControl("F_D06"), TextBox).Text = ""
          CType(.FindControl("F_D07"), TextBox).Text = ""
          CType(.FindControl("F_D08"), TextBox).Text = ""
          CType(.FindControl("F_D09"), TextBox).Text = ""
          CType(.FindControl("F_D10"), TextBox).Text = ""
          CType(.FindControl("F_D11"), TextBox).Text = ""
          CType(.FindControl("F_D12"), TextBox).Text = ""
          CType(.FindControl("F_D13"), TextBox).Text = ""
          CType(.FindControl("F_D14"), TextBox).Text = ""
          CType(.FindControl("F_D15"), TextBox).Text = ""
          CType(.FindControl("F_D16"), TextBox).Text = ""
          CType(.FindControl("F_D17"), TextBox).Text = ""
          CType(.FindControl("F_D18"), TextBox).Text = ""
          CType(.FindControl("F_D19"), TextBox).Text = ""
          CType(.FindControl("F_D20"), TextBox).Text = ""
          CType(.FindControl("F_D21"), TextBox).Text = ""
          CType(.FindControl("F_D22"), TextBox).Text = ""
          CType(.FindControl("F_D23"), TextBox).Text = ""
          CType(.FindControl("F_D24"), TextBox).Text = ""
          CType(.FindControl("F_D25"), TextBox).Text = ""
          CType(.FindControl("F_D26"), TextBox).Text = ""
          CType(.FindControl("F_D27"), TextBox).Text = ""
          CType(.FindControl("F_D28"), TextBox).Text = ""
          CType(.FindControl("F_D29"), TextBox).Text = ""
          CType(.FindControl("F_D30"), TextBox).Text = ""
          CType(.FindControl("F_D31"), TextBox).Text = ""
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function UZ_newHrmSiteEmployeesSelectList(ByVal SerialNo As String) As List(Of SIS.ATN.newHrmEmployees)
      Dim Results As List(Of SIS.ATN.newHrmEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If SerialNo = "" Then SerialNo = "0"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_newSiteHrmEmployeesSelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.newHrmEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.newHrmEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

#Region " SITE INCHARGE DAYS "
    Public ReadOnly Property ForeColor01() As Drawing.Color
      Get
        Return GetColor(D01)
      End Get
    End Property
    Public ReadOnly Property ForeColor02() As Drawing.Color
      Get
        Return GetColor(D02)
      End Get
    End Property
    Public ReadOnly Property ForeColor03() As Drawing.Color
      Get
        Return GetColor(D03)
      End Get
    End Property
    Public ReadOnly Property ForeColor04() As Drawing.Color
      Get
        Return GetColor(D04)
      End Get
    End Property
    Public ReadOnly Property ForeColor05() As Drawing.Color
      Get
        Return GetColor(D05)
      End Get
    End Property
    Public ReadOnly Property ForeColor06() As Drawing.Color
      Get
        Return GetColor(D06)
      End Get
    End Property
    Public ReadOnly Property ForeColor07() As Drawing.Color
      Get
        Return GetColor(D07)
      End Get
    End Property
    Public ReadOnly Property ForeColor08() As Drawing.Color
      Get
        Return GetColor(D08)
      End Get
    End Property
    Public ReadOnly Property ForeColor09() As Drawing.Color
      Get
        Return GetColor(D09)
      End Get
    End Property
    Public ReadOnly Property ForeColor10() As Drawing.Color
      Get
        Return GetColor(D10)
      End Get
    End Property
    Public ReadOnly Property ForeColor11() As Drawing.Color
      Get
        Return GetColor(D11)
      End Get
    End Property
    Public ReadOnly Property ForeColor12() As Drawing.Color
      Get
        Return GetColor(D12)
      End Get
    End Property
    Public ReadOnly Property ForeColor13() As Drawing.Color
      Get
        Return GetColor(D13)
      End Get
    End Property
    Public ReadOnly Property ForeColor14() As Drawing.Color
      Get
        Return GetColor(D14)
      End Get
    End Property
    Public ReadOnly Property ForeColor15() As Drawing.Color
      Get
        Return GetColor(D15)
      End Get
    End Property
    Public ReadOnly Property ForeColor16() As Drawing.Color
      Get
        Return GetColor(D16)
      End Get
    End Property
    Public ReadOnly Property ForeColor17() As Drawing.Color
      Get
        Return GetColor(D17)
      End Get
    End Property
    Public ReadOnly Property ForeColor18() As Drawing.Color
      Get
        Return GetColor(D18)
      End Get
    End Property
    Public ReadOnly Property ForeColor19() As Drawing.Color
      Get
        Return GetColor(D19)
      End Get
    End Property
    Public ReadOnly Property ForeColor20() As Drawing.Color
      Get
        Return GetColor(D20)
      End Get
    End Property
    Public ReadOnly Property ForeColor21() As Drawing.Color
      Get
        Return GetColor(D21)
      End Get
    End Property
    Public ReadOnly Property ForeColor22() As Drawing.Color
      Get
        Return GetColor(D22)
      End Get
    End Property
    Public ReadOnly Property ForeColor23() As Drawing.Color
      Get
        Return GetColor(D23)
      End Get
    End Property
    Public ReadOnly Property ForeColor24() As Drawing.Color
      Get
        Return GetColor(D24)
      End Get
    End Property
    Public ReadOnly Property ForeColor25() As Drawing.Color
      Get
        Return GetColor(D25)
      End Get
    End Property
    Public ReadOnly Property ForeColor26() As Drawing.Color
      Get
        Return GetColor(D26)
      End Get
    End Property
    Public ReadOnly Property ForeColor27() As Drawing.Color
      Get
        Return GetColor(D27)
      End Get
    End Property
    Public ReadOnly Property ForeColor28() As Drawing.Color
      Get
        Return GetColor(D28)
      End Get
    End Property
    Public ReadOnly Property ForeColor29() As Drawing.Color
      Get
        Return GetColor(D29)
      End Get
    End Property
    Public ReadOnly Property ForeColor30() As Drawing.Color
      Get
        Return GetColor(D30)
      End Get
    End Property
    Public ReadOnly Property ForeColor31() As Drawing.Color
      Get
        Return GetColor(D31)
      End Get
    End Property


    Public ReadOnly Property getD01() As String
      Get
        Return IIf(D01 = "", "--", D01)
      End Get
    End Property
    Public ReadOnly Property getD02() As String
      Get
        Return IIf(D02 = "", "--", D02)
      End Get
    End Property
    Public ReadOnly Property getD03() As String
      Get
        Return IIf(D03 = "", "--", D03)
      End Get
    End Property
    Public ReadOnly Property getD04() As String
      Get
        Return IIf(D04 = "", "--", D04)
      End Get
    End Property
    Public ReadOnly Property getD05() As String
      Get
        Return IIf(D05 = "", "--", D05)
      End Get
    End Property
    Public ReadOnly Property getD06() As String
      Get
        Return IIf(D06 = "", "--", D06)
      End Get
    End Property
    Public ReadOnly Property getD07() As String
      Get
        Return IIf(D07 = "", "--", D07)
      End Get
    End Property
    Public ReadOnly Property getD08() As String
      Get
        Return IIf(D08 = "", "--", D08)
      End Get
    End Property
    Public ReadOnly Property getD09() As String
      Get
        Return IIf(D09 = "", "--", D09)
      End Get
    End Property
    Public ReadOnly Property getD10() As String
      Get
        Return IIf(D10 = "", "--", D10)
      End Get
    End Property
    Public ReadOnly Property getD11() As String
      Get
        Return IIf(D11 = "", "--", D11)
      End Get
    End Property
    Public ReadOnly Property getD12() As String
      Get
        Return IIf(D12 = "", "--", D12)
      End Get
    End Property
    Public ReadOnly Property getD13() As String
      Get
        Return IIf(D13 = "", "--", D13)
      End Get
    End Property
    Public ReadOnly Property getD14() As String
      Get
        Return IIf(D14 = "", "--", D14)
      End Get
    End Property
    Public ReadOnly Property getD15() As String
      Get
        Return IIf(D15 = "", "--", D15)
      End Get
    End Property
    Public ReadOnly Property getD16() As String
      Get
        Return IIf(D16 = "", "--", D16)
      End Get
    End Property
    Public ReadOnly Property getD17() As String
      Get
        Return IIf(D17 = "", "--", D17)
      End Get
    End Property
    Public ReadOnly Property getD18() As String
      Get
        Return IIf(D18 = "", "--", D18)
      End Get
    End Property
    Public ReadOnly Property getD19() As String
      Get
        Return IIf(D19 = "", "--", D19)
      End Get
    End Property
    Public ReadOnly Property getD20() As String
      Get
        Return IIf(D20 = "", "--", D20)
      End Get
    End Property
    Public ReadOnly Property getD21() As String
      Get
        Return IIf(D21 = "", "--", D21)
      End Get
    End Property
    Public ReadOnly Property getD22() As String
      Get
        Return IIf(D22 = "", "--", D22)
      End Get
    End Property
    Public ReadOnly Property getD23() As String
      Get
        Return IIf(D23 = "", "--", D23)
      End Get
    End Property
    Public ReadOnly Property getD24() As String
      Get
        Return IIf(D24 = "", "--", D24)
      End Get
    End Property
    Public ReadOnly Property getD25() As String
      Get
        Return IIf(D25 = "", "--", D25)
      End Get
    End Property
    Public ReadOnly Property getD26() As String
      Get
        Return IIf(D26 = "", "--", D26)
      End Get
    End Property
    Public ReadOnly Property getD27() As String
      Get
        Return IIf(D27 = "", "--", D27)
      End Get
    End Property
    Public ReadOnly Property getD28() As String
      Get
        Return IIf(D28 = "", "--", D28)
      End Get
    End Property
    Public ReadOnly Property getD29() As String
      Get
        Return IIf(D29 = "", "--", D29)
      End Get
    End Property
    Public ReadOnly Property getD30() As String
      Get
        Return IIf(D30 = "", "--", D30)
      End Get
    End Property
    Public ReadOnly Property getD31() As String
      Get
        Return IIf(D31 = "", "--", D31)
      End Get
    End Property
#End Region

  End Class
End Namespace
