Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnAttendanceStatus
		Public Property ForeColor() As Drawing.Color
			Get
        Dim cl As Drawing.Color = Drawing.Color.Black
        Select Case _PunchStatusID
          Case "PR"
            cl = Drawing.Color.Green
          Case "AS", "AF", "AD"
            cl = Drawing.Color.Red
            If _Applied Then
              If Not _Posted Then
                cl = Drawing.Color.Blue
              Else
                cl = Drawing.Color.DarkOrchid
              End If
            ElseIf _ApplStatusID = "7" Then
              'Rejected
              cl = Drawing.Color.DarkMagenta
            End If
          Case "WO", "HD", "NH"
            cl = Drawing.Color.Orange
        End Select
        Return cl
      End Get
			Set(ByVal value As Drawing.Color)

			End Set
    End Property
    Private _OfficeID As Integer = 0
    Private _emp As SIS.ATN.atnEmployees = Nothing
    Public ReadOnly Property nOfficeID As Integer
      Get
        If _emp IsNot Nothing Then
          Return _OfficeID
        Else
          _emp = SIS.ATN.atnEmployees.GetByID(CardNo)
          _OfficeID = SIS.SYS.Utilities.ApplicationSpacific.GetOfficeID(_emp.C_OfficeID)
          Return _OfficeID
        End If
      End Get
    End Property

		Public Property LateColor() As Drawing.Color
			Get
				Dim cl As Drawing.Color = Drawing.Color.Green
				If Not _Applied Then
					Select Case _NeedsRegularization
						Case True
							cl = Drawing.Color.FromArgb(255, 0, 0)
						Case False
							cl = Drawing.Color.FromArgb(31, 160, 37)
					End Select
				Else
					Select Case _ApplStatusID
						Case 1
							cl = Drawing.Color.FromArgb(51, 102, 204)
						Case 2, 3, 4, 5
							cl = Drawing.Color.FromArgb(51, 204, 51)
						Case 6
							cl = Drawing.Color.FromArgb(153, 0, 255)
						Case 7
							cl = Drawing.Color.FromArgb(255, 102, 0)
					End Select
				End If
        'Dim eTime As Single = 9.3
        'If nOfficeID = 1 Then
        '  eTime = 9.15
        'End If
        'If Convert.ToDecimal(_Punch1Time) > eTime Then
        '  cl = Drawing.Color.Red
        'End If
				Return cl
			End Get
			Set(ByVal value As Drawing.Color)

			End Set
		End Property
	End Class
End Namespace
