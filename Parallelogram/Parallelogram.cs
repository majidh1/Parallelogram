using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallelogram
{
    public class Parallelogram:Shape
    {
        private List<Point> _points;
        public Parallelogram(List<Point> points)
        {
            _points =points;
        }

        public override void Draw(ref PictureBox board)
        {
            board.Refresh();

            foreach (var item in _points)
            {
                var dot = new Dot(item);
                dot.Draw(ref board);
            }

            var pointD = new Point
            {
                X = _points[0].X + _points[2].X - _points[1].X,
                Y = _points[0].Y + _points[2].Y - _points[1].Y,
            };

            _points.Add(pointD);

            var line1 = new Line(_points[0], _points[1]);
            line1.Draw(ref board);

            var line2 = new Line(_points[1], _points[2]);
            line2.Draw(ref board);

            var line3 = new Line(_points[0], _points[3]);
            line3.Draw(ref board);

            var line4 = new Line(_points[2], _points[3]);
            line4.Draw(ref board);

            //max(AB,BC) a
            //AO b=AC/2
            //BO c=BD/2

            var AB = Math.Sqrt(Math.Pow((_points[1].X - _points[0].X), 2) + Math.Pow((_points[1].Y - _points[0].Y), 2));
            var BC = Math.Sqrt(Math.Pow((_points[2].X - _points[1].X), 2) + Math.Pow((_points[2].Y - _points[1].Y), 2));
            var AC = Math.Sqrt(Math.Pow((_points[2].X - _points[0].X), 2) + Math.Pow((_points[2].Y - _points[0].Y), 2));
            var BD = Math.Sqrt(Math.Pow((_points[3].X - _points[1].X), 2) + Math.Pow((_points[3].Y - _points[1].Y), 2));
            var AO = AC / 2;
            var BO = BD / 2;
            double a = 0.0;
            if (AB > BC)
            {
                a = Math.Sqrt(Math.Pow((_points[1].X - _points[0].X), 2) + Math.Pow((_points[1].Y - _points[0].Y), 2));
            }
            else
            {
                a = Math.Sqrt(Math.Pow((_points[2].X - _points[1].X), 2) + Math.Pow((_points[2].Y - _points[1].Y), 2));
            }

            var b = AO;
            var c = BO;

            var s = (a + b + c) / 2;
            var h =2 * Math.Sqrt(2 * (s * (s - a) * (s - b) * (s - c))) / a;

            var centerX = (_points[0].X + _points[1].X + _points[2].X + _points[3].X) / 4;
            var centerY = (_points[0].Y + _points[1].Y + _points[2].Y + _points[3].Y) / 4;

            var circle = new Circle(centerX, centerY, h);
            circle.Draw(ref board);

            _points.Remove(_points.LastOrDefault());
        }
    }
}
