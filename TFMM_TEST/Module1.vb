Imports TFMM

Module Module1

    Sub Main()
        'Dim FMSelData As New sFMSelectorData
        'With FMSelData
        '    .sGameVersion = "Thief 2"
        'End With
        'Console.WriteLine(SelectFM(FMSelData))
        Dim si As New ProcessStartInfo
        Console.Write("Select Game [1-3, S]: ")
        Select Case Console.ReadKey.KeyChar
            Case "1"
                si.FileName = "Thief.exe"
                si.WorkingDirectory = "D:\Games\Thief GOLD"
            Case "2"
                si.FileName = "Thief2.exe"
                si.WorkingDirectory = "D:\Games\Thief 2 - The Metal Age"
            Case "3"
                si.FileName = "T3.exe"
                si.WorkingDirectory = "D:\Games\Thief - Deadly Shadows\System"
            Case "S", "s"
                si.FileName = "Shock2.exe"
                si.WorkingDirectory = "D:\Games\System Shock 2"
            Case Else
                Exit Sub
        End Select
        Process.Start(si)
    End Sub

End Module
