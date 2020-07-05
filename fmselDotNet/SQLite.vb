Imports System.IO
Imports System.Data.SQLite
Imports map = BoycoT.TFMM.MissionArchiveParser
Imports System.Collections.Specialized

Module SQLite

    Public dtMissions As DataTable
    Public dvMissions As DataView

    Private ReadOnly dbFile As String = Path.Combine(AppPath, "TFMM.db")
    Private ReadOnly ConnStr As String = New SQLiteConnectionStringBuilder With {.DataSource = dbFile, .Version = 3}.ConnectionString

    Public Sub InitializeDb()
        Using Conn As New SqliteConnection(ConnStr)
            Conn.Open()
            Using Cmd As New SqliteCommand
                Cmd.Connection = Conn
                Cmd.CommandText = My.Settings.CreateTableFMFiles
                Cmd.ExecuteNonQuery()
                Cmd.CommandText = My.Settings.CreateTableInfoFiles
                Cmd.ExecuteNonQuery()
                Cmd.CommandText = My.Settings.CreateTriggerFMDelete
                Cmd.ExecuteNonQuery()
                Cmd.CommandText = My.Settings.CreateTableUserNotes
                Cmd.ExecuteNonQuery()
            End Using
        End Using
        dtMissions = GetAllMissionsFromDb()
        dvMissions = New DataView(dtMissions)
        If Not ViewAllMissions Then dvMissions.RowFilter = "Ver = '" & GameVersion & "'"
    End Sub

    Private Function CreateDbCommand(cmdText As String) As SQLiteCommand
        CreateDbCommand = New SQLiteCommand(cmdText, CreateDbConnection)
    End Function

    Private Function CreateDbConnection() As SQLiteConnection
        Return New SQLiteConnection(ConnStr)
    End Function

    Public Function dbExecuteNonQuery(cmdText As String) As Integer
        With CreateDbCommand(cmdText)
            .Connection.Open()
            dbExecuteNonQuery = .ExecuteNonQuery
            .Connection.Close()
        End With
    End Function

    Public Function dbExecuteQuery(cmdText As String) As DataTable
        dbExecuteQuery = New DataTable
        With CreateDbCommand(cmdText)
            .Connection.Open()
            dbExecuteQuery.Load(.ExecuteReader)
            .Connection.Close()
        End With
    End Function

    Public Function GetAllMissionsFromDb() As DataTable
        GetAllMissionsFromDb = dbExecuteQuery(My.Settings.SelectAllFMFiles)
    End Function

    Public Function GetUserNotesFromDb(rowid As Integer) As String
        With CreateDbCommand(String.Format(My.Settings.SelectUserNotes, rowid))
            .Connection.Open()
            GetUserNotesFromDb = .ExecuteScalar
            .Connection.Close()
        End With
    End Function

    Public Sub SaveUserNote(rowid As Integer, Note As String)
        dbExecuteNonQuery(String.Format(My.Settings.UpdateUserNote, rowid, Note.SQLify))
    End Sub

    Public Sub InsertNewMissionFile(ByRef mi As map.MissionInfo)
        Dim rslt As Integer = 0
        Using conn As New SQLiteConnection(ConnStr)
            conn.Open()
            Using cmd As New SQLiteCommand(My.Settings.InsertMissionFile, conn)
                cmd.Parameters.Add("@Ver", DbType.String, 255).Value = mi.Game.ToString
                cmd.Parameters.Add("@Filename", DbType.String, 255).Value = mi.ArchiveFile.Name
                cmd.Parameters.Add("@FileSize", DbType.Int32).Value = mi.ArchiveFile.Length
                cmd.Parameters.Add("@MissionName", DbType.String, 255).Value = mi.Title
                cmd.Parameters.Add("@Author", DbType.String, 255).Value = mi.Author
                cmd.Parameters.Add("@ReleaseDate", DbType.Date).Value = mi.ReleaseDate.ToString("yyyy-MM-dd")
                cmd.Parameters.Add("@Rating", DbType.Int32).Value = 0
                cmd.Parameters.Add("@Completed", DbType.String, 255).Value = "No"
                cmd.Parameters.Add("@FileTypes", DbType.String, 255).Value = mi.FileTypes
                cmd.Parameters.Add("@Directory", DbType.String, 255).Value = mi.ArchiveFile.DirectoryName
                cmd.Parameters.Add("@InstallFolder", DbType.String, 255).Value = mi.InstallDirName
                cmd.Parameters.Add("@Hash", DbType.String, 255).Value = mi.MD5
                If cmd.ExecuteNonQuery > 0 Then
                    cmd.CommandText = "SELECT last_insert_rowid()"
                    mi.rowid = cmd.ExecuteScalar
                    cmd.CommandText = My.Settings.InsertInfoFile
                    For Each f As map.InfoFile In mi.InfoFiles
                        Dim bytes As Byte() = f.FileContent.Compress
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@FMFilesId", DbType.Int32).Value = mi.rowid
                        cmd.Parameters.Add("@Filename", DbType.String, 255).Value = f.Filename
                        cmd.Parameters.Add("@Content", DbType.Binary, bytes.Length).Value = bytes
                        cmd.ExecuteNonQuery()
                    Next
                End If
            End Using
        End Using
    End Sub

    Public Function SelectInfoFiles(fmId As Integer) As NameValueCollection
        Dim nv As New NameValueCollection
        With CreateDbCommand(String.Format(My.Settings.SelectInfoFiles, fmId))
            .Connection.Open()
            Dim reader As SQLiteDataReader = .ExecuteReader
            While reader.Read
                Dim Filename As String = reader.Item(0).ToString
                Dim Data As String = CType(reader.Item(1), Byte()).Expand
                nv.Add(Filename, Data)
            End While
            .Connection.Close()
        End With
        Return nv
    End Function

    Public Sub DeleteMissionFile(folderName As String, filename As String)
        dbExecuteNonQuery(String.Format(My.Settings.DeleteMissionFile, folderName, filename))
    End Sub

    Public Sub UpdateMissionFile(rowid As Integer, MissionName As String, Author As String, ReleaseDate As String, Rating As Integer, Completed As String)
        dbExecuteNonQuery(String.Format(My.Settings.UpdateFMFiles, MissionName, Author, ReleaseDate, Rating, Completed, rowid))
    End Sub

    Public Function GetFileHashListFromDb() As DataTable
        GetFileHashListFromDb = dbExecuteQuery(My.Settings.SelectFileHash)
    End Function

    Public Sub dtMissions_RowChanged(sender As Object, e As DataRowChangeEventArgs) 'Handles dtMissions.RowChanged
        'UPDATE FMFiles SET Ver = '{0}', MissionName = '{1}', Author = '{2}', ReleaseDate = '{3}', Rating = {4}, Completed = {5} WHERE rowid = {6}
        Dim cmd As String = String.Format(My.Settings.UpdateFMFiles, e.Row.Item(cols.Ver).ToString, e.Row.Item(cols.MissionName).ToString.SQLify, e.Row.Item(cols.Author).ToString.SQLify, CDate(e.Row.Item(cols.Released)).ToString("yyyy-MM-dd"), e.Row.Item(cols.Rating).ToString, e.Row.Item(cols.Completed).ToString, e.Row.Item(cols.id))
        With CreateDbCommand(cmd)
            .Connection.Open()
            .ExecuteNonQuery()
            .Connection.Close()
        End With
    End Sub

    Public ReadOnly Property TotalRowCount As Integer
        Get
            Return dtMissions.Rows.Count
        End Get
    End Property

    Public ReadOnly Property FilteredRowCount As Integer
        Get
            Return dvMissions.Count
        End Get
    End Property

End Module
