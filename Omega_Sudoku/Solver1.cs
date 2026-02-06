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
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Omega_Sudoku
{
    internal class Solver1
    {
        private int[,] mat;
        public int[] RowsArr;
        public int[] ColsArr;
        public int[] BlockArr;
        //Constractor
        public Solver1(int[,] mat, int start, int end)
        {
            this.mat = mat;
            int n = mat.GetLength(0);
            this.RowsArr = new int[n];
            this.ColsArr = new int[n];
            this.BlockArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                this.RowsArr[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                this.ColsArr[i] = 0;
            }
            for (int i = 0; i < (mat.GetLength(0)); i += 3)
            {
                for (int j = 0; j < (mat.GetLength(1)); j += 3)
                {
                    this.BlockArr[i + ((int)(j / 3))] = 0;
                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of rows where each row(key in the dictionary) contains all the numbers in the row(without 0).
        /// </summary>
        public void InitArrRow()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {  
                    if (mat[i, j] != 0)
                    {
                        this.RowsArr[i] |= (int)Math.Pow(2, this.mat[i, j] - 1);
                    }

                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of columns where each column(key in the dictionary) contains all the numbers in the columns(without 0).
        /// </summary>
        public void InitArrCol()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] != 0)
                        this.ColsArr[j] |= (int)Math.Pow(2, this.mat[i, j] - 1);
                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of blocks where each block(key in the dictionary) contains all the numbers in the block(without 0).
        /// </summary>
        public void InitArrBlock()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] != 0)
                    {
                        this.BlockArr[(int)(i / 3) * 3 + ((int)(j / 3))] |= (int)Math.Pow(2, this.mat[i, j] - 1);
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
            int numRow = this.RowsArr[row];
            int numCol = this.ColsArr[col];
            int numBlock = this.BlockArr[(int)(row / 3) * 3 + ((int)(col / 3))];
            return ((numRow & (1 << (number - 1))) == 0) && ((numCol & (1 << (number - 1))) == 0) && ((numBlock & (1 << (number - 1))) == 0);
        }
        

        public (int,int) FindNext()
        {
            int countZeroMin = -1;
            int rowMin = -1;
            int colMin = -1;
            for (int row = 0; row < this.mat.GetLength(0); row++)
            {
                for (int col = 0; col < this.mat.GetLength(1); col++)
                {
                    if (this.mat[row,col]==0)
                    {
                        int numRow = this.RowsArr[row];
                        int numCol = this.ColsArr[col];
                        int numBlock = this.BlockArr[(int)(row / 3) * 3 + ((int)(col / 3))];
                        int numtot = numRow | numCol | numBlock;
                        int countZero = CountZero(numtot);
                        
                        if (countZero< countZeroMin || countZeroMin == -1)
                        {
                            countZeroMin = countZero;
                            rowMin = row;
                            colMin = col;
                        }
                        

                    }
                    
                }
            }
            return (rowMin, colMin); 
        }


        public int CountZero(int number)
        {
            int count = 0;
            while(number!=0)
            {
                count += number & 1;
                number>>= 1;
            }
            return this.mat.GetLength(0) - count;
        }
        /// <summary>
        /// The function solves the sudoku using a recursion
        /// </summary>
        /// <param name="n">size of each row, col, and block</param>
        /// <param name="i">row number to start from</param>
        /// <param name="j">col number to start from</param>
        /// <returns>true if the function found a solution, false otherwise</returns>
        public bool SolveSudokuRec(int n)
        {
            (int row, int col) = FindNext();
            if (row == -1 && col == -1)
                return true;
            for (int number = mat.GetLength(0); number >0 ; number--)
            {
                if (IsValidPosition(number, row, col))
                {
                    this.mat[row, col] = number;
                    this.RowsArr[row] |= (1 << (number - 1));
                    this.ColsArr[col] |= (1 << (number - 1));
                    this.BlockArr[(int)(row / 3) * 3 + ((int)(col / 3))] |= (1 << (number - 1));
                    if (SolveSudokuRec(n))
                        return true;
                    this.mat[row, col] = 0;
                    this.RowsArr[row] &= ~(1 << (number - 1));
                    this.ColsArr[col] &= ~(1 << (number - 1));
                    this.BlockArr[(int)(row / 3) * 3 + ((int)(col / 3))] &= ~(1 << (number - 1));
                }
            }
            return false;//no solution
        }
        public void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool Solve()
        {
            InitArrRow();
            InitArrCol();
            InitArrBlock();
            if (SolveSudokuRec(mat.GetLength(0)))
                return true;
            else
            {
                throw new Exception("This Sudoku board is unsolvable.");
            }
        }
    }

}
