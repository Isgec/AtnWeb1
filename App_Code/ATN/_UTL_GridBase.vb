Namespace SIS.SYS
  Public MustInherit Class GridBase
    Inherits System.Web.UI.Page
    Protected WithEvents _lgFormView As GridView
    Protected WithEvents _lgToolBar As ToolBar0
    Private _dataClassName As String = ""
    Private _gvOK As Boolean = False
    Private _dcOK As Boolean = False
    Public Sub InitGridPage()
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
      Else
        Session("PageNo_" & FileName) = 0
      End If
    End Sub
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
        If _gvOK Then
          gvInit()
        End If
        Try
          _lgToolBar.SearchValidationGroup = DataClassName
        Catch ex As Exception
        End Try
      End Set
    End Property

    Public Property SetGridView() As GridView
      Get
        Return _lgFormView
      End Get
      Set(ByVal value As GridView)
        _lgFormView = value
        _gvOK = True
        If _dcOK Then
          gvInit()
        End If
      End Set
    End Property
    Public Property SetToolBar() As ToolBar0
      Get
        Return _lgToolBar
      End Get
      Set(ByVal value As ToolBar0)
        _lgToolBar = value
        Try
          _lgToolBar.SearchValidationGroup = DataClassName
        Catch ex As Exception
        End Try
      End Set
    End Property
    Private Sub _lgFormView_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lgFormView.DataBound
      With _lgToolBar
        .CurrentPage = _lgFormView.PageIndex
        .TotalPages = _lgFormView.PageCount
        .RecordsPerPage = _lgFormView.PageSize
      End With
    End Sub
    Private Sub _lgFormView_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lgFormView.PageIndexChanged
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), _lgFormView.PageIndex)
      Else
        Session("PageNo_" & FileName) = _lgFormView.PageIndex
      End If
    End Sub
    Private Sub gvInit()
      Try
        If Session("PageNoProvider") = True Then
          _lgFormView.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _lgFormView.PageIndex = Session("PageNo_" & FileName)
        End If
        If Session("PageSizeProvider") = True Then
          _lgFormView.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _lgFormView.PageSize = Session("PageSize_" & FileName)
        End If
      Catch ex As Exception
        _lgFormView.PageIndex = 0
        _lgFormView.PageSize = 10
      End Try
    End Sub
    Private Sub _lgToolBar_CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles _lgToolBar.CancelClicked
      Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar)
    End Sub
    Private Sub _lgToolBar_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles _lgToolBar.PageChanged
      If NewPageNo < 0 Then NewPageNo = 0
      _lgFormView.PageIndex = NewPageNo
      _lgFormView.PageSize = PageSize
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
      Else
        Session("PageNo_" & FileName) = NewPageNo
      End If
      If Session("PageSizeProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
      Else
        Session("PageSize_" & FileName) = PageSize
      End If
    End Sub
    Private Sub _lgToolBar_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles _lgToolBar.SearchClicked
      _lgFormView.PageIndex = 0
      CType(_lgFormView.DataSourceObject, ObjectDataSource).SelectParameters("SearchState").DefaultValue = SearchState
      CType(_lgFormView.DataSourceObject, ObjectDataSource).SelectParameters("SearchText").DefaultValue = SearchText
    End Sub
  End Class
  Public MustInherit Class psGridBase
    Inherits System.Web.UI.Page
    Protected WithEvents _lgFormView As GridView
    Protected WithEvents _lgToolBar As IpsBar
    Private _dataClassName As String = ""
    Private _gvOK As Boolean = False
    Private _dcOK As Boolean = False
    Public Sub InitGridPage()
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
      Else
        Session("PageNo_" & FileName) = 0
      End If
    End Sub
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
        If _gvOK Then
          gvInit()
        End If
      End Set
    End Property
    Public Property SetGridView() As GridView
      Get
        Return _lgFormView
      End Get
      Set(ByVal value As GridView)
        _lgFormView = value
        _gvOK = True
        If _dcOK Then
          gvInit()
        End If
      End Set
    End Property
    Public Property SetToolBar() As IpsBar
      Get
        Return _lgToolBar
      End Get
      Set(ByVal value As IpsBar)
        _lgToolBar = value
      End Set
    End Property
    Private Sub _lgFormView_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lgFormView.DataBound
      With _lgToolBar
        .CurrentPage = _lgFormView.PageIndex
        .TotalPages = _lgFormView.PageCount
        .RecordsPerPage = _lgFormView.PageSize
      End With
    End Sub
    Private Sub _lgFormView_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lgFormView.PageIndexChanged
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), _lgFormView.PageIndex)
      Else
        Session("PageNo_" & FileName) = _lgFormView.PageIndex
      End If
    End Sub
    Private Sub gvInit()
      Try
        If Session("PageNoProvider") = True Then
          _lgFormView.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _lgFormView.PageIndex = Session("PageNo_" & FileName)
        End If
        If Session("PageSizeProvider") = True Then
          _lgFormView.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _lgFormView.PageSize = Session("PageSize_" & FileName)
        End If
      Catch ex As Exception
        _lgFormView.PageIndex = 0
        _lgFormView.PageSize = 10
      End Try
    End Sub
    Private Sub _lgToolBar_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles _lgToolBar.PageChanged
      If NewPageNo < 0 Then NewPageNo = 0
      _lgFormView.PageIndex = NewPageNo
      _lgFormView.PageSize = PageSize
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
      Else
        Session("PageNo_" & FileName) = NewPageNo
      End If
      If Session("PageSizeProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
      Else
        Session("PageSize_" & FileName) = PageSize
      End If
    End Sub
    Private Sub _lgToolBar_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles _lgToolBar.SearchClicked
      _lgFormView.PageIndex = 0
      CType(_lgFormView.DataSourceObject, ObjectDataSource).SelectParameters("SearchState").DefaultValue = SearchState
      CType(_lgFormView.DataSourceObject, ObjectDataSource).SelectParameters("SearchText").DefaultValue = SearchText
    End Sub
  End Class
End Namespace
