Partial Class GT_MannualFPRegularization
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub LC_CardNo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_CardNo1.TextChanged
    Session("LC_CardNo") = LC_CardNo1.Text
    Session("LC_CardNoEmployeeName") = LC_CardNoEmployeeName1.Text
    Page_Load(sender, e)
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
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim CardNo As String = LC_CardNo1.Text
    If CardNo = "" Then Exit Sub
    Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
    Dim newRule2021 As Boolean = False
    If Convert.ToInt32(oEmp.C_OfficeID) <> hrmOffices.Site And Convert.ToInt32(Session("FinYear")) >= 2021 Then
      newRule2021 = True
    End If
    LoadIncompleteAttendance(oEmp, newRule2021)
  End Sub
  Private Function LoadIncompleteAttendance(oEmp As SIS.ATN.atnEmployees, newRule2021 As Boolean) As String
    Dim CardNo As String = oEmp.CardNo
    HttpContext.Current.Session("EmployeeUnderProcess") = CardNo
    Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
    If CardNo = String.Empty Then
      DrawTblDates(oLTs, newRule2021)
      Return ""
    End If
    Dim OfficeID As String = oEmp.C_OfficeID
    Dim oInAtns As List(Of SIS.ATN.atnProcessedPunch) = SIS.ATN.atnProcessedPunch.NewGetAllFPAttendanceWithoutFilter(CardNo)

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
      Col.Attributes.Add("style", "text-align:center;")
      Row.Cells.Add(Col)


      For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
        If oLT.LeaveTypeID <> "FP" Then Continue For
        Col = New TableCell
        Col.Attributes.Add("style", "text-align:center;")
        Chk = New CheckBox
        Chk.ID = "±" & oLT.LeaveTypeID & "±" & oAt.AttenID
        Chk.InputAttributes.Add("onclick", "lgValidate.leavetype_click(this);")
        Chk.ToolTip = oLT.Description
        Col.Controls.Add(Chk)

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
        'If oLT.LeaveTypeID <> "FP" Then Continue For
        'sRow = New TableRow
        'sCol = New TableCell
        'sCol.HorizontalAlign = HorizontalAlign.Right
        'sCol.BackColor = Drawing.Color.LightGray
        'Chk = New CheckBox
        'Chk.ID = "±" & oLT.LeaveTypeID & "±" & oAt.AttenID
        'Chk.Text = oLT.Description
        'Chk.ToolTip = oLT.LeaveTypeID
        'Chk.TextAlign = TextAlign.Right
        'Chk.InputAttributes.Add("onclick", "lgValidate.leavetype_click(this);")
        'sCol.Controls.Add(Chk)
        'sRow.Cells.Add(sCol)
        'Tbl.Rows.Add(sRow)
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
      If oLT.LeaveTypeID <> "FP" Then Continue For
      mStr = mStr & "  aLTs[" & I.ToString & "]='" & oLT.LeaveTypeID & "';" & vbCrLf
      Col = New TableCell
      Col.Text = oLT.Description
      Col.ToolTip = oLT.LeaveTypeID
      Col.Width = 80
      Col.BackColor = Drawing.Color.LightGray
      Col.Attributes.Add("style", "text-align:center;border:1pt solid gray;")
      Row.Cells.Add(Col)
      tblWidth += 80
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

    'If Not Page.ClientScript.IsClientScriptBlockRegistered("AdvanceLeaveTypeChanged") Then
    '  Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "AdvanceLeaveTypeChanged", mStr)
    'End If
    Return tblWidth
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)>
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
      ApplStatus = 5  'Direct to posting
      .ApplStatusID = ApplStatus
    End With
    oAppl.LeaveApplID = SIS.ATN.atnApplHeader.Insert(oAppl)
    For Each apl As SIS.ATN.LeaveContextDetail In oCon.LeaveContextDetails
      Dim oPP As SIS.ATN.atnAttendance = SIS.ATN.atnAttendance.GetByID(apl.AttenID)
      oPP.Applied = True
      oPP.ApplStatusID = ApplStatus
      oPP.ApplHeaderID = oAppl.LeaveApplID
      If oPP.PunchStatusID = "AF" Then
        oPP.Applied1LeaveTypeID = apl.LeaveType1
        oPP.Posted1LeaveTypeID = apl.LeaveType1
        oPP.AppliedValue = 0.5
      ElseIf oPP.PunchStatusID = "AS" Then
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
      ElseIf oPP.PunchStatusID = "AS" Then
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
