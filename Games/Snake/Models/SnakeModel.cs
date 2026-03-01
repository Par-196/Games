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

        public void MoveSnake()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey userInput = Console.ReadKey(true).Key;

                if ((userInput == ConsoleKey.W || userInput == ConsoleKey.UpArrow) && Direction != SnakeDirection.Down)
                {
                    Direction = SnakeDirection.Up;
                }
                else if ((userInput == ConsoleKey.D || userInput == ConsoleKey.RightArrow) && Direction != SnakeDirection.Left)
                {
                    Direction = SnakeDirection.Right;
                }
                else if ((userInput == ConsoleKey.S || userInput == ConsoleKey.DownArrow) && Direction != SnakeDirection.Up)
                {
                    Direction = SnakeDirection.Down;
                }
                else if ((userInput == ConsoleKey.A || userInput == ConsoleKey.LeftArrow) && Direction != SnakeDirection.Right)
                {
                    Direction = SnakeDirection.Left;
                }
            }
            MoveSnakeOnField(Direction);
        }

        public void MoveSnakeOnField(SnakeDirection snakeDirection)
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

        public bool DidSnakeEatFood(int foodXPoint, int foodYPoint)
        {
            var head = Body.Last();

            if (head._x == foodXPoint && head._y == foodYPoint)
            {
                return true;
            }

            return false;
        }

        public int UpdateSnake(Cell[,] cells, bool didSnakeEatFood)
        {

            if (didSnakeEatFood == false && Body.Count > 1)
            {
                var tail = Body.Peek();
                cells[tail._x, tail._y].ChangeCellType(TypeCell.Empty);

                Console.SetCursorPosition(tail._y, tail._x);
                Console.Write(cells[tail._x, tail._y].ToString());
                Console.ResetColor();

                Body.Dequeue();
            }

            foreach (var item in Body)
            {
                bool isHead = false;
                if (item == Body.Last())
                {
                    isHead = true;
                }
                var type = isHead ? TypeCell.SnakeHead : TypeCell.SnakeBody;
                cells[item._x, item._y].ChangeCellType(type);
                Console.SetCursorPosition(item._y, item._x);
                Console.Write(cells[item._x, item._y].ToString());
                Console.ResetColor();
            }
            return Body.Count;
        }
    }
}
