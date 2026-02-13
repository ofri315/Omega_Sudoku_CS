using Omega_Sudoku;

namespace Omega_Sudoku.Tests
{
    public class UnitTestInvalidSudokus
    {
        [Fact]
        public void TestWithSameNumberInRow()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("100100027000304015500170683430962001900007256006810000040600030012043500058001000"));
            string expected = "The number 1 appears more then once in row number:0";
            Assert.Equal(exception.Message, expected);
        }


        [Fact]
        public void TestWithSameNumberInCol()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("800000070806010053040600000000080400003000700020005038000000800004050061900002000"));
            string expected = "The number 8 appears more then once in col number:0";
            Assert.Equal(exception.Message, expected);
        }


        [Fact]
        public void TestWithSameNumberInBlock()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("800000070406010053040600000000080400003000700020005038000000800004050061900002000")); 
            string expected = "The number 4 appears more then once in block number:0";
            Assert.Equal(exception.Message, expected);
        }



        [Fact]
        public void TestWithUnsolveableSudoku()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("820000000003600000070090200050007000000045700000100030001000068008500010090000400"));
            string expected = "This Sudoku board is unsolvable.";
            Assert.Equal(exception.Message, expected);
        }
    }
}
