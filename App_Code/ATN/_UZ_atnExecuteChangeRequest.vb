Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
	Partial Public Class atnExecuteChangeRequest
		Public Property EnableEdit() As Boolean
			Get
				If Not _Executed Then
					Return True
				End If
				Return False
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		Public Shared Function UZ_Update(ByVal RecordID As Integer) As String
			Dim _Result As Integer = 0
			Dim _MsgStr As String = ""
			Dim oReq As SIS.ATN.atnExecuteChangeRequest = SIS.ATN.atnExecuteChangeRequest.GetByID(RecordID)
			If Not oReq Is Nothing Then
				Dim oEmp As SIS.ATN.atnEmployees = SIS.ATN.atnEmployees.GetByID(oReq.UserID)
				'Update Request Status
				If oReq.VerifierID = "" Then
					oReq.VerificationRequired = False
				End If
				If oReq.ApproverID = "" Then
					oReq.ApprovalRequired = False
				End If
				'*-*-*-*-*-*-*-*-*-*-*-*
				'Check for Verification
				'*-*-*-*-*-*-*-*-*-*-*-*
				'Verifier Introduced
        If oEmp.VerifierID = "" And oReq.VerifierID <> "" Then
          oEmp.VerificationRequired = oReq.VerificationRequired
          oEmp.VerifierID = oReq.VerifierID
          SIS.ATN.atnEmployees.Update(oEmp)
        ElseIf oEmp.VerifierID <> "" And oReq.VerifierID = "" Then
          'VerifierID Removed
          'Do not allow if there are pending Applications
          Dim oApls As List(Of SIS.ATN.atnApplHeader) = SIS.ATN.atnApplHeader.SelectApplicationsUnderVerification(oReq.UserID)
          If oApls.Count <= 0 Then
            oEmp.VerificationRequired = oReq.VerificationRequired
            oEmp.VerifierID = oReq.VerifierID
            SIS.ATN.atnEmployees.Update(oEmp)
          Else
            _Result = 1
            _MsgStr = _Result & "|" & "<b>Error: Request ID:" & oReq.RequestID.ToString & "</b> There are pending application(s) under verification." & vbCrLf & "Can not remove verifier."
          End If
        ElseIf oEmp.VerifierID <> oReq.VerifierID Then
          'Verifier Changed
          'Update Applications
          Dim oApls As List(Of SIS.ATN.atnApplHeader) = SIS.ATN.atnApplHeader.SelectApplicationsUnderVerification(oReq.UserID)
          For Each oApl As SIS.ATN.atnApplHeader In oApls
            oApl.VerifiedBy = oReq.VerifierID
            SIS.ATN.atnApplHeader.Update(oApl)
          Next
          'Update Emp Profile
          oEmp.VerifierID = oReq.VerifierID
          SIS.ATN.atnEmployees.Update(oEmp)
        End If
        '*-*-*-*-*-*-*-*-*-*-*-*-*-
				'Check for Approval
				'*-*-*-*-*-*-*-*-*-*-*
				'Approver Introduced
        If oEmp.ApproverID = "" And oReq.ApproverID <> "" Then
          oEmp.ApprovalRequired = oReq.ApprovalRequired
          oEmp.ApproverID = oReq.ApproverID
          SIS.ATN.atnEmployees.Update(oEmp)
        ElseIf oEmp.ApproverID <> "" And oReq.ApproverID = "" Then
          'do not allow if there are peding Applications under Approval
          Dim Allow As Boolean = True
          Dim oApls As List(Of SIS.ATN.atnApplHeader) = SIS.ATN.atnApplHeader.SelectApplicationsToBeApproved(oReq.UserID)
          For Each oApl As SIS.ATN.atnApplHeader In oApls
            If oApl.ApplStatusID = 3 Then 'under appl
              Allow = False
              Exit For
            End If
          Next
          If Allow Then
            For Each oApl As SIS.ATN.atnApplHeader In oApls
              oApl.ApprovalRequired = oReq.ApprovalRequired
              oApl.ApprovedBy = oReq.ApproverID
              SIS.ATN.atnApplHeader.Update(oApl)
            Next
            oEmp.ApprovalRequired = oReq.ApprovalRequired
            oEmp.ApproverID = oReq.ApproverID
            SIS.ATN.atnEmployees.Update(oEmp)
          Else
            _Result = _Result + 2
            If _Result > 2 Then
              _MsgStr = _Result & "|" & _MsgStr.Split("|".ToCharArray)(1) & vbCrLf & "There are pending application(s) under approval." & vbCrLf & "Can not remove approver."
            Else
              _MsgStr = _Result & "|" & "<b>Error: Request ID:" & oReq.RequestID.ToString & "</b> There are pending application(s) under approval." & vbCrLf & "Can not remove approver."
            End If
          End If
        ElseIf oEmp.ApproverID <> oReq.ApproverID Then
          Dim oApls As List(Of SIS.ATN.atnApplHeader) = SIS.ATN.atnApplHeader.SelectApplicationsToBeApproved(oReq.UserID)
          For Each oApl As SIS.ATN.atnApplHeader In oApls
            oApl.ApprovalRequired = oReq.ApprovalRequired
            oApl.ApprovedBy = oReq.ApproverID
            SIS.ATN.atnApplHeader.Update(oApl)
          Next
          oEmp.ApprovalRequired = oReq.ApprovalRequired
          oEmp.ApproverID = oReq.ApproverID
          SIS.ATN.atnEmployees.Update(oEmp)
        End If
        If _Result = 0 Then
          'Update Request
          oReq.Executed = True
          _Result = Update(oReq)
        End If
			End If
			If _MsgStr = "" Then
				_MsgStr = "0|"
			End If
			Return _MsgStr
		End Function
		Public Shared Function UZ_Delete(ByVal RecordID As Integer) As Int32
			Dim _Result As Integer = 0
      _Result = Delete(RecordID)
      Return _Result
		End Function
	End Class
End Namespace
