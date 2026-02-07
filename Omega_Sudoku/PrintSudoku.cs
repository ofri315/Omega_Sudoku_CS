using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    public class PrintSudoku
    {
        public static void PrintSudokuMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((j+1)%(int)Math.Sqrt(matrix.GetLength(0))==0 && (j+1)<matrix.GetLength(0))
                        Console.Write(matrix[i, j] + "|");
                    else
                        Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
                if ((i + 1) % (int)Math.Sqrt(matrix.GetLength(0)) == 0 && (i+1)<matrix.GetLength(0))
                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", matrix.GetLength(0)*2)));
            }
            Console.WriteLine();


        }
    }
}
