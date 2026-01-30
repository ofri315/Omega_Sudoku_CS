using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Omega_Sudoku
{
    internal class Solver
    {
        /// <summary>
        /// struct המייצג תא בסודוקו
        /// </summary>
        public struct Position
        {
            public int row;
            public int col;
        }


        private int[,] mat;
        private Dictionary<int, HashSet<int>> dictRow=new Dictionary<int, HashSet<int>>();
        private Dictionary<int, HashSet<int>> dictCol=new Dictionary<int, HashSet<int>>();
        private Dictionary<Position, HashSet<int>> dictBlock=new Dictionary<Position, HashSet<int>>();

        //Constractor
        public Solver(int[,] mat, int start, int end)
        {
            this.mat = mat;
            int n = mat.GetLength(0);
            for (int i = start; i <= end; i++)
            {
                dictRow.Add(i, new HashSet<int>());
            }
            for (int i = start; i <= end; i++)
            {
                dictCol.Add(i, new HashSet<int>());
            }
            for (int i=0;i< Math.Sqrt(mat.GetLength(0));i+=3)
            {
                for (int j = 0; j < Math.Sqrt(mat.GetLength(1)); j+=3)
                {
                    Position p = new Position();
                    p.row = i;
                    p.col = j;
                    dictBlock.Add(p,new HashSet<int>());
                }
            }
        }

        public void initDictRow()
        {
            for (int i = 0; i< mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i,j]!=0)
                        this.dictRow[i].Add(this.mat[i,j]);
                }
            }   
        }
        public void initDictCol()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] != 0)
                        this.dictCol[j].Add(this.mat[i, j]);
                }
            }
        }
        public void initDictBlock()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] != 0)
                    {
                        Position p = new Position();
                        p.row = (int)(i / 3);
                        p.col = (int)(j / 3);
                        this.dictBlock[p].Add(this.mat[i, j]);
                    }
                }
            }
        }
        /// <summary>
        /// הפעולה בודקת אם מספר נמצא בשורה 
        /// </summary>
        /// <param name="mat">מטריצה המייצגת סודוקו</param>
        /// <param name="rowNumber">מספר שורה</param>
        /// <param name="number">מספר לבדיקה אם נמצא בשורה</param>
        /// <returns>אמת אם המספר נמצא בשורה, ושקר אחרת</returns>
        public static bool NumberInRow(int[,] mat, int rowNumber, int number)
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
        public static bool NumberInCol(int[,] mat, int colNumber, int number)
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
        public static bool NumberInBlock(int[,] mat, int row, int col,int number)
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
         
        public bool isValidPosition(int number, int row, int col)
        {
            Position p = new Position();
            p.row= (int)(row / 3) * 3;
            p.col = (int)(col / 3) * 3;
            return !this.dictRow[row].Contains(number) && !this.dictCol[col].Contains(number) && !this.dictBlock[p].Contains(number);
        }



        /// <summary>
        /// הפעולה מוצאת את התא הראשון הריק במטריצה (ריק=0)
        /// </summary>
        /// <param name="mat">מטריצה המייצגת סודוקו</param>
        /// <returns>מחזירה struct של position המייצגת שורה ועמודה אם קיים תא ריק במטריצה, אחרת מחזירה null</returns>
        public Position? FindEmptyCell()
        {

            for (int i = 0; i < this.mat.GetLength(0); i++)
            {
                for (int j = 0; j < this.mat.GetLength(1); j++)
                {
                    if (mat[i,j]==0)
                    {
                        Position pos = new Position();
                        pos.row = i;
                        pos.col = j;
                        return pos;
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// הפעולה פותרת את הסודוקו
        /// </summary>
        /// <param name="mat">מטריצה המייצגת סודוקו</param>
        /// <returns>אמת אם קיים פתרון תקין לסודוקו, שקר אחרת</returns>
        public bool SolveSudokuRec()
        {
            if (FindEmptyCell()==null) //תנאי עצירה
            {
                return true;
            }
            Position pos = (Position)FindEmptyCell();
            int row=pos.row;
            int col = pos.col;
            for (int number = 1; number < 10; number++)
            {
                if (isValidPosition(number,row, col))
                {
                    mat[row, col] = number;
                    this.dictRow[row].Add( number);
                    this.dictCol[col].Add(number);
                    this.dictBlock[pos].Add(number);
                    if (SolveSudokuRec())
                    {
                        return true;
                    }
                    else
                    {
                        mat[row, col] = 0; //אם אף אחד מהמספרים 1-9 לא מתאים,
                                           //זה אומר שיש בעיה באחד המספרים הקודמים שמוקמו
                        this.dictRow[row].Remove(number);
                        this.dictCol[col].Remove(number);
                        this.dictBlock[pos].Remove(number);
                    }
                }
                
            }
            return false;

        }
        

 

    }
}
