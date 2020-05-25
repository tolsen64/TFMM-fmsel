Imports System.Runtime.InteropServices
Imports System.Text.Encoding
Imports System.IO
Imports System.Reflection

Public Module fmsel

    Private FMSelData As sFMSelectorData

    Public Enum eFMSelReturn
        kSelFMRet_OK = 0        ' run selected FM 'data->sName' (0-len string to run without an FM)
        kSelFMRet_Cancel = -1   ' cancel FM selection And start game As-Is (no FM Or If defined In cam_mod.ini use that)
        kSelFMRet_ExitGame = 1  ' abort And quit game
    End Enum

    <StructLayout(LayoutKind.Sequential, Pack:=4, CharSet:=CharSet.Ansi)>
    Public Structure sFMSelectorData
        Public nStructSize As Integer

        Public sGameVersion As String

        ' supplied initial FM root path (the FM Selector may change this)
        Public sRootPath As IntPtr
        Public nMaxRootLen As Integer

        ' buffer to copy the selected FM name
        Public sName As IntPtr
        Public nMaxNameLen As Integer

        ' set to non-zero when selector Is invoked after game exit (if requested during game start)
        Public bExitedGame As Integer
        ' FM selector should set this to non-zero if it wants to be invoked after game exits (only done for FMs)
        Public bRunAfterGame As Integer

        ' optional list of paths to exclude from mod_path/uber_mod_path in + separated format And Like the config
        ' vars, Or if "*" all Mod paths are excluded (leave buffer empty for no excludes)
        ' the specified exclude paths work as if they had a "*\" wildcard prefix
        Public sModExcludePaths As IntPtr
        Public nMaxModExcludeLen As Integer

        Public sLanguage As IntPtr
        Public nLanguageLen As Integer
        Public bForceLanguage As Integer
    End Structure

    <DllExport(CallingConvention:=CallingConvention.Cdecl, ExportName:="SelectFM")>
    Public Function SelectFM(ByRef data As sFMSelectorData) As Int32
        FMSelData = data

        ' Our form must be opened in a separate thread set to Single-Threaded Apartment state.
        ' this is necessary for common dialogs and DragDrop operations to function.
        With New Threading.Thread(AddressOf ShowMainWindow)
            .SetApartmentState(Threading.ApartmentState.STA)
            .Start()
            .Join()  'blocks the calling thread until thd exits.
        End With

        data = FMSelData
        Return FMSelReturnValue
    End Function

    Private Sub ShowMainWindow()
        ' This is necessary when our DLL is not installed in the same folder as the game.
        If AppPath <> GamePath Then
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve
        End If
        'AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
        With New frmMain
            .ShowDialog()
        End With
    End Sub

    Private Function CurrentDomain_AssemblyResolve(sender As Object, args As ResolveEventArgs) As Assembly
        Dim AssemblyName As String = Path.Combine(AppPath, args.Name.Split(","c)(0) & ".dll")
        Dim fi As New FileInfo(AssemblyName)
        If fi.Exists Then
            Return Assembly.LoadFrom(AssemblyName)
        Else
            Return Nothing
        End If
    End Function

    Private Sub CurrentDomain_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex As Exception = CType(e.ExceptionObject, Exception).GetBaseException
        If e.IsTerminating Then
            MsgBox("IsTerminating: " & e.IsTerminating.ToString & vbCrLf & vbCrLf & "Message: " & ex.Message & vbCrLf & vbCrLf & "Source: " & ex.Source & vbCrLf & vbCrLf & "Stack: " & ex.StackTrace)
        End If
    End Sub

