Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnEmployeeConfiguration
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
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal CardNo As String, ByVal SendVerifyMail As Boolean, ByVal SendApproveMail As Boolean, ByVal AttendanceThroughExcel As Boolean) As SIS.ATN.atnEmployeeConfiguration
      Dim Results As SIS.ATN.atnEmployeeConfiguration = atnEmployeeConfigurationGetByID(CardNo)
      With Results
        .SendApproveMail = SendApproveMail
        .SendVerifyMail = SendVerifyMail
        .AttendanceThroughExcel = AttendanceThroughExcel
      End With
      Results = SIS.ATN.atnEmployeeConfiguration.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_atnEmployeeConfigurationInsert(ByVal Record As SIS.ATN.atnEmployeeConfiguration) As SIS.ATN.atnEmployeeConfiguration
      Dim _Result As SIS.ATN.atnEmployeeConfiguration = atnEmployeeConfigurationInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_atnEmployeeConfigurationUpdate(ByVal Record As SIS.ATN.atnEmployeeConfiguration) As SIS.ATN.atnEmployeeConfiguration
      Dim _Result As SIS.ATN.atnEmployeeConfiguration = atnEmployeeConfigurationUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_CardNo"), TextBox).Text = ""
        CType(.FindControl("F_CardNo_Display"), Label).Text = ""
        CType(.FindControl("F_SendVerifyMail"), CheckBox).Checked = False
        CType(.FindControl("F_SendApproveMail"), CheckBox).Checked = False
        CType(.FindControl("F_AttendanceThroughExcel"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
