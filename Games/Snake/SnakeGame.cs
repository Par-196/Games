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

        public SnakeGame()
        {
            _cells = new Cell[40, 120];
            _field = new Field(_cells);
            _snake = new SnakeModel();
            _snake.PlaceSnakeOnField(_cells);
            _field.ShowField(_cells);
        }

        static void Main()
        {
            
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
                Thread.Sleep(50);
            }
        }
    }
}
