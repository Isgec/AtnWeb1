<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taTPInvoicing.ascx.vb" Inherits="LC_taTPInvoicing" %>
<asp:DropDownList 
  ID = "DDLtaTPInvoicing"
  DataSourceID = "OdsDdltaTPInvoicing"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaTPInvoicing"
  Runat = "server" 
  ControlToValidate = "DDLtaTPInvoicing"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaTPInvoicing"
  TypeName = "SIS.TA.taTPInvoicing"
  SortParameterName = "OrderBy"
  SelectMethod = "taTPInvoicingSelectList"
  Runat="server" />
