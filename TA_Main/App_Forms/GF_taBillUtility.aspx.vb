Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_taTravelUtility
  Inherits SIS.SYS.GridBase
  Protected Sub TBLatnEmployeeConfiguration_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLatnEmployeeConfiguration.Init
    SetToolBar = TBLatnEmployeeConfiguration
  End Sub
  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
    Dim CardNo As String = ""
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
              wsD = xlP.Workbook.Worksheets("Sheet1")
            Catch ex As Exception
              wsD = Nothing
            End Try
            '1. Process Document
            If wsD Is Nothing Then
              errMsg.Text = "XL File does not have Sheet1, Invalid MS-EXCEL file."
              xlP.Dispose()
              Exit Sub
              '*******
            End If
            '            Invoice DATE
            'INVOICE NO.
            'PAX NAME
            '            SECTOR()
            'Booking Date
            'TRAVEL DATE
            '            Airlines(Name)
            'TKT No.
            ' Net Amount 
            '            EMP(CODE)
            '            Sanction()
            '            Airline(Type)

            Dim InvoiceNo As String = ""
            For I As Integer = 2 To 9000
              InvoiceNo = wsD.Cells(I, 2).Text
              If InvoiceNo = String.Empty Then Exit For
              Dim Found As Boolean = True
              Dim Inv As SIS.TA.taTPInvoicing = Nothing
              Inv = SIS.TA.taTPInvoicing.taTPInvoicingGetByID(InvoiceNo)
              If Inv Is Nothing Then
                Inv = New SIS.TA.taTPInvoicing
                Found = False
              End If
              With Inv
                Try
                  .InvoiceDate = wsD.Cells(I, 1).Text
                Catch ex As Exception
                End Try
                Try
                  .InvoiceNo = wsD.Cells(I, 2).Text
                Catch ex As Exception
                End Try
                Try
                  .PAXName = wsD.Cells(I, 3).Text
                Catch ex As Exception
                End Try
                Try
                  .Sector = wsD.Cells(I, 4).Text
                Catch ex As Exception
                End Try
                Try
                  .BookingDate = wsD.Cells(I, 5).Text
                Catch ex As Exception
                End Try
                Try
                  .TravelDate = wsD.Cells(I, 6).Text
                Catch ex As Exception
                End Try
                Try
                  .AirlinesName = wsD.Cells(I, 7).Text
                Catch ex As Exception
                End Try
                Try
                  .TicketNo = wsD.Cells(I, 8).Text
                Catch ex As Exception
                End Try
                If wsD.Cells(I, 9).Text <> String.Empty Then
                  Try
                    .NetAmount = wsD.Cells(I, 9).Text
                  Catch ex As Exception
                  End Try
                End If
                If wsD.Cells(I, 10).Text <> String.Empty Then
                  .EmployeeCode = Right("0000" & wsD.Cells(I, 10).Text.Trim, 4)
                  CardNo = .EmployeeCode
                End If
                Try
                  .Sanction = wsD.Cells(I, 11).Text
                Catch ex As Exception
                End Try
                Try
                  .AirlineType = wsD.Cells(I, 12).Text
                Catch ex As Exception
                End Try
              End With
              Try
                If Found Then
                  SIS.TA.taTPInvoicing.UpdateData(Inv)
                  wsD.Cells(I, 13).Value = "updated"
                Else
                  SIS.TA.taTPInvoicing.InsertData(Inv)
                  wsD.Cells(I, 13).Value = "Inserted"
                End If
              Catch ex As Exception
                wsD.Cells(I, 13).Value = ex.Message.ToString
              End Try
            Next 'Item Line
            xlP.Save()
            xlP.Dispose()
          End Using
          Dim FileNameForUser As String = F_FileUpload.FileName
          If IO.File.Exists(tmpFile) Then
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser & """")
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
            Response.WriteFile(tmpFile)
          Response.End()
        End If
        End If
      End With
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString() & " : " & CardNo)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
over:
  End Sub

  Protected Sub cmdDownload_Click(sender As Object, e As System.EventArgs) Handles cmdDownload.Click
    Dim tmpFile As String = Server.MapPath("~/App_Templates/Travel_Invoices_Template.xlsx")
    If IO.File.Exists(tmpFile) Then
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & tmpFile & """")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(tmpFile)
      Response.WriteFile(tmpFile)
      Response.End()
    End If

  End Sub
End Class

