Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  Public Class retVal
    Public Property isErr As Boolean = False
    Public Property msg As String = ""
  End Class

  Partial Public Class atnApproverChangeRequest
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
      Dim mRet As Boolean = False
      If Not Requested Then mRet = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      If Not Requested Then mRet = True
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
        Dim mRet As Boolean = False
        If Not Requested Then mRet = True
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
    Public Shared Function InitiateWF(ByVal RequestID As Int32) As SIS.ATN.atnApproverChangeRequest
      Dim x As SIS.ATN.retVal = SIS.ATN.atnApproverChangeRequest.ValidateRequest(RequestID, True)
      If x.isErr Then
        Throw New Exception(x.msg)
      End If
      Dim Results As SIS.ATN.atnApproverChangeRequest = atnApproverChangeRequestGetByID(RequestID)
      Results.Requested = True
      Results.RequestedOn = Now
      SIS.ATN.atnApproverChangeRequest.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function ValidateRequest(ByVal RecordID As Integer, Optional OnlyValidate As Boolean = True) As SIS.ATN.retVal
      Dim _Result As Integer = 0
      Dim _MsgStr As String = ""
      Dim mRet As New SIS.ATN.retVal
      Dim oReq As SIS.ATN.atnApproverChangeRequest = SIS.ATN.atnApproverChangeRequest.atnApproverChangeRequestGetByID(RecordID)
      Dim oEmp As SIS.ATN.newHrmEmployees = SIS.ATN.newHrmEmployees.newHrmEmployeesGetByID(oReq.UserID)
      Dim oAplv As List(Of SIS.ATN.atnApplHeader) = SIS.ATN.atnApplHeader.SelectApplicationsUnderVerification(oReq.UserID)
      If oAplv.Count > 0 Then
        If oReq.VerifierID = "" Then
          mRet.isErr = True
          mRet.msg = "There are leave application(s) under verification, can not remove verifier"
          Return mRet
        End If
      End If
      Dim oApla As List(Of SIS.ATN.atnApplHeader) = SIS.ATN.atnApplHeader.SelectApplicationsToBeApproved(oReq.UserID)
      If oApla.Count > 0 Then
        If oReq.ApproverID = "" Then
          mRet.isErr = True
          mRet.msg = "There are leave application(s) under approval, can not remove approver"
          Return mRet
        End If
      End If
      Dim oTAv As List(Of SIS.ATN.atnTABills) = SIS.ATN.atnTABills.atnTABillList(oReq.UserID, 10)
      If oTAv.Count > 0 Then
        If oReq.TAVerifierID = "" Then
          mRet.isErr = True
          mRet.msg = "There are TA Bill(s) under verification, can not remove verifier"
          Return mRet
        End If
      End If
      Dim oTAa As List(Of SIS.ATN.atnTABills) = SIS.ATN.atnTABills.atnTABillList(oReq.UserID, 6)
      If oTAa.Count > 0 Then
        If oReq.TAApproverID = "" Then
          mRet.isErr = True
          mRet.msg = "There are TA Bill(s) under approval, can not remove approver"
          Return mRet
        End If
      End If
      Dim oTAs As List(Of SIS.ATN.atnTABills) = SIS.ATN.atnTABills.atnTABillList(oReq.UserID, 8)
      If oTAs.Count > 0 Then
        If oReq.TASA = "" Then
          mRet.isErr = True
          mRet.msg = "There are TA Bill(s) under special sanction, can not remove sanctioning authority"
          Return mRet
        End If
      End If
      If OnlyValidate Then
        Return mRet
      End If
      '==========
      'Now Update
      '==========
      Try
        '1. Homework oReq
        If oReq.VerifierID = "" Then oReq.VerificationRequired = False Else oReq.VerificationRequired = True
        If oReq.ApproverID = "" Then oReq.ApprovalRequired = False Else oReq.ApprovalRequired = True
        '2. Update Employee Master
        With oEmp
          .VerificationRequired = oReq.VerificationRequired
          .VerifierID = oReq.VerifierID
          .ApprovalRequired = oReq.ApprovalRequired
          .ApproverID = oReq.ApproverID
          .TAVerifier = oReq.TAVerifierID
          .TAApprover = oReq.TAApproverID
          .TASanctioningAuthority = oReq.TASA
        End With
        oEmp = SIS.ATN.newHrmEmployees.UpdateData(oEmp)
        '3. Update Transactions
        '3.1 Apl Verifier
        For Each apl As SIS.ATN.atnApplHeader In oAplv
          apl.VerificationRequired = oReq.VerificationRequired
          apl.VerifiedBy = oReq.VerifierID
          apl.ApprovalRequired = oReq.ApprovalRequired
          apl.ApprovedBy = oReq.ApproverID
          SIS.ATN.atnApplHeader.Update(apl)
        Next
        '3.2 Apl approver
        For Each apl As SIS.ATN.atnApplHeader In oApla
          apl.ApprovalRequired = oReq.ApprovalRequired
          apl.ApprovedBy = oReq.ApproverID
          SIS.ATN.atnApplHeader.Update(apl)
        Next
        '3.3.a TA Verifier
        For Each ta As SIS.ATN.atnTABills In oTAv
          ta.ApprovedBy = oReq.TAVerifierID
          ta.ApprovedByCC = oReq.TAApproverID
          ta.ApprovedBySA = oReq.TASA
          SIS.ATN.atnTABills.UpdateData(ta)
        Next
        '3.3.b Update TA Bills which are free
        oTAv = SIS.ATN.atnTABills.atnTABillList(oReq.UserID, 1) ' 1=>Free TA Bills
        For Each ta As SIS.ATN.atnTABills In oTAv
          ta.ApprovedBy = oReq.TAVerifierID
          ta.ApprovedByCC = oReq.TAApproverID
          ta.ApprovedBySA = oReq.TASA
          SIS.ATN.atnTABills.UpdateData(ta)
        Next
        '3.4 TA approver
        For Each ta As SIS.ATN.atnTABills In oTAv
          ta.ApprovedByCC = oReq.TAApproverID
          ta.ApprovedBySA = oReq.TASA
          SIS.ATN.atnTABills.UpdateData(ta)
        Next
        '3.5 TA SA
        For Each ta As SIS.ATN.atnTABills In oTAv
          ta.ApprovedBySA = oReq.TASA
          SIS.ATN.atnTABills.UpdateData(ta)
        Next
      Catch ex As Exception
        mRet.isErr = True
        mRet.msg = ex.Message
      End Try
      Return mRet
    End Function

    Public Shared Function UZ_atnApproverChangeRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnApproverChangeRequest)
      Dim Results As List(Of SIS.ATN.atnApproverChangeRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatn_LG_ApproverChangeRequestSelectListSearch"
            Cmd.CommandText = "spatnApproverChangeRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatn_LG_ApproverChangeRequestSelectListFilteres"
            Cmd.CommandText = "spatnApproverChangeRequestSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnApproverChangeRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnApproverChangeRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_RequestID"), TextBox).Text = ""
          CType(.FindControl("F_VerifierID"), TextBox).Text = ""
          CType(.FindControl("F_VerifierID_Display"), Label).Text = ""
          CType(.FindControl("F_ApproverID"), TextBox).Text = ""
          CType(.FindControl("F_ApproverID_Display"), Label).Text = ""
          CType(.FindControl("F_TAVerifierID"), TextBox).Text = ""
          CType(.FindControl("F_TAVerifierID_Display"), Label).Text = ""
          CType(.FindControl("F_TAApproverID"), TextBox).Text = ""
          CType(.FindControl("F_TAApproverID_Display"), Label).Text = ""
          CType(.FindControl("F_TASA"), TextBox).Text = ""
          CType(.FindControl("F_TASA_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
