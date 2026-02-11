using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    public class ConvertSudoku :IConverSudoku
    {
        /// <summary>
        /// The function receives a string representing the Sudoku and converts it to a matrix.
        /// </summary>
        /// <param name="sudokuExpression">The Sudoku expression for conversion.</param>
        /// <returns>A matrix representing the Sudoku board.</returns>
        public int[,] ConvertStringToMatrix(string sudokuExpression)
        {
            int rowColBlockLength = (int)Math.Sqrt(sudokuExpression.Length);
            int[,] sudokuMatrix = new int[rowColBlockLength, rowColBlockLength];
            int stringIndex = 0;
            for (int row = 0; row < rowColBlockLength; row++)
            {
                for (int col = 0; col < rowColBlockLength; col++)
                {
                    sudokuMatrix[row,col] = (int)sudokuExpression[stringIndex] -'0';
                    stringIndex++;
                }
            }
            return sudokuMatrix;
        }

        /// <summary>
        /// The function converts the matrix to a string.
        /// </summary>
        /// <param name="sudokuMatrix">The Sudoku matrix for conversion.</param>
        /// <returns>A string representing the Sudoku board.</returns>
        public string ConvertMatrixToString(int[,] sudokuMatrix)
        {
            string sudokuExpression = "";
            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
                {
                    sudokuExpression += sudokuMatrix[row, col];
                }
            }
            return sudokuExpression;
        }
    }
}
