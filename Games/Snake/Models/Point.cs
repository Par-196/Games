using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class Point
    {
        private int _x { get; set; }
        private int _y { get; set; }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
