using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelogram
{
    public static class Helpers
    {
        public static int RoundTo(int number, int to)
        {
            return (int)Math.Round((double)number / to) * to;
        }
    }
}
