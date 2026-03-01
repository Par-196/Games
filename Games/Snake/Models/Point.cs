using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class Point
    {
        public int _x { get; }
        public int _y { get; }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
