using Snake.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class Cell
    {
        private TypeCell _type { get; set; } = TypeCell.Empty;

        public Cell(int x, int y, TypeCell type) 
        {
            Point point = new Point(x, y);
            type = _type;
        }
    }
}
