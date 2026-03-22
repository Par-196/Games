using System;
using System.Collections.Generic;
using Sea_War.Models.Enums;

namespace Sea_War.Models
{
    public class Ship
    {
        private TypeShips Type { get; set; }
        private List<Point> Points { get; set; }
        private Ship(TypeShips type)
        {
            Type = type;
            Points = new List<Point>();
        }
    }
}
