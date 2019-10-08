Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Partial Class Print_abs
  Inherits System.Web.UI.Page

  Private Sub Print_abs_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Dim Mon As String = ""
    Dim Yr As String = ""
    If Request.QueryString("mon") IsNot Nothing Then
      Mon = Request.QueryString("mon")
    End If
    If Mon = "" Then Exit Sub
    Yr = HttpContext.Current.Session("FinYear")

    Dim slab1 As slabs = slabs.getSlabs(1, Mon, Yr)
    Dim slab4 As slabs = slabs.getSlabs(4, Mon, Yr)
    Dim slab5 As slabs = slabs.getSlabs(5, Mon, Yr)
    Dim retStr As String = ""

    retStr &= "  <script src='/../UserRights/jq3.3/jquery-3.3.1.min.js'></script>"
    retStr &= "  <link href='App_Resources/fa-5.9.0/css/all.css' rel='stylesheet' />"
    retStr &= "  <link rel='stylesheet' href='/../UserRights/bs4.0/css/bootstrap.min.css' />"
    retStr &= "  <script src='/../UserRights/Popper1.0/Popper.min.js'></script>"
    retStr &= "  <script src='/../UserRights/bs4.0/js/bootstrap.min.js'></script>"
    retStr &= "  <style> body{font-family:Tahoma;font-size:small;} .lgsm{font-family:Tahoma;font-size:small;}</style>"

    HttpContext.Current.Response.Write(retStr)
    HttpContext.Current.Response.Flush()
    retStr = "<div class='container text-center'><u><h2>Absent on Holiday</h2></u></div>"
    retStr &= "<div class='container text-center'><h3>" & Mon & "/" & Yr & "</h3></div>"
    HttpContext.Current.Response.Write(retStr)
    HttpContext.Current.Response.Flush()

    Dim xCnt As Integer = 0
    Dim emps As New List(Of Emp)
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select CardNo,EmployeeName, isnull(c_officeID,'1') as c_officeid, isnull(c_departmentid,'') as empdept, isnull(c_divisionid,'') as empdiv  from hrm_employees where activestate=1"
        Con.Open()
        Dim rd As SqlDataReader = Cmd.ExecuteReader
        While rd.Read
          emps.Add(New Emp(rd("cardno"), rd("employeename"), rd("c_officeid"), rd("empdept"), rd("empdiv")))
        End While
      End Using
    End Using
    For Each xemp As Emp In emps
      Dim slb As slabs = Nothing
      Select Case xemp.OfficeID
        Case "1"
          slb = slab1
        Case "4"
          slb = slab4
        Case "5"
          slb = slab5
      End Select
      Dim totFV As Integer = slb.Dates.Count
      Dim atnFV As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(sum(finalvalue),0) as fv from atn_attendance WHERE cardno='" & xemp.CardNo & "' and attendate in(" & slb.getSqlInClause & ")"
          Con.Open()
          atnFV = Cmd.ExecuteScalar
        End Using
      End Using
      If atnFV = 0 Then Continue For
      Dim atns As New List(Of atn)
      If atnFV < totFV Then
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select cardno, attendate as adt, punchstatusid as ps, applied as ap, finalvalue as fv, isnull(applied1leavetypeid,'-') as ap1, isnull(applied2leavetypeid,'-') as ap2 from atn_attendance WHERE cardno='" & xemp.CardNo & "' and attendate in(" & slb.getSqlInClause & ")"
            Con.Open()
            Dim rd As SqlDataReader = Cmd.ExecuteReader
            While rd.Read
              atns.Add(New atn(rd("cardno"), rd("adt"), rd("ps"), rd("ap"), rd("fv"), rd("ap1"), rd("ap2")))
            End While
          End Using
        End Using
        Dim ADonWO As Boolean = False
        For Each xatn As atn In atns
          If xatn.finalValue = 0 AndAlso slb.IsHoliday(xatn.atndate) Then
            ADonWO = True
            Exit For
          End If
        Next
        If Not ADonWO Then Continue For
        '====
        Dim prAvbl As Boolean = False
        Dim I As Integer = 0
        For I = 0 To atns.Count - 1
          Dim xAtn As atn = atns(I)
          If xAtn.finalValue = 0 AndAlso slb.IsHoliday(xAtn.atndate) Then
            Dim p1Atn As atn = Nothing
            Try
              p1Atn = atns(I - 1)
            Catch ex As Exception
            End Try
            If p1Atn IsNot Nothing Then
              If Not slb.IsHoliday(p1Atn.atndate) Then
                If p1Atn.finalValue = 1 Then
                  prAvbl = True
                  xAtn.Flagged = True
                End If
              Else
                Dim p2Atn As atn = Nothing
                Try
                  p2Atn = atns(I - 2)
                Catch ex As Exception
                End Try
                If p2Atn IsNot Nothing Then
                  If p2Atn.finalValue = 1 Then
                    prAvbl = True
                    xAtn.Flagged = True
                  End If
                End If
              End If
            End If
            If Not prAvbl Then
              Dim n1Atn As atn = Nothing
              Try
                n1Atn = atns(I + 1)
              Catch ex As Exception
              End Try
              If n1Atn IsNot Nothing Then
                If Not slb.IsHoliday(n1Atn.atndate) Then
                  If n1Atn.finalValue = 1 Then
                    prAvbl = True
                    xAtn.Flagged = True
                  End If
                Else
                  Dim n2Atn As atn = Nothing
                  Try
                    n2Atn = atns(I + 2)
                  Catch ex As Exception
                  End Try
                  If n2Atn IsNot Nothing Then
                    If n2Atn.finalValue = 1 Then
                      prAvbl = True
                      xAtn.Flagged = True
                    End If
                  End If
                End If
              End If
            End If
          End If
        Next
        If Not prAvbl Then Continue For
        'Render it
        retStr = ""
        'Build str
        retStr &= "<div class='container-fluid text-center'>"
        retStr &= "<div class='row btn-info'>"
        retStr &= "  <div class='col'>"
        retStr &= "  " & xemp.CardNo
        retStr &= "  </div>"
        retStr &= "  <div class='col'>"
        retStr &= "  " & xemp.EmpName
        retStr &= "  </div>"
        retStr &= "  <div class='col'>"
        retStr &= "  " & xemp.EmpDiv
        retStr &= "  </div>"
        retStr &= "  <div class='col'>"
        retStr &= "  " & xemp.EmpDept
        retStr &= "  </div>"
        retStr &= "  <div class='col'>"
        retStr &= "  " & xemp.OfficeID
        retStr &= "  </div>"
        retStr &= "</div>"
        retStr &= "<div class='row'>"
        For Each atnd As atn In atns
          If atnd.Flagged Then
            retStr &= "  <div class='col btn btn-danger'>"
          Else
            retStr &= "  <div class='col btn btn-outline-success'>"
          End If
          retStr &= "     <table class='lgsm' style='border-collapse:collapse;border:none;'>"
          retStr &= "       <tr>"
          retStr &= "         <td colspan='2' style='text-align:center;'>"
          If slb.IsHoliday(atnd.atndate) Then retStr &= "           <b>"
          retStr &= "             " & Convert.ToDateTime(atnd.atndate).ToString("dd/MM")
          If slb.IsHoliday(atnd.atndate) Then retStr &= "           </b>"
          retStr &= "         </td>"
          retStr &= "       </tr>"
          retStr &= "       <tr>"
          retStr &= "         <td colspan='2' style='text-align:center;'>"
          retStr &= "             " & atnd.punchStatus
          retStr &= "         </td>"
          retStr &= "       </tr>"
          retStr &= "       <tr>"
          retStr &= "         <td>"
          retStr &= "             " & atnd.LT1
          retStr &= "         </td>"
          retStr &= "         <td>"
          retStr &= "             " & atnd.LT2
          retStr &= "         </td>"
          retStr &= "       </tr>"
          retStr &= "     </table>"
          retStr &= "  </div>"
        Next
        retStr &= "</div>"
        retStr &= "</div>"
        Try
          HttpContext.Current.Response.Write(retStr)
          HttpContext.Current.Response.Flush()
          xCnt += 1
        Catch ex As Exception
          Exit Sub
        End Try
      End If
    Next 'For each Employee
    retStr = "<div class='container text-center'><h2>End of report</h2></div>"
    retStr &= "<div class='container text-center'><h3>" & xCnt & " Records</h3></div>"
    HttpContext.Current.Response.Write(retStr)
    HttpContext.Current.Response.Flush()
    HttpContext.Current.Response.End()
  End Sub
  Public Class atn
    Public Property CardNo As String = ""
    Public Property atndate As String = ""
    Public Property punchStatus As String = ""
    Public Property Applied As Boolean = False
    Public Property finalValue As Integer = 0
    Public Property Flagged As Boolean = False
    Public Property LT1 As String = ""
    Public Property LT2 As String = ""
    Public Sub New(ByVal c As String, ByVal adt As String, ByVal ps As String, ByVal ap As String, ByVal fv As String, ByVal ap1 As String, ByVal ap2 As String)
      CardNo = c
      atndate = adt
      punchStatus = ps
      Applied = ap
      finalValue = fv
      LT1 = ap1
      LT2 = ap2
      'If Convert.ToDateTime(atndate).DayOfWeek = DayOfWeek.Saturday Or Convert.ToDateTime(atndate).DayOfWeek = DayOfWeek.Sunday Then
      '  isHolidaye = True
      'End If
    End Sub
  End Class
  Public Class Emp
    Public Property CardNo As String = ""
    Public Property EmpName As String = ""
    Public Property EmpDept As String = ""
    Public Property EmpDiv As String = ""
    Public Property OfficeID As String = ""
    Public Sub New(ByVal c As String, ByVal n As String, ByVal o As String, ByVal dp As String, ByVal dv As String)
      CardNo = c
      Select Case o
        Case "4", "5"
          OfficeID = o
        Case Else
          OfficeID = "1"
      End Select
      EmpName = n
      EmpDept = dp
      EmpDiv = dv
    End Sub
  End Class
  Public Class slabs
    Public Property OfficeID As Integer = 0
    Public Property Mon As String = ""
    Public Property Yr As String = ""
    Private _dates As New List(Of slabDt)
    Public Function IsHoliday(ByVal dt As String) As Boolean
      Dim mRet As Boolean = False
      For Each xt As slabDt In Dates
        If xt.holiDate = dt Then
          Return xt.isHoliday
        End If
      Next
      Return mRet
    End Function
    Public Property Dates As List(Of slabDt)
      Get
        Return _dates
      End Get
      Set(value As List(Of slabDt))
        _dates = value
      End Set
    End Property
    Public Function getSqlInClause() As String
      Dim mRet As String = ""
      For Each x As slabDt In _dates
        If mRet = "" Then mRet = "convert(datetime,'" & x.holiDate & "',103)" Else mRet = mRet & ", convert(datetime,'" & x.holiDate & "',103)"
      Next
      Return mRet
    End Function
    Public Shared Function getSlabs(ByVal OfficeID As Integer, ByVal Mon As String, ByVal yr As String) As slabs
      Dim mRet As New slabs
      Dim L_Mon As String = Mon
      Dim L_Yr As String = yr
      If Convert.ToInt32(Mon) = 1 Then
        L_Mon = "12"
        L_Yr = Convert.ToInt32(yr) - 1
      Else
        L_Mon = (Convert.ToInt32(Mon) - 1).ToString.PadLeft(2, "0")
      End If
      Dim sDt As String = "22/" & L_Mon & "/" & L_Yr
      Dim eDt As String = "21/" & Mon & "/" & yr
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from atn_holidays WHERE (Holiday >= CONVERT(datetime, '" & sDt & "', 103)) AND (Holiday <= CONVERT(datetime, '" & eDt & "', 103)) AND (OfficeID = " & OfficeID & ")"
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            Dim tmp As slabDt = New slabDt(rd("Holiday"))
            tmp.isHoliday = True
            mRet.Dates.Add(tmp)
          End While
        End Using
      End Using
      mRet.OfficeID = OfficeID
      mRet.Mon = Mon
      mRet.Yr = yr
      'Add Additional Days To check
      Dim addDates As New List(Of slabDt)
      For Each sldt As slabDt In mRet.Dates
        Dim xDt As String = ""
        xDt = (Convert.ToDateTime(sldt.holiDate).AddDays(-1)).ToString("dd/MM/yyyy")
        Dim Found As Boolean = False
        Dim stage As Integer = 0
        stage = 1
        GoTo checkDate
