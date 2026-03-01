using Snake.Model.Enums;
using Snake.Models;
using Snake.Models.Enums;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{
    public class SnakeGame
    {
        private Field _field { get; set; }
        private Cell[,] _cells { get; set; }
        private SnakeModel _snake { get; set; }

        public SnakeGame(int width, int length)
        {
            _cells = new Cell[width, length];
            _field = new Field(_cells);
            _snake = new SnakeModel();
            _snake.PlaceSnakeOnField(_cells);
            _field.ShowField(_cells);
        }

        public void GameStart()
        {   
            int foodYPoint = 0;
            int foodXPoint = 0;
            bool didSnakeEatFood = true;
            bool gameEnd = false;
            while (!gameEnd)
            {
                (foodXPoint, foodYPoint) = _field.SpawnFood(_cells, didSnakeEatFood, foodXPoint, foodYPoint);
                _snake.MoveSnake();
                if (_snake.DidSnakeDie(_cells) == true)
                {
                    gameEnd = true;
                    Console.WriteLine("Game Over! Snake died.");
                    break;
                }
                didSnakeEatFood = _snake.DidSnakeEatFood(foodXPoint, foodYPoint);
                _snake.UpdateSnake(_cells, didSnakeEatFood);
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            int widthField = 30;
            int heightField = 70;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1.PLay\n" +
                "2.Field size\n" +
                "3.Records\n" +
                "4.Exit");

                Enum.TryParse(Console.ReadLine(), out GameMenu gameMenu);
                switch (gameMenu)
                {
                    case GameMenu.PLay:
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            SnakeGame snakeGame = new SnakeGame(widthField, heightField);
                            snakeGame.GameStart();
                            Console.ReadLine();
                        }
                        break;
                    case GameMenu.FieldSize:
                        {
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Enter Field height, min 20");
                                heightField = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Field widht, min 30");
                                widthField = int.Parse(Console.ReadLine());
                                if (heightField < 20 || widthField < 30)
                                {
                                    Console.WriteLine("Try again");
                                }
                            }
                            while (heightField < 20 || widthField < 30);
                        }
                        break;
                    case GameMenu.Records:
                        {
                        }
                        break;
                    case GameMenu.Exit:
                        {
                            exit = true;
                            Console.WriteLine("Exit from game");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Wrong input, try again");
                        }
                        break;
                }
            }
        }
    }
}
