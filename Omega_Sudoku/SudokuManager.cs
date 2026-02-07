using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    public class SudokuManager
    {
        private string sudokuExpression;
        public SudokuManager(string sudokuExpression)
        {
            this.sudokuExpression = sudokuExpression;
        }
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
