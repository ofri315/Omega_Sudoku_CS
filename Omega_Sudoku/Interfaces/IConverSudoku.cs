using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku.Interfaces
{
    internal interface IConverSudoku
    {
        /// <summary>
        /// The function receives a string representing the Sudoku and converts it to a matrix.
        /// </summary>
        /// <param name="sudokuExpression">The Sudoku expression for conversion.</param>
        /// <returns>A matrix representing the Sudoku board.</returns>
        int[,] ConvertStringToMatrix(string sudokuExpression);


        /// <summary>
        /// The function converts the matrix to a string.
        /// </summary>
        /// <param name="sudokuMatrix">The Sudoku matrix for conversion.</param>
        /// <returns>A string representing the Sudoku board.</returns>
        string ConvertMatrixToString(int[,] sudokuMatrix);
    }
}
