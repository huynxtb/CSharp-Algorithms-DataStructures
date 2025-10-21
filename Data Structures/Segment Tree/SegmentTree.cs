using System;

/// <summary>
/// Generic Segment Tree implementation for integer arrays supporting range sum queries and point updates.
/// </summary>
public class SegmentTree
{
    private readonly int[] tree;       // The segment tree array
    private readonly int[] data;       // The original input array
    private readonly int n;            // Size of the original array

    /// <summary>
    /// Initializes and builds the segment tree from the input array.
    /// </summary>
    /// <param name="inputArray">Input integer array to build the segment tree from</param>
    public SegmentTree(int[] inputArray)
    {
        if(inputArray == null || inputArray.Length == 0)
            throw new ArgumentException("Input array must be non-empty.");

        n = inputArray.Length;
        data = new int[n];
        Array.Copy(inputArray, data, n);

        // To store segment tree: allocate enough space (4 * n is safe bound)
        tree = new int[4 * n];
        Build(0, 0, n - 1);
    }

    /// <summary>
    /// Recursively build the segment tree.
    /// </summary>
    /// <param name="node">Current tree node index</param>
    /// <param name="start">Start index of segment in original array</param>
    /// <param name="end">End index of segment in original array</param>
    private void Build(int node, int start, int end)
    {
        if (start == end)
        {
            // Leaf node contains a single element
            tree[node] = data[start];
        }
        else
        {
            int mid = start + (end - start) / 2;
            // Build left subtree
            Build(2 * node + 1, start, mid);
            // Build right subtree
            Build(2 * node + 2, mid + 1, end);
            // Internal node value is sum of left + right children
            tree[node] = tree[2 * node + 1] + tree[2 * node + 2];
        }
    }

    /// <summary>
    /// Query the sum of elements in the range [left, right].
    /// </summary>
    /// <param name="left">Left index of query range (inclusive)</param>
    /// <param name="right">Right index of query range (inclusive)</param>
    /// <returns>Sum of the elements in that range</returns>
    public int Query(int left, int right)
    {
        if (left < 0 || right >= n || left > right)
            throw new ArgumentOutOfRangeException("Invalid query range.");

        return Query(0, 0, n - 1, left, right);
    }

    /// <summary>
    /// Internal recursive query function.
    /// </summary>
    private int Query(int node, int start, int end, int left, int right)
    {
        // If segment is completely outside query range
        if (right < start || left > end) return 0;

        // If segment is completely inside query range
        if (left <= start && end <= right) return tree[node];

        // Partial overlap: query both subtrees
        int mid = start + (end - start) / 2;
        int leftSum = Query(2 * node + 1, start, mid, left, right);
        int rightSum = Query(2 * node + 2, mid + 1, end, left, right);

        return leftSum + rightSum;
    }

    /// <summary>
    /// Update the element at index with a new value and update the segment tree accordingly.
    /// </summary>
    /// <param name="index">Index to update</param>
    /// <param name="value">New value to set</param>
    public void Update(int index, int value)
    {
        if (index < 0 || index >= n)
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds.");

        Update(0, 0, n - 1, index, value);
    }

    /// <summary>
    /// Internal recursive update function.
    /// </summary>
    private void Update(int node, int start, int end, int index, int value)
    {
        if (start == end)
        {
            // Leaf node: update both tree and data array
            data[index] = value;
            tree[node] = value;
        }
        else
        {
            int mid = start + (end - start) / 2;
            if (index <= mid)
                Update(2 * node + 1, start, mid, index, value);
            else
                Update(2 * node + 2, mid + 1, end, index, value);

            tree[node] = tree[2 * node + 1] + tree[2 * node + 2];
        }
    }
}