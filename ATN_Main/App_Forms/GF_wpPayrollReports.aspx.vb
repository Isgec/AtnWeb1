Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Partial Class GF_wpPayrollReports
  Inherits SIS.SYS.GridBase
  Protected Sub TBLatnEmployeeConfiguration_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnEmployeeConfiguration.Init
    SetToolBar = TBLatnEmployeeConfiguration
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_Month.SelectedValue = IIf(Now.Month <> 1, Now.Month - 1, 12)
  End Sub
#Region " PF Loan Report "
  Protected Sub cmdPFLoanReport_Click(sender As Object, e As System.EventArgs) Handles cmdPFLoanReport.Click
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    '================

    Dim ForMonth As String = ""
    Dim ForYear As String = ""
    Try
      ForMonth = F_Month.SelectedValue
      ForYear = F_Year.SelectedValue
    Catch ex As Exception
    End Try
    If ForMonth = String.Empty Then Return
    Dim DWFile As String = "PFLoan_" & ForMonth & "_" & ForYear
    Dim FilePath As String = CreateFile(ForMonth, ForYear)
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx" & """")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreateFile(ByVal ForMonth As String, ByVal ForYear As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\PFLoan_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")


    Dim oDocs As List(Of SIS.ATN.LGPFLoanView) = SIS.ATN.LGPFLoanView.LGPFLoanViewSelectList(0, 999, "", False, "", "", ForMonth, ForYear)

    Dim r As Integer = 6
    Dim c As Integer = 1
    Dim tc As Integer = 7
    With xlWS
      .Cells(2, 2).Value = ForMonth
      .Cells(3, 2).Value = ForYear

      For Each doc As SIS.ATN.LGPFLoanView In oDocs
        If r > 6 Then xlWS.InsertRow(r, 1, r + 1)
        c = 1
        .Cells(r, c).Value = doc.CardNo.Trim
        c += 1
        .Cells(r, c).Value = doc.EmployeeName
        c += 1
        .Cells(r, c).Value = Convert.ToDecimal(doc.InstallmentAmount)
        c += 1
        .Cells(r, c).Value = Convert.ToDecimal(doc.PaidPrincipal)
        c += 1
        .Cells(r, c).Value = Convert.ToDecimal(doc.PaidInterest)
        c += 1
        .Cells(r, c).Value = Convert.ToDecimal(doc.BalancePrincipal)
        r += 1
      Next
      .Cells(r + 1, 5).Formula = "=SUM(E6:E" & r - 1 & ")"
      .Cells(r + 1, 4).Formula = "=SUM(D6:D" & r - 1 & ")"
      .Cells(r + 1, 3).Formula = "=SUM(C6:C" & r - 1 & ")"
      .Cells(r + 1, 6).Formula = "=SUM(F6:F" & r - 1 & ")"
    End With
    xlPk.Save()
    xlPk.Dispose()

    Return FileName
  End Function

#End Region

#Region " PF Statement "
  Protected Sub cmdPFStatement_Click(sender As Object, e As System.EventArgs) Handles cmdPFStatement.Click
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    '================

    Dim ForMonth As String = ""
    Dim ForYear As String = ""
    Try
      ForMonth = F_Month.SelectedValue
      ForYear = F_Year.SelectedValue
    Catch ex As Exception
    End Try
    If ForMonth = String.Empty Then Return
    Dim DWFile As String = "PFStatement_" & ForMonth & "_" & ForYear
    Dim FilePath As String = CreatePFStatement(ForMonth, ForYear)
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx" & """")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreatePFStatement(ByVal ForMonth As String, ByVal ForYear As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\PFStatement_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")

    Dim r As Integer = 7
    Dim c As Integer = 1

    Dim aFld() As String
    ReDim aFld(0)
    Do While xlWS.Cells(r, c).Text <> String.Empty
      ReDim Preserve aFld(c - 1)
      aFld(c - 1) = xlWS.Cells(r, c).Text
      c += 1
    Loop
    Dim oDocs As List(Of PFStatement) = PFStatement.GetPFStatement(ForMonth, ForYear)
    With xlWS
      .Cells(2, 2).Value = ForMonth
      .Cells(3, 2).Value = ForYear
      For Each doc As PFStatement In oDocs
        If r > 7 Then xlWS.InsertRow(r, 1, r + 1)
        For c = 0 To aFld.Length
          Try
            .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
          Catch ex As Exception
          End Try
        Next
        r += 1
      Next
    End With
    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function
  Public Class PFStatement
    Public Property srNo As String = ""
    Public Property Pk_emp_Code As String = ""
    Public Property Pf_no As String = ""
    Public Property EmpName As String = ""
    Public Property PaidDays As String = ""
    Public Property LOP As String = ""
    Public Property Pfgross As String = ""
    Public Property ArrPFGross As String = ""
    Public Property PensionWages As String = ""
    Public Property ArrPenWages As String = ""
    Public Property Pf As String = ""
    Public Property ArrPf As String = ""
    Public Property Volpf As String = ""
    Public Property Arr_vpf As String = ""
    Public Property ETotal As String = ""
    Public Property Ac1 As String = ""
    Public Property ArrAc1 As String = ""
    Public Property Ac10 As String = ""
    Public Property ArrAC10 As String = ""
    Public Property ERTotal As String = ""
    Public Property Ac2 As String = ""
    Public Property Ac21 As String = ""
    Public Property Ac22 As String = ""
    Public Property Pension_no As String = ""
    Public Property UanNo As String = ""
    Public Property TotalofEmployeeandEmployerContribution As String = ""
    Public Property SeinerCitizen As String = ""
    Public Property ExpatEmployee As String = ""
    Public Property Age As String = ""
    Public Property EmpStatus As String = ""
    Public ReadOnly Property LG_PensionWages As Decimal
      Get
        Try
          Return Convert.ToDecimal(PensionWages) + Convert.ToDecimal(ArrPenWages)
        Catch ex As Exception
          Return 0
        End Try
      End Get
    End Property
    Public ReadOnly Property LG_PfGross As Decimal
      Get
        Try
          Return Convert.ToDecimal(Pfgross) + Convert.ToDecimal(ArrPFGross)
        Catch ex As Exception
          Return 0
        End Try
      End Get
    End Property
    Public ReadOnly Property LG_PF As Decimal
      Get
        Try
          Return Convert.ToDecimal(Pf) + Convert.ToDecimal(ArrPf)
        Catch ex As Exception
          Return 0
        End Try
      End Get
    End Property
    Public ReadOnly Property LG_VolPF As Decimal
      Get
        Try
          Return Convert.ToDecimal(Volpf) + Convert.ToDecimal(Arr_vpf)
        Catch ex As Exception
          Return 0
        End Try
      End Get
    End Property
    Public ReadOnly Property LG_AC1 As Decimal
      Get
        Try
          Return Convert.ToDecimal(Ac1) + Convert.ToDecimal(ArrAc1)
        Catch ex As Exception
          Return 0
        End Try
      End Get
    End Property
    Public ReadOnly Property LG_AC10 As Decimal
      Get
        Try
          Return Convert.ToDecimal(Ac10) + Convert.ToDecimal(ArrAC10)
        Catch ex As Exception
          Return 0
        End Try
      End Get
    End Property
    Public Shared Function GetPFStatement(ByVal ForMonth As Integer, ByVal ForYear As String) As List(Of PFStatement)
      Dim Results As List(Of PFStatement) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWebPayConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "LG_spPFStatement"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.Int, 2, ForMonth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForYear", SqlDbType.NVarChar, 4, ForYear)
          Results = New List(Of PFStatement)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New PFStatement(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
  End Class

#End Region

#Region " Employee Details "

  Protected Sub cmdEmpList_Click(sender As Object, e As System.EventArgs) Handles cmdEmpList.Click
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    Dim DWFile As String = "EmpList_" & Now.ToString("dd-MM-yyyy")
    Dim FilePath As String = CreateEmpList()
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx" & """")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreateEmpList() As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\EmpList_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")

    Dim r As Integer = 4
    Dim c As Integer = 1

    Dim aFld() As String
    ReDim aFld(0)
    Do While xlWS.Cells(r, c).Text <> String.Empty
      ReDim Preserve aFld(c - 1)
      aFld(c - 1) = xlWS.Cells(r, c).Text
      c += 1
    Loop
    Dim oDocs As List(Of EmpList) = EmpList.GetEmpList()
    With xlWS
      For Each doc As EmpList In oDocs
        If r > 4 Then xlWS.InsertRow(r, 1, r + 1)
        For c = 0 To aFld.Length
          Try
            .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
          Catch ex As Exception
          End Try
        Next
        r += 1
      Next
    End With
    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function
  Private Class EmpList
    Public Property CardNo As String = ""
    Public Property Salute As String = ""
    Public Property Gender As String = ""
    Public Property EmployeeName As String = ""
    Public Property FatherName As String = ""
    Public Property CostCompany As String = ""
    Public Property Unit As String = ""
    Public Property Category As String = ""
    Public Property Designation As String = ""
    Public Property DOB As String = ""
    Public Property DOJ As String = ""
    Public Property DOL As String = ""
    Public Property EMail As String = ""
    Public Property PFNo As String = ""
    Public Property PAN As String = ""
    Public Property Department As String = ""
    Public Property Finalized As String = ""
    Public Property PensionNo As String = ""
    Public Property SeatingLocation As String = ""
    Public Shared Function GetEmpList() As List(Of EmpList)
      Dim Results As List(Of EmpList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from ATN_WebPayNewEmp"
          Results = New List(Of EmpList)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New EmpList(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
  End Class
#End Region

#Region " Loan Report "

  Protected Sub cmdLoanReport_Click(sender As Object, e As System.EventArgs) Handles cmdLoanReport.Click
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    '================

    Dim ForMonth As String = ""
    Dim ForYear As String = ""
    Try
      ForMonth = F_Month.SelectedValue
      ForYear = F_Year.SelectedValue
    Catch ex As Exception
    End Try
    If ForMonth = String.Empty Then Return
    Dim DWFile As String = "LoanReport_" & ForMonth & "_" & ForYear
    Dim FilePath As String = CreateLoanReport(ForMonth, ForYear)
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx" & """")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreateLoanReport(ByVal ForMonth As String, ByVal ForYear As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\LoanReport_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")

    Dim r As Integer = 5
    Dim c As Integer = 1

    Dim aFld() As String
    ReDim aFld(0)
    Do While xlWS.Cells(r, c).Text <> String.Empty
      ReDim Preserve aFld(c - 1)
      aFld(c - 1) = xlWS.Cells(r, c).Text
      c += 1
    Loop
    Dim oDocs As List(Of LoanReport) = LoanReport.GetData(ForMonth, ForYear)
    With xlWS
      .Cells(2, 2).Value = ForMonth
      .Cells(3, 2).Value = ForYear
      For Each doc As LoanReport In oDocs
        If r > 5 Then xlWS.InsertRow(r, 1, r + 1)
        For c = 0 To aFld.Length
          Try
            .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
          Catch ex As Exception
          End Try
        Next
        r += 1
      Next
    End With
    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function

  Public Class LoanReport
    Public Property EmployeeName As String = ""
    Public Property LoanName As String = ""
    Public Property TransID As String = ""
    Public Property CardNo As String = ""
    Public Property LoanCode As String = ""
    Public Property LoanDate As String = ""
    Public Property PrincipalAmount As Decimal = 0
    Public Property LoanMonth As String = ""
    Public Property LoanYear As String = ""
    Public Property LoanInterest As Decimal = 0
    Public Property LoanInstallment As Decimal = 0
    Public Property NoOfInstallments As Decimal = 0
    Public Property PaidAmount As Decimal = 0
    Public Property PaidMonths As Decimal = 0
    Public Property Division As String = ""
    Public Property Designation As String = ""
    Public Property Department As String = ""
    Public Property PaidPrincipal As Decimal = 0
    Public Property PaidInterest As Decimal = 0
    Public ReadOnly Property BalancePrincipal As Decimal
      Get
        Return PrincipalAmount - PaidPrincipal
      End Get
    End Property
    Public Shared Function GetData(ByVal ForMonth As Integer, ByVal ForYear As String) As List(Of LoanReport)
      Dim Sql As String = "Select "
      Sql &= "	first_name	As 	EmployeeName	,	"
      Sql &= "	pay_desc	As 	LoanName	,	"
      Sql &= "	Pk_TransId	As 	TransID	,	"
      Sql &= "	fk_emp_code	As 	CardNo	,	"
      Sql &= "	fk_pay_code	As 	LoanCode	,	"
      Sql &= "	tarn_date	As 	LoanDate	,	"
      Sql &= "	principal	As 	PrincipalAmount	,	"
      Sql &= "	curr_mm	As 	LoanMonth	,	"
      Sql &= "	curr_yy	As 	LoanYear	,	"
      Sql &= "	interest	As 	LoanInterest	,	"
      Sql &= "	installment	As 	LoanInstallment	,	"
      Sql &= "	no_ofInstallment	As 	NoOfInstallments	,	"
      Sql &= "	Sum(InstallAmt) 	As 	PaidAmount	,	"
      Sql &= "	Sum(isnull(PaidPrinc,InstallAmt)) 	As 	PaidPrincipal	,	"
      Sql &= "	Sum(isnull(PaidIntrest,0)) 	As 	PaidInterest	,	"
      Sql &= "	count(Paymonth)	As 	PaidMonths	,	"
      Sql &= "	fk_costcenter_code	As 	Division	,	"
      Sql &= "	desig_desc	As 	Designation	,	"
      Sql &= "	fk_DomiclieCode	As 	Department		"
      Sql &= "	  FROM [ISGEC].[dbo].[LG_AllLoan]  group by 				"
      Sql &= "	first_name	,			"
      Sql &= "	pay_desc	,			"
      Sql &= "	Pk_TransId	,			"
      Sql &= "	fk_emp_code	,			"
      Sql &= "	fk_pay_code	,			"
      Sql &= "	tarn_date	,			"
      Sql &= "	principal	,			"
      Sql &= "	curr_mm	,			"
      Sql &= "	curr_yy	,			"
      Sql &= "	interest	,			"
      Sql &= "	installment	,			"
      Sql &= "	no_ofInstallment	,			"
      Sql &= "	fk_costcenter_code	,			"
      Sql &= "	desig_desc	,			"
      Sql &= "	fk_DomiclieCode				"

      Dim Results As List(Of LoanReport) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWebPayConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of LoanReport)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New LoanReport(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Dim dType As System.Type = pi.GetType
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                If pi.PropertyType.GetType.Name = "Decimal" Then
                  CallByName(Me, pi.Name, CallType.Let, 0)
                Else
                  CallByName(Me, pi.Name, CallType.Let, String.Empty)
                End If
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
  End Class
#End Region

  Protected Sub cmdUpdatePF(s As Object, e As EventArgs)
    Dim ForMonth As String = ""
    Dim ForYear As String = ""
    Dim ReBackup As Boolean = False
    Dim CardNo As String = ""
    Try
      ForMonth = F_Month.SelectedValue
      ForYear = F_Year.SelectedValue
      ReBackup = F_Backup.Checked
      CardNo = F_CardNo.Text
    Catch ex As Exception
    End Try
    If ForMonth = String.Empty Then Return

    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWebPayConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "LG_PF_Update"
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@f_month", SqlDbType.Int, 10, ForMonth)
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@f_year", SqlDbType.Int, 10, ForYear)
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@f_emp", SqlDbType.NVarChar, 8, CardNo)
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@f_rebackup", SqlDbType.Bit, 3, ReBackup)
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
    End Using

  End Sub

End Class

