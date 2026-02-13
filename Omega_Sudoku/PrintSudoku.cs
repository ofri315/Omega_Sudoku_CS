using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    /// <summary>
    /// The class is responsible for the Sudoku matrix printing function.
    /// </summary>
    public class PrintSudoku
    {
        /// <summary>
        /// The function prints the Sudoku board.
        /// </summary>
        /// <param name="matrix">Sudoku board for printing</param>
        public static void PrintSudokuMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0);row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((col+1)%(int)Math.Sqrt(matrix.GetLength(0))==0 && (col+1)<matrix.GetLength(0))
                        Console.Write(matrix[row, col] + "|");
                    else
                        Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
                if ((row + 1) % (int)Math.Sqrt(matrix.GetLength(0)) == 0 && (row+1)<matrix.GetLength(0))
                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", matrix.GetLength(0)*2)));
            }
            Console.WriteLine();


        }
    }
}
