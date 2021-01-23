Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class RegularizeAttendance
    Public Property tblData As Table = Nothing
    Public Property script As String = ""
    Public Property width As Integer = 0
    Public Property emp As SIS.ATN.atnEmployees = Nothing
    Public Property newRule2021 As Boolean = False
    Public Property notFound As Boolean = False
    Public Property oLTs As List(Of SIS.ATN.atnLeaveTypes) = Nothing
    Public Property oInAtns As List(Of SIS.ATN.atnProcessedPunch) = Nothing
    Public Property forHR As Boolean = False
    Public Property isOD As Boolean = False
    Public Property isFP As Boolean = False
    Public Property isTS As Boolean = False
    Public Shared Function LoadRegularize(mRet As SIS.ATN.RegularizeAttendance) As SIS.ATN.RegularizeAttendance
      HttpContext.Current.Session("EmployeeUnderProcess") = mRet.emp.CardNo
      Dim oInAtns As List(Of SIS.ATN.atnProcessedPunch) = Nothing
      If Not mRet.forHR Then
        oInAtns = SIS.ATN.atnProcessedPunch.NewGetAllIncompleteAttendance(mRet.emp.CardNo)
      Else
        oInAtns = SIS.ATN.atnProcessedPunch.NewGetAllIncompleteAttendanceWithoutFilter(mRet.emp.CardNo)
      End If
      If oInAtns.Count <= 0 Then
        mRet.notFound = True
        Return mRet
      End If
      mRet.oLTs = SIS.ATN.atnLeaveTypes.SelectList("Sequence")
      mRet = CreateHeader(mRet)
      mRet.oInAtns = oInAtns
      mRet = LoadData(mRet)
      mRet.oLTs = Nothing
      mRet.oInAtns = Nothing
      Return mRet
    End Function

    Public Shared Function LoadData(mRet As SIS.ATN.RegularizeAttendance) As SIS.ATN.RegularizeAttendance
      Dim oEmp As SIS.ATN.atnEmployees = mRet.emp
      Dim newRule2021 As Boolean = mRet.newRule2021
      Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = mRet.oLTs
      Dim oInAtns As List(Of SIS.ATN.atnProcessedPunch) = mRet.oInAtns
      Dim OfficeID As String = oEmp.C_OfficeID

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

        '=====================SH Enabled
        Dim SHEnabled As Boolean = False
        Select Case Convert.ToInt32(OfficeID)
          Case enumOffices.Chennai, enumOffices.Site, enumOffices.Kolkata, enumOffices.Mumbai
            If Convert.ToDecimal(oAt.Punch1Time > 0 And oAt.Punch2Time > 0) Then
              If oAt.PunchStatusID = "AS" Or oAt.PunchStatusID = "AF" Or oAt.PunchStatusID = "TS" Then
                'For Morning Short Leave
                If Convert.ToDecimal(oAt.Punch2Time) >= 17.4 Then
                  Dim hrs As Decimal = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(oAt.Punch1Time, 17.45)
                  If hrs >= 6.45 Then
                    SHEnabled = True
                  End If
                Else
                  'Evening Short Time
                  If Convert.ToDecimal(oAt.Punch1Time) <= 9.3 Then
                    Dim FirstPunchTime As Decimal = 9.0
                    If Convert.ToDecimal(oAt.Punch1Time) > 9.0 Then
                      FirstPunchTime = oAt.Punch1Time
                    End If
                    Dim hrs As Decimal = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(FirstPunchTime, oAt.Punch2Time)
                    If hrs >= 6.45 Then
                      SHEnabled = True
                    End If
                  End If
                End If
              End If
            End If
          Case Else
            If Convert.ToDecimal(oAt.Punch1Time > 0 And oAt.Punch2Time > 0) Then
              If oAt.PunchStatusID = "AS" Or oAt.PunchStatusID = "AF" Or oAt.PunchStatusID = "TS" Then
                'For Morning Short Leave
                If Convert.ToDecimal(oAt.Punch2Time) >= 17.25 Then
                  Dim hrs As Decimal = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(oAt.Punch1Time, 17.3)
                  If hrs >= 6.45 Then
                    SHEnabled = True
                  End If
                Else
                  'Evening Short Time
                  If Convert.ToDecimal(oAt.Punch1Time) <= 9.15 Then
                    Dim FirstPunchTime As Decimal = 8.45
                    If Convert.ToDecimal(oAt.Punch1Time) > 8.45 Then
                      FirstPunchTime = oAt.Punch1Time
                    End If
                    Dim hrs As Decimal = SIS.SYS.Utilities.NewAttendanceRules.DiffTime(FirstPunchTime, oAt.Punch2Time)
                    If hrs >= 6.45 Then
                      SHEnabled = True
                    End If
                  End If
                End If
              End If
            End If
        End Select
        '==================
        For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
          If oLT.LeaveTypeID = "SP" Then Continue For
          If Not mRet.isFP Then If oLT.LeaveTypeID = "FP" Then Continue For
          If Not mRet.isOD Then If oLT.LeaveTypeID = "OD" Then Continue For
          If Not mRet.isTS Then If oLT.LeaveTypeID = "TS" Then Continue For

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
          If oLT.LeaveTypeID = "SH" Then
            Chk.Enabled = SHEnabled
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

        mRet.tblData.Rows.Add(Row)
      Next
      Return mRet
    End Function

    Public Shared Function CreateHeader(mRet As SIS.ATN.RegularizeAttendance) As SIS.ATN.RegularizeAttendance
      Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = mRet.oLTs
      Dim newRule2021 As Boolean = mRet.newRule2021
      Dim tblDate As New Table
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
        If oLT.LeaveTypeID = "SP" Or oLT.LeaveTypeID = "FP" Or oLT.LeaveTypeID = "OD" Then Continue For
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

      mRet.tblData = tblDate
      mRet.script = mStr
      mRet.width = tblWidth

      Return mRet
    End Function
  End Class
End Namespace
