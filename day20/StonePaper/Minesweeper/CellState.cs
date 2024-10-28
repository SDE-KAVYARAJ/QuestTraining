using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal enum CellState
    {
        Empty,       // No adjacent mines
        Mine,        // Contains a mine
        OneMine,       //1 adjacent mine
        TwoMines,       //2 adjacent mine
    }
}