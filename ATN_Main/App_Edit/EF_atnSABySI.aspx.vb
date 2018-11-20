Imports System.Web.Script.Serialization
Partial Class EF_atnSABySI
  Inherits SIS.SYS.UpdateBase
  Public Property ChildAddable() As Boolean
    Get
      If ViewState("ChildAddable") IsNot Nothing Then
        Return CType(ViewState("ChildAddable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("ChildAddable", value)
    End Set
  End Property

  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSatnSABySI_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSatnSABySI.Selected
    Dim tmp As SIS.ATN.atnSABySI = CType(e.ReturnValue, SIS.ATN.atnSABySI)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    ChildAddable = tmp.ChildAddable
  End Sub
  Protected Sub FVatnSABySI_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySI.Init
    DataClassName = "EatnSABySI"
    SetFormView = FVatnSABySI
  End Sub
  Protected Sub TBLatnSABySI_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSABySI.Init
    SetToolBar = TBLatnSABySI
  End Sub
  Protected Sub FVatnSABySI_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVatnSABySI.PreRender
    TBLatnSABySI.EnableSave = Editable
    TBLatnSABySI.EnableDelete = Deleteable
    TBLatnSABySIDays.EnableAdd = Editable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ATN_Main/App_Edit") & "/EF_atnSABySI.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptatnSABySI") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptatnSABySI", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvatnSABySIDaysCC As New gvBase
  Protected Sub GVatnSABySIDays_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVatnSABySIDays.Init
    gvatnSABySIDaysCC.DataClassName = "GatnSABySIDays"
    gvatnSABySIDaysCC.SetGridView = GVatnSABySIDays
  End Sub
  Protected Sub TBLatnSABySIDays_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnSABySIDays.Init
    gvatnSABySIDaysCC.SetToolBar = TBLatnSABySIDays
  End Sub
  Protected Sub GVatnSABySIDays_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVatnSABySIDays.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVatnSABySIDays.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim CardNo As String = GVatnSABySIDays.DataKeys(e.CommandArgument).Values("CardNo")
        Dim RedirectUrl As String = TBLatnSABySIDays.EditUrl & "?SerialNo=" & SerialNo & "&CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVatnSABySIDays.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim CardNo As String = GVatnSABySIDays.DataKeys(e.CommandArgument).Values("CardNo")
        SIS.ATN.atnSABySIDays.DeleteWF(SerialNo, CardNo)
        GVatnSABySIDays.DataBind()
      Catch ex As Exception
        Dim ErrMsg As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim Script As String = String.Format("alert({0});", ErrMsg)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", Script, True)
      End Try
    End If
  End Sub
  Protected Sub TBLatnSABySIDays_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLatnSABySIDays.AddClicked
    Dim SerialNo As Int32 = CType(FVatnSABySI.FindControl("F_SerialNo"), TextBox).Text
    TBLatnSABySIDays.AddUrl &= "?SerialNo=" & SerialNo
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ATN.idmProjects.SelectidmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
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
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function UpdateAttendance(ByVal value As String) As String
    Dim aVal() As String = value.Split("|".ToCharArray)
    Dim sCtl As String = aVal(0)
    Dim mRet As String = "0|" & value
    Dim SerialNo As String = aVal(1)
    Dim CardNo As String = aVal(2)
    Dim State As String = aVal(3)
    Dim oVar As SIS.ATN.atnSABySIDays = SIS.ATN.atnSABySIDays.atnSABySIDaysGetByID(SerialNo, CardNo)
    If oVar Is Nothing Then
      mRet = "1|" & value & "|Record not found."
    Else
      If State = "BLANK" Then State = ""
      Dim tmp() As String = sCtl.Split("_".ToCharArray)
      Dim prop As String = tmp(tmp.Length - 2).Replace("Label", "")
      CallByName(oVar, prop, CallType.Let, State)
      SIS.ATN.atnSABySIDays.UpdateData(oVar)
      mRet = "0|" & value
    End If
    Return mRet
  End Function

  Private Sub EF_atnSABySI_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If Page.IsPostBack OrElse Page.IsCallback Then
      GVatnSABySIDays.DataBind()
    End If
  End Sub

  Private Sub FVatnSABySI_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVatnSABySI.ItemCommand
    Try
      'If e.CommandName.ToLower = "lgdownload" Then
      '  Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
      '  Dim SerialNo As String = aVal(0)
      '  Dim tmpApl As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(SerialNo)
      '  If IO.File.Exists(tmpApl.DiskFileName) Then
      '    Response.Clear()
      '    Response.AppendHeader("content-disposition", "attachment; filename=" & tmpApl.FileName)
      '    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(tmpApl.FileName)
      '    Response.WriteFile(tmpApl.DiskFileName)
      '    Response.End()
      '  End If
      'End If
      If e.CommandName.ToLower = "lgupload" Then
        Dim ReportFile As FileUpload = CType(FVatnSABySI.FindControl("F_ReportFile"), FileUpload)
        If ReportFile.HasFile Then
          Dim tmpPath As String = ConfigurationManager.AppSettings("AtchDir")
          If Not IO.Directory.Exists(tmpPath) Then
            tmpPath = ConfigurationManager.AppSettings("AtchDir1")
          End If
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          ReportFile.SaveAs(tmpFile)
          Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
          Dim SerialNo As String = aVal(0)
          Dim tmpApl As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(SerialNo)
          If tmpApl.FileName <> "" Then
            'Delete Old File
            If IO.File.Exists(tmpApl.DiskFileName) Then
              IO.File.Delete(tmpApl.DiskFileName)
            End If
          End If
          With tmpApl
            .DiskFileName = tmpFile
            .FileName = ReportFile.FileName
          End With
          SIS.ATN.atnSABySI.UpdateData(tmpApl)
          FVatnSABySI.DataBind()
        End If
      End If
      If e.CommandName.ToLower = "lgdelete" Then
        Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
        Dim SerialNo As String = aVal(0)
        Dim tmpApl As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(SerialNo)
        If IO.File.Exists(tmpApl.DiskFileName) Then
          IO.File.Delete(tmpApl.DiskFileName)
        End If
        With tmpApl
          .DiskFileName = ""
          .FileName = ""
        End With
        SIS.ATN.atnSABySI.UpdateData(tmpApl)
        FVatnSABySI.DataBind()
      End If

    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
  End Sub
End Class
