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
    public class Solver : ISolver
    {
        private int[,] sudokuMatrix;
        public int[,] SudokuMatrix;
        private int[] RowsArr;
        private int[] ColsArr;
        private int[] BlockArr;

        private int rowColBlocksize;
        private int subMatrixSideLength;


        int[,] ISolver.SudokuMatrix
        {
            get => sudokuMatrix;  
        }

        //Constractor
        public Solver(int[,] mat)
        {
            this.sudokuMatrix = mat;
            this.rowColBlocksize = mat.GetLength(0);
            this.subMatrixSideLength = (int)Math.Sqrt(rowColBlocksize);
            this.RowsArr = new int[this.rowColBlocksize];
            this.ColsArr = new int[this.rowColBlocksize];
            this.BlockArr = new int[this.rowColBlocksize];

            for (int i = 0; i < this.rowColBlocksize; i++)
            {
                this.RowsArr[i] = 0;
            }
            for (int i = 0; i < this.rowColBlocksize; i++)
            {
                this.ColsArr[i] = 0;
            }
            for (int i = 0; i < (mat.GetLength(0)); i += this.subMatrixSideLength)
            {
                for (int j = 0; j < (mat.GetLength(1)); j += this.subMatrixSideLength)
                {
                    this.BlockArr[i + ((int)(j / subMatrixSideLength))] = 0;
                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of rows where each row(key in the dictionary) contains all the numbers in the row(without 0).
        /// </summary>
        public void InitArrRow()
        {
            for (int i = 0; i < this.rowColBlocksize; i++)
            {
                for (int j = 0; j < this.rowColBlocksize; j++)
                {  
                    if (sudokuMatrix[i, j] != 0)
                    {
                        this.RowsArr[i] |= (int)Math.Pow(2, this.sudokuMatrix[i, j] - 1);
                    }

                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of columns where each column(key in the dictionary) contains all the numbers in the columns(without 0).
        /// </summary>
        public void InitArrCol()
        {
            for (int i = 0; i < this.rowColBlocksize; i++)
            {
                for (int j = 0; j < this.rowColBlocksize; j++)
                {
                    if (sudokuMatrix[i, j] != 0)
                        this.ColsArr[j] |= (int)Math.Pow(2, this.sudokuMatrix[i, j] - 1);
                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of blocks where each block(key in the dictionary) contains all the numbers in the block(without 0).
        /// </summary>
        public void InitArrBlock()
        {
            for (int i = 0; i < this.rowColBlocksize; i++)
            {
                for (int j = 0; j < this.rowColBlocksize; j++)
                {
                    if (sudokuMatrix[i, j] != 0)
                    {
                        this.BlockArr[(int)(i / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(j / this.subMatrixSideLength))] |= (int)Math.Pow(2, this.sudokuMatrix[i, j] - 1);
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
            int numBlock = this.BlockArr[(int)(row / this.subMatrixSideLength) * 3 + ((int)(col / this.subMatrixSideLength))];
            return ((numRow & (1 << (number - 1))) == 0) && ((numCol & (1 << (number - 1))) == 0) && ((numBlock & (1 << (number - 1))) == 0);
        }
        

        public (int,int) FindNext()
        {
            int countZeroMin = -1;
            int rowMin = -1;
            int colMin = -1;
            for (int row = 0; row < this.rowColBlocksize; row++)
            {
                for (int col = 0; col < this.rowColBlocksize; col++)
                {
                    if (this.sudokuMatrix[row,col]==0)
                    {
                        int numRow = this.RowsArr[row];
                        int numCol = this.ColsArr[col];
                        int numBlock = this.BlockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))];
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
            return this.rowColBlocksize - count;
        }
        /// <summary>
        /// The function solves the sudoku using a recursion
        /// </summary>
        /// <param name="n">size of each row, col, and block</param>
        /// <param name="i">row number to start from</param>
        /// <param name="j">col number to start from</param>
        /// <returns>true if the function found a solution, false otherwise</returns>
        public bool SolveSudokuRec()
        {
            (int row, int col) = FindNext();
            if (row == -1 && col == -1)
                return true;
            for (int number = this.rowColBlocksize; number >0 ; number--)
            {
                if (IsValidPosition(number, row, col))
                {
                    
                    this.sudokuMatrix[row, col] = number;
                    this.RowsArr[row] |= (1 << (number - 1));
                    this.ColsArr[col] |= (1 << (number - 1));
                    this.BlockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))] |= (1 << (number - 1));
                    if (SolveSudokuRec())
                        return true;
                    this.sudokuMatrix[row, col] = 0;
                    this.RowsArr[row] &= ~(1 << (number - 1));
                    this.ColsArr[col] &= ~(1 << (number - 1));
                    this.BlockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))] &= ~(1 << (number - 1));
                }
            }
            return false;//no solution
        }

        public bool Solve()
        {
            InitArrRow();
            InitArrCol();
            InitArrBlock();
            if (SolveSudokuRec())
                return true;
            else
            {
                throw new Exception("This Sudoku board is unsolvable.");
            }
        }
    }

}
