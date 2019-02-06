using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class polygram : Form
    {
        public polygram()
        {
            InitializeComponent();
        }

        private Graphics graph1;
        private Graphics graph2;

        private Pen redPen;
        private Pen bluePen;

        private Point p1;
        private Point p2;

        private Point p3;
        private Point p4;

        private int y_start = 50;
        private int y_end = 250;

        private double inc = 0;
        private double current = 255;

        private double inc1 = 0;
        private double current1 = 255;

        Point[] points =
        {
            new Point(60, 50),
            new Point(60, 100),
            new Point(10, 100),
            new Point(10, 200),
            new Point(60, 200),
            new Point(60, 250),

            new Point(360, 250),
            new Point(360, 200),
            new Point(410, 200),
            new Point(410, 100),
            new Point(360, 100),
            new Point(360, 50),
            new Point(60, 50)
        };

        private void polygram_Load(object sender, EventArgs e)
        {
            graph1 = this.CreateGraphics();
            graph2 = this.CreateGraphics();
            redPen = new Pen(Brushes.Red);
            bluePen = new Pen(Brushes.Blue);

            p1 = Point.Empty;
            p2 = Point.Empty;
            p3 = Point.Empty;
            p4 = Point.Empty;

            p1.X = 60;
            p2.X = 360;
            p3.X = 60;
            p4.X = 360;

            inc = 255 / 100;
            inc1 = 255 / 100;
        }

        private void polygram_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            graph.DrawPolygon(pen, points);

        }



        private void painting_Click(object sender, EventArgs e)
        {

            Parallel.Invoke(() =>
                {
                    for (int i = y_start; i < y_end; i++)
                    {
                        Thread.Sleep(100);
                        p1.Y = i;
                        p2.Y = i;

                        if (p1.Y == 100 && p2.Y == 100)
                        {
                            p1.X = 10;
                            p2.X = 410;
                        }

                        if (p1.Y == 200 && p2.Y == 200)
                        {
                            p1.X = 60;
                            p2.X = 360;
                        }

                        graph1.DrawLine(redPen, p1, p2);

                        if (current > 5)
                        {
                            current -= inc;
                            redPen.Color = Color.FromArgb((int)current, redPen.Color);
                        }
                        else
                        {
                            redPen.Color = Color.FromArgb(0, redPen.Color);
                        }
                    }

                },

                () =>
                {
                    for (int i = y_end; i > y_start; i--)
                    {
                        Thread.Sleep(100);
                        p3.Y = i;
                        p4.Y = i;

                        if (p3.Y == 200 && p4.Y == 200)
                        {
                            p3.X = 10;
                            p4.X = 410;
                        }

                        if (p3.Y == 100 && p4.Y == 100)
                        {
                            p3.X = 60;
                            p4.X = 360;
                        }

                        graph2.DrawLine(bluePen, p3, p4);

                        if (current1 > 5)
                        {
                            current1 -= inc1;
                            bluePen.Color = Color.FromArgb((int)current1, bluePen.Color);
                        }
                        else
                        {
                            bluePen.Color = Color.FromArgb((int)current1, bluePen.Color);
                        }
                    }
                }
            );
        }





        #region Move Control

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {

            int interval = Convert.ToInt32(textBox1.Text);

            for (int i = 0; i < points.Length; i++)
            {
                points[i].Y -= interval;
            }
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            int interval = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].Y += interval;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            int interval = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X += interval;
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            int interval = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X -= interval;
            }
        }







        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        #endregion

        #region other

        private void polygram_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
       

        #endregion


    }
}
