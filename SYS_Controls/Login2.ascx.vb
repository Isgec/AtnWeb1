Partial Class Login2
  Inherits System.Web.UI.UserControl
  Protected Sub ChangePassword1_ChangingPassword(sender As Object, e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles ChangePassword1.ChangingPassword
    Dim oPW As System.Web.UI.WebControls.ChangePassword = CType(sender, ChangePassword)
    Dim nPW As String = oPW.NewPassword
    Dim uID As String = oPW.UserName
    SIS.SYS.Utilities.SessionManager.UpdateMD5Password(uID, nPW)
  End Sub

End Class
