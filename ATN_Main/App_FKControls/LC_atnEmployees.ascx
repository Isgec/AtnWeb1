<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnEmployees.ascx.vb" Inherits="LC_atnEmployees" %>
<asp:DropDownList 
  ID = "DDLatnEmployees"
  DataSourceID = "OdsDdlatnEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnEmployees"
  Runat = "server" 
  ControlToValidate = "DDLatnEmployees"
  Text = "Employees is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEatnEmployees"
  runat = "server"
  TargetControlID = "DDLatnEmployees"
  PromptCssClass="DDSearchPrompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlatnEmployees"
  TypeName = "SIS.ATN.atnEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
