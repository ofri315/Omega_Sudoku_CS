using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Omega_Sudoku
{
    /// <summary>
    /// The class handles the initial validation of the Sudoku Expression.
    /// </summary>
    public class SudokuInitialValidation : IInitialValidation
    {
        private string sudokuExpression;
        public string SudokuExpression;
        /// <summary>
        /// a string representing the Sudoku expression.
        /// </summary>
        string IInitialValidation.SudokuExspression
        {
            get => sudokuExpression;
        }

        /// <summary>
        ///  Initializes a new instance of the SudokuInitialValidation class.
        /// </summary>
        /// <param name="sudokuExpression">The sudoku expression</param>
        public SudokuInitialValidation(string sudokuExpression)
        {
            this.sudokuExpression = sudokuExpression;   
        }

        /// <summary>
        /// The function checks if the given string is empty.
        /// </summary>
        /// <returns>True is the given string is not empty.</returns>
        /// <exception cref="ArgumentException">Thrown if the string is empty.</exception>
        public bool CheckEmptyString()
        {
            if (this.sudokuExpression == "")
                throw new ArgumentException("The Sudoku String is empty");
            else
                return true;
        }

        /// <summary>
        /// The function checks whether the length of the string is a square number.
        /// </summary>
        /// <returns>True if the length of the sudoku string is a square number.</returns>
        /// <exception cref="ArgumentException">Thrown if the length of the string is not a square number</exception>
        public bool CheckSquareLength()
        {
            double rowColBlockLength = Math.Sqrt(this.sudokuExpression.Length);
            if (rowColBlockLength - (int)rowColBlockLength == 0)
                return true;
            throw new ArgumentException("The length of the Sudoku string is not a square root.");
        }

        /// <summary>
        /// The function checks whether the length of the sudoku string is smaller then 81 (a larger number will not allow the string to be converted to a matrix so that each character is an cell in the matrix).
        /// </summary>
        /// <returns>True if the length of the sudoku string is smaller then 81 </returns>
        /// <exception cref="ArgumentException">Thrown if the length of the string is larger then 81.</exception>
        public bool CheckExpressionLength()
        {
            if (this.sudokuExpression.Length<=81)
                return true;
            throw new ArgumentException("The length of the string is bigger then 81.");
        }

        /// <summary>
        /// The function checks whether the length of the a submatrix is a square number.
        /// </summary>
        /// <returns>True if the length of the sudoku submatrix is a square number.</returns>
        /// <exception cref="ArgumentException">Thrown if the length of a sub-matrix is not a square number.</exception>
        public bool CheckSubMatrixLength()
        {
            double rowColBlockLength= Math.Sqrt(this.sudokuExpression.Length);
            double subMatrixLength= Math.Sqrt(rowColBlockLength);
            if (subMatrixLength - (int)subMatrixLength == 0)
                return true;
            throw new ArgumentException("The length of the sub matrices sides is not equal (NxN).");
        }


        /// <summary>
        /// The method checks whether the sudoku string contains only numbers.
        /// </summary>
        /// <returns>True if the string contains only numbers.</returns>
        /// <exception cref="ArgumentException">Thrown if the string contains a character which is not a number.</exception>
        public bool CheckOnlyNumbers()
        {
            if (this.sudokuExpression.All(char.IsDigit))
            {
                return true;
            }
            throw new ArgumentException("The string contains invalid characters.");
        }

        /// <summary>
        /// The function runs all the initial validation functions in the class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if there is a problem with the string, with a suitable message.</exception>
        public void CheckAllInitialValidations()
        {
            try
            {
                this.CheckEmptyString();
                this.CheckOnlyNumbers();
                this.CheckExpressionLength();
                this.CheckSquareLength();
                this.CheckSubMatrixLength();
            }
            catch (ArgumentException error)
            {
                throw new ArgumentException(error.Message);
            }
        }
    }
}
