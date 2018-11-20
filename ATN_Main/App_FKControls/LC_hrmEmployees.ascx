<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmEmployees.ascx.vb" Inherits="LC_hrmEmployees" %>
<asp:DropDownList 
  ID = "DDLhrmEmployees"
  DataSourceID = "OdsDdlhrmEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmEmployees"
  Runat = "server" 
  ControlToValidate = "DDLhrmEmployees"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlhrmEmployees"
  TypeName = "SIS.ATN.hrmEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "hrmEmployeesSelectList"
  Runat="server" />
