<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnPunchConfig.ascx.vb" Inherits="LC_atnPunchConfig" %>
<asp:DropDownList 
  ID = "DDLatnPunchConfig"
  DataSourceID = "OdsDdlatnPunchConfig"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnPunchConfig"
  Runat = "server" 
  ControlToValidate = "DDLatnPunchConfig"
  Text = "Punch Configuration is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEatnPunchConfig"
  runat = "server"
  TargetControlID = "DDLatnPunchConfig"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlatnPunchConfig"
  TypeName = "SIS.ATN.atnPunchConfig"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
