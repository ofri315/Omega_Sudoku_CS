using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Omega_Sudoku
{

    internal class Program
    {
        public static void printdict(Dictionary<int, int> dict)
        {
            for (int i = 0; i < dict.Count; i++)
            {
                Console.WriteLine(Convert.ToString(dict[i], 2));
            }
        }
        public static void printdictBlock(Dictionary<(int x, int y), int> dict)
        {
            int j = 0;
            for (int i = 0; i < dict.Count; i++)
            {
                Console.WriteLine(Convert.ToString(dict[((int)(i/3), (int)(j))], 2));
                j++;
                if (j > 2)
                    j = 0;
            }
        }
        public static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            

        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[,] mat = SolveSudoku("000060080020000000001000000070000102500030000000000400004201000300700600000000050");
            stopwatch.Stop();
            TimeSpan elapsedTime1 = stopwatch.Elapsed;
            printMatrix(mat);
            Console.WriteLine(elapsedTime1.TotalSeconds);



        }
    }
}
