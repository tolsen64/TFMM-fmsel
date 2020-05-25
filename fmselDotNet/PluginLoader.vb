'/*
'   Copyright 2013 Christoph Gattnar

'   Licensed under the Apache License, Version 2.0 (the "License");
'   you may Not use this file except In compliance With the License.
'   You may obtain a copy Of the License at

'	   http://www.apache.org/licenses/LICENSE-2.0

'   Unless required by applicable law Or agreed To In writing, software
'   distributed under the License Is distributed On an "AS IS" BASIS,
'   WITHOUT WARRANTIES Or CONDITIONS Of ANY KIND, either express Or implied.
'   See the License For the specific language governing permissions And
'   limitations under the License.
'
'   Converted to VB and modified from original code by Terry Olsen
'
'*/

Imports System.IO
Imports System.Reflection

Public Class PluginLoader(Of T)

    Public Shared Function LoadPlugins(PluginFolder As String, PluginDescription As String) As ICollection(Of T)
        Dim dllFileNames As String() = Nothing

        If Directory.Exists(PluginFolder) Then
            dllFileNames = Directory.GetFiles(PluginFolder, "*.dll")
            Dim assemblies As ICollection(Of Assembly) = New List(Of Assembly)(dllFileNames.Length)

            For Each dllFile As String In dllFileNames
                Dim fvi As FileVersionInfo = FileVersionInfo.GetVersionInfo(dllFile)

                If fvi.Comments = PluginDescription Then
                    Dim an As AssemblyName = AssemblyName.GetAssemblyName(dllFile)
                    Dim assembly As Assembly = Assembly.Load(an)
                    assemblies.Add(assembly)
                End If
            Next

            Dim pluginType As Type = GetType(T)
            Dim pluginTypes As ICollection(Of Type) = New List(Of Type)()

            For Each assembly As Assembly In assemblies

                If assembly IsNot Nothing Then
                    Dim types As Type() = assembly.GetTypes()

                    For Each type As Type In types

                        If type.IsInterface OrElse type.IsAbstract Then
                            Continue For
                        Else

                            If type.GetInterface(pluginType.FullName) IsNot Nothing Then
                                pluginTypes.Add(type)
                            End If
                        End If
                    Next
                End If
            Next

            Dim plugins As ICollection(Of T) = New List(Of T)(pluginTypes.Count)

            For Each type As Type In pluginTypes
                Dim plugin As T = CType(Activator.CreateInstance(type), T)
                plugins.Add(plugin)
            Next

            Return plugins
        End If

        Return Nothing
    End Function

End Class
