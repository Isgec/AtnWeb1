Partial Class GF_atnProcessed1Punch
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnProcessed1Punch"
    SetGridView = GridView1
  End Sub
  Private _EditUrl As String = "~/ATN_Main/App_Edit/EF_atnProcessed1Punch.aspx"
	Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim RedirectUrl As String = _EditUrl & "?Code=" & oBut.CommandArgument.ToString
		Response.Redirect(RedirectUrl)
	End Sub
	Protected Sub cmdProcessed_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		'SIS.SYS.Utilities.ProcessCardPunch.UpdateInterweavingLeaveAfterProcessing(oBut.CommandArgument)
		SIS.SYS.Utilities.NewAttendanceRules.UpdateInterweavingHolidays(oBut.CommandArgument)
	End Sub
	Protected Sub cmdConvert_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		SIS.SYS.Utilities.NewAttendanceRules.ConvertPR2AD(oBut.CommandArgument)
	End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ToolBar0_1.EditUrl = _EditUrl
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
  Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
    If GridView1.EditIndex > -1 Then
      If GridView1.Rows.Count = GridView1.EditIndex + 1 Then
      End If
    End If
  End Sub
End Class
