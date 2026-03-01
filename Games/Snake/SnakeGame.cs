using Snake.Model.Enums;
using Snake.Models;
using System;
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
        }

        public void GameStart()
        {
            _snake.DrawSnake(_cells);
        }

        public void MoveSnake()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            
        }

        static void Main(string[] args)
        {
            SnakeGame snakeGame = new SnakeGame(30, 70);
            snakeGame.GameStart();
            Console.ReadLine();
        }
    }
}
