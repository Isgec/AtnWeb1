Partial Class MasterCPage
	Inherits System.Web.UI.MasterPage
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not SIS.SYS.Utilities.ValidateURL.Validate(Request.AppRelativeCurrentExecutionFilePath) Then
			Response.Redirect("~/Login.aspx")
		End If
		If Not Page.ClientScript.IsClientScriptBlockRegistered("SplitterJS") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "SplitterJS", "<script src=""" & GetRelativePath("~/VwdCmsSplitterBar.js") & """ type=""text/javascript""></script>")
		End If
		If HttpContext.Current.User.Identity.IsAuthenticated Then
			Dim mFile As String = HttpContext.Current.Server.MapPath("~/..") & "UserRights/" & HttpContext.Current.Session("ApplicationID") & "/" & HttpContext.Current.User.Identity.Name & "_Menu.xml"
			If IO.File.Exists(mFile) Then
				XmlDataSource1.DataFile = mFile
			End If
		End If
	End Sub
	Public Function GetRelativePath(ByVal mPath As String) As String
		Return VirtualPathUtility.MakeRelative(Page.AppRelativeVirtualPath, mPath)
	End Function
	Protected Sub TreeView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DataBound
		If HttpContext.Current.User.Identity.IsAuthenticated Then
			Dim oND As TreeNode = New TreeNode
			With oND
				.ImageUrl = "~/App_Themes/Default/Images/signout.ico"
				.Text = "<B>&nbsp;&nbsp;Signout</B>"
				.SelectAction = TreeNodeSelectAction.Select
				.ImageToolTip = "Signout"
				.Value = "SignOut"
				TreeView1.Nodes(0).ChildNodes.Add(oND)
			End With
		End If
	End Sub
	Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
		Dim oTV As TreeView = CType(sender, TreeView)
		If oTV.SelectedValue.ToLower = "signout" Then
			System.Web.Security.FormsAuthentication.SignOut()
			SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
			Response.Redirect("~/Default.aspx?emptype=1")
		End If
	End Sub
	Protected Sub LoginLine1_SignedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginLine1.SignedIn
		Response.Redirect("~/Default.aspx?emptype=1")
	End Sub
	Protected Sub LoginLine1_SignOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginLine1.SignOut
		System.Web.Security.FormsAuthentication.SignOut()
		SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
		Response.Redirect("~/Default.aspx?emptype=1")
	End Sub
	Public Property Master_Form() As HtmlForm
		Get
			Return Me.form1
		End Get
		Set(ByVal value As HtmlForm)
			Me.form1 = value
		End Set
	End Property
	Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
		If (e.Exception.Data("ExtraInfo") <> Nothing) Then
			ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message & e.Exception.Data("ExtraInfo").ToString()
		Else
			ToolkitScriptManager1.AsyncPostBackErrorMessage = "An unspecified error occurred."
		End If
	End Sub
End Class

