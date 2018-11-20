Imports System.Web.Script.Serialization
Partial Class GF_atnSiteAttendPosting
  Inherits SIS.SYS.GridBase
  Protected Sub GVatnSiteAttendance_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVatnSiteAttendance.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As String = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("FinYear")
        Dim MonthID As Int32 = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("MonthID")
        Dim CardNo As String = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("CardNo")
        Dim RedirectUrl As String = TBLatnSiteAttendance.EditUrl & "?FinYear=" & FinYear & "&MonthID=" & MonthID & "&CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim PostingRemarks As String = CType(GVatnSiteAttendance.Rows(e.CommandArgument).FindControl("F_PostingRemarks"), TextBox).Text
        Dim FinYear As String = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("FinYear")
        Dim MonthID As Int32 = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("MonthID")
        Dim CardNo As String = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("CardNo")
        Dim tmpStr As String = SIS.ATN.atnSiteAttendPosting.InitiateWF(FinYear, MonthID, CardNo, PostingRemarks)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "lgValidate.show_leave('" & New JavaScriptSerializer().Serialize(tmpStr) & "');", True)
        'GVatnSiteAttendance.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim PostingRemarks As String = CType(GVatnSiteAttendance.Rows(e.CommandArgument).FindControl("F_PostingRemarks"), TextBox).Text
        Dim FinYear As String = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("FinYear")
        Dim MonthID As Int32 = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("MonthID")
        Dim CardNo As String = GVatnSiteAttendance.DataKeys(e.CommandArgument).Values("CardNo")
        SIS.ATN.atnSiteAttendPosting.RejectWF(FinYear, MonthID, CardNo, PostingRemarks)
        GVatnSiteAttendance.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVatnSiteAttendance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVatnSiteAttendance.Init
    DataClassName = "GatnSiteAttendance"
    SetGridView = GVatnSiteAttendance
  End Sub
  Protected Sub TBLatnSiteAttendance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSiteAttendance.Init
    SetToolBar = TBLatnSiteAttendance
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
  Private LastColor As String = ""
  Private Sub GVatnSiteAttendance_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GVatnSiteAttendance.RowCreated
    If e.Row.RowType = DataControlRowType.Header Then
      LastColor = ""
    End If
    If e.Row.RowType = DataControlRowType.DataRow Then
      If LastColor = "" Then
        LastColor = "#E5E5E5"
        e.Row.Style.Item("background-color") = LastColor
        e.Row.Style.Add("onmouseover", "yellow")
        CType(e.Row.FindControl("row1"), HtmlTableRow).Style.Add(HtmlTextWriterStyle.BackgroundColor, LastColor)
        CType(e.Row.FindControl("row2"), HtmlTableRow).Style.Add(HtmlTextWriterStyle.BackgroundColor, LastColor)
      Else
        LastColor = ""
      End If
    End If
  End Sub
  Private Sub GF_atnSiteAttendance_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If Page.IsPostBack OrElse Page.IsCallback Then
      GVatnSiteAttendance.DataBind()
    End If
  End Sub
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function UpdateAttendance(ByVal value As String) As String
    Dim aVal() As String = value.Split("|".ToCharArray)
    Dim sCtl As String = aVal(0)
    Dim mRet As String = "0|" & value
    Dim FinYear As String = aVal(1)
    Dim MonthID As String = aVal(2)
    Dim CardNo As String = aVal(3)
    Dim State As String = aVal(4)
    Dim oVar As SIS.ATN.atnSiteAttendance = SIS.ATN.atnSiteAttendance.atnSiteAttendanceGetByID(FinYear, MonthID, CardNo)
    If oVar Is Nothing Then
      mRet = "1|" & value & "|Record not found."
    Else
      If State = "BLANK" Then State = ""
      Dim tmp() As String = sCtl.Split("_".ToCharArray)
      Dim Pprop As String = tmp(tmp.Length - 2).Replace("Label", "")
      CallByName(oVar, Pprop, CallType.Let, State)
      SIS.ATN.atnSiteAttendance.UpdateData(oVar)
      mRet = "0|" & value
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function UpdateAppliedLeaveStatus(ByVal Context As String) As String
    Return SIS.ATN.atnSiteAttendPosting.UpdateAppliedLeaveStatus(Context)
  End Function


End Class
