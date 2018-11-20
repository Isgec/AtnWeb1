Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnMannualCorrectionHistory
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32
    Private _AttenID As String
    Private _AttenDate As String
    Private _CardNo As String
    Private _Punch1Time As String
    Private _Punch2Time As String
    Private _PunchStatusID As String
    Private _MannuallyCorrectedOn As String
    Private _MannuallyCorrectedBy As String
    Private _NewPunch1Time As String
    Private _NewPunch2Time As String
    Private _NewPunchStatusID As String
    Private _Remarks As String
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property AttenID() As String
      Get
        Return _AttenID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AttenID = ""
				 Else
					 _AttenID = value
			   End If
      End Set
    End Property
    Public Property AttenDate() As String
      Get
        If Not _AttenDate = String.Empty Then
          Return Convert.ToDateTime(_AttenDate).ToString("dd/MM/yyyy")
        End If
        Return _AttenDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AttenDate = ""
				 Else
					 _AttenDate = value
			   End If
      End Set
    End Property
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CardNo = ""
				 Else
					 _CardNo = value
			   End If
      End Set
    End Property
    Public Property Punch1Time() As String
      Get
        Return _Punch1Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Punch1Time = ""
				 Else
					 _Punch1Time = value
			   End If
      End Set
    End Property
    Public Property Punch2Time() As String
      Get
        Return _Punch2Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Punch2Time = ""
				 Else
					 _Punch2Time = value
			   End If
      End Set
    End Property
    Public Property PunchStatusID() As String
      Get
        Return _PunchStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PunchStatusID = ""
				 Else
					 _PunchStatusID = value
			   End If
      End Set
    End Property
    Public Property MannuallyCorrectedOn() As String
      Get
        If Not _MannuallyCorrectedOn = String.Empty Then
          Return Convert.ToDateTime(_MannuallyCorrectedOn).ToString("dd/MM/yyyy")
        End If
        Return _MannuallyCorrectedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MannuallyCorrectedOn = ""
				 Else
					 _MannuallyCorrectedOn = value
			   End If
      End Set
    End Property
    Public Property MannuallyCorrectedBy() As String
      Get
        Return _MannuallyCorrectedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MannuallyCorrectedBy = ""
				 Else
					 _MannuallyCorrectedBy = value
			   End If
      End Set
    End Property
    Public Property NewPunch1Time() As String
      Get
        Return _NewPunch1Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _NewPunch1Time = ""
				 Else
					 _NewPunch1Time = value
			   End If
      End Set
    End Property
    Public Property NewPunch2Time() As String
      Get
        Return _NewPunch2Time
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _NewPunch2Time = ""
				 Else
					 _NewPunch2Time = value
			   End If
      End Set
    End Property
    Public Property NewPunchStatusID() As String
      Get
        Return _NewPunchStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _NewPunchStatusID = ""
				 Else
					 _NewPunchStatusID = value
			   End If
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Remarks = ""
				 Else
					 _Remarks = value
			   End If
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SerialNo As Int32) As SIS.ATN.atnMannualCorrectionHistory
      Dim Results As SIS.ATN.atnMannualCorrectionHistory = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnMannualCorrectionHistorySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnMannualCorrectionHistory(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnMannualCorrectionHistory)
      Dim Results As List(Of SIS.ATN.atnMannualCorrectionHistory) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AttenDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnMannualCorrectionHistorySelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnMannualCorrectionHistorySelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnMannualCorrectionHistory)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnMannualCorrectionHistory(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnMannualCorrectionHistory) As Int32
      Dim _Result As Int32 = Record.SerialNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnMannualCorrectionHistoryInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID",SqlDbType.Int,11, Iif(Record.AttenID= "" ,Convert.DBNull, Record.AttenID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate",SqlDbType.DateTime,21, Iif(Record.AttenDate= "" ,Convert.DBNull, Record.AttenDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Iif(Record.CardNo= "" ,Convert.DBNull, Record.CardNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch1Time",SqlDbType.Decimal,9, Iif(Record.Punch1Time= "" ,Convert.DBNull, Record.Punch1Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch2Time",SqlDbType.Decimal,9, Iif(Record.Punch2Time= "" ,Convert.DBNull, Record.Punch2Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID",SqlDbType.NVarChar,3, Iif(Record.PunchStatusID= "" ,Convert.DBNull, Record.PunchStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MannuallyCorrectedOn",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MannuallyCorrectedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NewPunch1Time",SqlDbType.Decimal,9, Iif(Record.NewPunch1Time= "" ,Convert.DBNull, Record.NewPunch1Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NewPunch2Time",SqlDbType.Decimal,9, Iif(Record.NewPunch2Time= "" ,Convert.DBNull, Record.NewPunch2Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NewPunchStatusID",SqlDbType.NVarChar,3, Iif(Record.NewPunchStatusID= "" ,Convert.DBNull, Record.NewPunchStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      If Convert.IsDBNull(Reader("AttenID")) Then
        _AttenID = String.Empty
      Else
        _AttenID = Ctype(Reader("AttenID"), String)
      End If
      If Convert.IsDBNull(Reader("AttenDate")) Then
        _AttenDate = String.Empty
      Else
        _AttenDate = Ctype(Reader("AttenDate"), String)
      End If
      If Convert.IsDBNull(Reader("CardNo")) Then
        _CardNo = String.Empty
      Else
        _CardNo = Ctype(Reader("CardNo"), String)
      End If
      If Convert.IsDBNull(Reader("Punch1Time")) Then
        _Punch1Time = String.Empty
      Else
        _Punch1Time = Ctype(Reader("Punch1Time"), String)
      End If
      If Convert.IsDBNull(Reader("Punch2Time")) Then
        _Punch2Time = String.Empty
      Else
        _Punch2Time = Ctype(Reader("Punch2Time"), String)
      End If
      If Convert.IsDBNull(Reader("PunchStatusID")) Then
        _PunchStatusID = String.Empty
      Else
        _PunchStatusID = Ctype(Reader("PunchStatusID"), String)
      End If
      If Convert.IsDBNull(Reader("MannuallyCorrectedOn")) Then
        _MannuallyCorrectedOn = String.Empty
      Else
        _MannuallyCorrectedOn = Ctype(Reader("MannuallyCorrectedOn"), String)
      End If
      If Convert.IsDBNull(Reader("MannuallyCorrectedBy")) Then
        _MannuallyCorrectedBy = String.Empty
      Else
        _MannuallyCorrectedBy = Ctype(Reader("MannuallyCorrectedBy"), String)
      End If
      If Convert.IsDBNull(Reader("NewPunch1Time")) Then
        _NewPunch1Time = String.Empty
      Else
        _NewPunch1Time = Ctype(Reader("NewPunch1Time"), String)
      End If
      If Convert.IsDBNull(Reader("NewPunch2Time")) Then
        _NewPunch2Time = String.Empty
      Else
        _NewPunch2Time = Ctype(Reader("NewPunch2Time"), String)
      End If
      If Convert.IsDBNull(Reader("NewPunchStatusID")) Then
        _NewPunchStatusID = String.Empty
      Else
        _NewPunchStatusID = Ctype(Reader("NewPunchStatusID"), String)
      End If
      If Convert.IsDBNull(Reader("Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader("Remarks"), String)
      End If
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader(AliasName & "_SerialNo"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_AttenID")) Then
        _AttenID = String.Empty
      Else
        _AttenID = Ctype(Reader(AliasName & "_AttenID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_AttenDate")) Then
        _AttenDate = String.Empty
      Else
        _AttenDate = Ctype(Reader(AliasName & "_AttenDate"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_CardNo")) Then
        _CardNo = String.Empty
      Else
        _CardNo = Ctype(Reader(AliasName & "_CardNo"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Punch1Time")) Then
        _Punch1Time = String.Empty
      Else
        _Punch1Time = Ctype(Reader(AliasName & "_Punch1Time"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Punch2Time")) Then
        _Punch2Time = String.Empty
      Else
        _Punch2Time = Ctype(Reader(AliasName & "_Punch2Time"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_PunchStatusID")) Then
        _PunchStatusID = String.Empty
      Else
        _PunchStatusID = Ctype(Reader(AliasName & "_PunchStatusID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_MannuallyCorrectedOn")) Then
        _MannuallyCorrectedOn = String.Empty
      Else
        _MannuallyCorrectedOn = Ctype(Reader(AliasName & "_MannuallyCorrectedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_MannuallyCorrectedBy")) Then
        _MannuallyCorrectedBy = String.Empty
      Else
        _MannuallyCorrectedBy = Ctype(Reader(AliasName & "_MannuallyCorrectedBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_NewPunch1Time")) Then
        _NewPunch1Time = String.Empty
      Else
        _NewPunch1Time = Ctype(Reader(AliasName & "_NewPunch1Time"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_NewPunch2Time")) Then
        _NewPunch2Time = String.Empty
      Else
        _NewPunch2Time = Ctype(Reader(AliasName & "_NewPunch2Time"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_NewPunchStatusID")) Then
        _NewPunchStatusID = String.Empty
      Else
        _NewPunchStatusID = Ctype(Reader(AliasName & "_NewPunchStatusID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader(AliasName & "_Remarks"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
