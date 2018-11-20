Imports System.Web.Script.Serialization

Partial Class AF_atnSABySIDays
  Inherits SIS.SYS.InsertBase
  Protected Sub FVatnSABySIDays_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySIDays.Init
    DataClassName = "AatnSABySIDays"
    SetFormView = FVatnSABySIDays
  End Sub
  Protected Sub TBLatnSABySIDays_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSABySIDays.Init
    SetToolBar = TBLatnSABySIDays
  End Sub
  Protected Sub FVatnSABySIDays_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySIDays.DataBound
    SIS.ATN.atnSABySIDays.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVatnSABySIDays_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySIDays.PreRender
    Dim oF_SerialNo_Display As Label = FVatnSABySIDays.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox = FVatnSABySIDays.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_CardNo_Display As Label = FVatnSABySIDays.FindControl("F_CardNo_Display")
    Dim oF_CardNo As TextBox = FVatnSABySIDays.FindControl("F_CardNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Create") & "/AF_atnSABySIDays.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnSABySIDays") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnSABySIDays", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVatnSABySIDays.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVatnSABySIDays.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("CardNo") IsNot Nothing Then
      CType(FVatnSABySIDays.FindControl("F_CardNo"), TextBox).Text = Request.QueryString("CardNo")
      CType(FVatnSABySIDays.FindControl("F_CardNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.atnSABySI.SelectatnSABySIAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.newHrmEmployees.SelectnewHrmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ATN_SABySIDays_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ATN_SABySIDays_CardNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CardNo As String = CType(aVal(1), String)
    Dim oVar As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(CardNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub FVatnSABySIDays_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVatnSABySIDays.ItemInserting
    Dim SerialNo As String = e.Values("SerialNo")
    Dim CardNo As String = e.Values("CardNo")
    Dim tmp As SIS.ATN.atnSABySIDays = SIS.ATN.atnSABySIDays.atnSABySIDaysGetByID(SerialNo, CardNo)
    If tmp IsNot Nothing Then
      Dim ErrMsg As String = New JavaScriptSerializer().Serialize("Site Employee already added in list.")
      Dim Script As String = String.Format("alert({0});", ErrMsg)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", Script, True)
      e.Cancel = True
    End If
  End Sub

  Private Sub GVnewHrmEmployees_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVnewHrmEmployees.RowCommand
    If e.CommandName.ToLower = "lgselect" Then
      Try
        Dim CardNo As String = GVnewHrmEmployees.DataKeys(e.CommandArgument).Values("CardNo")
        Dim SerialNo As String = CType(FVatnSABySIDays.FindControl("F_SerialNo"), TextBox).Text
        Dim tmp As New SIS.ATN.atnSABySIDays
        tmp.SerialNo = SerialNo
        tmp.CardNo = CardNo
        SIS.ATN.atnSABySIDays.InsertData(tmp)
        GVnewHrmEmployees.DataBind()
      Catch ex As Exception
        Dim ErrMsg As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim Script As String = String.Format("alert({0});", ErrMsg)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", Script, True)
      End Try
    End If
  End Sub
End Class
