Imports System.IO

Module fmselCfg

    Public cfgFile As String = AppPath & "TFMM.cfg"
    Public lstFMDirs As New List(Of String)
    Public AlwaysStartAfterExit As Boolean = False
    Public ViewAllMissions As Boolean = False

    Public Sub SaveFMSelCfg()
        If File.Exists(cfgFile) Then File.Delete(cfgFile)
        Using sw As New StreamWriter(cfgFile)
            sw.WriteLine("AlwaysStartAfterExit=" & AlwaysStartAfterExit)
            sw.WriteLine("ViewAllMissions=" & ViewAllMissions)
            For Each s As String In lstFMDirs
                sw.WriteLine("FMDir=" & s)
            Next
            sw.Close()
        End Using
        LoadFMSelCfg()
    End Sub

    Public Sub LoadFMSelCfg()
        lstFMDirs.Clear()
        If File.Exists(cfgFile) Then
            Using sr As New StreamReader(cfgFile)
                Do Until sr.EndOfStream
                    Dim s As String() = sr.ReadLine.Split("="c)
                    If s.Length > 1 Then
                        Select Case s(0)
                            Case "AlwaysStartAfterExit"
                                AlwaysStartAfterExit = CBool(s(1))
                            Case "ViewAllMissions"
                                ViewAllMissions = CBool(s(1))
                            Case "FMDir"
                                lstFMDirs.Add(s(1))
                        End Select
                    End If
                Loop
            End Using
        End If
    End Sub

End Module
