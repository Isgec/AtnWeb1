<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnMonths.ascx.vb" Inherits="LC_atnMonths" %>
<asp:DropDownList 
  ID = "DDLatnMonths"
  DataSourceID = "OdsDdlatnMonths"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnMonths"
  Runat = "server" 
  ControlToValidate = "DDLatnMonths"
  Text = "Months is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlatnMonths"
  TypeName = "SIS.ATN.atnMonths"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
