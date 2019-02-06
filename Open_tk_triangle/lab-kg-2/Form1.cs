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

namespace lab_kg_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics drawGraphics = Graphics.FromImage(bitmap);



            Pen pen = new Pen(Color.Black);

            Point[] points =
            {
                new Point(0, 10),
                new Point(10, 10),
                new Point(10, 0),
                new Point(0, 30),
                new Point(10, 30),
                new Point(10, 40),

                new Point(80, 10),
                new Point(70, 0),
                new Point(70, 10),
                new Point(80, 30),
                new Point(70, 30),
                new Point(70, 40)
            };


            GraphicsPath graph = new GraphicsPath();
            graph.AddPolygon(points);

            drawGraphics.DrawPath(pen, graph);
        }
    }
}
