Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

<ValidationProperty("SelectedValue")> _
Partial Class LC_atnPunchConfig
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public Property CssClass() As String
    Get
      Return DDLatnPunchConfig.CssClass
    End Get
    Set(ByVal value As String)
      DDLatnPunchConfig.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLatnPunchConfig.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLatnPunchConfig.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatoratnPunchConfig.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoratnPunchConfig.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatoratnPunchConfig.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoratnPunchConfig.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLatnPunchConfig.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLatnPunchConfig.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLatnPunchConfig.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLatnPunchConfig.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLatnPunchConfig.DataTextField
    End Get
    Set(ByVal value As String)
      DDLatnPunchConfig.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLatnPunchConfig.DataValueField
    End Get
    Set(ByVal value As String)
      DDLatnPunchConfig.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLatnPunchConfig.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLatnPunchConfig.SelectedValue = String.Empty
      Else
        DDLatnPunchConfig.SelectedValue = value
      End If
    End Set
  End Property
  Public Property OrderBy() As String
    Get
      Return _OrderBy
    End Get
    Set(ByVal value As String)
      _OrderBy = value
    End Set
  End Property
  Public Property IncludeDefault() As Boolean
    Get
      Return _IncludeDefault
    End Get
    Set(ByVal value As Boolean)
      _IncludeDefault = value
    End Set
  End Property
  Public Property DefaultText() As String
    Get
      Return _DefaultText
    End Get
    Set(ByVal value As String)
      _DefaultText = value
    End Set
  End Property
  Public Property DefaultValue() As String
    Get
      Return _DefaultValue
    End Get
    Set(ByVal value As String)
      _DefaultValue = value
    End Set
  End Property
  Protected Sub OdsDdlatnPunchConfig_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlatnPunchConfig.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLatnPunchConfig_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLatnPunchConfig.DataBinding
    If _IncludeDefault Then
      DDLatnPunchConfig.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLatnPunchConfig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLatnPunchConfig.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
