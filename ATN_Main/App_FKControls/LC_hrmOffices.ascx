<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmOffices.ascx.vb" Inherits="LC_hrmOffices" %>
<asp:DropDownList 
  ID = "DDLhrmOffices"
  DataSourceID = "OdsDdlhrmOffices"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmOffices"
  Runat = "server" 
  ControlToValidate = "DDLhrmOffices"
  Text = "Offices is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEhrmOffices"
  runat = "server"
  TargetControlID = "DDLhrmOffices"
  PromptCssClass="DDSearchPrompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlhrmOffices"
  TypeName = "SIS.ATN.hrmOffices"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
