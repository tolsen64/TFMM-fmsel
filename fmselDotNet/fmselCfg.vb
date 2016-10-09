Imports System.IO

Module fmselCfg

    Public cfgFile As String = Path.Combine(AppPath, "TFMM.cfg")
    Public lstFMDirs As New List(Of String)
    Public ReturnToTFMMDefault As Boolean = False
    Public MaxCashDefault As Boolean = False
    Public ViewAllMissions As Boolean = False
    Public SS2GameExe As String = ""
    Public T1GameExe As String = ""
    Public T2GameExe As String = ""
    Public T3GameExe As String = ""

    Public Sub SaveFMSelCfg()
        If File.Exists(cfgFile) Then File.Delete(cfgFile)
        Using sw As New StreamWriter(cfgFile)
            sw.WriteLine("ReturnToTFMMDefault=" & ReturnToTFMMDefault)
            sw.WriteLine("MaxCashDefault=" & MaxCashDefault)
            sw.WriteLine("ViewAllMissions=" & ViewAllMissions)
            sw.WriteLine("SS2GameExe=" & SS2GameExe)
            sw.WriteLine("T1GameExe=" & T1GameExe)
            sw.WriteLine("T2GameExe=" & T2GameExe)
            sw.WriteLine("T3GameExe=" & T3GameExe)
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
                            Case "ReturnToTFMMDefault" : ReturnToTFMMDefault = CBool(s(1))
                            Case "MaxCashDefault" : MaxCashDefault = CBool(s(1))
                            Case "ViewAllMissions" : ViewAllMissions = CBool(s(1))
                            Case "SS2GameExe" : SS2GameExe = CStr(s(1))
                            Case "T1GameExe" : T1GameExe = CStr(s(1))
                            Case "T2GameExe" : T2GameExe = CStr(s(1))
                            Case "T3GameExe" : T3GameExe = CStr(s(1))
                            Case "FMDir" : lstFMDirs.Add(s(1))
                        End Select
                    End If
                Loop
            End Using
        End If
    End Sub

End Module
