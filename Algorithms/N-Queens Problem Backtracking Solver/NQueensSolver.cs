using System.Collections.Generic;

/// <summary>
/// Provides a solution to the N-Queens problem using a backtracking algorithm.
/// </summary>
public class NQueensSolver
{
    /// <summary>
    /// Finds all unique solutions to the N-Queens problem.
    /// Each solution is represented as an array of strings where 'Q' denotes a queen and '.' an empty space.
    /// </summary>
    /// <param name="n">The size of the board (n x n) and the number of queens to place.</param>
    /// <returns>A list of solutions, each solution is an array of strings representing the board.</returns>
    public List<string[]> SolveNQueens(int n)
    {
        var results = new List<string[]>();
        var queensPositions = new int[n];  // queensPositions[i] = column position of queen in row i
        Backtrack(0, n, queensPositions, results);
        return results;
    }

    /// <summary>
    /// Backtracking helper method that attempts to place queens row by row.
    /// </summary>
    /// <param name="row">Current row to place a queen in.</param>
    /// <param name="n">Total number of rows/columns (size of board).</param>
    /// <param name="queensPositions">Array storing column positions of queens placed so far per row.</param>
    /// <param name="results">List to collect valid board solutions.</param>
    private void Backtrack(int row, int n, int[] queensPositions, List<string[]> results)
    {
        if(row == n)
        {
            results.Add(GenerateBoard(queensPositions, n));
            return;
        }

        // Try placing a queen in every column of the current row
        for(int col = 0; col < n; col++)
        {
            if(IsValid(row, col, queensPositions))
            {
                queensPositions[row] = col;
                Backtrack(row + 1, n, queensPositions, results);
                // No need to reset queensPositions[row] because it will be overwritten or not used again after return
            }
        }
    }

    /// <summary>
    /// Checks if placing a queen at (row, col) does not conflict with previously placed queens.
    /// </summary>
    /// <param name="row">Row to place the queen.</param>
    /// <param name="col">Column to place the queen.</param>
    /// <param name="queensPositions">Positions of queens placed so far.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    private bool IsValid(int row, int col, int[] queensPositions)
    {
        for(int i = 0; i < row; i++)
        {
            int placedCol = queensPositions[i];
            // Check same column
            if(placedCol == col) return false;

            // Check diagonals
            // Difference in rows == difference in columns means on same diagonal
            if(System.Math.Abs(i - row) == System.Math.Abs(placedCol - col)) return false;
        }
        return true;
    }

    /// <summary>
    /// Converts the integer array of queen positions into a board representation.
    /// </summary>
    /// <param name="queensPositions">Array with column positions for each row.</param>
    /// <param name="n">Size of the board.</param>
    /// <returns>Array of strings representing the board.</returns>
    private string[] GenerateBoard(int[] queensPositions, int n)
    {
        var board = new string[n];
        for(int i = 0; i < n; i++)
        {
            var rowChars = new char[n];
            for(int j = 0; j < n; j++)
            {
                rowChars[j] = queensPositions[i] == j ? 'Q' : '.';
            }
            board[i] = new string(rowChars);
        }
        return board;
    }
}
