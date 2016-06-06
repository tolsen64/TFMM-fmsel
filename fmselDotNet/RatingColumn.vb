Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class RatingColumn
    Inherits DataGridViewImageColumn
    Public Sub New()
        Me.CellTemplate = New RatingCell()
        Me.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.ValueType = GetType(Integer)
    End Sub
End Class

Public Class RatingCell
        Inherits DataGridViewImageCell
        Public Sub New()
            ' Value type is an integer. 
            ' Formatted value type is an image since we derive from the ImageCell 
            Me.ValueType = GetType(Integer)
        End Sub

        Protected Overrides Function GetFormattedValue(value As Object, rowIndex As Integer, ByRef cellStyle As DataGridViewCellStyle, valueTypeConverter As TypeConverter, formattedValueTypeConverter As TypeConverter, context As DataGridViewDataErrorContexts) As Object
            ' Convert integer to star images 
            Return starImages(CInt(value))
        End Function

        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            ' default new row to 3 stars 
            Get
                Return 3
            End Get
        End Property

        Protected Overrides Sub Paint(graphics As Graphics, clipBounds As Rectangle, cellBounds As Rectangle, rowIndex As Integer, elementState As DataGridViewElementStates, value As Object,
            formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)
            Dim cellImage As Image = DirectCast(formattedValue, Image)

            Dim starNumber As Integer = GetStarFromMouse(cellBounds, Me.DataGridView.PointToClient(Control.MousePosition))

            If starNumber <> -1 Then
                cellImage = starHotImages(starNumber)
            End If

            ' surpress painting of selection 
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value,
                cellImage, errorText, cellStyle, advancedBorderStyle, (paintParts And Not DataGridViewPaintParts.SelectionBackground))
        End Sub

        ' Update cell's value when the user clicks on a star 
        Protected Overrides Sub OnContentClick(e As DataGridViewCellEventArgs)
            MyBase.OnContentClick(e)
            Dim starNumber As Integer = GetStarFromMouse(Me.DataGridView.GetCellDisplayRectangle(Me.DataGridView.CurrentCellAddress.X, Me.DataGridView.CurrentCellAddress.Y, False), Me.DataGridView.PointToClient(Control.MousePosition))

            If starNumber <> -1 Then
                Me.Value = starNumber
            End If
        End Sub

#Region "Invalidate cells when mouse moves or leaves the cell"
        Protected Overrides Sub OnMouseLeave(rowIndex As Integer)
            MyBase.OnMouseLeave(rowIndex)
            Me.DataGridView.InvalidateCell(Me)
        End Sub
        Protected Overrides Sub OnMouseMove(e As DataGridViewCellMouseEventArgs)
            MyBase.OnMouseMove(e)
            Me.DataGridView.InvalidateCell(Me)
        End Sub
#End Region

#Region "Private Implementation"
        Shared starImages As Image()
        Shared starHotImages As Image()
        Const IMAGEWIDTH As Integer = 58

        Private Function GetStarFromMouse(cellBounds As Rectangle, mouseLocation As Point) As Integer
            If cellBounds.Contains(mouseLocation) Then

                Dim mouseXRelativeToCell As Integer = (mouseLocation.X - cellBounds.X)
                Dim imageXArea As Integer = (cellBounds.Width / 2) - (IMAGEWIDTH \ 2)
                If ((mouseXRelativeToCell + 4) < imageXArea) OrElse (mouseXRelativeToCell >= (imageXArea + IMAGEWIDTH)) Then
                    Return -1
                Else
                    Dim oo As Integer = CInt(Math.Truncate(Math.Round(((CSng(mouseXRelativeToCell - imageXArea + 5) / CSng(IMAGEWIDTH)) * 5.0F), MidpointRounding.AwayFromZero)))
                    If oo > 5 OrElse oo < 0 Then
                        System.Diagnostics.Debugger.Break()
                    End If
                    Return oo
                End If
            Else
                Return -1
            End If
        End Function
        ' setup star images 
#Region "Load star images"
        Shared Sub New()
            starImages = New Image(5) {}
            starHotImages = New Image(5) {}
            ' load normal stars 
            starImages(0) = DirectCast(My.Resources.star0, Image)
            starImages(1) = DirectCast(My.Resources.star1, Image)
            starImages(2) = DirectCast(My.Resources.star2, Image)
            starImages(3) = DirectCast(My.Resources.star3, Image)
            starImages(4) = DirectCast(My.Resources.star4, Image)
            starImages(5) = DirectCast(My.Resources.star5, Image)

            ' load hot normal stars 
            starHotImages(0) = DirectCast(My.Resources.starhot0, Image)
            starHotImages(1) = DirectCast(My.Resources.starhot1, Image)
            starHotImages(2) = DirectCast(My.Resources.starhot2, Image)
            starHotImages(3) = DirectCast(My.Resources.starhot3, Image)
            starHotImages(4) = DirectCast(My.Resources.starhot4, Image)
            starHotImages(5) = DirectCast(My.Resources.starhot5, Image)
        End Sub
#End Region

#End Region

    End Class
