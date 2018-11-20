Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnPunchConfig
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32
    Private _Description As String
    Private _STD1Time As Decimal
    Private _Range1Start As Decimal
    Private _Range1End As Decimal
    Private _MeanTime As Decimal
    Private _STD2Time As Decimal
    Private _Range2Start As Decimal
    Private _Range2End As Decimal
    Private _EnableMinHrs As Boolean
    Private _MinHrsFullPresent As Decimal
    Private _MinHrsHalfPresent As Decimal
    Private _Active As Boolean
    Private _FinYear As String
    Private _DataFileLocation As String
    Public Property RecordID() As Int32
      Get
        Return _RecordID
      End Get
      Set(ByVal value As Int32)
        _RecordID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property STD1Time() As Decimal
      Get
        Return _STD1Time
      End Get
      Set(ByVal value As Decimal)
        _STD1Time = value
      End Set
    End Property
    Public Property Range1Start() As Decimal
      Get
        Return _Range1Start
      End Get
      Set(ByVal value As Decimal)
        _Range1Start = value
      End Set
    End Property
    Public Property Range1End() As Decimal
      Get
        Return _Range1End
      End Get
      Set(ByVal value As Decimal)
        _Range1End = value
      End Set
    End Property
    Public Property MeanTime() As Decimal
      Get
        Return _MeanTime
      End Get
      Set(ByVal value As Decimal)
        _MeanTime = value
      End Set
    End Property
    Public Property STD2Time() As Decimal
      Get
        Return _STD2Time
      End Get
      Set(ByVal value As Decimal)
        _STD2Time = value
      End Set
    End Property
    Public Property Range2Start() As Decimal
      Get
        Return _Range2Start
      End Get
      Set(ByVal value As Decimal)
        _Range2Start = value
      End Set
    End Property
    Public Property Range2End() As Decimal
      Get
        Return _Range2End
      End Get
      Set(ByVal value As Decimal)
        _Range2End = value
      End Set
    End Property
    Public Property EnableMinHrs() As Boolean
      Get
        Return _EnableMinHrs
      End Get
      Set(ByVal value As Boolean)
        _EnableMinHrs = value
      End Set
    End Property
    Public Property MinHrsFullPresent() As Decimal
      Get
        Return _MinHrsFullPresent
      End Get
      Set(ByVal value As Decimal)
        _MinHrsFullPresent = value
      End Set
    End Property
    Public Property MinHrsHalfPresent() As Decimal
      Get
        Return _MinHrsHalfPresent
      End Get
      Set(ByVal value As Decimal)
        _MinHrsHalfPresent = value
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
      End Set
    End Property
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
      End Set
    End Property
    Public Property DataFileLocation() As String
      Get
        Return _DataFileLocation
      End Get
      Set(ByVal value As String)
        _DataFileLocation = value
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ATN.atnPunchConfig)
      Dim Results As List(Of SIS.ATN.atnPunchConfig) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnPunchConfig)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnPunchConfig(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal RecordID As Int32) As SIS.ATN.atnPunchConfig
      Dim Results As SIS.ATN.atnPunchConfig = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnPunchConfig(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ATN.atnPunchConfig)
      Dim Results As List(Of SIS.ATN.atnPunchConfig) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnPunchConfigSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnPunchConfigSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnPunchConfig)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnPunchConfig(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ATN.atnPunchConfig) As Int32
      Dim _Result As Int32 = Record.RecordID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@STD1Time",SqlDbType.Decimal,9, Record.STD1Time)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range1Start",SqlDbType.Decimal,9, Record.Range1Start)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range1End",SqlDbType.Decimal,9, Record.Range1End)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MeanTime",SqlDbType.Decimal,9, Record.MeanTime)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@STD2Time",SqlDbType.Decimal,9, Record.STD2Time)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range2Start",SqlDbType.Decimal,9, Record.Range2Start)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range2End",SqlDbType.Decimal,9, Record.Range2End)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnableMinHrs",SqlDbType.Bit,3, Record.EnableMinHrs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinHrsFullPresent",SqlDbType.Decimal,9, Record.MinHrsFullPresent)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinHrsHalfPresent",SqlDbType.Decimal,9, Record.MinHrsHalfPresent)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,5, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DataFileLocation",SqlDbType.NVarChar,251, Record.DataFileLocation)
          Cmd.Parameters.Add("@Return_RecordID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_RecordID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_RecordID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnPunchConfig) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@STD1Time",SqlDbType.Decimal,9, Record.STD1Time)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range1Start",SqlDbType.Decimal,9, Record.Range1Start)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range1End",SqlDbType.Decimal,9, Record.Range1End)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MeanTime",SqlDbType.Decimal,9, Record.MeanTime)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@STD2Time",SqlDbType.Decimal,9, Record.STD2Time)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range2Start",SqlDbType.Decimal,9, Record.Range2Start)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Range2End",SqlDbType.Decimal,9, Record.Range2End)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnableMinHrs",SqlDbType.Bit,3, Record.EnableMinHrs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinHrsFullPresent",SqlDbType.Decimal,9, Record.MinHrsFullPresent)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinHrsHalfPresent",SqlDbType.Decimal,9, Record.MinHrsHalfPresent)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DataFileLocation",SqlDbType.NVarChar,251, Record.DataFileLocation)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function Delete(ByVal Record As SIS.ATN.atnPunchConfig) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPunchConfigDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,Record.RecordID.ToString.Length, Record.RecordID)
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
'		Autocomplete Method
		Public Shared Function SelectatnPunchConfigAutoCompleteList(ByVal Prefix As String, ByVal count As Integer) As String()
			Dim Results As List(Of String) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spatnPunchConfigAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---", ""))
					While (Reader.Read())
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Reader(0), Reader(1)))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader("RecordID"),Int32)
      _Description = Ctype(Reader("Description"),String)
      _STD1Time = Ctype(Reader("STD1Time"),Decimal)
      _Range1Start = Ctype(Reader("Range1Start"),Decimal)
      _Range1End = Ctype(Reader("Range1End"),Decimal)
      _MeanTime = Ctype(Reader("MeanTime"),Decimal)
      _STD2Time = Ctype(Reader("STD2Time"),Decimal)
      _Range2Start = Ctype(Reader("Range2Start"),Decimal)
      _Range2End = Ctype(Reader("Range2End"),Decimal)
      _EnableMinHrs = Ctype(Reader("EnableMinHrs"),Boolean)
      _MinHrsFullPresent = Ctype(Reader("MinHrsFullPresent"),Decimal)
      _MinHrsHalfPresent = Ctype(Reader("MinHrsHalfPresent"),Decimal)
      _Active = Ctype(Reader("Active"),Boolean)
      _FinYear = Ctype(Reader("FinYear"),String)
      _DataFileLocation = Ctype(Reader("DataFileLocation"),String)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RecordID = Ctype(Reader(AliasName & "_RecordID"),Int32)
      _Description = Ctype(Reader(AliasName & "_Description"),String)
      _STD1Time = Ctype(Reader(AliasName & "_STD1Time"),Decimal)
      _Range1Start = Ctype(Reader(AliasName & "_Range1Start"),Decimal)
      _Range1End = Ctype(Reader(AliasName & "_Range1End"),Decimal)
      _MeanTime = Ctype(Reader(AliasName & "_MeanTime"),Decimal)
      _STD2Time = Ctype(Reader(AliasName & "_STD2Time"),Decimal)
      _Range2Start = Ctype(Reader(AliasName & "_Range2Start"),Decimal)
      _Range2End = Ctype(Reader(AliasName & "_Range2End"),Decimal)
      _EnableMinHrs = Ctype(Reader(AliasName & "_EnableMinHrs"),Boolean)
      _MinHrsFullPresent = Ctype(Reader(AliasName & "_MinHrsFullPresent"),Decimal)
      _MinHrsHalfPresent = Ctype(Reader(AliasName & "_MinHrsHalfPresent"),Decimal)
      _Active = Ctype(Reader(AliasName & "_Active"),Boolean)
      _FinYear = Ctype(Reader(AliasName & "_FinYear"),String)
      _DataFileLocation = Ctype(Reader(AliasName & "_DataFileLocation"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
