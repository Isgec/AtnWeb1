Imports System.Collections.Generic
Partial Class Informations
  Inherits System.Web.UI.UserControl
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If HttpContext.Current.User.Identity.IsAuthenticated Then
			Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(HttpContext.Current.User.Identity.Name)
			If Not oEmp Is Nothing Then
				F_EmployeeName.Text = oEmp.EmployeeName
        'F_Department.Text = oEmp.C_DepartmentID
        'F_Designation.Text = oEmp.C_DesignationIDHRM_Designations.Description
				If oEmp.VerificationRequired Then
					F_Verifier.Text = oEmp.VerifierIDEmployeeName
				Else
					F_Verifier.Text = "N/A"
				End If
				If oEmp.ApprovalRequired Then
					F_Approver.Text = oEmp.ApproverIDEmployeeName
				Else
					F_Approver.Text = "N/A"
				End If
			End If
			Me.Visible = True
			If Not Page.IsPostBack And Not Page.IsCallback Then
				Try
					LC_atnFinYear1.SelectedValue = Session("FinYear").ToString
				Catch ex As Exception
					Response.Redirect("~/Expired.aspx")
				End Try
			End If
		End If
	End Sub

	Protected Sub LC_atnFinYear1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LC_atnFinYear1.SelectedIndexChanged
		Session("FinYear") = Convert.ToInt32(LC_atnFinYear1.SelectedValue)
  End Sub

End Class
