Imports System.Net
Imports System.IO
Imports System.Linq

Public Class UserControl

    Private Async Sub btnLoadAvailableMissions_Click(sender As Object, e As EventArgs) Handles btnLoadAvailableMissions.Click
        gridMissions.DataSource = Nothing
        lblRowCount.Text = ""

        Dim s As String = ""

        Using c As New WebClient
            s = Await c.DownloadStringTaskAsync("https://thiefmissions.com/missions.desc")
        End Using

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(String))
        'dt.PrimaryKey = New DataColumn() {dt.Columns("id")}

        Dim lines As String() = s.Split(New Char() {vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim id As String = ""
        Dim ht As Hashtable = Nothing

        For Each line As String In lines
            line = line.Trim(New Char() {"#"c, " "c})
            Debug.WriteLine(line)
            If line.StartsWith("[") AndAlso line.EndsWith("]") Then
                If ht IsNot Nothing Then
                    Dim dr As DataRow = dt.NewRow
                    For Each key As String In ht.Keys
                        dr(key) = ht(key)
                    Next
                    dt.Rows.Add(dr)
                End If
                ht = Nothing
                id = line.Trim(New Char() {"["c, "]"c, " "c})
                If id.Length > 0 Then
                    ht = New Hashtable
                    ht.Add("id", id)
                End If
            ElseIf line.Contains("=") AndAlso id.Length > 0 Then
                Dim prop As String() = line.Split(New Char() {"="c})
                Dim key As String = prop(0).Trim
                Dim val As String = prop(1).Trim
                If ht.ContainsKey(key) Then
                    ht(key) &= val & ", "
                Else
                    ht.Add(key, val)
                End If
                If Not dt.Columns.Contains(key) Then dt.Columns.Add(key)
            End If
        Next

        gridMissions.DataSource = dt
        lblRowCount.Text = $"Available Mission Count: {dt.Rows.Count}"
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged

    End Sub

End Class
