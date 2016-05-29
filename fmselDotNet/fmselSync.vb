Imports System.Data
Imports System.IO
Imports map = BoycoT.TFMM.MissionArchiveParser

Module fmselSync
    'TODO: Rewrite as class which contains everything needed for updating the database.
    '       Add event to update main grid if program is still running.

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
                               FMArchives.AddRange(New DirectoryInfo(fmdir).GetFiles("*.zip", SearchOption.AllDirectories))
                           Next

                           For i As Integer = 0 To FMArchives.Count - 1
                               If Not FileList.Contains(FMArchives(i).Name) Then
                                   RaiseEvent SyncInfo(Nothing, New SyncInfoEventArgs With {.FileCount = FMArchives.Count, .Filename = FMArchives(i).Name, .Index = i - 1})
                                   Dim mi As map.MissionInfo = map.ParseMissionArchive(FMArchives(i).FullName)
                                   If Not HashList.Contains(mi.MD5) Then
                                       InsertNewMissionFile(mi)
                                       Dim dr As DataRow = dtMissions.NewRow
                                       dr("Filename") = mi.ArchiveFile.Name
                                       dr("FileSize") = mi.ArchiveFile.Length
                                       dr("MissionName") = mi.Title
                                       dr("Author") = mi.Author
                                       dr("ReleaseDate") = mi.ReleaseDate
                                       dr("Directory") = mi.ArchiveFile.DirectoryName
                                       dr("InstallFolder") = mi.InstallDirName
                                       dtMissions.Rows.Add(dr)
                                       dtMissions.AcceptChanges()
                                   End If
                               End If
                               RaiseEvent SyncInfo(Nothing, New SyncInfoEventArgs With {.FileCount = FMArchives.Count, .Filename = FMArchives(i).Name, .Index = i})
                           Next
                       End Sub)
    End Sub

End Module
