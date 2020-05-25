Imports System.Windows.Forms

Public Interface IPlugin

    ''' <summary>
    ''' The display name of the plugin
    ''' </summary>
    ReadOnly Property PluginName As String

    ''' <summary>
    ''' Returns an instance of the UserControl to the host.
    ''' </summary>
    Function GetUserControl() As UserControl

    ''' <summary>
    ''' Notify the plugin that the host is shutting down so that it can perform any necessary cleanup.
    ''' </summary>
    Sub HostShutdown()

End Interface