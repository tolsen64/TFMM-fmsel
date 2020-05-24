Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class RichTextBoxEx
    Inherits RichTextBox

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function LoadLibrary(ByVal lpFileName As String) As IntPtr
    End Function

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim lResult As IntPtr = LoadLibrary("msftedit.dll")
            If lResult = IntPtr.Zero Then
                MessageBox.Show(Marshal.GetLastWin32Error().ToString())
            End If
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassName = "RICHEDIT60W"
            Return cp
        End Get
    End Property
End Class
