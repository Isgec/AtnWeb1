Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class WFHConfig
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
    Public Function GetDeleteable() As Boolean
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
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal SerialNo As Int32, ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal OpenedFor As String, ByVal Active As Boolean, ByVal AllowProcessed As Boolean) As SIS.ATN.WFHConfig
      Dim Results As SIS.ATN.WFHConfig = WFHConfigGetByID(SerialNo)
      With Results
        .SerialNo = SerialNo
        .FromDate = FromDate
        .ToDate = ToDate
        .Active = Active
        .AllowProcessed = AllowProcessed
        .OpenedFor = OpenedFor
      End With
      Results = SIS.ATN.WFHConfig.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_WFHConfigInsert(ByVal Record As SIS.ATN.WFHConfig) As SIS.ATN.WFHConfig
      Dim _Result As SIS.ATN.WFHConfig = WFHConfigInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_WFHConfigUpdate(ByVal Record As SIS.ATN.WFHConfig) As SIS.ATN.WFHConfig
      Dim _Result As SIS.ATN.WFHConfig = WFHConfigUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_WFHConfigDelete(ByVal Record As SIS.ATN.WFHConfig) As Integer
      Dim _Result as Integer = WFHConfigDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_FromDate"), TextBox).Text = ""
        CType(.FindControl("F_ToDate"), TextBox).Text = ""
        CType(.FindControl("F_OpenedFor"), TextBox).Text = ""
        CType(.FindControl("F_Active"), CheckBox).Checked = False
        CType(.FindControl("F_AllowProcessed"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
