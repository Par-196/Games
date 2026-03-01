using Snake.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class Field
    {
        public Field(int width, int length)
        {
            Cell[,] _cells = new Cell[width, length];
            CreateField(_cells);
            ShowField(_cells);
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

        private void ShowField(Cell[,] _cells)
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

    }
}
