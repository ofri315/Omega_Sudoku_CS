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
    class SudokuValidation
    {
        private string sudokuExpression;
        public SudokuValidation(string sudokuExpression)
        {
            this.sudokuExpression = sudokuExpression;
        }


        /// <summary>
        /// The method checks that each row has each number only one time
        /// </summary>
        /// <param name="sudokuMat">sudoku matrix</param>
        /// <returns>True if in any row each digit appears only once, false otherwise.</returns>
        public bool CheckRow(int[,] sudokuMat, int row)
        {
            int[] countDigArr = new int[sudokuMat.GetLength(0)+1];
            for (int i = 0;  i < countDigArr.Length;  i++)
            {
                countDigArr[i] = 0;
            }
            for (int i = 0; i < sudokuMat.GetLength(1); i++)
            {
                countDigArr[sudokuMat[row, i]]++;
            }
            for (int i = 1; i < countDigArr.Length; i++)
            {
                if (countDigArr[i] > 1)
                    return false;
                else
                    throw new ArgumentException(string.Format("The number {0} appears more then once in row number:{1}", i+1, row));

            }
            return true;
        }

        /// <summary>
        /// The method checks that each column has each number only one time
        /// </summary>
        /// <param name="sudokuMat">sudoku matrix</param>
        /// <returns>True if in any column each digit appears only once, false otherwise.</returns>
        public bool CheckColumn(int[,] sudokuMat, int col)
        {
            int[] countDigArr = new int[sudokuMat.GetLength(1) + 1];
            for (int i = 0; i < countDigArr.Length; i++)
            {
                countDigArr[i] = 0;
            }
            for (int i = 0; i < sudokuMat.GetLength(0); i++)
            {
                countDigArr[sudokuMat[i,col]]++;
            }
            for (int i = 1; i < countDigArr.Length; i++)
            {
                if (countDigArr[i] > 1)
                    return false;
                else
                    throw new ArgumentException(string.Format("The number {0} appears more then once in col number:{1}", i + 1, col));
            }
            return true;
        }

        /// <summary>
        /// The method checks that each Block has each number only one time
        /// </summary>
        /// <param name="sudokuMat">sudoku matrix</param>
        /// <returns>True if in any Block each digit appears only once, false otherwise.</returns>
        public bool CheckBlock(int[,] sudokuMat, int row, int col)
        {
            int[] countDigArr = new int[sudokuMat.GetLength(1) + 1];
            for (int i = 0; i < (int)Math.Sqrt(sudokuMat.GetLength(0)); i++)
            {
                for (int j = 0; j < (int)Math.Sqrt(sudokuMat.GetLength(1)); j++)
                {
                    int curr = sudokuMat[row + i, col + j];
                    countDigArr[curr]++;
                }
            }
            for (int i = 1; i < countDigArr.Length; i++)
            {
                if (countDigArr[i] > 1)
                    return false;
                else
                    throw new ArgumentException(string.Format("The number {0} appears more then once in block number:{1}", i + 1, (int)(row / 3) * 3 + ((int)(col / 3))));
            }
            return true;
        }


        public bool CheckRowsColsBlocks(int[,] sudokuMat)
        {
            try
            {
                for (int i = 0; i < sudokuMat.GetLength(0); i++)
                {
                    if (!CheckRow(sudokuMat, i))
                        return false;
                }
                for (int i = 0; i < sudokuMat.GetLength(1); i++)
                {
                    if (!CheckColumn(sudokuMat, i))
                        return false;
                }
                for (int i = 0; i < sudokuMat.GetLength(0); i++)
                {
                    for (int j = 0; j < sudokuMat.GetLength(1); j++)
                    {
                        if (!CheckBlock(sudokuMat, i, j))
                            return false;
                    }
                }
                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }


    }
}

