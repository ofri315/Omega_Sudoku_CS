using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    /// <summary>
    /// The class is responsible for managing all functions for solving the Sudoku board.
    /// </summary>
    public class SudokuManager
    {
        private string sudokuExpression;

        /// <summary>
        /// Initializes a new instance of the SudokuManager class.
        /// </summary>
        /// <param name="sudokuExpression">A string representing the Sudoku board.</param>
        public SudokuManager(string sudokuExpression)
        {
            this.sudokuExpression = sudokuExpression;
        }

        /// <summary>
        /// The function handles solving the Sudoku puzzle (including validity checks and conversion to a matrix).
        /// </summary>
        /// <returns>the Solved Sudoku matrix.</returns>
        /// <exception cref="Exception">Thrown if there is a problem with the sudoku puzzle with a suitable message.</exception>
        public int[,] SolveSudoku()
        {
            try
            {
                SudokuInitialValidation InitialValidation = new SudokuInitialValidation(this.sudokuExpression);
                InitialValidation.CheckAllInitialValidations();

                ConvertSudoku convertor = new ConvertSudoku();
                int[,] SudokuMatrix = convertor.ConvertStringToMatrix(this.sudokuExpression);

                SudokuValidation Validation = new SudokuValidation(SudokuMatrix);
                Validation.CheckRowsColsBlocks();

                ISolver solver = new Solver(SudokuMatrix);
                solver.Solve();

                return SudokuMatrix;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// The function handles solving the Sudoku puzzle and converting it back to a string for the unit tests.
        /// </summary>
        /// <returns>the Solved Sudoku expression.</returns>
        /// <exception cref="Exception">Thrown if there is a problem with the sudoku puzzle with a suitable message.</exception>
        public string SolveForTests()
        {
            try
            {
                int[,] sudokuMat=SolveSudoku();
                ConvertSudoku convertor=new ConvertSudoku();
                return convertor.ConvertMatrixToString(sudokuMat);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
