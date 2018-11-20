Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class newHrmEmployees
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
    Public Shared Function UZ_newHrmEmployeesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal C_OfficeID As Int32, ByVal C_DepartmentID As String, ByVal C_DesignationID As Int32, ByVal CategoryID As Int32) As List(Of SIS.ATN.newHrmEmployees)
      Dim Results As List(Of SIS.ATN.newHrmEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "EmployeeName"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatn_LG_newHrmEmployeesSelectListSearch"
            Cmd.CommandText = "spnewHrmEmployeesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatn_LG_newHrmEmployeesSelectListFilteres"
            Cmd.CommandText = "spnewHrmEmployeesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_OfficeID",SqlDbType.Int,10, IIf(C_OfficeID = Nothing, 0,C_OfficeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DepartmentID",SqlDbType.NVarChar,6, IIf(C_DepartmentID Is Nothing, String.Empty,C_DepartmentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DesignationID",SqlDbType.Int,10, IIf(C_DesignationID = Nothing, 0,C_DesignationID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryID",SqlDbType.Int,10, IIf(CategoryID = Nothing, 0,CategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.newHrmEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.newHrmEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_newHrmEmployeesInsert(ByVal Record As SIS.ATN.newHrmEmployees) As SIS.ATN.newHrmEmployees
      Dim _Result As SIS.ATN.newHrmEmployees = newHrmEmployeesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_newHrmEmployeesUpdate(ByVal Record As SIS.ATN.newHrmEmployees) As SIS.ATN.newHrmEmployees
      Dim _Result As SIS.ATN.newHrmEmployees = newHrmEmployeesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_newHrmEmployeesDelete(ByVal Record As SIS.ATN.newHrmEmployees) As Integer
      Dim _Result as Integer = newHrmEmployeesDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_CardNo"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeName"), TextBox).Text = ""
        CType(.FindControl("F_C_DivisionID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_OfficeID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_DepartmentID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_DesignationID"),Object).SelectedValue = ""
        CType(.FindControl("F_ActiveState"), CheckBox).Checked = False
        CType(.FindControl("F_CategoryID"),Object).SelectedValue = ""
        CType(.FindControl("F_Salute"), TextBox).Text = ""
        CType(.FindControl("F_Gender"), TextBox).Text = ""
        CType(.FindControl("F_C_DateOfJoining"), TextBox).Text = ""
        CType(.FindControl("F_C_ProjectSiteID"), TextBox).Text = ""
        CType(.FindControl("F_C_ProjectSiteID_Display"), Label).Text = ""
        CType(.FindControl("F_C_BasicSalary"), TextBox).Text = 0
        CType(.FindControl("F_C_StatusID"), DropDownList).SelectedValue = ""
        CType(.FindControl("F_Resigned"), CheckBox).Checked = False
        CType(.FindControl("F_C_ResignedOn"), TextBox).Text = ""
        CType(.FindControl("F_C_DateOfReleaving"), TextBox).Text = ""
        CType(.FindControl("F_C_ResignedRemark"), TextBox).Text = ""
        CType(.FindControl("F_Confirmed"), CheckBox).Checked = False
        CType(.FindControl("F_C_ConfirmedOn"), TextBox).Text = ""
        CType(.FindControl("F_C_ConfirmationRemark"), TextBox).Text = ""
        CType(.FindControl("F_DateOfBirth"), TextBox).Text = ""
        CType(.FindControl("F_FatherName"), TextBox).Text = ""
        CType(.FindControl("F_ContactNumbers"), TextBox).Text = ""
        CType(.FindControl("F_OfficeFileNumber"), TextBox).Text = ""
        CType(.FindControl("F_PFNumber"), TextBox).Text = ""
        CType(.FindControl("F_PAN"), TextBox).Text = ""
        CType(.FindControl("F_ModifiedBy"), TextBox).Text = ""
        CType(.FindControl("F_Freezed"), CheckBox).Checked = False
        CType(.FindControl("F_ESINumber"), TextBox).Text = ""
        CType(.FindControl("F_VerifierID"), TextBox).Text = ""
        CType(.FindControl("F_VerifierID_Display"), Label).Text = ""
        CType(.FindControl("F_VerificationRequired"), CheckBox).Checked = False
        CType(.FindControl("F_C_CompanyID"),Object).SelectedValue = ""
        CType(.FindControl("F_ApprovalRequired"), CheckBox).Checked = False
        CType(.FindControl("F_ModifiedOn"), TextBox).Text = ""
        CType(.FindControl("F_EMailID"), TextBox).Text = ""
        CType(.FindControl("F_ApproverID"), TextBox).Text = ""
        CType(.FindControl("F_ApproverID_Display"), Label).Text = ""
        CType(.FindControl("F_Contractual"), CheckBox).Checked = False
        CType(.FindControl("F_SiteAllowanceApprover"), TextBox).Text = ""
        CType(.FindControl("F_SiteAllowanceApprover_Display"), Label).Text = ""
        CType(.FindControl("F_TASelfApproval"), CheckBox).Checked = False
        CType(.FindControl("F_NonTechnical"), CheckBox).Checked = False
        CType(.FindControl("F_TAVerifier"), TextBox).Text = ""
        CType(.FindControl("F_TAVerifier_Display"), Label).Text = ""
        CType(.FindControl("F_TASanctioningAuthority"), TextBox).Text = ""
        CType(.FindControl("F_TASanctioningAuthority_Display"), Label).Text = ""
        CType(.FindControl("F_TAApprover"), TextBox).Text = ""
        CType(.FindControl("F_TAApprover_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
