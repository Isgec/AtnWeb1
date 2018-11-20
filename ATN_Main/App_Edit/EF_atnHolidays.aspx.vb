Partial Class EF_atnHolidays
  Inherits SIS.SYS.UpdateBase
  Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Init
    DataClassName = Page.GetType().Name
    SetFormView = FormView1
  End Sub
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    '    Dim oLC_OfficeID As LC_hrmOffices = FormView1.FindControl("LC_OfficeID1")
    '    oLC_OfficeID.Enabled = True
    '    oLC_OfficeID.SelectedValue = String.Empty
    '    If Not Session("LC_OfficeID") Is Nothing Then
    '      If Session("LC_OfficeID") <> String.Empty Then
    '        oLC_OfficeID.SelectedValue = Session("LC_OfficeID")
    '        oLC_OfficeID.Enabled = False
    '      End If
    '    End If
    '    Dim oLC_PunchStatusID As LC_atnPunchStatus = FormView1.FindControl("LC_PunchStatusID1")
    '    oLC_PunchStatusID.Enabled = True
    '    oLC_PunchStatusID.SelectedValue = String.Empty
    '    If Not Session("LC_PunchStatusID") Is Nothing Then
    '      If Session("LC_PunchStatusID") <> String.Empty Then
    '        oLC_PunchStatusID.SelectedValue = Session("LC_PunchStatusID")
    '      End If
    '    End If
  End Sub
End Class
