Partial Class GD_atnConvertTS2TC
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnConverTS2TC"
    SetGridView = GridView1
  End Sub

	Protected Sub LC_CardNo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_CardNo1.TextChanged
		Session("LC_CardNo") = LC_CardNo1.Text
		Session("LC_CardNoEmployeeName") = LC_CardNoEmployeeName1.Text
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	<System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
		Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
	End Function
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		If Not Session("LC_CardNo") Is Nothing Then
			LC_CardNo1.Text = Session("LC_CardNo").ToString
			LC_CardNoEmployeeName1.Text = Session("LC_CardNoEmployeeName").ToString
		Else
			LC_CardNo1.Text = String.Empty
		End If
	End Sub
  Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
      Exit Sub
    End If
    If e.CommandName.ToLower = "convertts2tc" Then
      Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(e.CommandArgument)
      If oAtnd.Applied = False Then
        'Find Out  balance Leave Type
        Dim LeaveTypeID As String = ""
        Dim BalDays As Decimal = 0
        BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "CL")
        If BalDays >= 0.5 Then
          LeaveTypeID = "CL"
        End If
        If LeaveTypeID = "" Then
          BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "PL")
          If BalDays >= 0.5 Then
            LeaveTypeID = "PL"
          End If
        End If
        If LeaveTypeID = "" Then
          BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "SL")
          If BalDays >= 0.5 Then
            LeaveTypeID = "SL"
          End If
        End If
        If LeaveTypeID = "" Then
          BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "AP")
          If BalDays >= 0.5 Then
            LeaveTypeID = "AP"
          End If
        End If
        If LeaveTypeID <> "" Then
          'Create Autoposted LgrRecord
          Dim _lgr As SIS.ATN.atnLeaveLedger = Nothing
          Dim _lgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(oAtnd.AttenID)
          Dim Found As Boolean = False
          For Each _lgr In _lgrs
            '_lgr will be initialized
            Found = True
            Exit For
          Next
          If Not Found Then
            _lgr = New SIS.ATN.atnLeaveLedger
          End If
          With _lgr
            .ApplDetailID = oAtnd.AttenID
            .ApplHeaderID = ""
            .CardNo = oAtnd.CardNo
            .Days = -0.5
            .InProcessDays = 0
            .LeaveTypeID = LeaveTypeID
            .TranDate = oAtnd.AttenDate
            .TranType = "TRN"
          End With
          If Not Found Then
            SIS.ATN.atnLeaveLedger.Insert(_lgr)
          Else
            SIS.ATN.atnLeaveLedger.Update(_lgr)
          End If
          'Update Attendance Status
          oAtnd.Applied = True
          oAtnd.Posted2LeaveTypeID = LeaveTypeID
          oAtnd.Posted = True
          oAtnd.FinalValue = 1
          oAtnd.TSStatus = "TC"
          oAtnd.TSStatusBy = HttpContext.Current.Session("LoginID")
          oAtnd.TSStatusOn = Now
          SIS.ATN.atnNewAttendance.Update(oAtnd)
          GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
        End If
      End If
    End If
  End Sub
	Protected Sub cmdConvertMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConvertMonth.Click
		If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
			Exit Sub
		End If
		Dim oTSs As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.ALLTSToBeConvertedToTCForMonth(Me.F_Mon.SelectedValue)
		For Each oAtnd As SIS.ATN.atnNewAttendance In oTSs
			If oAtnd.Applied Then
				'Find Out  balance Leave Type
				Dim LeaveTypeID As String = ""
				Dim BalDays As Decimal = 0
				BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "CL")
				If BalDays >= 0.5 Then
					LeaveTypeID = "CL"
				End If
				If LeaveTypeID = "" Then
					BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "PL")
					If BalDays >= 0.5 Then
						LeaveTypeID = "PL"
					End If
				End If
				If LeaveTypeID = "" Then
					BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "SL")
					If BalDays >= 0.5 Then
						LeaveTypeID = "SL"
					End If
				End If
				If LeaveTypeID = "" Then
					BalDays = SIS.ATN.atnLeaveLedger.GetLeaveBalByCardNoType(oAtnd.CardNo, "AP")
					If BalDays >= 0.5 Then
						LeaveTypeID = "AP"
					End If
				End If
				If LeaveTypeID <> "" Then
					'Create Autoposted LgrRecord
					Dim _lgr As SIS.ATN.atnLeaveLedger = Nothing
					Dim _lgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByApplDetailID(oAtnd.AttenID)
					Dim Found As Boolean = False
					For Each _lgr In _lgrs
						'_lgr will be initialized
						Found = True
						Exit For
					Next
					If Not Found Then
						_lgr = New SIS.ATN.atnLeaveLedger
					End If
					With _lgr
						.ApplDetailID = oAtnd.AttenID
						.ApplHeaderID = ""
						.CardNo = oAtnd.CardNo
						.Days = -0.5
						.InProcessDays = 0
						.LeaveTypeID = LeaveTypeID
						.TranDate = oAtnd.AttenDate
						.TranType = "TRN"
					End With
					If Not Found Then
						SIS.ATN.atnLeaveLedger.Insert(_lgr)
					Else
						SIS.ATN.atnLeaveLedger.Update(_lgr)
					End If
					'Update Attendance Status
					oAtnd.Applied = True
					oAtnd.Posted2LeaveTypeID = LeaveTypeID
					oAtnd.Posted = True
					oAtnd.FinalValue = 1
					oAtnd.TSStatus = "TC"
					oAtnd.TSStatusBy = HttpContext.Current.Session("LoginID")
					oAtnd.TSStatusOn = Now
					SIS.ATN.atnNewAttendance.Update(oAtnd)
				End If
			End If
		Next
		GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
	End Sub
End Class
