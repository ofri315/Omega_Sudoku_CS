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
        public bool CheckLength()
        {
            double n=Math.Sqrt(this.sudokuExpression.Length);
            return n - (int)n == 0;
        }

        /// <summary>
        /// The method checks whether the sudoku string contains only numbers
        /// </summary>
        /// <returns>True if the string contains only numbers, false otherwise</returns>
        public bool CheckOnlyNumbers()
        {
            return this.sudokuExpression.All(char.IsDigit);
        }

        /// <summary>
        /// The method checks that each row has each number only one time
        /// </summary>
        /// <param name="sudokuMat">sudoku matrix</param>
        /// <returns>True if in any row each digit appears only once, false otherwise.</returns>
        public bool CheckRows(int[,] sudokuMat)
        {
            for (int i = 0; i < sudokuMat.GetLength(0); i++)
            {
                int[] countDigArr = new int[sudokuMat.GetLength(0)+1];
                for (int j = 0;  j < countDigArr.Length;  j++)
                {
                    countDigArr[j] = 0;
                }
                for (int j = 0; j < sudokuMat.GetLength(1); j++)
                {
                    countDigArr[sudokuMat[i, j]]++;
                }
                for (int j = 1; j < countDigArr.Length; j++)
                {
                    Console.WriteLine(j);
                    if (countDigArr[j] >1)
                        return false;
                }
            }
            return true;

        }

    }
}
