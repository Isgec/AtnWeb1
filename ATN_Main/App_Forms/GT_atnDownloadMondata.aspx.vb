Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data
Imports OfficeOpenXml
Imports System.Reflection
Partial Class GT_atnDownloadMondata
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Private ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)

  Protected Sub Jul_Click(sender As Object, e As System.EventArgs) Handles Jul.Click
    WebPayDays(7, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub
  Private Sub WebPayDays(ByVal mm As Integer, ByVal yy As Integer)
    Dim startDate As DateTime = Convert.ToDateTime("01/" & mm.ToString.PadLeft(2, "0") & "/" & yy, ci)
    Dim cutofDate As DateTime = Convert.ToDateTime("21/" & mm.ToString.PadLeft(2, "0") & "/" & yy, ci)
    Dim lastDate As DateTime = Convert.ToDateTime(Date.DaysInMonth(cutofDate.Year, cutofDate.Month) & "/" & mm.ToString.PadLeft(2, "0") & "/" & yy, ci)

    Dim SalaryTable As String = "SalaryOtherDetails1718" 'For Arrear in LastYear
    'Dim SalaryTable As String = "SalaryOtherDetails"   'CurrentYear
    Dim SalaryCur As String = "SalaryOtherDetails"
    Dim SalaryLst1 As String = "SalaryOtherDetails"
    Dim SalaryLst2 As String = "SalaryOtherDetails1718"

    Select Case mm
      Case 4
        SalaryCur = "SalaryOtherDetails"
        SalaryLst1 = "SalaryOtherDetails" & (yy - 1).ToString.Substring(2) & yy.ToString.Substring(2)
        SalaryLst2 = "SalaryOtherDetails" & (yy - 1).ToString.Substring(2) & yy.ToString.Substring(2)
      Case 5
        SalaryCur = "SalaryOtherDetails"
        SalaryLst1 = "SalaryOtherDetails"
        SalaryLst2 = "SalaryOtherDetails" & (yy - 1).ToString.Substring(2) & yy.ToString.Substring(2)
      Case Else
        SalaryCur = "SalaryOtherDetails"
        SalaryLst1 = "SalaryOtherDetails"
        SalaryLst2 = "SalaryOtherDetails"
    End Select

    Dim Sql1 As String = ""

    Dim sql As String = "  SELECT "
    sql &= vbCrLf & "  a.CardNo, "
    sql &= vbCrLf & "  a.EmployeeName, "
    sql &= vbCrLf & "  a.C_DateofJoining as JDT, "
    sql &= vbCrLf & "  a.C_DateOfReleaving As RDT,"
    sql &= vbCrLf & "  a.ActiveState,  "
    sql &= vbCrLf & "  (case C_OfficeID when 6 then 'Site' else 'Office' end) as Location, "
    'Present Days Current Month upto 21
    sql &= vbCrLf & "  isnull((select sum(tmp.FinalValue) from atn_attendance as tmp "
    sql &= vbCrLf & "    where tmp.finyear=" & yy & " and month(tmp.attendate) = " & mm
    sql &= vbCrLf & "    and tmp.attendate <= convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) "
    sql &= vbCrLf & "    and tmp.cardno=a.cardno),0) AS PR_CurrMonth,  "
    'Balance Days in Current Month
    sql &= vbCrLf & " (case "
    sql &= vbCrLf & " 	when a.C_DateOfJoining <= convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) then"
    sql &= vbCrLf & " 		case"
    sql &= vbCrLf & " 			when a.C_DateOfReleaving is null then"
    sql &= vbCrLf & " 				datediff( d,convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) , convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103))"
    sql &= vbCrLf & " 			when a.C_DateOfReleaving >= convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103) then"
    sql &= vbCrLf & " 				datediff( d,convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) , convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103))"
    sql &= vbCrLf & " 			when a.C_DateOfReleaving >= convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) and a.C_DateOfReleaving < convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103) then"
    sql &= vbCrLf & " 			  datediff(d, convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103), a.C_DateOfReleaving) "
    sql &= vbCrLf & " 			else"
    sql &= vbCrLf & " 				0"
    sql &= vbCrLf & "   	end"
    sql &= vbCrLf & "   else "
    sql &= vbCrLf & " 		case"
    sql &= vbCrLf & " 			when a.C_DateOfReleaving is null then"
    sql &= vbCrLf & " 				datediff( d,a.C_DateOfJoining , convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103))"
    sql &= vbCrLf & " 			when a.C_DateOfReleaving >= convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103) then"
    sql &= vbCrLf & " 				datediff( d,a.C_DateOfJoining , convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103))"
    sql &= vbCrLf & " 			when a.C_DateOfReleaving >= a.C_DateOfJoining and a.C_DateOfReleaving < convert(datetime,'" & lastDate.ToString("dd/MM/yyyy") & "',103) then"
    sql &= vbCrLf & " 			  datediff(d, a.C_DateOfJoining, a.C_DateOfReleaving) "
    sql &= vbCrLf & " 			else"
    sql &= vbCrLf & " 				0"
    sql &= vbCrLf & "   	end"
    sql &= vbCrLf & " end) as BalDays,  "

    'Present Days Last 1 Month
    Dim yyLast1 As Integer = cutofDate.AddMonths(-1).Year
    Dim mmLast1 As Integer = cutofDate.AddMonths(-1).Month
    sql &= vbCrLf & "        isnull((select sum(tmp.FinalValue) from atn_attendance as tmp "
    sql &= vbCrLf & "                where tmp.finyear=" & yyLast1 & " and month(tmp.attendate) = " & mmLast1 & " "
    sql &= vbCrLf & "                and tmp.cardno=a.cardno),0) AS PR_Last1Month,  "
    'Paid Days Last 1 Month
    sql &= vbCrLf & "        isnull((select PD_LastMonth FROM OPENQUERY(WEBPAY,"
    sql &= vbCrLf & "						'SELECT    fk_Emp_Code As CardNo, PaidDays As PD_LastMonth"
    sql &= vbCrLf & "						FROM      " & SalaryLst1
    sql &= vbCrLf & "						WHERE     mm = " & mmLast1 & " AND YYYY = " & yyLast1 & "'              "
    sql &= vbCrLf & "            ) "
    sql &= vbCrLf & "               where CardNo=a.CardNo) "
    sql &= vbCrLf & "				,0) as PD_Last1Month, "
    'LWP Days Last 1 Month
    sql &= vbCrLf & "        isnull((select LWP_LastMonth FROM OPENQUERY(WEBPAY,"
    sql &= vbCrLf & "						'SELECT    fk_Emp_Code As CardNo, sum(LWP) As LWP_LastMonth"
    sql &= vbCrLf & "						FROM       " & SalaryLst1
    sql &= vbCrLf & "						WHERE     mm = " & mmLast1 & " AND YYYY = " & yyLast1 & " group by fk_emp_code '              "
    sql &= vbCrLf & "            ) "
    sql &= vbCrLf & "               where CardNo=a.CardNo) "
    sql &= vbCrLf & "				,0) as LWP_Last1Month, "


    'Present Days Last 2 Month
    Dim yyLast2 As Integer = cutofDate.AddMonths(-2).Year
    Dim mmLast2 As Integer = cutofDate.AddMonths(-2).Month
    sql &= vbCrLf & "        isnull((select sum(tmp.FinalValue) from atn_attendance as tmp "
    sql &= vbCrLf & "                where tmp.finyear=" & yyLast2 & " and month(tmp.attendate) = " & mmLast2 & " "
    sql &= vbCrLf & "                and tmp.cardno=a.cardno),0) AS PR_Last2Month,  "
    'Paid Days Last 2 Month
    sql &= vbCrLf & "        isnull((select PD_LastMonth FROM OPENQUERY(WEBPAY,"
    sql &= vbCrLf & "						'SELECT    fk_Emp_Code As CardNo, PaidDays As PD_LastMonth"
    sql &= vbCrLf & "						FROM       " & SalaryLst2
    sql &= vbCrLf & "						WHERE     mm = " & mmLast2 & " AND YYYY = " & yyLast2 & "'              "
    sql &= vbCrLf & "            ) "
    sql &= vbCrLf & "               where CardNo=a.CardNo) "
    sql &= vbCrLf & "				,0) as PD_Last2Month, "
    'Arrear Days of Last2 in Last1
    sql &= vbCrLf & "        isnull((select Arr_Last2InLast1 FROM OPENQUERY(WEBPAY,"
    sql &= vbCrLf & "						' "
    sql &= vbCrLf & "        select m.fk_emp_code As CardNo,sum(m.NoOfDays) as Arr_Last2InLast1 from trnemparrOtherDetails as m"
    sql &= vbCrLf & "        inner join trnempcurrarrOtherDetails as c on c.pk_currarrearid = m.fk_currarrearid"
    sql &= vbCrLf & "        where m.mm = " & mmLast2 & " AND m.YYYY = " & yyLast2
    sql &= vbCrLf & "        and c.mm = " & mmLast1 & " AND c.YYYY = " & yyLast1
    sql &= vbCrLf & "        and c.ProcessFlag IN (''J'',''D'') "
    sql &= vbCrLf & "        and m.NoofDays<>0 group by m.fk_emp_code"
    sql &= vbCrLf & "						' "
    sql &= vbCrLf & "            ) "
    sql &= vbCrLf & "               where CardNo=a.CardNo) "
    sql &= vbCrLf & "				,0) as Arr_Last2InLast1  "

    sql &= vbCrLf & "FROM    hrm_employees as a "


    Sql1 &= vbCrLf & " select CardNo,EmployeeName, JDT,RDT,ActiveState,Location,PR_CurrMonth, "
    Sql1 &= vbCrLf & " (case when pr_currmonth=0 "
    Sql1 &= vbCrLf & "    then (case when JDT > convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) then baldays else (case when RDT <= convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) then baldays else 0 end) end)  "
    Sql1 &= vbCrLf & "    else baldays "
    Sql1 &= vbCrLf & " end) as currBalDays, "
    Sql1 &= vbCrLf & " PR_Last1Month,PD_Last1Month, "
    Sql1 &= vbCrLf & " PR_Last1Month - PD_Last1Month as Arr_Last1Month, "
    Sql1 &= vbCrLf & " (case when (PR_Last1Month - PD_Last1Month) > LWP_Last1Month then 'ERR' else '' end) as Wrong_Arr, "
    Sql1 &= vbCrLf & " LWP_Last1Month, "
    Sql1 &= vbCrLf & " PR_Last2Month,PD_Last2Month,Arr_Last2InLast1, "
    Sql1 &= vbCrLf & " PR_Last2Month - (PD_Last2Month + Arr_Last2InLast1) as Arr_Last2Month, "
    Sql1 &= vbCrLf & " (PR_CurrMonth + (case when pr_currmonth=0 then (case when JDT > convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) then baldays else (case when RDT <= convert(datetime,'" & cutofDate.ToString("dd/MM/yyyy") & "',103) then baldays else 0 end) end) else baldays end)) as payCurr, (PR_Last1Month - PD_Last1Month) as arrLast,  PR_Last2Month - (PD_Last2Month + Arr_Last2InLast1) as Arr2Last "
    Sql1 &= vbCrLf & " FROM (" & sql & ") as b "
    Sql1 &= vbCrLf & " where (RDT >= convert(datetime,'" & startDate.ToString("dd/MM/yyyy") & "',103) OR RDT is NULL) "

    'Sql1 &= vbCrLf & "       and (cardno < '9000' or cardno in ('9883','9744','9010','9734','9986','9990'))"

    Sql1 &= vbCrLf & "       and (cardno not in ('0009','001059','001364','2641','7778'))"

    Dim oRec As List(Of salDays) = Execute(Sql1, yy, mm)

    Dim FilePath As String = CreateFile(oRec)
    Dim FileNameForUser As String = "webPay_" & Convert.ToDateTime(lastDate).ToString("dd-MM-yyyy") & ".xlsx"
    If IO.File.Exists(FilePath) Then
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=""" & FileNameForUser & """")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
      Response.WriteFile(FilePath)
      Response.End()
    End If


  End Sub
  Private Function CreateFile(ByVal oRqs As List(Of salDays)) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\SalaryDays_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")


    Dim r As Integer = 2
    Dim c As Integer = 1
    With xlWS
      For Each rq As salDays In oRqs
        On Error Resume Next
        If r > 2 Then xlWS.InsertRow(r, 1, r + 1)
        c = 1
        For Each p As System.Reflection.PropertyInfo In rq.GetType().GetProperties()
          If p.CanRead Then
            .Cells(r, c).Value = p.GetValue(rq, Nothing)
            c = c + 1
          End If
        Next
        r += 1
      Next
    End With

    r = 2
    xlWS = xlPk.Workbook.Worksheets("Days")
    With xlWS
      For Each rq As salDays In oRqs
        On Error Resume Next
        If r > 2 Then xlWS.InsertRow(r, 1, r + 1)
        .Cells(r, 1).Value = rq.CardNo
        .Cells(r, 2).Value = rq.EmployeeName
        .Cells(r, 3).Value = rq.ProcessingYear
        .Cells(r, 4).Value = rq.ProcessingMonth
        .Cells(r, 5).Value = rq.FullDay
        .Cells(r, 6).Value = Convert.ToDecimal(rq.payCurr)
        .Cells(r, 8).Value = rq.MonthDays - Convert.ToDecimal(rq.payCurr)
        .Cells(r, 14).Value = "N"
        .Cells(r, 15).Value = "N"
        r += 1
      Next
    End With


    r = 2
    xlWS = xlPk.Workbook.Worksheets("ArLast")
    Dim LastMonth As Integer = oRqs(0).ProcessingMonth
    Dim LastYear As Integer = oRqs(0).ProcessingYear
    If LastMonth = 1 Then
      LastMonth = 12
      LastYear = LastYear - 1
    Else
      LastMonth = LastMonth - 1
    End If
    With xlWS
      .Cells("C1").Value = MonthName(LastMonth, True) & " " & LastYear & " Days"
      For Each rq As salDays In oRqs
        On Error Resume Next
        If Convert.ToDecimal(rq.arrLast) = 0 Then Continue For
        If r > 2 Then xlWS.InsertRow(r, 1, r + 1)
        .Cells(r, 1).Value = rq.CardNo
        .Cells(r, 2).Value = rq.EmployeeName
        .Cells(r, 3).Value = rq.arrLast
        r += 1
      Next
    End With

    r = 2
    xlWS = xlPk.Workbook.Worksheets("ArLastLast")
    If LastMonth = 1 Then
      LastMonth = 12
      LastYear = LastYear - 1
    Else
      LastMonth = LastMonth - 1
    End If
    With xlWS
      .Cells("C1").Value = MonthName(LastMonth, True) & " " & LastYear & " Days"
      For Each rq As salDays In oRqs
        On Error Resume Next
        If Convert.ToDecimal(rq.arr2Last) = 0 Then Continue For
        If r > 2 Then xlWS.InsertRow(r, 1, r + 1)
        .Cells(r, 1).Value = rq.CardNo
        .Cells(r, 2).Value = rq.EmployeeName
        .Cells(r, 3).Value = rq.arr2Last
        r += 1
      Next
    End With

    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function

  Public Function Execute(ByVal sql As String, ByVal YY As Integer, ByVal MM As Integer) As List(Of salDays)
    Dim Results As List(Of salDays) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = sql
        Results = New List(Of salDays)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New salDays(Reader, YY, MM))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function

  Protected Sub Apr_Click(sender As Object, e As System.EventArgs) Handles Apr.Click
    WebPayDays(4, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Aug_Click(sender As Object, e As System.EventArgs) Handles Aug.Click
    WebPayDays(8, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Dec_Click(sender As Object, e As System.EventArgs) Handles Dec.Click
    WebPayDays(12, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Feb_Click(sender As Object, e As System.EventArgs) Handles Feb.Click
    WebPayDays(2, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Jan_Click(sender As Object, e As System.EventArgs) Handles Jan.Click
    WebPayDays(1, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Jun_Click(sender As Object, e As System.EventArgs) Handles Jun.Click
    WebPayDays(6, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Mar_Click(sender As Object, e As System.EventArgs) Handles Mar.Click
    WebPayDays(3, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub May_Click(sender As Object, e As System.EventArgs) Handles May.Click
    WebPayDays(5, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Nov_Click(sender As Object, e As System.EventArgs) Handles Nov.Click
    WebPayDays(11, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Oct_Click(sender As Object, e As System.EventArgs) Handles Oct.Click
    WebPayDays(10, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub

  Protected Sub Sep_Click(sender As Object, e As System.EventArgs) Handles Sep.Click
    WebPayDays(9, SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
  End Sub


  Protected Sub cmdEmp_Click(sender As Object, e As System.EventArgs) Handles cmdEmp.Click
    Dim mPage As Integer = 0
    Dim mSize As Integer = 50
    Dim owpEmps As List(Of SIS.ATN.atnWebPayNewEmp) = SIS.ATN.atnWebPayNewEmp.atnWebPayNewEmpSelectList(mPage, mSize, "CardNo", False, "", "")
    Do While owpEmps.Count > 0
      For Each wpEmp As SIS.ATN.atnWebPayNewEmp In owpEmps
        Dim oEmp As SIS.ATN.atnwpEmployees = Nothing
        oEmp = SIS.ATN.atnwpEmployees.atnwpEmployeesGetByID(wpEmp.CardNo)
        Dim Found As Boolean = True
        If oEmp Is Nothing Then
          oEmp = New SIS.ATN.atnwpEmployees
          Found = False
          With oEmp
            .CardNo = wpEmp.CardNo
            .ActiveState = True
          End With
        End If
        With oEmp
          .C_CompanyID = wpEmp.CostCompany
          .C_DateOfJoining = wpEmp.DOJ
          .C_DepartmentID = wpEmp.Department
          .C_DesignationID = wpEmp.DesignationCode
          .C_DivisionID = wpEmp.Unit
          If wpEmp.SeatingLocation <> "" Then
            Dim tmp() As String = wpEmp.SeatingLocation.Split(" ".ToCharArray)
            .C_OfficeID = tmp(0)
          Else
            .C_OfficeID = 1
          End If
          Try
            .CategoryID = SIS.ATN.taCategories.GetByDescription(wpEmp.Category).CategoryID
          Catch ex As Exception
          End Try
          .DateOfBirth = wpEmp.DOB
          .EMailID = wpEmp.EMail
          .EmployeeName = wpEmp.EmployeeName
          .PFNumber = wpEmp.PFNO
          .PAN = wpEmp.PAN
          .Salute = .Salute
          .Gender = wpEmp.Gender
          Select Case .Gender
            Case "M"
              .Salute = "Mr."
            Case "F"
              .Salute = "Ms."
          End Select
          If .CardNo.StartsWith("9") Then
            .Contractual = True
          End If
          .FatherName = wpEmp.FatherName
        End With
        If Not Found Then
          SIS.ATN.atnwpEmployees.InsertData(oEmp)
          Try
            'Create Event
            Dim oRef As New HRISEvents.wsWebHrAdm1SoapClient
            Dim oEvt As HRISEvents.admITEventTransactions = oRef.EventTransaction
            With oEvt
              .CardNo = oEmp.CardNo
              .EventDate = oEmp.C_DateOfJoining
              .Description = "New Joining: [" & oEmp.CardNo & "] " & oEmp.EmployeeName & vbCrLf
              .Description &= "Date of joining: " & oEmp.C_DateOfJoining
              Try
                .Circular = "Employee ID: " & oEmp.CardNo & vbCrLf
                .Circular &= "Employee Name: " & oEmp.EmployeeName & vbCrLf
                .Circular &= "Company: " & oEmp.FK_HRM_Employees_HRM_Companies.Description & vbCrLf
                .Circular &= "Location: " & oEmp.FK_HRM_Employees_HRM_Offices.Description & vbCrLf
                .Circular &= "Department: " & oEmp.FK_HRM_Employees_HRM_Departments.Description & vbCrLf
                .Circular &= "Designation: " & oEmp.FK_HRM_Employees_HRM_Designations.Description & vbCrLf
              Catch ex As Exception
              End Try
            End With
            oRef.CreateEventTransaction(oEvt)
            'End Of Create Event
          Catch ex As Exception
          End Try
          Try
            'Create Web Login
            Dim oUsr As MembershipUser = Membership.GetUser(oEmp.CardNo)
            If oUsr Is Nothing Then
              Try
                oUsr = Membership.CreateUser(oEmp.CardNo, oEmp.CardNo)
                If Not oUsr Is Nothing Then
                  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
                    Using Cmd As SqlCommand = Con.CreateCommand()
                      Cmd.CommandType = CommandType.StoredProcedure
                      Cmd.CommandText = "spVRUsersUpdate"
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserName", SqlDbType.NVarChar, 21, oEmp.CardNo)
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserFullName", SqlDbType.NVarChar, 51, oEmp.EmployeeName)
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining", SqlDbType.DateTime, 21, IIf(oEmp.C_DateOfJoining = "", Convert.DBNull, oEmp.C_DateOfJoining))
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID", SqlDbType.NVarChar, 7, IIf(oEmp.C_CompanyID = "", Convert.DBNull, oEmp.C_CompanyID))
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID", SqlDbType.NVarChar, 7, IIf(oEmp.C_DivisionID = "", Convert.DBNull, oEmp.C_DivisionID))
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID", SqlDbType.Int, 11, IIf(oEmp.C_OfficeID = "", Convert.DBNull, oEmp.C_OfficeID))
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID", SqlDbType.NVarChar, 7, IIf(oEmp.C_DepartmentID = "", Convert.DBNull, oEmp.C_DepartmentID))
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ProjectSiteID", SqlDbType.NVarChar, 7, IIf(oEmp.C_ProjectSiteID = "", Convert.DBNull, oEmp.C_ProjectSiteID))
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID", SqlDbType.Int, 11, IIf(oEmp.C_DesignationID = "", Convert.DBNull, oEmp.C_DesignationID))
                      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 3, oEmp.ActiveState)
                      Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
                      Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
                      Con.Open()
                      Cmd.ExecuteNonQuery()
                    End Using
                  End Using
                End If
              Catch ex As Exception
              End Try
            End If
            'End of WebLogin
          Catch ex As Exception
          End Try
          Try
            'Creat Perk User
            Dim oPrkEmp As SIS.PRK.PrkEmployees = SIS.PRK.PrkEmployees.GetByID(oEmp.CardNo)
            If oPrkEmp Is Nothing Then
              oPrkEmp = New SIS.PRK.PrkEmployees
              With oPrkEmp
                .EmployeeID = oEmp.CardNo
                .CardNo = oEmp.CardNo
                .EmployeeName = oEmp.EmployeeName
                .DOJ = oEmp.C_DateOfJoining
                .DOR = ""
                .CategoryID = 16
                .Company = "200"
                .Department = "ACC-I"
                .ESI = False
                .MaintenanceAllowed = False
                .PostedAt = "Office"
                .VehicleType = "None"
                .Basic = 0
                SIS.PRK.PrkEmployees.Insert(oPrkEmp)
              End With
            End If
            'End Of Perk User
          Catch ex As Exception

          End Try
        Else
          'Update Data will be tested first
          'SIS.ATN.atnwpEmployees.UpdateData(oEmp)
        End If
      Next
      mPage += msize
      owpEmps = SIS.ATN.atnWebPayNewEmp.atnWebPayNewEmpSelectList(mPage, mSize, "CardNo", False, "", "")
    Loop
  End Sub
  Protected Sub cmdUpload_Click(sender As Object, e As System.EventArgs) Handles cmdUpload.Click
    With atndUpload
      If .HasFile Then

      End If
    End With
  End Sub
End Class
Public Class salDays
  Public Property CardNo As String = ""
  Public Property EmployeeName As String = ""
  Public Property JDT As String = ""
  Public Property RDT As String = ""
  Public Property ActiveState As String = ""
  Public Property Location As String = ""
  Public Property PR_CurrMonth As String = ""
  Public Property currBalDays As String = ""
  Public Property PR_Last1Month As String = ""
  Public Property PD_Last1Month As String = ""
  Public Property Arr_Last1Month As String = ""
  Public Property Wrong_Arr As String = ""
  Public Property LWP_Last1Month As String = ""
  Public Property PR_Last2Month As String = ""
  Public Property PD_Last2Month As String = ""
  Public Property Arr_Last2InLast1 As String = ""
  Public Property Arr_Last2Month As String = ""
  Public Property payCurr As String = ""
  Public Property arrLast As String = ""
  Public Property arr2Last As String = ""
  Public Property ProcessingYear As Integer = 2016
  Public Property ProcessingMonth As Integer = 12
  Public Property MonthDays As Integer = 31
  Public ReadOnly Property FullDay As Decimal
    Get
      Dim doj As DateTime = Convert.ToDateTime(JDT)
      If doj.Month = ProcessingMonth And doj.Year = ProcessingYear Then
        Return MonthDays - doj.Day + 1
      Else
        Return MonthDays
      End If
    End Get
  End Property
  Sub New(ByVal rd As SqlDataReader, ByVal YY As Integer, ByVal MM As Integer)
    On Error Resume Next
    CardNo = rd("CardNo")
    EmployeeName = rd("EmployeeName")
    JDT = rd("JDT")
    RDT = rd("RDT")
    ActiveState = rd("ActiveState")
    Location = rd("Location")
    PR_CurrMonth = rd("PR_CurrMonth")
    currBalDays = rd("currBalDays")
    PR_Last1Month = rd("PR_Last1Month")
    PD_Last1Month = rd("PD_Last1Month")
    Arr_Last1Month = rd("Arr_Last1Month")
    Wrong_Arr = rd("Wrong_Arr")
    LWP_Last1Month = rd("LWP_Last1Month")
    PR_Last2Month = rd("PR_Last2Month")
    PD_Last2Month = rd("PD_Last2Month")
    Arr_Last2InLast1 = rd("Arr_Last2InLast1")
    Arr_Last2Month = rd("Arr_Last2Month")
    payCurr = rd("paycurr")
    arrLast = rd("ArrLast")
    arr2Last = rd("arr2last")
    If Convert.ToDecimal(payCurr) = 0 Then
      If Convert.ToDecimal(arrLast) < 0 Then
        arrLast = 0
      End If
      If Convert.ToDecimal(arr2Last) < 0 Then
        arr2Last = 0
      End If
    End If
    ProcessingYear = YY
    ProcessingMonth = MM
    MonthDays = System.DateTime.DaysInMonth(YY, MM)
  End Sub
End Class
