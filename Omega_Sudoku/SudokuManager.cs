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
        public int[,]? SolveSudoku()
        {
            try
            {
                SudokuInitialValidation sudokuInitialValidation = new SudokuInitialValidation(this.sudokuExpression);
                sudokuInitialValidation.CheckAllInitialValidations();
                ConvertSudoku convertSudoku = new ConvertSudoku();
                int[,] SudokuMatrix = convertSudoku.ConvertStringToMatrix(this.sudokuExpression);
                Solver solver = new Solver(SudokuMatrix);
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
                ConvertSudoku convertSudoku=new ConvertSudoku();
                return convertSudoku.ConvertMatrixToString(sudokuMat);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
