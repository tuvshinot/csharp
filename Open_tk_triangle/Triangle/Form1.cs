using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class DrawingForm : Form
    {
        public DrawingForm()
        {
            InitializeComponent();
        }

        Graphics g;
        Pen p;

        private Point p1;
        private Point p2;
        private int y_start = 100;
        private int y_length = 400;

        private double inc = 0;
        private double current = 255;


        private void DrawingForm_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            p = new Pen(Brushes.Black);


            p1 = Point.Empty;
            p2 = Point.Empty;

            p1.X = 200;
            p2.X = 500;

            inc = 255 / (double) y_length;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = y_start; i < y_start + y_length; i++)
            {
                p1.Y = i;
                p2.Y = i;

                g.DrawLine(p, p1, p2);

                p.Color = Color.FromArgb((int) current, p.Color);
                current -= inc;
            }

            MessageBox.Show("tan : 60 ----" + Math.Sin(60));
        }

        private void DrawingForm_Paint(object sender, PaintEventArgs e)
        {
        }

    }
}
