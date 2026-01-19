using System.Runtime.InteropServices;

namespace Omega_Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConvertSudoku convertor=new ConvertSudoku();
            int[,] mat = convertor.ConvertStringToMatrix("800000070006010053040600000000080400003000700020005038000000800004050061900002000");
            Solver.FindEmptyCell(mat);
        }
    }
}
