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
        private int[] rowsArr;
        private int[] colsArr;
        private int[] blockArr;

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

            this.rowsArr = new int[this.rowColBlocksize];
            this.colsArr = new int[this.rowColBlocksize];
            this.blockArr = new int[this.rowColBlocksize];

            for (int row = 0; row < this.rowColBlocksize; row++)
            {
                this.rowsArr[row] = 0;
            }
            for (int col = 0; col < this.rowColBlocksize; col++)
            {
                this.colsArr[col] = 0;
            }
            for (int row = 0; row < this.rowColBlocksize; row += this.subMatrixSideLength)
            {
                for (int col = 0; col < this.rowColBlocksize; col += this.subMatrixSideLength)
                {
                    this.blockArr[row + ((int)(col / subMatrixSideLength))] = 0;
                }
            }
        }

        /// <summary>
        /// The function initializes the arr of rows where each row(index in the arr) represented by a binary number.
        /// </summary>
        public void InitArrRow()
        {
            for (int row = 0; row < this.rowColBlocksize; row++)
            {
                for (int col = 0; col < this.rowColBlocksize; col++)
                {  
                    if (sudokuMatrix[row, col] != 0)
                    {
                        this.rowsArr[row] |= (int)Math.Pow(2, this.sudokuMatrix[row, col] - 1);
                    }

                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of columns where each column(key in the dictionary) contains all the numbers in the columns(without 0).
        /// </summary>
        public void InitArrCol()
        {
            for (int row = 0; row < this.rowColBlocksize; row++)
            {
                for (int col = 0; col < this.rowColBlocksize; col++)
                {
                    if (sudokuMatrix[row, col] != 0)
                        this.colsArr[col] |= (int)Math.Pow(2, this.sudokuMatrix[row, col] - 1);
                }
            }
        }

        /// <summary>
        /// The function initializes the dictionary of blocks where each block(key in the dictionary) contains all the numbers in the block(without 0).
        /// </summary>
        public void InitArrBlock()
        {
            for (int row = 0; row < this.rowColBlocksize; row++)
            {
                for (int col = 0; col < this.rowColBlocksize; col++)
                {
                    if (sudokuMatrix[row, col] != 0)
                    {
                        this.blockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))] |= (int)Math.Pow(2, this.sudokuMatrix[row, col] - 1);
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
            int numRow = this.rowsArr[row];
            int numCol = this.colsArr[col];
            int numBlock = this.blockArr[(int)(row / this.subMatrixSideLength) * 3 + ((int)(col / this.subMatrixSideLength))];
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
                        int numRow = this.rowsArr[row];
                        int numCol = this.colsArr[col];
                        int numBlock = this.blockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))];
                        int numTot = numRow | numCol | numBlock;
                        int countZero = CountZero(numTot);
                        
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
                    this.rowsArr[row] |= (1 << (number - 1));
                    this.colsArr[col] |= (1 << (number - 1));
                    this.blockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))] |= (1 << (number - 1));
                    if (SolveSudokuRec())
                        return true;
                    this.sudokuMatrix[row, col] = 0;
                    this.rowsArr[row] &= ~(1 << (number - 1));
                    this.colsArr[col] &= ~(1 << (number - 1));
                    this.blockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))] &= ~(1 << (number - 1));
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
