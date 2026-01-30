using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    class SudokuValidation
    {
        private string sudokuExpression;
        public SudokuValidation(string sudokuExpression)
        {
            this.sudokuExpression = sudokuExpression;
        }
        /// <summary>
        /// The method checks whether the length of the string is a square number.
        /// </summary>
        /// <returns>True if the length of the string is a square number, false otherwise</returns>
        public bool checkLength()
        {
            double n=Math.Sqrt(this.sudokuExpression.Length);
            return n - (int)n == 0;
        }

        /// <summary>
        /// The method checks whether the sudoku string contains only numbers
        /// </summary>
        /// <returns>True if the string contains only numbers, false otherwise</returns>
        public bool checkOnlyNumbers()
        {
            return this.sudokuExpression.All(char.IsDigit);
        }
    }
}
