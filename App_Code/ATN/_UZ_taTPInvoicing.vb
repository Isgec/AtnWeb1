Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taTPInvoicing
    Private Shared _TotalAmount As Decimal = 0
    Public Shared Property TotalAmount As Decimal
      Get
        Return _TotalAmount
      End Get
      Set(value As Decimal)
        If Convert.IsDBNull(value) Then
          _TotalAmount = 0
        Else
          _TotalAmount = value
        End If
      End Set
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_taTPInvoicingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelDate As DateTime, ByVal BookingDate As DateTime, ByVal EmployeeCode As String) As List(Of SIS.TA.taTPInvoicing)
      Dim Results As List(Of SIS.TA.taTPInvoicing) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "InvoiceNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_TPInvoicingSelectListSearch"
            Cmd.CommandText = "sptaTPInvoicingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_TPInvoicingSelectListFilteres"
            Cmd.CommandText = "sptaTPInvoicingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeCode", SqlDbType.NVarChar, 8, IIf(EmployeeCode Is Nothing, String.Empty, EmployeeCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelDate", SqlDbType.NVarChar, 20, IIf(TravelDate = Nothing, String.Empty, TravelDate))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BookingDate", SqlDbType.NVarChar, 20, IIf(BookingDate = Nothing, String.Empty, BookingDate))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal)
          Cmd.Parameters("@TotalAmount").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taTPInvoicing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taTPInvoicing(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
          _TotalAmount = Cmd.Parameters("@TotalAmount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taTPInvoicingInsert(ByVal Record As SIS.TA.taTPInvoicing) As SIS.TA.taTPInvoicing
      Dim _Result As SIS.TA.taTPInvoicing = taTPInvoicingInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taTPInvoicingUpdate(ByVal Record As SIS.TA.taTPInvoicing) As SIS.TA.taTPInvoicing
      Dim _Result As SIS.TA.taTPInvoicing = taTPInvoicingUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taTPInvoicingDelete(ByVal Record As SIS.TA.taTPInvoicing) As Integer
      Dim _Result As Integer = taTPInvoicingDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_InvoiceNo"), TextBox).Text = ""
          CType(.FindControl("F_InvoiceDate"), TextBox).Text = ""
          CType(.FindControl("F_PAXName"), TextBox).Text = ""
          CType(.FindControl("F_Sector"), TextBox).Text = ""
          CType(.FindControl("F_BookingDate"), TextBox).Text = ""
          CType(.FindControl("F_TravelDate"), TextBox).Text = ""
          CType(.FindControl("F_AirlinesName"), TextBox).Text = ""
          CType(.FindControl("F_TicketNo"), TextBox).Text = ""
          CType(.FindControl("F_NetAmount"), TextBox).Text = 0
          CType(.FindControl("F_EmployeeCode"), TextBox).Text = ""
          CType(.FindControl("F_EmployeeCode_Display"), Label).Text = ""
          CType(.FindControl("F_Sanction"), TextBox).Text = ""
          CType(.FindControl("F_AirlineType"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
