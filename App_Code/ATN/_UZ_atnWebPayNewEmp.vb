Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnWebPayNewEmp
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
    Public Shared Function InitiateWF(ByVal CardNo As String) As SIS.ATN.atnWebPayNewEmp
      Dim Results As SIS.ATN.atnWebPayNewEmp = atnWebPayNewEmpGetByID(CardNo)
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_CardNo"), TextBox).Text = ""
        CType(.FindControl("F_Salute"), TextBox).Text = ""
        CType(.FindControl("F_Gender"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeName"), TextBox).Text = ""
        CType(.FindControl("F_FatherName"), TextBox).Text = ""
        CType(.FindControl("F_CostCompany"), TextBox).Text = ""
        CType(.FindControl("F_Unit"), TextBox).Text = ""
        CType(.FindControl("F_Category"), TextBox).Text = ""
        CType(.FindControl("F_DesignationCode"), TextBox).Text = ""
        CType(.FindControl("F_Designation"), TextBox).Text = ""
        CType(.FindControl("F_DOB"), TextBox).Text = ""
        CType(.FindControl("F_DOJ"), TextBox).Text = ""
        CType(.FindControl("F_DOL"), TextBox).Text = ""
        CType(.FindControl("F_EMail"), TextBox).Text = ""
        CType(.FindControl("F_PFNO"), TextBox).Text = ""
        CType(.FindControl("F_PAN"), TextBox).Text = ""
        CType(.FindControl("F_Department"), TextBox).Text = ""
        CType(.FindControl("F_Finalized"), TextBox).Text = ""
        CType(.FindControl("F_PensionNo"), TextBox).Text = ""
        CType(.FindControl("F_SeatingLocation"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
