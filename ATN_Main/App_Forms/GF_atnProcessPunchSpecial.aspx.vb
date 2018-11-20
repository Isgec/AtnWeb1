Partial Class GF_atnProcessPunchSpecial
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub cmdIndividual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIndividual.Click
    If Convert.ToInt32(HttpContext.Current.Session("FinYear")) <> SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear Then
      Exit Sub
    End If
    Dim LastTimeOut As Integer = 60
    Dim oSM As ScriptManager = Me.Master.FindControl("ToolkitScriptManager1")
    If Not oSM Is Nothing Then
      LastTimeOut = oSM.AsyncPostBackTimeout
      oSM.AsyncPostBackTimeout = 3600
    End If
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 3600
    Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)

    Dim rDT As DateTime = Convert.ToDateTime("01/10/2010", ci)


    If F_FEmp.Text = F_TEmp.Text Then
      Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(F_FEmp.Text)
      Dim fdt As DateTime = Convert.ToDateTime(F_FDate.Text, ci)
      Dim tdt As DateTime = Convert.ToDateTime(F_TDate.Text, ci)
      While fdt <= tdt
        If F_RawPunch.Checked Then
          If fdt < rDT Then
            SIS.SYS.Utilities.ProcessCardPunch.ProcessIndividual(fdt, oEmp)
          Else
            SIS.SYS.Utilities.NewAttendanceRules.ProcessData(fdt.ToString("dd/MM/yyyy"), fdt.ToString("dd/MM/yyyy"), oEmp.CardNo, True)
          End If
        Else
          If fdt < rDT Then
            SIS.SYS.Utilities.ProcessCardPunch.ProcessForIndividualDate(fdt, oEmp)
          Else
            SIS.SYS.Utilities.NewAttendanceRules.ProcessData(fdt.ToString("dd/MM/yyyy"), fdt.ToString("dd/MM/yyyy"), oEmp.CardNo, False)
          End If
        End If
        fdt = fdt.AddDays(1)
      End While
    Else
      Dim oEmps As List(Of String) = SIS.ATN.atnEmployees.GetCardNoList("CardNo")
      For Each str As String In oEmps
        If str >= F_FEmp.Text And str <= F_TEmp.Text Then
          Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(str)
          Dim fdt As DateTime = Convert.ToDateTime(F_FDate.Text, ci)
          Dim tdt As DateTime = Convert.ToDateTime(F_TDate.Text, ci)
          While fdt <= tdt
            If F_RawPunch.Checked Then
              If fdt < rDT Then
                SIS.SYS.Utilities.ProcessCardPunch.ProcessIndividual(fdt, oEmp)
              Else
                SIS.SYS.Utilities.NewAttendanceRules.ProcessData(fdt.ToString("dd/MM/yyyy"), fdt.ToString("dd/MM/yyyy"), oEmp.CardNo, True)
              End If
            Else
              If fdt < rDT Then
                SIS.SYS.Utilities.ProcessCardPunch.ProcessForIndividualDate(fdt, oEmp)
              Else
                SIS.SYS.Utilities.NewAttendanceRules.ProcessData(fdt.ToString("dd/MM/yyyy"), fdt.ToString("dd/MM/yyyy"), oEmp.CardNo, False)
              End If
            End If
            fdt = fdt.AddDays(1)
          End While
        End If
      Next
    End If
    If Not oSM Is Nothing Then
      oSM.AsyncPostBackTimeout = LastTimeOut
    End If
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
  End Sub
End Class
