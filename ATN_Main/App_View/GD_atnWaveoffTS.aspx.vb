Partial Class GD_atnWaveoffTS
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = Page.GetType().Name
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
    If e.CommandName.ToLower = "waveoff" Then
      Dim oAtnd As SIS.ATN.atnNewAttendance = SIS.ATN.atnNewAttendance.GetByID(e.CommandArgument)
      If oAtnd.Applied = False Then
        oAtnd.Applied = True
        oAtnd.Posted = True
        oAtnd.FinalValue = 1
        oAtnd.TSStatus = "TW"
        oAtnd.TSStatusBy = HttpContext.Current.Session("LoginID")
        oAtnd.TSStatusOn = Now
        SIS.ATN.atnNewAttendance.Update(oAtnd)
        GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
      End If
    End If
  End Sub
	Protected Sub cmdWaveOffMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWaveOffMonth.Click
		If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
			Exit Sub
		End If
		Dim oTSs As List(Of SIS.ATN.atnNewAttendance) = SIS.ATN.atnNewAttendance.ALLTSToBeWavedoffForMonth(Me.F_Mon.SelectedValue)
		For Each oAtnd As SIS.ATN.atnNewAttendance In oTSs
			If oAtnd.Applied = False Then
				oAtnd.Applied = True
				oAtnd.Posted = True
				oAtnd.FinalValue = 1
				oAtnd.TSStatus = "TW"
				oAtnd.TSStatusBy = HttpContext.Current.Session("LoginID")
				oAtnd.TSStatusOn = Now
				SIS.ATN.atnNewAttendance.Update(oAtnd)
			End If
		Next
		GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
	End Sub
End Class
