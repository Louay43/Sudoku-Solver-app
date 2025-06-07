using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class NativeSudoku
    {
        // Import the native C function from the DLL
        [DllImport("sudoku.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void solveSudoku(int[,] input, int[,] output); // The input is a 9x9 grid of integers, and the output will be the solved Sudoku grid
    }
}
