Imports System.Data
Imports System.IO
Imports map = BoycoT.TFMM.MissionArchiveParser

Module fmselSync

    Public Event SyncInfo(sender As Object, e As EventArgs)

    Public Async Sub SyncMissionFolders()
        Await Task.Run(Sub()
                           Dim FileHashList As DataTable = GetFileHashListFromDb()
                           Dim FileList As New List(Of String)
                           Dim HashList As New List(Of String)
                           Dim FMDirs As List(Of String) = lstFMDirs
                           Dim FMArchives As New List(Of FileInfo)

                           For Each dr As DataRow In FileHashList.Rows
                               FileList.Add(dr("Filename").ToString.Trim)
                               HashList.Add(dr("Hash").ToString.Trim)
                           Next
                           FileList.Sort()
                           HashList.Sort()

                           For Each fmdir As String In FMDirs
                               FMArchives.AddRange(New DirectoryInfo(fmdir).GetFilesByExtensions(".zip", ".7z", ".rar"))
                           Next

                           For i As Integer = 0 To FMArchives.Count - 1
                               If Not FileList.Contains(FMArchives(i).Name) Then
                                   RaiseEvent SyncInfo(Nothing, New SyncInfoEventArgs With {.FileCount = FMArchives.Count, .Filename = FMArchives(i).Name, .Index = i - 1, .mi = Nothing})
                                   Dim mi As map.MissionInfo = map.ParseMissionArchive(FMArchives(i).FullName)
                                   If Not HashList.Contains(mi.MD5) Then
                                       InsertNewMissionFile(mi)
                                       RaiseEvent SyncInfo(Nothing, New SyncInfoEventArgs With {.FileCount = FMArchives.Count, .Filename = FMArchives(i).Name, .Index = i, .mi = mi})
                                   End If
                               End If
                               RaiseEvent SyncInfo(Nothing, New SyncInfoEventArgs With {.FileCount = FMArchives.Count, .Filename = FMArchives(i).Name, .Index = i})
                           Next
                       End Sub)
    End Sub

    Public Async Function ParseMissionFile(filename As String) As Task(Of map.MissionInfo)
        Debug.WriteLine("ParseMissionFile: " & filename)
        Dim FileHashList As DataTable = Await Task.Run(Function() GetFileHashListFromDb()).ConfigureAwait(False)

        Dim HashList As New List(Of String)

        For Each dr As DataRow In FileHashList.Rows
            HashList.Add(dr("Hash").ToString.Trim)
        Next
        HashList.Sort()

        Dim mi As map.MissionInfo = Await Task.Run(Function() map.ParseMissionArchive(filename))

        If HashList.Contains(mi.MD5) Then
            Dim ExistingFileName = FileHashList.AsEnumerable.Where(Function(row) row("Hash").ToString = mi.MD5).Select(Function(row) row("Filename"))(0)
            mi.Title = $"Mission already exists as {ExistingFileName}"
        Else
            Await Task.Run(Sub() InsertNewMissionFile(mi))
        End If

        Return mi

        'Await Task.Run(Sub()
        '                   Dim FileHashList As DataTable = GetFileHashListFromDb()
        '                   Dim HashList As New List(Of String)

        '                   For Each dr As DataRow In FileHashList.Rows
        '                       HashList.Add(dr("Hash").ToString.Trim)
        '                   Next
        '                   HashList.Sort()

        '                   Dim mi As map.MissionInfo = map.ParseMissionArchive(filename)

        '                   If Not HashList.Contains(mi.MD5) Then
        '                       InsertNewMissionFile(mi)
        '                   End If
        '               End Sub)
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function GetFilesByExtensions(dir As DirectoryInfo, ParamArray extensions As String()) As IEnumerable(Of FileInfo)
        If extensions Is Nothing Then
            Throw New ArgumentNullException("extensions")
        End If
        Dim files As IEnumerable(Of FileInfo) = dir.EnumerateFiles()
        Return files.Where(Function(f) extensions.Contains(f.Extension))
    End Function

End Module
