Imports System.IO

Module FFMpeg

    Public Sub ConvertToWav(inputFile As FileInfo)
        Using p As New Process
            With p.StartInfo
                .FileName = AppPath & "\ffmpeg.exe"
                .Arguments = "-i """ & inputFile.FullName & """ """ & inputFile.FullName.Replace(inputFile.Extension, ".wav") & """"
                .CreateNoWindow = True
                .UseShellExecute = False
            End With
            p.Start()
            p.WaitForExit()
            inputFile.Delete()
        End Using
    End Sub

End Module
