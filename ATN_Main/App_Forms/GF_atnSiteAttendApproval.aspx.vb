Imports System.Web.Script.Serialization
Partial Class GF_atnSiteAttendApproval
  Inherits SIS.SYS.GridBase
  Protected Sub GVatnSiteAttendApproval_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVatnSiteAttendApproval.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As String = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("FinYear")
        Dim MonthID As Int32 = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("MonthID")
        Dim CardNo As String = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("CardNo")
        Dim RedirectUrl As String = TBLatnSiteAttendApproval.EditUrl & "?FinYear=" & FinYear & "&MonthID=" & MonthID & "&CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim ApproverRemarks As String = CType(GVatnSiteAttendApproval.Rows(e.CommandArgument).FindControl("F_ApproverRemarks"), TextBox).Text
        Dim FinYear As String = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("FinYear")
        Dim MonthID As Int32 = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("MonthID")
        Dim CardNo As String = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("CardNo")
        SIS.ATN.atnSiteAttendApproval.ApproveWF(FinYear, MonthID, CardNo, ApproverRemarks)
        GVatnSiteAttendApproval.DataBind()
      Catch ex As Exception
        Dim ErrMsg As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim Script As String = String.Format("alert({0});", ErrMsg)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", Script, True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim ApproverRemarks As String = CType(GVatnSiteAttendApproval.Rows(e.CommandArgument).FindControl("F_ApproverRemarks"), TextBox).Text
        Dim FinYear As String = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("FinYear")
        Dim MonthID As Int32 = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("MonthID")
        Dim CardNo As String = GVatnSiteAttendApproval.DataKeys(e.CommandArgument).Values("CardNo")
        SIS.ATN.atnSiteAttendApproval.RejectWF(FinYear, MonthID, CardNo, ApproverRemarks)
        GVatnSiteAttendApproval.DataBind()
      Catch ex As Exception
        Dim ErrMsg As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim Script As String = String.Format("alert({0});", ErrMsg)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", Script, True)
      End Try
    End If
  End Sub
  Protected Sub GVatnSiteAttendApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVatnSiteAttendApproval.Init
    DataClassName = "GatnSiteAttendApproval"
    SetGridView = GVatnSiteAttendApproval
  End Sub
  Protected Sub TBLatnSiteAttendApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSiteAttendApproval.Init
    SetToolBar = TBLatnSiteAttendApproval
  End Sub
  Protected Sub F_MonthID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_MonthID.SelectedIndexChanged
    Session("F_MonthID") = F_MonthID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_ApprovedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ApprovedBy.TextChanged
    Session("F_ApprovedBy") = F_ApprovedBy.Text
    Session("F_ApprovedBy_Display") = F_ApprovedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ApprovedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_MonthID.SelectedValue = String.Empty
    If Not Session("F_MonthID") Is Nothing Then
      If Session("F_MonthID") <> String.Empty Then
        F_MonthID.SelectedValue = Session("F_MonthID")
      End If
    End If
    F_ApprovedBy_Display.Text = String.Empty
    If Not Session("F_ApprovedBy_Display") Is Nothing Then
      If Session("F_ApprovedBy_Display") <> String.Empty Then
        F_ApprovedBy_Display.Text = Session("F_ApprovedBy_Display")
      End If
    End If
    F_ApprovedBy.Text = String.Empty
    If Not Session("F_ApprovedBy") Is Nothing Then
      If Session("F_ApprovedBy") <> String.Empty Then
        F_ApprovedBy.Text = Session("F_ApprovedBy")
      End If
    End If
    Dim strScriptApprovedBy As String = "<script type=""text/javascript""> " &
      "function ACEApprovedBy_Selected(sender, e) {" &
      "  var F_ApprovedBy = $get('" & F_ApprovedBy.ClientID & "');" &
      "  var F_ApprovedBy_Display = $get('" & F_ApprovedBy_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ApprovedBy.value = p[0];" &
      "  F_ApprovedBy_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApprovedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApprovedBy", strScriptApprovedBy)
    End If
    Dim strScriptPopulatingApprovedBy As String = "<script type=""text/javascript""> " &
      "function ACEApprovedBy_Populating(o,e) {" &
      "  var p = $get('" & F_ApprovedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEApprovedBy_Populated(o,e) {" &
      "  var p = $get('" & F_ApprovedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApprovedByPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApprovedByPopulating", strScriptPopulatingApprovedBy)
    End If
    Dim validateScriptApprovedBy As String = "<script type=""text/javascript"">" &
      "  function validate_ApprovedBy(o) {" &
      "    validated_FK_ATN_SiteAttendance_ApprovedBy_main = true;" &
      "    validate_FK_ATN_SiteAttendance_ApprovedBy(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateApprovedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateApprovedBy", validateScriptApprovedBy)
    End If
    Dim validateScriptFK_ATN_SiteAttendance_ApprovedBy As String = "<script type=""text/javascript"">" &
      "  function validate_FK_ATN_SiteAttendance_ApprovedBy(o) {" &
      "    var value = o.id;" &
      "    var ApprovedBy = $get('" & F_ApprovedBy.ClientID & "');" &
      "    try{" &
      "    if(ApprovedBy.value==''){" &
      "      if(validated_FK_ATN_SiteAttendance_ApprovedBy.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ApprovedBy.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_ATN_SiteAttendance_ApprovedBy(value, validated_FK_ATN_SiteAttendance_ApprovedBy);" &
      "  }" &
      "  validated_FK_ATN_SiteAttendance_ApprovedBy_main = false;" &
      "  function validated_FK_ATN_SiteAttendance_ApprovedBy(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ATN_SiteAttendance_ApprovedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ATN_SiteAttendance_ApprovedBy", validateScriptFK_ATN_SiteAttendance_ApprovedBy)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ATN_SiteAttendance_ApprovedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ApprovedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(ApprovedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

End Class
