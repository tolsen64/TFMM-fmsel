Imports System.Windows.Forms

Public Interface IPlugin

    ''' <summary>
    ''' Returns an instance of the UserControl to the host.
    ''' </summary>
    ReadOnly Property PluginWindow As UserControl

    ''' <summary>
    ''' The display name of the plugin.
    ''' </summary>
    ReadOnly Property PluginName As String

    ''' <summary>
    ''' List of existing mission filenames for use by the plugin.
    ''' </summary>
    WriteOnly Property ExistingMissionList As List(Of String)

    ''' <summary>
    ''' List of mission folders for use by the plugin.
    ''' </summary>
    WriteOnly Property FMFolders As List(Of String)

    ''' <summary>
    ''' Plugin can call this to parse a mission file.
    ''' </summary>
    WriteOnly Property ParseMissionCallback As Action(Of String)

    ''' <summary>
    ''' Notify the plugin that the host is shutting down so that it can perform any necessary cleanup.
    ''' </summary>
    Sub HostShutdown()

End Interface