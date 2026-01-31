using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Omega_Sudoku
{
    internal class Position
    {
        public int row;
        public int column;
        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        public bool Equals(Position other)
        {
            return this.Equals(other as Position);
        }
        public string ToString()
        {
            return row+"," + column;    
        }
    }
}
