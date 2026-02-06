using System;
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
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            

        }
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter Sudoku Expression:");
                string sudokuExpression= Console.ReadLine();
                SudokuManager sudokuManager = new SudokuManager(sudokuExpression);
                int[,] sudokuMat=sudokuManager.SolveSudoku();
                printMatrix(sudokuMat);
            }
        }
    }
}
