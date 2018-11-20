Partial Class GP_atnAverageDelayInRegularization
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim oLTs As List(Of SIS.ATN.atnLeaveTypes) = SIS.ATN.atnLeaveTypes.SelectList("Sequence")

		Dim Row As TableRow = Nothing
		Dim Col As TableCell = Nothing
		Dim Chk As CheckBox = Nothing
		Dim Lbl As Label = Nothing

		For Each oLT As SIS.ATN.atnLeaveTypes In oLTs
			If oLT.Applyiable Then
				Row = New TableRow

				Col = New TableCell
				Col.Text = oLT.Description
				Row.Cells.Add(Col)

				Col = New TableCell
				Chk = New CheckBox
				Chk.ID = "±" & oLT.LeaveTypeID
				Chk.InputAttributes.Add("onclick", "leavetype_click(this);")
				Chk.ToolTip = oLT.Description
				Col.Controls.Add(Chk)
				Row.Cells.Add(Col)

				Row.Cells.Add(Col)

				Tbl1.Rows.Add(Row)
			End If
		Next

	End Sub
End Class
