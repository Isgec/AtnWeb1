Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnWaveoffTS
		Public Property Visible() As Boolean
			Get
				Return IIf(_TSStatus = "TS" And _Applied = False, True, False)
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
	End Class
End Namespace
