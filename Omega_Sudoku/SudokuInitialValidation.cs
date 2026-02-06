using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    internal class SudokuInitialValidation
    {
        private string sudokuExpression;
        public SudokuInitialValidation(string sudokuExpression)
        {
            this.sudokuExpression = sudokuExpression;   
        }
        /// <summary>
        /// The method checks whether the length of the string is a square number.
        /// </summary>
        /// <returns>True if the length of the string is a square number, false otherwise</returns>
        public bool CheckSquareLength()
        {
            double n = Math.Sqrt(this.sudokuExpression.Length);
            if (n - (int)n == 0)
                return true;
            throw new ArgumentException("The length of the Sudoku string is not a square root.");
        }




        /// <summary>
        /// The method checks whether the sudoku string contains only numbers
        /// </summary>
        /// <returns>True if the string contains only numbers, false otherwise</returns>
        public bool CheckOnlyNumbers()
        {
            if (this.sudokuExpression.All(char.IsDigit))
            {
                return true;
            }
            throw new ArgumentException("The string contains invalid characters.");
        }


        
    }
}