#Region "Properties"

    ''' <summary>
    ''' Returns the path of this dll.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property AppPath As String
        Get
            Return My.Application.Info.DirectoryPath
        End Get
    End Property

    ''' <summary>
    ''' Returns the path of the currently running game.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GamePath As String
        Get
            Return AppDomain.CurrentDomain.BaseDirectory
        End Get
    End Property

    ''' <summary>
    ''' 0 = Run selected fan mission. 1 = abort game and quit. -1 = Cancel fan mission and run original missions.
    ''' </summary>
    ''' <returns></returns>
    Public Property FMSelReturnValue As eFMSelReturn = eFMSelReturn.kSelFMRet_ExitGame

    Public Property SelectedFM As String
        Get
            Return Marshal.PtrToStringAnsi(FMSelData.sName)
        End Get
        Set(value As String)
            Dim sName As Byte() = ASCII.GetBytes(value & Chr(0))   'folder name of mission to play
            Marshal.Copy(sName, 0, FMSelData.sName, sName.Length)
        End Set
    End Property

    ''' <summary>
    ''' The game version as it is supplied from the game.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GameVersionRaw As String
        Get
            Return FMSelData.sGameVersion
        End Get
    End Property

    ''' <summary>
    ''' The game version string.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GameVersion As String
        Get
            If FMSelData.sGameVersion.StartsWith("System Shock 2") Then
                Return "SS2"
            ElseIf FMSelData.sGameVersion.StartsWith("Thief 3") Then
                Return "T3"
            ElseIf FMSelData.sGameVersion.StartsWith("Thief 2") Then
                If File.Exists(Path.Combine(GamePath, "DARKINST.CFG")) Then
                    Return "T2"
                Else
                    Return "T1"
                End If
            Else
                Return "Unk"
            End If
        End Get
    End Property

    ''' <summary>
    ''' The Game Name, of course.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GameName As String
        Get
            Select Case GameVersion
                Case "SS2" : GameName = "System Shock 2"
                Case "T1" : GameName = "Thief 1/Gold"
                Case "T2" : GameName = "Thief 2"
                Case "T3" : GameName = "Thief 3"
                Case Else : GameName = "Unk"
            End Select
        End Get
    End Property

    ''' <summary>
    ''' The fan mission root path.
    ''' </summary>
    ''' <returns></returns>
    Public Property FMRootPath As String
        Get
            If Not IsDebug Then
                Dim s = Marshal.PtrToStringAnsi(FMSelData.sRootPath).Trim
                If s = "" Then Return Path.Combine(GamePath, "FMs")
                If s.StartsWith(".") Then Return Path.Combine(GamePath, s.TrimStart("."c))
                If Not s.Contains(":") Then Return Path.Combine(GamePath, s)
                Return s
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            If Not IsDebug Then
                Dim tmp As Byte() = ASCII.GetBytes(value)
                Marshal.Copy(tmp, 0, FMSelData.sRootPath, tmp.Length)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Maximum length allowed in FMRootPath property.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property FMRootPathMaxLen As Integer
        Get
            Return FMSelData.nMaxRootLen
        End Get
    End Property

    ''' <summary>
    ''' The selected fan mission folder name.
    ''' </summary>
    ''' <returns></returns>
    Public Property FMFolderName As String
        Get
            Return Marshal.PtrToStringAnsi(FMSelData.sName)
        End Get
        Set(value As String)
            Dim tmp As Byte() = ASCII.GetBytes(value)
            Marshal.Copy(tmp, 0, FMSelData.sName, tmp.Length)
        End Set
    End Property

    ''' <summary>
    ''' Maximum length allowed in FMFolderName property.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property FMFolderNameMaxLen As Integer
        Get
            Return FMSelData.nMaxNameLen
        End Get
    End Property

    ''' <summary>
    ''' True when Fan Mission Selector is invoked at game exit.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GameExited As Boolean
        Get
            Return FMSelData.bExitedGame <> 0
        End Get
    End Property

    ''' <summary>
    ''' True if requesting Fan Mission Selector to be invoked at game exit.
    ''' </summary>
    ''' <returns></returns>
    Public Property RunAfterGameExit As Boolean
        Get
            Return (FMSelData.bRunAfterGame <> 0)
        End Get
        Set(value As Boolean)
            FMSelData.bRunAfterGame = If(value, 1, 0)
        End Set
    End Property

    ''' <summary>
    ''' Optional list of paths to exclude from mod_path/uber_mod_path in '+' delimited format, or '*' if all mod paths are to be excluded, or '' if no excludes.
    ''' </summary>
    ''' <returns></returns>
    Public Property ModExcludePaths As String
        Get
            Return Marshal.PtrToStringAnsi(FMSelData.sModExcludePaths)
        End Get
        Set(value As String)
            Dim tmp As Byte() = ASCII.GetBytes(value)
            Marshal.Copy(tmp, 0, FMSelData.sModExcludePaths, tmp.Length)
        End Set
    End Property

    ''' <summary>
    ''' Maximum length allowed in ModExcludePaths property.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ModExcludePathsMaxLength As Integer
        Get
            Return FMSelData.nMaxModExcludeLen
        End Get
    End Property

    ''' <summary>
    ''' The language to use for the fan mission (must be supported by the fan mission). Leave empty if no language resources exist in the fan mission.
    ''' </summary>
    ''' <returns></returns>
    Public Property FMLanguage As String
        Get
            Return Marshal.PtrToStringAnsi(FMSelData.sLanguage)
        End Get
        Set(value As String)
            Dim tmp As Byte() = ASCII.GetBytes(value)
            Marshal.Copy(tmp, 0, FMSelData.sLanguage, tmp.Length)
        End Set
    End Property

    ''' <summary>
    ''' Maximum length allowed in FMLanguage property.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property FMLanguageMaxLen As Integer
        Get
            Return FMSelData.nLanguageLen
        End Get
    End Property

    ''' <summary>
    ''' True if the language specified by FMLanguage is to be forced even if it differs from the game's current language.
    ''' </summary>
    ''' <returns></returns>
    Public Property ForceFMLanguage As Boolean
        Get
            Return FMSelData.bForceLanguage <> 0
        End Get
        Set(value As Boolean)
            FMSelData.bForceLanguage = If(value, 1, 0)
        End Set
    End Property

    Public Property IsDebug As Boolean = False

#End Region

End Module
