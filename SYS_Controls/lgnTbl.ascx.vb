Partial Class lgnTbl
  Inherits System.Web.UI.UserControl
  Public Enum ToolTypes
    lgNMGrid = 1
    lgNMAdd = 2
    lgNMEdit = 3
    lgNDGrid = 4
    lgNDEdit = 5
    lgWMSGrid = 6
    lgWMSAdd = 7
    lgWMPGrid = 8
    lgWMPEdit = 9
    lgNReport = 10
  End Enum
  Private _ToolType As ToolTypes
  Private _AddUrl As String = ""
  Private _EditUrl As String = ""
  Private _CancelUrl As String = ""
  Private _SearchUrl As String = ""
  Private _ValidationGroup As String = ""
  Private _SearchContext As String = ""
  Public Event AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event SaveClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event SaveAddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event UpdateClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event ReturnClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event DeleteClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
	Public Event PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
	Public Event SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
	Public Property SearchState() As Boolean
		Get
			Return DisableSearch.Checked
		End Get
		Set(ByVal value As Boolean)
			DisableSearch.Checked = value
		End Set
	End Property
  Public Property ToolType() As ToolTypes
    Get
      Return _ToolType
    End Get
    Set(ByVal value As ToolTypes)
      _ToolType = value
      SetToolType(value)
    End Set
  End Property
  Private Sub SetToolType(ByVal Type As ToolTypes)
    CmdExit.CommandName = "Cancel"
    CmdSave.CommandArgument = "Stay"
    Select Case Type
      Case ToolTypes.lgNMGrid
        SetNMGrid()
      Case ToolTypes.lgNMAdd
        SetNMAdd()
        CmdSave.CommandName = "Insert"
      Case ToolTypes.lgNMEdit
        SetNMEdit()
        CmdSave.CommandName = "Update"
        CmdDelete.CommandName = "Delete"
      Case ToolTypes.lgNDGrid
        SetNDGrid()
      Case ToolTypes.lgNDEdit
        SetNDEdit()
      Case ToolTypes.lgWMSGrid
        SetWMSGrid()
      Case ToolTypes.lgWMSAdd
        SetWMSAdd()
        CmdForward.CommandName = "Insert"
      Case ToolTypes.lgWMPGrid
        SetWMPGrid()
      Case ToolTypes.lgWMPEdit
        SetWMPEdit()
        CmdForward.CommandName = "Update"
        CmdReturn.CommandName = "Return"
      Case ToolTypes.lgNReport
        SetNDEdit()
        tdPage.Visible = False
        tdSearch.Visible = False
    End Select
    SetImage()
  End Sub
  Private Sub SetWMPEdit()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    CmdExit.Enabled = True
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = True
    CmdReturn.Enabled = True
  End Sub
  Private Sub SetWMPGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetWMSAdd()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    CmdExit.Enabled = True
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = True
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetWMSGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = True
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNDEdit()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    CmdExit.Enabled = True
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNDGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNMEdit()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    CmdExit.Enabled = True
    CmdSave.Enabled = True
    CmdAdd.Enabled = False
    CmdDelete.Enabled = True
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNMAdd()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    CmdExit.Enabled = True
    CmdSave.Enabled = True
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNMGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

		CmdExit.Enabled = True
		_CancelUrl = Session("ApplicationDefaultPage")
    CmdSave.Enabled = False
    CmdAdd.Enabled = True
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetImage()
    If tdDefault.Visible Then
      With CmdExit
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
      With CmdSave
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
      With CmdAdd
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
      With CmdDelete
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
      With CmdForward
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
      With CmdReturn
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End If
    If tdPage.Visible Then

    End If
    If tdSearch.Visible Then

    End If
  End Sub
  Public Property EnableReturn() As Boolean
    Get
      Return CmdReturn.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdReturn.Enabled = value
      With CmdReturn
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End Set
  End Property
  Public Property EnableForward() As Boolean
    Get
      Return CmdForward.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdForward.Enabled = value
      With CmdForward
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End Set
  End Property
  Public Property EnableSearch() As Boolean
    Get
      Return CmdSearch.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdSearch.Enabled = value
      With CmdSearch
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End Set
  End Property
  Public Property EnableAdd() As Boolean
    Get
      Return CmdAdd.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdAdd.Enabled = value
      With CmdAdd
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End Set
  End Property
  Public Property EnableDelete() As Boolean
    Get
      Return CmdDelete.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdDelete.Enabled = value
      With CmdDelete
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End Set
  End Property
  Public Property TotalRecords() As Integer
    Get
      Return _PageSizeButton.Text
    End Get
    Set(ByVal value As Integer)
      _PageSizeButton.Text = value
    End Set
  End Property
  Public Property RecordsPerPage() As Integer
    Get
      Return _PageSize.Text
    End Get
    Set(ByVal value As Integer)
      _PageSize.Text = value
    End Set
  End Property
  Public Property TotalPages() As Integer
    Get
      Return _TotalPages.Text
    End Get
    Set(ByVal value As Integer)
      _TotalPages.Text = value
      Dim oMEV As New AjaxControlToolkit.MaskedEditValidator
      With (oMEV)
        .ID = "MaskedEditValidatorCurrentPage"
        .ControlToValidate = "_CurrentPage"
        .ControlExtender = "MaskedEditExtenderCurrentPage"
        .InvalidValueMessage = ""
        .EmptyValueMessage = ""
        .EmptyValueBlurredText = ""
        .Display = ValidatorDisplay.Dynamic
        .EnableClientScript = True
        .ValidationGroup = "currentpage"
        .IsValidEmpty = False
        .MaximumValue = value
        .MinimumValue = 1
        .SetFocusOnError = True
      End With
      Me.Controls.Add(oMEV)
    End Set
  End Property
  Public Property CurrentPage() As Integer
    Get
      Return _CurrentPage.Text
    End Get
    Set(ByVal value As Integer)
      _CurrentPage.Text = value + 1
    End Set
  End Property
  Public Property SearchContext() As String
    Get
      Return _SearchContext
    End Get
    Set(ByVal value As String)
      _SearchContext = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return _ValidationGroup
    End Get
    Set(ByVal value As String)
      _ValidationGroup = value
      CmdSave.ValidationGroup = value
      CmdForward.ValidationGroup = value
    End Set
  End Property
  Public Property AddUrl() As String
    Get
      Return _AddUrl
    End Get
    Set(ByVal value As String)
      _AddUrl = value
      CmdAdd.CommandArgument = _AddUrl
      CmdAdd.PostBackUrl = _AddUrl
    End Set
  End Property
  Public Property EditUrl() As String
    Get
      Return _EditUrl
    End Get
    Set(ByVal value As String)
      _EditUrl = value
    End Set
  End Property
  Public Property CancelUrl() As String
    Get
      Return _CancelUrl
    End Get
    Set(ByVal value As String)
      _CancelUrl = value
      Me.CmdExit.PostBackUrl = value
    End Set
  End Property
  Public Property SearchUrl() As String
    Get
      Return _SearchUrl
    End Get
    Set(ByVal value As String)
      _SearchUrl = value
    End Set
  End Property
  Protected Sub CmdCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdExit.Click
    RaiseEvent CancelClicked(sender, e)
  End Sub
  Protected Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdAdd.Click
    RaiseEvent AddClicked(sender, e)
  End Sub
  Protected Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdSave.Click
    RaiseEvent SaveClicked(sender, e)
  End Sub
  Protected Sub CmdForward_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdForward.Click
    RaiseEvent UpdateClicked(sender, e)
  End Sub
  Protected Sub CmdReturn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdReturn.Click
    RaiseEvent ReturnClicked(sender, e)
  End Sub
	Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdSearch.Click
		If Not SearchTextBox.Text = String.Empty Then
			DisableSearch.Enabled = True
			DisableSearch.Checked = True
			RaiseEvent SearchClicked(SearchTextBox.Text, True)
		End If
	End Sub
	Protected Sub DisableSearch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DisableSearch.CheckedChanged
		DisableSearch.Enabled = False
		DisableSearch.Checked = False
		RaiseEvent SearchClicked(SearchTextBox.Text, False)
	End Sub
	Protected Sub _CurrentPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _CurrentPage.TextChanged
		RaiseEvent PageChanged(Convert.ToInt32(_CurrentPage.Text) - 1, Convert.ToInt32(_PageSize.Text))
	End Sub
  Protected Sub navFirst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navFirst.Click
    RaiseEvent PageChanged(0, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub navPrev_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navPrev.Click
    Dim cp As Integer = Convert.ToInt32(_CurrentPage.Text)
    If cp - 1 >= 1 Then
      RaiseEvent PageChanged(cp - 2, Convert.ToInt32(_PageSize.Text))
    End If
  End Sub
  Protected Sub navNext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navNext.Click
    Dim cp As Integer = Convert.ToInt32(_CurrentPage.Text)
    Dim lp As Integer = Convert.ToInt32(_TotalPages.Text)
    If cp + 1 <= lp Then
      RaiseEvent PageChanged(cp, Convert.ToInt32(_PageSize.Text))
    End If
  End Sub
  Protected Sub navLast_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navLast.Click
    Dim lp As Integer = Convert.ToInt32(_TotalPages.Text)
    RaiseEvent PageChanged(lp - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub _PageSizeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _PageSizeButton.Click
    RaiseEvent PageChanged(Convert.ToInt32(_CurrentPage.Text) - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
End Class
