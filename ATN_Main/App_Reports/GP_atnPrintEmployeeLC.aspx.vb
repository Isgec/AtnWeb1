Partial Class GP_atnPrintEmployeeLC
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  <System.Web.Services.WebMethod(EnableSession:=True)>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count)
  End Function
  Private pStr As String = ""
  Private Sub Print(x As String)
    pStr &= x
  End Sub
  Public Sub ProcessReport(emp As String)
    If emp = "" Then Exit Sub
    Dim ResignedCase As Boolean = False
    Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(emp)
    Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
    If oEmp.C_DateOfReleaving <> String.Empty Then ResignedCase = True

    Dim oBals As List(Of SIS.ATN.lgLedgerBalance) = SIS.ATN.lgLedgerBalance.GetLeadgerBalanceWithMonthlyData(oEmp.CardNo)
    If ResignedCase Then
      oBals = SIS.ATN.lgLedgerBalance.FinalizeForResigned(oBals, oEmp.CardNo)
    End If
    pStr = ""

    Print("<h3><u>Leave Card</u></h3>")
    Print("<h5>As On :" & Now.ToString("d") & "</h5>")
    Print("<h5>Date of Releaving :" & oEmp.C_DateOfReleaving & "</h5>")


    Print("<br />")

    Print("<table style=""width: 100%"">")
    Print("<tr>")

    Print("<td style=""width: 120px;text-align:right"">Employee Name:")
    Print("</td>")

    Print("<td><b>" & oEmp.EmployeeName & " [" & oEmp.CardNo & "]</b>")
    Print("</td>")

    Print("<td style=""width: 120px;text-align:right"">Department:")
    Print("</td>")

    Print("<td><b>" & oEmp.C_DepartmentIDHRM_Departments.Description & "</b>")
    Print("</td>")

    Print("<td style=""width: 120px;text-align:right"">Designation:")
    Print("</td>")

    Print("<td><b>" & oEmp.C_DesignationIDHRM_Designations.Description & "</b>")
    Print("</td>")

    Print("</tr>")
    Dim MayPrint As Boolean = True
    If ResignedCase Then
      If Convert.ToDateTime(oEmp.C_DateOfReleaving, ci).Year <> SIS.SYS.Utilities.ApplicationSpacific.ActiveFinYear Then
        Print("<tr>")
        Print("<td colspan=""6"">Pl. change selected year to Employee's last working year.</td>")
        Print("</tr>")
        MayPrint = False
      End If
    End If
    Print("</table>")
    Print("<br />")
    If MayPrint Then
      Print(SIS.ATN.lgLedgerBalance.GetHTMLLeaveCard(oBals, Nothing))
    End If
    divLC.InnerHtml = pStr
  End Sub

  Protected Sub cmdPrint_Click(sender As Object, e As EventArgs)
    Session("LC_CardNo") = LC_CardNo1.Text
    Session("LC_CardNoEmployeeName") = LC_CardNoEmployeeName1.Text
    ProcessReport(LC_CardNo1.Text)
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    If Not Session("LC_CardNo") Is Nothing Then
      LC_CardNo1.Text = Session("LC_CardNo").ToString
      LC_CardNoEmployeeName1.Text = Session("LC_CardNoEmployeeName").ToString
    Else
      LC_CardNo1.Text = String.Empty
    End If
  End Sub
End Class
