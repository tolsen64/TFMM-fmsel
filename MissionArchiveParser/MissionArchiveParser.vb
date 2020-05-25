Imports System.IO
Imports System.Text
Imports System.Text.Encoding
Imports System.Text.RegularExpressions
'Imports BoycoT.TFMM.ZipStorer
Imports System.Security.Cryptography
Imports SevenZip

Public Module MissionArchiveParser

    Public Enum Game
        Unk = 0
        T1 = 1
        T2 = 2
        T3 = 3
        SS2 = 10
        DM = 11
    End Enum

    Public Structure InfoFile
        Public Filename As String
        Public FileContent As String
    End Structure

    Public Structure MissionInfo
        Public rowid As Integer 'To be added later by caller.
        Public ArchiveFile As FileInfo
        Public MD5 As String
        Public Game As Game
        Public ReleaseDate As Date
        Public Title As String
        Public Author As String
        Public InstallDirName As String
        Public InfoFiles As List(Of InfoFile)
        Public FileTypes As String
    End Structure

    Public Function ParseMissionArchive(ByVal FileName As String) As MissionInfo
        Debug.WriteLine("ParseMissionArchive(" & FileName & ")")
        Try
            Dim mi As New MissionInfo With {.ArchiveFile = New FileInfo(FileName),
                                        .MD5 = GetMD5(FileName),
                                        .Game = Game.Unk,
                                        .ReleaseDate = New Date(1998, 11, 30),
                                        .InfoFiles = New List(Of InfoFile)
                                       }
            Dim titlesStr As String = ""
            Dim darkmodTxt As String = ""
            Dim misBuf() As Byte = {}
            Dim alMisNums As New ArrayList
            Dim fileTypes As New List(Of String)

            mi.InstallDirName = New Regex("[^a-z0-9]", RegexOptions.IgnoreCase).Replace(mi.ArchiveFile.Name.Replace(mi.ArchiveFile.Extension, ""), "")
            If mi.InstallDirName.Length > 30 Then mi.InstallDirName = mi.InstallDirName.Substring(0, 30)

            Using zs As New SevenZipExtractor(FileName)
                For Each entry As ArchiveFileInfo In zs.ArchiveFileData

                    If entry.LastWriteTime.Date > mi.ReleaseDate.Date AndAlso entry.LastWriteTime.Date < Now.Date Then mi.ReleaseDate = entry.LastWriteTime.Date
                    Dim fi As New FileInfo(entry.FileName)
                    If Not fileTypes.Contains(fi.Extension.ToLower) Then fileTypes.Add(fi.Extension.ToLower)
                    Select Case fi.Name.ToLower
                        Case "titles.str", "title.str"
                            titlesStr = GetZipEntryText(zs, entry)
                        Case "darkmod.txt"
                            mi.Game = Game.DM
                            With New StringReader(GetZipEntryText(zs, entry))
                                Do Until .Peek = 0
                                    darkmodTxt = .ReadLine & vbNullString
                                    If darkmodTxt.ToLower.StartsWith("title:") Then
                                        mi.Title = darkmodTxt.Substring(darkmodTxt.IndexOf(":") + 1).Trim
                                    ElseIf darkmodTxt.ToLower.StartsWith("author:") Then
                                        mi.Author = darkmodTxt.Substring(darkmodTxt.IndexOf(":") + 1).Trim
                                    End If
                                    If mi.Title <> "" AndAlso mi.Author <> "" Then Exit Do
                                Loop
                            End With
                    End Select

                    If fi.Name.Contains(".") Then
                        Select Case fi.Name.Substring(fi.Name.LastIndexOf(".")).ToUpper
                            Case ".MIS"
                                alMisNums.Add(GetNums(fi.Name)) 'To be used to get title from titles.str if necessary
                                If mi.Game = Game.Unk Then
                                    ReDim misBuf(entry.Size - 1)
                                    zs.ExtractFile(entry.FileName, New MemoryStream(misBuf))
                                    If PatternExists(misBuf, New Byte() {&HDE, &HAD, &HBE, &HEF}) Then   'Valid Mission Files contain the byte pattern: DE AD BE EF (Dead Beef)
                                        If PatternExists(misBuf, ASCII.GetBytes("HIT_EXPLOSION")) Then
                                            mi.Game = Game.T2
                                        ElseIf PatternExists(misBuf, ASCII.GetBytes("Electro Shock")) Then
                                            mi.Game = Game.SS2
                                        Else
                                            mi.Game = Game.T1
                                        End If
                                    End If
                                End If
                            Case ".IBT", ".CBT"
                                mi.Game = Game.T3
                            Case ".RTF", ".HTM", ".HTML", ".TXT"
                                Dim info As New InfoFile With {.Filename = fi.Name, .FileContent = GetZipEntryText(zs, entry)}
                                mi.InfoFiles.Add(info)
                            Case ".GLML"
                                Dim glml As String = GetZipEntryText(zs, entry)
                                With New Regex("(\[GL|\[/GL).*?\]") 'Matches all [GL..] and [/GL..] tags
                                    Do Until Not .IsMatch(glml)
                                        glml = .Replace(glml, "")
                                    Loop
                                End With
                                Dim info As New InfoFile With {.Filename = fi.Name, .FileContent = glml}
                                mi.InfoFiles.Add(info)
                        End Select
                    End If

                Next
            End Using

            fileTypes.Sort()
            mi.FileTypes = Join(fileTypes.ToArray, "").Replace(".", " ").Trim

            'This will search all the found text files for Author & Title
            Dim strLine As String = ""
            Dim rxTitleAuthor As New Regex("^\s*?(mission|level|)\s*?(?<param>name|title|author)(s|)\s*?:\s*?(?<value>.*?)\s*?$", RegexOptions.ExplicitCapture + RegexOptions.IgnoreCase + RegexOptions.Multiline)

            mi.Title &= vbNullString
            mi.Author &= vbNullString

            If mi.Author = "" Or mi.Title = "" Then
                For Each info As InfoFile In mi.InfoFiles
                    Dim str As String = info.FileContent
                    If info.Filename.ToLower.EndsWith(".rtf") AndAlso str.StartsWith("{\rtf1\") Then
                        str = Rtf2Txt(str)
                    End If

                    For Each m As Match In rxTitleAuthor.Matches(str)
                        Select Case m.Groups("param").Value.ToLower
                            Case "title" : If mi.Title = "" Then mi.Title = m.Groups("value").Value.Replace("""", "")
                            Case "author" : If mi.Author = "" Then mi.Author = m.Groups("value").Value.Replace("""", "")
                        End Select
                    Next
                    If mi.Title <> "" AndAlso mi.Author <> "" Then Exit For
                Next
            End If

            alMisNums.Remove("")
            alMisNums.Sort()

            If mi.Title = "" AndAlso titlesStr <> "" AndAlso alMisNums.Count > 0 Then   'Didn't get title from text files, get it from titles.str if it exists.
                With New Regex("(title|short)_" & alMisNums.Item(0) & ":\s*?""(.+?)""", RegexOptions.Multiline + RegexOptions.IgnoreCase)
                    If .IsMatch(titlesStr) Then
                        mi.Title = .Match(titlesStr).Groups(2).Value
                    End If
                End With
            End If

            mi.Title = mi.Title.Trim
            mi.Author = mi.Author.Trim

            Return mi
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Private Function GetNums(ByVal strIn As String) As String
        Dim sb As New System.Text.StringBuilder(strIn)
        For Each c As Char In strIn
            If Not Char.IsDigit(c) Then
                sb.Replace(c, "")
            End If
        Next
        Return sb.ToString
    End Function

    Private Function Rtf2Txt(ByVal strIn As String) As String
        Try
            If strIn.Contains("Schneesturm") Then Return "" 'this file locks up the RichTextBox.  Only file that does it.
            Dim rtb As New Windows.Forms.RichTextBox With {.Rtf = strIn}
            'Dim rtb As New RichTextBoxEx With {.Rtf = strIn}
            Return rtb.Text
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetZipEntryText(ByRef zs As SevenZipExtractor, ByRef entry As ArchiveFileInfo) As String
        Using ms As New MemoryStream
            zs.ExtractFile(entry.FileName, ms)
            Try
                GetZipEntryText = ASCII.GetString(ms.ToArray).Replace(Chr(0), "").Trim
            Catch ex As Exception
                GetZipEntryText = ex.Message
            End Try
        End Using
    End Function

    Private Function PatternExists(searchIn As Byte(), searchBytes As Byte(), Optional start As Integer = 0) As Boolean
        Dim found As Integer = -1
        'only look at this if we have a populated search array and search bytes with a sensible start
        If searchIn.Length > 0 AndAlso searchBytes.Length > 0 AndAlso start <= (searchIn.Length - searchBytes.Length) AndAlso searchIn.Length >= searchBytes.Length Then
            'iterate through the array to be searched
            For i As Integer = start To searchIn.Length - searchBytes.Length
                'if the start bytes match we will start comparing all other bytes
                If searchIn(i) = searchBytes(0) Then
                    If searchIn.Length > 1 Then
                        'multiple bytes to be searched we have to compare byte by byte
                        Dim matched As Boolean = True
                        For y As Integer = 1 To searchBytes.Length - 1
                            If searchIn(i + y) <> searchBytes(y) Then
                                matched = False
                                Exit For
                            End If
                        Next
                        'everything matched up
                        If matched Then
                            found = i
                            Exit For
                        End If
                    Else
                        'search byte is only one bit nothing else to do
                        found = i
                        'stop the loop
                        Exit For
                    End If
                End If
            Next
        End If
        Return found > -1
    End Function

    Function GetMD5(ByVal filePath As String)
        Dim md5 As New MD5CryptoServiceProvider
        Using f As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            md5.ComputeHash(f)
            f.Close()
        End Using

        Dim sb As New StringBuilder

        For Each hashByte As Byte In md5.Hash
            sb.Append(String.Format("{0:X2}", hashByte))
        Next

        Return sb.ToString
    End Function

End Module
