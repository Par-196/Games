using Snake.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class Field
    {
        public Field(Cell[,] _cells)
        {
            CreateField(_cells);
        }
        
        private void CreateField(Cell[,] _cells)
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i + 1 == _cells.GetLength(0) || j + 1 == _cells.GetLength(1))
                    {
                        _cells[i, j] = new Cell(i, j, TypeCell.Border);
                    }
                    else
                    {
                        _cells[i, j] = new Cell(i, j, TypeCell.Empty);
                    }
                }
            }
        }

        public void ShowField(Cell[,] _cells)
        {
            if (ArrayIsNotNull(_cells))
            {
                Console.SetWindowSize(_cells.GetLength(1), _cells.GetLength(0));
                for (int x = 0; x < _cells.GetLength(0); x++)
                {
                    for (int y = 0; y < _cells.GetLength(1); y++)
                    {
                        Console.Write(_cells[x, y].ToString());
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(0, 0);
            }
            else 
            {
                Console.WriteLine("I can't display the field because the array is empty");
            }
            
        }

        private bool ArrayIsNotNull(Cell[,] array)
        {
            if (array == null)
            {
                return false;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public (int, int) SpawnFood(Cell[,] cells, bool didSnakeEatFood, int foodXPoint, int foodYPoint)
        {
            Random random = new Random();
            if (didSnakeEatFood == true)
            {
                do
                {
                    foodXPoint = random.Next(1, cells.GetLength(0) - 2);
                    foodYPoint = random.Next(1, cells.GetLength(0) - 2);
                }
                while (cells[foodXPoint, foodYPoint].Type != TypeCell.Empty);


                cells[foodXPoint, foodYPoint].ChangeCellType(TypeCell.Food);
                Console.SetCursorPosition(foodYPoint, foodXPoint);
                Console.Write(cells[foodXPoint, foodYPoint].ToString());
                Console.ResetColor();
                didSnakeEatFood = false;
                return (foodXPoint, foodYPoint);
            }
            return (foodXPoint, foodYPoint);
        }

    }
}
