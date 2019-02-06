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

namespace lab_7_1
{
    public partial class Form1 : Form
    {

        private Graphics graph;
        private Graphics graph1;
        private Pen pen;
        private Point point;
        private Point p3;
        private Point p4;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = this.CreateGraphics();

            for (var x = 50; x < 351; x += 5)
            {
                Thread.Sleep(20);
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    graph.FillRectangle(brush, x, 50, 3, 1);
                }
            }

            for (var y = 50; y < 251; y += 5)
            {
                Thread.Sleep(20);
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    graph.FillRectangle(brush, 350, y, 1, 3);
                }
            }

            for (var x = 350; x > 49; x -= 5)
            {
                Thread.Sleep(20);
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    graph.FillRectangle(brush, x, 250, 3, 1);
                }
            }

            for (var y = 250; y > 49; y -= 5)
            {
                Thread.Sleep(20);
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    graph.FillRectangle(brush, 50, y, 1, 3);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen bluePen = new Pen(Color.Aqua);
            graph = this.CreateGraphics();
            graph1 = this.CreateGraphics();
            Graphics g = this.CreateGraphics();
            Graphics g1 = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            Graphics gextra = this.CreateGraphics();
            p3 = Point.Empty;
            p4 = Point.Empty;

            p3.X = 100;
            p4.X = 300;

            graph.DrawLine(pen, 100, 50, 300,50);

            Parallel.Invoke(
                () =>
                {
                    for (var y = 50; y < 101; y+=1)
                    {
                        Thread.Sleep(30);
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            graph.FillRectangle(brush, 100, y, 1, 1);
                        }
                    }

                    g.DrawLine(pen, 100,100, 50,100);

                    for (var y = 100; y < 201; y += 1)
                    {
                        Thread.Sleep(30);
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            graph.FillRectangle(brush, 50, y, 1, 1);
                        }
                    }

                    g.DrawLine(pen, 50, 200, 100, 200);

                    for (var y = 200; y < 251; y += 1)
                    {
                        Thread.Sleep(30);
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            graph.FillRectangle(brush, 100, y, 1, 1);
                        }
                    }
                },

                () =>
                {
                    for (var y = 50; y < 101; y += 1)
                    {
                        Thread.Sleep(30);
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            graph1.FillRectangle(brush, 300, y, 1, 1);
                        }
                    }

                    g1.DrawLine(pen, 300, 100, 350, 100);

                    for (var y = 100; y < 201; y += 1)
                    {
                        Thread.Sleep(30);
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            graph1.FillRectangle(brush, 350, y, 1, 1);
                        }
                    }

                    g1.DrawLine(pen, 350, 200, 300, 200);

                    for (var y = 200; y < 251; y += 1)
                    {
                        Thread.Sleep(30);
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            graph1.FillRectangle(brush, 300, y, 1, 1);
                        }
                    }
                },

                () =>
                {
                    for (int i = 50; i < 251; i++)
                    {
                        Thread.Sleep(25);

                        p3.Y = i;
                        p4.Y = i;

                        if (p3.Y == 100 && p4.Y == 100)
                        {
                            p3.X = 50;
                            p4.X = 350;
                        }

                        if (p3.Y == 200 && p4.Y == 200)
                        {
                            p3.X = 100;
                            p4.X = 300;
                        }

                        g.DrawLine(bluePen, p3, p4);
                    }
                }

            );

            graph.DrawLine(pen, 100, 250, 300, 250);
        }
    }
}
