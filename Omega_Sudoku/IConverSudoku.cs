using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    internal interface IConverSudoku
    {
        int[,] ConvertStringToMatrix(string sudokuExpression);

        string ConvertMatrixToString(int[,] sudokuMatrix);
    }
}
