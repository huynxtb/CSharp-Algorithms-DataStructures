# N-Queens Problem Backtracking Solver

## 1. Introduction
The N-Queens problem is a classic combinatorial puzzle in which N queens must be placed on an N×N chessboard in such a way that no two queens attack each other. This means no two queens may share the same row, column, or diagonal. This problem is used to demonstrate backtracking algorithms and constraint satisfaction.

This implementation provides a reusable class `NQueensSolver` that solves the problem for any integer N and returns all unique board configurations.

## 2. Usage
// Create an instance of the solver
NQueensSolver solver = new NQueensSolver();

// Solve for any N, for example 8
int n = 8;
List<string[]> solutions = solver.SolveNQueens(n);

// The result is a list of solutions, where each solution is an array of strings
// Each string represents one row, with 'Q' marking a queen and '.' an empty cell
foreach (string[] board in solutions)
{
    foreach (string row in board)
    {
        System.Console.WriteLine(row);
    }
    System.Console.WriteLine();
}

## 3. Detailed Explanation
The key idea is a backtracking approach that places queens one row at a time:

- Keep track of columns where queens are placed using an integer array where the index is the row and the value is the column.
- For each row, attempt placing the queen in every column and check if it's valid.
- The `IsValid` method ensures no two queens share the same column or diagonal by comparing current proposed position against all previously placed queens.
- If a valid position is found for a row, recursively attempt to place a queen in the next row.
- When the base case (row == n) is reached, a valid board configuration is found and saved.

This technique efficiently prunes invalid configurations early, avoiding unnecessary computations.

## 4. Complexity Analysis
- **Time Complexity:** Worst case is O(N!), since the first row has N choices, second not more than N-1, and so forth. However, the pruning via validity checks substantially reduces the search space.
- **Space Complexity:** O(N^2) for storing all solutions in worst case (depending on number of solutions). The recursion stack and queens position arrays use O(N) space.

This implementation balances clarity, correctness, and efficiency suitable for integration in larger projects needing N-Queens solutions.