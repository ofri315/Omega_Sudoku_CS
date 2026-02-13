using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku.Interfaces
{
    /// <summary>
    ///  The interface provides a contract describing the function and property required to check if a sudoku is valid (there is not duplicates in rows, columns or blocks).
    /// </summary>
    internal interface IValidation
    {
        /// <summary>
        /// The sudoku board as a matrix.
        /// </summary>
        int[,] SudokuMatrix { get; }

        /// <summary>
        /// The function checks that each row, column, and sub-matrix contains each number only once.
        /// </summary>
        void CheckRowsColsBlocks();
    }
}
