<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnPunchStatus.ascx.vb" Inherits="LC_atnPunchStatus" %>
<asp:DropDownList 
  ID = "DDLatnPunchStatus"
  DataSourceID = "OdsDdlatnPunchStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnPunchStatus"
  Runat = "server" 
  ControlToValidate = "DDLatnPunchStatus"
  Text = "Punch Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEatnPunchStatus"
  runat = "server"
  TargetControlID = "DDLatnPunchStatus"
  PromptCssClass="DDSearchPrompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlatnPunchStatus"
  TypeName = "SIS.ATN.atnPunchStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
