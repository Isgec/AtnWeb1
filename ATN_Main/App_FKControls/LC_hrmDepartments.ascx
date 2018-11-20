<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmDepartments.ascx.vb" Inherits="LC_hrmDepartments" %>
<asp:DropDownList 
  ID = "DDLhrmDepartments"
  DataSourceID = "OdsDdlhrmDepartments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmDepartments"
  Runat = "server" 
  ControlToValidate = "DDLhrmDepartments"
  Text = "Departments is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEhrmDepartments"
  runat = "server"
  TargetControlID = "DDLhrmDepartments"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlhrmDepartments"
  TypeName = "SIS.ATN.hrmDepartments"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
