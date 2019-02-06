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

namespace lab1
{
    public partial class lab1Tri : Form
    {
        public lab1Tri()
        {
            InitializeComponent();
        }



        Graphics g;
        Graphics g1;
        Graphics g2;

        private Pen penGreen;
        private Pen penRed;
        private Pen penBlue;

        private PointF pGreen1;
        private PointF pGreen2;
        private PointF pRed1;
        private PointF pRed2;
        private PointF pBlue1;
        private PointF pBlue2;

        private int y_start = 50;
        private int y_length = 150;

        private double inc1 = 0;
        private double current1 = 255;
        private double inc2 = 0;
        private double current2 = 255;
        private double inc3 = 0;
        private double current3 = 255;


        private void Form1_Load(object sender, EventArgs e)
        {

            g = this.CreateGraphics();
            g1 = this.CreateGraphics();
            g2 = this.CreateGraphics();

            penGreen = new Pen(Brushes.Green);
            penRed = new Pen(Brushes.Red);
            penBlue = new Pen(Brushes.Blue);

            pRed1 = PointF.Empty;
            pRed2 = PointF.Empty;
            pGreen1 = PointF.Empty;
            pGreen2 = PointF.Empty;
            pBlue1 = PointF.Empty;
            pBlue2 = PointF.Empty;


            pRed1.X = 457.73f;
            pRed2.X = 457.73f;

            pGreen1.X = 400;
            pGreen2.X = 400;

            pBlue1.X = 342.27f;
            pBlue2.X = 342.27f;



            inc1 = 255 / 65;
            inc2 = 255 / 65;
            inc3 = 255 / 65;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(() =>
            
                {
                    for (int i = y_start; i <= y_length; i++)
                    {
                        Thread.Sleep(100);
                        pGreen1.Y = i;
                        pGreen2.Y = i;

                        pGreen1.X -= 0.5773f;
                        pGreen2.X += 0.5773f;

                        g.DrawLine(penGreen, pGreen1, pGreen2);

                        if (current1 > 0)
                        {
                            current1 -= inc1;
                            penGreen.Color = Color.FromArgb((int)current1, penGreen.Color);
                        }
                        else
                        {
                            penGreen.Color = Color.FromArgb(0, penGreen.Color);
                        }

                    }
                },
                () =>
                {
                    for (int i = y_length; i >= y_start; i--)
                    {
                        Thread.Sleep(100);
                        pRed1.Y = i;
                        pRed2.Y = 150;
                        pRed1.X -= 0.5773f;
                        pRed2.X -= 1.1546f;

                        g1.DrawLine(penRed, pRed1, pRed2);

                        if (current2 > 0)
                        {
                            current2 -= inc2;
                            penRed.Color = Color.FromArgb((int)current2, penRed.Color);
                        }
                        else
                        {
                            penRed.Color = Color.FromArgb(0, penRed.Color);
                        }
                    }
                },

                () =>
                {
                    for (int i = y_length; i >= y_start; i--)
                    {
                        Thread.Sleep(100);
                        pBlue1.Y = i;
                        pBlue2.Y = 150;
                        pBlue1.X += 0.5773f;
                        pBlue2.X += 1.1546f;

                        g2.DrawLine(penBlue, pBlue1, pBlue2);


                        if (current3 > 0)
                        {
                            current3 -= inc3;
                            penBlue.Color = Color.FromArgb((int)current3, penBlue.Color);
                        }
                        else
                        {
                            penBlue.Color = Color.FromArgb(0, penBlue.Color);
                        }
                    }
                }
            );
        }
    }
}
