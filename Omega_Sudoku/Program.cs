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
<<<<<<< HEAD
            //start work on dev
=======
            ConvertSudoku convertor = new ConvertSudoku();
            
            int[,] mat = convertor.ConvertStringToMatrix("800000070006010053040600000000080400003000700020005038000000800004050061900002000");
            printMatrix(mat);
            Solver.SolveSudoku(mat);
            Console.WriteLine();
            printMatrix(mat);

>>>>>>> feature
        }
    }
}
