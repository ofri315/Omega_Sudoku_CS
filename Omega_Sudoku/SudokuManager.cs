using Omega_Sudoku.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    /// <summary>
    /// The class is responsible for managing all functions for solving the Sudoku board.
    /// </summary>
    public class SudokuManager : IManager
    {

        /// <summary>
        /// The function handles solving the Sudoku puzzle (including validity checks and conversion to a matrix).
        /// </summary>
        /// <param name="sudokuExpression">a string representing the Sudoku expression.</param>
        /// <returns>the Solved Sudoku matrix.</returns>
        /// <exception cref="Exception">Thrown if there is a problem with the sudoku puzzle with a suitable message.</exception>
        public int[,] SolveSudoku(string sudokuExpression)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                SudokuInitialValidation InitialValidation = new SudokuInitialValidation(sudokuExpression);
                InitialValidation.CheckAllInitialValidations();

                ConvertSudoku convertor = new ConvertSudoku();
                int[,] SudokuMatrix = convertor.ConvertStringToMatrix(sudokuExpression);

                Console.WriteLine("Sudoku Before Solution:");
                PrintSudoku.PrintSudokuMatrix(SudokuMatrix);

                SudokuValidation Validation = new SudokuValidation(SudokuMatrix);
                Validation.CheckRowsColsBlocks();

                ISolver solver = new Solver(SudokuMatrix);
                solver.Solve();
                Console.WriteLine("Solved Sudoku:");
                PrintSudoku.PrintSudokuMatrix(SudokuMatrix);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(string.Format("solving time: {0}ms",elapsedMs));

                return SudokuMatrix;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// The function handles solving the Sudoku puzzle and converting it back to a string for the unit tests.
        /// </summary>
        /// <param name="sudokuExpression">a string representing the Sudoku expression.</param>
        /// <returns>the Solved Sudoku expression.</returns>
        /// <exception cref="Exception">Thrown if there is a problem with the sudoku puzzle with a suitable message.</exception>
        public string SolveForTests(string sudokuExpression)
        {
            try
            {
                int[,] sudokuMat=SolveSudoku(sudokuExpression);
                ConvertSudoku convertor=new ConvertSudoku();
                return convertor.ConvertMatrixToString(sudokuMat);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
