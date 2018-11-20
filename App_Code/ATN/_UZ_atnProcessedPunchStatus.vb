Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnProcessedPunchStatus
		Private _C_OfficeID As String
		Public Property C_OfficeID() As String
			Get
				Return _C_OfficeID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_C_OfficeID = ""
				Else
					_C_OfficeID = value
				End If
			End Set
		End Property
		Public Property ForeColor() As Drawing.Color
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
				Return cl
			End Get
			Set(ByVal value As Drawing.Color)

			End Set
		End Property
	End Class
End Namespace
