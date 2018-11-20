Partial Class GF_newHrmEmployees
  Inherits SIS.SYS.GridBase
  Protected Sub GVnewHrmEmployees_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnewHrmEmployees.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CardNo As String = GVnewHrmEmployees.DataKeys(e.CommandArgument).Values("CardNo")
        Dim RedirectUrl As String = TBLnewHrmEmployees.EditUrl & "?CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnewHrmEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnewHrmEmployees.Init
    DataClassName = "GnewHrmEmployees"
    SetGridView = GVnewHrmEmployees
  End Sub
  Protected Sub TBLnewHrmEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnewHrmEmployees.Init
    SetToolBar = TBLnewHrmEmployees
  End Sub
  Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
    Session("F_CardNo") = F_CardNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_C_OfficeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_OfficeID.SelectedIndexChanged
    Session("F_C_OfficeID") = F_C_OfficeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_DepartmentID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DepartmentID.SelectedIndexChanged
    Session("F_C_DepartmentID") = F_C_DepartmentID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_DesignationID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DesignationID.SelectedIndexChanged
    Session("F_C_DesignationID") = F_C_DesignationID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_C_OfficeID.SelectedValue = String.Empty
    If Not Session("F_C_OfficeID") Is Nothing Then
      If Session("F_C_OfficeID") <> String.Empty Then
        F_C_OfficeID.SelectedValue = Session("F_C_OfficeID")
      End If
    End If
    F_C_DepartmentID.SelectedValue = String.Empty
    If Not Session("F_C_DepartmentID") Is Nothing Then
      If Session("F_C_DepartmentID") <> String.Empty Then
        F_C_DepartmentID.SelectedValue = Session("F_C_DepartmentID")
      End If
    End If
    F_C_DesignationID.SelectedValue = String.Empty
    If Not Session("F_C_DesignationID") Is Nothing Then
      If Session("F_C_DesignationID") <> String.Empty Then
        F_C_DesignationID.SelectedValue = Session("F_C_DesignationID")
      End If
    End If
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
  End Sub
End Class
