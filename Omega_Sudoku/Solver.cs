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

    }
}
