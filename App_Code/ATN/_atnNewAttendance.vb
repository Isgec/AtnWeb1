Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()>
  Partial Public Class atnNewAttendance
    Private Shared _RecordCount As Integer
#Region " DB Properties "
    Public Property AttenID As Int32
    Private _AttenDate As String
    Public Property CardNo As String
    Public Property Punch1Time As String
    Public Property Punch2Time As String
    Public Property PunchStatusID As String
    Public Property Punch9Time As String
    Public Property PunchValue As String
    Public Property NeedsRegularization As Boolean
    Public Property FinYear As String
    Public Property Applied As Boolean
    Public Property AppliedValue As String
    Public Property Applied1LeaveTypeID As String
    Public Property Applied2LeaveTypeID As String
    Public Property Posted As Boolean
    Public Property Posted1LeaveTypeID As String
    Public Property Posted2LeaveTypeID As String
    Public Property ApplHeaderID As String
    Public Property ApplStatusID As String
    Public Property FinalValue As String
    Public Property AdvanceApplication As Boolean
    Public Property MannuallyCorrected As Boolean
    Public Property Destination As String
    Public Property Purpose As String
    Public Property ConfigID As String
    Public Property ConfigDetailID As String
    Public Property ConfigStatus As String
    Public Property TSStatus As String
    Public Property TSStatusBy As String
    Private _TSStatusOn As String
    Public Property FirstPunchMachine As String = ""
    Public Property SecondPunchMachine As String = ""
    Public Property HoliDay As Boolean = False
    Public Property SiteAttendance As Boolean = False
    Public Property SiteAttendanceVerified As Boolean = False
    Public Property SiteAttendanceVerifiedBy As String = ""
    Private _SiteAttendanceVerifiedOn As String = ""
    Public Property OfficeID As String = ""
    Public Property SiteAttendanceVerifiedOn() As String
      Get
        If Not _SiteAttendanceVerifiedOn = String.Empty Then
          Return Convert.ToDateTime(_SiteAttendanceVerifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _SiteAttendanceVerifiedOn
      End Get
      Set(ByVal value As String)
        _SiteAttendanceVerifiedOn = value
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
        _AttenDate = value
      End Set
    End Property
    Public Property TSStatusOn() As String
      Get
        If Not _TSStatusOn = String.Empty Then
          Return Convert.ToDateTime(_TSStatusOn).ToString("dd/MM/yyyy")
        End If
        Return _TSStatusOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TSStatusOn = ""
        Else
          _TSStatusOn = value
        End If
      End Set
    End Property
#End Region

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByID(ByVal AttenID As Int32) As SIS.ATN.atnNewAttendance
      Dim Results As SIS.ATN.atnNewAttendance = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewAttendanceSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenID", SqlDbType.Int, AttenID.ToString.Length, AttenID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnNewAttendance(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnNewAttendance)
      Dim Results As List(Of SIS.ATN.atnNewAttendance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If orderBy = String.Empty Then orderBy = "AttenDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spatnNewAttendanceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spatnNewAttendanceSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnNewAttendance)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnNewAttendance(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnNewAttendance) As Int32
      Dim _Result As Int32 = Record.AttenID
      SIS.ATN.atnNewAttendance.SetPunch9Time(Record)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewAttendanceInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch1Time", SqlDbType.Decimal, 9, IIf(Record.Punch1Time = "", Convert.DBNull, Record.Punch1Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch2Time", SqlDbType.Decimal, 9, IIf(Record.Punch2Time = "", Convert.DBNull, Record.Punch2Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID", SqlDbType.NVarChar, 3, IIf(Record.PunchStatusID = "", Convert.DBNull, Record.PunchStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch9Time", SqlDbType.Decimal, 9, IIf(Record.Punch9Time = "", Convert.DBNull, Record.Punch9Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchValue", SqlDbType.Decimal, 9, IIf(Record.PunchValue = "", Convert.DBNull, Record.PunchValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NeedsRegularization", SqlDbType.Bit, 3, Record.NeedsRegularization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.NVarChar, 5, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied", SqlDbType.Bit, 3, Record.Applied)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppliedValue", SqlDbType.Decimal, 9, IIf(Record.AppliedValue = "", Convert.DBNull, Record.AppliedValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied1LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Applied1LeaveTypeID = "", Convert.DBNull, Record.Applied1LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied2LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Applied2LeaveTypeID = "", Convert.DBNull, Record.Applied2LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted", SqlDbType.Bit, 3, Record.Posted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted1LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Posted1LeaveTypeID = "", Convert.DBNull, Record.Posted1LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted2LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Posted2LeaveTypeID = "", Convert.DBNull, Record.Posted2LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID", SqlDbType.Int, 11, IIf(Record.ApplHeaderID = "", Convert.DBNull, Record.ApplHeaderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID", SqlDbType.Int, 11, IIf(Record.ApplStatusID = "", Convert.DBNull, Record.ApplStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalValue", SqlDbType.Decimal, 9, IIf(Record.FinalValue = "", Convert.DBNull, Record.FinalValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication", SqlDbType.Bit, 3, Record.AdvanceApplication)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MannuallyCorrected", SqlDbType.Bit, 3, Record.MannuallyCorrected)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Destination", SqlDbType.NVarChar, 51, IIf(Record.Destination = "", Convert.DBNull, Record.Destination))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Purpose", SqlDbType.NVarChar, 251, IIf(Record.Purpose = "", Convert.DBNull, Record.Purpose))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigID", SqlDbType.Int, 11, IIf(Record.ConfigID = "", Convert.DBNull, Record.ConfigID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigDetailID", SqlDbType.Int, 11, IIf(Record.ConfigDetailID = "", Convert.DBNull, Record.ConfigDetailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigStatus", SqlDbType.NVarChar, 3, IIf(Record.ConfigStatus = "", Convert.DBNull, Record.ConfigStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSStatus", SqlDbType.NVarChar, 3, IIf(Record.TSStatus = "", Convert.DBNull, Record.TSStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSStatusBy", SqlDbType.NVarChar, 9, IIf(Record.TSStatusBy = "", Convert.DBNull, Record.TSStatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSStatusOn", SqlDbType.DateTime, 21, IIf(Record.TSStatusOn = "", Convert.DBNull, Record.TSStatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoliDay", SqlDbType.Bit, 3, Record.HoliDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendance", SqlDbType.Bit, 3, Record.SiteAttendance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendanceVerified", SqlDbType.Bit, 3, Record.SiteAttendanceVerified)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendanceVerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.SiteAttendanceVerifiedBy = "", Convert.DBNull, Record.SiteAttendanceVerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendanceVerifiedOn", SqlDbType.DateTime, 21, IIf(Record.SiteAttendanceVerifiedOn = "", Convert.DBNull, Record.SiteAttendanceVerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FirstPunchMachine", SqlDbType.NVarChar, 100, IIf(Record.FirstPunchMachine = "", Convert.DBNull, Record.FirstPunchMachine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SecondPunchMachine", SqlDbType.NVarChar, 100, IIf(Record.SecondPunchMachine = "", Convert.DBNull, Record.SecondPunchMachine))
          Cmd.Parameters.Add("@Return_AttenID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_AttenID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_AttenID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function Update(ByVal Record As SIS.ATN.atnNewAttendance) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewAttendanceUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttenID", SqlDbType.Int, 11, Record.AttenID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttenDate", SqlDbType.DateTime, 21, Record.AttenDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch1Time", SqlDbType.Decimal, 9, IIf(Record.Punch1Time = "", Convert.DBNull, Record.Punch1Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch2Time", SqlDbType.Decimal, 9, IIf(Record.Punch2Time = "", Convert.DBNull, Record.Punch2Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchStatusID", SqlDbType.NVarChar, 3, IIf(Record.PunchStatusID = "", Convert.DBNull, Record.PunchStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Punch9Time", SqlDbType.Decimal, 9, IIf(Record.Punch9Time = "", Convert.DBNull, Record.Punch9Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PunchValue", SqlDbType.Decimal, 9, IIf(Record.PunchValue = "", Convert.DBNull, Record.PunchValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NeedsRegularization", SqlDbType.Bit, 3, Record.NeedsRegularization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied", SqlDbType.Bit, 3, Record.Applied)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppliedValue", SqlDbType.Decimal, 9, IIf(Record.AppliedValue = "", Convert.DBNull, Record.AppliedValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied1LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Applied1LeaveTypeID = "", Convert.DBNull, Record.Applied1LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied2LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Applied2LeaveTypeID = "", Convert.DBNull, Record.Applied2LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted", SqlDbType.Bit, 3, Record.Posted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted1LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Posted1LeaveTypeID = "", Convert.DBNull, Record.Posted1LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Posted2LeaveTypeID", SqlDbType.NVarChar, 3, IIf(Record.Posted2LeaveTypeID = "", Convert.DBNull, Record.Posted2LeaveTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplHeaderID", SqlDbType.Int, 11, IIf(Record.ApplHeaderID = "", Convert.DBNull, Record.ApplHeaderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID", SqlDbType.Int, 11, IIf(Record.ApplStatusID = "", Convert.DBNull, Record.ApplStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalValue", SqlDbType.Decimal, 9, IIf(Record.FinalValue = "", Convert.DBNull, Record.FinalValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication", SqlDbType.Bit, 3, Record.AdvanceApplication)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MannuallyCorrected", SqlDbType.Bit, 3, Record.MannuallyCorrected)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Destination", SqlDbType.NVarChar, 51, IIf(Record.Destination = "", Convert.DBNull, Record.Destination))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Purpose", SqlDbType.NVarChar, 251, IIf(Record.Purpose = "", Convert.DBNull, Record.Purpose))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigID", SqlDbType.Int, 11, IIf(Record.ConfigID = "", Convert.DBNull, Record.ConfigID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigDetailID", SqlDbType.Int, 11, IIf(Record.ConfigDetailID = "", Convert.DBNull, Record.ConfigDetailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConfigStatus", SqlDbType.NVarChar, 3, IIf(Record.ConfigStatus = "", Convert.DBNull, Record.ConfigStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSStatus", SqlDbType.NVarChar, 3, IIf(Record.TSStatus = "", Convert.DBNull, Record.TSStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSStatusBy", SqlDbType.NVarChar, 9, IIf(Record.TSStatusBy = "", Convert.DBNull, Record.TSStatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSStatusOn", SqlDbType.DateTime, 21, IIf(Record.TSStatusOn = "", Convert.DBNull, Record.TSStatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoliDay", SqlDbType.Bit, 3, Record.HoliDay)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendance", SqlDbType.Bit, 3, Record.SiteAttendance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendanceVerified", SqlDbType.Bit, 3, Record.SiteAttendanceVerified)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendanceVerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.SiteAttendanceVerifiedBy = "", Convert.DBNull, Record.SiteAttendanceVerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAttendanceVerifiedOn", SqlDbType.DateTime, 21, IIf(Record.SiteAttendanceVerifiedOn = "", Convert.DBNull, Record.SiteAttendanceVerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FirstPunchMachine", SqlDbType.NVarChar, 100, IIf(Record.FirstPunchMachine = "", Convert.DBNull, Record.FirstPunchMachine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SecondPunchMachine", SqlDbType.NVarChar, 100, IIf(Record.SecondPunchMachine = "", Convert.DBNull, Record.SecondPunchMachine))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception

          End Try
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnNewAttendance) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnNewAttendanceDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttenID", SqlDbType.Int, Record.AttenID.ToString.Length, Record.AttenID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, reader)
    End Sub
  End Class
End Namespace
