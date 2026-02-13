using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku.Interfaces
{
    /// <summary>
    ///  The interface provides a contract describing the functions required to handle the Sudoku Solver.
    /// </summary>
    internal interface IManager
    {
        /// <summary>
        /// The function handles solving the Sudoku puzzle (including validity checks and conversion to a matrix).
        /// </summary>
        /// <param name="sudokuExpression">a string representing the Sudoku expression.</param>
        /// <returns>the Solved Sudoku matrix.</returns>
        int[,] SolveSudoku(string sudokuExpression);


        /// <summary>
        /// The function handles solving the Sudoku puzzle and converting it back to a string for the unit tests.
        /// </summary>
        /// <param name="sudokuExpression">a string representing the Sudoku expression.</param>
        /// <returns>the Solved Sudoku expression.</returns>
        string SolveForTests(string sudokuExpression);

    }
}
