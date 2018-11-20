<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnFinYear.ascx.vb" Inherits="LC_atnFinYear" %>
<asp:DropDownList 
  ID = "DDLatnFinYear"
  DataSourceID = "OdsDdlatnFinYear"
  AppendDataBoundItems = "true"
  CssClass = "finyear"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnFinYear"
  Runat = "server" 
  ControlToValidate = "DDLatnFinYear"
  Text = "*"
  ErrorMessage = "*"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlatnFinYear"
  TypeName = "SIS.ATN.atnFinYear"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
