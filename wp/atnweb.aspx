<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Dim conPerks As String = "Data Source=perk03;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
  Dim conLocal As String = "Data Source=11.11.16.30\LGSQL2005;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
  Dim strPara As String = Guid.NewGuid().ToString()
  Dim strUser As String = ""
  Protected Sub Page_Load(sender As Object, e As System.EventArgs)
    strUser = Session("uid")
    Dim cnt As Boolean = False
    If Request.QueryString("cnt") IsNot Nothing Then
      cnt = True
    End If
    Using Con As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(conPerks)
      Using Cmd As System.Data.SqlClient.SqlCommand = Con.CreateCommand()
        Dim mSql As String = "update aspnet_users set wp_user = '" & strPara & "' where LoginID = '" & strUser & "'"
        Cmd.CommandType = System.Data.CommandType.Text
        Cmd.CommandText = mSql
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
    End Using
    If Not cnt Then
      Response.Redirect("http://perk01/atnweb1/default.aspx?wpid=" & strPara, True)
    Else
      Response.Redirect("http://perk01/atnweb1/default.aspx?wpid=" & strPara & "&cnt=1", True)
    End If
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
