Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.IO.Compression
Imports System.IO

Module tfmsGlobals

    Public Enum cols
        id
        Ver
        FileName
        FileSize
        MissionName
        Author
        Released
        Rating
        Completed
        FileTypes
        Directory
        InstallFolder
        Hash
    End Enum

    Public Function GetDLLPath() As String
        GetDLLPath = New FileInfo(New Uri(Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath).DirectoryName
    End Function

    Public Function FormatFileSize(ByVal FileSizeBytes As Long) As String
        Dim sizeTypes() As String = {"b", "Kb", "Mb", "Gb"}
        Dim Len As Decimal = FileSizeBytes
        Dim sizeType As Integer = 0
        Do While Len > 1024
            Len = Decimal.Round(Len / 1024, 2)
            sizeType += 1
            If sizeType >= sizeTypes.Length - 1 Then Exit Do
        Loop

        Dim Resp As String = Len.ToString("N2", CultureInfo.CurrentCulture) & " " & sizeTypes(sizeType)
        Return Resp
    End Function

    Public Sub OpenMissionNotes(rowid As Integer)
        Dim fn As String = Path.Combine(AppPath, "MissionNotes" & rowid & ".txt")
        Dim txt As String = GetUserNotesFromDb(rowid)
        File.WriteAllText(fn, txt)
        Process.Start(fn)
    End Sub

    Public Sub ImportMissionNotes()
        For Each fi As FileInfo In New DirectoryInfo(AppPath).GetFiles("MissionNotes*.txt", SearchOption.TopDirectoryOnly)
            Dim txt As String = File.ReadAllText(fi.FullName)
            Dim rowid As Integer = CInt(fi.Name.Replace("MissionNotes", "").Replace(".txt", ""))
            fi.Delete()
            SaveUserNote(rowid, txt)
        Next
    End Sub

    ''' <summary>
    ''' Compresses supplied string into a GZipped byte array.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    <Extension()>
    Function Compress(value As String) As Byte()
        Using mso As New MemoryStream
            Using gz As New GZipStream(mso, CompressionMode.Compress)
                Using sw As New StreamWriter(gz)
                    sw.Write(value)
                End Using
            End Using
            Compress = mso.ToArray
        End Using
    End Function

    ''' <summary>
    ''' Expands GZipped byte array into a string.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    <Extension()>
    Function Expand(value As Byte()) As String
        Using msi As New MemoryStream(value)
            Using gz As New GZipStream(msi, CompressionMode.Decompress)
                Using sr As New StreamReader(gz)
                    Expand = sr.ReadToEnd
                End Using
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Prepares a string to be used in an SQL command.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    <Extension()>
    Function SQLify(value As String) As String
        value = value & vbNullString
        value = value.Trim
        value = value.Replace("'", "''")
        Return value
    End Function

    <Extension()>
    Function bak(Filename As String) As String
        Return Filename & ".bak"
    End Function

    <Extension()>
    Function tfmm(Filename As String) As String
        Return Filename & ".tfmm"
    End Function
End Module
