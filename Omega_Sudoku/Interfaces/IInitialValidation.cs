using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku.Interfaces
{
    public interface IInitialValidation
    {
        /// <summary>
        /// a string representing the Sudoku expression.
        /// </summary>
        string SudokuExspression { get; }

        /// <summary>
        /// The function runs all the initial validation functions in the class.
        /// </summary>
        void CheckAllInitialValidations();

    }
}
