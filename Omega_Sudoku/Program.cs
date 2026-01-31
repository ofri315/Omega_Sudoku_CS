using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Omega_Sudoku
{

    internal class Program
    {

        public static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            ConvertSudoku convertor = new ConvertSudoku();

            int[,] mat = convertor.ConvertStringToMatrix("000000010400000000020000000000050407008000300001090000300400200050100000000806000");
            printMatrix(mat);
            Solver s = new Solver(mat,0,9);
            s.InitDictRow();
            s.InitDictCol();
            s.InitDictBlock();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            s.SolveSudokuRec(0, 0);
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Console.WriteLine();
            printMatrix(mat);
            Console.WriteLine(elapsedTime.TotalSeconds);


        }
    }
}
