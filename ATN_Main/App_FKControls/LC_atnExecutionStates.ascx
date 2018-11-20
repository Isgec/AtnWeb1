<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnExecutionStates.ascx.vb" Inherits="LC_atnExecutionStates" %>
<asp:DropDownList 
  ID = "DDLatnExecutionStates"
  DataSourceID = "OdsDdlatnExecutionStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnExecutionStates"
  Runat = "server" 
  ControlToValidate = "DDLatnExecutionStates"
  Text = "Execution States is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEatnExecutionStates"
  runat = "server"
  TargetControlID = "DDLatnExecutionStates"
  PromptCssClass="DDSearchPrompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlatnExecutionStates"
  TypeName = "SIS.ATN.atnExecutionStates"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
