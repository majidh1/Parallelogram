using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallelogram
{
    public class Circle : Shape
    {
        readonly float _size;
        public Circle(int x,int y, double size = 10)
        {
            _size = (float)size;
            X =x;
            Y = y;
        }

        public override void Draw(ref PictureBox board)
        {
            Graphics formGraphics;
            formGraphics = board.CreateGraphics();
            formGraphics.DrawArc(Pens.Yellow, X- _size/2, Y - _size / 2, _size, _size, 0, 400);
            formGraphics.Dispose();
        }
    }
}
