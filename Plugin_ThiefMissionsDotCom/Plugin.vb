Imports PluginContracts

Public Class Plugin
    Implements IPlugin

    Public ReadOnly Property PluginName As String Implements IPlugin.PluginName
        Get
            Return "thiefmissions.com: Cheap Thief Missions"
        End Get
    End Property

    Public Sub HostShutdown() Implements IPlugin.HostShutdown
        Throw New NotImplementedException()
    End Sub

    Public Function GetUserControl() As Windows.Forms.UserControl Implements IPlugin.GetUserControl
        Return New UserControl
    End Function
End Class
