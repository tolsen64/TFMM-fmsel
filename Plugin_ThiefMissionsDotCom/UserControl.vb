Imports System.Drawing
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO
Imports System.Linq

Public Class UserControl

    Private dt As DataTable
    Private dv As DataView
    Private WithEvents chkHideExistingMissions As New CheckBox With {.Text = "Hide Existing Missions", .BackColor = Color.Transparent}
    Private BaseUrl As String = "https://thiefmissions.com"

    Public Property ExistingMissions As List(Of String)
    Public Property FMFolders As List(Of String)
    Public ParseMissionCallback As Action(Of String)

    Private Sub UserControl_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim host As New ToolStripControlHost(chkHideExistingMissions)
        ToolStrip1.Items.Insert(5, host)

    End Sub

    Private Async Sub btnLoadAvailableMissions_Click(sender As Object, e As EventArgs) Handles btnLoadAvailableMissions.Click
        gridMissions.DataSource = Nothing
        lblRowCount.Text = "Downloading Mission List. Please wait..."
        lblFilteredRowCount.Text = ""

        Dim s As String = ""

        Using c As New WebClient
            Try
                s = Await c.DownloadStringTaskAsync($"{BaseUrl}/missions.desc")
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            End Try
        End Using

        dt = New DataTable
        dv = dt.DefaultView
        dt.Columns.Add("id", GetType(String))
        'dt.PrimaryKey = New DataColumn() {dt.Columns("id")}

        Dim lines As String() = s.Split(New Char() {vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim id As String = ""
        Dim ht As Hashtable = Nothing

        For Each line As String In lines
            line = line.Trim(New Char() {"#"c, " "c})
            If line.StartsWith("[") AndAlso line.EndsWith("]") Then
                If ht IsNot Nothing Then
                    Dim dr As DataRow = dt.NewRow
                    For Each key As String In ht.Keys
                        dr(key) = ht(key)
                    Next
                    If "|Shock 2|Thief Gold|Thief 2|Thief 3|".Contains($"|{dr("Game")}|") Then
                        dt.Rows.Add(dr)
                    End If
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

        gridMissions.DataSource = dv
        lblRowCount.Text = $"Available Mission Count: {dt.Rows.Count}"
        lblFilteredRowCount.Text = $"Visible Mission Count: {dv.Count}"
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged, chkHideExistingMissions.CheckedChanged
        If dt Is Nothing Then
            MsgBox("Load data first!")
            Return
        End If
        Dim RowFilter As String = ""
        If txtFilter.Text.Trim.Length > 0 Then
            Dim lst1 As New List(Of String)
            Dim lst2 As New List(Of String)
            Dim terms As String() = txtFilter.Text.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
            For Each c As DataColumn In dt.Columns
                lst1.Clear()
                For Each term As String In terms
                    lst1.Add($"[{c.ColumnName}] LIKE '%{term.Replace("'", "''")}%'")
                Next
                lst2.Add($"({String.Join(" AND ", lst1.ToArray)})")
            Next
            RowFilter = String.Join(" OR ", lst2.ToArray)
        End If
        If chkHideExistingMissions.Checked Then
            'Dim s1 As String = String.Join(",", ExistingMissions).Replace("'", "''").Replace(",", "','")
            Dim s1 As String = String.Join(",", ExistingMissions.Select(Function(s) $"'{s.Replace("'", "''")}'"))
            If RowFilter.Length > 0 Then
                RowFilter = $"({RowFilter}) AND ([FName] NOT IN ({s1}))"
            Else
                RowFilter = $"([FName] NOT IN ({s1}))"
            End If
        End If
        Debug.WriteLine(RowFilter)
        dv.RowFilter = RowFilter
        lblFilteredRowCount.Text = $"Visible Mission Count: {dv.Count}"
    End Sub

    Dim clickedRowId As String = ""

    Private Sub gridMissions_MouseDown(sender As Object, e As MouseEventArgs) Handles gridMissions.MouseDown
        If (e.Button = MouseButtons.Right) Then
            Dim hit As DataGridView.HitTestInfo = gridMissions.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                gridMissions.Rows(hit.RowIndex).Cells(hit.ColumnIndex).Selected = True
                clickedRowId = gridMissions.Rows(hit.RowIndex).Cells("id").Value.ToString()
            Else
                clickedRowId = ""
            End If
        End If
    End Sub

    Private Sub ViewMissionInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewMissionInfoToolStripMenuItem.Click
        Dim dr As DataRow = dt.Select($"[id] = '{clickedRowId.Replace("'", "''")}'")(0)
        Dim sb As New StringBuilder()
        For Each col As DataColumn In dt.Columns
            Dim s As String = dr(col.ColumnName).ToString
            If s.Length > 0 Then sb.AppendLine($"{col.ColumnName}: {s}")
        Next
        MsgBox(sb.ToString, Nothing, "Mission Info")
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        e.Cancel = gridMissions.Rows.Count = 0 OrElse clickedRowId.Length = 0
    End Sub

    Private Async Sub DownloadMissionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadMissionToolStripMenuItem.Click
        Dim rx As New Regex("""(?<url>/dl/.*?/(?<file>.*?))""")
        Try
            Using c As New WebClient()
                Dim s As String = Await c.DownloadStringTaskAsync($"{BaseUrl}/download.cgi?m={clickedRowId}")
                Debug.WriteLine(s)
                If rx.IsMatch(s) Then
                    Dim fldr As String = ""
                    Using dlg As New dlgChooseDownloadLocation(FMFolders)
                        If Not dlg.ShowDialog() = DialogResult.OK Then Return
                        fldr = dlg.SelectedLocation
                    End Using
                    lblDownloadProgress.Visible = True
                    progDownload.Value = 0
                    progDownload.Visible = True
                    AddHandler c.DownloadProgressChanged, AddressOf DownloadProgressChanged
                    AddHandler c.DownloadFileCompleted, AddressOf DownloadFileCompleted
                    Dim m As Match = rx.Match(s)
                    Await c.DownloadFileTaskAsync($"{BaseUrl}{m.Groups("url").Value}", Path.Combine(fldr, m.Groups("file").Value))
                    RemoveHandler c.DownloadProgressChanged, AddressOf DownloadProgressChanged
                    RemoveHandler c.DownloadFileCompleted, AddressOf DownloadFileCompleted
                    ParseMissionCallback(Path.Combine(fldr, m.Groups("file").Value))
                Else
                    MsgBox("Mission Not found on the server.", Nothing, "Can't download selected mission")
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, Nothing, "Can't download selected mission")
        End Try
    End Sub

    Private Sub DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        progDownload.Value = e.ProgressPercentage
    End Sub

    Private Sub DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs)
        MsgBox("Completed!", Nothing, "Download Status")
        lblDownloadProgress.Visible = False
        progDownload.Visible = False
    End Sub

    ' https://thiefmissions.com/download.cgi?m=ShortNightsWork&noredir=1

End Class
