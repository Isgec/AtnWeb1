Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Partial Public Class atnNewApplHeader
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
    Public Shared Function GetbyApplication(ByVal Application As String) As SIS.ATN.atnNewApplHeader
      Dim Results As SIS.ATN.atnNewApplHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatn_LG_NewApplHeaderSelectByApplication"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Application", SqlDbType.NVarChar, Application.Length, Application)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnNewApplHeader(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_LeaveApplID"), TextBox).Text = ""
          CType(.FindControl("F_CardNo"), TextBox).Text = ""
          CType(.FindControl("F_Approved"), TextBox).Text = ""
          CType(.FindControl("F_Rejected"), TextBox).Text = ""
          CType(.FindControl("F_Application"), TextBox).Text = ""
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
          CType(.FindControl("F_ApplStatusID"), TextBox).Text = 0
          CType(.FindControl("F_AppliedOn"), TextBox).Text = ""
          CType(.FindControl("F_VerificationOn"), TextBox).Text = ""
          CType(.FindControl("F_ApprovalOn"), TextBox).Text = ""
          CType(.FindControl("F_SanctionOn"), TextBox).Text = ""
          CType(.FindControl("F_PostedOn"), TextBox).Text = ""
          CType(.FindControl("F_VerificationRequired"), CheckBox).Checked = False
          CType(.FindControl("F_ApprovalRequired"), CheckBox).Checked = False
          CType(.FindControl("F_SanctionRequired"), CheckBox).Checked = False
          CType(.FindControl("F_VerifiedBy"), TextBox).Text = ""
          CType(.FindControl("F_ApprovedBy"), TextBox).Text = ""
          CType(.FindControl("F_SanctionedBy"), TextBox).Text = ""
          CType(.FindControl("F_PostedBy"), TextBox).Text = ""
          CType(.FindControl("F_VerificationRemark"), TextBox).Text = ""
          CType(.FindControl("F_ApprovalRemark"), TextBox).Text = ""
          CType(.FindControl("F_SanctionRemark"), TextBox).Text = ""
          CType(.FindControl("F_PostingRemark"), TextBox).Text = ""
          CType(.FindControl("F_AdvanceApplication"), CheckBox).Checked = False
          CType(.FindControl("F_ExecutionState"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
