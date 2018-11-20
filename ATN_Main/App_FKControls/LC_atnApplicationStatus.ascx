<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnApplicationStatus.ascx.vb" Inherits="LC_atnApplicationStatus" %>
<asp:DropDownList 
  ID = "DDLatnApplicationStatus"
  DataSourceID = "OdsDdlatnApplicationStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnApplicationStatus"
  Runat = "server" 
  ControlToValidate = "DDLatnApplicationStatus"
  Text = "Application Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEatnApplicationStatus"
  runat = "server"
  TargetControlID = "DDLatnApplicationStatus"
  PromptCssClass="DDSearchPrompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlatnApplicationStatus"
  TypeName = "SIS.ATN.atnApplicationStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
