
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.Net
Imports System.Data
Imports System.Data.SqlClient

Partial Class WFHRooster
  Inherits System.Web.UI.Page

  Private Sub WFHRooster_Load(sender As Object, e As EventArgs) Handles Me.Load
    cmdGenerate.Visible = False
    cmdDelete.Visible = False
    cmdSetting.Visible = False
    HttpContext.Current.Session("IsAdmin") = False
    Try
      Dim user As String = HttpContext.Current.Session("LoginID")
      If SIS.ATN.WFHRooster.IsAdmin(user) Then
        cmdGenerate.Visible = True
        cmdDelete.Visible = True
        cmdSetting.Visible = True
      End If
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "wfh_script.failed('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
  End Sub
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Private aCards As ArrayList = Nothing

  Private Function WriteEmp(ws As ExcelWorksheet, x As SIS.ATN.wEmp, r As Integer, cnf As SIS.ATN.WFHConfig) As Integer
    Dim Found As Boolean = False
    For Each str As String In aCards
      If str = x.cno Then
        Found = True
        Exit For
      End If
    Next
    If Not Found Then
      aCards.Add(x.cno)
      With ws
        .Cells(r, 2).Value = x.cno
        .Cells(r, 3).Value = x.enm
        .Cells(r, 4 + x.lvl).Value = x.enm
        .Cells(r, 14).Value = x.dep
        Dim c As Integer = 0
        For Each d As SIS.ATN.wRst In x.rsts
          If d.en Then
            .Cells(r, 15 + c).Value = "NA"
            .Cells(r, 15 + c).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            .Cells(r, 15 + c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Silver)
            .Cells(r, 15 + c).Style.Font.Color.SetColor(System.Drawing.Color.Blue)
            .Cells(r, 15 + c).Style.Locked = True
          ElseIf d.nw Then
            .Cells(r, 15 + c).Value = "WO"
            .Cells(r, 15 + c).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            .Cells(r, 15 + c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Goldenrod)
            .Cells(r, 15 + c).Style.Font.Color.SetColor(System.Drawing.Color.Black)
            .Cells(r, 15 + c).Style.Locked = True
          ElseIf d.wd Then
            .Cells(r, 15 + c).Value = "Y"
            .Cells(r, 15 + c).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            .Cells(r, 15 + c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red)
            .Cells(r, 15 + c).Style.Font.Color.SetColor(System.Drawing.Color.White)
          ElseIf Not d.wd Then
            .Cells(r, 15 + c).Value = "N"
            .Cells(r, 15 + c).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            .Cells(r, 15 + c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green)
            .Cells(r, 15 + c).Style.Font.Color.SetColor(System.Drawing.Color.White)
          End If
          c += 1
        Next
        r += 1
      End With
    End If
    For Each y As SIS.ATN.wEmp In x.cEmps
      Dim z As SIS.ATN.wResp = SIS.ATN.wResp.GetReport(y.cno, cnf, y.lvl)
      If z.emp IsNot Nothing Then
        r = WriteEmp(ws, z.emp, r, cnf)
      End If
    Next
    Return r
  End Function
  Protected Sub cmdDownload_Click(sender As Object, e As EventArgs) Handles cmdDownload.Click
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    aCards = New ArrayList
    Dim confstr As String = DDLWFHConfig.SelectedValue
    Dim user As String = HttpContext.Current.Session("LoginID")
    Dim Level As Integer = 0
    Dim Conf As SIS.ATN.WFHConfig = SIS.ATN.WFHConfig.WFHConfigGetByID(confstr)
    Dim x As SIS.ATN.wResp = Nothing

    'If PkgNo = String.Empty Then
    '  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Package No is required for Template download.") & "');", True)
    '  HttpContext.Current.Server.ScriptTimeout = st
    '  Exit Sub
    'End If

    Dim TemplateName As String = "WFH_Roster.xlsx"

    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      '1.
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("WFHData")
      Dim r As Integer = 1
      Dim c As Integer = 1
      Dim cnt As Integer = 1


      With xlWS
        .Cells(2, 4).Value = confstr
        .Cells(3, 4).Value = user
      End With
      Dim sdt As DateTime = Convert.ToDateTime(Conf.FromDate)
      c = 0
      Do While sdt <= Convert.ToDateTime(Conf.ToDate)
        xlWS.Cells(4, 15 + c).Value = sdt.ToString("dd-MM")
        c += 1
        sdt = sdt.AddDays(1)
      Loop

      x = SIS.ATN.wResp.GetReport(user, Conf, Level)
      r = 5
      c = 1
      If x.emp IsNot Nothing Then
        WriteEmp(xlWS, x.emp, r, Conf)
      End If

      xlPk.Save()
      xlPk.Dispose()

      Dim wc As WebClient = New WebClient

      Response.Clear()
      Response.ClearContent()
      Response.ClearHeaders()
      Response.Buffer = True
      Response.AppendHeader("content-disposition", "attachment; filename=" & user & "_" & confstr & ".xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      'Response.WriteFile(FileName)
      Dim aByte() As Byte = wc.DownloadData(FileName)
      Response.BinaryWrite(aByte)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

  Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
    If Request.Files.Count > 0 Then
      Dim IsError As Boolean = False
      Dim ErrMsg As New ArrayList
      '1. Read XL File
      HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
      Try
        Dim tmpPath As String = Server.MapPath("~/../App_Temp")
        Dim tmpName As String = IO.Path.GetRandomFileName()
        Dim tmpFile As String = tmpPath & "\\" & tmpName
        Request.Files(0).SaveAs(tmpFile)
        Dim fi As FileInfo = New FileInfo(tmpFile)
        Dim aEmps As New List(Of SIS.ATN.wEmp)
        Dim User As String = ""
        Dim LoginID As String = ""
        Dim cnf As SIS.ATN.WFHConfig = Nothing
        Using xlP As ExcelPackage = New ExcelPackage(fi)
          Dim wsD As ExcelWorksheet = Nothing
          Try
            wsD = xlP.Workbook.Worksheets("WFHData")
          Catch ex As Exception
            wsD = Nothing
          End Try
          If wsD Is Nothing Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid XL Data Sheet Not Found") & "');", True)
            xlP.Dispose()
            HttpContext.Current.Server.ScriptTimeout = st
            Exit Sub
          End If
          'Load Document
          Dim SerialNo As Integer = wsD.Cells(2, 4).Text
          User = wsD.Cells(3, 4).Text
          Try
            Dim tmp As String = HttpContext.Current.Session("LoginID")
            LoginID = tmp
          Catch ex As Exception
          End Try
          If LoginID = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Session expired, Login again.") & "');", True)
            xlP.Dispose()
            HttpContext.Current.Server.ScriptTimeout = st
            Exit Sub
          End If
          Try
            cnf = SIS.ATN.WFHConfig.WFHConfigGetByID(SerialNo)
          Catch ex As Exception
          End Try
          If cnf Is Nothing Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Configuration ID Not Found") & "');", True)
            xlP.Dispose()
            HttpContext.Current.Server.ScriptTimeout = st
            Exit Sub
          End If
          'Admin Can Upload Other User File, but as per authorization of User
          If Not SIS.ATN.WFHRooster.IsAdmin(LoginID) Then
            If LoginID <> User Then
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Uploaded file does not belong to logged in user.") & "');", True)
              xlP.Dispose()
              HttpContext.Current.Server.ScriptTimeout = st
              Exit Sub
            End If
          End If
          If Not cnf.Active Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Period is not open for update.") & "');", True)
            xlP.Dispose()
            HttpContext.Current.Server.ScriptTimeout = st
            Exit Sub
          End If
          If Not cnf.OpenedFor.IndexOf("*") >= 0 And Not cnf.OpenedFor.IndexOf(User) >= 0 Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Period is not open for the template user.") & "');", True)
            xlP.Dispose()
            HttpContext.Current.Server.ScriptTimeout = st
            Exit Sub
          End If
          For I As Integer = 5 To 99999
            Dim x As New SIS.ATN.wEmp
            x.cno = wsD.Cells(I, 2).Text
            If x.cno = "" Then Exit For
            Dim sdt As DateTime = Convert.ToDateTime(cnf.FromDate)
            Dim edt As DateTime = Convert.ToDateTime(cnf.ToDate)
            Dim J As Integer = 15
            Do While sdt <= edt
              Dim val As String = wsD.Cells(I, J).Text.ToLower
              Select Case val
                Case "na", "wo", "y", "n"
                  Dim rst As New SIS.ATN.wRst
                  With rst
                    .adt = sdt.ToString("dd/MM/yyyy")
                    If val = "na" Then
                      rst.en = True
                    ElseIf val = "wo" Then
                      rst.nw = True
                    ElseIf val = "y" Then
                      rst.wd = True
                    End If
                  End With
                  x.rsts.Add(rst)
                Case Else
                  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Line No." & I & ", " & sdt.ToString("dd/MM/yyyy") & " invalid value: " & val & " Pl. correct all such data and upload again.") & "');", True)
                  xlP.Dispose()
                  HttpContext.Current.Server.ScriptTimeout = st
                  Exit Sub
              End Select
              sdt = sdt.AddDays(1)
              J += 1
            Loop
            aEmps.Add(x)
          Next
          xlP.Dispose()
        End Using
        If aEmps.Count > 0 Then
          Dim lpd As DateTime = SIS.SYS.Utilities.ApplicationSpacific.LastProcessedDate
          Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
            Con.Open()
            For Each x As SIS.ATN.wEmp In aEmps
              For Each rst As SIS.ATN.wRst In x.rsts
                Dim mayUpdate As Boolean = True
                If Not cnf.AllowProcessed Then
                  If Convert.ToDateTime(rst.adt) <= lpd Then
                    mayUpdate = False
                  End If
                End If
                If mayUpdate Then
                  Using Cmd As SqlCommand = Con.CreateCommand()
                    Dim Sql As String = ""
                    Sql &= ""
                    Sql &= " update atn_wfhrooster set "
                    If rst.en Then
                      Sql &= " EmployeeNotActive = 1"
                    Else
                      Sql &= " EmployeeNotActive = 0"
                    End If
                    If rst.nw Then
                      Sql &= " ,NonWorkingDay = 1"
                    Else
                      Sql &= " ,NonWorkingDay = 0"
                    End If
                    If rst.wd Then
                      Sql &= " ,WFHFullDay = 1"
                    Else
                      Sql &= " ,WFHFullDay = 0"
                    End If
                    Sql &= " ,ModifiedBy = '" & LoginID & "'"
                    Sql &= " ,ModifiedOn = GetDate() "
                    Sql &= " ,ModifierRemarks = 'Excel Upload'"
                    Sql &= " ,RoosterStatus = " & enumRoosterStatus.Updated
                    Sql &= " where cardno='" & x.cno & "'"
                    Sql &= " and attendate=convert(datetime,'" & rst.adt & "',103) "
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Cmd.ExecuteNonQuery()
                  End Using
                  'Insert History
                  Using Cmd As SqlCommand = Con.CreateCommand()
                    Dim Sql As String = ""
                    Sql &= ""
                    Sql &= " Insert atn_wfhroosterHistory "
                    Sql &= " (CardNo,AttenDate,WFH1stHalf,WFH2ndHalf,WFHFullDay,NonWorkingDay,EmployeeNotActive,RoosterStatus,ModifiedBy,ModifiedOn,ModifierRemarks)"
                    Sql &= " values ("
                    Sql &= "'" & x.cno & "'"
                    Sql &= ",convert(datetime,'" & rst.adt & "',103)"
                    Sql &= ",0,0," & IIf(rst.wd, 1, 0) & ""
                    Sql &= "," & IIf(rst.nw, 1, 0) & ""
                    Sql &= "," & IIf(rst.en, 1, 0) & ""
                    Sql &= "," & enumRoosterStatus.Updated & ""
                    Sql &= ",'" & LoginID & "'"
                    Sql &= ",GetDate()"
                    Sql &= ",'Excel Upload')"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Cmd.ExecuteNonQuery()
                  End Using
                End If
              Next
            Next
          End Using
        End If
      Catch ex As Exception
        HttpContext.Current.Server.ScriptTimeout = st
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
      HttpContext.Current.Server.ScriptTimeout = st
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Data updated.") & "');", True)
    End If
  End Sub
End Class
