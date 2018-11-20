<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_atnTranType.ascx.vb" Inherits="LC_atnTranType" %>
<asp:DropDownList 
  ID = "DDLatnTranType"
  DataSourceID = "OdsDdlatnTranType"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoratnTranType"
  Runat = "server" 
  ControlToValidate = "DDLatnTranType"
  Text = "Transaction Type is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEatnTranType"
  runat = "server"
  TargetControlID = "DDLatnTranType"
  PromptCssClass="DDSearchPrompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlatnTranType"
  TypeName = "SIS.ATN.atnTranType"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
