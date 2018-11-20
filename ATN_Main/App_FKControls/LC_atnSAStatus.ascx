<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnSAStatus.ascx.vb" Inherits="LC_atnSAStatus" %>
<asp:DropDownList 
  ID = "DDLatnSAStatus"
  DataSourceID = "OdsDdlatnSAStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnSAStatus"
  Runat = "server" 
  ControlToValidate = "DDLatnSAStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlatnSAStatus"
  TypeName = "SIS.ATN.atnSAStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "atnSAStatusSelectList"
  Runat="server" />
