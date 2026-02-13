using Omega_Sudoku;
namespace Omega_Sudoku.Tests
{
    public class UnitTestValidSudokus
    {
        [Fact]
        public void TestWithValidSudoku1()
        {
            string solvedExpression = new SudokuManager().SolveForTests("070000043040009610800634900094052000358460020000800530080070091902100005007040802");
            string expected = "679518243543729618821634957794352186358461729216897534485276391962183475137945862";
            Assert.Equal(solvedExpression, expected);
            
        }

        [Fact]
        public void TestWithValidSudoku2()
        {
            string solvedExpression = new SudokuManager().SolveForTests("000030007480960501063570820009610203350097006000005094000000005804706910001040070");
            string expected = "925831467487962531163574829749618253352497186618325794276189345834756912591243678";
            Assert.Equal(solvedExpression, expected);
        }


        [Fact]
        public void TestWithValidSudoku3()
        {
            string solvedExpression = new SudokuManager().SolveForTests("407851030000470805001032640018723400670089020930604708349208000000300269720090384");
            string expected = "467851932293476815851932647518723496674589123932614758349268571185347269726195384";
            Assert.Equal(solvedExpression, expected);
        }



        [Fact]
        public void TestWithValidSudoku4()
        {
            string solvedExpression = new SudokuManager().SolveForTests("600000701010079603273801000800750002007018000021040008180025300030004060400307200");
            string expected = "694532781518479623273861954846753192957218436321946578189625347732194865465387219";
            Assert.Equal(solvedExpression, expected);

        }


        [Fact]
        public void TestWithValidSudoku5()
        {
            string solvedExpression = new SudokuManager().SolveForTests("300006205052300000984000607840001579020058043000700060500403001270000000009502000");
            string expected = "317846295652397418984125637843261579726958143195734862568473921271689354439512786";
            Assert.Equal(solvedExpression, expected);

        }

        [Fact]
        public void TestWithValidSudoku6()
        {
            string solvedExpression = new SudokuManager().SolveForTests("000060080020000000001000000070000102500030000000000400004201000300700600000000050");
            string expected = "947165283823974516651328947478596132516432879239817465764251398385749621192683754";
            Assert.Equal(solvedExpression,expected );

        }


        [Fact]
        public void TestWithValidSudoku7()
        {
            string solvedExpression = new SudokuManager().SolveForTests("000000014000708000000000000104005000000200830600000000500040000030000700000090001");
            string expected = "857926314341758692962431578184365927795214836623879145519647283436182759278593461";
            Assert.Equal(solvedExpression, expected);

        }


        [Fact]
        public void TestWithValidSudoku8()
        {
            string solvedExpression = new SudokuManager().SolveForTests("900000052300004000000010000010000040080200000000000300000790008400000200000500000");
            string expected = "948376152351924687762815934213657849684239571579481326125793468437168295896542713";
            Assert.Equal(solvedExpression, expected);

        }


        [Fact]
        public void TestWithValidSudoku9()
        {
            string solvedExpression = new SudokuManager().SolveForTests("000000230700010000000000050002500000030000700000090000600207000800000001000300400");
            string expected = "461875239725913864398426157972534618534168792186792543613247985847659321259381476";
            Assert.Equal(solvedExpression, expected);

        }

        [Fact]
        public void TestWithValidSudoku10()
        {
            string solvedExpression = new SudokuManager().SolveForTests("000000012000035000000600070700000300000400800100000000000120000080000040050000600");
            string expected = "673894512912735486845612973798261354526473891134589267469128735287356149351947628";
            Assert.Equal(solvedExpression, expected);

        }


        [Fact]
        public void TestWithValidSudoku11()
        {
            string solvedExpression = new SudokuManager().SolveForTests("200000060000300040760000000508000200000061000000400000000030709010000000000700000");
            string expected = "234597168189326547765814392548973216973261854621458973456132789317689425892745631";
            Assert.Equal(solvedExpression, expected);

        }


    }
}