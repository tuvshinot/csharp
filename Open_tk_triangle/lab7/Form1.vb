Public Class Form1
    Dim side As String
    Dim angle As Integer = 0
    Dim i As Integer = 0

    Dim myPen As Pen
    Dim Points As Point() = {}
    Dim myPoint2x As Point() =
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
    Dim myPoint1x As Point() =
            {
                New Point(60, 50),
                New Point(60, 75),
                New Point(35, 75),
                New Point(35, 125),
                New Point(60, 125),
                New Point(60, 150),
                New Point(210, 150),
                New Point(210, 125),
                New Point(235, 125),
                New Point(235, 75),
                New Point(210, 75),
                New Point(210, 50),
                New Point(60, 50)
            }

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("1x")
        ComboBox1.Items.Add("2x")
        ComboBox1.SelectedItem = ComboBox1.Items.Item(0)
    End Sub
    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        Me.Invalidate()
        If ComboBox1.Text$ = "1x" Then
            Points = myPoint1x
        ElseIf ComboBox1.Text$ = "2x" Then
            Points = myPoint2x
        End If
    End Sub
    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            side = "left"
            Timer1.Start()
        End If
    End Sub
    Private Sub Button2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            side = "right"
            Timer1.Start()
        End If
    End Sub
    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp
        Timer1.Stop()
    End Sub
    Private Sub Button2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseUp
        Timer1.Stop()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If side = "left" Then
            i = i - 1
        ElseIf side = "right" Then
            i = i + 1
        End If
        Me.Invalidate()
        angle = i
    End Sub
    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        e.Graphics.RotateTransform(angle)
        e.Graphics.TranslateTransform(Me.ClientSize.Width / 2, Me.ClientSize.Height / 2, Drawing2D.MatrixOrder.Append)
        myPen = New Pen(Drawing.Color.Blue, 5)
        e.Graphics.DrawPolygon(myPen, Points)

    End Sub

End Class


