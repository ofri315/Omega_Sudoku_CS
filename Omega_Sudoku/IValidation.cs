using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    internal interface IValidation
    {
        int[,] SudokuMatrix { get; }

        void SudokuValidation();
    }
}
