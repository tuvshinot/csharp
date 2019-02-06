Public Class Form1

    Dim myPen As Pen
    Dim myPoints As Point() =
    {
                New Point(60, 50),
                New Point(60, 100),
                New Point(10, 100),
                New Point(10, 200),
                New Point(60, 200),
                New Point(60, 250),
                New Point(360, 250),
                New Point(360, 200),
                New Point(410, 200),
                New Point(410, 100),
                New Point(360, 100),
                New Point(360, 50),
                New Point(60, 50)
    }

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        myPen = New Pen(Drawing.Color.Blue, 5)
        Dim myGraphics As Graphics = Me.CreateGraphics
        myGraphics.DrawPolygon(myPen, myPoints)
    End Sub
End Class
