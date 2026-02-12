using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Omega_Sudoku
{
    
    public class Program
    {
        /// <summary>
        /// The function runs the main loop that handles the sudoku solver.
        /// </summary>
        /// <exception cref="Exception">throw an error when the expression input is invalid, or when the Sudoku is unsolvable.</exception>
        public static void RunSudokuSolver()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Sudoku Expression:");
                    string sudokuExpression = Console.ReadLine();

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    ConvertSudoku convertor = new ConvertSudoku();

                    int[,] matrixBefore = new ConvertSudoku().ConvertStringToMatrix(sudokuExpression);
                    Console.WriteLine("Sudoku Before Solution:");
                    PrintSudoku.PrintSudokuMatrix(matrixBefore);

                    int[,] matrixAfter = new SudokuManager().SolveSudoku(sudokuExpression);
                    stopwatch.Stop();
                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    TimeSpan elapsedTime1 = stopwatch.Elapsed;
                    Console.WriteLine("Solved Sudoku:");
                    PrintSudoku.PrintSudokuMatrix(matrixAfter);
                    Console.WriteLine(elapsedTime1.TotalSeconds);
                }
                catch (Exception error)
                {
                    //Console.WriteLine(error.Message);
                    throw new Exception(error.Message); 
                }

            }
        }
        static void Main(string[] args)
        {
            RunSudokuSolver();
        }
    }
}
