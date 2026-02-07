using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Omega_Sudoku
{
    public class SudokuValidation: IValidation
    {
        private int[,] sudokuMatrix;
        public int[,] SudokuMatrix;
        int[,] IValidation.SudokuMatrix 
        {
            get => sudokuMatrix;
        }
        public SudokuValidation(int[,] sudokuMatrix)
        {
            this.sudokuMatrix = sudokuMatrix;
        }


        /// <summary>
        /// The method checks that each row has each number only one time
        /// </summary>
        /// <returns>True if in any row each digit appears only once, false otherwise.</returns>
        public bool CheckRow(int row)
        {
            int[] countDigArr = new int[sudokuMatrix.GetLength(0)+1];
            for (int i = 0;  i < countDigArr.Length;  i++)
            {
                countDigArr[i] = 0;
            }
            for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
            {
                countDigArr[sudokuMatrix[row, col]]++;
            }
            for (int i = 1; i < countDigArr.Length; i++)
            {
                if (countDigArr[i] > 1)
                    throw new ArgumentException(string.Format("The number {0} appears more then once in row number:{1}", i, row));

            }
            return true;
        }

        /// <summary>
        /// The method checks that each column has each number only one time
        /// </summary>
        /// <returns>True if in any column each digit appears only once, false otherwise.</returns>
        public bool CheckColumn(int col)
        {
            int[] countDigArr = new int[sudokuMatrix.GetLength(1) + 1];
            for (int i = 0; i < countDigArr.Length; i++)
            {
                countDigArr[i] = 0;
            }
            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                countDigArr[sudokuMatrix[row,col]]++;
            }
            for (int i = 1; i < countDigArr.Length; i++)
            {
                if (countDigArr[i] > 1)
                    throw new ArgumentException(string.Format("The number {0} appears more then once in col number:{1}", i, col));
            }
            return true;
        }

        /// <summary>
        /// The method checks that each Block has each number only one time
        /// </summary>
        /// <param name="sudokuMat">sudoku matrix</param>
        /// <returns>True if in any Block each digit appears only once, false otherwise.</returns>
        public bool CheckBlock(int row, int col)
        {
            int[] countDigArr = new int[sudokuMatrix.GetLength(1) + 1];
            for (int i = 0; i < countDigArr.Length; i++)
            {
                countDigArr[i] = 0;
            }
            for (int rowIndex = 0; rowIndex < (int)Math.Sqrt(sudokuMatrix.GetLength(0)); rowIndex++)
            {
                for (int colIndex = 0; colIndex < (int)Math.Sqrt(sudokuMatrix.GetLength(1)); colIndex++)
                {
                    int curr = sudokuMatrix[row + rowIndex, col + colIndex];
                    countDigArr[curr]++;
                }
            }
            for (int i = 1; i < countDigArr.Length; i++)
            {
                if (countDigArr[i] > 1)
                    throw new ArgumentException(string.Format("The number {0} appears more then once in block number:{1}", i, (int)(row / 3) * 3 + ((int)(col / 3))));
            }
            return true;
        }


        public void CheckRowsColsBlocks()
        {
            try
            {
                for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
                {
                    CheckRow(row);
                }
                for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
                {
                    CheckColumn(col);
                }
                for (int row = 0; row < sudokuMatrix.GetLength(0); row+=(int)Math.Sqrt(sudokuMatrix.GetLength(0)))
                {
                    for (int col = 0; col < sudokuMatrix.GetLength(1); col+= (int)Math.Sqrt(sudokuMatrix.GetLength(1)))
                    {
                        CheckBlock(row, col);
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }


    }
}

