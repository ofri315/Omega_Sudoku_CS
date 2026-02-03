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
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(Convert.ToString(2323, 2));
            ConvertSudoku convertor = new ConvertSudoku();

            int[,] mat = convertor.ConvertStringToMatrix("800000070006010053040600000000080400003000700020005038000000800004050061900002000");
            printMatrix(mat);
            Solver s = new Solver(mat,0,9);
            s.InitDictRow();
            s.InitDictCol();
            s.InitDictBlock();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine(s.SolveSudokuRec(9,0,0));
            
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            //Console.WriteLine();
            printMatrix(mat);
            Console.WriteLine(elapsedTime.TotalSeconds);


        }
    }
}
