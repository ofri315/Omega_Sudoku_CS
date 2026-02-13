using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku.Interfaces
{
    /// <summary>
    ///  The interface provides a contract describing the function and property required to check if a sudoku expression is valid (length and type of characters)
    /// </summary>
    public interface IInitialValidation
    {
        /// <summary>
        /// a string representing the Sudoku expression.
        /// </summary>
        string SudokuExspression { get; }

        /// <summary>
        /// The function checks that the Sudoku string input is valid.
        /// </summary>
        void CheckAllInitialValidations();

    }
}
