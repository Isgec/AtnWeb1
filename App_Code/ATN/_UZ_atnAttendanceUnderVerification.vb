Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	<DataObject()> _
 Partial Public Class atnAttendanceUnderVerification
		Private Shared _RecordCount As Integer
		Private _AttenID As Int32
		Private _AttenDate As String
		Private _CardNo As String
		Private _Applied1LeaveTypeID As String
		Private _Applied2LeaveTypeID As String
		Private _ApplHeaderID As String
		Private _ApplStatusID As String
		Private _Destination As String
		Private _Purpose As String
		Private _Employees1_EmployeeName As String
		Private _LeaveTypes2_Description As String
		Private _LeaveTypes3_Description As String
		Private _ApplHeader4_VerifiedBy As String
		Private _Employees5_EmployeeName As String
		Public Property AttenID() As Int32
			Get
				Return _AttenID
			End Get
			Set(ByVal value As Int32)
				_AttenID = value
			End Set
		End Property
		Public Property AttenDate() As String
			Get
				If Not _AttenDate = String.Empty Then
					Return Convert.ToDateTime(_AttenDate).ToString("dd/MM/yyyy")
				End If
				Return _AttenDate
			End Get
			Set(ByVal value As String)
				_AttenDate = value
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
		Public Property Applied1LeaveTypeID() As String
			Get
				Return _Applied1LeaveTypeID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Applied1LeaveTypeID = ""
				Else
					_Applied1LeaveTypeID = value
				End If
			End Set
		End Property
		Public Property Applied2LeaveTypeID() As String
			Get
				Return _Applied2LeaveTypeID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Applied2LeaveTypeID = ""
				Else
					_Applied2LeaveTypeID = value
				End If
			End Set
		End Property
		Public Property ApplHeaderID() As String
			Get
				Return _ApplHeaderID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_ApplHeaderID = ""
				Else
					_ApplHeaderID = value
				End If
			End Set
		End Property
		Public Property ApplStatusID() As String
			Get
				Return _ApplStatusID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_ApplStatusID = ""
				Else
					_ApplStatusID = value
				End If
			End Set
		End Property
		Public Property Destination() As String
			Get
				Return _Destination
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Destination = ""
				Else
					_Destination = value
				End If
			End Set
		End Property
		Public Property Purpose() As String
			Get
				Return _Purpose
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Purpose = ""
				Else
					_Purpose = value
				End If
			End Set
		End Property
		Public Property Employees1_EmployeeName() As String
			Get
				Return _Employees1_EmployeeName
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Employees1_EmployeeName = ""
				Else
					_Employees1_EmployeeName = value
				End If
			End Set
		End Property
		Public Property LeaveTypes2_Description() As String
			Get
				Return _LeaveTypes2_Description
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_LeaveTypes2_Description = ""
				Else
					_LeaveTypes2_Description = value
				End If
			End Set
		End Property
		Public Property LeaveTypes3_Description() As String
			Get
				Return _LeaveTypes3_Description
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_LeaveTypes3_Description = ""
				Else
					_LeaveTypes3_Description = value
				End If
			End Set
		End Property
		Public Property ApplHeader4_VerifiedBy() As String
			Get
				Return _ApplHeader4_VerifiedBy
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_ApplHeader4_VerifiedBy = ""
				Else
					_ApplHeader4_VerifiedBy = value
				End If
			End Set
		End Property
		Public Property Employees5_EmployeeName() As String
			Get
				Return _Employees5_EmployeeName
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Employees5_EmployeeName = ""
				Else
					_Employees5_EmployeeName = value
				End If
			End Set
		End Property
		Public Shared Function GetAttendanceUnderVerification(ByVal VerifiedBy As String) As List(Of SIS.ATN.atnAttendanceUnderVerification)
			Dim Results As List(Of SIS.ATN.atnAttendanceUnderVerification) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatn_LG_AttendanceUnderVerification"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 50, VerifiedBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID", SqlDbType.Int, 10, 2)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnAttendanceUnderVerification)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnAttendanceUnderVerification(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetHTMLAttendanceUnderVerification(ByVal VerifiedBy As String) As String
			Dim mRet As String = ""
			Dim oDays As List(Of SIS.ATN.atnAttendanceUnderVerification) = SIS.ATN.atnAttendanceUnderVerification.GetAttendanceUnderVerification(VerifiedBy)
			mRet = mRet & "<table width=""100%"">"
			mRet = mRet & "<tr>"
			mRet = mRet & "<td class=""bar_greenHeader"" height=""25px"" style=""text-align:left;color: blue""><b>DATE</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right;color: blue""><b>Employee</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right;color: blue""><b>Ist HALF</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:right;color: blue""><b>IInd HALF</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:left;color: blue""><b>Destination</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "<td class=""bar_greenHeader"" style=""text-align:left;color: blue""><b>Purpose</b>"
			mRet = mRet & "</td>"
			mRet = mRet & "</tr>"
			Dim L_Month As Integer = 0
			For Each oDy As SIS.ATN.atnAttendanceUnderVerification In oDays
				If L_Month <> Convert.ToDateTime(oDy.AttenDate).Month Then
					mRet = mRet & "<tr>"
					mRet = mRet & "<td colspan=""6"" style=""color: red""><b><u>" & Convert.ToDateTime(oDy.AttenDate).ToString("MMMM") & "</u></b>"
					mRet = mRet & "</td>"
					L_Month = Convert.ToDateTime(oDy.AttenDate).Month
				End If
				mRet = mRet & "<tr>"
				mRet = mRet & "<td>" & oDy.AttenDate
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & oDy.Employees1_EmployeeName
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & oDy.LeaveTypes2_Description
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:right;padding-right: 2px"">" & oDy.LeaveTypes3_Description
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:left;padding-right: 2px"">" & oDy.Destination
				mRet = mRet & "</td>"
				mRet = mRet & "<td style=""text-align:left;padding-right: 2px"">" & oDy.Purpose
				mRet = mRet & "</td>"
				mRet = mRet & "</tr>"
			Next
			mRet = mRet & "<tr>"
			mRet = mRet & "<td colspan=""6"" style=""text-align:center"">"
			mRet = mRet & "<input type=""image"" src=""../../App_Themes/Default/Images/closewindow.png"" height=""18px"" onclick=""closeWindow();return false;"" title=""Click to close""  />"
			mRet = mRet & "</td>"
			mRet = mRet & "</tr>"
			mRet = mRet & "</table>"
			Return mRet
		End Function
		Public Sub New(ByVal Reader As SqlDataReader)
			On Error Resume Next
			_AttenID = CType(Reader("AttenID"), Int32)
			_AttenDate = CType(Reader("AttenDate"), DateTime)
			_CardNo = CType(Reader("CardNo"), String)
			If Convert.IsDBNull(Reader("Applied1LeaveTypeID")) Then
				_Applied1LeaveTypeID = String.Empty
			Else
				_Applied1LeaveTypeID = CType(Reader("Applied1LeaveTypeID"), String)
			End If
			If Convert.IsDBNull(Reader("Applied2LeaveTypeID")) Then
				_Applied2LeaveTypeID = String.Empty
			Else
				_Applied2LeaveTypeID = CType(Reader("Applied2LeaveTypeID"), String)
			End If
			If Convert.IsDBNull(Reader("ApplHeaderID")) Then
				_ApplHeaderID = String.Empty
			Else
				_ApplHeaderID = CType(Reader("ApplHeaderID"), String)
			End If
			If Convert.IsDBNull(Reader("ApplStatusID")) Then
				_ApplStatusID = String.Empty
			Else
				_ApplStatusID = CType(Reader("ApplStatusID"), String)
			End If
			If Convert.IsDBNull(Reader("Destination")) Then
				_Destination = String.Empty
			Else
				_Destination = CType(Reader("Destination"), String)
			End If
			If Convert.IsDBNull(Reader("Purpose")) Then
				_Purpose = String.Empty
			Else
				_Purpose = CType(Reader("Purpose"), String)
			End If

			If Convert.IsDBNull(Reader("HRM_Employees1_EmployeeName")) Then
				_Employees1_EmployeeName = String.Empty
			Else
				_Employees1_EmployeeName = CType(Reader("HRM_Employees1_EmployeeName"), String)
			End If

			If Convert.IsDBNull(Reader("ATN_LeaveTypes2_Description")) Then
				_LeaveTypes2_Description = String.Empty
			Else
				_LeaveTypes2_Description = CType(Reader("ATN_LeaveTypes2_Description"), String)
			End If
			If Convert.IsDBNull(Reader("ATN_LeaveTypes3_Description")) Then
				_LeaveTypes3_Description = String.Empty
			Else
				_LeaveTypes3_Description = CType(Reader("ATN_LeaveTypes3_Description"), String)
			End If
			If Convert.IsDBNull(Reader("ATN_ApplHeader4_VerifiedBy")) Then
				_ApplHeader4_VerifiedBy = String.Empty
			Else
				_ApplHeader4_VerifiedBy = CType(Reader("ATN_ApplHeader4_VerifiedBy"), String)
			End If
			If Convert.IsDBNull(Reader("HRM_Employees5_EmployeeName")) Then
				_Employees5_EmployeeName = String.Empty
			Else
				_Employees5_EmployeeName = CType(Reader("HRM_Employees5_EmployeeName"), String)
			End If
		End Sub
		Public Sub New()
			'Dummy
		End Sub
	End Class
End Namespace
