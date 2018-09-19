using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Parallelogram.Helpers;

namespace Parallelogram
{
    public partial class Form1 : Form
    {
        private List<Point> Points;
        private bool isDragable;
        private int selectedPoint;

        public Form1()
        {
            Points = new List<Point>();
            isDragable = false;
            InitializeComponent();
        }

        private void DrawDotAndSetPoint(int x,int y)
        {
            var point = new Point
            {
                X = x,
                Y = y
            };
            Points.Add(point);
            var dot = new Dot(point);
            dot.Draw(ref mainBoard);
        }

        private void mainBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if ((Points?.Count() ?? 0) < 2)
            {
                DrawDotAndSetPoint(e.X, e.Y);
            }
            else if((Points?.Count() ?? 0) == 2)
            {
                DrawDotAndSetPoint(e.X, e.Y);

                DrawParallelogram();
            }
            else
            {
                isDragable = false;
            }
        }

        private void DrawParallelogram()
        {
            Parallelogram parallelogram = new Parallelogram(Points);
            parallelogram.Draw(ref mainBoard);
        }

        private void mainBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragable)
            {
                Points[selectedPoint] = new Point
                {
                    X = e.X,
                    Y = e.Y
                };
                DrawParallelogram();
            }
            label1.Text = $"isDragable: {isDragable} \n selectedPoint: {selectedPoint} ";
        }

        private void mainBoard_MouseDown(object sender, MouseEventArgs e)
        {
            const int toRound= 20;
            if ((Points?.Count()?? 0) >2)
            {
                var point = new Point
                {
                    X = RoundTo(e.X, toRound),
                    Y = RoundTo(e.Y, toRound)
                };
                for (var i = 0; i < 3; i++)
                {
                    var x = RoundTo(Points[i].X, toRound);
                    var y = RoundTo(Points[i].Y, toRound);
                    if (point.X == x && point.Y == y)
                    {
                        isDragable = true;
                        selectedPoint = i;
                        break;
                    }
                    else
                    {
                        isDragable = false;
                        selectedPoint = 0;
                    }
                }
            }
        }





        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MAjidH1
            //
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/majidh1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First, for each click within the specified range, a point is inserted, which is drawn after three clicks of an equilateral trapezoid, with a circle in its center. \n You can change the points by dragging and dropping the points. , Which causes the shape to change at the moment of the form, and always the circle remains in the center of the shape.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ابتدا به ازای هر کلیک در محدوده مشخص شده یک نقطه درج میشود، که پس از سه کلیک یک ذوزنقه متساوی الاضلاع رسم میشود، که یک دایره در مرکز آن وجود دارد.\n شما امکان تغییر نقاط را به وسیله کشیدن و رها کردن نقاط دارید، که این موضوع باعث میشود در لحظه حالت شکل تغییر کند و همیشه دایره در مرکز شکل باقی بماند.");
        }
    }
}
