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
    /// <summary>
    /// The class handles the validation of the Sudoku board (checking for duplicates in the rows, columns, and submatrices).
    /// </summary>
    public class SudokuValidation: IValidation
    {
        private int[,] sudokuMatrix;
        public int[,] SudokuMatrix;

        /// <summary>
        /// The sudoku board as a matrix.
        /// </summary>
        int[,] IValidation.SudokuMatrix 
        {
            get => sudokuMatrix;
        }

        /// <summary>
        /// Initializes a new instance of the SudokuValidation class.
        /// </summary>
        /// <param name="sudokuMatrix">The sudoku board.</param>
        public SudokuValidation(int[,] sudokuMatrix)
        {
            this.sudokuMatrix = sudokuMatrix;
        }


        /// <summary>
        /// The method checks that a row has each number only one time.
        /// </summary>
        /// <param name="row">row number</param>
        /// <returns>True if in a row each digit appears only once.</returns>
        /// <exception cref="ArgumentException">Thrown if a row contains a number more than once</exception>
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
        /// The method checks that a column has each number only one time.
        /// </summary>
        /// <param name="col">column number</param>
        /// <returns>True if in a column each digit appears only once.</returns>
        /// <exception cref="ArgumentException">Thrown if a column contains a number more than once</exception>
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
        /// The method checks that a sub-matrix has each number only one time.
        /// </summary>
        /// <param name="row">row number</param>
        /// <param name="col">col number</param>
        /// <returns>True if in a sub-matrix each digit appears only once.</returns>
        /// <exception cref="ArgumentException">Thrown if a sub-matrix contains a number more than once</exception>
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

        /// <summary>
        /// The function checks that each row, column, and sub-matrix contains each number only once.
        /// </summary>
        /// <exception cref="Exception">Thrown if a row, a column or a sub-matrix contains a number more than once.</exception>
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

