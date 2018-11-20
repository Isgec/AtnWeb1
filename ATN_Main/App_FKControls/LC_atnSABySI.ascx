<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnSABySI.ascx.vb" Inherits="LC_atnSABySI" %>
<asp:DropDownList 
  ID = "DDLatnSABySI"
  DataSourceID = "OdsDdlatnSABySI"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnSABySI"
  Runat = "server" 
  ControlToValidate = "DDLatnSABySI"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlatnSABySI"
  TypeName = "SIS.ATN.atnSABySI"
  SortParameterName = "OrderBy"
  SelectMethod = "atnSABySISelectList"
  Runat="server" />
