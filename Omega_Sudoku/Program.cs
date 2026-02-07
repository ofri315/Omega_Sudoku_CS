using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Omega_Sudoku
{
    
    public class Program
    {
        public static void RunSudokuSolver()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Sudoku Expression:");
                    string sudokuExpression = Console.ReadLine();

                    int[,] MatrixBefore = new ConvertSudoku().ConvertStringToMatrix(sudokuExpression);
                    Console.WriteLine("Sudoku Before Solution:");
                    PrintSudoku.PrintSudokuMatrix(MatrixBefore);

                    SudokuManager sudokuManager = new SudokuManager(sudokuExpression);
                    int[,] MatrixAfter = sudokuManager.SolveSudoku();

                    Console.WriteLine("Solved Sudoku:");
                    PrintSudoku.PrintSudokuMatrix(MatrixAfter);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            }
        }
        static void Main(string[] args)
        {
            RunSudokuSolver();
        }
    }
}
