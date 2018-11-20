Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class filedownload
    Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim docPK As String = ""
    Dim filePK As String = ""
    Dim downloadType As Integer = 0
    '0=Template
    '1=Attachement
    Dim val() As String = Nothing
    Dim Value As String = ""
    If Request.QueryString("sasi") IsNot Nothing Then
      Value = Request.QueryString("sasi")
      DownloadSASI(Value)
    End If
    If Request.QueryString("sasr") IsNot Nothing Then
      Value = Request.QueryString("sasr")
      DownloadSASR(Value)
    End If

  End Sub
  Private Sub DownloadSASR(ByVal value As String)
    Dim aVal() As String = value.Split("|".ToCharArray)
    Dim SerialNo As String = aVal(0)
    Dim tmpApl As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(SerialNo)
    If IO.File.Exists(tmpApl.DiskFileName) Then
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & tmpApl.FileName)
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(tmpApl.FileName)
      Response.WriteFile(tmpApl.DiskFileName)
      Response.End()
    End If
  End Sub

#Region "SASI "
  'Private Function WriteBItemXL(ByVal xlWS As ExcelWorksheet, ByVal r As Integer, ByVal SerialNo As Integer, ByVal BOMNo As Integer, ByVal pItemNo As Integer) As Integer
  '  Dim Items As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.GetByParentPOBItemNo(SerialNo, BOMNo, pItemNo, "")
  '  If Items.Count > 0 Then
  '    For Each tmp As SIS.PAK.pakPOBItems In Items
  '      With xlWS
  '        r += 1
  '        Dim c As Integer = 1
  '        .Cells(r, c).Value = tmp.ItemNo
  '        c += 1
  '        .Cells(r, c).Value = tmp.ElementID
  '        c += 1
  '        .Cells(r, c).Value = tmp.ItemCode
  '        c += 1
  '        .Cells(r, c).Value = tmp.ItemDescription
  '        If Not tmp.Bottom Then
  '          .Cells(r, c).Style.Font.Bold = True
  '          .Cells(r, c).Style.Font.Color.SetColor(tmp.GetColor)
  '        End If
  '        c += 1
  '        If tmp.UOMQuantity <> "" Then .Cells(r, c).Value = tmp.UOMQuantity & "-" & tmp.PAK_Units10_Description
  '        c += 1
  '        .Cells(r, c).Value = tmp.Quantity
  '        c += 1
  '        If tmp.UOMWeight <> "" Then .Cells(r, c).Value = tmp.UOMWeight & "-" & tmp.PAK_Units11_Description
  '        c += 1
  '        .Cells(r, c).Value = tmp.WeightPerUnit
  '        c += 1
  '        If POStatusID = pakPOStates.UnderSupplierVerification Then
  '          .Cells(r, c).Value = IIf(tmp.Accepted, "Y", "N")
  '          c += 1
  '        ElseIf POStatusID = pakPOStates.UnderISGECApproval Then
  '          .Cells(r, c).Value = IIf(tmp.Freezed, "Y", "N")
  '          c += 1
  '        End If
  '        .Cells(r, c).Value = tmp.SupplierRemarks
  '        c += 1
  '        .Cells(r, c).Value = tmp.ISGECRemarks
  '        c += 1
  '        If Not tmp.Bottom Then
  '          r = WriteBItemXL(xlWS, r, tmp.SerialNo, tmp.BOMNo, tmp.ItemNo)
  '        End If
  '      End With
  '    Next
  '  End If
  '  Return r
  'End Function

  Private Sub DownloadSASI(ByVal value As String)
    Dim SerialNo As Integer = value

    Dim tmpS As SIS.ATN.atnSABySI = SIS.ATN.atnSABySI.atnSABySIGetByID(SerialNo)
    Dim tmpDs As List(Of SIS.ATN.atnSABySIDays) = SIS.ATN.atnSABySIDays.atnSABySIDaysSelectList(0, 999, "", False, "", SerialNo)

    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue

    'If ItemNo <= 0 Then
    '  Dim message As String = New JavaScriptSerializer().Serialize("BOM Item ID is required for Template download.")
    '  Dim script As String = String.Format("alert({0});", message)
    '  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    '  Exit Sub
    'End If


    Dim TemplateName As String = "ATN_SA.xlsm"
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      '1.
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
      Dim r As Integer = 1
      Dim c As Integer = 1
      Dim cnt As Integer = 1
      With xlWS
        .Cells(1, 2).Value = tmpS.MonthID
        .Cells(2, 2).Value = tmpS.FinYear
        .Cells(3, 2).Value = tmpS.SerialNo
      End With

      r = 5
      c = 1
      For Each tmpD As SIS.ATN.atnSABySIDays In tmpDs
        With xlWS
          .Cells(r, 1).Value = tmpD.CardNo
          .Cells(r, 2).Value = tmpD.HRM_Employees2_EmployeeName
          .Cells(r, 3).Value = tmpD.FK_ATN_SABySIDays_CardNo.HRM_Divisions12_Description
          .Cells(r, 4).Value = tmpD.FK_ATN_SABySIDays_CardNo.HRM_Departments6_Description
          .Cells(r, 5).Value = tmpD.FK_ATN_SABySIDays_CardNo.HRM_Designations9_Description
          .Cells(r, 6).Value = tmpD.D22
          .Cells(r, 7).Value = tmpD.D23
          .Cells(r, 8).Value = tmpD.D24
          .Cells(r, 9).Value = tmpD.D25
          .Cells(r, 10).Value = tmpD.D26
          .Cells(r, 11).Value = tmpD.D27
          .Cells(r, 12).Value = tmpD.D28
          .Cells(r, 13).Value = tmpD.D29
          .Cells(r, 14).Value = tmpD.D30
          .Cells(r, 15).Value = tmpD.D31
          .Cells(r, 16).Value = tmpD.D01
          .Cells(r, 17).Value = tmpD.D02
          .Cells(r, 18).Value = tmpD.D03
          .Cells(r, 19).Value = tmpD.D04
          .Cells(r, 20).Value = tmpD.D05
          .Cells(r, 21).Value = tmpD.D06
          .Cells(r, 22).Value = tmpD.D07
          .Cells(r, 23).Value = tmpD.D08
          .Cells(r, 24).Value = tmpD.D09
          .Cells(r, 25).Value = tmpD.D10
          .Cells(r, 26).Value = tmpD.D11
          .Cells(r, 27).Value = tmpD.D12
          .Cells(r, 28).Value = tmpD.D13
          .Cells(r, 29).Value = tmpD.D14
          .Cells(r, 30).Value = tmpD.D15
          .Cells(r, 31).Value = tmpD.D16
          .Cells(r, 32).Value = tmpD.D17
          .Cells(r, 33).Value = tmpD.D18
          .Cells(r, 34).Value = tmpD.D19
          .Cells(r, 35).Value = tmpD.D20
          .Cells(r, 36).Value = tmpD.D21
          .Cells(r, 37).Value = tmpD.Remarks
        End With
        r += 1
      Next

      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & "ATN_" & tmpS.FinYear & "_" & tmpS.MonthID.PadLeft(2, "0") & ".xlsm")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

#End Region



End Class
