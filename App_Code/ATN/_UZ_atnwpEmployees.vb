Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnwpEmployees
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
    Public Shared Function InitiateWF(ByVal CardNo As String) As SIS.ATN.atnwpEmployees
      Dim Results As SIS.ATN.atnwpEmployees = atnwpEmployeesGetByID(CardNo)
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal CardNo As String) As SIS.ATN.atnwpEmployees
      Dim Results As SIS.ATN.atnwpEmployees = atnwpEmployeesGetByID(CardNo)
      Return Results
    End Function
    Public Shared Function UZ_atnwpEmployeesUpdate(ByVal Record As SIS.ATN.atnwpEmployees) As SIS.ATN.atnwpEmployees
      Dim _Result As SIS.ATN.atnwpEmployees = atnwpEmployeesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_CardNo"), TextBox).Text = ""
        CType(.FindControl("F_Salute"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeName"), TextBox).Text = ""
        CType(.FindControl("F_AliasName"), TextBox).Text = ""
        CType(.FindControl("F_Gender"), TextBox).Text = ""
        CType(.FindControl("F_C_DateOfJoining"), TextBox).Text = ""
        CType(.FindControl("F_C_CompanyID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_DivisionID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_OfficeID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_DepartmentID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_ProjectSiteID"), TextBox).Text = ""
        CType(.FindControl("F_C_ProjectSiteID_Display"), Label).Text = ""
        CType(.FindControl("F_C_DesignationID"), TextBox).Text = ""
        CType(.FindControl("F_C_DesignationID_Display"), Label).Text = ""
        CType(.FindControl("F_ActiveState"), CheckBox).Checked = False
        CType(.FindControl("F_Resigned"), CheckBox).Checked = False
        CType(.FindControl("F_C_ResignedOn"), TextBox).Text = ""
        CType(.FindControl("F_C_DateOfReleaving"), TextBox).Text = ""
        CType(.FindControl("F_C_ResignedRemark"), TextBox).Text = ""
        CType(.FindControl("F_DateOfBirth"), TextBox).Text = ""
        CType(.FindControl("F_FatherName"), TextBox).Text = ""
        CType(.FindControl("F_ContactNumbers"), TextBox).Text = ""
        CType(.FindControl("F_PFNumber"), TextBox).Text = ""
        CType(.FindControl("F_ESINumber"), TextBox).Text = ""
        CType(.FindControl("F_PAN"), TextBox).Text = ""
        CType(.FindControl("F_EMailID"), TextBox).Text = ""
        CType(.FindControl("F_Freezed"), CheckBox).Checked = False
        CType(.FindControl("F_ModifiedBy"), TextBox).Text = ""
        CType(.FindControl("F_ModifiedOn"), TextBox).Text = ""
        CType(.FindControl("F_ModifiedEvent"), TextBox).Text = ""
        CType(.FindControl("F_VerificationRequired"), CheckBox).Checked = False
        CType(.FindControl("F_VerifierID"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalRequired"), CheckBox).Checked = False
        CType(.FindControl("F_ApproverID"), TextBox).Text = ""
        CType(.FindControl("F_Contractual"), CheckBox).Checked = False
        CType(.FindControl("F_CategoryID"),Object).SelectedValue = ""
        CType(.FindControl("F_NonTechnical"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
