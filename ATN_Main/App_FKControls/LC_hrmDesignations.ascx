<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmDesignations.ascx.vb" Inherits="LC_hrmDesignations" %>
<asp:DropDownList 
  ID = "DDLhrmDesignations"
  DataSourceID = "OdsDdlhrmDesignations"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmDesignations"
  Runat = "server" 
  ControlToValidate = "DDLhrmDesignations"
  Text = "Designations is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEhrmDesignations"
  runat = "server"
  TargetControlID = "DDLhrmDesignations"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlhrmDesignations"
  TypeName = "SIS.ATN.hrmDesignations"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
