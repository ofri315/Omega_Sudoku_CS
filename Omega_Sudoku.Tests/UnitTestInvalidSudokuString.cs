using Omega_Sudoku;
namespace Omega_Sudoku.Tests
{
    public class UnitTestInvalidSudokuString
    {
        [Fact]
        public void TestWithEmptyString()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests(""));
            string expected = "The Sudoku String is empty";
            Assert.Equal(exception.Message, expected);
        }

        [Fact]
        public void TestWithInvalidCharacters()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("07000a0430400096108*0634900094052000358460020000800530080070091902100005007040802"));
            string expected = "The string contains invalid characters.";
            Assert.Equal(exception.Message, expected);
        }

        [Fact]
        public void TestWithLongString()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("80000007000601005304060000000008040000300070002000503800000080000405006190000200000"));
            string expected = "The length of the string is bigger then 81.";
            Assert.Equal(exception.Message, expected);
        }


        [Fact]
        public void TestWithLengthNotSquareRoot()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("8000000700060100530406000000000804000030007000200050380000008000040500619000"));
            string expected = "The length of the Sudoku string is not a square root.";
            Assert.Equal(exception.Message, expected);
        }

        [Fact]
        public void TestWithSubMatrixLengthNotSquareRoot()
        {
            var exception = Assert.Throws<Exception>(() => new SudokuManager().SolveForTests("300006006120204365005201460510002034"));
            string expected = "The size of the sub matrices is not a square root.";
            Assert.Equal(exception.Message, expected);
        }




    }
}
