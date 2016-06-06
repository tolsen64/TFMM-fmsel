Imports map = BoycoT.TFMM.MissionArchiveParser

Public Class SyncInfoEventArgs
    Inherits EventArgs
    Public Filename As String
    Public FileCount As Integer
    Public Index As Integer
    Public mi As map.MissionInfo
End Class
