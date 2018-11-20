Partial Class GD_atnProcessedPunchStatus
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnAttendanceStatus"
    SetGridView = GridView1
  End Sub
  Protected Sub cmdProcessed_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    SIS.SYS.Utilities.NewAttendanceRules.UpdateLateComing(oBut.CommandArgument)
    GridView1.DataBind()
  End Sub
	Protected Sub cmdPosted_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
    SIS.SYS.Utilities.NewAttendanceRules.UpdateInterweavingHolidays(oBut.CommandArgument)
    GridView1.DataBind()
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
		If Not Session("C_OfficeID") Is Nothing Then
			LC_C_OfficeID1.SelectedValue = Session("C_OfficeID").ToString
		Else
			LC_C_OfficeID1.SelectedValue = String.Empty
		End If
		If Not Session("TextBoxAttenDate") Is Nothing Then
			TextBoxAttenDate.Text = Session("TextBoxAttenDate").ToString
		Else
			TextBoxAttenDate.Text = String.Empty
		End If
  End Sub
  Protected Sub LC_C_OfficeID1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_C_OfficeID1.SelectedIndexChanged
    Session("LC_C_OfficeID") = LC_C_OfficeID1.SelectedValue
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
	Protected Sub TextBoxAttenDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAttenDate.TextChanged
		Session("TextBoxAttenDate") = TextBoxAttenDate.Text
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
End Class
