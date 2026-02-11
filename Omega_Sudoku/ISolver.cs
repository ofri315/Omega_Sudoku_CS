using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    public interface ISolver
    {
        /// <summary>
        /// The sudoku board as a matrix.
        /// </summary>
        int[,] SudokuMatrix { get; }

        /// <summary>
        /// The function manages the sudoku solver functions.
        /// </summary>
        /// <returns>True if there is a solution for the Sudoku puzzle.</returns>
        bool Solve();


    }
}
