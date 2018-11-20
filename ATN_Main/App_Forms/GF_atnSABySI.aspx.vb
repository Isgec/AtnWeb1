Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_atnSABySI
  Inherits SIS.SYS.GridBase
  Protected Sub GVatnSABySI_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVatnSABySI.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVatnSABySI.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLatnSABySI.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVatnSABySI.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.ATN.atnSABySI.DeleteWF(SerialNo)
        GVatnSABySI.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVatnSABySI.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.ATN.atnSABySI.InitiateWF(SerialNo)
        GVatnSABySI.DataBind()
      Catch ex As Exception
        Dim ErrMsg As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim Script As String = String.Format("alert({0});", ErrMsg)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", Script, True)
      End Try
    End If
  End Sub
  Protected Sub GVatnSABySI_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVatnSABySI.Init
    DataClassName = "GatnSABySI"
    SetGridView = GVatnSABySI
  End Sub
  Protected Sub TBLatnSABySI_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSABySI.Init
    SetToolBar = TBLatnSABySI
  End Sub
  Protected Sub F_MonthID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_MonthID.SelectedIndexChanged
    Session("F_MonthID") = F_MonthID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.idmProjects.SelectidmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_MonthID.SelectedValue = String.Empty
    If Not Session("F_MonthID") Is Nothing Then
      If Session("F_MonthID") <> String.Empty Then
        F_MonthID.SelectedValue = Session("F_MonthID")
      End If
    End If
    F_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        F_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    F_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        F_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim strScriptProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Selected(sender, e) {" &
      "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ProjectID.value = p[0];" &
      "  F_ProjectID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
    End If
    Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Populating(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEProjectID_Populated(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectID(o) {" &
      "    validated_FK_ATN_SABySI_ProjectID_main = true;" &
      "    validate_FK_ATN_SABySI_ProjectID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptFK_ATN_SABySI_ProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_ATN_SABySI_ProjectID(o) {" &
      "    var value = o.id;" &
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "    try{" &
      "    if(ProjectID.value==''){" &
      "      if(validated_FK_ATN_SABySI_ProjectID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_ATN_SABySI_ProjectID(value, validated_FK_ATN_SABySI_ProjectID);" &
      "  }" &
      "  validated_FK_ATN_SABySI_ProjectID_main = false;" &
      "  function validated_FK_ATN_SABySI_ProjectID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ATN_SABySI_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ATN_SABySI_ProjectID", validateScriptFK_ATN_SABySI_ProjectID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ATN_SABySI_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.ATN.idmProjects = SIS.ATN.idmProjects.idmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub cmdUpload_Command(sender As Object, e As CommandEventArgs) Handles cmdUpload.Command
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim ErrMsg As String = ""
    Dim script As String = ""
    Try
      With F_FileUpload
        If .HasFile Then
          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          .SaveAs(tmpFile)
          Dim fi As FileInfo = New FileInfo(tmpFile)
          Using xlP As ExcelPackage = New ExcelPackage(fi)
            Dim wsD As ExcelWorksheet = Nothing
            Try
              Try
                wsD = xlP.Workbook.Worksheets("Data")
              Catch ex As Exception
                wsD = Nothing
              End Try
              If wsD Is Nothing Then
                ErrMsg = "XL File does not have DATA sheet, Invalid MS-EXCEL file."
                xlP.Dispose()
                GoTo over
              End If
              Dim SerialNo As Integer = wsD.Cells(3, 2).Text

              Dim tmpS As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(SerialNo)
              If Not tmpS.Editable Then
                ErrMsg = "Attendance Data is not Editable, can NOT update."
                xlP.Dispose()
                GoTo over
              End If
              Dim tmpDs As List(Of SIS.ATN.atnSABySIDays) = SIS.ATN.atnSABySIDays.atnSABySIDaysSelectList(0, 999, "", False, "", SerialNo)

              Dim CardNo As String = ""
              Dim ItemDesc As String = ""
              For I As Integer = 5 To 999
                CardNo = wsD.Cells(I, 1).Text
                If CardNo = String.Empty Then Exit For
                Dim tmpD As SIS.ATN.atnSABySIDays = Nothing
                For Each tmpD In tmpDs
                  If tmpD.CardNo = CardNo Then
                    With tmpD
                      .D22 = wsD.Cells(I, 6).Text.ToUpper
                      .D23 = wsD.Cells(I, 7).Text.ToUpper
                      .D24 = wsD.Cells(I, 8).Text.ToUpper
                      .D25 = wsD.Cells(I, 9).Text.ToUpper
                      .D26 = wsD.Cells(I, 10).Text.ToUpper
                      .D27 = wsD.Cells(I, 11).Text.ToUpper
                      .D28 = wsD.Cells(I, 12).Text.ToUpper
                      .D29 = wsD.Cells(I, 13).Text.ToUpper
                      .D30 = wsD.Cells(I, 14).Text.ToUpper
                      .D31 = wsD.Cells(I, 15).Text.ToUpper
                      .D01 = wsD.Cells(I, 16).Text.ToUpper
                      .D02 = wsD.Cells(I, 17).Text.ToUpper
                      .D03 = wsD.Cells(I, 18).Text.ToUpper
                      .D04 = wsD.Cells(I, 19).Text.ToUpper
                      .D05 = wsD.Cells(I, 20).Text.ToUpper
                      .D06 = wsD.Cells(I, 21).Text.ToUpper
                      .D07 = wsD.Cells(I, 22).Text.ToUpper
                      .D08 = wsD.Cells(I, 23).Text.ToUpper
                      .D09 = wsD.Cells(I, 24).Text.ToUpper
                      .D10 = wsD.Cells(I, 25).Text.ToUpper
                      .D11 = wsD.Cells(I, 26).Text.ToUpper
                      .D12 = wsD.Cells(I, 27).Text.ToUpper
                      .D13 = wsD.Cells(I, 28).Text.ToUpper
                      .D14 = wsD.Cells(I, 29).Text.ToUpper
                      .D15 = wsD.Cells(I, 30).Text.ToUpper
                      .D16 = wsD.Cells(I, 31).Text.ToUpper
                      .D17 = wsD.Cells(I, 32).Text.ToUpper
                      .D18 = wsD.Cells(I, 33).Text.ToUpper
                      .D19 = wsD.Cells(I, 34).Text.ToUpper
                      .D20 = wsD.Cells(I, 35).Text.ToUpper
                      .D21 = wsD.Cells(I, 36).Text.ToUpper
                      .Remarks = wsD.Cells(I, 37).Text
                    End With
                    SIS.ATN.atnSABySIDays.UpdateData(tmpD)
                    Exit For
                  End If
                Next
              Next
            Catch ex As Exception
              ErrMsg = New JavaScriptSerializer().Serialize(ex.Message.ToString())
              script = String.Format("alert({0});", ErrMsg)
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
            End Try
            xlP.Save()
            wsD.Dispose()
            xlP.Dispose()
          End Using
          HttpContext.Current.Server.ScriptTimeout = st
          ErrMsg = New JavaScriptSerializer().Serialize("File Uploaded")
          script = String.Format("alert({0});", ErrMsg)
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)

          'Dim FileNameForUser As String = F_FileUpload.FileName
          ''======================
          'Response.Clear()
          'Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
          'Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
          'Response.WriteFile(tmpFile)
          'Response.End()

        End If
      End With
    Catch ex As Exception
      ErrMsg = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      script = String.Format("alert({0});", ErrMsg)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
    Exit Sub
over:
    ErrMsg = New JavaScriptSerializer().Serialize(ErrMsg)
    script = String.Format("alert({0});", ErrMsg)
    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  End Sub
End Class
