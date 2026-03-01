using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame

{
    public class SnakeGame
    {
        private Cell[,] _cells { get; set; }

        public SnakeGame(int width, int length)
        {
            _cells = new Cell[width, length];
            
        }

        public void GameStart()
        {
            Field field = new Field(_cells);
            Snake snake = new Snake();
            snake.PlaceSnakeOnField(_cells);
            snake.DrawSnake(_cells);
        }

        static void Main(string[] args)
        {
            SnakeGame snakeGame = new SnakeGame(30, 70);
            snakeGame.GameStart();

            Console.ReadLine();
        }
    }
}
