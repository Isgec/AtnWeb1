<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_newHrmEmployees.ascx.vb" Inherits="LC_newHrmEmployees" %>
<asp:DropDownList 
  ID = "DDLnewHrmEmployees"
  DataSourceID = "OdsDdlnewHrmEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornewHrmEmployees"
  Runat = "server" 
  ControlToValidate = "DDLnewHrmEmployees"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnewHrmEmployees"
  TypeName = "SIS.ATN.newHrmEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "newHrmEmployeesSelectList"
  Runat="server" />
