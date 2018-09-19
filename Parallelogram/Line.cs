using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallelogram
{
    public class Line:Shape
    {
        private readonly Point _point1;
        private readonly Point _point2;
        public Line(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }
        public override void Draw(ref PictureBox board)
        {
            Graphics formGraphics;
            formGraphics = board.CreateGraphics();
            formGraphics.DrawLine(Pens.Blue, _point1, _point2);
            formGraphics.Dispose();
        }
    }
}
