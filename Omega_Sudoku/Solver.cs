using Omega_Sudoku.Interfaces;
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
    /// <summary>
    /// The class is responsible for finding a solution to the Sudoku puzzle. (inherits from ISolver interface).
    /// </summary>
    public class Solver : ISolver
    {
        private int[,] sudokuMatrix;
        public int[,] SudokuMatrix;
        private int[] rowsArr;
        private int[] colsArr;
        private int[] blockArr;

        private int rowColBlocksize;
        private int subMatrixSideLength;

        /// <summary>
        /// The sudoku board as a matrix.
        /// </summary>
        int[,] ISolver.SudokuMatrix
        {
            get => sudokuMatrix;  
        }

        /// <summary>
        /// Initializes a new instance of the Solver class.
        /// </summary>
        /// <param name="matrix">The sudoku as a matrix.</param>
        public Solver(int[,] matrix)
        {
            this.sudokuMatrix = matrix;

            this.rowColBlocksize = matrix.GetLength(0);
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
        /// The function initializes the arr of rows where each row represented by a binary number.
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
        ///The function initializes the arr of columns where each column represented by a binary number.
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
        ///The function initializes the arr of blocks where each block represented by a binary number.
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
        /// The function counts how many zeros are there in a binary number. (which is the number of possible options in a row/col/block).
        /// </summary>
        /// <param name="number">a number to count how many zeros it has.</param>
        /// <returns>number of zeros (which is the number of options).</returns>
        public int CountOptions(int number)
        {
            int count = 0;
            while (number != 0)
            {
                count += number & 1;
                number >>= 1;
            }
            return this.rowColBlocksize - count;
        }

        /// <summary>
        /// The function finds the cell with the minimum number of possible numbers (which is the next cell).
        /// </summary>
        /// <returns>row and column of the next cell.</returns>
        public (int,int) FindNext()
        {
            int countOptionsMin = -1;
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
                        int countOptions = CountOptions(numTot);
                        
                        if (countOptions < countOptionsMin || countOptionsMin == -1)
                        {
                            countOptionsMin = countOptions;
                            rowMin = row;
                            colMin = col;
                        }
                        if (countOptions == 1)
                        {
                            return (row, col);
                        }
                        if (CountOptions(numRow) == 1 || CountOptions(numCol) == 1 || CountOptions(numBlock) == 1)
                        {
                            return (row, col);
                        }
                        if (countOptions == 0)
                        {
                            return (row, col);
                        }
                    }
                }
            }
            return (rowMin, colMin); 
        }



        /// <summary>
        /// The function checks if the number can be placed in the given position
        /// </summary>
        /// <param name="number">A number to check if valid in the given position.</param>
        /// <param name="row">row number</param>
        /// <param name="col">col number</param>
        /// <returns>True if the position is valid, false otherwise</returns>
        public bool IsValidPosition(int number, int row, int col)
        {
            int numRow = this.rowsArr[row];
            int numCol = this.colsArr[col];
            int numBlock = this.blockArr[(int)(row / this.subMatrixSideLength) * this.subMatrixSideLength + ((int)(col / this.subMatrixSideLength))];
            return ((numRow & (1 << (number - 1))) == 0) && ((numCol & (1 << (number - 1))) == 0) && ((numBlock & (1 << (number - 1))) == 0);
        }

        /// <summary>
        /// The function solves the sudoku using a recursion.
        /// </summary>
        /// <returns>True if the function found a solution to the puzzle, false otherwise.</returns>
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
            return false;
        }

        /// <summary>
        /// The function manages the sudoku solver functions.
        /// </summary>
        /// <returns>True if there is a solution for the Sudoku puzzle.</returns>
        /// <exception cref="Exception">Thrown if the Sudoku is unsolvable.</exception>
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
