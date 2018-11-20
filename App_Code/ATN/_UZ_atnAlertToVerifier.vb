Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnAlertToVerifier
		Private _ApplicationCount As Integer
		Private _EMailID As String
		Private _MessageBody As String = "Dear Sir/Madam" & vbCrLf & vbCrLf & "There are some pending leave application(s)." & vbCrLf & "Kindly login in to the Leave Management System and" & vbCrLf & "verify/reject the same." & vbCrLf & vbCrLf & "NOTE: This is system generated E-Mail, please do not reply."
		Public Property Visible() As Boolean
			Get
				If _ApplicationCount > 0 Then
					Return True
				End If
				Return False
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		Public Property ApplicationCount() As Integer
			Get
				Return _ApplicationCount
			End Get
			Set(ByVal value As Integer)
				_ApplicationCount = value
			End Set
		End Property
		Public Property EMailID() As String
			Get
				Return _EMailID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_EMailID = ""
				Else
					_EMailID = value
				End If
			End Set
		End Property
		Public Property MessageBody() As String
			Get
				Return _MessageBody
			End Get
			Set(ByVal value As String)
				_MessageBody = value
			End Set
		End Property
		Public Shared Function AlertSelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnAlertToVerifier)
			Dim Results As List(Of SIS.ATN.atnAlertToVerifier) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If orderBy = String.Empty Then orderBy = "VerifiedBy"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatn_LG_AlertToVerifierSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatn_LG_AlertToVerifierSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID", SqlDbType.Int, 10, 2)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ATN.atnAlertToVerifier)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ATN.atnAlertToVerifier(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
	End Class
End Namespace
