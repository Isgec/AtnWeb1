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
Partial Class LC_atnMonths
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public Property CssClass() As String
    Get
      Return DDLatnMonths.CssClass
    End Get
    Set(ByVal value As String)
      DDLatnMonths.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLatnMonths.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLatnMonths.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatoratnMonths.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoratnMonths.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatoratnMonths.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoratnMonths.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLatnMonths.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLatnMonths.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLatnMonths.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLatnMonths.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLatnMonths.DataTextField
    End Get
    Set(ByVal value As String)
      DDLatnMonths.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLatnMonths.DataValueField
    End Get
    Set(ByVal value As String)
      DDLatnMonths.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLatnMonths.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLatnMonths.SelectedValue = String.Empty
      Else
        DDLatnMonths.SelectedValue = value
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
  Protected Sub OdsDdlatnMonths_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlatnMonths.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLatnMonths_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLatnMonths.DataBinding
    If _IncludeDefault Then
      DDLatnMonths.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLatnMonths_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLatnMonths.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
