Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Public Class wResp
    Public Property cfg As SIS.ATN.wConfig = Nothing
    Public Property lpd As String = ""
    Public Property emp As SIS.ATN.wEmp = Nothing
    Public Property err As Boolean = False
    Public Property msg As String = ""
    Public Property id As String = ""
    ''' <summary>
    ''' Current Status of WFH is returned, After Executing ChangeStatus
    ''' </summary>
    ''' <returns></returns>
    Public Property s As Boolean = False
    Public Shared Function GetResp(CardNo As String, cnf As SIS.ATN.WFHConfig, Level As Integer) As SIS.ATN.wResp
      Dim tmp As New SIS.ATN.wResp
      Dim c As New SIS.ATN.wConfig
      c.Assign(cnf)
      tmp.cfg = c
      Dim e As SIS.ATN.wEmp = SIS.ATN.wEmp.GetwEmp(CardNo, cnf, Level)
      If e IsNot Nothing Then
        Dim ce As List(Of SIS.ATN.wEmp) = SIS.ATN.wEmp.GetcEmps(CardNo, cnf, Level + 1)
        'e.c = ce.Count
        e.cEmps = ce
        tmp.emp = e
      End If
      Return tmp
    End Function
    Public Shared Function GetReport(CardNo As String, cnf As SIS.ATN.WFHConfig, Level As Integer) As SIS.ATN.wResp
      Dim tmp As New SIS.ATN.wResp
      Dim c As New SIS.ATN.wConfig
      c.Assign(cnf)
      tmp.cfg = c
      Dim e As SIS.ATN.wEmp = SIS.ATN.wEmp.GetwEmpReport(CardNo, cnf, Level)
      If e IsNot Nothing Then
        Dim ce As List(Of SIS.ATN.wEmp) = SIS.ATN.wEmp.GetcEmpsReport(CardNo, cnf, Level + 1)
        'e.c = ce.Count
        e.cEmps = ce
        tmp.emp = e
      End If
      Return tmp
    End Function
  End Class
  Public Class wConfig
    Public Property sn As Integer = 0
    Public Property fdt As String = ""
    Public Property tdt As String = ""
    Public Property usr As String = ""
    Public Property act As Boolean = False
    Public Sub Assign(cnf As SIS.ATN.WFHConfig)
      With cnf
        sn = .SerialNo
        fdt = .FromDate
        tdt = .ToDate
        usr = .OpenedFor
        act = .Active
      End With
    End Sub
    Public Sub Extract(cnf As SIS.ATN.WFHConfig)
      With cnf
        .SerialNo = sn
        .FromDate = fdt
        .ToDate = tdt
        .OpenedFor = usr
        .Active = act
      End With
    End Sub
  End Class
  Public Class wEmp
    ''' <summary>
    ''' Array of Reporting Employees
    ''' </summary>
    ''' <returns></returns>
    Public Property cEmps As New List(Of SIS.ATN.wEmp)
    ''' <summary>
    ''' Array of Date wise status
    ''' </summary>
    ''' <returns></returns>
    Public Property rsts As New List(Of SIS.ATN.wRst)
    ''' <summary>
    ''' Loading Level, Zero Based
    ''' </summary>
    ''' <returns></returns>
    Public Property lvl As Integer = 0
    ''' <summary>
    ''' Employee Code
    ''' </summary>
    ''' <returns></returns>
    Public Property cno As String = ""
    ''' <summary>
    ''' Roster Status Code
    ''' </summary>
    ''' <returns></returns>
    Public Property rs As Integer = 0
    ''' <summary>
    ''' Employee Name
    ''' </summary>
    ''' <returns></returns>
    Public Property enm As String = ""
    ''' <summary>
    ''' Employee Department
    ''' </summary>
    ''' <returns></returns>
    Public Property dep As String = ""
    ''' <summary>
    ''' Count of Reporting Employees
    ''' </summary>
    ''' <returns></returns>
    Public Property c As Integer = 0
    ''' <summary>
    ''' Last Updated By Name and DateTime
    ''' </summary>
    ''' <returns></returns>
    Public Property h As String = ""
    ''' <summary>
    ''' Status Name
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property rsnm As String
      Get
        Return System.Enum.GetName(GetType(enumRoosterStatus), rs)
      End Get
    End Property
    Public Sub Assign(eRst As SIS.ATN.WFHRooster)
      With eRst
        cno = .CardNo
        rs = .RoosterStatus
        enm = .HRM_Employees1_EmployeeName
        dep = .DepartmentName
      End With
    End Sub
    Public Sub Extract(eRst As SIS.ATN.WFHRooster)
      With eRst
        .CardNo = cno
        .RoosterStatus = rs
        .HRM_Employees1_EmployeeName = enm
        .DepartmentName = dep
      End With
    End Sub
    Public Shared Function GetcEmps(CardNo As String, cnf As SIS.ATN.WFHConfig, Level As Integer) As List(Of SIS.ATN.wEmp)
      Dim emps As New List(Of SIS.ATN.wEmp)
      Dim childs As List(Of SIS.ATN.CardCount) = SIS.ATN.WFHRooster.GetChildEmployees(CardNo, Level)
      For Each chld As SIS.ATN.CardCount In childs
        Dim x As SIS.ATN.wEmp = SIS.ATN.wEmp.GetwEmp(chld.CardNo, cnf, Level)
        If x IsNot Nothing Then
          x.c = chld.Cnt
          emps.Add(x)
        End If
      Next
      Return emps
    End Function
    Public Shared Function GetcEmpsReport(CardNo As String, cnf As SIS.ATN.WFHConfig, Level As Integer) As List(Of SIS.ATN.wEmp)
      Dim emps As New List(Of SIS.ATN.wEmp)
      Dim childs As List(Of SIS.ATN.CardCount) = SIS.ATN.WFHRooster.GetChildEmployees(CardNo, Level, True)
      For Each chld As SIS.ATN.CardCount In childs
        Dim x As New SIS.ATN.wEmp
        x.cno = chld.CardNo
        x.c = chld.Cnt
        x.lvl = Level
        emps.Add(x)
      Next
      Return emps
    End Function

    Public Shared Function GetwEmp(CardNo As String, cnf As SIS.ATN.WFHConfig, Level As Integer) As SIS.ATN.wEmp
      Dim emp As SIS.ATN.wEmp = Nothing
      Dim rsts As List(Of SIS.ATN.WFHRooster) = SIS.ATN.WFHRooster.GetRooster(CardNo, cnf, Level)
      If rsts.Count > 0 Then
        emp = New SIS.ATN.wEmp
        emp.Assign(rsts(0))
        Dim rstH As SIS.ATN.WFHRoosterHistory = Nothing
        rstH = SIS.ATN.WFHRoosterHistory.GetLatestByCardConfig(CardNo, cnf.FromDate, cnf.ToDate)
        If rstH IsNot Nothing Then
          emp.rs = rstH.RoosterStatus
          emp.h = rstH.HRM_Employees1_EmployeeName & " - " & rstH.ModifiedOn
        End If
        For Each rst As SIS.ATN.WFHRooster In rsts
          Dim x As New SIS.ATN.wRst
          x.Assign(rst)
          'Only Latest History for Each Date
          rstH = SIS.ATN.WFHRoosterHistory.GetLatestByCardDate(CardNo, rst.AttenDate)
          If rstH IsNot Nothing Then
            Dim rh As New SIS.ATN.wRstH
            rh.Assign(rstH)
            x.hst.Add(rh)
          End If
          emp.rsts.Add(x)
          emp.lvl = Level
        Next
      End If
      Return emp
    End Function
    Public Shared Function GetwEmpReport(CardNo As String, cnf As SIS.ATN.WFHConfig, Level As Integer) As SIS.ATN.wEmp
      Dim emp As SIS.ATN.wEmp = Nothing
      Dim rsts As List(Of SIS.ATN.WFHRooster) = SIS.ATN.WFHRooster.GetRooster(CardNo, cnf, Level)
      If rsts.Count > 0 Then
        emp = New SIS.ATN.wEmp
        emp.Assign(rsts(0))
        For Each rst As SIS.ATN.WFHRooster In rsts
          Dim x As New SIS.ATN.wRst
          x.Assign(rst)
          emp.rsts.Add(x)
          emp.lvl = Level
        Next
      End If
      Return emp
    End Function
  End Class
  Public Class wRst
    Public Property adt As String = ""
    Public Property nw As Boolean = False
    Public Property wf As Boolean = False
    Public Property ws As Boolean = False
    Public Property wd As Boolean = False
    Public Property en As Boolean = False
    Public Property hst As New List(Of SIS.ATN.wRstH) 'Update Hostory

    Public Sub Assign(rst As SIS.ATN.WFHRooster)
      With rst
        adt = .AttenDate
        nw = .NonWorkingDay
        wf = .WFH1stHalf
        ws = .WFH2ndHalf
        wd = .WFHFullDay
        en = .EmployeeNotActive
      End With
    End Sub
    Public Sub Extract(rst As SIS.ATN.WFHRooster)
      With rst
        .AttenDate = adt
        .NonWorkingDay = nw
        .WFH1stHalf = wf
        .WFH2ndHalf = ws
        .WFHFullDay = wd
        .EmployeeNotActive = en
      End With
    End Sub

  End Class
  Public Class wRstH
    Public Property sn As Integer = 0
    Public Property nw As Boolean = False
    Public Property wf As Boolean = False
    Public Property ws As Boolean = False
    Public Property wd As Boolean = False
    Public Property en As Boolean = False
    Public Property rs As Integer = 0
    Public Property mu As String = ""
    Public Property munm As String = ""
    Public Property md As String = ""
    Public Property mr As String = ""
    Public ReadOnly Property rsnm As String
      Get
        Return System.Enum.GetName(GetType(enumRoosterStatus), rs)
      End Get
    End Property
    Public ReadOnly Property h As String
      Get
        Return munm & " - " & md
      End Get
    End Property
    Public Sub Extract(rst As SIS.ATN.WFHRoosterHistory)
      With rst
        .SerialNo = sn
        .NonWorkingDay = nw
        .WFH1stHalf = wf
        .WFH2ndHalf = ws
        .WFHFullDay = wd
        .EmployeeNotActive = en
        .RoosterStatus = rs
        .ModifiedBy = mu
        .HRM_Employees1_EmployeeName = munm
        .ModifiedOn = md
        .ModifierRemarks = mr
      End With
    End Sub
    Public Sub Assign(rst As SIS.ATN.WFHRoosterHistory)
      With rst
        sn = .SerialNo
        nw = .NonWorkingDay
        wf = .WFH1stHalf
        ws = .WFH2ndHalf
        wd = .WFHFullDay
        en = .EmployeeNotActive
        rs = .RoosterStatus
        mu = .ModifiedBy
        munm = .HRM_Employees1_EmployeeName
        md = .ModifiedOn
        mr = .ModifierRemarks
      End With
    End Sub

  End Class

End Namespace

