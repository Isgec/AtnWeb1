Partial Class GT_atnNewAdvanceApplication
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub

	Protected Sub CmdImport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdImport.Click
		LoadAdvanceDates(HttpContext.Current.Session("LoginID"))
	End Sub
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Page.IsPostBack Then
			If Not Page.IsPostBackEventControlRegistered Then
				LoadAdvanceDates(HttpContext.Current.Session("LoginID"))
			End If
		Else
			LoadAdvanceDates(HttpContext.Current.Session("LoginID"))
		End If
	End Sub
	Private Function LoadAdvanceDates(ByVal CardNo As String) As String
		HttpContext.Current.Session("EmployeeUnderProcess") = CardNo
		Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
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
		Dim Opt As RadioButton = Nothing
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
			Row.Cells.Add(Col)

			Col = New TableCell
			Col.CssClass = "rowpurple1"
			Col.Enabled = False

			Txt = New TextBox
			Txt.Text = "AD"
			Txt.ID = "±YY±" & strStartdate
			Txt.Style("display") = "none"
			Col.Controls.Add(Txt)

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
              Pnl.BackColor = Drawing.Color.LightYellow
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
              Txt.MaxLength = 50
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
              Txt.Attributes.Add("onkeypress", "if (this.value.length > 249) { return false; }")
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
    Return SIS.ATN.atnApplHeader.UpdateAppliedLeaveStatus(Context, True)
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
