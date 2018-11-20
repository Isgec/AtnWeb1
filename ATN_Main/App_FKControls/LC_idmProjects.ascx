<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_idmProjects.ascx.vb" Inherits="LC_idmProjects" %>
<asp:DropDownList 
  ID = "DDLidmProjects"
  DataSourceID = "OdsDdlidmProjects"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoridmProjects"
  Runat = "server" 
  ControlToValidate = "DDLidmProjects"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlidmProjects"
  TypeName = "SIS.ATN.idmProjects"
  SortParameterName = "OrderBy"
  SelectMethod = "idmProjectsSelectList"
  Runat="server" />
