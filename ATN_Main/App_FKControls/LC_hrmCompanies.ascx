<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmCompanies.ascx.vb" Inherits="LC_hrmCompanies" %>
<asp:DropDownList 
  ID = "DDLhrmCompanies"
  DataSourceID = "OdsDdlhrmCompanies"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmCompanies"
  Runat = "server" 
  ControlToValidate = "DDLhrmCompanies"
  Text = "Companies is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEhrmCompanies"
  runat = "server"
  TargetControlID = "DDLhrmCompanies"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlhrmCompanies"
  TypeName = "SIS.ATN.hrmCompanies"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
