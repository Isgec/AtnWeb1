Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnSABySI
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/ATN_Main/App_Downloads/filedownload.aspx?sasi=" & PrimaryKey & "', 'win" & _SerialNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property GetDownloadLinkSASR() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/ATN_Main/App_Downloads/filedownload.aspx?sasr=" & PrimaryKey & "', 'win" & _SerialNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case SAStatusID
        Case atnAplStates.SubmittedToHO
          mRet = Drawing.Color.Green
        Case atnAplStates.Locked
          mRet = Drawing.Color.Goldenrod
      End Select
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
      If SAStatusID = atnAplStates.Free Then
        mRet = True
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      mRet = GetEditable()
      Return mRet
    End Function
    Public ReadOnly Property ChildAddable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
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
        Dim mRet As Boolean = False
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
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
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
    Public Shared Function DeleteWF(ByVal SerialNo As Int32) As SIS.ATN.atnSABySI
      Dim Results As SIS.ATN.atnSABySI = atnSABySIGetByID(SerialNo)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        mRet = GetEditable()
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
    Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.ATN.atnSABySI
      Dim Results As SIS.ATN.atnSABySI = atnSABySIGetByID(SerialNo)
      If Results.FileName = "" Then
        'Throw New Exception("Please attach Scanned copy of site attendance register.")
      End If
      With Results
        .VerifiedOn = Now
        .SAStatusID = atnAplStates.SubmittedToHO
      End With
      Results = SIS.ATN.atnSABySI.UpdateData(Results)
      '=========Update In Consolidated==============
      Dim tmpDs As List(Of SIS.ATN.atnSABySIDays) = SIS.ATN.atnSABySIDays.atnSABySIDaysSelectList(0, 999, "", False, "", SerialNo)
      For Each tmpD As SIS.ATN.atnSABySIDays In tmpDs
        For I As Integer = 1 To 31
          Try
            Dim xTmp As String = CallByName(tmpD, "D" & I.ToString.PadLeft(2, "0"), CallType.Get)
            Select Case xTmp
              Case "HO", "TR"
                xTmp = "OD"
                CallByName(tmpD, "D" & I.ToString.PadLeft(2, "0"), CallType.Let, xTmp)
            End Select
          Catch ex As Exception
          End Try
        Next
        CreateOrUpdateConsolidate(tmpD)
      Next
      '==========End Consolidated ==================
      Return Results
    End Function
    Public Shared Sub CreateOrUpdateConsolidate(ByVal tmpD As SIS.ATN.atnSABySIDays, Optional ByVal Create As Boolean = True)
      Dim Results As SIS.ATN.atnSABySI = tmpD.FK_ATN_SABySIDays_SerialNo
      Dim tmpCD As SIS.ATN.atnSiteAttendance = SIS.ATN.atnSiteAttendance.atnSiteAttendanceGetByID(Results.FinYear, Results.MonthID, tmpD.CardNo)
      Dim Found As Boolean = True
      If tmpCD Is Nothing Then
        If Not Create Then Exit Sub 'Can Not Update
        Found = False
        tmpCD = New SIS.ATN.atnSiteAttendance
        tmpCD.FinYear = Results.FinYear
        tmpCD.MonthID = Results.MonthID
        tmpCD.CardNo = tmpD.CardNo
        tmpCD.ATNStatusID = atnAplStates.SubmittedToHO
        tmpCD.SAStatusID = atnSAStates.Free
      End If
      Dim BlankFound As Boolean = False
      Dim FilledFound As Boolean = False
      Dim DaysInMonth As Integer = DateTime.DaysInMonth(Results.FinYear, Results.MonthID)
      With tmpCD
        If .SN01 = "" OrElse .SN01 = tmpD.SerialNo Then
          If tmpD.D01 = "" Then
            .SN01 = ""
            .VD01 = ""
            .AD01 = ""
            .PD01 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN01 = tmpD.SerialNo
            .VD01 = tmpD.D01
            .AD01 = tmpD.D01
            .PD01 = tmpD.D01
          End If
        End If
        If .SN02 = "" OrElse .SN02 = tmpD.SerialNo Then
          If tmpD.D02 = "" Then
            .SN02 = ""
            .VD02 = ""
            .AD02 = ""
            .PD02 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN02 = tmpD.SerialNo
            .VD02 = tmpD.D02
            .AD02 = tmpD.D02
            .PD02 = tmpD.D02
          End If
        End If
        If .SN03 = "" OrElse .SN03 = tmpD.SerialNo Then
          If tmpD.D03 = "" Then
            .SN03 = ""
            .VD03 = ""
            .AD03 = ""
            .PD03 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN03 = tmpD.SerialNo
            .VD03 = tmpD.D03
            .AD03 = tmpD.D03
            .PD03 = tmpD.D03
          End If
        End If
        If .SN04 = "" OrElse .SN04 = tmpD.SerialNo Then
          If tmpD.D04 = "" Then
            .SN04 = ""
            .VD04 = ""
            .AD04 = ""
            .PD04 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN04 = tmpD.SerialNo
            .VD04 = tmpD.D04
            .AD04 = tmpD.D04
            .PD04 = tmpD.D04
          End If
        End If
        If .SN05 = "" OrElse .SN05 = tmpD.SerialNo Then
          If tmpD.D05 = "" Then
            .SN05 = ""
            .VD05 = ""
            .AD05 = ""
            .PD05 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN05 = tmpD.SerialNo
            .VD05 = tmpD.D05
            .AD05 = tmpD.D05
            .PD05 = tmpD.D05
          End If
        End If
        If .SN06 = "" OrElse .SN06 = tmpD.SerialNo Then
          If tmpD.D06 = "" Then
            .SN06 = ""
            .VD06 = ""
            .AD06 = ""
            .PD06 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN06 = tmpD.SerialNo
            .VD06 = tmpD.D06
            .AD06 = tmpD.D06
            .PD06 = tmpD.D06
          End If
        End If
        If .SN07 = "" OrElse .SN07 = tmpD.SerialNo Then
          If tmpD.D07 = "" Then
            .SN07 = ""
            .VD07 = ""
            .AD07 = ""
            .PD07 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN07 = tmpD.SerialNo
            .VD07 = tmpD.D07
            .AD07 = tmpD.D07
            .PD07 = tmpD.D07
          End If
        End If
        If .SN08 = "" OrElse .SN08 = tmpD.SerialNo Then
          If tmpD.D08 = "" Then
            .SN08 = ""
            .VD08 = ""
            .AD08 = ""
            .PD08 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN08 = tmpD.SerialNo
            .VD08 = tmpD.D08
            .AD08 = tmpD.D08
            .PD08 = tmpD.D08
          End If
        End If
        If .SN09 = "" OrElse .SN09 = tmpD.SerialNo Then
          If tmpD.D09 = "" Then
            .SN09 = ""
            .VD09 = ""
            .AD09 = ""
            .PD09 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN09 = tmpD.SerialNo
            .VD09 = tmpD.D09
            .AD09 = tmpD.D09
            .PD09 = tmpD.D09
          End If
        End If
        If .SN10 = "" OrElse .SN10 = tmpD.SerialNo Then
          If tmpD.D10 = "" Then
            .SN10 = ""
            .VD10 = ""
            .AD10 = ""
            .PD10 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN10 = tmpD.SerialNo
            .VD10 = tmpD.D10
            .AD10 = tmpD.D10
            .PD10 = tmpD.D10
          End If
        End If
        If .SN11 = "" OrElse .SN11 = tmpD.SerialNo Then
          If tmpD.D11 = "" Then
            .SN11 = ""
            .VD11 = ""
            .AD11 = ""
            .PD11 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN11 = tmpD.SerialNo
            .VD11 = tmpD.D11
            .AD11 = tmpD.D11
            .PD11 = tmpD.D11
          End If
        End If
        If .SN12 = "" OrElse .SN12 = tmpD.SerialNo Then
          If tmpD.D12 = "" Then
            .SN12 = ""
            .VD12 = ""
            .AD12 = ""
            .PD12 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN12 = tmpD.SerialNo
            .VD12 = tmpD.D12
            .AD12 = tmpD.D12
            .PD12 = tmpD.D12
          End If
        End If
        If .SN13 = "" OrElse .SN13 = tmpD.SerialNo Then
          If tmpD.D13 = "" Then
            .SN13 = ""
            .VD13 = ""
            .AD13 = ""
            .PD13 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN13 = tmpD.SerialNo
            .VD13 = tmpD.D13
            .AD13 = tmpD.D13
            .PD13 = tmpD.D13
          End If
        End If
        If .SN14 = "" OrElse .SN14 = tmpD.SerialNo Then
          If tmpD.D14 = "" Then
            .SN14 = ""
            .VD14 = ""
            .AD14 = ""
            .PD14 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN14 = tmpD.SerialNo
            .VD14 = tmpD.D14
            .AD14 = tmpD.D14
            .PD14 = tmpD.D14
          End If
        End If
        If .SN15 = "" OrElse .SN15 = tmpD.SerialNo Then
          If tmpD.D15 = "" Then
            .SN15 = ""
            .VD15 = ""
            .AD15 = ""
            .PD15 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN15 = tmpD.SerialNo
            .VD15 = tmpD.D15
            .AD15 = tmpD.D15
            .PD15 = tmpD.D15
          End If
        End If
        If .SN16 = "" OrElse .SN16 = tmpD.SerialNo Then
          If tmpD.D16 = "" Then
            .SN16 = ""
            .VD16 = ""
            .AD16 = ""
            .PD16 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN16 = tmpD.SerialNo
            .VD16 = tmpD.D16
            .AD16 = tmpD.D16
            .PD16 = tmpD.D16
          End If
        End If
        If .SN17 = "" OrElse .SN17 = tmpD.SerialNo Then
          If tmpD.D17 = "" Then
            .SN17 = ""
            .VD17 = ""
            .AD17 = ""
            .PD17 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN17 = tmpD.SerialNo
            .VD17 = tmpD.D17
            .AD17 = tmpD.D17
            .PD17 = tmpD.D17
          End If
        End If
        If .SN18 = "" OrElse .SN18 = tmpD.SerialNo Then
          If tmpD.D18 = "" Then
            .SN18 = ""
            .VD18 = ""
            .AD18 = ""
            .PD18 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN18 = tmpD.SerialNo
            .VD18 = tmpD.D18
            .AD18 = tmpD.D18
            .PD18 = tmpD.D18
          End If
        End If
        If .SN19 = "" OrElse .SN19 = tmpD.SerialNo Then
          If tmpD.D19 = "" Then
            .SN19 = ""
            .VD19 = ""
            .AD19 = ""
            .PD19 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN19 = tmpD.SerialNo
            .VD19 = tmpD.D19
            .AD19 = tmpD.D19
            .PD19 = tmpD.D19
          End If
        End If
        If .SN20 = "" OrElse .SN20 = tmpD.SerialNo Then
          If tmpD.D20 = "" Then
            .SN20 = ""
            .VD20 = ""
            .AD20 = ""
            .PD20 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN20 = tmpD.SerialNo
            .VD20 = tmpD.D20
            .AD20 = tmpD.D20
            .PD20 = tmpD.D20
          End If
        End If
        If .SN21 = "" OrElse .SN21 = tmpD.SerialNo Then
          If tmpD.D21 = "" Then
            .SN21 = ""
            .VD21 = ""
            .AD21 = ""
            .PD21 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN21 = tmpD.SerialNo
            .VD21 = tmpD.D21
            .AD21 = tmpD.D21
            .PD21 = tmpD.D21
          End If
        End If
        If .SN22 = "" OrElse .SN22 = tmpD.SerialNo Then
          If tmpD.D22 = "" Then
            .SN22 = ""
            .VD22 = ""
            .AD22 = ""
            .PD22 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN22 = tmpD.SerialNo
            .VD22 = tmpD.D22
            .AD22 = tmpD.D22
            .PD22 = tmpD.D22
          End If
        End If
        If .SN23 = "" OrElse .SN23 = tmpD.SerialNo Then
          If tmpD.D23 = "" Then
            .SN23 = ""
            .VD23 = ""
            .AD23 = ""
            .PD23 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN23 = tmpD.SerialNo
            .VD23 = tmpD.D23
            .AD23 = tmpD.D23
            .PD23 = tmpD.D23
          End If
        End If
        If .SN24 = "" OrElse .SN24 = tmpD.SerialNo Then
          If tmpD.D24 = "" Then
            .SN24 = ""
            .VD24 = ""
            .AD24 = ""
            .PD24 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN24 = tmpD.SerialNo
            .VD24 = tmpD.D24
            .AD24 = tmpD.D24
            .PD24 = tmpD.D24
          End If
        End If
        If .SN25 = "" OrElse .SN25 = tmpD.SerialNo Then
          If tmpD.D25 = "" Then
            .SN25 = ""
            .VD25 = ""
            .AD25 = ""
            .PD25 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN25 = tmpD.SerialNo
            .VD25 = tmpD.D25
            .AD25 = tmpD.D25
            .PD25 = tmpD.D25
          End If
        End If
        If .SN26 = "" OrElse .SN26 = tmpD.SerialNo Then
          If tmpD.D26 = "" Then
            .SN26 = ""
            .VD26 = ""
            .AD26 = ""
            .PD26 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN26 = tmpD.SerialNo
            .VD26 = tmpD.D26
            .AD26 = tmpD.D26
            .PD26 = tmpD.D26
          End If
        End If
        If .SN27 = "" OrElse .SN27 = tmpD.SerialNo Then
          If tmpD.D27 = "" Then
            .SN27 = ""
            .VD27 = ""
            .AD27 = ""
            .PD27 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN27 = tmpD.SerialNo
            .VD27 = tmpD.D27
            .AD27 = tmpD.D27
            .PD27 = tmpD.D27
          End If
        End If
        If .SN28 = "" OrElse .SN28 = tmpD.SerialNo Then
          If tmpD.D28 = "" Then
            .SN28 = ""
            .VD28 = ""
            .AD28 = ""
            .PD28 = ""
            BlankFound = True
          Else
            FilledFound = True
            .SN28 = tmpD.SerialNo
            .VD28 = tmpD.D28
            .AD28 = tmpD.D28
            .PD28 = tmpD.D28
          End If
        End If
        If .SN29 = "" OrElse .SN29 = tmpD.SerialNo Then
          If tmpD.D29 = "" Then
            .SN29 = ""
            .VD29 = ""
            .AD29 = ""
            .PD29 = ""
            If DaysInMonth >= 29 Then
              BlankFound = True
            End If
          Else
            If DaysInMonth >= 29 Then
              FilledFound = True
            End If
            .SN29 = tmpD.SerialNo
            .VD29 = tmpD.D29
            .AD29 = tmpD.D29
            .PD29 = tmpD.D29
          End If
        End If
        If .SN30 = "" OrElse .SN30 = tmpD.SerialNo Then
          If tmpD.D30 = "" Then
            .SN30 = ""
            .VD30 = ""
            .AD30 = ""
            .PD30 = ""
            If DaysInMonth >= 30 Then
              BlankFound = True
            End If
          Else
            If DaysInMonth >= 30 Then
              FilledFound = True
            End If
            .SN30 = tmpD.SerialNo
            .VD30 = tmpD.D30
            .AD30 = tmpD.D30
            .PD30 = tmpD.D30
          End If
        End If
        If .SN31 = "" OrElse .SN31 = tmpD.SerialNo Then
          If tmpD.D31 = "" Then
            .SN31 = ""
            .VD31 = ""
            .AD31 = ""
            .PD31 = ""
            If DaysInMonth >= 31 Then
              BlankFound = True
            End If
          Else
            If DaysInMonth >= 31 Then
              FilledFound = True
            End If
            .SN31 = tmpD.SerialNo
            .VD31 = tmpD.D31
            .AD31 = tmpD.D31
            .PD31 = tmpD.D31
          End If
        End If
      End With
      If Not BlankFound And FilledFound Then
        tmpCD.SAStatusID = atnSAStates.Complete
      ElseIf Not FilledFound And BlankFound Then
        tmpCD.SAStatusID = atnSAStates.Free
      ElseIf FilledFound And BlankFound Then
        tmpCD.SAStatusID = atnSAStates.Partially
      End If
      If Found Then
        tmpCD = SIS.ATN.atnSiteAttendance.UpdateData(tmpCD)
      Else
        tmpCD = SIS.ATN.atnSiteAttendance.InsertData(tmpCD)
      End If

    End Sub
    Public Shared Function UZ_atnSABySISelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ProjectID As String) As List(Of SIS.ATN.atnSABySI)
      Dim Results As List(Of SIS.ATN.atnSABySI) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatn_LG_SABySISelectListSearch"
            Cmd.CommandText = "spatnSABySISelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatn_LG_SABySISelectListFilteres"
            Cmd.CommandText = "spatnSABySISelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_MonthID", SqlDbType.Int, 10, IIf(MonthID = Nothing, 0, MonthID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnSABySI)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSABySI(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByMonthID(ByVal MonthID As Int32, ByVal OrderBy As String) As List(Of SIS.ATN.atnSABySI)
      Dim Results As List(Of SIS.ATN.atnSABySI) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_SABySISelectByMonthID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID", SqlDbType.Int, MonthID.ToString.Length, MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnSABySI)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSABySI(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByVerifiedBy(ByVal VerifiedBy As String, ByVal OrderBy As String) As List(Of SIS.ATN.atnSABySI)
      Dim Results As List(Of SIS.ATN.atnSABySI) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSABySISelectByVerifiedBy"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, VerifiedBy.ToString.Length, VerifiedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnSABySI)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnSABySI(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_atnSABySIInsert(ByVal Record As SIS.ATN.atnSABySI) As SIS.ATN.atnSABySI
      Dim tmp As List(Of SIS.ATN.atnSABySI) = SIS.ATN.atnSABySI.GetByMonthID(Record.MonthID, "")
      Record = atnSABySIInsert(Record)
      If tmp.Count = 0 Then
        tmp = SIS.ATN.atnSABySI.GetByMonthID(Convert.ToInt32(Record.MonthID) - 1, "")
        If tmp.Count > 0 Then
          Dim tmpLast As SIS.ATN.atnSABySI = tmp.Last
          Dim tmpSAs As List(Of SIS.ATN.atnSABySIDays) = SIS.ATN.atnSABySIDays.atnSABySIDaysSelectList(0, 999, "", False, "", tmpLast.SerialNo)
          Dim himSelfFound As Boolean = False
          For Each tmpSA As SIS.ATN.atnSABySIDays In tmpSAs
            If tmpSA.CardNo = Record.VerifiedBy Then himSelfFound = True
            Dim nTmp As New SIS.ATN.atnSABySIDays
            nTmp.SerialNo = Record.SerialNo
            nTmp.CardNo = tmpSA.CardNo
            SIS.ATN.atnSABySIDays.InsertData(nTmp)
          Next
          If Not himSelfFound Then
            Dim nTmp As New SIS.ATN.atnSABySIDays
            nTmp.SerialNo = Record.SerialNo
            nTmp.CardNo = Record.VerifiedBy
            SIS.ATN.atnSABySIDays.InsertData(nTmp)
          End If
        Else
          Dim nTmp As New SIS.ATN.atnSABySIDays
          nTmp.SerialNo = Record.SerialNo
          nTmp.CardNo = Record.VerifiedBy
          SIS.ATN.atnSABySIDays.InsertData(nTmp)
        End If
      End If
      Return Record
    End Function
    Public Shared Function UZ_atnSABySIUpdate(ByVal Record As SIS.ATN.atnSABySI) As SIS.ATN.atnSABySI
      Dim _Result As SIS.ATN.atnSABySI = atnSABySIUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_atnSABySIDelete(ByVal Record As SIS.ATN.atnSABySI) As Integer
      Dim _Result as Integer = atnSABySIDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_MonthID"),Object).SelectedValue = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_SiteName"), TextBox).Text = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
