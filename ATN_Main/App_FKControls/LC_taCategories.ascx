<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taCategories.ascx.vb" Inherits="LC_taCategories" %>
<asp:DropDownList 
  ID = "DDLtaCategories"
  DataSourceID = "OdsDdltaCategories"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaCategories"
  Runat = "server" 
  ControlToValidate = "DDLtaCategories"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaCategories"
  TypeName = "SIS.ATN.taCategories"
  SortParameterName = "OrderBy"
  SelectMethod = "taCategoriesSelectList"
  Runat="server" />
