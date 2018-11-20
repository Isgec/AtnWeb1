Partial Class GT_atnRegularizeFPAttendance
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Exit Sub
    LoadIncompleteAttendance(HttpContext.Current.Session("LoginID"))
  End Sub
  Private Function LoadIncompleteAttendance(ByVal CardNo As String) As String
    HttpContext.Current.Session("EmployeeUnderProcess") = CardNo


    Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
		Dim oInAtns As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.NewGetAllFPAttendance(CardNo)

		Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)

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

		If oInAtns.Count > 0 Then
			tblWidth = DrawTblDates(oLTs)
			tblRemarks.Style("width") = tblWidth.ToString & "px"
			tdNoDataFound.Style("display") = "none"
			tdRemarks.Style("display") = "block"
		Else
			tdNoDataFound.Style("display") = "block"
			tdRemarks.Style("display") = "none"
		End If

		For Each oAt As SIS.ATN.atnProcessedPunch In oInAtns
			Row = New TableRow

			Col = New TableCell
			Lbl = New Label
			Lbl.ID = "±BB±" & oAt.AttenID
			Lbl.Attributes.Add("onmouseover", "lgValidate.mouseover_date(this);")
			Lbl.Attributes.Add("onmouseout", "lgValidate.mouseout_date(this);")
			Lbl.Text = oAt.AttenDate
			Col.Controls.Add(Lbl)

			Pnl = New Panel
			Pnl.CssClass = "cancel_button"
			Pnl.Style("display") = "none"
			Pnl.ID = "±CC±" & oAt.AttenID
			Pnl.BorderColor = Drawing.Color.Pink
			Pnl.BorderStyle = BorderStyle.Solid
      Pnl.BorderWidth = 1
      Pnl.BackColor = Drawing.Color.Yellow
			Pnl.Height = 20
			Pnl.Style("padding-top") = "8px"
			Lbl = New Label
      Lbl.Text = "<b>Ist Punch: </b>" & oAt.Punch1Time & ", <b>IInd Punch: </b>" & oAt.Punch2Time & ", " & oAt.PunchStatusIDATN_PunchStatus.Description
      'Lbl.Text = "<b>Time : </b>" & oAt.Punch1Time & "<b>Punch Status: </b>" & oAt.PunchStatusIDATN_PunchStatus.Description
			Pnl.Controls.Add(Lbl)
			'new code
			Txt = New TextBox
			Txt.Text = oAt.PunchStatusID
			Txt.ID = "±YY±" & oAt.AttenID
			Txt.Style("display") = "none"
			Pnl.Controls.Add(Txt)
			'new code end
			Shd = New AjaxControlToolkit.DropShadowExtender
			Shd.TargetControlID = Pnl.ClientID
			Shd.Width = 3
			Shd.Opacity = 0.5
			Shd.TrackPosition = True
			Col.Controls.Add(Pnl)
			Col.Controls.Add(Shd)
			Col.CssClass = "rowpurple1"
			Row.Cells.Add(Col)

			Col = New TableCell
			Col.Text = oAt.PunchStatusID
			Col.ToolTip = oAt.PunchStatusIDATN_PunchStatus.Description
			Col.CssClass = "rowpurple1"
			Row.Cells.Add(Col)


			For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
				If oLT.LeaveTypeID <> "FP" Then Continue For
				If oLT.Applyiable Then
					If oLT.MainType Then
						Col = New TableCell
						Chk = New CheckBox
						Chk.ID = "±" & oLT.LeaveTypeID & "±" & oAt.AttenID
						Chk.InputAttributes.Add("onclick", "lgValidate.leavetype_click(this);")
						Chk.ToolTip = oLT.Description

						'Applied With In Days Value Must be picked from Leave Types
						If Convert.ToDateTime(oAt.AttenDate) < SIS.SYS.Utilities.ApplicationSpacific.LastWorkingDateForFP(oEmp.CardNo, ConfigurationManager.AppSettings("FPRegularizeInDays")) Then
							Chk.Enabled = False
						End If


						Col.Controls.Add(Chk)
						Col.CssClass = "rowpurple1"

						'new code
						If oLT.LeaveTypeID = "OD" Then
							Pnl = New Panel
							Pnl.CssClass = "ok_button"
							Pnl.Style("display") = "none"
							Pnl.Style("z-index") = "201"
							Pnl.ID = "±GG±" & oAt.AttenID
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
							Txt.ID = "±HH±" & oAt.AttenID
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
							Txt.ID = "±II±" & oAt.AttenID
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
							But.ID = "±JJ±" & oAt.AttenID
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
			Chk.ID = "±ZZ±" & oAt.AttenID
			Chk.InputAttributes.Add("onclick", "lgValidate.split_click(this);")
			If oAt.PunchValue > 0 Then
				Chk.Enabled = False
				Chk.InputAttributes.Add("disabled", "disabled")
			End If
			Chk.ToolTip = "Click to select two leave types for 1st & 2nd Half."
			Col.Controls.Add(Chk)
			Col.CssClass = "roworange1"
			Row.Cells.Add(Col)

			Col = New TableCell
			Txt = New TextBox
			Txt.ID = "±AA±" & oAt.AttenID
			Txt.CssClass = "mytxt"
			Txt.Width = 40
			Txt.Enabled = False
			Col.Controls.Add(Txt)
			Col.CssClass = "rowpurple1"
			Row.Cells.Add(Col)

			Col = New TableCell
			But = New Image
			But.ImageUrl = "~/App_Themes/Default/Images/openwindow.jpg"
			But.ID = "±DD±" & oAt.AttenID
			But.Attributes.Add("onclick", "lgValidate.showotherleavetype_click(this);")
			Col.Controls.Add(But)
			Tbl = New Table
			Tbl.ID = "±EE±" & oAt.AttenID
			Tbl.Style("display") = "none"
			Tbl.Style("position") = "absolute"
			sRow = New TableRow
			For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
				'All Skiped
				Continue For

				If oLT.Applyiable Then
					If Not oLT.MainType Then
						sCol = New TableCell
						sCol.CssClass = "ok_button"
						Chk = New CheckBox
						Chk.ID = "±" & oLT.LeaveTypeID & "±" & oAt.AttenID
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
			But.ID = "±FF±" & oAt.AttenID
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
		Next
		Return ""
	End Function
	Private Function DrawTblDates(ByVal oLTs As List(Of SIS.ATN.atnLeaveTypes)) As Integer
		Dim tblWidth As Integer = 334
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
		Col.Text = "STATUS"
		Col.Width = 60
		Col.CssClass = "rowpurple0"
		Row.Cells.Add(Col)

		Dim I As Integer = 0
		Dim mStr As String = "<script type=""text/javascript"">" & vbCrLf
		mStr = mStr & "  var aLTs = new Array();" & vbCrLf

		For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
			If oLT.LeaveTypeID <> "FP" Then Continue For
			If oLT.Applyiable Then
				mStr = mStr & "  aLTs[" & I.ToString & "]='" & oLT.LeaveTypeID & "';" & vbCrLf
				If oLT.MainType Then
					Col = New TableCell
					Col.Text = oLT.LeaveTypeID
					Col.ToolTip = oLT.Description
					Col.Width = 170
					Col.CssClass = "rowpurple0"
					Row.Cells.Add(Col)
					tblWidth += 155
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

		If Not Page.ClientScript.IsClientScriptBlockRegistered("AdvanceLeaveTypeChanged") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "AdvanceLeaveTypeChanged", mStr)
		End If
		Return tblWidth
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
  Public Shared Function UpdateAppliedLeaveStatus(ByVal Context As String) As String
    Return SIS.ATN.atnApplHeader.UpdateAppliedLeaveStatus(Context)
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)> _
  Public Shared Function ShowLeaveCard(ByVal Context As String) As String
    Return SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(SIS.ATN.lgLedgerBalance.GetLeadgerBalance(Context))
  End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function CheckAppliedLeaves(ByVal Context As String) As String
		Return SIS.ATN.atnLeaveLedger.NewCheckAppliedLeaves(Context)
	End Function
  'Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
  '	If Session("onContract") = True Then
  '     'Me.MasterPageFile = "~/MasterCPage.master"
  '	End If

  'End Sub

End Class
