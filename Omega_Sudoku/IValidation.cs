using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
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
