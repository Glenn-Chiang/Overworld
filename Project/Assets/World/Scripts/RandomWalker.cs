
// Generates a boolean grid where true represents walls/obstacles
// and false represents empty space
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class RandomWalker
{
    private readonly bool[,] grid;
    private readonly int stepLimit;

    // Initialize walker with grid dimensions
    // stepLimit refers to the number of cells in the grid that will be marked as empty
    public RandomWalker(int rows, int cols, int stepLimit)
    {
        grid = new bool[rows, cols];
        this.stepLimit = stepLimit;
        // Set every cell to be a wall
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = true;
            }
        }
    }

    private (int, int)[] directions = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

    public bool[,] Generate()
    {
        if (stepLimit == 0) return grid;

        int steps = 0;

        // Select random starting cell
        int currentRow = Random.Range(0, grid.GetLength(0));
        int currentCol = Random.Range(0, grid.GetLength(1));

        grid[currentRow, currentCol] = false;
        steps++;

        while (steps < stepLimit)
        {
            // Pick a random direction to "walk" to
            var dir = RandomDirection();
            int nextRow = currentRow + dir.Item1;
            int nextCol = currentCol + dir.Item2;

            if (!InBounds(nextRow, nextCol)) continue;
            
            currentRow = nextRow;
            currentCol = nextCol;
            
            if (grid[nextRow, nextCol])
            {
                grid[currentRow, currentCol] = false;
                steps++;
            }
        }

        return grid;
    }

    private (int, int) RandomDirection()
    {
        return RandomUtils.RandomSelect(directions);
    }

    private bool InBounds(int row, int col)
    {
        return row >= 0 && col >= 0 && row < grid.GetLength(0) && col < grid.GetLength(1);
    }
}