using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    internal class ConvertToMatrix
    {
        /// <summary>
        /// הפעולה מקבלת מחרוזת המייצגת את הסודוקו וממירה למערך דו מימדי
        /// </summary>
        /// <param name="sudokuExpression">הביטוי המייצג סודוקו להמרה</param>
        /// <returns>מערך דו מימדי המייצג את הסודוקו טרם פתירתו</returns>
        public int[,] ConvertStringToMatrix(string sudokuExpression)
        {
            int n = (int)Math.Sqrt(sudokuExpression.Length);
            int[,] sudokuMatrix = new int[n,n];
            int k = 0;
            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sudokuMatrix[i,j] = (int)sudokuExpression[k]-'0';
                    k++;
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
            for (int i = 0; i < sudokuMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuMatrix.GetLength(1); j++)
                {
                    sudokuExpression += sudokuMatrix[i, j];
                }
            }
            return sudokuExpression;
        }
    }
}
