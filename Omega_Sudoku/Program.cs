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
                    new SudokuManager().SolveSudoku(sudokuExpression);
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
