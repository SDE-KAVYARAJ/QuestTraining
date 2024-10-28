using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Minesweeper
    {
        private const int GridSize = 5;  // Size of the grid
        private const int MineCount = 3;  // Number of mines
        private CellState[,] grid = new CellState[GridSize, GridSize]; // The grid for the mines
        private bool[,] revealed = new bool[GridSize, GridSize]; // Tracks revealed cells
        

        public Minesweeper()
        {
            InitializeGrid(); // Setup the grid with mines and counts
            RenderGrid(); // Display the initial grid
        }
        private void InitializeGrid()
        {
            var random = new Random();
            // Place mines randomly
            for (int placedMines = 0; placedMines < MineCount;)
            {
                int x = random.Next(GridSize);
                int y = random.Next(GridSize);

                if (grid[x, y] != CellState.Mine)
                {
                    grid[x, y] = CellState.Mine;
                    placedMines++;
                }
            }

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (grid[i, j] != CellState.Mine)
                    {
                        int mineCount = CountAdjacentMines(i, j);
                        if (mineCount > 0)
                        {
                            grid[i, j] = mineCount == 1 ? CellState.OneMine : CellState.TwoMines;
                        }
                    }
                }
            }
        }
        private int CountAdjacentMines(int x, int y)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue; // Skip the current cell
                    int nx = x + i;
                    int ny = y + j;

                    // Check bounds and count mines
                    if (nx >= 0 && ny >= 0 && nx < GridSize && ny < GridSize && grid[nx, ny] == CellState.Mine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void RenderGrid()
        {
            Console.WriteLine("\nCurrent Grid:");
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (revealed[i, j])
                    {
                        if (grid[i, j] == CellState.Mine)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Color for mines

                            Console.Write(" * "); // Mine
                        }
                        else if (grid[i, j] == CellState.OneMine)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" 1 "); // One adjacent mine
                        }
                        else if (grid[i, j] == CellState.TwoMines)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; // Color for two adjacent mines
                            Console.Write(" 2 "); // Two adjacent mines
                        }
                        else
                        {

                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" . "); // Empty
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" X "); // Unrevealed
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            
        }
        // Reveal a cell and check if it contains a mine
        public bool RevealCell(int x, int y)
        {
            if (x < 0 || x >= GridSize || y < 0 || y >= GridSize || revealed[x, y])
            {
                Console.WriteLine("Invalid input or cell already revealed.");
                return true; // Continue playing
            }

            revealed[x, y] = true; // Mark the cell as revealed

            if (grid[x, y] == CellState.Mine)
            {
                Console.WriteLine("Boom! You hit a mine. Game over.");
                return false; // Game over
            }
            else
            {
                Console.WriteLine($"Cell [{x + 1},{y + 1}] revealed. No mine here.");
                RenderGrid(); // Show the grid after revealing the cell
                return true; // Continue playing
            }
        }
        public void Play()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\nEnter the cell to reveal (row and column 1-5): ");
                Console.Write("Row: ");
                int x = int.Parse(Console.ReadLine()) - 1; // Convert to 0-based index
                Console.Write("Column: ");
                int y = int.Parse(Console.ReadLine()) - 1; // Convert to 0-based index

                playing = RevealCell(x, y); // Reveal the chosen cell
            }
        }

    }
}
