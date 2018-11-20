Imports System.Data.SqlClient
Imports System.Data
Partial Class GP_atnPrintLedger
	Inherits System.Web.UI.Page

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
		Dim oTS As IO.StreamReader = New IO.StreamReader("C:\inetpub\wwwroot\webatnd1\app_data\email.cln")
		Dim mstr As String = oTS.ReadLine()
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Con.Open()
			Do While Not mstr Is Nothing
				Dim astr() As String = mstr.Split(",".ToCharArray)
				If astr.Length > 1 Then
					Using Cmd As SqlCommand = Con.CreateCommand()
						Cmd.CommandType = CommandType.Text
						Cmd.CommandText = "update aspnet_users set emailid = '" & astr(1).Trim & "' where username = '" & astr(0) & "'"
						Cmd.ExecuteNonQuery()
					End Using
				End If
				mstr = oTS.ReadLine()
			Loop
		End Using
		oTS.Close()

	End Sub
	Private lastTime As String = ""
	Private Function SetPunch9Time(ByVal Punch2Time As String) As String
		Dim Punch9Time As String = ""
		If Punch2Time <> String.Empty Then
			If Punch2Time > "18.15" Then
				If Punch9Time >= "17.45" And Punch9Time <= "18.15" Then
					'do nothing,time has allready  been derived
				Else
					'Else derive time
					Dim aa As Random = New Random
					Dim bb As Double = 0
					Do While True
						Do
							bb = aa.NextDouble()
						Loop While Left(bb.ToString, 4) = lastTime
						If bb > 0.46 And bb <= 0.6 Then
							Exit Do
						End If
						If bb > 0.01 And bb <= 0.15 Then
							Exit Do
						End If
					Loop
					lastTime = Left(bb.ToString, 4)
					If bb > 0.01 And bb <= 0.15 Then
						Punch9Time = Left((18 + bb).ToString, 4)
					Else
						Punch9Time = Left((17 + bb).ToString, 4)
					End If
				End If
			Else
				Punch9Time = Punch2Time
			End If
		Else
			Punch9Time = ""
		End If
		Return Punch9Time
	End Function
	Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
		Dim LastTimeOut As Integer = 60
    Dim oSM As ScriptManager = Me.Master.FindControl("ToolkitScriptManager1")
		If Not oSM Is Nothing Then
			LastTimeOut = oSM.AsyncPostBackTimeout
			oSM.AsyncPostBackTimeout = 1200
		End If
		Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
		HttpContext.Current.Server.ScriptTimeout = 1200

		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = "select * from atn_attendance where month(attendate) = " & F_FMon.SelectedValue & " and punch2time > 0 "
					Con.Open()
					Con1.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Dim cmd1 As SqlCommand = Con1.CreateCommand
						Dim Punch9Time As String = SetPunch9Time(Reader("Punch2Time"))
						With cmd1
							.CommandTimeout = 15000
							.CommandType = CommandType.Text
							.CommandText = "update atn_attendance set punch9time=" & Punch9Time & " where attenid=" & Reader("Attenid")
							cmd1.ExecuteNonQuery()
						End With
					End While
					Reader.Close()
				End Using
			End Using
		End Using

		oSM.AsyncPostBackTimeout = LastTimeOut
		If Not oSM Is Nothing Then
			oSM.AsyncPostBackTimeout = LastTimeOut
		End If
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout

	End Sub
End Class
