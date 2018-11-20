<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnwpEmployees.ascx.vb" Inherits="LC_atnwpEmployees" %>
<asp:DropDownList 
  ID = "DDLatnwpEmployees"
  DataSourceID = "OdsDdlatnwpEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnwpEmployees"
  Runat = "server" 
  ControlToValidate = "DDLatnwpEmployees"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlatnwpEmployees"
  TypeName = "SIS.ATN.atnwpEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "atnwpEmployeesSelectList"
  Runat="server" />
