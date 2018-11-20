<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmDivisions.ascx.vb" Inherits="LC_hrmDivisions" %>
<asp:DropDownList 
  ID = "DDLhrmDivisions"
  DataSourceID = "OdsDdlhrmDivisions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmDivisions"
  Runat = "server" 
  ControlToValidate = "DDLhrmDivisions"
  Text = "Divisions is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEhrmDivisions"
  runat = "server"
  TargetControlID = "DDLhrmDivisions"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlhrmDivisions"
  TypeName = "SIS.ATN.hrmDivisions"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
