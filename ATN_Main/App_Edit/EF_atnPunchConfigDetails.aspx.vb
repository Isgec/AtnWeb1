Partial Class EF_atnPunchConfigDetails
  Inherits SIS.SYS.UpdateBase
  Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Init
    DataClassName = Page.GetType().Name
    SetFormView = FormView1
  End Sub
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    '    Dim oLC_ConfigID As LC_atnPunchConfig = FormView1.FindControl("LC_ConfigID1")
    '    oLC_ConfigID.Enabled = True
    '    oLC_ConfigID.SelectedValue = String.Empty
    '    If Not Session("LC_ConfigID") Is Nothing Then
    '      If Session("LC_ConfigID") <> String.Empty Then
    '        oLC_ConfigID.SelectedValue = Session("LC_ConfigID")
    '        oLC_ConfigID.Enabled = False
    '      End If
    '    End If
  End Sub
End Class
