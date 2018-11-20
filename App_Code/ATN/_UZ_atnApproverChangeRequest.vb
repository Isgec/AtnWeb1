Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnApproverChangeRequest
		Public Property ForeColor() As Drawing.Color
			Get
				If Not Executed Then
					Return Drawing.Color.Green
				End If
				Return Drawing.Color.Red
			End Get
			Set(ByVal value As Drawing.Color)

			End Set
		End Property
		Public Property EnableEdit() As Boolean
			Get
				If Not _Executed Then
					Return True
				End If
				Return False
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
	End Class
End Namespace
