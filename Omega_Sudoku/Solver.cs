using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    internal class Solver
    {
        /// <summary>
        /// הפעולה בודקת אם מספר נמצא בשורה 
        /// </summary>
        /// <param name="mat">מטריצה המייצגת סודוקו</param>
        /// <param name="rowNumber">מספר שורה</param>
        /// <param name="number">מספר לבדיקה אם נמצא בשורה</param>
        /// <returns>אמת אם המספר נמצא בשורה, ושקר אחרת</returns>
        public bool NumberInRow(int[,] mat, int rowNumber, int number)
        {
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                if (mat[rowNumber, i] == number)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// הפעולה בודקת אם המספר נמצא בטור 
        /// </summary>
        /// <param name="mat">מטריצה המייצגת סודוקו</param>
        /// <param name="colNumber">מספר טור</param>
        /// <param name="number">מספר לבדיקה אם הוא נמצא בטור</param>
        /// <returns>אמת אם המספר נמצא בטור, שקר אחרת</returns>
        public bool NumberInCol(int[,] mat, int colNumber, int number)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[i,colNumber] == number)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// הפעולה בודקת האם מספר נמצא בבלוק 
        /// </summary>
        /// <param name="mat">מטריצה המייצגת סודוקו</param>
        /// <param name="rowStart">מספר שורה בה מתחיל הבלוק</param>
        /// <param name="colStart">מספר טור בו מתחיל הבלוק</param>
        /// <param name="number">מספר לבדיקה אם נמצא בבלוק</param>
        /// <returns>אמת אם המספר נמצא בבלוק, שקר אחרת</returns>
        public bool NumberInBlock(int[,] mat, int row, int col,int number)
        {
            int block_row = (int)(row / 3) * 3;
            int block_col = (int)(col / 3) * 3;
            for (int i = block_row; i < block_row+3; i++)
            {
                for (int j = block_col; j < block_col+3; j++)
                {
                    if (mat[i,j]==number)
                        return true;
                }
            }
            return false;
        }

    }
}
