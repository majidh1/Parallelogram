using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelogram
{
    public class Dot:Shape
    {
        public Dot(Point point,int size=10)
        {
            Height = size;
            Width = size;
            X = point.X;
            Y = point.Y;
        }
        public override void Draw(ref System.Windows.Forms.PictureBox board)
        {
            Graphics formGraphics;
            formGraphics = board.CreateGraphics();
            formGraphics.DrawArc(Pens.Red,X- Width/2, Y-Height/2, Height, Width, 0, 400);
            formGraphics.FillPie(Brushes.Red, X - Width / 2, Y - Height / 2, Height, Width, 0, 400);
            formGraphics.Dispose();
        }
    }
}
