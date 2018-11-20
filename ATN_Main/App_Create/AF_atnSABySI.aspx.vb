Partial Class AF_atnSABySI
  Inherits SIS.SYS.InsertBase
  Protected Sub FVatnSABySI_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySI.Init
    DataClassName = "AatnSABySI"
    SetFormView = FVatnSABySI
  End Sub
  Protected Sub TBLatnSABySI_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSABySI.Init
    SetToolBar = TBLatnSABySI
  End Sub
  Protected Sub ODSatnSABySI_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnSABySI.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.ATN.atnSABySI = CType(e.ReturnValue,SIS.ATN.atnSABySI)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&SerialNo=" & oDC.SerialNo
      TBLatnSABySI.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVatnSABySI_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySI.DataBound
    SIS.ATN.atnSABySI.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVatnSABySI_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySI.PreRender
    Dim oF_MonthID As LC_atnMonths = FVatnSABySI.FindControl("F_MonthID")
    oF_MonthID.Enabled = True
    oF_MonthID.SelectedValue = String.Empty
    If Not Session("F_MonthID") Is Nothing Then
      If Session("F_MonthID") <> String.Empty Then
        oF_MonthID.SelectedValue = Session("F_MonthID")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVatnSABySI.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVatnSABySI.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Create") & "/AF_atnSABySI.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnSABySI") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnSABySI", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVatnSABySI.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVatnSABySI.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.idmProjects.SelectidmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ATN_SABySI_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.ATN.idmProjects = SIS.ATN.idmProjects.idmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
