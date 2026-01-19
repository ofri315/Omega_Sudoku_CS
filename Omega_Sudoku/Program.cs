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
            
            int[,] mat = convertor.ConvertStringToMatrix("800000020004010000000700040060090003050000700100020000090000500000030400070000006");
            printMatrix(mat);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Solver.SolveSudoku(mat);

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            
            Console.WriteLine();
            printMatrix(mat);
            Console.WriteLine(elapsedTime.TotalSeconds);




        }
    }
}
