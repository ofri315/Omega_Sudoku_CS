using System;
using System.Collections.Concurrent;
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
        private int[,] mat;
        private Dictionary<int, int[]> dictRow=new Dictionary<int, int[]>();
        private Dictionary<int, int[]> dictCol=new Dictionary<int, int[]>();
        private Dictionary<(int x, int y), int[]> dictBlock=new Dictionary<(int x, int y), int[]>();

        //Constractor
        public Solver(int[,] mat, int start, int end)
        {
            this.mat = mat;
            int n = mat.GetLength(0);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = 0;
            }
            for (int i = 0; i <= n; i++)
            {
                dictRow.Add(i, new int[n]);
            }
            for (int i = 0; i <= n; i++)
            {
                dictCol.Add(i, new int[n]);
            }
            for (int i=0;i< (mat.GetLength(0));i+=3)
            {
                for (int j = 0; j < (mat.GetLength(1)); j+=3)
                {
                    dictBlock.Add(((int)(i / 3), (int)(j / 3)), new int[n]);
                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of rows where each row (key in the dictionary) contains all the numbers in the row (without 0).
        /// </summary>
        public void InitDictRow()
        {
            for (int i = 0; i< mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i,j]!=0)
                    {
                        this.dictRow[i][mat[i, j] - 1]++;
                    }
                        
                }
            }   
        }

        /// <summary>
        /// The function initializes the dictionary of columns where each column (key in the dictionary) contains all the numbers in the columns (without 0).
        /// </summary>
        public void InitDictCol()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] != 0)
                        this.dictCol[j][mat[i, j] - 1]++;
                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of blocks where each block (key in the dictionary) contains all the numbers in the block (without 0).
        /// </summary>
        public void InitDictBlock()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] != 0)
                    {
                        this.dictBlock[((int)(i / 3), (int)(j / 3))][mat[i, j] - 1]++;
                    }
                }
            }
        }

        /// <summary>
        /// The function checks if the number can be placed in the given position
        /// </summary>
        /// <param name="number">number bettween 1-9</param>
        /// <param name="row">row number</param>
        /// <param name="col">col number</param>
        /// <returns>true if the position is valid, false otherwise</returns>
        public bool IsValidPosition(int number, int row, int col)
        {
            return this.dictRow[row][number-1]==0 && this.dictCol[col][number - 1] == 0 && this.dictBlock[((int)(row / 3) , (int)(col / 3) )][number - 1] == 0;
        }


        /// <summary>
        /// The function solves the sudoku using a recursion
        /// </summary>
        /// <param name="row">row number to start from</param>
        /// <param name="col">col number to start from</param>
        /// <returns>true if the function found a solution, false otherwise</returns>
        public bool SolveSudokuRec(int row, int col)
        {
            if (row == 9)
                return true;
            if (col == 9)
                return SolveSudokuRec(row + 1, 0);
            if (this.mat[row, col] != 0)
                return SolveSudokuRec(row, col + 1);
            for (int number = 1; number < 10; number++)
            {
                if (IsValidPosition(number, row, col))
                {
                    this.mat[row, col] = number;
                    this.dictRow[row][number - 1]=1;
                    this.dictCol[col][number - 1] = 1;

                    this.dictBlock[((int)(row / 3), (int)(col / 3))][number-1]=1;

                    if (SolveSudokuRec(row, col + 1))
                        return true;

                    this.mat[row, col] = 0;
                    this.dictRow[row][number - 1] =0;
                    this.dictCol[col][number - 1] = 0;
                    this.dictBlock[((int)(row / 3), (int)(col / 3))][number - 1] = 0;
                }
            }
            return false;//no solution
        }


    }
}
