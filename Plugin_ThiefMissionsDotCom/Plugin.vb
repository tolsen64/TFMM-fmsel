Imports PluginContracts

Public Class Plugin
    Implements IPlugin

    Private _PluginWindow As UserControl = New UserControl

    Public ReadOnly Property PluginWindow As Windows.Forms.UserControl Implements IPlugin.PluginWindow
        Get
            Return _PluginWindow
        End Get
    End Property

    Public ReadOnly Property PluginName As String Implements IPlugin.PluginName
        Get
            Return "thiefmissions.com: Cheap Thief Missions"
        End Get
    End Property

    Public WriteOnly Property ExistingMissionList As List(Of String) Implements IPlugin.ExistingMissionList
        Set(value As List(Of String))
            _PluginWindow.ExistingMissions = value
        End Set
    End Property

    Public WriteOnly Property FMFolders As List(Of String) Implements IPlugin.FMFolders
        Set(value As List(Of String))
            _PluginWindow.FMFolders = value
        End Set
    End Property

    Public WriteOnly Property ParseMissionCallback As Action(Of String) Implements IPlugin.ParseMissionCallback
        Set(value As Action(Of String))
            _PluginWindow.ParseMissionCallback = value
        End Set
    End Property

    Public Sub HostShutdown() Implements IPlugin.HostShutdown

    End Sub

End Class
