Partial Class GF_atnEmployees
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = Page.GetType().Name
    SetGridView = GridView1
  End Sub
  Private _EditUrl As String = "~/ATN_Main/App_Edit/EF_atnEmployees.aspx"
  Private _AddUrl As String = "~/ATN_Main/App_Create/AF_atnEmployees.aspx"
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnEmployees.aspx"
  Private _DisplayEdit As Boolean = True
  Private _DisplayInfo As Boolean = False
	Protected Sub cmdRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim oBut As LinkButton = CType(sender, LinkButton)
		Dim CardNo As String = oBut.CommandArgument
		SIS.SYS.Utilities.ApplicationSpacific.RemoveAttendanceAfterReleavingDate(CardNo)
	End Sub
	Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim RedirectUrl As String = _EditUrl & "?Code=" & oBut.CommandArgument.ToString
		Response.Redirect(RedirectUrl)
	End Sub
	Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim RedirectUrl As String = _InfoUrl & "?Code=" & oBut.CommandArgument.ToString
		Response.Redirect(RedirectUrl)
	End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    GridView1.Columns(0).Visible = _DisplayEdit
    GridView1.Columns(1).Visible = _DisplayInfo
    ToolBar0_1.AddUrl = _AddUrl
    ToolBar0_1.EditUrl = _EditUrl
    If Not _DisplayEdit Then
      ToolBar0_1.ToolType = lgToolBar.ToolTypes.lgNDGrid
    End If

  End Sub

  <System.Web.Services.WebMethod(EnableSession:=True)> _
 <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function VerifierIDCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
  End Function
  Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
    e.NewValues("VerifierID") = LC_VerifierID2.Text
    e.NewValues("ApproverID") = LC_ApproverID2.Text
  End Sub
  Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
    If GridView1.EditIndex > -1 Then
      If GridView1.Rows.Count = GridView1.EditIndex + 1 Then
        Dim oLC_VerifierID2 As TextBox = GridView1.Rows(GridView1.EditIndex).FindControl("LC_VerifierID2")
        LC_VerifierID2.Text = oLC_VerifierID2.Text
        Dim oLC_ApproverID2 As TextBox = GridView1.Rows(GridView1.EditIndex).FindControl("LC_ApproverID2")
        LC_ApproverID2.Text = oLC_ApproverID2.Text
      End If
    End If
  End Sub
  Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    If e.CommandName.ToLower = "openingbalance" Then
      Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
      Dim oFyr As SIS.ATN.atnFinYear = SIS.ATN.atnFinYear.GetByID(SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear)
      Dim LastDate As DateTime = Convert.ToDateTime(oFyr.EndDate, ci)

      Dim CardNo As String = e.CommandArgument
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(CardNo)
      If oEmp.Contractual Then Exit Sub
      If oEmp.ActiveState Then
        If Convert.ToDateTime(oEmp.C_DateOfJoining, ci) > Convert.ToDateTime(oFyr.StartDate, ci) Then
          Dim oLgrs As List(Of SIS.ATN.atnLeaveLedger) = SIS.ATN.atnLeaveLedger.GetByCardNo(CardNo, "")
          For Each oLgr As SIS.ATN.atnLeaveLedger In oLgrs
            If oLgr.TranType = "OPB" Then
              If oLgr.LeaveTypeID = "CL" Or oLgr.LeaveTypeID = "SL" Then
                SIS.ATN.atnLeaveLedger.Delete(oLgr)
              End If
            End If
          Next
          Dim WorkDays As Integer = 0
          Dim YrDays As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oFyr.StartDate, ci))
          WorkDays = DateDiff(DateInterval.Day, Convert.ToDateTime(oFyr.EndDate, ci), Convert.ToDateTime(oEmp.C_DateOfJoining, ci))
          Dim cCL As Single = SIS.ATN.lgLedgerBalance.LvRoundof((7 / YrDays) * WorkDays)
          Dim cSL As Single = SIS.ATN.lgLedgerBalance.LvRoundof((8 / YrDays) * WorkDays)
          Dim iLgr As SIS.ATN.atnLeaveLedger
          'Insert CL
          iLgr = New SIS.ATN.atnLeaveLedger
          With iLgr
            .CardNo = CardNo
            .Days = cCL
            .FinYear = SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear
            .InProcessDays = 0
            .LeaveTypeID = "CL"
            .TranDate = Now
            .TranType = "OPB"
          End With
          SIS.ATN.atnLeaveLedger.InsertOpeningBalance(iLgr)
          'Insert SL
          iLgr = New SIS.ATN.atnLeaveLedger
          With iLgr
            .CardNo = CardNo
            .Days = cSL
            .FinYear = SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear
            .InProcessDays = 0
            .LeaveTypeID = "SL"
            .TranDate = Now
            .TranType = "OPB"
          End With
          SIS.ATN.atnLeaveLedger.InsertOpeningBalance(iLgr)
        End If
      End If
    End If
  End Sub

  Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
    'CType(Me.FindControl("content1"), Content).ContentPlaceHolderID = SIS.SYS.Utilities.SessionManager.cphid
  End Sub

  Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad

  End Sub
End Class