continue1:
        If Not Found Then
          addDates.Add(New slabDt(xDt))
        End If
        xDt = (Convert.ToDateTime(sldt.holiDate).AddDays(1)).ToString("dd/MM/yyyy")
        Found = False
        stage = 2
        GoTo checkDate
continue2:
        If Not Found Then
          addDates.Add(New slabDt(xDt))
        End If
        GoTo checkEnd
checkDate:
        For Each x As slabDt In mRet.Dates
          If x.holiDate = xDt Then
            Found = True
            Exit For
          End If
        Next
        If Not Found Then
          For Each x As slabDt In addDates
            If x.holiDate = xDt Then
              Found = True
              Exit For
            End If
          Next
        End If
        If stage = 1 Then GoTo continue1
        If stage = 2 Then GoTo continue2
checkEnd:
      Next
      mRet.Dates.AddRange(addDates)
      Return mRet
    End Function
  End Class
  Public Class slabDt
    Public Property holiDate As String = ""
    Public Property isHoliday As Boolean = False
    Public ReadOnly Property sqlDt As String
      Get
        Return " convert(datetime,'" & holiDate & "',103) "
      End Get
    End Property
    Sub New(ByVal dt As String)
      holiDate = dt
    End Sub
    Sub New()

    End Sub
  End Class
End Class
