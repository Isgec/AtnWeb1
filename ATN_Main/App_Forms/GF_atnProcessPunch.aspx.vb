Partial Class GF_atnProcessPunch
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnProcessPunch"
    SetGridView = GridView1
  End Sub
  Protected Sub cmdProcess_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
      Exit Sub
    End If
    Dim LastTimeOut As Integer = 60
    Dim oSM As ScriptManager = Me.Master.FindControl("ToolkitScriptManager1")
    If Not oSM Is Nothing Then
      LastTimeOut = oSM.AsyncPostBackTimeout
      oSM.AsyncPostBackTimeout = 1200
    End If
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    Dim oBut As ImageButton = CType(sender, ImageButton)

    'Modified
    Dim oPD As SIS.ATN.atnProcessPunch = SIS.ATN.atnProcessPunch.GetByID(oBut.CommandArgument.ToString)
    Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
    Dim pDT As DateTime = Convert.ToDateTime(oPD.ProcessDate, ci)
    Dim rDT As DateTime = Convert.ToDateTime("01/10/2010", ci)
    If pDT >= rDT Then
      Dim ErrStr As String = ""
      ErrStr = SIS.SYS.Utilities.NewAttendanceRules.ProcessData(pDT.ToString("dd/MM/yyyy"), pDT.ToString("dd/MM/yyyy"), "", True)
      If ErrStr.Length > 0 Then
        Dim aErr() As String = ErrStr.Split("|".ToCharArray)
        Dim row As TableRow = Nothing
        Dim col As TableCell = Nothing
        tblerr.Rows.Clear()
        For Each Str As String In aErr
          row = New TableRow
          col = New TableCell
          col.Text = Str
          row.Cells.Add(col)
          tblerr.Rows.Add(row)
        Next
      End If
    Else
      SIS.SYS.Utilities.ProcessCardPunch.ProcessForDate(oBut.CommandArgument.ToString)
    End If
    'End of Modified

    oSM.AsyncPostBackTimeout = LastTimeOut
    GridView1.Sort(GridView1.SortExpression, SortDirection.Descending)
    If Not oSM Is Nothing Then
      oSM.AsyncPostBackTimeout = LastTimeOut
    End If
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
  End Sub
  Protected Sub cmdInsert_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdInsert.Click
    Dim dt As DateTime = SIS.SYS.Utilities.ApplicationSpacific.LastProcessedDate
    Dim oPD As New SIS.ATN.atnProcessPunch
    oPD.ProcessDate = dt.AddDays(1)
    SIS.ATN.atnProcessPunch.Insert(oPD)
    GridView1.Sort(GridView1.SortExpression, SortDirection.Descending)
  End Sub
End Class
