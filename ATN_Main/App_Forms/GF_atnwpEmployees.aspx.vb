Partial Class GF_atnwpEmployees
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnwpEmployees.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CardNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVatnwpEmployees_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVatnwpEmployees.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CardNo As String = GVatnwpEmployees.DataKeys(e.CommandArgument).Values("CardNo")  
        Dim RedirectUrl As String = TBLatnwpEmployees.EditUrl & "?CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim CardNo As String = GVatnwpEmployees.DataKeys(e.CommandArgument).Values("CardNo")  
        SIS.ATN.atnwpEmployees.InitiateWF(CardNo)
        GVatnwpEmployees.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim CardNo As String = GVatnwpEmployees.DataKeys(e.CommandArgument).Values("CardNo")  
        SIS.ATN.atnwpEmployees.ApproveWF(CardNo)
        GVatnwpEmployees.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVatnwpEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVatnwpEmployees.Init
    DataClassName = "GatnwpEmployees"
    SetGridView = GVatnwpEmployees
  End Sub
  Protected Sub TBLatnwpEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnwpEmployees.Init
    SetToolBar = TBLatnwpEmployees
  End Sub
  Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
    Session("F_CardNo") = F_CardNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_C_DivisionID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DivisionID.SelectedIndexChanged
    Session("F_C_DivisionID") = F_C_DivisionID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_OfficeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_OfficeID.SelectedIndexChanged
    Session("F_C_OfficeID") = F_C_OfficeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_DepartmentID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DepartmentID.SelectedIndexChanged
    Session("F_C_DepartmentID") = F_C_DepartmentID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_DesignationID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DesignationID.SelectedIndexChanged
    Session("F_C_DesignationID") = F_C_DesignationID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_ProjectSiteID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_ProjectSiteID.TextChanged
    Session("F_C_ProjectSiteID") = F_C_ProjectSiteID.Text
    Session("F_C_ProjectSiteID_Display") = F_C_ProjectSiteID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function C_ProjectSiteIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.idmProjects.SelectidmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_C_CompanyID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_CompanyID.SelectedIndexChanged
    Session("F_C_CompanyID") = F_C_CompanyID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_C_DivisionID.SelectedValue = String.Empty
    If Not Session("F_C_DivisionID") Is Nothing Then
      If Session("F_C_DivisionID") <> String.Empty Then
        F_C_DivisionID.SelectedValue = Session("F_C_DivisionID")
      End If
    End If
    F_C_OfficeID.SelectedValue = String.Empty
    If Not Session("F_C_OfficeID") Is Nothing Then
      If Session("F_C_OfficeID") <> String.Empty Then
        F_C_OfficeID.SelectedValue = Session("F_C_OfficeID")
      End If
    End If
    F_C_DepartmentID.SelectedValue = String.Empty
    If Not Session("F_C_DepartmentID") Is Nothing Then
      If Session("F_C_DepartmentID") <> String.Empty Then
        F_C_DepartmentID.SelectedValue = Session("F_C_DepartmentID")
      End If
    End If
    F_C_DesignationID.SelectedValue = String.Empty
    If Not Session("F_C_DesignationID") Is Nothing Then
      If Session("F_C_DesignationID") <> String.Empty Then
        F_C_DesignationID.SelectedValue = Session("F_C_DesignationID")
      End If
    End If
    F_C_ProjectSiteID_Display.Text = String.Empty
    If Not Session("F_C_ProjectSiteID_Display") Is Nothing Then
      If Session("F_C_ProjectSiteID_Display") <> String.Empty Then
        F_C_ProjectSiteID_Display.Text = Session("F_C_ProjectSiteID_Display")
      End If
    End If
    F_C_ProjectSiteID.Text = String.Empty
    If Not Session("F_C_ProjectSiteID") Is Nothing Then
      If Session("F_C_ProjectSiteID") <> String.Empty Then
        F_C_ProjectSiteID.Text = Session("F_C_ProjectSiteID")
      End If
    End If
    Dim strScriptC_ProjectSiteID As String = "<script type=""text/javascript""> " & _
      "function ACEC_ProjectSiteID_Selected(sender, e) {" & _
      "  var F_C_ProjectSiteID = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
      "  var F_C_ProjectSiteID_Display = $get('" & F_C_ProjectSiteID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_C_ProjectSiteID.value = p[0];" & _
      "  F_C_ProjectSiteID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_C_ProjectSiteID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_C_ProjectSiteID", strScriptC_ProjectSiteID)
      End If
    Dim strScriptPopulatingC_ProjectSiteID As String = "<script type=""text/javascript""> " & _
      "function ACEC_ProjectSiteID_Populating(o,e) {" & _
      "  var p = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEC_ProjectSiteID_Populated(o,e) {" & _
      "  var p = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_C_ProjectSiteIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_C_ProjectSiteIDPopulating", strScriptPopulatingC_ProjectSiteID)
      End If
    F_C_CompanyID.SelectedValue = String.Empty
    If Not Session("F_C_CompanyID") Is Nothing Then
      If Session("F_C_CompanyID") <> String.Empty Then
        F_C_CompanyID.SelectedValue = Session("F_C_CompanyID")
      End If
    End If
    Dim validateScriptC_ProjectSiteID As String = "<script type=""text/javascript"">" & _
      "  function validate_C_ProjectSiteID(o) {" & _
      "    validated_FK_HRM_C_ProjectSiteID_main = true;" & _
      "    validate_FK_HRM_C_ProjectSiteID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateC_ProjectSiteID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateC_ProjectSiteID", validateScriptC_ProjectSiteID)
    End If
    Dim validateScriptFK_HRM_C_ProjectSiteID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_HRM_C_ProjectSiteID(o) {" & _
      "    var value = o.id;" & _
      "    var C_ProjectSiteID = $get('" & F_C_ProjectSiteID.ClientID & "');" & _
      "    try{" & _
      "    if(C_ProjectSiteID.value==''){" & _
      "      if(validated_FK_HRM_C_ProjectSiteID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + C_ProjectSiteID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_HRM_C_ProjectSiteID(value, validated_FK_HRM_C_ProjectSiteID);" & _
      "  }" & _
      "  validated_FK_HRM_C_ProjectSiteID_main = false;" & _
      "  function validated_FK_HRM_C_ProjectSiteID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_C_ProjectSiteID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_C_ProjectSiteID", validateScriptFK_HRM_C_ProjectSiteID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_C_ProjectSiteID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim C_ProjectSiteID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.idmProjects = SIS.ATN.idmProjects.idmProjectsGetByID(C_ProjectSiteID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
