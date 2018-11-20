
Partial Class GT_NewMannualApplication
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
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
	Protected Sub CmdImport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdImport.Click
		LoadAdvanceDates(LC_CardNo1.Text)
	End Sub
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Page.IsPostBack Then
			If Not Page.IsPostBackEventControlRegistered Then
				LoadAdvanceDates(LC_CardNo1.Text)
			End If
		Else
			LoadAdvanceDates(LC_CardNo1.Text)
		End If
	End Sub
	Private Function LoadAdvanceDates(ByVal CardNo As String) As String
		Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
		If CardNo = String.Empty Then
			DrawTblDates(oLTs)
			Return ""
		End If
		HttpContext.Current.Session("EmployeeUnderProcess") = CardNo
		Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		'Dim oInAtns As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.GetAllIncompleteAttendance(CardNo)
		Dim StartDate As DateTime = Convert.ToDateTime(SIS.SYS.Utilities.ApplicationSpacific.LastProcessedDate, ci)
		Dim DataCount As Integer = Convert.ToInt32(F_NextDays.Text)

		Dim Row As TableRow = Nothing
		Dim Col As TableCell = Nothing
		Dim Chk As CheckBox = Nothing
		Dim Txt As TextBox = Nothing
		Dim Lbl As Label = Nothing
		Dim But As Image = Nothing
		Dim Tbl As Table = Nothing
		Dim sRow As TableRow = Nothing
		Dim sCol As TableCell = Nothing
		Dim Shd As AjaxControlToolkit.DropShadowExtender = Nothing
		Dim Pnl As Panel = Nothing
		Dim tblWidth As Integer = 0
		Dim FinYearLastDate As DateTime = Convert.ToDateTime(SIS.SYS.Utilities.ApplicationSpacific.FinYearEndDate, ci)

		tblWidth = DrawTblDates(oLTs)
		tblRemarks.Style("width") = tblWidth.ToString & "px"
		tdNoDataFound.Style("display") = "none"
		tdRemarks.Style("display") = "block"

		Dim I As Integer = 1
		Do While I <= DataCount

			StartDate = StartDate.AddDays(1)
			If StartDate > FinYearLastDate Then
				Exit Do
			End If

			'Check if Allready Applied or Attendance Present
			Dim oPP As SIS.ATN.atnProcessedPunch = SIS.ATN.atnProcessedPunch.GetProcessedPunchByCardNoDate(CardNo, StartDate)
			If Not oPP Is Nothing Then
				Continue Do
			End If

			I = I + 1

			Dim strStartdate As String = StartDate.ToString("dd/MM/yyyy")

			Row = New TableRow

			Col = New TableCell
			Lbl = New Label
			Lbl.Text = strStartdate
			Col.Controls.Add(Lbl)
			Col.CssClass = "rowpurple1"
			'new code
			Txt = New TextBox
			Txt.Text = "AD"
			Txt.ID = "±YY±" & strStartdate
			Txt.Style("display") = "none"
			Col.Controls.Add(Txt)
			Row.Cells.Add(Col)

			Col = New TableCell
			Col.CssClass = "rowpurple1"
			Col.Enabled = False
			Row.Cells.Add(Col)


			For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
				If oLT.LeaveTypeID = "SP" Or oLT.LeaveTypeID = "FP" Or oLT.LeaveTypeID = "SH" Then Continue For
				If oLT.Applyiable Then
					If oLT.MainType Then
						Col = New TableCell
						Chk = New CheckBox
						Chk.ID = "±" & oLT.LeaveTypeID & "±" & strStartdate
						Chk.InputAttributes.Add("onclick", "lgValidate.leavetype_click(this);")
						Chk.ToolTip = oLT.Description
						Col.Controls.Add(Chk)
						Col.CssClass = "rowpurple1"

						'new code
						If oLT.LeaveTypeID = "OD" Then
							Pnl = New Panel
							Pnl.CssClass = "ok_button"
							Pnl.Style("display") = "none"
							Pnl.Style("z-index") = "201"
							Pnl.ID = "±GG±" & strStartdate
							Pnl.BorderColor = Drawing.Color.Pink
							Pnl.BorderStyle = BorderStyle.Solid
							Pnl.BorderWidth = 1
							Pnl.Height = 100
							Pnl.Style("padding-top") = "4px"
							Dim tTbl As New Table
							Dim trow As TableRow = Nothing
							Dim tcol As TableCell = Nothing

							trow = New TableRow

							tcol = New TableCell
							Lbl = New Label
							Lbl.Text = "<b>Destination: </b>"
							tcol.Controls.Add(Lbl)
							trow.Cells.Add(tcol)


							tcol = New TableCell
							Txt = New TextBox
							Txt.ID = "±HH±" & strStartdate
							Txt.Width = 100
							Txt.MaxLength = 30
							Txt.Attributes.Add("onblur", "this.value=this.value.replace(/\'/g,'');")
							tcol.Controls.Add(Txt)
							trow.Cells.Add(tcol)

							tTbl.Rows.Add(trow)

							trow = New TableRow

							tcol = New TableCell
							Lbl = New Label
							Lbl.Text = "<b>Purpose: </b>"
							tcol.Controls.Add(Lbl)
							trow.Cells.Add(tcol)


							tcol = New TableCell
							Txt = New TextBox
							Txt.ID = "±II±" & strStartdate
							Txt.Width = 200
							Txt.Height = 40
							Txt.TextMode = TextBoxMode.MultiLine
							Txt.MaxLength = 250
							Txt.Attributes.Add("onblur", "this.value=this.value.replace(/\'/g,'');")
							tcol.Controls.Add(Txt)
							trow.Cells.Add(tcol)

							tTbl.Rows.Add(trow)

							trow = New TableRow
							tcol = New TableCell
							tcol.ColumnSpan = 2
							But = New Image
							But.Height = 18
							But.Width = 18
							But.ImageUrl = "~/App_Themes/Default/Images/closewindow.png"
							But.ID = "±JJ±" & strStartdate
							But.Attributes.Add("onclick", "lgValidate.hideODdetail_click(this);")
							tcol.Controls.Add(But)
							trow.Cells.Add(tcol)
							tTbl.Rows.Add(trow)


							Pnl.Controls.Add(tTbl)
							Shd = New AjaxControlToolkit.DropShadowExtender
							Shd.TargetControlID = Pnl.ClientID
							Shd.Width = 3
							Shd.Opacity = 0.5
							Shd.TrackPosition = True
							Col.Controls.Add(Pnl)
							Col.Controls.Add(Shd)
						End If
						'end new code

						Row.Cells.Add(Col)
					End If
				End If
			Next


			Col = New TableCell
			Chk = New CheckBox
			Chk.ID = "±ZZ±" & strStartdate
			Chk.InputAttributes.Add("onclick", "lgValidate.split_click(this);")
			Chk.ToolTip = "Click to select two leave types for 1st & 2nd Half."
			Col.Controls.Add(Chk)
			Col.CssClass = "roworange1"
			Row.Cells.Add(Col)

			Col = New TableCell
			Txt = New TextBox
			Txt.ID = "±AA±" & strStartdate
			Txt.CssClass = "mytxt"
			Txt.Width = 40
			Txt.Enabled = False
			Col.Controls.Add(Txt)
			Col.CssClass = "rowpurple1"
			Row.Cells.Add(Col)

			Col = New TableCell
			But = New Image
			But.ImageUrl = "~/App_Themes/Default/Images/openwindow.jpg"
			But.ID = "±DD±" & strStartdate
			But.Attributes.Add("onclick", "lgValidate.showotherleavetype_click(this);")
			Col.Controls.Add(But)
			Tbl = New Table
			Tbl.ID = "±EE±" & strStartdate
			Tbl.Style("display") = "none"
			Tbl.Style("position") = "absolute"
			sRow = New TableRow
			For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
				If oLT.Applyiable Then
					If Not oLT.MainType Then
						sCol = New TableCell
						sCol.CssClass = "ok_button"
						Chk = New CheckBox
						Chk.ID = "±" & oLT.LeaveTypeID & "±" & strStartdate
						Chk.Text = oLT.LeaveTypeID
						Chk.ToolTip = oLT.Description
						Chk.TextAlign = TextAlign.Left
						Chk.InputAttributes.Add("onclick", "lgValidate.leavetype_click(this);")
						sCol.Controls.Add(Chk)
						sRow.Cells.Add(sCol)
					End If
				End If
			Next
			sCol = New TableCell
			sCol.CssClass = "ok_button"
			But = New Image
			But.Height = 18
			But.Width = 18
			But.ImageUrl = "~/App_Themes/Default/Images/closewindow.png"
			But.ID = "±FF±" & strStartdate
			But.Attributes.Add("onclick", "lgValidate.hideotherleavetype_click(this);")
			sCol.Controls.Add(But)
			sRow.Cells.Add(sCol)

			Tbl.Rows.Add(sRow)
			Tbl.BorderColor = Drawing.Color.DarkGreen
			Tbl.BorderStyle = BorderStyle.Solid
			Tbl.BorderWidth = 1
			Tbl.Height = 30
			Shd = New AjaxControlToolkit.DropShadowExtender
			Shd.TargetControlID = Tbl.ClientID
			Shd.Width = 3
			Shd.Opacity = 0.5
			Shd.TrackPosition = True
			Col.Controls.Add(Tbl)
			Col.Controls.Add(Shd)
			Col.CssClass = "rowpurple1"
			Row.Cells.Add(Col)

			tblDate.Rows.Add(Row)
		Loop
		Return ""
	End Function
	Private Function DrawTblDates(ByVal oLTs As List(Of SIS.ATN.atnLeaveTypes)) As Integer
		Dim tblWidth As Integer = 374
		tblDate.Rows.Clear()

		Dim Row As TableRow = Nothing
		Dim Col As TableCell = Nothing

		Row = New TableRow
		Row.Font.Bold = True
		Row.Height = 24

		Col = New TableCell
		Col.Text = "DATE"
		Col.Width = 80
		Col.CssClass = "rowpurple0"
		Row.Cells.Add(Col)

		Col = New TableCell
		Col.Text = "AD AF AS"
		Col.Width = 100
		Col.CssClass = "rowpurple0"
		Row.Cells.Add(Col)

		Dim I As Integer = 0
		Dim mStr As String = "<script type=""text/javascript"">" & vbCrLf
		mStr = mStr & "  var aLTs = new Array();" & vbCrLf

		For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
			If oLT.LeaveTypeID = "SP" Or oLT.LeaveTypeID = "FP" Or oLT.LeaveTypeID = "SH" Then Continue For
			If oLT.Applyiable Then
				mStr = mStr & "  aLTs[" & I.ToString & "]='" & oLT.LeaveTypeID & "';" & vbCrLf
				If oLT.MainType Then
					Col = New TableCell
					Col.Text = oLT.LeaveTypeID
					Col.ToolTip = oLT.Description
					Col.Width = 40
					Col.CssClass = "rowpurple0"
					Row.Cells.Add(Col)
					tblWidth += 40
				End If
				I = I + 1
			End If
		Next
		mStr = mStr & "</script>" & vbCrLf

		Col = New TableCell
		Col.Text = "SPLIT"
		Col.ToolTip = "To apply 1st & 2nd Half separately"
		Col.Width = 50
		Col.CssClass = "roworange0"
		Row.Cells.Add(Col)

		Col = New TableCell
		Col.Text = "MARKED"
		Col.Width = 60
		Col.CssClass = "rowpurple0"
		Row.Cells.Add(Col)

		Col = New TableCell
		Col.Text = "OTHER"
		Col.Width = 50
		Col.CssClass = "rowpurple0"
		Row.Cells.Add(Col)

		tblDate.Rows.Add(Row)

		If Not Page.ClientScript.IsClientScriptBlockRegistered("LeaveTypeChanged") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "LeaveTypeChanged", mStr)
		End If
		Return tblWidth
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function UpdateAppliedLeaveStatus(ByVal Context As String) As String
		'Revalidate Before Posting
		Dim MaySubmit As Boolean = False
		SIS.ATN.atnLeaveLedger.NewCheckAppliedLeaves(Context, MaySubmit)
		If Not MaySubmit Then Return "true"
		'End of Revalidation

		Dim oCon As SIS.ATN.LeaveContext = New SIS.ATN.LeaveContext(Context, True)
		Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(HttpContext.Current.Session("EmployeeUnderProcess"))

		Dim oAppl As New SIS.ATN.atnApplHeader
		Dim ApplStatus As Integer = 1
		With oAppl
			.CardNo = oEmp.CardNo
			.VerificationRequired = oEmp.VerificationRequired
			.VerifiedBy = oEmp.VerifierID
			.ApprovalRequired = oEmp.ApprovalRequired
			.ApprovedBy = oEmp.ApproverID
			.AppliedOn = Now
			.Remarks = oCon.Remarks
			.SanctionRequired = oCon.SanctionRequired
			.SanctionedBy = oCon.SanctionBy
			ApplStatus = 5
			.ApplStatusID = ApplStatus
			.AdvanceApplication = True
			.ExecutionState = 1
		End With
		oAppl.LeaveApplID = SIS.ATN.atnApplHeader.Insert(oAppl)
		For Each apl As SIS.ATN.LeaveContextDetail In oCon.LeaveContextDetails
			Dim onPP As New SIS.ATN.atnProcessedPunch
			With onPP
				.AttenDate = apl.AttenDate
				.CardNo = oEmp.CardNo
				.NeedsRegularization = True
				.Punch1Time = 0
				.Punch2Time = 0
				.AdvanceApplication = True
				.PunchStatusID = "AD"
				.PunchValue = 0
				.FinalValue = 0
			End With
			onPP.AttenID = SIS.ATN.atnProcessedPunch.Insert(onPP)
			Dim oPP As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(onPP.AttenID)
			oPP.Applied = True
			oPP.ApplStatusID = ApplStatus
			oPP.ApplHeaderID = oAppl.LeaveApplID
			If oPP.PunchStatusID = "AF" Then
				oPP.Applied1LeaveTypeID = apl.LeaveType1
				oPP.Posted1LeaveTypeID = apl.LeaveType1
				oPP.AppliedValue = 0.5
			ElseIf oPP.PunchStatusID = "AS" Or oPP.PunchStatusID = "TS" Then
				oPP.Applied2LeaveTypeID = apl.LeaveType1
				oPP.Posted2LeaveTypeID = apl.LeaveType1
				oPP.AppliedValue = 0.5
			ElseIf oPP.PunchStatusID = "AD" Then
				oPP.Applied1LeaveTypeID = apl.LeaveType1
				oPP.Applied2LeaveTypeID = apl.LeaveType1
				oPP.Posted1LeaveTypeID = apl.LeaveType1
				oPP.Posted2LeaveTypeID = apl.LeaveType1
				oPP.AppliedValue = 1
				If apl.LeaveType2 <> String.Empty Then
					oPP.Applied2LeaveTypeID = apl.LeaveType2
					oPP.Posted2LeaveTypeID = apl.LeaveType2
				End If
			End If
			SIS.ATN.atnAttendance.Update(oPP)
			'Update InProcess Ledger
			If oPP.PunchStatusID = "AF" Then
				Dim oLgr As New SIS.ATN.atnLeaveLedger
				With oLgr
					.CardNo = oEmp.CardNo
					.ApplHeaderID = oAppl.LeaveApplID
					.ApplDetailID = oPP.AttenID
					.InProcessDays = 0.5
					.LeaveTypeID = apl.LeaveType1
					.TranType = "TRN"
				End With
				SIS.ATN.atnLeaveLedger.Insert(oLgr)
			ElseIf oPP.PunchStatusID = "AS" Or oPP.PunchStatusID = "TS" Then
				Dim oLgr As New SIS.ATN.atnLeaveLedger
				With oLgr
					.CardNo = oEmp.CardNo
					.ApplHeaderID = oAppl.LeaveApplID
					.ApplDetailID = oPP.AttenID
					.InProcessDays = 0.5
					.LeaveTypeID = apl.LeaveType1
					.TranType = "TRN"
				End With
				SIS.ATN.atnLeaveLedger.Insert(oLgr)
			ElseIf oPP.PunchStatusID = "AD" Then
				If apl.LeaveType2 <> String.Empty Then
					Dim oLgr As New SIS.ATN.atnLeaveLedger
					With oLgr
						.CardNo = oEmp.CardNo
						.ApplHeaderID = oAppl.LeaveApplID
						.ApplDetailID = oPP.AttenID
						.InProcessDays = 0.5
						.LeaveTypeID = apl.LeaveType1
						.TranType = "TRN"
					End With
					SIS.ATN.atnLeaveLedger.Insert(oLgr)
					oLgr = New SIS.ATN.atnLeaveLedger
					With oLgr
						.CardNo = oEmp.CardNo
						.ApplHeaderID = oAppl.LeaveApplID
						.ApplDetailID = oPP.AttenID
						.InProcessDays = 0.5
						.LeaveTypeID = apl.LeaveType2
						.TranType = "TRN"
					End With
					SIS.ATN.atnLeaveLedger.Insert(oLgr)
				Else
					Dim oLgr As New SIS.ATN.atnLeaveLedger
					With oLgr
						.CardNo = oEmp.CardNo
						.ApplHeaderID = oAppl.LeaveApplID
						.ApplDetailID = oPP.AttenID
						.InProcessDays = 1
						.LeaveTypeID = apl.LeaveType1
						.TranType = "TRN"
					End With
					SIS.ATN.atnLeaveLedger.Insert(oLgr)
				End If
			End If
		Next
		Return "true"
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function ShowLeaveCard(ByVal Context As String) As String
		Return SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(SIS.ATN.lgLedgerBalance.GetLeadgerBalance(Context))
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function CheckAppliedLeaves(ByVal Context As String) As String
		Return SIS.ATN.atnLeaveLedger.NewCheckAppliedLeaves(Context)
	End Function
End Class
