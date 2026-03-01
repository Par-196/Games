using SnakeGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Cell
    {
        private int _x { get; set; }
        private int _y { get; set; }
        private TypeCell _type { get; set; }
        public TypeCell Type => _type;

        public Cell(int x, int y, TypeCell type) 
        {
            _x = x;
            _y = y;
            _type = type;
        }

        public override string ToString()
        {
            switch (_type)
            {
                case TypeCell.Empty:
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        return " ";
                    }
                case TypeCell.SnakeHead:
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        return " ";
                    }
                case TypeCell.SnakeBody:
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        return " ";
                    }
                case TypeCell.Border:
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        return " ";
                    }
                case TypeCell.Food:
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        return " ";
                    }
                default:
                    break;
            }

            return "Error";
        }

        public void ChangeCellType(TypeCell type)
        {
            _type = type;
        }
    }
}
