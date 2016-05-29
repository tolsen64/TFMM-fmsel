Imports TFMM

Module Module1

    Sub Main()
        Dim FMSelData As New sFMSelectorData
        With FMSelData
            .sGameVersion = "Thief 2"
        End With
        Console.WriteLine(SelectFM(FMSelData))
    End Sub

End Module
