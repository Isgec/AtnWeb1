<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnLeaveTypes.ascx.vb" Inherits="LC_atnLeaveTypes" %>
<asp:DropDownList 
  ID = "DDLatnLeaveTypes"
  DataSourceID = "OdsDdlatnLeaveTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnLeaveTypes"
  Runat = "server" 
  ControlToValidate = "DDLatnLeaveTypes"
  Text = "Leave Types is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEatnLeaveTypes"
  runat = "server"
  TargetControlID = "DDLatnLeaveTypes"
  PromptCssClass="DDSearchPrompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlatnLeaveTypes"
  TypeName = "SIS.ATN.atnLeaveTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
