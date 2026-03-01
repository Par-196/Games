using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Point
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
