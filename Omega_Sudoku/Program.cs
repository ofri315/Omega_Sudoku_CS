using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Omega_Sudoku
{

    public class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter Sudoku Expression:");
                    string sudokuExpression = Console.ReadLine();
                    SudokuManager sudokuManager = new SudokuManager(sudokuExpression);
                    int[,] sudokuMat = sudokuManager.SolveSudoku();
                    PrintSudoku.PrintSudokuMatrix(sudokuMat);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            }
        }
    }
}
