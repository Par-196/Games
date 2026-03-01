using Snake.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class SnakeModel
    {
        public Queue<Point> Body { get; set; }
        public SnakeDirection Direction { get; set; }

        public SnakeModel()
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
                    cells[item._x, item._y].ChangeCellType(TypeCell.SnakeBody);
                    Console.SetCursorPosition(item._y, item._x);
                    Console.Write(cells[item._x, item._y].ToString());
                    Console.ResetColor();
                }
            }
        }

        public void MoveSnake(SnakeDirection snakeDirection)
        {
            switch (snakeDirection)
            {
                case SnakeDirection.Up:
                    {
                        Body.Enqueue(new Point(Body.Last()._x - 1, Body.Last()._y));
                    }
                    break;
                case SnakeDirection.Right:
                    {
                        Body.Enqueue(new Point(Body.Last()._x, Body.Last()._y + 1));
                    }
                    break;
                case SnakeDirection.Down:
                    {
                        Body.Enqueue(new Point(Body.Last()._x + 1, Body.Last()._y));
                    }
                    break;
                case SnakeDirection.Left:
                    {
                        Body.Enqueue(new Point(Body.Last()._x, Body.Last()._y - 1));
                    }
                    break;
            }
        }

        public bool DidSnakeDie(Cell[,] cells)
        {
            if (Body.Last()._x < 1 || Body.Last()._y < 1 || Body.Last()._x > cells.GetLength(0) - 2 || Body.Last()._y > cells.GetLength(1) - 2)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("You smashed into a wall");
                return true;
            }
            foreach (var item in Body)
            {

                if ((Body.Last()._x == item._x && Body.Last()._y == item._y) && (item != Body.Last()))
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("You smashed into yourself"); 
                    return true;
                }
            }

            return false;
        }
    }
}
