<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_ijtMonths.ascx.vb" Inherits="LC_ijtMonths" %>
<asp:DropDownList 
  ID = "DDLijtMonths"
  DataSourceID = "OdsDdlijtMonths"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorijtMonths"
  Runat = "server" 
  ControlToValidate = "DDLijtMonths"
  Text = "Months is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEijtMonths"
  runat = "server"
  TargetControlID = "DDLijtMonths"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlijtMonths"
  TypeName = "SIS.IJT.ijtMonths"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
