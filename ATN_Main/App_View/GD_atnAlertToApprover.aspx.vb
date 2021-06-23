Imports System.Net.Mail
Partial Class GD_atnAlertToApprover
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnAlertToApprover"
    SetGridView = GridView1
  End Sub
  <System.Web.Services.WebMethod(EnableSession:=True)> _
  Public Shared Function SendMail(ByVal context As String) As String
    Dim aVals() As String = context.Split("±".ToCharArray)
    If aVals(1) = String.Empty Then
      Return aVals(0)
    End If
    Dim oClient As SmtpClient = New SmtpClient()
    Dim oMsg As New System.Net.Mail.MailMessage
    With oMsg
      .To.Add(aVals(1))
      .Body = "<a href='http://perk01/atnweb1/dummy.aspx'>.</a><br/>"
      .Body &= aVals(2)
      .Subject = "Pending Leave Application(s)"
    End With
    oClient.Send(oMsg)
    Return aVals(0)
  End Function
  Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    If e.CommandName.ToLower = "sendlinkemail" Then
      Dim ApproverID As String = e.CommandArgument
      SIS.ATN.atnApplHeader.SendClubbedEMailForVerificationOrApproval(ApproverID, True)
    End If
  End Sub
End Class
