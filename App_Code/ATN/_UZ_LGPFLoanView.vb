Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class LGPFLoanView
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_CardNo"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeName"), TextBox).Text = ""
        CType(.FindControl("F_InstallmentAmount"), TextBox).Text = 0
        CType(.FindControl("F_PaidPrincipal"), TextBox).Text = 0
        CType(.FindControl("F_PaidInterest"), TextBox).Text = 0
        CType(.FindControl("F_BalancePrincipal"), TextBox).Text = 0
        CType(.FindControl("F_PayCode"), TextBox).Text = ""
        CType(.FindControl("F_ForMonth"), TextBox).Text = ""
        CType(.FindControl("F_ForYear"), TextBox).Text = ""
        CType(.FindControl("F_Processed"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
