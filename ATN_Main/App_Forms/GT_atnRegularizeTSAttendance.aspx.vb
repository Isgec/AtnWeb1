Partial Class GT_atnRegularizeTSAttendance
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim CardNo As String = HttpContext.Current.Session("LoginID")
    Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
    Dim newRule2021 As Boolean = False
    If Convert.ToInt32(oEmp.C_OfficeID) <> hrmOffices.Site And Convert.ToInt32(Session("FinYear")) >= 2021 Then
      newRule2021 = True
    End If
    LoadIncompleteAttendance(oEmp, newRule2021)
  End Sub
  Private Function LoadIncompleteAttendance(oEmp As SIS.ATN.atnEmployees, newRule2021 As Boolean) As String
    Dim Cardno As String = oEmp.CardNo
    HttpContext.Current.Session("EmployeeUnderProcess") = Cardno
    Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
    If Cardno = String.Empty Then
      DrawTblDates(oLTs, newRule2021)
      Return ""
    End If
    Dim OfficeID As String = oEmp.C_OfficeID
    Dim oInAtns As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.NewTSGetAllIncompleteAttendance(Cardno)

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
      tblWidth = DrawTblDates(oLTs, newRule2021)
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
      Lbl.Font.Bold = oAt.HoliDay
      Col.Controls.Add(Lbl)

      Pnl = New Panel
      Pnl.CssClass = "cancel_button"
      Pnl.BackColor = Drawing.Color.Yellow
      Pnl.Style("display") = "none"
      Pnl.ID = "±CC±" & oAt.AttenID
      Pnl.BorderColor = Drawing.Color.Pink
      Pnl.BorderStyle = BorderStyle.Solid
      Pnl.BorderWidth = 1
      Pnl.Height = 20
      Pnl.Style("padding-top") = "8px"
      Lbl = New Label
      Lbl.Style("margin") = "4px"
      Lbl.Text = "<b>Ist Punch: </b>" & oAt.Punch1Time & ", <b>IInd Punch: </b>" & oAt.Punch2Time & ", <b> Punch Status :</b> " & oAt.PunchStatusIDATN_PunchStatus.Description
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
      Col.Attributes.Add("style", "text-align:center;")
      Row.Cells.Add(Col)


      For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
        If oLT.LeaveTypeID <> "SH" Then Continue For
        If newRule2021 Then If ((Not oLT.ApplyiableOffice) Or (Not oLT.MainType)) Then Continue For
        If Not newRule2021 Then If ((Not oLT.Applyiable) Or (Not oLT.MainType)) Then Continue For
        Col = New TableCell
        Col.Attributes.Add("style", "text-align:center;")
        Chk = New CheckBox
        Chk.ID = "±" & oLT.LeaveTypeID & "±" & oAt.AttenID
        Chk.InputAttributes.Add("onclick", "lgValidate.leavetype_click(this);")
        Chk.ToolTip = oLT.Description
        If oLT.LeaveTypeID = "FP" Then
          If Convert.ToDecimal(oAt.Punch2Time) > 0 Then
            Chk.Enabled = False
          End If
        End If
        Col.Controls.Add(Chk)
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
      Col.Attributes.Add("style", "text-align:center;")
      Row.Cells.Add(Col)

      Col = New TableCell
      Txt = New TextBox
      Txt.ID = "±AA±" & oAt.AttenID
      Txt.CssClass = "mytxt"
      Txt.Width = 40
      Txt.Enabled = False
      Col.Controls.Add(Txt)
      Col.Attributes.Add("style", "text-align:center;")
      Row.Cells.Add(Col)

      Col = New TableCell
      Col.Attributes.Add("style", "text-align:center;")
      But = New Image
      But.ImageUrl = "~/App_Themes/Default/Images/openwindow.jpg"
      But.ID = "±DD±" & oAt.AttenID
      But.Attributes.Add("onclick", "lgValidate.showotherleavetype_click(this);")
      Col.Controls.Add(But)
      Tbl = New Table
      Tbl.ID = "±EE±" & oAt.AttenID
      Tbl.Style("display") = "none"
      Tbl.Style("position") = "absolute"
      For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
        If oLT.LeaveTypeID <> "SH" Then Continue For
        If newRule2021 Then If ((Not oLT.ApplyiableOffice) Or (oLT.MainType)) Then Continue For
        If Not newRule2021 Then If ((Not oLT.Applyiable) Or (oLT.MainType)) Then Continue For
        sRow = New TableRow
        sCol = New TableCell
        sCol.HorizontalAlign = HorizontalAlign.Right
        sCol.BackColor = Drawing.Color.LightGray
        Chk = New CheckBox
        Chk.ID = "±" & oLT.LeaveTypeID & "±" & oAt.AttenID
        Chk.Text = oLT.Description
        Chk.ToolTip = oLT.LeaveTypeID
        Chk.TextAlign = TextAlign.Right
        Chk.InputAttributes.Add("onclick", "lgValidate.leavetype_click(this);")
        sCol.Controls.Add(Chk)
        sRow.Cells.Add(sCol)
        Tbl.Rows.Add(sRow)
      Next
      sRow = New TableRow
      sCol = New TableCell
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
      Shd = New AjaxControlToolkit.DropShadowExtender
      Shd.TargetControlID = Tbl.ClientID
      Shd.Width = 3
      Shd.Opacity = 0.7
      Shd.TrackPosition = True
      Col.Controls.Add(Tbl)
      Col.Controls.Add(Shd)
      Row.Cells.Add(Col)

      tblDate.Rows.Add(Row)
    Next
    Return ""
  End Function
  Private Function DrawTblDates(ByVal oLTs As List(Of SIS.ATN.atnLeaveTypes), newRule2021 As Boolean) As Integer
    Dim tblWidth As Integer = 300
    tblDate.Rows.Clear()

    Dim Row As TableRow = Nothing
    Dim Col As TableCell = Nothing

    Row = New TableRow
    Row.Font.Bold = True
    Row.Height = 24

    Col = New TableCell
    Col.Text = "DATE"
    Col.Width = 80
    Col.BackColor = Drawing.Color.LightGray
    Col.Attributes.Add("style", "text-align:center;border:1pt solid gray;")
    Row.Cells.Add(Col)

    Col = New TableCell
    Col.Text = "STATUS"
    Col.Width = 60
    Col.BackColor = Drawing.Color.LightGray
    Col.Attributes.Add("style", "text-align:center;border:1pt solid gray;")
    Row.Cells.Add(Col)

    Dim I As Integer = 0
    Dim mStr As String = "<script type=""text/javascript"">" & vbCrLf
    mStr = mStr & "  var aLTs = new Array();" & vbCrLf

    For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
      If oLT.LeaveTypeID <> "SH" Then Continue For
      If newRule2021 Then If (Not oLT.ApplyiableOffice) Then Continue For
      If Not newRule2021 Then If (Not oLT.Applyiable) Then Continue For
      mStr = mStr & "  aLTs[" & I.ToString & "]='" & oLT.LeaveTypeID & "';" & vbCrLf
      If oLT.MainType Then
        Col = New TableCell
        Col.Text = oLT.Description
        Col.ToolTip = oLT.LeaveTypeID
        Col.Width = 80
        Col.BackColor = Drawing.Color.LightGray
        Col.Attributes.Add("style", "text-align:center;border:1pt solid gray;")
        Row.Cells.Add(Col)
        tblWidth += 80
      End If
      I = I + 1
    Next
    mStr = mStr & "</script>" & vbCrLf

    Col = New TableCell
    Col.Text = "SPLIT"
    Col.ToolTip = "To apply 1st & 2nd Half separately"
    Col.Width = 50
    Col.BackColor = Drawing.Color.LightGray
    Col.Attributes.Add("style", "text-align:center;border:1pt solid gray;")
    Row.Cells.Add(Col)

    Col = New TableCell
    Col.Text = "MARKED"
    Col.Width = 60
    Col.BackColor = Drawing.Color.LightGray
    Col.Attributes.Add("style", "text-align:center;border:1pt solid gray;")
    Row.Cells.Add(Col)

    Col = New TableCell
    Col.Text = "OTHER"
    Col.Width = 50
    Col.BackColor = Drawing.Color.LightGray
    Col.Attributes.Add("style", "text-align:center;border:1pt solid gray;")
    Row.Cells.Add(Col)

    tblDate.Rows.Add(Row)

    If Not Page.ClientScript.IsClientScriptBlockRegistered("AdvanceLeaveTypeChanged") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "AdvanceLeaveTypeChanged", mStr)
    End If
    Return tblWidth
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function UpdateAppliedLeaveStatus(ByVal Context As String) As String
    Return SIS.ATN.atnApplHeader.UpdateAppliedLeaveStatus(Context)
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function ShowLeaveCard(ByVal Context As String) As String
		Return SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(Context))
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function CheckAppliedLeaves(ByVal Context As String) As String
		Return SIS.ATN.atnLeaveLedger.NewCheckAppliedLeaves(Context)
	End Function
End Class
