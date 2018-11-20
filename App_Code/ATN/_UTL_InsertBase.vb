Namespace SIS.SYS
	Public MustInherit Class InsertBase
		Inherits System.Web.UI.Page
		Private _AddAndStay As Boolean = False
    Protected WithEvents _lgToolBar As ToolBar0
    Protected WithEvents _lgFormView As FormView
    Private _dataClassName As String = ""
    Private _fvOK As Boolean = False
    Private _dcOK As Boolean = False
    Public ReadOnly Property FileName() As String
      Get
        Return _dataClassName & "." & _lgFormView.ID
      End Get
    End Property
    Public Property DataClassName() As String
      Get
        Return _dataClassName
      End Get
      Set(ByVal value As String)
        _dataClassName = value
        _dcOK = True
        If _fvOK Then
          fvInit()
        End If
      End Set
    End Property
    Public Property SetToolBar() As ToolBar0
      Get
        Return _lgToolBar
      End Get
      Set(ByVal value As ToolBar0)
        _lgToolBar = value
      End Set
    End Property
    Public Property SetFormView() As FormView
      Get
        Return _lgFormView
      End Get
      Set(ByVal value As FormView)
        _lgFormView = value
        _fvOK = True
        If _dcOK Then
          fvInit()
        End If
      End Set
    End Property
    Protected Sub fvInit()
      Try
        If Session("PageNoProvider") = True Then
          _lgFormView.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _lgFormView.PageIndex = Session("PageNo_" & FileName)
        End If
      Catch ex As Exception
        _lgFormView.PageIndex = 0
      End Try
    End Sub
    Private Sub ExceptionHandling(ByVal InnerException As String, ByVal Message As String)
      If Not InnerException Is Nothing Then
        Session("myError") = InnerException.ToString & vbCrLf & Message
      Else
        Session("myError") = Message
      End If
      Response.Redirect("~/ErrorPage.aspx")
    End Sub
    Private Sub _lgToolBar_CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles _lgToolBar.CancelClicked
      Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar)
    End Sub
    Private Sub _lgToolBar_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles _lgToolBar.PageChanged
      _lgFormView.PageIndex = NewPageNo
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
      Else
        Session("PageNo_" & FileName) = NewPageNo
      End If
    End Sub
    Private Sub _lgToolBar_SaveClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles _lgToolBar.SaveClicked
      _lgFormView.InsertItem(True)
    End Sub
    Private Sub _lgToolBar_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles _lgToolBar.SearchClicked
      _lgFormView.PageIndex = 0
      CType(_lgFormView.DataSourceObject, ObjectDataSource).SelectParameters("SearchState").DefaultValue = SearchState
      CType(_lgFormView.DataSourceObject, ObjectDataSource).SelectParameters("SearchText").DefaultValue = SearchText
    End Sub
    Private Sub _lgFormView_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lgFormView.DataBound
      With _lgToolBar
        .CurrentPage = _lgFormView.PageIndex
        .TotalPages = _lgFormView.PageCount
        .RecordsPerPage = 1
      End With
    End Sub

    Private Sub _lgFormView_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles _lgFormView.ItemCommand
      If e.CommandName.ToLower = "cancel" Then
        Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar)
      End If
      If e.CommandArgument.ToLower = "stay" Then
        _AddAndStay = True
      End If
    End Sub
    Private Sub _lgFormView_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles _lgFormView.ItemInserted
      If e.Exception Is Nothing Then
        If Not _lgToolBar.InsertAndStay Then
          If _lgToolBar.AfterInsertURL = String.Empty Then
            Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar())
          Else
            Response.Redirect(_lgToolBar.AfterInsertURL)
          End If
        End If
      Else
        Try
          e.ExceptionHandled = True
          ExceptionHandling(e.Exception.InnerException.ToString, e.Exception.Message)
        Catch ex As Exception
        End Try
      End If
    End Sub
    Private Sub _lgFormView_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lgFormView.PageIndexChanged
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), _lgFormView.PageIndex)
      Else
        Session("PageNo_" & FileName) = _lgFormView.PageIndex
      End If
    End Sub
	End Class
End Namespace
