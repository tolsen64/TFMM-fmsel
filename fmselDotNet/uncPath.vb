Imports System.Runtime.InteropServices
Imports System.ComponentModel

    Public Module uncPath

        Const UNIVERSAL_NAME_INFO_LEVEL = 1
        Const REMOTE_NAME_INFO_LEVEL = 2
        Const ERROR_MORE_DATA = 234
        Const NOERROR = 0

        <DllImport("mpr.dll", CharSet:=CharSet.Unicode)>
        Private Function WNetGetUniversalName(lpLocalPath As String, <MarshalAs(UnmanagedType.U4)> dwInfoLevel As Integer, lpBuffer As IntPtr, <MarshalAs(UnmanagedType.U4)> ByRef lpBufferSize As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        End Function

        Public Function GetUniversalName(localPath As String) As String
            ' The return value.
            Dim retVal As String = Nothing

            ' The pointer in memory to the structure.
            Dim buffer As IntPtr = IntPtr.Zero

            ' Wrap in a try/catch block for cleanup.
            Try
                ' First, call WNetGetUniversalName to get the size.
                Dim size As Integer = 0

                ' Make the call.
                ' Pass IntPtr.Size because the API doesn't like null, even though
                ' size is zero.  We know that IntPtr.Size will be
                ' aligned correctly.
                Dim apiRetVal As Integer = WNetGetUniversalName(localPath, UNIVERSAL_NAME_INFO_LEVEL, CType(IntPtr.Size, IntPtr), size)

                ' If the return value is not ERROR_MORE_DATA, then
                ' raise an exception.
                If apiRetVal <> ERROR_MORE_DATA Then
                    ' Throw an exception.
                    Return localPath
                    Throw New Win32Exception(apiRetVal)
                End If

                ' Allocate the memory.
                buffer = Marshal.AllocCoTaskMem(size)

                ' Now make the call.
                apiRetVal = WNetGetUniversalName(localPath, UNIVERSAL_NAME_INFO_LEVEL, buffer, size)

                ' If it didn't succeed, then throw.
                If apiRetVal <> NOERROR Then
                    ' Throw an exception.
                    Return localPath
                    Throw New Win32Exception(apiRetVal)
                End If

                ' Now get the string.  It's all in the same buffer, but
                ' the pointer is first, so offset the pointer by IntPtr.Size
                ' and pass to PtrToStringAnsi.
                retVal = Marshal.PtrToStringAuto(New IntPtr(buffer.ToInt64() + IntPtr.Size), size)
                retVal = retVal.Substring(0, retVal.IndexOf(ControlChars.NullChar))
            Finally
                ' Release the buffer.
                Marshal.FreeCoTaskMem(buffer)
            End Try

            ' First, allocate the memory for the structure.

            ' That's all folks.
            Return retVal
        End Function

    End Module