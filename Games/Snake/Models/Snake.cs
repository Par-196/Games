using SnakeGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Snake
    {
        public Queue<Point> Body { get; set; }
        public SnakeDirection Direction { get; set; }

        public Snake()
        {
            Body = new Queue<Point>();
        }

        public void PlaceSnakeOnField(Cell[,] cells)
        {
            Random random = new Random();
            int snakeX = 0;
            int snakeY = 0;
            do
            {
                snakeX = random.Next(1, cells.GetLength(0) - 2);
                snakeY = random.Next(1, cells.GetLength(1) - 2);
            }
            while (cells[snakeX, snakeY].Type != TypeCell.Empty);
            Body.Enqueue(new Point(snakeX, snakeY));
        }

        public void DrawSnake(Cell[,] cells)
        {
            foreach (var item in Body)
            {
                if (item == Body.Peek())
                {
                    cells[item._x, item._y].ChangeCellType(TypeCell.SnakeHead);
                    Console.SetCursorPosition(item._y, item._x);
                    Console.Write(cells[item._x, item._y].ToString());
                    Console.ResetColor();
                }
                else
                {
                    cells[item._x, item._y].ChangeCellType(TypeCell.SnakeHead);
                    Console.SetCursorPosition(item._y, item._x);
                    Console.Write(cells[item._x, item._y].ToString());
                    Console.ResetColor();
                }
            }
        }
    }
}
