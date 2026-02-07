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
        /// הפעולה מקבלת מחרוזת המייצגת את הסודוקו וממירה למערך דו מימדי
        /// </summary>
        /// <param name="sudokuExpression">הביטוי המייצג סודוקו להמרה</param>
        /// <returns>מערך דו מימדי המייצג את הסודוקו טרם פתירתו</returns>
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
        /// הפעולה ממירה את המטריצה חזרה למחרוזת
        /// </summary>
        /// <param name="sudokuMatrix">מטריצה המייצגת סודוקו</param>
        /// <returns>מחרוזת המייצת את הסודוקו</returns>
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
