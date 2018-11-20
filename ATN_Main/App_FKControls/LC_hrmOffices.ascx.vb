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
Partial Class LC_hrmOffices
	Inherits System.Web.UI.UserControl
	Private _OrderBy As String = String.Empty
	Private _IncludeDefault As Boolean = True
	Private _DefaultText As String = "-- Select --"
	Private _DefaultValue As String = String.Empty
	Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
	Public Property CssClass() As String
		Get
			Return DDLhrmOffices.CssClass
		End Get
		Set(ByVal value As String)
			DDLhrmOffices.CssClass = value
		End Set
	End Property
	Public Property Width() As System.Web.UI.WebControls.Unit
		Get
			Return DDLhrmOffices.Width
		End Get
		Set(ByVal value As System.Web.UI.WebControls.Unit)
			DDLhrmOffices.Width = value
		End Set
	End Property
	Public Property RequiredFieldErrorMessage() As String
		Get
			Return RequiredFieldValidatorhrmOffices.Text
		End Get
		Set(ByVal value As String)
			RequiredFieldValidatorhrmOffices.Text = value
		End Set
	End Property
	Public Property ValidationGroup() As String
		Get
			Return RequiredFieldValidatorhrmOffices.ValidationGroup
		End Get
		Set(ByVal value As String)
			RequiredFieldValidatorhrmOffices.ValidationGroup = value
		End Set
	End Property
	Public Property Enabled() As Boolean
		Get
			Return DDLhrmOffices.Enabled
		End Get
		Set(ByVal value As Boolean)
			DDLhrmOffices.Enabled = value
		End Set
	End Property
	Public Property AutoPostBack() As Boolean
		Get
			Return DDLhrmOffices.AutoPostBack
		End Get
		Set(ByVal value As Boolean)
			DDLhrmOffices.AutoPostBack = value
		End Set
	End Property
	Public Property DataTextField() As String
		Get
			Return DDLhrmOffices.DataTextField
		End Get
		Set(ByVal value As String)
			DDLhrmOffices.DataTextField = value
		End Set
	End Property
	Public Property DataValueField() As String
		Get
			Return DDLhrmOffices.DataValueField
		End Get
		Set(ByVal value As String)
			DDLhrmOffices.DataValueField = value
		End Set
	End Property
	Public Property SelectedValue() As String
		Get
			Return DDLhrmOffices.SelectedValue
		End Get
		Set(ByVal value As String)
			If Convert.IsDBNull(value) Then
				DDLhrmOffices.SelectedValue = String.Empty
			Else
				DDLhrmOffices.SelectedValue = value
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
	Protected Sub OdsDdlhrmOffices_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlhrmOffices.Selecting
		e.Arguments.SortExpression = _OrderBy
	End Sub
	Protected Sub DDLhrmOffices_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLhrmOffices.DataBinding
		If _IncludeDefault Then
			DDLhrmOffices.Items.Add(New ListItem(_DefaultText, _DefaultValue))
		End If
	End Sub
	Protected Sub DDLhrmOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLhrmOffices.SelectedIndexChanged
		RaiseEvent SelectedIndexChanged(sender, e)
	End Sub
End Class
