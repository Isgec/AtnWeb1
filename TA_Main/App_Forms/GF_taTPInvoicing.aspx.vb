Partial Class GF_taTPInvoicing
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taTPInvoicing.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?InvoiceNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaTPInvoicing_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaTPInvoicing.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim InvoiceNo As String = GVtaTPInvoicing.DataKeys(e.CommandArgument).Values("InvoiceNo")  
        Dim RedirectUrl As String = TBLtaTPInvoicing.EditUrl & "?InvoiceNo=" & InvoiceNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaTPInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaTPInvoicing.Init
    DataClassName = "GtaTPInvoicing"
    SetGridView = GVtaTPInvoicing
  End Sub
  Protected Sub TBLtaTPInvoicing_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTPInvoicing.Init
    SetToolBar = TBLtaTPInvoicing
  End Sub
  Protected Sub F_BookingDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BookingDate.TextChanged
    Session("F_BookingDate") = F_BookingDate.Text
    InitGridPage()
  End Sub
  Protected Sub F_TravelDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TravelDate.TextChanged
    Session("F_TravelDate") = F_TravelDate.Text
    InitGridPage()
  End Sub
  Protected Sub F_EmployeeCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EmployeeCode.TextChanged
    Session("F_EmployeeCode") = F_EmployeeCode.Text
    Session("F_EmployeeCode_Display") = F_EmployeeCode_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function EmployeeCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.atnEmployees.SelectatnEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_EmployeeCode_Display.Text = String.Empty
    If Not Session("F_EmployeeCode_Display") Is Nothing Then
      If Session("F_EmployeeCode_Display") <> String.Empty Then
        F_EmployeeCode_Display.Text = Session("F_EmployeeCode_Display")
      End If
    End If
    F_EmployeeCode.Text = String.Empty
    If Not Session("F_EmployeeCode") Is Nothing Then
      If Session("F_EmployeeCode") <> String.Empty Then
        F_EmployeeCode.Text = Session("F_EmployeeCode")
      End If
    End If
    Dim strScriptEmployeeCode As String = "<script type=""text/javascript""> " & _
      "function ACEEmployeeCode_Selected(sender, e) {" & _
      "  var F_EmployeeCode = $get('" & F_EmployeeCode.ClientID & "');" & _
      "  var F_EmployeeCode_Display = $get('" & F_EmployeeCode_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_EmployeeCode.value = p[0];" & _
      "  F_EmployeeCode_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeCode") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeCode", strScriptEmployeeCode)
      End If
    Dim strScriptPopulatingEmployeeCode As String = "<script type=""text/javascript""> " & _
      "function ACEEmployeeCode_Populating(o,e) {" & _
      "  var p = $get('" & F_EmployeeCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEEmployeeCode_Populated(o,e) {" & _
      "  var p = $get('" & F_EmployeeCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeCodePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeCodePopulating", strScriptPopulatingEmployeeCode)
      End If
    Dim validateScriptEmployeeCode As String = "<script type=""text/javascript"">" & _
      "  function validate_EmployeeCode(o) {" & _
      "    validated_FK_TA_TPInvoicing_EmployeeCode_main = true;" & _
      "    validate_FK_TA_TPInvoicing_EmployeeCode(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEmployeeCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEmployeeCode", validateScriptEmployeeCode)
    End If
    Dim validateScriptFK_TA_TPInvoicing_EmployeeCode As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_TA_TPInvoicing_EmployeeCode(o) {" & _
      "    var value = o.id;" & _
      "    var EmployeeCode = $get('" & F_EmployeeCode.ClientID & "');" & _
      "    try{" & _
      "    if(EmployeeCode.value==''){" & _
      "      if(validated_FK_TA_TPInvoicing_EmployeeCode.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + EmployeeCode.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_TA_TPInvoicing_EmployeeCode(value, validated_FK_TA_TPInvoicing_EmployeeCode);" & _
      "  }" & _
      "  validated_FK_TA_TPInvoicing_EmployeeCode_main = false;" & _
      "  function validated_FK_TA_TPInvoicing_EmployeeCode(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_TPInvoicing_EmployeeCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_TPInvoicing_EmployeeCode", validateScriptFK_TA_TPInvoicing_EmployeeCode)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_TPInvoicing_EmployeeCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim EmployeeCode As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.atnEmployeesGetByID(EmployeeCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

  Protected Sub GVtaTPInvoicing_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GVtaTPInvoicing.RowDataBound
    If e.Row.RowType = DataControlRowType.Footer Then
      CType(e.Row.FindControl("LabelTotalAmount"), Label).Text = SIS.TA.taTPInvoicing.TotalAmount
    End If
  End Sub
End Class
