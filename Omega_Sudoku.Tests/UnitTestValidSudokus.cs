using Omega_Sudoku;
namespace Omega_Sudoku.Tests
{
    public class UnitTestValidSudokus
    {
        [Fact]
        public void TestWithValidSudoku1()
        {
            SudokuManager sudokuManager = new SudokuManager("070000043040009610800634900094052000358460020000800530080070091902100005007040802");
            string solvedExpression = sudokuManager.SolveForTests();
            string expected = "679518243543729618821634957794352186358461729216897534485276391962183475137945862";
            Assert.Equal(solvedExpression, expected);
            
        }

        [Fact]
        public void TestWithValidSudoku2()
        {
            SudokuManager sudokuManager = new SudokuManager("000030007480960501063570820009610203350097006000005094000000005804706910001040070");
            string solvedExpression = sudokuManager.SolveForTests();
            string expected = "925831467487962531163574829749618253352497186618325794276189345834756912591243678";
            Assert.Equal(solvedExpression, expected);
        }


        [Fact]
        public void TestWithValidSudoku3()
        {
            SudokuManager sudokuManager = new SudokuManager("407851030000470805001032640018723400670089020930604708349208000000300269720090384");
            string solvedExpression = sudokuManager.SolveForTests();
            string expected = "467851932293476815851932647518723496674589123932614758349268571185347269726195384";
            Assert.Equal(solvedExpression, expected);
        }



        [Fact]
        public void TestWithValidSudoku4()
        {
            SudokuManager sudokuManager = new SudokuManager("600000701010079603273801000800750002007018000021040008180025300030004060400307200");
            string solvedExpression = sudokuManager.SolveForTests();
            string expected = "694532781518479623273861954846753192957218436321946578189625347732194865465387219";
            Assert.Equal(solvedExpression, expected);

        }


        [Fact]
        public void TestWithValidSudoku5()
        {
            SudokuManager sudokuManager = new SudokuManager("300006205052300000984000607840001579020058043000700060500403001270000000009502000");
            string solvedExpression = sudokuManager.SolveForTests();
            string expected = "317846295652397418984125637843261579726958143195734862568473921271689354439512786";
            Assert.Equal(solvedExpression, expected);

        }

        [Fact]
        public void TestWithValidSudoku6()
        {
            SudokuManager sudokuManager = new SudokuManager("000060080020000000001000000070000102500030000000000400004201000300700600000000050");
            string solvedExpression = sudokuManager.SolveForTests();
            string expected = "947165283823974516651328947478596132516432879239817465764251398385749621192683754";
            Assert.Equal(solvedExpression,expected );

        }



       


    }
}