Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnSiteAttendance
    Private Shared _RecordCount As Integer
    Private _FinYear As String = ""
    Private _MonthID As Int32 = 0
    Private _CardNo As String = ""
    Private _VD01 As String = ""
    Private _VD02 As String = ""
    Private _VD03 As String = ""
    Private _VD04 As String = ""
    Private _VD05 As String = ""
    Private _VD06 As String = ""
    Private _VD07 As String = ""
    Private _VD08 As String = ""
    Private _VD09 As String = ""
    Private _VD10 As String = ""
    Private _VD11 As String = ""
    Private _VD12 As String = ""
    Private _VD13 As String = ""
    Private _VD14 As String = ""
    Private _VD15 As String = ""
    Private _VD16 As String = ""
    Private _VD17 As String = ""
    Private _VD18 As String = ""
    Private _VD19 As String = ""
    Private _VD20 As String = ""
    Private _VD21 As String = ""
    Private _VD22 As String = ""
    Private _VD23 As String = ""
    Private _VD24 As String = ""
    Private _VD25 As String = ""
    Private _VD26 As String = ""
    Private _VD27 As String = ""
    Private _VD28 As String = ""
    Private _VD29 As String = ""
    Private _VD30 As String = ""
    Private _VD31 As String = ""
    Private _SN04 As String = ""
    Private _SN09 As String = ""
    Private _SN08 As String = ""
    Private _SN10 As String = ""
    Private _SN06 As String = ""
    Private _SN07 As String = ""
    Private _SN11 As String = ""
    Private _SN12 As String = ""
    Private _SN13 As String = ""
    Private _SN05 As String = ""
    Private _PD29 As String = ""
    Private _PD30 As String = ""
    Private _PD31 As String = ""
    Private _SN03 As String = ""
    Private _SN26 As String = ""
    Private _SN02 As String = ""
    Private _SN01 As String = ""
    Private _SN14 As String = ""
    Private _SN28 As String = ""
    Private _SN25 As String = ""
    Private _SN31 As String = ""
    Private _PD28 As String = ""
    Private _SN15 As String = ""
    Private _SN27 As String = ""
    Private _SN29 As String = ""
    Private _SN30 As String = ""
    Private _SN24 As String = ""
    Private _SN18 As String = ""
    Private _SN19 As String = ""
    Private _SN16 As String = ""
    Private _SN17 As String = ""
    Private _SN22 As String = ""
    Private _SN23 As String = ""
    Private _SN20 As String = ""
    Private _SN21 As String = ""
    Private _AD14 As String = ""
    Private _AD13 As String = ""
    Private _AD16 As String = ""
    Private _AD15 As String = ""
    Private _AD10 As String = ""
    Private _AD09 As String = ""
    Private _AD12 As String = ""
    Private _AD11 As String = ""
    Private _AD22 As String = ""
    Private _AD21 As String = ""
    Private _AD24 As String = ""
    Private _AD23 As String = ""
    Private _AD18 As String = ""
    Private _AD17 As String = ""
    Private _AD20 As String = ""
    Private _AD19 As String = ""
    Private _AD04 As String = ""
    Private _PostedOn As String = ""
    Private _PD27 As String = ""
    Private _AD03 As String = ""
    Private _ApproverRemarks As String = ""
    Private _ApprovedOn As String = ""
    Private _AD06 As String = ""
    Private _PD13 As String = ""
    Private _AD07 As String = ""
    Private _AD05 As String = ""
    Private _ApprovedBy As String = ""
    Private _PostedBy As String = ""
    Private _AD08 As String = ""
    Private _PD12 As String = ""
    Private _PostingRemarks As String = ""
    Private _SAStatusID As String = ""
    Private _ATNStatusID As String = ""
    Private _AD02 As String = ""
    Private _PD11 As String = ""
    Private _AD01 As String = ""
    Private _PD15 As String = ""
    Private _PD18 As String = ""
    Private _PD17 As String = ""
    Private _PD16 As String = ""
    Private _PD14 As String = ""
    Private _PD24 As String = ""
    Private _PD23 As String = ""
    Private _PD26 As String = ""
    Private _PD25 As String = ""
    Private _PD20 As String = ""
    Private _PD19 As String = ""
    Private _PD22 As String = ""
    Private _PD21 As String = ""
    Private _PD10 As String = ""
    Private _AD30 As String = ""
    Private _AD29 As String = ""
    Private _PD01 As String = ""
    Private _AD31 As String = ""
    Private _AD26 As String = ""
    Private _AD25 As String = ""
    Private _AD28 As String = ""
    Private _AD27 As String = ""
    Private _PD07 As String = ""
    Private _PD06 As String = ""
    Private _PD09 As String = ""
    Private _PD08 As String = ""
    Private _PD03 As String = ""
    Private _PD02 As String = ""
    Private _PD05 As String = ""
    Private _PD04 As String = ""
    Private _VerifierRemarks As String = ""
    Private _VerifiedBy As String = ""
    Private _VerifiedOn As String = ""
    Private _ATN_ApplicationStatus1_Description As String = ""
    Private _ATN_FinYear2_Description As String = ""
    Private _ATN_Months3_Description As String = ""
    Private _ATN_SAStatus4_Description As String = ""
    Private _HRM_Employees5_EmployeeName As String = ""
    Private _HRM_Employees6_EmployeeName As String = ""
    Private _HRM_Employees7_EmployeeName As String = ""
    Private _HRM_Employees8_EmployeeName As String = ""
    Private _ATN_SABySI1_SiteName As String = ""
    Private _ATN_SABySI3_SiteName As String = ""
    Private _ATN_SABySI4_SiteName As String = ""
    Private _ATN_SABySI5_SiteName As String = ""
    Private _ATN_SABySI6_SiteName As String = ""
    Private _ATN_SABySI7_SiteName As String = ""
    Private _ATN_SABySI8_SiteName As String = ""
    Private _ATN_SABySI9_SiteName As String = ""
    Private _ATN_SABySI10_SiteName As String = ""
    Private _ATN_SABySI11_SiteName As String = ""
    Private _ATN_SABySI12_SiteName As String = ""
    Private _ATN_SABySI13_SiteName As String = ""
    Private _ATN_SABySI14_SiteName As String = ""
    Private _ATN_SABySI15_SiteName As String = ""
    Private _ATN_SABySI16_SiteName As String = ""
    Private _ATN_SABySI17_SiteName As String = ""
    Private _ATN_SABySI18_SiteName As String = ""
    Private _ATN_SABySI19_SiteName As String = ""
    Private _ATN_SABySI20_SiteName As String = ""
    Private _ATN_SABySI21_SiteName As String = ""
    Private _ATN_SABySI22_SiteName As String = ""
    Private _ATN_SABySI23_SiteName As String = ""
    Private _ATN_SABySI24_SiteName As String = ""
    Private _ATN_SABySI25_SiteName As String = ""
    Private _ATN_SABySI26_SiteName As String = ""
    Private _ATN_SABySI27_SiteName As String = ""
    Private _ATN_SABySI28_SiteName As String = ""
    Private _ATN_SABySI29_SiteName As String = ""
    Private _ATN_SABySI30_SiteName As String = ""
    Private _ATN_SABySI31_SiteName As String = ""
    Private _ATN_SABySI2_SiteName As String = ""
    Private _FK_ATN_SiteAttendance_ATNStatusID As SIS.ATN.atnApplicationStatus = Nothing
    Private _FK_ATN_SiteAttendance_FinYear As SIS.ATN.atnFinYear = Nothing
    Private _FK_ATN_SiteAttendance_MonthID As SIS.ATN.atnMonths = Nothing
    Private _FK_ATN_SiteAttendance_SAStatusID As SIS.ATN.atnSAStatus = Nothing
    Private _FK_ATN_SiteAttendance_CardNo As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_ATN_SiteAttendance_ApprovedBy As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_ATN_SiteAttendance_PostedBy As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_ATN_SiteAttendance_VerifiedBy As SIS.ATN.newHrmEmployees = Nothing
    Private _FK_ATN_SiteAttendance_SN01 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN03 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN04 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN05 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN06 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN07 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN08 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN09 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN10 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN11 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN12 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN13 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN14 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN15 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN16 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN17 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN18 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN19 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN20 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN21 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN22 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN23 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN24 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN25 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN26 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN27 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN28 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN29 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN30 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN31 As SIS.ATN.atnSABySI = Nothing
    Private _FK_ATN_SiteAttendance_SN02 As SIS.ATN.atnSABySI = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
      End Set
    End Property
    Public Property MonthID() As Int32
      Get
        Return _MonthID
      End Get
      Set(ByVal value As Int32)
        _MonthID = value
      End Set
    End Property
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property VD01() As String
      Get
        Return _VD01
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD01 = ""
         Else
           _VD01 = value
         End If
      End Set
    End Property
    Public Property VD02() As String
      Get
        Return _VD02
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD02 = ""
         Else
           _VD02 = value
         End If
      End Set
    End Property
    Public Property VD03() As String
      Get
        Return _VD03
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD03 = ""
         Else
           _VD03 = value
         End If
      End Set
    End Property
    Public Property VD04() As String
      Get
        Return _VD04
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD04 = ""
         Else
           _VD04 = value
         End If
      End Set
    End Property
    Public Property VD05() As String
      Get
        Return _VD05
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD05 = ""
         Else
           _VD05 = value
         End If
      End Set
    End Property
    Public Property VD06() As String
      Get
        Return _VD06
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD06 = ""
         Else
           _VD06 = value
         End If
      End Set
    End Property
    Public Property VD07() As String
      Get
        Return _VD07
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD07 = ""
         Else
           _VD07 = value
         End If
      End Set
    End Property
    Public Property VD08() As String
      Get
        Return _VD08
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD08 = ""
         Else
           _VD08 = value
         End If
      End Set
    End Property
    Public Property VD09() As String
      Get
        Return _VD09
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD09 = ""
         Else
           _VD09 = value
         End If
      End Set
    End Property
    Public Property VD10() As String
      Get
        Return _VD10
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD10 = ""
         Else
           _VD10 = value
         End If
      End Set
    End Property
    Public Property VD11() As String
      Get
        Return _VD11
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD11 = ""
         Else
           _VD11 = value
         End If
      End Set
    End Property
    Public Property VD12() As String
      Get
        Return _VD12
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD12 = ""
         Else
           _VD12 = value
         End If
      End Set
    End Property
    Public Property VD13() As String
      Get
        Return _VD13
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD13 = ""
         Else
           _VD13 = value
         End If
      End Set
    End Property
    Public Property VD14() As String
      Get
        Return _VD14
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD14 = ""
         Else
           _VD14 = value
         End If
      End Set
    End Property
    Public Property VD15() As String
      Get
        Return _VD15
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD15 = ""
         Else
           _VD15 = value
         End If
      End Set
    End Property
    Public Property VD16() As String
      Get
        Return _VD16
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD16 = ""
         Else
           _VD16 = value
         End If
      End Set
    End Property
    Public Property VD17() As String
      Get
        Return _VD17
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD17 = ""
         Else
           _VD17 = value
         End If
      End Set
    End Property
    Public Property VD18() As String
      Get
        Return _VD18
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD18 = ""
         Else
           _VD18 = value
         End If
      End Set
    End Property
    Public Property VD19() As String
      Get
        Return _VD19
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD19 = ""
         Else
           _VD19 = value
         End If
      End Set
    End Property
    Public Property VD20() As String
      Get
        Return _VD20
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD20 = ""
         Else
           _VD20 = value
         End If
      End Set
    End Property
    Public Property VD21() As String
      Get
        Return _VD21
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD21 = ""
         Else
           _VD21 = value
         End If
      End Set
    End Property
    Public Property VD22() As String
      Get
        Return _VD22
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD22 = ""
         Else
           _VD22 = value
         End If
      End Set
    End Property
    Public Property VD23() As String
      Get
        Return _VD23
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD23 = ""
         Else
           _VD23 = value
         End If
      End Set
    End Property
    Public Property VD24() As String
      Get
        Return _VD24
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD24 = ""
         Else
           _VD24 = value
         End If
      End Set
    End Property
    Public Property VD25() As String
      Get
        Return _VD25
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD25 = ""
         Else
           _VD25 = value
         End If
      End Set
    End Property
    Public Property VD26() As String
      Get
        Return _VD26
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD26 = ""
         Else
           _VD26 = value
         End If
      End Set
    End Property
    Public Property VD27() As String
      Get
        Return _VD27
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD27 = ""
         Else
           _VD27 = value
         End If
      End Set
    End Property
    Public Property VD28() As String
      Get
        Return _VD28
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD28 = ""
         Else
           _VD28 = value
         End If
      End Set
    End Property
    Public Property VD29() As String
      Get
        Return _VD29
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD29 = ""
         Else
           _VD29 = value
         End If
      End Set
    End Property
    Public Property VD30() As String
      Get
        Return _VD30
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD30 = ""
         Else
           _VD30 = value
         End If
      End Set
    End Property
    Public Property VD31() As String
      Get
        Return _VD31
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VD31 = ""
         Else
           _VD31 = value
         End If
      End Set
    End Property
    Public Property SN04() As String
      Get
        Return _SN04
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN04 = ""
         Else
           _SN04 = value
         End If
      End Set
    End Property
    Public Property SN09() As String
      Get
        Return _SN09
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN09 = ""
         Else
           _SN09 = value
         End If
      End Set
    End Property
    Public Property SN08() As String
      Get
        Return _SN08
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN08 = ""
         Else
           _SN08 = value
         End If
      End Set
    End Property
    Public Property SN10() As String
      Get
        Return _SN10
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN10 = ""
         Else
           _SN10 = value
         End If
      End Set
    End Property
    Public Property SN06() As String
      Get
        Return _SN06
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN06 = ""
         Else
           _SN06 = value
         End If
      End Set
    End Property
    Public Property SN07() As String
      Get
        Return _SN07
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN07 = ""
         Else
           _SN07 = value
         End If
      End Set
    End Property
    Public Property SN11() As String
      Get
        Return _SN11
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN11 = ""
         Else
           _SN11 = value
         End If
      End Set
    End Property
    Public Property SN12() As String
      Get
        Return _SN12
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN12 = ""
         Else
           _SN12 = value
         End If
      End Set
    End Property
    Public Property SN13() As String
      Get
        Return _SN13
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN13 = ""
         Else
           _SN13 = value
         End If
      End Set
    End Property
    Public Property SN05() As String
      Get
        Return _SN05
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN05 = ""
         Else
           _SN05 = value
         End If
      End Set
    End Property
    Public Property PD29() As String
      Get
        Return _PD29
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD29 = ""
         Else
           _PD29 = value
         End If
      End Set
    End Property
    Public Property PD30() As String
      Get
        Return _PD30
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD30 = ""
         Else
           _PD30 = value
         End If
      End Set
    End Property
    Public Property PD31() As String
      Get
        Return _PD31
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD31 = ""
         Else
           _PD31 = value
         End If
      End Set
    End Property
    Public Property SN03() As String
      Get
        Return _SN03
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN03 = ""
         Else
           _SN03 = value
         End If
      End Set
    End Property
    Public Property SN26() As String
      Get
        Return _SN26
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN26 = ""
         Else
           _SN26 = value
         End If
      End Set
    End Property
    Public Property SN02() As String
      Get
        Return _SN02
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN02 = ""
         Else
           _SN02 = value
         End If
      End Set
    End Property
    Public Property SN01() As String
      Get
        Return _SN01
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN01 = ""
         Else
           _SN01 = value
         End If
      End Set
    End Property
    Public Property SN14() As String
      Get
        Return _SN14
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN14 = ""
         Else
           _SN14 = value
         End If
      End Set
    End Property
    Public Property SN28() As String
      Get
        Return _SN28
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN28 = ""
         Else
           _SN28 = value
         End If
      End Set
    End Property
    Public Property SN25() As String
      Get
        Return _SN25
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN25 = ""
         Else
           _SN25 = value
         End If
      End Set
    End Property
    Public Property SN31() As String
      Get
        Return _SN31
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN31 = ""
         Else
           _SN31 = value
         End If
      End Set
    End Property
    Public Property PD28() As String
      Get
        Return _PD28
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD28 = ""
         Else
           _PD28 = value
         End If
      End Set
    End Property
    Public Property SN15() As String
      Get
        Return _SN15
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN15 = ""
         Else
           _SN15 = value
         End If
      End Set
    End Property
    Public Property SN27() As String
      Get
        Return _SN27
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN27 = ""
         Else
           _SN27 = value
         End If
      End Set
    End Property
    Public Property SN29() As String
      Get
        Return _SN29
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN29 = ""
         Else
           _SN29 = value
         End If
      End Set
    End Property
    Public Property SN30() As String
      Get
        Return _SN30
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN30 = ""
         Else
           _SN30 = value
         End If
      End Set
    End Property
    Public Property SN24() As String
      Get
        Return _SN24
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN24 = ""
         Else
           _SN24 = value
         End If
      End Set
    End Property
    Public Property SN18() As String
      Get
        Return _SN18
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN18 = ""
         Else
           _SN18 = value
         End If
      End Set
    End Property
    Public Property SN19() As String
      Get
        Return _SN19
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN19 = ""
         Else
           _SN19 = value
         End If
      End Set
    End Property
    Public Property SN16() As String
      Get
        Return _SN16
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN16 = ""
         Else
           _SN16 = value
         End If
      End Set
    End Property
    Public Property SN17() As String
      Get
        Return _SN17
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN17 = ""
         Else
           _SN17 = value
         End If
      End Set
    End Property
    Public Property SN22() As String
      Get
        Return _SN22
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN22 = ""
         Else
           _SN22 = value
         End If
      End Set
    End Property
    Public Property SN23() As String
      Get
        Return _SN23
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN23 = ""
         Else
           _SN23 = value
         End If
      End Set
    End Property
    Public Property SN20() As String
      Get
        Return _SN20
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN20 = ""
         Else
           _SN20 = value
         End If
      End Set
    End Property
    Public Property SN21() As String
      Get
        Return _SN21
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SN21 = ""
         Else
           _SN21 = value
         End If
      End Set
    End Property
    Public Property AD14() As String
      Get
        Return _AD14
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD14 = ""
         Else
           _AD14 = value
         End If
      End Set
    End Property
    Public Property AD13() As String
      Get
        Return _AD13
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD13 = ""
         Else
           _AD13 = value
         End If
      End Set
    End Property
    Public Property AD16() As String
      Get
        Return _AD16
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD16 = ""
         Else
           _AD16 = value
         End If
      End Set
    End Property
    Public Property AD15() As String
      Get
        Return _AD15
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD15 = ""
         Else
           _AD15 = value
         End If
      End Set
    End Property
    Public Property AD10() As String
      Get
        Return _AD10
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD10 = ""
         Else
           _AD10 = value
         End If
      End Set
    End Property
    Public Property AD09() As String
      Get
        Return _AD09
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD09 = ""
         Else
           _AD09 = value
         End If
      End Set
    End Property
    Public Property AD12() As String
      Get
        Return _AD12
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD12 = ""
         Else
           _AD12 = value
         End If
      End Set
    End Property
    Public Property AD11() As String
      Get
        Return _AD11
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD11 = ""
         Else
           _AD11 = value
         End If
      End Set
    End Property
    Public Property AD22() As String
      Get
        Return _AD22
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD22 = ""
         Else
           _AD22 = value
         End If
      End Set
    End Property
    Public Property AD21() As String
      Get
        Return _AD21
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD21 = ""
         Else
           _AD21 = value
         End If
      End Set
    End Property
    Public Property AD24() As String
      Get
        Return _AD24
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD24 = ""
         Else
           _AD24 = value
         End If
      End Set
    End Property
    Public Property AD23() As String
      Get
        Return _AD23
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD23 = ""
         Else
           _AD23 = value
         End If
      End Set
    End Property
    Public Property AD18() As String
      Get
        Return _AD18
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD18 = ""
         Else
           _AD18 = value
         End If
      End Set
    End Property
    Public Property AD17() As String
      Get
        Return _AD17
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD17 = ""
         Else
           _AD17 = value
         End If
      End Set
    End Property
    Public Property AD20() As String
      Get
        Return _AD20
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD20 = ""
         Else
           _AD20 = value
         End If
      End Set
    End Property
    Public Property AD19() As String
      Get
        Return _AD19
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD19 = ""
         Else
           _AD19 = value
         End If
      End Set
    End Property
    Public Property AD04() As String
      Get
        Return _AD04
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD04 = ""
         Else
           _AD04 = value
         End If
      End Set
    End Property
    Public Property PostedOn() As String
      Get
        If Not _PostedOn = String.Empty Then
          Return Convert.ToDateTime(_PostedOn).ToString("dd/MM/yyyy")
        End If
        Return _PostedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedOn = ""
         Else
           _PostedOn = value
         End If
      End Set
    End Property
    Public Property PD27() As String
      Get
        Return _PD27
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD27 = ""
         Else
           _PD27 = value
         End If
      End Set
    End Property
    Public Property AD03() As String
      Get
        Return _AD03
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD03 = ""
         Else
           _AD03 = value
         End If
      End Set
    End Property
    Public Property ApproverRemarks() As String
      Get
        Return _ApproverRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApproverRemarks = ""
         Else
           _ApproverRemarks = value
         End If
      End Set
    End Property
    Public Property ApprovedOn() As String
      Get
        If Not _ApprovedOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedOn = ""
         Else
           _ApprovedOn = value
         End If
      End Set
    End Property
    Public Property AD06() As String
      Get
        Return _AD06
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD06 = ""
         Else
           _AD06 = value
         End If
      End Set
    End Property
    Public Property PD13() As String
      Get
        Return _PD13
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD13 = ""
         Else
           _PD13 = value
         End If
      End Set
    End Property
    Public Property AD07() As String
      Get
        Return _AD07
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD07 = ""
         Else
           _AD07 = value
         End If
      End Set
    End Property
    Public Property AD05() As String
      Get
        Return _AD05
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD05 = ""
         Else
           _AD05 = value
         End If
      End Set
    End Property
    Public Property ApprovedBy() As String
      Get
        Return _ApprovedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedBy = ""
         Else
           _ApprovedBy = value
         End If
      End Set
    End Property
    Public Property PostedBy() As String
      Get
        Return _PostedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedBy = ""
         Else
           _PostedBy = value
         End If
      End Set
    End Property
    Public Property AD08() As String
      Get
        Return _AD08
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD08 = ""
         Else
           _AD08 = value
         End If
      End Set
    End Property
    Public Property PD12() As String
      Get
        Return _PD12
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD12 = ""
         Else
           _PD12 = value
         End If
      End Set
    End Property
    Public Property PostingRemarks() As String
      Get
        Return _PostingRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostingRemarks = ""
         Else
           _PostingRemarks = value
         End If
      End Set
    End Property
    Public Property SAStatusID() As String
      Get
        Return _SAStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SAStatusID = ""
         Else
           _SAStatusID = value
         End If
      End Set
    End Property
    Public Property ATNStatusID() As String
      Get
        Return _ATNStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATNStatusID = ""
         Else
           _ATNStatusID = value
         End If
      End Set
    End Property
    Public Property AD02() As String
      Get
        Return _AD02
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD02 = ""
         Else
           _AD02 = value
         End If
      End Set
    End Property
    Public Property PD11() As String
      Get
        Return _PD11
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD11 = ""
         Else
           _PD11 = value
         End If
      End Set
    End Property
    Public Property AD01() As String
      Get
        Return _AD01
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD01 = ""
         Else
           _AD01 = value
         End If
      End Set
    End Property
    Public Property PD15() As String
      Get
        Return _PD15
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD15 = ""
         Else
           _PD15 = value
         End If
      End Set
    End Property
    Public Property PD18() As String
      Get
        Return _PD18
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD18 = ""
         Else
           _PD18 = value
         End If
      End Set
    End Property
    Public Property PD17() As String
      Get
        Return _PD17
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD17 = ""
         Else
           _PD17 = value
         End If
      End Set
    End Property
    Public Property PD16() As String
      Get
        Return _PD16
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD16 = ""
         Else
           _PD16 = value
         End If
      End Set
    End Property
    Public Property PD14() As String
      Get
        Return _PD14
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD14 = ""
         Else
           _PD14 = value
         End If
      End Set
    End Property
    Public Property PD24() As String
      Get
        Return _PD24
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD24 = ""
         Else
           _PD24 = value
         End If
      End Set
    End Property
    Public Property PD23() As String
      Get
        Return _PD23
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD23 = ""
         Else
           _PD23 = value
         End If
      End Set
    End Property
    Public Property PD26() As String
      Get
        Return _PD26
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD26 = ""
         Else
           _PD26 = value
         End If
      End Set
    End Property
    Public Property PD25() As String
      Get
        Return _PD25
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD25 = ""
         Else
           _PD25 = value
         End If
      End Set
    End Property
    Public Property PD20() As String
      Get
        Return _PD20
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD20 = ""
         Else
           _PD20 = value
         End If
      End Set
    End Property
    Public Property PD19() As String
      Get
        Return _PD19
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD19 = ""
         Else
           _PD19 = value
         End If
      End Set
    End Property
    Public Property PD22() As String
      Get
        Return _PD22
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD22 = ""
         Else
           _PD22 = value
         End If
      End Set
    End Property
    Public Property PD21() As String
      Get
        Return _PD21
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD21 = ""
         Else
           _PD21 = value
         End If
      End Set
    End Property
    Public Property PD10() As String
      Get
        Return _PD10
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD10 = ""
         Else
           _PD10 = value
         End If
      End Set
    End Property
    Public Property AD30() As String
      Get
        Return _AD30
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD30 = ""
         Else
           _AD30 = value
         End If
      End Set
    End Property
    Public Property AD29() As String
      Get
        Return _AD29
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD29 = ""
         Else
           _AD29 = value
         End If
      End Set
    End Property
    Public Property PD01() As String
      Get
        Return _PD01
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD01 = ""
         Else
           _PD01 = value
         End If
      End Set
    End Property
    Public Property AD31() As String
      Get
        Return _AD31
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD31 = ""
         Else
           _AD31 = value
         End If
      End Set
    End Property
    Public Property AD26() As String
      Get
        Return _AD26
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD26 = ""
         Else
           _AD26 = value
         End If
      End Set
    End Property
    Public Property AD25() As String
      Get
        Return _AD25
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD25 = ""
         Else
           _AD25 = value
         End If
      End Set
    End Property
    Public Property AD28() As String
      Get
        Return _AD28
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD28 = ""
         Else
           _AD28 = value
         End If
      End Set
    End Property
    Public Property AD27() As String
      Get
        Return _AD27
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AD27 = ""
         Else
           _AD27 = value
         End If
      End Set
    End Property
    Public Property PD07() As String
      Get
        Return _PD07
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD07 = ""
         Else
           _PD07 = value
         End If
      End Set
    End Property
    Public Property PD06() As String
      Get
        Return _PD06
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD06 = ""
         Else
           _PD06 = value
         End If
      End Set
    End Property
    Public Property PD09() As String
      Get
        Return _PD09
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD09 = ""
         Else
           _PD09 = value
         End If
      End Set
    End Property
    Public Property PD08() As String
      Get
        Return _PD08
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD08 = ""
         Else
           _PD08 = value
         End If
      End Set
    End Property
    Public Property PD03() As String
      Get
        Return _PD03
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD03 = ""
         Else
           _PD03 = value
         End If
      End Set
    End Property
    Public Property PD02() As String
      Get
        Return _PD02
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD02 = ""
         Else
           _PD02 = value
         End If
      End Set
    End Property
    Public Property PD05() As String
      Get
        Return _PD05
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD05 = ""
         Else
           _PD05 = value
         End If
      End Set
    End Property
    Public Property PD04() As String
      Get
        Return _PD04
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PD04 = ""
         Else
           _PD04 = value
         End If
      End Set
    End Property
    Public Property ATN_ApplicationStatus1_Description() As String
      Get
        Return _ATN_ApplicationStatus1_Description
      End Get
      Set(ByVal value As String)
        _ATN_ApplicationStatus1_Description = value
      End Set
    End Property
    Public Property ATN_FinYear2_Description() As String
      Get
        Return _ATN_FinYear2_Description
      End Get
      Set(ByVal value As String)
        _ATN_FinYear2_Description = value
      End Set
    End Property
    Public Property ATN_Months3_Description() As String
      Get
        Return _ATN_Months3_Description.Substring(0, 3).ToUpper
      End Get
      Set(ByVal value As String)
        _ATN_Months3_Description = value
      End Set
    End Property
    Public Property ATN_SAStatus4_Description() As String
      Get
        Return _ATN_SAStatus4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SAStatus4_Description = ""
         Else
           _ATN_SAStatus4_Description = value
         End If
      End Set
    End Property
    Public Property HRM_Employees5_EmployeeName() As String
      Get
        Return _HRM_Employees5_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees5_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees6_EmployeeName() As String
      Get
        Return _HRM_Employees6_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees6_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees7_EmployeeName() As String
      Get
        Return _HRM_Employees7_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees7_EmployeeName = value
      End Set
    End Property
    Public Property ATN_SABySI1_SiteName() As String
      Get
        Return _ATN_SABySI1_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI1_SiteName = ""
         Else
           _ATN_SABySI1_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI3_SiteName() As String
      Get
        Return _ATN_SABySI3_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI3_SiteName = ""
         Else
           _ATN_SABySI3_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI4_SiteName() As String
      Get
        Return _ATN_SABySI4_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI4_SiteName = ""
         Else
           _ATN_SABySI4_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI5_SiteName() As String
      Get
        Return _ATN_SABySI5_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI5_SiteName = ""
         Else
           _ATN_SABySI5_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI6_SiteName() As String
      Get
        Return _ATN_SABySI6_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI6_SiteName = ""
         Else
           _ATN_SABySI6_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI7_SiteName() As String
      Get
        Return _ATN_SABySI7_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI7_SiteName = ""
         Else
           _ATN_SABySI7_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI8_SiteName() As String
      Get
        Return _ATN_SABySI8_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI8_SiteName = ""
         Else
           _ATN_SABySI8_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI9_SiteName() As String
      Get
        Return _ATN_SABySI9_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI9_SiteName = ""
         Else
           _ATN_SABySI9_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI10_SiteName() As String
      Get
        Return _ATN_SABySI10_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI10_SiteName = ""
         Else
           _ATN_SABySI10_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI11_SiteName() As String
      Get
        Return _ATN_SABySI11_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI11_SiteName = ""
         Else
           _ATN_SABySI11_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI12_SiteName() As String
      Get
        Return _ATN_SABySI12_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI12_SiteName = ""
         Else
           _ATN_SABySI12_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI13_SiteName() As String
      Get
        Return _ATN_SABySI13_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI13_SiteName = ""
         Else
           _ATN_SABySI13_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI14_SiteName() As String
      Get
        Return _ATN_SABySI14_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI14_SiteName = ""
         Else
           _ATN_SABySI14_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI15_SiteName() As String
      Get
        Return _ATN_SABySI15_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI15_SiteName = ""
         Else
           _ATN_SABySI15_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI16_SiteName() As String
      Get
        Return _ATN_SABySI16_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI16_SiteName = ""
         Else
           _ATN_SABySI16_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI17_SiteName() As String
      Get
        Return _ATN_SABySI17_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI17_SiteName = ""
         Else
           _ATN_SABySI17_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI18_SiteName() As String
      Get
        Return _ATN_SABySI18_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI18_SiteName = ""
         Else
           _ATN_SABySI18_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI19_SiteName() As String
      Get
        Return _ATN_SABySI19_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI19_SiteName = ""
         Else
           _ATN_SABySI19_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI20_SiteName() As String
      Get
        Return _ATN_SABySI20_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI20_SiteName = ""
         Else
           _ATN_SABySI20_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI21_SiteName() As String
      Get
        Return _ATN_SABySI21_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI21_SiteName = ""
         Else
           _ATN_SABySI21_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI22_SiteName() As String
      Get
        Return _ATN_SABySI22_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI22_SiteName = ""
         Else
           _ATN_SABySI22_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI23_SiteName() As String
      Get
        Return _ATN_SABySI23_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI23_SiteName = ""
         Else
           _ATN_SABySI23_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI24_SiteName() As String
      Get
        Return _ATN_SABySI24_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI24_SiteName = ""
         Else
           _ATN_SABySI24_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI25_SiteName() As String
      Get
        Return _ATN_SABySI25_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI25_SiteName = ""
         Else
           _ATN_SABySI25_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI26_SiteName() As String
      Get
        Return _ATN_SABySI26_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI26_SiteName = ""
         Else
           _ATN_SABySI26_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI27_SiteName() As String
      Get
        Return _ATN_SABySI27_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI27_SiteName = ""
         Else
           _ATN_SABySI27_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI28_SiteName() As String
      Get
        Return _ATN_SABySI28_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI28_SiteName = ""
         Else
           _ATN_SABySI28_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI29_SiteName() As String
      Get
        Return _ATN_SABySI29_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI29_SiteName = ""
         Else
           _ATN_SABySI29_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI30_SiteName() As String
      Get
        Return _ATN_SABySI30_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI30_SiteName = ""
         Else
           _ATN_SABySI30_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI31_SiteName() As String
      Get
        Return _ATN_SABySI31_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI31_SiteName = ""
         Else
           _ATN_SABySI31_SiteName = value
         End If
      End Set
    End Property
    Public Property ATN_SABySI2_SiteName() As String
      Get
        Return _ATN_SABySI2_SiteName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ATN_SABySI2_SiteName = ""
         Else
           _ATN_SABySI2_SiteName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FinYear & "|" & _MonthID & "|" & _CardNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKatnSiteAttendance
      Private _FinYear As String = ""
      Private _MonthID As Int32 = 0
      Private _CardNo As String = ""
      Public Property FinYear() As String
        Get
          Return _FinYear
        End Get
        Set(ByVal value As String)
          _FinYear = value
        End Set
      End Property
      Public Property MonthID() As Int32
        Get
          Return _MonthID
        End Get
        Set(ByVal value As Int32)
          _MonthID = value
        End Set
      End Property
      Public Property CardNo() As String
        Get
          Return _CardNo
        End Get
        Set(ByVal value As String)
          _CardNo = value
        End Set
      End Property
    End Class
    Public Property VerifierRemarks() As String
      Get
        Return _VerifierRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifierRemarks = ""
        Else
          _VerifierRemarks = value
        End If
      End Set
    End Property
    Public Property VerifiedBy() As String
      Get
        Return _VerifiedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifiedBy = ""
        Else
          _VerifiedBy = value
        End If
      End Set
    End Property
    Public Property VerifiedOn() As String
      Get
        If Not _VerifiedOn = String.Empty Then
          Return Convert.ToDateTime(_VerifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _VerifiedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifiedOn = ""
        Else
          _VerifiedOn = value
        End If
      End Set
    End Property
    Public Property HRM_Employees8_EmployeeName() As String
      Get
        Return _HRM_Employees8_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees8_EmployeeName = value
      End Set
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_ATNStatusID() As SIS.ATN.atnApplicationStatus
      Get
        If _FK_ATN_SiteAttendance_ATNStatusID Is Nothing Then
          _FK_ATN_SiteAttendance_ATNStatusID = SIS.ATN.atnApplicationStatus.atnApplicationStatusGetByID(_ATNStatusID)
        End If
        Return _FK_ATN_SiteAttendance_ATNStatusID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_FinYear() As SIS.ATN.atnFinYear
      Get
        If _FK_ATN_SiteAttendance_FinYear Is Nothing Then
          _FK_ATN_SiteAttendance_FinYear = SIS.ATN.atnFinYear.atnFinYearGetByID(_FinYear)
        End If
        Return _FK_ATN_SiteAttendance_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_MonthID() As SIS.ATN.atnMonths
      Get
        If _FK_ATN_SiteAttendance_MonthID Is Nothing Then
          _FK_ATN_SiteAttendance_MonthID = SIS.ATN.atnMonths.atnMonthsGetByID(_MonthID)
        End If
        Return _FK_ATN_SiteAttendance_MonthID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SAStatusID() As SIS.ATN.atnSAStatus
      Get
        If _FK_ATN_SiteAttendance_SAStatusID Is Nothing Then
          _FK_ATN_SiteAttendance_SAStatusID = SIS.ATN.atnSAStatus.atnSAStatusGetByID(_SAStatusID)
        End If
        Return _FK_ATN_SiteAttendance_SAStatusID
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_CardNo() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_SiteAttendance_CardNo Is Nothing Then
          _FK_ATN_SiteAttendance_CardNo = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_CardNo)
        End If
        Return _FK_ATN_SiteAttendance_CardNo
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_ApprovedBy() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_SiteAttendance_ApprovedBy Is Nothing Then
          _FK_ATN_SiteAttendance_ApprovedBy = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_ApprovedBy)
        End If
        Return _FK_ATN_SiteAttendance_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_PostedBy() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_SiteAttendance_PostedBy Is Nothing Then
          _FK_ATN_SiteAttendance_PostedBy = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_PostedBy)
        End If
        Return _FK_ATN_SiteAttendance_PostedBy
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_VerifiedBy() As SIS.ATN.newHrmEmployees
      Get
        If _FK_ATN_SiteAttendance_VerifiedBy Is Nothing Then
          _FK_ATN_SiteAttendance_VerifiedBy = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(_VerifiedBy)
        End If
        Return _FK_ATN_SiteAttendance_VerifiedBy
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN01() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN01 Is Nothing Then
          _FK_ATN_SiteAttendance_SN01 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN01)
        End If
        Return _FK_ATN_SiteAttendance_SN01
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN03() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN03 Is Nothing Then
          _FK_ATN_SiteAttendance_SN03 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN03)
        End If
        Return _FK_ATN_SiteAttendance_SN03
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN04() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN04 Is Nothing Then
          _FK_ATN_SiteAttendance_SN04 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN04)
        End If
        Return _FK_ATN_SiteAttendance_SN04
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN05() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN05 Is Nothing Then
          _FK_ATN_SiteAttendance_SN05 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN05)
        End If
        Return _FK_ATN_SiteAttendance_SN05
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN06() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN06 Is Nothing Then
          _FK_ATN_SiteAttendance_SN06 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN06)
        End If
        Return _FK_ATN_SiteAttendance_SN06
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN07() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN07 Is Nothing Then
          _FK_ATN_SiteAttendance_SN07 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN07)
        End If
        Return _FK_ATN_SiteAttendance_SN07
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN08() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN08 Is Nothing Then
          _FK_ATN_SiteAttendance_SN08 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN08)
        End If
        Return _FK_ATN_SiteAttendance_SN08
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN09() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN09 Is Nothing Then
          _FK_ATN_SiteAttendance_SN09 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN09)
        End If
        Return _FK_ATN_SiteAttendance_SN09
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN10() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN10 Is Nothing Then
          _FK_ATN_SiteAttendance_SN10 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN10)
        End If
        Return _FK_ATN_SiteAttendance_SN10
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN11() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN11 Is Nothing Then
          _FK_ATN_SiteAttendance_SN11 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN11)
        End If
        Return _FK_ATN_SiteAttendance_SN11
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN12() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN12 Is Nothing Then
          _FK_ATN_SiteAttendance_SN12 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN12)
        End If
        Return _FK_ATN_SiteAttendance_SN12
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN13() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN13 Is Nothing Then
          _FK_ATN_SiteAttendance_SN13 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN13)
        End If
        Return _FK_ATN_SiteAttendance_SN13
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN14() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN14 Is Nothing Then
          _FK_ATN_SiteAttendance_SN14 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN14)
        End If
        Return _FK_ATN_SiteAttendance_SN14
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN15() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN15 Is Nothing Then
          _FK_ATN_SiteAttendance_SN15 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN15)
        End If
        Return _FK_ATN_SiteAttendance_SN15
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN16() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN16 Is Nothing Then
          _FK_ATN_SiteAttendance_SN16 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN16)
        End If
        Return _FK_ATN_SiteAttendance_SN16
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN17() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN17 Is Nothing Then
          _FK_ATN_SiteAttendance_SN17 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN17)
        End If
        Return _FK_ATN_SiteAttendance_SN17
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN18() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN18 Is Nothing Then
          _FK_ATN_SiteAttendance_SN18 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN18)
        End If
        Return _FK_ATN_SiteAttendance_SN18
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN19() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN19 Is Nothing Then
          _FK_ATN_SiteAttendance_SN19 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN19)
        End If
        Return _FK_ATN_SiteAttendance_SN19
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN20() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN20 Is Nothing Then
          _FK_ATN_SiteAttendance_SN20 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN20)
        End If
        Return _FK_ATN_SiteAttendance_SN20
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN21() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN21 Is Nothing Then
          _FK_ATN_SiteAttendance_SN21 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN21)
        End If
        Return _FK_ATN_SiteAttendance_SN21
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN22() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN22 Is Nothing Then
          _FK_ATN_SiteAttendance_SN22 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN22)
        End If
        Return _FK_ATN_SiteAttendance_SN22
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN23() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN23 Is Nothing Then
          _FK_ATN_SiteAttendance_SN23 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN23)
        End If
        Return _FK_ATN_SiteAttendance_SN23
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN24() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN24 Is Nothing Then
          _FK_ATN_SiteAttendance_SN24 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN24)
        End If
        Return _FK_ATN_SiteAttendance_SN24
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN25() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN25 Is Nothing Then
          _FK_ATN_SiteAttendance_SN25 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN25)
        End If
        Return _FK_ATN_SiteAttendance_SN25
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN26() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN26 Is Nothing Then
          _FK_ATN_SiteAttendance_SN26 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN26)
        End If
        Return _FK_ATN_SiteAttendance_SN26
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN27() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN27 Is Nothing Then
          _FK_ATN_SiteAttendance_SN27 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN27)
        End If
        Return _FK_ATN_SiteAttendance_SN27
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN28() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN28 Is Nothing Then
          _FK_ATN_SiteAttendance_SN28 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN28)
        End If
        Return _FK_ATN_SiteAttendance_SN28
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN29() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN29 Is Nothing Then
          _FK_ATN_SiteAttendance_SN29 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN29)
        End If
        Return _FK_ATN_SiteAttendance_SN29
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN30() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN30 Is Nothing Then
          _FK_ATN_SiteAttendance_SN30 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN30)
        End If
        Return _FK_ATN_SiteAttendance_SN30
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN31() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN31 Is Nothing Then
          _FK_ATN_SiteAttendance_SN31 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN31)
        End If
        Return _FK_ATN_SiteAttendance_SN31
      End Get
    End Property
    Public ReadOnly Property FK_ATN_SiteAttendance_SN02() As SIS.ATN.atnSABySI
      Get
        If _FK_ATN_SiteAttendance_SN02 Is Nothing Then
          _FK_ATN_SiteAttendance_SN02 = SIS.ATN.atnSABySI.atnSABySIGetByID(_SN02)
        End If
        Return _FK_ATN_SiteAttendance_SN02
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendanceGetNewRecord() As SIS.ATN.atnSiteAttendance
      Return New SIS.ATN.atnSiteAttendance()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendanceGetByID(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String) As SIS.ATN.atnSiteAttendance
      Dim Results As SIS.ATN.atnSiteAttendance = Nothing
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
            Results = New SIS.ATN.atnSiteAttendance(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendanceSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String) As List(Of SIS.ATN.atnSiteAttendance)
      Dim Results As List(Of SIS.ATN.atnSiteAttendance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "MonthID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnSiteAttendanceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnSiteAttendanceSelectListFilteres"
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
    Public Shared Function atnSiteAttendanceSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal MonthID As Int32, ByVal ApprovedBy As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function atnSiteAttendanceGetByID(ByVal FinYear As String, ByVal MonthID As Int32, ByVal CardNo As String, ByVal Filter_MonthID As Int32, ByVal Filter_ApprovedBy As String) As SIS.ATN.atnSiteAttendance
      Return atnSiteAttendanceGetByID(FinYear, MonthID, CardNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function atnSiteAttendanceInsert(ByVal Record As SIS.ATN.atnSiteAttendance) As SIS.ATN.atnSiteAttendance
      Dim _Rec As SIS.ATN.atnSiteAttendance = SIS.ATN.atnSiteAttendance.atnSiteAttendanceGetNewRecord()
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
        .SN04 = Record.SN04
        .SN09 = Record.SN09
        .SN08 = Record.SN08
        .SN10 = Record.SN10
        .SN06 = Record.SN06
        .SN07 = Record.SN07
        .SN11 = Record.SN11
        .SN12 = Record.SN12
        .SN13 = Record.SN13
        .SN05 = Record.SN05
        .PD29 = Record.PD29
        .PD30 = Record.PD30
        .PD31 = Record.PD31
        .SN03 = Record.SN03
        .SN26 = Record.SN26
        .SN02 = Record.SN02
        .SN01 = Record.SN01
        .SN14 = Record.SN14
        .SN28 = Record.SN28
        .SN25 = Record.SN25
        .SN31 = Record.SN31
        .PD28 = Record.PD28
        .SN15 = Record.SN15
        .SN27 = Record.SN27
        .SN29 = Record.SN29
        .SN30 = Record.SN30
        .SN24 = Record.SN24
        .SN18 = Record.SN18
        .SN19 = Record.SN19
        .SN16 = Record.SN16
        .SN17 = Record.SN17
        .SN22 = Record.SN22
        .SN23 = Record.SN23
        .SN20 = Record.SN20
        .SN21 = Record.SN21
        .AD14 = Record.AD14
        .AD13 = Record.AD13
        .AD16 = Record.AD16
        .AD15 = Record.AD15
        .AD10 = Record.AD10
        .AD09 = Record.AD09
        .AD12 = Record.AD12
        .AD11 = Record.AD11
        .AD22 = Record.AD22
        .AD21 = Record.AD21
        .AD24 = Record.AD24
        .AD23 = Record.AD23
        .AD18 = Record.AD18
        .AD17 = Record.AD17
        .AD20 = Record.AD20
        .AD19 = Record.AD19
        .AD04 = Record.AD04
        .PostedOn = Record.PostedOn
        .PD27 = Record.PD27
        .AD03 = Record.AD03
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
        .AD06 = Record.AD06
        .PD13 = Record.PD13
        .AD07 = Record.AD07
        .AD05 = Record.AD05
        .ApprovedBy = Record.ApprovedBy
        .PostedBy = Record.PostedBy
        .AD08 = Record.AD08
        .PD12 = Record.PD12
        .PostingRemarks = Record.PostingRemarks
        .SAStatusID = Record.SAStatusID
        .ATNStatusID = Record.ATNStatusID
        .AD02 = Record.AD02
        .PD11 = Record.PD11
        .AD01 = Record.AD01
        .PD15 = Record.PD15
        .PD18 = Record.PD18
        .PD17 = Record.PD17
        .PD16 = Record.PD16
        .PD14 = Record.PD14
        .PD24 = Record.PD24
        .PD23 = Record.PD23
        .PD26 = Record.PD26
        .PD25 = Record.PD25
        .PD20 = Record.PD20
        .PD19 = Record.PD19
        .PD22 = Record.PD22
        .PD21 = Record.PD21
        .PD10 = Record.PD10
        .AD30 = Record.AD30
        .AD29 = Record.AD29
        .PD01 = Record.PD01
        .AD31 = Record.AD31
        .AD26 = Record.AD26
        .AD25 = Record.AD25
        .AD28 = Record.AD28
        .AD27 = Record.AD27
        .PD07 = Record.PD07
        .PD06 = Record.PD06
        .PD09 = Record.PD09
        .PD08 = Record.PD08
        .PD03 = Record.PD03
        .PD02 = Record.PD02
        .PD05 = Record.PD05
        .PD04 = Record.PD04
        .VerifierRemarks = Record.VerifierRemarks
        .VerifiedBy = Record.VerifiedBy
        .VerifiedOn = Record.VerifiedOn
      End With
      Return SIS.ATN.atnSiteAttendance.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ATN.atnSiteAttendance) As SIS.ATN.atnSiteAttendance
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSiteAttendanceInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID",SqlDbType.Int,11, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD01",SqlDbType.NVarChar,3, Iif(Record.VD01= "" ,Convert.DBNull, Record.VD01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD02",SqlDbType.NVarChar,3, Iif(Record.VD02= "" ,Convert.DBNull, Record.VD02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD03",SqlDbType.NVarChar,3, Iif(Record.VD03= "" ,Convert.DBNull, Record.VD03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD04",SqlDbType.NVarChar,3, Iif(Record.VD04= "" ,Convert.DBNull, Record.VD04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD05",SqlDbType.NVarChar,3, Iif(Record.VD05= "" ,Convert.DBNull, Record.VD05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD06",SqlDbType.NVarChar,3, Iif(Record.VD06= "" ,Convert.DBNull, Record.VD06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD07",SqlDbType.NVarChar,3, Iif(Record.VD07= "" ,Convert.DBNull, Record.VD07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD08",SqlDbType.NVarChar,3, Iif(Record.VD08= "" ,Convert.DBNull, Record.VD08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD09",SqlDbType.NVarChar,3, Iif(Record.VD09= "" ,Convert.DBNull, Record.VD09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD10",SqlDbType.NVarChar,3, Iif(Record.VD10= "" ,Convert.DBNull, Record.VD10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD11",SqlDbType.NVarChar,3, Iif(Record.VD11= "" ,Convert.DBNull, Record.VD11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD12",SqlDbType.NVarChar,3, Iif(Record.VD12= "" ,Convert.DBNull, Record.VD12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD13",SqlDbType.NVarChar,3, Iif(Record.VD13= "" ,Convert.DBNull, Record.VD13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD14",SqlDbType.NVarChar,3, Iif(Record.VD14= "" ,Convert.DBNull, Record.VD14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD15",SqlDbType.NVarChar,3, Iif(Record.VD15= "" ,Convert.DBNull, Record.VD15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD16",SqlDbType.NVarChar,3, Iif(Record.VD16= "" ,Convert.DBNull, Record.VD16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD17",SqlDbType.NVarChar,3, Iif(Record.VD17= "" ,Convert.DBNull, Record.VD17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD18",SqlDbType.NVarChar,3, Iif(Record.VD18= "" ,Convert.DBNull, Record.VD18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD19",SqlDbType.NVarChar,3, Iif(Record.VD19= "" ,Convert.DBNull, Record.VD19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD20",SqlDbType.NVarChar,3, Iif(Record.VD20= "" ,Convert.DBNull, Record.VD20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD21",SqlDbType.NVarChar,3, Iif(Record.VD21= "" ,Convert.DBNull, Record.VD21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD22",SqlDbType.NVarChar,3, Iif(Record.VD22= "" ,Convert.DBNull, Record.VD22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD23",SqlDbType.NVarChar,3, Iif(Record.VD23= "" ,Convert.DBNull, Record.VD23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD24",SqlDbType.NVarChar,3, Iif(Record.VD24= "" ,Convert.DBNull, Record.VD24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD25",SqlDbType.NVarChar,3, Iif(Record.VD25= "" ,Convert.DBNull, Record.VD25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD26",SqlDbType.NVarChar,3, Iif(Record.VD26= "" ,Convert.DBNull, Record.VD26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD27",SqlDbType.NVarChar,3, Iif(Record.VD27= "" ,Convert.DBNull, Record.VD27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD28",SqlDbType.NVarChar,3, Iif(Record.VD28= "" ,Convert.DBNull, Record.VD28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD29",SqlDbType.NVarChar,3, Iif(Record.VD29= "" ,Convert.DBNull, Record.VD29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD30",SqlDbType.NVarChar,3, Iif(Record.VD30= "" ,Convert.DBNull, Record.VD30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD31",SqlDbType.NVarChar,3, Iif(Record.VD31= "" ,Convert.DBNull, Record.VD31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN04",SqlDbType.Int,11, Iif(Record.SN04= "" ,Convert.DBNull, Record.SN04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN09",SqlDbType.Int,11, Iif(Record.SN09= "" ,Convert.DBNull, Record.SN09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN08",SqlDbType.Int,11, Iif(Record.SN08= "" ,Convert.DBNull, Record.SN08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN10",SqlDbType.Int,11, Iif(Record.SN10= "" ,Convert.DBNull, Record.SN10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN06",SqlDbType.Int,11, Iif(Record.SN06= "" ,Convert.DBNull, Record.SN06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN07",SqlDbType.Int,11, Iif(Record.SN07= "" ,Convert.DBNull, Record.SN07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN11",SqlDbType.Int,11, Iif(Record.SN11= "" ,Convert.DBNull, Record.SN11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN12",SqlDbType.Int,11, Iif(Record.SN12= "" ,Convert.DBNull, Record.SN12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN13",SqlDbType.Int,11, Iif(Record.SN13= "" ,Convert.DBNull, Record.SN13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN05",SqlDbType.Int,11, Iif(Record.SN05= "" ,Convert.DBNull, Record.SN05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD29",SqlDbType.NVarChar,3, Iif(Record.PD29= "" ,Convert.DBNull, Record.PD29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD30",SqlDbType.NVarChar,3, Iif(Record.PD30= "" ,Convert.DBNull, Record.PD30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD31",SqlDbType.NVarChar,3, Iif(Record.PD31= "" ,Convert.DBNull, Record.PD31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN03",SqlDbType.Int,11, Iif(Record.SN03= "" ,Convert.DBNull, Record.SN03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN26",SqlDbType.Int,11, Iif(Record.SN26= "" ,Convert.DBNull, Record.SN26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN02",SqlDbType.Int,11, Iif(Record.SN02= "" ,Convert.DBNull, Record.SN02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN01",SqlDbType.Int,11, Iif(Record.SN01= "" ,Convert.DBNull, Record.SN01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN14",SqlDbType.Int,11, Iif(Record.SN14= "" ,Convert.DBNull, Record.SN14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN28",SqlDbType.Int,11, Iif(Record.SN28= "" ,Convert.DBNull, Record.SN28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN25",SqlDbType.Int,11, Iif(Record.SN25= "" ,Convert.DBNull, Record.SN25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN31",SqlDbType.Int,11, Iif(Record.SN31= "" ,Convert.DBNull, Record.SN31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD28",SqlDbType.NVarChar,3, Iif(Record.PD28= "" ,Convert.DBNull, Record.PD28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN15",SqlDbType.Int,11, Iif(Record.SN15= "" ,Convert.DBNull, Record.SN15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN27",SqlDbType.Int,11, Iif(Record.SN27= "" ,Convert.DBNull, Record.SN27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN29",SqlDbType.Int,11, Iif(Record.SN29= "" ,Convert.DBNull, Record.SN29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN30",SqlDbType.Int,11, Iif(Record.SN30= "" ,Convert.DBNull, Record.SN30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN24",SqlDbType.Int,11, Iif(Record.SN24= "" ,Convert.DBNull, Record.SN24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN18",SqlDbType.Int,11, Iif(Record.SN18= "" ,Convert.DBNull, Record.SN18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN19",SqlDbType.Int,11, Iif(Record.SN19= "" ,Convert.DBNull, Record.SN19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN16",SqlDbType.Int,11, Iif(Record.SN16= "" ,Convert.DBNull, Record.SN16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN17",SqlDbType.Int,11, Iif(Record.SN17= "" ,Convert.DBNull, Record.SN17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN22",SqlDbType.Int,11, Iif(Record.SN22= "" ,Convert.DBNull, Record.SN22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN23",SqlDbType.Int,11, Iif(Record.SN23= "" ,Convert.DBNull, Record.SN23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN20",SqlDbType.Int,11, Iif(Record.SN20= "" ,Convert.DBNull, Record.SN20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN21",SqlDbType.Int,11, Iif(Record.SN21= "" ,Convert.DBNull, Record.SN21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD14",SqlDbType.NVarChar,3, Iif(Record.AD14= "" ,Convert.DBNull, Record.AD14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD13",SqlDbType.NVarChar,3, Iif(Record.AD13= "" ,Convert.DBNull, Record.AD13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD16",SqlDbType.NVarChar,3, Iif(Record.AD16= "" ,Convert.DBNull, Record.AD16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD15",SqlDbType.NVarChar,3, Iif(Record.AD15= "" ,Convert.DBNull, Record.AD15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD10",SqlDbType.NVarChar,3, Iif(Record.AD10= "" ,Convert.DBNull, Record.AD10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD09",SqlDbType.NVarChar,3, Iif(Record.AD09= "" ,Convert.DBNull, Record.AD09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD12",SqlDbType.NVarChar,3, Iif(Record.AD12= "" ,Convert.DBNull, Record.AD12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD11",SqlDbType.NVarChar,3, Iif(Record.AD11= "" ,Convert.DBNull, Record.AD11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD22",SqlDbType.NVarChar,3, Iif(Record.AD22= "" ,Convert.DBNull, Record.AD22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD21",SqlDbType.NVarChar,3, Iif(Record.AD21= "" ,Convert.DBNull, Record.AD21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD24",SqlDbType.NVarChar,3, Iif(Record.AD24= "" ,Convert.DBNull, Record.AD24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD23",SqlDbType.NVarChar,3, Iif(Record.AD23= "" ,Convert.DBNull, Record.AD23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD18",SqlDbType.NVarChar,3, Iif(Record.AD18= "" ,Convert.DBNull, Record.AD18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD17",SqlDbType.NVarChar,3, Iif(Record.AD17= "" ,Convert.DBNull, Record.AD17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD20",SqlDbType.NVarChar,3, Iif(Record.AD20= "" ,Convert.DBNull, Record.AD20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD19",SqlDbType.NVarChar,3, Iif(Record.AD19= "" ,Convert.DBNull, Record.AD19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD04",SqlDbType.NVarChar,3, Iif(Record.AD04= "" ,Convert.DBNull, Record.AD04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD27",SqlDbType.NVarChar,3, Iif(Record.PD27= "" ,Convert.DBNull, Record.PD27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD03",SqlDbType.NVarChar,3, Iif(Record.AD03= "" ,Convert.DBNull, Record.AD03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,251, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD06",SqlDbType.NVarChar,3, Iif(Record.AD06= "" ,Convert.DBNull, Record.AD06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD13",SqlDbType.NVarChar,3, Iif(Record.PD13= "" ,Convert.DBNull, Record.PD13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD07",SqlDbType.NVarChar,3, Iif(Record.AD07= "" ,Convert.DBNull, Record.AD07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD05",SqlDbType.NVarChar,3, Iif(Record.AD05= "" ,Convert.DBNull, Record.AD05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.NVarChar,9, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierRemarks", SqlDbType.NVarChar, 251, IIf(Record.VerifierRemarks = "", Convert.DBNull, Record.VerifierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD08", SqlDbType.NVarChar, 3, IIf(Record.AD08 = "", Convert.DBNull, Record.AD08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD12",SqlDbType.NVarChar,3, Iif(Record.PD12= "" ,Convert.DBNull, Record.PD12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostingRemarks",SqlDbType.NVarChar,251, Iif(Record.PostingRemarks= "" ,Convert.DBNull, Record.PostingRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SAStatusID",SqlDbType.Int,11, Iif(Record.SAStatusID= "" ,Convert.DBNull, Record.SAStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ATNStatusID",SqlDbType.Int,11, Iif(Record.ATNStatusID= "" ,Convert.DBNull, Record.ATNStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD02",SqlDbType.NVarChar,3, Iif(Record.AD02= "" ,Convert.DBNull, Record.AD02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD11",SqlDbType.NVarChar,3, Iif(Record.PD11= "" ,Convert.DBNull, Record.PD11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD01",SqlDbType.NVarChar,3, Iif(Record.AD01= "" ,Convert.DBNull, Record.AD01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD15",SqlDbType.NVarChar,3, Iif(Record.PD15= "" ,Convert.DBNull, Record.PD15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD18",SqlDbType.NVarChar,3, Iif(Record.PD18= "" ,Convert.DBNull, Record.PD18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD17",SqlDbType.NVarChar,3, Iif(Record.PD17= "" ,Convert.DBNull, Record.PD17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD16",SqlDbType.NVarChar,3, Iif(Record.PD16= "" ,Convert.DBNull, Record.PD16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD14",SqlDbType.NVarChar,3, Iif(Record.PD14= "" ,Convert.DBNull, Record.PD14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD24",SqlDbType.NVarChar,3, Iif(Record.PD24= "" ,Convert.DBNull, Record.PD24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD23",SqlDbType.NVarChar,3, Iif(Record.PD23= "" ,Convert.DBNull, Record.PD23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD26",SqlDbType.NVarChar,3, Iif(Record.PD26= "" ,Convert.DBNull, Record.PD26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD25",SqlDbType.NVarChar,3, Iif(Record.PD25= "" ,Convert.DBNull, Record.PD25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD20",SqlDbType.NVarChar,3, Iif(Record.PD20= "" ,Convert.DBNull, Record.PD20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD19",SqlDbType.NVarChar,3, Iif(Record.PD19= "" ,Convert.DBNull, Record.PD19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD22",SqlDbType.NVarChar,3, Iif(Record.PD22= "" ,Convert.DBNull, Record.PD22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD21",SqlDbType.NVarChar,3, Iif(Record.PD21= "" ,Convert.DBNull, Record.PD21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD10",SqlDbType.NVarChar,3, Iif(Record.PD10= "" ,Convert.DBNull, Record.PD10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD30",SqlDbType.NVarChar,3, Iif(Record.AD30= "" ,Convert.DBNull, Record.AD30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD29",SqlDbType.NVarChar,3, Iif(Record.AD29= "" ,Convert.DBNull, Record.AD29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD01",SqlDbType.NVarChar,3, Iif(Record.PD01= "" ,Convert.DBNull, Record.PD01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD31",SqlDbType.NVarChar,3, Iif(Record.AD31= "" ,Convert.DBNull, Record.AD31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD26",SqlDbType.NVarChar,3, Iif(Record.AD26= "" ,Convert.DBNull, Record.AD26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD25",SqlDbType.NVarChar,3, Iif(Record.AD25= "" ,Convert.DBNull, Record.AD25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD28",SqlDbType.NVarChar,3, Iif(Record.AD28= "" ,Convert.DBNull, Record.AD28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD27",SqlDbType.NVarChar,3, Iif(Record.AD27= "" ,Convert.DBNull, Record.AD27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD07",SqlDbType.NVarChar,3, Iif(Record.PD07= "" ,Convert.DBNull, Record.PD07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD06",SqlDbType.NVarChar,3, Iif(Record.PD06= "" ,Convert.DBNull, Record.PD06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD09",SqlDbType.NVarChar,3, Iif(Record.PD09= "" ,Convert.DBNull, Record.PD09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD08",SqlDbType.NVarChar,3, Iif(Record.PD08= "" ,Convert.DBNull, Record.PD08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD03",SqlDbType.NVarChar,3, Iif(Record.PD03= "" ,Convert.DBNull, Record.PD03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD02",SqlDbType.NVarChar,3, Iif(Record.PD02= "" ,Convert.DBNull, Record.PD02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD05",SqlDbType.NVarChar,3, Iif(Record.PD05= "" ,Convert.DBNull, Record.PD05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD04",SqlDbType.NVarChar,3, Iif(Record.PD04= "" ,Convert.DBNull, Record.PD04))
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.NVarChar, 5)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_MonthID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_MonthID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CardNo", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_CardNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.MonthID = Cmd.Parameters("@Return_MonthID").Value
          Record.CardNo = Cmd.Parameters("@Return_CardNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function atnSiteAttendanceUpdate(ByVal Record As SIS.ATN.atnSiteAttendance) As SIS.ATN.atnSiteAttendance
      Dim _Rec As SIS.ATN.atnSiteAttendance = SIS.ATN.atnSiteAttendance.atnSiteAttendanceGetByID(Record.FinYear, Record.MonthID, Record.CardNo)
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
        .SN04 = Record.SN04
        .SN09 = Record.SN09
        .SN08 = Record.SN08
        .SN10 = Record.SN10
        .SN06 = Record.SN06
        .SN07 = Record.SN07
        .SN11 = Record.SN11
        .SN12 = Record.SN12
        .SN13 = Record.SN13
        .SN05 = Record.SN05
        .PD29 = Record.PD29
        .PD30 = Record.PD30
        .PD31 = Record.PD31
        .SN03 = Record.SN03
        .SN26 = Record.SN26
        .SN02 = Record.SN02
        .SN01 = Record.SN01
        .SN14 = Record.SN14
        .SN28 = Record.SN28
        .SN25 = Record.SN25
        .SN31 = Record.SN31
        .PD28 = Record.PD28
        .SN15 = Record.SN15
        .SN27 = Record.SN27
        .SN29 = Record.SN29
        .SN30 = Record.SN30
        .SN24 = Record.SN24
        .SN18 = Record.SN18
        .SN19 = Record.SN19
        .SN16 = Record.SN16
        .SN17 = Record.SN17
        .SN22 = Record.SN22
        .SN23 = Record.SN23
        .SN20 = Record.SN20
        .SN21 = Record.SN21
        .AD14 = Record.AD14
        .AD13 = Record.AD13
        .AD16 = Record.AD16
        .AD15 = Record.AD15
        .AD10 = Record.AD10
        .AD09 = Record.AD09
        .AD12 = Record.AD12
        .AD11 = Record.AD11
        .AD22 = Record.AD22
        .AD21 = Record.AD21
        .AD24 = Record.AD24
        .AD23 = Record.AD23
        .AD18 = Record.AD18
        .AD17 = Record.AD17
        .AD20 = Record.AD20
        .AD19 = Record.AD19
        .AD04 = Record.AD04
        .PostedOn = Record.PostedOn
        .PD27 = Record.PD27
        .AD03 = Record.AD03
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
        .AD06 = Record.AD06
        .PD13 = Record.PD13
        .AD07 = Record.AD07
        .AD05 = Record.AD05
        .ApprovedBy = Record.ApprovedBy
        .PostedBy = Record.PostedBy
        .AD08 = Record.AD08
        .PD12 = Record.PD12
        .PostingRemarks = Record.PostingRemarks
        .SAStatusID = Record.SAStatusID
        .ATNStatusID = Record.ATNStatusID
        .AD02 = Record.AD02
        .PD11 = Record.PD11
        .AD01 = Record.AD01
        .PD15 = Record.PD15
        .PD18 = Record.PD18
        .PD17 = Record.PD17
        .PD16 = Record.PD16
        .PD14 = Record.PD14
        .PD24 = Record.PD24
        .PD23 = Record.PD23
        .PD26 = Record.PD26
        .PD25 = Record.PD25
        .PD20 = Record.PD20
        .PD19 = Record.PD19
        .PD22 = Record.PD22
        .PD21 = Record.PD21
        .PD10 = Record.PD10
        .AD30 = Record.AD30
        .AD29 = Record.AD29
        .PD01 = Record.PD01
        .AD31 = Record.AD31
        .AD26 = Record.AD26
        .AD25 = Record.AD25
        .AD28 = Record.AD28
        .AD27 = Record.AD27
        .PD07 = Record.PD07
        .PD06 = Record.PD06
        .PD09 = Record.PD09
        .PD08 = Record.PD08
        .PD03 = Record.PD03
        .PD02 = Record.PD02
        .PD05 = Record.PD05
        .PD04 = Record.PD04
        .VerifierRemarks = Record.VerifierRemarks
        .VerifiedBy = Record.VerifiedBy
        .VerifiedOn = Record.VerifiedOn
      End With
      Return SIS.ATN.atnSiteAttendance.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ATN.atnSiteAttendance) As SIS.ATN.atnSiteAttendance
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSiteAttendanceUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.NVarChar,5, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MonthID",SqlDbType.Int,11, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID",SqlDbType.Int,11, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD01",SqlDbType.NVarChar,3, Iif(Record.VD01= "" ,Convert.DBNull, Record.VD01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD02",SqlDbType.NVarChar,3, Iif(Record.VD02= "" ,Convert.DBNull, Record.VD02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD03",SqlDbType.NVarChar,3, Iif(Record.VD03= "" ,Convert.DBNull, Record.VD03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD04",SqlDbType.NVarChar,3, Iif(Record.VD04= "" ,Convert.DBNull, Record.VD04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD05",SqlDbType.NVarChar,3, Iif(Record.VD05= "" ,Convert.DBNull, Record.VD05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD06",SqlDbType.NVarChar,3, Iif(Record.VD06= "" ,Convert.DBNull, Record.VD06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD07",SqlDbType.NVarChar,3, Iif(Record.VD07= "" ,Convert.DBNull, Record.VD07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD08",SqlDbType.NVarChar,3, Iif(Record.VD08= "" ,Convert.DBNull, Record.VD08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD09",SqlDbType.NVarChar,3, Iif(Record.VD09= "" ,Convert.DBNull, Record.VD09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD10",SqlDbType.NVarChar,3, Iif(Record.VD10= "" ,Convert.DBNull, Record.VD10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD11",SqlDbType.NVarChar,3, Iif(Record.VD11= "" ,Convert.DBNull, Record.VD11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD12",SqlDbType.NVarChar,3, Iif(Record.VD12= "" ,Convert.DBNull, Record.VD12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD13",SqlDbType.NVarChar,3, Iif(Record.VD13= "" ,Convert.DBNull, Record.VD13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD14",SqlDbType.NVarChar,3, Iif(Record.VD14= "" ,Convert.DBNull, Record.VD14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD15",SqlDbType.NVarChar,3, Iif(Record.VD15= "" ,Convert.DBNull, Record.VD15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD16",SqlDbType.NVarChar,3, Iif(Record.VD16= "" ,Convert.DBNull, Record.VD16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD17",SqlDbType.NVarChar,3, Iif(Record.VD17= "" ,Convert.DBNull, Record.VD17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD18",SqlDbType.NVarChar,3, Iif(Record.VD18= "" ,Convert.DBNull, Record.VD18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD19",SqlDbType.NVarChar,3, Iif(Record.VD19= "" ,Convert.DBNull, Record.VD19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD20",SqlDbType.NVarChar,3, Iif(Record.VD20= "" ,Convert.DBNull, Record.VD20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD21",SqlDbType.NVarChar,3, Iif(Record.VD21= "" ,Convert.DBNull, Record.VD21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD22",SqlDbType.NVarChar,3, Iif(Record.VD22= "" ,Convert.DBNull, Record.VD22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD23",SqlDbType.NVarChar,3, Iif(Record.VD23= "" ,Convert.DBNull, Record.VD23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD24",SqlDbType.NVarChar,3, Iif(Record.VD24= "" ,Convert.DBNull, Record.VD24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD25",SqlDbType.NVarChar,3, Iif(Record.VD25= "" ,Convert.DBNull, Record.VD25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD26",SqlDbType.NVarChar,3, Iif(Record.VD26= "" ,Convert.DBNull, Record.VD26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD27",SqlDbType.NVarChar,3, Iif(Record.VD27= "" ,Convert.DBNull, Record.VD27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD28",SqlDbType.NVarChar,3, Iif(Record.VD28= "" ,Convert.DBNull, Record.VD28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD29",SqlDbType.NVarChar,3, Iif(Record.VD29= "" ,Convert.DBNull, Record.VD29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD30",SqlDbType.NVarChar,3, Iif(Record.VD30= "" ,Convert.DBNull, Record.VD30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VD31",SqlDbType.NVarChar,3, Iif(Record.VD31= "" ,Convert.DBNull, Record.VD31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN04",SqlDbType.Int,11, Iif(Record.SN04= "" ,Convert.DBNull, Record.SN04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN09",SqlDbType.Int,11, Iif(Record.SN09= "" ,Convert.DBNull, Record.SN09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN08",SqlDbType.Int,11, Iif(Record.SN08= "" ,Convert.DBNull, Record.SN08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN10",SqlDbType.Int,11, Iif(Record.SN10= "" ,Convert.DBNull, Record.SN10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN06",SqlDbType.Int,11, Iif(Record.SN06= "" ,Convert.DBNull, Record.SN06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN07",SqlDbType.Int,11, Iif(Record.SN07= "" ,Convert.DBNull, Record.SN07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN11",SqlDbType.Int,11, Iif(Record.SN11= "" ,Convert.DBNull, Record.SN11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN12",SqlDbType.Int,11, Iif(Record.SN12= "" ,Convert.DBNull, Record.SN12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN13",SqlDbType.Int,11, Iif(Record.SN13= "" ,Convert.DBNull, Record.SN13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN05",SqlDbType.Int,11, Iif(Record.SN05= "" ,Convert.DBNull, Record.SN05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD29",SqlDbType.NVarChar,3, Iif(Record.PD29= "" ,Convert.DBNull, Record.PD29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD30",SqlDbType.NVarChar,3, Iif(Record.PD30= "" ,Convert.DBNull, Record.PD30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD31",SqlDbType.NVarChar,3, Iif(Record.PD31= "" ,Convert.DBNull, Record.PD31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN03",SqlDbType.Int,11, Iif(Record.SN03= "" ,Convert.DBNull, Record.SN03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN26",SqlDbType.Int,11, Iif(Record.SN26= "" ,Convert.DBNull, Record.SN26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN02",SqlDbType.Int,11, Iif(Record.SN02= "" ,Convert.DBNull, Record.SN02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN01",SqlDbType.Int,11, Iif(Record.SN01= "" ,Convert.DBNull, Record.SN01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN14",SqlDbType.Int,11, Iif(Record.SN14= "" ,Convert.DBNull, Record.SN14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN28",SqlDbType.Int,11, Iif(Record.SN28= "" ,Convert.DBNull, Record.SN28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN25",SqlDbType.Int,11, Iif(Record.SN25= "" ,Convert.DBNull, Record.SN25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN31",SqlDbType.Int,11, Iif(Record.SN31= "" ,Convert.DBNull, Record.SN31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD28",SqlDbType.NVarChar,3, Iif(Record.PD28= "" ,Convert.DBNull, Record.PD28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN15",SqlDbType.Int,11, Iif(Record.SN15= "" ,Convert.DBNull, Record.SN15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN27",SqlDbType.Int,11, Iif(Record.SN27= "" ,Convert.DBNull, Record.SN27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN29",SqlDbType.Int,11, Iif(Record.SN29= "" ,Convert.DBNull, Record.SN29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN30",SqlDbType.Int,11, Iif(Record.SN30= "" ,Convert.DBNull, Record.SN30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN24",SqlDbType.Int,11, Iif(Record.SN24= "" ,Convert.DBNull, Record.SN24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN18",SqlDbType.Int,11, Iif(Record.SN18= "" ,Convert.DBNull, Record.SN18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN19",SqlDbType.Int,11, Iif(Record.SN19= "" ,Convert.DBNull, Record.SN19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN16",SqlDbType.Int,11, Iif(Record.SN16= "" ,Convert.DBNull, Record.SN16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN17",SqlDbType.Int,11, Iif(Record.SN17= "" ,Convert.DBNull, Record.SN17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN22",SqlDbType.Int,11, Iif(Record.SN22= "" ,Convert.DBNull, Record.SN22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN23",SqlDbType.Int,11, Iif(Record.SN23= "" ,Convert.DBNull, Record.SN23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN20",SqlDbType.Int,11, Iif(Record.SN20= "" ,Convert.DBNull, Record.SN20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SN21",SqlDbType.Int,11, Iif(Record.SN21= "" ,Convert.DBNull, Record.SN21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD14",SqlDbType.NVarChar,3, Iif(Record.AD14= "" ,Convert.DBNull, Record.AD14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD13",SqlDbType.NVarChar,3, Iif(Record.AD13= "" ,Convert.DBNull, Record.AD13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD16",SqlDbType.NVarChar,3, Iif(Record.AD16= "" ,Convert.DBNull, Record.AD16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD15",SqlDbType.NVarChar,3, Iif(Record.AD15= "" ,Convert.DBNull, Record.AD15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD10",SqlDbType.NVarChar,3, Iif(Record.AD10= "" ,Convert.DBNull, Record.AD10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD09",SqlDbType.NVarChar,3, Iif(Record.AD09= "" ,Convert.DBNull, Record.AD09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD12",SqlDbType.NVarChar,3, Iif(Record.AD12= "" ,Convert.DBNull, Record.AD12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD11",SqlDbType.NVarChar,3, Iif(Record.AD11= "" ,Convert.DBNull, Record.AD11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD22",SqlDbType.NVarChar,3, Iif(Record.AD22= "" ,Convert.DBNull, Record.AD22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD21",SqlDbType.NVarChar,3, Iif(Record.AD21= "" ,Convert.DBNull, Record.AD21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD24",SqlDbType.NVarChar,3, Iif(Record.AD24= "" ,Convert.DBNull, Record.AD24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD23",SqlDbType.NVarChar,3, Iif(Record.AD23= "" ,Convert.DBNull, Record.AD23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD18",SqlDbType.NVarChar,3, Iif(Record.AD18= "" ,Convert.DBNull, Record.AD18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD17",SqlDbType.NVarChar,3, Iif(Record.AD17= "" ,Convert.DBNull, Record.AD17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD20",SqlDbType.NVarChar,3, Iif(Record.AD20= "" ,Convert.DBNull, Record.AD20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD19",SqlDbType.NVarChar,3, Iif(Record.AD19= "" ,Convert.DBNull, Record.AD19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD04",SqlDbType.NVarChar,3, Iif(Record.AD04= "" ,Convert.DBNull, Record.AD04))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD27",SqlDbType.NVarChar,3, Iif(Record.PD27= "" ,Convert.DBNull, Record.PD27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD03",SqlDbType.NVarChar,3, Iif(Record.AD03= "" ,Convert.DBNull, Record.AD03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,251, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD06",SqlDbType.NVarChar,3, Iif(Record.AD06= "" ,Convert.DBNull, Record.AD06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD13",SqlDbType.NVarChar,3, Iif(Record.PD13= "" ,Convert.DBNull, Record.PD13))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD07",SqlDbType.NVarChar,3, Iif(Record.AD07= "" ,Convert.DBNull, Record.AD07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD05",SqlDbType.NVarChar,3, Iif(Record.AD05= "" ,Convert.DBNull, Record.AD05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.NVarChar,9, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierRemarks", SqlDbType.NVarChar, 251, IIf(Record.VerifierRemarks = "", Convert.DBNull, Record.VerifierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD08", SqlDbType.NVarChar, 3, IIf(Record.AD08 = "", Convert.DBNull, Record.AD08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD12",SqlDbType.NVarChar,3, Iif(Record.PD12= "" ,Convert.DBNull, Record.PD12))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostingRemarks",SqlDbType.NVarChar,251, Iif(Record.PostingRemarks= "" ,Convert.DBNull, Record.PostingRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SAStatusID",SqlDbType.Int,11, Iif(Record.SAStatusID= "" ,Convert.DBNull, Record.SAStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ATNStatusID",SqlDbType.Int,11, Iif(Record.ATNStatusID= "" ,Convert.DBNull, Record.ATNStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD02",SqlDbType.NVarChar,3, Iif(Record.AD02= "" ,Convert.DBNull, Record.AD02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD11",SqlDbType.NVarChar,3, Iif(Record.PD11= "" ,Convert.DBNull, Record.PD11))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD01",SqlDbType.NVarChar,3, Iif(Record.AD01= "" ,Convert.DBNull, Record.AD01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD15",SqlDbType.NVarChar,3, Iif(Record.PD15= "" ,Convert.DBNull, Record.PD15))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD18",SqlDbType.NVarChar,3, Iif(Record.PD18= "" ,Convert.DBNull, Record.PD18))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD17",SqlDbType.NVarChar,3, Iif(Record.PD17= "" ,Convert.DBNull, Record.PD17))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD16",SqlDbType.NVarChar,3, Iif(Record.PD16= "" ,Convert.DBNull, Record.PD16))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD14",SqlDbType.NVarChar,3, Iif(Record.PD14= "" ,Convert.DBNull, Record.PD14))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD24",SqlDbType.NVarChar,3, Iif(Record.PD24= "" ,Convert.DBNull, Record.PD24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD23",SqlDbType.NVarChar,3, Iif(Record.PD23= "" ,Convert.DBNull, Record.PD23))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD26",SqlDbType.NVarChar,3, Iif(Record.PD26= "" ,Convert.DBNull, Record.PD26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD25",SqlDbType.NVarChar,3, Iif(Record.PD25= "" ,Convert.DBNull, Record.PD25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD20",SqlDbType.NVarChar,3, Iif(Record.PD20= "" ,Convert.DBNull, Record.PD20))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD19",SqlDbType.NVarChar,3, Iif(Record.PD19= "" ,Convert.DBNull, Record.PD19))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD22",SqlDbType.NVarChar,3, Iif(Record.PD22= "" ,Convert.DBNull, Record.PD22))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD21",SqlDbType.NVarChar,3, Iif(Record.PD21= "" ,Convert.DBNull, Record.PD21))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD10",SqlDbType.NVarChar,3, Iif(Record.PD10= "" ,Convert.DBNull, Record.PD10))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD30",SqlDbType.NVarChar,3, Iif(Record.AD30= "" ,Convert.DBNull, Record.AD30))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD29",SqlDbType.NVarChar,3, Iif(Record.AD29= "" ,Convert.DBNull, Record.AD29))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD01",SqlDbType.NVarChar,3, Iif(Record.PD01= "" ,Convert.DBNull, Record.PD01))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD31",SqlDbType.NVarChar,3, Iif(Record.AD31= "" ,Convert.DBNull, Record.AD31))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD26",SqlDbType.NVarChar,3, Iif(Record.AD26= "" ,Convert.DBNull, Record.AD26))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD25",SqlDbType.NVarChar,3, Iif(Record.AD25= "" ,Convert.DBNull, Record.AD25))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD28",SqlDbType.NVarChar,3, Iif(Record.AD28= "" ,Convert.DBNull, Record.AD28))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AD27",SqlDbType.NVarChar,3, Iif(Record.AD27= "" ,Convert.DBNull, Record.AD27))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD07",SqlDbType.NVarChar,3, Iif(Record.PD07= "" ,Convert.DBNull, Record.PD07))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD06",SqlDbType.NVarChar,3, Iif(Record.PD06= "" ,Convert.DBNull, Record.PD06))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD09",SqlDbType.NVarChar,3, Iif(Record.PD09= "" ,Convert.DBNull, Record.PD09))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD08",SqlDbType.NVarChar,3, Iif(Record.PD08= "" ,Convert.DBNull, Record.PD08))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD03",SqlDbType.NVarChar,3, Iif(Record.PD03= "" ,Convert.DBNull, Record.PD03))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD02",SqlDbType.NVarChar,3, Iif(Record.PD02= "" ,Convert.DBNull, Record.PD02))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD05",SqlDbType.NVarChar,3, Iif(Record.PD05= "" ,Convert.DBNull, Record.PD05))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PD04",SqlDbType.NVarChar,3, Iif(Record.PD04= "" ,Convert.DBNull, Record.PD04))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function atnSiteAttendanceDelete(ByVal Record As SIS.ATN.atnSiteAttendance) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnSiteAttendanceDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.NVarChar,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MonthID",SqlDbType.Int,Record.MonthID.ToString.Length, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,Record.CardNo.ToString.Length, Record.CardNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
